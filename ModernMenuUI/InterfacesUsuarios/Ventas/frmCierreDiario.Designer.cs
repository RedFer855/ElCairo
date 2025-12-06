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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCierreDiario));
            panel1 = new Panel();
            dgvCierre = new DataGridView();
            IdMarca = new DataGridViewTextBoxColumn();
            ProductoCierre = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            Precios = new DataGridViewTextBoxColumn();
            Precio = new DataGridViewTextBoxColumn();
            dtpFecha = new DateTimePicker();
            cmbEmpleado = new ComboBox();
            panel3 = new Panel();
            txtTotalVentas = new TextBox();
            label3 = new Label();
            btnImprimirCierre = new Button();
            btnSalir = new Button();
            gbxEstado = new GroupBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            label4 = new Label();
            btnMarca = new Button();
            btnBuscarEmpleado = new Button();
            label5 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCierre).BeginInit();
            panel3.SuspendLayout();
            gbxEstado.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(189, 215, 238);
            panel1.Controls.Add(dgvCierre);
            panel1.ForeColor = Color.FromArgb(87, 99, 110);
            panel1.Location = new Point(12, 70);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(949, 485);
            panel1.TabIndex = 0;
            // 
            // dgvCierre
            // 
            dgvCierre.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle1.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dgvCierre.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvCierre.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvCierre.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvCierre.BackgroundColor = Color.FromArgb(189, 215, 238);
            dgvCierre.BorderStyle = BorderStyle.None;
            dgvCierre.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCierre.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle2.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvCierre.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvCierre.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCierre.Columns.AddRange(new DataGridViewColumn[] { IdMarca, ProductoCierre, dataGridViewTextBoxColumn4, Precios, Precio });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle3.Padding = new Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvCierre.DefaultCellStyle = dataGridViewCellStyle3;
            dgvCierre.EnableHeadersVisualStyles = false;
            dgvCierre.GridColor = Color.FromArgb(189, 215, 238);
            dgvCierre.Location = new Point(12, 15);
            dgvCierre.Name = "dgvCierre";
            dgvCierre.ReadOnly = true;
            dgvCierre.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle4.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(102, 102, 102);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvCierre.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvCierre.RowHeadersWidth = 30;
            dgvCierre.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvCierre.RowTemplate.Height = 50;
            dgvCierre.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCierre.Size = new Size(924, 455);
            dgvCierre.TabIndex = 3;
            dgvCierre.TabStop = false;
            // 
            // IdMarca
            // 
            IdMarca.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            IdMarca.DataPropertyName = "IdVenta";
            IdMarca.HeaderText = "Código";
            IdMarca.Name = "IdMarca";
            IdMarca.ReadOnly = true;
            IdMarca.Width = 89;
            // 
            // ProductoCierre
            // 
            ProductoCierre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ProductoCierre.DataPropertyName = "Producto";
            ProductoCierre.HeaderText = "Producto";
            ProductoCierre.Name = "ProductoCierre";
            ProductoCierre.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewTextBoxColumn4.DataPropertyName = "Cantidad";
            dataGridViewTextBoxColumn4.FillWeight = 120F;
            dataGridViewTextBoxColumn4.HeaderText = "Cantidad";
            dataGridViewTextBoxColumn4.MinimumWidth = 100;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            dataGridViewTextBoxColumn4.Width = 105;
            // 
            // Precios
            // 
            Precios.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Precios.DataPropertyName = "Precio";
            Precios.HeaderText = "Precio";
            Precios.Name = "Precios";
            Precios.ReadOnly = true;
            Precios.Width = 84;
            // 
            // Precio
            // 
            Precio.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Precio.DataPropertyName = "Subtotal";
            Precio.HeaderText = "Subtotal";
            Precio.Name = "Precio";
            Precio.ReadOnly = true;
            Precio.Width = 101;
            // 
            // dtpFecha
            // 
            dtpFecha.CalendarForeColor = Color.DimGray;
            dtpFecha.CalendarTitleForeColor = Color.DimGray;
            dtpFecha.Dock = DockStyle.Fill;
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(361, 2);
            dtpFecha.Margin = new Padding(3, 2, 3, 2);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(194, 25);
            dtpFecha.TabIndex = 3;
            dtpFecha.ValueChanged += dtpFecha_ValueChanged;
            // 
            // cmbEmpleado
            // 
            cmbEmpleado.Dock = DockStyle.Fill;
            cmbEmpleado.ForeColor = Color.DimGray;
            cmbEmpleado.FormattingEnabled = true;
            cmbEmpleado.Location = new Point(83, 2);
            cmbEmpleado.Margin = new Padding(3, 2, 3, 2);
            cmbEmpleado.Name = "cmbEmpleado";
            cmbEmpleado.Size = new Size(194, 26);
            cmbEmpleado.TabIndex = 2;
            cmbEmpleado.Text = "(Empleado)";
            cmbEmpleado.SelectedIndexChanged += cmbEmpleado_SelectedIndexChanged;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panel3.BackColor = Color.FromArgb(189, 215, 238);
            panel3.Controls.Add(txtTotalVentas);
            panel3.Controls.Add(label3);
            panel3.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel3.Location = new Point(562, 573);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(399, 61);
            panel3.TabIndex = 2;
            // 
            // txtTotalVentas
            // 
            txtTotalVentas.Font = new Font("Itim", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTotalVentas.ForeColor = Color.DimGray;
            txtTotalVentas.Location = new Point(143, 14);
            txtTotalVentas.Margin = new Padding(3, 2, 3, 2);
            txtTotalVentas.Name = "txtTotalVentas";
            txtTotalVentas.Size = new Size(243, 36);
            txtTotalVentas.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Itim", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DimGray;
            label3.Location = new Point(9, 22);
            label3.Name = "label3";
            label3.Size = new Size(128, 23);
            label3.TabIndex = 2;
            label3.Text = "Total de Venta:";
            // 
            // btnImprimirCierre
            // 
            btnImprimirCierre.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnImprimirCierre.BackColor = Color.FromArgb(189, 215, 238);
            btnImprimirCierre.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnImprimirCierre.ForeColor = Color.FromArgb(87, 99, 110);
            btnImprimirCierre.Location = new Point(4, 3);
            btnImprimirCierre.Margin = new Padding(4, 3, 4, 3);
            btnImprimirCierre.Name = "btnImprimirCierre";
            btnImprimirCierre.Size = new Size(164, 60);
            btnImprimirCierre.TabIndex = 25;
            btnImprimirCierre.Text = "Imprimir Cierre";
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
            btnSalir.Location = new Point(176, 3);
            btnSalir.Margin = new Padding(4, 3, 4, 3);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(155, 60);
            btnSalir.TabIndex = 27;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // gbxEstado
            // 
            gbxEstado.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbxEstado.Controls.Add(tableLayoutPanel2);
            gbxEstado.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbxEstado.ForeColor = Color.DimGray;
            gbxEstado.Location = new Point(12, 12);
            gbxEstado.Name = "gbxEstado";
            gbxEstado.Size = new Size(949, 53);
            gbxEstado.TabIndex = 29;
            gbxEstado.TabStop = false;
            gbxEstado.Text = "Filtros de Búsqueda:";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 6;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 33F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 45F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 34F));
            tableLayoutPanel2.Controls.Add(cmbEmpleado, 1, 0);
            tableLayoutPanel2.Controls.Add(dtpFecha, 4, 0);
            tableLayoutPanel2.Controls.Add(label4, 3, 0);
            tableLayoutPanel2.Controls.Add(btnMarca, 5, 0);
            tableLayoutPanel2.Controls.Add(btnBuscarEmpleado, 2, 0);
            tableLayoutPanel2.Controls.Add(label5, 0, 0);
            tableLayoutPanel2.Location = new Point(6, 17);
            tableLayoutPanel2.MinimumSize = new Size(400, 30);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(593, 30);
            tableLayoutPanel2.TabIndex = 39;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(316, 0);
            label4.Name = "label4";
            label4.Size = new Size(39, 30);
            label4.TabIndex = 40;
            label4.Text = "Día:";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnMarca
            // 
            btnMarca.BackColor = Color.FromArgb(168, 191, 212);
            btnMarca.BackgroundImage = (Image)resources.GetObject("btnMarca.BackgroundImage");
            btnMarca.BackgroundImageLayout = ImageLayout.Zoom;
            btnMarca.Dock = DockStyle.Fill;
            btnMarca.FlatAppearance.BorderSize = 0;
            btnMarca.FlatStyle = FlatStyle.Flat;
            btnMarca.Location = new Point(561, 3);
            btnMarca.Name = "btnMarca";
            btnMarca.Size = new Size(29, 24);
            btnMarca.TabIndex = 2;
            btnMarca.UseVisualStyleBackColor = false;
            // 
            // btnBuscarEmpleado
            // 
            btnBuscarEmpleado.BackColor = Color.FromArgb(168, 191, 212);
            btnBuscarEmpleado.BackgroundImage = (Image)resources.GetObject("btnBuscarEmpleado.BackgroundImage");
            btnBuscarEmpleado.BackgroundImageLayout = ImageLayout.Zoom;
            btnBuscarEmpleado.Dock = DockStyle.Fill;
            btnBuscarEmpleado.FlatAppearance.BorderSize = 0;
            btnBuscarEmpleado.FlatStyle = FlatStyle.Flat;
            btnBuscarEmpleado.Location = new Point(283, 3);
            btnBuscarEmpleado.Name = "btnBuscarEmpleado";
            btnBuscarEmpleado.Size = new Size(27, 24);
            btnBuscarEmpleado.TabIndex = 38;
            btnBuscarEmpleado.UseVisualStyleBackColor = false;
            btnBuscarEmpleado.Click += btnBuscarEmpleado_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(74, 30);
            label5.TabIndex = 39;
            label5.Text = "Empleado:";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            flowLayoutPanel1.Controls.Add(btnImprimirCierre);
            flowLayoutPanel1.Controls.Add(btnSalir);
            flowLayoutPanel1.Location = new Point(12, 570);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(361, 63);
            flowLayoutPanel1.TabIndex = 30;
            // 
            // frmCierreDiario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(973, 645);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(gbxEstado);
            Controls.Add(panel3);
            Controls.Add(panel1);
            ForeColor = Color.DimGray;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmCierreDiario";
            Text = "frmCierreDiario";
            FormClosing += frmCierreDiario_FormClosing;
            Load += frmCierreDiario_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCierre).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            gbxEstado.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private DateTimePicker dtpFecha;
        private ComboBox cmbEmpleado;
        private TextBox txtTotalVentas;
        private Label label3;
        private Button btnImprimirCierre;
        private Button btnSalir;
        private DataGridView dgvCierre;
        private DataGridViewTextBoxColumn IdMarca;
        private DataGridViewTextBoxColumn ProductoCierre;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn Precios;
        private DataGridViewTextBoxColumn Precio;
        private GroupBox gbxEstado;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label4;
        private Button btnMarca;
        private Button btnBuscarEmpleado;
        private Label label5;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}