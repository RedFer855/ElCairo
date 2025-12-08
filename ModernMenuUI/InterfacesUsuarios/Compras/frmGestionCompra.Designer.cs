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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            btnSalir = new Button();
            btnImprimirOrden = new Button();
            panel5 = new Panel();
            btnBuscarProv = new Button();
            txtBuscarProv = new TextBox();
            label4 = new Label();
            btnAgregarCompra = new Button();
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
            CodigoBarra = new DataGridViewTextBoxColumn();
            Producto = new DataGridViewTextBoxColumn();
            Marca = new DataGridViewTextBoxColumn();
            Categoria = new DataGridViewTextBoxColumn();
            Precio = new DataGridViewTextBoxColumn();
            Stock = new DataGridViewTextBoxColumn();
            Codigos = new DataGridViewTextBoxColumn();
            panel2 = new Panel();
            txtNuevoPrecio = new TextBox();
            label10 = new Label();
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
            lstSugerencias = new ListBox();
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
            btnSalir.Location = new Point(821, 645);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(80, 63);
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
            btnImprimirOrden.Location = new Point(681, 645);
            btnImprimirOrden.Name = "btnImprimirOrden";
            btnImprimirOrden.Size = new Size(134, 63);
            btnImprimirOrden.TabIndex = 24;
            btnImprimirOrden.Text = "Imprimir Orden";
            btnImprimirOrden.UseVisualStyleBackColor = false;
            btnImprimirOrden.Click += btnImprimirOrden_Click;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(189, 215, 238);
            panel5.Controls.Add(btnBuscarProv);
            panel5.Controls.Add(txtBuscarProv);
            panel5.Controls.Add(label4);
            panel5.Location = new Point(12, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(338, 51);
            panel5.TabIndex = 23;
            // 
            // btnBuscarProv
            // 
            btnBuscarProv.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuscarProv.BackColor = Color.FromArgb(168, 191, 212);
            btnBuscarProv.BackgroundImage = (Image)resources.GetObject("btnBuscarProv.BackgroundImage");
            btnBuscarProv.BackgroundImageLayout = ImageLayout.Zoom;
            btnBuscarProv.FlatAppearance.BorderSize = 0;
            btnBuscarProv.FlatStyle = FlatStyle.Flat;
            btnBuscarProv.Location = new Point(272, 15);
            btnBuscarProv.Name = "btnBuscarProv";
            btnBuscarProv.Size = new Size(48, 20);
            btnBuscarProv.TabIndex = 2;
            btnBuscarProv.UseVisualStyleBackColor = false;
            btnBuscarProv.Click += btnBuscarProv_Click;
            // 
            // txtBuscarProv
            // 
            txtBuscarProv.BorderStyle = BorderStyle.None;
            txtBuscarProv.Font = new Font("Itim", 13F);
            txtBuscarProv.Location = new Point(73, 14);
            txtBuscarProv.Name = "txtBuscarProv";
            txtBuscarProv.Size = new Size(193, 21);
            txtBuscarProv.TabIndex = 22;
            txtBuscarProv.TextChanged += txtBuscar_TextChanged;
            txtBuscarProv.Enter += txtBuscarProv_Enter;
            txtBuscarProv.KeyDown += txtBuscar_KeyDown;
            txtBuscarProv.KeyUp += txtBuscar_KeyUp;
            txtBuscarProv.Leave += txtBuscar_Leave;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(87, 99, 110);
            label4.Location = new Point(10, 16);
            label4.Name = "label4";
            label4.Size = new Size(66, 17);
            label4.TabIndex = 16;
            label4.Text = "Proveedor:";
            // 
            // btnAgregarCompra
            // 
            btnAgregarCompra.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAgregarCompra.BackColor = Color.FromArgb(149, 195, 172);
            btnAgregarCompra.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregarCompra.ForeColor = SystemColors.ButtonFace;
            btnAgregarCompra.Location = new Point(567, 645);
            btnAgregarCompra.Name = "btnAgregarCompra";
            btnAgregarCompra.Size = new Size(108, 63);
            btnAgregarCompra.TabIndex = 25;
            btnAgregarCompra.Text = "Ingresar Compra";
            btnAgregarCompra.UseVisualStyleBackColor = false;
            btnAgregarCompra.Click += btnAgregarCompra_Click;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel4.BackColor = Color.FromArgb(189, 215, 238);
            panel4.Controls.Add(panel9);
            panel4.Controls.Add(tableLayoutPanel1);
            panel4.Location = new Point(12, 645);
            panel4.Name = "panel4";
            panel4.Size = new Size(549, 63);
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
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 44F));
            tableLayoutPanel1.Controls.Add(panel8, 5, 0);
            tableLayoutPanel1.Controls.Add(panel3, 3, 0);
            tableLayoutPanel1.Controls.Add(panel6, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(549, 63);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel8
            // 
            panel8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel8.Controls.Add(txtTotal);
            panel8.Controls.Add(label6);
            panel8.Location = new Point(355, 3);
            panel8.Name = "panel8";
            panel8.Size = new Size(145, 51);
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
            txtTotal.Size = new Size(145, 29);
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
            panel3.Location = new Point(218, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(99, 57);
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
            txtImpuesto.Size = new Size(99, 29);
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
            panel6.Location = new Point(28, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(147, 51);
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
            txtSubTotal.Size = new Size(147, 29);
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
            panelCarrito.Size = new Size(889, 338);
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
            panel10.Size = new Size(849, 312);
            panel10.TabIndex = 17;
            // 
            // pbxCarritoVacio
            // 
            pbxCarritoVacio.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pbxCarritoVacio.BackColor = Color.Transparent;
            pbxCarritoVacio.Image = (Image)resources.GetObject("pbxCarritoVacio.Image");
            pbxCarritoVacio.Location = new Point(286, 106);
            pbxCarritoVacio.Name = "pbxCarritoVacio";
            pbxCarritoVacio.Size = new Size(270, 143);
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
            dgvCarrito.AllowUserToDeleteRows = false;
            dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCarrito.BackgroundColor = Color.FromArgb(189, 215, 238);
            dgvCarrito.BorderStyle = BorderStyle.None;
            dgvCarrito.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCarrito.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle1.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle1.SelectionBackColor = Color.Transparent;
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
            dgvCarrito.ReadOnly = true;
            dgvCarrito.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle4.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(102, 102, 102);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvCarrito.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvCarrito.RowHeadersWidth = 51;
            dgvCarrito.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle5.SelectionForeColor = Color.White;
            dgvCarrito.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvCarrito.RowTemplate.Height = 50;
            dgvCarrito.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCarrito.Size = new Size(849, 312);
            dgvCarrito.TabIndex = 1;
            dgvCarrito.CellClick += dgvCarrito_CellClick;
            dgvCarrito.CellMouseDown += dgvCarrito_CellMouseDown;
            dgvCarrito.CellMouseEnter += dgvCarrito_CellMouseEnter;
            dgvCarrito.CellMouseLeave += dgvCarrito_CellMouseLeave;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle2.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.Padding = new Padding(0, 1, 0, 0);
            dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewTextBoxColumn1.FillWeight = 50F;
            dataGridViewTextBoxColumn1.HeaderText = "Código";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.FillWeight = 120F;
            dataGridViewTextBoxColumn2.HeaderText = "Producto";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.FillWeight = 60F;
            dataGridViewTextBoxColumn3.HeaderText = "Precio";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.FillWeight = 70F;
            dataGridViewTextBoxColumn4.HeaderText = "Cantidad";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // Restar
            // 
            Restar.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Restar.Description = "Sumar";
            Restar.HeaderText = "";
            Restar.MinimumWidth = 6;
            Restar.Name = "Restar";
            Restar.ReadOnly = true;
            Restar.Resizable = DataGridViewTriState.True;
            Restar.Width = 50;
            // 
            // Sumar
            // 
            Sumar.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Sumar.Description = "Restar";
            Sumar.HeaderText = "";
            Sumar.MinimumWidth = 6;
            Sumar.Name = "Sumar";
            Sumar.ReadOnly = true;
            Sumar.Resizable = DataGridViewTriState.True;
            Sumar.Width = 50;
            // 
            // Eliminar
            // 
            Eliminar.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Eliminar.Description = "Eliminar";
            Eliminar.HeaderText = "";
            Eliminar.MinimumWidth = 6;
            Eliminar.Name = "Eliminar";
            Eliminar.ReadOnly = true;
            Eliminar.Resizable = DataGridViewTriState.True;
            Eliminar.Width = 50;
            // 
            // panelBusqueda
            // 
            panelBusqueda.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelBusqueda.BackColor = Color.FromArgb(189, 215, 238);
            panelBusqueda.Controls.Add(txtBuscar);
            panelBusqueda.Controls.Add(btnBuscarProductos);
            panelBusqueda.Location = new Point(356, 4);
            panelBusqueda.Name = "panelBusqueda";
            panelBusqueda.Size = new Size(545, 51);
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
            txtBuscar.Size = new Size(450, 20);
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
            btnBuscarProductos.Location = new Point(477, 13);
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
            panel1.Location = new Point(356, 61);
            panel1.Name = "panel1";
            panel1.Size = new Size(545, 234);
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
            panel7.Size = new Size(504, 210);
            panel7.TabIndex = 12;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle6.ForeColor = Color.DimGray;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(147, 167, 186);
            dataGridViewCellStyle6.SelectionForeColor = Color.White;
            dgvProductos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.BackgroundColor = Color.FromArgb(189, 215, 238);
            dgvProductos.BorderStyle = BorderStyle.None;
            dgvProductos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProductos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle7.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle7.SelectionBackColor = Color.Transparent;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvProductos.ColumnHeadersHeight = 31;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvProductos.Columns.AddRange(new DataGridViewColumn[] { CodigoBarra, Producto, Marca, Categoria, Precio, Stock, Codigos });
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = Color.White;
            dataGridViewCellStyle10.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle10.ForeColor = Color.White;
            dataGridViewCellStyle10.Padding = new Padding(5);
            dataGridViewCellStyle10.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle10.SelectionForeColor = Color.White;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.False;
            dgvProductos.DefaultCellStyle = dataGridViewCellStyle10;
            dgvProductos.Dock = DockStyle.Fill;
            dgvProductos.EnableHeadersVisualStyles = false;
            dgvProductos.GridColor = Color.FromArgb(189, 215, 238);
            dgvProductos.Location = new Point(0, 0);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = SystemColors.Control;
            dataGridViewCellStyle11.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle11.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle11.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.True;
            dgvProductos.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            dgvProductos.RowHeadersWidth = 30;
            dgvProductos.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle12.BackColor = Color.White;
            dataGridViewCellStyle12.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle12.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle12.SelectionForeColor = Color.White;
            dgvProductos.RowsDefaultCellStyle = dataGridViewCellStyle12;
            dgvProductos.RowTemplate.Height = 30;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(504, 210);
            dgvProductos.TabIndex = 0;
            dgvProductos.SelectionChanged += dgvProductos_SelectionChanged;
            // 
            // CodigoBarra
            // 
            CodigoBarra.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            CodigoBarra.DataPropertyName = "CodigoBarraProducto";
            CodigoBarra.HeaderText = "Código de Barra";
            CodigoBarra.MinimumWidth = 6;
            CodigoBarra.Name = "CodigoBarra";
            CodigoBarra.ReadOnly = true;
            CodigoBarra.Width = 152;
            // 
            // Producto
            // 
            Producto.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Producto.DataPropertyName = "NombreProducto";
            Producto.FillWeight = 200F;
            Producto.HeaderText = "Producto";
            Producto.MinimumWidth = 6;
            Producto.Name = "Producto";
            Producto.ReadOnly = true;
            Producto.Width = 105;
            // 
            // Marca
            // 
            Marca.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Marca.DataPropertyName = "NombreMarca";
            Marca.HeaderText = "Marca";
            Marca.MinimumWidth = 6;
            Marca.Name = "Marca";
            Marca.ReadOnly = true;
            Marca.Width = 84;
            // 
            // Categoria
            // 
            Categoria.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Categoria.DataPropertyName = "NombreCategoria";
            Categoria.HeaderText = "Categoria";
            Categoria.MinimumWidth = 6;
            Categoria.Name = "Categoria";
            Categoria.ReadOnly = true;
            Categoria.Width = 108;
            // 
            // Precio
            // 
            Precio.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Precio.DataPropertyName = "PrecioCompra";
            Precio.FillWeight = 80F;
            Precio.HeaderText = "Precio";
            Precio.MinimumWidth = 6;
            Precio.Name = "Precio";
            Precio.ReadOnly = true;
            Precio.Width = 84;
            // 
            // Stock
            // 
            Stock.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Stock.DataPropertyName = "CantidadProducto";
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Stock.DefaultCellStyle = dataGridViewCellStyle8;
            Stock.FillWeight = 80F;
            Stock.HeaderText = "Stock";
            Stock.MinimumWidth = 6;
            Stock.Name = "Stock";
            Stock.ReadOnly = true;
            Stock.Width = 80;
            // 
            // Codigos
            // 
            Codigos.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Codigos.DataPropertyName = "IdProducto";
            dataGridViewCellStyle9.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle9.Padding = new Padding(0, 1, 0, 0);
            Codigos.DefaultCellStyle = dataGridViewCellStyle9;
            Codigos.FillWeight = 90F;
            Codigos.HeaderText = "Código";
            Codigos.MinimumWidth = 6;
            Codigos.Name = "Codigos";
            Codigos.ReadOnly = true;
            Codigos.Width = 89;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(189, 215, 238);
            panel2.Controls.Add(txtNuevoPrecio);
            panel2.Controls.Add(label10);
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
            panel2.Font = new Font("Itim", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel2.Location = new Point(12, 61);
            panel2.Name = "panel2";
            panel2.Size = new Size(338, 234);
            panel2.TabIndex = 20;
            // 
            // txtNuevoPrecio
            // 
            txtNuevoPrecio.BorderStyle = BorderStyle.None;
            txtNuevoPrecio.Font = new Font("Itim", 13F);
            txtNuevoPrecio.Location = new Point(115, 136);
            txtNuevoPrecio.Name = "txtNuevoPrecio";
            txtNuevoPrecio.Size = new Size(192, 21);
            txtNuevoPrecio.TabIndex = 23;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.FromArgb(87, 99, 110);
            label10.Location = new Point(10, 136);
            label10.Name = "label10";
            label10.Size = new Size(96, 18);
            label10.TabIndex = 22;
            label10.Text = "Precio Nuevo:";
            // 
            // nudCantidad
            // 
            nudCantidad.Font = new Font("Itim", 16.25F);
            nudCantidad.ForeColor = Color.FromArgb(87, 99, 110);
            nudCantidad.Location = new Point(88, 168);
            nudCantidad.Maximum = new decimal(new int[] { 400, 0, 0, 0 });
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(65, 33);
            nudCantidad.TabIndex = 21;
            nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Itim", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(87, 99, 110);
            label9.Location = new Point(10, 9);
            label9.Name = "label9";
            label9.Size = new Size(189, 25);
            label9.TabIndex = 20;
            label9.Text = "Datos del Producto:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(87, 99, 110);
            label8.Location = new Point(51, 46);
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
            txtCodigo.Location = new Point(115, 46);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.ReadOnly = true;
            txtCodigo.Size = new Size(192, 21);
            txtCodigo.TabIndex = 18;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(87, 99, 110);
            label3.Location = new Point(10, 177);
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
            label2.Location = new Point(10, 106);
            label2.Name = "label2";
            label2.Size = new Size(98, 18);
            label2.TabIndex = 16;
            label2.Text = "Precio Actual:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(87, 99, 110);
            label1.Location = new Point(37, 78);
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
            txtProducto.Location = new Point(115, 75);
            txtProducto.Name = "txtProducto";
            txtProducto.ReadOnly = true;
            txtProducto.Size = new Size(192, 21);
            txtProducto.TabIndex = 13;
            // 
            // txtPrecio
            // 
            txtPrecio.BorderStyle = BorderStyle.None;
            txtPrecio.Enabled = false;
            txtPrecio.Font = new Font("Itim", 13F);
            txtPrecio.Location = new Point(115, 104);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.ReadOnly = true;
            txtPrecio.Size = new Size(192, 21);
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
            btnAgregar.Location = new Point(165, 168);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Padding = new Padding(40, 0, 0, 0);
            btnAgregar.Size = new Size(142, 44);
            btnAgregar.TabIndex = 10;
            btnAgregar.Text = "Añadir";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // lstSugerencias
            // 
            lstSugerencias.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstSugerencias.ForeColor = Color.DimGray;
            lstSugerencias.FormattingEnabled = true;
            lstSugerencias.ItemHeight = 18;
            lstSugerencias.Location = new Point(85, 40);
            lstSugerencias.Name = "lstSugerencias";
            lstSugerencias.Size = new Size(193, 22);
            lstSugerencias.TabIndex = 27;
            lstSugerencias.Visible = false;
            lstSugerencias.MouseClick += lstSugerencias_MouseClick;
            lstSugerencias.SelectedValueChanged += lstSugerencias_SelectedIndexChanged;
            lstSugerencias.KeyDown += lstSugerencias_KeyDown;
            lstSugerencias.MouseDown += lstSugerencias_MouseDown;
            lstSugerencias.MouseUp += lstSugerencias_MouseUp;
            // 
            // frmGestionCompra
            // 
            AccessibleRole = AccessibleRole.None;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            ClientSize = new Size(913, 712);
            Controls.Add(lstSugerencias);
            Controls.Add(btnSalir);
            Controls.Add(btnImprimirOrden);
            Controls.Add(panel5);
            Controls.Add(btnAgregarCompra);
            Controls.Add(panel4);
            Controls.Add(panelCarrito);
            Controls.Add(panelBusqueda);
            Controls.Add(panel1);
            Controls.Add(panel2);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmGestionCompra";
            Text = "frmGestionCompra";
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
        private Button btnAgregarCompra;
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
        private TextBox txtBuscarProv;
        private Button btnBuscarProv;
        private ListBox lstSugerencias;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewImageColumn Restar;
        private DataGridViewImageColumn Sumar;
        private DataGridViewImageColumn Eliminar;
        private Label label10;
        private TextBox txtNuevoPrecio;
        private DataGridViewTextBoxColumn CodigoBarra;
        private DataGridViewTextBoxColumn Producto;
        private DataGridViewTextBoxColumn Marca;
        private DataGridViewTextBoxColumn Categoria;
        private DataGridViewTextBoxColumn Precio;
        private DataGridViewTextBoxColumn Stock;
        private DataGridViewTextBoxColumn Codigos;
    }
}