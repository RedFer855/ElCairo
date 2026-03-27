using ModernMenuUI.ClasesUI;
using ModernMenuUI.InterfacesUsuarios.InicioSesion;
using ModernMenuUI.ServiciosUI;
using Serilog;
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
    public partial class frmRecuperacionContrasenia : Form
    {

        private readonly ServicioRecuperacionContrasenia _servicio;

        private static readonly Serilog.ILogger _log = new Serilog.LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/RecuContra.txt", rollingInterval: Serilog.RollingInterval.Day)
    .CreateLogger();

        public frmRecuperacionContrasenia()
        {
            InitializeComponent();
            _servicio = new ServicioRecuperacionContrasenia();
        }




        private void pbxLogoEmpresa_MouseDown(object sender, MouseEventArgs e)
        {
            clsAnmaciones.MoverFormulario(this.Handle);
        }

        private void panDatosIngreso_MouseDown(object sender, MouseEventArgs e)
        {
            clsAnmaciones.MoverFormulario(this.Handle);
        }

        private void panBarraControl_MouseDown(object sender, MouseEventArgs e)
        {
            clsAnmaciones.MoverFormulario(this.Handle);
        }

        private void lblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            clsAnmaciones.MoverFormulario(this.Handle);
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblRegresar_Click(object sender, EventArgs e)
        {
            frmIniciosesion inicio = new frmIniciosesion();
            inicio.Show();
            this.Hide();
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

        private void panBarraControl_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            btnEnviar.Enabled = false;

            try
            {
                _log.Information("Solicitud de recuperación de contraseña para: {Correo}", txtCorreo.Text);

                var validacion = await _servicio.ValidarCorreoRegistradoAsync(txtCorreo.Text);

                if (!validacion.ok)
                {
                    _log.Warning("Correo no registrado en recuperación: {Correo}", txtCorreo.Text);
                    MessageBox.Show(
                        validacion.mensaje,
                        "Recuperación de contraseña",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    txtCorreo.Focus();
                    txtCorreo.SelectAll();
                    return;
                }

                var resultado = await _servicio.EnviarCodigoAsync(validacion.correoNormalizado);

                if (!resultado.ok)
                {
                    _log.Warning("Fallo al enviar código de recuperación a: {Correo}", validacion.correoNormalizado);
                    MessageBox.Show(
                        resultado.mensaje,
                        "Recuperación de contraseña",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                _log.Information("Código de recuperación enviado exitosamente a: {Correo}", validacion.correoNormalizado);
                MessageBox.Show(
                    resultado.mensaje,
                    "Recuperación de contraseña",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                frmCodigoRecuperacion frm = new frmCodigoRecuperacion(validacion.correoNormalizado);
                this.Hide();
                frm.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                _log.Error(ex, "Error inesperado en recuperación de contraseña para: {Correo}", txtCorreo.Text);
                MessageBox.Show("Ocurrió un error inesperado. Intente de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnEnviar.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        private void txtCorreo_Enter(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "Correo...")
            {
                txtCorreo.Text = "";
                txtCorreo.ForeColor = Color.White;
            }
        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "")
            {
                txtCorreo.Text = "Correo...";
                txtCorreo.ForeColor = Color.Gray;
            }
        }
    }
}
