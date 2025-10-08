using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI
{
    public partial class FormInicioUsuarios : Form
    {
        public FormInicioUsuarios()
        {
            InitializeComponent();
        }
        private void btnAcceder_Click(object sender, EventArgs e)
        {
            Form formcarga = new FormPantallaDeCarga();
            this.Visible = false;
            formcarga.ShowDialog();
            this.Close();

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void panDatosIngreso_MouseDown(object sender, MouseEventArgs e)
        {

            Clase_Animaciones.MoverFormulario(this.Handle);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Clase_Animaciones.MoverFormulario(this.Handle);
        }

        private void panBarraControl_MouseDown(object sender, MouseEventArgs e)
        {
            Clase_Animaciones.MoverFormulario(this.Handle);
        }

        private void panLogo_MouseDown(object sender, MouseEventArgs e)
        {
            Clase_Animaciones.MoverFormulario(this.Handle);
        }

        // ANIMACIONES DENTRO DE 

        // Salir de la caja de contraseña y usuario
        private void txtContra_Leave(object sender, EventArgs e)
        {
            if (txtContra.Text == "")
            {
                txtContra.Text = "CONTRASEÑA";
                txtContra.ForeColor = Color.LightGray;
                txtContra.UseSystemPasswordChar = false;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        // Ingresar a caja de contra y usuario
        private void txtContra_Enter(object sender, EventArgs e)
        {
            Clase_Animaciones.PrivacidadIngresarDatos(txtContra, "");
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }
    }
}
