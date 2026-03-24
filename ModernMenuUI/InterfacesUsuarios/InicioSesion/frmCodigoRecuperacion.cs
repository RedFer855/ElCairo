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
    public partial class frmCodigoRecuperacion : Form
    {

        private readonly ServicioRecuperacionContrasenia _servicio;
        private readonly string _correo;
        public frmCodigoRecuperacion(string correo)
        {
            InitializeComponent();
            _servicio = new ServicioRecuperacionContrasenia();
            _correo = correo;
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void lblRegresar_Click(object sender, EventArgs e)
        {
            frmIniciosesion login = new frmIniciosesion();
            this.Hide();
            login.Show();
        }

        private async void btnVerificar_Click(object sender, EventArgs e)
        {
            {
                this.Cursor = Cursors.AppStarting;
                btnVerificar.Enabled = false;

                try
                {
                    var resultado = await _servicio.VerificarCodigoAsync(_correo, txtCodigo.Text);

                    if (!resultado.ok)
                    {
                        MessageBox.Show(
                            resultado.mensaje,
                            "Verificación de código",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        txtCodigo.Focus();
                        txtCodigo.SelectAll();
                        return;
                    }

                    MessageBox.Show(
                        resultado.mensaje,
                        "Verificación de código",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    frmNuevaContrasenia frm = new frmNuevaContrasenia();
                    this.Hide();
                    frm.ShowDialog();
                    this.Close();
                }
                finally
                {
                    btnVerificar.Enabled = true;
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private async void btnReenviar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            btnReenviar.Enabled = false;

            try
            {
                var resultado = await _servicio.EnviarCodigoAsync(_correo);

                MessageBox.Show(
                    resultado.mensaje,
                    "Reenvío de código",
                    MessageBoxButtons.OK,
                    resultado.ok ? MessageBoxIcon.Information : MessageBoxIcon.Warning
                );
            }
            finally
            {
                btnReenviar.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
