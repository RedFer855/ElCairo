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
    /// <summary>
    /// Formulario que muestra y monitorea en tiempo real la bitácora del sistema.
    /// Incluye:
    /// - Carga inicial con timeout
    /// - Suscripción Realtime a la tabla bitacora_empleado
    /// - Manejo automático de reconexión
    /// - Limpieza de suscripciones al cerrar
    /// </summary>
    public partial class frmBitacora : Form
    {
        // =====================================================================
        // 1. Dependencias y Campos
        // =====================================================================

        /// <summary>
        /// Repositorio encargado de obtener los registros de bitácora.
        /// </summary>
        private readonly BitacoraRepositorio _bitacoraRepo;

        /// <summary>
        /// Canal de suscripción Realtime asignado para escuchar cambios en Bitácora.
        /// </summary>
        private Supabase.Realtime.RealtimeChannel? _bitacoraSubscription;

        /// <summary>
        /// Servicio que monitorea la conexión a Internet.
        /// </summary>
        private readonly ServicioVerificacionConexion _monitorConexion = new ServicioVerificacionConexion();

        /// <summary>
        /// Cliente Supabase usado exclusivamente para la suscripción Realtime.
        /// </summary>
        private Supabase.Client? _supabaseClient;

        // =====================================================================
        // 2. Constructor
        // =====================================================================

        /// <summary>
        /// Inicializa el formulario y configura el DataGridView y eventos de cierre.
        /// </summary>
        public frmBitacora()
        {
            InitializeComponent();

            dgvBitacora.AutoGenerateColumns = false;

            _bitacoraRepo = new BitacoraRepositorio();

            // Asegura limpieza de suscripciones al cerrar el formulario
            this.FormClosing += frmBitacora_FormClosing;
        }

        // =====================================================================
        // 3. Cargar Bitácoras desde Supabase
        // =====================================================================

        /// <summary>
        /// Carga las bitácoras desde la base de datos con timeout de 5s.
        /// Muestra errores apropiados si hay lentitud, desconexión o fallos.
        /// </summary>
        private async Task CargarBitacoras()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5)))
                {
                    var listaDeBitacoras = await _bitacoraRepo.ObtenerTodasLasBitacoras(cts.Token);

                    dgvBitacora.DataSource = null;
                    dgvBitacora.DataSource = listaDeBitacoras;
                }

                if (dgvBitacora.Rows.Count > 0)
                    dgvBitacora.ClearSelection();
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show(
                    "No se pudo conectar con el servidor (tiempo de espera agotado).",
                    "Error de Red",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al cargar la bitácora",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        // =====================================================================
        // 4. Suscripción Realtime a la tabla de Bitácora
        // =====================================================================

        /// <summary>
        /// Inicia la suscripción Realtime a Supabase escuchando cambios en bitacora_empleado.
        /// Cada cambio (INSERT, UPDATE, DELETE) fuerza recarga de la tabla.
        /// </summary>
        private async Task IniciarSuscripcionBitacoras()
        {
            await DesecharSuscripcion();

            try
            {
                _supabaseClient = await Conexion.ConnectWithTimeoutAsync(10);

                _bitacoraSubscription = await _supabaseClient
                    .From<Bitacora>()
                    .On(ListenType.All, (sender, change) =>
                    {
                        try
                        {
                            if (this == null || this.IsDisposed || !this.IsHandleCreated)
                                return;

                            this.BeginInvoke((MethodInvoker)(async () =>
                            {
                                if (this.IsDisposed) return;

                                System.Diagnostics.Debug.WriteLine($"Cambio detectado en Bitácora: {change.Event}");

                                await CargarBitacoras();
                            }));
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"Error al manejar evento Realtime: {ex.Message}");
                        }
                    });

                System.Diagnostics.Debug.WriteLine("Realtime Bitácora: suscripción creada.");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error creando suscripción Realtime Bitácora: {ex.Message}");
            }
        }

        // =====================================================================
        // 5. Manejo de reconexión automática
        // =====================================================================

        /// <summary>
        /// Detecta cambios en el estado de la red y reinicia la suscripción
        /// cuando la conexión se recupera.
        /// </summary>
        private async void MonitorConexion_EstadoDeRedCambiado(NetworkStatus status)
        {
            if (!this.IsHandleCreated || this.IsDisposed)
                return;

            if (status == NetworkStatus.Internet)
            {
                this.BeginInvoke((MethodInvoker)(async () =>
                {
                    if (this.IsDisposed) return;

                    System.Diagnostics.Debug.WriteLine("Red recuperada. Reiniciando suscripción y recargando datos...");

                    await CargarBitacoras();
                    await IniciarSuscripcionBitacoras();
                }));
            }
        }

        // =====================================================================
        // 6. Desuscribir Realtime correctamente
        // =====================================================================

        /// <summary>
        /// Elimina la suscripción Realtime de Supabase si existe.
        /// </summary>
        private async Task DesecharSuscripcion()
        {
            if (_bitacoraSubscription != null)
            {
                try
                {
                    await Task.Run(() => _bitacoraSubscription.Unsubscribe());
                    System.Diagnostics.Debug.WriteLine("Suscripción Realtime de Bitácora eliminada.");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error al eliminar suscripción: {ex.Message}");
                }

                _bitacoraSubscription = null;
            }
        }

        // =====================================================================
        // 7. Eventos del formulario
        // =====================================================================

        /// <summary>
        /// Limpia la suscripción Realtime al cerrar el formulario vía botón.
        /// </summary>
        private async void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                await DesecharSuscripcion();
            }
            catch { }
            finally
            {
                clsAnmaciones.NombreMenuPrincipal();
                this.Close();
            }
        }

        /// <summary>
        /// Limpia la suscripción al cerrar el formulario por cualquier medio (X, ALT+F4, etc.)
        /// </summary>
        private async void frmBitacora_FormClosing(object sender, FormClosingEventArgs e)
        {
            await DesecharSuscripcion();
        }

        /// <summary>
        /// Carga inicial del formulario:
        /// - Registra monitor de conexión
        /// - Carga bitácoras
        /// - Inicia Realtime
        /// </summary>
        private async void frmBitacora_Load(object sender, EventArgs e)
        {
            _monitorConexion.EstadoDeRedCambiado += MonitorConexion_EstadoDeRedCambiado;

            await CargarBitacoras();
            await IniciarSuscripcionBitacoras();
        }
    }
}
