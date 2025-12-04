namespace ModernMenuUI.InterfacesUsuarios.Ventas
{
    partial class frmImprimirCierre
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
            panel1 = new Panel();
            dgvCierreDiario = new DataGridView();
            btnPDF = new Button();
            btnExcel = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCierreDiario).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(189, 215, 238);
            panel1.Controls.Add(dgvCierreDiario);
            panel1.Location = new Point(21, 22);
            panel1.Name = "panel1";
            panel1.Size = new Size(758, 350);
            panel1.TabIndex = 1;
            // 
            // dgvCierreDiario
            // 
            dgvCierreDiario.AllowUserToAddRows = false;
            dgvCierreDiario.AllowUserToDeleteRows = false;
            dgvCierreDiario.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dgvCierreDiario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCierreDiario.BackgroundColor = Color.FromArgb(189, 215, 238);
            dgvCierreDiario.BorderStyle = BorderStyle.None;
            dgvCierreDiario.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCierreDiario.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle1.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle1.SelectionBackColor = Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCierreDiario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCierreDiario.ColumnHeadersHeight = 40;
            dgvCierreDiario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvCierreDiario.DefaultCellStyle = dataGridViewCellStyle2;
            dgvCierreDiario.EnableHeadersVisualStyles = false;
            dgvCierreDiario.GridColor = Color.FromArgb(189, 215, 238);
            dgvCierreDiario.Location = new Point(0, 22);
            dgvCierreDiario.Margin = new Padding(4);
            dgvCierreDiario.Name = "dgvCierreDiario";
            dgvCierreDiario.ReadOnly = true;
            dgvCierreDiario.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(102, 102, 102);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvCierreDiario.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvCierreDiario.RowHeadersWidth = 51;
            dgvCierreDiario.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dgvCierreDiario.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvCierreDiario.RowTemplate.Height = 50;
            dgvCierreDiario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCierreDiario.Size = new Size(758, 294);
            dgvCierreDiario.TabIndex = 3;
            // 
            // btnPDF
            // 
            btnPDF.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnPDF.BackColor = Color.FromArgb(228, 158, 144);
            btnPDF.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPDF.ForeColor = Color.White;
            btnPDF.ImageAlign = ContentAlignment.TopCenter;
            btnPDF.Location = new Point(58, 423);
            btnPDF.Margin = new Padding(4);
            btnPDF.Name = "btnPDF";
            btnPDF.Size = new Size(182, 64);
            btnPDF.TabIndex = 44;
            btnPDF.Text = "Exportar a PDF";
            btnPDF.UseVisualStyleBackColor = false;
            btnPDF.Click += btnPDF_Click;
            // 
            // btnExcel
            // 
            btnExcel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnExcel.BackColor = Color.FromArgb(149, 195, 172);
            btnExcel.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExcel.ForeColor = Color.White;
            btnExcel.ImageAlign = ContentAlignment.TopCenter;
            btnExcel.Location = new Point(264, 423);
            btnExcel.Margin = new Padding(4);
            btnExcel.Name = "btnExcel";
            btnExcel.Size = new Size(182, 64);
            btnExcel.TabIndex = 45;
            btnExcel.Text = "Exportar a Excel";
            btnExcel.UseVisualStyleBackColor = false;
            btnExcel.Click += btnExcel_Click;
            // 
            // frmImprimirCierre
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 529);
            Controls.Add(btnExcel);
            Controls.Add(btnPDF);
            Controls.Add(panel1);
            Name = "frmImprimirCierre";
            Text = "frmImprimirCierre";
            Load += frmImprimirCierre_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCierreDiario).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dgvCierreDiario;
        private Button btnPDF;
        private Button btnExcel;
    }
}