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
                LimpiarDatos(e, e);
            }
            else
            {
                // Validadcion inicial para acceder al servidor y comprobar Inicio de sesión
                string username = txtUsuario.Text;
                string password = txtContra.Text;
                username = username.Trim();
                password = password.Trim();

                lblMensajeError.ForeColor = Color.DarkGray; // Color neutro para carga
                lblMensajeError.Visible = true;
                lblMensajeError.Text = "Procesando...";

                try
                {
                    pbxCargando.Visible = true; // Picture box con imagen en formato gift para carga

                    Usuario_ usuario = await clsConexion.Iniciar_Sesion(username, password); // Conexion con el Usuarios

                    if (usuario != null)
                    {
                        // Muestra el label y prepara el primer mensaje
                        lblMensajeError.ForeColor = Color.DarkGray; // Color neutro para carga
                        lblMensajeError.Text = "Conectando al servidor...";
                        lblMensajeError.Visible = true;

                        // Pausa 1: Espera 1 s
                        await Task.Delay(400);

                        // Pausa 2: Muestra el segundo mensaje 1s
                        lblMensajeError.Text = "Verificando credenciales...";
                        await Task.Delay(300);

                        // Pausa 3: Muestra el tercer mensaje (opcional, simula la espera real) 1s
                        lblMensajeError.Text = "Validando Permisos...";
                        await Task.Delay(500); // 1s segundo

                        // Pausa 4: Mensaje de incio de sesión
                        lblMensajeError.ForeColor = Color.Green;
                        lblMensajeError.Text = "Inicio exitoso Bienvenido a El Cairo...";
                        await Task.Delay(500); // 1s Final de espera
                        pbxCargando.Visible = false;

                        // Se abre el nuevo form e inicia la aplicación 
                        Form formcarga = new frmInicioBodega();
                        this.Visible = false;
                        formcarga.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        // FALLO DE CREDENCIALES: El servidor respondió, pero el usuario/contraseña no coincide.
                        pbxCargando.Visible = false;
                        lblMensajeError.Visible = true;
                        lblMensajeError.ForeColor = Color.Red; // Color neutro para carga
                        lblMensajeError.Text = "Usuario o Contraseña incorrectos";

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
                    // Lógica de limpieza y re-enfoque
                    LimpiarDatos(e, e);
                }
                catch (ApplicationException aex)
                {
                    pbxCargando.Visible = false;
                    // Captura el error de configuración
                    MessageBox.Show($"Error de configuración: {aex.Message}\nEl programa terminará.", "Error en el Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.Close();
                }
                catch (Exception)
                {
                    pbxCargando.Visible = false;
                    // Captura cualquier otro error inesperado
                    MessageBox.Show("Ocurrió un error inesperado al intentar iniciar sesión.", "Error Desconocido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Lógica de limpieza y re-enfoque
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
            this.Close(); // Cerrar el fromulario
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; // Minimizar formulario

        }

        private void panDatosIngreso_MouseDown(object sender, MouseEventArgs e)
        {

            clsAnmaciones.MoverFormulario(this.Handle); // Fución para mover formulario en propiedad none
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            clsAnmaciones.MoverFormulario(this.Handle); // Fución para mover formulario en propiedad none
        }

        private void panBarraControl_MouseDown(object sender, MouseEventArgs e)
        {
            clsAnmaciones.MoverFormulario(this.Handle); // Fución para mover formulario en propiedad none
        }

        private void panLogo_MouseDown(object sender, MouseEventArgs e)
        {
            clsAnmaciones.MoverFormulario(this.Handle); // Fución para mover formulario en propiedad none
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

        private void lblRecuperarContrasenia_MouseEnter(object sender, EventArgs e)
        {
            lblRecuperarContrasenia.ForeColor = Color.Blue; // Cambia color al pasar el mouse
            lblRecuperarContrasenia.Font = new Font(lblRecuperarContrasenia.Font, FontStyle.Underline);
        }

        private void lblRecuperarContrasenia_MouseLeave(object sender, EventArgs e)
        {

            lblRecuperarContrasenia.ForeColor = Color.DimGray;

            // Vuelve al color normal
            lblRecuperarContrasenia.Font = new Font(lblRecuperarContrasenia.Font, FontStyle.Regular); // Quita subrayado
        }

        private void lblRecuperarContrasenia_Click(object sender, EventArgs e)
        {

        }
    }
}
