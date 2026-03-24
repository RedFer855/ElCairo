using CapaServiciosSeguridadValidacion;
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
            string contra = txtNuevaContra.Text.Trim();
            string contra2 = txtConfirContra.Text.Trim();
            var v1 = ServicioValidacionesIngresoDatos.ValidarContrasenia(contra, "La contraseña");
            if (v1.Error)
            {
                MessageBox.Show(v1.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnCambiar.Enabled = true;
                return;
            }
            var v2 = ServicioValidacionesIngresoDatos.ValidarContrasenia(contra, "La contraseña");
            if (v2.Error)
            {
                MessageBox.Show(v2.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnCambiar.Enabled = true;
                return;
            }
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
                
                this.Close();           

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
