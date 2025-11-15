using CapaDeDatos.Modelados;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
using Supabase.Gotrue.Exceptions;
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
        private readonly UsuarioRepositorio _usuarioRepo;

        public frmIniciosesion()
        {
            InitializeComponent();
            _usuarioRepo = new UsuarioRepositorio();
           
        }


        public void LimpiarDatos(object sender, EventArgs e)
        {
            txtContrasenia.Text = "";
            txtUsuario.Text = "";
            txtContra_Leave(e, e);
            txtUsuario_Leave(e, e);
            txtContrasenia.Focus();
            txtUsuario.Focus();
        }
        private async void btnAcceder_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            btnAcceder.Enabled = false;
            lblRecuperarContrasenia.Enabled = false;

            if (txtContrasenia.Text == "" || txtUsuario.Text == "")
            {
                btnAcceder.Enabled = true;
                MessageBox.Show("El Usuario o contraseña estan vacios", "Credenciales Vacias", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LimpiarDatos(e, e);

            }
            else
            {
                string username = txtUsuario.Text + "@gmail.com";
                string password = txtContrasenia.Text;
                username = username.Trim();
                password = password.Trim();

                lblMensajeError.ForeColor = Color.DarkGray; 
                lblMensajeError.Visible = true;
                lblMensajeError.Text = "Procesando...";

                try
                {

                    pbxCargando.Visible = true; 

                    var supabase = await CapaDeDatos.Datos.Conexion.GetClientAsync();
                    var usuario = await supabase.Auth.SignIn(username, password);
                    var Actual = supabase.Auth.CurrentUser;

                    if (usuario != null)
                    {
                        lblMensajeError.ForeColor = Color.DarkGray; 
                        lblMensajeError.Text = "Conectando al servidor...";
                        lblMensajeError.Visible = true;

                        await Task.Delay(400);

                        lblMensajeError.Text = "Verificando credenciales...";
                        await Task.Delay(300);

                        lblMensajeError.Text = "Validando Permisos...";
                        await Task.Delay(500); 

                        lblMensajeError.ForeColor = Color.Green;
                        lblMensajeError.Text = "Inicio exitoso Bienvenido a El Cairo...";
                        await Task.Delay(100); 
                      
                        try
                        {
                            var uuidUsuario = Actual.Id;
                            var validacionRepo = new ValidacionRolRepositorio();
                            var contexto = await validacionRepo.ConstruirContexto(uuidUsuario);

                            ServicioSesionUsuario.IniciarSesion(Actual, contexto);

                            pbxCargando.Visible = false;

                            var acciones = contexto.AccionesPermitidas;
                            if (acciones == null || acciones.Count == 0)
                            {
                                MessageBox.Show("⚠️ El usuario no tiene acciones cargadas. El menú aparecerá vacío.");
                            }
                            else
                            { /*
                                MessageBox.Show("✅ Acciones cargadas: " + string.Join(", ", acciones.Select(a => a.NombreAccion)));
                                */
                            }
                        }
                        catch (Exception ex)
                        {
                            pbxCargando.Visible = false;  
                            MessageBox.Show($"Error crítico al cargar permisos: {ex.Message}. Cierre la aplicación.", "Error de Permisos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            LimpiarDatos(e, e);
                            return; 
                        }

                        Form formcarga = new frmInicioBodega();
                        this.Visible = false;
                        formcarga.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        pbxCargando.Visible = false;
                        lblMensajeError.Visible = true;
                        lblMensajeError.ForeColor = Color.Red;
                        lblMensajeError.Text = "Usuario o Contraseña incorrectos";

                        LimpiarDatos(e, e);
                    }
                }
                catch (GotrueException gex)
                {
                    pbxCargando.Visible = false;
                    lblMensajeError.Visible = true;
                    lblMensajeError.ForeColor = Color.Red;

                    if (gex.Message.Contains("Invalid login credentials"))
                    {
                        lblMensajeError.Text = "Usuario o Contraseña incorrectos";
                    }
                    else if (gex.Message.Contains("Email not confirmed"))
                    {
                        lblMensajeError.Text = "El email no ha sido confirmado.";
                    }
                    else
                    {
                        lblMensajeError.Text = "Error de autenticación.";
                        Console.WriteLine($"GotrueError: {gex.Message}");
                    }

                    LimpiarDatos(e, e);

                }
                catch (System.Net.WebException wex)
                {
                    pbxCargando.Visible = false;

                    MessageBox.Show($"Fallo de conexión: {wex.Message}\nAsegúrese de que el Wi-Fi o su conexión de red estén activos.",
                                    "Error de Conexión de Red", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimpiarDatos(e, e);
                    lblMensajeError.Visible = false;
                    lblMensajeError.Visible = false;
                }
                catch (TimeoutException tex)
                {
                    pbxCargando.Visible = false;
                    MessageBox.Show(tex.Message, "Tiempo de Espera del Servidor Excedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LimpiarDatos(e, e);
                    lblMensajeError.Visible = false;
                }
                catch (ApplicationException aex)
                {
                    pbxCargando.Visible = false;
                    MessageBox.Show($"Error de configuración: {aex.Message}\nEl programa terminará.", "Error en el Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.Close();
                    lblMensajeError.Visible = false;
                }
                catch (Exception ex)
                {
                    pbxCargando.Visible = false;

                    if (ex.Message.Contains("Unable to connect to the remote server", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("No se pudo conectar con el servidor. Verifica tu conexión a Internet o intenta más tarde.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error inesperado al intentar iniciar sesión." + ex.Message, "Error Desconocido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                    LimpiarDatos(e, e);
                    lblMensajeError.Visible = false;
                }
                finally
                {
                    lblRecuperarContrasenia.Enabled = true;    
                    btnAcceder.Enabled = true; 
                    this.Cursor = Cursors.Default;
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

        private void txtContra_Leave(object sender, EventArgs e)
        {
            if (txtContrasenia.Text == "")
            {
                txtContrasenia.Text = "CONTRASEÑA";
                txtContrasenia.ForeColor = Color.LightGray;
                txtContrasenia.UseSystemPasswordChar = false;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }
        private void txtContra_Enter(object sender, EventArgs e)
        {
            clsAnmaciones.PrivacidadIngresarDatos(txtContrasenia, "");
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
            lblRecuperarContrasenia.ForeColor = Color.Blue; 
            lblRecuperarContrasenia.Font = new Font(lblRecuperarContrasenia.Font, FontStyle.Underline);
        }

        private void lblRecuperarContrasenia_MouseLeave(object sender, EventArgs e)
        {

            lblRecuperarContrasenia.ForeColor = Color.DimGray;
            lblRecuperarContrasenia.Font = new Font(lblRecuperarContrasenia.Font, FontStyle.Regular);
        }

        private void lblRecuperarContrasenia_Click(object sender, EventArgs e)
        {
            frmRecuperacionContrasenia ContraNueva = new frmRecuperacionContrasenia();
            this.Visible = false;
            ContraNueva.ShowDialog();   
            this.Visible = true;
        }

        private void btnVer_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtContrasenia.Text != "CONTRASEÑA")
            {
                txtContrasenia.UseSystemPasswordChar = false; 
            }
        }

        private void btnVer_MouseUp(object sender, MouseEventArgs e)
        {
            if (txtContrasenia.Text != "CONTRASEÑA")
            {
                txtContrasenia.UseSystemPasswordChar = true;
            }
        }
    }
}
