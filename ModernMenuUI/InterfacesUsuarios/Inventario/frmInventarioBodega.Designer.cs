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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInventarioBodega));
            panel1 = new Panel();
            dgvProducto = new DataGridView();
            cmbBodega = new ComboBox();
            label8 = new Label();
            panelBusqueda = new Panel();
            txtBuscar = new TextBox();
            btnbuscar = new Button();
            cmbEstado = new ComboBox();
            label1 = new Label();
            btnSalir = new Button();
            btnCambioBodega = new Button();
            panel2 = new Panel();
            label2 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            tlp = new TableLayoutPanel();
            Producto = new DataGridViewTextBoxColumn();
            Bodega = new DataGridViewTextBoxColumn();
            CategoriaStock = new DataGridViewTextBoxColumn();
            MarcaStock = new DataGridViewTextBoxColumn();
            StockTotal = new DataGridViewTextBoxColumn();
            StockMinimo = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducto).BeginInit();
            panelBusqueda.SuspendLayout();
            panel2.SuspendLayout();
            tlp.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(189, 215, 238);
            panel1.Controls.Add(dgvProducto);
            panel1.Location = new Point(15, 116);
            panel1.Name = "panel1";
            panel1.Size = new Size(739, 474);
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
            dgvProducto.Columns.AddRange(new DataGridViewColumn[] { Producto, Bodega, CategoriaStock, MarcaStock, StockTotal, StockMinimo });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle3.NullValue = "(Vacío)";
            dataGridViewCellStyle3.Padding = new Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvProducto.DefaultCellStyle = dataGridViewCellStyle3;
            dgvProducto.EnableHeadersVisualStyles = false;
            dgvProducto.GridColor = Color.FromArgb(189, 215, 238);
            dgvProducto.Location = new Point(18, 17);
            dgvProducto.Name = "dgvProducto";
            dgvProducto.ReadOnly = true;
            dgvProducto.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle4.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(102, 102, 102);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvProducto.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvProducto.RowHeadersWidth = 30;
            dgvProducto.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvProducto.RowTemplate.Height = 50;
            dgvProducto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducto.Size = new Size(705, 439);
            dgvProducto.TabIndex = 14;
            // 
            // cmbBodega
            // 
            cmbBodega.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbBodega.ForeColor = Color.DimGray;
            cmbBodega.FormattingEnabled = true;
            cmbBodega.Location = new Point(167, 75);
            cmbBodega.Name = "cmbBodega";
            cmbBodega.Size = new Size(190, 26);
            cmbBodega.TabIndex = 34;
            cmbBodega.SelectedIndexChanged += cmbBodega_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(87, 99, 110);
            label8.Location = new Point(15, 75);
            label8.Name = "label8";
            label8.Size = new Size(146, 18);
            label8.TabIndex = 35;
            label8.Text = "Seleccione la Bodega:";
            // 
            // panelBusqueda
            // 
            panelBusqueda.BackColor = Color.FromArgb(189, 215, 238);
            panelBusqueda.Controls.Add(txtBuscar);
            panelBusqueda.Controls.Add(btnbuscar);
            panelBusqueda.Dock = DockStyle.Fill;
            panelBusqueda.Location = new Point(3, 3);
            panelBusqueda.Name = "panelBusqueda";
            panelBusqueda.Size = new Size(444, 39);
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
            txtBuscar.Size = new Size(347, 20);
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
            btnbuscar.Location = new Point(377, 12);
            btnbuscar.Name = "btnbuscar";
            btnbuscar.Size = new Size(48, 20);
            btnbuscar.TabIndex = 0;
            btnbuscar.UseVisualStyleBackColor = false;
            // 
            // cmbEstado
            // 
            cmbEstado.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbEstado.ForeColor = Color.DimGray;
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(560, 76);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(194, 26);
            cmbEstado.TabIndex = 37;
            cmbEstado.SelectedIndexChanged += cmbEstado_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(87, 99, 110);
            label1.Location = new Point(452, 77);
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
            btnSalir.Location = new Point(316, 613);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(146, 54);
            btnSalir.TabIndex = 39;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnCambioBodega
            // 
            btnCambioBodega.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCambioBodega.BackColor = Color.FromArgb(149, 195, 172);
            btnCambioBodega.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCambioBodega.ForeColor = Color.White;
            btnCambioBodega.ImageAlign = ContentAlignment.TopCenter;
            btnCambioBodega.Location = new Point(164, 613);
            btnCambioBodega.Name = "btnCambioBodega";
            btnCambioBodega.Size = new Size(146, 54);
            btnCambioBodega.TabIndex = 40;
            btnCambioBodega.Text = "Cambiar Bodega del Sistema";
            btnCambioBodega.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(189, 215, 238);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(textBox1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(453, 3);
            panel2.MaximumSize = new Size(400, 100);
            panel2.Name = "panel2";
            panel2.Size = new Size(283, 39);
            panel2.TabIndex = 41;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(87, 99, 110);
            label2.Location = new Point(9, 14);
            label2.Name = "label2";
            label2.Size = new Size(106, 18);
            label2.TabIndex = 36;
            label2.Text = "Bodega Actual:";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(121, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(149, 20);
            textBox1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.BackColor = Color.FromArgb(149, 195, 172);
            button1.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.ImageAlign = ContentAlignment.TopCenter;
            button1.Location = new Point(12, 613);
            button1.Name = "button1";
            button1.Size = new Size(146, 54);
            button1.TabIndex = 42;
            button1.Text = "Crear Bodega";
            button1.UseVisualStyleBackColor = false;
            // 
            // tlp
            // 
            tlp.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tlp.ColumnCount = 2;
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60.8930969F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 39.1069031F));
            tlp.Controls.Add(panelBusqueda, 0, 0);
            tlp.Controls.Add(panel2, 1, 0);
            tlp.Location = new Point(15, 12);
            tlp.Name = "tlp";
            tlp.RowCount = 1;
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlp.Size = new Size(739, 45);
            tlp.TabIndex = 43;
            // 
            // Producto
            // 
            Producto.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Producto.DataPropertyName = "NombreProducto";
            Producto.FillWeight = 35.1780434F;
            Producto.HeaderText = "Producto";
            Producto.Name = "Producto";
            Producto.ReadOnly = true;
            Producto.Width = 105;
            // 
            // Bodega
            // 
            Bodega.DataPropertyName = "NombreBodega";
            Bodega.HeaderText = "Bodega";
            Bodega.Name = "Bodega";
            Bodega.ReadOnly = true;
            // 
            // CategoriaStock
            // 
            CategoriaStock.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            CategoriaStock.DataPropertyName = "Categoria";
            CategoriaStock.FillWeight = 40.203476F;
            CategoriaStock.HeaderText = "Categoria";
            CategoriaStock.Name = "CategoriaStock";
            CategoriaStock.ReadOnly = true;
            CategoriaStock.Width = 108;
            // 
            // MarcaStock
            // 
            MarcaStock.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            MarcaStock.DataPropertyName = "Telefono";
            MarcaStock.FillWeight = 40.203476F;
            MarcaStock.HeaderText = "Marca";
            MarcaStock.Name = "MarcaStock";
            MarcaStock.ReadOnly = true;
            MarcaStock.Width = 84;
            // 
            // StockTotal
            // 
            StockTotal.DataPropertyName = "StockProductoBodegaInventario";
            StockTotal.FillWeight = 40.203476F;
            StockTotal.HeaderText = "Stock";
            StockTotal.Name = "StockTotal";
            StockTotal.ReadOnly = true;
            // 
            // StockMinimo
            // 
            StockMinimo.DataPropertyName = "StockMinimoProductoBodegaInventario";
            StockMinimo.FillWeight = 70F;
            StockMinimo.HeaderText = "Stock Mínimo";
            StockMinimo.MinimumWidth = 20;
            StockMinimo.Name = "StockMinimo";
            StockMinimo.ReadOnly = true;
            // 
            // frmInventarioBodega
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(766, 679);
            Controls.Add(tlp);
            Controls.Add(button1);
            Controls.Add(btnCambioBodega);
            Controls.Add(btnSalir);
            Controls.Add(label1);
            Controls.Add(cmbEstado);
            Controls.Add(label8);
            Controls.Add(cmbBodega);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmInventarioBodega";
            Text = "frmInventarioBodega";
            FormClosing += frmInventarioBodega_FormClosing;
            Load += frmInventarioBodega_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProducto).EndInit();
            panelBusqueda.ResumeLayout(false);
            panelBusqueda.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tlp.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private ComboBox cmbBodega;
        private Label label8;
        private Panel panelBusqueda;
        private TextBox txtBuscar;
        private Button btnbuscar;
        private ComboBox cmbEstado;
        private Label label1;
        private Button btnSalir;
        private Button btnCambioBodega;
        private Panel panel2;
        private Label label2;
        private TextBox textBox1;
        private Button button1;
        private DataGridView dgvProducto;
        private TableLayoutPanel tlp;
        private DataGridViewTextBoxColumn IdStock;
        private DataGridViewTextBoxColumn Producto;
        private DataGridViewTextBoxColumn Bodega;
        private DataGridViewTextBoxColumn CategoriaStock;
        private DataGridViewTextBoxColumn MarcaStock;
        private DataGridViewTextBoxColumn StockTotal;
        private DataGridViewTextBoxColumn StockMinimo;
    }
}