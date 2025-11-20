namespace ModernMenuUI.InterfacesUsuarios.Reporteria
{
    partial class frmAbrirReporte
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
            dgvStockCritico = new DataGridView();
            btnExportarPDF = new Button();
            btnExportarExcel = new Button();
            panel1 = new Panel();
            lblNombreReporte = new Label();
            label1 = new Label();
            cmbBodegas = new ComboBox();
            btnGenerarReporte = new Button();
            CodigoBarra = new DataGridViewTextBoxColumn();
            Producto = new DataGridViewTextBoxColumn();
            CantidadActual = new DataGridViewTextBoxColumn();
            StockMinimo = new DataGridViewTextBoxColumn();
            Diferencia = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvStockCritico).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvStockCritico
            // 
            dgvStockCritico.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dgvStockCritico.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvStockCritico.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvStockCritico.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvStockCritico.BackgroundColor = Color.FromArgb(189, 215, 238);
            dgvStockCritico.BorderStyle = BorderStyle.None;
            dgvStockCritico.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvStockCritico.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle2.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle2.SelectionBackColor = Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvStockCritico.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvStockCritico.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStockCritico.Columns.AddRange(new DataGridViewColumn[] { CodigoBarra, Producto, CantidadActual, StockMinimo, Diferencia });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle3.Padding = new Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvStockCritico.DefaultCellStyle = dataGridViewCellStyle3;
            dgvStockCritico.EnableHeadersVisualStyles = false;
            dgvStockCritico.GridColor = Color.FromArgb(189, 215, 238);
            dgvStockCritico.Location = new Point(12, 125);
            dgvStockCritico.Name = "dgvStockCritico";
            dgvStockCritico.ReadOnly = true;
            dgvStockCritico.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle4.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(102, 102, 102);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvStockCritico.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvStockCritico.RowHeadersWidth = 30;
            dgvStockCritico.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvStockCritico.RowTemplate.Height = 50;
            dgvStockCritico.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStockCritico.Size = new Size(778, 363);
            dgvStockCritico.TabIndex = 2;
            // 
            // btnExportarPDF
            // 
            btnExportarPDF.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnExportarPDF.BackColor = Color.FromArgb(228, 158, 144);
            btnExportarPDF.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExportarPDF.ForeColor = Color.White;
            btnExportarPDF.ImageAlign = ContentAlignment.TopCenter;
            btnExportarPDF.Location = new Point(12, 494);
            btnExportarPDF.Name = "btnExportarPDF";
            btnExportarPDF.Size = new Size(146, 51);
            btnExportarPDF.TabIndex = 44;
            btnExportarPDF.Text = "Exportar a PDF";
            btnExportarPDF.UseVisualStyleBackColor = false;
            btnExportarPDF.Click += btnExportarPDF_Click;
            // 
            // btnExportarExcel
            // 
            btnExportarExcel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnExportarExcel.BackColor = Color.FromArgb(149, 195, 172);
            btnExportarExcel.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExportarExcel.ForeColor = Color.White;
            btnExportarExcel.ImageAlign = ContentAlignment.TopCenter;
            btnExportarExcel.Location = new Point(167, 494);
            btnExportarExcel.Name = "btnExportarExcel";
            btnExportarExcel.Size = new Size(146, 51);
            btnExportarExcel.TabIndex = 45;
            btnExportarExcel.Text = "Exportar a Excel";
            btnExportarExcel.UseVisualStyleBackColor = false;
            btnExportarExcel.Click += btnExportarExcel_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(148, 168, 187);
            panel1.Controls.Add(lblNombreReporte);
            panel1.Location = new Point(12, 21);
            panel1.Name = "panel1";
            panel1.Size = new Size(778, 49);
            panel1.TabIndex = 47;
            // 
            // lblNombreReporte
            // 
            lblNombreReporte.AutoSize = true;
            lblNombreReporte.Font = new Font("Itim", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombreReporte.ForeColor = Color.White;
            lblNombreReporte.Location = new Point(3, 9);
            lblNombreReporte.Name = "lblNombreReporte";
            lblNombreReporte.Size = new Size(344, 29);
            lblNombreReporte.TabIndex = 45;
            lblNombreReporte.Text = "REPORTE DE INVENTARIO BAJO";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(87, 99, 110);
            label1.Location = new Point(12, 86);
            label1.Name = "label1";
            label1.Size = new Size(118, 19);
            label1.TabIndex = 46;
            label1.Text = "Bodega Actual: ";
            // 
            // cmbBodegas
            // 
            cmbBodegas.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbBodegas.ForeColor = Color.DimGray;
            cmbBodegas.FormattingEnabled = true;
            cmbBodegas.Location = new Point(136, 83);
            cmbBodegas.Name = "cmbBodegas";
            cmbBodegas.Size = new Size(223, 27);
            cmbBodegas.TabIndex = 48;
            // 
            // btnGenerarReporte
            // 
            btnGenerarReporte.BackColor = Color.FromArgb(149, 195, 172);
            btnGenerarReporte.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGenerarReporte.ForeColor = Color.White;
            btnGenerarReporte.ImageAlign = ContentAlignment.TopCenter;
            btnGenerarReporte.Location = new Point(365, 76);
            btnGenerarReporte.Name = "btnGenerarReporte";
            btnGenerarReporte.Size = new Size(146, 39);
            btnGenerarReporte.TabIndex = 49;
            btnGenerarReporte.Text = "Generar Reporte";
            btnGenerarReporte.UseVisualStyleBackColor = false;
            btnGenerarReporte.Click += btnGenerarReporte_Click_1;
            // 
            // CodigoBarra
            // 
            CodigoBarra.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            CodigoBarra.DataPropertyName = "CodigoBarraProducto";
            CodigoBarra.HeaderText = "CodigoBarra";
            CodigoBarra.Name = "CodigoBarra";
            CodigoBarra.ReadOnly = true;
            // 
            // Producto
            // 
            Producto.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Producto.DataPropertyName = "NombreProducto";
            Producto.HeaderText = "Producto";
            Producto.Name = "Producto";
            Producto.ReadOnly = true;
            // 
            // CantidadActual
            // 
            CantidadActual.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            CantidadActual.DataPropertyName = "CantidadActual";
            CantidadActual.HeaderText = "Cantidad Actual";
            CantidadActual.Name = "CantidadActual";
            CantidadActual.ReadOnly = true;
            // 
            // StockMinimo
            // 
            StockMinimo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            StockMinimo.DataPropertyName = "StockMinimo";
            StockMinimo.HeaderText = "Cantidad Mínima";
            StockMinimo.Name = "StockMinimo";
            StockMinimo.ReadOnly = true;
            // 
            // Diferencia
            // 
            Diferencia.DataPropertyName = "Diferencia";
            Diferencia.HeaderText = "Diferencia";
            Diferencia.Name = "Diferencia";
            Diferencia.ReadOnly = true;
            // 
            // frmAbrirReporte
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(802, 557);
            Controls.Add(btnGenerarReporte);
            Controls.Add(cmbBodegas);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(btnExportarExcel);
            Controls.Add(btnExportarPDF);
            Controls.Add(dgvStockCritico);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAbrirReporte";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmAbrirReporte";
            Load += frmAbrirReporte_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStockCritico).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvStockCritico;
        private Button btnExportarPDF;
        private Button btnExportarExcel;
        private Panel panel1;
        public Label lblNombreReporte;
        public Label label1;
        private ComboBox cmbBodegas;
        private Button btnGenerarReporte;
        private DataGridViewTextBoxColumn CodigoBarra;
        private DataGridViewTextBoxColumn Producto;
        private DataGridViewTextBoxColumn CantidadActual;
        private DataGridViewTextBoxColumn StockMinimo;
        private DataGridViewTextBoxColumn Diferencia;
    }
}