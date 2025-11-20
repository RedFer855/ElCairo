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
            txtContenido = new TextBox();
            cmbUnidadContenido = new ComboBox();
            label22 = new Label();
            label21 = new Label();
            pnlNota = new Panel();
            label20 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnGuardarProducto = new Button();
            btnModificarProducto = new Button();
            btnVolver = new Button();
            btnBuscarPresentacion = new Button();
            btnBuscarMarca = new Button();
            btnBuscarCategoria = new Button();
            pictureBox1 = new PictureBox();
            label19 = new Label();
            label9 = new Label();
            txtCantidad = new TextBox();
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
            txtPrecioCompra = new TextBox();
            label16 = new Label();
            txtCodBarra = new TextBox();
            label17 = new Label();
            label18 = new Label();
            txtNombreProducto = new TextBox();
            txtPrecioVenta = new TextBox();
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
            pnlNota.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            panBarraControl.Size = new Size(767, 37);
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
            lblNombreModulo.Size = new Size(767, 37);
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
            // txtPrecio
            // 
            txtPrecio.BackColor = Color.White;
            txtPrecio.BorderStyle = BorderStyle.None;
            txtPrecio.Enabled = false;
            txtPrecio.Font = new Font("Itim", 11.9999981F);
            txtPrecio.Location = new Point(153, 91);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.ReadOnly = true;
            txtPrecio.Size = new Size(275, 20);
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
            panel2.Size = new Size(767, 448);
            panel2.TabIndex = 12;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(189, 215, 238);
            panel1.Controls.Add(txtContenido);
            panel1.Controls.Add(cmbUnidadContenido);
            panel1.Controls.Add(label22);
            panel1.Controls.Add(label21);
            panel1.Controls.Add(pnlNota);
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Controls.Add(btnBuscarPresentacion);
            panel1.Controls.Add(btnBuscarMarca);
            panel1.Controls.Add(btnBuscarCategoria);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label19);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(txtCantidad);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(txtPresentacion);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(txtMarca);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(txtCategoria);
            panel1.Controls.Add(txtPrecioCompra);
            panel1.Controls.Add(label16);
            panel1.Controls.Add(txtCodBarra);
            panel1.Controls.Add(label17);
            panel1.Controls.Add(label18);
            panel1.Controls.Add(txtNombreProducto);
            panel1.Controls.Add(txtPrecioVenta);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(767, 448);
            panel1.TabIndex = 41;
            // 
            // txtContenido
            // 
            txtContenido.BackColor = Color.White;
            txtContenido.BorderStyle = BorderStyle.None;
            txtContenido.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContenido.Location = new Point(153, 270);
            txtContenido.Name = "txtContenido";
            txtContenido.PlaceholderText = "(Cantidad)";
            txtContenido.Size = new Size(120, 20);
            txtContenido.TabIndex = 58;
            // 
            // cmbUnidadContenido
            // 
            cmbUnidadContenido.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbUnidadContenido.FormattingEnabled = true;
            cmbUnidadContenido.Items.AddRange(new object[] { "(Unidades)", "mg", "kg", "g", "lb", "oz", "ml", "cl", "l", "fl(oz)" });
            cmbUnidadContenido.Location = new Point(363, 269);
            cmbUnidadContenido.Name = "cmbUnidadContenido";
            cmbUnidadContenido.Size = new Size(65, 26);
            cmbUnidadContenido.TabIndex = 57;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Itim", 11.9999981F);
            label22.ForeColor = Color.FromArgb(87, 99, 110);
            label22.Location = new Point(279, 271);
            label22.Name = "label22";
            label22.Size = new Size(78, 19);
            label22.TabIndex = 56;
            label22.Text = "Unidades:";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.BackColor = Color.Transparent;
            label21.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label21.ForeColor = Color.DimGray;
            label21.Location = new Point(87, 336);
            label21.Name = "label21";
            label21.Size = new Size(281, 19);
            label21.TabIndex = 54;
            label21.Text = "Al crear el estado por defecto es activo.";
            // 
            // pnlNota
            // 
            pnlNota.Controls.Add(label20);
            pnlNota.Location = new Point(446, 349);
            pnlNota.Name = "pnlNota";
            pnlNota.Size = new Size(300, 87);
            pnlNota.TabIndex = 53;
            // 
            // label20
            // 
            label20.BackColor = Color.FromArgb(148, 168, 187);
            label20.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label20.ForeColor = Color.White;
            label20.Location = new Point(0, 0);
            label20.Name = "label20";
            label20.Size = new Size(300, 84);
            label20.TabIndex = 52;
            label20.Text = "Nota: Para ingresar Inventario de este \r\nproducto, y establecer cantidades \r\nmínimas de inventario deberá realizarlo \r\npor medio de compra.";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnGuardarProducto);
            flowLayoutPanel1.Controls.Add(btnModificarProducto);
            flowLayoutPanel1.Controls.Add(btnVolver);
            flowLayoutPanel1.Location = new Point(34, 389);
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
            // btnBuscarPresentacion
            // 
            btnBuscarPresentacion.BackColor = Color.FromArgb(168, 191, 212);
            btnBuscarPresentacion.BackgroundImage = (Image)resources.GetObject("btnBuscarPresentacion.BackgroundImage");
            btnBuscarPresentacion.BackgroundImageLayout = ImageLayout.Zoom;
            btnBuscarPresentacion.FlatAppearance.BorderSize = 0;
            btnBuscarPresentacion.FlatStyle = FlatStyle.Flat;
            btnBuscarPresentacion.Location = new Point(380, 227);
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
            btnBuscarMarca.Location = new Point(380, 187);
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
            btnBuscarCategoria.Location = new Point(380, 147);
            btnBuscarCategoria.Name = "btnBuscarCategoria";
            btnBuscarCategoria.Size = new Size(48, 20);
            btnBuscarCategoria.TabIndex = 44;
            btnBuscarCategoria.UseVisualStyleBackColor = false;
            btnBuscarCategoria.Click += btnBuscarCategoria_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(446, 28);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(300, 300);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 43;
            pictureBox1.TabStop = false;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Itim", 11.9999981F);
            label19.ForeColor = Color.FromArgb(87, 99, 110);
            label19.Location = new Point(58, 269);
            label19.Name = "label19";
            label19.Size = new Size(84, 19);
            label19.TabIndex = 42;
            label19.Text = "Contenido:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Itim", 11.9999981F);
            label9.ForeColor = Color.FromArgb(87, 99, 110);
            label9.Location = new Point(503, 377);
            label9.Name = "label9";
            label9.Size = new Size(76, 19);
            label9.TabIndex = 40;
            label9.Text = "Cantidad:";
            // 
            // txtCantidad
            // 
            txtCantidad.BackColor = Color.White;
            txtCantidad.BorderStyle = BorderStyle.None;
            txtCantidad.Enabled = false;
            txtCantidad.Font = new Font("Itim", 11.9999981F);
            txtCantidad.Location = new Point(585, 376);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.ReadOnly = true;
            txtCantidad.Size = new Size(116, 20);
            txtCantidad.TabIndex = 39;
            txtCantidad.Text = "0";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Itim", 11.9999981F);
            label11.ForeColor = Color.FromArgb(87, 99, 110);
            label11.Location = new Point(446, 414);
            label11.Name = "label11";
            label11.Size = new Size(133, 19);
            label11.TabIndex = 38;
            label11.Text = "Precio de Compra:";
            // 
            // txtPresentacion
            // 
            txtPresentacion.BackColor = Color.White;
            txtPresentacion.BorderStyle = BorderStyle.None;
            txtPresentacion.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPresentacion.Location = new Point(153, 227);
            txtPresentacion.Name = "txtPresentacion";
            txtPresentacion.PlaceholderText = "(Seleccione Buscar)";
            txtPresentacion.ReadOnly = true;
            txtPresentacion.Size = new Size(221, 20);
            txtPresentacion.TabIndex = 37;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Itim", 11.9999981F);
            label12.ForeColor = Color.FromArgb(87, 99, 110);
            label12.Location = new Point(40, 226);
            label12.Name = "label12";
            label12.Size = new Size(102, 19);
            label12.TabIndex = 32;
            label12.Text = "Presentación:";
            // 
            // txtMarca
            // 
            txtMarca.BackColor = Color.White;
            txtMarca.BorderStyle = BorderStyle.None;
            txtMarca.Font = new Font("Itim", 11.9999981F);
            txtMarca.Location = new Point(153, 187);
            txtMarca.Name = "txtMarca";
            txtMarca.PlaceholderText = "(Seleccione Buscar)";
            txtMarca.ReadOnly = true;
            txtMarca.Size = new Size(221, 20);
            txtMarca.TabIndex = 31;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbDeshabilitado);
            groupBox1.Controls.Add(rbHabilitado);
            groupBox1.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.DimGray;
            groupBox1.Location = new Point(153, 293);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(275, 38);
            groupBox1.TabIndex = 30;
            groupBox1.TabStop = false;
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
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Itim", 11.9999981F);
            label13.ForeColor = Color.FromArgb(87, 99, 110);
            label13.Location = new Point(87, 187);
            label13.Name = "label13";
            label13.Size = new Size(55, 19);
            label13.TabIndex = 27;
            label13.Text = "Marca:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.FromArgb(87, 99, 110);
            label14.Location = new Point(82, 309);
            label14.Name = "label14";
            label14.Size = new Size(60, 19);
            label14.TabIndex = 26;
            label14.Text = "Estado:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Itim", 11.9999981F);
            label15.ForeColor = Color.FromArgb(87, 99, 110);
            label15.Location = new Point(63, 146);
            label15.Name = "label15";
            label15.Size = new Size(79, 19);
            label15.TabIndex = 25;
            label15.Text = "Categoría:";
            // 
            // txtCategoria
            // 
            txtCategoria.BackColor = Color.White;
            txtCategoria.BorderStyle = BorderStyle.None;
            txtCategoria.Font = new Font("Itim", 11.9999981F);
            txtCategoria.Location = new Point(153, 147);
            txtCategoria.Name = "txtCategoria";
            txtCategoria.PlaceholderText = "(Seleccione Buscar)";
            txtCategoria.ReadOnly = true;
            txtCategoria.Size = new Size(221, 20);
            txtCategoria.TabIndex = 23;
            // 
            // txtPrecioCompra
            // 
            txtPrecioCompra.BackColor = Color.White;
            txtPrecioCompra.BorderStyle = BorderStyle.None;
            txtPrecioCompra.Enabled = false;
            txtPrecioCompra.Font = new Font("Itim", 11.9999981F);
            txtPrecioCompra.Location = new Point(585, 414);
            txtPrecioCompra.Name = "txtPrecioCompra";
            txtPrecioCompra.ReadOnly = true;
            txtPrecioCompra.Size = new Size(116, 20);
            txtPrecioCompra.TabIndex = 22;
            txtPrecioCompra.Text = "0";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Itim", 11.9999981F);
            label16.ForeColor = Color.FromArgb(87, 99, 110);
            label16.Location = new Point(19, 29);
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
            txtCodBarra.Location = new Point(153, 27);
            txtCodBarra.Name = "txtCodBarra";
            txtCodBarra.PlaceholderText = "(Ingrese o Escanee el Código)";
            txtCodBarra.Size = new Size(275, 20);
            txtCodBarra.TabIndex = 18;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Itim", 11.9999981F);
            label17.ForeColor = Color.FromArgb(87, 99, 110);
            label17.Location = new Point(22, 107);
            label17.Name = "label17";
            label17.Size = new Size(120, 19);
            label17.TabIndex = 16;
            label17.Text = "Precio de Venta:";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Itim", 11.9999981F);
            label18.ForeColor = Color.FromArgb(87, 99, 110);
            label18.Location = new Point(66, 67);
            label18.Name = "label18";
            label18.Size = new Size(76, 19);
            label18.TabIndex = 15;
            label18.Text = "Producto:";
            // 
            // txtNombreProducto
            // 
            txtNombreProducto.BackColor = Color.White;
            txtNombreProducto.BorderStyle = BorderStyle.None;
            txtNombreProducto.Font = new Font("Itim", 11.9999981F);
            txtNombreProducto.Location = new Point(153, 67);
            txtNombreProducto.Name = "txtNombreProducto";
            txtNombreProducto.Size = new Size(275, 20);
            txtNombreProducto.TabIndex = 13;
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.BackColor = Color.White;
            txtPrecioVenta.BorderStyle = BorderStyle.None;
            txtPrecioVenta.Font = new Font("Itim", 11.9999981F);
            txtPrecioVenta.Location = new Point(153, 107);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(275, 20);
            txtPrecioVenta.TabIndex = 12;
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
            // frmAgregarEditarProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(767, 485);
            Controls.Add(panel2);
            Controls.Add(panBarraControl);
            Font = new Font("Itim", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAgregarEditarProducto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Producto";
            MouseDown += Editar_Producto_MouseDown;
            panBarraControl.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            pnlNota.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private TextBox txtCantidad;
        private Label label11;
        private TextBox txtPresentacion;
        private Label label12;
        private TextBox txtMarca;
        private GroupBox groupBox1;
        private RadioButton rbHabilitado;
        private Label label13;
        private Label label14;
        private Label label15;
        private TextBox txtCategoria;
        private TextBox txtPrecioCompra;
        private Label label16;
        private TextBox txtCodBarra;
        private Label label17;
        private Label label18;
        private TextBox txtNombreProducto;
        private TextBox txtPrecioVenta;
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
        private Label label20;
        private Panel pnlNota;
        private Label label21;
        private ComboBox cmbUnidadContenido;
        private Label label22;
        private TextBox txtContenido;
    }
}