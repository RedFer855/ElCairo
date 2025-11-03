using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
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
    
    public partial class frmEmpleados : Form
    {
        private readonly EmpleadoRepositorio _empleadoRepo;
        private Supabase.Realtime.RealtimeChannel? _empleadoSubscription;
        private readonly ServicioVerificacionConexion _monitorConexion = new ServicioVerificacionConexion();
        private Supabase.Client? _supabaseClient;

        public frmEmpleados()
        {
            InitializeComponent();
            dgvEmpleados.AutoGenerateColumns = false;
            _empleadoRepo = new EmpleadoRepositorio();
        }

        
        private async void FrmEmpleados_Load(object sender, EventArgs e)
        {
            _monitorConexion.EstadoDeRedCambiado += MonitorConexion_EstadoDeRedCambiado;
            await CargarEmpleados(); // Ahora llamamos con await
            await IniciarSuscripcionEmpleados();
        }


        private async Task DesecharSuscripcion()
        {
            if (_empleadoSubscription != null)
            {
                try
                {
                    // ENVUELVE la llamada para que el compilador acepte el 'await'
                    await Task.Run(() => _empleadoSubscription.Unsubscribe());

                    System.Diagnostics.Debug.WriteLine("Suscripción antigua desechada con éxito.");
                }
                catch (Exception ex)
                {
                    // Ignoramos el error, el objeto puede estar ya roto (Disposed)
                    System.Diagnostics.Debug.WriteLine($"Error al desechar suscripción: {ex.Message}");
                }
                // Lo ponemos a null para que IniciarSuscripcionEmpleados pueda crear uno nuevo
                _empleadoSubscription = null;
            }
        }
        private async Task IniciarSuscripcionEmpleados()
        {

            await DesecharSuscripcion();

            try
            {
                _supabaseClient = await Conexion.ConnectWithTimeoutAsync(10);

                // <- IMPORTANTE: usamos await aquí
                _empleadoSubscription = await _supabaseClient.From<Empleado>()
                    .On(ListenType.All, (sender, change) =>
                    {
                        this.Invoke((MethodInvoker)(async () =>
                        {
                            System.Diagnostics.Debug.WriteLine($"Cambio detectado: {change.Event} en la tabla Empleados.");
                            await CargarEmpleados();
                        }));
                    });

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

                // 1. Creamos un token que se cancela automáticamente en 5 segundos
                using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3)))
                {
                    // 2. Pasamos el token al repositorio
                    List<Empleado> listaDeEmpleados = await _empleadoRepo.ObtenerTodosLosEmpleados(cts.Token);
            
                    dgvEmpleados.DataSource = null;
                    dgvEmpleados.DataSource = listaDeEmpleados;
                }
            }
            catch (OperationCanceledException) // <-- Captura el timeout
            {
                // El token se canceló (pasaron 5 segundos)
                MessageBox.Show("No se pudo conectar con el servidor (tiempo de espera agotado).", "Error de Red", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Esto se ejecuta SIEMPRE, liberando el cursor
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

        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            frmAgregarEmpleado Empleados = new frmAgregarEmpleado();
            Empleados.ShowDialog();

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // Hacemos que "Nuevo" haga lo mismo que "Agregar"
            frmAgregarEmpleado Empleados = new frmAgregarEmpleado();
            Empleados.ShowDialog();
        }
        private async void MonitorConexion_EstadoDeRedCambiado(bool hayRed)
        {

            // CÓDIGO DE SEGURIDAD CLAVE: Si el Handle no ha sido creado o el Formulario está cerrándose, sal.
            if (!this.IsHandleCreated || this.IsDisposed)
            {
                System.Diagnostics.Debug.WriteLine("MonitorConexion_EstadoDeRedCambiado: Formulario no listo para Invoke.");
                return;
            }

            if (hayRed)
            {
                this.Invoke((MethodInvoker)(async () =>
                {
                    // Verificación adicional de Dispose dentro del Invoke, por si acaso
                    if (this.IsDisposed) return;

                    System.Diagnostics.Debug.WriteLine("Red recuperada. Iniciando recarga y Realtime...");

                    // 1. Recargar los datos estáticos del DGV
                    await CargarEmpleados();

                    // 2. Intentar establecer la suscripción Realtime (solo si falló antes)
                    await IniciarSuscripcionEmpleados();
                }));
            }
        }
        private void dgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}