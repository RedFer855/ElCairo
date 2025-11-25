using CapaDeDatos.Datos;
using CapaDeDatos.Modelados.Inventario;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.ServiciosUI;
using Supabase.Interfaces;
using Supabase.Realtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Supabase.Realtime.PostgresChanges.PostgresChangesOptions;

namespace ModernMenuUI
{
    public enum NivelStockFiltro
    {
        Todos,
        Bajo,
        Medio,
        Alto
    }
    public partial class frmInventarioBodega : Form
    {
        private List<Inventario> _listaInventarioGlobal = new List<Inventario>();
        private readonly ServiciosUI.ServicioPermisosUI _servicioPermisos = new ServiciosUI.ServicioPermisosUI();
        // === REPOSITORIOS Y CLIENTE ===
        private readonly InventarioRepositorio _inventarioRepo = new InventarioRepositorio();
        private readonly BodegaRepositorio _bodegaRepo = new BodegaRepositorio();
        private Supabase.Client? _supabaseClient;

        // === REALTIME Y CONEXIÓN ===
        private RealtimeChannel? _inventarioSubscription;
        private RealtimeChannel? _bodegaSubscription;
        private readonly ServicioVerificacionConexion _monitorConexion = new ServicioVerificacionConexion();

        // Delegado para actualizar UI desde hilos
        private delegate Task RefreshDelegate();

        private List<Inventario> _listaOriginal = new List<Inventario>();

        // Buscador (asumo que ya tienes la clase BuscadorInteractivo)
        private BuscadorInteractivo<Inventario> _buscadorCtrl;

        public frmInventarioBodega()
        {
            InitializeComponent();
            dgvProducto.AutoGenerateColumns = false; // Importante para DataBoundItem

            // Eventos de limpieza
            this.FormClosing += frmInventarioBodega_FormClosing;
            RegistrarBotonesConPermisos();
            _servicioPermisos.AplicarPermisos();

        }
        private async void frmInventarioBodega_Load(object sender, EventArgs e)
        {

            _monitorConexion.EstadoDeRedCambiado += MonitorConexion_EstadoDeRedCambiado;

            try
            {
                _supabaseClient = await Conexion.ConnectWithTimeoutAsync(3);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo conectar a Supabase: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            await CargarInventarioGridAsync(); // Carga el Grid
            txtBodegaActual.Text = ServicioSesionUsuario.ObtenerNombreBodega();
            // Cargar datos iniciales
          
            // 1. Primero carga el combo
            await CargarBodegasComboBox();

            // 2. Luego carga los datos y filtra
            await CargarDatosInventario();

            // Iniciar suscripciones Realtime
            await IniciarSuscripcionInventario();
            await IniciarSuscripcionBodegas();

        }

      


        // ======== FILTRAR AL CAMBIAR LA BODEGA =========
        private void btnSalir_Click(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            this.Close();
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async Task CargarInventarioGridAsync()
        {
            if (_supabaseClient == null) return;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10)))
                {
                    // 1. Carga TODOS los datos (Patrón Empleado)
                    List<Inventario> lista = await _inventarioRepo.ObtenerTodoElInventario(cts.Token);

                    dgvProducto.DataSource = null;
                    dgvProducto.DataSource = lista;
                }

       
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show(ex.Message, "Tiempo de Espera", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Cargar Inventario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private Task CargarComboBoxesEstado()
        {
            cmbEstado.Items.Clear();
            cmbEstado.Items.Add(NivelStockFiltro.Todos.ToString());
            cmbEstado.Items.Add(NivelStockFiltro.Bajo.ToString());
            cmbEstado.Items.Add(NivelStockFiltro.Medio.ToString());
            cmbEstado.Items.Add(NivelStockFiltro.Alto.ToString());
            cmbEstado.SelectedIndex = 0;
            return Task.CompletedTask;
        }

        private async Task IniciarSuscripcionInventario()
        {
            if (_supabaseClient == null) return;

            // Limpiar suscripción anterior
            if (_inventarioSubscription != null)
            {
                await Task.Run(() => _inventarioSubscription.Unsubscribe());
                _inventarioSubscription = null;
            }

            try
            {
                _inventarioSubscription = await _supabaseClient.From<Inventario>()
                    .On(ListenType.All, (sender, change) =>
                    {
                        try
                        {
                            if (this.IsDisposed || !this.IsHandleCreated) return;

                            this.BeginInvoke((MethodInvoker)(async () =>
                            {
                                if (this.IsDisposed) return;
                                System.Diagnostics.Debug.WriteLine($"Cambio detectado: {change.Event} en Inventario.");
                                await CargarInventarioGridAsync();
                            }));
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"Error manejando evento Realtime Inventario: {ex.Message}");
                        }
                    });
                System.Diagnostics.Debug.WriteLine("Suscripción a Realtime Inventario creada.");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al suscribir Inventario: {ex.Message}");
            }
        }

        private async Task IniciarSuscripcionBodegas()
        {
            if (_supabaseClient == null) return;

            // Limpiar suscripción anterior
            if (_bodegaSubscription != null)
            {
                await Task.Run(() => _bodegaSubscription.Unsubscribe());
                _bodegaSubscription = null;
            }

            try
            {
                // ✅ USANDO TU PATRÓN:
                _bodegaSubscription = await _supabaseClient.From<Bodega>()
                    .On(ListenType.All, (sender, change) =>
                    {
                        try
                        {
                            if (this.IsDisposed || !this.IsHandleCreated) return;

                            this.BeginInvoke((MethodInvoker)(async () =>
                            {
                                if (this.IsDisposed) return;
                                System.Diagnostics.Debug.WriteLine($"Cambio detectado: {change.Event} en Bodega.");
                                await CargarBodegasComboBox();      // Recarga el combo
                                await CargarInventarioGridAsync();  // Recarga el grid
                            }));
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"Error manejando evento Realtime Bodega: {ex.Message}");
                        }
                    });
                System.Diagnostics.Debug.WriteLine("Suscripción a Realtime Bodega creada.");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al suscribir Bodega: {ex.Message}");
            }
        }

        private async void MonitorConexion_EstadoDeRedCambiado(NetworkStatus status)
        {
            if (!this.IsHandleCreated || this.IsDisposed) return;

            if (status == NetworkStatus.Internet)
            {
                this.BeginInvoke((MethodInvoker)(async () =>
                {
                    if (this.IsDisposed) return;
                    System.Diagnostics.Debug.WriteLine("Red recuperada. Reiniciando conexión y suscripciones...");

                    try { _supabaseClient = await Conexion.ConnectWithTimeoutAsync(3); }
                    catch { /* Ignorar error de reconexión */ }

                    await CargarBodegasComboBox();
                    await CargarInventarioGridAsync();
                    await IniciarSuscripcionInventario();
                    await IniciarSuscripcionBodegas();
                }));
            }
        }

        private async Task DesecharSuscripcion()
        {
            if (_inventarioSubscription != null)
            {
                try { await Task.Run(() => _inventarioSubscription.Unsubscribe()); }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine($"Error al desechar sub inventario: {ex.Message}"); }
                _inventarioSubscription = null;
            }
            if (_bodegaSubscription != null)
            {
                try { await Task.Run(() => _bodegaSubscription.Unsubscribe()); }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine($"Error al desechar sub bodega: {ex.Message}"); }
                _bodegaSubscription = null;
            }
        }

        private async void frmInventarioBodega_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Asegura la limpieza al cerrar con la 'X'
            await DesecharSuscripcion();
        }

        private async Task CargarBodegasComboBox()
        {
            try
            {
                // Obtenemos las bodegas de la base de datos
                List<Bodega> bodegas = await _bodegaRepo.ObtenerTodasLasBodegasAsync();

                // Creamos la opción "Todas" manualmente
                // IMPORTANTE: Asegúrate que IdBodega 0 no exista en tu BD real
                var opcionTodas = new Bodega { IdBodega = 0, NombreBodega = "Todas las Bodegas" };
                bodegas.Insert(0, opcionTodas);

                // Configuramos el Combo
                cmbBodega.DataSource = null; // Limpiar enlace previo
                cmbBodega.DataSource = bodegas;
                cmbBodega.DisplayMember = "NombreBodega"; // Lo que se ve
                cmbBodega.ValueMember = "IdBodega";       // El valor interno (ID)

                // Seleccionamos "Todas" por defecto
                cmbBodega.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar bodegas: {ex.Message}");
            }
        }

        private async Task CargarDatosInventario()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // Traemos TODO el inventario de la BD una sola vez
                _listaInventarioGlobal = await _inventarioRepo.ObtenerTodoElInventario();

                // Aplicamos el filtro inmediatamente para llenar el grid
                FiltrarPorBodega();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar inventario: {ex.Message}");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void FiltrarPorBodega()
        {
            // Si la lista está vacía, no hacemos nada
            if (_listaInventarioGlobal == null || _listaInventarioGlobal.Count == 0) return;

            // Validamos que haya un valor seleccionado
            if (cmbBodega.SelectedValue == null) return;

            // Intentamos obtener el ID seleccionado
            if (int.TryParse(cmbBodega.SelectedValue.ToString(), out int idBodegaSeleccionada))
            {
                List<Inventario> listaFiltrada;

                if (idBodegaSeleccionada == 0)
                {
                    // Si es 0, mostramos TODO (copiamos la lista global)
                    listaFiltrada = _listaInventarioGlobal.ToList();
                }
                else
                {
                    // Si es > 0, filtramos por esa bodega específica
                    listaFiltrada = _listaInventarioGlobal
                                    .Where(prod => prod.IdBodegaInventario == idBodegaSeleccionada)
                                    .ToList();
                }

                // Actualizamos el Grid
                dgvProducto.DataSource = null;
                dgvProducto.DataSource = listaFiltrada;
            }
        }

        // Evento del ComboBox
        private void cmbBodega_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarPorBodega();
        }

        private void btnCambiarBodega_Click(object sender, EventArgs e)
        {

        }


        private void RegistrarBotonesConPermisos()
        {
            // BOTONES DE MÓDULO (Lógica "OR")
            _servicioPermisos.RegistrarBoton(btnCambiarBodega, "update_inventario");
            _servicioPermisos.RegistrarBoton(btnCrearBodega, "update_inventario");

        }

        private void btnCrearBodega_Click(object sender, EventArgs e)
        {

        }
    }
}
