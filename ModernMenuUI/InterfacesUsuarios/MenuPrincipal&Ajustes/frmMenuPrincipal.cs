using Microsoft.VisualBasic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Globalization;


namespace ModernMenuUI
{
    public partial class frmMenuPrincipal : Form
    {
        public bool Animacion = true;
        clsAnimadorPanel animadorPanel;
        private Form formularioactivo = null;

        public frmMenuPrincipal()
        {
            InitializeComponent();
            animadorPanel = new clsAnimadorPanel(panelNotificaciones, 0, 350, 50);
            this.BackColor = Color.White;
            clsAnmaciones objnombre = new clsAnmaciones("MENU PRINCIPAL", lblNombreModulo);
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
            clsManejarFormularios.Inicializar(this.panelFormHijo); // PanelContenedor es tu panel principal
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

        // Inicializar timers
        private void MenulateralAnimacion()
        {
            if (panelMenuLateral.Width == 100)
            {
                panelFormHijo.Invalidate(false);
                panelFormHijo.Visible = false;
                panelMenuLateral.Width = 260;
                panelFormHijo.Update();
                panelFormHijo.Visible = true;
            }
            else
            {
                panelFormHijo.Invalidate(false);
                panelFormHijo.Visible = false;
                panelMenuLateral.Width = 100;
                CerrarSubmenu();
                panelFormHijo.Update();
                panelFormHijo.Visible = true;

            }
        }

        // Ocultar Men� Lateral
        private void btnAbrirMenu_Click(object sender, EventArgs e)
        {
            MenulateralAnimacion();
        }

        // BOTENES PARA ABRIR SUBMENUS
        private void btnInventario_Click(object sender, EventArgs e)
        {
            AbrirCerrarPanel(panelInventario);
        }

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

        private void btnReporteria_Click(object sender, EventArgs e)
        {
            AbrirCerrarPanel(panelReporteria);
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
                btnUsuarios.Text = "            " + "Usuarios";
                btnVentas.Text = "            " + "Ventas";
                btnCompras.Text = "            " + "Compras";
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
                btnUsuarios.Text = null;
                btnVentas.Text = null;
                btnCompras.Text = null;
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
            clsManejarFormularios.Instancia.AbrirFormulario(new frmAjustes());
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
            clsManejarFormularios.Instancia.AbrirFormulario(new frmProductos());
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "INVENTARIO");
            
        }

        private void btnInventarioBodega_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            clsManejarFormularios.Instancia.AbrirFormulario(new frmInventarioBodega());
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "INVENTARIO");
          
        }

        private void btnGestionCompra_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            clsManejarFormularios.Instancia.AbrirFormulario(new frmGestionCompra());
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "COMPRAS");
           
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "COMPRAS");
           
        }

        private void btnGestionVentas_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            clsManejarFormularios.Instancia.AbrirFormulario(new frmFacturacion());
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "VENTAS");
            
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            clsManejarFormularios.Instancia.AbrirFormulario(new frmClientes());
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "VENTAS");
            
        }

        private void btnGestionEmpleados_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            clsManejarFormularios.Instancia.AbrirFormulario(new frmEmpleados());
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "USUARIOS");
           
        }

        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            clsManejarFormularios.Instancia.AbrirFormulario(new frmGestionUsuario());
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "USUARIOS");
            
        }

        private void btnGestionRoles_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            clsManejarFormularios.Instancia.AbrirFormulario(new frmRoles());
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
            clsManejarFormularios.Instancia.AbrirFormulario(new frmBitacora());
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
            lblFecha.Text = DateTime.Now.ToString("dddd dd 'de' MMMM 'del' yyyy", new CultureInfo("es-ES"));
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

        private void btnCierreDiario_Click(object sender, EventArgs e)
        {

        }
    }
}
