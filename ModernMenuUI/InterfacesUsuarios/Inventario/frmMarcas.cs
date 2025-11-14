using CapaDeDatos.Datos;
using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion.CapaServiciosSeguridadValidacion;
using ModernMenuUI.InterfacesUsuarios.Compras;
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

namespace ModernMenuUI.InterfacesUsuarios.Inventario
{
    public partial class frmMarcas : Form
    {
        private readonly MarcaRepositorio marcaRepositorio;
        private List<Marca> _listaMaestraMarcas = new List<Marca>();
        private Supabase.Realtime.RealtimeChannel? _marcasSubscription;
        private readonly ServicioVerificacionConexion _monitorConexion = new ServicioVerificacionConexion();
        private Supabase.Client? _supabaseClient;
        public Marca MarcaSeleccionada { get; private set; }
        public frmMarcas()
        {
            InitializeComponent();
            btnAgregarMarca.Visible = false;
            btnModificarMArca.Visible = false;
            this.DoubleBuffered = true;
            marcaRepositorio = new MarcaRepositorio();
            dgvMarcas.AutoGenerateColumns = false;
            this.FormClosing += frmMarcas_FormClosing;
        }

        public frmMarcas(bool tipo)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            marcaRepositorio = new MarcaRepositorio();
            dgvMarcas.AutoGenerateColumns = false;
            this.FormClosing += frmMarcas_FormClosing;
        }

        private async void frmMarcas_Load(object sender, EventArgs e)
        {
            _monitorConexion.EstadoDeRedCambiado += MonitorConexion_EstadoDeRedCambiado;
            await CargarMarcasMaestras();
            RefrescarGrid();
            await IniciarSuscripcionMarcas();
        }

        private async Task CargarMarcasMaestras()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                _listaMaestraMarcas = await marcaRepositorio.ObtenerTodasLasMarcas(null);
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("No se pudo conectar con el servidor (tiempo de espera agotado).", "Error de Red", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar marcas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }


        private void RefrescarGrid()
        {
            this.Cursor = Cursors.WaitCursor;
            // gbxEstado.Enabled = false;

            // 1. Determinar el filtro de estado
            bool? estado = null;
            if (rbMostrarHablilitados.Checked) estado = true;
            if (rbMostrarDeshablitados.Checked) estado = false;

            // 2. Filtrar la LISTA MAESTRA (Declarada como List<Marca>)
            List<Marca> listaFiltrada; // <-- Declarada como List<>

            if (estado == null)
            {
                listaFiltrada = _listaMaestraMarcas; // Asigna la lista maestra
            }
            else
            {
                // Asigna el resultado de .ToList()
                listaFiltrada = _listaMaestraMarcas.Where(m => m.EstadoMarca == estado).ToList();
            }

            // 3. Asigna la lista filtrada (que ya es un List<>)
            dgvMarcas.DataSource = null;
            dgvMarcas.DataSource = listaFiltrada; // <-- Sin el .ToList() aquí

            if (dgvMarcas.Rows.Count > 0)
                dgvMarcas.ClearSelection();

            // gbxEstado.Enabled = true; 
            this.Cursor = Cursors.Default;
        }


        private async Task DesecharSuscripcion()
        {
            if (_marcasSubscription != null)
            {
                try
                {
                    await Task.Run(() => _marcasSubscription.Unsubscribe());
                    System.Diagnostics.Debug.WriteLine("Suscripción de Marcas desechada.");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error al desechar suscripción Marcas: {ex.Message}");
                }
                _marcasSubscription = null;
            }
        }

        private async Task IniciarSuscripcionMarcas()
        {
            await DesecharSuscripcion();

            try
            {
                _supabaseClient = await Conexion.ConnectWithTimeoutAsync(3);

                // Suscripción a la tabla 'marcas'
                _marcasSubscription = await _supabaseClient.From<Marca>()
                    .On(ListenType.All, (sender, change) =>
                    {
                        try
                        {
                            if (this == null || this.IsDisposed || !this.IsHandleCreated) return;

                            this.BeginInvoke((MethodInvoker)(async () =>
                            {
                                if (this.IsDisposed) return;
                                System.Diagnostics.Debug.WriteLine($"Cambio detectado: {change.Event} en Marcas.");

                                // 1. Vuelve a cargar la lista maestra
                                await CargarMarcasMaestras();
                                // 2. Refresca el grid
                                RefrescarGrid();
                            }));
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"Error manejando evento Realtime Marcas: {ex.Message}");
                        }
                    });

                System.Diagnostics.Debug.WriteLine("Suscripción a Realtime (Marcas) creada.");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al suscribir a Realtime (Marcas): {ex.Message}");
            }
        }

        // --- MANEJO DE CONEXIÓN (Misma lógica) ---
        private async void MonitorConexion_EstadoDeRedCambiado(NetworkStatus status)
        {
            if (!this.IsHandleCreated || this.IsDisposed) return;

            if (status == NetworkStatus.Internet)
            {
                this.BeginInvoke((MethodInvoker)(async () =>
                {
                    if (this.IsDisposed) return;
                    System.Diagnostics.Debug.WriteLine("Red recuperada. Recargando Marcas y Realtime...");
                    await CargarMarcasMaestras();
                    RefrescarGrid();
                    await IniciarSuscripcionMarcas();
                }));
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSeleccionarMarca_Click(object sender, EventArgs e)
        {
            if (dgvMarcas.SelectedRows.Count > 0)
            {
                MarcaSeleccionada = dgvMarcas.SelectedRows[0].DataBoundItem as Marca;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private async void frmMarcas_FormClosing(object sender, FormClosingEventArgs e)
        {
            await DesecharSuscripcion();
            _monitorConexion.EstadoDeRedCambiado -= MonitorConexion_EstadoDeRedCambiado;
        }

        private void dgvMarcas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Asignar la marca seleccionada a la propiedad pública y cerrar.
                MarcaSeleccionada = dgvMarcas.Rows[e.RowIndex].DataBoundItem as Marca;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void rbMostrarHablilitados_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbMostrarHablilitados.Checked)
            {
                RefrescarGrid();
            }
        }

        private void rbMostrarDeshablitados_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbMostrarDeshablitados.Checked)
            {
                RefrescarGrid();
            }
        }

        private void rbMostrarTodos_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbMostrarTodos.Checked)
            {
                RefrescarGrid();
            }
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            frmProveedores proveedores = new frmProveedores();  
            proveedores.ShowDialog();   
        }
    }
}
