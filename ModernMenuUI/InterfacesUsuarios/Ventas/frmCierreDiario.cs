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

namespace ModernMenuUI.InterfacesUsuarios.Ventas
{
    public partial class frmCierreDiario : Form
    {
        public frmCierreDiario()
        {
            InitializeComponent();
            dgvCierreDiario.AutoGenerateColumns = true;
            txtTotalVentas.ReadOnly = true;
        }

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

            // AHORA usamos el alias, no idEmpleado
            string alias = cmbEmpleados.SelectedValue?.ToString();
            DateTime fecha = dtpFecha.Value.Date;

            if (string.IsNullOrWhiteSpace(alias))
            {
                // Todavía no hay alias seleccionado, no hacemos nada
                return;
            }

            // Llamamos a la función que filtra por ALIAS + FECHA
            var lista = await supabase.Rpc<List<CierreDiarioResult>>("fn_cierre_diario_alias", new
            {
                p_alias_usuario = alias,
                p_fecha = fecha.ToString("yyyy-MM-dd")
            });

           // MessageBox.Show("Filas devueltas: " + lista.Count);

            // Llenar DataGridView
            dgvCierreDiario.DataSource = lista;

            // Total de ventas del día
            decimal totalDia = lista.Sum(x => x.Subtotal);
            txtTotalVentas.Text = totalDia.ToString("0.00");
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
            
        }

        private async void frmCierreDiario_Load(object sender, EventArgs e)
        {
            dgvCierreDiario.AutoGenerateColumns = true;
            dgvCierreDiario.DataSource = new List<CierreDiarioResult>();
            await CargarAliasUsuariosAsync();
            dtpFecha.Value = DateTime.Today;
        }

        private async void cmbEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            await GenerarCierreAsync();
        }
    }
}
