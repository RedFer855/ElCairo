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
            panel2 = new Panel();
            label2 = new Label();
            lblUsuario = new Label();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panelReporteria = new Panel();
            btnReportesCreados = new Button();
            btnCrearReporte = new Button();
            btnReporteria = new Button();
            panelUsuarios = new Panel();
            btnBitacora = new Button();
            btnAcciones = new Button();
            btnGestionRoles = new Button();
            btnGestionUsuarios = new Button();
            btnGestionEmpleados = new Button();
            btnUsuarios = new Button();
            panelVentas = new Panel();
            btnDevoluciones = new Button();
            btnCierreDiario = new Button();
            btnClientes = new Button();
            btnGestionVentas = new Button();
            btnVentas = new Button();
            panelCompras = new Panel();
            btnProveedores = new Button();
            btnGestionCompra = new Button();
            btnCompras = new Button();
            panelInventario = new Panel();
            btnRegistroPerdida = new Button();
            btnInventarioBodega = new Button();
            btnGestionInventario = new Button();
            btnInventario = new Button();
            panelMneuLateral = new Panel();
            btnAbrirMenu = new Button();
            panelFormHijo = new Panel();
            lblHora = new Label();
            lblFecha = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel8 = new Panel();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            panel10 = new Panel();
            chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel5 = new Panel();
            panel11 = new Panel();
            panel7 = new Panel();
            panel4 = new Panel();
            pbxCalculadora = new PictureBox();
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
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelReporteria.SuspendLayout();
            panelUsuarios.SuspendLayout();
            panelVentas.SuspendLayout();
            panelCompras.SuspendLayout();
            panelInventario.SuspendLayout();
            panelMneuLateral.SuspendLayout();
            panelFormHijo.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chart2).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panel4.SuspendLayout();
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
            panBarraControl.Size = new Size(928, 65);
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
            panel6.Location = new Point(795, 0);
            panel6.Name = "panel6";
            panel6.RightToLeft = RightToLeft.Yes;
            panel6.Size = new Size(68, 65);
            panel6.TabIndex = 11;
            // 
            // lblEstadoConexion
            // 
            lblEstadoConexion.AutoSize = true;
            lblEstadoConexion.BackColor = Color.Transparent;
            lblEstadoConexion.Dock = DockStyle.Fill;
            lblEstadoConexion.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEstadoConexion.ForeColor = Color.Black;
            lblEstadoConexion.Location = new Point(0, 26);
            lblEstadoConexion.Name = "lblEstadoConexion";
            lblEstadoConexion.RightToLeft = RightToLeft.Yes;
            lblEstadoConexion.Size = new Size(68, 24);
            lblEstadoConexion.TabIndex = 3;
            lblEstadoConexion.Text = "Estado";
            // 
            // panel12
            // 
            panel12.Dock = DockStyle.Bottom;
            panel12.Location = new Point(0, 48);
            panel12.Name = "panel12";
            panel12.Size = new Size(68, 17);
            panel12.TabIndex = 15;
            // 
            // panel9
            // 
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(0, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(68, 26);
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
            btnNotificaciones.Location = new Point(863, 0);
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
            panel3.Location = new Point(928, 0);
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
            btnMinimizar.Location = new Point(928, 0);
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
            btnMiniMaxi.Location = new Point(928, 0);
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
            btnCerrar.Location = new Point(928, 0);
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
            panelMenuLateral.Controls.Add(panel2);
            panelMenuLateral.Controls.Add(pictureBox1);
            panelMenuLateral.Controls.Add(panelReporteria);
            panelMenuLateral.Controls.Add(btnReporteria);
            panelMenuLateral.Controls.Add(panelUsuarios);
            panelMenuLateral.Controls.Add(btnUsuarios);
            panelMenuLateral.Controls.Add(panelVentas);
            panelMenuLateral.Controls.Add(btnVentas);
            panelMenuLateral.Controls.Add(panelCompras);
            panelMenuLateral.Controls.Add(btnCompras);
            panelMenuLateral.Controls.Add(panelInventario);
            panelMenuLateral.Controls.Add(btnInventario);
            panelMenuLateral.Controls.Add(panelMneuLateral);
            panelMenuLateral.Dock = DockStyle.Left;
            panelMenuLateral.Location = new Point(0, 0);
            panelMenuLateral.Name = "panelMenuLateral";
            panelMenuLateral.Size = new Size(300, 741);
            panelMenuLateral.TabIndex = 0;
            panelMenuLateral.MouseDown += panelMenuLateral_MouseDown;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(167, 191, 211);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(lblUsuario);
            panel2.Controls.Add(pictureBox2);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 1280);
            panel2.Name = "panel2";
            panel2.Size = new Size(279, 80);
            panel2.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(104, 39);
            label2.Name = "label2";
            label2.Size = new Size(99, 23);
            label2.TabIndex = 10;
            label2.Text = "Rol: Admin";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsuario.ForeColor = Color.White;
            lblUsuario.Location = new Point(104, 13);
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
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(0, 1105);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(279, 175);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panelReporteria
            // 
            panelReporteria.BackColor = Color.FromArgb(238, 238, 238);
            panelReporteria.Controls.Add(btnReportesCreados);
            panelReporteria.Controls.Add(btnCrearReporte);
            panelReporteria.Dock = DockStyle.Top;
            panelReporteria.Location = new Point(0, 1025);
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
            // btnReporteria
            // 
            btnReporteria.BackColor = Color.FromArgb(189, 215, 238);
            btnReporteria.Dock = DockStyle.Top;
            btnReporteria.FlatAppearance.BorderColor = Color.White;
            btnReporteria.FlatStyle = FlatStyle.Flat;
            btnReporteria.Font = new Font("Itim", 17.2499981F);
            btnReporteria.ForeColor = Color.FromArgb(87, 99, 110);
            btnReporteria.Image = (Image)resources.GetObject("btnReporteria.Image");
            btnReporteria.ImageAlign = ContentAlignment.MiddleLeft;
            btnReporteria.Location = new Point(0, 945);
            btnReporteria.Name = "btnReporteria";
            btnReporteria.Padding = new Padding(30, 0, 0, 0);
            btnReporteria.Size = new Size(279, 80);
            btnReporteria.TabIndex = 9;
            btnReporteria.Text = "            Reportería";
            btnReporteria.TextAlign = ContentAlignment.MiddleLeft;
            btnReporteria.UseVisualStyleBackColor = false;
            btnReporteria.Click += btnReporteria_Click;
            // 
            // panelUsuarios
            // 
            panelUsuarios.BackColor = Color.FromArgb(238, 238, 238);
            panelUsuarios.Controls.Add(btnBitacora);
            panelUsuarios.Controls.Add(btnAcciones);
            panelUsuarios.Controls.Add(btnGestionRoles);
            panelUsuarios.Controls.Add(btnGestionUsuarios);
            panelUsuarios.Controls.Add(btnGestionEmpleados);
            panelUsuarios.Dock = DockStyle.Top;
            panelUsuarios.Location = new Point(0, 745);
            panelUsuarios.Name = "panelUsuarios";
            panelUsuarios.Size = new Size(279, 200);
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
            btnBitacora.Location = new Point(0, 160);
            btnBitacora.Name = "btnBitacora";
            btnBitacora.Padding = new Padding(20, 0, 0, 0);
            btnBitacora.Size = new Size(279, 40);
            btnBitacora.TabIndex = 7;
            btnBitacora.Text = "Bitacora";
            btnBitacora.TextAlign = ContentAlignment.MiddleLeft;
            btnBitacora.UseVisualStyleBackColor = false;
            btnBitacora.Click += btnBitacora_Click;
            // 
            // btnAcciones
            // 
            btnAcciones.BackColor = Color.FromArgb(202, 223, 255);
            btnAcciones.Dock = DockStyle.Top;
            btnAcciones.FlatAppearance.BorderColor = Color.White;
            btnAcciones.FlatStyle = FlatStyle.Flat;
            btnAcciones.Font = new Font("Itim", 11.25F);
            btnAcciones.ForeColor = Color.FromArgb(87, 99, 110);
            btnAcciones.Location = new Point(0, 120);
            btnAcciones.Name = "btnAcciones";
            btnAcciones.Padding = new Padding(20, 0, 0, 0);
            btnAcciones.Size = new Size(279, 40);
            btnAcciones.TabIndex = 5;
            btnAcciones.Text = "Lista de Acciones";
            btnAcciones.TextAlign = ContentAlignment.MiddleLeft;
            btnAcciones.UseVisualStyleBackColor = false;
            btnAcciones.Click += btnAcciones_Click;
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
            btnUsuarios.Dock = DockStyle.Top;
            btnUsuarios.FlatAppearance.BorderColor = Color.White;
            btnUsuarios.FlatStyle = FlatStyle.Flat;
            btnUsuarios.Font = new Font("Itim", 17.2499981F);
            btnUsuarios.ForeColor = Color.FromArgb(87, 99, 110);
            btnUsuarios.Image = (Image)resources.GetObject("btnUsuarios.Image");
            btnUsuarios.ImageAlign = ContentAlignment.MiddleLeft;
            btnUsuarios.Location = new Point(0, 665);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Padding = new Padding(30, 0, 0, 0);
            btnUsuarios.Size = new Size(279, 80);
            btnUsuarios.TabIndex = 7;
            btnUsuarios.Text = "            Usuarios";
            btnUsuarios.TextAlign = ContentAlignment.MiddleLeft;
            btnUsuarios.UseVisualStyleBackColor = false;
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // panelVentas
            // 
            panelVentas.BackColor = Color.FromArgb(238, 238, 238);
            panelVentas.Controls.Add(btnDevoluciones);
            panelVentas.Controls.Add(btnCierreDiario);
            panelVentas.Controls.Add(btnClientes);
            panelVentas.Controls.Add(btnGestionVentas);
            panelVentas.Dock = DockStyle.Top;
            panelVentas.Location = new Point(0, 505);
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
            btnVentas.Dock = DockStyle.Top;
            btnVentas.FlatAppearance.BorderColor = Color.White;
            btnVentas.FlatStyle = FlatStyle.Flat;
            btnVentas.Font = new Font("Itim", 17.2499981F);
            btnVentas.ForeColor = Color.FromArgb(87, 99, 110);
            btnVentas.Image = (Image)resources.GetObject("btnVentas.Image");
            btnVentas.ImageAlign = ContentAlignment.MiddleLeft;
            btnVentas.Location = new Point(0, 425);
            btnVentas.Name = "btnVentas";
            btnVentas.Padding = new Padding(30, 0, 0, 0);
            btnVentas.Size = new Size(279, 80);
            btnVentas.TabIndex = 5;
            btnVentas.Text = "            Ventas";
            btnVentas.TextAlign = ContentAlignment.MiddleLeft;
            btnVentas.UseVisualStyleBackColor = false;
            btnVentas.Click += btnVentas_Click;
            // 
            // panelCompras
            // 
            panelCompras.BackColor = Color.FromArgb(238, 238, 238);
            panelCompras.Controls.Add(btnProveedores);
            panelCompras.Controls.Add(btnGestionCompra);
            panelCompras.Dock = DockStyle.Top;
            panelCompras.Location = new Point(0, 345);
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
            btnCompras.Dock = DockStyle.Top;
            btnCompras.FlatAppearance.BorderColor = Color.White;
            btnCompras.FlatStyle = FlatStyle.Flat;
            btnCompras.Font = new Font("Itim", 17.2499981F);
            btnCompras.ForeColor = Color.FromArgb(87, 99, 110);
            btnCompras.Image = (Image)resources.GetObject("btnCompras.Image");
            btnCompras.ImageAlign = ContentAlignment.MiddleLeft;
            btnCompras.Location = new Point(0, 265);
            btnCompras.Name = "btnCompras";
            btnCompras.Padding = new Padding(30, 0, 0, 0);
            btnCompras.Size = new Size(279, 80);
            btnCompras.TabIndex = 3;
            btnCompras.Text = "            Compras";
            btnCompras.TextAlign = ContentAlignment.MiddleLeft;
            btnCompras.UseVisualStyleBackColor = false;
            btnCompras.Click += btnCompras_Click;
            // 
            // panelInventario
            // 
            panelInventario.BackColor = Color.FromArgb(238, 238, 238);
            panelInventario.Controls.Add(btnRegistroPerdida);
            panelInventario.Controls.Add(btnInventarioBodega);
            panelInventario.Controls.Add(btnGestionInventario);
            panelInventario.Dock = DockStyle.Top;
            panelInventario.Location = new Point(0, 145);
            panelInventario.Name = "panelInventario";
            panelInventario.Size = new Size(279, 120);
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
            btnRegistroPerdida.Location = new Point(0, 80);
            btnRegistroPerdida.Name = "btnRegistroPerdida";
            btnRegistroPerdida.Padding = new Padding(20, 0, 0, 0);
            btnRegistroPerdida.Size = new Size(279, 40);
            btnRegistroPerdida.TabIndex = 3;
            btnRegistroPerdida.Text = "Perdidas";
            btnRegistroPerdida.TextAlign = ContentAlignment.MiddleLeft;
            btnRegistroPerdida.UseVisualStyleBackColor = false;
            btnRegistroPerdida.Click += btnRegistroPerdida_Click;
            // 
            // btnInventarioBodega
            // 
            btnInventarioBodega.BackColor = Color.FromArgb(202, 223, 255);
            btnInventarioBodega.Dock = DockStyle.Top;
            btnInventarioBodega.FlatAppearance.BorderColor = Color.White;
            btnInventarioBodega.FlatStyle = FlatStyle.Flat;
            btnInventarioBodega.Font = new Font("Itim", 11.25F);
            btnInventarioBodega.ForeColor = Color.FromArgb(87, 99, 110);
            btnInventarioBodega.Location = new Point(0, 40);
            btnInventarioBodega.Name = "btnInventarioBodega";
            btnInventarioBodega.Padding = new Padding(20, 0, 0, 0);
            btnInventarioBodega.Size = new Size(279, 40);
            btnInventarioBodega.TabIndex = 2;
            btnInventarioBodega.Text = "Inventario de Bodegas";
            btnInventarioBodega.TextAlign = ContentAlignment.MiddleLeft;
            btnInventarioBodega.UseVisualStyleBackColor = false;
            btnInventarioBodega.Click += btnInventarioBodega_Click;
            // 
            // btnGestionInventario
            // 
            btnGestionInventario.BackColor = Color.FromArgb(202, 223, 255);
            btnGestionInventario.Dock = DockStyle.Top;
            btnGestionInventario.FlatAppearance.BorderColor = Color.White;
            btnGestionInventario.FlatStyle = FlatStyle.Flat;
            btnGestionInventario.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGestionInventario.ForeColor = Color.FromArgb(87, 99, 110);
            btnGestionInventario.Location = new Point(0, 0);
            btnGestionInventario.Name = "btnGestionInventario";
            btnGestionInventario.Padding = new Padding(20, 0, 0, 0);
            btnGestionInventario.Size = new Size(279, 40);
            btnGestionInventario.TabIndex = 0;
            btnGestionInventario.Text = "Productos";
            btnGestionInventario.TextAlign = ContentAlignment.MiddleLeft;
            btnGestionInventario.UseVisualStyleBackColor = false;
            btnGestionInventario.Click += btnGestionInventario_Click;
            // 
            // btnInventario
            // 
            btnInventario.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnInventario.BackColor = Color.FromArgb(189, 215, 238);
            btnInventario.Dock = DockStyle.Top;
            btnInventario.FlatAppearance.BorderColor = Color.White;
            btnInventario.FlatStyle = FlatStyle.Flat;
            btnInventario.Font = new Font("Itim", 17.2499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnInventario.ForeColor = Color.FromArgb(87, 99, 110);
            btnInventario.Image = (Image)resources.GetObject("btnInventario.Image");
            btnInventario.ImageAlign = ContentAlignment.MiddleLeft;
            btnInventario.Location = new Point(0, 65);
            btnInventario.Name = "btnInventario";
            btnInventario.Padding = new Padding(30, 0, 0, 0);
            btnInventario.Size = new Size(279, 80);
            btnInventario.TabIndex = 1;
            btnInventario.Text = "            Inventario";
            btnInventario.TextAlign = ContentAlignment.MiddleLeft;
            btnInventario.UseVisualStyleBackColor = false;
            btnInventario.Click += btnInventario_Click;
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
            btnAbrirMenu.Dock = DockStyle.Left;
            btnAbrirMenu.FlatAppearance.BorderSize = 0;
            btnAbrirMenu.FlatStyle = FlatStyle.Flat;
            btnAbrirMenu.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAbrirMenu.ForeColor = Color.FromArgb(167, 191, 211);
            btnAbrirMenu.Image = (Image)resources.GetObject("btnAbrirMenu.Image");
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
            panelFormHijo.Controls.Add(lblHora);
            panelFormHijo.Controls.Add(lblFecha);
            panelFormHijo.Controls.Add(flowLayoutPanel1);
            panelFormHijo.Dock = DockStyle.Fill;
            panelFormHijo.Location = new Point(300, 65);
            panelFormHijo.Name = "panelFormHijo";
            panelFormHijo.Size = new Size(928, 676);
            panelFormHijo.TabIndex = 2;
            // 
            // lblHora
            // 
            lblHora.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblHora.AutoSize = true;
            lblHora.Font = new Font("Itim", 14.25F);
            lblHora.ForeColor = Color.DimGray;
            lblHora.Location = new Point(6, 624);
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
            lblFecha.Location = new Point(6, 647);
            lblFecha.Name = "lblFecha";
            lblFecha.RightToLeft = RightToLeft.Yes;
            lblFecha.Size = new Size(76, 29);
            lblFecha.TabIndex = 33;
            lblFecha.Text = "label3";
            lblFecha.TextAlign = ContentAlignment.MiddleRight;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.Controls.Add(tableLayoutPanel2);
            flowLayoutPanel1.Controls.Add(tableLayoutPanel1);
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(928, 612);
            flowLayoutPanel1.TabIndex = 32;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(panel8, 0, 0);
            tableLayoutPanel2.Controls.Add(panel10, 1, 0);
            tableLayoutPanel2.Location = new Point(10, 10);
            tableLayoutPanel2.Margin = new Padding(10);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(904, 310);
            tableLayoutPanel2.TabIndex = 14;
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(189, 215, 238);
            panel8.Controls.Add(chart1);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(10, 10);
            panel8.Margin = new Padding(10);
            panel8.Name = "panel8";
            panel8.Size = new Size(432, 290);
            panel8.TabIndex = 11;
            // 
            // chart1
            // 
            chart1.BackColor = Color.FromArgb(189, 215, 238);
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            chart1.Dock = DockStyle.Fill;
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(0, 0);
            chart1.Name = "chart1";
            chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(432, 290);
            chart1.TabIndex = 0;
            chart1.Text = "chart1";
            // 
            // panel10
            // 
            panel10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel10.BackColor = Color.FromArgb(189, 215, 238);
            panel10.Controls.Add(chart2);
            panel10.Location = new Point(462, 10);
            panel10.Margin = new Padding(10);
            panel10.Name = "panel10";
            panel10.Size = new Size(432, 290);
            panel10.TabIndex = 12;
            // 
            // chart2
            // 
            chart2.BackColor = Color.FromArgb(189, 215, 238);
            chartArea2.Name = "ChartArea1";
            chart2.ChartAreas.Add(chartArea2);
            chart2.Dock = DockStyle.Fill;
            legend2.Name = "Legend1";
            chart2.Legends.Add(legend2);
            chart2.Location = new Point(0, 0);
            chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            series2.YValuesPerPoint = 4;
            chart2.Series.Add(series2);
            chart2.Size = new Size(432, 290);
            chart2.TabIndex = 0;
            chart2.Text = "chart1";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel5, 1, 0);
            tableLayoutPanel1.Controls.Add(panel11, 1, 1);
            tableLayoutPanel1.Controls.Add(panel7, 0, 1);
            tableLayoutPanel1.Controls.Add(panel4, 0, 0);
            tableLayoutPanel1.Location = new Point(10, 340);
            tableLayoutPanel1.Margin = new Padding(10);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(637, 242);
            tableLayoutPanel1.TabIndex = 13;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(189, 215, 238);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(328, 10);
            panel5.Margin = new Padding(10);
            panel5.Name = "panel5";
            panel5.Size = new Size(299, 101);
            panel5.TabIndex = 8;
            // 
            // panel11
            // 
            panel11.BackColor = Color.FromArgb(189, 215, 238);
            panel11.Dock = DockStyle.Fill;
            panel11.Location = new Point(328, 131);
            panel11.Margin = new Padding(10);
            panel11.Name = "panel11";
            panel11.Size = new Size(299, 101);
            panel11.TabIndex = 11;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(189, 215, 238);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(10, 131);
            panel7.Margin = new Padding(10);
            panel7.Name = "panel7";
            panel7.Size = new Size(298, 101);
            panel7.TabIndex = 9;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(189, 215, 238);
            panel4.Controls.Add(pbxCalculadora);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(10, 10);
            panel4.Margin = new Padding(10);
            panel4.Name = "panel4";
            panel4.Size = new Size(298, 101);
            panel4.TabIndex = 7;
            // 
            // pbxCalculadora
            // 
            pbxCalculadora.Image = Properties.Resources.calculadora;
            pbxCalculadora.Location = new Point(0, 0);
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
            panelNotificaciones.Location = new Point(1228, 65);
            panelNotificaciones.Name = "panelNotificaciones";
            panelNotificaciones.Size = new Size(0, 676);
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
            ClientSize = new Size(1228, 741);
            Controls.Add(panelNotificaciones);
            Controls.Add(panelFormHijo);
            Controls.Add(panBarraControl);
            Controls.Add(panelMenuLateral);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 10F);
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
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelReporteria.ResumeLayout(false);
            panelUsuarios.ResumeLayout(false);
            panelVentas.ResumeLayout(false);
            panelCompras.ResumeLayout(false);
            panelInventario.ResumeLayout(false);
            panelMneuLateral.ResumeLayout(false);
            panelFormHijo.ResumeLayout(false);
            panelFormHijo.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chart2).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbxCalculadora).EndInit();
            panelNotificaciones.ResumeLayout(false);
            panelNotificaciones.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenuLateral;
        private Panel panelInventario;
        private Button btnGestionInventario;
        private Button btnInventario;
        private Panel panelVentas;
        private Button btnClientes;
        private Button btnGestionVentas;
        private Button btnVentas;
        private Panel panelCompras;
        private Button btnProveedores;
        private Button btnGestionCompra;
        private Button btnCompras;
        private Button btnReporteria;
        private Panel panelUsuarios;
        private Button btnGestionUsuarios;
        private Button btnGestionEmpleados;
        private Button btnUsuarios;
        private Panel panelReporteria;
        private Button btnReportesCreados;
        private Button btnCrearReporte;
        private Button btnAcciones;
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
        private Label label2;
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
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnCierreDiario;
        private Panel panel4;
        private Panel panel5;
        private Panel panel7;
        private Panel panel8;
        private Panel panel11;
        private Panel panel10;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private Label lblFecha;
        private Label lblHora;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button btnDevoluciones;
        private Button btnRegistroPerdida;
        private Label lblEstadoConexion;
        private Panel panel6;
        private Panel panel9;
        private Panel panel12;
    }
}
