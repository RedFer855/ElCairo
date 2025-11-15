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
            panelCarrito = new Panel();
            dgvCarrito = new DataGridView();
            btnPDF = new Button();
            btnExcel = new Button();
            panelCarrito.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).BeginInit();
            SuspendLayout();
            // 
            // panelCarrito
            // 
            panelCarrito.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelCarrito.BackColor = Color.FromArgb(189, 215, 238);
            panelCarrito.Controls.Add(dgvCarrito);
            panelCarrito.Location = new Point(12, 22);
            panelCarrito.Margin = new Padding(3, 4, 3, 4);
            panelCarrito.Name = "panelCarrito";
            panelCarrito.Size = new Size(776, 301);
            panelCarrito.TabIndex = 22;
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
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.Gray;
            dataGridViewCellStyle2.Padding = new Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvCarrito.DefaultCellStyle = dataGridViewCellStyle2;
            dgvCarrito.Dock = DockStyle.Fill;
            dgvCarrito.EnableHeadersVisualStyles = false;
            dgvCarrito.GridColor = Color.FromArgb(189, 215, 238);
            dgvCarrito.Location = new Point(0, 0);
            dgvCarrito.Margin = new Padding(3, 4, 3, 4);
            dgvCarrito.Name = "dgvCarrito";
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
            dgvCarrito.RowTemplate.Height = 50;
            dgvCarrito.Size = new Size(776, 301);
            dgvCarrito.TabIndex = 2;
            // 
            // btnPDF
            // 
            btnPDF.Location = new Point(85, 372);
            btnPDF.Name = "btnPDF";
            btnPDF.Size = new Size(119, 29);
            btnPDF.TabIndex = 23;
            btnPDF.Text = "Exportar a PDF";
            btnPDF.UseVisualStyleBackColor = true;
            btnPDF.Click += btnPDF_Click;
            // 
            // btnExcel
            // 
            btnExcel.Location = new Point(589, 372);
            btnExcel.Name = "btnExcel";
            btnExcel.Size = new Size(126, 29);
            btnExcel.TabIndex = 24;
            btnExcel.Text = "Exportar a Excel";
            btnExcel.UseVisualStyleBackColor = true;
            btnExcel.Click += btnExcel_Click;
            // 
            // frmReporteOrdenCompra
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnExcel);
            Controls.Add(btnPDF);
            Controls.Add(panelCarrito);
            Name = "frmReporteOrdenCompra";
            Text = "frmReporteOrdenCompra";
            Load += frmReporteOrdenCompra_Load;
            panelCarrito.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelCarrito;
        private DataGridView dgvCarrito;
        private Button btnPDF;
        private Button btnExcel;
    }
}