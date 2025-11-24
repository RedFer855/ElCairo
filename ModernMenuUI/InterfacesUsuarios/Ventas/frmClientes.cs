using CapaDeDatos.Datos;
using CapaDeDatos.Modelados.Ventas;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.InterfacesUsuarios.Ventas;
using Supabase.Interfaces;
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
    public partial class frmClientes : Form
    {
        private readonly ClienteRepositorio _clienteRepo;
        private Supabase.Realtime.RealtimeChannel? _clienteSubscription;
        private readonly ServicioVerificacionConexion _monitorConexion = new ServicioVerificacionConexion();
        private Supabase.Client? _supabaseClient;
        private Cliente ClienteSeleccionado = null;
        public frmClientes()
        {
            InitializeComponent();
            dgvClientes.AutoGenerateColumns = false;
            _clienteRepo = new ClienteRepositorio();

            this.FormClosing += frmClientes_FormClosing;
        }
        private async void frmClientes_Load(object sender, EventArgs e)
        {
            _monitorConexion.EstadoDeRedCambiado += MonitorConexion_EstadoDeRedCambiado;

            await CargarClientes();

            await IniciarSuscripcionClientes();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            this.Close();
        }
        private async Task DesecharSuscripcion()
        {
            if (_clienteSubscription != null)
            {
                try
                {
                    await Task.Run(() => _clienteSubscription.Unsubscribe());
                    System.Diagnostics.Debug.WriteLine("Suscripción de clientes desechada correctamente.");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error al desechar suscripción: {ex.Message}");
                }

                _clienteSubscription = null;
            }
        }

        private async Task IniciarSuscripcionClientes()
        {
            await DesecharSuscripcion();

            try
            {
                _supabaseClient = await Conexion.ConnectWithTimeoutAsync(3);

                _clienteSubscription = await _supabaseClient
                    .From<Cliente>()
                    .On(ListenType.All, (sender, change) =>
                    {
                        try
                        {
                            if (this == null || this.IsDisposed || !this.IsHandleCreated)
                            {
                                System.Diagnostics.Debug.WriteLine("Realtime ignorado: formulario no disponible.");
                                return;
                            }

                            this.BeginInvoke((MethodInvoker)(async () =>
                            {
                                if (!this.IsDisposed)
                                {
                                    System.Diagnostics.Debug.WriteLine($"Cambio detectado: {change.Event} en clientes.");
                                    await CargarClientes();
                                }
                            }));
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"Error en evento Realtime: {ex.Message}");
                        }
                    });

                System.Diagnostics.Debug.WriteLine("Suscripción Realtime a clientes iniciada.");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al suscribirse a clientes: {ex.Message}");
            }
        }

        private async Task CargarClientes()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3)))
                {
                    List<Cliente> lista = await _clienteRepo.ObtenerTodosLosClientes();

                    dgvClientes.DataSource = null;
                    dgvClientes.DataSource = lista;
                }

                if (dgvClientes.Rows.Count > 0)
                {
                    dgvClientes.ClearSelection();
                }
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("No se pudo conectar al servidor (timeout).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private async void MonitorConexion_EstadoDeRedCambiado(NetworkStatus status)
        {
            if (!this.IsHandleCreated || this.IsDisposed) return;

            if (status == NetworkStatus.Internet)
            {
                this.BeginInvoke((MethodInvoker)(async () =>
                {
                    if (!this.IsDisposed)
                    {
                        await CargarClientes();
                        await IniciarSuscripcionClientes();
                    }
                }));
            }
        }
        private async void frmClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            await DesecharSuscripcion();
        }
        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                ClienteSeleccionado = dgvClientes.SelectedRows[0].DataBoundItem as Cliente;
            }
            else
            {
                ClienteSeleccionado = null;
            }
        }
        private void btnCliente_Click(object sender, EventArgs e)
        {
            frmAgregarEditarClientes form = new frmAgregarEditarClientes(habilitarCorreo: true);
            form.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (ClienteSeleccionado != null)
            {
                frmAgregarEditarClientes form = new frmAgregarEditarClientes(ClienteSeleccionado);
                form.ShowDialog();
                CargarClientes();
            }
            else
            {
                MessageBox.Show("Seleccione un cliente primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
