using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.ServiciosUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI.InterfacesUsuarios.Inventario
{
    /// <summary>
    /// Formulario encargado de administrar, buscar, filtrar y seleccionar presentaciones de productos.
    /// Proporciona:
    /// - Búsqueda interactiva mediante BuscadorInteractivo{T}.
    /// - Filtrado por estado (habilitada / deshabilitada / todas).
    /// - Recarga automática vía Realtime cuando se detectan cambios externos.
    /// - Operaciones CRUD mediante formularios auxiliares.
    /// </summary>
    public partial class frmPresentaciones : Form
    {
        #region 1. Campos y Dependencias

        /// <summary>Repositorio encargado de ejecutar operaciones CRUD sobre Presentación.</summary>
        private readonly PresentacionRepositorio _presentacionRepositorio;

        /// <summary>Gestor de cambios en tiempo real para reflejar modificaciones externas.</summary>
        private readonly GestorRealtime<Presentacion> _gestorRealtime;

        /// <summary>Manejador de búsqueda inteligente basado en texto y sugerencias.</summary>
        private BuscadorInteractivo<Presentacion> _buscadorCtrl;

        /// <summary>Lista maestra que contiene todas las presentaciones cargadas desde la DB.</summary>
        private List<Presentacion> _listaCompletaPresentaciones = new List<Presentacion>();

        /// <summary>Presentación seleccionada en la grilla.</summary>
        private Presentacion _presentacionSeleccionada;

        /// <summary>Presentación retornada cuando el formulario actúa como selector modal.</summary>
        public Presentacion PresentacionSeleccionada { get; private set; }

        #endregion

        #region 2. Constructores

        /// <summary>
        /// Constructor por defecto para modo administración.
        /// </summary>
        public frmPresentaciones()
        {
            InitializeComponent();
            ConfigurarFormulario();

            _presentacionRepositorio = new PresentacionRepositorio();
            _gestorRealtime = new GestorRealtime<Presentacion>();

            if (pnlLimpiarFiltros != null) pnlLimpiarFiltros.Visible = false;
            ConfigurarRealtime();
        }

        /// <summary>
        /// Constructor alternativo para modo selección.
        /// </summary>
        public frmPresentaciones(bool soloSeleccion)
        {
            InitializeComponent();
            ConfigurarFormulario();

            _presentacionRepositorio = new PresentacionRepositorio();
            _gestorRealtime = new GestorRealtime<Presentacion>();

            // En modo modal: sin bordes y sin el botón seleccionar (opcional).
            FormBorderStyle = FormBorderStyle.None;

            if (soloSeleccion)
                btnSeleccionarPresentacion.Visible = false;

            if (pnlLimpiarFiltros != null) pnlLimpiarFiltros.Visible = false;

            ConfigurarRealtime();
        }

        /// <summary>
        /// Configuración general del formulario: performance, estilos y eventos básicos.
        /// </summary>
        private void ConfigurarFormulario()
        {
            this.DoubleBuffered = true;
            dgvPresentaciones.AutoGenerateColumns = false;
            ConfigurarEventosUnificados();
        }

        /// <summary>
        /// Configura eventos del gestor realtime para actualizar la interfaz cuando la base cambia.
        /// </summary>
        private void ConfigurarRealtime()
        {
            _gestorRealtime.OnCambioBaseDatos += (c) => RecargarInterfazSafe();
            _gestorRealtime.OnReconexionExitosa += () => RecargarInterfazSafe();
        }

        #endregion

        #region 3. Carga y Lógica Principal

        /// <summary>
        /// Al inicializar, carga datos, activa el buscador y suscribe al realtime.
        /// </summary>
        private async void frmPresentaciones_Load(object sender, EventArgs e)
        {
            // Asegurar selección de estado válida
            if (!rbMostrarTodos.Checked &&
                !rbMostrarHabilitados.Checked &&
                !rbMostrarDeshabilitados.Checked)
            {
                rbMostrarTodos.Checked = true;
            }

            await InicializarDatosYBuscador();
            await _gestorRealtime.SuscribirAsync();
        }

        /// <summary>
        /// Al cerrar el formulario, se desuscribe del realtime.
        /// </summary>
        private async void frmPresentaciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            await _gestorRealtime.DesuscribirAsync();
        }

        /// <summary>
        /// Recarga segura desde hilos externos (invocado por realtime).
        /// </summary>
        private void RecargarInterfazSafe()
        {
            if (!this.IsDisposed && this.IsHandleCreated)
                this.BeginInvoke((MethodInvoker)(async () => await CargarPresentacionesMaestras()));
        }

        /// <summary>
        /// Carga inicial de datos y configuración del buscador interactivo.
        /// </summary>
        private async Task InicializarDatosYBuscador()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _listaCompletaPresentaciones =
                    await _presentacionRepositorio.ObtenerTodasLasPresentaciones();

                _buscadorCtrl = new BuscadorInteractivo<Presentacion>(
                    txtBuscar,
                    lstSugerencias,
                    dgvPresentaciones,
                    _listaCompletaPresentaciones,

                    // Búsqueda exacta por ID
                    (p, term) => p.IdPresentacionProducto.ToString() == term,

                    // Búsqueda parcial por nombre
                    (p, term) =>
                        p.NombrePresentacion != null &&
                        p.NombrePresentacion.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0,

                    // Representación textual en sugerencias
                    (p) => p.NombrePresentacion,

                    // Callback al activar/desactivar la búsqueda
                    (buscando) =>
                    {
                        if (pnlLimpiarFiltros != null)
                            pnlLimpiarFiltros.Visible = buscando;

                        if (!buscando)
                            RefrescarGrid();
                    },

                    // Extra validator no usado
                    (txt) => false
                );

                RefrescarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally { this.Cursor = Cursors.Default; }
        }

        /// <summary>
        /// Recarga los datos desde el repositorio y actualiza la grilla.
        /// </summary>
        private async Task CargarPresentacionesMaestras()
        {
            try
            {
                _listaCompletaPresentaciones =
                    await _presentacionRepositorio.ObtenerTodasLasPresentaciones();

                _buscadorCtrl?.ActualizarDatosMaestros(_listaCompletaPresentaciones);
                RefrescarGrid();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Aplica filtros de estado y texto, actualiza el DataGridView y el estado visual de filtros activos.
        /// </summary>
        private void RefrescarGrid()
        {
            if (_listaCompletaPresentaciones == null) return;

            this.Cursor = Cursors.WaitCursor;

            IEnumerable<Presentacion> query = _listaCompletaPresentaciones;

            // Filtro por estado
            if (rbMostrarHabilitados.Checked)
                query = query.Where(p => p.EstadoPresentacion == true);
            else if (rbMostrarDeshabilitados.Checked)
                query = query.Where(p => p.EstadoPresentacion == false);

            _buscadorCtrl?.ActualizarDatosMaestros(query.ToList());

            // Filtro textual
            string texto = txtBuscar.Text.Trim();
            if (!string.IsNullOrEmpty(texto))
            {
                query = query.Where(p =>
                    p.NombrePresentacion != null &&
                    p.NombrePresentacion.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            // Bind final
            var listaFinal = query.ToList();
            dgvPresentaciones.DataSource = null;
            dgvPresentaciones.DataSource = listaFinal;

            // Mostrar / ocultar panel limpiar
            if (pnlLimpiarFiltros != null)
            {
                bool hayFiltros =
                    !rbMostrarHabilitados.Checked || !string.IsNullOrEmpty(texto);

                pnlLimpiarFiltros.Visible = hayFiltros;
            }

            if (dgvPresentaciones.Rows.Count > 0)
                dgvPresentaciones.ClearSelection();

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Conexión de eventos de los radio buttons en una sola función lambda.
        /// </summary>
        private void ConfigurarEventosUnificados()
        {
            rbMostrarTodos.CheckedChanged += (s, e) =>
            {
                if (((RadioButton)s).Checked) RefrescarGrid();
            };

            rbMostrarHabilitados.CheckedChanged += (s, e) =>
            {
                if (((RadioButton)s).Checked) RefrescarGrid();
            };

            rbMostrarDeshabilitados.CheckedChanged += (s, e) =>
            {
                if (((RadioButton)s).Checked) RefrescarGrid();
            };
        }

        #endregion

        #region 4. Eventos Buscador (Delegados)

        private async void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if (_buscadorCtrl != null)
                await _buscadorCtrl.ManejarKeyUpAsync(e);
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            _buscadorCtrl?.ManejarKeyDown(e);
        }

        private void lstSugerencias_MouseClick(object sender, MouseEventArgs e)
        {
            _buscadorCtrl?.ManejarClickLista();
        }

        private void lstSugerencias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                _buscadorCtrl?.ManejarClickLista();
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            _buscadorCtrl?.LimpiarBusqueda();
            rbMostrarHabilitados.Checked = true;

            if (pnlLimpiarFiltros != null)
                pnlLimpiarFiltros.Visible = false;

            RefrescarGrid();
        }

        #endregion

        #region 5. Selección y Salida

        private void dgvPresentaciones_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPresentaciones.SelectedRows.Count > 0)
                _presentacionSeleccionada =
                    dgvPresentaciones.SelectedRows[0].DataBoundItem as Presentacion;
            else
                _presentacionSeleccionada = null;
        }

        private void btnSeleccionarPresentacion_Click(object sender, EventArgs e)
            => ConfirmarSeleccion();

        private void dgvPresentaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
            => ConfirmarSeleccion();

        /// <summary>
        /// Cierra el formulario devolviendo la presentación seleccionada.
        /// </summary>
        private void ConfirmarSeleccion()
        {
            if (dgvPresentaciones.SelectedRows.Count > 0)
            {
                PresentacionSeleccionada =
                    dgvPresentaciones.SelectedRows[0].DataBoundItem as Presentacion;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
            => this.Close();

        #endregion

        #region 6. CRUD

        private async void btnModificarPresentacion_Click(object sender, EventArgs e)
        {
            if (_presentacionSeleccionada != null)
            {
                if (new frmAgregarEditarPresentacion(_presentacionSeleccionada)
                    .ShowDialog() == DialogResult.OK)
                {
                    await CargarPresentacionesMaestras();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una presentación.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnAgregarPresentacion_Click(object sender, EventArgs e)
        {
            if (new frmAgregarEditarPresentacion()
                .ShowDialog() == DialogResult.OK)
            {
                await CargarPresentacionesMaestras();
            }
        }

        #endregion
    }
}
