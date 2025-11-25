using CapaDeDatos.Datos;
using CapaDeDatos.Modelados.UsuariosEmpleados;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Supabase.Realtime.PostgresChanges.PostgresChangesOptions;

namespace ModernMenuUI
{
    public partial class frmBitacora : Form
    {
        // 1. Declaración de miembros para el repositorio y la suscripción
        private readonly BitacoraRepositorio _bitacoraRepo;
        private Supabase.Realtime.RealtimeChannel? _bitacoraSubscription;
        private readonly ServicioVerificacionConexion _monitorConexion = new ServicioVerificacionConexion();
        private Supabase.Client? _supabaseClient;

        public frmBitacora()
        {
            InitializeComponent();
            // Asegúrate de que el DataGridView (dgvBitacora) exista en el diseñador
            // y que las columnas estén configuradas correctamente.
            dgvBitacora.AutoGenerateColumns = false;

            _bitacoraRepo = new BitacoraRepositorio();

            // Aseguramos la limpieza de la suscripción cuando se cierre el formulario
            this.FormClosing += frmBitacora_FormClosing;
        }



        private async Task CargarBitacoras()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // Usamos un CancellationTokenSource para manejar el timeout de la consulta
                using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5)))
                {
                    // Llama al método del repositorio para obtener los datos
                    List<Bitacora> listaDeBitacoras = await _bitacoraRepo.ObtenerTodasLasBitacoras(cts.Token);

                    // Actualiza la fuente de datos en el DataGridView
                    dgvBitacora.DataSource = null;
                    dgvBitacora.DataSource = listaDeBitacoras;
                }

                if (dgvBitacora.Rows.Count > 0)
                {
                    dgvBitacora.ClearSelection();
                }
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("No se pudo conectar con el servidor (tiempo de espera agotado) para cargar la bitácora.", "Error de Red", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar la bitácora", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private async Task IniciarSuscripcionBitacoras()
        {
            await DesecharSuscripcion(); // Limpia cualquier suscripción anterior

            try
            {
                // Conexión segura con timeout
                _supabaseClient = await Conexion.ConnectWithTimeoutAsync(10);

                // Suscripción al canal de Realtime para la tabla 'bitacora_empleado'
                _bitacoraSubscription = await _supabaseClient.From<Bitacora>()
                    .On(ListenType.All, (sender, change) =>
                    {
                        try
                        {
                            // Validación antes de acceder al formulario desde otro hilo
                            if (this == null || this.IsDisposed || !this.IsHandleCreated)
                            {
                                System.Diagnostics.Debug.WriteLine("Evento Realtime ignorado: formulario cerrado.");
                                return;
                            }

                            // Ejecutamos la recarga en el hilo de la UI
                            this.BeginInvoke((MethodInvoker)(async () =>
                            {
                                if (this.IsDisposed) return;
                                System.Diagnostics.Debug.WriteLine($"Cambio detectado: {change.Event} en la tabla Bitácora.");

                                // Recarga los datos para reflejar el cambio (INSERT, UPDATE, DELETE)
                                await CargarBitacoras();
                            }));
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"Error manejando evento Realtime de Bitácora: {ex.Message}");
                        }
                    });

                System.Diagnostics.Debug.WriteLine("Suscripción a Realtime de Bitácora creada correctamente.");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al suscribir Bitácora a Realtime: {ex.Message}");
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
                    await CargarBitacoras();
                    await IniciarSuscripcionBitacoras();
                }));
            }
        }
        private async Task DesecharSuscripcion()
        {
            if (_bitacoraSubscription != null)
            {
                try
                {
                    // Se ejecuta en un Task.Run para evitar bloquear el hilo de la UI
                    await Task.Run(() => _bitacoraSubscription.Unsubscribe());
                    System.Diagnostics.Debug.WriteLine("Suscripción de Bitácora desechada con éxito.");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error al desechar suscripción de Bitácora: {ex.Message}");
                }
                _bitacoraSubscription = null;
            }
        }

        private async void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                // Asegura la desuscripción antes de cerrar
                await DesecharSuscripcion();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al remover canal al salir: {ex.Message}");
            }
            finally
            {
                clsAnmaciones.NombreMenuPrincipal();
                this.Close();
            }
        }

        private async void frmBitacora_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Maneja el cierre del formulario (ej. clic en la 'X' o Alt+F4)
            await DesecharSuscripcion();
        }

        private async void frmBitacora_Load(object sender, EventArgs e)
        {
            _monitorConexion.EstadoDeRedCambiado += MonitorConexion_EstadoDeRedCambiado;

            // Carga inicial de datos
            await CargarBitacoras();

            // Inicia la suscripción Realtime
            await IniciarSuscripcionBitacoras();
        }
    }
}

