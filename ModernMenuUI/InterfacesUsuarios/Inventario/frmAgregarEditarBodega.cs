using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI.InterfacesUsuarios.Inventario
{
    public partial class frmAgregarEditarBodega : Form
    {
        public frmAgregarEditarBodega()
        {
            InitializeComponent();
        }

        public frmAgregarEditarBodega(Bodega _nuevaBodega)
        {
            InitializeComponent();
            txtNombreBodega.Text = _nuevaBodega.NombreBodega;
                
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnGuardarBodega_Click(object sender, EventArgs e)
        {
            try
            {
                var supabase = await Conexion.GetClientAsync();
                var usuarioAuth = supabase.Auth.CurrentUser;
                
                await supabase.Rpc("insertar_bodega", new
                {
                    p_nombre_bodega = txtNombreBodega.Text,
                    p_contrasenia = txtContrasenia.Text,
                    p_estado_bodega = rbActivo.Checked,
                    p_id_estado = rbActivo.Checked ? 1 : 2
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la bodega: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Close();
            }
        }
    }
}
