using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion.CapaServiciosSeguridadValidacion; // Añadido para el monitor
using Supabase; // Añadido
using Supabase.Realtime; // Añadido
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading; // Añadido para CancellationTokenSource
using System.Threading.Tasks;
using System.Windows.Forms;
using static Supabase.Realtime.PostgresChanges.PostgresChangesOptions; // Añadido
using static Supabase.Postgrest.Constants;
using System.Text.Json;


namespace ModernMenuUI
{
    public partial class frmGestionCompra : Form
    {

        private readonly ProductoRepositorio productoRepositorio;
        private Producto ProductoSeleccionado;


        private List<Producto> _listaMaestraProductos = new List<Producto>(); // <-- Tu lista, renombrada
        private Supabase.Realtime.RealtimeChannel? _productosSubscription;
        private readonly ServicioVerificacionConexion _monitorConexion = new ServicioVerificacionConexion();
        private Supabase.Client? _supabaseClient;

        public frmGestionCompra()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            // ===== ESTILO BARRA LATERAL (RowHeader) =====
            dgvProductos.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#DCE6F1");
            dgvProductos.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#57636e");
            dgvProductos.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            productoRepositorio = new ProductoRepositorio();
            dgvProductos.AutoGenerateColumns = false;
            //dgvProductos.Rows.Clear(); // Limpia las filas actuales

            //dgvProductos.DefaultCellStyle.ForeColor = Color.DimGray;
            /*
                        dgvProductos.Rows.Add(1, "Manzana", 10, 20);
                        dgvProductos.Rows.Add(2, "Pan", 5, 43);
                        dgvProductos.Rows.Add(3, "Leche", 8, 70);
                        dgvProductos.Rows.Add(4, "Pera", 10, 29);
                        dgvProductos.Rows.Add(5, "Semitas", 5, 89);
                        dgvProductos.Rows.Add(6, "Ensure", 8, 48);
                        dgvProductos.Rows.Add(7, "Bolsa de Frijoles", 8, 90);*/
        }
        private async void frmGestionCompra_Load(object sender, EventArgs e)
        {

            _monitorConexion.EstadoDeRedCambiado += MonitorConexion_EstadoDeRedCambiado;


            await CargarProductosMaestros();

            RefrescarGrid();
            await IniciarSuscripcionProductos();

        }
        private async Task CargarProductosMaestros()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.Cursor = Cursors.WaitCursor;

                // Carga TODOS los productos a tu lista de memoria
                // Llamada original con un solo argumento (null = todos)
                _listaMaestraProductos = await productoRepositorio.ObtenerActivos(true);
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("No se pudo conectar con el servidor (tiempo de espera agotado).", "Error de Red", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar productos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void RefrescarGrid()
        {
            this.Cursor = Cursors.WaitCursor;
            bool? estado = true;

            // 2. Filtrar la LISTA MAESTRA en memoria (LINQ)
            var listaFiltrada = _listaMaestraProductos
            .Where(p => p.EstadoProducto == estado)
            .ToList();

            // 3. Asigna los datos filtrados al DataGridView
            dgvProductos.DataSource = listaFiltrada;

            if (dgvProductos.Rows.Count > 0)
                dgvProductos.ClearSelection();

            this.Cursor = Cursors.Default;
        }
        private async Task DesecharSuscripcion()
        {
            if (_productosSubscription != null)
            {
                try
                {
                    await Task.Run(() => _productosSubscription.Unsubscribe());
                    System.Diagnostics.Debug.WriteLine("Suscripción de Productos desechada.");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error al desechar suscripción Productos: {ex.Message}");
                }
                _productosSubscription = null;
            }
        }

        private async Task IniciarSuscripcionProductos()
        {
            await DesecharSuscripcion();

            try
            {
                _supabaseClient = await Conexion.ConnectWithTimeoutAsync(3);

                _productosSubscription = await _supabaseClient.From<Producto>()
                    .On(ListenType.All, (sender, change) =>
                    {
                        try
                        {
                            if (this == null || this.IsDisposed || !this.IsHandleCreated) return;

                            this.BeginInvoke((MethodInvoker)(async () =>
                            {
                                if (this.IsDisposed) return;
                                System.Diagnostics.Debug.WriteLine($"Cambio detectado: {change.Event} en Productos.");

                                // 1. Vuelve a cargar la lista maestra
                                await CargarProductosMaestros();
                                // 2. Refresca el grid con los filtros actuales
                                RefrescarGrid();
                            }));
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"Error manejando evento Realtime Productos: {ex.Message}");
                        }
                    });

                System.Diagnostics.Debug.WriteLine("Suscripción a Realtime (Productos) creada.");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al suscribir a Realtime (Productos): {ex.Message}");
            }
        }

        private async void MonitorConexion_EstadoDeRedCambiado(NetworkStatus status)
        {
            if (!this.IsHandleCreated || this.IsDisposed) return;

            if (status == NetworkStatus.Internet)
            {
                this.BeginInvoke((MethodInvoker)(async () =>
                {
                    if (this.IsDisposed) return;
                    System.Diagnostics.Debug.WriteLine("Red recuperada. Recargando Productos y Realtime...");
                    await CargarProductosMaestros();
                    RefrescarGrid();
                    await IniciarSuscripcionProductos();
                }));
            }
        }
        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null && dgvProductos.CurrentRow.Selected)
            {
                txtCodigo.Text = dgvProductos.CurrentRow.Cells[0].Value.ToString();    // Código
                txtProducto.Text = dgvProductos.CurrentRow.Cells[1].Value.ToString(); // Descripción
                txtPrecio.Text = dgvProductos.CurrentRow.Cells[4].Value.ToString();   // Precio
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

            // Columna eliminar (4)
            if (e.ColumnIndex == 4)
            {
                if (dgvCarrito.CurrentRow != null)
                    dgvCarrito.Rows.RemoveAt(e.RowIndex);
                return;
            }

            // Columna restar (5)
            if (e.ColumnIndex == 5)
            {
                if (int.TryParse(dgvCarrito.Rows[e.RowIndex].Cells[3].Value?.ToString(), out int cantidad))
                {
                    if (cantidad > 1)
                        dgvCarrito.Rows[e.RowIndex].Cells[3].Value = cantidad - 1;
                    else
                        MessageBox.Show("La cantidad no puede ser menor a 1", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return;
            }

            // Columna sumar (6)
            if (e.ColumnIndex == 6)
            {
                if (int.TryParse(dgvCarrito.Rows[e.RowIndex].Cells[3].Value?.ToString(), out int cantidad))
                {
                    if (cantidad < 400)
                        dgvCarrito.Rows[e.RowIndex].Cells[3].Value = cantidad + 1;
                    else
                        MessageBox.Show("La cantidad máxima por producto es 400.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return;
            }
        }
       

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (nudCantidad.Value <= 0)
            {
                MessageBox.Show("No puede ingresar 0 o negativo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } else if (nudCantidad.Value > 400)
            {
                MessageBox.Show("El límite de compra es de 400 unidades por producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } else if (string.IsNullOrWhiteSpace(txtCodigo.Text) || string.IsNullOrWhiteSpace(txtProducto.Text))
            {
                MessageBox.Show("Por favor seleccione un producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AgregarAlCarrito(Convert.ToInt32(txtCodigo.Text), Convert.ToInt32(nudCantidad.Value));

            // Reiniciar controles
            nudCantidad.Value = 1;
            txtCodigo.Text = null;
            txtProducto.Text = null;
            dgvProductos.ClearSelection();
            txtPrecio.Text = null;
            ActualizarImagenCarrito();
        }
        private void AgregarAlCarrito(int codigoProducto, int cantidadAgregar)
        {
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
                MessageBox.Show("Producto no encontrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string descripcion = producto.Cells[1].Value.ToString();
            decimal costo = Convert.ToDecimal(producto.Cells[4].Value);

            // Verificar si ya está en el carrito
            for (int i = 0; i < dgvCarrito.Rows.Count; i++)
            {
                if ((int)dgvCarrito.Rows[i].Cells[0].Value == codigoProducto)
                {
                    int cantidadActual = Convert.ToInt32(dgvCarrito.Rows[i].Cells[3].Value);
                    int nuevaCantidad = cantidadActual + cantidadAgregar;

                    // 🔹 Límite máximo de 400
                    if (nuevaCantidad > 400)
                    {
                        MessageBox.Show("La cantidad máxima por producto es 400.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgvCarrito.Rows[i].Cells[3].Value = 400;
                    }
                    else
                    {
                        dgvCarrito.Rows[i].Cells[3].Value = nuevaCantidad;
                    }

                    return;
                }
            }

            // Si no está en el carrito, agregar nuevo producto
            int cantidadFinal = Math.Min(cantidadAgregar, 400);
            if (cantidadAgregar > 400)
                MessageBox.Show("La cantidad máxima por producto es 400. Se ajustó automáticamente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            dgvCarrito.Rows.Add(codigoProducto, descripcion, costo, cantidadFinal, Eliminar, Restar, Sumar);

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

        private async void button2_Click(object sender, EventArgs e)
        {
            if (dgvCarrito.Rows.Count==0)
            {   
                MessageBox.Show($"Por favor seleccione un Producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {
                int proveedrId = 3; //por mientras, en lo que se configura la barra de busqueda
                var supabase = await CapaDeDatos.Datos.Conexion.GetClientAsync();
                var Actual = supabase.Auth.CurrentUser;
                
                if (Actual == null)
                {
                    throw new Exception("No hay usuario autenticado en la sesión actual.");
                }

                //obteniendo el usuario
                var respEmpleado = await CompraRepositorio.getUserId(Actual.Id);

                //obteniendo el id de la compra recien creada
                //esto no necesita estar en el repo ya que es una consulta de mi dgv, no de la base de datos.
                var detalles = dgvCarrito.Rows
                .Cast<DataGridViewRow>()
                .Where(r => !r.IsNewRow)
                .Select(r => new {
                    id_producto = Convert.ToInt32(r.Cells[0].Value),
                    cantidad_compra = Convert.ToInt32(r.Cells[3].Value)
                }).ToList();

                if (respEmpleado == null)
                {
                    MessageBox.Show("No se encontró empleado asociado al usuario autenticado.");
                    return;
                }

                int idEmpleado = respEmpleado.IdUsuario;

                var compra = new Compra
                {
                    IdEmpleado = idEmpleado,
                    IdProveedor = proveedrId,
                    FechaCompra = DateTime.UtcNow
                };
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    var compraRepositorio = new CompraRepositorio();
                    await compraRepositorio.InsertarCompra(compra);
                    //MessageBox.Show(detallesJson);
                    // se llama aqui para no crear registros fantasmas
                    int? IdCompra = await CompraRepositorio.ObtenerCompraId(idEmpleado);
                    if (IdCompra == null)
                    {
                        MessageBox.Show("No se pudo obtener el ID de la compra recién creada.");
                        return;
                    }
                    await supabase.Rpc("registrar_detalle_compra", new
                    {
                        p_id_compra = IdCompra,
                        p_detalles = detalles,
                    });

                    MessageBox.Show($"Compra registrada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //ActualizarImagenCarrito();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al registrar la compra: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                    dgvCarrito.Rows.Clear();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
