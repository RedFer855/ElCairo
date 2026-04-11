using CapaDeDatos.Datos; // Para Conexion a Supabase
using CapaDeDatos.Modelados.UsuariosEmpleados;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion; // Para ServicioVerificacionConexion
using ModernMenuUI.ClasesUI;
using ModernMenuUI.InterfacesUsuarios.Usuarios;
using ModernMenuUI.ServiciosUI;
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
        private UsuarioDisplay _usuarioSeleccionado = null;

        /// <summary>Monitor que detecta cambios de conectividad de red.</summary>
        private readonly ServicioVerificacionConexion _monitorConexion = new();

        /// <summary>Cliente activo de Supabase (Realtime + PostgREST).</summary>
        private Supabase.Client? _supabaseClient;

        /// <summary>Canal Realtime para escuchar cambios en la tabla Usuario.</summary>
        private RealtimeChannel? _canalRealtime;
        private List<UsuarioDisplay> _listaMaestraUsuarios = new();

        private BuscadorInteractivo<UsuarioDisplay> _buscadorCtrl;

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

                    _listaMaestraUsuarios = await _usuarioRepo.ObtenerTodosLosUsuarios(cts.Token);
                }

                InicializarBuscador();

                RefrescarGrid();

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

        private List<UsuarioDisplay> ObtenerUsuariosSegunFiltro()
        {
            IEnumerable<UsuarioDisplay> query = _listaMaestraUsuarios;

            if (rdbHabilitados.Checked)
                query = query.Where(u => u.EstadoUsuario == true);

            else if (rdbDeshabilitados.Checked)
                query = query.Where(u => u.EstadoUsuario == false);

            // Si es "Todos", no se filtra

            return query.ToList();
        }
        private List<UsuarioDisplay> BuscarUsuarios(string textoBusqueda)
        {
            string busqueda = textoBusqueda?.ToLower().Trim() ?? "";

            var listaBase = ObtenerUsuariosSegunFiltro();

            if (string.IsNullOrEmpty(busqueda))
                return listaBase;

            return listaBase.Where(u =>
                (!string.IsNullOrEmpty(u.AliasUsuario) && u.AliasUsuario.ToLower().Contains(busqueda))
                //(!string.IsNullOrEmpty(u.Email) && u.Email.ToLower().Contains(busqueda))
            ).ToList();
        }

        private void InicializarBuscador()
        {
            _buscadorCtrl = new BuscadorInteractivo<UsuarioDisplay>(
                txtBuscar,
                lstSugerencias,
                dgvUsuario,
                _listaMaestraUsuarios,

                // BÚSQUEDA EXACTA
                (u, txt) =>
                    u.IdUsuario.ToString() == txt ||
                    (u.AliasUsuario != null && u.AliasUsuario.Equals(txt, StringComparison.OrdinalIgnoreCase)),

                // BÚSQUEDA PARCIAL
                (u, txt) =>
                {
                    if (!u.EstadoUsuario) return false;

                    bool porAlias =
                        u.AliasUsuario != null &&
                        u.AliasUsuario.IndexOf(txt, StringComparison.OrdinalIgnoreCase) >= 0;

                    return porAlias;
                },

                // TEXTO MOSTRADO
                (u) => u.AliasUsuario,

                // EVENTO FILTRO ACTIVO
                (busquedaActiva) =>
                {
                    pnlLimpiarFiltros.Visible = busquedaActiva;
                    if (!busquedaActiva) RefrescarGrid();
                },

                // SOLO NÚMEROS
                (txt) => txt.All(char.IsDigit)
            );
        }


        private async void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                return;

            var resultados = BuscarUsuarios(txtBuscar.Text);
            var top = resultados.Take(10).ToList();
            var listaFinal = resultados.Take(10).ToList();


            if (top.Count > 0 && !string.IsNullOrEmpty(txtBuscar.Text))
            {
                lstSugerencias.DataSource = null;
                lstSugerencias.DataSource = top;
                AjustarAlturaListBoxUsuarios(listaFinal.Count);
                lstSugerencias.Visible = true;
            }
            else
            {
                lstSugerencias.Visible = false;
            }
        }

        private void AjustarAlturaListBoxUsuarios(int numeroDeResultados)
        {
            int alturaItem = lstSugerencias.ItemHeight;

            int alturaMaxima = (alturaItem * 10) + 10; // máximo 10 visibles
            int alturaNecesaria = (alturaItem * numeroDeResultados) + 10;

            lstSugerencias.Height = Math.Min(alturaNecesaria, alturaMaxima);
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e) => _buscadorCtrl.ManejarKeyDown(e);
        private void txtBuscar_Leave(object sender, EventArgs e) => _buscadorCtrl.ManejarLeave();
        private void lstSugerencias_MouseClick(object sender, MouseEventArgs e) => _buscadorCtrl.ManejarClickLista();

        private void lstSugerencias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                _buscadorCtrl.ManejarClickLista();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            _buscadorCtrl.ManejarKeyDown(new KeyEventArgs(Keys.Enter));
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
                    .From<UsuarioDisplay>()
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
                _usuarioSeleccionado = filaSeleccionada.DataBoundItem as UsuarioDisplay;
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

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }


        private void rdbTodos_CheckedChanged(object sender, EventArgs e)
        {
            RefrescarGrid();
            ActualizarBuscador();

        }
        private void RefrescarGrid()
        {
            var query = _listaMaestraUsuarios.AsEnumerable();

            if (rdbHabilitados.Checked)
                query = query.Where(u => u.EstadoUsuario);
            else if (rdbDeshabilitados.Checked)
                query = query.Where(u => !u.EstadoUsuario);

            var listaFinal = query.ToList();

            dgvUsuario.DataSource = null;
            dgvUsuario.DataSource = listaFinal;

            bool hayFiltrosExtras = !rdbHabilitados.Checked;
            pnlLimpiarFiltros.Visible = hayFiltrosExtras;

            if (listaFinal.Count > 0)
                dgvUsuario.ClearSelection();
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            rdbHabilitados.Checked = true;
            _buscadorCtrl.LimpiarBusqueda();
            RefrescarGrid();
        }

        private void rdbHabilitados_CheckedChanged(object sender, EventArgs e)
        {
            RefrescarGrid();
            ActualizarBuscador();

        }

        private void rdbDeshabilitados_CheckedChanged(object sender, EventArgs e)
        {
            RefrescarGrid();
            ActualizarBuscador();

        }

        private void ActualizarBuscador()
        {
            var listaFiltrada = ObtenerUsuariosSegunFiltro();

            lstSugerencias.DataSource = null;
            lstSugerencias.DataSource = listaFiltrada.Take(10).ToList();
            lstSugerencias.DisplayMember = "AliasUsuario";
        }

    }
}
