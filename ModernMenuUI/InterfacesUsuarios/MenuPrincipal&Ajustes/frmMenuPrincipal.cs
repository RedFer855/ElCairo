using CapaDeDatos.Modelados.Reporteria.Reporteria;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using Microsoft.VisualBasic;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.InterfacesUsuarios.Compras;
using ModernMenuUI.InterfacesUsuarios.Inventario;
using ModernMenuUI.InterfacesUsuarios.Reporteria;
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
        private readonly ServicioVerificacionConexion _monitorConexion;
        private readonly ServiciosUI.ServicioPermisosUI _servicioPermisos = new ServiciosUI.ServicioPermisosUI();
        
        // Variables para almacenar los tamaños calculados una sola vez
        private int _anchoMenuAbierto;
        private int _anchoMenuCerrado;
        private AnimadorPanel _animadorNotificaciones; // Instancia para notificaciones

        // Tolerancia para la comparación
        private const int TOLERANCIA = 5;


        public frmMenuPrincipal()
        {
            InitializeComponent();
            ConfigurarMenu();
            ConfigurarNotificaciones();
            animadorPanel = new AnimadorPanel(panelNotificaciones, 0, 350, 50);
            this.BackColor = Color.White;
            clsAnmaciones objnombre = new clsAnmaciones("MENU PRINCIPAL", lblNombreModulo);
            _monitorConexion = new ServicioVerificacionConexion();
            // 3. Suscribirse al evento que dispara el servicio
            _monitorConexion.EstadoDeRedCambiado += MonitorConexion_EstadoDeRedCambiado;
            // 4. Comprobar el estado inicial
            ActualizarEstadoVisual(_monitorConexion.HayConexionAhora());
            RegistrarBotonesConPermisos();
            _servicioPermisos.AplicarPermisos();
        }


        // Mostrar paneles cerrados al cargar por primera vez el form
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
            ManejarFormularios.Inicializar(this.panelFormHijo); // PanelContenedor es tu panel principal
            panelvisible();

            // Ahora puedes mostrar en un label
            lblBodega.Text = ServicioSesionUsuario.ObtenerNombreBodega();
        }
        private void ConfigurarNotificaciones()
        {
            int anchoMaximoNotif = CalculadoraResolucion.ObtenerAnchoNotificaciones();
            // overlay = true evita que cambien los tamaños (Dock) y por tanto el re-layout del panelFormHijo
            _animadorNotificaciones = new AnimadorPanel(panelNotificaciones, 0, anchoMaximoNotif, 50, true);
            // ya no forzamos panelNotificaciones.Width = 0 aquí
        }

        private void ConfigurarMenu()
        {
            // 1. LLAMADA A LA CLASE: Obtenemos los tamaños según el monitor actual
            var dimensiones = CalculadoraResolucion.ObtenerDimensionesOptimas();

            _anchoMenuAbierto = dimensiones.AnchoAbierto;
            _anchoMenuCerrado = dimensiones.AnchoCerrado;

            // 2. Estado inicial: Empezamos abiertos (según tu indicación)
            panelMenuLateral.Width = _anchoMenuAbierto;

            // Debug: Para que veas en consola cuánto calculó
            Console.WriteLine($"Resolución detectada. Menu Abierto: {_anchoMenuAbierto}, Cerrado: {_anchoMenuCerrado}");
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

        private void MenulateralAnimacion()
        {
            AlternarMenu();
        }

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
            try
            {
                var parent = panelNotificaciones.Parent;
                bool estaCerrado;

                if (parent == null)
                {
                    // Si no hay parent, basa la comprobación en Visible
                    estaCerrado = !panelNotificaciones.Visible;
                }
                else
                {
                    // Cerrado si no es visible o si está completamente fuera a la derecha
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

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            bool tipo = true;
            CerrarSubmenu();
            ManejarFormularios.Instancia.AbrirFormulario(new frmCategorias(tipo));
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
            ManejarFormularios.Instancia.AbrirFormulario(new InterfacesUsuarios.Compras.frmProveedor());
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "COMPRAS");


        }

        private void btnPresentaciones_Click(object sender, EventArgs e)
        {
            bool tipo = true;  
            CerrarSubmenu();
            ManejarFormularios.Instancia.AbrirFormulario(new frmPresentaciones(tipo));
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "INVENTARIO");
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

        private void btnBitacora_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            ManejarFormularios.Instancia.AbrirFormulario(new frmBitacora());
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "USUARIOS");

        }

        private void btnCrearReporte_Click(object sender, EventArgs e)
        {
            CerrarSubmenu();
            ManejarFormularios.Instancia.AbrirFormulario(new frmCrearReporte());
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

        // Servicio de para ocultar Acciones visualmete en el sistema
        private void RegistrarBotonesConPermisos()
        {
            // BOTONES DE MÓDULO (Lógica "OR")
            //Mapeo Inventario
            _servicioPermisos.RegistrarBoton(btnInventarios, "select_inventario", "update_inventario", "create_inventario");
            _servicioPermisos.RegistrarBoton(btnInventarioBodega, "select_inventario", "update_inventario", "create_inventario");
            _servicioPermisos.RegistrarBoton(btnGestionInventario, "select_inventario", "update_inventario", "create_inventario");
            _servicioPermisos.RegistrarBoton(btnRegistroPerdida, "select_inventario", "update_inventario", "create_inventario");
            _servicioPermisos.RegistrarBoton(btnMarcas, "select_inventario", "update_inventario", "create_inventario");
            _servicioPermisos.RegistrarBoton(btnCategorias, "select_inventario", "update_inventario", "create_inventario");
            _servicioPermisos.RegistrarBoton(btnPresentaciones, "select_inventario", "update_inventario", "create_inventario");
            //Mapeo Compras
            _servicioPermisos.RegistrarBoton(btnCompras, "select_compra", "update_compra", "create_compra");
            _servicioPermisos.RegistrarBoton(btnGestionCompra, "select_compra", "update_compra", "create_compra");
            _servicioPermisos.RegistrarBoton(btnProveedores, "select_compra", "update_compra", "create_compra");
            //Mapeo Ventas
            _servicioPermisos.RegistrarBoton(btnVentas, "select_venta", "update_venta", "create_venta");
            _servicioPermisos.RegistrarBoton(btnGestionVentas, "select_venta", "update_venta", "create_venta");
            _servicioPermisos.RegistrarBoton(btnClientes, "select_venta", "update_venta", "create_venta");
            //Mapeo Usuarios
            _servicioPermisos.RegistrarBoton(btnUsuarios, "select_usuario", "update_usuario", "create_usuario");
            _servicioPermisos.RegistrarBoton(btnGestionUsuarios, "select_usuario", "update_usuario", "create_usuario");
            _servicioPermisos.RegistrarBoton(btnGestionRoles, "select_usuario", "update_usuario", "create_usuario");
            _servicioPermisos.RegistrarBoton(btnBitacora, "select_usuario", "update_usuario", "create_usuario");
            //Mapeo Reporteria
            _servicioPermisos.RegistrarBoton(btnReporte, "select_reporte", "update_reporte", "create_reporte");
            _servicioPermisos.RegistrarBoton(btnCrearReporte, "select_reporte", "update_reporte", "create_reporte");
            _servicioPermisos.RegistrarBoton(btnReportesCreados, "select_reporte", "update_reporte", "create_reporte");
        }

        private void btnMarcas_Click(object sender, EventArgs e)
        {
            bool tipo = true;
            CerrarSubmenu();
            ManejarFormularios.Instancia.AbrirFormulario(new frmMarcas(tipo));
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "INVENTARIO");
        }
    }
}
