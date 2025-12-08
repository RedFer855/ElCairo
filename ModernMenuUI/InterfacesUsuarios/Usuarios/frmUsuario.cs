using CapaDeDatos.Datos; // Para Conexion a Supabase
using CapaDeDatos.Modelados.UsuariosEmpleados;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion; // Para ServicioVerificacionConexion
using ModernMenuUI.ClasesUI;
using ModernMenuUI.InterfacesUsuarios.Usuarios;
using Supabase.Realtime;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Supabase.Realtime.PostgresChanges.PostgresChangesOptions;

namespace ModernMenuUI
{
    /// <summary>
    /// Formulario encargado de mostrar, actualizar y editar usuarios del sistema.
    /// 
    /// Características principales:
    /// ✔ Carga de usuarios desde Supabase  
    /// ✔ Realtime: detección de INSERT/UPDATE/DELETE  
    /// ✔ Reconexión automática si se pierde el Internet  
    /// ✔ Edición de usuarios mediante frmAgregarEditarUsuario  
    /// ✔ DataGridView protegido contra autogeneración de columnas  
    /// </summary>
    public partial class frmUsuario : Form
    {
        // -------------------------------------------------------------
        // 1. CAMPOS PRIVADOS
        // -------------------------------------------------------------

        /// <summary>Repositorio de acceso a datos de usuarios.</summary>
        private readonly UsuarioRepositorio _usuarioRepo;

        /// <summary>Usuario actualmente seleccionado en el DataGridView.</summary>
        private Usuario _usuarioSeleccionado = null;

        /// <summary>Monitor que detecta cambios de conectividad de red.</summary>
        private readonly ServicioVerificacionConexion _monitorConexion = new();

        /// <summary>Cliente activo de Supabase (Realtime + PostgREST).</summary>
        private Supabase.Client? _supabaseClient;

        /// <summary>Canal Realtime para escuchar cambios en la tabla Usuario.</summary>
        private RealtimeChannel? _canalRealtime;


        // -------------------------------------------------------------
        // 2. CONSTRUCTOR
        // -------------------------------------------------------------
        public frmUsuario()
        {
            InitializeComponent();

            _usuarioRepo = new UsuarioRepositorio();

            // Configuración del DataGridView (evita columnas duplicadas o desordenadas)
            dgvUsuario.AutoGenerateColumns = false;

            // Registro manual de eventos del formulario
            this.dgvUsuario.SelectionChanged += new System.EventHandler(this.dgvProductos_SelectionChanged);
            this.Load += new System.EventHandler(this.frmUsuario_Load);
            this.FormClosing += new FormClosingEventHandler(this.frmUsuario_FormClosing);
        }


        // -------------------------------------------------------------
        // 3. LOAD Y FORM CLOSING
        // -------------------------------------------------------------

        /// <summary>
        /// Evento Load del formulario.
        /// Inicializa:
        /// - Monitor de red
        /// - Carga inicial de datos
        /// - Suscripción Realtime
        /// </summary>
        private async void frmUsuario_Load(object sender, EventArgs e)
        {
            _monitorConexion.EstadoDeRedCambiado += MonitorConexion_EstadoDeRedCambiado;

            await CargarDatosAsync();
            await IniciarSuscripcionAsync();
        }

        /// <summary>
        /// Limpia recursos antes de cerrar el formulario.
        /// </summary>
        private async void frmUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            _monitorConexion.EstadoDeRedCambiado -= MonitorConexion_EstadoDeRedCambiado;
            await DesecharSuscripcionAsync();
        }


        // -------------------------------------------------------------
        // 4. CARGA DE DATOS
        // -------------------------------------------------------------

        /// <summary>
        /// Carga todos los usuarios desde Supabase respetando timeout.
        /// </summary>
        private async Task CargarDatosAsync(CancellationToken ct = default)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (var cts = CancellationTokenSource.CreateLinkedTokenSource(ct))
                {
                    cts.CancelAfter(TimeSpan.FromSeconds(10));

                    List<Usuario> listaDeUsuarios =
                        await _usuarioRepo.ObtenerTodosLosUsuarios(cts.Token);

                    dgvUsuario.DataSource = null;
                    dgvUsuario.DataSource = listaDeUsuarios;
                }

                if (dgvUsuario.Rows.Count > 0)
                    dgvUsuario.ClearSelection();
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("No se pudo conectar con el servidor (tiempo de espera agotado).",
                                "Error de Red", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Error al cargar datos",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        // -------------------------------------------------------------
        // 5. MONITOR DE RED Y REALTIME
        // -------------------------------------------------------------

        /// <summary>
        /// Ejecutado cuando cambia el estado de la red.
        /// Si vuelve el Internet:
        ///   - Recarga datos
        ///   - Reconecta Realtime
        /// </summary>
        private async void MonitorConexion_EstadoDeRedCambiado(NetworkStatus status)
        {
            if (!this.IsHandleCreated || this.IsDisposed)
            {
                Debug.WriteLine("MonitorConexion: Formulario no listo.");
                return;
            }

            if (status == NetworkStatus.Internet)
            {
                this.BeginInvoke((MethodInvoker)(async () =>
                {
                    if (this.IsDisposed) return;

                    Debug.WriteLine("Red recuperada. Recargando datos y Realtime...");

                    await CargarDatosAsync();
                    await IniciarSuscripcionAsync();
                }));
            }
        }

        /// <summary>
        /// Crea la suscripción Realtime a la tabla Usuario.
        /// Detecta automáticamente:
        ///  - INSERT
        ///  - UPDATE
        ///  - DELETE
        /// </summary>
        private async Task IniciarSuscripcionAsync()
        {
            await DesecharSuscripcionAsync(); // Limpia suscripción previa

            try
            {
                _supabaseClient = await Conexion.ConnectWithTimeoutAsync(10);

                _canalRealtime = await _supabaseClient
                    .From<Usuario>()
                    .On(ListenType.All, (sender, change) =>
                    {
                        try
                        {
                            if (this == null || this.IsDisposed || !this.IsHandleCreated)
                                return;

                            // Se reenfila al hilo de UI
                            this.BeginInvoke((MethodInvoker)(async () =>
                            {
                                if (this.IsDisposed) return;

                                Debug.WriteLine($"Cambio detectado (Usuarios): {change.Event}. Recargando...");
                                await CargarDatosAsync();
                            }));
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"Error en evento Realtime: {ex.Message}");
                        }
                    });

                Debug.WriteLine("Suscripción a Realtime (Usuarios) creada.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al suscribir a Realtime: {ex.Message}");
            }
        }

        /// <summary>
        /// Cancela la suscripción anterior de Realtime para evitar fugas de memoria.
        /// </summary>
        private async Task DesecharSuscripcionAsync()
        {
            if (_canalRealtime != null)
            {
                try
                {
                    await Task.Run(() => _canalRealtime.Unsubscribe());
                    Debug.WriteLine("Suscripción (Usuarios) desechada.");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error al desechar suscripción: {ex.Message}");
                }

                _canalRealtime = null;
            }
        }


        // -------------------------------------------------------------
        // 6. BOTONES Y GRID
        // -------------------------------------------------------------

        private void btnSalir_Click(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            this.Close();
        }

        /// <summary>
        /// Actualiza el usuario seleccionado cuando el grid cambia de fila.
        /// </summary>
        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuario.SelectedRows.Count > 0)
            {
                var filaSeleccionada = dgvUsuario.SelectedRows[0];
                _usuarioSeleccionado = filaSeleccionada.DataBoundItem as Usuario;
            }
            else
            {
                _usuarioSeleccionado = null;
            }
        }

        /// <summary>
        /// Abre el editor de usuario con los permisos y restricciones correctas.
        /// </summary>
        private async void btnEditarUsuarios_Click(object sender, EventArgs e)
        {
            var client = await Conexion.GetClientAsync();
            var authUser = client.Auth.CurrentUser;

            var usuarioActualSistema = await client
                .From<Usuario>()
                .Where(u => u.Uuid == authUser.Id)
                .Single();

            if (_usuarioSeleccionado == null)
            {
                MessageBox.Show("Por favor, seleccione un usuario de la lista antes de continuar.",
                                "Seleccione un usuario",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            frmAgregarEditarUsuario usuario =
                new frmAgregarEditarUsuario(_usuarioSeleccionado, usuarioActualSistema);

            usuario.ShowDialog();
        }
    }
}
