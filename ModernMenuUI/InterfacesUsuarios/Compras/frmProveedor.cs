using CapaDeDatos.Datos;
using CapaDeDatos.Modelados.Productos; // Asegúrate de que Proveedor esté aquí o ajusta el namespace
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using Supabase.Realtime;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Supabase.Realtime.PostgresChanges.PostgresChangesOptions;

namespace ModernMenuUI.InterfacesUsuarios.Compras
{
    public partial class frmProveedor : Form
    {
        // VARIABLES DE OBJETOS Y DEPENDENCIAS
        private readonly ProveedorRepositorio RepositorioProveedor;
        private readonly ServicioVerificacionConexion MonitorConexion = new ServicioVerificacionConexion();

        // VARIABLES DE ESTADO Y DATOS
        private Supabase.Realtime.RealtimeChannel? SuscribcionProveedor;
        private Supabase.Client? _supabaseClient;
        private Proveedor ObjProveedor = null;
        private List<Proveedor> _listaMaestraProveedores = new List<Proveedor>(); // Lista para filtrar en memoria

        // PROPIEDAD PARA SELECCIÓN EXTERNA
        public Proveedor ProveedorSeleccionado { get; private set; }

        #region CONSTRUCTORES
        public frmProveedor()
        {
            InitializeComponent();
            ConfigurarFormulario();
            RepositorioProveedor = new ProveedorRepositorio();
        }

        public frmProveedor(bool tipo)
        {
            InitializeComponent();
            ConfigurarFormulario();
            RepositorioProveedor = new ProveedorRepositorio();

            // Configuración modo selección
            FormBorderStyle = FormBorderStyle.None;
            btnSeleccionarProveedor.Visible = false;
        }

        private void ConfigurarFormulario()
        {
            dgvProveedores.AutoGenerateColumns = false;
            this.DoubleBuffered = true; // Reduce parpadeo
            this.FormClosing += frmProveedores_FormClosing;
        }
        #endregion

        #region CICLO DE VIDA (Load / Closing)
        private async void frmProveedores_Load(object sender, EventArgs e)
        {
            // Suscribir eventos de radio buttons unificados
            ConfigurarEventosFiltros();

            await CargarProveedores();
            MonitorConexion.EstadoDeRedCambiado += MonitorConexion_EstadoDeRedCambiado;
            await IniciarSuscripcionProveedores();
        }

        private async void frmProveedores_FormClosing(object sender, FormClosingEventArgs e)
        {
            await DesecharSuscripcion();
            MonitorConexion.EstadoDeRedCambiado -= MonitorConexion_EstadoDeRedCambiado;
        }
        #endregion

        #region LOGICA DE DATOS Y FILTROS

        private async Task CargarProveedores()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (var cts = new System.Threading.CancellationTokenSource(TimeSpan.FromSeconds(5)))
                {
                    // 1. Descargamos TODOS los datos a la lista maestra
                    _listaMaestraProveedores = await RepositorioProveedor.ObtenerTodosLosProveedores(cts.Token);

                    // 2. Aplicamos los filtros visuales (Grid)
                    RefrescarGrid();
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

        private void RefrescarGrid()
        {
            if (_listaMaestraProveedores == null) return;

            this.Cursor = Cursors.WaitCursor;

            IEnumerable<Proveedor> query = _listaMaestraProveedores;

            if (rbMostrarHabilitados.Checked)
            {
                query = query.Where(p => p.EstadoProveedor == true);
            }
            else if (rbMostrarDeshabilitados.Checked)
            {
                query = query.Where(p => p.EstadoProveedor == false);
            }
 
            var listaFiltrada = query.ToList();
            dgvProveedores.DataSource = null;
            dgvProveedores.DataSource = listaFiltrada;

            if (dgvProveedores.Rows.Count > 0)
                dgvProveedores.ClearSelection();

            this.Cursor = Cursors.Default;
        }

        private void ConfigurarEventosFiltros()
        {
            // Unificamos el evento para limpiar código
            rbMostrarTodos.CheckedChanged += Filtro_CheckedChanged;
            rbMostrarHabilitados.CheckedChanged += Filtro_CheckedChanged;
            rbMostrarDeshabilitados.CheckedChanged += Filtro_CheckedChanged;
        }

        private void Filtro_CheckedChanged(object sender, EventArgs e)
        {
            // Solo recargamos si el botón que disparó el evento está marcado (para evitar doble carga)
            if (sender is RadioButton rb && rb.Checked)
            {
                RefrescarGrid();
            }
        }

        #endregion

        #region REALTIME Y CONEXIÓN

        private async void MonitorConexion_EstadoDeRedCambiado(NetworkStatus status)
        {
            if (!this.IsHandleCreated || this.IsDisposed) return;
            if (status == NetworkStatus.Internet)
            {
                this.BeginInvoke((MethodInvoker)(async () =>
                {
                    if (this.IsDisposed) return;
                    System.Diagnostics.Debug.WriteLine("Red recuperada. Recargando Proveedores...");
                    await CargarProveedores();
                    await IniciarSuscripcionProveedores();
                }));
            }
        }

        private async Task IniciarSuscripcionProveedores()
        {
            await DesecharSuscripcion();

            try
            {
                _supabaseClient = await Conexion.ConnectWithTimeoutAsync(10);

                SuscribcionProveedor = await _supabaseClient.From<Proveedor>()
                    .On(ListenType.All, (sender, change) =>
                    {
                        try
                        {
                            if (this == null || this.IsDisposed || !this.IsHandleCreated) return;

                            this.BeginInvoke((MethodInvoker)(async () =>
                            {
                                if (this.IsDisposed) return;

                                System.Diagnostics.Debug.WriteLine($"Cambio detectado en Proveedores: {change.Event}. Recargando...");

                                // Esto recargará la lista maestra y luego refrescará el grid manteniendo filtros
                                await CargarProveedores();
                            }));
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"Error manejando evento Realtime (Proveedor): {ex.Message}");
                        }
                    });

                System.Diagnostics.Debug.WriteLine("Suscripción a Proveedores (Realtime) creada.");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al suscribir a Realtime (Proveedor): {ex.Message}");
            }
        }

        private async Task DesecharSuscripcion()
        {
            if (SuscribcionProveedor != null)
            {
                try
                {
                    await Task.Run(() => SuscribcionProveedor.Unsubscribe());
                    System.Diagnostics.Debug.WriteLine("Suscripción (Proveedor) desechada con éxito.");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error al desechar suscripción de Proveedor: {ex.Message}");
                }
                SuscribcionProveedor = null;
            }
        }
        #endregion

        #region BOTONES Y ACCIONES UI

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            frmAgregarEditarProveedor prov = new frmAgregarEditarProveedor();
            if (prov.ShowDialog() == DialogResult.OK)
            {
                // La recarga automática se encargará el Realtime, 
                // pero forzamos por si acaso hay lag en la red local
                await CargarProveedores();
            }
        }

        private void btnEditarProveedor_Click(object sender, EventArgs e)
        {
            if (ObjProveedor != null)
            {
                frmAgregarEditarProveedor edi = new frmAgregarEditarProveedor(ObjProveedor);
                edi.ShowDialog();
                // No necesitamos llamar a CargarProveedores aquí si el Realtime funciona,
                // pero si quieres asegurar: await CargarProveedores();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un proveedor de la lista para editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvProveedores_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count > 0)
            {
                ObjProveedor = dgvProveedores.SelectedRows[0].DataBoundItem as Proveedor;
            }
            else
            {
                ObjProveedor = null;
            }
        }

        private void btnSeleccionarProveedor_Click(object sender, EventArgs e)
        {
            ConfirmarSeleccion();
        }

        private void dgvProveedores_DoubleClick(object sender, EventArgs e)
        {
            ConfirmarSeleccion();
        }

        private void ConfirmarSeleccion()
        {
            if (dgvProveedores.SelectedRows.Count > 0)
            {
                ProveedorSeleccionado = dgvProveedores.SelectedRows[0].DataBoundItem as Proveedor;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // Solo mostramos mensaje si se hizo clic en el botón, no en doble clic vacío
                if (this.ActiveControl == btnSeleccionarProveedor)
                    MessageBox.Show("Por favor, seleccione un proveedor de la lista.");
            }
        }
        #endregion
    }
}