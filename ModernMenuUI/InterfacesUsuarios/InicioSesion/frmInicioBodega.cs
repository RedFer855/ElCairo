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
using BCrypt.Net;


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

            // 1. Validaciones básicas
            if (inputCodigo == "CÓDIGO" || string.IsNullOrEmpty(inputCodigo) ||
                inputPass == "CONTRASEÑA" || string.IsNullOrEmpty(inputPass))
            {
                lblMensajeError.Text = "Ingrese los datos.";
                lblMensajeError.Visible = true;
                return;
            }

            // 2. Convertir ID
            if (!int.TryParse(inputCodigo, out int idBodegaBuscado))
            {
                lblMensajeError.Text = "El código debe ser un número.";
                lblMensajeError.Visible = true;
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                var supabase = await Conexion.GetClientAsync();

                // 3. CAMBIO IMPORTANTE: Solo buscamos por ID, NO por contraseña
                var result = await supabase
                    .From<Bodega>()
                    .Select("*")
                    .Filter("id_bodega", Supabase.Postgrest.Constants.Operator.Equals, idBodegaBuscado)
                    .Single(); // Traemos la bodega (con su contraseña encriptada)

                if (result != null)
                {
                    // 4. VERIFICAR LA CONTRASEÑA ENCRIPTADA
                    // BCrypt compara tu texto ("1234") con el hash ("$2a$06...") y nos dice si coinciden.
                    bool passwordEsCorrecta = false;

                    try
                    {
                        // Intenta verificar como Hash BCrypt
                        passwordEsCorrecta = BCrypt.Net.BCrypt.Verify(inputPass, result.ContraseniaBodega);
                    }
                    catch
                    {
                        // Si falla (por ejemplo, si la contraseña en la BD es texto plano "1234" y no un hash)
                        // hacemos una comparación simple como respaldo.
                        if (inputPass == result.ContraseniaBodega) passwordEsCorrecta = true;
                    }

                    if (passwordEsCorrecta)
                    {
                        // --- LOGIN CORRECTO ---
                        SessionData.IdBodegaActual = result.IdBodega;
                        SessionData.NombreBodegaActual = result.NombreBodega;

                        Form formcarga = new frmPantallaDeCarga();
                        this.Visible = false;
                        formcarga.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        // Contraseña incorrecta
                        lblMensajeError.Text = "Contraseña incorrecta.";
                        lblMensajeError.Visible = true;
                    }
                }
            }
            catch (Exception)
            {
                // Si no encuentra el ID de la bodega
                lblMensajeError.Text = "La bodega no existe.";
                lblMensajeError.Visible = true;
            }
            finally
            {
                this.Cursor = Cursors.Default;
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
    }
}
