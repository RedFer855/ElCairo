namespace ModernMenuUI
{
    partial class MenuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipal));
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
            label1 = new Label();
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
            btnClientes = new Button();
            btnGestionVentas = new Button();
            btnVentas = new Button();
            panelCompras = new Panel();
            btnProveedores = new Button();
            btnGestionCompra = new Button();
            btnCompras = new Button();
            panelInventario = new Panel();
            btnInventarioBodega = new Button();
            btnGestionInventario = new Button();
            btnInventario = new Button();
            panelMneuLateral = new Panel();
            btnAbrirMenu = new Button();
            panelFormHijo = new Panel();
            timerAbrir = new System.Windows.Forms.Timer(components);
            timerCerrar = new System.Windows.Forms.Timer(components);
            panelNotificaciones = new Panel();
            lblNotificaciones = new Label();
            panBarraControl = new Panel();
            panBarraControl.SuspendLayout();
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
            panelNotificaciones.SuspendLayout();
            SuspendLayout();
            // 
            // panBarraControl
            // 
            panBarraControl.BackColor = Color.FromArgb(148, 168, 187);
            panBarraControl.Controls.Add(btnNotificaciones);
            panBarraControl.Controls.Add(panel3);
            panBarraControl.Controls.Add(panel1);
            panBarraControl.Controls.Add(btnAjustes);
            panBarraControl.Controls.Add(btnMinimizar);
            panBarraControl.Controls.Add(btnMiniMaxi);
            panBarraControl.Controls.Add(btnCerrar);
            panBarraControl.Dock = DockStyle.Top;
            panBarraControl.ForeColor = Color.Coral;
            panBarraControl.Location = new Point(260, 0);
            panBarraControl.Name = "panBarraControl";
            panBarraControl.Size = new Size(764, 65);
            panBarraControl.TabIndex = 1;
            panBarraControl.MouseDown += panBarraControl_MouseDown;
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
            btnNotificaciones.Location = new Point(414, 0);
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
            panel3.Location = new Point(479, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(90, 65);
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
            lblNombreModulo.Location = new Point(3, 15);
            lblNombreModulo.Name = "lblNombreModulo";
            lblNombreModulo.Size = new Size(200, 29);
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
            btnMinimizar.Image = Properties.Resources.minimizar_signo;
            btnMinimizar.ImageAlign = ContentAlignment.MiddleLeft;
            btnMinimizar.Location = new Point(569, 0);
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.Padding = new Padding(11, 0, 0, 0);
            btnMinimizar.Size = new Size(65, 65);
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
            btnMiniMaxi.Image = Properties.Resources.cuadrado_en_blanco__1_;
            btnMiniMaxi.ImageAlign = ContentAlignment.MiddleLeft;
            btnMiniMaxi.Location = new Point(634, 0);
            btnMiniMaxi.Name = "btnMiniMaxi";
            btnMiniMaxi.Padding = new Padding(11, 0, 0, 0);
            btnMiniMaxi.Size = new Size(65, 65);
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
            btnCerrar.Location = new Point(699, 0);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Padding = new Padding(11, 0, 0, 0);
            btnCerrar.Size = new Size(65, 65);
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
            panelMenuLateral.Size = new Size(260, 728);
            panelMenuLateral.TabIndex = 0;
            panelMenuLateral.MouseDown += panelMenuLateral_MouseDown;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(167, 191, 211);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(pictureBox2);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 1160);
            panel2.Name = "panel2";
            panel2.Size = new Size(243, 80);
            panel2.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(104, 39);
            label2.Name = "label2";
            label2.Size = new Size(87, 18);
            label2.TabIndex = 10;
            label2.Text = "Rol: Admin";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(104, 13);
            label1.Name = "label1";
            label1.Size = new Size(136, 16);
            label1.TabIndex = 9;
            label1.Text = "Fernando Barahona";
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
            pictureBox1.Location = new Point(0, 985);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(243, 175);
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
            panelReporteria.Location = new Point(0, 905);
            panelReporteria.Name = "panelReporteria";
            panelReporteria.Size = new Size(243, 80);
            panelReporteria.TabIndex = 10;
            // 
            // btnReportesCreados
            // 
            btnReportesCreados.Dock = DockStyle.Top;
            btnReportesCreados.FlatAppearance.BorderSize = 0;
            btnReportesCreados.Font = new Font("Segoe UI", 11.25F);
            btnReportesCreados.ForeColor = Color.FromArgb(87, 99, 110);
            btnReportesCreados.Location = new Point(0, 40);
            btnReportesCreados.Name = "btnReportesCreados";
            btnReportesCreados.Padding = new Padding(20, 0, 0, 0);
            btnReportesCreados.Size = new Size(243, 40);
            btnReportesCreados.TabIndex = 1;
            btnReportesCreados.Text = "Reportes Creados";
            btnReportesCreados.TextAlign = ContentAlignment.MiddleLeft;
            btnReportesCreados.UseVisualStyleBackColor = true;
            btnReportesCreados.Click += btnReportesCreados_Click;
            // 
            // btnCrearReporte
            // 
            btnCrearReporte.Dock = DockStyle.Top;
            btnCrearReporte.FlatAppearance.BorderSize = 0;
            btnCrearReporte.Font = new Font("Segoe UI", 11.25F);
            btnCrearReporte.ForeColor = Color.FromArgb(87, 99, 110);
            btnCrearReporte.Location = new Point(0, 0);
            btnCrearReporte.Name = "btnCrearReporte";
            btnCrearReporte.Padding = new Padding(20, 0, 0, 0);
            btnCrearReporte.Size = new Size(243, 40);
            btnCrearReporte.TabIndex = 0;
            btnCrearReporte.Text = "Crear Reporte";
            btnCrearReporte.TextAlign = ContentAlignment.MiddleLeft;
            btnCrearReporte.UseVisualStyleBackColor = true;
            btnCrearReporte.Click += btnCrearReporte_Click;
            // 
            // btnReporteria
            // 
            btnReporteria.BackColor = Color.FromArgb(189, 215, 238);
            btnReporteria.Dock = DockStyle.Top;
            btnReporteria.FlatAppearance.BorderSize = 0;
            btnReporteria.Font = new Font("Itim", 17.2499981F);
            btnReporteria.ForeColor = Color.FromArgb(87, 99, 110);
            btnReporteria.Image = (Image)resources.GetObject("btnReporteria.Image");
            btnReporteria.ImageAlign = ContentAlignment.MiddleLeft;
            btnReporteria.Location = new Point(0, 825);
            btnReporteria.Name = "btnReporteria";
            btnReporteria.Padding = new Padding(30, 0, 0, 0);
            btnReporteria.Size = new Size(243, 80);
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
            panelUsuarios.Location = new Point(0, 625);
            panelUsuarios.Name = "panelUsuarios";
            panelUsuarios.Size = new Size(243, 200);
            panelUsuarios.TabIndex = 8;
            // 
            // btnBitacora
            // 
            btnBitacora.Dock = DockStyle.Top;
            btnBitacora.FlatAppearance.BorderSize = 0;
            btnBitacora.Font = new Font("Segoe UI", 11.25F);
            btnBitacora.ForeColor = Color.FromArgb(87, 99, 110);
            btnBitacora.Location = new Point(0, 160);
            btnBitacora.Name = "btnBitacora";
            btnBitacora.Padding = new Padding(20, 0, 0, 0);
            btnBitacora.Size = new Size(243, 40);
            btnBitacora.TabIndex = 7;
            btnBitacora.Text = "Bitacora";
            btnBitacora.TextAlign = ContentAlignment.MiddleLeft;
            btnBitacora.UseVisualStyleBackColor = true;
            btnBitacora.Click += btnBitacora_Click;
            // 
            // btnAcciones
            // 
            btnAcciones.Dock = DockStyle.Top;
            btnAcciones.FlatAppearance.BorderSize = 0;
            btnAcciones.Font = new Font("Segoe UI", 11.25F);
            btnAcciones.ForeColor = Color.FromArgb(87, 99, 110);
            btnAcciones.Location = new Point(0, 120);
            btnAcciones.Name = "btnAcciones";
            btnAcciones.Padding = new Padding(20, 0, 0, 0);
            btnAcciones.Size = new Size(243, 40);
            btnAcciones.TabIndex = 5;
            btnAcciones.Text = "Lista de Acciones";
            btnAcciones.TextAlign = ContentAlignment.MiddleLeft;
            btnAcciones.UseVisualStyleBackColor = true;
            btnAcciones.Click += btnAcciones_Click;
            // 
            // btnGestionRoles
            // 
            btnGestionRoles.Dock = DockStyle.Top;
            btnGestionRoles.FlatAppearance.BorderSize = 0;
            btnGestionRoles.Font = new Font("Segoe UI", 11.25F);
            btnGestionRoles.ForeColor = Color.FromArgb(87, 99, 110);
            btnGestionRoles.Location = new Point(0, 80);
            btnGestionRoles.Name = "btnGestionRoles";
            btnGestionRoles.Padding = new Padding(20, 0, 0, 0);
            btnGestionRoles.Size = new Size(243, 40);
            btnGestionRoles.TabIndex = 4;
            btnGestionRoles.Text = "Gestión de Roles";
            btnGestionRoles.TextAlign = ContentAlignment.MiddleLeft;
            btnGestionRoles.UseVisualStyleBackColor = true;
            btnGestionRoles.Click += btnGestionRoles_Click;
            // 
            // btnGestionUsuarios
            // 
            btnGestionUsuarios.Dock = DockStyle.Top;
            btnGestionUsuarios.FlatAppearance.BorderSize = 0;
            btnGestionUsuarios.Font = new Font("Segoe UI", 11.25F);
            btnGestionUsuarios.ForeColor = Color.FromArgb(87, 99, 110);
            btnGestionUsuarios.Location = new Point(0, 40);
            btnGestionUsuarios.Name = "btnGestionUsuarios";
            btnGestionUsuarios.Padding = new Padding(20, 0, 0, 0);
            btnGestionUsuarios.Size = new Size(243, 40);
            btnGestionUsuarios.TabIndex = 1;
            btnGestionUsuarios.Text = "Gestión de Usuarios";
            btnGestionUsuarios.TextAlign = ContentAlignment.MiddleLeft;
            btnGestionUsuarios.UseVisualStyleBackColor = true;
            btnGestionUsuarios.Click += btnGestionUsuarios_Click;
            // 
            // btnGestionEmpleados
            // 
            btnGestionEmpleados.Dock = DockStyle.Top;
            btnGestionEmpleados.FlatAppearance.BorderSize = 0;
            btnGestionEmpleados.Font = new Font("Segoe UI", 11.25F);
            btnGestionEmpleados.ForeColor = Color.FromArgb(87, 99, 110);
            btnGestionEmpleados.Location = new Point(0, 0);
            btnGestionEmpleados.Name = "btnGestionEmpleados";
            btnGestionEmpleados.Padding = new Padding(20, 0, 0, 0);
            btnGestionEmpleados.Size = new Size(243, 40);
            btnGestionEmpleados.TabIndex = 0;
            btnGestionEmpleados.Text = "Gestión de Empleados";
            btnGestionEmpleados.TextAlign = ContentAlignment.MiddleLeft;
            btnGestionEmpleados.UseVisualStyleBackColor = true;
            btnGestionEmpleados.Click += btnGestionEmpleados_Click;
            // 
            // btnUsuarios
            // 
            btnUsuarios.BackColor = Color.FromArgb(189, 215, 238);
            btnUsuarios.Dock = DockStyle.Top;
            btnUsuarios.FlatAppearance.BorderSize = 0;
            btnUsuarios.Font = new Font("Itim", 17.2499981F);
            btnUsuarios.ForeColor = Color.FromArgb(87, 99, 110);
            btnUsuarios.Image = (Image)resources.GetObject("btnUsuarios.Image");
            btnUsuarios.ImageAlign = ContentAlignment.MiddleLeft;
            btnUsuarios.Location = new Point(0, 545);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Padding = new Padding(30, 0, 0, 0);
            btnUsuarios.Size = new Size(243, 80);
            btnUsuarios.TabIndex = 7;
            btnUsuarios.Text = "            Usuarios";
            btnUsuarios.TextAlign = ContentAlignment.MiddleLeft;
            btnUsuarios.UseVisualStyleBackColor = false;
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // panelVentas
            // 
            panelVentas.BackColor = Color.FromArgb(238, 238, 238);
            panelVentas.Controls.Add(btnClientes);
            panelVentas.Controls.Add(btnGestionVentas);
            panelVentas.Dock = DockStyle.Top;
            panelVentas.Location = new Point(0, 465);
            panelVentas.Name = "panelVentas";
            panelVentas.Size = new Size(243, 80);
            panelVentas.TabIndex = 6;
            // 
            // btnClientes
            // 
            btnClientes.Dock = DockStyle.Top;
            btnClientes.FlatAppearance.BorderSize = 0;
            btnClientes.Font = new Font("Segoe UI", 11.25F);
            btnClientes.ForeColor = Color.FromArgb(87, 99, 110);
            btnClientes.Location = new Point(0, 40);
            btnClientes.Name = "btnClientes";
            btnClientes.Padding = new Padding(20, 0, 0, 0);
            btnClientes.Size = new Size(243, 40);
            btnClientes.TabIndex = 1;
            btnClientes.Text = "Clientes";
            btnClientes.TextAlign = ContentAlignment.MiddleLeft;
            btnClientes.UseVisualStyleBackColor = true;
            btnClientes.Click += btnClientes_Click;
            // 
            // btnGestionVentas
            // 
            btnGestionVentas.Dock = DockStyle.Top;
            btnGestionVentas.FlatAppearance.BorderSize = 0;
            btnGestionVentas.Font = new Font("Segoe UI", 11.25F);
            btnGestionVentas.ForeColor = Color.FromArgb(87, 99, 110);
            btnGestionVentas.Location = new Point(0, 0);
            btnGestionVentas.Name = "btnGestionVentas";
            btnGestionVentas.Padding = new Padding(20, 0, 0, 0);
            btnGestionVentas.Size = new Size(243, 40);
            btnGestionVentas.TabIndex = 0;
            btnGestionVentas.Text = "Facturación";
            btnGestionVentas.TextAlign = ContentAlignment.MiddleLeft;
            btnGestionVentas.UseVisualStyleBackColor = true;
            btnGestionVentas.Click += btnGestionVentas_Click;
            // 
            // btnVentas
            // 
            btnVentas.BackColor = Color.FromArgb(189, 215, 238);
            btnVentas.Dock = DockStyle.Top;
            btnVentas.FlatAppearance.BorderSize = 0;
            btnVentas.Font = new Font("Itim", 17.2499981F);
            btnVentas.ForeColor = Color.FromArgb(87, 99, 110);
            btnVentas.Image = (Image)resources.GetObject("btnVentas.Image");
            btnVentas.ImageAlign = ContentAlignment.MiddleLeft;
            btnVentas.Location = new Point(0, 385);
            btnVentas.Name = "btnVentas";
            btnVentas.Padding = new Padding(30, 0, 0, 0);
            btnVentas.Size = new Size(243, 80);
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
            panelCompras.Location = new Point(0, 305);
            panelCompras.Name = "panelCompras";
            panelCompras.Size = new Size(243, 80);
            panelCompras.TabIndex = 4;
            // 
            // btnProveedores
            // 
            btnProveedores.Dock = DockStyle.Top;
            btnProveedores.FlatAppearance.BorderSize = 0;
            btnProveedores.Font = new Font("Segoe UI", 11.25F);
            btnProveedores.ForeColor = Color.FromArgb(87, 99, 110);
            btnProveedores.Location = new Point(0, 40);
            btnProveedores.Name = "btnProveedores";
            btnProveedores.Padding = new Padding(20, 0, 0, 0);
            btnProveedores.Size = new Size(243, 40);
            btnProveedores.TabIndex = 1;
            btnProveedores.Text = "Proveedores";
            btnProveedores.TextAlign = ContentAlignment.MiddleLeft;
            btnProveedores.UseVisualStyleBackColor = true;
            btnProveedores.Click += btnProveedores_Click;
            // 
            // btnGestionCompra
            // 
            btnGestionCompra.Dock = DockStyle.Top;
            btnGestionCompra.FlatAppearance.BorderSize = 0;
            btnGestionCompra.Font = new Font("Segoe UI", 11.25F);
            btnGestionCompra.ForeColor = Color.FromArgb(87, 99, 110);
            btnGestionCompra.Location = new Point(0, 0);
            btnGestionCompra.Name = "btnGestionCompra";
            btnGestionCompra.Padding = new Padding(20, 0, 0, 0);
            btnGestionCompra.Size = new Size(243, 40);
            btnGestionCompra.TabIndex = 0;
            btnGestionCompra.Text = "Gestión de Compra";
            btnGestionCompra.TextAlign = ContentAlignment.MiddleLeft;
            btnGestionCompra.UseVisualStyleBackColor = true;
            btnGestionCompra.Click += btnGestionCompra_Click;
            // 
            // btnCompras
            // 
            btnCompras.BackColor = Color.FromArgb(189, 215, 238);
            btnCompras.Dock = DockStyle.Top;
            btnCompras.FlatAppearance.BorderSize = 0;
            btnCompras.Font = new Font("Itim", 17.2499981F);
            btnCompras.ForeColor = Color.FromArgb(87, 99, 110);
            btnCompras.Image = (Image)resources.GetObject("btnCompras.Image");
            btnCompras.ImageAlign = ContentAlignment.MiddleLeft;
            btnCompras.Location = new Point(0, 225);
            btnCompras.Name = "btnCompras";
            btnCompras.Padding = new Padding(30, 0, 0, 0);
            btnCompras.Size = new Size(243, 80);
            btnCompras.TabIndex = 3;
            btnCompras.Text = "            Compras";
            btnCompras.TextAlign = ContentAlignment.MiddleLeft;
            btnCompras.UseVisualStyleBackColor = false;
            btnCompras.Click += btnCompras_Click;
            // 
            // panelInventario
            // 
            panelInventario.BackColor = Color.FromArgb(238, 238, 238);
            panelInventario.Controls.Add(btnInventarioBodega);
            panelInventario.Controls.Add(btnGestionInventario);
            panelInventario.Dock = DockStyle.Top;
            panelInventario.Location = new Point(0, 145);
            panelInventario.Name = "panelInventario";
            panelInventario.Size = new Size(243, 80);
            panelInventario.TabIndex = 2;
            // 
            // btnInventarioBodega
            // 
            btnInventarioBodega.Dock = DockStyle.Top;
            btnInventarioBodega.FlatAppearance.BorderSize = 0;
            btnInventarioBodega.Font = new Font("Segoe UI", 11.25F);
            btnInventarioBodega.ForeColor = Color.FromArgb(87, 99, 110);
            btnInventarioBodega.Location = new Point(0, 40);
            btnInventarioBodega.Name = "btnInventarioBodega";
            btnInventarioBodega.Padding = new Padding(20, 0, 0, 0);
            btnInventarioBodega.Size = new Size(243, 40);
            btnInventarioBodega.TabIndex = 2;
            btnInventarioBodega.Text = "Inventario por Bodega";
            btnInventarioBodega.TextAlign = ContentAlignment.MiddleLeft;
            btnInventarioBodega.UseVisualStyleBackColor = true;
            btnInventarioBodega.Click += btnInventarioBodega_Click;
            // 
            // btnGestionInventario
            // 
            btnGestionInventario.Dock = DockStyle.Top;
            btnGestionInventario.FlatAppearance.BorderSize = 0;
            btnGestionInventario.Font = new Font("Segoe UI", 11.25F);
            btnGestionInventario.ForeColor = Color.FromArgb(87, 99, 110);
            btnGestionInventario.Location = new Point(0, 0);
            btnGestionInventario.Name = "btnGestionInventario";
            btnGestionInventario.Padding = new Padding(20, 0, 0, 0);
            btnGestionInventario.Size = new Size(243, 40);
            btnGestionInventario.TabIndex = 0;
            btnGestionInventario.Text = "Gestión de Inventario";
            btnGestionInventario.TextAlign = ContentAlignment.MiddleLeft;
            btnGestionInventario.UseVisualStyleBackColor = true;
            btnGestionInventario.Click += btnGestionInventario_Click;
            // 
            // btnInventario
            // 
            btnInventario.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnInventario.BackColor = Color.FromArgb(189, 215, 238);
            btnInventario.Dock = DockStyle.Top;
            btnInventario.FlatAppearance.BorderSize = 0;
            btnInventario.Font = new Font("Itim", 17.2499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnInventario.ForeColor = Color.FromArgb(87, 99, 110);
            btnInventario.Image = (Image)resources.GetObject("btnInventario.Image");
            btnInventario.ImageAlign = ContentAlignment.MiddleLeft;
            btnInventario.Location = new Point(0, 65);
            btnInventario.Name = "btnInventario";
            btnInventario.Padding = new Padding(30, 0, 0, 0);
            btnInventario.Size = new Size(243, 80);
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
            panelMneuLateral.Size = new Size(243, 65);
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
            panelFormHijo.BackColor = Color.FromArgb(253, 253, 253);
            panelFormHijo.Dock = DockStyle.Fill;
            panelFormHijo.Location = new Point(260, 65);
            panelFormHijo.Name = "panelFormHijo";
            panelFormHijo.Size = new Size(764, 663);
            panelFormHijo.TabIndex = 2;
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
            panelNotificaciones.BackColor = Color.FromArgb(189, 215, 238);
            panelNotificaciones.BackgroundImage = Properties.Resources.sin_notificacion;
            panelNotificaciones.BackgroundImageLayout = ImageLayout.Center;
            panelNotificaciones.Controls.Add(lblNotificaciones);
            panelNotificaciones.Dock = DockStyle.Right;
            panelNotificaciones.Location = new Point(1024, 65);
            panelNotificaciones.Name = "panelNotificaciones";
            panelNotificaciones.Size = new Size(0, 663);
            panelNotificaciones.TabIndex = 3;
            // 
            // lblNotificaciones
            // 
            lblNotificaciones.AutoSize = true;
            lblNotificaciones.Font = new Font("Itim", 14F);
            lblNotificaciones.ForeColor = Color.FromArgb(148, 168, 187);
            lblNotificaciones.Location = new Point(24, 408);
            lblNotificaciones.Name = "lblNotificaciones";
            lblNotificaciones.Size = new Size(314, 23);
            lblNotificaciones.TabIndex = 0;
            lblNotificaciones.Text = "No tienes notificaciones pendientes...";
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(1024, 728);
            Controls.Add(panelNotificaciones);
            Controls.Add(panelFormHijo);
            Controls.Add(panBarraControl);
            Controls.Add(panelMenuLateral);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 10F);
            Name = "MenuPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "  ";
            Load += Form1_Load;
            panBarraControl.ResumeLayout(false);
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
        private Label lblNombreModulo;
        private Panel panel2;
        private Label label2;
        private Label label1;
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
    }
}
