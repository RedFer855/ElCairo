using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI; // Necesario para GestorRealtime
using ModernMenuUI.ClasesUI.Extenciones; // Si usas la extensión de doble buffer
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
        private readonly PresentacionRepositorio presentacionRepositorio;
        private readonly GestorRealtime<Presentacion> _gestorRealtime; // Implementación del Gestor

        private List<Presentacion> _listaMaestraPresentaciones = new List<Presentacion>();

        public Presentacion PresentacionSeleccionada { get; private set; }
        #endregion

        #region 2. Constructores
        public frmPresentaciones()
        {
            InitializeComponent();
            ConfigurarFormulario(); // Método auxiliar para no repetir código

            // Inicializamos repositorios y gestor
            presentacionRepositorio = new PresentacionRepositorio();
            _gestorRealtime = new GestorRealtime<Presentacion>();

            ConfigurarRealtime();
        }

        // Sobrecarga para modo 'Solo Selección'
        public frmPresentaciones(bool soloSeleccion)
        {
            InitializeComponent();
            ConfigurarFormulario();

            presentacionRepositorio = new PresentacionRepositorio();
            _gestorRealtime = new GestorRealtime<Presentacion>();

            if (soloSeleccion)
            {
                btnSeleccionarPresentacion.Visible = false;
                // Ajusta aquí si necesitas ocultar más botones en modo selección
            }
            FormBorderStyle = FormBorderStyle.None;

            ConfigurarRealtime();
        }

        private void ConfigurarFormulario()
        {
            this.DoubleBuffered = true;
            // Si tienes la extensión de ModernMenuUI activada:
            // dgvPresentaciones.ActivarDobleBuffer(); 
            dgvPresentaciones.AutoGenerateColumns = false;

            // Ocultar botones por defecto (según tu código original)
            btnAgregarPresentacion.Visible = false;
            btnModificarPresentacion.Visible = false;
        }

        private void ConfigurarRealtime()
        {
            // Suscripción a eventos del Gestor (Igual que en Productos)
            _gestorRealtime.OnCambioBaseDatos += (c) => RecargarInterfazSafe();
            _gestorRealtime.OnReconexionExitosa += () => RecargarInterfazSafe();
        }
        #endregion

        #region 3. Eventos de Ciclo de Vida (Load / Closing)
        private async void frmPresentaciones_Load(object sender, EventArgs e)
        {
            // Carga inicial de datos
            await CargarPresentacionesMaestras();
            RefrescarGrid();

            // Iniciar suscripción Realtime
            await _gestorRealtime.SuscribirAsync();
        }

        private async void frmPresentaciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Limpieza de suscripción al cerrar
            await _gestorRealtime.DesuscribirAsync();
        }
        #endregion

        #region 4. Lógica de Carga y Actualización
        private void RecargarInterfazSafe()
        {
            // Método seguro para actualizar la UI desde el hilo de Realtime
            if (!this.IsDisposed && this.IsHandleCreated)
            {
                this.BeginInvoke((MethodInvoker)(async () =>
                {
                    await CargarPresentacionesMaestras();
                    RefrescarGrid();
                }));
            }
        }

        private async Task CargarPresentacionesMaestras()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                _listaMaestraPresentaciones = await presentacionRepositorio.ObtenerTodasLasPresentaciones();
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("No se pudo conectar con el servidor (tiempo de espera agotado).", "Error de Red", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar presentaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void RefrescarGrid()
        {
            this.Cursor = Cursors.WaitCursor;

            bool? estado = null;

            if (rbMostrarHabilitados.Checked) estado = true;
            if (rbMostrarDeshabilitados.Checked) estado = false;
            // Si rbMostrarTodos está marcado, estado queda null

            List<Presentacion> listaFiltrada;

            if (estado == null)
            {
                listaFiltrada = _listaMaestraPresentaciones;
            }
            else
            {
                listaFiltrada = _listaMaestraPresentaciones.Where(p => p.EstadoPresentacion == estado).ToList();
            }

            dgvPresentaciones.DataSource = null;
            dgvPresentaciones.DataSource = listaFiltrada;

            if (dgvPresentaciones.Rows.Count > 0)
                dgvPresentaciones.ClearSelection();

            this.Cursor = Cursors.Default;
        }
        #endregion

        #region 5. Eventos de UI (Filtros y Selección)
        private void rbMostrarHabilitados_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMostrarHabilitados.Checked) RefrescarGrid();
        }

        private void rbMostrarDeshabilitados_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMostrarDeshabilitados.Checked) RefrescarGrid();
        }

        private void rbMostrarTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMostrarTodos.Checked) RefrescarGrid();
        }

        private void dgvPresentaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                PresentacionSeleccionada = dgvPresentaciones.Rows[e.RowIndex].DataBoundItem as Presentacion;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnSeleccionarPresentacion_Click(object sender, EventArgs e)
        {
            if (dgvPresentaciones.SelectedRows.Count > 0)
            {
                PresentacionSeleccionada = dgvPresentaciones.SelectedRows[0].DataBoundItem as Presentacion;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}