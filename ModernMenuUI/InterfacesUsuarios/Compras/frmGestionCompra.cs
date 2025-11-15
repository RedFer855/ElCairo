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

        // --- NUEVO: Repositorio y lista maestra de proveedores ---
        private readonly ProveedorRepositorio proveedorRepositorio;
        private List<Proveedor> _listaMaestraProveedores = new List<Proveedor>();
        private Proveedor ProveedorSeleccionado = null;
        

        private List<Producto> _listaMaestraProductos = new List<Producto>(); // <-- Tu lista, renombrada
        private Supabase.Realtime.RealtimeChannel? _productosSubscription;
        private readonly ServicioVerificacionConexion _monitorConexion = new ServicioVerificacionConexion();
        private Supabase.Client? _supabaseClient;
        private CancellationTokenSource _ctsBusqueda;
        private string sugerenciaActual = "";
        private bool _ignorarTextChanged = false;
        private bool _usuarioSeleccionoConMouse = false;
        private const int MAX_SUGGESTIONS = 10; // (Opcional, para el tamaño)

        public frmGestionCompra()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            dgvProductos.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#DCE6F1");
            dgvProductos.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#57636e");
            dgvProductos.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            productoRepositorio = new ProductoRepositorio();

            // --- Inicializa el repositorio de proveedores (asumo que existe) ---
            proveedorRepositorio = new ProveedorRepositorio();

            dgvProductos.AutoGenerateColumns = false;
        }
        private async void frmGestionCompra_Load(object sender, EventArgs e)
        {
            _monitorConexion.EstadoDeRedCambiado += MonitorConexion_EstadoDeRedCambiado;


            // Cargamos solo los proveedores al iniciar
            await CargarProveedoresMaestros();

            // 🔹 Dejamos el DataGridView vacío hasta que se seleccione un proveedor
            _listaMaestraProductos.Clear();
            dgvProductos.DataSource = null;

            // Mantiene la suscripción activa por si luego se quieren ver productos
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

        // --- NUEVO: carga en memoria la lista de proveedores ---
        private async Task CargarProveedoresMaestros()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

                // Intento: usar el repositorio (si no existe, reemplázalo por tu forma de obtener proveedores)
                _listaMaestraProveedores = await proveedorRepositorio.ObtenerTodosLosProveedores(cts.Token);
                // Si tu repositorio tiene otro método, ajusta aquí.
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("No se pudo conectar con el servidor (tiempo de espera agotado).", "Error de Red", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar proveedores", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    //await CargarProductosMaestros();
                    //RefrescarGrid();
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

        private void dgvCarrito_CellMouseUp(object sender, DataGridViewCellEventArgs e)
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
                    /*if (cantidad > 1)
                        dgvCarrito.Rows[e.RowIndex].Cells[3].Value = cantidad - 1;
                    else
                        MessageBox.Show("La cantidad no puede ser menor a 1", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                */
                }
                dgvCarrito.Rows[e.RowIndex].Cells[3].Value = cantidad - 1;
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
            /*if (nudCantidad.Value <= 0)
            {
                MessageBox.Show("No puede ingresar 0 o negativo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } else */
            if (nudCantidad.Value > 400)
            {
                MessageBox.Show("El límite de compra es de 400 unidades por producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtCodigo.Text) || string.IsNullOrWhiteSpace(txtProducto.Text))
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
            if (dgvCarrito.Rows.Count == 0)
            {
                MessageBox.Show($"Por favor seleccione un Producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Ahora usamos el proveedor seleccionado desde la búsqueda
                if (ProveedorSeleccionado == null)
                {
                    MessageBox.Show("Por favor seleccione un proveedor antes de registrar la compra.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int proveedrId = ProveedorSeleccionado.IdProveedor;

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
                .Select(r => new
                {
                    id_producto = Convert.ToInt32(r.Cells[0].Value),
                    cantidad_compra = Convert.ToInt32(r.Cells[3].Value)
                }).ToList();

                if (respEmpleado == null)
                {
                    MessageBox.Show("No se encontró empleado asociado al usuario autenticado.");
                    return;
                }

                int idEmpleado = respEmpleado.IdUsuario;
                int idBodega = frmInicioBodega.SessionData.IdBodegaActual;

                var parametros = new
                {
                    p_id_empleado = idEmpleado,
                    p_id_proveedor = proveedrId,
                    p_fecha_compra = DateTime.UtcNow,
                    p_detalles = detalles,
                    p_id_bodega = idBodega,
                };
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    await supabase.Rpc("registrar_compra", parametros);

                    MessageBox.Show($"Compra registrada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        // ------------------ LÓGICA DE BÚSQUEDA DE PROVEEDORES (SUGERENCIAS) ------------------


        // Método que filtra la lista maestra de proveedores (sin usar teléfono)
        private List<Proveedor> BuscarProveedores(string textoBusqueda)
        {
            string busqueda = textoBusqueda?.ToLower().Trim() ?? "";

            // Si está vacío, devolver todos los proveedores activos
            if (string.IsNullOrEmpty(busqueda))
            {
                return _listaMaestraProveedores.Where(p => p.EstadoProveedor == true).ToList();
            }

            var resultados = _listaMaestraProveedores.Where(proveedor =>
                    // Sólo activos
                    proveedor.EstadoProveedor == true
                    &&
                    // Y que coincidan por nombre o dirección (no usamos teléfono)
                    (
                        (proveedor.NombreProveedor != null && proveedor.NombreProveedor.ToLower().Contains(busqueda)) ||
                        (proveedor.DireccionProveedor != null && proveedor.DireccionProveedor.ToLower().Contains(busqueda))
                    )
                )
                .ToList();

            return resultados;
        }

        // Ajusta la altura del ListBox según número de resultados (máx MAX_SUGGESTIONS)
        private void AjustarAlturaListBox(int numeroDeResultados)
        {
            int alturaItem = lstSugerencias.ItemHeight;
            int alturaMaxima = (alturaItem * MAX_SUGGESTIONS) + 10;
            int alturaNecesaria = (alturaItem * numeroDeResultados) + 10;
            lstSugerencias.Height = Math.Min(alturaNecesaria, alturaMaxima);
        }

        // KeyUp en el TextBox de búsqueda (debe estar enlazado en el diseñador a txtBuscar_KeyUp)
        private async void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            // Ignorar las teclas de navegación para que no relancen la búsqueda
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                return;
            }

            _ctsBusqueda?.Cancel();
            _ctsBusqueda = new CancellationTokenSource();

            try
            {

                await Task.Delay(300, _ctsBusqueda.Token);

                List<Proveedor> resultados = BuscarProveedores(txtBuscarProv.Text);
                List<Proveedor> top10 = resultados.Take(10).ToList();

                if (resultados.Count > 0 && !string.IsNullOrEmpty(txtBuscarProv.Text))
                {
                    lstSugerencias.DataSource = null;
                    lstSugerencias.DataSource = top10;
                    lstSugerencias.DisplayMember = "NombreProveedor";

                    // Llama a la función para ajustar la altura
                    AjustarAlturaListBox(resultados.Count);

                    lstSugerencias.Visible = true;
                }
                else
                {
                    lstSugerencias.Visible = false;
                }
            }
            catch (TaskCanceledException)
            {
                // Búsqueda cancelada (el usuario siguió tecleando), es normal.
            }
        }

        // KeyDown para manejar navegación por la lista y la aceptación con Enter
        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            // Si la lista no está visible, no hacer nada
            if (!lstSugerencias.Visible) return;

            if (e.KeyCode == Keys.Down)
            {
                // Mover selección hacia abajo
                int newIndex = Math.Min(lstSugerencias.SelectedIndex + 1, lstSugerencias.Items.Count - 1);
                if (newIndex >= 0)
                    lstSugerencias.SelectedIndex = newIndex;

                e.Handled = true; // Evita que el cursor del TextBox se mueva
            }
            else if (e.KeyCode == Keys.Up)
            {
                // Mover selección hacia arriba
                int newIndex = Math.Max(lstSugerencias.SelectedIndex - 1, 0);
                if (newIndex >= 0)
                    lstSugerencias.SelectedIndex = newIndex;
                e.Handled = true; // Evita que el cursor del TextBox se mueva
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (lstSugerencias.SelectedItem != null)
                {
                    // Aceptar la selección
                    Proveedor proveedorSel = lstSugerencias.SelectedItem as Proveedor;
                    txtBuscarProv.Text = proveedorSel.NombreProveedor;
                    txtBuscarProv.SelectionStart = txtBuscarProv.Text.Length;

                    lstSugerencias.Visible = false;
                    _ctsBusqueda?.Cancel(); // Cancela el KeyUp pendiente

                    // Setea el proveedor seleccionado para usarlo al registrar la compra
                    ProveedorSeleccionado = proveedorSel;

                    e.Handled = true;
                    e.SuppressKeyPress = true; // Evita el sonido "ding"
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (_ignorarTextChanged) return;
            sugerenciaActual = "";
            // Si el usuario edita el texto, limpiamos la selección previa
            ProveedorSeleccionado = null;
        }

        private async void txtBuscar_Leave(object sender, EventArgs e)
        {

            await Task.Delay(150);

            if (!lstSugerencias.Focused)
            {
                lstSugerencias.Visible = false;
            }
        }

        private void lstSugerencias_MouseClick(object sender, MouseEventArgs e)
        {
            if (lstSugerencias.SelectedItem != null)
            {
                Proveedor proveedorSel = lstSugerencias.SelectedItem as Proveedor;
                txtBuscarProv.Text = proveedorSel.NombreProveedor;
                txtBuscarProv.SelectionStart = txtBuscarProv.Text.Length;
                lstSugerencias.Visible = false;
                _ctsBusqueda?.Cancel();

                // Guardar proveedor seleccionado
                ProveedorSeleccionado = proveedorSel;
            }
        }

        private void lstSugerencias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && lstSugerencias.SelectedItem != null)
            {
                Proveedor proveedorSel = lstSugerencias.SelectedItem as Proveedor;
                if (proveedorSel != null)
                {
                    _ignorarTextChanged = true;
                    txtBuscarProv.Text = proveedorSel.NombreProveedor;
                    txtBuscarProv.SelectionStart = txtBuscarProv.Text.Length;
                    txtBuscarProv.SelectionLength = 0;
                    _ignorarTextChanged = false;

                    lstSugerencias.Visible = false;
                    sugerenciaActual = "";

                    // Guardar proveedor seleccionado
                    ProveedorSeleccionado = proveedorSel;
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void lstSugerencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Evita que cambie automáticamente si el usuario no hizo clic
            if (!_usuarioSeleccionoConMouse) return;

            if (lstSugerencias.SelectedItem != null)
            {
                Proveedor proveedorSel = lstSugerencias.SelectedItem as Proveedor;
                if (proveedorSel != null)
                {
                    txtBuscarProv.Text = proveedorSel.NombreProveedor;
                    lstSugerencias.Visible = false;

                    // Guardar proveedor seleccionado
                    ProveedorSeleccionado = proveedorSel;
                }
            }
        }

        // Si quieres detectar que la selección fue por mouse (opcional)
        private void lstSugerencias_MouseDown(object sender, MouseEventArgs e)
        {
            _usuarioSeleccionoConMouse = true;
        }
        private void lstSugerencias_MouseUp(object sender, MouseEventArgs e)
        {
            // Dejamos un pequeño retraso para evitar conflictos con Leave/Focus
            Task.Run(async () =>
            {
                await Task.Delay(50);
                _usuarioSeleccionoConMouse = false;
            });
        }

        private async void btnGetProv_Click(object sender, EventArgs e)
        {
            string nombre = txtBuscarProv.Text?.Trim() ?? "";

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Ingrese el nombre del proveedor para buscar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            try
            {
                var id = await ProveedorRepositorio.ObtenerIdProveedorPorNombreAsync(nombre);

                if (id == null)
                {
                    MessageBox.Show("No se encontró un proveedor con ese nombre.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Intentar obtener el proveedor desde la lista en memoria
                ProveedorSeleccionado = _listaMaestraProveedores.FirstOrDefault(p => p.IdProveedor == id);

                // Si no está en la lista maestra (cache), lo cargamos desde Supabase
                if (ProveedorSeleccionado == null)
                {
                    ProveedorSeleccionado = await ProveedorRepositorio.CargarProveedorPorIdAsync(id.Value);
                    // Opcional: agregar a la lista maestra para cache
                    if (ProveedorSeleccionado != null)
                    {
                        _listaMaestraProveedores.Add(ProveedorSeleccionado);
                    }
                }

                if (ProveedorSeleccionado != null)
                {
                    // Mostrar información
                    MessageBox.Show($"Proveedor seleccionado:\nID: {ProveedorSeleccionado.IdProveedor}\nNombre: {ProveedorSeleccionado.NombreProveedor}",
                        "Proveedor encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 🔹 Cargar los productos de este proveedor y actualizar el grid
                    this.Cursor = Cursors.WaitCursor;
                    try
                    {
                        var productosProveedor = await productoRepositorio.ObtenerProductosPorProveedorAsync(ProveedorSeleccionado.IdProveedor);

                        _listaMaestraProductos = productosProveedor; // actualiza la lista interna
                        RefrescarGrid(); // refresca el DataGridView
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
