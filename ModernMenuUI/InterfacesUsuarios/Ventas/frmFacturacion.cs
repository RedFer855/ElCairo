using CapaDeAplicacion;
using CapaDominio;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.VisualBasic.ApplicationServices;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Image = System.Drawing.Image;



using CapaDeDatos.Datos;
using CapaDeDatos.Repositorios;
using CapaDeDatos.Modelados.UsuariosEmpleados;
using CapaDeDatos.Modelados;
using CapaDeDatos.Modelados.Inventario;
using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Modelados.Ventas;
using static Supabase.Realtime.PostgresChanges.PostgresChangesOptions;
using Supabase.Realtime;
using Supabase.Realtime.Interfaces;
using Supabase.Realtime.PostgresChanges;
namespace ModernMenuUI
{
    public partial class frmFacturacion : Form
    {
        private readonly ProductoRepositorio _productoRepo;
        private Supabase.Client? _supabaseClient;
        private RealtimeChannel? _productoSubscription;
        private List<Producto> _productosCache = new List<Producto>();
        private InventarioRepositorio _inventarioRepo = new InventarioRepositorio();
        private ClienteRepositorio _clienteRepo = new ClienteRepositorio();
        private List<Cliente> _todosLosClientes = new List<Cliente>(); // La caché
        private Cliente _clienteSeleccionado = null; // Aquí guardaremos al elegido

        public frmFacturacion()
        {
            InitializeComponent();
            // _productoRepo = new ProductoRepositorio();
            _inventarioRepo = new InventarioRepositorio();
            // ===== ESTILO BARRA LATERAL (RowHeader) =====
            dgvProductos.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#DCE6F1");
            dgvProductos.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#57636e");
            dgvProductos.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            clsAnmaciones.ActivarDoubleBuffering(dgvCarrito);
            clsAnmaciones.ActivarDoubleBuffering(dgvProductos);
            txtBuscar.PlaceholderText = "Buscar producto...";
            txtBuscar.ForeColor = Color.Black; // Esto cambia el color del texto normal
            dgvProductos.ClearSelection();
            this.FormClosing += frmFacturacion_FormClosing;
        }


        // FUNCIONES
        private void SeleccionarCliente(Cliente cliente)
        {
            txtCliente.Text = cliente.NombreCliente;
            _clienteSeleccionado = cliente; // ¡IMPORTANTE! Guardamos el objeto
            lstClientes.Visible = false;
            txtCliente.SelectionStart = txtCliente.Text.Length; // Cursor al final
            txtCliente.Focus();
        }

        private async Task DesecharSuscripcionProductosAsync()
        {
            if (_productoSubscription != null)
            {
                try
                {
                    await Task.Run(() => _productoSubscription.Unsubscribe());
                    System.Diagnostics.Debug.WriteLine("Suscripción a Inventario en Facturación desechada.");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error al desuscribir productos en Facturación: {ex.Message}");
                }

                _productoSubscription = null;
            }
        }

        private async Task IniciarSuscripcionProductosAsync()
        {
            await DesecharSuscripcionProductosAsync();

            try
            {
                _supabaseClient = await Conexion.GetClientAsync();

                int idBodega = CapaServiciosSeguridadValidacion.ServicioSesionUsuario.ObtenerIdBodega();

                _productoSubscription = await _supabaseClient
                    .From<Inventario>()
                   .On(ListenType.All, (IRealtimeChannel sender, PostgresChangesResponse change) =>
                   {
                       var modeloCambiado = change.Model<Inventario>();
                       if (modeloCambiado != null && modeloCambiado.IdBodegaInventario != idBodega)
                       {
                           return;
                       }

                       if (!this.IsHandleCreated || this.IsDisposed)
                           return;

                       this.BeginInvoke((MethodInvoker)(async () =>
                       {
                           if (this.IsDisposed) return;

                           System.Diagnostics.Debug.WriteLine("Cambio de stock detectado. Recargando...");

                           await CargarProductosDeBodega();
                       }));
                   });

                System.Diagnostics.Debug.WriteLine($"Suscripción a Inventario (Bodega {idBodega}) iniciada.");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al suscribir inventario: {ex.Message}");
            }
        }

        private void ActualizarTotales()
        {
            decimal subtotal = 0;

            foreach (DataGridViewRow fila in dgvCarrito.Rows)
            {
                if (fila.Cells[2].Value != null && fila.Cells[3].Value != null)
                {
                    decimal precio = Convert.ToDecimal(fila.Cells[2].Value);
                    int cantidad = Convert.ToInt32(fila.Cells[3].Value);

                    subtotal += (precio * cantidad);
                }
            }

            decimal impuesto = subtotal * 0.15m;

            decimal total = subtotal + impuesto;

            txtSubtotal.Text = subtotal.ToString("N2");
            txtImpuesto.Text = impuesto.ToString("N2");
            txtTotal.Text = total.ToString("N2");
        }

        private async Task CargarProductosDeBodega()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // 1. Obtener el ID de la bodega desde la sesión (Login)
                int idBodega = CapaServiciosSeguridadValidacion.ServicioSesionUsuario.ObtenerIdBodega();

                // 2. Obtener SOLO los productos de esa bodega
                _productosCache = await _inventarioRepo.ObtenerProductosDeBodega(idBodega);

                // 3. Mostrar en el Grid
                dgvProductos.DataSource = null;
                dgvProductos.Rows.Clear();

                foreach (var p in _productosCache)
                {
                    dgvProductos.Rows.Add(
                        p.IdProducto,
                        p.NombreProducto,
                        p.PrecioCompra, // O PrecioVenta
                        p.StockEnBodega // <--- ¡OJO! Usamos el stock específico de esta bodega
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void AgregarAlCarrito(int codigoProducto, int cantidadAgregar)
        {
            int limiteProductos = 3;
            int productosActuales = dgvCarrito.Rows.Count;

            // Si ya llegó al límite y el producto no está en el carrito
            bool productoYaExiste = dgvCarrito.Rows
                .Cast<DataGridViewRow>()
                .Any(r => !r.IsNewRow && (int)r.Cells[0].Value == codigoProducto);

            if (productosActuales >= limiteProductos && !productoYaExiste)
            {
                MessageBox.Show(
                    $"Solo puedes agregar hasta {limiteProductos} productos diferentes al carrito.",
                    "Límite alcanzado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return; //  Detiene el método
            }

            Image Eliminar = Properties.Resources.eliminar__1_;
            Image Restar = Properties.Resources.signo_menos__1_;
            Image Sumar = Properties.Resources.mas__2_;

            // Buscar producto en dgvProductos
            DataGridViewRow producto = null;
            for (int i = 0; i < dgvProductos.Rows.Count; i++)
            {
                if ((int)dgvProductos.Rows[i].Cells[0].Value == codigoProducto)
                {
                    producto = dgvProductos.Rows[i];
                    break;
                }
            }

            if (producto == null)
            {
                MessageBox.Show("Producto no encontrado.");
                return;
            }

            string descripcion = producto.Cells[1].Value.ToString();
            decimal precio = Convert.ToDecimal(producto.Cells[2].Value);
            int stock = Convert.ToInt32(producto.Cells[3].Value);

            // Revisar si ya está en el carrito
            for (int i = 0; i < dgvCarrito.Rows.Count; i++)
            {
                if ((int)dgvCarrito.Rows[i].Cells[0].Value == codigoProducto)
                {
                    int cantidadActual = Convert.ToInt32(dgvCarrito.Rows[i].Cells[3].Value);
                    int nuevaCantidad = cantidadActual + cantidadAgregar;

                    if (nuevaCantidad > stock)
                    {
                        dgvCarrito.Rows[i].Cells[3].Value = stock;
                        MessageBox.Show($"Stock insuficiente. Solo hay {stock} unidades disponibles.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                    {
                        dgvCarrito.Rows[i].Cells[3].Value = nuevaCantidad;
                    }

                    return;
                }
            }
            // Si no está en el carrito, agregar nueva fila
            int cantidadFinal = cantidadAgregar;

            if (stock <= 0)
            {
                MessageBox.Show("Este producto está agotado (Stock 0).", "Sin Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Detiene el método aquí, no agrega nada
            }

            if (cantidadFinal > stock)
            {
                cantidadFinal = stock;
                MessageBox.Show($"Stock insuficiente. Solo hay {stock} unidades disponibles.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            dgvCarrito.Rows.Add(codigoProducto, descripcion, precio, cantidadFinal, Eliminar, Restar, Sumar);
        }

        private void LimpiarCarrito()
        {
            dgvCarrito.Rows.Clear();      // borra todos los productos del carrito
            ActualizarTotales();          // deja subtotal, total e impuesto en 0
            ActualizarImagenCarrito();    // muestra la imagen de carrito vacío
            txtCodigo.Text = "";
            txtProducto.Text = "";
            txtPrecio.Text = "";
            nudCantidad.Value = 1;
            dgvProductos.ClearSelection();
        }

        // EVENTOS
        private void lstSugerencias_Leave(object sender, EventArgs e)
        {
            lstSugerencias.Visible = false;
            txtBuscar.Text = "";
        }

        private void lstSugerencias_DoubleClick(object sender, EventArgs e)
        {
            if (lstSugerencias.SelectedItem is Producto producto)
            {
                // Llenar los textbox del producto
                txtCodigo.Text = producto.IdProducto.ToString();
                txtProducto.Text = producto.NombreProducto;
                txtPrecio.Text = producto.PrecioVenta.ToString("N2");

                // Buscar y seleccionar la fila correspondiente en dgvProductos
                foreach (DataGridViewRow fila in dgvProductos.Rows)
                {
                    if (fila.Cells[0].Value != null && (int)fila.Cells[0].Value == producto.IdProducto)
                    {
                        fila.Selected = true;
                        dgvProductos.CurrentCell = fila.Cells[0];
                        break;
                    }
                }

                // Ocultar las sugerencias
                lstSugerencias.Visible = false;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim();

            if (string.IsNullOrWhiteSpace(texto) || _productosCache == null || _productosCache.Count == 0)
            {
                lstSugerencias.Visible = false;
                return;
            }

            // Buscar coincidencias por nombre
            var resultados = _productosCache
                .Where(p => p.NombreProducto.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0)
                .Take(10) // máximo 10 sugerencias
                .ToList();

            if (resultados.Count == 0)
            {
                lstSugerencias.Visible = false;
                return;
            }

            // Cargar sugerencias
            lstSugerencias.DataSource = resultados;
            lstSugerencias.DisplayMember = "NombreProducto";
            lstSugerencias.ValueMember = "IdProducto";
            lstSugerencias.Visible = true;
        }

        private async void frmFacturacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            await DesecharSuscripcionProductosAsync();
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null && dgvProductos.CurrentRow.Selected)
            {
                txtProducto.Text = dgvProductos.CurrentRow.Cells[1].Value.ToString(); // Descripción
                txtPrecio.Text = dgvProductos.CurrentRow.Cells[2].Value.ToString();   // Precio
                txtCodigo.Text = dgvProductos.CurrentRow.Cells[0].Value.ToString();    // Código
            }
            else
            {
                txtProducto.Text = "";
                txtPrecio.Text = "";
                txtCodigo.Text = "";
            }
        }

        private void dgvCarrito_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 4)
            {
                dgvCarrito[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.LightBlue;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            this.Close();
        }

        private void dgvCarrito_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 4)
            {
                dgvCarrito[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;
            }
        }

        private void dgvCarrito_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 5) // columna específica
            {
                dgvCarrito[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Gray; // color oscuro al presionar
            }
        }

        private void dgvCarrito_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvCarrito.RowCount && e.ColumnIndex >= 4 && e.ColumnIndex <= 6 && e.ColumnIndex < dgvCarrito.ColumnCount)
            {
                // Restaurar color si lo necesitas
                dgvCarrito[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;

                // Quitar la selección solo de esa celda
                dgvCarrito[e.ColumnIndex, e.RowIndex].Selected = false;
            }
        }

        private void dgvCarrito_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvCarrito.RowCount)
                return;

            int stock = 0;

            // Obtener el stock del producto desde dgvProductos
            int codigoProducto = Convert.ToInt32(dgvCarrito.Rows[e.RowIndex].Cells[0].Value);
            for (int i = 0; i < dgvProductos.Rows.Count; i++)
            {
                if ((int)dgvProductos.Rows[i].Cells[0].Value == codigoProducto)
                {
                    stock = Convert.ToInt32(dgvProductos.Rows[i].Cells[3].Value);
                    break;
                }
            }

            // Columna eliminar
            if (e.ColumnIndex == 4)
            {
                if (dgvCarrito.CurrentRow != null)
                    dgvCarrito.Rows.Remove(dgvCarrito.CurrentRow);
                ActualizarTotales();
            }

            // Columna restar
            if (e.ColumnIndex == 5)
            {
                int cantidad = Convert.ToInt32(dgvCarrito.Rows[e.RowIndex].Cells[3].Value);
                if (cantidad > 1)
                {
                    dgvCarrito.Rows[e.RowIndex].Cells[3].Value = cantidad - 1;
                    ActualizarTotales();
                }
                else
                {
                    MessageBox.Show("La cantidad no puede ser menor a 1", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }

            // Columna sumar
            if (e.ColumnIndex == 6)
            {
                int cantidad = Convert.ToInt32(dgvCarrito.Rows[e.RowIndex].Cells[3].Value);

                if (cantidad < stock)
                {
                    dgvCarrito.Rows[e.RowIndex].Cells[3].Value = cantidad + 1;
                    ActualizarTotales();
                }
                else
                {
                    MessageBox.Show($"Stock insuficiente. Solo hay {stock} unidades disponibles.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (nudCantidad.Value <= 0)
            {
                MessageBox.Show($"No puede ingresar 0 o negativo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (nudCantidad.Value <= 0 || txtCodigo.Text == "" && txtProducto.Text == "")
                    MessageBox.Show($"Por favor seleccione un Producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    AgregarAlCarrito(Convert.ToInt32(txtCodigo.Text), Convert.ToInt32(nudCantidad.Text));
                nudCantidad.Value = 1;
                txtCodigo.Text = null;
                txtProducto.Text = null;
                dgvProductos.ClearSelection();
                txtPrecio.Text = null;
                ActualizarTotales();
                ActualizarImagenCarrito();
            }

        }

        private void dgvCarrito_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                // Solo recalcular si cambia la columna de cantidad (3) o precio (2)
                if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
                {
                    double precio = Convert.ToDouble(dgvCarrito.Rows[e.RowIndex].Cells[2].Value);
                    double cantidad = Convert.ToDouble(dgvCarrito.Rows[e.RowIndex].Cells[3].Value);
                }
            }
        }

        private void ActualizarImagenCarrito()
        {
            // Si no hay filas visibles (ni productos)
            if (dgvCarrito.Rows.Count == 0)
            {
                pbxCarritoVacio.Visible = true;
                //lblCarritoVacio.Visible = true;
            }
            else
            {
                pbxCarritoVacio.Visible = false;
                //lblCarritoVacio.Visible = false;
            }
        }
        private void lstClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && lstClientes.SelectedItem != null)
            {
                SeleccionarCliente((Cliente)lstClientes.SelectedItem);
            }
        }
        private void txtCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && lstClientes.Visible)
            {
                lstClientes.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (lstClientes.Visible && lstClientes.Items.Count > 0)
                {
                    var cliente = (Cliente)lstClientes.Items[0];
                    SeleccionarCliente(cliente);
                    e.SuppressKeyPress = true;
                }
            }
        }
        private void lstClientes_MouseClick(object sender, MouseEventArgs e)
        {
            if (lstClientes.SelectedItem is Cliente cliente)
            {
                SeleccionarCliente(cliente);
            }
        }
        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Clientes cargados: " + _todosLosClientes.Count);
            string texto = txtCliente.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(texto))
            {
                lstClientes.Visible = false;
                _clienteSeleccionado = null; // Limpiamos si borra el texto
                return;
            }

            // Filtramos la lista en memoria
            var resultados = _todosLosClientes
                .Where(c => c.NombreCliente.ToLower().Contains(texto))
                .ToList();
            if (resultados.Count > 0)
            {
                lstClientes.DataSource = null;
                lstClientes.DataSource = resultados;
                lstClientes.DisplayMember = "NombreCliente";
                lstClientes.ValueMember = "IdCliente";

                // Ajuste visual de altura
                int alturaItem = lstClientes.ItemHeight;
                lstClientes.Height = Math.Min((resultados.Count * alturaItem) + 10, 150);

                lstClientes.Visible = true;
            }
            else
            {
                lstClientes.Visible = false;
            }
        }

        private async void Gestion_de_Ventas_Load(object sender, EventArgs e)
        {
            /* MessageBox.Show($"ID Bodega Actual: {SessionData.IdBodegaActual}\n" +
          $"Método que voy a llamar: CargarProductosDeBodegaAsync",
          "Diagnóstico", MessageBoxButtons.OK, MessageBoxIcon.Information);*/

            await CargarProductosDeBodega();
            // await CargarProductosAsync();
            try
            {
                // Asegúrate de tener _clienteRepo instanciado arriba
                _todosLosClientes = await _clienteRepo.ObtenerTodosLosClientes();

                // Opcional: Mensaje para verificar si cargaron
                // MessageBox.Show($"Se cargaron {_todosLosClientes.Count} clientes."); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
            await IniciarSuscripcionProductosAsync();
            // await CargarRutasAsync();
            //await CargarClientesAsync();
        }
        private Factura CrearFacturaDesdeCarrito()
        {
            Factura factura = new Factura
            {
                NombreEmisor = "Mi Empresa S.A.",
                RTNEmisor = "08011999123999",
                DireccionEmisor = "Tegucigalpa, Honduras",
                FechaEmision = DateTime.Now,
                NumeroFactura = "FAC-001",
                NombreCliente = "Cliente de Prueba",
                RTNCliente = "08011999123998",
                DireccionCliente = "Dirección Cliente"
            };

            foreach (DataGridViewRow row in dgvCarrito.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    ItemFactura item = new ItemFactura
                    {
                        Descripcion = row.Cells[1].Value.ToString(),
                        PrecioUnitario = Convert.ToDecimal(row.Cells[2].Value),
                        Cantidad = Convert.ToInt32(row.Cells[3].Value)
                    };
                    factura.Items.Add(item);
                }
            }

            return factura;
        }

        private async void btnFacturar_Click(object sender, EventArgs e)
        {
            try
            {
                Factura factura = CrearFacturaDesdeCarrito();

                if (!factura.EsValida())
                {
                    MessageBox.Show("La factura no tiene productos o está incompleta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Carpeta segura en Documentos
                string carpeta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Facturas");
                if (!Directory.Exists(carpeta)) Directory.CreateDirectory(carpeta);

                string ruta = Path.Combine(carpeta, $"Factura_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

                // Logo desde recursos
                Image logo = ModernMenuUI.Properties.Resources.buscar;

                // Crear fuentes
                PdfFont fontNormal = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                PdfFont fontBold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                PdfFont fontItalic = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_OBLIQUE);

                // Crear PDF
                using (var fs = new FileStream(ruta, FileMode.Create, FileAccess.Write))
                using (var writer = new PdfWriter(fs))
                using (var pdf = new PdfDocument(writer))
                using (var doc = new iText.Layout.Document(pdf))
                {
                    // Logo
                    if (logo != null)
                    {
                        using (var ms = new MemoryStream())
                        {
                            logo.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            var imgData = iText.IO.Image.ImageDataFactory.Create(ms.ToArray());
                            var img = new iText.Layout.Element.Image(imgData).ScaleToFit(100, 50);
                            doc.Add(img);
                        }
                    }

                    // Título
                    doc.Add(new Paragraph("FACTURA")
                        .SetFont(fontBold)
                        .SetFontSize(18)
                        .SetTextAlignment(TextAlignment.CENTER));
                    doc.Add(new Paragraph(" ")); // espacio

                    // DATOS DEL EMISOR
                    doc.Add(new Paragraph($"Emisor: {factura.NombreEmisor}").SetFont(fontNormal));
                    doc.Add(new Paragraph($"RTN: {factura.RTNEmisor}").SetFont(fontNormal));
                    doc.Add(new Paragraph($"Dirección: {factura.DireccionEmisor}").SetFont(fontNormal));
                    doc.Add(new Paragraph($"Factura N°: {factura.NumeroFactura}").SetFont(fontNormal));
                    doc.Add(new Paragraph($"Fecha: {factura.FechaEmision:dd/MM/yyyy HH:mm}").SetFont(fontNormal));
                    doc.Add(new Paragraph(" ")); // espacio

                    // DATOS DEL CLIENTE
                    doc.Add(new Paragraph($"Cliente: {factura.NombreCliente}").SetFont(fontNormal));
                    doc.Add(new Paragraph($"RTN: {factura.RTNCliente}").SetFont(fontNormal));
                    doc.Add(new Paragraph($"Dirección: {factura.DireccionCliente}").SetFont(fontNormal));
                    doc.Add(new Paragraph(" ")); // espacio

                    // TABLA DE PRODUCTOS
                    Table tabla = new Table(4, true);
                    tabla.AddHeaderCell(new Cell().Add(new Paragraph("Producto").SetFont(fontBold)));
                    tabla.AddHeaderCell(new Cell().Add(new Paragraph("Cantidad").SetFont(fontBold)));
                    tabla.AddHeaderCell(new Cell().Add(new Paragraph("Precio Unitario").SetFont(fontBold)));
                    tabla.AddHeaderCell(new Cell().Add(new Paragraph("Subtotal").SetFont(fontBold)));

                    foreach (var item in factura.Items)
                    {
                        tabla.AddCell(new Cell().Add(new Paragraph(item.Descripcion).SetFont(fontNormal)));
                        tabla.AddCell(new Cell().Add(new Paragraph(item.Cantidad.ToString()).SetFont(fontNormal)));
                        tabla.AddCell(new Cell().Add(new Paragraph(item.PrecioUnitario.ToString("C")).SetFont(fontNormal)));
                        tabla.AddCell(new Cell().Add(new Paragraph((item.Cantidad * item.PrecioUnitario).ToString("C")).SetFont(fontNormal)));
                    }

                    doc.Add(tabla);

                    // TOTAL
                    decimal total = factura.Items.Sum(x => x.Cantidad * x.PrecioUnitario);
                    doc.Add(new Paragraph($"\nTOTAL: {total:C}")
                        .SetFont(fontBold)
                        .SetFontSize(14));

                    // Mensaje final
                    doc.Add(new Paragraph("\nGracias por su compra!").SetFont(fontItalic));

                    doc.Close();
                }

                // Abrir PDF automáticamente
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = ruta,
                    UseShellExecute = true
                });

                MessageBox.Show($"Factura generada correctamente en:\n{ruta}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar la factura:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {/*
            try
            {
                Factura factura = CrearFacturaDesdeCarrito();

                if (!factura.EsValida())
                {
                    MessageBox.Show("La factura no tiene productos o está incompleta.", "Advertencia");
                    return;
                }

                string carpeta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "FacturasTXT");
                if (!Directory.Exists(carpeta)) Directory.CreateDirectory(carpeta);

                string archivo = $"Factura_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
                string ruta = Path.Combine(carpeta, archivo);

                // Configuración de columnas
                int anchoCant = 6;
                int anchoProd = 35;
                int anchoPrecio = 12;

                // Calculos
                decimal subtotal = factura.Items.Sum(x => x.Cantidad * x.PrecioUnitario);
                decimal impuesto = subtotal * 0.15m; // 15% de ISV
                decimal total = subtotal + impuesto;
                decimal pago = 2000; // ejemplo
                decimal cambio = pago - total;

                StringBuilder sb = new StringBuilder();

                // ENCABEZADO
                sb.AppendLine("           Punto de Venta Restaurante - Honduras");
                sb.AppendLine("                  Boulevard Ejemplo Systems");
                sb.AppendLine("                  Tegucigalpa, Honduras");
                sb.AppendLine("                  R.T.N. 08000000000000");
                sb.AppendLine("                     Tel: 0000-0000");
                sb.AppendLine("             Correo Elec.: cliente@ejemplo.com");
                sb.AppendLine();
                sb.AppendLine("                             Venta");
                sb.AppendLine($"Factura {factura.NumeroFactura} Fecha {DateTime.Now:yyyyMMdd}");
                sb.AppendLine("------------------------------------------------------------");

                // Encabezados de columna
                sb.AppendLine("Cant.".PadRight(anchoCant) + "Producto".PadRight(anchoProd) + "Precio L".PadLeft(anchoPrecio));
                sb.AppendLine("------------------------------------------------------------");

                // Productos
                foreach (var item in factura.Items)
                {
                    string nombre = item.Descripcion.Length > anchoProd ? item.Descripcion.Substring(0, anchoProd) : item.Descripcion;
                    sb.AppendLine(item.Cantidad.ToString().PadRight(anchoCant) +
                                  nombre.PadRight(anchoProd) +
                                  (item.Cantidad * item.PrecioUnitario).ToString("N0", new System.Globalization.CultureInfo("es-HN")).PadLeft(anchoPrecio));
                }

                sb.AppendLine("------------------------------------------------------------");

                // Totales
                sb.AppendLine("Subtotal :".PadLeft(anchoCant + anchoProd) + subtotal.ToString("N0", new System.Globalization.CultureInfo("es-HN")).PadLeft(anchoPrecio));
                sb.AppendLine("ISV (15%) :".PadLeft(anchoCant + anchoProd) + impuesto.ToString("N0", new System.Globalization.CultureInfo("es-HN")).PadLeft(anchoPrecio));
                sb.AppendLine("------------------------------------------------------------");
                sb.AppendLine("TOTAL :".PadLeft(anchoCant + anchoProd) + total.ToString("N0", new System.Globalization.CultureInfo("es-HN")).PadLeft(anchoPrecio));
                sb.AppendLine();
                sb.AppendLine("Efectivo :".PadLeft(anchoCant + anchoProd) + pago.ToString("N0", new System.Globalization.CultureInfo("es-HN")).PadLeft(anchoPrecio));
                sb.AppendLine("Cambio   :".PadLeft(anchoCant + anchoProd) + cambio.ToString("N0", new System.Globalization.CultureInfo("es-HN")).PadLeft(anchoPrecio));
                sb.AppendLine("------------------------------------------------------------");
                sb.AppendLine($"         {DateTime.Now:dd/MM/yyyy hh:mm:ss tt}");
                sb.AppendLine("************************************************************");

                // Mensaje al cliente
                sb.AppendLine("Gracias por su compra!");
                sb.AppendLine("Si tiene dudas sobre su factura, por favor contáctenos:");
                sb.AppendLine("Correo: soporte@ejemplo.com");
                sb.AppendLine("Tel: 0000-0000");
                sb.AppendLine("************************************************************");

                File.WriteAllText(ruta, sb.ToString());

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = ruta,
                    UseShellExecute = true
                });

                MessageBox.Show($"Factura TXT generada correctamente en:\n{ruta}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar la factura:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            /*
            Factura factura = CrearFacturaDesdeCarrito();

            if (!factura.EsValida())
            {
                MessageBox.Show("La factura no tiene productos o está incompleta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Logo desde archivo
            Image logo = ModernMenuUI.Properties.Resources.buscar;

            ServicioDeImpresion servicioImpresion = new ServicioDeImpresion();
            servicioImpresion.ImprimirTicket(factura, logo);

            */
        }
    }
}

