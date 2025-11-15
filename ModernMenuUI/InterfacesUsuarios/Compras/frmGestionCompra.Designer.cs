namespace ModernMenuUI
{
    partial class frmGestionCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGestionCompra));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            btnSalir = new Button();
            btnImprimirOrden = new Button();
            panel5 = new Panel();
            btnBuscarCliente = new Button();
            textBox4 = new TextBox();
            label4 = new Label();
            button2 = new Button();
            panel4 = new Panel();
            panel9 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel8 = new Panel();
            txtTotal = new TextBox();
            label6 = new Label();
            panel3 = new Panel();
            txtImpuesto = new TextBox();
            label7 = new Label();
            panel6 = new Panel();
            txtSubTotal = new TextBox();
            label5 = new Label();
            panelCarrito = new Panel();
            panel10 = new Panel();
            pbxCarritoVacio = new PictureBox();
            pbxCarrito = new PictureBox();
            dgvCarrito = new DataGridView();
            colCodigo = new DataGridViewTextBoxColumn();
            colProducto = new DataGridViewTextBoxColumn();
            colPrecio = new DataGridViewTextBoxColumn();
            colCantidad = new DataGridViewTextBoxColumn();
            Restar = new DataGridViewImageColumn();
            Sumar = new DataGridViewImageColumn();
            Eliminar = new DataGridViewImageColumn();
            panelBusqueda = new Panel();
            txtBuscar = new TextBox();
            btnBuscarProductos = new Button();
            panel1 = new Panel();
            panel7 = new Panel();
            dgvProductos = new DataGridView();
            Codigos = new DataGridViewTextBoxColumn();
            Producto = new DataGridViewTextBoxColumn();
            Precio = new DataGridViewTextBoxColumn();
            Stock = new DataGridViewTextBoxColumn();
            panel2 = new Panel();
            nudCantidad = new NumericUpDown();
            label9 = new Label();
            label8 = new Label();
            txtCodigo = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtProducto = new TextBox();
            txtPrecio = new TextBox();
            btnAgregar = new Button();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel8.SuspendLayout();
            panel3.SuspendLayout();
            panel6.SuspendLayout();
            panelCarrito.SuspendLayout();
            panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxCarritoVacio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxCarrito).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).BeginInit();
            panelBusqueda.SuspendLayout();
            panel1.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalir.BackColor = Color.FromArgb(148, 168, 187);
            btnSalir.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.White;
            btnSalir.ImageAlign = ContentAlignment.TopCenter;
            btnSalir.Location = new Point(770, 816);
            btnSalir.Margin = new Padding(3, 4, 3, 4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(91, 84);
            btnSalir.TabIndex = 26;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click_1;
            // 
            // btnImprimirOrden
            // 
            btnImprimirOrden.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnImprimirOrden.BackColor = Color.FromArgb(189, 215, 238);
            btnImprimirOrden.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnImprimirOrden.ForeColor = Color.FromArgb(87, 99, 110);
            btnImprimirOrden.Location = new Point(610, 816);
            btnImprimirOrden.Margin = new Padding(3, 4, 3, 4);
            btnImprimirOrden.Name = "btnImprimirOrden";
            btnImprimirOrden.Size = new Size(153, 84);
            btnImprimirOrden.TabIndex = 24;
            btnImprimirOrden.Text = "Imprimir Orden";
            btnImprimirOrden.UseVisualStyleBackColor = false;
            btnImprimirOrden.Click += button1_Click;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(189, 215, 238);
            panel5.Controls.Add(btnBuscarCliente);
            panel5.Controls.Add(textBox4);
            panel5.Controls.Add(label4);
            panel5.Location = new Point(14, 5);
            panel5.Margin = new Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(329, 68);
            panel5.TabIndex = 23;
            // 
            // btnBuscarCliente
            // 
            btnBuscarCliente.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuscarCliente.BackColor = Color.FromArgb(168, 191, 212);
            btnBuscarCliente.BackgroundImage = (Image)resources.GetObject("btnBuscarCliente.BackgroundImage");
            btnBuscarCliente.BackgroundImageLayout = ImageLayout.Zoom;
            btnBuscarCliente.FlatAppearance.BorderSize = 0;
            btnBuscarCliente.FlatStyle = FlatStyle.Flat;
            btnBuscarCliente.Location = new Point(254, 20);
            btnBuscarCliente.Margin = new Padding(3, 4, 3, 4);
            btnBuscarCliente.Name = "btnBuscarCliente";
            btnBuscarCliente.Size = new Size(55, 27);
            btnBuscarCliente.TabIndex = 2;
            btnBuscarCliente.UseVisualStyleBackColor = false;
            // 
            // textBox4
            // 
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.Enabled = false;
            textBox4.Font = new Font("Itim", 13F);
            textBox4.Location = new Point(77, 19);
            textBox4.Margin = new Padding(3, 4, 3, 4);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(169, 26);
            textBox4.TabIndex = 22;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(87, 99, 110);
            label4.Location = new Point(11, 21);
            label4.Name = "label4";
            label4.Size = new Size(61, 20);
            label4.TabIndex = 16;
            label4.Text = "Cliente:";
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.BackColor = Color.FromArgb(149, 195, 172);
            button2.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Location = new Point(480, 816);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(123, 84);
            button2.TabIndex = 25;
            button2.Text = "Ingresar Compra";
            button2.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel4.BackColor = Color.FromArgb(189, 215, 238);
            panel4.Controls.Add(panel9);
            panel4.Controls.Add(tableLayoutPanel1);
            panel4.Location = new Point(14, 816);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(459, 84);
            panel4.TabIndex = 22;
            // 
            // panel9
            // 
            panel9.Dock = DockStyle.Left;
            panel9.Location = new Point(0, 84);
            panel9.Margin = new Padding(3, 4, 3, 4);
            panel9.Name = "panel9";
            panel9.Size = new Size(34, 0);
            panel9.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 7;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.147059F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.3921566F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.352941F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.833334F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6.372549F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.90196F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.Controls.Add(panel8, 5, 0);
            tableLayoutPanel1.Controls.Add(panel3, 3, 0);
            tableLayoutPanel1.Controls.Add(panel6, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(459, 84);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel8
            // 
            panel8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel8.Controls.Add(txtTotal);
            panel8.Controls.Add(label6);
            panel8.Location = new Point(304, 4);
            panel8.Margin = new Padding(3, 4, 3, 4);
            panel8.Name = "panel8";
            panel8.Size = new Size(123, 68);
            panel8.TabIndex = 24;
            // 
            // txtTotal
            // 
            txtTotal.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTotal.BorderStyle = BorderStyle.None;
            txtTotal.Enabled = false;
            txtTotal.Font = new Font("Itim", 18F);
            txtTotal.Location = new Point(0, 23);
            txtTotal.Margin = new Padding(3, 4, 3, 4);
            txtTotal.Name = "txtTotal";
            txtTotal.PlaceholderText = "L0,00";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(123, 36);
            txtTotal.TabIndex = 24;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Top;
            label6.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(0, 0);
            label6.Name = "label6";
            label6.Size = new Size(50, 20);
            label6.TabIndex = 19;
            label6.Text = "Total:";
            // 
            // panel3
            // 
            panel3.Controls.Add(txtImpuesto);
            panel3.Controls.Add(label7);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(187, 4);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(84, 76);
            panel3.TabIndex = 22;
            // 
            // txtImpuesto
            // 
            txtImpuesto.BorderStyle = BorderStyle.None;
            txtImpuesto.Dock = DockStyle.Fill;
            txtImpuesto.Enabled = false;
            txtImpuesto.Font = new Font("Itim", 18F);
            txtImpuesto.Location = new Point(0, 20);
            txtImpuesto.Margin = new Padding(3, 4, 3, 4);
            txtImpuesto.Name = "txtImpuesto";
            txtImpuesto.PlaceholderText = "L0,00";
            txtImpuesto.ReadOnly = true;
            txtImpuesto.Size = new Size(84, 36);
            txtImpuesto.TabIndex = 22;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Top;
            label7.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(0, 0);
            label7.Name = "label7";
            label7.Size = new Size(78, 20);
            label7.TabIndex = 21;
            label7.Text = "Impuesto:";
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel6.Controls.Add(txtSubTotal);
            panel6.Controls.Add(label5);
            panel6.Location = new Point(25, 4);
            panel6.Margin = new Padding(3, 4, 3, 4);
            panel6.Name = "panel6";
            panel6.Size = new Size(125, 68);
            panel6.TabIndex = 23;
            // 
            // txtSubTotal
            // 
            txtSubTotal.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSubTotal.BorderStyle = BorderStyle.None;
            txtSubTotal.Enabled = false;
            txtSubTotal.Font = new Font("Itim", 18F);
            txtSubTotal.Location = new Point(0, 23);
            txtSubTotal.Margin = new Padding(3, 4, 3, 4);
            txtSubTotal.Name = "txtSubTotal";
            txtSubTotal.PlaceholderText = "L0,00";
            txtSubTotal.ReadOnly = true;
            txtSubTotal.Size = new Size(125, 36);
            txtSubTotal.TabIndex = 23;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Top;
            label5.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(74, 20);
            label5.TabIndex = 18;
            label5.Text = "Subtotal:";
            // 
            // panelCarrito
            // 
            panelCarrito.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelCarrito.BackColor = Color.FromArgb(189, 215, 238);
            panelCarrito.Controls.Add(panel10);
            panelCarrito.Location = new Point(14, 401);
            panelCarrito.Margin = new Padding(3, 4, 3, 4);
            panelCarrito.Name = "panelCarrito";
            panelCarrito.Size = new Size(848, 407);
            panelCarrito.TabIndex = 21;
            // 
            // panel10
            // 
            panel10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel10.Controls.Add(pbxCarritoVacio);
            panel10.Controls.Add(pbxCarrito);
            panel10.Controls.Add(dgvCarrito);
            panel10.Location = new Point(23, 15);
            panel10.Margin = new Padding(3, 4, 3, 4);
            panel10.Name = "panel10";
            panel10.Size = new Size(802, 372);
            panel10.TabIndex = 17;
            // 
            // pbxCarritoVacio
            // 
            pbxCarritoVacio.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pbxCarritoVacio.BackColor = Color.Transparent;
            pbxCarritoVacio.Image = Properties.Resources.carro_vacio;
            pbxCarritoVacio.Location = new Point(309, 129);
            pbxCarritoVacio.Margin = new Padding(3, 4, 3, 4);
            pbxCarritoVacio.Name = "pbxCarritoVacio";
            pbxCarritoVacio.Size = new Size(197, 172);
            pbxCarritoVacio.SizeMode = PictureBoxSizeMode.Zoom;
            pbxCarritoVacio.TabIndex = 3;
            pbxCarritoVacio.TabStop = false;
            // 
            // pbxCarrito
            // 
            pbxCarrito.BackColor = Color.Transparent;
            pbxCarrito.Image = (Image)resources.GetObject("pbxCarrito.Image");
            pbxCarrito.Location = new Point(0, 0);
            pbxCarrito.Margin = new Padding(3, 4, 3, 4);
            pbxCarrito.Name = "pbxCarrito";
            pbxCarrito.Size = new Size(46, 53);
            pbxCarrito.TabIndex = 2;
            pbxCarrito.TabStop = false;
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
            dgvCarrito.Columns.AddRange(new DataGridViewColumn[] { colCodigo, colProducto, colPrecio, colCantidad, Restar, Sumar, Eliminar });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.Padding = new Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvCarrito.DefaultCellStyle = dataGridViewCellStyle3;
            dgvCarrito.Dock = DockStyle.Fill;
            dgvCarrito.EnableHeadersVisualStyles = false;
            dgvCarrito.GridColor = Color.FromArgb(189, 215, 238);
            dgvCarrito.Location = new Point(0, 0);
            dgvCarrito.Margin = new Padding(3, 4, 3, 4);
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
            dgvCarrito.RowHeadersWidth = 51;
            dgvCarrito.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvCarrito.RowTemplate.Height = 50;
            dgvCarrito.Size = new Size(802, 372);
            dgvCarrito.TabIndex = 1;
            dgvCarrito.CellClick += dgvCarrito_CellClick;
            // 
            // colCodigo
            // 
            dataGridViewCellStyle2.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.Padding = new Padding(0, 1, 0, 0);
            colCodigo.DefaultCellStyle = dataGridViewCellStyle2;
            colCodigo.FillWeight = 50F;
            colCodigo.HeaderText = "Código";
            colCodigo.MinimumWidth = 6;
            colCodigo.Name = "colCodigo";
            // 
            // colProducto
            // 
            colProducto.FillWeight = 120F;
            colProducto.HeaderText = "Producto";
            colProducto.MinimumWidth = 6;
            colProducto.Name = "colProducto";
            // 
            // colPrecio
            // 
            colPrecio.FillWeight = 60F;
            colPrecio.HeaderText = "Precio";
            colPrecio.MinimumWidth = 6;
            colPrecio.Name = "colPrecio";
            // 
            // colCantidad
            // 
            colCantidad.FillWeight = 70F;
            colCantidad.HeaderText = "Cantidad";
            colCantidad.MinimumWidth = 6;
            colCantidad.Name = "colCantidad";
            // 
            // Restar
            // 
            Restar.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Restar.HeaderText = "";
            Restar.MinimumWidth = 6;
            Restar.Name = "Restar";
            Restar.Resizable = DataGridViewTriState.True;
            Restar.Width = 50;
            // 
            // Sumar
            // 
            Sumar.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Sumar.HeaderText = "";
            Sumar.MinimumWidth = 6;
            Sumar.Name = "Sumar";
            Sumar.Resizable = DataGridViewTriState.True;
            Sumar.Width = 50;
            // 
            // Eliminar
            // 
            Eliminar.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Eliminar.HeaderText = "";
            Eliminar.MinimumWidth = 6;
            Eliminar.Name = "Eliminar";
            Eliminar.Resizable = DataGridViewTriState.True;
            Eliminar.Width = 50;
            // 
            // panelBusqueda
            // 
            panelBusqueda.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelBusqueda.BackColor = Color.FromArgb(189, 215, 238);
            panelBusqueda.Controls.Add(txtBuscar);
            panelBusqueda.Controls.Add(btnBuscarProductos);
            panelBusqueda.Location = new Point(350, 5);
            panelBusqueda.Margin = new Padding(3, 4, 3, 4);
            panelBusqueda.Name = "panelBusqueda";
            panelBusqueda.Size = new Size(512, 68);
            panelBusqueda.TabIndex = 18;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.BorderStyle = BorderStyle.None;
            txtBuscar.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(24, 19);
            txtBuscar.Margin = new Padding(3, 4, 3, 4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar Productos...";
            txtBuscar.Size = new Size(403, 24);
            txtBuscar.TabIndex = 1;
            // 
            // btnBuscarProductos
            // 
            btnBuscarProductos.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuscarProductos.BackColor = Color.FromArgb(168, 191, 212);
            btnBuscarProductos.BackgroundImage = (Image)resources.GetObject("btnBuscarProductos.BackgroundImage");
            btnBuscarProductos.BackgroundImageLayout = ImageLayout.Zoom;
            btnBuscarProductos.FlatAppearance.BorderSize = 0;
            btnBuscarProductos.FlatStyle = FlatStyle.Flat;
            btnBuscarProductos.Location = new Point(434, 17);
            btnBuscarProductos.Margin = new Padding(3, 4, 3, 4);
            btnBuscarProductos.Name = "btnBuscarProductos";
            btnBuscarProductos.Size = new Size(55, 27);
            btnBuscarProductos.TabIndex = 0;
            btnBuscarProductos.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(189, 215, 238);
            panel1.Controls.Add(panel7);
            panel1.Location = new Point(350, 81);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(512, 312);
            panel1.TabIndex = 19;
            // 
            // panel7
            // 
            panel7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel7.AutoSize = true;
            panel7.BackColor = Color.FromArgb(189, 215, 238);
            panel7.Controls.Add(dgvProductos);
            panel7.Location = new Point(24, 16);
            panel7.Margin = new Padding(3, 4, 3, 4);
            panel7.Name = "panel7";
            panel7.Size = new Size(465, 280);
            panel7.TabIndex = 12;
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
            dataGridViewCellStyle7.ForeColor = Color.White;
            dataGridViewCellStyle7.Padding = new Padding(5);
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle7.SelectionForeColor = Color.White;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            dgvProductos.DefaultCellStyle = dataGridViewCellStyle7;
            dgvProductos.Dock = DockStyle.Fill;
            dgvProductos.EnableHeadersVisualStyles = false;
            dgvProductos.GridColor = Color.FromArgb(189, 215, 238);
            dgvProductos.Location = new Point(0, 0);
            dgvProductos.Margin = new Padding(3, 4, 3, 4);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Control;
            dataGridViewCellStyle8.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            dgvProductos.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvProductos.RowTemplate.Height = 40;
            dgvProductos.Size = new Size(465, 280);
            dgvProductos.TabIndex = 0;
            dgvProductos.SelectionChanged += dgvProductos_SelectionChanged;
            // 
            // Codigos
            // 
            dataGridViewCellStyle6.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.Padding = new Padding(0, 1, 0, 0);
            Codigos.DefaultCellStyle = dataGridViewCellStyle6;
            Codigos.FillWeight = 90F;
            Codigos.HeaderText = "Código";
            Codigos.MinimumWidth = 6;
            Codigos.Name = "Codigos";
            // 
            // Producto
            // 
            Producto.FillWeight = 200F;
            Producto.HeaderText = "Producto";
            Producto.MinimumWidth = 6;
            Producto.Name = "Producto";
            // 
            // Precio
            // 
            Precio.FillWeight = 80F;
            Precio.HeaderText = "Precio";
            Precio.MinimumWidth = 6;
            Precio.Name = "Precio";
            // 
            // Stock
            // 
            Stock.FillWeight = 80F;
            Stock.HeaderText = "Stock";
            Stock.MinimumWidth = 6;
            Stock.Name = "Stock";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(189, 215, 238);
            panel2.Controls.Add(nudCantidad);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(txtCodigo);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtProducto);
            panel2.Controls.Add(txtPrecio);
            panel2.Controls.Add(btnAgregar);
            panel2.Location = new Point(14, 81);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(329, 312);
            panel2.TabIndex = 20;
            // 
            // nudCantidad
            // 
            nudCantidad.Font = new Font("Itim", 16.25F);
            nudCantidad.ForeColor = Color.FromArgb(87, 99, 110);
            nudCantidad.Location = new Point(109, 175);
            nudCantidad.Margin = new Padding(3, 4, 3, 4);
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(94, 40);
            nudCantidad.TabIndex = 21;
            nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Comic Sans MS", 12F);
            label9.ForeColor = Color.FromArgb(87, 99, 110);
            label9.Location = new Point(11, 12);
            label9.Name = "label9";
            label9.Size = new Size(193, 28);
            label9.TabIndex = 20;
            label9.Text = "Datos del Producto:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(87, 99, 110);
            label8.Location = new Point(11, 61);
            label8.Name = "label8";
            label8.Size = new Size(72, 23);
            label8.TabIndex = 19;
            label8.Text = "Código:";
            // 
            // txtCodigo
            // 
            txtCodigo.BorderStyle = BorderStyle.None;
            txtCodigo.Enabled = false;
            txtCodigo.Font = new Font("Itim", 13F);
            txtCodigo.Location = new Point(109, 61);
            txtCodigo.Margin = new Padding(3, 4, 3, 4);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.ReadOnly = true;
            txtCodigo.Size = new Size(200, 26);
            txtCodigo.TabIndex = 18;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(87, 99, 110);
            label3.Location = new Point(13, 181);
            label3.Name = "label3";
            label3.Size = new Size(90, 23);
            label3.TabIndex = 17;
            label3.Text = "Cantidad:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(87, 99, 110);
            label2.Location = new Point(13, 139);
            label2.Name = "label2";
            label2.Size = new Size(67, 23);
            label2.TabIndex = 16;
            label2.Text = "Precio:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(87, 99, 110);
            label1.Location = new Point(11, 100);
            label1.Name = "label1";
            label1.Size = new Size(90, 23);
            label1.TabIndex = 15;
            label1.Text = "Producto:";
            // 
            // txtProducto
            // 
            txtProducto.BorderStyle = BorderStyle.None;
            txtProducto.Enabled = false;
            txtProducto.Font = new Font("Itim", 13F);
            txtProducto.Location = new Point(109, 100);
            txtProducto.Margin = new Padding(3, 4, 3, 4);
            txtProducto.Name = "txtProducto";
            txtProducto.ReadOnly = true;
            txtProducto.Size = new Size(200, 26);
            txtProducto.TabIndex = 13;
            // 
            // txtPrecio
            // 
            txtPrecio.BorderStyle = BorderStyle.None;
            txtPrecio.Enabled = false;
            txtPrecio.Font = new Font("Itim", 13F);
            txtPrecio.Location = new Point(109, 139);
            txtPrecio.Margin = new Padding(3, 4, 3, 4);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.ReadOnly = true;
            txtPrecio.Size = new Size(200, 26);
            txtPrecio.TabIndex = 12;
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
            btnAgregar.Location = new Point(83, 235);
            btnAgregar.Margin = new Padding(3, 4, 3, 4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Padding = new Padding(46, 0, 0, 0);
            btnAgregar.Size = new Size(162, 61);
            btnAgregar.TabIndex = 10;
            btnAgregar.Text = "Añadir";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // frmGestionCompra
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(875, 905);
            Controls.Add(btnSalir);
            Controls.Add(btnImprimirOrden);
            Controls.Add(panel5);
            Controls.Add(button2);
            Controls.Add(panel4);
            Controls.Add(panelCarrito);
            Controls.Add(panelBusqueda);
            Controls.Add(panel1);
            Controls.Add(panel2);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmGestionCompra";
            Text = "frmGestionCompra";
            FormClosing += frmGestionCompra_FormClosing;
            Load += frmGestionCompra_Load;
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panelCarrito.ResumeLayout(false);
            panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbxCarritoVacio).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxCarrito).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).EndInit();
            panelBusqueda.ResumeLayout(false);
            panelBusqueda.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnSalir;
        private Button btnImprimirOrden;
        private Panel panel5;
        private Label label4;
        private Button button2;
        private Panel panel4;
        private Panel panel9;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel8;
        private TextBox txtTotal;
        private Label label6;
        private Panel panel3;
        private TextBox txtImpuesto;
        private Label label7;
        private Panel panel6;
        private TextBox txtSubTotal;
        private Label label5;
        private Panel panelCarrito;
        private Panel panel10;
        private PictureBox pbxCarritoVacio;
        private PictureBox pbxCarrito;
        private DataGridView dgvCarrito;
        private Panel panelBusqueda;
        private TextBox txtBuscar;
        private Button btnBuscarProductos;
        private Panel panel1;
        private Panel panel2;
        private NumericUpDown nudCantidad;
        private Label label9;
        private Label label8;
        private TextBox txtCodigo;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtProducto;
        private TextBox txtPrecio;
        private Button btnAgregar;
        private Panel panel7;
        private DataGridView dgvProductos;
        private DataGridViewTextBoxColumn Codigos;
        private DataGridViewTextBoxColumn Producto;
        private DataGridViewTextBoxColumn Precio;
        private DataGridViewTextBoxColumn Stock;
        private TextBox textBox4;
        private Button btnBuscarCliente;
        private DataGridViewTextBoxColumn colCodigo;
        private DataGridViewTextBoxColumn colProducto;
        private DataGridViewTextBoxColumn colPrecio;
        private DataGridViewTextBoxColumn colCantidad;
        private DataGridViewImageColumn Restar;
        private DataGridViewImageColumn Sumar;
        private DataGridViewImageColumn Eliminar;
    }
}