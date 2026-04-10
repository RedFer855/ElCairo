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
            Panel panBarraControl;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarEditarProducto));
            lblNombreModulo = new Label();
            label8 = new Label();
            txtCodigo = new TextBox();
            label2 = new Label();
            label1 = new Label();
            txtProducto = new TextBox();
            txtPrecio = new TextBox();
            btnAgregar = new Button();
            panel2 = new Panel();
            panel1 = new Panel();
            btnModoGanancia = new Button();
            txtPrecioCosto = new NumericUpDown();
            label20 = new Label();
            btnImagenes = new Button();
            Imagen_Producto = new PictureBox();
            txtPrecioCompra = new NumericUpDown();
            txtPrecioVenta = new NumericUpDown();
            txtContenido = new TextBox();
            cmbUnidadContenido = new ComboBox();
            label22 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnGuardarProducto = new Button();
            btnModificarProducto = new Button();
            btnVolver = new Button();
            btnBuscarPresentacion = new Button();
            btnBuscarMarca = new Button();
            btnBuscarCategoria = new Button();
            label19 = new Label();
            label11 = new Label();
            txtPresentacion = new TextBox();
            label12 = new Label();
            txtMarca = new TextBox();
            groupBox1 = new GroupBox();
            rbDeshabilitado = new RadioButton();
            rbHabilitado = new RadioButton();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            txtCategoria = new TextBox();
            label16 = new Label();
            txtCodBarra = new TextBox();
            label17 = new Label();
            label18 = new Label();
            txtNombreProducto = new TextBox();
            txtTipoGanancia = new TextBox();
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
            panBarraControl = new Panel();
            panBarraControl.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtPrecioCosto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Imagen_Producto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPrecioCompra).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPrecioVenta).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
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
            panBarraControl.Size = new Size(878, 37);
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
            lblNombreModulo.Size = new Size(878, 37);
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
            label8.Size = new Size(74, 24);
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
            txtCodigo.Size = new Size(275, 24);
            txtCodigo.TabIndex = 18;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Itim", 11.9999981F);
            label2.ForeColor = Color.FromArgb(87, 99, 110);
            label2.Location = new Point(27, 91);
            label2.Name = "label2";
            label2.Size = new Size(149, 24);
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
            label1.Size = new Size(93, 24);
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
            txtProducto.Size = new Size(275, 24);
            txtProducto.TabIndex = 13;
            // 
            // txtPrecio
            // 
            txtPrecio.BackColor = Color.White;
            txtPrecio.BorderStyle = BorderStyle.None;
            txtPrecio.Enabled = false;
            txtPrecio.Font = new Font("Itim", 11.9999981F);
            txtPrecio.Location = new Point(153, 91);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.ReadOnly = true;
            txtPrecio.Size = new Size(275, 24);
            txtPrecio.TabIndex = 12;
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
            panel2.Controls.Add(txtPrecio);
            panel2.Controls.Add(btnAgregar);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 37);
            panel2.Name = "panel2";
            panel2.Size = new Size(878, 526);
            panel2.TabIndex = 12;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(189, 215, 238);
            panel1.Controls.Add(btnModoGanancia);
            panel1.Controls.Add(txtPrecioCosto);
            panel1.Controls.Add(label20);
            panel1.Controls.Add(btnImagenes);
            panel1.Controls.Add(Imagen_Producto);
            panel1.Controls.Add(txtPrecioCompra);
            panel1.Controls.Add(txtPrecioVenta);
            panel1.Controls.Add(txtContenido);
            panel1.Controls.Add(cmbUnidadContenido);
            panel1.Controls.Add(label22);
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Controls.Add(btnBuscarPresentacion);
            panel1.Controls.Add(btnBuscarMarca);
            panel1.Controls.Add(btnBuscarCategoria);
            panel1.Controls.Add(label19);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(txtPresentacion);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(txtMarca);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(txtCategoria);
            panel1.Controls.Add(label16);
            panel1.Controls.Add(txtCodBarra);
            panel1.Controls.Add(label17);
            panel1.Controls.Add(label18);
            panel1.Controls.Add(txtNombreProducto);
            panel1.Controls.Add(txtTipoGanancia);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(878, 526);
            panel1.TabIndex = 41;
            // 
            // btnModoGanancia
            // 
            btnModoGanancia.BackColor = Color.FromArgb(74, 148, 225);
            btnModoGanancia.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnModoGanancia.ForeColor = SystemColors.Window;
            btnModoGanancia.Location = new Point(387, 270);
            btnModoGanancia.Name = "btnModoGanancia";
            btnModoGanancia.Size = new Size(131, 111);
            btnModoGanancia.TabIndex = 67;
            btnModoGanancia.Text = "Editar Precios y Ganancias";
            btnModoGanancia.UseVisualStyleBackColor = false;
            btnModoGanancia.Click += btnModoGanancia_Click;
            // 
            // txtPrecioCosto
            // 
            txtPrecioCosto.DecimalPlaces = 2;
            txtPrecioCosto.Enabled = false;
            txtPrecioCosto.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPrecioCosto.ForeColor = Color.DimGray;
            txtPrecioCosto.Location = new Point(243, 356);
            txtPrecioCosto.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            txtPrecioCosto.Name = "txtPrecioCosto";
            txtPrecioCosto.Size = new Size(138, 30);
            txtPrecioCosto.TabIndex = 65;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Itim", 11.9999981F);
            label20.ForeColor = Color.FromArgb(87, 99, 110);
            label20.Location = new Point(80, 357);
            label20.Name = "label20";
            label20.Size = new Size(148, 24);
            label20.TabIndex = 64;
            label20.Text = "Precio de Costo:";
            // 
            // btnImagenes
            // 
            btnImagenes.BackColor = Color.FromArgb(149, 195, 172);
            btnImagenes.Cursor = Cursors.Hand;
            btnImagenes.Font = new Font("Itim", 11.9999981F);
            btnImagenes.ForeColor = Color.White;
            btnImagenes.Location = new Point(540, 331);
            btnImagenes.Name = "btnImagenes";
            btnImagenes.Size = new Size(300, 43);
            btnImagenes.TabIndex = 63;
            btnImagenes.Text = "Consultar Imagenes ya guardadas";
            btnImagenes.UseVisualStyleBackColor = false;
            btnImagenes.Click += btnImagenes_Click;
            // 
            // Imagen_Producto
            // 
            Imagen_Producto.BackColor = Color.Silver;
            Imagen_Producto.BackgroundImage = Properties.Resources.buscar;
            Imagen_Producto.BackgroundImageLayout = ImageLayout.Center;
            Imagen_Producto.BorderStyle = BorderStyle.FixedSingle;
            Imagen_Producto.Location = new Point(540, 27);
            Imagen_Producto.Name = "Imagen_Producto";
            Imagen_Producto.Size = new Size(300, 300);
            Imagen_Producto.SizeMode = PictureBoxSizeMode.Zoom;
            Imagen_Producto.TabIndex = 62;
            Imagen_Producto.TabStop = false;
            Imagen_Producto.Click += Imagen_Producto_Click;
            // 
            // txtPrecioCompra
            // 
            txtPrecioCompra.DecimalPlaces = 2;
            txtPrecioCompra.Enabled = false;
            txtPrecioCompra.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPrecioCompra.ForeColor = Color.DimGray;
            txtPrecioCompra.Location = new Point(243, 313);
            txtPrecioCompra.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            txtPrecioCompra.Name = "txtPrecioCompra";
            txtPrecioCompra.Size = new Size(138, 30);
            txtPrecioCompra.TabIndex = 60;
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.DecimalPlaces = 2;
            txtPrecioVenta.Enabled = false;
            txtPrecioVenta.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPrecioVenta.ForeColor = Color.DimGray;
            txtPrecioVenta.Location = new Point(243, 269);
            txtPrecioVenta.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(138, 30);
            txtPrecioVenta.TabIndex = 59;
            // 
            // txtContenido
            // 
            txtContenido.BackColor = Color.White;
            txtContenido.BorderStyle = BorderStyle.None;
            txtContenido.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContenido.Location = new Point(243, 219);
            txtContenido.Name = "txtContenido";
            txtContenido.PlaceholderText = "(Cantidad)";
            txtContenido.Size = new Size(108, 24);
            txtContenido.TabIndex = 58;
            // 
            // cmbUnidadContenido
            // 
            cmbUnidadContenido.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbUnidadContenido.ForeColor = Color.DimGray;
            cmbUnidadContenido.FormattingEnabled = true;
            cmbUnidadContenido.Items.AddRange(new object[] { "(Unidades)", "mg", "kg", "g", "lb", "oz", "ml", "cl", "l", "fl(oz)" });
            cmbUnidadContenido.Location = new Point(441, 217);
            cmbUnidadContenido.Name = "cmbUnidadContenido";
            cmbUnidadContenido.Size = new Size(77, 31);
            cmbUnidadContenido.TabIndex = 57;
            cmbUnidadContenido.SelectedIndexChanged += cmbUnidadContenido_SelectedIndexChanged;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Itim", 11.9999981F);
            label22.ForeColor = Color.FromArgb(87, 99, 110);
            label22.Location = new Point(357, 219);
            label22.Name = "label22";
            label22.Size = new Size(95, 24);
            label22.TabIndex = 56;
            label22.Text = "Unidades:";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            flowLayoutPanel1.Controls.Add(btnGuardarProducto);
            flowLayoutPanel1.Controls.Add(btnModificarProducto);
            flowLayoutPanel1.Controls.Add(btnVolver);
            flowLayoutPanel1.Location = new Point(540, 387);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(200, 127);
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
            btnVolver.Location = new Point(3, 49);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(86, 40);
            btnVolver.TabIndex = 46;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnBuscarPresentacion
            // 
            btnBuscarPresentacion.BackColor = Color.FromArgb(168, 191, 212);
            btnBuscarPresentacion.BackgroundImage = (Image)resources.GetObject("btnBuscarPresentacion.BackgroundImage");
            btnBuscarPresentacion.BackgroundImageLayout = ImageLayout.Zoom;
            btnBuscarPresentacion.FlatAppearance.BorderSize = 0;
            btnBuscarPresentacion.FlatStyle = FlatStyle.Flat;
            btnBuscarPresentacion.Location = new Point(470, 179);
            btnBuscarPresentacion.Name = "btnBuscarPresentacion";
            btnBuscarPresentacion.Size = new Size(48, 20);
            btnBuscarPresentacion.TabIndex = 49;
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
            btnBuscarMarca.Location = new Point(470, 139);
            btnBuscarMarca.Name = "btnBuscarMarca";
            btnBuscarMarca.Size = new Size(48, 20);
            btnBuscarMarca.TabIndex = 45;
            btnBuscarMarca.UseVisualStyleBackColor = false;
            btnBuscarMarca.Click += btnBuscarMarca_Click;
            // 
            // btnBuscarCategoria
            // 
            btnBuscarCategoria.BackColor = Color.FromArgb(168, 191, 212);
            btnBuscarCategoria.BackgroundImage = (Image)resources.GetObject("btnBuscarCategoria.BackgroundImage");
            btnBuscarCategoria.BackgroundImageLayout = ImageLayout.Zoom;
            btnBuscarCategoria.FlatAppearance.BorderSize = 0;
            btnBuscarCategoria.FlatStyle = FlatStyle.Flat;
            btnBuscarCategoria.Location = new Point(470, 98);
            btnBuscarCategoria.Name = "btnBuscarCategoria";
            btnBuscarCategoria.Size = new Size(48, 20);
            btnBuscarCategoria.TabIndex = 44;
            btnBuscarCategoria.UseVisualStyleBackColor = false;
            btnBuscarCategoria.Click += btnBuscarCategoria_Click;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Itim", 11.9999981F);
            label19.ForeColor = Color.FromArgb(87, 99, 110);
            label19.Location = new Point(115, 217);
            label19.Name = "label19";
            label19.Size = new Size(103, 24);
            label19.TabIndex = 42;
            label19.Text = "Contenido:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Itim", 11.9999981F);
            label11.ForeColor = Color.FromArgb(87, 99, 110);
            label11.Location = new Point(68, 314);
            label11.Name = "label11";
            label11.Size = new Size(167, 24);
            label11.TabIndex = 38;
            label11.Text = "Precio de Compra:";
            // 
            // txtPresentacion
            // 
            txtPresentacion.BackColor = Color.White;
            txtPresentacion.BorderStyle = BorderStyle.None;
            txtPresentacion.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPresentacion.Location = new Point(243, 179);
            txtPresentacion.Name = "txtPresentacion";
            txtPresentacion.PlaceholderText = "(Seleccione Buscar)";
            txtPresentacion.ReadOnly = true;
            txtPresentacion.Size = new Size(221, 24);
            txtPresentacion.TabIndex = 37;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Itim", 11.9999981F);
            label12.ForeColor = Color.FromArgb(87, 99, 110);
            label12.Location = new Point(97, 176);
            label12.Name = "label12";
            label12.Size = new Size(127, 24);
            label12.TabIndex = 32;
            label12.Text = "Presentación:";
            // 
            // txtMarca
            // 
            txtMarca.BackColor = Color.White;
            txtMarca.BorderStyle = BorderStyle.None;
            txtMarca.Font = new Font("Itim", 11.9999981F);
            txtMarca.Location = new Point(243, 139);
            txtMarca.Name = "txtMarca";
            txtMarca.PlaceholderText = "(Seleccione Buscar)";
            txtMarca.ReadOnly = true;
            txtMarca.Size = new Size(221, 24);
            txtMarca.TabIndex = 31;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbDeshabilitado);
            groupBox1.Controls.Add(rbHabilitado);
            groupBox1.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.DimGray;
            groupBox1.Location = new Point(243, 387);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(196, 44);
            groupBox1.TabIndex = 30;
            groupBox1.TabStop = false;
            // 
            // rbDeshabilitado
            // 
            rbDeshabilitado.AutoSize = true;
            rbDeshabilitado.Location = new Point(90, 15);
            rbDeshabilitado.Name = "rbDeshabilitado";
            rbDeshabilitado.Size = new Size(100, 28);
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
            rbHabilitado.Size = new Size(84, 28);
            rbHabilitado.TabIndex = 28;
            rbHabilitado.TabStop = true;
            rbHabilitado.Text = "Activo";
            rbHabilitado.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Itim", 11.9999981F);
            label13.ForeColor = Color.FromArgb(87, 99, 110);
            label13.Location = new Point(144, 138);
            label13.Name = "label13";
            label13.Size = new Size(68, 24);
            label13.TabIndex = 27;
            label13.Text = "Marca:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.FromArgb(87, 99, 110);
            label14.Location = new Point(149, 402);
            label14.Name = "label14";
            label14.Size = new Size(73, 24);
            label14.TabIndex = 26;
            label14.Text = "Estado:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Itim", 11.9999981F);
            label15.ForeColor = Color.FromArgb(87, 99, 110);
            label15.Location = new Point(123, 98);
            label15.Name = "label15";
            label15.Size = new Size(99, 24);
            label15.TabIndex = 25;
            label15.Text = "Categoría:";
            // 
            // txtCategoria
            // 
            txtCategoria.BackColor = Color.White;
            txtCategoria.BorderStyle = BorderStyle.None;
            txtCategoria.Font = new Font("Itim", 11.9999981F);
            txtCategoria.Location = new Point(243, 98);
            txtCategoria.Name = "txtCategoria";
            txtCategoria.PlaceholderText = "(Seleccione Buscar)";
            txtCategoria.ReadOnly = true;
            txtCategoria.Size = new Size(221, 24);
            txtCategoria.TabIndex = 23;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Itim", 11.9999981F);
            label16.ForeColor = Color.FromArgb(87, 99, 110);
            label16.Location = new Point(76, 27);
            label16.Name = "label16";
            label16.Size = new Size(154, 24);
            label16.TabIndex = 19;
            label16.Text = "Código de Barra:";
            // 
            // txtCodBarra
            // 
            txtCodBarra.BackColor = Color.White;
            txtCodBarra.BorderStyle = BorderStyle.None;
            txtCodBarra.Font = new Font("Itim", 11.9999981F);
            txtCodBarra.Location = new Point(243, 27);
            txtCodBarra.MaxLength = 13;
            txtCodBarra.Name = "txtCodBarra";
            txtCodBarra.PlaceholderText = "(Ingrese o Escanee el Código)";
            txtCodBarra.Size = new Size(275, 24);
            txtCodBarra.TabIndex = 18;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Itim", 11.9999981F);
            label17.ForeColor = Color.FromArgb(87, 99, 110);
            label17.Location = new Point(82, 270);
            label17.Name = "label17";
            label17.Size = new Size(149, 24);
            label17.TabIndex = 16;
            label17.Text = "Precio de Venta:";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Itim", 11.9999981F);
            label18.ForeColor = Color.FromArgb(87, 99, 110);
            label18.Location = new Point(126, 64);
            label18.Name = "label18";
            label18.Size = new Size(93, 24);
            label18.TabIndex = 15;
            label18.Text = "Producto:";
            // 
            // txtNombreProducto
            // 
            txtNombreProducto.BackColor = Color.White;
            txtNombreProducto.BorderStyle = BorderStyle.None;
            txtNombreProducto.Font = new Font("Itim", 11.9999981F);
            txtNombreProducto.Location = new Point(243, 67);
            txtNombreProducto.Name = "txtNombreProducto";
            txtNombreProducto.PlaceholderText = "(Nombre del Producto)";
            txtNombreProducto.Size = new Size(275, 24);
            txtNombreProducto.TabIndex = 13;
            // 
            // txtTipoGanancia
            // 
            txtTipoGanancia.BackColor = Color.White;
            txtTipoGanancia.BorderStyle = BorderStyle.None;
            txtTipoGanancia.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTipoGanancia.Location = new Point(584, 300);
            txtTipoGanancia.Name = "txtTipoGanancia";
            txtTipoGanancia.PlaceholderText = "Osmany Gay";
            txtTipoGanancia.ReadOnly = true;
            txtTipoGanancia.Size = new Size(102, 24);
            txtTipoGanancia.TabIndex = 69;
            txtTipoGanancia.Visible = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Itim", 11.9999981F);
            label10.ForeColor = Color.FromArgb(87, 99, 110);
            label10.Location = new Point(70, 259);
            label10.Name = "label10";
            label10.Size = new Size(93, 24);
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
            textBox5.Size = new Size(197, 24);
            textBox5.TabIndex = 39;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Itim", 11.9999981F);
            label7.ForeColor = Color.FromArgb(87, 99, 110);
            label7.Location = new Point(34, 225);
            label7.Name = "label7";
            label7.Size = new Size(142, 24);
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
            textBox4.Size = new Size(197, 24);
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
            label3.Size = new Size(127, 24);
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
            textBox3.Size = new Size(197, 24);
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
            radioButton1.Size = new Size(84, 28);
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
            rbActivo.Size = new Size(84, 28);
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
            label6.Size = new Size(68, 24);
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
            label5.Size = new Size(73, 24);
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
            label4.Size = new Size(99, 24);
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
            textBox2.Size = new Size(197, 24);
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
            textBox1.Size = new Size(197, 24);
            textBox1.TabIndex = 22;
            // 
            // frmAgregarEditarProducto
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            ClientSize = new Size(878, 563);
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
            ((System.ComponentModel.ISupportInitialize)txtPrecioCosto).EndInit();
            ((System.ComponentModel.ISupportInitialize)Imagen_Producto).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPrecioCompra).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPrecioVenta).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
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
        private TextBox txtPrecio;
        private Button btnAgregar;
        private Panel panel2;
        private Label label4;
        private TextBox textBox2;
        private TextBox textBox1;
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
        private RadioButton radioButton1;
        private Panel panel1;
        private Button btnModoGanancia;
        private NumericUpDown txtPrecioCosto;
        private Label label20;
        private Button btnImagenes;
        private PictureBox Imagen_Producto;
        private NumericUpDown txtPrecioCompra;
        private NumericUpDown txtPrecioVenta;
        private TextBox txtContenido;
        private ComboBox cmbUnidadContenido;
        private Label label22;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnGuardarProducto;
        private Button btnModificarProducto;
        private Button btnVolver;
        private Button btnBuscarPresentacion;
        private Button btnBuscarMarca;
        private Button btnBuscarCategoria;
        private Label label19;
        private Label label11;
        private TextBox txtPresentacion;
        private Label label12;
        private TextBox txtMarca;
        private GroupBox groupBox1;
        private RadioButton rbDeshabilitado;
        private RadioButton rbHabilitado;
        private Label label13;
        private Label label14;
        private Label label15;
        private TextBox txtCategoria;
        private Label label16;
        private TextBox txtCodBarra;
        private Label label18;
        private TextBox txtNombreProducto;
        private Label label17;
        private TextBox txtTipoGanancia;
    }
}