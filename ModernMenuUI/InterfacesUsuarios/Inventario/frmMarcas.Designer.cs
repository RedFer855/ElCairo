namespace ModernMenuUI.InterfacesUsuarios.Inventario
{
    partial class frmMarcas
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMarcas));
            panel1 = new Panel();
            panelCarrito = new Panel();
            panel10 = new Panel();
            dgvMarcas = new DataGridView();
            btnAgregarMarca = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnSeleccionarMarca = new Button();
            btnModificarMarca = new Button();
            btnSalir = new Button();
            gbxEstado = new GroupBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            txtMarca = new TextBox();
            btnProveedores = new Button();
            label1 = new Label();
            rbMostrarDeshablitados = new RadioButton();
            rbMostrarTodos = new RadioButton();
            rbMostrarHablilitados = new RadioButton();
            panelBusqueda = new Panel();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            lstSugerencias = new ListBox();
            pnlLimpiarFiltros = new Panel();
            btnLimpiarFiltros = new Button();
            pbxClean = new PictureBox();
            IdMarca = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            Proveedor = new DataGridViewTextBoxColumn();
            EstadoProducto = new DataGridViewCheckBoxColumn();
            panel1.SuspendLayout();
            panelCarrito.SuspendLayout();
            panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMarcas).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            gbxEstado.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panelBusqueda.SuspendLayout();
            pnlLimpiarFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxClean).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(189, 215, 238);
            panel1.Controls.Add(panelCarrito);
            panel1.Location = new Point(14, 161);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(929, 376);
            panel1.TabIndex = 34;
            // 
            // panelCarrito
            // 
            panelCarrito.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelCarrito.BackColor = Color.FromArgb(189, 215, 238);
            panelCarrito.Controls.Add(panel10);
            panelCarrito.Location = new Point(17, 25);
            panelCarrito.Margin = new Padding(3, 4, 3, 4);
            panelCarrito.Name = "panelCarrito";
            panelCarrito.Size = new Size(891, 324);
            panelCarrito.TabIndex = 13;
            // 
            // panel10
            // 
            panel10.AutoScroll = true;
            panel10.Controls.Add(dgvMarcas);
            panel10.Dock = DockStyle.Fill;
            panel10.Location = new Point(0, 0);
            panel10.Margin = new Padding(3, 4, 3, 4);
            panel10.Name = "panel10";
            panel10.Size = new Size(891, 324);
            panel10.TabIndex = 17;
            // 
            // dgvMarcas
            // 
            dgvMarcas.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dgvMarcas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvMarcas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvMarcas.BackgroundColor = Color.FromArgb(189, 215, 238);
            dgvMarcas.BorderStyle = BorderStyle.None;
            dgvMarcas.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMarcas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle2.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvMarcas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvMarcas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMarcas.Columns.AddRange(new DataGridViewColumn[] { IdMarca, dataGridViewTextBoxColumn4, Proveedor, EstadoProducto });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle3.Padding = new Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvMarcas.DefaultCellStyle = dataGridViewCellStyle3;
            dgvMarcas.Dock = DockStyle.Fill;
            dgvMarcas.EnableHeadersVisualStyles = false;
            dgvMarcas.GridColor = Color.FromArgb(189, 215, 238);
            dgvMarcas.Location = new Point(0, 0);
            dgvMarcas.Margin = new Padding(3, 4, 3, 4);
            dgvMarcas.Name = "dgvMarcas";
            dgvMarcas.ReadOnly = true;
            dgvMarcas.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle4.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(102, 102, 102);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvMarcas.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvMarcas.RowHeadersWidth = 30;
            dgvMarcas.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvMarcas.RowTemplate.Height = 50;
            dgvMarcas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMarcas.Size = new Size(891, 324);
            dgvMarcas.TabIndex = 1;
            dgvMarcas.TabStop = false;
            dgvMarcas.CellDoubleClick += dgvMarcas_CellDoubleClick;
            dgvMarcas.SelectionChanged += dgvMarcas_SelectionChanged;
            // 
            // btnAgregarMarca
            // 
            btnAgregarMarca.BackColor = Color.FromArgb(149, 195, 172);
            btnAgregarMarca.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregarMarca.ForeColor = SystemColors.ButtonFace;
            btnAgregarMarca.Location = new Point(3, 4);
            btnAgregarMarca.Margin = new Padding(3, 4, 3, 4);
            btnAgregarMarca.Name = "btnAgregarMarca";
            btnAgregarMarca.Size = new Size(142, 59);
            btnAgregarMarca.TabIndex = 35;
            btnAgregarMarca.Text = "Nueva Marca";
            btnAgregarMarca.UseVisualStyleBackColor = false;
            btnAgregarMarca.Click += btnAgregarMarca_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            flowLayoutPanel1.Controls.Add(btnAgregarMarca);
            flowLayoutPanel1.Controls.Add(btnSeleccionarMarca);
            flowLayoutPanel1.Controls.Add(btnModificarMarca);
            flowLayoutPanel1.Controls.Add(btnSalir);
            flowLayoutPanel1.Location = new Point(14, 557);
            flowLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(602, 68);
            flowLayoutPanel1.TabIndex = 36;
            // 
            // btnSeleccionarMarca
            // 
            btnSeleccionarMarca.BackColor = Color.FromArgb(149, 195, 172);
            btnSeleccionarMarca.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSeleccionarMarca.ForeColor = SystemColors.ButtonFace;
            btnSeleccionarMarca.Location = new Point(151, 4);
            btnSeleccionarMarca.Margin = new Padding(3, 4, 3, 4);
            btnSeleccionarMarca.Name = "btnSeleccionarMarca";
            btnSeleccionarMarca.Size = new Size(175, 59);
            btnSeleccionarMarca.TabIndex = 38;
            btnSeleccionarMarca.Text = "Seleccionar Marca";
            btnSeleccionarMarca.UseVisualStyleBackColor = false;
            btnSeleccionarMarca.Click += btnSeleccionarMarca_Click;
            // 
            // btnModificarMarca
            // 
            btnModificarMarca.BackColor = Color.FromArgb(148, 168, 187);
            btnModificarMarca.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnModificarMarca.ForeColor = SystemColors.ButtonFace;
            btnModificarMarca.Location = new Point(332, 4);
            btnModificarMarca.Margin = new Padding(3, 4, 3, 4);
            btnModificarMarca.Name = "btnModificarMarca";
            btnModificarMarca.Size = new Size(147, 59);
            btnModificarMarca.TabIndex = 36;
            btnModificarMarca.Text = "Ver Marca";
            btnModificarMarca.UseVisualStyleBackColor = false;
            btnModificarMarca.Click += btnModificarMarca_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(148, 168, 187);
            btnSalir.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = SystemColors.ButtonFace;
            btnSalir.Location = new Point(485, 4);
            btnSalir.Margin = new Padding(3, 4, 3, 4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(104, 59);
            btnSalir.TabIndex = 37;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // gbxEstado
            // 
            gbxEstado.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbxEstado.Controls.Add(tableLayoutPanel2);
            gbxEstado.Controls.Add(rbMostrarDeshablitados);
            gbxEstado.Controls.Add(rbMostrarTodos);
            gbxEstado.Controls.Add(rbMostrarHablilitados);
            gbxEstado.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbxEstado.ForeColor = Color.DimGray;
            gbxEstado.Location = new Point(14, 83);
            gbxEstado.Margin = new Padding(3, 4, 3, 4);
            gbxEstado.Name = "gbxEstado";
            gbxEstado.Padding = new Padding(3, 4, 3, 4);
            gbxEstado.Size = new Size(929, 71);
            gbxEstado.TabIndex = 37;
            gbxEstado.TabStop = false;
            gbxEstado.Text = "Filtros de Búsqueda:";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 114F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 37F));
            tableLayoutPanel2.Controls.Add(txtMarca, 1, 0);
            tableLayoutPanel2.Controls.Add(btnProveedores, 2, 0);
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Location = new Point(437, 23);
            tableLayoutPanel2.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel2.MaximumSize = new Size(480, 40);
            tableLayoutPanel2.MinimumSize = new Size(344, 40);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(480, 40);
            tableLayoutPanel2.TabIndex = 39;
            // 
            // txtMarca
            // 
            txtMarca.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMarca.Location = new Point(117, 4);
            txtMarca.Margin = new Padding(3, 4, 3, 4);
            txtMarca.Name = "txtMarca";
            txtMarca.PlaceholderText = "(Todos los Proveedores)";
            txtMarca.ReadOnly = true;
            txtMarca.Size = new Size(323, 30);
            txtMarca.TabIndex = 34;
            // 
            // btnProveedores
            // 
            btnProveedores.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnProveedores.BackColor = Color.FromArgb(168, 191, 212);
            btnProveedores.BackgroundImage = (Image)resources.GetObject("btnProveedores.BackgroundImage");
            btnProveedores.BackgroundImageLayout = ImageLayout.Zoom;
            btnProveedores.FlatAppearance.BorderSize = 0;
            btnProveedores.FlatStyle = FlatStyle.Flat;
            btnProveedores.Location = new Point(448, 4);
            btnProveedores.Margin = new Padding(3, 4, 3, 4);
            btnProveedores.Name = "btnProveedores";
            btnProveedores.Size = new Size(29, 32);
            btnProveedores.TabIndex = 2;
            btnProveedores.UseVisualStyleBackColor = false;
            btnProveedores.Click += btnProveedores_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(108, 40);
            label1.TabIndex = 35;
            label1.Text = "Proveedores:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // rbMostrarDeshablitados
            // 
            rbMostrarDeshablitados.AutoSize = true;
            rbMostrarDeshablitados.Location = new Point(139, 29);
            rbMostrarDeshablitados.Margin = new Padding(3, 4, 3, 4);
            rbMostrarDeshablitados.Name = "rbMostrarDeshablitados";
            rbMostrarDeshablitados.Size = new Size(149, 27);
            rbMostrarDeshablitados.TabIndex = 30;
            rbMostrarDeshablitados.Text = "Deshabilitados";
            rbMostrarDeshablitados.UseVisualStyleBackColor = true;
            // 
            // rbMostrarTodos
            // 
            rbMostrarTodos.AutoSize = true;
            rbMostrarTodos.Location = new Point(285, 29);
            rbMostrarTodos.Margin = new Padding(3, 4, 3, 4);
            rbMostrarTodos.Name = "rbMostrarTodos";
            rbMostrarTodos.Size = new Size(150, 27);
            rbMostrarTodos.TabIndex = 29;
            rbMostrarTodos.Text = "Mostrar Todos";
            rbMostrarTodos.UseVisualStyleBackColor = true;
            // 
            // rbMostrarHablilitados
            // 
            rbMostrarHablilitados.AutoSize = true;
            rbMostrarHablilitados.Checked = true;
            rbMostrarHablilitados.Location = new Point(17, 28);
            rbMostrarHablilitados.Margin = new Padding(3, 4, 3, 4);
            rbMostrarHablilitados.Name = "rbMostrarHablilitados";
            rbMostrarHablilitados.Size = new Size(124, 27);
            rbMostrarHablilitados.TabIndex = 28;
            rbMostrarHablilitados.TabStop = true;
            rbMostrarHablilitados.Text = "Habilitados";
            rbMostrarHablilitados.UseVisualStyleBackColor = true;
            // 
            // panelBusqueda
            // 
            panelBusqueda.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelBusqueda.BackColor = Color.FromArgb(189, 215, 238);
            panelBusqueda.Controls.Add(txtBuscar);
            panelBusqueda.Controls.Add(btnBuscar);
            panelBusqueda.Location = new Point(17, 16);
            panelBusqueda.Margin = new Padding(3, 4, 3, 4);
            panelBusqueda.MaximumSize = new Size(800, 57);
            panelBusqueda.MinimumSize = new Size(377, 57);
            panelBusqueda.Name = "panelBusqueda";
            panelBusqueda.Size = new Size(544, 57);
            panelBusqueda.TabIndex = 38;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtBuscar.BorderStyle = BorderStyle.None;
            txtBuscar.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(21, 16);
            txtBuscar.Margin = new Padding(3, 4, 3, 4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar Marcas...";
            txtBuscar.Size = new Size(445, 24);
            txtBuscar.TabIndex = 1;
            txtBuscar.KeyDown += txtBuscar_KeyDown;
            txtBuscar.KeyUp += txtBuscar_KeyUp;
            // 
            // btnBuscar
            // 
            btnBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuscar.BackColor = Color.FromArgb(168, 191, 212);
            btnBuscar.BackgroundImage = (Image)resources.GetObject("btnBuscar.BackgroundImage");
            btnBuscar.BackgroundImageLayout = ImageLayout.Zoom;
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Location = new Point(472, 16);
            btnBuscar.Margin = new Padding(3, 4, 3, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(55, 27);
            btnBuscar.TabIndex = 0;
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // lstSugerencias
            // 
            lstSugerencias.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lstSugerencias.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstSugerencias.ForeColor = Color.DimGray;
            lstSugerencias.FormattingEnabled = true;
            lstSugerencias.ItemHeight = 23;
            lstSugerencias.Location = new Point(38, 60);
            lstSugerencias.Margin = new Padding(3, 4, 3, 4);
            lstSugerencias.MinimumSize = new Size(277, 28);
            lstSugerencias.Name = "lstSugerencias";
            lstSugerencias.Size = new Size(444, 27);
            lstSugerencias.TabIndex = 39;
            lstSugerencias.Visible = false;
            lstSugerencias.MouseClick += lstSugerencias_MouseClick;
            lstSugerencias.KeyDown += lstSugerencias_KeyDown;
            // 
            // pnlLimpiarFiltros
            // 
            pnlLimpiarFiltros.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlLimpiarFiltros.BackColor = Color.FromArgb(189, 215, 238);
            pnlLimpiarFiltros.Controls.Add(btnLimpiarFiltros);
            pnlLimpiarFiltros.Controls.Add(pbxClean);
            pnlLimpiarFiltros.Location = new Point(753, 16);
            pnlLimpiarFiltros.Margin = new Padding(3, 4, 3, 4);
            pnlLimpiarFiltros.Name = "pnlLimpiarFiltros";
            pnlLimpiarFiltros.Size = new Size(190, 57);
            pnlLimpiarFiltros.TabIndex = 56;
            pnlLimpiarFiltros.Visible = false;
            // 
            // btnLimpiarFiltros
            // 
            btnLimpiarFiltros.BackColor = Color.FromArgb(148, 168, 187);
            btnLimpiarFiltros.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLimpiarFiltros.ForeColor = Color.White;
            btnLimpiarFiltros.ImageAlign = ContentAlignment.TopCenter;
            btnLimpiarFiltros.Location = new Point(3, 7);
            btnLimpiarFiltros.Margin = new Padding(3, 4, 3, 4);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(134, 43);
            btnLimpiarFiltros.TabIndex = 34;
            btnLimpiarFiltros.Text = "Limpiar Filtros";
            btnLimpiarFiltros.UseVisualStyleBackColor = false;
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;
            // 
            // pbxClean
            // 
            pbxClean.Image = (Image)resources.GetObject("pbxClean.Image");
            pbxClean.Location = new Point(138, 11);
            pbxClean.Margin = new Padding(3, 4, 3, 4);
            pbxClean.Name = "pbxClean";
            pbxClean.Size = new Size(51, 32);
            pbxClean.SizeMode = PictureBoxSizeMode.Zoom;
            pbxClean.TabIndex = 35;
            pbxClean.TabStop = false;
            // 
            // IdMarca
            // 
            IdMarca.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            IdMarca.DataPropertyName = "IdMarca";
            IdMarca.HeaderText = "Código";
            IdMarca.MinimumWidth = 6;
            IdMarca.Name = "IdMarca";
            IdMarca.ReadOnly = true;
            IdMarca.Visible = false;
            IdMarca.Width = 106;
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
            // Proveedor
            // 
            Proveedor.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Proveedor.DataPropertyName = "NombreProveedor";
            Proveedor.HeaderText = "Proveedor";
            Proveedor.MinimumWidth = 6;
            Proveedor.Name = "Proveedor";
            Proveedor.ReadOnly = true;
            // 
            // EstadoProducto
            // 
            EstadoProducto.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            EstadoProducto.DataPropertyName = "EstadoMarca";
            EstadoProducto.HeaderText = "Estado";
            EstadoProducto.MinimumWidth = 6;
            EstadoProducto.Name = "EstadoProducto";
            EstadoProducto.ReadOnly = true;
            EstadoProducto.Resizable = DataGridViewTriState.True;
            EstadoProducto.SortMode = DataGridViewColumnSortMode.Automatic;
            EstadoProducto.Width = 105;
            // 
            // frmMarcas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(957, 641);
            Controls.Add(pnlLimpiarFiltros);
            Controls.Add(lstSugerencias);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panelBusqueda);
            Controls.Add(gbxEstado);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(816, 626);
            Name = "frmMarcas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Marcas";
            FormClosing += frmMarcas_FormClosing;
            Load += frmMarcas_Load;
            panel1.ResumeLayout(false);
            panelCarrito.ResumeLayout(false);
            panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMarcas).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            gbxEstado.ResumeLayout(false);
            gbxEstado.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            panelBusqueda.ResumeLayout(false);
            panelBusqueda.PerformLayout();
            pnlLimpiarFiltros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbxClean).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panelCarrito;
        private Panel panel10;
        private DataGridView dgvMarcas;
        private Button btnAgregarMarca;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnModificarMarca;
        private Button btnSalir;
        private GroupBox gbxEstado;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox txtMarca;
        private Button btnProveedores;
        private RadioButton rbMostrarDeshablitados;
        private RadioButton rbMostrarTodos;
        private RadioButton rbMostrarHablilitados;
        private Label label1;
        private Panel panelBusqueda;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private Button btnSeleccionarMarca;
        private ListBox lstSugerencias;
        private Panel pnlLimpiarFiltros;
        private Button btnLimpiarFiltros;
        private PictureBox pbxClean;
        private DataGridViewTextBoxColumn IdMarca;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn Proveedor;
        private DataGridViewCheckBoxColumn EstadoProducto;
    }
}