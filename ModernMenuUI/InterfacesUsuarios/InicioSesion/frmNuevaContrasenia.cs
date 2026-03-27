using CapaServiciosSeguridadValidacion;
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

namespace ModernMenuUI.InterfacesUsuarios.InicioSesion
{
    public partial class frmNuevaContrasenia : Form
    {

        private readonly ServicioRecuperacionContrasenia _servicio;

        private static readonly Serilog.ILogger _log = new Serilog.LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/NuevaContra.txt", rollingInterval: Serilog.RollingInterval.Day)
    .CreateLogger();
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
            string contra = txtNuevaContra.Text.Trim();
            string contra2 = txtConfirContra.Text.Trim();

            var v1 = ServicioValidacionesIngresoDatos.ValidarContrasenia(contra, "La contraseña");
            if (v1.Error)
            {
                _log.Warning("Contraseña nueva no cumple validaciones: {Mensaje}", v1.Mensaje);
                MessageBox.Show(v1.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnCambiar.Enabled = true;
                return;
            }

            var v2 = ServicioValidacionesIngresoDatos.ValidarContrasenia(contra2, "La confirmación");
            if (v2.Error)
            {
                _log.Warning("Confirmación de contraseña no cumple validaciones: {Mensaje}", v2.Mensaje);
                MessageBox.Show(v2.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnCambiar.Enabled = true;
                return;
            }

            this.Cursor = Cursors.AppStarting;
            btnCambiar.Enabled = false;

            try
            {
                _log.Information("Intentando cambiar contraseña");

                var resultado = await _servicio.CambiarContraseniaAsync(
                    txtNuevaContra.Text,
                    txtConfirContra.Text
                );

                if (!resultado.ok)
                {
                    _log.Warning("Fallo al cambiar contraseña: {Mensaje}", resultado.mensaje);
                    MessageBox.Show(
                        resultado.mensaje,
                        "Cambio de contraseña",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                _log.Information("Contraseña cambiada exitosamente");
                MessageBox.Show(
                    resultado.mensaje,
                    "Cambio de contraseña",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                this.Close();
            }
            catch (Exception ex)
            {
                _log.Error(ex, "Error inesperado al cambiar contraseña");
                MessageBox.Show("Ocurrió un error inesperado. Intente de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnCambiar.Enabled = true;
                this.Cursor = Cursors.Default;
            }

            frmIniciosesion Inicio = new frmIniciosesion();
            Inicio.Show();
        }

        private void lblRegresar_Click(object sender, EventArgs e)
        {
            frmIniciosesion Inicio = new frmIniciosesion();
            this.Close();
            Inicio.Show();
            
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

        private void txtNuevaContra_Enter(object sender, EventArgs e)
        {
            if (txtNuevaContra.Text == "Nueva Contraseña...")
            {
                txtNuevaContra.Text = "";
                txtNuevaContra.ForeColor = Color.White;
                txtNuevaContra.UseSystemPasswordChar = true;
            }
        }

        private void txtNuevaContra_Leave(object sender, EventArgs e)
        {
            if (txtNuevaContra.Text == "")
            {
                txtNuevaContra.Text = "Nueva Contraseña...";
                txtNuevaContra.ForeColor = Color.Gray;
                txtNuevaContra.UseSystemPasswordChar = false;
            }
        }

        private void txtConfirContra_Enter(object sender, EventArgs e)
        {
            if (txtConfirContra.Text == "Confirmar Contraseña...")
            {
                txtConfirContra.Text = "";
                txtConfirContra.ForeColor = Color.White;
                txtConfirContra.UseSystemPasswordChar = true;
            }
        }

        private void txtConfirContra_Leave(object sender, EventArgs e)
        {
            if (txtNuevaContra.Text == "")
            {
                txtNuevaContra.Text = "Confirmar Contraseña...";
                txtNuevaContra.ForeColor = Color.Gray;
                txtNuevaContra.UseSystemPasswordChar = false;
            }
        }

        private void btnVerNueva_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtNuevaContra.Text != "Nueva Contraseña...")
            {
                txtNuevaContra.UseSystemPasswordChar = false;
            }
        }

        private void btnVerConfirmacion_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtConfirContra.Text != "Confirmar Contraseña...")
            {
                txtConfirContra.UseSystemPasswordChar = false;
            }
        }

        private void btnVerNueva_MouseUp(object sender, MouseEventArgs e)
        {
            if (txtNuevaContra.Text != "Nueva Contraseña...")
            {
                txtNuevaContra.UseSystemPasswordChar = true;
            }
        }

        private void btnVerConfirmacion_MouseUp(object sender, MouseEventArgs e)
        {
            if (txtConfirContra.Text != "Confirmar Contraseña...")
            {
                txtConfirContra.UseSystemPasswordChar = true;
            }
        }
    }
}
