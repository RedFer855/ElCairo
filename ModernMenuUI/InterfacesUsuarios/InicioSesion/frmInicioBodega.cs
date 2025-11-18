using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeDatos.Datos;       // Necesario para Conexion
using CapaDeDatos.Modelados;   // Necesario para el modelo Bodega
using ModernMenuUI.Utilidades; // Necesario para SessionData


namespace ModernMenuUI
{
    public partial class frmInicioBodega : Form
    {
       // static String CodBodega = "1";
        //static String Contrasenia = "1";
        public frmInicioBodega()
        {
            InitializeComponent();

        }



        private async void btnAcceder_Click(object sender, EventArgs e)
        {
            string inputCodigo = txtCodigoBodega.Text.Trim();
            string inputPass = txtContrasenia.Text.Trim();

            // Validaciones básicas
            if (inputCodigo == "CÓDIGO" || string.IsNullOrEmpty(inputCodigo) ||
                inputPass == "CONTRASEÑA" || string.IsNullOrEmpty(inputPass))
            {
                lblMensajeError.Text = "Ingrese los datos.";
                lblMensajeError.Visible = true;
                return;
            }

            // Intentar convertir el código a número (porque id_bodega es numérico)
            if (!int.TryParse(inputCodigo, out int idBodegaBuscado))
            {
                lblMensajeError.Text = "El código debe ser un número (ID de bodega).";
                lblMensajeError.Visible = true;
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                var supabase = await Conexion.GetClientAsync();

                // Buscamos por ID y por Contraseña exacta
                var result = await supabase
                    .From<Bodega>()
                    .Select("*")
                    .Filter("id_bodega", Supabase.Postgrest.Constants.Operator.Equals, idBodegaBuscado)
                    .Filter("Contrasenia_Bodega", Supabase.Postgrest.Constants.Operator.Equals, inputPass)
                    .Single();

                if (result != null)
                {
                    // LOGIN CORRECTO
                    SessionData.IdBodegaActual = result.IdBodega;
                    SessionData.NombreBodegaActual = result.NombreBodega;

                    Form formcarga = new frmPantallaDeCarga();
                    this.Visible = false;
                    formcarga.ShowDialog();
                    this.Close();
                }
            }
            catch (Exception)
            {
                lblMensajeError.Text = "Datos incorrectos.";
                lblMensajeError.Visible = true;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            /* String codbodega = txtCodigoBodega.Text;
             String contrasenia = txtContrasenia.Text;
             if (contrasenia == Contrasenia && codbodega == CodBodega)
             {
                 Form formcarga = new frmPantallaDeCarga();
                 this.Visible = false;
                 formcarga.ShowDialog();
                 this.Close();
             }
             else
             {
                 lblMensajeError.Visible = true;

             }*/
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
    }
}
