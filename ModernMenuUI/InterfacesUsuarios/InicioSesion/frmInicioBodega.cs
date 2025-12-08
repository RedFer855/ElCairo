using CapaDeDatos.Modelados.Inventario;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
using System;
using System.Windows.Forms;

namespace ModernMenuUI
{
    public partial class frmInicioBodega : Form
    {
        private string _placeholderCodigo = "CÓDIGO";
        private string _placeholderContrasenia = "CONTRASEÑA";

        public frmInicioBodega()
        {
            InitializeComponent();
            this.Shown += (s, e) => txtCodigoBodega.Focus();
        }

        public static class SessionData
        {
            public static int IdBodegaActual { get; set; }
        }

        /// <summary>
        /// Restablece los campos visuales del formulario de inicio.
        /// </summary>
        private void ResetearCamposLogin()
        {
            txtCodigoBodega.UseSystemPasswordChar = false;
            txtContrasenia.UseSystemPasswordChar = false;

            txtCodigoBodega.Text = _placeholderCodigo;
            txtContrasenia.Text = _placeholderContrasenia;

            txtCodigoBodega.SelectionStart = 0;
            txtCodigoBodega.SelectionLength = 0;

            txtCodigoBodega.Focus();
        }

        /// <summary>
        /// Procesa el intento de inicio de sesión a una bodega.
        /// </summary>
        private async void btnAcceder_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigoBodega.Text.Trim();
            string contrasenia = txtContrasenia.Text.Trim();

            bool codigoInvalido = codigo == "" || codigo == _placeholderCodigo;
            bool contraseniaInvalida = contrasenia == "" || contrasenia == _placeholderContrasenia;

            if (codigoInvalido || contraseniaInvalida)
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

                bool loginCorrecto = await BodegaRepositorio.IniciarSesion(codigo, contrasenia);

                if (loginCorrecto)
                {
                    var bodega = await BodegaRepositorio.ObtenerBodegaPorIdAsync(codigo);

                    if (bodega != null)
                        ServicioSesionUsuario.AsignarBodegaActual(bodega);

                    Form pantallaCarga = new frmPantallaDeCarga();
                    this.Visible = false;
                    pantallaCarga.ShowDialog();
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

        /// <summary>
        /// Cierra el formulario.
        /// </summary>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Minimiza la ventana actual.
        /// </summary>
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Permite mover la ventana mediante el panel superior.
        /// </summary>
        private void panBarraControl_MouseDown(object sender, MouseEventArgs e)
        {
            clsAnmaciones.MoverFormulario(this.Handle);
        }

        /// <summary>
        /// Limpia el placeholder al enfocarse en la contraseña.
        /// </summary>
        private void txtContrasenia_Enter(object sender, EventArgs e)
        {
            if (txtContrasenia.Text == _placeholderContrasenia)
                clsAnmaciones.PrivacidadIngresarDatos(txtContrasenia, "");
        }

        /// <summary>
        /// Restaura el placeholder cuando no hay texto.
        /// </summary>
        private void txtContrasenia_Leave(object sender, EventArgs e)
        {
            if (txtContrasenia.Text == "")
            {
                txtContrasenia.UseSystemPasswordChar = false;
                txtContrasenia.Text = _placeholderContrasenia;
            }
        }

        /// <summary>
        /// Limpia placeholder del código al entrar.
        /// </summary>
        private void txtCodigoBodega_Enter(object sender, EventArgs e)
        {
            if (txtCodigoBodega.Text == _placeholderCodigo)
                txtCodigoBodega.Text = "";
        }

        /// <summary>
        /// Restaura placeholder del código si no hay texto.
        /// </summary>
        private void txtCodigoBodega_Leave(object sender, EventArgs e)
        {
            if (txtCodigoBodega.Text == "")
                txtCodigoBodega.Text = _placeholderCodigo;
        }

        /// <summary>
        /// Muestra u oculta la contraseña al mantener presionado el botón.
        /// </summary>
        private void btnVer_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtContrasenia.Text != _placeholderContrasenia)
                txtContrasenia.UseSystemPasswordChar = false;
        }

        private void btnVer_MouseUp(object sender, MouseEventArgs e)
        {
            if (txtContrasenia.Text != _placeholderContrasenia)
                txtContrasenia.UseSystemPasswordChar = true;
        }

        /// <summary>
        /// Enviar con Enter desde el campo código.
        /// </summary>
        private void txtCodigoBodega_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtContrasenia.Focus();
            }
        }

        /// <summary>
        /// Enviar formulario con Enter desde contraseña.
        /// </summary>
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
