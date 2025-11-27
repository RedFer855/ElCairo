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
    public partial class frmProductos : Form
    {
        #region 1. Campos y Dependencias
        private readonly ProductoRepositorio _productoRepositorio;
        private readonly ServiciosUI.ServicioPermisosUI _servicioPermisos;
        private readonly GestorRealtime<Producto> _gestorRealtime;

        private BuscadorInteractivo<Producto> _buscadorCtrl;

        private List<Producto> _listaMaestraProductos = new List<Producto>();
        private Producto ProductoSeleccionado; // Respetando tu nombre original (PascalCase)

        private int? _filtroMarcaId = null;
        private int? _filtroCategoriaId = null;
        #endregion

        #region 2. Constructor y Load
        public frmProductos()
        {
            InitializeComponent();

            // A. Inicialización
            _productoRepositorio = new ProductoRepositorio();
            _servicioPermisos = new ServiciosUI.ServicioPermisosUI();
            _gestorRealtime = new GestorRealtime<Producto>();

            // B. Configuración Grid
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.ActivarDobleBuffer(); // Extension method optimizado
            dgvProductos.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 230, 241);

            // C. Permisos y Eventos
            RegistrarBotonesConPermisos();
            _servicioPermisos.AplicarPermisos();

            // Optimización: Unificar eventos de RadioButtons
            ConfigurarEventosUnificados();

            // D. Realtime Callbacks
            _gestorRealtime.OnCambioBaseDatos += (c) => RecargarInterfazSafe();
            _gestorRealtime.OnReconexionExitosa += () => RecargarInterfazSafe();
        }

        private async void frmProductos_Load(object sender, EventArgs e)
        {
            await InicializarDatosYBuscador();
            await _gestorRealtime.SuscribirAsync();
        }

        private async void frmProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            await _gestorRealtime.DesuscribirAsync();
        }
        #endregion

        #region 3. Lógica de Carga y Realtime
        private async Task InicializarDatosYBuscador()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                _listaMaestraProductos = await _productoRepositorio.ObtenerTodosLosProductos(null);

                
                _buscadorCtrl = new BuscadorInteractivo<Producto>(
                    txtBuscar,
                    lstSugerencias,
                    dgvProductos,
                    _listaMaestraProductos,
                    (p, txt) => p.CodigoBarraProducto != null && p.CodigoBarraProducto.Equals(txt),
                    (p, txt) => p.ToString().IndexOf(txt, StringComparison.OrdinalIgnoreCase) >= 0,
                    (p) => p.ToString(),
                    (busquedaActiva) => {
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

        private async Task CargarProductosMaestros()
        {
            try
            {
                // Solo actualizamos datos, no recreamos el objeto
                _listaMaestraProductos = await _productoRepositorio.ObtenerTodosLosProductos(null);
                _buscadorCtrl?.ActualizarDatosMaestros(_listaMaestraProductos);
                RefrescarGrid();
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
        #endregion

        #region 4. Búsqueda (Delegada al Controlador)
        private async void txtBuscar_KeyUp(object sender, KeyEventArgs e) => await _buscadorCtrl.ManejarKeyUpAsync(e);

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e) => _buscadorCtrl.ManejarKeyDown(e);

        private void txtBuscar_Leave(object sender, EventArgs e) =>  _buscadorCtrl.ManejarLeave();

        private void lstSugerencias_MouseClick(object sender, MouseEventArgs e) => _buscadorCtrl.ManejarClickLista();

        private void lstSugerencias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) _buscadorCtrl.ManejarClickLista();
        }

        private void btnBuscar_Click(object sender, EventArgs e) => _buscadorCtrl.ManejarKeyDown(new KeyEventArgs(Keys.Enter));
        #endregion

        #region 5. Filtrado y Grid (Optimizado)
        private void RefrescarGrid()
        {
            gbxEstado.Enabled = false;

            var query = _listaMaestraProductos.AsEnumerable();

            // Filtro de Estado (Usando tus nombres de variable exactos)
            if (rbMostrarHabilitados.Checked) query = query.Where(p => p.EstadoProducto == true);
            else if (rbMostrardeshabilitados.Checked) query = query.Where(p => p.EstadoProducto == false);

            // Filtros Combos
            if (_filtroMarcaId.HasValue) query = query.Where(p => p.IdMarca == _filtroMarcaId.Value);
            if (_filtroCategoriaId.HasValue) query = query.Where(p => p.IdCategoria == _filtroCategoriaId.Value);

            var listaFinal = query.ToList();
            dgvProductos.DataSource = listaFinal;

            // Manejo visual del botón limpiar (opcional si ya lo maneja el buscador, pero bueno dejarlo por los combos)
            bool hayFiltrosExtras = !rbMostrarHabilitados.Checked || _filtroMarcaId.HasValue || _filtroCategoriaId.HasValue;
            if (hayFiltrosExtras) pnlLimpiarFiltros.Visible = true;

            if (listaFinal.Count > 0) dgvProductos.ClearSelection();

            gbxEstado.Enabled = true;
        }

        private void ConfigurarEventosUnificados()
        {
            // Suscribimos los 3 radiobuttons al mismo evento
            rbMostrarTodos.CheckedChanged += FiltroEstado_Changed;
            rbMostrarHabilitados.CheckedChanged += FiltroEstado_Changed;
            rbMostrardeshabilitados.CheckedChanged += FiltroEstado_Changed;
        }

        private void FiltroEstado_Changed(object sender, EventArgs e)
        {
            if (sender is RadioButton rb && rb.Checked) RefrescarGrid();
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                ProductoSeleccionado = dgvProductos.SelectedRows[0].DataBoundItem as Producto;
            }
            else
            {
                ProductoSeleccionado = null;
            }
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

        #region 6. CRUD y Acciones
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
            var frm = prod == null ? new frmAgregarEditarProducto() : new frmAgregarEditarProducto(prod);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                await CargarProductosMaestros();
            }
        }

        private void btnIngresarPerdida_Click(object sender, EventArgs e)
        {
            new frmAgregarEditarProducto().ShowDialog();
        }
        #endregion

        #region 7. Filtros de Marcas y Categorías
        // Helper para evitar repetir código
        private void AbrirFiltro<TForm>(Func<TForm> factory, Action<TForm> onSuccess) where TForm : Form
        {
            using (var frm = factory())
            {
                if (frm.ShowDialog() == DialogResult.OK) onSuccess(frm);
            }
        }

        private void btnMarca_Click(object sender, EventArgs e) => AbrirFiltro(() => new frmMarcas(), f => {
            txtFiltroMarca.Text = f.MarcaSeleccionada.NombreMarca;
            _filtroMarcaId = f.MarcaSeleccionada.IdMarca;
            RefrescarGrid();
        });

        private void btnCategoria_Click(object sender, EventArgs e) => AbrirFiltro(() => new frmCategorias(), f => {
            txtFiltroCategoria.Text = f.CategoriaSeleccionada.NombreCategoria;
            _filtroCategoriaId = f.CategoriaSeleccionada.IdCategoria;
            RefrescarGrid();
        });

        private void btnAgregarMarca_Click(object sender, EventArgs e) => new frmMarcas().ShowDialog();
        private void btnAgregarCategoria_Click(object sender, EventArgs e) => new frmCategorias().ShowDialog();
        #endregion

        #region 8. Helpers y UI
        private void btnSalir_Click(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            this.Close();
        }

        private void RegistrarBotonesConPermisos()
        {
            _servicioPermisos.RegistrarBoton(btnNuevoProducto, "insert_inventario");
            _servicioPermisos.RegistrarBoton(btnEditarProducto, "update_inventario");
            _servicioPermisos.RegistrarBoton(btnAgregarCategoria, "update_inventario");
            _servicioPermisos.RegistrarBoton(btnAgregarMarca, "update_inventario");
            _servicioPermisos.RegistrarBoton(btnIngresarPerdida, "update_inventario");
        }
        #endregion
    }
}