using CapaDeDatos.Datos; // Para Conexion
using CapaDeDatos.Modelados.UsuariosEmpleados;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion; // Para el monitor de red
using CapaServiciosSeguridadValidacion.CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.InterfacesUsuarios.Usuarios;
using Supabase.Realtime; // Para Realtime
using System;
using System.Collections.Generic;
using System.Diagnostics; // Para Debug.WriteLine
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Supabase.Realtime.PostgresChanges.PostgresChangesOptions;

namespace ModernMenuUI
{
    public partial class frmUsuario : Form
    {

        private readonly UsuarioRepositorio _usuarioRepo;
        private Usuario _usuarioSeleccionado = null;

        private readonly ServicioVerificacionConexion _monitorConexion = new();
        private Supabase.Client? _supabaseClient;
        private RealtimeChannel? _canalRealtime;


        public frmUsuario()
        {
            InitializeComponent();

            _usuarioRepo = new UsuarioRepositorio();

            //Usamos 'dgvProductos' (el nombre de tu control)
            dgvUsuario.AutoGenerateColumns = false;

            // 3. CONECTAMOS LOS EVENTOS MANUALMENTE
            this.dgvUsuario.SelectionChanged += new System.EventHandler(this.dgvProductos_SelectionChanged);
            this.Load += new System.EventHandler(this.frmUsuario_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmUsuario_FormClosing);
        }

        // --- 4. CICLO DE VIDA DEL FORMULARIO ---

        private async void frmUsuario_Load(object sender, EventArgs e)
        {
            // Conectar el monitor de red
            _monitorConexion.EstadoDeRedCambiado += MonitorConexion_EstadoDeRedCambiado;

            // Carga inicial
            await CargarDatosAsync();

            // Suscripción inicial a Realtime
            await IniciarSuscripcionAsync();
        }

        private async void frmUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Limpieza fundamental
            _monitorConexion.EstadoDeRedCambiado -= MonitorConexion_EstadoDeRedCambiado;
            await DesecharSuscripcionAsync();
        }

        // --- 5. LÓGICA DE CARGA DE DATOS ---

        private async Task CargarDatosAsync(CancellationToken ct = default)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (var cts = CancellationTokenSource.CreateLinkedTokenSource(ct))
                {
                    cts.CancelAfter(TimeSpan.FromSeconds(10));
                    List<Usuario> listaDeUsuarios = await _usuarioRepo.ObtenerTodosLosUsuarios(cts.Token);

                    dgvUsuario.DataSource = null;
                    dgvUsuario.DataSource = listaDeUsuarios;
                }

                if (dgvUsuario.Rows.Count > 0)
                {
                    dgvUsuario.ClearSelection();
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

        // --- 6. LÓGICA DE RED Y REALTIME ---

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

        private async Task IniciarSuscripcionAsync()
        {
            await DesecharSuscripcionAsync(); // Limpia la anterior
            try
            {
                _supabaseClient = await Conexion.ConnectWithTimeoutAsync(10);

                _canalRealtime = await _supabaseClient.From<Usuario>()
                    .On(ListenType.All, (sender, change) =>
                    {
                        try
                        {
                            if (this == null || this.IsDisposed || !this.IsHandleCreated) return;

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

        // --- 7. LÓGICA DE BOTONES Y GRID (Tu código original) ---

        private void btnSalir_Click(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (_usuarioSeleccionado == null)
            {
                MessageBox.Show("Seleccione un usuario para editar.");
            }
            else
            {
                // Lógica para editar
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Lógica para agregar
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Clic en celda
        }

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

        private void frmUsuario_Load_1(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {

        }

        private async void btnNuevo_Click_2(object sender, EventArgs e)
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
            else
            {
                frmAgregarEditarUsuario usuario = new frmAgregarEditarUsuario(_usuarioSeleccionado, usuarioActualSistema);
                usuario.ShowDialog();
            }


        }
    }
}