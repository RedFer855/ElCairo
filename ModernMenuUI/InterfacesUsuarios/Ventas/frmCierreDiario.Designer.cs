namespace ModernMenuUI.InterfacesUsuarios.Ventas
{
    partial class frmCierreDiario
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
            panel2 = new Panel();
            dtpFecha = new DateTimePicker();
            cmbEmpleado = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            panel3 = new Panel();
            txtTotalVentas = new TextBox();
            label3 = new Label();
            btnImprimirCierre = new Button();
            btnSalir = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCierreDiario).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(189, 215, 238);
            panel1.Controls.Add(dgvCierreDiario);
            panel1.Location = new Point(28, 198);
            panel1.Name = "panel1";
            panel1.Size = new Size(758, 437);
            panel1.TabIndex = 0;
            // 
            // dgvCierreDiario
            // 
            dgvCierreDiario.AllowUserToAddRows = false;
            dgvCierreDiario.AllowUserToDeleteRows = false;
            dgvCierreDiario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            dgvCierreDiario.Location = new Point(0, 30);
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
            dgvCierreDiario.Size = new Size(758, 385);
            dgvCierreDiario.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(189, 215, 238);
            panel2.Controls.Add(dtpFecha);
            panel2.Controls.Add(cmbEmpleado);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(28, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(758, 106);
            panel2.TabIndex = 1;
            // 
            // dtpFecha
            // 
            dtpFecha.Anchor = AnchorStyles.Top;
            dtpFecha.Location = new Point(563, 29);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(179, 27);
            dtpFecha.TabIndex = 3;
            dtpFecha.ValueChanged += dtpFecha_ValueChanged;
            // 
            // cmbEmpleado
            // 
            cmbEmpleado.Anchor = AnchorStyles.Top;
            cmbEmpleado.FormattingEnabled = true;
            cmbEmpleado.Location = new Point(198, 28);
            cmbEmpleado.Name = "cmbEmpleado";
            cmbEmpleado.Size = new Size(186, 28);
            cmbEmpleado.TabIndex = 2;
            cmbEmpleado.SelectedIndexChanged += cmbEmpleado_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Location = new Point(400, 34);
            label2.Name = "label2";
            label2.Size = new Size(130, 20);
            label2.TabIndex = 1;
            label2.Text = "Seleccionar Fecha:";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Location = new Point(13, 31);
            label1.Name = "label1";
            label1.Size = new Size(160, 20);
            label1.TabIndex = 0;
            label1.Text = "Seleccionar Empleado:";
            label1.Click += label1_Click;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panel3.BackColor = Color.FromArgb(189, 215, 238);
            panel3.Controls.Add(txtTotalVentas);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(467, 715);
            panel3.Name = "panel3";
            panel3.Size = new Size(319, 115);
            panel3.TabIndex = 2;
            // 
            // txtTotalVentas
            // 
            txtTotalVentas.Location = new Point(178, 45);
            txtTotalVentas.Name = "txtTotalVentas";
            txtTotalVentas.Size = new Size(125, 27);
            txtTotalVentas.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 48);
            label3.Name = "label3";
            label3.Size = new Size(133, 20);
            label3.TabIndex = 2;
            label3.Text = "TOTAL DE VENTAS:";
            // 
            // btnImprimirCierre
            // 
            btnImprimirCierre.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnImprimirCierre.BackColor = Color.FromArgb(189, 215, 238);
            btnImprimirCierre.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnImprimirCierre.ForeColor = Color.FromArgb(87, 99, 110);
            btnImprimirCierre.Location = new Point(244, 715);
            btnImprimirCierre.Margin = new Padding(4);
            btnImprimirCierre.Name = "btnImprimirCierre";
            btnImprimirCierre.Size = new Size(187, 115);
            btnImprimirCierre.TabIndex = 25;
            btnImprimirCierre.Text = "Imprimir Orden";
            btnImprimirCierre.UseVisualStyleBackColor = false;
            btnImprimirCierre.Click += btnImprimirCierre_Click;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSalir.BackColor = Color.FromArgb(148, 168, 187);
            btnSalir.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.White;
            btnSalir.ImageAlign = ContentAlignment.TopCenter;
            btnSalir.Location = new Point(41, 715);
            btnSalir.Margin = new Padding(4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(177, 115);
            btnSalir.TabIndex = 27;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // frmCierreDiario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(820, 860);
            Controls.Add(btnSalir);
            Controls.Add(btnImprimirCierre);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmCierreDiario";
            Text = "frmCierreDiario";
            FormClosing += frmCierreDiario_FormClosing;
            Load += frmCierreDiario_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCierreDiario).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private DataGridView dgvCierreDiario;
        private Label label1;
        private DateTimePicker dtpFecha;
        private ComboBox cmbEmpleado;
        private Label label2;
        private TextBox txtTotalVentas;
        private Label label3;
        private Button btnImprimirCierre;
        private Button btnSalir;
    }
}