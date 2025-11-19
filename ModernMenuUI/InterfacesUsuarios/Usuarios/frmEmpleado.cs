using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using CapaServiciosSeguridadValidacion.CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
using Supabase;
using Supabase.Realtime;
using Supabase.Realtime.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Websocket.Client;
using static Supabase.Realtime.PostgresChanges.PostgresChangesOptions;

namespace ModernMenuUI
{
    public partial class frmEmpleado : Form
    {
        private readonly EmpleadoRepositorio _empleadoRepo;
        private Supabase.Realtime.RealtimeChannel? _empleadoSubscription;
        private readonly ServicioVerificacionConexion _monitorConexion = new ServicioVerificacionConexion();
        private Supabase.Client? _supabaseClient;
        private Empleado EmpleadoSeleccionado = null;

        public frmEmpleado()
        {
            InitializeComponent();
            dgvEmpleados.AutoGenerateColumns = false;
            _empleadoRepo = new EmpleadoRepositorio();

            // 👇 Aseguramos la limpieza de la suscripción cuando se cierre el formulario
            this.FormClosing += frmEmpleados_FormClosing;
        }

        private async void FrmEmpleados_Load(object sender, EventArgs e)
        {
            // Suscripción al monitor de red
            _monitorConexion.EstadoDeRedCambiado += MonitorConexion_EstadoDeRedCambiado;

            // Carga inicial
            await CargarEmpleados();

            // Inicia suscripción Realtime
            await IniciarSuscripcionEmpleados();
        }

        private async Task DesecharSuscripcion()
        {
            if (_empleadoSubscription != null)
            {
                try
                {
                    await Task.Run(() => _empleadoSubscription.Unsubscribe());
                    System.Diagnostics.Debug.WriteLine("Suscripción antigua desechada con éxito.");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error al desechar suscripción: {ex.Message}");
                }
                _empleadoSubscription = null;
            }
        }

        private async Task IniciarSuscripcionEmpleados()
        {
            await DesecharSuscripcion();

            try
            {
                _supabaseClient = await Conexion.ConnectWithTimeoutAsync(3);

                _empleadoSubscription = await _supabaseClient.From<Empleado>()
                    .On(ListenType.All, (sender, change) =>
                    {
                        try
                        {
               
                            if (this == null || this.IsDisposed || !this.IsHandleCreated)
                            {
                                System.Diagnostics.Debug.WriteLine("Evento Realtime ignorado: formulario cerrado o no inicializado.");
                                return;
                            }

                  
                            this.BeginInvoke((MethodInvoker)(async () =>
                            {
                                if (this.IsDisposed) return; 
                                System.Diagnostics.Debug.WriteLine($"Cambio detectado: {change.Event} en la tabla Empleados.");
                                await CargarEmpleados();
                            }));

                           
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"Error manejando evento Realtime: {ex.Message}");
                        }
                    });

                System.Diagnostics.Debug.WriteLine("Suscripción a Realtime creada correctamente.");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al suscribir a Realtime: {ex.Message}");
            }
        }

        private async Task CargarEmpleados()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3)))
                {
                    List<Empleado> listaDeEmpleados = await _empleadoRepo.ObtenerTodosLosEmpleados(cts.Token);

                    dgvEmpleados.DataSource = null;
                    dgvEmpleados.DataSource = listaDeEmpleados;
                }

                if (dgvEmpleados.Rows.Count > 0)
                {
                    dgvEmpleados.ClearSelection();
                }
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("No se pudo conectar con el servidor (tiempo de espera agotado).", "Error de Red", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private async void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                await DesecharSuscripcion();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al remover canal: {ex.Message}");
            }
            finally
            {
                clsAnmaciones.NombreMenuPrincipal();
                this.Close();
            }
        }

        private async void frmEmpleados_FormClosing(object sender, FormClosingEventArgs e)
        {
            await DesecharSuscripcion();
        }


        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            frmAgregarEditarEmpleado Empleados = new frmAgregarEditarEmpleado();
            Empleados.ShowDialog();
        }

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            if (EmpleadoSeleccionado != null)
            {
                frmAgregarEditarEmpleado EmpleadosEditar = new frmAgregarEditarEmpleado(EmpleadoSeleccionado);
                EmpleadosEditar.ShowDialog();
                await CargarEmpleados();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un empleado de la lista para editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void MonitorConexion_EstadoDeRedCambiado(NetworkStatus status)
        {
            if (!this.IsHandleCreated || this.IsDisposed)
            {
                System.Diagnostics.Debug.WriteLine("MonitorConexion: Formulario no listo para Invoke.");
                return;
            }

            if (status == NetworkStatus.Internet)
            {
                this.BeginInvoke((MethodInvoker)(async () =>
                {
                    if (this.IsDisposed) return;
                    System.Diagnostics.Debug.WriteLine("Red recuperada. Iniciando recarga y Realtime...");
                    await CargarEmpleados();
                    await IniciarSuscripcionEmpleados();
                }));
            }
        }

        private void dgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgvEmpleados_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                var filaSeleccionada = dgvEmpleados.SelectedRows[0];
                Empleado empleado = filaSeleccionada.DataBoundItem as Empleado;

                if (empleado != null)
                {
                    EmpleadoSeleccionado = empleado;
                }
            }
            else
            {
                EmpleadoSeleccionado = null;
            }
        }
    }
}
