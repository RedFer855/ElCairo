using CapaDeDatos.Modelados.Inventario;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI
{
    public partial class frmInicioBodega : Form
    {
        public frmInicioBodega()
        {
            InitializeComponent();
            this.Shown += (s, e) => txtCodigoBodega.Focus();
        }

        public static class SessionData
        {
            public static int IdBodegaActual { get; set; }
        }

        private void ResetearCamposLogin()
        {
            txtCodigoBodega.UseSystemPasswordChar = false;
            txtContrasenia.UseSystemPasswordChar = false;

            txtCodigoBodega.Text = "CÓDIGO";
            txtContrasenia.Text = "CONTRASEÑA";

            txtCodigoBodega.SelectionStart = 0;
            txtCodigoBodega.SelectionLength = 0;

            txtCodigoBodega.Focus();
        }

        private async void btnAcceder_Click(object sender, EventArgs e)
        {
            string codbodega = txtCodigoBodega.Text.Trim();
            string contrasenia = txtContrasenia.Text.Trim();

            // 🔥 VALIDACIÓN: asegurar que no use placeholders como datos reales
            bool codigoVacio = codbodega == "" || codbodega == "CÓDIGO";
            bool passVacia = contrasenia == "" || contrasenia == "CONTRASEÑA";

            if (codigoVacio || passVacia)
            {
                MessageBox.Show(
                    "Debe llenar todos los campos para iniciar sesión.",
                    "Campos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                btnAcceder.Enabled = false;

                bool success = await BodegaRepositorio.IniciarSesion(codbodega, contrasenia);

                if (success)
                {
                    var bodega = await BodegaRepositorio.ObtenerBodegaPorIdAsync(codbodega);

                    if (bodega != null)
                        ServicioSesionUsuario.AsignarBodegaActual(bodega);

                    Form formcarga = new frmPantallaDeCarga();
                    this.Visible = false;
                    formcarga.ShowDialog();
                }
                else
                {
                    lblMensajeError.Visible = true;
                    lblMensajeError.Text = "Código o contraseña incorrectos.";

                    ResetearCamposLogin();
                }
            }
            catch
            {
                MessageBox.Show("Error al intentar iniciar sesión.", "Error",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            finally
            {
                btnAcceder.Enabled = true;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panBarraControl_MouseDown(object sender, MouseEventArgs e)
        {
            clsAnmaciones.MoverFormulario(this.Handle);
        }

        private void txtContrasenia_Enter(object sender, EventArgs e)
        {
            if (txtContrasenia.Text == "CONTRASEÑA")
                clsAnmaciones.PrivacidadIngresarDatos(txtContrasenia, "");
        }

        private void txtContrasenia_Leave(object sender, EventArgs e)
        {
            if (txtContrasenia.Text == "")
            {
                txtContrasenia.UseSystemPasswordChar = false;
                txtContrasenia.Text = "CONTRASEÑA";
            }
        }

        private void txtCodigoBodega_Enter(object sender, EventArgs e)
        {
            if (txtCodigoBodega.Text == "CÓDIGO")
                txtCodigoBodega.Text = "";
        }

        private void txtCodigoBodega_Leave(object sender, EventArgs e)
        {
            if (txtCodigoBodega.Text == "")
                txtCodigoBodega.Text = "CÓDIGO";
        }

        private void btnVer_MouseUp(object sender, MouseEventArgs e)
        {
            if (txtContrasenia.Text != "CONTRASEÑA")
                txtContrasenia.UseSystemPasswordChar = true;
        }

        private void btnVer_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtContrasenia.Text != "CONTRASEÑA")
                txtContrasenia.UseSystemPasswordChar = false;
        }

        private void txtCodigoBodega_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtContrasenia.Focus();
            }
        }

        private void txtContrasenia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnAcceder.PerformClick();
            }
        }
    }
}
