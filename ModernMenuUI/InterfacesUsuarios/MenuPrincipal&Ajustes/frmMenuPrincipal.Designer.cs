namespace ModernMenuUI
{
    partial class frmMenuPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Panel panBarraControl;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuPrincipal));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            panel6 = new Panel();
            lblEstadoConexion = new Label();
            panel12 = new Panel();
            panel9 = new Panel();
            btnNotificaciones = new Button();
            panel3 = new Panel();
            panel1 = new Panel();
            lblNombreModulo = new Label();
            btnAjustes = new Button();
            btnMinimizar = new Button();
            btnMiniMaxi = new Button();
            btnCerrar = new Button();
            panelMenuLateral = new Panel();
            pictureBox1 = new PictureBox();
            pnlDivisorReporteria = new Panel();
            panelReporteria = new Panel();
            btnReportesCreados = new Button();
            btnCrearReporte = new Button();
            btnReporte = new controlBotonesMenuPrincipal();
            pnlDivisorUsuario = new Panel();
            panelUsuarios = new Panel();
            btnBitacora = new Button();
            btnGestionRoles = new Button();
            btnGestionUsuarios = new Button();
            btnGestionEmpleados = new Button();
            btnUsuarios = new controlBotonesMenuPrincipal();
            pnlDivisorVentas = new Panel();
            panel2 = new Panel();
            lblBodega = new Label();
            lblRol = new Label();
            lblUsuario = new Label();
            pictureBox2 = new PictureBox();
            panelVentas = new Panel();
            btnDevoluciones = new Button();
            btnCierreDiario = new Button();
            btnClientes = new Button();
            btnGestionVentas = new Button();
            btnVentas = new controlBotonesMenuPrincipal();
            pnlDivisorCompras = new Panel();
            panelCompras = new Panel();
            btnProveedores = new Button();
            btnGestionCompra = new Button();
            btnCompras = new controlBotonesMenuPrincipal();
            pnlDivisorInventario = new Panel();
            panelInventario = new Panel();
            btnRegistroPerdida = new Button();
            btnPresentaciones = new Button();
            btnCategorias = new Button();
            btnMarcas = new Button();
            btnGestionInventario = new Button();
            btnBodegas = new Button();
            btnInventarioBodega = new Button();
            btnInventarios = new controlBotonesMenuPrincipal();
            panDiv = new Panel();
            panelMneuLateral = new Panel();
            btnAbrirMenu = new Button();
            panelFormHijo = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            pbxCalculadora = new PictureBox();
            lblHora = new Label();
            lblFecha = new Label();
            timerAbrir = new System.Windows.Forms.Timer(components);
            timerCerrar = new System.Windows.Forms.Timer(components);
            panelNotificaciones = new Panel();
            lblNotificaciones = new Label();
            HoraFecha = new System.Windows.Forms.Timer(components);
            panBarraControl = new Panel();
            panBarraControl.SuspendLayout();
            panel6.SuspendLayout();
            panel1.SuspendLayout();
            panelMenuLateral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelReporteria.SuspendLayout();
            panelUsuarios.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panelVentas.SuspendLayout();
            panelCompras.SuspendLayout();
            panelInventario.SuspendLayout();
            panelMneuLateral.SuspendLayout();
            panelFormHijo.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxCalculadora).BeginInit();
            panelNotificaciones.SuspendLayout();
            SuspendLayout();
            // 
            // panBarraControl
            // 
            panBarraControl.BackColor = Color.FromArgb(148, 168, 187);
            panBarraControl.Controls.Add(panel6);
            panBarraControl.Controls.Add(btnNotificaciones);
            panBarraControl.Controls.Add(panel3);
            panBarraControl.Controls.Add(panel1);
            panBarraControl.Controls.Add(btnAjustes);
            panBarraControl.Controls.Add(btnMinimizar);
            panBarraControl.Controls.Add(btnMiniMaxi);
            panBarraControl.Controls.Add(btnCerrar);
            panBarraControl.Dock = DockStyle.Top;
            panBarraControl.ForeColor = Color.Coral;
            panBarraControl.Location = new Point(300, 0);
            panBarraControl.Name = "panBarraControl";
            panBarraControl.Size = new Size(934, 65);
            panBarraControl.TabIndex = 1;
            panBarraControl.MouseDown += panBarraControl_MouseDown;
            // 
            // panel6
            // 
            panel6.AutoSize = true;
            panel6.Controls.Add(lblEstadoConexion);
            panel6.Controls.Add(panel12);
            panel6.Controls.Add(panel9);
            panel6.Dock = DockStyle.Right;
            panel6.Location = new Point(737, 0);
            panel6.Name = "panel6";
            panel6.RightToLeft = RightToLeft.Yes;
            panel6.Size = new Size(132, 65);
            panel6.TabIndex = 11;
            // 
            // lblEstadoConexion
            // 
            lblEstadoConexion.AutoSize = true;
            lblEstadoConexion.BackColor = Color.Transparent;
            lblEstadoConexion.Dock = DockStyle.Fill;
            lblEstadoConexion.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEstadoConexion.ForeColor = Color.White;
            lblEstadoConexion.Location = new Point(0, 26);
            lblEstadoConexion.Name = "lblEstadoConexion";
            lblEstadoConexion.RightToLeft = RightToLeft.Yes;
            lblEstadoConexion.Size = new Size(132, 24);
            lblEstadoConexion.TabIndex = 3;
            lblEstadoConexion.Text = "Estado de Red";
            // 
            // panel12
            // 
            panel12.Dock = DockStyle.Bottom;
            panel12.Location = new Point(0, 48);
            panel12.Name = "panel12";
            panel12.Size = new Size(132, 17);
            panel12.TabIndex = 15;
            // 
            // panel9
            // 
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(0, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(132, 26);
            panel9.TabIndex = 4;
            // 
            // btnNotificaciones
            // 
            btnNotificaciones.BackColor = Color.FromArgb(148, 168, 187);
            btnNotificaciones.Dock = DockStyle.Right;
            btnNotificaciones.FlatAppearance.BorderSize = 0;
            btnNotificaciones.FlatStyle = FlatStyle.Flat;
            btnNotificaciones.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnNotificaciones.ForeColor = Color.FromArgb(87, 99, 110);
            btnNotificaciones.Image = (Image)resources.GetObject("btnNotificaciones.Image");
            btnNotificaciones.Location = new Point(869, 0);
            btnNotificaciones.Name = "btnNotificaciones";
            btnNotificaciones.Size = new Size(65, 65);
            btnNotificaciones.TabIndex = 6;
            btnNotificaciones.Text = "99+";
            btnNotificaciones.UseVisualStyleBackColor = false;
            btnNotificaciones.Click += btnNotificaciones_Click;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(934, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(0, 65);
            panel3.TabIndex = 10;
            panel3.Visible = false;
            panel3.MouseDown += panel3_MouseDown;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblNombreModulo);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(65, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(218, 65);
            panel1.TabIndex = 9;
            panel1.MouseDown += panel1_MouseDown_1;
            // 
            // lblNombreModulo
            // 
            lblNombreModulo.AutoSize = true;
            lblNombreModulo.Font = new Font("Itim", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombreModulo.ForeColor = Color.White;
            lblNombreModulo.Location = new Point(3, 17);
            lblNombreModulo.Name = "lblNombreModulo";
            lblNombreModulo.Size = new Size(251, 35);
            lblNombreModulo.TabIndex = 8;
            lblNombreModulo.Text = "MENU PRINCIPAL";
            lblNombreModulo.MouseDown += lblNombreModulo_MouseDown;
            // 
            // btnAjustes
            // 
            btnAjustes.BackColor = Color.FromArgb(148, 168, 187);
            btnAjustes.Dock = DockStyle.Left;
            btnAjustes.FlatAppearance.BorderSize = 0;
            btnAjustes.FlatStyle = FlatStyle.Flat;
            btnAjustes.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAjustes.ForeColor = Color.FromArgb(167, 191, 211);
            btnAjustes.Image = (Image)resources.GetObject("btnAjustes.Image");
            btnAjustes.ImageAlign = ContentAlignment.MiddleLeft;
            btnAjustes.Location = new Point(0, 0);
            btnAjustes.Name = "btnAjustes";
            btnAjustes.Padding = new Padding(11, 0, 0, 0);
            btnAjustes.Size = new Size(65, 65);
            btnAjustes.TabIndex = 7;
            btnAjustes.TextAlign = ContentAlignment.MiddleLeft;
            btnAjustes.UseVisualStyleBackColor = false;
            btnAjustes.Click += btnAjustes_Click;
            // 
            // btnMinimizar
            // 
            btnMinimizar.BackColor = Color.FromArgb(148, 168, 187);
            btnMinimizar.Dock = DockStyle.Right;
            btnMinimizar.FlatAppearance.BorderSize = 0;
            btnMinimizar.FlatStyle = FlatStyle.Flat;
            btnMinimizar.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMinimizar.ForeColor = Color.FromArgb(167, 191, 211);
            btnMinimizar.ImageAlign = ContentAlignment.MiddleLeft;
            btnMinimizar.Location = new Point(934, 0);
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.Padding = new Padding(11, 0, 0, 0);
            btnMinimizar.Size = new Size(0, 65);
            btnMinimizar.TabIndex = 5;
            btnMinimizar.TextAlign = ContentAlignment.MiddleLeft;
            btnMinimizar.UseVisualStyleBackColor = false;
            btnMinimizar.Visible = false;
            btnMinimizar.Click += btnMinimizar_Click;
            // 
            // btnMiniMaxi
            // 
            btnMiniMaxi.BackColor = Color.FromArgb(148, 168, 187);
            btnMiniMaxi.Dock = DockStyle.Right;
            btnMiniMaxi.FlatAppearance.BorderSize = 0;
            btnMiniMaxi.FlatStyle = FlatStyle.Flat;
            btnMiniMaxi.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMiniMaxi.ForeColor = Color.FromArgb(167, 191, 211);
            btnMiniMaxi.ImageAlign = ContentAlignment.MiddleLeft;
            btnMiniMaxi.Location = new Point(934, 0);
            btnMiniMaxi.Name = "btnMiniMaxi";
            btnMiniMaxi.Padding = new Padding(11, 0, 0, 0);
            btnMiniMaxi.Size = new Size(0, 65);
            btnMiniMaxi.TabIndex = 4;
            btnMiniMaxi.TextAlign = ContentAlignment.MiddleLeft;
            btnMiniMaxi.UseVisualStyleBackColor = false;
            btnMiniMaxi.Visible = false;
            btnMiniMaxi.Click += btnMiniMaxi_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.FromArgb(148, 168, 187);
            btnCerrar.Dock = DockStyle.Right;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCerrar.ForeColor = Color.FromArgb(167, 191, 211);
            btnCerrar.Image = (Image)resources.GetObject("btnCerrar.Image");
            btnCerrar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCerrar.Location = new Point(934, 0);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Padding = new Padding(11, 0, 0, 0);
            btnCerrar.Size = new Size(0, 65);
            btnCerrar.TabIndex = 3;
            btnCerrar.TextAlign = ContentAlignment.MiddleLeft;
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Visible = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // panelMenuLateral
            // 
            panelMenuLateral.AccessibleRole = AccessibleRole.Cursor;
            panelMenuLateral.AutoScroll = true;
            panelMenuLateral.BackColor = Color.FromArgb(189, 216, 235);
            panelMenuLateral.Controls.Add(pictureBox1);
            panelMenuLateral.Controls.Add(pnlDivisorReporteria);
            panelMenuLateral.Controls.Add(panelReporteria);
            panelMenuLateral.Controls.Add(btnReporte);
            panelMenuLateral.Controls.Add(pnlDivisorUsuario);
            panelMenuLateral.Controls.Add(panelUsuarios);
            panelMenuLateral.Controls.Add(btnUsuarios);
            panelMenuLateral.Controls.Add(pnlDivisorVentas);
            panelMenuLateral.Controls.Add(panel2);
            panelMenuLateral.Controls.Add(panelVentas);
            panelMenuLateral.Controls.Add(btnVentas);
            panelMenuLateral.Controls.Add(pnlDivisorCompras);
            panelMenuLateral.Controls.Add(panelCompras);
            panelMenuLateral.Controls.Add(btnCompras);
            panelMenuLateral.Controls.Add(pnlDivisorInventario);
            panelMenuLateral.Controls.Add(panelInventario);
            panelMenuLateral.Controls.Add(btnInventarios);
            panelMenuLateral.Controls.Add(panDiv);
            panelMenuLateral.Controls.Add(panelMneuLateral);
            panelMenuLateral.Dock = DockStyle.Left;
            panelMenuLateral.Location = new Point(0, 0);
            panelMenuLateral.Name = "panelMenuLateral";
            panelMenuLateral.Size = new Size(300, 761);
            panelMenuLateral.TabIndex = 0;
            panelMenuLateral.MouseDown += panelMenuLateral_MouseDown;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(0, 1237);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(279, 175);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pnlDivisorReporteria
            // 
            pnlDivisorReporteria.BackColor = Color.White;
            pnlDivisorReporteria.Dock = DockStyle.Top;
            pnlDivisorReporteria.Location = new Point(0, 1235);
            pnlDivisorReporteria.Name = "pnlDivisorReporteria";
            pnlDivisorReporteria.Size = new Size(279, 2);
            pnlDivisorReporteria.TabIndex = 21;
            // 
            // panelReporteria
            // 
            panelReporteria.AutoSize = true;
            panelReporteria.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelReporteria.BackColor = Color.FromArgb(238, 238, 238);
            panelReporteria.Controls.Add(btnReportesCreados);
            panelReporteria.Controls.Add(btnCrearReporte);
            panelReporteria.Dock = DockStyle.Top;
            panelReporteria.Location = new Point(0, 1155);
            panelReporteria.Name = "panelReporteria";
            panelReporteria.Size = new Size(279, 80);
            panelReporteria.TabIndex = 10;
            // 
            // btnReportesCreados
            // 
            btnReportesCreados.BackColor = Color.FromArgb(202, 223, 255);
            btnReportesCreados.Dock = DockStyle.Top;
            btnReportesCreados.FlatAppearance.BorderColor = Color.White;
            btnReportesCreados.FlatStyle = FlatStyle.Flat;
            btnReportesCreados.Font = new Font("Itim", 11.25F);
            btnReportesCreados.ForeColor = Color.FromArgb(87, 99, 110);
            btnReportesCreados.Location = new Point(0, 40);
            btnReportesCreados.Name = "btnReportesCreados";
            btnReportesCreados.Padding = new Padding(20, 0, 0, 0);
            btnReportesCreados.Size = new Size(279, 40);
            btnReportesCreados.TabIndex = 1;
            btnReportesCreados.Text = "Reportes Creados";
            btnReportesCreados.TextAlign = ContentAlignment.MiddleLeft;
            btnReportesCreados.UseVisualStyleBackColor = false;
            btnReportesCreados.Click += btnReportesCreados_Click;
            // 
            // btnCrearReporte
            // 
            btnCrearReporte.BackColor = Color.FromArgb(202, 223, 255);
            btnCrearReporte.Dock = DockStyle.Top;
            btnCrearReporte.FlatAppearance.BorderColor = Color.White;
            btnCrearReporte.FlatStyle = FlatStyle.Flat;
            btnCrearReporte.Font = new Font("Itim", 11.25F);
            btnCrearReporte.ForeColor = Color.FromArgb(87, 99, 110);
            btnCrearReporte.Location = new Point(0, 0);
            btnCrearReporte.Name = "btnCrearReporte";
            btnCrearReporte.Padding = new Padding(20, 0, 0, 0);
            btnCrearReporte.Size = new Size(279, 40);
            btnCrearReporte.TabIndex = 0;
            btnCrearReporte.Text = "Crear Reporte";
            btnCrearReporte.TextAlign = ContentAlignment.MiddleLeft;
            btnCrearReporte.UseVisualStyleBackColor = false;
            btnCrearReporte.Click += btnCrearReporte_Click;
            // 
            // btnReporte
            // 
            btnReporte.BackColor = Color.FromArgb(189, 215, 238);
            btnReporte.ColorClick = Color.FromArgb(200, 212, 222);
            btnReporte.ColorHover = Color.FromArgb(170, 193, 214);
            btnReporte.ColorNormal = Color.FromArgb(189, 215, 238);
            btnReporte.ColorTexto = Color.FromArgb(87, 99, 110);
            btnReporte.Dock = DockStyle.Top;
            btnReporte.Imagen = (Image)resources.GetObject("btnReporte.Imagen");
            btnReporte.Location = new Point(0, 1075);
            btnReporte.Margin = new Padding(3, 4, 3, 4);
            btnReporte.Name = "btnReporte";
            btnReporte.Size = new Size(279, 80);
            btnReporte.TabIndex = 30;
            btnReporte.Texto = "Reportería";
            btnReporte.Click += btnReporte_Click;
            // 
            // pnlDivisorUsuario
            // 
            pnlDivisorUsuario.BackColor = Color.White;
            pnlDivisorUsuario.Dock = DockStyle.Top;
            pnlDivisorUsuario.Location = new Point(0, 1073);
            pnlDivisorUsuario.Name = "pnlDivisorUsuario";
            pnlDivisorUsuario.Size = new Size(279, 2);
            pnlDivisorUsuario.TabIndex = 22;
            // 
            // panelUsuarios
            // 
            panelUsuarios.AutoSize = true;
            panelUsuarios.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelUsuarios.BackColor = Color.FromArgb(238, 238, 238);
            panelUsuarios.Controls.Add(btnBitacora);
            panelUsuarios.Controls.Add(btnGestionRoles);
            panelUsuarios.Controls.Add(btnGestionUsuarios);
            panelUsuarios.Controls.Add(btnGestionEmpleados);
            panelUsuarios.Dock = DockStyle.Top;
            panelUsuarios.Location = new Point(0, 913);
            panelUsuarios.Name = "panelUsuarios";
            panelUsuarios.Size = new Size(279, 160);
            panelUsuarios.TabIndex = 8;
            // 
            // btnBitacora
            // 
            btnBitacora.BackColor = Color.FromArgb(202, 223, 255);
            btnBitacora.Dock = DockStyle.Top;
            btnBitacora.FlatAppearance.BorderColor = Color.White;
            btnBitacora.FlatStyle = FlatStyle.Flat;
            btnBitacora.Font = new Font("Itim", 11.25F);
            btnBitacora.ForeColor = Color.FromArgb(87, 99, 110);
            btnBitacora.Location = new Point(0, 120);
            btnBitacora.Name = "btnBitacora";
            btnBitacora.Padding = new Padding(20, 0, 0, 0);
            btnBitacora.Size = new Size(279, 40);
            btnBitacora.TabIndex = 7;
            btnBitacora.Text = "Bitacora";
            btnBitacora.TextAlign = ContentAlignment.MiddleLeft;
            btnBitacora.UseVisualStyleBackColor = false;
            btnBitacora.Click += btnBitacora_Click;
            // 
            // btnGestionRoles
            // 
            btnGestionRoles.BackColor = Color.FromArgb(202, 223, 255);
            btnGestionRoles.Dock = DockStyle.Top;
            btnGestionRoles.FlatAppearance.BorderColor = Color.White;
            btnGestionRoles.FlatStyle = FlatStyle.Flat;
            btnGestionRoles.Font = new Font("Itim", 11.25F);
            btnGestionRoles.ForeColor = Color.FromArgb(87, 99, 110);
            btnGestionRoles.Location = new Point(0, 80);
            btnGestionRoles.Name = "btnGestionRoles";
            btnGestionRoles.Padding = new Padding(20, 0, 0, 0);
            btnGestionRoles.Size = new Size(279, 40);
            btnGestionRoles.TabIndex = 4;
            btnGestionRoles.Text = "Gestión de Roles";
            btnGestionRoles.TextAlign = ContentAlignment.MiddleLeft;
            btnGestionRoles.UseVisualStyleBackColor = false;
            btnGestionRoles.Click += btnGestionRoles_Click;
            // 
            // btnGestionUsuarios
            // 
            btnGestionUsuarios.BackColor = Color.FromArgb(202, 223, 255);
            btnGestionUsuarios.Dock = DockStyle.Top;
            btnGestionUsuarios.FlatAppearance.BorderColor = Color.White;
            btnGestionUsuarios.FlatStyle = FlatStyle.Flat;
            btnGestionUsuarios.Font = new Font("Itim", 11.25F);
            btnGestionUsuarios.ForeColor = Color.FromArgb(87, 99, 110);
            btnGestionUsuarios.Location = new Point(0, 40);
            btnGestionUsuarios.Name = "btnGestionUsuarios";
            btnGestionUsuarios.Padding = new Padding(20, 0, 0, 0);
            btnGestionUsuarios.Size = new Size(279, 40);
            btnGestionUsuarios.TabIndex = 1;
            btnGestionUsuarios.Text = "Gestión de Usuarios";
            btnGestionUsuarios.TextAlign = ContentAlignment.MiddleLeft;
            btnGestionUsuarios.UseVisualStyleBackColor = false;
            btnGestionUsuarios.Click += btnGestionUsuarios_Click;
            // 
            // btnGestionEmpleados
            // 
            btnGestionEmpleados.BackColor = Color.FromArgb(202, 223, 255);
            btnGestionEmpleados.Dock = DockStyle.Top;
            btnGestionEmpleados.FlatAppearance.BorderColor = Color.White;
            btnGestionEmpleados.FlatStyle = FlatStyle.Flat;
            btnGestionEmpleados.Font = new Font("Itim", 11.25F);
            btnGestionEmpleados.ForeColor = Color.FromArgb(87, 99, 110);
            btnGestionEmpleados.Location = new Point(0, 0);
            btnGestionEmpleados.Name = "btnGestionEmpleados";
            btnGestionEmpleados.Padding = new Padding(20, 0, 0, 0);
            btnGestionEmpleados.Size = new Size(279, 40);
            btnGestionEmpleados.TabIndex = 0;
            btnGestionEmpleados.Text = "Gestión de Empleados";
            btnGestionEmpleados.TextAlign = ContentAlignment.MiddleLeft;
            btnGestionEmpleados.UseVisualStyleBackColor = false;
            btnGestionEmpleados.Click += btnGestionEmpleados_Click;
            // 
            // btnUsuarios
            // 
            btnUsuarios.BackColor = Color.FromArgb(189, 215, 238);
            btnUsuarios.ColorClick = Color.FromArgb(200, 212, 222);
            btnUsuarios.ColorHover = Color.FromArgb(170, 193, 214);
            btnUsuarios.ColorNormal = Color.FromArgb(189, 215, 238);
            btnUsuarios.ColorTexto = Color.FromArgb(87, 99, 110);
            btnUsuarios.Dock = DockStyle.Top;
            btnUsuarios.Imagen = (Image)resources.GetObject("btnUsuarios.Imagen");
            btnUsuarios.Location = new Point(0, 833);
            btnUsuarios.Margin = new Padding(3, 4, 3, 4);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(279, 80);
            btnUsuarios.TabIndex = 28;
            btnUsuarios.Texto = "Usuarios";
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // pnlDivisorVentas
            // 
            pnlDivisorVentas.BackColor = Color.White;
            pnlDivisorVentas.Dock = DockStyle.Top;
            pnlDivisorVentas.Location = new Point(0, 831);
            pnlDivisorVentas.Name = "pnlDivisorVentas";
            pnlDivisorVentas.Size = new Size(279, 2);
            pnlDivisorVentas.TabIndex = 23;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(167, 191, 211);
            panel2.Controls.Add(lblBodega);
            panel2.Controls.Add(lblRol);
            panel2.Controls.Add(lblUsuario);
            panel2.Controls.Add(pictureBox2);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 1412);
            panel2.Name = "panel2";
            panel2.Size = new Size(279, 80);
            panel2.TabIndex = 11;
            // 
            // lblBodega
            // 
            lblBodega.AutoSize = true;
            lblBodega.Font = new Font("Itim", 11.25F);
            lblBodega.ForeColor = Color.White;
            lblBodega.Location = new Point(106, 55);
            lblBodega.Name = "lblBodega";
            lblBodega.Size = new Size(165, 23);
            lblBodega.TabIndex = 11;
            lblBodega.Text = "Bodega: Mi Bodega";
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Font = new Font("Itim", 11.25F);
            lblRol.ForeColor = Color.White;
            lblRol.Location = new Point(106, 32);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(99, 23);
            lblRol.TabIndex = 10;
            lblRol.Text = "Rol: Admin";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Itim", 11.25F);
            lblUsuario.ForeColor = Color.White;
            lblUsuario.Location = new Point(106, 6);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(169, 23);
            lblUsuario.TabIndex = 9;
            lblUsuario.Text = "Fernando Barahona";
            // 
            // pictureBox2
            // 
            pictureBox2.Dock = DockStyle.Left;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(100, 80);
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // panelVentas
            // 
            panelVentas.AutoSize = true;
            panelVentas.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelVentas.BackColor = Color.FromArgb(238, 238, 238);
            panelVentas.Controls.Add(btnDevoluciones);
            panelVentas.Controls.Add(btnCierreDiario);
            panelVentas.Controls.Add(btnClientes);
            panelVentas.Controls.Add(btnGestionVentas);
            panelVentas.Dock = DockStyle.Top;
            panelVentas.Location = new Point(0, 671);
            panelVentas.Name = "panelVentas";
            panelVentas.Size = new Size(279, 160);
            panelVentas.TabIndex = 6;
            // 
            // btnDevoluciones
            // 
            btnDevoluciones.BackColor = Color.FromArgb(202, 223, 255);
            btnDevoluciones.Dock = DockStyle.Top;
            btnDevoluciones.FlatAppearance.BorderColor = Color.White;
            btnDevoluciones.FlatStyle = FlatStyle.Flat;
            btnDevoluciones.Font = new Font("Itim", 11.25F);
            btnDevoluciones.ForeColor = Color.FromArgb(87, 99, 110);
            btnDevoluciones.Location = new Point(0, 120);
            btnDevoluciones.Name = "btnDevoluciones";
            btnDevoluciones.Padding = new Padding(20, 0, 0, 0);
            btnDevoluciones.Size = new Size(279, 40);
            btnDevoluciones.TabIndex = 3;
            btnDevoluciones.Text = "Devoluciones";
            btnDevoluciones.TextAlign = ContentAlignment.MiddleLeft;
            btnDevoluciones.UseVisualStyleBackColor = false;
            btnDevoluciones.Click += btnDevoluciones_Click;
            // 
            // btnCierreDiario
            // 
            btnCierreDiario.BackColor = Color.FromArgb(202, 223, 255);
            btnCierreDiario.Dock = DockStyle.Top;
            btnCierreDiario.FlatAppearance.BorderColor = Color.White;
            btnCierreDiario.FlatStyle = FlatStyle.Flat;
            btnCierreDiario.Font = new Font("Itim", 11.25F);
            btnCierreDiario.ForeColor = Color.FromArgb(87, 99, 110);
            btnCierreDiario.Location = new Point(0, 80);
            btnCierreDiario.Name = "btnCierreDiario";
            btnCierreDiario.Padding = new Padding(20, 0, 0, 0);
            btnCierreDiario.Size = new Size(279, 40);
            btnCierreDiario.TabIndex = 2;
            btnCierreDiario.Text = "Cierre Diario";
            btnCierreDiario.TextAlign = ContentAlignment.MiddleLeft;
            btnCierreDiario.UseVisualStyleBackColor = false;
            btnCierreDiario.Click += btnCierreDiario_Click;
            // 
            // btnClientes
            // 
            btnClientes.BackColor = Color.FromArgb(202, 223, 255);
            btnClientes.Dock = DockStyle.Top;
            btnClientes.FlatAppearance.BorderColor = Color.White;
            btnClientes.FlatStyle = FlatStyle.Flat;
            btnClientes.Font = new Font("Itim", 11.25F);
            btnClientes.ForeColor = Color.FromArgb(87, 99, 110);
            btnClientes.Location = new Point(0, 40);
            btnClientes.Name = "btnClientes";
            btnClientes.Padding = new Padding(20, 0, 0, 0);
            btnClientes.Size = new Size(279, 40);
            btnClientes.TabIndex = 1;
            btnClientes.Text = "Clientes";
            btnClientes.TextAlign = ContentAlignment.MiddleLeft;
            btnClientes.UseVisualStyleBackColor = false;
            btnClientes.Click += btnClientes_Click;
            // 
            // btnGestionVentas
            // 
            btnGestionVentas.BackColor = Color.FromArgb(202, 223, 255);
            btnGestionVentas.Dock = DockStyle.Top;
            btnGestionVentas.FlatAppearance.BorderColor = Color.White;
            btnGestionVentas.FlatStyle = FlatStyle.Flat;
            btnGestionVentas.Font = new Font("Itim", 11.25F);
            btnGestionVentas.ForeColor = Color.FromArgb(87, 99, 110);
            btnGestionVentas.Location = new Point(0, 0);
            btnGestionVentas.Name = "btnGestionVentas";
            btnGestionVentas.Padding = new Padding(20, 0, 0, 0);
            btnGestionVentas.Size = new Size(279, 40);
            btnGestionVentas.TabIndex = 0;
            btnGestionVentas.Text = "Facturación";
            btnGestionVentas.TextAlign = ContentAlignment.MiddleLeft;
            btnGestionVentas.UseVisualStyleBackColor = false;
            btnGestionVentas.Click += btnGestionVentas_Click;
            // 
            // btnVentas
            // 
            btnVentas.BackColor = Color.FromArgb(189, 215, 238);
            btnVentas.ColorClick = Color.FromArgb(200, 212, 222);
            btnVentas.ColorHover = Color.FromArgb(170, 193, 214);
            btnVentas.ColorNormal = Color.FromArgb(189, 215, 238);
            btnVentas.ColorTexto = Color.FromArgb(87, 99, 110);
            btnVentas.Dock = DockStyle.Top;
            btnVentas.Imagen = (Image)resources.GetObject("btnVentas.Imagen");
            btnVentas.Location = new Point(0, 591);
            btnVentas.Margin = new Padding(3, 4, 3, 4);
            btnVentas.Name = "btnVentas";
            btnVentas.Size = new Size(279, 80);
            btnVentas.TabIndex = 27;
            btnVentas.Texto = "Ventas";
            btnVentas.Click += btnVentas_Click;
            // 
            // pnlDivisorCompras
            // 
            pnlDivisorCompras.BackColor = Color.White;
            pnlDivisorCompras.Dock = DockStyle.Top;
            pnlDivisorCompras.Location = new Point(0, 589);
            pnlDivisorCompras.Name = "pnlDivisorCompras";
            pnlDivisorCompras.Size = new Size(279, 2);
            pnlDivisorCompras.TabIndex = 24;
            // 
            // panelCompras
            // 
            panelCompras.AutoSize = true;
            panelCompras.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelCompras.BackColor = Color.FromArgb(238, 238, 238);
            panelCompras.Controls.Add(btnProveedores);
            panelCompras.Controls.Add(btnGestionCompra);
            panelCompras.Dock = DockStyle.Top;
            panelCompras.Location = new Point(0, 509);
            panelCompras.Name = "panelCompras";
            panelCompras.Size = new Size(279, 80);
            panelCompras.TabIndex = 4;
            // 
            // btnProveedores
            // 
            btnProveedores.BackColor = Color.FromArgb(202, 223, 255);
            btnProveedores.Dock = DockStyle.Top;
            btnProveedores.FlatAppearance.BorderColor = Color.White;
            btnProveedores.FlatStyle = FlatStyle.Flat;
            btnProveedores.Font = new Font("Itim", 11.25F);
            btnProveedores.ForeColor = Color.FromArgb(87, 99, 110);
            btnProveedores.Location = new Point(0, 40);
            btnProveedores.Name = "btnProveedores";
            btnProveedores.Padding = new Padding(20, 0, 0, 0);
            btnProveedores.Size = new Size(279, 40);
            btnProveedores.TabIndex = 1;
            btnProveedores.Text = "Proveedores";
            btnProveedores.TextAlign = ContentAlignment.MiddleLeft;
            btnProveedores.UseVisualStyleBackColor = false;
            btnProveedores.Click += btnProveedores_Click;
            // 
            // btnGestionCompra
            // 
            btnGestionCompra.BackColor = Color.FromArgb(202, 223, 255);
            btnGestionCompra.Dock = DockStyle.Top;
            btnGestionCompra.FlatAppearance.BorderColor = Color.White;
            btnGestionCompra.FlatStyle = FlatStyle.Flat;
            btnGestionCompra.Font = new Font("Itim", 11.25F);
            btnGestionCompra.ForeColor = Color.FromArgb(87, 99, 110);
            btnGestionCompra.Location = new Point(0, 0);
            btnGestionCompra.Name = "btnGestionCompra";
            btnGestionCompra.Padding = new Padding(20, 0, 0, 0);
            btnGestionCompra.Size = new Size(279, 40);
            btnGestionCompra.TabIndex = 0;
            btnGestionCompra.Text = "Gestión de Compra";
            btnGestionCompra.TextAlign = ContentAlignment.MiddleLeft;
            btnGestionCompra.UseVisualStyleBackColor = false;
            btnGestionCompra.Click += btnGestionCompra_Click;
            // 
            // btnCompras
            // 
            btnCompras.BackColor = Color.FromArgb(189, 215, 238);
            btnCompras.ColorClick = Color.FromArgb(200, 212, 222);
            btnCompras.ColorHover = Color.FromArgb(170, 193, 214);
            btnCompras.ColorNormal = Color.FromArgb(189, 215, 238);
            btnCompras.ColorTexto = Color.FromArgb(87, 99, 110);
            btnCompras.Dock = DockStyle.Top;
            btnCompras.Imagen = (Image)resources.GetObject("btnCompras.Imagen");
            btnCompras.Location = new Point(0, 429);
            btnCompras.Margin = new Padding(3, 4, 3, 4);
            btnCompras.Name = "btnCompras";
            btnCompras.Size = new Size(279, 80);
            btnCompras.TabIndex = 26;
            btnCompras.Texto = "Compras";
            btnCompras.Click += btnCompras_Click;
            // 
            // pnlDivisorInventario
            // 
            pnlDivisorInventario.BackColor = Color.White;
            pnlDivisorInventario.Dock = DockStyle.Top;
            pnlDivisorInventario.Location = new Point(0, 427);
            pnlDivisorInventario.Name = "pnlDivisorInventario";
            pnlDivisorInventario.Size = new Size(279, 2);
            pnlDivisorInventario.TabIndex = 20;
            // 
            // panelInventario
            // 
            panelInventario.AutoSize = true;
            panelInventario.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelInventario.BackColor = Color.FromArgb(238, 238, 238);
            panelInventario.Controls.Add(btnRegistroPerdida);
            panelInventario.Controls.Add(btnPresentaciones);
            panelInventario.Controls.Add(btnCategorias);
            panelInventario.Controls.Add(btnMarcas);
            panelInventario.Controls.Add(btnGestionInventario);
            panelInventario.Controls.Add(btnBodegas);
            panelInventario.Controls.Add(btnInventarioBodega);
            panelInventario.Dock = DockStyle.Top;
            panelInventario.Location = new Point(0, 147);
            panelInventario.Name = "panelInventario";
            panelInventario.Size = new Size(279, 280);
            panelInventario.TabIndex = 2;
            // 
            // btnRegistroPerdida
            // 
            btnRegistroPerdida.BackColor = Color.FromArgb(202, 223, 255);
            btnRegistroPerdida.Dock = DockStyle.Top;
            btnRegistroPerdida.FlatAppearance.BorderColor = Color.White;
            btnRegistroPerdida.FlatStyle = FlatStyle.Flat;
            btnRegistroPerdida.Font = new Font("Itim", 11.25F);
            btnRegistroPerdida.ForeColor = Color.FromArgb(87, 99, 110);
            btnRegistroPerdida.Location = new Point(0, 240);
            btnRegistroPerdida.Name = "btnRegistroPerdida";
            btnRegistroPerdida.Padding = new Padding(20, 0, 0, 0);
            btnRegistroPerdida.Size = new Size(279, 40);
            btnRegistroPerdida.TabIndex = 3;
            btnRegistroPerdida.Text = "Perdidas";
            btnRegistroPerdida.TextAlign = ContentAlignment.MiddleLeft;
            btnRegistroPerdida.UseVisualStyleBackColor = false;
            btnRegistroPerdida.Visible = false;
            btnRegistroPerdida.Click += btnRegistroPerdida_Click;
            // 
            // btnPresentaciones
            // 
            btnPresentaciones.BackColor = Color.FromArgb(202, 223, 255);
            btnPresentaciones.Dock = DockStyle.Top;
            btnPresentaciones.FlatAppearance.BorderColor = Color.White;
            btnPresentaciones.FlatStyle = FlatStyle.Flat;
            btnPresentaciones.Font = new Font("Itim", 11.25F);
            btnPresentaciones.ForeColor = Color.FromArgb(87, 99, 110);
            btnPresentaciones.Location = new Point(0, 200);
            btnPresentaciones.Name = "btnPresentaciones";
            btnPresentaciones.Padding = new Padding(20, 0, 0, 0);
            btnPresentaciones.Size = new Size(279, 40);
            btnPresentaciones.TabIndex = 6;
            btnPresentaciones.Text = "Tipos de Presentación";
            btnPresentaciones.TextAlign = ContentAlignment.MiddleLeft;
            btnPresentaciones.UseVisualStyleBackColor = false;
            btnPresentaciones.Visible = false;
            btnPresentaciones.Click += btnPresentaciones_Click;
            // 
            // btnCategorias
            // 
            btnCategorias.BackColor = Color.FromArgb(202, 223, 255);
            btnCategorias.Dock = DockStyle.Top;
            btnCategorias.FlatAppearance.BorderColor = Color.White;
            btnCategorias.FlatStyle = FlatStyle.Flat;
            btnCategorias.Font = new Font("Itim", 11.25F);
            btnCategorias.ForeColor = Color.FromArgb(87, 99, 110);
            btnCategorias.Location = new Point(0, 160);
            btnCategorias.Name = "btnCategorias";
            btnCategorias.Padding = new Padding(20, 0, 0, 0);
            btnCategorias.Size = new Size(279, 40);
            btnCategorias.TabIndex = 5;
            btnCategorias.Text = "Listado de Categorías";
            btnCategorias.TextAlign = ContentAlignment.MiddleLeft;
            btnCategorias.UseVisualStyleBackColor = false;
            btnCategorias.Visible = false;
            btnCategorias.Click += btnCategorias_Click;
            // 
            // btnMarcas
            // 
            btnMarcas.BackColor = Color.FromArgb(202, 223, 255);
            btnMarcas.Dock = DockStyle.Top;
            btnMarcas.FlatAppearance.BorderColor = Color.White;
            btnMarcas.FlatStyle = FlatStyle.Flat;
            btnMarcas.Font = new Font("Itim", 11.25F);
            btnMarcas.ForeColor = Color.FromArgb(87, 99, 110);
            btnMarcas.Location = new Point(0, 120);
            btnMarcas.Name = "btnMarcas";
            btnMarcas.Padding = new Padding(20, 0, 0, 0);
            btnMarcas.Size = new Size(279, 40);
            btnMarcas.TabIndex = 4;
            btnMarcas.Text = "Marcas";
            btnMarcas.TextAlign = ContentAlignment.MiddleLeft;
            btnMarcas.UseVisualStyleBackColor = false;
            btnMarcas.Visible = false;
            btnMarcas.Click += btnMarcas_Click;
            // 
            // btnGestionInventario
            // 
            btnGestionInventario.BackColor = Color.FromArgb(202, 223, 255);
            btnGestionInventario.Dock = DockStyle.Top;
            btnGestionInventario.FlatAppearance.BorderColor = Color.White;
            btnGestionInventario.FlatStyle = FlatStyle.Flat;
            btnGestionInventario.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGestionInventario.ForeColor = Color.FromArgb(87, 99, 110);
            btnGestionInventario.Location = new Point(0, 80);
            btnGestionInventario.Name = "btnGestionInventario";
            btnGestionInventario.Padding = new Padding(20, 0, 0, 0);
            btnGestionInventario.Size = new Size(279, 40);
            btnGestionInventario.TabIndex = 0;
            btnGestionInventario.Text = "Productos";
            btnGestionInventario.TextAlign = ContentAlignment.MiddleLeft;
            btnGestionInventario.UseVisualStyleBackColor = false;
            btnGestionInventario.Click += btnGestionInventario_Click;
            // 
            // btnBodegas
            // 
            btnBodegas.BackColor = Color.FromArgb(202, 223, 255);
            btnBodegas.Dock = DockStyle.Top;
            btnBodegas.FlatAppearance.BorderColor = Color.White;
            btnBodegas.FlatStyle = FlatStyle.Flat;
            btnBodegas.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBodegas.ForeColor = Color.FromArgb(87, 99, 110);
            btnBodegas.Location = new Point(0, 40);
            btnBodegas.Name = "btnBodegas";
            btnBodegas.Padding = new Padding(20, 0, 0, 0);
            btnBodegas.Size = new Size(279, 40);
            btnBodegas.TabIndex = 7;
            btnBodegas.Text = "Bodegas";
            btnBodegas.TextAlign = ContentAlignment.MiddleLeft;
            btnBodegas.UseVisualStyleBackColor = false;
            btnBodegas.Click += btnBodegas_Click;
            // 
            // btnInventarioBodega
            // 
            btnInventarioBodega.BackColor = Color.FromArgb(202, 223, 255);
            btnInventarioBodega.Dock = DockStyle.Top;
            btnInventarioBodega.FlatAppearance.BorderColor = Color.White;
            btnInventarioBodega.FlatStyle = FlatStyle.Flat;
            btnInventarioBodega.Font = new Font("Itim", 11.25F);
            btnInventarioBodega.ForeColor = Color.FromArgb(87, 99, 110);
            btnInventarioBodega.Location = new Point(0, 0);
            btnInventarioBodega.Name = "btnInventarioBodega";
            btnInventarioBodega.Padding = new Padding(20, 0, 0, 0);
            btnInventarioBodega.Size = new Size(279, 40);
            btnInventarioBodega.TabIndex = 2;
            btnInventarioBodega.Text = "Inventario de Bodegas";
            btnInventarioBodega.TextAlign = ContentAlignment.MiddleLeft;
            btnInventarioBodega.UseVisualStyleBackColor = false;
            btnInventarioBodega.Click += btnInventarioBodega_Click;
            // 
            // btnInventarios
            // 
            btnInventarios.BackColor = Color.FromArgb(189, 215, 238);
            btnInventarios.ColorClick = Color.FromArgb(200, 212, 222);
            btnInventarios.ColorHover = Color.FromArgb(170, 193, 214);
            btnInventarios.ColorNormal = Color.FromArgb(189, 215, 238);
            btnInventarios.ColorTexto = Color.FromArgb(87, 99, 110);
            btnInventarios.Dock = DockStyle.Top;
            btnInventarios.Imagen = (Image)resources.GetObject("btnInventarios.Imagen");
            btnInventarios.Location = new Point(0, 67);
            btnInventarios.Margin = new Padding(3, 4, 3, 4);
            btnInventarios.Name = "btnInventarios";
            btnInventarios.Size = new Size(279, 80);
            btnInventarios.TabIndex = 29;
            btnInventarios.Texto = "Inventario";
            btnInventarios.Click += btbStocks_Click;
            // 
            // panDiv
            // 
            panDiv.BackColor = Color.White;
            panDiv.Dock = DockStyle.Top;
            panDiv.Location = new Point(0, 65);
            panDiv.Name = "panDiv";
            panDiv.Size = new Size(279, 2);
            panDiv.TabIndex = 4;
            // 
            // panelMneuLateral
            // 
            panelMneuLateral.BackColor = Color.FromArgb(167, 191, 211);
            panelMneuLateral.Controls.Add(btnAbrirMenu);
            panelMneuLateral.Dock = DockStyle.Top;
            panelMneuLateral.ForeColor = Color.Coral;
            panelMneuLateral.Location = new Point(0, 0);
            panelMneuLateral.Name = "panelMneuLateral";
            panelMneuLateral.Size = new Size(279, 65);
            panelMneuLateral.TabIndex = 0;
            panelMneuLateral.MouseDown += panel1_MouseDown;
            // 
            // btnAbrirMenu
            // 
            btnAbrirMenu.BackColor = Color.FromArgb(167, 191, 211);
            btnAbrirMenu.BackgroundImage = (Image)resources.GetObject("btnAbrirMenu.BackgroundImage");
            btnAbrirMenu.BackgroundImageLayout = ImageLayout.Zoom;
            btnAbrirMenu.Dock = DockStyle.Left;
            btnAbrirMenu.FlatAppearance.BorderSize = 0;
            btnAbrirMenu.FlatStyle = FlatStyle.Flat;
            btnAbrirMenu.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAbrirMenu.ForeColor = Color.FromArgb(167, 191, 211);
            btnAbrirMenu.ImageAlign = ContentAlignment.MiddleLeft;
            btnAbrirMenu.Location = new Point(0, 0);
            btnAbrirMenu.Name = "btnAbrirMenu";
            btnAbrirMenu.Padding = new Padding(28, 0, 0, 0);
            btnAbrirMenu.Size = new Size(100, 65);
            btnAbrirMenu.TabIndex = 2;
            btnAbrirMenu.TextAlign = ContentAlignment.MiddleLeft;
            btnAbrirMenu.UseVisualStyleBackColor = false;
            btnAbrirMenu.Click += btnAbrirMenu_Click;
            // 
            // panelFormHijo
            // 
            panelFormHijo.BackColor = Color.White;
            panelFormHijo.Controls.Add(tableLayoutPanel1);
            panelFormHijo.Controls.Add(pbxCalculadora);
            panelFormHijo.Controls.Add(lblHora);
            panelFormHijo.Controls.Add(lblFecha);
            panelFormHijo.Dock = DockStyle.Fill;
            panelFormHijo.Location = new Point(300, 65);
            panelFormHijo.Name = "panelFormHijo";
            panelFormHijo.Size = new Size(934, 696);
            panelFormHijo.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(chart1, 0, 0);
            tableLayoutPanel1.Controls.Add(chart2, 1, 0);
            tableLayoutPanel1.Location = new Point(20, 380);
            tableLayoutPanel1.MaximumSize = new Size(1550, 450);
            tableLayoutPanel1.MinimumSize = new Size(550, 200);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(892, 261);
            tableLayoutPanel1.TabIndex = 35;
            // 
            // chart1
            // 
            chart1.BackColor = Color.FromArgb(189, 215, 238);
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            chart1.Dock = DockStyle.Fill;
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(20, 20);
            chart1.Margin = new Padding(20);
            chart1.Name = "chart1";
            chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(406, 221);
            chart1.TabIndex = 0;
            chart1.Text = "chart1";
            // 
            // chart2
            // 
            chart2.BackColor = Color.FromArgb(189, 215, 238);
            chartArea2.Name = "ChartArea1";
            chart2.ChartAreas.Add(chartArea2);
            chart2.Dock = DockStyle.Fill;
            legend2.Name = "Legend1";
            chart2.Legends.Add(legend2);
            chart2.Location = new Point(466, 20);
            chart2.Margin = new Padding(20);
            chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            series2.YValuesPerPoint = 4;
            chart2.Series.Add(series2);
            chart2.Size = new Size(406, 221);
            chart2.TabIndex = 0;
            chart2.Text = "chart1";
            // 
            // pbxCalculadora
            // 
            pbxCalculadora.Image = Properties.Resources.calculadora;
            pbxCalculadora.Location = new Point(34, 34);
            pbxCalculadora.Margin = new Padding(10);
            pbxCalculadora.Name = "pbxCalculadora";
            pbxCalculadora.Size = new Size(86, 100);
            pbxCalculadora.SizeMode = PictureBoxSizeMode.Zoom;
            pbxCalculadora.TabIndex = 6;
            pbxCalculadora.TabStop = false;
            pbxCalculadora.Click += pbxCalculadora_Click;
            pbxCalculadora.MouseDown += pbxCalculadora_MouseDown;
            pbxCalculadora.MouseUp += pbxCalculadora_MouseUp;
            // 
            // lblHora
            // 
            lblHora.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblHora.AutoSize = true;
            lblHora.Font = new Font("Itim", 14.25F);
            lblHora.ForeColor = Color.DimGray;
            lblHora.Location = new Point(20, 644);
            lblHora.Name = "lblHora";
            lblHora.RightToLeft = RightToLeft.Yes;
            lblHora.Size = new Size(76, 29);
            lblHora.TabIndex = 34;
            lblHora.Text = "label3";
            lblHora.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblFecha
            // 
            lblFecha.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Itim", 14.25F);
            lblFecha.ForeColor = Color.DimGray;
            lblFecha.Location = new Point(20, 667);
            lblFecha.Name = "lblFecha";
            lblFecha.RightToLeft = RightToLeft.Yes;
            lblFecha.Size = new Size(76, 29);
            lblFecha.TabIndex = 33;
            lblFecha.Text = "label3";
            lblFecha.TextAlign = ContentAlignment.MiddleRight;
            // 
            // timerAbrir
            // 
            timerAbrir.Interval = 8;
            timerAbrir.Tick += timerAbrir_Tick;
            // 
            // timerCerrar
            // 
            timerCerrar.Interval = 8;
            timerCerrar.Tick += timerCerrar_Tick;
            // 
            // panelNotificaciones
            // 
            panelNotificaciones.BackColor = Color.FromArgb(167, 191, 211);
            panelNotificaciones.BackgroundImageLayout = ImageLayout.Center;
            panelNotificaciones.Controls.Add(lblNotificaciones);
            panelNotificaciones.Dock = DockStyle.Right;
            panelNotificaciones.Location = new Point(1234, 65);
            panelNotificaciones.Name = "panelNotificaciones";
            panelNotificaciones.Size = new Size(0, 696);
            panelNotificaciones.TabIndex = 3;
            // 
            // lblNotificaciones
            // 
            lblNotificaciones.AutoSize = true;
            lblNotificaciones.Font = new Font("Itim", 14F);
            lblNotificaciones.ForeColor = Color.FromArgb(148, 168, 187);
            lblNotificaciones.Location = new Point(24, 408);
            lblNotificaciones.Name = "lblNotificaciones";
            lblNotificaciones.Size = new Size(392, 29);
            lblNotificaciones.TabIndex = 0;
            lblNotificaciones.Text = "No tienes notificaciones pendientes...";
            // 
            // HoraFecha
            // 
            HoraFecha.Enabled = true;
            HoraFecha.Tick += HoraFecha_Tick;
            // 
            // frmMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(1234, 761);
            Controls.Add(panelNotificaciones);
            Controls.Add(panelFormHijo);
            Controls.Add(panBarraControl);
            Controls.Add(panelMenuLateral);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 10F);
            MinimumSize = new Size(900, 500);
            Name = "frmMenuPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "  ";
            Load += Form1_Load;
            panBarraControl.ResumeLayout(false);
            panBarraControl.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelMenuLateral.ResumeLayout(false);
            panelMenuLateral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelReporteria.ResumeLayout(false);
            panelUsuarios.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panelVentas.ResumeLayout(false);
            panelCompras.ResumeLayout(false);
            panelInventario.ResumeLayout(false);
            panelMneuLateral.ResumeLayout(false);
            panelFormHijo.ResumeLayout(false);
            panelFormHijo.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxCalculadora).EndInit();
            panelNotificaciones.ResumeLayout(false);
            panelNotificaciones.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenuLateral;
        private Panel panelInventario;
        private Button btnGestionInventario;
        private Panel panelVentas;
        private Button btnClientes;
        private Button btnGestionVentas;
        private Panel panelCompras;
        private Button btnProveedores;
        private Button btnGestionCompra;
        private Panel panelUsuarios;
        private Button btnGestionUsuarios;
        private Button btnGestionEmpleados;
        private Panel panelReporteria;
        private Button btnReportesCreados;
        private Button btnCrearReporte;
        private Button btnGestionRoles;
        private Panel panelMneuLateral;
        private Button btnInventarioBodega;
        private Button btnBitacora;
        private Panel panBarraControl;
        private Button btnAbrirMenu;
        private Button btnAjustes;
        private Panel panelFormHijo;
        public Label lblNombreModulo;
        private Panel panel2;
        private Label lblRol;
        private Label lblUsuario;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private System.Windows.Forms.Timer timerAbrir;
        private System.Windows.Forms.Timer timerCerrar;
        private Panel panelNotificaciones;
        private Panel panel1;
        private Label lblNotificaciones;
        private Button btnNotificaciones;
        private Panel panel3;
        private Button btnMinimizar;
        private Button btnMiniMaxi;
        private Button btnCerrar;
        private System.Windows.Forms.Timer HoraFecha;
        private PictureBox pbxCalculadora;
        private Button btnCierreDiario;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private Label lblFecha;
        private Label lblHora;
        private Button btnDevoluciones;
        private Button btnRegistroPerdida;
        private Label lblEstadoConexion;
        private Panel panel6;
        private Panel panel9;
        private Panel panel12;
        private controlBotonesMenuPrincipal btnPrueba;
        private controlBotonesMenuPrincipal btnInventario;
        private controlBotonesMenuPrincipal btnReporteria;
        private controlBotonesMenuPrincipal btnUsuario;
        private controlBotonesMenuPrincipal btnVenta;
        private controlBotonesMenuPrincipal botonesMenuPrincipal1;
        private Panel panDiv;
        private controlBotonesMenuPrincipal btnCompra;
        private Panel pnlDivisorCompras;
        private Panel pnlDivisorVentas;
        private Panel pnlDivisorUsuario;
        private Panel pnlDivisorInventario;
        private Panel pnlDivisorReporteria;
        private controlBotonesMenuPrincipal btnUsuarios;
        private controlBotonesMenuPrincipal btnVentas;
        private controlBotonesMenuPrincipal btnCompras;
        private controlBotonesMenuPrincipal btnReporte;
        private controlBotonesMenuPrincipal btnInventarios;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnMarcas;
        private Label lblBodega;
        private Button btnCategorias;
        private Button btnPresentaciones;
        private Button btnBodegas;
    }
}
