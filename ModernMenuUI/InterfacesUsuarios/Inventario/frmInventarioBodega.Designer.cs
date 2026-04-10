namespace ModernMenuUI
{
    partial class frmInventarioBodega
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInventarioBodega));
            panel1 = new Panel();
            dgvProducto = new DataGridView();
            Codigo = new DataGridViewTextBoxColumn();
            Bodega = new DataGridViewTextBoxColumn();
            Anaquel = new DataGridViewTextBoxColumn();
            StockTotal = new DataGridViewTextBoxColumn();
            StockMinimo = new DataGridViewTextBoxColumn();
            Producto = new DataGridViewTextBoxColumn();
            Marca = new DataGridViewTextBoxColumn();
            ContenidoProducto = new DataGridViewTextBoxColumn();
            Presentacion = new DataGridViewTextBoxColumn();
            Categoria = new DataGridViewTextBoxColumn();
            EstadoBodega = new DataGridViewCheckBoxColumn();
            cmbBodega = new ComboBox();
            label8 = new Label();
            panelBusqueda = new Panel();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            cmbEstado = new ComboBox();
            label1 = new Label();
            btnSalir = new Button();
            btnCambiarBodega = new Button();
            panel2 = new Panel();
            label2 = new Label();
            txtBodegaActual = new TextBox();
            btnCrearBodega = new Button();
            tlp = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            lstSugerencias = new ListBox();
            pnlLimpiarFiltros = new Panel();
            btnLimpiarFiltros = new Button();
            pbxClean = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducto).BeginInit();
            panelBusqueda.SuspendLayout();
            panel2.SuspendLayout();
            tlp.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            pnlLimpiarFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxClean).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(189, 215, 238);
            panel1.Controls.Add(dgvProducto);
            panel1.Location = new Point(19, 145);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1168, 592);
            panel1.TabIndex = 33;
            // 
            // dgvProducto
            // 
            dgvProducto.AllowUserToAddRows = false;
            dgvProducto.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dgvProducto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvProducto.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProducto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducto.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvProducto.BackgroundColor = Color.FromArgb(189, 215, 238);
            dgvProducto.BorderStyle = BorderStyle.None;
            dgvProducto.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProducto.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle2.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvProducto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvProducto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducto.Columns.AddRange(new DataGridViewColumn[] { Codigo, Bodega, Anaquel, StockTotal, StockMinimo, Producto, Marca, ContenidoProducto, Presentacion, Categoria, EstadoBodega });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle5.NullValue = "(Vacío)";
            dataGridViewCellStyle5.Padding = new Padding(5);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle5.SelectionForeColor = Color.White;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgvProducto.DefaultCellStyle = dataGridViewCellStyle5;
            dgvProducto.EnableHeadersVisualStyles = false;
            dgvProducto.GridColor = Color.FromArgb(189, 215, 238);
            dgvProducto.Location = new Point(22, 21);
            dgvProducto.Margin = new Padding(4);
            dgvProducto.Name = "dgvProducto";
            dgvProducto.ReadOnly = true;
            dgvProducto.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle6.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(102, 102, 102);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvProducto.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvProducto.RowHeadersWidth = 30;
            dgvProducto.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvProducto.RowTemplate.Height = 50;
            dgvProducto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducto.Size = new Size(1125, 549);
            dgvProducto.TabIndex = 14;
            dgvProducto.CellFormatting += dgvProducto_CellFormatting;
            // 
            // Codigo
            // 
            Codigo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Codigo.DataPropertyName = "IdBodega";
            Codigo.HeaderText = "Código";
            Codigo.MinimumWidth = 130;
            Codigo.Name = "Codigo";
            Codigo.ReadOnly = true;
            Codigo.Visible = false;
            // 
            // Bodega
            // 
            Bodega.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Bodega.DataPropertyName = "NombreBodega";
            Bodega.HeaderText = "Bodega";
            Bodega.MinimumWidth = 6;
            Bodega.Name = "Bodega";
            Bodega.ReadOnly = true;
            Bodega.Width = 111;
            // 
            // Anaquel
            // 
            Anaquel.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Anaquel.DataPropertyName = "Anaquel";
            Anaquel.HeaderText = "Anaquel";
            Anaquel.MinimumWidth = 6;
            Anaquel.Name = "Anaquel";
            Anaquel.ReadOnly = true;
            Anaquel.Width = 118;
            // 
            // StockTotal
            // 
            StockTotal.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            StockTotal.DataPropertyName = "StockProductoBodegaInventario";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            StockTotal.DefaultCellStyle = dataGridViewCellStyle3;
            StockTotal.HeaderText = "Stock";
            StockTotal.MinimumWidth = 6;
            StockTotal.Name = "StockTotal";
            StockTotal.ReadOnly = true;
            StockTotal.Width = 95;
            // 
            // StockMinimo
            // 
            StockMinimo.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            StockMinimo.DataPropertyName = "StockMinimoProductoBodegaInventario";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.NullValue = "(Sin Stock Mínimo)";
            StockMinimo.DefaultCellStyle = dataGridViewCellStyle4;
            StockMinimo.HeaderText = "Stock Mínimo";
            StockMinimo.MinimumWidth = 135;
            StockMinimo.Name = "StockMinimo";
            StockMinimo.ReadOnly = true;
            StockMinimo.Width = 150;
            // 
            // Producto
            // 
            Producto.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Producto.DataPropertyName = "NombreProducto";
            Producto.HeaderText = "Producto";
            Producto.MinimumWidth = 85;
            Producto.Name = "Producto";
            Producto.ReadOnly = true;
            Producto.Width = 125;
            // 
            // Marca
            // 
            Marca.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Marca.DataPropertyName = "NombreMarca";
            Marca.HeaderText = "Marca";
            Marca.MinimumWidth = 6;
            Marca.Name = "Marca";
            Marca.ReadOnly = true;
            // 
            // ContenidoProducto
            // 
            ContenidoProducto.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            ContenidoProducto.DataPropertyName = "ContenidoProducto";
            ContenidoProducto.HeaderText = "Contenido";
            ContenidoProducto.MinimumWidth = 6;
            ContenidoProducto.Name = "ContenidoProducto";
            ContenidoProducto.ReadOnly = true;
            ContenidoProducto.Width = 135;
            // 
            // Presentacion
            // 
            Presentacion.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Presentacion.DataPropertyName = "NombrePresentacion";
            Presentacion.HeaderText = "Presentación";
            Presentacion.MinimumWidth = 6;
            Presentacion.Name = "Presentacion";
            Presentacion.ReadOnly = true;
            Presentacion.Width = 159;
            // 
            // Categoria
            // 
            Categoria.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Categoria.DataPropertyName = "NombreCategoria";
            Categoria.HeaderText = "Categoría";
            Categoria.MinimumWidth = 6;
            Categoria.Name = "Categoria";
            Categoria.ReadOnly = true;
            // 
            // EstadoBodega
            // 
            EstadoBodega.DataPropertyName = "EstadoBodega";
            EstadoBodega.HeaderText = "Estado";
            EstadoBodega.MinimumWidth = 6;
            EstadoBodega.Name = "EstadoBodega";
            EstadoBodega.ReadOnly = true;
            EstadoBodega.Visible = false;
            // 
            // cmbBodega
            // 
            cmbBodega.AutoCompleteMode = AutoCompleteMode.Append;
            cmbBodega.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbBodega.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbBodega.ForeColor = Color.DimGray;
            cmbBodega.FormattingEnabled = true;
            cmbBodega.Location = new Point(209, 94);
            cmbBodega.Margin = new Padding(4);
            cmbBodega.Name = "cmbBodega";
            cmbBodega.Size = new Size(236, 31);
            cmbBodega.TabIndex = 34;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(87, 99, 110);
            label8.Location = new Point(19, 98);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(186, 23);
            label8.TabIndex = 35;
            label8.Text = "Seleccione la Bodega:";
            // 
            // panelBusqueda
            // 
            panelBusqueda.BackColor = Color.FromArgb(189, 215, 238);
            panelBusqueda.Controls.Add(txtBuscar);
            panelBusqueda.Controls.Add(btnBuscar);
            panelBusqueda.Dock = DockStyle.Fill;
            panelBusqueda.Location = new Point(4, 4);
            panelBusqueda.Margin = new Padding(4);
            panelBusqueda.Name = "panelBusqueda";
            panelBusqueda.Size = new Size(618, 48);
            panelBusqueda.TabIndex = 36;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.BorderStyle = BorderStyle.None;
            txtBuscar.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(19, 15);
            txtBuscar.Margin = new Padding(4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar Productos...";
            txtBuscar.Size = new Size(498, 24);
            txtBuscar.TabIndex = 1;
            // 
            // btnBuscar
            // 
            btnBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuscar.BackColor = Color.FromArgb(168, 191, 212);
            btnBuscar.BackgroundImage = (Image)resources.GetObject("btnBuscar.BackgroundImage");
            btnBuscar.BackgroundImageLayout = ImageLayout.Zoom;
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Location = new Point(534, 15);
            btnBuscar.Margin = new Padding(4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(60, 25);
            btnBuscar.TabIndex = 0;
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Visible = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // cmbEstado
            // 
            cmbEstado.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbEstado.ForeColor = Color.DimGray;
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(602, 94);
            cmbEstado.Margin = new Padding(4);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(242, 31);
            cmbEstado.TabIndex = 37;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(87, 99, 110);
            label1.Location = new Point(468, 100);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(130, 23);
            label1.TabIndex = 38;
            label1.Text = "Nivel de Stock:";
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSalir.BackColor = Color.FromArgb(148, 168, 187);
            btnSalir.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.White;
            btnSalir.ImageAlign = ContentAlignment.TopCenter;
            btnSalir.Location = new Point(194, 4);
            btnSalir.Margin = new Padding(4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(182, 64);
            btnSalir.TabIndex = 39;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnCambiarBodega
            // 
            btnCambiarBodega.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCambiarBodega.BackColor = Color.FromArgb(149, 195, 172);
            btnCambiarBodega.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCambiarBodega.ForeColor = Color.White;
            btnCambiarBodega.ImageAlign = ContentAlignment.TopCenter;
            btnCambiarBodega.Location = new Point(404, 6);
            btnCambiarBodega.Margin = new Padding(4);
            btnCambiarBodega.Name = "btnCambiarBodega";
            btnCambiarBodega.Size = new Size(112, 38);
            btnCambiarBodega.TabIndex = 40;
            btnCambiarBodega.Text = "Cambiar";
            btnCambiarBodega.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(189, 215, 238);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(btnCambiarBodega);
            panel2.Controls.Add(txtBodegaActual);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(630, 4);
            panel2.Margin = new Padding(4);
            panel2.MaximumSize = new Size(625, 125);
            panel2.Name = "panel2";
            panel2.Size = new Size(534, 48);
            panel2.TabIndex = 41;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(87, 99, 110);
            label2.Location = new Point(11, 15);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(133, 23);
            label2.TabIndex = 36;
            label2.Text = "Bodega Actual:";
            // 
            // txtBodegaActual
            // 
            txtBodegaActual.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBodegaActual.BorderStyle = BorderStyle.None;
            txtBodegaActual.Enabled = false;
            txtBodegaActual.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBodegaActual.Location = new Point(151, 12);
            txtBodegaActual.Margin = new Padding(4);
            txtBodegaActual.Name = "txtBodegaActual";
            txtBodegaActual.Size = new Size(245, 24);
            txtBodegaActual.TabIndex = 2;
            // 
            // btnCrearBodega
            // 
            btnCrearBodega.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCrearBodega.BackColor = Color.FromArgb(149, 195, 172);
            btnCrearBodega.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCrearBodega.ForeColor = Color.White;
            btnCrearBodega.ImageAlign = ContentAlignment.TopCenter;
            btnCrearBodega.Location = new Point(4, 4);
            btnCrearBodega.Margin = new Padding(4);
            btnCrearBodega.Name = "btnCrearBodega";
            btnCrearBodega.Size = new Size(182, 64);
            btnCrearBodega.TabIndex = 42;
            btnCrearBodega.Text = "Crear Bodega";
            btnCrearBodega.UseVisualStyleBackColor = false;
            btnCrearBodega.Visible = false;
            btnCrearBodega.Click += btnCrearBodega_Click;
            // 
            // tlp
            // 
            tlp.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tlp.ColumnCount = 2;
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 53.64026F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 46.35974F));
            tlp.Controls.Add(panelBusqueda, 0, 0);
            tlp.Controls.Add(panel2, 1, 0);
            tlp.Location = new Point(19, 15);
            tlp.Margin = new Padding(4);
            tlp.Name = "tlp";
            tlp.RowCount = 1;
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlp.Size = new Size(1168, 56);
            tlp.TabIndex = 43;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            flowLayoutPanel1.Controls.Add(btnCrearBodega);
            flowLayoutPanel1.Controls.Add(btnSalir);
            flowLayoutPanel1.Location = new Point(15, 750);
            flowLayoutPanel1.Margin = new Padding(4);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(386, 74);
            flowLayoutPanel1.TabIndex = 44;
            // 
            // lstSugerencias
            // 
            lstSugerencias.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lstSugerencias.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstSugerencias.ForeColor = Color.DimGray;
            lstSugerencias.FormattingEnabled = true;
            lstSugerencias.ItemHeight = 24;
            lstSugerencias.Location = new Point(41, 60);
            lstSugerencias.Margin = new Padding(4);
            lstSugerencias.MaximumSize = new Size(999, 499);
            lstSugerencias.MinimumSize = new Size(205, 28);
            lstSugerencias.Name = "lstSugerencias";
            lstSugerencias.Size = new Size(498, 28);
            lstSugerencias.TabIndex = 45;
            lstSugerencias.Visible = false;
            // 
            // pnlLimpiarFiltros
            // 
            pnlLimpiarFiltros.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlLimpiarFiltros.BackColor = Color.FromArgb(189, 215, 238);
            pnlLimpiarFiltros.Controls.Add(btnLimpiarFiltros);
            pnlLimpiarFiltros.Controls.Add(pbxClean);
            pnlLimpiarFiltros.Location = new Point(979, 79);
            pnlLimpiarFiltros.Margin = new Padding(4);
            pnlLimpiarFiltros.Name = "pnlLimpiarFiltros";
            pnlLimpiarFiltros.Size = new Size(208, 54);
            pnlLimpiarFiltros.TabIndex = 46;
            pnlLimpiarFiltros.Visible = false;
            // 
            // btnLimpiarFiltros
            // 
            btnLimpiarFiltros.BackColor = Color.FromArgb(148, 168, 187);
            btnLimpiarFiltros.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLimpiarFiltros.ForeColor = Color.White;
            btnLimpiarFiltros.ImageAlign = ContentAlignment.TopCenter;
            btnLimpiarFiltros.Location = new Point(4, 6);
            btnLimpiarFiltros.Margin = new Padding(4);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(146, 40);
            btnLimpiarFiltros.TabIndex = 34;
            btnLimpiarFiltros.Text = "Limpiar Filtros";
            btnLimpiarFiltros.UseVisualStyleBackColor = false;
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;
            // 
            // pbxClean
            // 
            pbxClean.Image = (Image)resources.GetObject("pbxClean.Image");
            pbxClean.Location = new Point(151, 10);
            pbxClean.Margin = new Padding(4);
            pbxClean.Name = "pbxClean";
            pbxClean.Size = new Size(56, 30);
            pbxClean.SizeMode = PictureBoxSizeMode.Zoom;
            pbxClean.TabIndex = 35;
            pbxClean.TabStop = false;
            // 
            // frmInventarioBodega
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            ClientSize = new Size(1201, 849);
            Controls.Add(pnlLimpiarFiltros);
            Controls.Add(lstSugerencias);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(tlp);
            Controls.Add(label1);
            Controls.Add(cmbEstado);
            Controls.Add(label8);
            Controls.Add(cmbBodega);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "frmInventarioBodega";
            Text = "frmInventarioBodega";
            Load += frmInventarioBodega_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProducto).EndInit();
            panelBusqueda.ResumeLayout(false);
            panelBusqueda.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tlp.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            pnlLimpiarFiltros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbxClean).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private ComboBox cmbBodega;
        private Label label8;
        private Panel panelBusqueda;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private ComboBox cmbEstado;
        private Label label1;
        private Button btnSalir;
        private Button btnCambiarBodega;
        private Panel panel2;
        private Label label2;
        private TextBox txtBodegaActual;
        private Button btnCrearBodega;
        private DataGridView dgvProducto;
        private TableLayoutPanel tlp;
        private DataGridViewTextBoxColumn IdStock;
        private FlowLayoutPanel flowLayoutPanel1;
        private ListBox lstSugerencias;
        private Panel pnlLimpiarFiltros;
        private Button btnLimpiarFiltros;
        private PictureBox pbxClean;
        private DataGridViewTextBoxColumn Codigo;
        private DataGridViewTextBoxColumn Bodega;
        private DataGridViewTextBoxColumn Anaquel;
        private DataGridViewTextBoxColumn StockTotal;
        private DataGridViewTextBoxColumn StockMinimo;
        private DataGridViewTextBoxColumn Producto;
        private DataGridViewTextBoxColumn Marca;
        private DataGridViewTextBoxColumn ContenidoProducto;
        private DataGridViewTextBoxColumn Presentacion;
        private DataGridViewTextBoxColumn Categoria;
        private DataGridViewCheckBoxColumn EstadoBodega;
    }
}