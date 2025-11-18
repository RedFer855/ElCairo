using CapaDeDatos.Datos;
using CapaDeDatos.Repositorios;
using CapaDeDatos.Modelados.Inventario.Bodega_;
using CapaServiciosSeguridadValidacion.CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
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

            // Cargar datos iniciales
            await CargarComboBoxesEstado();
            await CargarBodegasComboBox();
            await CargarInventarioGridAsync(); // Carga el Grid

            // Iniciar suscripciones Realtime
            await IniciarSuscripcionInventario();
            await IniciarSuscripcionBodegas();
        }

        private void FiltrarYColorear()
        {
            /*
            string bodegaSeleccionada = cmbBodega.SelectedItem?.ToString() ?? "Todas";
            string estadoSeleccionado = cmbEstado.SelectedItem?.ToString() ?? "Todos";

            foreach (DataGridViewRow fila in dgvProducto.Rows)
            {
                if (fila.IsNewRow) continue;

                string bodega = fila.Cells["Bodega"].Value.ToString();
                int stockActual = Convert.ToInt32(fila.Cells[4].Value);
                int stockMinimo = Convert.ToInt32(fila.Cells[5].Value);

                // Determinar color lógico
                string estadoFila = "";
                if (stockActual < stockMinimo)
                    estadoFila = "Bajo";
                else if (stockActual >= stockMinimo && stockActual <= stockMinimo + 10)
                    estadoFila = "Medio";
                else
                    estadoFila = "Alto";


                // Aplicar visibilidad según filtros
                bool visiblePorBodega = (bodegaSeleccionada == "Todas" || bodega == bodegaSeleccionada);
                bool visiblePorEstado = (estadoSeleccionado == "Todos" || estadoFila == estadoSeleccionado);
                fila.Visible = visiblePorBodega && visiblePorEstado;

                // Aplicar color solo si es visible
                if (fila.Visible)
                {
                    if (estadoFila == "Bajo")
                        fila.DefaultCellStyle.BackColor = Color.FromArgb(255, 221, 221); //Rojo
                    else if (estadoFila == "Medio")
                        fila.DefaultCellStyle.BackColor = Color.FromArgb(252, 239, 220); // Amarillo
                    else if (estadoFila == "Alto")
                        fila.DefaultCellStyle.BackColor = Color.FromArgb(223, 244, 216); // Verde
                    else
                        MessageBox.Show("Nuevo estado");
                }
            }
            */
        }


        // ======== FILTRAR AL CAMBIAR LA BODEGA =========
        private void btnSalir_Click(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            this.Close();
        }

        private void cmbBodega_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarYColorear();
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

                // 2. Aplica el filtrado y coloreado en C# (Tu lógica original)
                FiltrarYColorear();
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

        // ====================================================================
        // REALTIME Y CONEXIÓN (Patrón frmEmpleado)
        // ====================================================================

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
                // ✅ USANDO TU PATRÓN:
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

                List<Bodega> bodegas = await _bodegaRepo.ObtenerTodasLasBodegasAsync();
                bodegas.Insert(0, new Bodega { IdBodega = 0, NombreBodega = "Todas" });

                cmbBodega.DataSource = null;
                cmbBodega.DataSource = bodegas;
                cmbBodega.DisplayMember = "NombreBodega";
                cmbBodega.ValueMember = "Id"; // Usamos el ID para el filtro
                cmbBodega.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al cargar bodegas: {ex.Message}");
            }
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
    }
}
