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
            button1 = new Button();
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
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
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
            btnSalir.Location = new Point(674, 612);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(80, 63);
            btnSalir.TabIndex = 26;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click_1;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.BackColor = Color.FromArgb(189, 215, 238);
            button1.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(87, 99, 110);
            button1.Location = new Point(534, 612);
            button1.Name = "button1";
            button1.Size = new Size(134, 63);
            button1.TabIndex = 24;
            button1.Text = "Imprimir Orden";
            button1.UseVisualStyleBackColor = false;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(189, 215, 238);
            panel5.Controls.Add(btnBuscarCliente);
            panel5.Controls.Add(textBox4);
            panel5.Controls.Add(label4);
            panel5.Location = new Point(12, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(288, 51);
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
            btnBuscarCliente.Location = new Point(222, 15);
            btnBuscarCliente.Name = "btnBuscarCliente";
            btnBuscarCliente.Size = new Size(48, 20);
            btnBuscarCliente.TabIndex = 2;
            btnBuscarCliente.UseVisualStyleBackColor = false;
            // 
            // textBox4
            // 
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.Enabled = false;
            textBox4.Font = new Font("Itim", 13F);
            textBox4.Location = new Point(67, 14);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(148, 21);
            textBox4.TabIndex = 22;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(87, 99, 110);
            label4.Location = new Point(10, 16);
            label4.Name = "label4";
            label4.Size = new Size(51, 17);
            label4.TabIndex = 16;
            label4.Text = "Cliente:";
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.BackColor = Color.FromArgb(149, 195, 172);
            button2.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Location = new Point(420, 612);
            button2.Name = "button2";
            button2.Size = new Size(108, 63);
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
            panel4.Location = new Point(12, 612);
            panel4.Name = "panel4";
            panel4.Size = new Size(402, 63);
            panel4.TabIndex = 22;
            // 
            // panel9
            // 
            panel9.Dock = DockStyle.Left;
            panel9.Location = new Point(0, 63);
            panel9.Name = "panel9";
            panel9.Size = new Size(30, 0);
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
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(panel8, 5, 0);
            tableLayoutPanel1.Controls.Add(panel3, 3, 0);
            tableLayoutPanel1.Controls.Add(panel6, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(402, 63);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel8
            // 
            panel8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel8.Controls.Add(txtTotal);
            panel8.Controls.Add(label6);
            panel8.Location = new Point(269, 3);
            panel8.Name = "panel8";
            panel8.Size = new Size(108, 51);
            panel8.TabIndex = 24;
            // 
            // txtTotal
            // 
            txtTotal.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTotal.BorderStyle = BorderStyle.None;
            txtTotal.Enabled = false;
            txtTotal.Font = new Font("Itim", 18F);
            txtTotal.Location = new Point(0, 17);
            txtTotal.Name = "txtTotal";
            txtTotal.PlaceholderText = "L0,00";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(108, 29);
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
            label6.Size = new Size(42, 17);
            label6.TabIndex = 19;
            label6.Text = "Total:";
            // 
            // panel3
            // 
            panel3.Controls.Add(txtImpuesto);
            panel3.Controls.Add(label7);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(166, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(73, 57);
            panel3.TabIndex = 22;
            // 
            // txtImpuesto
            // 
            txtImpuesto.BorderStyle = BorderStyle.None;
            txtImpuesto.Dock = DockStyle.Fill;
            txtImpuesto.Enabled = false;
            txtImpuesto.Font = new Font("Itim", 18F);
            txtImpuesto.Location = new Point(0, 17);
            txtImpuesto.Name = "txtImpuesto";
            txtImpuesto.PlaceholderText = "L0,00";
            txtImpuesto.ReadOnly = true;
            txtImpuesto.Size = new Size(73, 29);
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
            label7.Size = new Size(63, 17);
            label7.TabIndex = 21;
            label7.Text = "Impuesto:";
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel6.Controls.Add(txtSubTotal);
            panel6.Controls.Add(label5);
            panel6.Location = new Point(22, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(110, 51);
            panel6.TabIndex = 23;
            // 
            // txtSubTotal
            // 
            txtSubTotal.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSubTotal.BorderStyle = BorderStyle.None;
            txtSubTotal.Enabled = false;
            txtSubTotal.Font = new Font("Itim", 18F);
            txtSubTotal.Location = new Point(0, 17);
            txtSubTotal.Name = "txtSubTotal";
            txtSubTotal.PlaceholderText = "L0,00";
            txtSubTotal.ReadOnly = true;
            txtSubTotal.Size = new Size(110, 29);
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
            label5.Size = new Size(60, 17);
            label5.TabIndex = 18;
            label5.Text = "Subtotal:";
            // 
            // panelCarrito
            // 
            panelCarrito.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelCarrito.BackColor = Color.FromArgb(189, 215, 238);
            panelCarrito.Controls.Add(panel10);
            panelCarrito.Location = new Point(12, 301);
            panelCarrito.Name = "panelCarrito";
            panelCarrito.Size = new Size(742, 305);
            panelCarrito.TabIndex = 21;
            // 
            // panel10
            // 
            panel10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel10.Controls.Add(pbxCarritoVacio);
            panel10.Controls.Add(pbxCarrito);
            panel10.Controls.Add(dgvCarrito);
            panel10.Location = new Point(20, 11);
            panel10.Name = "panel10";
            panel10.Size = new Size(702, 279);
            panel10.TabIndex = 17;
            // 
            // pbxCarritoVacio
            // 
            pbxCarritoVacio.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pbxCarritoVacio.BackColor = Color.Transparent;
            pbxCarritoVacio.Image = (Image)resources.GetObject("pbxCarritoVacio.Image");
            pbxCarritoVacio.Location = new Point(209, 73);
            pbxCarritoVacio.Name = "pbxCarritoVacio";
            pbxCarritoVacio.Size = new Size(294, 148);
            pbxCarritoVacio.SizeMode = PictureBoxSizeMode.Zoom;
            pbxCarritoVacio.TabIndex = 3;
            pbxCarritoVacio.TabStop = false;
            // 
            // pbxCarrito
            // 
            pbxCarrito.BackColor = Color.Transparent;
            pbxCarrito.Image = (Image)resources.GetObject("pbxCarrito.Image");
            pbxCarrito.Location = new Point(0, 0);
            pbxCarrito.Name = "pbxCarrito";
            pbxCarrito.Size = new Size(40, 40);
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
            dgvCarrito.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, Restar, Sumar, Eliminar });
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
            dgvCarrito.Size = new Size(702, 279);
            dgvCarrito.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle2.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.Padding = new Padding(0, 1, 0, 0);
            dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewTextBoxColumn1.FillWeight = 50F;
            dataGridViewTextBoxColumn1.HeaderText = "Código";
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
            // panelBusqueda
            // 
            panelBusqueda.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelBusqueda.BackColor = Color.FromArgb(189, 215, 238);
            panelBusqueda.Controls.Add(txtBuscar);
            panelBusqueda.Controls.Add(btnBuscarProductos);
            panelBusqueda.Location = new Point(306, 4);
            panelBusqueda.Name = "panelBusqueda";
            panelBusqueda.Size = new Size(448, 51);
            panelBusqueda.TabIndex = 18;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.BorderStyle = BorderStyle.None;
            txtBuscar.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(21, 14);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar Productos...";
            txtBuscar.Size = new Size(353, 20);
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
            btnBuscarProductos.Location = new Point(380, 13);
            btnBuscarProductos.Name = "btnBuscarProductos";
            btnBuscarProductos.Size = new Size(48, 20);
            btnBuscarProductos.TabIndex = 0;
            btnBuscarProductos.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(189, 215, 238);
            panel1.Controls.Add(panel7);
            panel1.Location = new Point(306, 61);
            panel1.Name = "panel1";
            panel1.Size = new Size(448, 234);
            panel1.TabIndex = 19;
            // 
            // panel7
            // 
            panel7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel7.AutoSize = true;
            panel7.BackColor = Color.FromArgb(189, 215, 238);
            panel7.Controls.Add(dgvProductos);
            panel7.Location = new Point(21, 12);
            panel7.Name = "panel7";
            panel7.Size = new Size(407, 210);
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
            dgvProductos.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvProductos.RowTemplate.Height = 40;
            dgvProductos.Size = new Size(407, 210);
            dgvProductos.TabIndex = 0;
            // 
            // Codigos
            // 
            dataGridViewCellStyle6.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.Padding = new Padding(0, 1, 0, 0);
            Codigos.DefaultCellStyle = dataGridViewCellStyle6;
            Codigos.FillWeight = 90F;
            Codigos.HeaderText = "Código";
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
            panel2.Location = new Point(12, 61);
            panel2.Name = "panel2";
            panel2.Size = new Size(288, 234);
            panel2.TabIndex = 20;
            // 
            // nudCantidad
            // 
            nudCantidad.Font = new Font("Itim", 16.25F);
            nudCantidad.ForeColor = Color.FromArgb(87, 99, 110);
            nudCantidad.Location = new Point(95, 131);
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(82, 33);
            nudCantidad.TabIndex = 21;
            nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Comic Sans MS", 12F);
            label9.ForeColor = Color.FromArgb(87, 99, 110);
            label9.Location = new Point(10, 9);
            label9.Name = "label9";
            label9.Size = new Size(153, 23);
            label9.TabIndex = 20;
            label9.Text = "Datos del Producto:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(87, 99, 110);
            label8.Location = new Point(10, 46);
            label8.Name = "label8";
            label8.Size = new Size(58, 18);
            label8.TabIndex = 19;
            label8.Text = "Código:";
            // 
            // txtCodigo
            // 
            txtCodigo.BorderStyle = BorderStyle.None;
            txtCodigo.Enabled = false;
            txtCodigo.Font = new Font("Itim", 13F);
            txtCodigo.Location = new Point(95, 46);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.ReadOnly = true;
            txtCodigo.Size = new Size(175, 21);
            txtCodigo.TabIndex = 18;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(87, 99, 110);
            label3.Location = new Point(11, 136);
            label3.Name = "label3";
            label3.Size = new Size(72, 18);
            label3.TabIndex = 17;
            label3.Text = "Cantidad:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(87, 99, 110);
            label2.Location = new Point(11, 104);
            label2.Name = "label2";
            label2.Size = new Size(53, 18);
            label2.TabIndex = 16;
            label2.Text = "Precio:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(87, 99, 110);
            label1.Location = new Point(10, 75);
            label1.Name = "label1";
            label1.Size = new Size(72, 18);
            label1.TabIndex = 15;
            label1.Text = "Producto:";
            // 
            // txtProducto
            // 
            txtProducto.BorderStyle = BorderStyle.None;
            txtProducto.Enabled = false;
            txtProducto.Font = new Font("Itim", 13F);
            txtProducto.Location = new Point(95, 75);
            txtProducto.Name = "txtProducto";
            txtProducto.ReadOnly = true;
            txtProducto.Size = new Size(175, 21);
            txtProducto.TabIndex = 13;
            // 
            // txtPrecio
            // 
            txtPrecio.BorderStyle = BorderStyle.None;
            txtPrecio.Enabled = false;
            txtPrecio.Font = new Font("Itim", 13F);
            txtPrecio.Location = new Point(95, 104);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.ReadOnly = true;
            txtPrecio.Size = new Size(175, 21);
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
            btnAgregar.Location = new Point(73, 176);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Padding = new Padding(40, 0, 0, 0);
            btnAgregar.Size = new Size(142, 46);
            btnAgregar.TabIndex = 10;
            btnAgregar.Text = "Añadir";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // frmGestionCompra
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
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmGestionCompra";
            Text = "frmGestionCompra";
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
        private Button button1;
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
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewImageColumn Restar;
        private DataGridViewImageColumn Sumar;
        private DataGridViewImageColumn Eliminar;
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
    }
}