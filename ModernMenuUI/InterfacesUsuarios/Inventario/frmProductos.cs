using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.InterfacesUsuarios.Inventario;
using ModernMenuUI.ServiciosUI;
using System.Data;
using ModernMenuUI.ClasesUI.Extenciones;


namespace ModernMenuUI
{
    /// <summary>
    /// Formulario principal para la administración, filtrado, búsqueda y edición de productos.
    /// Integra:
    /// - Búsqueda interactiva con sugerencias.
    /// - Filtros por estado, marca y categoría.
    /// - Actualización automática mediante Realtime.
    /// - Operaciones CRUD vía formularios secundarios.
    /// - Aplicación de permisos UI dinámicos.
    /// </summary>
    public partial class frmProductos : Form
    {
        #region 1. Campos y Dependencias
        /// <summary>Repositorio encargado de obtener, insertar y actualizar productos.</summary>
        private readonly ProductoRepositorio _productoRepositorio;

        /// <summary>Servicio encargado de habilitar o bloquear botones según permisos del usuario.</summary>
        private readonly ServiciosUI.ServicioPermisosUI _servicioPermisos;

        /// <summary>Gestor de cambios en tiempo real para reflejar alteraciones externas a nivel de productos.</summary>
        private readonly GestorRealtime<Producto> _gestorRealtime;

        /// <summary>Buscador interactivo que gestiona texto, sugerencias y acciones sobre DataGridView.</summary>
        private BuscadorInteractivo<Producto> _buscadorCtrl;

        /// <summary>Lista maestra con todos los productos cargados inicialmente.</summary>
        private List<Producto> _listaMaestraProductos = new List<Producto>();

        /// <summary>Producto actualmente seleccionado en la grilla.</summary>
        private Producto ProductoSeleccionado;

        /// <summary>Filtro para limitar los productos por Marca.</summary>
        private int? _filtroMarcaId = null;

        /// <summary>Filtro para limitar los productos por Categoría.</summary>
        private int? _filtroCategoriaId = null;
        #endregion

        #region 2. Constructor y Load

        /// <summary>
        /// Constructor principal: configura repositorios, permisos, grilla, realtime y eventos generales.
        /// </summary>
        public frmProductos()
        {
            InitializeComponent();

            // A. Inicialización de dependencias
            _productoRepositorio = new ProductoRepositorio();
            _servicioPermisos = new ServiciosUI.ServicioPermisosUI();
            _gestorRealtime = new GestorRealtime<Producto>();

            // B. Configuración visual y de rendimiento del grid
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.ActivarDobleBuffer();
            dgvProductos.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 230, 241);

            // C. Registrar botones bajo control de permisos
            RegistrarBotonesConPermisos();
            _servicioPermisos.AplicarPermisos();

            // D. Evento unificado para los RadioButtons de estado
            ConfigurarEventosUnificados();

            // E. Callbacks Realtime para recargar datos cuando la BD cambie
            _gestorRealtime.OnCambioBaseDatos += (c) => RecargarInterfazSafe();
            _gestorRealtime.OnReconexionExitosa += () => RecargarInterfazSafe();
        }

        /// <summary>
        /// Carga inicial del formulario: obtiene productos, configura buscador y suscribe a Realtime.
        /// </summary>
        private async void frmProductos_Load(object sender, EventArgs e)
        {
            await InicializarDatosYBuscador();
            await _gestorRealtime.SuscribirAsync();
        }

        /// <summary>
        /// Al cerrar el formulario se desuscribe del canal Realtime.
        /// </summary>
        private async void frmProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            await _gestorRealtime.DesuscribirAsync();
        }

        #endregion

        #region 3. Lógica de Carga y Realtime

        /// <summary>
        /// Carga inicial de productos, crea el buscador interactivo y refresca la vista.
        /// </summary>
        private async Task InicializarDatosYBuscador()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // Obtener todos los productos
                _listaMaestraProductos = await _productoRepositorio.ObtenerTodosLosProductos(null);

                // Crear buscador interactivo usando tus criterios originales
                _buscadorCtrl = new BuscadorInteractivo<Producto>(
                    txtBuscar,
                    lstSugerencias,
                    dgvProductos,
                    _listaMaestraProductos,
                    (p, txt) => p.CodigoBarraProducto != null && p.CodigoBarraProducto.Equals(txt),
                    (p, txt) => p.ToString().IndexOf(txt, StringComparison.OrdinalIgnoreCase) >= 0,
                    (p) => p.ToString(),
                    (busquedaActiva) =>
                    {
                        pnlLimpiarFiltros.Visible = busquedaActiva;
                        if (!busquedaActiva) RefrescarGrid();
                    },
                    (txt) => txt.All(char.IsDigit) && txt.Length >= 8 && txt.Length <= 13
                );

                RefrescarGrid();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error carga inicial: {ex.Message}");
                MessageBox.Show(
                    $"No se pudieron cargar los productos.\nPosible causa: Internet inestable o servidor en mantenimiento.\n\nDetalle: {ex.Message}",
                    "Error de Carga",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally { this.Cursor = Cursors.Default; }
        }

        /// <summary>
        /// Recarga la lista maestra desde la BD y actualiza el buscador + grid.
        /// </summary>
        private async Task CargarProductosMaestros()
        {
            try
            {
                _listaMaestraProductos = await _productoRepositorio.ObtenerTodosLosProductos(null);
                _buscadorCtrl?.ActualizarDatosMaestros(_listaMaestraProductos);
                RefrescarGrid();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error recarga: {ex.Message}");
            }
        }

        /// <summary>
        /// Ejecuta recarga de forma segura (evita cross-thread exceptions).
        /// </summary>
        private void RecargarInterfazSafe()
        {
            if (!this.IsDisposed && this.IsHandleCreated)
                this.BeginInvoke((MethodInvoker)(async () => await CargarProductosMaestros()));
        }

        #endregion

        #region 4. Búsqueda (Delegada al Controlador de Sugerencias)

        private async void txtBuscar_KeyUp(object sender, KeyEventArgs e)
            => await _buscadorCtrl.ManejarKeyUpAsync(e);

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
            => _buscadorCtrl.ManejarKeyDown(new KeyEventArgs(Keys.Enter));

        #endregion

        #region 5. Filtrado y Grid

        /// <summary>
        /// Aplica todos los filtros activos (estado, marca, categoría) y refresca DataGridView.
        /// </summary>
        private void RefrescarGrid()
        {
            gbxEstado.Enabled = false;

            var query = _listaMaestraProductos.AsEnumerable();

            // Filtro por estado
            if (rbMostrarHabilitados.Checked)
                query = query.Where(p => p.EstadoProducto);
            else if (rbMostrardeshabilitados.Checked)
                query = query.Where(p => !p.EstadoProducto);

            // Filtros adicionales
            if (_filtroMarcaId.HasValue)
                query = query.Where(p => p.IdMarca == _filtroMarcaId.Value);

            if (_filtroCategoriaId.HasValue)
                query = query.Where(p => p.IdCategoria == _filtroCategoriaId.Value);

            var listaFinal = query.ToList();
            dgvProductos.DataSource = listaFinal;

            // Mostrar botón de limpiar filtros si corresponde
            bool hayFiltros = !rbMostrarHabilitados.Checked || _filtroMarcaId != null || _filtroCategoriaId != null;
            pnlLimpiarFiltros.Visible = hayFiltros;

            if (listaFinal.Count > 0)
                dgvProductos.ClearSelection();

            gbxEstado.Enabled = true;
        }

        /// <summary>
        /// Suscribe los radio buttons al mismo manejador para evitar código repetido.
        /// </summary>
        private void ConfigurarEventosUnificados()
        {
            rbMostrarTodos.CheckedChanged += FiltroEstado_Changed;
            rbMostrarHabilitados.CheckedChanged += FiltroEstado_Changed;
            rbMostrardeshabilitados.CheckedChanged += FiltroEstado_Changed;
        }

        private void FiltroEstado_Changed(object sender, EventArgs e)
        {
            if (sender is RadioButton rb && rb.Checked)
                RefrescarGrid();
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
                ProductoSeleccionado = dgvProductos.SelectedRows[0].DataBoundItem as Producto;
            else
                ProductoSeleccionado = null;
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            _filtroMarcaId = null;
            _filtroCategoriaId = null;

            txtFiltroMarca.Text = "";
            txtFiltroCategoria.Text = "";

            rbMostrarHabilitados.Checked = true;

            _buscadorCtrl.LimpiarBusqueda();
            RefrescarGrid();
        }

        #endregion

        #region 6. CRUD

        /// <summary>Abre un formulario para crear un nuevo producto.</summary>
        private async void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            await AbrirEditorProducto(null);
        }

        /// <summary>Abre un formulario para editar el producto seleccionado.</summary>
        private async void btnEditarProducto_Click(object sender, EventArgs e)
        {
            if (ProductoSeleccionado == null)
            {
                MessageBox.Show(
                    "Seleccione un producto primero.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            await AbrirEditorProducto(ProductoSeleccionado);
        }

        /// <summary>
        /// Lanza el form de edición/inserción y refresca la grilla si hubo cambios.
        /// </summary>
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

        #endregion

        #region 7. Filtros de Marcas y Categorías

        /// <summary>
        /// Helper genérico que abre formularios de selección (Marcas / Categorías).
        /// </summary>
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
            });

        private void btnCategoria_Click(object sender, EventArgs e)
            => AbrirFiltro(() => new frmCategorias(), f =>
            {
                txtFiltroCategoria.Text = f.CategoriaSeleccionada.NombreCategoria;
                _filtroCategoriaId = f.CategoriaSeleccionada.IdCategoria;
                RefrescarGrid();
            });

        private void btnAgregarMarca_Click(object sender, EventArgs e)
            => new frmMarcas().ShowDialog();

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
            => new frmCategorias().ShowDialog();

        #endregion

        #region 8. Helpers y UI

        private void btnSalir_Click(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            this.Close();
        }

        /// <summary>
        /// Registra todos los botones que dependen de permisos del usuario.
        /// </summary>
        private void RegistrarBotonesConPermisos()
        {
            _servicioPermisos.RegistrarBoton(btnNuevoProducto, "create_inventario");
            _servicioPermisos.RegistrarBoton(btnEditarProducto, "update_inventario");
            _servicioPermisos.RegistrarBoton(btnAgregarCategoria, "update_inventario");
            _servicioPermisos.RegistrarBoton(btnAgregarMarca, "update_inventario");
            _servicioPermisos.RegistrarBoton(btnIngresarPerdida, "update_inventario");
        }

        #endregion
    }
}
