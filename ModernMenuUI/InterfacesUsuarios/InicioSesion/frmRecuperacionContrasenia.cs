using ModernMenuUI.ClasesUI;
using ModernMenuUI.InterfacesUsuarios.InicioSesion;
using ModernMenuUI.ServiciosUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            btnEnviar.Enabled = false;

            System.Diagnostics.Stopwatch swTotal = new System.Diagnostics.Stopwatch();
            System.Diagnostics.Stopwatch swPaso = new System.Diagnostics.Stopwatch();
            swTotal.Start();

            try
            {
                // PASO A: Validar correo
                swPaso.Start();
                var validacion = await _servicio.ValidarCorreoRegistradoAsync(txtCorreo.Text);
                swPaso.Stop();
                long tiempoValidacion = swPaso.ElapsedMilliseconds;
                swPaso.Reset();

                if (!validacion.ok)
                {
                    MessageBox.Show(validacion.mensaje, "Recuperación de contraseña",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCorreo.Focus();
                    txtCorreo.SelectAll();
                    return;
                }

                // PASO B: Enviar código
                swPaso.Start();
                var resultado = await _servicio.EnviarCodigoAsync(validacion.correoNormalizado);
                swPaso.Stop();
                long tiempoEnvio = swPaso.ElapsedMilliseconds;

                if (!resultado.ok)
                {
                    MessageBox.Show(resultado.mensaje, "Recuperación de contraseña",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                swTotal.Stop();
                string resumen =
                    $"--- MÉTRICAS DE RENDIMIENTO ---\n" +
                    $"Validación de Correo: {tiempoValidacion} ms\n" +
                    $"Envío de Código: {tiempoEnvio} ms\n" +
                    $"Tiempo Total: {swTotal.ElapsedMilliseconds} ms\n" +
                    $"-------------------------------";
                MessageBox.Show(resumen, "Evaluación del Sistema",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                MessageBox.Show(resultado.mensaje, "Recuperación de contraseña",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmCodigoRecuperacion frm = new frmCodigoRecuperacion(validacion.correoNormalizado);
                this.Hide();
                frm.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                swTotal.Stop();
                MessageBox.Show($"FALLO DETECTADO:\n" +
                                $"Tiempo hasta el error: {swTotal.ElapsedMilliseconds} ms\n" +
                                $"Error: {ex.Message}", "Análisis de Fiabilidad",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void frmRecuperacionContrasenia_Load(object sender, EventArgs e)
        {
            var sw = Stopwatch.StartNew();

        }
    }
}
