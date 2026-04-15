using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.InterfacesUsuarios.Inventario;
using ModernMenuUI.ServiciosUI;
using System.Data;
using ModernMenuUI.ClasesUI.Extenciones;
using Supabase.Realtime.PostgresChanges;

namespace ModernMenuUI
{
    public partial class frmProductos : Form
    {
        private readonly ProductoRepositorio _productoRepositorio;
        private readonly ServiciosUI.ServicioPermisosUI _servicioPermisos;

        private BuscadorInteractivo<Producto> _buscadorCtrl;
        private List<Producto> _listaMaestraProductos = new List<Producto>();
        private Producto ProductoSeleccionado;

        private int? _filtroMarcaId = null;
        private int? _filtroCategoriaId = null;

        private Action<PostgresChangesResponse> _handlerCambio;

        public frmProductos()
        {
            InitializeComponent();

            _productoRepositorio = new ProductoRepositorio();
            _servicioPermisos = new ServiciosUI.ServicioPermisosUI();

            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.ActivarDobleBuffer();
            dgvProductos.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 230, 241);

            RegistrarBotonesConPermisos();
            _servicioPermisos.AplicarPermisos();

            ConfigurarEventosUnificados();

            _handlerCambio = (c) => RecargarInterfazSafe();
            RealtimeManager.OnProductoChanged += _handlerCambio;
        }

        private async void frmProductos_Load(object sender, EventArgs e)
        {
            await InicializarDatosYBuscador();
        }

        private void frmProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_handlerCambio != null)
                    RealtimeManager.OnProductoChanged -= _handlerCambio;
            }
            catch { }
        }

        // -------------------------------------------------------------
        // CARGA DE DATOS
        // -------------------------------------------------------------
        private async Task InicializarDatosYBuscador()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _listaMaestraProductos = await _productoRepositorio.ObtenerTodosLosProductos(null);

                InicializarBuscador();
                RefrescarGrid();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error carga inicial: {ex.Message}");
                MessageBox.Show(
                    $"No se pudieron cargar los productos.\n\nDetalle: {ex.Message}",
                    "Error de Carga",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally { this.Cursor = Cursors.Default; }
        }

        private async Task CargarProductosMaestros()
        {
            try
            {
                _listaMaestraProductos = await _productoRepositorio.ObtenerTodosLosProductos(null);
                RefrescarGrid();
                ActualizarBuscador();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error recarga: {ex.Message}");
            }
        }

        private void RecargarInterfazSafe()
        {
            if (!this.IsDisposed && this.IsHandleCreated)
                this.BeginInvoke((MethodInvoker)(async () => await CargarProductosMaestros()));
        }

        // -------------------------------------------------------------
        // FILTROS COMBINADOS (estado + marca + categoría)
        // -------------------------------------------------------------
        private List<Producto> ObtenerProductosSegunFiltro()
        {
            if (_listaMaestraProductos == null)
                return new List<Producto>();

            IEnumerable<Producto> query = _listaMaestraProductos;

            if (rbMostrarHabilitados.Checked)
                query = query.Where(p => p.EstadoProducto);
            else if (rbMostrardeshabilitados.Checked)
                query = query.Where(p => !p.EstadoProducto);

            if (_filtroMarcaId.HasValue)
                query = query.Where(p => p.IdMarca == _filtroMarcaId.Value);

            if (_filtroCategoriaId.HasValue)
                query = query.Where(p => p.IdCategoria == _filtroCategoriaId.Value);

            return query.ToList();
        }

        private void InicializarBuscador()
        {
            _buscadorCtrl = new BuscadorInteractivo<Producto>(
                txtBuscar,
                lstSugerencias,
                dgvProductos,
                ObtenerProductosSegunFiltro(),

                // BÚSQUEDA EXACTA (código de barras)
                (p, txt) => p.CodigoBarraProducto != null && p.CodigoBarraProducto.Equals(txt),

                // BÚSQUEDA PARCIAL
                (p, txt) =>
                    p.ToString().IndexOf(txt, StringComparison.OrdinalIgnoreCase) >= 0,

                // TEXTO MOSTRADO
                (p) => p.ToString(),

                // EVENTO FILTRO ACTIVO
                (busquedaActiva) =>
                {
                    pnlLimpiarFiltros.Visible = busquedaActiva || HayFiltrosExtras();
                    if (!busquedaActiva) RefrescarGrid();
                },

                // CÓDIGO DE BARRAS (8-13 dígitos)
                (txt) => txt.All(char.IsDigit) && txt.Length >= 8 && txt.Length <= 13
            );
        }

        private void ActualizarBuscador()
        {
            if (_buscadorCtrl == null) return;
            _buscadorCtrl.ActualizarDatosMaestros(ObtenerProductosSegunFiltro());
        }

        private bool HayFiltrosExtras()
        {
            return !rbMostrarHabilitados.Checked ||
                   _filtroMarcaId.HasValue ||
                   _filtroCategoriaId.HasValue;
        }

        // -------------------------------------------------------------
        // BÚSQUEDA GLOBAL POR CÓDIGO DE BARRAS (ignora filtros)
        // -------------------------------------------------------------
        private bool IntentarBusquedaPorCodigoBarras(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return false;
            if (!(texto.All(char.IsDigit) && texto.Length >= 8 && texto.Length <= 13))
                return false;

            var producto = _listaMaestraProductos
                .FirstOrDefault(p => p.CodigoBarraProducto != null &&
                                     p.CodigoBarraProducto.Equals(texto));

            if (producto == null)
            {
                MessageBox.Show(
                    "No se encontró ningún producto con ese código de barras.",
                    "No encontrado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return true;
            }

            if (!producto.EstadoProducto)
            {
                MessageBox.Show(
                    "Este producto está deshabilitado. Consulte con su administrador.",
                    "Producto deshabilitado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return true;
            }

            // Producto habilitado → si está oculto por filtros, limpiamos filtros
            bool visibleEnGridActual = ObtenerProductosSegunFiltro()
                .Any(p => p.IdProducto == producto.IdProducto);

            if (!visibleEnGridActual)
            {
                rbMostrarTodos.Checked = true;
                _filtroMarcaId = null;
                _filtroCategoriaId = null;
                txtFiltroMarca.Text = "";
                txtFiltroCategoria.Text = "";
                RefrescarGrid();
                ActualizarBuscador();
            }

            // Seleccionar la fila correspondiente
            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                if (row.DataBoundItem is Producto p && p.IdProducto == producto.IdProducto)
                {
                    row.Selected = true;
                    dgvProductos.CurrentCell = row.Cells[0];
                    break;
                }
            }

            txtBuscar.Clear();
            return true;
        }

        // -------------------------------------------------------------
        // GRID
        // -------------------------------------------------------------
        private void RefrescarGrid()
        {
            gbxEstado.Enabled = false;

            var listaFinal = ObtenerProductosSegunFiltro();

            dgvProductos.DataSource = null;
            dgvProductos.DataSource = listaFinal;

            pnlLimpiarFiltros.Visible = HayFiltrosExtras();

            if (listaFinal.Count > 0)
                dgvProductos.ClearSelection();

            gbxEstado.Enabled = true;
        }

        // -------------------------------------------------------------
        // EVENTOS BUSCADOR
        // -------------------------------------------------------------
        private async void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter &&
                IntentarBusquedaPorCodigoBarras(txtBuscar.Text.Trim()))
            {
                return;
            }

            await _buscadorCtrl.ManejarKeyUpAsync(e);
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
            => _buscadorCtrl.ManejarKeyDown(e);

        private void txtBuscar_Leave(object sender, EventArgs e)
            => _buscadorCtrl.ManejarLeave();

        private void lstSugerencias_MouseClick(object sender, MouseEventArgs e)
            => _buscadorCtrl.ManejarClickLista();

        private void lstSugerencias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) _buscadorCtrl.ManejarClickLista();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (IntentarBusquedaPorCodigoBarras(txtBuscar.Text.Trim()))
                return;

            _buscadorCtrl.ManejarKeyDown(new KeyEventArgs(Keys.Enter));
        }

        // -------------------------------------------------------------
        // RADIO BUTTONS
        // -------------------------------------------------------------
        private void ConfigurarEventosUnificados()
        {
            rbMostrarTodos.CheckedChanged += FiltroEstado_Changed;
            rbMostrarHabilitados.CheckedChanged += FiltroEstado_Changed;
            rbMostrardeshabilitados.CheckedChanged += FiltroEstado_Changed;
        }

        private void FiltroEstado_Changed(object sender, EventArgs e)
        {
            if (sender is RadioButton rb && rb.Checked)
            {
                RefrescarGrid();
                ActualizarBuscador();
            }
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
                ProductoSeleccionado = dgvProductos.SelectedRows[0].DataBoundItem as Producto;
            else
                ProductoSeleccionado = null;
        }

        // -------------------------------------------------------------
        // LIMPIAR FILTROS
        // -------------------------------------------------------------
        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            _filtroMarcaId = null;
            _filtroCategoriaId = null;

            txtFiltroMarca.Text = "";
            txtFiltroCategoria.Text = "";

            rbMostrarHabilitados.Checked = true;

            _buscadorCtrl.LimpiarBusqueda();
            RefrescarGrid();
            ActualizarBuscador();
        }

        // -------------------------------------------------------------
        // CRUD PRODUCTOS
        // -------------------------------------------------------------
        private async void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            await AbrirEditorProducto(null);
        }

        private async void btnEditarProducto_Click(object sender, EventArgs e)
        {
            if (ProductoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un producto primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            await AbrirEditorProducto(ProductoSeleccionado);
        }

        private async Task AbrirEditorProducto(Producto prod)
        {
            var frm = prod == null
                ? new frmAgregarEditarProducto()
                : new frmAgregarEditarProducto(prod);

            if (frm.ShowDialog() == DialogResult.OK)
                await CargarProductosMaestros();
        }

        private void btnIngresarPerdida_Click(object sender, EventArgs e)
        {
            new frmAgregarEditarProducto().ShowDialog();
        }

        // -------------------------------------------------------------
        // FILTROS MARCA Y CATEGORÍA
        // -------------------------------------------------------------
        private void AbrirFiltro<TForm>(Func<TForm> factory, Action<TForm> onSuccess)
            where TForm : Form
        {
            using (var frm = factory())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    onSuccess(frm);
            }
        }

        private void btnMarca_Click(object sender, EventArgs e)
            => AbrirFiltro(() => new frmMarcas(), f =>
            {
                txtFiltroMarca.Text = f.MarcaSeleccionada.NombreMarca;
                _filtroMarcaId = f.MarcaSeleccionada.IdMarca;
                RefrescarGrid();
                ActualizarBuscador();
            });

        private void btnCategoria_Click(object sender, EventArgs e)
            => AbrirFiltro(() => new frmCategorias(), f =>
            {
                txtFiltroCategoria.Text = f.CategoriaSeleccionada.NombreCategoria;
                _filtroCategoriaId = f.CategoriaSeleccionada.IdCategoria;
                RefrescarGrid();
                ActualizarBuscador();
            });

        private void btnAgregarMarca_Click(object sender, EventArgs e)
            => new frmMarcas().ShowDialog();

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
            => new frmCategorias().ShowDialog();

        private void btnSalir_Click(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            this.Close();
        }

        private void RegistrarBotonesConPermisos()
        {
            _servicioPermisos.RegistrarBoton(btnNuevoProducto, "create_inventario");
            _servicioPermisos.RegistrarBoton(btnEditarProducto, "update_inventario");
            _servicioPermisos.RegistrarBoton(btnAgregarCategoria, "update_inventario");
            _servicioPermisos.RegistrarBoton(btnAgregarMarca, "update_inventario");
        }

        private void rbMostrarHabilitados_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}