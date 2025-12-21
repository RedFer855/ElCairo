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
            cmbBodega = new ComboBox();
            label8 = new Label();
            panelBusqueda = new Panel();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            cmbEstado = new ComboBox();
            label1 = new Label();
            btnSalir = new Button();
            panel2 = new Panel();
            label2 = new Label();
            txtBodegaActual = new TextBox();
            btnCrearBodega = new Button();
            tlp = new TableLayoutPanel();
            pnlLimpiarFiltros = new Panel();
            btnLimpiarFiltros = new Button();
            pbxClean = new PictureBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            lstSugerencias = new ListBox();
            gbxFiltros = new GroupBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducto).BeginInit();
            panelBusqueda.SuspendLayout();
            panel2.SuspendLayout();
            tlp.SuspendLayout();
            pnlLimpiarFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxClean).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            gbxFiltros.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(189, 215, 238);
            panel1.Controls.Add(dgvProducto);
            panel1.Location = new Point(15, 129);
            panel1.Name = "panel1";
            panel1.Size = new Size(844, 486);
            panel1.TabIndex = 33;
            // 
            // dgvProducto
            // 
            dgvProducto.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dgvProducto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvProducto.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProducto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducto.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvProducto.BackgroundColor = Color.FromArgb(189, 215, 238);
            dgvProducto.BorderStyle = BorderStyle.Fixed3D;
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
            dgvProducto.Columns.AddRange(new DataGridViewColumn[] { Codigo, Bodega, Anaquel, StockTotal, StockMinimo, Producto, Marca, ContenidoProducto, Presentacion, Categoria });
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
            dgvProducto.Location = new Point(14, 12);
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
            dgvProducto.Size = new Size(815, 460);
            dgvProducto.TabIndex = 14;
            dgvProducto.CellFormatting += dgvProducto_CellFormatting;
            // 
            // Codigo
            // 
            Codigo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Codigo.DataPropertyName = "CodigoBarraProducto";
            Codigo.HeaderText = "Código";
            Codigo.MinimumWidth = 130;
            Codigo.Name = "Codigo";
            Codigo.ReadOnly = true;
            // 
            // Bodega
            // 
            Bodega.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Bodega.DataPropertyName = "NombreBodega";
            Bodega.HeaderText = "Bodega";
            Bodega.MinimumWidth = 6;
            Bodega.Name = "Bodega";
            Bodega.ReadOnly = true;
            Bodega.Width = 93;
            // 
            // Anaquel
            // 
            Anaquel.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Anaquel.HeaderText = "Anaquel";
            Anaquel.MinimumWidth = 6;
            Anaquel.Name = "Anaquel";
            Anaquel.ReadOnly = true;
            Anaquel.Width = 99;
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
            StockTotal.Width = 80;
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
            StockMinimo.Width = 135;
            // 
            // Producto
            // 
            Producto.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Producto.DataPropertyName = "NombreProducto";
            Producto.HeaderText = "Producto";
            Producto.MinimumWidth = 85;
            Producto.Name = "Producto";
            Producto.ReadOnly = true;
            Producto.Width = 105;
            // 
            // Marca
            // 
            Marca.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Marca.DataPropertyName = "NombreMarca";
            Marca.HeaderText = "Marca";
            Marca.Name = "Marca";
            Marca.ReadOnly = true;
            Marca.Width = 84;
            // 
            // ContenidoProducto
            // 
            ContenidoProducto.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            ContenidoProducto.DataPropertyName = "ContenidoProducto";
            ContenidoProducto.HeaderText = "Contenido";
            ContenidoProducto.Name = "ContenidoProducto";
            ContenidoProducto.ReadOnly = true;
            ContenidoProducto.Width = 113;
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
            // Categoria
            // 
            Categoria.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Categoria.DataPropertyName = "NombreCategoria";
            Categoria.HeaderText = "Categoría";
            Categoria.Name = "Categoria";
            Categoria.ReadOnly = true;
            // 
            // cmbBodega
            // 
            cmbBodega.AutoCompleteMode = AutoCompleteMode.Append;
            cmbBodega.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbBodega.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbBodega.ForeColor = Color.DimGray;
            cmbBodega.FormattingEnabled = true;
            cmbBodega.Location = new Point(155, 21);
            cmbBodega.Name = "cmbBodega";
            cmbBodega.Size = new Size(190, 26);
            cmbBodega.TabIndex = 34;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(87, 99, 110);
            label8.Location = new Point(3, 24);
            label8.Name = "label8";
            label8.Size = new Size(146, 18);
            label8.TabIndex = 35;
            label8.Text = "Seleccione la Bodega:";
            // 
            // panelBusqueda
            // 
            panelBusqueda.BackColor = Color.FromArgb(189, 215, 238);
            panelBusqueda.Controls.Add(txtBuscar);
            panelBusqueda.Controls.Add(btnBuscar);
            panelBusqueda.Dock = DockStyle.Fill;
            panelBusqueda.Location = new Point(3, 3);
            panelBusqueda.Name = "panelBusqueda";
            panelBusqueda.Size = new Size(338, 39);
            panelBusqueda.TabIndex = 36;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.BorderStyle = BorderStyle.None;
            txtBuscar.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(15, 12);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar Productos...";
            txtBuscar.Size = new Size(263, 20);
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
            btnBuscar.Location = new Point(284, 12);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(48, 20);
            btnBuscar.TabIndex = 0;
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // cmbEstado
            // 
            cmbEstado.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbEstado.ForeColor = Color.DimGray;
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(459, 21);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(194, 26);
            cmbEstado.TabIndex = 37;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(87, 99, 110);
            label1.Location = new Point(351, 24);
            label1.Name = "label1";
            label1.Size = new Size(102, 18);
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
            btnSalir.Location = new Point(155, 3);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(146, 40);
            btnSalir.TabIndex = 39;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(189, 215, 238);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtBodegaActual);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(347, 3);
            panel2.MaximumSize = new Size(500, 100);
            panel2.Name = "panel2";
            panel2.Size = new Size(314, 39);
            panel2.TabIndex = 41;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(87, 99, 110);
            label2.Location = new Point(3, 11);
            label2.Name = "label2";
            label2.Size = new Size(106, 18);
            label2.TabIndex = 36;
            label2.Text = "Bodega Actual:";
            // 
            // txtBodegaActual
            // 
            txtBodegaActual.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBodegaActual.BorderStyle = BorderStyle.None;
            txtBodegaActual.Enabled = false;
            txtBodegaActual.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBodegaActual.Location = new Point(111, 10);
            txtBodegaActual.Name = "txtBodegaActual";
            txtBodegaActual.Size = new Size(187, 20);
            txtBodegaActual.TabIndex = 2;
            // 
            // btnCrearBodega
            // 
            btnCrearBodega.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCrearBodega.BackColor = Color.FromArgb(149, 195, 172);
            btnCrearBodega.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCrearBodega.ForeColor = Color.White;
            btnCrearBodega.ImageAlign = ContentAlignment.TopCenter;
            btnCrearBodega.Location = new Point(3, 3);
            btnCrearBodega.Name = "btnCrearBodega";
            btnCrearBodega.Size = new Size(146, 40);
            btnCrearBodega.TabIndex = 42;
            btnCrearBodega.Text = "Crear Bodega";
            btnCrearBodega.UseVisualStyleBackColor = false;
            btnCrearBodega.Click += btnCrearBodega_Click;
            // 
            // tlp
            // 
            tlp.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tlp.ColumnCount = 3;
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 320F));
            tlp.ColumnStyles.Add(new ColumnStyle());
            tlp.Controls.Add(panelBusqueda, 0, 0);
            tlp.Controls.Add(panel2, 1, 0);
            tlp.Controls.Add(pnlLimpiarFiltros, 2, 0);
            tlp.Location = new Point(15, 12);
            tlp.Name = "tlp";
            tlp.RowCount = 1;
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp.Size = new Size(844, 45);
            tlp.TabIndex = 43;
            // 
            // pnlLimpiarFiltros
            // 
            pnlLimpiarFiltros.BackColor = Color.FromArgb(189, 215, 238);
            pnlLimpiarFiltros.Controls.Add(btnLimpiarFiltros);
            pnlLimpiarFiltros.Controls.Add(pbxClean);
            pnlLimpiarFiltros.Dock = DockStyle.Fill;
            pnlLimpiarFiltros.Location = new Point(667, 3);
            pnlLimpiarFiltros.Name = "pnlLimpiarFiltros";
            pnlLimpiarFiltros.Size = new Size(174, 39);
            pnlLimpiarFiltros.TabIndex = 46;
            pnlLimpiarFiltros.Visible = false;
            // 
            // btnLimpiarFiltros
            // 
            btnLimpiarFiltros.BackColor = Color.FromArgb(148, 168, 187);
            btnLimpiarFiltros.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLimpiarFiltros.ForeColor = Color.White;
            btnLimpiarFiltros.ImageAlign = ContentAlignment.TopCenter;
            btnLimpiarFiltros.Location = new Point(3, 5);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(117, 30);
            btnLimpiarFiltros.TabIndex = 34;
            btnLimpiarFiltros.Text = "Limpiar Filtros";
            btnLimpiarFiltros.UseVisualStyleBackColor = false;
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;
            // 
            // pbxClean
            // 
            pbxClean.Image = (Image)resources.GetObject("pbxClean.Image");
            pbxClean.Location = new Point(126, 6);
            pbxClean.Name = "pbxClean";
            pbxClean.Size = new Size(42, 30);
            pbxClean.SizeMode = PictureBoxSizeMode.Zoom;
            pbxClean.TabIndex = 35;
            pbxClean.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            flowLayoutPanel1.Controls.Add(btnCrearBodega);
            flowLayoutPanel1.Controls.Add(btnSalir);
            flowLayoutPanel1.Location = new Point(15, 621);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(309, 46);
            flowLayoutPanel1.TabIndex = 44;
            // 
            // lstSugerencias
            // 
            lstSugerencias.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lstSugerencias.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstSugerencias.ForeColor = Color.DimGray;
            lstSugerencias.FormattingEnabled = true;
            lstSugerencias.ItemHeight = 19;
            lstSugerencias.Location = new Point(33, 48);
            lstSugerencias.MaximumSize = new Size(800, 400);
            lstSugerencias.MinimumSize = new Size(165, 23);
            lstSugerencias.Name = "lstSugerencias";
            lstSugerencias.Size = new Size(264, 23);
            lstSugerencias.TabIndex = 45;
            lstSugerencias.Visible = false;
            // 
            // gbxFiltros
            // 
            gbxFiltros.Controls.Add(label8);
            gbxFiltros.Controls.Add(cmbBodega);
            gbxFiltros.Controls.Add(label1);
            gbxFiltros.Controls.Add(cmbEstado);
            gbxFiltros.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbxFiltros.ForeColor = Color.DimGray;
            gbxFiltros.Location = new Point(15, 63);
            gbxFiltros.Name = "gbxFiltros";
            gbxFiltros.Size = new Size(665, 60);
            gbxFiltros.TabIndex = 47;
            gbxFiltros.TabStop = false;
            gbxFiltros.Text = "Filtros:";
            // 
            // frmInventarioBodega
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            ClientSize = new Size(871, 679);
            Controls.Add(lstSugerencias);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(tlp);
            Controls.Add(panel1);
            Controls.Add(gbxFiltros);
            FormBorderStyle = FormBorderStyle.None;
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
            pnlLimpiarFiltros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbxClean).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            gbxFiltros.ResumeLayout(false);
            gbxFiltros.PerformLayout();
            ResumeLayout(false);
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
        private GroupBox gbxFiltros;
    }
}