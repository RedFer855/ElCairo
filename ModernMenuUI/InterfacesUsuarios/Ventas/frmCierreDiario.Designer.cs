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
            btnSalir = new Button();
            panel1 = new Panel();
            dgvCierreDiario = new DataGridView();
            panel2 = new Panel();
            label4 = new Label();
            label8 = new Label();
            cmbEmpleados = new ComboBox();
            dtpFecha = new DateTimePicker();
            btnImprimir = new Button();
            txtTotalVentas = new TextBox();
            panel3 = new Panel();
            label1 = new Label();
            textBox2 = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCierreDiario).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSalir.BackColor = Color.FromArgb(148, 168, 187);
            btnSalir.Font = new Font("Itim", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.White;
            btnSalir.ImageAlign = ContentAlignment.TopCenter;
            btnSalir.Location = new Point(34, 840);
            btnSalir.Margin = new Padding(3, 4, 3, 4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(167, 82);
            btnSalir.TabIndex = 52;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(189, 215, 238);
            panel1.Controls.Add(dgvCierreDiario);
            panel1.Location = new Point(13, 280);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(775, 527);
            panel1.TabIndex = 51;
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
            dgvCierreDiario.Size = new Size(775, 527);
            dgvCierreDiario.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(189, 215, 238);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(cmbEmpleados);
            panel2.Controls.Add(dtpFecha);
            panel2.Location = new Point(12, 24);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(484, 179);
            panel2.TabIndex = 52;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(87, 99, 110);
            label4.Location = new Point(27, 101);
            label4.Name = "label4";
            label4.Size = new Size(161, 23);
            label4.TabIndex = 21;
            label4.Text = "Seleccionar Fecha:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(87, 99, 110);
            label8.Location = new Point(7, 46);
            label8.Name = "label8";
            label8.Size = new Size(192, 23);
            label8.TabIndex = 20;
            label8.Text = "Seleccionar Empleado:";
            // 
            // cmbEmpleados
            // 
            cmbEmpleados.FormattingEnabled = true;
            cmbEmpleados.Location = new Point(205, 45);
            cmbEmpleados.Name = "cmbEmpleados";
            cmbEmpleados.Size = new Size(239, 28);
            cmbEmpleados.TabIndex = 19;
            cmbEmpleados.SelectedIndexChanged += cmbEmpleados_SelectedIndexChanged;
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(194, 97);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(250, 27);
            dtpFecha.TabIndex = 0;
            dtpFecha.ValueChanged += dtpFecha_ValueChanged;
            // 
            // btnImprimir
            // 
            btnImprimir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnImprimir.BackColor = Color.FromArgb(149, 195, 172);
            btnImprimir.Font = new Font("Itim", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnImprimir.ForeColor = SystemColors.ButtonFace;
            btnImprimir.Location = new Point(525, 89);
            btnImprimir.Margin = new Padding(3, 4, 3, 4);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(247, 84);
            btnImprimir.TabIndex = 17;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = false;
            btnImprimir.Click += btnCierre_Click;
            // 
            // txtTotalVentas
            // 
            txtTotalVentas.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtTotalVentas.Location = new Point(184, 42);
            txtTotalVentas.Name = "txtTotalVentas";
            txtTotalVentas.Size = new Size(125, 27);
            txtTotalVentas.TabIndex = 19;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackColor = Color.FromArgb(189, 215, 238);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(txtTotalVentas);
            panel3.Controls.Add(textBox2);
            panel3.Location = new Point(463, 831);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(325, 130);
            panel3.TabIndex = 52;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(87, 99, 110);
            label1.Location = new Point(5, 46);
            label1.Name = "label1";
            label1.Size = new Size(173, 23);
            label1.TabIndex = 22;
            label1.Text = "TOTAL DE VENTAS:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(530, 161);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 19;
            // 
            // frmCierreDiario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 974);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(btnImprimir);
            Controls.Add(btnSalir);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmCierreDiario";
            Text = "frmCierreDiario";
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

        private Button btnSalir;
        private Panel panel1;
        private Panel panel2;
        private DateTimePicker dtpFecha;
        private Panel panel3;
        private TextBox textBox2;
        private TextBox txtTotalVentas;
        private Button btnImprimir;
        private ComboBox cmbEmpleados;
        private DataGridView dgvCierreDiario;
        private Label label4;
        private Label label8;
        private Label label1;
    }
}