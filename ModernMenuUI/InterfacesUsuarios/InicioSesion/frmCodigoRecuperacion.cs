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

        private int segundosRestantes = 60;

        private void IniciarContadorReenvio()
        {
            segundosRestantes = 60;
            btnReenviar.Enabled = false;
            lblContadorReenvio.Text = $"Podrás reenviar el código en {segundosRestantes} s";
            timerReenvio.Start();
        }

        private void timerReenvio_Tick(object sender, EventArgs e)
        {
            segundosRestantes--;

            if (segundosRestantes > 0)
            {
                lblContadorReenvio.Text = $"Podrás reenviar el código en {segundosRestantes} s";
            }
            else
            {
                timerReenvio.Stop();
                btnReenviar.Enabled = true;
                lblContadorReenvio.Text = "Ya puedes reenviar el código.";
            }
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void lblRegresar_Click(object sender, EventArgs e)
        {
            frmRecuperacionContrasenia login = new frmRecuperacionContrasenia();
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
                    this.Close();
                    frm.Show();
              
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

                if (resultado.ok)
                {
                    MessageBox.Show("Se envió un nuevo código al correo.");
                    IniciarContadorReenvio();
                }
                else
                {
                    MessageBox.Show(resultado.mensaje);
                    btnReenviar.Enabled = true;
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtCodigo_Enter(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "Código...")
            {
                txtCodigo.Text = "";
                txtCodigo.ForeColor = Color.White;
            }
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                txtCodigo.Text = "Código...";
                txtCodigo.ForeColor = Color.White;
            }
        }

        private void lblRegresar_MouseEnter(object sender, EventArgs e)
        {
            lblRegresar.ForeColor = Color.Blue;
            lblRegresar.Font = new Font(lblRegresar.Font, FontStyle.Underline);
        }

        private void lblRegresar_MouseLeave(object sender, EventArgs e)
        {
            lblRegresar.ForeColor = Color.DimGray;
            lblRegresar.Font = new Font(lblRegresar.Font, FontStyle.Regular);
        }

        private void frmCodigoRecuperacion_Load(object sender, EventArgs e)
        {
            txtCodigo.MaxLength = 6;
            IniciarContadorReenvio();
        }
    }
}
