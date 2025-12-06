using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using CapaDeDatos.Modelados.UsuariosEmpleados;
using CapaDeDatos.Modelados.Ventas;
using ModernMenuUI.ClasesUI;
using Supabase.Realtime;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI.InterfacesUsuarios.Ventas
{
    public partial class frmCierreDiario : Form
    {
        private RealtimeChannel? _ventasSubscription;
        private bool _formCargado = false;

        public frmCierreDiario()
        {
            InitializeComponent();
            dgvCierre.AutoGenerateColumns = false;
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

        private async Task CargarCierreDiarioAsync()
        {
            var supabase = await Conexion.GetClientAsync();

            string alias = cmbEmpleado.SelectedValue?.ToString();
            DateTime fecha = dtpFecha.Value.Date;

            if (string.IsNullOrWhiteSpace(alias))
                return;

            var lista = await supabase.Rpc<List<CierreDiarioResult>>("fn_cierre_diario_alias", new
            {
                p_alias_usuario = alias,
                p_fecha = fecha.ToString("yyyy-MM-dd")
            });

            // 👉 ÚNICO DGV
            dgvCierre.DataSource = lista;

            // 👉 SUMATORIA
            decimal totalDia = lista.Sum(x => x.Subtotal);
            txtTotalVentas.Text = "L." + totalDia.ToString("0.00");
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

                var lista = resp.Models.ToList();

                cmbEmpleado.DataSource = lista;
                cmbEmpleado.DisplayMember = "AliasUsuario";
                cmbEmpleado.ValueMember = "AliasUsuario";
                cmbEmpleado.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            this.Close();
        }

        private async void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (!_formCargado) return;
            if (cmbEmpleado.SelectedValue == null)
                return;

            await GenerarCierreAsync();
        }

        private async void frmCierreDiario_Load(object sender, EventArgs e)
        {
            dgvCierre.DataSource = new List<CierreDiarioResult>();

            await CargarAliasUsuariosAsync();
            dtpFecha.Value = DateTime.Today;

            _formCargado = true;
        }

        private async void cmbEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_formCargado) return;
            if (cmbEmpleado.SelectedValue == null)
                return;

            await GenerarCierreAsync();
        }

        private async void frmCierreDiario_FormClosing(object sender, FormClosingEventArgs e)
        {
            await DesecharSuscripcionVentas();
        }

        private void btnImprimirCierre_Click(object sender, EventArgs e)
        {
            var datosCierre = dgvCierre.DataSource as List<CierreDiarioResult>;

            string totalVentas = txtTotalVentas.Text;
            string alias = cmbEmpleado.Text;
            string fecha = dtpFecha.Value.ToShortDateString();

            if (datosCierre == null || !datosCierre.Any())
            {
                MessageBox.Show("No hay datos cargados para exportar. Por favor, selecciona un empleado y una fecha con ventas.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var frm = new frmImprimirCierre(datosCierre, totalVentas, alias, fecha))
            {
                frm.ShowDialog();
            }
        }

        private void btnBuscarEmpleado_Click(object sender, EventArgs e)
        {
            frmUsuario _usuarioCierre = new frmUsuario();   
            _usuarioCierre.ShowDialog();
        }
    }
}
