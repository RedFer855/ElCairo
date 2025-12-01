namespace ModernMenuUI
{
    partial class frmFacturacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFacturacion));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            btnSalir = new Button();
            btnImprimirCotizacion = new Button();
            txtCliente = new TextBox();
            panel5 = new Panel();
            button2 = new Button();
            label7 = new Label();
            label6 = new Label();
            btnFacturar = new Button();
            panel8 = new Panel();
            txtTotal = new TextBox();
            panel6 = new Panel();
            txtSubtotal = new TextBox();
            label5 = new Label();
            panel3 = new Panel();
            txtImpuesto = new TextBox();
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
            buscar = new Button();
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
            tableLayoutPanel1 = new TableLayoutPanel();
            panel4 = new Panel();
            panel9 = new Panel();
            lstClientes = new ListBox();
            lstSugerencias = new ListBox();
            panel5.SuspendLayout();
            panel8.SuspendLayout();
            panel6.SuspendLayout();
            panel3.SuspendLayout();
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
            tableLayoutPanel1.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalir.BackColor = Color.FromArgb(148, 168, 187);
            btnSalir.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.White;
            btnSalir.ImageAlign = ContentAlignment.TopCenter;
            btnSalir.Location = new Point(823, 604);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(80, 63);
            btnSalir.TabIndex = 17;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnImprimirCotizacion
            // 
            btnImprimirCotizacion.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnImprimirCotizacion.BackColor = Color.FromArgb(189, 215, 238);
            btnImprimirCotizacion.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnImprimirCotizacion.ForeColor = Color.FromArgb(87, 99, 110);
            btnImprimirCotizacion.Location = new Point(683, 604);
            btnImprimirCotizacion.Name = "btnImprimirCotizacion";
            btnImprimirCotizacion.Size = new Size(134, 63);
            btnImprimirCotizacion.TabIndex = 15;
            btnImprimirCotizacion.Text = "Imprimir Cotización";
            btnImprimirCotizacion.UseVisualStyleBackColor = false;
            btnImprimirCotizacion.Click += btnImprimirCotizacion_Click;
            // 
            // txtCliente
            // 
            txtCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtCliente.BorderStyle = BorderStyle.None;
            txtCliente.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCliente.Location = new Point(21, 14);
            txtCliente.Name = "txtCliente";
            txtCliente.PlaceholderText = "Buscar Cliente...";
            txtCliente.Size = new Size(197, 20);
            txtCliente.TabIndex = 13;
            txtCliente.TextChanged += txtCliente_TextChanged;
            txtCliente.KeyDown += txtCliente_KeyDown;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(189, 215, 238);
            panel5.Controls.Add(button2);
            panel5.Controls.Add(txtCliente);
            panel5.Location = new Point(12, 12);
            panel5.Name = "panel5";
            panel5.Size = new Size(290, 51);
            panel5.TabIndex = 14;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.BackColor = Color.FromArgb(168, 191, 212);
            button2.BackgroundImageLayout = ImageLayout.Zoom;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(224, 14);
            button2.Name = "button2";
            button2.Size = new Size(48, 20);
            button2.TabIndex = 17;
            button2.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Top;
            label7.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(0, 0);
            label7.Name = "label7";
            label7.Size = new Size(63, 17);
            label7.TabIndex = 21;
            label7.Text = "Impuesto:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Top;
            label6.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(0, 0);
            label6.Name = "label6";
            label6.Size = new Size(42, 17);
            label6.TabIndex = 19;
            label6.Text = "Total:";
            // 
            // btnFacturar
            // 
            btnFacturar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnFacturar.BackColor = Color.FromArgb(149, 195, 172);
            btnFacturar.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFacturar.ForeColor = SystemColors.ButtonFace;
            btnFacturar.Location = new Point(569, 604);
            btnFacturar.Name = "btnFacturar";
            btnFacturar.Size = new Size(108, 63);
            btnFacturar.TabIndex = 16;
            btnFacturar.Text = "Facturar";
            btnFacturar.UseVisualStyleBackColor = false;
            btnFacturar.Click += btnFacturar_Click;
            // 
            // panel8
            // 
            panel8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel8.Controls.Add(txtTotal);
            panel8.Controls.Add(label6);
            panel8.Location = new Point(369, 3);
            panel8.Name = "panel8";
            panel8.Size = new Size(150, 51);
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
            txtTotal.Size = new Size(150, 29);
            txtTotal.TabIndex = 24;
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel6.Controls.Add(txtSubtotal);
            panel6.Controls.Add(label5);
            panel6.Location = new Point(30, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(153, 51);
            panel6.TabIndex = 23;
            // 
            // txtSubtotal
            // 
            txtSubtotal.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSubtotal.BorderStyle = BorderStyle.None;
            txtSubtotal.Enabled = false;
            txtSubtotal.Font = new Font("Itim", 18F);
            txtSubtotal.Location = new Point(0, 17);
            txtSubtotal.Name = "txtSubtotal";
            txtSubtotal.PlaceholderText = "L0,00";
            txtSubtotal.ReadOnly = true;
            txtSubtotal.Size = new Size(153, 29);
            txtSubtotal.TabIndex = 23;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Top;
            label5.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(60, 17);
            label5.TabIndex = 18;
            label5.Text = "Subtotal:";
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel3.Controls.Add(txtImpuesto);
            panel3.Controls.Add(label7);
            panel3.Location = new Point(227, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(103, 51);
            panel3.TabIndex = 22;
            // 
            // txtImpuesto
            // 
            txtImpuesto.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtImpuesto.BorderStyle = BorderStyle.None;
            txtImpuesto.Enabled = false;
            txtImpuesto.Font = new Font("Itim", 18F);
            txtImpuesto.Location = new Point(0, 17);
            txtImpuesto.Name = "txtImpuesto";
            txtImpuesto.PlaceholderText = "L0,00";
            txtImpuesto.ReadOnly = true;
            txtImpuesto.Size = new Size(103, 29);
            txtImpuesto.TabIndex = 22;
            // 
            // panelCarrito
            // 
            panelCarrito.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelCarrito.BackColor = Color.FromArgb(189, 215, 238);
            panelCarrito.Controls.Add(panel10);
            panelCarrito.Location = new Point(12, 268);
            panelCarrito.Name = "panelCarrito";
            panelCarrito.Size = new Size(891, 330);
            panelCarrito.TabIndex = 12;
            // 
            // panel10
            // 
            panel10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel10.Controls.Add(pbxCarritoVacio);
            panel10.Controls.Add(pbxCarrito);
            panel10.Controls.Add(dgvCarrito);
            panel10.Location = new Point(21, 16);
            panel10.Name = "panel10";
            panel10.Size = new Size(849, 301);
            panel10.TabIndex = 17;
            // 
            // pbxCarritoVacio
            // 
            pbxCarritoVacio.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pbxCarritoVacio.BackColor = Color.Transparent;
            pbxCarritoVacio.Image = (Image)resources.GetObject("pbxCarritoVacio.Image");
            pbxCarritoVacio.Location = new Point(275, 92);
            pbxCarritoVacio.Name = "pbxCarritoVacio";
            pbxCarritoVacio.Size = new Size(308, 143);
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
            dataGridViewCellStyle4.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle4.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(102, 102, 102);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvCarrito.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvCarrito.RowHeadersWidth = 51;
            dgvCarrito.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvCarrito.RowTemplate.Height = 50;
            dgvCarrito.Size = new Size(849, 301);
            dgvCarrito.TabIndex = 1;
            dgvCarrito.CellClick += dgvCarrito_CellClick;
            dgvCarrito.CellMouseDown += dgvCarrito_CellMouseDown;
            dgvCarrito.CellMouseEnter += dgvCarrito_CellMouseEnter;
            dgvCarrito.CellMouseLeave += dgvCarrito_CellMouseLeave;
            dgvCarrito.CellMouseUp += dgvCarrito_CellMouseUp;
            dgvCarrito.CellValueChanged += dgvCarrito_CellValueChanged;
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
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.FillWeight = 120F;
            dataGridViewTextBoxColumn2.HeaderText = "Producto";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.FillWeight = 60F;
            dataGridViewTextBoxColumn3.HeaderText = "Precio";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.FillWeight = 70F;
            dataGridViewTextBoxColumn4.HeaderText = "Cantidad";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
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
            panelBusqueda.Controls.Add(buscar);
            panelBusqueda.Location = new Point(308, 12);
            panelBusqueda.Name = "panelBusqueda";
            panelBusqueda.Size = new Size(595, 51);
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
            txtBuscar.Size = new Size(504, 20);
            txtBuscar.TabIndex = 1;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // buscar
            // 
            buscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buscar.BackColor = Color.FromArgb(168, 191, 212);
            buscar.BackgroundImage = (Image)resources.GetObject("buscar.BackgroundImage");
            buscar.BackgroundImageLayout = ImageLayout.Zoom;
            buscar.FlatAppearance.BorderSize = 0;
            buscar.FlatStyle = FlatStyle.Flat;
            buscar.Location = new Point(532, 14);
            buscar.Name = "buscar";
            buscar.Size = new Size(48, 20);
            buscar.TabIndex = 0;
            buscar.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(189, 215, 238);
            panel1.Controls.Add(panel7);
            panel1.Location = new Point(308, 69);
            panel1.Name = "panel1";
            panel1.Size = new Size(595, 193);
            panel1.TabIndex = 10;
            // 
            // panel7
            // 
            panel7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel7.AutoSize = true;
            panel7.BackColor = Color.FromArgb(189, 215, 238);
            panel7.Controls.Add(dgvProductos);
            panel7.Location = new Point(21, 9);
            panel7.Name = "panel7";
            panel7.Size = new Size(556, 170);
            panel7.TabIndex = 11;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle5.ForeColor = Color.DimGray;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle5.SelectionForeColor = Color.White;
            dgvProductos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.BackgroundColor = Color.FromArgb(189, 215, 238);
            dgvProductos.BorderStyle = BorderStyle.None;
            dgvProductos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProductos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle6.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvProductos.ColumnHeadersHeight = 31;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvProductos.Columns.AddRange(new DataGridViewColumn[] { Codigos, Producto, Precio, Stock });
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.White;
            dataGridViewCellStyle8.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(102, 102, 102);
            dataGridViewCellStyle8.Padding = new Padding(5);
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle8.SelectionForeColor = Color.White;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dgvProductos.DefaultCellStyle = dataGridViewCellStyle8;
            dgvProductos.Dock = DockStyle.Fill;
            dgvProductos.EnableHeadersVisualStyles = false;
            dgvProductos.GridColor = Color.FromArgb(189, 215, 238);
            dgvProductos.Location = new Point(0, 0);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = SystemColors.Control;
            dataGridViewCellStyle9.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle9.ForeColor = Color.FromArgb(102, 102, 102);
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            dgvProductos.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dgvProductos.RowHeadersWidth = 30;
            dgvProductos.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvProductos.RowTemplate.Height = 30;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(556, 170);
            dgvProductos.TabIndex = 0;
            dgvProductos.SelectionChanged += dgvProductos_SelectionChanged;
            // 
            // Codigos
            // 
            dataGridViewCellStyle7.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.Padding = new Padding(0, 1, 0, 0);
            Codigos.DefaultCellStyle = dataGridViewCellStyle7;
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
            panel2.Location = new Point(12, 69);
            panel2.Name = "panel2";
            panel2.Size = new Size(290, 193);
            panel2.TabIndex = 11;
            // 
            // nudCantidad
            // 
            nudCantidad.Font = new Font("Itim", 16.25F);
            nudCantidad.ForeColor = Color.FromArgb(87, 99, 110);
            nudCantidad.Location = new Point(82, 142);
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(59, 33);
            nudCantidad.TabIndex = 21;
            nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label9
            // 
            label9.BackColor = Color.FromArgb(148, 168, 187);
            label9.Font = new Font("Itim", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.WhiteSmoke;
            label9.Location = new Point(11, 9);
            label9.Name = "label9";
            label9.Size = new Size(265, 23);
            label9.TabIndex = 20;
            label9.Text = "Datos del Producto:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(87, 99, 110);
            label8.Location = new Point(24, 45);
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
            txtCodigo.Location = new Point(82, 43);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.ReadOnly = true;
            txtCodigo.Size = new Size(194, 21);
            txtCodigo.TabIndex = 18;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(87, 99, 110);
            label3.Location = new Point(10, 151);
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
            label2.Location = new Point(29, 106);
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
            txtProducto.Location = new Point(82, 73);
            txtProducto.Name = "txtProducto";
            txtProducto.ReadOnly = true;
            txtProducto.Size = new Size(194, 21);
            txtProducto.TabIndex = 13;
            // 
            // txtPrecio
            // 
            txtPrecio.BorderStyle = BorderStyle.None;
            txtPrecio.Enabled = false;
            txtPrecio.Font = new Font("Itim", 13F);
            txtPrecio.Location = new Point(82, 104);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.ReadOnly = true;
            txtPrecio.Size = new Size(194, 21);
            txtPrecio.TabIndex = 12;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(149, 195, 172);
            btnAgregar.BackgroundImage = (Image)resources.GetObject("btnAgregar.BackgroundImage");
            btnAgregar.BackgroundImageLayout = ImageLayout.None;
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.Font = new Font("Itim", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregar.ForeColor = SystemColors.ButtonFace;
            btnAgregar.ImageAlign = ContentAlignment.BottomLeft;
            btnAgregar.Location = new Point(147, 136);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Padding = new Padding(30, 0, 0, 0);
            btnAgregar.Size = new Size(121, 43);
            btnAgregar.TabIndex = 10;
            btnAgregar.Text = "Añadir";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
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
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 26F));
            tableLayoutPanel1.Controls.Add(panel8, 5, 0);
            tableLayoutPanel1.Controls.Add(panel3, 3, 0);
            tableLayoutPanel1.Controls.Add(panel6, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(551, 63);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel4.BackColor = Color.FromArgb(189, 215, 238);
            panel4.Controls.Add(panel9);
            panel4.Controls.Add(tableLayoutPanel1);
            panel4.Location = new Point(12, 604);
            panel4.Name = "panel4";
            panel4.Size = new Size(551, 63);
            panel4.TabIndex = 13;
            // 
            // panel9
            // 
            panel9.Dock = DockStyle.Left;
            panel9.Location = new Point(0, 63);
            panel9.Name = "panel9";
            panel9.Size = new Size(30, 0);
            panel9.TabIndex = 1;
            // 
            // lstClientes
            // 
            lstClientes.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstClientes.ForeColor = Color.DimGray;
            lstClientes.FormattingEnabled = true;
            lstClientes.ItemHeight = 18;
            lstClientes.Location = new Point(33, 47);
            lstClientes.Name = "lstClientes";
            lstClientes.Size = new Size(197, 22);
            lstClientes.TabIndex = 18;
            lstClientes.Visible = false;
            lstClientes.MouseClick += lstClientes_MouseClick;
            lstClientes.KeyDown += lstClientes_KeyDown;
            // 
            // lstSugerencias
            // 
            lstSugerencias.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstSugerencias.ForeColor = Color.DimGray;
            lstSugerencias.FormattingEnabled = true;
            lstSugerencias.ItemHeight = 18;
            lstSugerencias.Location = new Point(329, 47);
            lstSugerencias.Name = "lstSugerencias";
            lstSugerencias.Size = new Size(504, 22);
            lstSugerencias.TabIndex = 19;
            lstSugerencias.Visible = false;
            lstSugerencias.DoubleClick += lstSugerencias_DoubleClick;
            lstSugerencias.Leave += lstSugerencias_Leave;
            // 
            // frmFacturacion
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            ClientSize = new Size(915, 679);
            Controls.Add(lstSugerencias);
            Controls.Add(lstClientes);
            Controls.Add(btnSalir);
            Controls.Add(btnImprimirCotizacion);
            Controls.Add(panel5);
            Controls.Add(btnFacturar);
            Controls.Add(panel4);
            Controls.Add(panelCarrito);
            Controls.Add(panelBusqueda);
            Controls.Add(panel1);
            Controls.Add(panel2);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmFacturacion";
            Text = "frmFacturacion";
            FormClosing += frmFacturacion_FormClosing;
            Load += Gestion_de_Ventas_Load;
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
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
            tableLayoutPanel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnSalir;
        private Button btnImprimirCotizacion;
        private TextBox txtCliente;
        private Panel panel5;
        private Label label7;
        private Label label6;
        private Button btnFacturar;
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
        private Button btnAgregar;
        private DataGridView dgvProductos;
        private Panel panel7;
        private Panel panel10;
        private DataGridView dgvCarrito;
        private PictureBox pbxCarrito;
        private Label label8;
        private TextBox txtCodigo;
        private Panel panel3;
        private Panel panel8;
        private Panel panel6;
        private TextBox txtImpuesto;
        private TextBox txtTotal;
        private TextBox txtSubtotal;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel4;
        private Panel panel9;
        private PictureBox pbxCarritoVacio;
        private Label label5;
        private Label label9;
        private NumericUpDown nudCantidad;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewImageColumn Restar;
        private DataGridViewImageColumn Sumar;
        private DataGridViewImageColumn Eliminar;
        private DataGridViewTextBoxColumn Codigos;
        private DataGridViewTextBoxColumn Producto;
        private DataGridViewTextBoxColumn Precio;
        private DataGridViewTextBoxColumn Stock;
        private ListBox lstClientes;
        private ListBox lstSugerencias;
        private Button button2;
    }
}