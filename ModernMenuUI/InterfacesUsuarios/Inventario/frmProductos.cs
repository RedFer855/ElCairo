using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.ClasesUI.Extenciones;
using ModernMenuUI.InterfacesUsuarios.Inventario;
using ModernMenuUI.ServiciosUI;
using Supabase.Realtime.PostgresChanges;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private readonly ProductoRepositorio _productoRepositorio;
        private readonly ServicioPermisosUI _servicioPermisos;
        private readonly GestorRealtime<Producto> _gestorRealtime;

        private BuscadorInteractivo<Producto> _buscadorCtrl;
        private List<Producto> _listaMaestraProductos = new List<Producto>();
        private Producto ProductoSeleccionado;
        private int? _filtroMarcaId = null;
        private int? _filtroCategoriaId = null;

        // Evita recargas simultáneas por eventos de realtime
        private readonly SemaphoreSlim _semaforoRecarga = new SemaphoreSlim(1, 1);

        // Bandera para no seguir trabajando al cerrar
        private bool _cerrandoFormulario = false;

        // Evita limpiar dos veces
        private bool _limpiezaEjecutada = false;

        #endregion

        #region 2. Constructor y Load

        public frmProductos()
        {
            InitializeComponent();

            _productoRepositorio = new ProductoRepositorio();
            _servicioPermisos = new ServicioPermisosUI();
            _gestorRealtime = new GestorRealtime<Producto>();

            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.ActivarDobleBuffer();
            dgvProductos.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 230, 241);

            RegistrarBotonesConPermisos();
            _servicioPermisos.AplicarPermisos();
            ConfigurarEventosUnificados();

            // Importante: usar métodos nombrados para poder desuscribir correctamente
            _gestorRealtime.OnCambioBaseDatos += GestorRealtime_OnCambioBaseDatos;
            _gestorRealtime.OnReconexionExitosa += GestorRealtime_OnReconexionExitosa;

            // Por si no los conectaste desde el diseñador
            this.Load += frmProductos_Load;
            this.FormClosing += frmProductos_FormClosing;
            this.FormClosed += frmProductos_FormClosed;
        }

        private async void frmProductos_Load(object sender, EventArgs e)
        {
            await InicializarDatosYBuscador();
            await _gestorRealtime.SuscribirAsync();
        }

        #endregion

        #region 3. Cierre y Limpieza

        private async void frmProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            _cerrandoFormulario = true;

            try
            {
                // Primero rompemos la relación del formulario con el realtime
                _gestorRealtime.OnCambioBaseDatos -= GestorRealtime_OnCambioBaseDatos;
                _gestorRealtime.OnReconexionExitosa -= GestorRealtime_OnReconexionExitosa;

                // Luego liberamos completamente el gestor
                await _gestorRealtime.LiberarAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error liberando realtime en frmProductos: {ex.Message}");
            }

            // Limpieza local temprana
            LimpiarRecursosLocales();
        }

        private void frmProductos_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Limpieza final ligera por si algo siguió referenciado hasta el cierre final
            LimpiarRecursosLocales();
        }

        private void LimpiarRecursosLocales()
        {
            if (_limpiezaEjecutada)
                return;

            _limpiezaEjecutada = true;

            try
            {
                _buscadorCtrl?.Liberar();
                _buscadorCtrl = null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error liberando buscador: {ex.Message}");
            }

            try
            {
                dgvProductos.DataSource = null;
                lstSugerencias.DataSource = null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error limpiando controles enlazados: {ex.Message}");
            }

            try
            {
                ProductoSeleccionado = null;

                _listaMaestraProductos?.Clear();
                _listaMaestraProductos = null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error liberando listas del formulario: {ex.Message}");
            }

            try
            {
                if (_semaforoRecarga.CurrentCount == 0)
                {
                    // no hacemos nada si está ocupado; solo evitamos tocarlo mal
                }
            }
            catch
            {
            }
        }

        #endregion

        #region 4. Lógica de Carga y Realtime

        private void GestorRealtime_OnCambioBaseDatos(PostgresChangesResponse cambio)
        {
            RecargarInterfazSafe();
        }

        private void GestorRealtime_OnReconexionExitosa()
        {
            RecargarInterfazSafe();
        }

        private async Task InicializarDatosYBuscador()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                _listaMaestraProductos = await _productoRepositorio.ObtenerTodosLosProductos(null);

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
                        if (!busquedaActiva)
                            RefrescarGrid();
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
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private async Task CargarProductosMaestrosSeguro()
        {
            if (_cerrandoFormulario || IsDisposed || !IsHandleCreated || _limpiezaEjecutada)
                return;

            if (!await _semaforoRecarga.WaitAsync(0))
                return;

            try
            {
                var productos = await _productoRepositorio.ObtenerTodosLosProductos(null);

                if (_cerrandoFormulario || IsDisposed || _limpiezaEjecutada)
                    return;

                _listaMaestraProductos = productos ?? new List<Producto>();
                _buscadorCtrl?.ActualizarDatosMaestros(_listaMaestraProductos);

                RefrescarGrid();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error recarga: {ex.Message}");
            }
            finally
            {
                _semaforoRecarga.Release();
            }
        }

        private void RecargarInterfazSafe()
        {
            if (_cerrandoFormulario || IsDisposed || !IsHandleCreated || _limpiezaEjecutada)
                return;

            BeginInvoke(new MethodInvoker(async () => await CargarProductosMaestrosSeguro()));
        }

        #endregion

        #region 5. Búsqueda

        private async void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if (_buscadorCtrl == null || _cerrandoFormulario || _limpiezaEjecutada)
                return;

            await _buscadorCtrl.ManejarKeyUpAsync(e);
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (_buscadorCtrl == null || _cerrandoFormulario || _limpiezaEjecutada)
                return;

            _buscadorCtrl.ManejarKeyDown(e);
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (_buscadorCtrl == null || _cerrandoFormulario || _limpiezaEjecutada)
                return;

            _buscadorCtrl.ManejarLeave();
        }

        private void lstSugerencias_MouseClick(object sender, MouseEventArgs e)
        {
            if (_buscadorCtrl == null || _cerrandoFormulario || _limpiezaEjecutada)
                return;

            _buscadorCtrl.ManejarClickLista();
        }

        private void lstSugerencias_KeyDown(object sender, KeyEventArgs e)
        {
            if (_buscadorCtrl == null || _cerrandoFormulario || _limpiezaEjecutada)
                return;

            if (e.KeyCode == Keys.Enter)
                _buscadorCtrl.ManejarClickLista();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (_buscadorCtrl == null || _cerrandoFormulario || _limpiezaEjecutada)
                return;

            _buscadorCtrl.ManejarKeyDown(new KeyEventArgs(Keys.Enter));
        }

        #endregion

        #region 6. Filtrado y Grid

        private void RefrescarGrid()
        {
            if (_cerrandoFormulario || _limpiezaEjecutada || _listaMaestraProductos == null)
                return;

            gbxEstado.Enabled = false;

            try
            {
                IEnumerable<Producto> query = _listaMaestraProductos.AsEnumerable();

                if (rbMostrarHabilitados.Checked)
                    query = query.Where(p => p.EstadoProducto);
                else if (rbMostrardeshabilitados.Checked)
                    query = query.Where(p => !p.EstadoProducto);

                if (_filtroMarcaId.HasValue)
                    query = query.Where(p => p.IdMarca == _filtroMarcaId.Value);

                if (_filtroCategoriaId.HasValue)
                    query = query.Where(p => p.IdCategoria == _filtroCategoriaId.Value);

                var listaFinal = query.ToList();

                dgvProductos.DataSource = null;
                dgvProductos.DataSource = listaFinal;

                bool hayFiltros = !rbMostrarHabilitados.Checked || _filtroMarcaId != null || _filtroCategoriaId != null;
                pnlLimpiarFiltros.Visible = hayFiltros;

                if (listaFinal.Count > 0)
                    dgvProductos.ClearSelection();
            }
            finally
            {
                gbxEstado.Enabled = true;
            }
        }

        private void ConfigurarEventosUnificados()
        {
            rbMostrarTodos.CheckedChanged += FiltroEstado_Changed;
            rbMostrarHabilitados.CheckedChanged += FiltroEstado_Changed;
            rbMostrardeshabilitados.CheckedChanged += FiltroEstado_Changed;
        }

        private void FiltroEstado_Changed(object sender, EventArgs e)
        {
            if (_cerrandoFormulario || _limpiezaEjecutada)
                return;

            if (sender is RadioButton rb && rb.Checked)
                RefrescarGrid();
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (_cerrandoFormulario || _limpiezaEjecutada)
                return;

            if (dgvProductos.SelectedRows.Count > 0)
                ProductoSeleccionado = dgvProductos.SelectedRows[0].DataBoundItem as Producto;
            else
                ProductoSeleccionado = null;
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            if (_cerrandoFormulario || _limpiezaEjecutada)
                return;

            _filtroMarcaId = null;
            _filtroCategoriaId = null;

            txtFiltroMarca.Text = string.Empty;
            txtFiltroCategoria.Text = string.Empty;

            rbMostrarHabilitados.Checked = true;

            _buscadorCtrl?.LimpiarBusqueda();
            RefrescarGrid();
        }

        #endregion

        #region 7. CRUD

        private async void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            if (_cerrandoFormulario || _limpiezaEjecutada)
                return;

            await AbrirEditorProducto(null);
        }

        private async void btnEditarProducto_Click(object sender, EventArgs e)
        {
            if (_cerrandoFormulario || _limpiezaEjecutada)
                return;

            if (ProductoSeleccionado == null)
            {
                MessageBox.Show(
                    "Seleccione un producto primero.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            await AbrirEditorProducto(ProductoSeleccionado);
        }

        private async Task AbrirEditorProducto(Producto prod)
        {
            using var frm = prod == null
                ? new frmAgregarEditarProducto()
                : new frmAgregarEditarProducto(prod);

            if (frm.ShowDialog() == DialogResult.OK)
                await CargarProductosMaestrosSeguro();
        }

        private void btnIngresarPerdida_Click(object sender, EventArgs e)
        {
            if (_cerrandoFormulario || _limpiezaEjecutada)
                return;

            using var frm = new frmAgregarEditarProducto();
            frm.ShowDialog();
        }

        #endregion

        #region 8. Filtros de Marcas y Categorías

        private void AbrirFiltro<TForm>(Func<TForm> factory, Action<TForm> onSuccess)
            where TForm : Form
        {
            if (_cerrandoFormulario || _limpiezaEjecutada)
                return;

            using var frm = factory();

            if (frm.ShowDialog() == DialogResult.OK)
                onSuccess(frm);
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
        {
            if (_cerrandoFormulario || _limpiezaEjecutada)
                return;

            using var frm = new frmMarcas();
            frm.ShowDialog();
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            if (_cerrandoFormulario || _limpiezaEjecutada)
                return;

            using var frm = new frmCategorias();
            frm.ShowDialog();
        }

        #endregion

        #region 9. Helpers y UI

        private void btnSalir_Click(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            Close();
        }

        private void RegistrarBotonesConPermisos()
        {
            _servicioPermisos.RegistrarBoton(btnNuevoProducto, "create_inventario");
            _servicioPermisos.RegistrarBoton(btnEditarProducto, "update_inventario");
            _servicioPermisos.RegistrarBoton(btnAgregarCategoria, "update_inventario");
            _servicioPermisos.RegistrarBoton(btnAgregarMarca, "update_inventario");
            _servicioPermisos.RegistrarBoton(btnIngresarPerdida, "update_inventario");
        }

        #endregion

        private void lblHora_Click(object sender, EventArgs e)
        {

        }
    }
}