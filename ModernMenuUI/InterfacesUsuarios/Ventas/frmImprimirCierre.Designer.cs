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
            panel2 = new Panel();
            dgvCierreDiario = new DataGridView();
            btnPDF = new Button();
            btnExcel = new Button();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCierreDiario).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(189, 215, 238);
            panel2.Controls.Add(dgvCierreDiario);
            panel2.Location = new Point(29, 25);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(715, 302);
            panel2.TabIndex = 53;
            // 
            // dgvCierreDiario
            // 
            dgvCierreDiario.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dgvCierreDiario.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvCierreDiario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCierreDiario.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvCierreDiario.BackgroundColor = Color.FromArgb(189, 215, 238);
            dgvCierreDiario.BorderStyle = BorderStyle.None;
            dgvCierreDiario.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCierreDiario.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle2.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvCierreDiario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvCierreDiario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle3.Padding = new Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvCierreDiario.DefaultCellStyle = dataGridViewCellStyle3;
            dgvCierreDiario.Dock = DockStyle.Fill;
            dgvCierreDiario.EnableHeadersVisualStyles = false;
            dgvCierreDiario.GridColor = Color.FromArgb(189, 215, 238);
            dgvCierreDiario.Location = new Point(0, 0);
            dgvCierreDiario.Margin = new Padding(3, 4, 3, 4);
            dgvCierreDiario.Name = "dgvCierreDiario";
            dgvCierreDiario.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle4.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(102, 102, 102);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvCierreDiario.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvCierreDiario.RowHeadersWidth = 30;
            dgvCierreDiario.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvCierreDiario.RowTemplate.DefaultCellStyle.BackColor = Color.White;
            dgvCierreDiario.RowTemplate.Height = 50;
            dgvCierreDiario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCierreDiario.Size = new Size(715, 302);
            dgvCierreDiario.TabIndex = 5;
            // 
            // btnPDF
            // 
            btnPDF.Location = new Point(29, 371);
            btnPDF.Name = "btnPDF";
            btnPDF.Size = new Size(127, 29);
            btnPDF.TabIndex = 54;
            btnPDF.Text = "Exportar a PDF";
            btnPDF.UseVisualStyleBackColor = true;
            btnPDF.Click += btnPDF_Click;
            // 
            // btnExcel
            // 
            btnExcel.Location = new Point(617, 371);
            btnExcel.Name = "btnExcel";
            btnExcel.Size = new Size(127, 29);
            btnExcel.TabIndex = 55;
            btnExcel.Text = "Exportar a Excel";
            btnExcel.UseVisualStyleBackColor = true;
            btnExcel.Click += btnExcel_Click;
            // 
            // frmImprimirCierre
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnExcel);
            Controls.Add(btnPDF);
            Controls.Add(panel2);
            Name = "frmImprimirCierre";
            Text = "frmImprimirCierre";
            Load += frmImprimirCierre_Load;
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCierreDiario).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private DataGridView dgvCierreDiario;
        private Button btnPDF;
        private Button btnExcel;
    }
}