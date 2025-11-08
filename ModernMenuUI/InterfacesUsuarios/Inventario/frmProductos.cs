using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion.CapaServiciosSeguridadValidacion; // Añadido para el monitor
using ModernMenuUI.ClasesUI;
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

namespace ModernMenuUI
{
    public partial class frmProductos : Form
    {
        private readonly ProductoRepositorio productoRepositorio;
        private Producto ProductoSeleccionado;
        Form formularioactivo = null;

        // --- VARIABLES DE LISTA MAESTRA Y REALTIME (Patrón frmEmpleado) ---
        private List<Producto> _listaMaestraProductos = new List<Producto>(); // <-- Tu lista, renombrada
        private Supabase.Realtime.RealtimeChannel? _productosSubscription;
        private readonly ServicioVerificacionConexion _monitorConexion = new ServicioVerificacionConexion();
        private Supabase.Client? _supabaseClient;


        public frmProductos()
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

            // --- AÑADIDO (Patrón frmEmpleado) ---
            this.FormClosing += frmProductos_FormClosing;
        }

        // --- frmProductos_Load (Patrón frmEmpleado) ---
        private async void frmProductos_Load(object sender, EventArgs e)
        {

            _monitorConexion.EstadoDeRedCambiado += MonitorConexion_EstadoDeRedCambiado;


            await CargarProductosMaestros();

            RefrescarGrid();
            await IniciarSuscripcionProductos();

        }

        // --- LÓGICA DE CARGA MAESTRA (Equivalente a CargarEmpleados) ---
        private async Task CargarProductosMaestros()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.Cursor = Cursors.WaitCursor;

                // Carga TODOS los productos a tu lista de memoria
                // Llamada original con un solo argumento (null = todos)
                _listaMaestraProductos = await productoRepositorio.ObtenerTodosLosProductos(null);
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

        // --- NUEVO MÉTODO: Filtra la lista maestra y actualiza el Grid ---
        private void RefrescarGrid()
        {
            this.Cursor = Cursors.WaitCursor;
            gbxEstado.Enabled = false; // Deshabilita los radio buttons

            // 1. Determinar el filtro de estado
            bool? estado = null;
            if (rbMostrarHabilitados.Checked) estado = true;
            if (rbMostrardeshabilitados.Checked) estado = false;

            // 2. Filtrar la LISTA MAESTRA en memoria (LINQ)
            List<Producto> listaFiltrada;

            if (estado == null)
            {
                listaFiltrada = _listaMaestraProductos; // Todos
            }
            else
            {
                listaFiltrada = _listaMaestraProductos.Where(p => p.EstadoProducto == estado).ToList();
            }

            // (Aquí podrías añadir el filtro del buscador en el futuro)

            // 3. Asigna los datos filtrados al DataGridView
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = listaFiltrada;

            if (dgvProductos.Rows.Count > 0)
                dgvProductos.ClearSelection();

            gbxEstado.Enabled = true; // Vuelve a habilitar
            this.Cursor = Cursors.Default;
        }

        // --- LÓGICA REALTIME (Patrón frmEmpleado) ---

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

        // --- EVENTOS DE FILTRO (Ahora llaman a RefrescarGrid) ---

        private void rbMostrarTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                RefrescarGrid();
            }
        }

        private void rbMostrarHabilitados_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                RefrescarGrid();
            }
        }

        private void rbMostrardeshabilitados_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                RefrescarGrid();
            }
        }

        // --- EVENTOS CRUD (Patrón frmEmpleado) ---

        private async void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            frmAgregarEditarProducto NuevoProducto = new frmAgregarEditarProducto();
            DialogResult resultado = NuevoProducto.ShowDialog();

            // Refresco manual opcional (Realtime DEBERÍA manejarlo,
            // pero si hay lag, puedes forzarlo)
            if (resultado == DialogResult.OK)
            {
                await CargarProductosMaestros();
                RefrescarGrid();
            }
        }

        private async void btnEditarProducto_Click(object sender, EventArgs e)
        {
            if (ProductoSeleccionado != null)
            {
                // ¡CORREGIDO! Pasando el producto seleccionado
                frmAgregarEditarProducto EditarProducto = new frmAgregarEditarProducto(ProductoSeleccionado);
                DialogResult resultado = EditarProducto.ShowDialog();

                // Refresco manual (siguiendo patrón frmEmpleado)
                if (resultado == DialogResult.OK)
                {
                    await CargarProductosMaestros();
                    RefrescarGrid();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private List<Producto> BuscarProductos(string textoBusqueda)
        {
            string busqueda = textoBusqueda.ToLower().Trim();

            if (string.IsNullOrEmpty(busqueda))
            {
                // Devuelve la lista filtrada por los radiobuttons
                bool? estado = null;
                if (rbMostrarHabilitados.Checked) estado = true;
                if (rbMostrardeshabilitados.Checked) estado = false;

                if (estado == null) return _listaMaestraProductos;
                return _listaMaestraProductos.Where(p => p.EstadoProducto == estado).ToList();
            }

            var resultados = _listaMaestraProductos.Where(producto =>
                    // Filtra por estado PRIMERO
                    (rbMostrarTodos.Checked ||
                     (rbMostrarHabilitados.Checked && producto.EstadoProducto == true) ||
                     (rbMostrardeshabilitados.Checked && producto.EstadoProducto == false))
                    &&
                    // Y LUEGO por texto
                    (
                        (producto.NombreProducto != null && producto.NombreProducto.ToLower().Contains(busqueda)) ||
                        (producto.Categoria.NombreCategoria != null && producto.Categoria.NombreCategoria.ToLower().Contains(busqueda)) ||
                        (producto.Marca.NombreMarca != null && producto.Marca.NombreMarca.ToLower().Contains(busqueda)) ||
                        (producto.CodigoBarraProducto != null && producto.CodigoBarraProducto.ToLower().Contains(busqueda))
                    )
                )
                //.Take(10) // Puedes descomentar esto si quieres limitar los resultados
                .ToList();

            return resultados;
        }

        // --- CÓDIGO DE SOPORTE (Sin cambios) ---

        private void btnSalir_Click(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            this.Close(); // FormClosing se encargará de desechar la suscripción
        }

        private async void frmProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            await DesecharSuscripcion();
        }

        private void HoraFecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss tt", new CultureInfo("es-ES"));
            lblFecha.Text = DateTime.Now.ToString("dddd dd 'de' MMMM 'del' yyyy", new CultureInfo("es-ES"));
        }

        // --- VARIABLES ---
        private CancellationTokenSource _ctsBusqueda;
        private string sugerenciaActual = "";
        private bool _ignorarTextChanged = false;
        private bool _usuarioSeleccionoConMouse = false;
        private const int MAX_SUGGESTIONS = 10; // (Opcional, para el tamaño)

        // --- EVENTOS ---

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

                List<Producto> resultados = BuscarProductos(txtBuscar.Text);
                List<Producto> top10 = resultados.Take(10).ToList();

                if (resultados.Count > 0 && !string.IsNullOrEmpty(txtBuscar.Text))
                {
                    lstSugerencias.DataSource = null;
                    lstSugerencias.DataSource = top10;
                    lstSugerencias.DisplayMember = "NombreProducto";

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
                    Producto productoSel = lstSugerencias.SelectedItem as Producto;
                    txtBuscar.Text = productoSel.NombreProducto;
                    txtBuscar.SelectionStart = txtBuscar.Text.Length;

                    // ¡SOLUCIÓN AL PROBLEMA 2!
                    lstSugerencias.Visible = false;
                    _ctsBusqueda?.Cancel(); // Cancela el KeyUp pendiente
                    SeleccionarProductoEnGrid(productoSel);
                    e.Handled = true;
                    e.SuppressKeyPress = true; // Evita el sonido "ding"
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (_ignorarTextChanged) return;
            sugerenciaActual = "";
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
                Producto productoSel = lstSugerencias.SelectedItem as Producto;
                txtBuscar.Text = productoSel.NombreProducto;
                txtBuscar.SelectionStart = txtBuscar.Text.Length;
                lstSugerencias.Visible = false;
                _ctsBusqueda?.Cancel();
                SeleccionarProductoEnGrid(productoSel);
            }
        }

        private void lstSugerencias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && lstSugerencias.SelectedItem != null)
            {
                Producto productoSel = lstSugerencias.SelectedItem as Producto;
                if (productoSel != null)
                {
                    _ignorarTextChanged = true;
                    txtBuscar.Text = productoSel.NombreProducto;
                    txtBuscar.SelectionStart = txtBuscar.Text.Length;
                    txtBuscar.SelectionLength = 0;
                    _ignorarTextChanged = false;

                    lstSugerencias.Visible = false;
                    sugerenciaActual = "";
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
                Producto productoSel = lstSugerencias.SelectedItem as Producto;
                if (productoSel != null)
                {
                    txtBuscar.Text = productoSel.NombreProducto;
                    lstSugerencias.Visible = false;
                }
            }
        }


        private void AjustarAlturaListBox(int numeroDeResultados)
        {
            int alturaItem = lstSugerencias.ItemHeight;
            int alturaMaxima = (alturaItem * MAX_SUGGESTIONS) + 10;
            int alturaNecesaria = (alturaItem * numeroDeResultados) + 10;
            lstSugerencias.Height = Math.Min(alturaNecesaria, alturaMaxima);
        }

        private void SeleccionarProductoEnGrid(Producto productoBuscado)
        {
            if (productoBuscado == null) return;

            // 1. Obtener la lista de datos que está en el DataGridView
            var listaDelGrid = dgvProductos.DataSource as List<Producto>;
            if (listaDelGrid == null) return; // No se puede buscar

            // 2. Encontrar el ÍNDICE del producto en la lista (¡casi instantáneo!)
            //    (Asegúrate de que 'IdProducto' sea tu llave primaria)
            int indice = listaDelGrid.FindIndex(p => p.IdProducto == productoBuscado.IdProducto);

            // 3. Si se encuentra, seleccionar esa fila por su índice
            if (indice != -1 && indice < dgvProductos.Rows.Count)
            {
                dgvProductos.ClearSelection();
                dgvProductos.Rows[indice].Selected = true;

                // Mueve el scroll para que la fila sea visible
                dgvProductos.FirstDisplayedScrollingRowIndex = indice;
            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {

        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                var filaSeleccionada = dgvProductos.SelectedRows[0];
                Producto producto = filaSeleccionada.DataBoundItem as Producto;

                if (producto != null)
                {
                    ProductoSeleccionado = producto;
                }
            }
            else
            {
                ProductoSeleccionado = null;
            }
        }
    }
}
