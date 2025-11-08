using CapaDeDatos.Modelados;
using CapaDeDatos.Repositorios;
using ModernMenuUI.ClasesUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI
{

    public partial class frmGestionUsuario : Form
    {
        private readonly UsuarioRepositorio usuario_repo;


        private async void frmGestionUsuario_Load(object sender, EventArgs e)
        {
            //CargarUsuarios();
            var supabase = await CapaDeDatos.Datos.Conexion.GetClientAsync();

            if (supabase != null)
            {
                MessageBox.Show("Conexión exitosa al servidor.", "Conexión Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                this.Close();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            this.Close();
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        /*
        private async void CargarUsuarios()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                List<Usuario> listausuarios = await usuario_repo.ObtenerTodosLosUsuarios();
                dgvUsuarios.DataSource = null;
                dgvUsuarios.DataSource = listausuarios;
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
        */

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }


    }
}
