using ModernMenuUI.ServiciosUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI.InterfacesUsuarios.InicioSesion
{
    public partial class frmNuevaContrasenia : Form
    {

        private readonly ServicioRecuperacionContrasenia _servicio;
        public frmNuevaContrasenia()
        {
            InitializeComponent();
            _servicio = new ServicioRecuperacionContrasenia();
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private async void btnCambiar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            btnCambiar.Enabled = false;

            try
            {
                var resultado = await _servicio.CambiarContraseniaAsync(
                    txtNuevaContra.Text,
                    txtConfirContra.Text
                );

                if (!resultado.ok)
                {
                    MessageBox.Show(
                        resultado.mensaje,
                        "Cambio de contraseña",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                MessageBox.Show(
                    resultado.mensaje,
                    "Cambio de contraseña",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                frmIniciosesion login = new frmIniciosesion();
                this.Hide();
                login.Show();
            }
            finally
            {
                btnCambiar.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }
    }
}
