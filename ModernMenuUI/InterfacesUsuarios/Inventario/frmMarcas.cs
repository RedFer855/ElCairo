using CapaDeDatos.Datos;
using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.ClasesUI.Extenciones;
using ModernMenuUI.InterfacesUsuarios.Compras;
using ModernMenuUI.ServiciosUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI.InterfacesUsuarios.Inventario
{
    /// <summary>
    /// Formulario para administración, filtrado, búsqueda y selección de marcas.
    /// Ofrece:
    /// - Búsqueda interactiva con sugerencias.
    /// - Filtrado por estado (habilitado / deshabilitado).
    /// - Recarga automática mediante Realtime.
    /// - Selección de marca para otros formularios (modo modal).
    /// </summary>
    public partial class frmMarcas : Form
    {
        #region 1. Campos y Dependencias

        /// <summary>Repositorio encargado de las operaciones CRUD de marcas.</summary>
        private readonly MarcaRepositorio _marcaRepositorio;

        /// <summary>Gestor responsable de escuchar cambios en tiempo real (Supabase Realtime).</summary>
        private readonly GestorRealtime<Marca> _gestorRealtime;

        /// <summary>Controlador general de búsqueda interactiva.</summary>
        private BuscadorInteractivo<Marca> _buscadorCtrl;

        /// <summary>Lista maestra de marcas cargadas desde el repositorio.</summary>
        private List<Marca> _listaMaestraMarcas = new List<Marca>();

        /// <summary>Marca actualmente seleccionada en la grilla.</summary>
        private Marca _marcaSeleccionada;

        /// <summary>Marca seleccionada cuando el formulario actúa en modo modal.</summary>
        public Marca MarcaSeleccionada { get; private set; }

        #endregion

        #region 2. Constructor y Load

        /// <summary>
        /// Constructor principal para el modo de administración de marcas.
        /// </summary>
        public frmMarcas()
        {
            InitializeComponent();
            ConfigurarFormulario();

            _marcaRepositorio = new MarcaRepositorio();
            _gestorRealtime = new GestorRealtime<Marca>();

            ConfigurarRealtime();
        }

        /// <summary>
        /// Constructor alterno utilizado cuando el formulario actúa como selector modal.
        /// </summary>
        public frmMarcas(bool tipo)
        {
            InitializeComponent();
            ConfigurarFormulario();

            _marcaRepositorio = new MarcaRepositorio();
            _gestorRealtime = new GestorRealtime<Marca>();

            // En modo selección, ocultamos controles administrativos.
            FormBorderStyle = FormBorderStyle.None;
            btnSeleccionarMarca.Visible = false;

            ConfigurarRealtime();
        }

        /// <summary>
        /// Configura parámetros visuales e iniciales del formulario.
        /// </summary>
        private void ConfigurarFormulario()
        {
            this.DoubleBuffered = true;
            dgvMarcas.AutoGenerateColumns = false;

            ConfigurarEventosUnificados();
        }

        /// <summary>
        /// Configura la escucha de cambios en tiempo real.
        /// </summary>
        private void ConfigurarRealtime()
        {
            _gestorRealtime.OnCambioBaseDatos += (c) => RecargarInterfazSafe();
            _gestorRealtime.OnReconexionExitosa += () => RecargarInterfazSafe();
        }

        /// <summary>
        /// Evento LOAD — inicializa datos, activa buscador y suscribe realtime.
        /// </summary>
        private async void frmMarcas_Load(object sender, EventArgs e)
        {
            await InicializarDatosYBuscador();
            await _gestorRealtime.SuscribirAsync();
        }

        /// <summary>
        /// Al cerrar el formulario se desuscribe del realtime.
        /// </summary>
        private async void frmMarcas_FormClosing(object sender, FormClosingEventArgs e)
        {
            await _gestorRealtime.DesuscribirAsync();
        }

        #endregion

        #region 3. Lógica de Carga y Realtime

        /// <summary>
        /// Método seguro para recargar la interfaz desde un hilo distinto al de UI.
        /// </summary>
        private void RecargarInterfazSafe()
        {
            if (!this.IsDisposed && this.IsHandleCreated)
            {
                this.BeginInvoke((MethodInvoker)(async () =>
                    await CargarMarcasMaestras()
                ));
            }
        }

        /// <summary>
        /// Carga marcas desde el repositorio y prepara el controlador de búsqueda interactiva.
        /// </summary>
        private async Task InicializarDatosYBuscador()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _listaMaestraMarcas = await _marcaRepositorio.ObtenerTodasLasMarcas(null);

                // Configuración del buscador interactivo
                _buscadorCtrl = new BuscadorInteractivo<Marca>(
                    txtBuscar,
                    lstSugerencias,
                    dgvMarcas,
                    _listaMaestraMarcas,

                    // Criterio exacto -> ID
                    (m, term) => m.IdMarca.ToString() == term,

                    // Criterio parcial -> nombre marca o proveedor
                    (m, term) =>
                    {
                        bool porNombreMarca = m.NombreMarca != null &&
                            m.NombreMarca.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0;

                        bool porProveedor = m.NombreProveedor != null &&
                            m.NombreProveedor.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0;

                        return porNombreMarca || porProveedor;
                    },

                    // Texto de visualización en sugerencias -> solo nombre de marca
                    (m) => m.NombreMarca,

                    // Callback UI al activar/desactivar búsqueda
                    (busquedaActiva) =>
                    {
                        if (pnlLimpiarFiltros != null)
                            pnlLimpiarFiltros.Visible = busquedaActiva;

                        if (!busquedaActiva)
                            RefrescarGrid();
                    },

                    // No usamos validación de código (no aplica)
                    (txt) => false
                );

                RefrescarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inicializando datos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Recarga la lista maestra desde base de datos y actualiza buscador y grilla.
        /// </summary>
        private async Task CargarMarcasMaestras()
        {
            try
            {
                _listaMaestraMarcas = await _marcaRepositorio.ObtenerTodasLasMarcas(null);

                _buscadorCtrl?.ActualizarDatosMaestros(_listaMaestraMarcas);

                RefrescarGrid();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error recargando marcas: {ex.Message}");
            }
        }

        #endregion

        #region 4. Búsqueda Delegada al Controlador

        /// <summary>Evento KeyUp que activa búsqueda interactiva.</summary>
        private async void txtBuscar_KeyUp(object sender, KeyEventArgs e) =>
            await _buscadorCtrl.ManejarKeyUpAsync(e);

        /// <summary>Navegación y comportamiento especial del buscador.</summary>
        private void txtBuscar_KeyDown(object sender, KeyEventArgs e) =>
            _buscadorCtrl.ManejarKeyDown(e);

        private void lstSugerencias_MouseClick(object sender, MouseEventArgs e) =>
            _buscadorCtrl.ManejarClickLista();

        private void lstSugerencias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                _buscadorCtrl.ManejarClickLista();
        }

        /// <summary>Simula Enter sobre el buscador.</summary>
        private void btnBuscar_Click(object sender, EventArgs e) =>
            _buscadorCtrl.ManejarKeyDown(new KeyEventArgs(Keys.Enter));

        #endregion

        #region 5. Filtrado y Grid

        /// <summary>
        /// Aplica filtros de estado y de texto, y refresca el DataGridView.
        /// </summary>
        private void RefrescarGrid()
        {
            if (_listaMaestraMarcas == null) return;

            this.Cursor = Cursors.WaitCursor;

            IEnumerable<Marca> query = _listaMaestraMarcas;

            // Filtrar por estado
            if (rbMostrarHablilitados.Checked)
                query = query.Where(m => m.EstadoMarca == true);

            else if (rbMostrarDeshablitados.Checked)
                query = query.Where(m => m.EstadoMarca == false);

            // Filtrar por texto
            string textoBusqueda = txtBuscar.Text.Trim();
            if (!string.IsNullOrEmpty(textoBusqueda))
            {
                query = query.Where(m =>
                    (m.NombreMarca != null &&
                     m.NombreMarca.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0)
                    ||
                    (m.NombreProveedor != null &&
                     m.NombreProveedor.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0)
                );
            }

            var listaFinal = query.ToList();

            dgvMarcas.DataSource = null;
            dgvMarcas.DataSource = listaFinal;

            bool hayFiltrosActivos =
                !rbMostrarHablilitados.Checked ||
                !string.IsNullOrEmpty(textoBusqueda);

            if (pnlLimpiarFiltros != null)
                pnlLimpiarFiltros.Visible = hayFiltrosActivos;

            if (dgvMarcas.Rows.Count > 0)
                dgvMarcas.ClearSelection();

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Conecta todos los RadioButtons de estado a un solo evento.
        /// </summary>
        private void ConfigurarEventosUnificados()
        {
            rbMostrarTodos.CheckedChanged += FiltroEstado_Changed;
            rbMostrarHablilitados.CheckedChanged += FiltroEstado_Changed;
            rbMostrarDeshablitados.CheckedChanged += FiltroEstado_Changed;
        }

        /// <summary>
        /// Evento unificado de cambio de estado; refresca la grilla cuando un RadioButton cambia.
        /// </summary>
        private void FiltroEstado_Changed(object sender, EventArgs e)
        {
            if (sender is RadioButton rb && rb.Checked)
                RefrescarGrid();
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            _buscadorCtrl.LimpiarBusqueda();
            rbMostrarHablilitados.Checked = true;

            if (pnlLimpiarFiltros != null)
                pnlLimpiarFiltros.Visible = false;

            RefrescarGrid();
        }

        #endregion

        #region 6. Acciones CRUD y Selección

        /// <summary>
        /// Abre formulario para agregar una nueva marca.
        /// </summary>
        private async void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            frmAgregarEditarMarca nuevaMarca = new frmAgregarEditarMarca();

            if (nuevaMarca.ShowDialog() == DialogResult.OK)
                await CargarMarcasMaestras();
        }

        /// <summary>
        /// Abre formulario para modificar la marca seleccionada.
        /// </summary>
        private async void btnModificarMarca_Click(object sender, EventArgs e)
        {
            if (_marcaSeleccionada != null)
            {
                frmAgregarEditarMarca editarForm = new frmAgregarEditarMarca(_marcaSeleccionada);

                if (editarForm.ShowDialog() == DialogResult.OK)
                    await CargarMarcasMaestras();
            }
            else
            {
                MessageBox.Show("Seleccione una marca primero.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Actualiza la marca seleccionada cuando cambia la selección de la grilla.
        /// </summary>
        private void dgvMarcas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMarcas.SelectedRows.Count > 0)
                _marcaSeleccionada = dgvMarcas.SelectedRows[0].DataBoundItem as Marca;
            else
                _marcaSeleccionada = null;
        }

        /// <summary>
        /// Botón de seleccionar marca (en modo modal).
        /// </summary>
        private void btnSeleccionarMarca_Click(object sender, EventArgs e)
        {
            ConfirmarSeleccion();
        }

        /// <summary>
        /// Doble clic para seleccionar marca.
        /// </summary>
        private void dgvMarcas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ConfirmarSeleccion();
        }

        /// <summary>
        /// Cierra el formulario devolviendo la marca seleccionada.
        /// </summary>
        private void ConfirmarSeleccion()
        {
            if (dgvMarcas.SelectedRows.Count > 0)
            {
                MarcaSeleccionada = dgvMarcas.SelectedRows[0].DataBoundItem as Marca;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// Abre el formulario de proveedores desde marcas.
        /// </summary>
        private void btnProveedores_Click(object sender, EventArgs e)
        {
            frmProveedor provNuevo = new frmProveedor();
            provNuevo.ShowDialog();
        }

        /// <summary>
        /// Cierra el formulario.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
