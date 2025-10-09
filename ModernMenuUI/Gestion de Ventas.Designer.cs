namespace ModernMenuUI
{
    partial class Gestion_de_Ventas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gestion_de_Ventas));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            btnSalir = new Button();
            button1 = new Button();
            label4 = new Label();
            textBox4 = new TextBox();
            panel5 = new Panel();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            button2 = new Button();
            panel4 = new Panel();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            panelCarrito = new Panel();
            panel10 = new Panel();
            pictureBox1 = new PictureBox();
            dgvCarrito = new DataGridView();
            panelBusqueda = new Panel();
            txtBuscar = new TextBox();
            buscar = new Button();
            panel1 = new Panel();
            panel7 = new Panel();
            dgvProductos = new DataGridView();
            Codigos = new DataGridViewTextBoxColumn();
            Producto = new DataGridViewTextBoxColumn();
            Precio = new DataGridViewTextBoxColumn();
            Stock = new DataGridViewTextBoxColumn();
            panel2 = new Panel();
            label8 = new Label();
            txtCodigo = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtProducto = new TextBox();
            txtPrecio = new TextBox();
            txtCantidad = new TextBox();
            btnAgregar = new Button();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            Restar = new DataGridViewImageColumn();
            Sumar = new DataGridViewImageColumn();
            Eliminar = new DataGridViewImageColumn();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panelCarrito.SuspendLayout();
            panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).BeginInit();
            panelBusqueda.SuspendLayout();
            panel1.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalir.BackColor = Color.FromArgb(148, 168, 187);
            btnSalir.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.White;
            btnSalir.ImageAlign = ContentAlignment.TopCenter;
            btnSalir.Location = new Point(671, 598);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(66, 63);
            btnSalir.TabIndex = 17;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.BackColor = Color.FromArgb(189, 215, 238);
            button1.Location = new Point(578, 598);
            button1.Name = "button1";
            button1.Size = new Size(87, 63);
            button1.TabIndex = 15;
            button1.Text = "Imprimir";
            button1.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(10, 16);
            label4.Name = "label4";
            label4.Size = new Size(78, 17);
            label4.TabIndex = 16;
            label4.Text = "No. Factura:";
            // 
            // textBox4
            // 
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox4.Location = new Point(91, 14);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(148, 20);
            textBox4.TabIndex = 13;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(189, 215, 238);
            panel5.Controls.Add(label4);
            panel5.Controls.Add(textBox4);
            panel5.Location = new Point(29, 12);
            panel5.Name = "panel5";
            panel5.Size = new Size(258, 51);
            panel5.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(165, 6);
            label7.Name = "label7";
            label7.Size = new Size(63, 17);
            label7.TabIndex = 21;
            label7.Text = "Impuesto:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(261, 6);
            label6.Name = "label6";
            label6.Size = new Size(42, 17);
            label6.TabIndex = 19;
            label6.Text = "Total:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(14, 6);
            label5.Name = "label5";
            label5.Size = new Size(60, 17);
            label5.TabIndex = 18;
            label5.Text = "Subtotal:";
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.BackColor = Color.FromArgb(149, 195, 172);
            button2.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Location = new Point(464, 598);
            button2.Name = "button2";
            button2.Size = new Size(108, 63);
            button2.TabIndex = 16;
            button2.Text = "Cerrar Venta";
            button2.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel4.BackColor = Color.FromArgb(189, 215, 238);
            panel4.Controls.Add(textBox3);
            panel4.Controls.Add(textBox2);
            panel4.Controls.Add(textBox1);
            panel4.Controls.Add(label7);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(label5);
            panel4.Location = new Point(29, 598);
            panel4.Name = "panel4";
            panel4.Size = new Size(429, 63);
            panel4.TabIndex = 13;
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox3.Location = new Point(261, 27);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(153, 22);
            textBox3.TabIndex = 24;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(165, 27);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(90, 22);
            textBox2.TabIndex = 23;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(14, 27);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(145, 22);
            textBox1.TabIndex = 22;
            // 
            // panelCarrito
            // 
            panelCarrito.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelCarrito.BackColor = Color.FromArgb(189, 215, 238);
            panelCarrito.Controls.Add(panel10);
            panelCarrito.Location = new Point(29, 309);
            panelCarrito.Name = "panelCarrito";
            panelCarrito.Size = new Size(708, 273);
            panelCarrito.TabIndex = 12;
            // 
            // panel10
            // 
            panel10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel10.Controls.Add(pictureBox1);
            panel10.Controls.Add(dgvCarrito);
            panel10.Location = new Point(21, 19);
            panel10.Name = "panel10";
            panel10.Size = new Size(666, 237);
            panel10.TabIndex = 17;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(40, 39);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // dgvCarrito
            // 
            dgvCarrito.AllowUserToAddRows = false;
            dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCarrito.BackgroundColor = Color.FromArgb(189, 215, 238);
            dgvCarrito.BorderStyle = BorderStyle.None;
            dgvCarrito.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCarrito.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle1.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCarrito.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCarrito.ColumnHeadersHeight = 40;
            dgvCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCarrito.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, Restar, Sumar, Eliminar });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle3.Padding = new Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvCarrito.DefaultCellStyle = dataGridViewCellStyle3;
            dgvCarrito.Dock = DockStyle.Fill;
            dgvCarrito.EnableHeadersVisualStyles = false;
            dgvCarrito.GridColor = Color.FromArgb(189, 215, 238);
            dgvCarrito.Location = new Point(0, 0);
            dgvCarrito.Name = "dgvCarrito";
            dgvCarrito.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(102, 102, 102);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvCarrito.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvCarrito.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvCarrito.RowTemplate.Height = 50;
            dgvCarrito.Size = new Size(666, 237);
            dgvCarrito.TabIndex = 1;
            dgvCarrito.CellClick += dgvCarrito_CellClick;
            dgvCarrito.CellContentClick += dgvCarrito_CellContentClick;
            dgvCarrito.CellMouseDown += dgvCarrito_CellMouseDown;
            dgvCarrito.CellMouseEnter += dgvCarrito_CellMouseEnter;
            dgvCarrito.CellMouseLeave += dgvCarrito_CellMouseLeave;
            dgvCarrito.CellMouseUp += dgvCarrito_CellMouseUp;
            dgvCarrito.CellValueChanged += dgvCarrito_CellValueChanged;
            // 
            // panelBusqueda
            // 
            panelBusqueda.BackColor = Color.FromArgb(189, 215, 238);
            panelBusqueda.Controls.Add(txtBuscar);
            panelBusqueda.Controls.Add(buscar);
            panelBusqueda.Location = new Point(308, 12);
            panelBusqueda.Name = "panelBusqueda";
            panelBusqueda.Size = new Size(429, 51);
            panelBusqueda.TabIndex = 9;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.BorderStyle = BorderStyle.None;
            txtBuscar.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(21, 14);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar Productos...";
            txtBuscar.Size = new Size(338, 20);
            txtBuscar.TabIndex = 1;
            // 
            // buscar
            // 
            buscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buscar.BackColor = Color.FromArgb(168, 191, 212);
            buscar.BackgroundImage = (Image)resources.GetObject("buscar.BackgroundImage");
            buscar.BackgroundImageLayout = ImageLayout.Zoom;
            buscar.FlatAppearance.BorderSize = 0;
            buscar.FlatStyle = FlatStyle.Flat;
            buscar.Location = new Point(366, 14);
            buscar.Name = "buscar";
            buscar.Size = new Size(48, 23);
            buscar.TabIndex = 0;
            buscar.UseVisualStyleBackColor = false;
            buscar.Click += buscar_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(189, 215, 238);
            panel1.Controls.Add(panel7);
            panel1.Location = new Point(308, 84);
            panel1.Name = "panel1";
            panel1.Size = new Size(429, 207);
            panel1.TabIndex = 10;
            // 
            // panel7
            // 
            panel7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel7.AutoSize = true;
            panel7.BackColor = Color.FromArgb(189, 215, 238);
            panel7.Controls.Add(dgvProductos);
            panel7.Location = new Point(21, 17);
            panel7.Name = "panel7";
            panel7.Size = new Size(390, 173);
            panel7.TabIndex = 11;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.BackgroundColor = Color.FromArgb(189, 215, 238);
            dgvProductos.BorderStyle = BorderStyle.None;
            dgvProductos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProductos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle5.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvProductos.ColumnHeadersHeight = 40;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvProductos.Columns.AddRange(new DataGridViewColumn[] { Codigos, Producto, Precio, Stock });
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.White;
            dataGridViewCellStyle7.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle7.Padding = new Padding(5);
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle7.SelectionForeColor = Color.White;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            dgvProductos.DefaultCellStyle = dataGridViewCellStyle7;
            dgvProductos.Dock = DockStyle.Fill;
            dgvProductos.EnableHeadersVisualStyles = false;
            dgvProductos.GridColor = Color.FromArgb(189, 215, 238);
            dgvProductos.Location = new Point(0, 0);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Control;
            dataGridViewCellStyle8.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(102, 102, 102);
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            dgvProductos.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dgvProductos.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvProductos.RowTemplate.Height = 40;
            dgvProductos.Size = new Size(390, 173);
            dgvProductos.TabIndex = 0;
            dgvProductos.SelectionChanged += dgvProductos_SelectionChanged;
            // 
            // Codigos
            // 
            dataGridViewCellStyle6.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.Padding = new Padding(0, 1, 0, 0);
            Codigos.DefaultCellStyle = dataGridViewCellStyle6;
            Codigos.FillWeight = 80F;
            Codigos.HeaderText = "Id";
            Codigos.Name = "Codigos";
            // 
            // Producto
            // 
            Producto.FillWeight = 200F;
            Producto.HeaderText = "Producto";
            Producto.Name = "Producto";
            // 
            // Precio
            // 
            Precio.FillWeight = 80F;
            Precio.HeaderText = "Precio";
            Precio.Name = "Precio";
            // 
            // Stock
            // 
            Stock.FillWeight = 80F;
            Stock.HeaderText = "Stock";
            Stock.Name = "Stock";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(189, 215, 238);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(txtCodigo);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtProducto);
            panel2.Controls.Add(txtPrecio);
            panel2.Controls.Add(txtCantidad);
            panel2.Controls.Add(btnAgregar);
            panel2.Location = new Point(28, 84);
            panel2.Name = "panel2";
            panel2.Size = new Size(259, 207);
            panel2.TabIndex = 11;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(12, 17);
            label8.Name = "label8";
            label8.Size = new Size(47, 17);
            label8.TabIndex = 19;
            label8.Text = "Código:";
            // 
            // txtCodigo
            // 
            txtCodigo.BorderStyle = BorderStyle.None;
            txtCodigo.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCodigo.Location = new Point(80, 17);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.ReadOnly = true;
            txtCodigo.Size = new Size(160, 20);
            txtCodigo.TabIndex = 18;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(10, 108);
            label3.Name = "label3";
            label3.Size = new Size(59, 17);
            label3.TabIndex = 17;
            label3.Text = "Cantidad:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(15, 75);
            label2.Name = "label2";
            label2.Size = new Size(46, 17);
            label2.TabIndex = 16;
            label2.Text = "Precio:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(10, 46);
            label1.Name = "label1";
            label1.Size = new Size(60, 17);
            label1.TabIndex = 15;
            label1.Text = "Producto:";
            // 
            // txtProducto
            // 
            txtProducto.BorderStyle = BorderStyle.None;
            txtProducto.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProducto.Location = new Point(80, 46);
            txtProducto.Name = "txtProducto";
            txtProducto.ReadOnly = true;
            txtProducto.Size = new Size(160, 20);
            txtProducto.TabIndex = 13;
            // 
            // txtPrecio
            // 
            txtPrecio.BorderStyle = BorderStyle.None;
            txtPrecio.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPrecio.Location = new Point(80, 75);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.ReadOnly = true;
            txtPrecio.Size = new Size(160, 20);
            txtPrecio.TabIndex = 12;
            // 
            // txtCantidad
            // 
            txtCantidad.BorderStyle = BorderStyle.None;
            txtCantidad.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCantidad.Location = new Point(80, 108);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.PlaceholderText = "Ingrese la Cantidad...";
            txtCantidad.Size = new Size(160, 20);
            txtCantidad.TabIndex = 11;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(149, 195, 172);
            btnAgregar.BackgroundImage = (Image)resources.GetObject("btnAgregar.BackgroundImage");
            btnAgregar.BackgroundImageLayout = ImageLayout.None;
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.Font = new Font("Itim", 18.25F);
            btnAgregar.ForeColor = SystemColors.ButtonFace;
            btnAgregar.ImageAlign = ContentAlignment.BottomLeft;
            btnAgregar.Location = new Point(15, 144);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Padding = new Padding(40, 0, 0, 0);
            btnAgregar.Size = new Size(225, 46);
            btnAgregar.TabIndex = 10;
            btnAgregar.Text = "Añadir";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle2.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.Padding = new Padding(0, 1, 0, 0);
            dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewTextBoxColumn1.FillWeight = 50F;
            dataGridViewTextBoxColumn1.HeaderText = "Id";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.FillWeight = 120F;
            dataGridViewTextBoxColumn2.HeaderText = "Producto";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.FillWeight = 60F;
            dataGridViewTextBoxColumn3.HeaderText = "Precio";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.FillWeight = 70F;
            dataGridViewTextBoxColumn4.HeaderText = "Cantidad";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // Restar
            // 
            Restar.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Restar.HeaderText = "";
            Restar.Name = "Restar";
            Restar.Resizable = DataGridViewTriState.True;
            Restar.Width = 50;
            // 
            // Sumar
            // 
            Sumar.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Sumar.HeaderText = "";
            Sumar.Name = "Sumar";
            Sumar.Resizable = DataGridViewTriState.True;
            Sumar.Width = 50;
            // 
            // Eliminar
            // 
            Eliminar.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Eliminar.HeaderText = "";
            Eliminar.Name = "Eliminar";
            Eliminar.Resizable = DataGridViewTriState.True;
            Eliminar.Width = 50;
            // 
            // Gestion_de_Ventas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(766, 679);
            Controls.Add(btnSalir);
            Controls.Add(button1);
            Controls.Add(panel5);
            Controls.Add(button2);
            Controls.Add(panel4);
            Controls.Add(panelCarrito);
            Controls.Add(panelBusqueda);
            Controls.Add(panel1);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Gestion_de_Ventas";
            Text = "Gestion_de_Ventas";
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panelCarrito.ResumeLayout(false);
            panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).EndInit();
            panelBusqueda.ResumeLayout(false);
            panelBusqueda.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnSalir;
        private Button button1;
        private Label label4;
        private TextBox textBox4;
        private Panel panel5;
        private Label label7;
        private Label label6;
        private Label label5;
        private Button button2;
        private Panel panel4;
        private Panel panelCarrito;
        private Panel panelBusqueda;
        private TextBox txtBuscar;
        private Button buscar;
        private Panel panel1;
        private Panel panel2;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtProducto;
        private TextBox txtPrecio;
        private TextBox txtCantidad;
        private Button btnAgregar;
        private DataGridView dgvProductos;
        private Panel panel7;
        private Panel panel10;
        private DataGridView dgvCarrito;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private PictureBox pictureBox1;
        private Label label8;
        private TextBox txtCodigo;
        private DataGridViewTextBoxColumn Codigos;
        private DataGridViewTextBoxColumn Producto;
        private DataGridViewTextBoxColumn Precio;
        private DataGridViewTextBoxColumn Stock;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewImageColumn Restar;
        private DataGridViewImageColumn Sumar;
        private DataGridViewImageColumn Eliminar;
    }
}