namespace ModernMenuUI
{
    partial class Editar_Producto
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
            lblNombreModulo = new Label();
            label8 = new Label();
            txtCodigo = new TextBox();
            label2 = new Label();
            label1 = new Label();
            txtPrecio = new TextBox();
            btnAgregar = new Button();
            panel2 = new Panel();
            panel1 = new Panel();
            label11 = new Label();
            txtPrecioCompra = new TextBox();
            label17 = new Label();
            txtPrecioVenta = new TextBox();
            label19 = new Label();
            txtPrecioCosto = new TextBox();
            label9 = new Label();
            txtCantidad = new TextBox();
            txtGanancia = new TextBox();
            btnVerMarca = new Button();
            btnVerCategoria = new Button();
            button8 = new Button();
            label12 = new Label();
            txtMarca = new TextBox();
            groupBox1 = new GroupBox();
            rbInactivo = new RadioButton();
            rbActivo = new RadioButton();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            txtCategoria = new TextBox();
            label16 = new Label();
            txtCodBarra = new TextBox();
            label18 = new Label();
            txtNombreProducto = new TextBox();
            btnGuardar = new Button();
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
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            panBarraControl = new Panel();
            panBarraControl.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
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
            panBarraControl.Margin = new Padding(3, 4, 3, 4);
            panBarraControl.Name = "panBarraControl";
            panBarraControl.Size = new Size(550, 83);
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
            lblNombreModulo.Size = new Size(550, 83);
            lblNombreModulo.TabIndex = 8;
            lblNombreModulo.Text = "EDITAR PRODUCTO";
            lblNombreModulo.TextAlign = ContentAlignment.MiddleCenter;
            lblNombreModulo.Click += lblNombreModulo_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Itim", 11.9999981F);
            label8.ForeColor = Color.FromArgb(87, 99, 110);
            label8.Location = new Point(94, 28);
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
            txtCodigo.Location = new Point(175, 25);
            txtCodigo.Margin = new Padding(3, 4, 3, 4);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.ReadOnly = true;
            txtCodigo.Size = new Size(314, 24);
            txtCodigo.TabIndex = 18;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Itim", 11.9999981F);
            label2.ForeColor = Color.FromArgb(87, 99, 110);
            label2.Location = new Point(31, 131);
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
            label1.Location = new Point(81, 83);
            label1.Name = "label1";
            label1.Size = new Size(93, 24);
            label1.TabIndex = 15;
            label1.Text = "Producto:";
            // 
            // txtPrecio
            // 
            txtPrecio.BackColor = Color.White;
            txtPrecio.BorderStyle = BorderStyle.None;
            txtPrecio.Enabled = false;
            txtPrecio.Font = new Font("Itim", 11.9999981F);
            txtPrecio.Location = new Point(175, 131);
            txtPrecio.Margin = new Padding(3, 4, 3, 4);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.ReadOnly = true;
            txtPrecio.Size = new Size(314, 24);
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
            btnAgregar.Location = new Point(51, 569);
            btnAgregar.Margin = new Padding(3, 4, 3, 4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(143, 61);
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
            panel2.Controls.Add(txtPrecio);
            panel2.Controls.Add(btnAgregar);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 83);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(550, 646);
            panel2.TabIndex = 12;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(189, 215, 238);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(txtPrecioCompra);
            panel1.Controls.Add(label17);
            panel1.Controls.Add(txtPrecioVenta);
            panel1.Controls.Add(label19);
            panel1.Controls.Add(txtPrecioCosto);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(txtCantidad);
            panel1.Controls.Add(txtGanancia);
            panel1.Controls.Add(btnVerMarca);
            panel1.Controls.Add(btnVerCategoria);
            panel1.Controls.Add(button8);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(txtMarca);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(txtCategoria);
            panel1.Controls.Add(label16);
            panel1.Controls.Add(txtCodBarra);
            panel1.Controls.Add(label18);
            panel1.Controls.Add(txtNombreProducto);
            panel1.Controls.Add(btnGuardar);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(550, 646);
            panel1.TabIndex = 41;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Itim", 11.9999981F);
            label11.ForeColor = Color.FromArgb(87, 99, 110);
            label11.Location = new Point(26, 257);
            label11.Name = "label11";
            label11.Size = new Size(142, 24);
            label11.TabIndex = 46;
            label11.Text = "Precio Compra:";
            // 
            // txtPrecioCompra
            // 
            txtPrecioCompra.BackColor = Color.White;
            txtPrecioCompra.BorderStyle = BorderStyle.None;
            txtPrecioCompra.Font = new Font("Itim", 11.9999981F);
            txtPrecioCompra.Location = new Point(174, 257);
            txtPrecioCompra.Margin = new Padding(3, 4, 3, 4);
            txtPrecioCompra.Name = "txtPrecioCompra";
            txtPrecioCompra.Size = new Size(314, 24);
            txtPrecioCompra.TabIndex = 45;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Itim", 11.9999981F);
            label17.ForeColor = Color.FromArgb(87, 99, 110);
            label17.Location = new Point(19, 353);
            label17.Name = "label17";
            label17.Size = new Size(149, 24);
            label17.TabIndex = 44;
            label17.Text = "Precio de Venta:";
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.BackColor = Color.White;
            txtPrecioVenta.BorderStyle = BorderStyle.None;
            txtPrecioVenta.Font = new Font("Itim", 11.9999981F);
            txtPrecioVenta.Location = new Point(174, 353);
            txtPrecioVenta.Margin = new Padding(3, 4, 3, 4);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(314, 24);
            txtPrecioVenta.TabIndex = 43;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Itim", 11.9999981F);
            label19.ForeColor = Color.FromArgb(87, 99, 110);
            label19.Location = new Point(45, 305);
            label19.Name = "label19";
            label19.Size = new Size(123, 24);
            label19.TabIndex = 42;
            label19.Text = "Precio Costo:";
            // 
            // txtPrecioCosto
            // 
            txtPrecioCosto.BackColor = Color.White;
            txtPrecioCosto.BorderStyle = BorderStyle.None;
            txtPrecioCosto.Font = new Font("Itim", 11.9999981F);
            txtPrecioCosto.Location = new Point(174, 305);
            txtPrecioCosto.Margin = new Padding(3, 4, 3, 4);
            txtPrecioCosto.Name = "txtPrecioCosto";
            txtPrecioCosto.Size = new Size(314, 24);
            txtPrecioCosto.TabIndex = 41;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Itim", 11.9999981F);
            label9.ForeColor = Color.FromArgb(87, 99, 110);
            label9.Location = new Point(69, 400);
            label9.Name = "label9";
            label9.Size = new Size(93, 24);
            label9.TabIndex = 40;
            label9.Text = "Cantidad:";
            // 
            // txtCantidad
            // 
            txtCantidad.BackColor = Color.White;
            txtCantidad.BorderStyle = BorderStyle.None;
            txtCantidad.Font = new Font("Itim", 11.9999981F);
            txtCantidad.Location = new Point(168, 397);
            txtCantidad.Margin = new Padding(3, 4, 3, 4);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(314, 24);
            txtCantidad.TabIndex = 39;
            // 
            // txtGanancia
            // 
            txtGanancia.BackColor = Color.White;
            txtGanancia.BorderStyle = BorderStyle.None;
            txtGanancia.Font = new Font("Itim", 11.9999981F);
            txtGanancia.Location = new Point(174, 212);
            txtGanancia.Margin = new Padding(3, 4, 3, 4);
            txtGanancia.Name = "txtGanancia";
            txtGanancia.Size = new Size(314, 24);
            txtGanancia.TabIndex = 37;
            // 
            // btnVerMarca
            // 
            btnVerMarca.BackColor = Color.FromArgb(148, 168, 187);
            btnVerMarca.BackgroundImageLayout = ImageLayout.None;
            btnVerMarca.FlatAppearance.BorderSize = 0;
            btnVerMarca.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnVerMarca.ForeColor = SystemColors.ButtonFace;
            btnVerMarca.ImageAlign = ContentAlignment.BottomLeft;
            btnVerMarca.Location = new Point(406, 167);
            btnVerMarca.Margin = new Padding(3, 4, 3, 4);
            btnVerMarca.Name = "btnVerMarca";
            btnVerMarca.Size = new Size(82, 37);
            btnVerMarca.TabIndex = 36;
            btnVerMarca.Text = "Ver";
            btnVerMarca.UseVisualStyleBackColor = false;
            btnVerMarca.Click += btnVerMarca_Click;
            // 
            // btnVerCategoria
            // 
            btnVerCategoria.BackColor = Color.FromArgb(148, 168, 187);
            btnVerCategoria.BackgroundImageLayout = ImageLayout.None;
            btnVerCategoria.FlatAppearance.BorderSize = 0;
            btnVerCategoria.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnVerCategoria.ForeColor = SystemColors.ButtonFace;
            btnVerCategoria.ImageAlign = ContentAlignment.BottomLeft;
            btnVerCategoria.Location = new Point(406, 122);
            btnVerCategoria.Margin = new Padding(3, 4, 3, 4);
            btnVerCategoria.Name = "btnVerCategoria";
            btnVerCategoria.Size = new Size(82, 37);
            btnVerCategoria.TabIndex = 35;
            btnVerCategoria.Text = "Ver";
            btnVerCategoria.UseVisualStyleBackColor = false;
            btnVerCategoria.Click += btnVerCategoria_Click;
            // 
            // button8
            // 
            button8.BackColor = Color.FromArgb(148, 168, 187);
            button8.BackgroundImageLayout = ImageLayout.None;
            button8.FlatAppearance.BorderSize = 0;
            button8.Font = new Font("Itim", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button8.ForeColor = SystemColors.ButtonFace;
            button8.ImageAlign = ContentAlignment.BottomLeft;
            button8.Location = new Point(346, 569);
            button8.Margin = new Padding(3, 4, 3, 4);
            button8.Name = "button8";
            button8.Size = new Size(143, 61);
            button8.TabIndex = 33;
            button8.Text = "Volver";
            button8.UseVisualStyleBackColor = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Itim", 11.9999981F);
            label12.ForeColor = Color.FromArgb(87, 99, 110);
            label12.Location = new Point(67, 212);
            label12.Name = "label12";
            label12.Size = new Size(95, 24);
            label12.TabIndex = 32;
            label12.Text = "Ganancia:";
            // 
            // txtMarca
            // 
            txtMarca.BackColor = Color.White;
            txtMarca.BorderStyle = BorderStyle.None;
            txtMarca.Enabled = false;
            txtMarca.Font = new Font("Itim", 11.9999981F);
            txtMarca.Location = new Point(174, 175);
            txtMarca.Margin = new Padding(3, 4, 3, 4);
            txtMarca.Name = "txtMarca";
            txtMarca.ReadOnly = true;
            txtMarca.Size = new Size(225, 24);
            txtMarca.TabIndex = 31;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbInactivo);
            groupBox1.Controls.Add(rbActivo);
            groupBox1.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.DimGray;
            groupBox1.Location = new Point(177, 457);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(314, 72);
            groupBox1.TabIndex = 30;
            groupBox1.TabStop = false;
            groupBox1.Enter += groupBox1_Enter;
            // 
            // rbInactivo
            // 
            rbInactivo.AutoSize = true;
            rbInactivo.Location = new Point(180, 28);
            rbInactivo.Margin = new Padding(3, 4, 3, 4);
            rbInactivo.Name = "rbInactivo";
            rbInactivo.Size = new Size(100, 28);
            rbInactivo.TabIndex = 29;
            rbInactivo.TabStop = true;
            rbInactivo.Text = "Inactivo";
            rbInactivo.UseVisualStyleBackColor = true;
            // 
            // rbActivo
            // 
            rbActivo.AutoSize = true;
            rbActivo.Location = new Point(24, 28);
            rbActivo.Margin = new Padding(3, 4, 3, 4);
            rbActivo.Name = "rbActivo";
            rbActivo.Size = new Size(84, 28);
            rbActivo.TabIndex = 28;
            rbActivo.TabStop = true;
            rbActivo.Text = "Activo";
            rbActivo.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Itim", 11.9999981F);
            label13.ForeColor = Color.FromArgb(87, 99, 110);
            label13.Location = new Point(94, 173);
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
            label14.Location = new Point(102, 476);
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
            label15.Location = new Point(63, 128);
            label15.Name = "label15";
            label15.Size = new Size(99, 24);
            label15.TabIndex = 25;
            label15.Text = "Categoría:";
            // 
            // txtCategoria
            // 
            txtCategoria.BackColor = Color.White;
            txtCategoria.BorderStyle = BorderStyle.None;
            txtCategoria.Enabled = false;
            txtCategoria.Font = new Font("Itim", 11.9999981F);
            txtCategoria.Location = new Point(174, 127);
            txtCategoria.Margin = new Padding(3, 4, 3, 4);
            txtCategoria.Name = "txtCategoria";
            txtCategoria.ReadOnly = true;
            txtCategoria.Size = new Size(225, 24);
            txtCategoria.TabIndex = 23;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Itim", 11.9999981F);
            label16.ForeColor = Color.FromArgb(87, 99, 110);
            label16.Location = new Point(8, 25);
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
            txtCodBarra.Location = new Point(175, 25);
            txtCodBarra.Margin = new Padding(3, 4, 3, 4);
            txtCodBarra.Name = "txtCodBarra";
            txtCodBarra.Size = new Size(314, 24);
            txtCodBarra.TabIndex = 18;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Itim", 11.9999981F);
            label18.ForeColor = Color.FromArgb(87, 99, 110);
            label18.Location = new Point(69, 80);
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
            txtNombreProducto.Location = new Point(168, 80);
            txtNombreProducto.Margin = new Padding(3, 4, 3, 4);
            txtNombreProducto.Name = "txtNombreProducto";
            txtNombreProducto.Size = new Size(314, 24);
            txtNombreProducto.TabIndex = 13;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(149, 195, 172);
            btnGuardar.BackgroundImageLayout = ImageLayout.None;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Font = new Font("Itim", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = SystemColors.ButtonFace;
            btnGuardar.ImageAlign = ContentAlignment.BottomLeft;
            btnGuardar.Location = new Point(51, 569);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(143, 61);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += button9_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Itim", 11.9999981F);
            label10.ForeColor = Color.FromArgb(87, 99, 110);
            label10.Location = new Point(80, 369);
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
            textBox5.Location = new Point(175, 368);
            textBox5.Margin = new Padding(3, 4, 3, 4);
            textBox5.Name = "textBox5";
            textBox5.ReadOnly = true;
            textBox5.Size = new Size(225, 24);
            textBox5.TabIndex = 39;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Itim", 11.9999981F);
            label7.ForeColor = Color.FromArgb(87, 99, 110);
            label7.Location = new Point(39, 321);
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
            textBox4.Location = new Point(175, 321);
            textBox4.Margin = new Padding(3, 4, 3, 4);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(225, 24);
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
            button4.Location = new Point(407, 265);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(82, 37);
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
            button3.Location = new Point(407, 220);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(82, 37);
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
            button2.Location = new Point(407, 175);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(82, 37);
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
            button1.Location = new Point(234, 569);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(143, 61);
            button1.TabIndex = 33;
            button1.Text = "Volver";
            button1.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Itim", 11.9999981F);
            label3.ForeColor = Color.FromArgb(87, 99, 110);
            label3.Location = new Point(51, 272);
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
            textBox3.Location = new Point(175, 273);
            textBox3.Margin = new Padding(3, 4, 3, 4);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(225, 24);
            textBox3.TabIndex = 31;
            // 
            // gbxEstado
            // 
            gbxEstado.Controls.Add(radioButton1);
            gbxEstado.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbxEstado.ForeColor = Color.DimGray;
            gbxEstado.Location = new Point(175, 473);
            gbxEstado.Margin = new Padding(3, 4, 3, 4);
            gbxEstado.Name = "gbxEstado";
            gbxEstado.Padding = new Padding(3, 4, 3, 4);
            gbxEstado.Size = new Size(314, 72);
            gbxEstado.TabIndex = 30;
            gbxEstado.TabStop = false;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(198, 28);
            radioButton1.Margin = new Padding(3, 4, 3, 4);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(84, 28);
            radioButton1.TabIndex = 29;
            radioButton1.TabStop = true;
            radioButton1.Text = "Activo";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Itim", 11.9999981F);
            label6.ForeColor = Color.FromArgb(87, 99, 110);
            label6.Location = new Point(105, 225);
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
            label5.Location = new Point(102, 507);
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
            label4.Location = new Point(78, 180);
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
            textBox2.Location = new Point(175, 225);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(225, 24);
            textBox2.TabIndex = 23;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.White;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Enabled = false;
            textBox1.Font = new Font("Itim", 11.9999981F);
            textBox1.Location = new Point(175, 180);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(225, 24);
            textBox1.TabIndex = 22;
            // 
            // Editar_Producto
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(550, 729);
            Controls.Add(panel2);
            Controls.Add(panBarraControl);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Editar_Producto";
            Text = "Editar_Producto";
            Load += Editar_Producto_Load;
            MouseDown += Editar_Producto_MouseDown;
            panBarraControl.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
        private TextBox txtPrecio;
        private Button btnAgregar;
        private Panel panel2;
        private Label label4;
        private TextBox textBox2;
        private TextBox textBox1;
        private RadioButton radioButton2;
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
        private TextBox txtGanancia;
        private Button btnVerMarca;
        private Button btnVerCategoria;
        private Button button8;
        private Label label12;
        private TextBox txtMarca;
        private GroupBox groupBox1;
        private Label label13;
        private Label label14;
        private Label label15;
        private TextBox txtCategoria;
        private Label label16;
        private TextBox txtCodBarra;
        private Label label18;
        private TextBox txtNombreProducto;
        private Button btnGuardar;
        private RadioButton radioButton1;
        private Label label19;
        private TextBox txtPrecioCosto;
        private Label label11;
        private TextBox txtPrecioCompra;
        private Label label17;
        private TextBox txtPrecioVenta;
        private RadioButton rbInactivo;
    }
}