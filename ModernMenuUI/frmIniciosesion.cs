using CapaDeDatos;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ModernMenuUI
{
    public partial class frmIniciosesion : Form
    {
        private readonly Supabase.Client SupabaseClient;

        public frmIniciosesion()
        {
            InitializeComponent();
        }
        public void LimpiarDatos(object sender, EventArgs e)
        {
            txtContra.Text = "";
            txtUsuario.Text = "";
            txtContra_Leave(e, e);
            txtUsuario_Leave(e, e);
            txtContra.Focus();
            txtUsuario.Focus();
        }
        private async void btnAcceder_Click(object sender, EventArgs e)
        {
            btnAcceder.Enabled = false;

            if (txtContra.Text == "" || txtUsuario.Text == "")
            {
                btnAcceder.Enabled = true;
                MessageBox.Show("El Usuario o contraseña estan vacios", "Credenciales Vacias", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LimpiarDatos(e,e);
            }
            else
            {
                string username = txtUsuario.Text;
                string password = txtContra.Text;



                // ... (Validación inicial y deshabilitar botón) ...

                try
                {
                    pbxCargando.Visible = true;
                    Usuario_ usuario = await clsConexion.Iniciar_Sesion(username, password);

                    if (usuario != null)
                    {
                        // Muestra el label y prepara el primer mensaje
                        lblMensajeError.ForeColor = Color.DarkGray; // Color neutro para carga
                        lblMensajeError.Text = "Conectando al servidor...";
                        lblMensajeError.Visible = true;

                        // Pausa 1: Espera 1.5 segundos
                        await Task.Delay(1000);

                        // Pausa 2: Muestra el segundo mensaje
                        lblMensajeError.Text = "Verificando credenciales...";
                        await Task.Delay(1000);

                        // Pausa 3: Muestra el tercer mensaje (opcional, simula la espera real)
                        lblMensajeError.Text = "Procesando...";

                        await Task.Delay(1000); // 2 segundos finales para sumar 5s totales
                        lblMensajeError.ForeColor = Color.Green;
                        lblMensajeError.Text = "Inicio exitoso Bienvenido a El Cairo...";
                        await Task.Delay(1000);
                        pbxCargando.Visible = false;
                        // ÉXITO: ... (Tu código de éxito) ...


                        Form formcarga = new frmInicioBodega();
                        this.Visible = false;
                        formcarga.ShowDialog();
                        this.Close();
                        lblMensajeError.Visible = true;
                    }
                    else
                    {
                        pbxCargando.Visible = false;
                        // FALLO DE CREDENCIALES: El servidor respondió, pero el usuario/contraseña no coincide.
                        lblMensajeError.Visible = true;

                        // Lógica de limpieza y re-enfoque
                        LimpiarDatos(e, e);
                    }
                }
                catch (System.Net.WebException wex)
                {
                    pbxCargando.Visible = false;

                    // NUEVO BLOQUE: Captura explícitamente el fallo de conexión/red
                    MessageBox.Show($"Fallo de conexión: {wex.Message}\nAsegúrese de que el Wi-Fi o su conexión de red estén activos.",
                                    "Error de Conexión de Red", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimpiarDatos(e, e);
                }
                catch (TimeoutException tex)
                {
                    pbxCargando.Visible = false;
                    // Captura el error de timeout (conexión lenta)
                    MessageBox.Show(tex.Message, "Tiempo de Espera del Servidor Excedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LimpiarDatos(e, e);
                }
                catch (ApplicationException aex)
                {
                    pbxCargando.Visible = false;
                    // Captura el error de configuración
                    MessageBox.Show($"Error de configuración: {aex.Message}\nEl programa terminará.", "Error Fatal", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.Close();
                    
                }
                catch (Exception)
                {
                    pbxCargando.Visible = false;
                    // Captura cualquier otro error inesperado
                    MessageBox.Show("Ocurrió un error inesperado al intentar iniciar sesión.", "Error Desconocido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimpiarDatos(e, e);
                }
                finally
                {
                    btnAcceder.Enabled = true; // Habilitar el botón
                }
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

        private void panDatosIngreso_MouseDown(object sender, MouseEventArgs e)
        {

            clsAnmaciones.MoverFormulario(this.Handle);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            clsAnmaciones.MoverFormulario(this.Handle);
        }

        private void panBarraControl_MouseDown(object sender, MouseEventArgs e)
        {
            clsAnmaciones.MoverFormulario(this.Handle);
        }

        private void panLogo_MouseDown(object sender, MouseEventArgs e)
        {
            clsAnmaciones.MoverFormulario(this.Handle);
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
            clsAnmaciones.PrivacidadIngresarDatos(txtContra, "");
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }

        private void lblMensajeError_Click(object sender, EventArgs e)
        {

        }
    }
}
