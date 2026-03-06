using CapaDeAplicacion;
using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using CapaDeDatos.Modelados.Inventario;
using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Modelados.UsuariosEmpleados;
using CapaDeDatos.Modelados.Ventas;
using CapaDeDatos.Repositorios;
using CapaDeNegocio.Entidades;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.VisualBasic.ApplicationServices;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.Properties;
using ModernMenuUI.ServiciosUI;
using Supabase.Realtime;
using Supabase.Realtime.Interfaces;
using Supabase.Realtime.PostgresChanges;
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
using static Supabase.Postgrest.Constants;
using static Supabase.Realtime.PostgresChanges.PostgresChangesOptions;
using Image = System.Drawing.Image;
namespace ModernMenuUI
{
    public partial class frmFacturacion : Form
    {
        private bool _bloquearSugerencias = false;
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
            _inventarioRepo = new InventarioRepositorio();
            dgvProductos.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#DCE6F1");
            dgvProductos.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#57636e");
            dgvProductos.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            clsAnmaciones.ActivarDoubleBuffering(dgvCarrito);
            clsAnmaciones.ActivarDoubleBuffering(dgvProductos);
            dgvProductos.ClearSelection();
            this.FormClosing += frmFacturacion_FormClosing;
            CargarProductosDeBodega();
        }

        private void SeleccionarCliente(Cliente cliente)
        {
            txtCliente.Text = cliente.NombreCliente;
            _clienteSeleccionado = cliente;
            lstClientes.Visible = false;
            txtCliente.SelectionStart = txtCliente.Text.Length;
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
                int idBodega = CapaServiciosSeguridadValidacion.ServicioSesionUsuario.ObtenerIdBodega();
                _productosCache = await _inventarioRepo.ObtenerProductosDeBodega(idBodega);
                dgvProductos.DataSource = null;
                dgvProductos.Rows.Clear();

                foreach (var p in _productosCache)
                {
                    dgvProductos.Rows.Add(
                        p.IdProducto,
                        p.NombreProducto,
                        p.PrecioCompra,
                        p.StockEnBodega
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
                return;
            }

            Image Eliminar = Properties.Resources.eliminar__1_;
            Image Restar = Properties.Resources.signo_menos__1_;
            Image Sumar = Properties.Resources.mas__2_;

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

            int cantidadFinal = cantidadAgregar;

            if (stock <= 0)
            {
                MessageBox.Show("Este producto está agotado (Stock 0).", "Sin Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
            dgvCarrito.Rows.Clear();
            ActualizarTotales();
            ActualizarImagenCarrito();
            txtCodigo.Text = "";
            txtProducto.Text = "";
            txtPrecio.Text = "";
            nudCantidad.Value = 1;
            dgvProductos.ClearSelection();
        }

        private void lstSugerencias_Leave(object sender, EventArgs e)
        {
            lstSugerencias.Visible = false;
            txtBuscar.Text = "";
        }

        private void lstSugerencias_DoubleClick(object sender, EventArgs e)
        {
            if (lstSugerencias.SelectedItem is Producto producto)
            {

                txtCodigo.Text = producto.IdProducto.ToString();
                txtProducto.Text = producto.NombreProducto;
                txtPrecio.Text = producto.PrecioVenta.ToString("N2");


                foreach (DataGridViewRow fila in dgvProductos.Rows)
                {
                    if (fila.Cells[0].Value != null && (int)fila.Cells[0].Value == producto.IdProducto)
                    {
                        fila.Selected = true;
                        dgvProductos.CurrentCell = fila.Cells[0];
                        break;
                    }
                }

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

            var resultados = _productosCache
                .Where(p => p.NombreProducto.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0)
                .Take(10)
                .ToList();

            if (resultados.Count == 0)
            {
                lstSugerencias.Visible = false;
                return;
            }

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
                txtProducto.Text = dgvProductos.CurrentRow.Cells[1].Value.ToString();
                txtPrecio.Text = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                txtCodigo.Text = dgvProductos.CurrentRow.Cells[0].Value.ToString();
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
            if (e.RowIndex >= 0 && e.ColumnIndex == 5)
            {
                dgvCarrito[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Gray;
            }
        }

        private void dgvCarrito_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvCarrito.RowCount && e.ColumnIndex >= 4 && e.ColumnIndex <= 6 && e.ColumnIndex < dgvCarrito.ColumnCount)
            {
                dgvCarrito[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;
                dgvCarrito[e.ColumnIndex, e.RowIndex].Selected = false;
            }
        }

        private void dgvCarrito_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvCarrito.RowCount)
                return;

            int stock = 0;

            int codigoProducto = Convert.ToInt32(dgvCarrito.Rows[e.RowIndex].Cells[0].Value);
            for (int i = 0; i < dgvProductos.Rows.Count; i++)
            {
                if ((int)dgvProductos.Rows[i].Cells[0].Value == codigoProducto)
                {
                    stock = Convert.ToInt32(dgvProductos.Rows[i].Cells[3].Value);
                    break;
                }
            }

            if (e.ColumnIndex == 4)
            {
                if (dgvCarrito.CurrentRow != null)
                    dgvCarrito.Rows.Remove(dgvCarrito.CurrentRow);
                ActualizarTotales();
            }

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
                if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
                {
                    double precio = Convert.ToDouble(dgvCarrito.Rows[e.RowIndex].Cells[2].Value);
                    double cantidad = Convert.ToDouble(dgvCarrito.Rows[e.RowIndex].Cells[3].Value);
                }
            }
        }

        private void ActualizarImagenCarrito()
        {
            if (dgvCarrito.Rows.Count == 0)
            {
                pbxCarritoVacio.Visible = true;

            }
            else
            {
                pbxCarritoVacio.Visible = false;
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
            if (_bloquearSugerencias)
                return;

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
            
            
            try
            {
                _todosLosClientes = await _clienteRepo.ObtenerTodosLosClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
            await IniciarSuscripcionProductosAsync();
        }
        private Factura CrearFacturaDesdeCarrito()
        {
            Factura factura = new Factura
            {
                NombreEmisor = "El Cairo S.A.",
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
            if (dgvCarrito.Rows.Count == 0)
            {
                MessageBox.Show("El carrito está vacío. Agregue productos para facturar.",
                                "Carrito Vacio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_clienteSeleccionado == null)
            {
                MessageBox.Show("Debe buscar y seleccionar un Cliente.",
                                "Falta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCliente.Focus();
                return;
            }

            int idBodegaVenta = CapaServiciosSeguridadValidacion.ServicioSesionUsuario.ObtenerIdBodega();
            if (idBodegaVenta == -1)
            {
                MessageBox.Show("Error de Sesión: No se detecta la bodega actual.",
                                "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FacturaReportService servicio = new FacturaReportService();
            servicio.MostrarFacturaAsync();
            LimpiarCarrito();
        }

        private void btnImprimirCotizacion_Click(object sender, EventArgs e)
        {
            /*
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

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            frmClientes selector = new frmClientes(true);

            if (selector.ShowDialog() == DialogResult.OK)
            {
                Cliente seleccionado = selector._clienteSeleccionadoFinal;

                if (seleccionado != null)
                {
                    _bloquearSugerencias = true;
                    txtCliente.Text = seleccionado.NombreCliente;
                    _clienteSeleccionado = seleccionado;

                    lstClientes.Visible = false;
                    _bloquearSugerencias = false;
                }
            }
        }

        private void panelCarrito_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

