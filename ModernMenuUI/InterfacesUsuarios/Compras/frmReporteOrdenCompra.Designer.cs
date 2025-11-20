namespace ModernMenuUI.InterfacesUsuarios.Compras
{
    partial class frmReporteOrdenCompra
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
            panelCarrito = new Panel();
            panel10 = new Panel();
            dgvCarrito = new DataGridView();
            btnPdf = new Button();
            btnExcel = new Button();
            lblNombreModulo = new Label();
            panel1 = new Panel();
            panelCarrito.SuspendLayout();
            panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelCarrito
            // 
            panelCarrito.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelCarrito.BackColor = Color.FromArgb(189, 215, 238);
            panelCarrito.Controls.Add(panel10);
            panelCarrito.Location = new Point(12, 65);
            panelCarrito.Name = "panelCarrito";
            panelCarrito.Size = new Size(764, 368);
            panelCarrito.TabIndex = 22;
            // 
            // panel10
            // 
            panel10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel10.Controls.Add(dgvCarrito);
            panel10.Location = new Point(14, 16);
            panel10.Name = "panel10";
            panel10.Size = new Size(735, 334);
            panel10.TabIndex = 17;
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
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvCarrito.DefaultCellStyle = dataGridViewCellStyle2;
            dgvCarrito.Dock = DockStyle.Fill;
            dgvCarrito.EnableHeadersVisualStyles = false;
            dgvCarrito.GridColor = Color.FromArgb(189, 215, 238);
            dgvCarrito.Location = new Point(0, 0);
            dgvCarrito.Name = "dgvCarrito";
            dgvCarrito.ReadOnly = true;
            dgvCarrito.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(102, 102, 102);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvCarrito.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvCarrito.RowHeadersWidth = 51;
            dgvCarrito.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dgvCarrito.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvCarrito.RowTemplate.Height = 50;
            dgvCarrito.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCarrito.Size = new Size(735, 334);
            dgvCarrito.TabIndex = 1;
            // 
            // btnPdf
            // 
            btnPdf.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnPdf.BackColor = Color.FromArgb(228, 158, 144);
            btnPdf.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPdf.ForeColor = Color.White;
            btnPdf.ImageAlign = ContentAlignment.TopCenter;
            btnPdf.Location = new Point(12, 439);
            btnPdf.Name = "btnPdf";
            btnPdf.Size = new Size(146, 51);
            btnPdf.TabIndex = 43;
            btnPdf.Text = "Exportar a PDF";
            btnPdf.UseVisualStyleBackColor = false;
            btnPdf.Click += btnPDF_Click;
            // 
            // btnExcel
            // 
            btnExcel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnExcel.BackColor = Color.FromArgb(149, 195, 172);
            btnExcel.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExcel.ForeColor = Color.White;
            btnExcel.ImageAlign = ContentAlignment.TopCenter;
            btnExcel.Location = new Point(164, 439);
            btnExcel.Name = "btnExcel";
            btnExcel.Size = new Size(146, 51);
            btnExcel.TabIndex = 44;
            btnExcel.Text = "Exportar a Excel";
            btnExcel.UseVisualStyleBackColor = false;
            btnExcel.Click += btnExcel_Click;
            // 
            // lblNombreModulo
            // 
            lblNombreModulo.AutoSize = true;
            lblNombreModulo.Font = new Font("Itim", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombreModulo.ForeColor = Color.White;
            lblNombreModulo.Location = new Point(3, 9);
            lblNombreModulo.Name = "lblNombreModulo";
            lblNombreModulo.Size = new Size(360, 29);
            lblNombreModulo.TabIndex = 45;
            lblNombreModulo.Text = "REPORTE DE ORDEN DE COMPRA";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(148, 168, 187);
            panel1.Controls.Add(lblNombreModulo);
            panel1.Location = new Point(12, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(764, 49);
            panel1.TabIndex = 46;
            // 
            // frmReporteOrdenCompra
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(788, 502);
            Controls.Add(panel1);
            Controls.Add(btnExcel);
            Controls.Add(btnPdf);
            Controls.Add(panelCarrito);
            Name = "frmReporteOrdenCompra";
            Text = "Reporte de Compra";
            Load += frmReporteOrdenCompra_Load;
            panelCarrito.ResumeLayout(false);
            panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelCarrito;
        private Panel panel10;
        private DataGridView dgvCarrito;
        private Button btnPdf;
        private Button btnExcel;
        public Label lblNombreModulo;
        private Panel panel1;
    }
}