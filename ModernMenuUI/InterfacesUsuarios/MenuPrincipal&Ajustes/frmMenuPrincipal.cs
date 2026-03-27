using CapaDeDatos.Modelados.Reporteria.Reporteria;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using Microsoft.VisualBasic;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.InterfacesUsuarios.Compras;
using ModernMenuUI.InterfacesUsuarios.Inventario;
using ModernMenuUI.InterfacesUsuarios.Reporteria;
using ModernMenuUI.InterfacesUsuarios.Ventas;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Globalization;


namespace ModernMenuUI
{
    /// <summary>
    /// Formulario principal de la aplicación. Maneja el menú lateral, notificaciones y la apertura de formularios hijos.
    /// </summary>
    public partial class frmMenuPrincipal : Form
    {
        /// <summary>Indica si las animaciones están habilitadas.</summary>
        public bool Animacion = true;

        private AnimadorPanel animadorPanel;
        private Form formularioactivo = null;
        private readonly ServicioVerificacionConexion _monitorConexion;
        private readonly ServiciosUI.ServicioPermisosUI _servicioPermisos = new ServiciosUI.ServicioPermisosUI();

        private int _anchoMenuAbierto;
        private int _anchoMenuCerrado;
        private AnimadorPanel _animadorNotificaciones;

        private const int TOLERANCIA = 5;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="frmMenuPrincipal"/>.
        /// </summary>
        public frmMenuPrincipal()
        {
            InitializeComponent();
            ConfigurarMenu();
            ConfigurarNotificaciones();
            animadorPanel = new AnimadorPanel(panelNotificaciones, 0, 350, 50);
            this.BackColor = Color.White;
            clsAnmaciones objnombre = new clsAnmaciones("MENU PRINCIPAL", lblNombreModulo);
            _monitorConexion = new ServicioVerificacionConexion();
            _monitorConexion.EstadoDeRedCambiado += MonitorConexion_EstadoDeRedCambiado;
            ActualizarEstadoVisual(_monitorConexion.HayConexionAhora());
            RegistrarBotonesConPermisos();
            _servicioPermisos.AplicarPermisos();
        }

        /// <summary>
        /// Evento Load: ajusta visibilidad inicial de divisores y registra panel contenedor para formularios hijos.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            if (btnInventarios.Visible == false)
            {
                pnlDivisorInventario.Visible = false;
            }

            if (btnVentas.Visible == false)
            {
                pnlDivisorVentas.Visible = false;
            }

            if (btnCompras.Visible == false)
            {
                pnlDivisorCompras.Visible = false;
            }

            if (btnUsuarios.Visible == false)
            {
                pnlDivisorUsuario.Visible = false;
            }

            if (btnReporte.Visible == false)
            {
                pnlDivisorReporteria.Visible = false;
            }
            lblUsuario.Text = CapaServiciosSeguridadValidacion.ServicioSesionUsuario.ObtenerEmailUsuario();
            lblRol.Text = CapaServiciosSeguridadValidacion.ServicioSesionUsuario.ObtenerRolUsuario();
            ManejarFormularios.Inicializar(this.panelFormHijo);
            panelvisible();
            lblBodega.Text = ServicioSesionUsuario.ObtenerNombreBodega();
        }

        /// <summary>
        /// Configura el controlador/animador de notificaciones en modo overlay.
        /// </summary>
        private void ConfigurarNotificaciones()
        {
            int anchoMaximoNotif = CalculadoraResolucion.ObtenerAnchoNotificaciones();
            _animadorNotificaciones = new AnimadorPanel(panelNotificaciones, 0, anchoMaximoNotif, 50, true);
        }

        /// <summary>
        /// Calcula y aplica dimensiones del menú lateral según resolución.
        /// </summary>
        private void ConfigurarMenu()
        {
            var dimensiones = CalculadoraResolucion.ObtenerDimensionesOptimas();

            _anchoMenuAbierto = dimensiones.AnchoAbierto;
            _anchoMenuCerrado = dimensiones.AnchoCerrado;

            panelMenuLateral.Width = _anchoMenuAbierto;
            Console.WriteLine($"Resolución detectada. Menu Abierto: {_anchoMenuAbierto}, Cerrado: {_anchoMenuCerrado}");
        }

        /// <summary>
        /// Handler del servicio de verificación de conexión; actualiza la UI.
        /// </summary>
        private void MonitorConexion_EstadoDeRedCambiado(NetworkStatus status)
        {
            ActualizarEstadoVisual(status);
        }

        /// <summary>
        /// Actualiza de forma segura (hilo UI) la etiqueta que muestra el estado de red.
        /// </summary>
        private void ActualizarEstadoVisual(NetworkStatus status)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    ActualizarEstadoVisual(status);
                });
                return;
            }

            switch (status)
            {
                case NetworkStatus.Internet:
                    lblEstadoConexion.Text = "✅ Conectado a la Red";
                    lblEstadoConexion.ForeColor = Color.White;
                    break;

                case NetworkStatus.RedSinInternet:
                    lblEstadoConexion.Text = "⚠️ Conectado Sin Internet";
                    lblEstadoConexion.ForeColor = Color.Yellow;
                    break;

                case NetworkStatus.SinRed:
                    lblEstadoConexion.Text = "🛑 Sin conexión";
                    lblEstadoConexion.ForeColor = Color.FromArgb(150, 42, 68);
                    break;
            }
        }

        /// <summary>
        /// Establece la visibilidad de un panel secundario.
        /// </summary>
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

        /// <summary>
        /// Oculta todos los paneles de submenú.
        /// </summary>
        private void panelvisible()
        {
            panelInventario.Visible = false;
            panelCompras.Visible = false;
            panelVentas.Visible = false;
            panelReporteria.Visible = false;
            panelUsuarios.Visible = false;
        }

        /// <summary>
        /// Cierra todos los submenús.
        /// </summary>
        private void CerrarSubmenu()
        {
            Panel[] submenus = { panelInventario, panelCompras, panelVentas, panelReporteria, panelUsuarios };
            foreach (var p in submenus)
                p.Visible = false;
        }

        /// <summary>
        /// Abre o cierra un subpanel concreto y anima el menú lateral si procede.
        /// </summary>
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

                if (Math.Abs(panelMenuLateral.Width - _anchoMenuCerrado) <= TOLERANCIA)
                {
                    MenulateralAnimacion();
                }
            }
        }

        /// <summary>
        /// Ejecuta la animación del menú lateral.
        /// </summary>
        private void MenulateralAnimacion()
        {
            AlternarMenu();
        }

        /// <summary>
        /// Alterna el ancho del menú lateral entre abierto y cerrado.
        /// </summary>
        private void AlternarMenu()
        {
            lblEstadoConexion.Visible = false;
            btnNotificaciones.Visible = false;
            panelFormHijo.Visible = false;
            panelFormHijo.SuspendLayout();

            bool estaAbierto = Math.Abs(panelMenuLateral.Width - _anchoMenuAbierto) <= TOLERANCIA;

            if (estaAbierto)
            {
                CerrarSubmenu();
                panelMenuLateral.Width = _anchoMenuCerrado;
            }
            else
            {
                panelMenuLateral.Width = _anchoMenuAbierto;
            }

            panelFormHijo.ResumeLayout();
            panelFormHijo.Visible = true;
            btnNotificaciones.Visible = true;
            lblEstadoConexion.Visible = true;
        }

        /// <summary>
        /// Handler del botón que abre/cierra el menú lateral.
        /// </summary>
        private void btnAbrirMenu_Click(object sender, EventArgs e)
        {
            MenulateralAnimacion();
        }

        /// <summary>
        /// Tick del timer de apertura del menú lateral.
        /// </summary>
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

        /// <summary>
        /// Tick del timer de cierre del menú lateral.
        /// </summary>
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

        /// <summary>
        /// Cierra la ventana principal.
        /// </summary>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Alterna entre maximizar y restaurar la ventana.
        /// </summary>
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

        /// <summary>
        /// Minimiza la ventana.
        /// </summary>
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Abre el formulario de ajustes.
        /// </summary>
        private void btnAjustes_Click(object sender, EventArgs e)
        {
            ManejarFormularios.Instancia.AbrirFormulario(new frmAjustes());
        }

        /// <summary>
        /// Alterna la pantalla de notificaciones mediante el animador.
        /// </summary>
        private void btnNotificaciones_Click(object sender, EventArgs e)
        {
            try
            {
                var parent = panelNotificaciones.Parent;
                bool estaCerrado;

                if (parent == null)
                {
                    estaCerrado = !panelNotificaciones.Visible;
                }
                else
                {
                    estaCerrado = !panelNotificaciones.Visible || panelNotificaciones.Left >= parent.ClientSize.Width - 1;
                }

                if (estaCerrado)
                {
                    btnNotificaciones.Enabled = false;
                    _animadorNotificaciones?.Abrir();
                    btnNotificaciones.Enabled = true;
                }
                else
                {
                    _animadorNotificaciones?.Cerrar();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"btnNotificaciones_Click error: {ex.Message}");
            }
        }

        /// <summary>
        /// Abre el formulario de gestión de inventario.
        /// </summary>
        private void btnGestionInventario_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            ManejarFormularios.Instancia.AbrirFormulario(new frmProductos());
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "INVENTARIO");
        }

        /// <summary>
        /// Abre el formulario de inventario por bodega.
        /// </summary>
        private void btnInventarioBodega_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            ManejarFormularios.Instancia.AbrirFormulario(new frmInventarioBodega());
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "INVENTARIO BODEGAS");
        }

        /// <summary>
        /// Abre el formulario de categorías.
        /// </summary>
        private void btnCategorias_Click(object sender, EventArgs e)
        {
            bool tipo = true;
            CerrarSubmenu();
            ManejarFormularios.Instancia.AbrirFormulario(new frmCategorias(tipo));
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "CATEGORIAS");
        }

        /// <summary>
        /// Abre el formulario de gestión de compras.
        /// </summary>
        private void btnGestionCompra_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            ManejarFormularios.Instancia.AbrirFormulario(new frmGestionCompra());
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "COMPRAS");
        }

        /// <summary>
        /// Abre el formulario de proveedores (modo compras).
        /// </summary>
        private void btnProveedores_Click(object sender, EventArgs e)
        {
            bool tipo = true;
            CerrarSubmenu();
            ManejarFormularios.Instancia.AbrirFormulario(new InterfacesUsuarios.Compras.frmProveedor(tipo));
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "PROVEEDORES");
        }

        /// <summary>
        /// Abre el formulario de presentaciones.
        /// </summary>
        private void btnPresentaciones_Click(object sender, EventArgs e)
        {
            bool tipo = true;
            CerrarSubmenu();
            ManejarFormularios.Instancia.AbrirFormulario(new frmPresentaciones(tipo));
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "PRESENTACION");
        }

        /// <summary>
        /// Abre el formulario de facturación.
        /// </summary>
        private void btnGestionVentas_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            ManejarFormularios.Instancia.AbrirFormulario(new frmFacturacion());
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "VENTAS");
        }

        /// <summary>
        /// Abre el formulario de clientes.
        /// </summary>
        private void btnClientes_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            ManejarFormularios.Instancia.AbrirFormulario(new frmClientes());
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "CLIENTES");
        }

        /// <summary>
        /// Abre el formulario de gestión de empleados.
        /// </summary>
        private void btnGestionEmpleados_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            ManejarFormularios.Instancia.AbrirFormulario(new frmEmpleado());
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "EMPLEADOS");
        }

        /// <summary>
        /// Abre el formulario de usuarios.
        /// </summary>
        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            ManejarFormularios.Instancia.AbrirFormulario(new frmUsuario());
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "USUARIOS");
        }

        /// <summary>
        /// Abre el formulario de roles.
        /// </summary>
        private void btnGestionRoles_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            ManejarFormularios.Instancia.AbrirFormulario(new frmRol());
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "ROLES");
        }

        /// <summary>
        /// Abre el formulario de bitácora.
        /// </summary>
        private void btnBitacora_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            ManejarFormularios.Instancia.AbrirFormulario(new frmBitacora());
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "BITACORA");
        }

        /// <summary>
        /// Abre el formulario para crear reportes.
        /// </summary>
        private void btnCrearReporte_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            ManejarFormularios.Instancia.AbrirFormulario(new frmCrearReporte());
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "REPORTERIA");
        }

        /// <summary>
        /// Muestra la lista de reportes creados.
        /// </summary>
        private void btnReportesCreados_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "REPORTERIA");
        }

        /// <summary>
        /// Abre el formulario de registro de pérdidas.
        /// </summary>
        private void btnRegistroPerdida_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            ManejarFormularios.Instancia.AbrirFormulario(new frmPruebaInventario());
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "PERDIDAS");
        }

        /// <summary>
        /// Abre el formulario de cierre diario.
        /// </summary>
        private void btnCierreDiario_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            ManejarFormularios.Instancia.AbrirFormulario(new frmCierreDiario());
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "CIERRE DIARIO");
        }

        /// <summary>
        /// Acción para devoluciones.
        /// </summary>
        private void btnDevoluciones_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "DEVOLUCIONES");
        }

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

        /// <summary>
        /// Actualiza hora y fecha mostradas en la UI.
        /// </summary>
        private void HoraFecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss tt", new CultureInfo("es-ES"));
            lblFecha.Text = DateTime.Now.ToString("dddd dd 'de' MMMM 'del' yyyy", new CultureInfo("es-ES"));
        }

        private void pbxCalculadora_Click(object sender, EventArgs e)
        {

        }

        private void pbxCalculadora_MouseDown(object sender, MouseEventArgs e)
        {
            pbxCalculadora.BackColor = Color.LightGreen;
        }

        private void pbxCalculadora_MouseUp(object sender, MouseEventArgs e)
        {
            pbxCalculadora.BackColor = Color.Transparent;
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

        private void btbStocks_Click(object sender, EventArgs e)
        {
            AbrirCerrarPanel(panelInventario);
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            AbrirCerrarPanel(panelReporteria);
        }

        /// <summary>
        /// Registra botones y acciones en el servicio de permisos.
        /// </summary>
        private void RegistrarBotonesConPermisos()
        {
            _servicioPermisos.RegistrarBoton(btnInventarios, "select_inventario", "update_inventario", "create_inventario");
            _servicioPermisos.RegistrarBoton(btnInventarioBodega, "select_inventario", "update_inventario", "create_inventario");
            _servicioPermisos.RegistrarBoton(btnGestionInventario, "select_inventario", "update_inventario", "create_inventario");
            //_servicioPermisos.RegistrarBoton(btnRegistroPerdida, "select_inventario", "update_inventario", "create_inventario");
            _servicioPermisos.RegistrarBoton(btnMarcas, "select_inventario", "update_inventario", "create_inventario");
            _servicioPermisos.RegistrarBoton(btnCategorias, "select_inventario", "update_inventario", "create_inventario");
            _servicioPermisos.RegistrarBoton(btnPresentaciones, "select_inventario", "update_inventario", "create_inventario");

            _servicioPermisos.RegistrarBoton(btnCompras, "select_compra", "update_compra", "create_compra");
            _servicioPermisos.RegistrarBoton(btnGestionCompra, "select_compra", "update_compra", "create_compra");
            _servicioPermisos.RegistrarBoton(btnProveedores, "select_compra", "update_compra", "create_compra");

            _servicioPermisos.RegistrarBoton(btnVentas, "select_venta", "update_venta", "create_venta");
            _servicioPermisos.RegistrarBoton(btnGestionVentas, "select_venta", "update_venta", "create_venta");
            _servicioPermisos.RegistrarBoton(btnClientes, "select_venta", "update_venta", "create_venta");

            _servicioPermisos.RegistrarBoton(btnUsuarios, "select_usuario", "update_usuario", "create_usuario");
            _servicioPermisos.RegistrarBoton(btnGestionUsuarios, "select_usuario", "update_usuario", "create_usuario");
            //_servicioPermisos.RegistrarBoton(btnGestionRoles, "select_usuario", "update_usuario", "create_usuario");
            _servicioPermisos.RegistrarBoton(btnBitacora, "select_usuario", "update_usuario", "create_usuario");

            _servicioPermisos.RegistrarBoton(btnReporte, "select_reporte", "update_reporte", "create_reporte");
            _servicioPermisos.RegistrarBoton(btnCrearReporte, "select_reporte", "update_reporte", "create_reporte");
            //_servicioPermisos.RegistrarBoton(btnReportesCreados, "select_reporte", "update_reporte", "create_reporte");
        }

        private void btnMarcas_Click(object sender, EventArgs e)
        {
            bool tipo = true;
            CerrarSubmenu();
            ManejarFormularios.Instancia.AbrirFormulario(new frmMarcas(tipo));
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "INVENTARIO");
        }

        private void btnBodegas_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            ManejarFormularios.Instancia.AbrirFormulario(new frmInventarioBodega(modoSoloLectura: true));
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "BODEGAS");
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panelFormHijo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            string listaForms = "";

            foreach (Form frm in Application.OpenForms)
            {
                listaForms += frm.Name + " | " + frm.GetType().Name + Environment.NewLine;
            }

            long memoriaMB = GC.GetTotalMemory(false) / (1024 * 1024);

            MessageBox.Show(
                "Forms abiertos: " + Application.OpenForms.Count +
                "\nMemoria .NET: " + memoriaMB + " MB\n\n" +
                listaForms
            );
        }

        private void pbxCalculadora_Click_1(object sender, EventArgs e)
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
    }
}
