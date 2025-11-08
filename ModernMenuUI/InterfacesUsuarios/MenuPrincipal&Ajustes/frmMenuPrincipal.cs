using CapaServiciosSeguridadValidacion;
using CapaServiciosSeguridadValidacion.CapaServiciosSeguridadValidacion;
using Microsoft.VisualBasic;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.InterfacesUsuarios.Compras;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Globalization;


namespace ModernMenuUI
{
    public partial class frmMenuPrincipal : Form
    {
        public bool Animacion = true;
        AnimadorPanel animadorPanel;
        private Form formularioactivo = null;
        // 1. Declarar una instancia de tu servicio. Hazlo privado y de solo lectura.
        private readonly CapaServiciosSeguridadValidacion.CapaServiciosSeguridadValidacion.ServicioVerificacionConexion _monitorConexion;

        public frmMenuPrincipal()
        {
            InitializeComponent();
            animadorPanel = new AnimadorPanel(panelNotificaciones, 0, 350, 50);
            this.BackColor = Color.White;
            clsAnmaciones objnombre = new clsAnmaciones("MENU PRINCIPAL", lblNombreModulo);

            _monitorConexion = new ServicioVerificacionConexion();

            // 3. Suscribirse al evento que dispara el servicio
            _monitorConexion.EstadoDeRedCambiado += MonitorConexion_EstadoDeRedCambiado;

            // 4. Comprobar el estado inicial
            ActualizarEstadoVisual(_monitorConexion.HayConexionAhora());


        }

        private void MonitorConexion_EstadoDeRedCambiado(NetworkStatus status)
        {
            // Llamar a la función de actualización de la UI para manejar el Invoke
            ActualizarEstadoVisual(status);
        }

        // 6. Método Thread-Safe para actualizar la UI
        //    (Ahora maneja 3 estados)
        private void ActualizarEstadoVisual(NetworkStatus status)
        {
            // Usar Invoke para garantizar que la actualización ocurra en el hilo de la UI.
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    ActualizarEstadoVisual(status);
                });
                return;
            }

            // Actualización visual del Label con 3 estados
            switch (status)
            {
                case NetworkStatus.Internet:
                    lblEstadoConexion.Text = "✅ Conectado a la Red";
                    lblEstadoConexion.ForeColor = Color.White; // Tu color de "Conectado"
                    break;

                case NetworkStatus.RedSinInternet: // <-- EL NUEVO ESTADO
                    lblEstadoConexion.Text = "⚠️ Conectado Sin Internet";
                    lblEstadoConexion.ForeColor = Color.Yellow; // Naranja para advertencia
                    break;

                case NetworkStatus.SinRed:
                    lblEstadoConexion.Text = "🛑 Sin conexión";
                    lblEstadoConexion.ForeColor = Color.FromArgb(150, 42, 68); // Tu rojo
                    break;
            }
        }

        // PANELES
        // FUNCIONES DENTRO DE PANELES SUBMENUS

        // Mostrar Paneles
        private void AbrirPaneles(Panel panel)
        {
            if (panel.Visible == false)
            {
                panel.Visible = !panel.Visible;
            }
            else
            {
                panel.Visible = true;
            }
        }

        // Cerrar todos lo paneles
        private void panelvisible()
        {
            panelInventario.Visible = false;
            panelCompras.Visible = false;
            panelVentas.Visible = false;
            panelReporteria.Visible = false;
            panelUsuarios.Visible = false;

        }

        // Mostrar paneles cerrados al cargar por primera vez el form
        private void Form1_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = CapaServiciosSeguridadValidacion.ServicioSesionUsuario.ObtenerEmailUsuario();
            lblRol.Text = CapaServiciosSeguridadValidacion.ServicioSesionUsuario.ObtenerRolUsuario();
            ManejarFormularios.Inicializar(this.panelFormHijo); // PanelContenedor es tu panel principal
            panelvisible();
        }

        // Cerrar todos los submenu
        private void CerrarSubmenu()
        {
            Panel[] submenus = { panelInventario, panelCompras, panelVentas, panelReporteria, panelUsuarios };
            foreach (var p in submenus)
                p.Visible = false;
        }

        //Abrir y Cerrar Paneles
        private void AbrirCerrarPanel(Panel PanelActual)
        {
            if (PanelActual.Visible == true)
            {
                CerrarSubmenu();
            }
            else
            {
                CerrarSubmenu();
                AbrirPaneles(PanelActual);
                if (panelMenuLateral.Width == 100)
                {
                    MenulateralAnimacion();
                }
            }
        }

        private readonly int designFormWidth = 1920;   // ancho de referencia (Full HD)
        private readonly int designMenuOpen = 300;     // menú abierto en diseño
        private readonly int designMenuClosed = 100;   // menú cerrado en diseño

        private void MenulateralAnimacion()
        {
            panelFormHijo.Invalidate(false);
            panelFormHijo.Visible = false;

            // Calcula proporciones según el ancho actual del formulario
            double ratioOpen = (double)designMenuOpen / designFormWidth;
            double ratioClosed = (double)designMenuClosed / designFormWidth;

            int targetOpen = Math.Max(designMenuOpen, (int)Math.Round(this.Width * ratioOpen));
            int targetClosed = Math.Max(designMenuClosed, (int)Math.Round(this.Width * ratioClosed));

            // tolerancia para comparar (evita problemas de igualdad/redondeo)
            int tol = 8;

            // Si actualmente estamos cerca del estado abierto -> achicamos.
            // Si estamos ya cerca del cerrado -> lo abrimos.
            if (Math.Abs(panelMenuLateral.Width - targetOpen) <= tol)
            {
                // achicar (cerrar)
                panelMenuLateral.Width = targetClosed;
                CerrarSubmenu();
            }
            else
            {
                // abrir (si no estaba en abierto lo ponemos en abierto)
                panelMenuLateral.Width = targetOpen;
            }

            panelFormHijo.Update();
            panelFormHijo.Visible = true;
        }


        // Ocultar Men� Lateral
        private void btnAbrirMenu_Click(object sender, EventArgs e)
        {
            MenulateralAnimacion();
        }




        // Timers para Animar apneles en abrir y cerrar
        private void timerAbrir_Tick(object sender, EventArgs e)
        {
            if (panelMenuLateral.Width < 261)
            {
                btnCerrar.SuspendLayout();
                btnMiniMaxi.SuspendLayout();
                btnMinimizar.SuspendLayout();
                btnAbrirMenu.Enabled = false;
                panelMenuLateral.Width = panelMenuLateral.Width + 20;
            }
            else
            {
                timerAbrir.Stop();
                btnReporteria.Text = "            " + "Reporter�a";
                btnUsuario.Text = "            " + "Usuarios";
                btnVenta.Text = "            " + "Ventas";
                btnCompra.Text = "            " + "Compras";
                btnInventario.Text = "            " + "Inventario";
                btnAbrirMenu.Enabled = true;
                panelFormHijo.Visible = true;
                btnCerrar.ResumeLayout();
                btnMiniMaxi.ResumeLayout();
                btnMinimizar.ResumeLayout();

            }

        }
        private void timerCerrar_Tick(object sender, EventArgs e)
        {
            if (panelMenuLateral.Width > 101)
            {
                btnCerrar.SuspendLayout();
                btnMiniMaxi.SuspendLayout();
                btnMinimizar.SuspendLayout();
                btnReporteria.Text = null;
                btnUsuario.Text = null;
                btnVenta.Text = null;
                btnCompra.Text = null;
                btnInventario.Text = null;
                btnAbrirMenu.Enabled = false;
                panelMenuLateral.Width = panelMenuLateral.Width - 20;
            }
            else
            {
                timerCerrar.Stop();
                btnAbrirMenu.Enabled = true;
                panelFormHijo.Visible = true;
                btnCerrar.ResumeLayout();
                btnMiniMaxi.ResumeLayout();
                btnMinimizar.ResumeLayout();
            }
        }

        // BOTONES DE CONTROL DE VENTANA
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMiniMaxi_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnAjustes_Click(object sender, EventArgs e)
        {
            ManejarFormularios.Instancia.AbrirFormulario(new frmAjustes());
        }

        private void btnNotificaciones_Click(object sender, EventArgs e)
        {
            if (panelNotificaciones.Width == 0)
            {
                btnNotificaciones.Enabled = false;
                animadorPanel.Abrir();
                btnNotificaciones.Enabled = true;
            }
            else
            {
                btnNotificaciones.Enabled = false;
                animadorPanel.Cerrar();
                btnNotificaciones.Enabled = true;
            }
        }

        // BOTONES SUBMENUS
        private void btnGestionInventario_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            ManejarFormularios.Instancia.AbrirFormulario(new frmProductos());
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "INVENTARIO");

        }

        private void btnInventarioBodega_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            ManejarFormularios.Instancia.AbrirFormulario(new frmInventarioBodega());
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "INVENTARIO");

        }

        private void btnGestionCompra_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            ManejarFormularios.Instancia.AbrirFormulario(new frmGestionCompra());
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "COMPRAS");

        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            ManejarFormularios.Instancia.AbrirFormulario(new frmProveedores());
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "COMPRAS");
            

        }

        private void btnGestionVentas_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            ManejarFormularios.Instancia.AbrirFormulario(new frmFacturacion());
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "VENTAS");

        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            ManejarFormularios.Instancia.AbrirFormulario(new frmClientes());
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "VENTAS");

        }

        private void btnGestionEmpleados_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            ManejarFormularios.Instancia.AbrirFormulario(new frmEmpleado());
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "USUARIOS");

        }

        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            ManejarFormularios.Instancia.AbrirFormulario(new frmUsuario());
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "USUARIOS");

        }

        private void btnGestionRoles_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            ManejarFormularios.Instancia.AbrirFormulario(new frmRol());
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "USUARIOS");

        }

        private void btnAcciones_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "USUARIOS");

        }

        private void btnBitacora_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            ManejarFormularios.Instancia.AbrirFormulario(new frmBitacora());
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "USUARIOS");

        }

        private void btnCrearReporte_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "REPORTER�A");

        }

        private void btnReportesCreados_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "REPORTER�A");
        }

        private void btnRegistroPerdida_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "INVENTARIO");
        }

        private void btnCierreDiario_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "VENTAS");
        }


        private void btnDevoluciones_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "VENTAS");
        }

        // CONTENEDORES PARA MOVER FORMULARIO CON EVENTO
        private void lblNombreModulo_MouseDown(object sender, MouseEventArgs e)
        {
            clsAnmaciones.MoverFormulario(this.Handle);
        }

        private void panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            clsAnmaciones.MoverFormulario(this.Handle);
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            clsAnmaciones.MoverFormulario(this.Handle);
        }
        private void panBarraControl_MouseDown(object sender, MouseEventArgs e)
        {
            clsAnmaciones.MoverFormulario(this.Handle);
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            clsAnmaciones.MoverFormulario(this.Handle);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            clsAnmaciones.MoverFormulario(this.Handle);
        }

        private void panelMenuLateral_MouseDown(object sender, MouseEventArgs e)
        {
            clsAnmaciones.MoverFormulario(this.Handle);
        }

        // HORA FECHA
        private void HoraFecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss tt", new CultureInfo("es-ES"));
            lblFecha.Text = DateTime.Now.ToString("ddd dd 'de' MMMM 'del' yyyy", new CultureInfo("es-ES"));
        }

        private void pbxCalculadora_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("calc.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir la calculadora: " + ex.Message);
            }
        }

        private void pbxCalculadora_MouseDown(object sender, MouseEventArgs e)
        {
            pbxCalculadora.BackColor = Color.LightGreen; // resalta
        }

        private void pbxCalculadora_MouseUp(object sender, MouseEventArgs e)
        {
            pbxCalculadora.BackColor = Color.Transparent; // resalta
        }

        // BOTENES PARA ABRIR SUBMENUS

        private void btnCompras_Click(object sender, EventArgs e)
        {
            AbrirCerrarPanel(panelCompras);
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            AbrirCerrarPanel(panelVentas);
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirCerrarPanel(panelUsuarios);
        }

        private void btbStocks_Click(object sender, EventArgs e)
        {
            AbrirCerrarPanel(panelInventario);
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            AbrirCerrarPanel(panelReporteria);
        }
    }
}
