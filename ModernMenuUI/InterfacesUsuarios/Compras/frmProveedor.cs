using CapaDeDatos.Datos;
using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
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
    public partial class frmProveedor : Form
    {
        // VARIABLES DE OBJETOS
        private readonly ProveedorRepositorio RepositorioProveedor;
        private Supabase.Realtime.RealtimeChannel? SuscribcionProveedor;
        private readonly ServicioVerificacionConexion MonitorConexion = new ServicioVerificacionConexion();
        private Supabase.Client? _supabaseClient;
        private Proveedor ObjProveedor = null;

        public Proveedor ProveedorSeleccionado { get; private set; }

        public frmProveedor()
        {
            InitializeComponent();
            dgvProveedores.AutoGenerateColumns = false; // Asumiendo que se llama dgvProveedores
            RepositorioProveedor = new ProveedorRepositorio();
            this.FormClosing += frmProveedores_FormClosing;

        }

        public frmProveedor(bool tipo)
        {
            InitializeComponent();
            dgvProveedores.AutoGenerateColumns = false; // Asumiendo que se llama dgvProveedores
            RepositorioProveedor = new ProveedorRepositorio();
            this.FormClosing += frmProveedores_FormClosing;
            FormBorderStyle = FormBorderStyle.None;
        }

        // CARGAR FORMULARIO
        private async void frmProveedores_Load(object sender, EventArgs e)
        {
            await CargarProveedores();
            MonitorConexion.EstadoDeRedCambiado += MonitorConexion_EstadoDeRedCambiado;
            await IniciarSuscripcionProveedores();
        }

        // FUNCIONES DE REALTIME Y CRUD

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

        private async void frmProveedores_FormClosing(object sender, FormClosingEventArgs e)
        {
            await DesecharSuscripcion();
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
                SuscribcionProveedor = await _supabaseClient.From<Proveedor>()
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

        private async Task CargarProveedores()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3)))
                {
                    List<Proveedor> listaDeProveedores = await RepositorioProveedor.ObtenerTodosLosProveedores(cts.Token);
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

        // BOTONES DE FORMULARIO
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            frmAgregarEditarProveedor prov = new frmAgregarEditarProveedor();
            DialogResult resul = prov.ShowDialog();
            if (resul == DialogResult.OK)
            {
                await CargarProveedores();
            }
        }

        private void btnEditarProveedor_Click(object sender, EventArgs e)
        {
            if (ObjProveedor != null)
            {
                frmAgregarEditarProveedor edi = new frmAgregarEditarProveedor(ObjProveedor);
                edi.ShowDialog();
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
                var filaSeleccionada = dgvProveedores.SelectedRows[0];
                Proveedor proveedor = filaSeleccionada.DataBoundItem as Proveedor;

                if (proveedor != null)
                {
                    ObjProveedor = proveedor;
                }
            }
            else
            {
                ObjProveedor = null;
            }
        }

        private void btnSeleccionarProveedor_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count > 0)
            {
                ProveedorSeleccionado = dgvProveedores.SelectedRows[0].DataBoundItem as Proveedor;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un proveedor de la lista.");
            }
        }

        private void dgvProveedores_DoubleClick(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count > 0)
            {
                // Asignamos el objeto de la fila seleccionada a la propiedad pública
                ProveedorSeleccionado = dgvProveedores.SelectedRows[0].DataBoundItem as Proveedor;

                // Cerramos con OK para que el formulario padre sepa que hubo selección
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
