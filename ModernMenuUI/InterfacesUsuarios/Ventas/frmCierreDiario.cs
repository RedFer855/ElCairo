using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using Supabase.Realtime;
using static Supabase.Realtime.PostgresChanges.PostgresChangesOptions;

namespace ModernMenuUI.InterfacesUsuarios.Ventas
{
    public partial class frmCierreDiario : Form
    {
        private Supabase.Client? _supabaseClient;
        private RealtimeChannel? _ventasSubscription;
        private bool _formCargado = false;
        public frmCierreDiario()
        {
            InitializeComponent();
            dgvCierreDiario.AutoGenerateColumns = false;
            txtTotalVentas.ReadOnly = true;
            this.FormClosing += frmCierreDiario_FormClosing;
        }
        private async Task DesecharSuscripcionVentas()
        {
            if (_ventasSubscription != null)
            {
                try
                {
                    await Task.Run(() => _ventasSubscription.Unsubscribe());
                    System.Diagnostics.Debug.WriteLine("Suscripción a Ventas desechada.");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error al desuscribir Ventas: {ex.Message}");
                }

                _ventasSubscription = null;
            }
        }
       /* private async Task IniciarSuscripcionVentas()
        {
            // Por si ya había una suscripción activa
            await DesecharSuscripcionVentas();

            try
            {
                _supabaseClient = await Conexion.ConnectWithTimeoutAsync(10);

                // Suscripción a la tabla "ventas"
                _ventasSubscription = await _supabaseClient
                    .From<Venta>()              // 👈 tu modelo de ventas
                    .On(ListenType.All, (sender, change) =>
                    {
                        // Esto se ejecuta en hilo de Supabase, hay que volver al hilo de UI
                        if (!this.IsHandleCreated || this.IsDisposed) return;

                        this.BeginInvoke((MethodInvoker)(async () =>
                        {
                            if (this.IsDisposed) return;
                            if (!_formCargado) return;

                            // Cada vez que se inserte/actualice/elimine una venta,
                            // volvemos a generar el cierre (respeta alias + fecha actuales):
                            await GenerarCierreAsync();  // o CargarCierreDiarioAsync()
                        }));
                    });

                System.Diagnostics.Debug.WriteLine("Suscripción a Ventas (Realtime) creada.");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al suscribir a Realtime (Ventas): {ex.Message}");
            }
        }*/

        private void btnSalir_Click(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            this.Close();
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private async Task CargarCierreDiarioAsync()
        {
            var supabase = await Conexion.GetClientAsync();

            string alias = cmbEmpleados.SelectedValue?.ToString();
            DateTime fecha = dtpFecha.Value.Date;

            if (string.IsNullOrWhiteSpace(alias))
                return;

            var lista = await supabase.Rpc<List<CierreDiarioResult>>("fn_cierre_diario_alias", new
            {
                p_alias_usuario = alias,
                p_fecha = fecha.ToString("yyyy-MM-dd")
            });

            dgvCierreDiario.DataSource = lista;

            decimal totalDia = lista.Sum(x => x.Subtotal);
            txtTotalVentas.Text = totalDia.ToString("0.00");

            if (dgvCierreDiario.Columns.Contains("BaseUrl"))
                dgvCierreDiario.Columns["BaseUrl"].Visible = false;
            if (dgvCierreDiario.Columns.Contains("RequestClient"))
                dgvCierreDiario.Columns["RequestClient"].Visible = false;
            if (dgvCierreDiario.Columns.Contains("TableName"))
                dgvCierreDiario.Columns["TableName"].Visible = false;
            if (dgvCierreDiario.Columns.Contains("PrimaryKey"))
                dgvCierreDiario.Columns["PrimaryKey"].Visible = false;
            if (dgvCierreDiario.Columns.Contains("RequestClientOptions"))
                dgvCierreDiario.Columns["RequestClientOptions"].Visible = false;
            if (dgvCierreDiario.Columns.Contains("FechaVenta"))
                dgvCierreDiario.Columns["FechaVenta"].Visible = false;




        }
        private async Task CargarAliasUsuariosAsync()
        {
            try
            {
                var supabase = await Conexion.GetClientAsync();

                var resp = await supabase
                    .From<Usuario>()
                    .Select("alias_usuario")
                    .Get();

                // Usamos directamente la lista de Usuario
                var lista = resp.Models.ToList();

                cmbEmpleados.DataSource = lista;
                cmbEmpleados.DisplayMember = "AliasUsuario"; // lo que se muestra
                cmbEmpleados.ValueMember = "AliasUsuario";   // lo que se usa como valor
                cmbEmpleados.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void btnCierre_Click(object sender, EventArgs e)
        {
            var datosCierre = dgvCierreDiario.DataSource as List<CierreDiarioResult>;

            // 2. Obtener los valores de resumen necesarios
            string totalVentas = txtTotalVentas.Text;
            string alias = cmbEmpleados.Text; // Alias del empleado seleccionado
            string fecha = dtpFecha.Value.ToShortDateString(); // Fecha seleccionada

            // 3. Validación de datos
            if (datosCierre == null || !datosCierre.Any())
            {
                MessageBox.Show("No hay datos cargados para exportar. Por favor, selecciona un empleado y una fecha con ventas.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Crear una instancia del nuevo formulario (frmImprimirCierre) 
            // y pasarle los datos al constructor.
            using (var frm = new frmImprimirCierre(datosCierre, totalVentas, alias, fecha))
            {
                // Mostrar el nuevo formulario como un diálogo modal
                frm.ShowDialog();
            }
            /*frmImprimirCierre cierre = new frmImprimirCierre();
            cierre.ShowDialog();*/
        }
        private async Task GenerarCierreAsync()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                await CargarCierreDiarioAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el cierre: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private async void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (!_formCargado) return;
            if (cmbEmpleados.SelectedValue == null)
                return;

            await GenerarCierreAsync();
        }

        private async void frmCierreDiario_Load(object sender, EventArgs e)
        {
            dgvCierreDiario.AutoGenerateColumns = true;
            dgvCierreDiario.DataSource = new List<CierreDiarioResult>();

            await CargarAliasUsuariosAsync();
            dtpFecha.Value = DateTime.Today;

            _formCargado = true;
            /*dgvCierreDiario.AutoGenerateColumns = true;
            dgvCierreDiario.DataSource = new List<CierreDiarioResult>();
            await CargarAliasUsuariosAsync();
            dtpFecha.Value = DateTime.Today;*/
        }

        private async void cmbEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_formCargado) return;
            if (cmbEmpleados.SelectedValue == null)
                return;
            await GenerarCierreAsync();
        }

        private async void frmCierreDiario_FormClosing(object sender, FormClosingEventArgs e)
        {
            await DesecharSuscripcionVentas();
        }
    }
}
