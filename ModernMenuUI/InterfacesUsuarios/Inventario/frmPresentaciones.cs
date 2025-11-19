using CapaDeDatos.Datos;
using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion.CapaServiciosSeguridadValidacion;
using Supabase;
using Supabase.Realtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Supabase.Realtime.PostgresChanges.PostgresChangesOptions;

namespace ModernMenuUI.InterfacesUsuarios.Inventario
{
    public partial class frmPresentaciones : Form
    {
        private readonly PresentacionRepositorio presentacionRepositorio;
        private List<Presentacion> _listaMaestraPresentaciones = new List<Presentacion>();
        private RealtimeChannel? _presentacionesSubscription;
        private readonly ServicioVerificacionConexion _monitorConexion = new ServicioVerificacionConexion();
        private Supabase.Client? _supabaseClient;

        public Presentacion PresentacionSeleccionada { get; private set; }

        public frmPresentaciones()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            presentacionRepositorio = new PresentacionRepositorio();
            dgvPresentaciones.AutoGenerateColumns = false;

           
            btnAgregarPresentacion.Visible = false;
            btnModificarPresentacion.Visible = false;

            this.FormClosing += frmPresentaciones_FormClosing;
        }

        // Si quieres una sobrecarga tipo 'solo selección' como en marcas
        public frmPresentaciones(bool soloSeleccion)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            presentacionRepositorio = new PresentacionRepositorio();
            dgvPresentaciones.AutoGenerateColumns = false;
            this.FormClosing += frmPresentaciones_FormClosing;

            if (soloSeleccion)
            {
              
                btnSeleccionarPresentacion.Visible = false;
               
            }
        }

        private async void frmPresentaciones_Load(object sender, EventArgs e)
        {
            _monitorConexion.EstadoDeRedCambiado += MonitorConexion_EstadoDeRedCambiado;

            await CargarPresentacionesMaestras();
            RefrescarGrid();
            await IniciarSuscripcionPresentaciones();
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
            // Ajusta los nombres de los radio buttons según tu diseñador:
            if (rbMostrarHabilitados.Checked) estado = true;
            if (rbMostrarDeshabilitados.Checked) estado = false;

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

        private async Task DesecharSuscripcion()
        {
            if (_presentacionesSubscription != null)
            {
                try
                {
                    await Task.Run(() => _presentacionesSubscription.Unsubscribe());
                    System.Diagnostics.Debug.WriteLine("Suscripción de Presentaciones desechada.");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error al desechar suscripción Presentaciones: {ex.Message}");
                }

                _presentacionesSubscription = null;
            }
        }

        private async Task IniciarSuscripcionPresentaciones()
        {
            await DesecharSuscripcion();

            try
            {
                _supabaseClient = await Conexion.ConnectWithTimeoutAsync(3);

                _presentacionesSubscription = await _supabaseClient.From<Presentacion>()
                    .On(ListenType.All, (sender, change) =>
                    {
                        try
                        {
                            if (this == null || this.IsDisposed || !this.IsHandleCreated) return;

                            this.BeginInvoke((MethodInvoker)(async () =>
                            {
                                if (this.IsDisposed) return;
                                System.Diagnostics.Debug.WriteLine($"Cambio detectado: {change.Event} en Presentaciones.");

                                // 1. Recargar la lista maestra
                                await CargarPresentacionesMaestras();
                                // 2. Refrescar grid
                                RefrescarGrid();
                            }));
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"Error manejando evento Realtime Presentaciones: {ex.Message}");
                        }
                    });

                System.Diagnostics.Debug.WriteLine("Suscripción a Realtime (Presentaciones) creada.");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al suscribir a Realtime (Presentaciones): {ex.Message}");
            }
        }

        // --- MANEJO DE CONEXIÓN (igual que en frmMarcas) ---
        private async void MonitorConexion_EstadoDeRedCambiado(NetworkStatus status)
        {
            if (!this.IsHandleCreated || this.IsDisposed) return;

            if (status == NetworkStatus.Internet)
            {
                this.BeginInvoke((MethodInvoker)(async () =>
                {
                    if (this.IsDisposed) return;
                    System.Diagnostics.Debug.WriteLine("Red recuperada. Recargando Presentaciones y Realtime...");
                    await CargarPresentacionesMaestras();
                    RefrescarGrid();
                    await IniciarSuscripcionPresentaciones();
                }));
            }
        }

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

        private async void frmPresentaciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            await DesecharSuscripcion();
            _monitorConexion.EstadoDeRedCambiado -= MonitorConexion_EstadoDeRedCambiado;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
