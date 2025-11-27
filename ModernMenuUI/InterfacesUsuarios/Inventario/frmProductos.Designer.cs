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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductos));
            panelCarrito = new Panel();
            panel10 = new Panel();
            dgvProductos = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            Contenido = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            Categoria = new DataGridViewTextBoxColumn();
            Presentacion = new DataGridViewTextBoxColumn();
            CantidadProducto = new DataGridViewTextBoxColumn();
            PrecioVenta = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            PrecioCompra = new DataGridViewTextBoxColumn();
            PorcentajeGanancia = new DataGridViewTextBoxColumn();
            EstadoProducto = new DataGridViewCheckBoxColumn();
            panelBusqueda = new Panel();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            btnNuevoProducto = new Button();
            btnSalir = new Button();
            btnAgregarMarca = new Button();
            gbxEstado = new GroupBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            label1 = new Label();
            txtFiltroMarca = new TextBox();
            btnMarca = new Button();
            btnCategoria = new Button();
            txtFiltroCategoria = new TextBox();
            label2 = new Label();
            rbMostrardeshabilitados = new RadioButton();
            rbMostrarTodos = new RadioButton();
            rbMostrarHabilitados = new RadioButton();
            lblFecha = new Label();
            lblHora = new Label();
            HoraFecha = new System.Windows.Forms.Timer(components);
            btnIngresarPerdida = new Button();
            btnAgregarCategoria = new Button();
            btnEditarProducto = new Button();
            panel1 = new Panel();
            lstSugerencias = new ListBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnLimpiarFiltros = new Button();
            pbxClean = new PictureBox();
            pnlLimpiarFiltros = new Panel();
            label3 = new Label();
            panelCarrito.SuspendLayout();
            panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            panelBusqueda.SuspendLayout();
            gbxEstado.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxClean).BeginInit();
            pnlLimpiarFiltros.SuspendLayout();
            SuspendLayout();
            // 
            // panelCarrito
            // 
            panelCarrito.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelCarrito.BackColor = Color.FromArgb(189, 215, 238);
            panelCarrito.Controls.Add(panel10);
            panelCarrito.Location = new Point(15, 17);
            panelCarrito.Name = "panelCarrito";
            panelCarrito.Size = new Size(718, 407);
            panelCarrito.TabIndex = 13;
            // 
            // panel10
            // 
            panel10.AutoScroll = true;
            panel10.Controls.Add(dgvProductos);
            panel10.Dock = DockStyle.Fill;
            panel10.Location = new Point(0, 0);
            panel10.Name = "panel10";
            panel10.Size = new Size(718, 407);
            panel10.TabIndex = 17;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dgvProductos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvProductos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvProductos.BackgroundColor = Color.FromArgb(189, 215, 238);
            dgvProductos.BorderStyle = BorderStyle.None;
            dgvProductos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProductos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle2.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle2.SelectionBackColor = Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, Contenido, dataGridViewTextBoxColumn4, Categoria, Presentacion, CantidadProducto, PrecioVenta, dataGridViewTextBoxColumn3, PrecioCompra, PorcentajeGanancia, EstadoProducto });
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.White;
            dataGridViewCellStyle9.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle9.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle9.Padding = new Padding(5);
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle9.SelectionForeColor = Color.White;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
            dgvProductos.DefaultCellStyle = dataGridViewCellStyle9;
            dgvProductos.Dock = DockStyle.Fill;
            dgvProductos.EnableHeadersVisualStyles = false;
            dgvProductos.GridColor = Color.FromArgb(189, 215, 238);
            dgvProductos.Location = new Point(0, 0);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle10.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle10.ForeColor = Color.FromArgb(102, 102, 102);
            dataGridViewCellStyle10.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            dgvProductos.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            dgvProductos.RowHeadersWidth = 30;
            dgvProductos.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvProductos.RowTemplate.Height = 50;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(718, 407);
            dgvProductos.TabIndex = 1;
            dgvProductos.SelectionChanged += dgvProductos_SelectionChanged;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewTextBoxColumn1.DataPropertyName = "CodigoBarraProducto";
            dataGridViewCellStyle3.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.Padding = new Padding(0, 1, 0, 0);
            dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewTextBoxColumn1.FillWeight = 80F;
            dataGridViewTextBoxColumn1.HeaderText = "Código";
            dataGridViewTextBoxColumn1.MinimumWidth = 65;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Width = 89;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn2.DataPropertyName = "NombreProducto";
            dataGridViewTextBoxColumn2.HeaderText = "Producto";
            dataGridViewTextBoxColumn2.MinimumWidth = 180;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // Contenido
            // 
            Contenido.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Contenido.DataPropertyName = "ContenidoProducto";
            Contenido.HeaderText = "Contenido";
            Contenido.Name = "Contenido";
            Contenido.ReadOnly = true;
            Contenido.Width = 113;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            dataGridViewTextBoxColumn4.DataPropertyName = "NombreMarca";
            dataGridViewTextBoxColumn4.FillWeight = 120F;
            dataGridViewTextBoxColumn4.HeaderText = "Marca";
            dataGridViewTextBoxColumn4.MinimumWidth = 100;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // Categoria
            // 
            Categoria.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Categoria.DataPropertyName = "NombreCategoria";
            Categoria.HeaderText = "Categoría";
            Categoria.MinimumWidth = 120;
            Categoria.Name = "Categoria";
            Categoria.ReadOnly = true;
            Categoria.Width = 120;
            // 
            // Presentacion
            // 
            Presentacion.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Presentacion.DataPropertyName = "NombrePresentacion";
            Presentacion.HeaderText = "Presentación";
            Presentacion.Name = "Presentacion";
            Presentacion.ReadOnly = true;
            Presentacion.Width = 131;
            // 
            // CantidadProducto
            // 
            CantidadProducto.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            CantidadProducto.DataPropertyName = "CantidadProducto";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            CantidadProducto.DefaultCellStyle = dataGridViewCellStyle4;
            CantidadProducto.HeaderText = "Cantidad";
            CantidadProducto.Name = "CantidadProducto";
            CantidadProducto.ReadOnly = true;
            CantidadProducto.Width = 105;
            // 
            // PrecioVenta
            // 
            PrecioVenta.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            PrecioVenta.DataPropertyName = "PrecioVenta";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            PrecioVenta.DefaultCellStyle = dataGridViewCellStyle5;
            PrecioVenta.FillWeight = 80F;
            PrecioVenta.HeaderText = "Precio Venta";
            PrecioVenta.Name = "PrecioVenta";
            PrecioVenta.ReadOnly = true;
            PrecioVenta.Width = 127;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewTextBoxColumn3.DataPropertyName = "PrecioCosto";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewTextBoxColumn3.FillWeight = 80F;
            dataGridViewTextBoxColumn3.HeaderText = "Precio Costo";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn3.Width = 127;
            // 
            // PrecioCompra
            // 
            PrecioCompra.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            PrecioCompra.DataPropertyName = "PrecioCompra";
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            PrecioCompra.DefaultCellStyle = dataGridViewCellStyle7;
            PrecioCompra.FillWeight = 80F;
            PrecioCompra.HeaderText = "Precio Compra";
            PrecioCompra.Name = "PrecioCompra";
            PrecioCompra.ReadOnly = true;
            PrecioCompra.Width = 141;
            // 
            // PorcentajeGanancia
            // 
            PorcentajeGanancia.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            PorcentajeGanancia.DataPropertyName = "PorcentajeGananciaProducto";
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            PorcentajeGanancia.DefaultCellStyle = dataGridViewCellStyle8;
            PorcentajeGanancia.FillWeight = 80F;
            PorcentajeGanancia.HeaderText = "Ganancia";
            PorcentajeGanancia.MinimumWidth = 95;
            PorcentajeGanancia.Name = "PorcentajeGanancia";
            PorcentajeGanancia.ReadOnly = true;
            PorcentajeGanancia.Width = 107;
            // 
            // EstadoProducto
            // 
            EstadoProducto.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            EstadoProducto.DataPropertyName = "EstadoProducto";
            EstadoProducto.HeaderText = "Estado";
            EstadoProducto.Name = "EstadoProducto";
            EstadoProducto.ReadOnly = true;
            EstadoProducto.Resizable = DataGridViewTriState.True;
            EstadoProducto.SortMode = DataGridViewColumnSortMode.Automatic;
            EstadoProducto.Width = 89;
            // 
            // panelBusqueda
            // 
            panelBusqueda.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelBusqueda.BackColor = Color.FromArgb(189, 215, 238);
            panelBusqueda.Controls.Add(txtBuscar);
            panelBusqueda.Controls.Add(btnBuscar);
            panelBusqueda.Location = new Point(12, 12);
            panelBusqueda.MaximumSize = new Size(885, 43);
            panelBusqueda.MinimumSize = new Size(250, 43);
            panelBusqueda.Name = "panelBusqueda";
            panelBusqueda.Size = new Size(428, 43);
            panelBusqueda.TabIndex = 14;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtBuscar.BorderStyle = BorderStyle.None;
            txtBuscar.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(18, 12);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar Productos...";
            txtBuscar.Size = new Size(343, 20);
            txtBuscar.TabIndex = 1;
            txtBuscar.KeyDown += txtBuscar_KeyDown;
            txtBuscar.KeyUp += txtBuscar_KeyUp;
            txtBuscar.Leave += txtBuscar_Leave;
            // 
            // btnBuscar
            // 
            btnBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuscar.BackColor = Color.FromArgb(168, 191, 212);
            btnBuscar.BackgroundImage = (Image)resources.GetObject("btnBuscar.BackgroundImage");
            btnBuscar.BackgroundImageLayout = ImageLayout.Zoom;
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Location = new Point(367, 12);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(48, 20);
            btnBuscar.TabIndex = 0;
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnNuevoProducto
            // 
            btnNuevoProducto.BackColor = Color.FromArgb(149, 195, 172);
            btnNuevoProducto.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNuevoProducto.ForeColor = SystemColors.ButtonFace;
            btnNuevoProducto.Location = new Point(3, 3);
            btnNuevoProducto.Name = "btnNuevoProducto";
            btnNuevoProducto.Size = new Size(185, 44);
            btnNuevoProducto.TabIndex = 17;
            btnNuevoProducto.Text = "Nuevo Producto";
            btnNuevoProducto.UseVisualStyleBackColor = false;
            btnNuevoProducto.Click += btnNuevoProducto_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(148, 168, 187);
            btnSalir.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.White;
            btnSalir.ImageAlign = ContentAlignment.TopCenter;
            btnSalir.Location = new Point(340, 53);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(140, 44);
            btnSalir.TabIndex = 18;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnAgregarMarca
            // 
            btnAgregarMarca.BackColor = Color.FromArgb(149, 195, 172);
            btnAgregarMarca.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregarMarca.ForeColor = SystemColors.ButtonFace;
            btnAgregarMarca.Location = new Point(340, 3);
            btnAgregarMarca.Name = "btnAgregarMarca";
            btnAgregarMarca.Size = new Size(140, 44);
            btnAgregarMarca.TabIndex = 21;
            btnAgregarMarca.Text = "Marcas";
            btnAgregarMarca.UseVisualStyleBackColor = false;
            btnAgregarMarca.Click += btnAgregarMarca_Click;
            // 
            // gbxEstado
            // 
            gbxEstado.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbxEstado.Controls.Add(tableLayoutPanel2);
            gbxEstado.Controls.Add(rbMostrardeshabilitados);
            gbxEstado.Controls.Add(rbMostrarTodos);
            gbxEstado.Controls.Add(rbMostrarHabilitados);
            gbxEstado.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbxEstado.ForeColor = Color.DimGray;
            gbxEstado.Location = new Point(12, 61);
            gbxEstado.Name = "gbxEstado";
            gbxEstado.Size = new Size(746, 53);
            gbxEstado.TabIndex = 28;
            gbxEstado.TabStop = false;
            gbxEstado.Text = "Filtros de Búsqueda:";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 6;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 94F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 33F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 67F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 34F));
            tableLayoutPanel2.Controls.Add(label1, 3, 0);
            tableLayoutPanel2.Controls.Add(txtFiltroMarca, 4, 0);
            tableLayoutPanel2.Controls.Add(btnMarca, 5, 0);
            tableLayoutPanel2.Controls.Add(btnCategoria, 2, 0);
            tableLayoutPanel2.Controls.Add(txtFiltroCategoria, 1, 0);
            tableLayoutPanel2.Controls.Add(label2, 0, 0);
            tableLayoutPanel2.Location = new Point(375, 17);
            tableLayoutPanel2.MinimumSize = new Size(350, 30);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(372, 30);
            tableLayoutPanel2.TabIndex = 39;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(202, 0);
            label1.Name = "label1";
            label1.Size = new Size(61, 30);
            label1.TabIndex = 40;
            label1.Text = "Marcas:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtFiltroMarca
            // 
            txtFiltroMarca.Dock = DockStyle.Fill;
            txtFiltroMarca.Location = new Point(269, 3);
            txtFiltroMarca.Name = "txtFiltroMarca";
            txtFiltroMarca.PlaceholderText = "(Todas)";
            txtFiltroMarca.ReadOnly = true;
            txtFiltroMarca.Size = new Size(66, 25);
            txtFiltroMarca.TabIndex = 34;
            // 
            // btnMarca
            // 
            btnMarca.BackColor = Color.FromArgb(168, 191, 212);
            btnMarca.BackgroundImage = (Image)resources.GetObject("btnMarca.BackgroundImage");
            btnMarca.BackgroundImageLayout = ImageLayout.Zoom;
            btnMarca.Dock = DockStyle.Fill;
            btnMarca.FlatAppearance.BorderSize = 0;
            btnMarca.FlatStyle = FlatStyle.Flat;
            btnMarca.Location = new Point(341, 3);
            btnMarca.Name = "btnMarca";
            btnMarca.Size = new Size(28, 24);
            btnMarca.TabIndex = 2;
            btnMarca.UseVisualStyleBackColor = false;
            btnMarca.Click += btnMarca_Click;
            // 
            // btnCategoria
            // 
            btnCategoria.BackColor = Color.FromArgb(168, 191, 212);
            btnCategoria.BackgroundImage = (Image)resources.GetObject("btnCategoria.BackgroundImage");
            btnCategoria.BackgroundImageLayout = ImageLayout.Zoom;
            btnCategoria.Dock = DockStyle.Fill;
            btnCategoria.FlatAppearance.BorderSize = 0;
            btnCategoria.FlatStyle = FlatStyle.Flat;
            btnCategoria.Location = new Point(169, 3);
            btnCategoria.Name = "btnCategoria";
            btnCategoria.Size = new Size(27, 24);
            btnCategoria.TabIndex = 38;
            btnCategoria.UseVisualStyleBackColor = false;
            btnCategoria.Click += btnCategoria_Click;
            // 
            // txtFiltroCategoria
            // 
            txtFiltroCategoria.Dock = DockStyle.Fill;
            txtFiltroCategoria.Location = new Point(97, 3);
            txtFiltroCategoria.Name = "txtFiltroCategoria";
            txtFiltroCategoria.PlaceholderText = "(Todas)";
            txtFiltroCategoria.ReadOnly = true;
            txtFiltroCategoria.Size = new Size(66, 25);
            txtFiltroCategoria.TabIndex = 35;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(88, 30);
            label2.TabIndex = 39;
            label2.Text = "Categorías:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // rbMostrardeshabilitados
            // 
            rbMostrardeshabilitados.AutoSize = true;
            rbMostrardeshabilitados.Location = new Point(113, 22);
            rbMostrardeshabilitados.Name = "rbMostrardeshabilitados";
            rbMostrardeshabilitados.Size = new Size(121, 22);
            rbMostrardeshabilitados.TabIndex = 30;
            rbMostrardeshabilitados.Text = "Deshabilitados";
            rbMostrardeshabilitados.UseVisualStyleBackColor = true;
            // 
            // rbMostrarTodos
            // 
            rbMostrarTodos.AutoSize = true;
            rbMostrarTodos.Location = new Point(240, 22);
            rbMostrarTodos.Name = "rbMostrarTodos";
            rbMostrarTodos.Size = new Size(120, 22);
            rbMostrarTodos.TabIndex = 29;
            rbMostrarTodos.Text = "Mostrar Todos";
            rbMostrarTodos.UseVisualStyleBackColor = true;
            // 
            // rbMostrarHabilitados
            // 
            rbMostrarHabilitados.AutoSize = true;
            rbMostrarHabilitados.Checked = true;
            rbMostrarHabilitados.Location = new Point(6, 22);
            rbMostrarHabilitados.Name = "rbMostrarHabilitados";
            rbMostrarHabilitados.Size = new Size(101, 22);
            rbMostrarHabilitados.TabIndex = 28;
            rbMostrarHabilitados.TabStop = true;
            rbMostrarHabilitados.Text = "Habilitados";
            rbMostrarHabilitados.UseVisualStyleBackColor = true;
            // 
            // lblFecha
            // 
            lblFecha.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Itim", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFecha.ForeColor = Color.FromArgb(148, 168, 187);
            lblFecha.Location = new Point(730, 642);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(22, 25);
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
            lblHora.Location = new Point(730, 616);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(28, 33);
            lblHora.TabIndex = 29;
            lblHora.Text = "1";
            lblHora.Visible = false;
            // 
            // HoraFecha
            // 
            HoraFecha.Enabled = true;
            // 
            // btnIngresarPerdida
            // 
            btnIngresarPerdida.BackColor = Color.FromArgb(204, 116, 131);
            btnIngresarPerdida.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIngresarPerdida.ForeColor = SystemColors.ButtonFace;
            btnIngresarPerdida.Location = new Point(194, 3);
            btnIngresarPerdida.Name = "btnIngresarPerdida";
            btnIngresarPerdida.Size = new Size(140, 44);
            btnIngresarPerdida.TabIndex = 23;
            btnIngresarPerdida.Text = "Perdidas";
            btnIngresarPerdida.UseVisualStyleBackColor = false;
            btnIngresarPerdida.Click += btnIngresarPerdida_Click;
            // 
            // btnAgregarCategoria
            // 
            btnAgregarCategoria.BackColor = Color.FromArgb(149, 195, 172);
            btnAgregarCategoria.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregarCategoria.ForeColor = SystemColors.ButtonFace;
            btnAgregarCategoria.Location = new Point(194, 53);
            btnAgregarCategoria.Name = "btnAgregarCategoria";
            btnAgregarCategoria.Size = new Size(140, 44);
            btnAgregarCategoria.TabIndex = 22;
            btnAgregarCategoria.Text = "Categorias";
            btnAgregarCategoria.UseVisualStyleBackColor = false;
            btnAgregarCategoria.Click += btnAgregarCategoria_Click;
            // 
            // btnEditarProducto
            // 
            btnEditarProducto.BackColor = Color.FromArgb(189, 215, 238);
            btnEditarProducto.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEditarProducto.ForeColor = Color.FromArgb(87, 99, 110);
            btnEditarProducto.Location = new Point(3, 53);
            btnEditarProducto.Name = "btnEditarProducto";
            btnEditarProducto.Size = new Size(185, 44);
            btnEditarProducto.TabIndex = 20;
            btnEditarProducto.Text = "Editar Producto";
            btnEditarProducto.UseVisualStyleBackColor = false;
            btnEditarProducto.Click += btnEditarProducto_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(189, 215, 238);
            panel1.Controls.Add(panelCarrito);
            panel1.Location = new Point(12, 120);
            panel1.Name = "panel1";
            panel1.Size = new Size(746, 437);
            panel1.TabIndex = 32;
            // 
            // lstSugerencias
            // 
            lstSugerencias.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lstSugerencias.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstSugerencias.ForeColor = Color.DimGray;
            lstSugerencias.FormattingEnabled = true;
            lstSugerencias.ItemHeight = 19;
            lstSugerencias.Location = new Point(30, 45);
            lstSugerencias.MaximumSize = new Size(800, 400);
            lstSugerencias.MinimumSize = new Size(165, 23);
            lstSugerencias.Name = "lstSugerencias";
            lstSugerencias.Size = new Size(343, 23);
            lstSugerencias.TabIndex = 2;
            lstSugerencias.Visible = false;
            lstSugerencias.MouseClick += lstSugerencias_MouseClick;
            lstSugerencias.KeyDown += lstSugerencias_KeyDown;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            flowLayoutPanel1.Controls.Add(btnNuevoProducto);
            flowLayoutPanel1.Controls.Add(btnIngresarPerdida);
            flowLayoutPanel1.Controls.Add(btnAgregarMarca);
            flowLayoutPanel1.Controls.Add(btnEditarProducto);
            flowLayoutPanel1.Controls.Add(btnAgregarCategoria);
            flowLayoutPanel1.Controls.Add(btnSalir);
            flowLayoutPanel1.Location = new Point(12, 567);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(490, 100);
            flowLayoutPanel1.TabIndex = 33;
            // 
            // btnLimpiarFiltros
            // 
            btnLimpiarFiltros.BackColor = Color.FromArgb(148, 168, 187);
            btnLimpiarFiltros.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLimpiarFiltros.ForeColor = Color.White;
            btnLimpiarFiltros.ImageAlign = ContentAlignment.TopCenter;
            btnLimpiarFiltros.Location = new Point(3, 5);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(117, 32);
            btnLimpiarFiltros.TabIndex = 34;
            btnLimpiarFiltros.Text = "Limpiar Filtros";
            btnLimpiarFiltros.UseVisualStyleBackColor = false;
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;
            // 
            // pbxClean
            // 
            pbxClean.Image = (Image)resources.GetObject("pbxClean.Image");
            pbxClean.Location = new Point(121, 8);
            pbxClean.Name = "pbxClean";
            pbxClean.Size = new Size(45, 24);
            pbxClean.SizeMode = PictureBoxSizeMode.Zoom;
            pbxClean.TabIndex = 35;
            pbxClean.TabStop = false;
            // 
            // pnlLimpiarFiltros
            // 
            pnlLimpiarFiltros.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlLimpiarFiltros.BackColor = Color.FromArgb(189, 215, 238);
            pnlLimpiarFiltros.Controls.Add(btnLimpiarFiltros);
            pnlLimpiarFiltros.Controls.Add(pbxClean);
            pnlLimpiarFiltros.Location = new Point(446, 12);
            pnlLimpiarFiltros.Name = "pnlLimpiarFiltros";
            pnlLimpiarFiltros.Size = new Size(166, 43);
            pnlLimpiarFiltros.TabIndex = 36;
            pnlLimpiarFiltros.Visible = false;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DimGray;
            label3.Location = new Point(627, 17);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(132, 36);
            label3.TabIndex = 37;
            label3.Text = ":Total de Productos\r\n110\r\n";
            // 
            // frmProductos
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            ClientSize = new Size(770, 679);
            Controls.Add(label3);
            Controls.Add(pnlLimpiarFiltros);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(lstSugerencias);
            Controls.Add(gbxEstado);
            Controls.Add(panelBusqueda);
            Controls.Add(lblFecha);
            Controls.Add(lblHora);
            Controls.Add(panel1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
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
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            panel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbxClean).EndInit();
            pnlLimpiarFiltros.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelCarrito;
        private Panel panel10;
        private DataGridView dgvProductos;
        private Panel panelBusqueda;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private Button btnNuevoProducto;
        private Button btnSalir;
        private Button btnAgregarMarca;
        private GroupBox gbxEstado;
        private RadioButton rbMostrardeshabilitados;
        private RadioButton rbMostrarTodos;
        private RadioButton rbMostrarHabilitados;
        private Label lblFecha;
        private Label lblHora;
        private System.Windows.Forms.Timer HoraFecha;
        private Button btnAgregarCategoria;
        private Button btnEditarProducto;
        private Panel panel1;
        private Button btnIngresarPerdida;
        private ListBox lstSugerencias;
        private TextBox txtFiltroCategoria;
        private TextBox txtFiltroMarca;
        private Button btnMarca;
        private TableLayoutPanel tableLayoutPanel2;
        private Button btnCategoria;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnLimpiarFiltros;
        private PictureBox pbxClean;
        private Panel pnlLimpiarFiltros;
        private Label label2;
        private Label label1;
        private Label label3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn Contenido;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn Categoria;
        private DataGridViewTextBoxColumn Presentacion;
        private DataGridViewTextBoxColumn CantidadProducto;
        private DataGridViewTextBoxColumn PrecioVenta;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn PrecioCompra;
        private DataGridViewTextBoxColumn PorcentajeGanancia;
        private DataGridViewCheckBoxColumn EstadoProducto;
    }
}