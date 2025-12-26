namespace ModernMenuUI
{
    partial class frmAgregarEditarProducto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Panel panBarraControl;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarEditarProducto));
            lblNombreModulo = new Label();
            label8 = new Label();
            txtCodigo = new TextBox();
            label2 = new Label();
            label1 = new Label();
            txtProducto = new TextBox();
            btnAgregar = new Button();
            panel2 = new Panel();
            panel1 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnGuardarProducto = new Button();
            btnModificarProducto = new Button();
            btnVolver = new Button();
            fpnlDinamico = new FlowLayoutPanel();
            pnlDatosGenerales = new Panel();
            txtCategoria = new TextBox();
            label15 = new Label();
            label13 = new Label();
            txtMarca = new TextBox();
            label12 = new Label();
            txtContenido = new TextBox();
            txtPresentacion = new TextBox();
            cmbUnidadContenido = new ComboBox();
            label16 = new Label();
            txtCodBarra = new TextBox();
            label22 = new Label();
            label18 = new Label();
            label19 = new Label();
            txtNombreProducto = new TextBox();
            btnBuscarCategoria = new Button();
            btnBuscarPresentacion = new Button();
            btnBuscarMarca = new Button();
            pnlCantidad = new Panel();
            label25 = new Label();
            nudCantidad = new NumericUpDown();
            label9 = new Label();
            pnlCompras = new Panel();
            label23 = new Label();
            label21 = new Label();
            nudPrecioCosto = new NumericUpDown();
            label11 = new Label();
            nudPrecioCompra = new NumericUpDown();
            label20 = new Label();
            pnlVentas = new Panel();
            label24 = new Label();
            label14 = new Label();
            nudPorcentajeGanancia = new NumericUpDown();
            nudPrecioVenta = new NumericUpDown();
            label17 = new Label();
            lblNota = new Label();
            pictureBox1 = new PictureBox();
            gbxEstadoProductoNuevo = new GroupBox();
            rbDeshabilitado = new RadioButton();
            rbHabilitado = new RadioButton();
            lblEstado = new Label();
            label10 = new Label();
            textBox5 = new TextBox();
            label7 = new Label();
            textBox4 = new TextBox();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            label3 = new Label();
            textBox3 = new TextBox();
            gbxEstado = new GroupBox();
            radioButton1 = new RadioButton();
            rbActivo = new RadioButton();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            tipEditar = new ToolTip(components);
            tipCompras = new ToolTip(components);
            hpVentaGanancia = new HelpProvider();
            panBarraControl = new Panel();
            panBarraControl.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            fpnlDinamico.SuspendLayout();
            pnlDatosGenerales.SuspendLayout();
            pnlCantidad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            pnlCompras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPrecioCosto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecioCompra).BeginInit();
            pnlVentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPorcentajeGanancia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecioVenta).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            gbxEstadoProductoNuevo.SuspendLayout();
            gbxEstado.SuspendLayout();
            SuspendLayout();
            // 
            // panBarraControl
            // 
            panBarraControl.BackColor = Color.FromArgb(148, 168, 187);
            panBarraControl.Controls.Add(lblNombreModulo);
            panBarraControl.Dock = DockStyle.Top;
            panBarraControl.ForeColor = Color.Coral;
            panBarraControl.Location = new Point(0, 0);
            panBarraControl.Name = "panBarraControl";
            panBarraControl.Size = new Size(864, 37);
            panBarraControl.TabIndex = 2;
            panBarraControl.MouseDown += panBarraControl_MouseDown;
            // 
            // lblNombreModulo
            // 
            lblNombreModulo.Dock = DockStyle.Fill;
            lblNombreModulo.Font = new Font("Itim", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombreModulo.ForeColor = Color.White;
            lblNombreModulo.Location = new Point(0, 0);
            lblNombreModulo.Name = "lblNombreModulo";
            lblNombreModulo.Size = new Size(864, 37);
            lblNombreModulo.TabIndex = 8;
            lblNombreModulo.Text = "EDITAR PRODUCTO";
            lblNombreModulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Itim", 11.9999981F);
            label8.ForeColor = Color.FromArgb(87, 99, 110);
            label8.Location = new Point(82, 20);
            label8.Name = "label8";
            label8.Size = new Size(60, 19);
            label8.TabIndex = 19;
            label8.Text = "Código:";
            // 
            // txtCodigo
            // 
            txtCodigo.BackColor = Color.White;
            txtCodigo.BorderStyle = BorderStyle.None;
            txtCodigo.Enabled = false;
            txtCodigo.Font = new Font("Itim", 11.9999981F);
            txtCodigo.Location = new Point(153, 18);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.ReadOnly = true;
            txtCodigo.Size = new Size(275, 20);
            txtCodigo.TabIndex = 18;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Itim", 11.9999981F);
            label2.ForeColor = Color.FromArgb(87, 99, 110);
            label2.Location = new Point(27, 91);
            label2.Name = "label2";
            label2.Size = new Size(120, 19);
            label2.TabIndex = 16;
            label2.Text = "Precio de Venta:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Itim", 11.9999981F);
            label1.ForeColor = Color.FromArgb(87, 99, 110);
            label1.Location = new Point(71, 58);
            label1.Name = "label1";
            label1.Size = new Size(76, 19);
            label1.TabIndex = 15;
            label1.Text = "Producto:";
            // 
            // txtProducto
            // 
            txtProducto.BackColor = Color.White;
            txtProducto.BorderStyle = BorderStyle.None;
            txtProducto.Enabled = false;
            txtProducto.Font = new Font("Itim", 11.9999981F);
            txtProducto.Location = new Point(153, 56);
            txtProducto.Name = "txtProducto";
            txtProducto.ReadOnly = true;
            txtProducto.Size = new Size(275, 20);
            txtProducto.TabIndex = 13;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(149, 195, 172);
            btnAgregar.BackgroundImageLayout = ImageLayout.None;
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.Font = new Font("Itim", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregar.ForeColor = SystemColors.ButtonFace;
            btnAgregar.ImageAlign = ContentAlignment.BottomLeft;
            btnAgregar.Location = new Point(45, 399);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(125, 43);
            btnAgregar.TabIndex = 10;
            btnAgregar.Text = "Guardar";
            btnAgregar.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(189, 215, 238);
            panel2.Controls.Add(panel1);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(textBox5);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(textBox4);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(textBox3);
            panel2.Controls.Add(gbxEstado);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(txtCodigo);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtProducto);
            panel2.Controls.Add(btnAgregar);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 37);
            panel2.Name = "panel2";
            panel2.Size = new Size(864, 544);
            panel2.TabIndex = 12;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(189, 215, 238);
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Controls.Add(fpnlDinamico);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(gbxEstadoProductoNuevo);
            panel1.Controls.Add(lblEstado);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(864, 544);
            panel1.TabIndex = 41;
            panel1.Paint += panel1_Paint;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            flowLayoutPanel1.Controls.Add(btnGuardarProducto);
            flowLayoutPanel1.Controls.Add(btnModificarProducto);
            flowLayoutPanel1.Controls.Add(btnVolver);
            flowLayoutPanel1.Location = new Point(18, 485);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(261, 47);
            flowLayoutPanel1.TabIndex = 51;
            // 
            // btnGuardarProducto
            // 
            btnGuardarProducto.BackColor = Color.FromArgb(149, 195, 172);
            btnGuardarProducto.BackgroundImageLayout = ImageLayout.None;
            btnGuardarProducto.FlatAppearance.BorderSize = 0;
            btnGuardarProducto.Font = new Font("Itim", 11.9999981F);
            btnGuardarProducto.ForeColor = SystemColors.ButtonFace;
            btnGuardarProducto.ImageAlign = ContentAlignment.BottomLeft;
            btnGuardarProducto.Location = new Point(3, 3);
            btnGuardarProducto.Name = "btnGuardarProducto";
            btnGuardarProducto.Size = new Size(89, 40);
            btnGuardarProducto.TabIndex = 47;
            btnGuardarProducto.Text = "Guardar";
            btnGuardarProducto.UseVisualStyleBackColor = false;
            btnGuardarProducto.Visible = false;
            btnGuardarProducto.Click += btnGuardarProducto_Click;
            // 
            // btnModificarProducto
            // 
            btnModificarProducto.BackColor = Color.FromArgb(74, 148, 225);
            btnModificarProducto.BackgroundImageLayout = ImageLayout.None;
            btnModificarProducto.FlatAppearance.BorderSize = 0;
            btnModificarProducto.Font = new Font("Itim", 11.9999981F);
            btnModificarProducto.ForeColor = SystemColors.ButtonFace;
            btnModificarProducto.ImageAlign = ContentAlignment.BottomLeft;
            btnModificarProducto.Location = new Point(98, 3);
            btnModificarProducto.Name = "btnModificarProducto";
            btnModificarProducto.Size = new Size(89, 40);
            btnModificarProducto.TabIndex = 48;
            btnModificarProducto.Text = "Editar";
            btnModificarProducto.UseVisualStyleBackColor = false;
            btnModificarProducto.Click += btnModificarProducto_Click;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.FromArgb(148, 168, 187);
            btnVolver.BackgroundImageLayout = ImageLayout.None;
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.Font = new Font("Itim", 11.9999981F);
            btnVolver.ForeColor = SystemColors.ButtonFace;
            btnVolver.ImageAlign = ContentAlignment.BottomLeft;
            btnVolver.Location = new Point(193, 3);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(64, 40);
            btnVolver.TabIndex = 46;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // fpnlDinamico
            // 
            fpnlDinamico.Controls.Add(pnlDatosGenerales);
            fpnlDinamico.Controls.Add(pnlCantidad);
            fpnlDinamico.Controls.Add(pnlCompras);
            fpnlDinamico.Controls.Add(pnlVentas);
            fpnlDinamico.Controls.Add(lblNota);
            fpnlDinamico.Location = new Point(18, 20);
            fpnlDinamico.Name = "fpnlDinamico";
            fpnlDinamico.Size = new Size(449, 462);
            fpnlDinamico.TabIndex = 67;
            // 
            // pnlDatosGenerales
            // 
            pnlDatosGenerales.Controls.Add(txtCategoria);
            pnlDatosGenerales.Controls.Add(label15);
            pnlDatosGenerales.Controls.Add(label13);
            pnlDatosGenerales.Controls.Add(txtMarca);
            pnlDatosGenerales.Controls.Add(label12);
            pnlDatosGenerales.Controls.Add(txtContenido);
            pnlDatosGenerales.Controls.Add(txtPresentacion);
            pnlDatosGenerales.Controls.Add(cmbUnidadContenido);
            pnlDatosGenerales.Controls.Add(label16);
            pnlDatosGenerales.Controls.Add(txtCodBarra);
            pnlDatosGenerales.Controls.Add(label22);
            pnlDatosGenerales.Controls.Add(label18);
            pnlDatosGenerales.Controls.Add(label19);
            pnlDatosGenerales.Controls.Add(txtNombreProducto);
            pnlDatosGenerales.Controls.Add(btnBuscarCategoria);
            pnlDatosGenerales.Controls.Add(btnBuscarPresentacion);
            pnlDatosGenerales.Controls.Add(btnBuscarMarca);
            pnlDatosGenerales.Location = new Point(0, 0);
            pnlDatosGenerales.Margin = new Padding(0);
            pnlDatosGenerales.Name = "pnlDatosGenerales";
            pnlDatosGenerales.Size = new Size(450, 225);
            pnlDatosGenerales.TabIndex = 62;
            // 
            // txtCategoria
            // 
            txtCategoria.BackColor = Color.White;
            txtCategoria.BorderStyle = BorderStyle.None;
            txtCategoria.Font = new Font("Itim", 11.9999981F);
            txtCategoria.ForeColor = Color.DimGray;
            txtCategoria.Location = new Point(151, 82);
            txtCategoria.Name = "txtCategoria";
            txtCategoria.PlaceholderText = "(Seleccione Buscar)";
            txtCategoria.ReadOnly = true;
            txtCategoria.Size = new Size(221, 20);
            txtCategoria.TabIndex = 23;
            tipEditar.SetToolTip(txtCategoria, "Para editar este producto, presione el botón Editar.");
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Itim", 11.9999981F);
            label15.ForeColor = Color.FromArgb(87, 99, 110);
            label15.Location = new Point(61, 83);
            label15.Name = "label15";
            label15.Size = new Size(79, 19);
            label15.TabIndex = 25;
            label15.Text = "Categoría:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Itim", 11.9999981F);
            label13.ForeColor = Color.FromArgb(87, 99, 110);
            label13.Location = new Point(85, 123);
            label13.Name = "label13";
            label13.Size = new Size(55, 19);
            label13.TabIndex = 27;
            label13.Text = "Marca:";
            // 
            // txtMarca
            // 
            txtMarca.BackColor = Color.White;
            txtMarca.BorderStyle = BorderStyle.None;
            txtMarca.Font = new Font("Itim", 11.9999981F);
            txtMarca.ForeColor = Color.DimGray;
            txtMarca.Location = new Point(151, 123);
            txtMarca.Name = "txtMarca";
            txtMarca.PlaceholderText = "(Seleccione Buscar)";
            txtMarca.ReadOnly = true;
            txtMarca.Size = new Size(221, 20);
            txtMarca.TabIndex = 31;
            tipEditar.SetToolTip(txtMarca, "Para editar este producto, presione el botón Editar.");
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Itim", 11.9999981F);
            label12.ForeColor = Color.FromArgb(87, 99, 110);
            label12.Location = new Point(38, 163);
            label12.Name = "label12";
            label12.Size = new Size(102, 19);
            label12.TabIndex = 32;
            label12.Text = "Presentación:";
            // 
            // txtContenido
            // 
            txtContenido.BackColor = Color.White;
            txtContenido.BorderStyle = BorderStyle.None;
            txtContenido.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContenido.ForeColor = Color.DimGray;
            txtContenido.Location = new Point(151, 203);
            txtContenido.Name = "txtContenido";
            txtContenido.PlaceholderText = "(Cantidad)";
            txtContenido.Size = new Size(108, 20);
            txtContenido.TabIndex = 58;
            tipEditar.SetToolTip(txtContenido, "Para editar este producto, presione el botón Editar.");
            // 
            // txtPresentacion
            // 
            txtPresentacion.BackColor = Color.White;
            txtPresentacion.BorderStyle = BorderStyle.None;
            txtPresentacion.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPresentacion.ForeColor = Color.DimGray;
            txtPresentacion.Location = new Point(151, 163);
            txtPresentacion.Name = "txtPresentacion";
            txtPresentacion.PlaceholderText = "(Seleccione Buscar)";
            txtPresentacion.ReadOnly = true;
            txtPresentacion.Size = new Size(221, 20);
            txtPresentacion.TabIndex = 37;
            tipEditar.SetToolTip(txtPresentacion, "Para editar este producto, presione el botón Editar.");
            // 
            // cmbUnidadContenido
            // 
            cmbUnidadContenido.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbUnidadContenido.ForeColor = Color.DimGray;
            cmbUnidadContenido.FormattingEnabled = true;
            cmbUnidadContenido.Items.AddRange(new object[] { "(Unidades)", "mg", "kg", "g", "lb", "oz", "ml", "cl", "l", "fl(oz)" });
            cmbUnidadContenido.Location = new Point(349, 198);
            cmbUnidadContenido.Name = "cmbUnidadContenido";
            cmbUnidadContenido.Size = new Size(77, 26);
            cmbUnidadContenido.TabIndex = 57;
            tipEditar.SetToolTip(cmbUnidadContenido, "Para editar este producto, presione el botón Editar.");
            cmbUnidadContenido.SelectedIndexChanged += cmbUnidadContenido_SelectedIndexChanged;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Itim", 11.9999981F);
            label16.ForeColor = Color.FromArgb(87, 99, 110);
            label16.Location = new Point(17, 2);
            label16.Name = "label16";
            label16.Size = new Size(123, 19);
            label16.TabIndex = 19;
            label16.Text = "Código de Barra:";
            // 
            // txtCodBarra
            // 
            txtCodBarra.BackColor = Color.White;
            txtCodBarra.BorderStyle = BorderStyle.None;
            txtCodBarra.Font = new Font("Itim", 11.9999981F);
            txtCodBarra.ForeColor = Color.DimGray;
            txtCodBarra.Location = new Point(151, 0);
            txtCodBarra.MaxLength = 13;
            txtCodBarra.Name = "txtCodBarra";
            txtCodBarra.PlaceholderText = "(Ingrese o Escanee el Código)";
            txtCodBarra.Size = new Size(275, 20);
            txtCodBarra.TabIndex = 18;
            tipEditar.SetToolTip(txtCodBarra, "Para editar este producto, presione el botón Editar.");
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Itim", 11.9999981F);
            label22.ForeColor = Color.FromArgb(87, 99, 110);
            label22.Location = new Point(265, 203);
            label22.Name = "label22";
            label22.Size = new Size(78, 19);
            label22.TabIndex = 56;
            label22.Text = "Unidades:";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Itim", 11.9999981F);
            label18.ForeColor = Color.FromArgb(87, 99, 110);
            label18.Location = new Point(64, 40);
            label18.Name = "label18";
            label18.Size = new Size(76, 19);
            label18.TabIndex = 15;
            label18.Text = "Producto:";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Itim", 11.9999981F);
            label19.ForeColor = Color.FromArgb(87, 99, 110);
            label19.Location = new Point(56, 203);
            label19.Name = "label19";
            label19.Size = new Size(84, 19);
            label19.TabIndex = 42;
            label19.Text = "Contenido:";
            // 
            // txtNombreProducto
            // 
            txtNombreProducto.BackColor = Color.White;
            txtNombreProducto.BorderStyle = BorderStyle.None;
            txtNombreProducto.Font = new Font("Itim", 11.9999981F);
            txtNombreProducto.ForeColor = Color.DimGray;
            txtNombreProducto.Location = new Point(151, 40);
            txtNombreProducto.MaxLength = 500;
            txtNombreProducto.Name = "txtNombreProducto";
            txtNombreProducto.PlaceholderText = "(Nombre del Producto)";
            txtNombreProducto.Size = new Size(275, 20);
            txtNombreProducto.TabIndex = 13;
            tipEditar.SetToolTip(txtNombreProducto, "Para editar este producto, presione el botón Editar.");
            // 
            // btnBuscarCategoria
            // 
            btnBuscarCategoria.BackColor = Color.FromArgb(168, 191, 212);
            btnBuscarCategoria.BackgroundImage = (Image)resources.GetObject("btnBuscarCategoria.BackgroundImage");
            btnBuscarCategoria.BackgroundImageLayout = ImageLayout.Zoom;
            btnBuscarCategoria.FlatAppearance.BorderSize = 0;
            btnBuscarCategoria.FlatStyle = FlatStyle.Flat;
            btnBuscarCategoria.Location = new Point(378, 82);
            btnBuscarCategoria.Name = "btnBuscarCategoria";
            btnBuscarCategoria.Size = new Size(48, 20);
            btnBuscarCategoria.TabIndex = 44;
            tipEditar.SetToolTip(btnBuscarCategoria, "Para editar este producto, presione el botón Editar.");
            btnBuscarCategoria.UseVisualStyleBackColor = false;
            btnBuscarCategoria.Click += btnBuscarCategoria_Click;
            // 
            // btnBuscarPresentacion
            // 
            btnBuscarPresentacion.BackColor = Color.FromArgb(168, 191, 212);
            btnBuscarPresentacion.BackgroundImage = (Image)resources.GetObject("btnBuscarPresentacion.BackgroundImage");
            btnBuscarPresentacion.BackgroundImageLayout = ImageLayout.Zoom;
            btnBuscarPresentacion.FlatAppearance.BorderSize = 0;
            btnBuscarPresentacion.FlatStyle = FlatStyle.Flat;
            btnBuscarPresentacion.Location = new Point(378, 163);
            btnBuscarPresentacion.Name = "btnBuscarPresentacion";
            btnBuscarPresentacion.Size = new Size(48, 20);
            btnBuscarPresentacion.TabIndex = 49;
            tipEditar.SetToolTip(btnBuscarPresentacion, "Para editar este producto, presione el botón Editar.");
            btnBuscarPresentacion.UseVisualStyleBackColor = false;
            btnBuscarPresentacion.Click += btnBuscarPresentacion_Click;
            // 
            // btnBuscarMarca
            // 
            btnBuscarMarca.BackColor = Color.FromArgb(168, 191, 212);
            btnBuscarMarca.BackgroundImage = (Image)resources.GetObject("btnBuscarMarca.BackgroundImage");
            btnBuscarMarca.BackgroundImageLayout = ImageLayout.Zoom;
            btnBuscarMarca.FlatAppearance.BorderSize = 0;
            btnBuscarMarca.FlatStyle = FlatStyle.Flat;
            btnBuscarMarca.Location = new Point(378, 123);
            btnBuscarMarca.Name = "btnBuscarMarca";
            btnBuscarMarca.Size = new Size(48, 20);
            btnBuscarMarca.TabIndex = 45;
            tipEditar.SetToolTip(btnBuscarMarca, "Para editar este producto, presione el botón Editar.");
            btnBuscarMarca.UseVisualStyleBackColor = false;
            btnBuscarMarca.Click += btnBuscarMarca_Click;
            // 
            // pnlCantidad
            // 
            pnlCantidad.Controls.Add(label25);
            pnlCantidad.Controls.Add(nudCantidad);
            pnlCantidad.Controls.Add(label9);
            pnlCantidad.Location = new Point(0, 245);
            pnlCantidad.Margin = new Padding(0, 20, 0, 0);
            pnlCantidad.Name = "pnlCantidad";
            pnlCantidad.Size = new Size(450, 26);
            pnlCantidad.TabIndex = 66;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new Font("Itim", 11.9999981F);
            label25.ForeColor = Color.FromArgb(87, 99, 110);
            label25.Location = new Point(304, 1);
            label25.Name = "label25";
            label25.Size = new Size(122, 19);
            label25.TabIndex = 66;
            label25.Text = "(No Modificable)";
            tipCompras.SetToolTip(label25, "Incremente la Cantidad Ingresando una Compra.");
            // 
            // nudCantidad
            // 
            nudCantidad.Enabled = false;
            nudCantidad.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudCantidad.ForeColor = Color.DimGray;
            nudCantidad.InterceptArrowKeys = false;
            nudCantidad.Location = new Point(151, 0);
            nudCantidad.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(147, 25);
            nudCantidad.TabIndex = 61;
            tipEditar.SetToolTip(nudCantidad, "Para editar este producto, presione el botón Editar.");
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Itim", 11.9999981F);
            label9.ForeColor = Color.FromArgb(87, 99, 110);
            label9.Location = new Point(64, 1);
            label9.Name = "label9";
            label9.Size = new Size(76, 19);
            label9.TabIndex = 40;
            label9.Text = "Cantidad:";
            // 
            // pnlCompras
            // 
            pnlCompras.Controls.Add(label23);
            pnlCompras.Controls.Add(label21);
            pnlCompras.Controls.Add(nudPrecioCosto);
            pnlCompras.Controls.Add(label11);
            pnlCompras.Controls.Add(nudPrecioCompra);
            pnlCompras.Controls.Add(label20);
            pnlCompras.Location = new Point(0, 291);
            pnlCompras.Margin = new Padding(0, 20, 0, 0);
            pnlCompras.Name = "pnlCompras";
            pnlCompras.Size = new Size(450, 69);
            pnlCompras.TabIndex = 66;
            tipCompras.SetToolTip(pnlCompras, "Estos valores solo pueden modificarse ingresando una compra.");
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Itim", 11.9999981F);
            label23.ForeColor = Color.FromArgb(87, 99, 110);
            label23.Location = new Point(304, 45);
            label23.Name = "label23";
            label23.Size = new Size(122, 19);
            label23.TabIndex = 66;
            label23.Text = "(No Modificable)";
            tipCompras.SetToolTip(label23, "Este valor se Calcula al ingresar una Compra.");
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Itim", 11.9999981F);
            label21.ForeColor = Color.FromArgb(87, 99, 110);
            label21.Location = new Point(304, 1);
            label21.Name = "label21";
            label21.Size = new Size(122, 19);
            label21.TabIndex = 65;
            label21.Text = "(No Modificable)";
            tipCompras.SetToolTip(label21, "Estos valores solo pueden modificarse ingresando una compra.");
            // 
            // nudPrecioCosto
            // 
            nudPrecioCosto.DecimalPlaces = 2;
            nudPrecioCosto.Enabled = false;
            nudPrecioCosto.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudPrecioCosto.ForeColor = Color.DimGray;
            nudPrecioCosto.InterceptArrowKeys = false;
            nudPrecioCosto.Location = new Point(151, 44);
            nudPrecioCosto.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudPrecioCosto.Name = "nudPrecioCosto";
            nudPrecioCosto.Size = new Size(147, 25);
            nudPrecioCosto.TabIndex = 64;
            tipEditar.SetToolTip(nudPrecioCosto, "Para editar este producto, presione el botón Editar.");
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Itim", 11.9999981F);
            label11.ForeColor = Color.FromArgb(87, 99, 110);
            label11.Location = new Point(12, 1);
            label11.Name = "label11";
            label11.Size = new Size(133, 19);
            label11.TabIndex = 38;
            label11.Text = "Precio de Compra:";
            // 
            // nudPrecioCompra
            // 
            nudPrecioCompra.DecimalPlaces = 2;
            nudPrecioCompra.Enabled = false;
            nudPrecioCompra.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudPrecioCompra.ForeColor = Color.DimGray;
            nudPrecioCompra.InterceptArrowKeys = false;
            nudPrecioCompra.Location = new Point(151, 0);
            nudPrecioCompra.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudPrecioCompra.Name = "nudPrecioCompra";
            nudPrecioCompra.Size = new Size(147, 25);
            nudPrecioCompra.TabIndex = 60;
            tipEditar.SetToolTip(nudPrecioCompra, "Para editar este producto, presione el botón Editar.");
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Itim", 11.9999981F);
            label20.ForeColor = Color.FromArgb(87, 99, 110);
            label20.Location = new Point(25, 44);
            label20.Name = "label20";
            label20.Size = new Size(119, 19);
            label20.TabIndex = 63;
            label20.Text = "Precio de Costo:";
            tipCompras.SetToolTip(label20, "Este campo es Calculado.");
            // 
            // pnlVentas
            // 
            pnlVentas.Controls.Add(label24);
            pnlVentas.Controls.Add(label14);
            pnlVentas.Controls.Add(nudPorcentajeGanancia);
            pnlVentas.Controls.Add(nudPrecioVenta);
            pnlVentas.Controls.Add(label17);
            pnlVentas.Location = new Point(0, 380);
            pnlVentas.Margin = new Padding(0, 20, 0, 0);
            pnlVentas.Name = "pnlVentas";
            pnlVentas.Size = new Size(450, 70);
            pnlVentas.TabIndex = 65;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Itim", 11.9999981F);
            label24.ForeColor = Color.FromArgb(87, 99, 110);
            label24.Location = new Point(235, 45);
            label24.Name = "label24";
            label24.Size = new Size(20, 19);
            label24.TabIndex = 62;
            label24.Text = "%";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Itim", 11.9999981F);
            label14.ForeColor = Color.FromArgb(87, 99, 110);
            label14.Location = new Point(62, 45);
            label14.Name = "label14";
            label14.Size = new Size(78, 19);
            label14.TabIndex = 61;
            label14.Text = "Ganancia:";
            // 
            // nudPorcentajeGanancia
            // 
            nudPorcentajeGanancia.DecimalPlaces = 2;
            nudPorcentajeGanancia.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudPorcentajeGanancia.ForeColor = Color.DimGray;
            nudPorcentajeGanancia.InterceptArrowKeys = false;
            nudPorcentajeGanancia.Location = new Point(151, 44);
            nudPorcentajeGanancia.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudPorcentajeGanancia.Name = "nudPorcentajeGanancia";
            nudPorcentajeGanancia.Size = new Size(85, 25);
            nudPorcentajeGanancia.TabIndex = 60;
            tipEditar.SetToolTip(nudPorcentajeGanancia, "Para editar este producto, presione el botón Editar.");
            // 
            // nudPrecioVenta
            // 
            nudPrecioVenta.DecimalPlaces = 2;
            nudPrecioVenta.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudPrecioVenta.ForeColor = Color.DimGray;
            nudPrecioVenta.InterceptArrowKeys = false;
            nudPrecioVenta.Location = new Point(151, 0);
            nudPrecioVenta.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudPrecioVenta.Name = "nudPrecioVenta";
            nudPrecioVenta.Size = new Size(275, 25);
            nudPrecioVenta.TabIndex = 59;
            tipEditar.SetToolTip(nudPrecioVenta, "Para editar este producto, presione el botón Editar.");
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Itim", 11.9999981F);
            label17.ForeColor = Color.FromArgb(87, 99, 110);
            label17.Location = new Point(20, 1);
            label17.Name = "label17";
            label17.Size = new Size(120, 19);
            label17.TabIndex = 16;
            label17.Text = "Precio de Venta:";
            // 
            // lblNota
            // 
            lblNota.BackColor = Color.FromArgb(148, 168, 187);
            lblNota.Font = new Font("Itim", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNota.ForeColor = Color.White;
            lblNota.ImageAlign = ContentAlignment.MiddleLeft;
            lblNota.Location = new Point(0, 470);
            lblNota.Margin = new Padding(0, 20, 0, 0);
            lblNota.Name = "lblNota";
            lblNota.Size = new Size(426, 92);
            lblNota.TabIndex = 52;
            lblNota.Text = "Nota: Para ingresar Inventario de un producto nuevo, establecer cantidades mínimas de inventario, y precio de compra deberá realizarlo por medio del módulo de compra.";
            lblNota.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(494, 20);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(350, 350);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 43;
            pictureBox1.TabStop = false;
            // 
            // gbxEstadoProductoNuevo
            // 
            gbxEstadoProductoNuevo.Controls.Add(rbDeshabilitado);
            gbxEstadoProductoNuevo.Controls.Add(rbHabilitado);
            gbxEstadoProductoNuevo.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbxEstadoProductoNuevo.ForeColor = Color.DimGray;
            gbxEstadoProductoNuevo.Location = new Point(560, 387);
            gbxEstadoProductoNuevo.Name = "gbxEstadoProductoNuevo";
            gbxEstadoProductoNuevo.Size = new Size(196, 44);
            gbxEstadoProductoNuevo.TabIndex = 30;
            gbxEstadoProductoNuevo.TabStop = false;
            // 
            // rbDeshabilitado
            // 
            rbDeshabilitado.AutoSize = true;
            rbDeshabilitado.Location = new Point(89, 15);
            rbDeshabilitado.Name = "rbDeshabilitado";
            rbDeshabilitado.Size = new Size(82, 23);
            rbDeshabilitado.TabIndex = 29;
            rbDeshabilitado.Text = "Inactivo";
            rbDeshabilitado.UseVisualStyleBackColor = true;
            // 
            // rbHabilitado
            // 
            rbHabilitado.AutoSize = true;
            rbHabilitado.Checked = true;
            rbHabilitado.Location = new Point(7, 15);
            rbHabilitado.Name = "rbHabilitado";
            rbHabilitado.Size = new Size(70, 23);
            rbHabilitado.TabIndex = 28;
            rbHabilitado.TabStop = true;
            rbHabilitado.Text = "Activo";
            rbHabilitado.UseVisualStyleBackColor = true;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEstado.ForeColor = Color.FromArgb(87, 99, 110);
            lblEstado.Location = new Point(494, 403);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(60, 19);
            lblEstado.TabIndex = 26;
            lblEstado.Text = "Estado:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Itim", 11.9999981F);
            label10.ForeColor = Color.FromArgb(87, 99, 110);
            label10.Location = new Point(70, 259);
            label10.Name = "label10";
            label10.Size = new Size(76, 19);
            label10.TabIndex = 40;
            label10.Text = "Cantidad:";
            // 
            // textBox5
            // 
            textBox5.BackColor = Color.White;
            textBox5.BorderStyle = BorderStyle.None;
            textBox5.Enabled = false;
            textBox5.Font = new Font("Itim", 11.9999981F);
            textBox5.Location = new Point(153, 258);
            textBox5.Name = "textBox5";
            textBox5.ReadOnly = true;
            textBox5.Size = new Size(197, 20);
            textBox5.TabIndex = 39;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Itim", 11.9999981F);
            label7.ForeColor = Color.FromArgb(87, 99, 110);
            label7.Location = new Point(34, 225);
            label7.Name = "label7";
            label7.Size = new Size(112, 19);
            label7.TabIndex = 38;
            label7.Text = "Precio Compra:";
            // 
            // textBox4
            // 
            textBox4.BackColor = Color.White;
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.Enabled = false;
            textBox4.Font = new Font("Itim", 11.9999981F);
            textBox4.Location = new Point(153, 225);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(197, 20);
            textBox4.TabIndex = 37;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(148, 168, 187);
            button4.BackgroundImageLayout = ImageLayout.None;
            button4.FlatAppearance.BorderSize = 0;
            button4.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.ForeColor = SystemColors.ButtonFace;
            button4.ImageAlign = ContentAlignment.BottomLeft;
            button4.Location = new Point(356, 186);
            button4.Name = "button4";
            button4.Size = new Size(72, 26);
            button4.TabIndex = 36;
            button4.Text = "Ver";
            button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(148, 168, 187);
            button3.BackgroundImageLayout = ImageLayout.None;
            button3.FlatAppearance.BorderSize = 0;
            button3.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = SystemColors.ButtonFace;
            button3.ImageAlign = ContentAlignment.BottomLeft;
            button3.Location = new Point(356, 154);
            button3.Name = "button3";
            button3.Size = new Size(72, 26);
            button3.TabIndex = 35;
            button3.Text = "Ver";
            button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(148, 168, 187);
            button2.BackgroundImageLayout = ImageLayout.None;
            button2.FlatAppearance.BorderSize = 0;
            button2.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ButtonFace;
            button2.ImageAlign = ContentAlignment.BottomLeft;
            button2.Location = new Point(356, 122);
            button2.Name = "button2";
            button2.Size = new Size(72, 26);
            button2.TabIndex = 34;
            button2.Text = "Ver";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(148, 168, 187);
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatAppearance.BorderSize = 0;
            button1.Font = new Font("Itim", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ButtonFace;
            button1.ImageAlign = ContentAlignment.BottomLeft;
            button1.Location = new Point(205, 399);
            button1.Name = "button1";
            button1.Size = new Size(125, 43);
            button1.TabIndex = 33;
            button1.Text = "Volver";
            button1.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Itim", 11.9999981F);
            label3.ForeColor = Color.FromArgb(87, 99, 110);
            label3.Location = new Point(45, 190);
            label3.Name = "label3";
            label3.Size = new Size(102, 19);
            label3.TabIndex = 32;
            label3.Text = "Presentación:";
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.White;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Enabled = false;
            textBox3.Font = new Font("Itim", 11.9999981F);
            textBox3.Location = new Point(153, 191);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(197, 20);
            textBox3.TabIndex = 31;
            // 
            // gbxEstado
            // 
            gbxEstado.Controls.Add(radioButton1);
            gbxEstado.Controls.Add(rbActivo);
            gbxEstado.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbxEstado.ForeColor = Color.DimGray;
            gbxEstado.Location = new Point(153, 331);
            gbxEstado.Name = "gbxEstado";
            gbxEstado.Size = new Size(275, 50);
            gbxEstado.TabIndex = 30;
            gbxEstado.TabStop = false;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(173, 20);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(70, 23);
            radioButton1.TabIndex = 29;
            radioButton1.TabStop = true;
            radioButton1.Text = "Activo";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // rbActivo
            // 
            rbActivo.AutoSize = true;
            rbActivo.Location = new Point(8, 21);
            rbActivo.Name = "rbActivo";
            rbActivo.Size = new Size(70, 23);
            rbActivo.TabIndex = 28;
            rbActivo.TabStop = true;
            rbActivo.Text = "Activo";
            rbActivo.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Itim", 11.9999981F);
            label6.ForeColor = Color.FromArgb(87, 99, 110);
            label6.Location = new Point(92, 158);
            label6.Name = "label6";
            label6.Size = new Size(55, 19);
            label6.TabIndex = 27;
            label6.Text = "Marca:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(87, 99, 110);
            label5.Location = new Point(89, 355);
            label5.Name = "label5";
            label5.Size = new Size(60, 19);
            label5.TabIndex = 26;
            label5.Text = "Estado:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Itim", 11.9999981F);
            label4.ForeColor = Color.FromArgb(87, 99, 110);
            label4.Location = new Point(68, 126);
            label4.Name = "label4";
            label4.Size = new Size(79, 19);
            label4.TabIndex = 25;
            label4.Text = "Categoría:";
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.White;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Enabled = false;
            textBox2.Font = new Font("Itim", 11.9999981F);
            textBox2.Location = new Point(153, 158);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(197, 20);
            textBox2.TabIndex = 23;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.White;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Enabled = false;
            textBox1.Font = new Font("Itim", 11.9999981F);
            textBox1.Location = new Point(153, 126);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(197, 20);
            textBox1.TabIndex = 22;
            // 
            // tipEditar
            // 
            tipEditar.AutoPopDelay = 5000;
            tipEditar.InitialDelay = 300;
            tipEditar.ReshowDelay = 100;
            // 
            // frmAgregarEditarProducto
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            ClientSize = new Size(864, 581);
            Controls.Add(panel2);
            Controls.Add(panBarraControl);
            Font = new Font("Itim", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAgregarEditarProducto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Producto";
            Load += frmAgregarEditarProducto_Load;
            MouseDown += Editar_Producto_MouseDown;
            panBarraControl.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            fpnlDinamico.ResumeLayout(false);
            pnlDatosGenerales.ResumeLayout(false);
            pnlDatosGenerales.PerformLayout();
            pnlCantidad.ResumeLayout(false);
            pnlCantidad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            pnlCompras.ResumeLayout(false);
            pnlCompras.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPrecioCosto).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecioCompra).EndInit();
            pnlVentas.ResumeLayout(false);
            pnlVentas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPorcentajeGanancia).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecioVenta).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            gbxEstadoProductoNuevo.ResumeLayout(false);
            gbxEstadoProductoNuevo.PerformLayout();
            gbxEstado.ResumeLayout(false);
            gbxEstado.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        public Label lblNombreModulo;
        private Label label8;
        private TextBox txtCodigo;
        private Label label2;
        private Label label1;
        private TextBox txtProducto;
        private Button btnAgregar;
        private Panel panel2;
        private Label label4;
        private TextBox textBox2;
        private TextBox textBox1;
        private RadioButton rbDeshabilitado;
        private RadioButton rbActivo;
        private Label label6;
        private Label label5;
        private GroupBox gbxEstado;
        private Label label3;
        private TextBox textBox3;
        private Button button1;
        private Button button2;
        private Button button4;
        private Button button3;
        private Label label10;
        private TextBox textBox5;
        private Label label7;
        private TextBox textBox4;
        private Panel panel1;
        private Label label9;
        private Label label11;
        private TextBox txtPresentacion;
        private Label label12;
        private TextBox txtMarca;
        private GroupBox gbxEstadoProductoNuevo;
        private RadioButton rbHabilitado;
        private Label label13;
        private Label lblEstado;
        private Label label15;
        private TextBox txtCategoria;
        private Label label16;
        private TextBox txtCodBarra;
        private Label label17;
        private Label label18;
        private TextBox txtNombreProducto;
        private RadioButton radioButton1;
        private Label label19;
        private PictureBox pictureBox1;
        private Button btnBuscarMarca;
        private Button btnBuscarCategoria;
        private Button btnModificarProducto;
        private Button btnVolver;
        private Button btnGuardarProducto;
        private Button btnBuscarPresentacion;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label lblNota;
        private ComboBox cmbUnidadContenido;
        private Label label22;
        private TextBox txtContenido;
        private NumericUpDown nudPrecioCompra;
        private NumericUpDown nudPrecioVenta;
        private NumericUpDown nudCantidad;
        private Panel pnlVentas;
        private NumericUpDown numericUpDown1;
        private Label label20;
        private Panel pnlDatosGenerales;
        private Panel pnlCompras;
        private FlowLayoutPanel fpnlDinamico;
        private ToolTip tipEditar;
        private Panel pnlCantidad;
        private NumericUpDown nudPrecioCosto;
        private Label label14;
        private NumericUpDown nudPorcentajeGanancia;
        private Label label23;
        private ToolTip tipCompras;
        private Label label21;
        private Label label24;
        private Label label25;
        private HelpProvider hpVentaGanancia;
    }
}