using CapaDeDatos.Modelados;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.ServiciosUI;
using Supabase.Gotrue.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ModernMenuUI
{
    public partial class frmIniciosesion : Form
    {
        private readonly UsuarioRepositorio _usuarioRepo;
        private readonly ServicioBiometrico _biometrico;

        public frmIniciosesion()
        {
            InitializeComponent();
            _usuarioRepo = new UsuarioRepositorio();
            _biometrico = new ServicioBiometrico();
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
            System.Diagnostics.Stopwatch swTotal = new System.Diagnostics.Stopwatch();
            System.Diagnostics.Stopwatch swPaso = new System.Diagnostics.Stopwatch();
            swTotal.Start();

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

                    // PASO A: Autenticación
                    swPaso.Start();
                    var supabase = await CapaDeDatos.Datos.Conexion.GetClientAsync();
                    var usuario = await supabase.Auth.SignIn(username, password);
                    var Actual = supabase.Auth.CurrentUser;
                    swPaso.Stop();
                    long tiempoAuth = swPaso.ElapsedMilliseconds;
                    swPaso.Reset();

                    if (usuario != null)
                    {
                        AnimacionInicio();

                        try
                        {
                            // PASO B: Carga de permisos
                            swPaso.Start();
                            var uuidUsuario = Actual.Id;
                            var validacionRepo = new ValidacionRolRepositorio();
                            var contexto = await validacionRepo.ConstruirContexto(uuidUsuario);
                            ServicioSesionUsuario.IniciarSesion(Actual, contexto);
                            swPaso.Stop();
                            long tiempoPermisos = swPaso.ElapsedMilliseconds;

                            // REPORTE DE MÉTRICAS
                            swTotal.Stop();
                            string resumen =
                                $"--- MÉTRICAS DE RENDIMIENTO ---\n" +
                                $"Autenticación Supabase: {tiempoAuth} ms\n" +
                                $"Carga de Permisos: {tiempoPermisos} ms\n" +
                                $"Tiempo Total Login: {swTotal.ElapsedMilliseconds} ms\n" +
                                $"-------------------------------";
                            MessageBox.Show(resumen, "Evaluación del Sistema",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                            try
                            {
                                if (supabase.Auth.CurrentSession != null && await _biometrico.EsPosibleUsarHuella())
                                {
                                    var result = MessageBox.Show(
                                        "¿Desea habilitar el inicio de sesión con huella en este equipo?",
                                        "Configuración Biométrica",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question);

                                    if (result == DialogResult.Yes)
                                    {
                                        _biometrico.GuardarTokenSeguro(Actual.Email, supabase.Auth.CurrentSession.RefreshToken);
                                        Properties.Settings.Default.UltimoUsuario = Actual.Email;
                                        Properties.Settings.Default.Save();
                                        MessageBox.Show("¡Huella vinculada con éxito!", "Proyecto El Cairo");
                                    }
                                }
                            }
                            catch { }

                            pbxCargando.Visible = false;

                            var acciones = contexto.AccionesPermitidas;
                            if (acciones == null || acciones.Count == 0)
                            {
                                MessageBox.Show("⚠️ El usuario no tiene acciones cargadas. El menú aparecerá vacío.");
                            }
                        }
                        catch (Exception ex)
                        {
                            pbxCargando.Visible = false;
                            throw;
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
                    swTotal.Stop();
                    pbxCargando.Visible = false;
                    lblMensajeError.Visible = true;
                    lblMensajeError.ForeColor = Color.Red;

                    if (gex.Message.Contains("Invalid login credentials"))
                        lblMensajeError.Text = "Usuario o Contraseña incorrectos";
                    else if (gex.Message.Contains("Email not confirmed"))
                        lblMensajeError.Text = "El email no ha sido confirmado.";
                    else
                    {
                        lblMensajeError.Text = "Error de autenticación.";
                        Console.WriteLine($"GotrueError: {gex.Message}");
                    }
                    LimpiarDatos(e, e);
                }
                catch (System.Net.WebException wex)
                {
                    swTotal.Stop();
                    pbxCargando.Visible = false;
                    MessageBox.Show($"Fallo de conexión: {wex.Message}\nAsegúrese de que el Wi-Fi o su conexión de red estén activos.",
                                    "Error de Conexión de Red", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimpiarDatos(e, e);
                    lblMensajeError.Visible = false;
                }
                catch (TimeoutException tex)
                {
                    swTotal.Stop();
                    pbxCargando.Visible = false;
                    MessageBox.Show(tex.Message, "Tiempo de Espera del Servidor Excedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LimpiarDatos(e, e);
                    lblMensajeError.Visible = false;
                }
                catch (ApplicationException aex)
                {
                    swTotal.Stop();
                    pbxCargando.Visible = false;
                    MessageBox.Show($"Error de configuración: {aex.Message}\nEl programa terminará.", "Error en el Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.Close();
                    lblMensajeError.Visible = false;
                }
                catch (Exception ex)
                {
                    swTotal.Stop();
                    pbxCargando.Visible = false;
                    if (ex.Message.Contains("Unable to connect to the remote server", StringComparison.OrdinalIgnoreCase))
                        MessageBox.Show("No se pudo conectar con el servidor. Verifica tu conexión a Internet o intenta más tarde.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Ocurrió un error inesperado al intentar iniciar sesión." + ex.Message, "Error Desconocido", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            this.Hide();

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

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
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

        private async void btnBiometrico_Click(object sender, EventArgs e)
        {


            // 1. Validaciones iniciales
            string ultimoEmail = Properties.Settings.Default.UltimoUsuario;
            if (string.IsNullOrEmpty(ultimoEmail))
            {
                MessageBox.Show("Inicia sesión con contraseña primero.", "Aviso");
                this.Cursor = Cursors.Default;
                return;
            }

            if (!await _biometrico.EsPosibleUsarHuella())
            {
                MessageBox.Show("No hay sensor de huella.", "Error");
                this.Cursor = Cursors.Default;
                return;
            }

            // 2. Huella y Login
            if (await _biometrico.VerificarIdentidad($"Hola {ultimoEmail}, confirma."))
            {
                btnAcceder.Enabled = false;
                btnBiometrico.Enabled = false;
                btnBiometrico.Enabled = false;
                try
                {
                    AnimacionInicio();
                    string token = _biometrico.ObtenerTokenGuardado(ultimoEmail);
                    if (string.IsNullOrEmpty(token)) throw new Exception("Sin credencial.");

                    var usuarioSupabase = await _usuarioRepo.IniciarSesionConToken(token);

                    var validacionRepo = new ValidacionRolRepositorio();
                    var contexto = await validacionRepo.ConstruirContexto(usuarioSupabase.Id);
                    ServicioSesionUsuario.IniciarSesion(usuarioSupabase, contexto);

                    var cliente = await CapaDeDatos.Datos.Conexion.GetClientAsync();
                    if (cliente.Auth.CurrentSession != null)
                    {
                        _biometrico.GuardarTokenSeguro(ultimoEmail, cliente.Auth.CurrentSession.RefreshToken);
                    }

                    this.Visible = false;
                    new frmInicioBodega().ShowDialog();
                    btnBiometrico.Enabled = true;
                    this.Close();

                }
                catch (Exception ex)
                {
                    lblMensajeError.ForeColor = Color.Red;
                    lblMensajeError.Text = ex.Message;
                    MessageBox.Show(ex.Message);
                    _biometrico.BorrarToken(ultimoEmail);
                    btnBiometrico.Enabled = true;
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                    pbxCargando.Visible = false;
                    btnAcceder.Enabled = true;
                    btnBiometrico.Enabled = true;

               
                }
            }
        }

        private async void AnimacionInicio()
        {
            pbxCargando.Visible = true;
            lblMensajeError.ForeColor = Color.DarkGray;
            lblMensajeError.Text = "Conectando al servidor...";
            lblMensajeError.Visible = true;

            await Task.Delay(300);

            lblMensajeError.Text = "Verificando credenciales...";
            await Task.Delay(300);

            lblMensajeError.Text = "Validando Permisos...";
            await Task.Delay(300);

            lblMensajeError.ForeColor = Color.Green;
            lblMensajeError.Text = "Inicio exitoso Bienvenido a El Cairo...";
            await Task.Delay(100);
        }

        private void frmIniciosesion_Load(object sender, EventArgs e)
        {
            var sw = Stopwatch.StartNew();
 
        }
    }
}
