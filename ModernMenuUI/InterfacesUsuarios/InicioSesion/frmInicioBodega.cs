using CapaDeDatos.Modelados.Inventario;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
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
        private void LimpiarDatos()
        {
            txtContrasenia.Text = null;
            txtCodigoBodega.Text = null;
            txtCodigoBodega.Focus();
        }

        private async void btnAcceder_Click(object sender, EventArgs e)
        {
            string codbodega = txtCodigoBodega.Text.Trim();
            string contrasenia = txtContrasenia.Text.Trim();

            try
            {
                // Puedes mostrar un pequeño mensaje o un spinner aquí
                btnAcceder.Enabled = false;

                bool success = await BodegaRepositorio.IniciarSesion(codbodega, contrasenia);

                if (success)
                {
                    // Recuperar datos de la bodega logueada
                    var bodega = await BodegaRepositorio.ObtenerBodegaPorIdAsync(codbodega);


                    if (bodega != null)
                    {
                        ServicioSesionUsuario.AsignarBodegaActual(bodega);
                    }

                    Bodega id_bodega = new Bodega();


                    // Guardar en la sesión global
                    SessionData.IdBodegaActual = bodega.IdBodega;
                    var formCarga = new frmPantallaDeCarga();
                    this.Visible = false;

                    formCarga.ShowDialog();
                    this.Close();
                }
                else
                {
                    lblMensajeError.Visible = true;
                    lblMensajeError.Text = "Código o contraseña incorrectos.";
                    codbodega = "";
                    contrasenia = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar iniciar sesión.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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
            {
                clsAnmaciones.PrivacidadIngresarDatos(txtContrasenia, "");
            }
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
            {
                txtCodigoBodega.Text = "";
            }
        }

        private void txtCodigoBodega_Leave(object sender, EventArgs e)
        {
            if (txtCodigoBodega.Text == "")
            {
                txtCodigoBodega.Text = "CÓDIGO";
            }
        }


        private void btnVer_MouseUp(object sender, MouseEventArgs e)
        {
            if (txtContrasenia.Text != "CONTRASEÑA")
            {
                txtContrasenia.UseSystemPasswordChar = true;
            }
        }

        private void btnVer_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtContrasenia.Text != "CONTRASEÑA")
            {
                txtContrasenia.UseSystemPasswordChar = false;
            }
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
