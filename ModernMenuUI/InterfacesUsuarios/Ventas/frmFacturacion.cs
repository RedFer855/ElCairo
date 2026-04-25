using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using CapaDeDatos.Modelados.Inventario;
using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Modelados.UsuariosEmpleados;
using CapaDeDatos.Modelados.Ventas;
using CapaDeDatos.Repositorios;
using CapaDominio;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using ModernMenuUI.ClasesUI;
using Supabase.Realtime.PostgresChanges;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Supabase.Postgrest.Constants;
using Image = System.Drawing.Image;

namespace ModernMenuUI
{
    public partial class frmFacturacion : Form
    {
        // =========================================================
        // CAMPOS
        // =========================================================
        private readonly InventarioRepositorio _inventarioRepo = new InventarioRepositorio();
        private readonly ClienteRepositorio _clienteRepo = new ClienteRepositorio();
        private readonly CarritoManager _carrito = new CarritoManager();

        private bool _bloquearSugerencias = false;
        private List<Cliente> _todosLosClientes = new List<Cliente>();
        private Cliente _clienteSeleccionado = null;

        // Debounce + cancelación para buscador
        private readonly System.Windows.Forms.Timer _timerDebounce;
        private CancellationTokenSource _ctsSugerencias;

        // Panel de detalle
        private Producto _productoEnDetalle;
        private readonly HttpClient _httpClient = new HttpClient();

        // =========================================================
        // CONSTRUCTOR
        // =========================================================
        public frmFacturacion()
        {
            InitializeComponent();

            clsAnmaciones.ActivarDoubleBuffering(dgvCarrito);
            txtBuscar.PlaceholderText = "Buscar producto o escanear código...";

            // Debounce 350ms para sugerencias
            _timerDebounce = new System.Windows.Forms.Timer { Interval = 350 };
            _timerDebounce.Tick += TimerDebounce_Tick;

            // Suscribir CarritoManager al grid
            _carrito.CarritoCambiado += (s, e) =>
            {
                ActualizarGridCarrito();
                ActualizarTotales();
                ActualizarImagenCarrito();
            };

            this.FormClosing += frmFacturacion_FormClosing;
        }

        // =========================================================
        // CARGA INICIAL
        // =========================================================
        // =========================================================
        // CARGA INICIAL
        // =========================================================
        private async void Gestion_de_Ventas_Load(object sender, EventArgs e)
        {
            try
            {
                _todosLosClientes = await _clienteRepo.ObtenerTodosLosClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }

            // Suscribir evento de la barra: agregar al carrito al clickear
            barraProductos.ProductoSeleccionado += (s, producto) =>
            {
                var resultado = _carrito.AgregarProducto(producto, (int)nudCantidad.Value);
                if (resultado != ResultadoCarrito.Exitoso)
                    ManejarResultadoCarrito(resultado, producto);
            };

            // Cargar top 20 más vendidos de esta bodega
            int idBodega = CapaServiciosSeguridadValidacion
                .ServicioSesionUsuario.ObtenerIdBodega();
            await barraProductos.CargarMasVendidosAsync(idBodega, 20);
        }

        private void frmFacturacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _timerDebounce?.Stop();
                _timerDebounce?.Dispose();
                _ctsSugerencias?.Cancel();
                _ctsSugerencias?.Dispose();
                _httpClient?.Dispose();
            }
            catch { }
        }

        // =========================================================
        // BUSCADOR CON SCANNER Y SUGERENCIAS
        // =========================================================
        private async void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _timerDebounce.Stop();
                string texto = txtBuscar.Text?.Trim();
                if (string.IsNullOrEmpty(texto)) return;

                int idBodega = CapaServiciosSeguridadValidacion
                    .ServicioSesionUsuario.ObtenerIdBodega();

                bool esCodigo = texto.All(char.IsDigit)
                                && texto.Length >= 8
                                && texto.Length <= 13;

                if (esCodigo)
                {
                    lstSugerencias.Visible = false;
                    var producto = await _inventarioRepo
                        .BuscarPorCodigoBarraEnBodegaAsync(texto, idBodega);

                    if (producto != null)
                    {
                        var resultado = _carrito.AgregarProducto(producto, (int)nudCantidad.Value);
                        if (resultado != ResultadoCarrito.Exitoso)
                            ManejarResultadoCarrito(resultado, producto);
                    }
                    else
                    {
                        MessageBox.Show("Producto no encontrado en esta bodega.",
                            "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    txtBuscar.Clear();
                    txtBuscar.Focus();
                    return;
                }

                // Es texto: si hay sugerencia seleccionada, mostrar detalle
                if (lstSugerencias.Visible && lstSugerencias.SelectedItem is Producto pSugerido)
                {
                    lstSugerencias.Visible = false;
                    txtBuscar.Clear();
                    await MostrarDetalleProductoAsync(pSugerido);
                }

                // Si es texto sin sugerencia seleccionada: no hacer nada
                return;
            }

            // Flecha abajo: navegar a sugerencias
            if (e.KeyCode == Keys.Down && lstSugerencias.Visible
                && lstSugerencias.Items.Count > 0)
            {
                lstSugerencias.Focus();
                lstSugerencias.SelectedIndex = 0;
                return;
            }

            // Escape: cerrar sugerencias
            if (e.KeyCode == Keys.Escape)
            {
                lstSugerencias.Visible = false;
                return;
            }

            // Otras teclas: debounce para sugerencias
            _timerDebounce.Stop();
            _timerDebounce.Start();
        }

        private async void TimerDebounce_Tick(object sender, EventArgs e)
        {
            _timerDebounce.Stop();
            string texto = txtBuscar.Text?.Trim();

            // Si no hay texto: volver a mostrar los más vendidos
            if (string.IsNullOrEmpty(texto))
            {
                int idBodega = CapaServiciosSeguridadValidacion
                    .ServicioSesionUsuario.ObtenerIdBodega();
                await barraProductos.CargarMasVendidosAsync(idBodega, 20);
                return;
            }

            _ctsSugerencias?.Cancel();
            _ctsSugerencias?.Dispose();
            _ctsSugerencias = new CancellationTokenSource();

            try
            {
                int idBodega = CapaServiciosSeguridadValidacion
                    .ServicioSesionUsuario.ObtenerIdBodega();

                var sugerencias = await _inventarioRepo
                    .ObtenerSugerenciasBodegaAsync(
                        texto, idBodega, 20, _ctsSugerencias.Token);

                if (_ctsSugerencias.IsCancellationRequested) return;

                lstSugerencias.DataSource = null;
                lstSugerencias.DataSource = sugerencias;
                lstSugerencias.DisplayMember = "NombreCompleto";
                lstSugerencias.Visible = sugerencias.Count > 0;
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error sugerencias: " + ex.Message);
            }
        }

        private async void lstSugerencias_DoubleClick(object sender, EventArgs e)
        {
            if (lstSugerencias.SelectedItem is Producto producto)
            {
                lstSugerencias.Visible = false;
                txtBuscar.Clear();
                await MostrarDetalleProductoAsync(producto);
            }
        }

        private async void lstSugerencias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && lstSugerencias.SelectedItem is Producto p)
            {
                lstSugerencias.Visible = false;
                txtBuscar.Clear();
                txtBuscar.Focus();
                await MostrarDetalleProductoAsync(p);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                lstSugerencias.Visible = false;
                txtBuscar.Focus();
            }
        }

        private async void txtBuscar_Leave(object sender, EventArgs e)
        {
            await Task.Delay(200);
            if (!this.IsDisposed && !lstSugerencias.Focused)
                lstSugerencias.Visible = false;
        }

        // =========================================================
        // CARRITO — Grid y totales
        // =========================================================
        private void ActualizarGridCarrito()
        {
            dgvCarrito.Rows.Clear();

            foreach (var item in _carrito.Items)
            {
                dgvCarrito.Rows.Add(
                    item.CodigoBarra,
                    item.NombreProducto,
                    item.PrecioVenta,
                    item.Cantidad,
                    Properties.Resources.eliminar__1_,
                    Properties.Resources.signo_menos__1_,
                    Properties.Resources.mas__2_
                );
            }
        }

        private void ActualizarTotales()
        {
            txtSubtotal.Text = _carrito.Subtotal.ToString("N2");
            txtImpuesto.Text = _carrito.ISV.ToString("N2");
            txtTotal.Text = _carrito.Total.ToString("N2");
        }

        private void ActualizarImagenCarrito()
        {
            pbxCarritoVacio.Visible = _carrito.EstaVacio;
        }

        private void LimpiarCarrito()
        {
            _carrito.Limpiar();
            txtCodigo.Text = "";
            txtProducto.Text = "";
            txtPrecio.Text = "";
            nudCantidad.Value = 1;
        }

        // =========================================================
        // EVENTOS DEL CARRITO (botones eliminar/restar/sumar)
        // =========================================================
        private async void dgvCarrito_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvCarrito.RowCount) return;

            string codigoBarra = dgvCarrito.Rows[e.RowIndex].Cells[0].Value?.ToString();
            if (string.IsNullOrEmpty(codigoBarra)) return;

            // Eliminar
            if (e.ColumnIndex == 4)
            {
                _carrito.Eliminar(codigoBarra);
            }
            // Restar
            else if (e.ColumnIndex == 5)
            {
                if (!_carrito.ModificarCantidad(codigoBarra, -1))
                    MessageBox.Show("La cantidad no puede ser menor a 1.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // Sumar
            else if (e.ColumnIndex == 6)
            {
                if (!_carrito.ModificarCantidad(codigoBarra, +1))
                    MessageBox.Show("Stock insuficiente.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // Columnas de datos: mostrar detalle del producto
            else if (e.ColumnIndex >= 0 && e.ColumnIndex <= 3)
            {
                int idBodega = CapaServiciosSeguridadValidacion
                    .ServicioSesionUsuario.ObtenerIdBodega();
                var producto = await _inventarioRepo
                    .BuscarPorCodigoBarraEnBodegaAsync(codigoBarra, idBodega);
                await MostrarDetalleProductoAsync(producto);
            }
        }

        private void dgvCarrito_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 4)
                dgvCarrito[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.LightBlue;
        }

        private void dgvCarrito_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 4)
                dgvCarrito[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;
        }

        private void dgvCarrito_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 5)
                dgvCarrito[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Gray;
        }

        private void dgvCarrito_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvCarrito.RowCount
                && e.ColumnIndex >= 4 && e.ColumnIndex <= 6)
            {
                dgvCarrito[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;
                dgvCarrito[e.ColumnIndex, e.RowIndex].Selected = false;
            }
        }

        private void dgvCarrito_CellValueChanged(object sender, DataGridViewCellEventArgs e) { }
        private void dgvCarrito_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        // =========================================================
        // CLIENTES
        // =========================================================
        private void SeleccionarCliente(Cliente cliente)
        {
            txtCliente.Text = cliente.NombreCliente;
            _clienteSeleccionado = cliente;
            lstClientes.Visible = false;
            txtCliente.SelectionStart = txtCliente.Text.Length;
            txtCliente.Focus();
        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            if (_bloquearSugerencias) return;

            string texto = txtCliente.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(texto))
            {
                lstClientes.Visible = false;
                _clienteSeleccionado = null;
                return;
            }

            var resultados = _todosLosClientes
                .Where(c => c.NombreCliente.ToLower().Contains(texto))
                .ToList();

            if (resultados.Count > 0)
            {
                lstClientes.DataSource = null;
                lstClientes.DataSource = resultados;
                lstClientes.DisplayMember = "NombreCliente";
                lstClientes.ValueMember = "IdCliente";
                lstClientes.Height = Math.Min(
                    (resultados.Count * lstClientes.ItemHeight) + 10, 150);
                lstClientes.Visible = true;
            }
            else
            {
                lstClientes.Visible = false;
            }
        }

        private void txtCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && lstClientes.Visible)
                lstClientes.Focus();
            else if (e.KeyCode == Keys.Enter && lstClientes.Visible
                     && lstClientes.Items.Count > 0)
            {
                SeleccionarCliente((Cliente)lstClientes.Items[0]);
                e.SuppressKeyPress = true;
            }
        }

        private void lstClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && lstClientes.SelectedItem != null)
                SeleccionarCliente((Cliente)lstClientes.SelectedItem);
        }

        private void lstClientes_MouseClick(object sender, MouseEventArgs e)
        {
            if (lstClientes.SelectedItem is Cliente cliente)
                SeleccionarCliente(cliente);
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            using (var selector = new frmClientes(true))
            {
                if (selector.ShowDialog() == DialogResult.OK
                    && selector._clienteSeleccionadoFinal != null)
                {
                    _bloquearSugerencias = true;
                    txtCliente.Text = selector._clienteSeleccionadoFinal.NombreCliente;
                    _clienteSeleccionado = selector._clienteSeleccionadoFinal;
                    lstClientes.Visible = false;
                    _bloquearSugerencias = false;
                }
            }
        }

        // =========================================================
        // FACTURAR
        // =========================================================
        private async void btnFacturar_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (_carrito.EstaVacio)
            {
                MessageBox.Show("El carrito está vacío.",
                    "Carrito Vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_clienteSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un cliente.",
                    "Falta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCliente.Focus();
                return;
            }

            int idBodegaVenta = CapaServiciosSeguridadValidacion
                .ServicioSesionUsuario.ObtenerIdBodega();

            if (idBodegaVenta == -1)
            {
                MessageBox.Show("Error de sesión: no se detecta la bodega.",
                    "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                var supabase = await Conexion.GetClientAsync();
                var usuarioAuth = supabase.Auth.CurrentUser;

                if (usuarioAuth == null)
                    throw new Exception("No hay usuario autenticado.");

                var respEmpleado = await supabase
                    .From<Usuario>()
                    .Select("id_empleado")
                    .Filter("user_id", Operator.Equals, usuarioAuth.Id)
                    .Get();

                if (respEmpleado.Models == null || !respEmpleado.Models.Any())
                    throw new Exception("El usuario no tiene empleado vinculado.");

                int idEmpleado = respEmpleado.Models.First().IdUsuario;

                // Detalles desde CarritoManager (usa IdProducto para el RPC)
                var detallesVenta = _carrito.Items.Select(item => new
                {
                    id_producto = item.IdProducto,
                    cantidad_venta = item.Cantidad,
                    id_bodega = idBodegaVenta
                }).ToList();

                var parametros = new
                {
                    p_id_cliente = _clienteSeleccionado.IdCliente,
                    p_id_rutas = (int?)null,
                    p_id_empleado = idEmpleado,
                    p_fecha_venta = DateTime.UtcNow,
                    p_detalles = detallesVenta,
                    p_nombre_host = Environment.UserName,
                    p_computadora_host = Environment.MachineName
                };

                // DEBUG TEMPORAL
                System.Diagnostics.Debug.WriteLine("=== DETALLES VENTA ===");
                foreach (var d in detallesVenta)
                    System.Diagnostics.Debug.WriteLine($"IdProducto={d.id_producto}, Cantidad={d.cantidad_venta}, IdBodega={d.id_bodega}");

                await supabase.Rpc("registrar_venta", parametros);

                // Generar PDF
                Factura factura = CrearFacturaDesdeCarrito();
                factura.NombreCliente = _clienteSeleccionado.NombreCliente;
                factura.RTNCliente = _clienteSeleccionado.DniCliente;
                factura.DireccionCliente = _clienteSeleccionado.DireccionCliente;

                string carpeta = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "Facturas");
                Directory.CreateDirectory(carpeta);
                string ruta = Path.Combine(carpeta,
                    $"Factura_{DateTime.Now:yyyyMMdd_HHmmss}_{Guid.NewGuid().ToString()[..6]}.pdf");

                await GenerarPDFFacturaAsync(factura, ruta);

                MessageBox.Show(
                    $"¡Venta registrada para {_clienteSeleccionado.NombreCliente}!",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al facturar:\n\n{ex.Message}",
                    "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                nudCantidad.Value = 1;
                LimpiarCarrito();
                txtCliente.Text = "";
                txtImpuesto.Text = "0.00";
                txtSubtotal.Text = "0.00";
                txtTotal.Text = "0.00";
                _clienteSeleccionado = null;
            }
        }

        // =========================================================
        // PDF (sin cambios por ahora — Fase 7 la mueve a su clase)
        // =========================================================
        private Factura CrearFacturaDesdeCarrito()
        {
            var factura = new Factura
            {
                NombreEmisor = "El Cairo S.A.",
                RTNEmisor = "08011999123999",
                DireccionEmisor = "Tegucigalpa, Honduras",
                FechaEmision = DateTime.Now,
                NumeroFactura = "FAC-001"
            };

            foreach (var item in _carrito.Items)
            {
                factura.Items.Add(new ItemFactura
                {
                    Descripcion = item.NombreProducto,
                    PrecioUnitario = item.PrecioVenta,
                    Cantidad = item.Cantidad
                });
            }

            return factura;
        }

        private async Task GenerarPDFFacturaAsync(Factura factura, string ruta)
        {
            await Task.Run(() =>
            {
                var culture = new CultureInfo("es-HN");
                var fontNormal = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                var fontBold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                var fontItalic = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_OBLIQUE);
                Image logo = Properties.Resources.logo_ElCairo;

                using var ms = new MemoryStream();
                using var writer = new PdfWriter(ms);
                using var pdf = new PdfDocument(writer);
                using var doc = new Document(pdf, iText.Kernel.Geom.PageSize.A4);

                doc.SetMargins(20, 20, 20, 20);

                if (logo != null)
                {
                    try
                    {
                        using var lms = new MemoryStream();
                        logo.Save(lms, System.Drawing.Imaging.ImageFormat.Png);
                        doc.Add(new iText.Layout.Element.Image(
                            iText.IO.Image.ImageDataFactory.Create(lms.ToArray()))
                            .ScaleToFit(120, 60));
                    }
                    catch { }
                }

                doc.Add(new Paragraph("FACTURA")
                    .SetFont(fontBold).SetFontSize(20)
                    .SetTextAlignment(TextAlignment.CENTER));

                doc.Add(new Paragraph($"Cliente: {factura.NombreCliente}").SetFont(fontNormal));
                doc.Add(new Paragraph($"RTN: {factura.RTNCliente}").SetFont(fontNormal));
                doc.Add(new Paragraph($"Dirección: {factura.DireccionCliente}").SetFont(fontNormal));
                doc.Add(new Paragraph(" "));

                // Tabla con código de barras incluido
                var t = new Table(UnitValue.CreatePercentArray(
                    new float[] { 20, 40, 10, 15, 15 }))
                    .UseAllAvailableWidth();

                t.AddHeaderCell("Código");
                t.AddHeaderCell("Producto");
                t.AddHeaderCell("Cant.");
                t.AddHeaderCell("Precio");
                t.AddHeaderCell("Total");

                foreach (var item in factura.Items)
                {
                    t.AddCell(item.CodigoBarra ?? "");
                    t.AddCell(item.Descripcion);
                    t.AddCell(item.Cantidad.ToString());
                    t.AddCell(item.PrecioUnitario.ToString("C", culture));
                    t.AddCell(item.TotalLinea.ToString("C", culture));
                }

                doc.Add(t);
                doc.Add(new Paragraph($"\nSubtotal: {factura.SubTotal.ToString("C", culture)}"));
                doc.Add(new Paragraph($"ISV (15%): {factura.ISV.ToString("C", culture)}"));
                doc.Add(new Paragraph($"TOTAL: {factura.Total.ToString("C", culture)}").SetFont(fontBold));
                doc.Add(new Paragraph("\nGracias por su compra!")
                    .SetFont(fontItalic).SetTextAlignment(TextAlignment.CENTER));
                doc.Close();

                File.WriteAllBytes(ruta, ms.ToArray());

                try
                {
                    System.Diagnostics.Process.Start(
                        new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = ruta,
                            UseShellExecute = true
                        });
                }
                catch { }
            });
        }

        // =========================================================
        // DETALLE DE PRODUCTO
        // =========================================================
        private void ManejarResultadoCarrito(ResultadoCarrito resultado, Producto p)
        {
            switch (resultado)
            {
                case ResultadoCarrito.AjustadoAlStock:
                    var item = _carrito.Items.FirstOrDefault(i => i.CodigoBarra == p.CodigoBarraProducto);
                    MessageBox.Show(
                        $"Solo hay {p.StockEnBodega} unidades disponibles.\nSe ajustó la cantidad a {item?.Cantidad}.",
                        "Stock ajustado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case ResultadoCarrito.SinStock:
                    MessageBox.Show($"'{p.NombreProducto}' está agotado en esta bodega.",
                        "Sin Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case ResultadoCarrito.LimiteAlcanzado:
                    MessageBox.Show("El carrito alcanzó el límite de productos.",
                        "Límite", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        private async Task MostrarDetalleProductoAsync(Producto p)
        {
            if (p == null)
            {
                _productoEnDetalle = null;
                lblSinSeleccion.Visible = true;
                pbxDetalleImagen.Visible = false;
                lblDetalleNombre.Visible = false;
                lblDetalleMarca.Visible = false;
                lblDetallePrecio.Visible = false;
                lblDetalleStock.Visible = false;
                lblDetalleCodigo.Visible = false;
                btnDetalleAgregar.Visible = false;
                return;
            }

            _productoEnDetalle = p;
            lblSinSeleccion.Visible = false;
            pbxDetalleImagen.Visible = true;
            lblDetalleNombre.Visible = true;
            lblDetalleMarca.Visible = true;
            lblDetallePrecio.Visible = true;
            lblDetalleStock.Visible = true;
            lblDetalleCodigo.Visible = true;
            btnDetalleAgregar.Visible = true;

            lblDetalleNombre.Text = p.NombreCompleto;
            lblDetalleMarca.Text = p.Marca?.NombreMarca ?? p.NombreMarcaCache ?? "Sin Marca";
            lblDetallePrecio.Text = p.PrecioVenta.ToString("C", new CultureInfo("es-HN"));
            lblDetalleStock.Text = $"Stock: {p.StockEnBodega}";
            lblDetalleCodigo.Text = p.CodigoBarraProducto;
            btnDetalleAgregar.Enabled = p.StockEnBodega > 0;

            pbxDetalleImagen.Image = null;

            try
            {
                string url = await ImagenHelper.ObtenerUrlPublicaAsync(p.ImagenProducto);

                if (string.IsNullOrEmpty(url))
                {
                    pbxDetalleImagen.Image = Properties.Resources.sin_imagen;
                    return;
                }

                var bytes = await _httpClient.GetByteArrayAsync(url);
                using var ms = new MemoryStream(bytes);

                pbxDetalleImagen.Image = new Bitmap(ms);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                pbxDetalleImagen.Image = Properties.Resources.sin_imagen;
            }
        }

        private void btnDetalleAgregar_Click(object sender, EventArgs e)
        {
            if (_productoEnDetalle == null) return;
            var resultado = _carrito.AgregarProducto(_productoEnDetalle, (int)nudCantidad.Value);
            if (resultado != ResultadoCarrito.Exitoso)
                ManejarResultadoCarrito(resultado, _productoEnDetalle);
        }

        // =========================================================
        // OTROS
        // =========================================================
        private void btnSalir_Click(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            this.Close();
        }
    }
}