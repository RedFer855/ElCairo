using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion.CapaServiciosSeguridadValidacion;
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


namespace ModernMenuUI.InterfacesUsuarios.Compras
{
    public partial class frmProveedores : Form
    {
        private readonly ProveedorRepositorio _proveedorRepo;
        private Supabase.Realtime.RealtimeChannel? _proveedorSubscription;
        private readonly ServicioVerificacionConexion _monitorConexion = new ServicioVerificacionConexion();
        private Supabase.Client? _supabaseClient;
        private Proveedor _proveedorSeleccionado = null;

        public frmProveedores()
        {
            InitializeComponent();
            dgvProveedores.AutoGenerateColumns = false; // Asumiendo que se llama dgvProveedores
            _proveedorRepo = new ProveedorRepositorio();
            this.FormClosing += frmProveedores_FormClosing;

        }

        private async Task CargarProveedores()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3)))
                {
                    List<Proveedor> listaDeProveedores = await _proveedorRepo.ObtenerTodosLosProveedores(cts.Token);
                    dgvProveedores.DataSource = null;
                    dgvProveedores.DataSource = listaDeProveedores;
                }
                if (dgvProveedores.Rows.Count > 0) dgvProveedores.ClearSelection();
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
        private async Task DesecharSuscripcion()
        {
            if (_proveedorSubscription != null)
            {
                try
                {
                    await Task.Run(() => _proveedorSubscription.Unsubscribe());
                    System.Diagnostics.Debug.WriteLine("Suscripción (Proveedor) desechada con éxito.");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error al desechar suscripción de Proveedor: {ex.Message}");
                }
                _proveedorSubscription = null;
            }
        }
        private async Task IniciarSuscripcionProveedores()
        {
            // Limpia cualquier suscripción anterior
            await DesecharSuscripcion();

            try
            {
                // Obtiene el cliente (igual que en frmEmpleado)
                _supabaseClient = await Conexion.ConnectWithTimeoutAsync(10);

                // Se suscribe a CUALQUIER cambio (Insert, Update, Delete)
                _proveedorSubscription = await _supabaseClient.From<Proveedor>()
                    .On(ListenType.All, (sender, change) =>
                    {
                        try
                        {
                            // Valida que el formulario aún exista
                            if (this == null || this.IsDisposed || !this.IsHandleCreated)
                            {
                                return;
                            }

                            // Ejecuta la recarga en el hilo de la UI
                            this.BeginInvoke((MethodInvoker)(async () =>
                            {
                                if (this.IsDisposed) return; // Doble validación

                                System.Diagnostics.Debug.WriteLine($"Cambio detectado en Proveedores: {change.Event}. Recargando...");

                                // Llama a tu método de carga
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
        private async void MonitorConexion_EstadoDeRedCambiado(NetworkStatus status)
        {
            if (!this.IsHandleCreated || this.IsDisposed) return;
            if (status == NetworkStatus.Internet)
            {
                this.BeginInvoke((MethodInvoker)(async () =>
                {
                    if (this.IsDisposed) return;
                    await CargarProveedores();
                    await IniciarSuscripcionProveedores();
                }));
            }
        }
        private async void frmProveedor_FormClosing(object sender, FormClosingEventArgs e)
        {
            await DesecharSuscripcion();
        }


        private async void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            frmAgregarEditarProveedor prov = new frmAgregarEditarProveedor();
            DialogResult resul = prov.ShowDialog();
            //  Muestra el formulario y "pausa" este código
            if (resul == DialogResult.OK)
            {
                // 4. Si la señal fue "OK", refrescamos manualmente el DataGridView
                //    llamando al método que ya tienes.
                await CargarProveedores();
            }
        }



        private async void frmProveedores_Load(object sender, EventArgs e)
        {
            // Carga inicial de datos
            await CargarProveedores();
            // Suscripción al monitor de red
            _monitorConexion.EstadoDeRedCambiado += MonitorConexion_EstadoDeRedCambiado;
            // Inicia la suscripción a Realtime
            await IniciarSuscripcionProveedores();
        }




        private void btnSalir_Click(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            this.Close();

        }
       
        private async void frmProveedores_FormClosing(object sender, FormClosingEventArgs e)
        {
            await DesecharSuscripcion();
        }

        private void btnEditarProveedor_Click(object sender, EventArgs e)
        {
            if (_proveedorSeleccionado != null)
            {
                frmAgregarEditarProveedor edi = new frmAgregarEditarProveedor(_proveedorSeleccionado);
                edi.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un proveedor de la lista para editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvProveedores_SelectionChanged_1(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count > 0)
            {
                var filaSeleccionada = dgvProveedores.SelectedRows[0];
                Proveedor proveedor = filaSeleccionada.DataBoundItem as Proveedor;

                if (proveedor != null)
                {
                    _proveedorSeleccionado = proveedor;
                }
            }
            else
            {
                _proveedorSeleccionado = null;
            }
        }
    }
}
