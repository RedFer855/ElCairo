namespace ModernMenuUI
{
    partial class frmProductos
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
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductos));
            panelCarrito = new Panel();
            panel10 = new Panel();
            dgvProductos = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            Categoria = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            PorcentajeGanancia = new DataGridViewTextBoxColumn();
            PrecioCompra = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            PrecioVenta = new DataGridViewTextBoxColumn();
            CantidadProducto = new DataGridViewTextBoxColumn();
            EstadoProducto = new DataGridViewCheckBoxColumn();
            panelBusqueda = new Panel();
            txtBuscar = new TextBox();
            btnbuscar = new Button();
            btnNuevoProducto = new Button();
            btnSalir = new Button();
            button1 = new Button();
            gbxEstado = new GroupBox();
            comboBox2 = new ComboBox();
            cmbMarca = new ComboBox();
            rbMostrardeshabilitados = new RadioButton();
            rbMostrarTodos = new RadioButton();
            rbMostrarHabilitados = new RadioButton();
            lblFecha = new Label();
            lblHora = new Label();
            HoraFecha = new System.Windows.Forms.Timer(components);
            tableLayoutPanel1 = new TableLayoutPanel();
            button4 = new Button();
            btnNuevo = new Button();
            panel1 = new Panel();
            panelCarrito.SuspendLayout();
            panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            panelBusqueda.SuspendLayout();
            gbxEstado.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelCarrito
            // 
            panelCarrito.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelCarrito.BackColor = Color.FromArgb(189, 215, 238);
            panelCarrito.Controls.Add(panel10);
            panelCarrito.Location = new Point(17, 23);
            panelCarrito.Margin = new Padding(3, 4, 3, 4);
            panelCarrito.Name = "panelCarrito";
            panelCarrito.Size = new Size(912, 543);
            panelCarrito.TabIndex = 13;
            // 
            // panel10
            // 
            panel10.AutoScroll = true;
            panel10.Controls.Add(dgvProductos);
            panel10.Dock = DockStyle.Fill;
            panel10.Location = new Point(0, 0);
            panel10.Margin = new Padding(3, 4, 3, 4);
            panel10.Name = "panel10";
            panel10.Size = new Size(912, 543);
            panel10.TabIndex = 17;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dgvProductos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            dgvProductos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProductos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvProductos.BackgroundColor = Color.FromArgb(189, 215, 238);
            dgvProductos.BorderStyle = BorderStyle.None;
            dgvProductos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProductos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle7.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, Categoria, dataGridViewTextBoxColumn4, PorcentajeGanancia, PrecioCompra, dataGridViewTextBoxColumn3, PrecioVenta, CantidadProducto, EstadoProducto });
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.White;
            dataGridViewCellStyle9.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle9.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle9.Padding = new Padding(5);
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle9.SelectionForeColor = Color.White;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
            dgvProductos.DefaultCellStyle = dataGridViewCellStyle9;
            dgvProductos.EnableHeadersVisualStyles = false;
            dgvProductos.GridColor = Color.FromArgb(189, 215, 238);
            dgvProductos.Location = new Point(0, 0);
            dgvProductos.Margin = new Padding(3, 4, 3, 4);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = SystemColors.Control;
            dataGridViewCellStyle10.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle10.ForeColor = Color.FromArgb(102, 102, 102);
            dataGridViewCellStyle10.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            dgvProductos.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            dgvProductos.RowHeadersWidth = 30;
            dgvProductos.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvProductos.RowTemplate.Height = 50;
            dgvProductos.Size = new Size(912, 543);
            dgvProductos.TabIndex = 1;
            dgvProductos.SelectionChanged += dgvProductos_SelectionChanged;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "IdProducto";
            dataGridViewCellStyle8.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.Padding = new Padding(0, 1, 0, 0);
            dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle8;
            dataGridViewTextBoxColumn1.FillWeight = 80F;
            dataGridViewTextBoxColumn1.HeaderText = "Código";
            dataGridViewTextBoxColumn1.MinimumWidth = 65;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Width = 65;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn2.DataPropertyName = "NombreProducto";
            dataGridViewTextBoxColumn2.HeaderText = "Producto";
            dataGridViewTextBoxColumn2.MinimumWidth = 100;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // Categoria
            // 
            Categoria.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Categoria.DataPropertyName = "NombreCategoria";
            Categoria.HeaderText = "Categoría";
            Categoria.MinimumWidth = 120;
            Categoria.Name = "Categoria";
            Categoria.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn4.DataPropertyName = "NombreMarca";
            dataGridViewTextBoxColumn4.FillWeight = 120F;
            dataGridViewTextBoxColumn4.HeaderText = "Marca";
            dataGridViewTextBoxColumn4.MinimumWidth = 100;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // PorcentajeGanancia
            // 
            PorcentajeGanancia.DataPropertyName = "PorcentajeGananciaProducto";
            PorcentajeGanancia.FillWeight = 80F;
            PorcentajeGanancia.HeaderText = "Ganancia";
            PorcentajeGanancia.MinimumWidth = 95;
            PorcentajeGanancia.Name = "PorcentajeGanancia";
            PorcentajeGanancia.ReadOnly = true;
            PorcentajeGanancia.Width = 95;
            // 
            // PrecioCompra
            // 
            PrecioCompra.DataPropertyName = "PrecioCompra";
            PrecioCompra.FillWeight = 80F;
            PrecioCompra.HeaderText = "Precio Compra";
            PrecioCompra.MinimumWidth = 6;
            PrecioCompra.Name = "PrecioCompra";
            PrecioCompra.ReadOnly = true;
            PrecioCompra.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.DataPropertyName = "PrecioCosto";
            dataGridViewTextBoxColumn3.FillWeight = 80F;
            dataGridViewTextBoxColumn3.HeaderText = "Precio Costo";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn3.Width = 130;
            // 
            // PrecioVenta
            // 
            PrecioVenta.DataPropertyName = "PrecioVenta";
            PrecioVenta.FillWeight = 80F;
            PrecioVenta.HeaderText = "Precio Venta";
            PrecioVenta.MinimumWidth = 6;
            PrecioVenta.Name = "PrecioVenta";
            PrecioVenta.ReadOnly = true;
            PrecioVenta.Width = 130;
            // 
            // CantidadProducto
            // 
            CantidadProducto.DataPropertyName = "CantidadProducto";
            CantidadProducto.HeaderText = "Cantidad";
            CantidadProducto.MinimumWidth = 6;
            CantidadProducto.Name = "CantidadProducto";
            CantidadProducto.ReadOnly = true;
            CantidadProducto.Width = 125;
            // 
            // EstadoProducto
            // 
            EstadoProducto.DataPropertyName = "EstadoProducto";
            EstadoProducto.HeaderText = "Estado";
            EstadoProducto.MinimumWidth = 6;
            EstadoProducto.Name = "EstadoProducto";
            EstadoProducto.ReadOnly = true;
            EstadoProducto.Resizable = DataGridViewTriState.True;
            EstadoProducto.SortMode = DataGridViewColumnSortMode.Automatic;
            EstadoProducto.Width = 80;
            // 
            // panelBusqueda
            // 
            panelBusqueda.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelBusqueda.BackColor = Color.FromArgb(189, 215, 238);
            panelBusqueda.Controls.Add(txtBuscar);
            panelBusqueda.Controls.Add(btnbuscar);
            panelBusqueda.Location = new Point(14, 16);
            panelBusqueda.Margin = new Padding(3, 4, 3, 4);
            panelBusqueda.Name = "panelBusqueda";
            panelBusqueda.Size = new Size(944, 57);
            panelBusqueda.TabIndex = 14;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.BorderStyle = BorderStyle.None;
            txtBuscar.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(21, 16);
            txtBuscar.Margin = new Padding(3, 4, 3, 4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar Productos...";
            txtBuscar.Size = new Size(847, 24);
            txtBuscar.TabIndex = 1;
            // 
            // btnbuscar
            // 
            btnbuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnbuscar.BackColor = Color.FromArgb(168, 191, 212);
            btnbuscar.BackgroundImage = (Image)resources.GetObject("btnbuscar.BackgroundImage");
            btnbuscar.BackgroundImageLayout = ImageLayout.Zoom;
            btnbuscar.FlatAppearance.BorderSize = 0;
            btnbuscar.FlatStyle = FlatStyle.Flat;
            btnbuscar.Location = new Point(874, 16);
            btnbuscar.Margin = new Padding(3, 4, 3, 4);
            btnbuscar.Name = "btnbuscar";
            btnbuscar.Size = new Size(55, 27);
            btnbuscar.TabIndex = 0;
            btnbuscar.UseVisualStyleBackColor = false;
            // 
            // btnNuevoProducto
            // 
            btnNuevoProducto.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnNuevoProducto.BackColor = Color.FromArgb(149, 195, 172);
            btnNuevoProducto.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNuevoProducto.ForeColor = SystemColors.ButtonFace;
            btnNuevoProducto.Location = new Point(3, 4);
            btnNuevoProducto.Margin = new Padding(3, 4, 3, 4);
            btnNuevoProducto.Name = "btnNuevoProducto";
            btnNuevoProducto.Size = new Size(163, 58);
            btnNuevoProducto.TabIndex = 17;
            btnNuevoProducto.Text = "Nuevo Producto";
            btnNuevoProducto.UseVisualStyleBackColor = false;
            btnNuevoProducto.Click += btnNuevoProducto_Click;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSalir.BackColor = Color.FromArgb(148, 168, 187);
            btnSalir.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.White;
            btnSalir.ImageAlign = ContentAlignment.TopCenter;
            btnSalir.Location = new Point(343, 4);
            btnSalir.Margin = new Padding(3, 4, 3, 4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(111, 58);
            btnSalir.TabIndex = 18;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.BackColor = Color.FromArgb(149, 195, 172);
            button1.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(173, 4);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(163, 58);
            button1.TabIndex = 21;
            button1.Text = "Agregar Marca";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // gbxEstado
            // 
            gbxEstado.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbxEstado.Controls.Add(comboBox2);
            gbxEstado.Controls.Add(cmbMarca);
            gbxEstado.Controls.Add(rbMostrardeshabilitados);
            gbxEstado.Controls.Add(rbMostrarTodos);
            gbxEstado.Controls.Add(rbMostrarHabilitados);
            gbxEstado.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbxEstado.ForeColor = Color.DimGray;
            gbxEstado.Location = new Point(14, 81);
            gbxEstado.Margin = new Padding(3, 4, 3, 4);
            gbxEstado.Name = "gbxEstado";
            gbxEstado.Padding = new Padding(3, 4, 3, 4);
            gbxEstado.Size = new Size(944, 71);
            gbxEstado.TabIndex = 28;
            gbxEstado.TabStop = false;
            gbxEstado.Text = "Filtros de Búsqueda:";
            // 
            // comboBox2
            // 
            comboBox2.ForeColor = Color.DimGray;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(501, 23);
            comboBox2.Margin = new Padding(3, 4, 3, 4);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(210, 31);
            comboBox2.TabIndex = 34;
            comboBox2.Text = "Seleccionar Categoría";
            // 
            // cmbMarca
            // 
            cmbMarca.ForeColor = Color.DimGray;
            cmbMarca.FormattingEnabled = true;
            cmbMarca.Location = new Point(753, 23);
            cmbMarca.Margin = new Padding(3, 4, 3, 4);
            cmbMarca.Name = "cmbMarca";
            cmbMarca.Size = new Size(175, 31);
            cmbMarca.TabIndex = 33;
            cmbMarca.Text = "Seleccionar Marca";
            // 
            // rbMostrardeshabilitados
            // 
            rbMostrardeshabilitados.AutoSize = true;
            rbMostrardeshabilitados.Location = new Point(320, 28);
            rbMostrardeshabilitados.Margin = new Padding(3, 4, 3, 4);
            rbMostrardeshabilitados.Name = "rbMostrardeshabilitados";
            rbMostrardeshabilitados.Size = new Size(149, 27);
            rbMostrardeshabilitados.TabIndex = 30;
            rbMostrardeshabilitados.Text = "Deshabilitados";
            rbMostrardeshabilitados.UseVisualStyleBackColor = true;
            rbMostrardeshabilitados.CheckedChanged += rbMostrardeshabilitados_CheckedChanged;
            // 
            // rbMostrarTodos
            // 
            rbMostrarTodos.AutoSize = true;
            rbMostrarTodos.Checked = true;
            rbMostrarTodos.Location = new Point(7, 28);
            rbMostrarTodos.Margin = new Padding(3, 4, 3, 4);
            rbMostrarTodos.Name = "rbMostrarTodos";
            rbMostrarTodos.Size = new Size(150, 27);
            rbMostrarTodos.TabIndex = 29;
            rbMostrarTodos.TabStop = true;
            rbMostrarTodos.Text = "Mostrar Todos";
            rbMostrarTodos.UseVisualStyleBackColor = true;
            rbMostrarTodos.CheckedChanged += rbMostrarTodos_CheckedChanged;
            // 
            // rbMostrarHabilitados
            // 
            rbMostrarHabilitados.AutoSize = true;
            rbMostrarHabilitados.Location = new Point(174, 28);
            rbMostrarHabilitados.Margin = new Padding(3, 4, 3, 4);
            rbMostrarHabilitados.Name = "rbMostrarHabilitados";
            rbMostrarHabilitados.Size = new Size(124, 27);
            rbMostrarHabilitados.TabIndex = 28;
            rbMostrarHabilitados.Text = "Habilitados";
            rbMostrarHabilitados.UseVisualStyleBackColor = true;
            rbMostrarHabilitados.CheckedChanged += rbMostrarHabilitados_CheckedChanged;
            // 
            // lblFecha
            // 
            lblFecha.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Itim", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFecha.ForeColor = Color.FromArgb(148, 168, 187);
            lblFecha.Location = new Point(575, 851);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(28, 33);
            lblFecha.TabIndex = 30;
            lblFecha.Text = "1";
            lblFecha.Visible = false;
            // 
            // lblHora
            // 
            lblHora.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblHora.AutoSize = true;
            lblHora.Font = new Font("Itim", 20.2499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHora.ForeColor = Color.FromArgb(148, 168, 187);
            lblHora.Location = new Point(575, 816);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(33, 40);
            lblHora.TabIndex = 29;
            lblHora.Text = "1";
            lblHora.Visible = false;
            // 
            // HoraFecha
            // 
            HoraFecha.Enabled = true;
            HoraFecha.Tick += HoraFecha_Tick;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 118F));
            tableLayoutPanel1.Controls.Add(button4, 0, 1);
            tableLayoutPanel1.Controls.Add(btnNuevo, 1, 1);
            tableLayoutPanel1.Controls.Add(btnNuevoProducto, 0, 0);
            tableLayoutPanel1.Controls.Add(btnSalir, 2, 0);
            tableLayoutPanel1.Controls.Add(button1, 1, 0);
            tableLayoutPanel1.Location = new Point(14, 751);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(458, 133);
            tableLayoutPanel1.TabIndex = 31;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button4.BackColor = Color.FromArgb(149, 195, 172);
            button4.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.ForeColor = SystemColors.ButtonFace;
            button4.Location = new Point(3, 70);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(163, 59);
            button4.TabIndex = 22;
            button4.Text = "Agregar Categoria";
            button4.UseVisualStyleBackColor = false;
            // 
            // btnNuevo
            // 
            btnNuevo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnNuevo.BackColor = Color.FromArgb(189, 215, 238);
            btnNuevo.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNuevo.ForeColor = Color.FromArgb(87, 99, 110);
            btnNuevo.Location = new Point(173, 70);
            btnNuevo.Margin = new Padding(3, 4, 3, 4);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(163, 59);
            btnNuevo.TabIndex = 20;
            btnNuevo.Text = "Editar Producto";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += button3_Click_1;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(189, 215, 238);
            panel1.Controls.Add(panelCarrito);
            panel1.Location = new Point(14, 160);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(944, 583);
            panel1.TabIndex = 32;
            // 
            // frmProductos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(971, 905);
            Controls.Add(panel1);
            Controls.Add(lblFecha);
            Controls.Add(lblHora);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(gbxEstado);
            Controls.Add(panelBusqueda);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmProductos";
            Text = "frmProductos";
            Load += frmProductos_Load;
            panelCarrito.ResumeLayout(false);
            panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            panelBusqueda.ResumeLayout(false);
            panelBusqueda.PerformLayout();
            gbxEstado.ResumeLayout(false);
            gbxEstado.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelCarrito;
        private Panel panel10;
        private DataGridView dgvProductos;
        private Panel panelBusqueda;
        private TextBox txtBuscar;
        private Button btnbuscar;
        private Button btnNuevoProducto;
        private Button btnSalir;
        private Button button1;
        private GroupBox gbxEstado;
        private RadioButton rbMostrardeshabilitados;
        private RadioButton rbMostrarTodos;
        private RadioButton rbMostrarHabilitados;
        private Label lblFecha;
        private Label lblHora;
        private System.Windows.Forms.Timer HoraFecha;
        private TableLayoutPanel tableLayoutPanel1;
        private Button button4;
        private Button btnNuevo;
        private Panel panel1;
        private ComboBox cmbMarca;
        private ComboBox comboBox2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn Categoria;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn PorcentajeGanancia;
        private DataGridViewTextBoxColumn PrecioCompra;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn PrecioVenta;
        private DataGridViewTextBoxColumn CantidadProducto;
        private DataGridViewCheckBoxColumn EstadoProducto;
    }
}