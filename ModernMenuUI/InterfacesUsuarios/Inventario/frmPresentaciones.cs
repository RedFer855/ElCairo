using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.ServiciosUI; // Necesario para BuscadorInteractivo
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI.InterfacesUsuarios.Inventario
{
    public partial class frmPresentaciones : Form
    {
        #region 1. Campos y Dependencias
        private readonly PresentacionRepositorio _presentacionRepositorio;
        private readonly GestorRealtime<Presentacion> _gestorRealtime;

        // Agregamos el BuscadorInteractivo
        private BuscadorInteractivo<Presentacion> _buscadorCtrl;

        // Lista maestra en memoria
        private List<Presentacion> _listaCompletaPresentaciones = new List<Presentacion>();

        private Presentacion _presentacionSeleccionada;
        public Presentacion PresentacionSeleccionada { get; private set; }
        #endregion

        #region 2. Constructores
        public frmPresentaciones()
        {
            InitializeComponent();
            ConfigurarFormulario();

            _presentacionRepositorio = new PresentacionRepositorio();
            _gestorRealtime = new GestorRealtime<Presentacion>();

            // Configuración visual por defecto (se mantiene tu lógica original de ocultar botones)
            btnAgregarPresentacion.Visible = false;
            btnModificarPresentacion.Visible = false;
            if (pnlLimpiarFiltros != null) pnlLimpiarFiltros.Visible = false;

            ConfigurarRealtime();
        }

        public frmPresentaciones(bool soloSeleccion)
        {
            InitializeComponent();
            ConfigurarFormulario();

            _presentacionRepositorio = new PresentacionRepositorio();
            _gestorRealtime = new GestorRealtime<Presentacion>();

            FormBorderStyle = FormBorderStyle.None;

            if (soloSeleccion)
            {
                btnSeleccionarPresentacion.Visible = false;
            }
            if (pnlLimpiarFiltros != null) pnlLimpiarFiltros.Visible = false;

            ConfigurarRealtime();
        }

        private void ConfigurarFormulario()
        {
            this.DoubleBuffered = true;
            dgvPresentaciones.AutoGenerateColumns = false;
            ConfigurarEventosUnificados();

            // IMPORTANTE: Evitamos el filtrado automático al escribir para delegarlo al buscador
        }

        private void ConfigurarRealtime()
        {
            _gestorRealtime.OnCambioBaseDatos += (c) => RecargarInterfazSafe();
            _gestorRealtime.OnReconexionExitosa += () => RecargarInterfazSafe();
        }
        #endregion

        #region 3. Carga y Lógica Principal
        private async void frmPresentaciones_Load(object sender, EventArgs e)
        {
            // Asegurar un radio button por defecto
            if (!rbMostrarTodos.Checked && !rbMostrarHabilitados.Checked && !rbMostrarDeshabilitados.Checked)
            {
                rbMostrarTodos.Checked = true;
            }

            await InicializarDatosYBuscador();
            await _gestorRealtime.SuscribirAsync();
        }

        private async void frmPresentaciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            await _gestorRealtime.DesuscribirAsync();
        }

        private void RecargarInterfazSafe()
        {
            if (!this.IsDisposed && this.IsHandleCreated)
                this.BeginInvoke((MethodInvoker)(async () => await CargarPresentacionesMaestras()));
        }

        private async Task InicializarDatosYBuscador()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                // Carga inicial de datos
                _listaCompletaPresentaciones = await _presentacionRepositorio.ObtenerTodasLasPresentaciones();

                // Configuración del Buscador Interactivo
                _buscadorCtrl = new BuscadorInteractivo<Presentacion>(
                    txtBuscar,
                    lstSugerencias,
                    dgvPresentaciones,
                    _listaCompletaPresentaciones,
                    (p, term) => p.IdPresentacionProducto.ToString() == term, // Buscar por ID
                    (p, term) => p.NombrePresentacion != null && p.NombrePresentacion.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0, // Buscar por NombreEmpleado
                    (p) => p.NombrePresentacion, // Texto a mostrar en sugerencias
                    (buscando) =>
                    {
                        if (pnlLimpiarFiltros != null) pnlLimpiarFiltros.Visible = buscando;
                        // Solo refrescamos grid si LIMPIA la búsqueda (buscando = false)
                        if (!buscando) RefrescarGrid();
                    },
                    (txt) => false // Validación extra si fuera necesaria
                );

                RefrescarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally { this.Cursor = Cursors.Default; }
        }

        private async Task CargarPresentacionesMaestras()
        {
            try
            {
                _listaCompletaPresentaciones = await _presentacionRepositorio.ObtenerTodasLasPresentaciones();
                if (_buscadorCtrl != null) _buscadorCtrl.ActualizarDatosMaestros(_listaCompletaPresentaciones);
                RefrescarGrid();
            }
            catch (Exception ex)
            {
                // Manejo silencioso o log en reconexión
                Console.WriteLine(ex.Message);
            }
        }

        private void RefrescarGrid()
        {
            if (_listaCompletaPresentaciones == null) return;
            this.Cursor = Cursors.WaitCursor;

            // 1. Filtro de Estado (En Memoria - Optimizado)
            IEnumerable<Presentacion> query = _listaCompletaPresentaciones;

            if (rbMostrarHabilitados.Checked)
                query = query.Where(p => p.EstadoPresentacion == true);
            else if (rbMostrarDeshabilitados.Checked)
                query = query.Where(p => p.EstadoPresentacion == false);

            // Actualizamos la lista base del buscador con lo filtrado por estado
            if (_buscadorCtrl != null) _buscadorCtrl.ActualizarDatosMaestros(query.ToList());

            // 2. Filtro de Texto (Solo aplica cuando llamamos a este método manualmente o por cambio de radio button)
            string texto = txtBuscar.Text.Trim();
            if (!string.IsNullOrEmpty(texto))
            {
                query = query.Where(p => p.NombrePresentacion != null &&
                                         p.NombrePresentacion.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            // 3. Bind al Grid
            var listaFinal = query.ToList();
            dgvPresentaciones.DataSource = null;
            dgvPresentaciones.DataSource = listaFinal;

            // Botón Limpiar (Lógica visual)
            if (pnlLimpiarFiltros != null)
            {
                bool hayFiltros = !rbMostrarHabilitados.Checked || !string.IsNullOrEmpty(texto);
                pnlLimpiarFiltros.Visible = hayFiltros;
            }

            if (dgvPresentaciones.Rows.Count > 0) dgvPresentaciones.ClearSelection();
            this.Cursor = Cursors.Default;
        }

        private void ConfigurarEventosUnificados()
        {
            // Unificamos lógica para no repetir código en cada RadioButton
            rbMostrarTodos.CheckedChanged += (s, e) => { if (((RadioButton)s).Checked) RefrescarGrid(); };
            rbMostrarHabilitados.CheckedChanged += (s, e) => { if (((RadioButton)s).Checked) RefrescarGrid(); };
            rbMostrarDeshabilitados.CheckedChanged += (s, e) => { if (((RadioButton)s).Checked) RefrescarGrid(); };
        }
        #endregion

        #region 4. Eventos Buscador (Delegados al BuscadorInteractivo)

        private async void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if (_buscadorCtrl != null) await _buscadorCtrl.ManejarKeyUpAsync(e);
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (_buscadorCtrl != null) _buscadorCtrl.ManejarKeyDown(e);
        }

        private void lstSugerencias_MouseClick(object sender, MouseEventArgs e)
        {
            if (_buscadorCtrl != null) _buscadorCtrl.ManejarClickLista();
        }

        private void lstSugerencias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && _buscadorCtrl != null) _buscadorCtrl.ManejarClickLista();
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            if (_buscadorCtrl != null) _buscadorCtrl.LimpiarBusqueda();
            rbMostrarHabilitados.Checked = true; // O el default que prefieras
            if (pnlLimpiarFiltros != null) pnlLimpiarFiltros.Visible = false;
            RefrescarGrid();
        }
        #endregion

        #region 5. Selección y Salida

        // Nota: Los botones de Agregar/Modificar existen pero estaban ocultos en tu código original.
        // Si necesitas su lógica, sería análoga a la de Categorías.

        private void dgvPresentaciones_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPresentaciones.SelectedRows.Count > 0)
                _presentacionSeleccionada = dgvPresentaciones.SelectedRows[0].DataBoundItem as Presentacion;
            else
                _presentacionSeleccionada = null;
        }

        private void btnSeleccionarPresentacion_Click(object sender, EventArgs e) => ConfirmarSeleccion();
        private void dgvPresentaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e) => ConfirmarSeleccion();

        private void ConfirmarSeleccion()
        {
            if (dgvPresentaciones.SelectedRows.Count > 0)
            {
                PresentacionSeleccionada = dgvPresentaciones.SelectedRows[0].DataBoundItem as Presentacion;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e) => this.Close();
        #endregion

        private async void btnModificarPresentacion_Click(object sender, EventArgs e)
        {
            if (_presentacionSeleccionada != null)
            {
                if (new frmAgregarEditarPresentacion(_presentacionSeleccionada).ShowDialog() == DialogResult.OK) await CargarPresentacionesMaestras();
            }
            else
            {
                MessageBox.Show("Seleccione una presentación.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnAgregarPresentacion_Click(object sender, EventArgs e)
        {
            if (new frmAgregarEditarPresentacion().ShowDialog() == DialogResult.OK) await CargarPresentacionesMaestras();
        }
    }
}