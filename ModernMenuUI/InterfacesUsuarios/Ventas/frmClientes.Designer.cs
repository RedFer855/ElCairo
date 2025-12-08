namespace ModernMenuUI
{
    partial class frmClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientes));
            panel1 = new Panel();
            panel10 = new Panel();
            dgvClientes = new DataGridView();
            panelBusqueda = new Panel();
            txtBuscar = new TextBox();
            btnbuscar = new Button();
            gbxEstado = new GroupBox();
            rbDeshabilitados = new RadioButton();
            rbHabilitados = new RadioButton();
            rbTodos = new RadioButton();
            btnFactura = new Button();
            btnSalir = new Button();
            btnVerCliente = new Button();
            btnAgregarCliente = new Button();
            lstSugerencias = new ListBox();
            pnlLimpiarFiltros = new Panel();
            btnLimpiarFiltros = new Button();
            pbxClean = new PictureBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            Dni = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            PorcentajeGanancia = new DataGridViewTextBoxColumn();
            Correo = new DataGridViewTextBoxColumn();
            RTN = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            panelBusqueda.SuspendLayout();
            gbxEstado.SuspendLayout();
            pnlLimpiarFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxClean).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(189, 215, 238);
            panel1.Controls.Add(panel10);
            panel1.Location = new Point(12, 121);
            panel1.Name = "panel1";
            panel1.Size = new Size(741, 488);
            panel1.TabIndex = 33;
            // 
            // panel10
            // 
            panel10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel10.AutoScroll = true;
            panel10.Controls.Add(dgvClientes);
            panel10.Location = new Point(16, 19);
            panel10.Name = "panel10";
            panel10.Size = new Size(704, 450);
            panel10.TabIndex = 17;
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dgvClientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvClientes.BackgroundColor = Color.FromArgb(189, 215, 238);
            dgvClientes.BorderStyle = BorderStyle.None;
            dgvClientes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvClientes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle2.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Columns.AddRange(new DataGridViewColumn[] { Dni, dataGridViewTextBoxColumn2, PorcentajeGanancia, Correo, RTN, dataGridViewTextBoxColumn4 });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle3.Padding = new Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvClientes.DefaultCellStyle = dataGridViewCellStyle3;
            dgvClientes.Dock = DockStyle.Fill;
            dgvClientes.EnableHeadersVisualStyles = false;
            dgvClientes.GridColor = Color.FromArgb(189, 215, 238);
            dgvClientes.Location = new Point(0, 0);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle4.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(102, 102, 102);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvClientes.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvClientes.RowHeadersWidth = 30;
            dgvClientes.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvClientes.RowTemplate.Height = 50;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.Size = new Size(704, 450);
            dgvClientes.TabIndex = 1;
            dgvClientes.SelectionChanged += dgvClientes_SelectionChanged;
            // 
            // panelBusqueda
            // 
            panelBusqueda.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelBusqueda.BackColor = Color.FromArgb(189, 215, 238);
            panelBusqueda.Controls.Add(txtBuscar);
            panelBusqueda.Controls.Add(btnbuscar);
            panelBusqueda.Location = new Point(12, 13);
            panelBusqueda.MaximumSize = new Size(885, 43);
            panelBusqueda.MinimumSize = new Size(250, 43);
            panelBusqueda.Name = "panelBusqueda";
            panelBusqueda.Size = new Size(570, 43);
            panelBusqueda.TabIndex = 37;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.BorderStyle = BorderStyle.None;
            txtBuscar.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(18, 12);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar Clientes...";
            txtBuscar.Size = new Size(482, 20);
            txtBuscar.TabIndex = 1;
            txtBuscar.KeyDown += txtBuscar_KeyDown;
            txtBuscar.KeyUp += txtBuscar_KeyUp;
            txtBuscar.Leave += txtBuscar_Leave;
            // 
            // btnbuscar
            // 
            btnbuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnbuscar.BackColor = Color.FromArgb(168, 191, 212);
            btnbuscar.BackgroundImage = (Image)resources.GetObject("btnbuscar.BackgroundImage");
            btnbuscar.BackgroundImageLayout = ImageLayout.Zoom;
            btnbuscar.FlatAppearance.BorderSize = 0;
            btnbuscar.FlatStyle = FlatStyle.Flat;
            btnbuscar.Location = new Point(506, 12);
            btnbuscar.Name = "btnbuscar";
            btnbuscar.Size = new Size(48, 20);
            btnbuscar.TabIndex = 0;
            btnbuscar.UseVisualStyleBackColor = false;
            btnbuscar.Click += btnBuscar_Click;
            // 
            // gbxEstado
            // 
            gbxEstado.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbxEstado.Controls.Add(rbDeshabilitados);
            gbxEstado.Controls.Add(rbHabilitados);
            gbxEstado.Controls.Add(rbTodos);
            gbxEstado.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbxEstado.ForeColor = SystemColors.ControlDarkDark;
            gbxEstado.Location = new Point(11, 62);
            gbxEstado.Name = "gbxEstado";
            gbxEstado.Size = new Size(742, 53);
            gbxEstado.TabIndex = 38;
            gbxEstado.TabStop = false;
            gbxEstado.Text = "Filtro";
            // 
            // rbDeshabilitados
            // 
            rbDeshabilitados.AutoSize = true;
            rbDeshabilitados.Location = new Point(306, 21);
            rbDeshabilitados.Name = "rbDeshabilitados";
            rbDeshabilitados.Size = new Size(178, 22);
            rbDeshabilitados.TabIndex = 30;
            rbDeshabilitados.Text = "Mostrar Deshabilitados";
            rbDeshabilitados.UseVisualStyleBackColor = true;
            // 
            // rbHabilitados
            // 
            rbHabilitados.AutoSize = true;
            rbHabilitados.Checked = true;
            rbHabilitados.Location = new Point(18, 21);
            rbHabilitados.Name = "rbHabilitados";
            rbHabilitados.Size = new Size(156, 22);
            rbHabilitados.TabIndex = 29;
            rbHabilitados.TabStop = true;
            rbHabilitados.Text = "Mostrar Habilitados";
            rbHabilitados.UseVisualStyleBackColor = true;
            // 
            // rbTodos
            // 
            rbTodos.AutoSize = true;
            rbTodos.Location = new Point(180, 21);
            rbTodos.Name = "rbTodos";
            rbTodos.Size = new Size(120, 22);
            rbTodos.TabIndex = 28;
            rbTodos.Text = "Mostrar Todos";
            rbTodos.UseVisualStyleBackColor = true;
            // 
            // btnFactura
            // 
            btnFactura.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnFactura.BackColor = Color.FromArgb(149, 195, 172);
            btnFactura.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFactura.ForeColor = SystemColors.ButtonFace;
            btnFactura.Location = new Point(204, 3);
            btnFactura.Name = "btnFactura";
            btnFactura.Size = new Size(193, 44);
            btnFactura.TabIndex = 23;
            btnFactura.Text = "Factura con Cliente";
            btnFactura.UseVisualStyleBackColor = false;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSalir.BackColor = Color.FromArgb(148, 168, 187);
            btnSalir.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.White;
            btnSalir.ImageAlign = ContentAlignment.TopCenter;
            btnSalir.Location = new Point(519, 3);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(82, 44);
            btnSalir.TabIndex = 18;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnVerCliente
            // 
            btnVerCliente.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnVerCliente.BackColor = Color.FromArgb(189, 215, 238);
            btnVerCliente.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnVerCliente.ForeColor = Color.FromArgb(87, 99, 110);
            btnVerCliente.Location = new Point(403, 3);
            btnVerCliente.Name = "btnVerCliente";
            btnVerCliente.Size = new Size(110, 44);
            btnVerCliente.TabIndex = 20;
            btnVerCliente.Text = "Ver Cliente";
            btnVerCliente.UseVisualStyleBackColor = false;
            btnVerCliente.Click += btnVerCliente_Click;
            // 
            // btnAgregarCliente
            // 
            btnAgregarCliente.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAgregarCliente.BackColor = Color.FromArgb(149, 195, 172);
            btnAgregarCliente.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregarCliente.ForeColor = SystemColors.ButtonFace;
            btnAgregarCliente.Location = new Point(3, 3);
            btnAgregarCliente.Name = "btnAgregarCliente";
            btnAgregarCliente.Size = new Size(195, 44);
            btnAgregarCliente.TabIndex = 22;
            btnAgregarCliente.Text = "Agregar Cliente";
            btnAgregarCliente.UseVisualStyleBackColor = false;
            btnAgregarCliente.Click += btnCliente_Click;
            // 
            // lstSugerencias
            // 
            lstSugerencias.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lstSugerencias.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstSugerencias.ForeColor = Color.DimGray;
            lstSugerencias.FormattingEnabled = true;
            lstSugerencias.ItemHeight = 19;
            lstSugerencias.Location = new Point(30, 47);
            lstSugerencias.MaximumSize = new Size(800, 400);
            lstSugerencias.MinimumSize = new Size(165, 23);
            lstSugerencias.Name = "lstSugerencias";
            lstSugerencias.Size = new Size(482, 23);
            lstSugerencias.TabIndex = 40;
            lstSugerencias.Visible = false;
            lstSugerencias.KeyDown += lstSugerencias_KeyDown;
            // 
            // pnlLimpiarFiltros
            // 
            pnlLimpiarFiltros.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlLimpiarFiltros.BackColor = Color.FromArgb(189, 215, 238);
            pnlLimpiarFiltros.Controls.Add(btnLimpiarFiltros);
            pnlLimpiarFiltros.Controls.Add(pbxClean);
            pnlLimpiarFiltros.Location = new Point(588, 13);
            pnlLimpiarFiltros.Name = "pnlLimpiarFiltros";
            pnlLimpiarFiltros.Size = new Size(166, 43);
            pnlLimpiarFiltros.TabIndex = 41;
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
            btnLimpiarFiltros.Size = new Size(117, 32);
            btnLimpiarFiltros.TabIndex = 34;
            btnLimpiarFiltros.Text = "Limpiar Filtros";
            btnLimpiarFiltros.UseVisualStyleBackColor = false;
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;
            // 
            // pbxClean
            // 
            pbxClean.Image = (Image)resources.GetObject("pbxClean.Image");
            pbxClean.Location = new Point(121, 8);
            pbxClean.Name = "pbxClean";
            pbxClean.Size = new Size(45, 24);
            pbxClean.SizeMode = PictureBoxSizeMode.Zoom;
            pbxClean.TabIndex = 35;
            pbxClean.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            flowLayoutPanel1.Controls.Add(btnAgregarCliente);
            flowLayoutPanel1.Controls.Add(btnFactura);
            flowLayoutPanel1.Controls.Add(btnVerCliente);
            flowLayoutPanel1.Controls.Add(btnSalir);
            flowLayoutPanel1.Location = new Point(12, 615);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(741, 52);
            flowLayoutPanel1.TabIndex = 42;
            // 
            // Dni
            // 
            Dni.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Dni.DataPropertyName = "DniCliente";
            Dni.HeaderText = "DNI";
            Dni.MinimumWidth = 6;
            Dni.Name = "Dni";
            Dni.ReadOnly = true;
            Dni.Width = 70;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewTextBoxColumn2.DataPropertyName = "NombreCliente";
            dataGridViewTextBoxColumn2.FillWeight = 70F;
            dataGridViewTextBoxColumn2.HeaderText = "Nombre";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Width = 96;
            // 
            // PorcentajeGanancia
            // 
            PorcentajeGanancia.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            PorcentajeGanancia.DataPropertyName = "TelefonoCliente";
            PorcentajeGanancia.FillWeight = 80F;
            PorcentajeGanancia.HeaderText = "Teléfono";
            PorcentajeGanancia.MinimumWidth = 6;
            PorcentajeGanancia.Name = "PorcentajeGanancia";
            PorcentajeGanancia.ReadOnly = true;
            PorcentajeGanancia.Width = 101;
            // 
            // Correo
            // 
            Correo.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Correo.DataPropertyName = "CorreoCliente";
            Correo.HeaderText = "Correo";
            Correo.MinimumWidth = 6;
            Correo.Name = "Correo";
            Correo.ReadOnly = true;
            Correo.Width = 88;
            // 
            // RTN
            // 
            RTN.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            RTN.DataPropertyName = "RtnCliente";
            RTN.HeaderText = "RTN";
            RTN.MinimumWidth = 6;
            RTN.Name = "RTN";
            RTN.ReadOnly = true;
            RTN.Width = 72;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn4.DataPropertyName = "DireccionCliente";
            dataGridViewTextBoxColumn4.FillWeight = 70F;
            dataGridViewTextBoxColumn4.HeaderText = "Dirección";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // frmClientes
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            ClientSize = new Size(766, 679);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(pnlLimpiarFiltros);
            Controls.Add(lstSugerencias);
            Controls.Add(gbxEstado);
            Controls.Add(panelBusqueda);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmClientes";
            Text = "frmClientes";
            FormClosing += frmClientes_FormClosing;
            Load += frmClientes_Load;
            panel1.ResumeLayout(false);
            panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            panelBusqueda.ResumeLayout(false);
            panelBusqueda.PerformLayout();
            gbxEstado.ResumeLayout(false);
            gbxEstado.PerformLayout();
            pnlLimpiarFiltros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbxClean).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel10;
        private DataGridView dgvClientes;
        private Panel panelBusqueda;
        private TextBox txtBuscar;
        private Button btnbuscar;
        private GroupBox gbxEstado;
        private RadioButton rbDeshabilitados;
        private RadioButton rbHabilitados;
        private RadioButton rbTodos;
        private Button btnAgregarCliente;
        private Button btnVerCliente;
        private Button btnSalir;
        private Button btnFactura;
        private ListBox lstSugerencias;
        private Panel pnlLimpiarFiltros;
        private Button btnLimpiarFiltros;
        private PictureBox pbxClean;
        private FlowLayoutPanel flowLayoutPanel1;
        private DataGridViewTextBoxColumn Dni;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn PorcentajeGanancia;
        private DataGridViewTextBoxColumn Correo;
        private DataGridViewTextBoxColumn RTN;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}