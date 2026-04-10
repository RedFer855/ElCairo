using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.ServiciosUI;
using Supabase.Realtime.PostgresChanges;
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
        private readonly PresentacionRepositorio _presentacionRepositorio;
        private BuscadorInteractivo<Presentacion> _buscadorCtrl;
        private List<Presentacion> _listaCompletaPresentaciones = new List<Presentacion>();
        private Presentacion _presentacionSeleccionada;

        private Action<PostgresChangesResponse> _handlerCambio;

        public Presentacion PresentacionSeleccionada { get; private set; }

        public frmPresentaciones()
        {
            InitializeComponent();
            ConfigurarFormulario();

            _presentacionRepositorio = new PresentacionRepositorio();

            if (pnlLimpiarFiltros != null) pnlLimpiarFiltros.Visible = false;

            ConfigurarRealtime();
        }

        public frmPresentaciones(bool soloSeleccion)
        {
            InitializeComponent();
            ConfigurarFormulario();

            _presentacionRepositorio = new PresentacionRepositorio();

            FormBorderStyle = FormBorderStyle.None;

            if (soloSeleccion)
                btnSeleccionarPresentacion.Visible = false;

            if (pnlLimpiarFiltros != null) pnlLimpiarFiltros.Visible = false;

            ConfigurarRealtime();
        }

        private void ConfigurarFormulario()
        {
            this.DoubleBuffered = true;
            dgvPresentaciones.AutoGenerateColumns = false;
            ConfigurarEventosUnificados();
        }

        private void ConfigurarRealtime()
        {
            _handlerCambio = (c) => RecargarInterfazSafe();
            RealtimeManager.OnPresentacionChanged += _handlerCambio;
        }

        private async void frmPresentaciones_Load(object sender, EventArgs e)
        {
            if (!rbMostrarTodos.Checked &&
                !rbMostrarHabilitados.Checked &&
                !rbMostrarDeshabilitados.Checked)
            {
                rbMostrarTodos.Checked = true;
            }

            await InicializarDatosYBuscador();
        }

        private void frmPresentaciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_handlerCambio != null)
                    RealtimeManager.OnPresentacionChanged -= _handlerCambio;
            }
            catch { }
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

                _listaCompletaPresentaciones =
                                        await _presentacionRepositorio.ObtenerTodasLasPresentaciones();

                _buscadorCtrl = new BuscadorInteractivo<Presentacion>(
                    txtBuscar,
                    lstSugerencias,
                    dgvPresentaciones,
                    _listaCompletaPresentaciones,

                    (p, term) => p.IdPresentacionProducto.ToString() == term,

                    (p, term) =>
                    {
                        if (!p.EstadoPresentacion) return false;

                        return p.NombrePresentacion != null &&
                               p.NombrePresentacion.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0;
                    },

                    (p) => p.NombrePresentacion,

                    (buscando) =>
                    {
                        if (pnlLimpiarFiltros != null)
                            pnlLimpiarFiltros.Visible = buscando;

                        if (!buscando)
                            RefrescarGrid();
                    },

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

        private void RefrescarGrid()
        {
            if (_listaCompletaPresentaciones == null) return;

            this.Cursor = Cursors.WaitCursor;

            IEnumerable<Presentacion> query = _listaCompletaPresentaciones;

            if (rbMostrarHabilitados.Checked)
                query = query.Where(p => p.EstadoPresentacion == true);
            else if (rbMostrarDeshabilitados.Checked)
                query = query.Where(p => p.EstadoPresentacion == false);

            _buscadorCtrl?.ActualizarDatosMaestros(query.ToList());

            string texto = txtBuscar.Text.Trim();
            if (!string.IsNullOrEmpty(texto))
            {
                query = query.Where(p =>
                    p.NombrePresentacion != null &&
                    p.NombrePresentacion.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            var listaFinal = query.ToList();
            dgvPresentaciones.DataSource = null;
            dgvPresentaciones.DataSource = listaFinal;

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
    }
}