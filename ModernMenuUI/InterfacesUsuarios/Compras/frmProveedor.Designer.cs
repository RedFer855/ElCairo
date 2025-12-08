namespace ModernMenuUI.InterfacesUsuarios.Compras
{
    partial class frmProveedor
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProveedor));
            panel1 = new Panel();
            panel10 = new Panel();
            dgvProveedores = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            Categoria = new DataGridViewTextBoxColumn();
            PorcentajeGanancia = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewCheckBoxColumn();
            btnSalir = new Button();
            btnAgregarProveedor = new Button();
            btnEditarProveedor = new Button();
            gbxFiltro = new GroupBox();
            rbMostrarDeshabilitados = new RadioButton();
            rbMostrarHabilitados = new RadioButton();
            rbMostrarTodos = new RadioButton();
            panelBusqueda = new Panel();
            txtBuscar = new TextBox();
            btnbuscar = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnSeleccionarProveedor = new Button();
            lstSugerencias = new ListBox();
            pnlLimpiarFiltros = new Panel();
            btnLimpiarFiltros = new Button();
            pbxClean = new PictureBox();
            panel1.SuspendLayout();
            panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).BeginInit();
            gbxFiltro.SuspendLayout();
            panelBusqueda.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            pnlLimpiarFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxClean).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(189, 215, 238);
            panel1.Controls.Add(panel10);
            panel1.Location = new Point(12, 120);
            panel1.Name = "panel1";
            panel1.Size = new Size(789, 403);
            panel1.TabIndex = 50;
            // 
            // panel10
            // 
            panel10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel10.AutoScroll = true;
            panel10.Controls.Add(dgvProveedores);
            panel10.Location = new Point(18, 20);
            panel10.Name = "panel10";
            panel10.Size = new Size(752, 365);
            panel10.TabIndex = 17;
            // 
            // dgvProveedores
            // 
            dgvProveedores.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dgvProveedores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProveedores.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvProveedores.BackgroundColor = Color.FromArgb(189, 215, 238);
            dgvProveedores.BorderStyle = BorderStyle.None;
            dgvProveedores.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProveedores.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle2.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvProveedores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProveedores.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, Categoria, PorcentajeGanancia, dataGridViewTextBoxColumn3 });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle4.Padding = new Padding(5);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvProveedores.DefaultCellStyle = dataGridViewCellStyle4;
            dgvProveedores.Dock = DockStyle.Fill;
            dgvProveedores.EnableHeadersVisualStyles = false;
            dgvProveedores.GridColor = Color.FromArgb(189, 215, 238);
            dgvProveedores.Location = new Point(0, 0);
            dgvProveedores.Name = "dgvProveedores";
            dgvProveedores.ReadOnly = true;
            dgvProveedores.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle5.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(102, 102, 102);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvProveedores.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvProveedores.RowHeadersWidth = 30;
            dgvProveedores.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvProveedores.RowTemplate.Height = 50;
            dgvProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProveedores.Size = new Size(752, 365);
            dgvProveedores.TabIndex = 1;
            dgvProveedores.SelectionChanged += dgvProveedores_SelectionChanged;
            dgvProveedores.DoubleClick += dgvProveedores_DoubleClick;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewTextBoxColumn1.DataPropertyName = "IdProveedor";
            dataGridViewCellStyle3.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.Padding = new Padding(0, 1, 0, 0);
            dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewTextBoxColumn1.FillWeight = 60F;
            dataGridViewTextBoxColumn1.HeaderText = "Id";
            dataGridViewTextBoxColumn1.MinimumWidth = 45;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Width = 57;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewTextBoxColumn2.DataPropertyName = "NombreProveedor";
            dataGridViewTextBoxColumn2.FillWeight = 35.1780434F;
            dataGridViewTextBoxColumn2.HeaderText = "Proveedor";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Width = 111;
            // 
            // Categoria
            // 
            Categoria.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Categoria.DataPropertyName = "TelefonoProveedor";
            Categoria.FillWeight = 40.203476F;
            Categoria.HeaderText = "Teléfono";
            Categoria.Name = "Categoria";
            Categoria.ReadOnly = true;
            Categoria.Width = 101;
            // 
            // PorcentajeGanancia
            // 
            PorcentajeGanancia.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            PorcentajeGanancia.DataPropertyName = "DireccionProveedor";
            PorcentajeGanancia.FillWeight = 40.203476F;
            PorcentajeGanancia.HeaderText = "Dirección";
            PorcentajeGanancia.Name = "PorcentajeGanancia";
            PorcentajeGanancia.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewTextBoxColumn3.DataPropertyName = "EstadoProveedor";
            dataGridViewTextBoxColumn3.FillWeight = 40.203476F;
            dataGridViewTextBoxColumn3.HeaderText = "Estado";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn3.Resizable = DataGridViewTriState.True;
            dataGridViewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridViewTextBoxColumn3.Width = 89;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(148, 168, 187);
            btnSalir.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.White;
            btnSalir.ImageAlign = ContentAlignment.TopCenter;
            btnSalir.Location = new Point(498, 3);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(118, 43);
            btnSalir.TabIndex = 18;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnAgregarProveedor
            // 
            btnAgregarProveedor.BackColor = Color.FromArgb(149, 195, 172);
            btnAgregarProveedor.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregarProveedor.ForeColor = SystemColors.ButtonFace;
            btnAgregarProveedor.Location = new Point(192, 3);
            btnAgregarProveedor.Name = "btnAgregarProveedor";
            btnAgregarProveedor.Size = new Size(158, 43);
            btnAgregarProveedor.TabIndex = 22;
            btnAgregarProveedor.Text = "Agregar Proveedor";
            btnAgregarProveedor.UseVisualStyleBackColor = false;
            btnAgregarProveedor.Click += btnAgregarProveedor_Click;
            // 
            // btnEditarProveedor
            // 
            btnEditarProveedor.BackColor = Color.FromArgb(189, 215, 238);
            btnEditarProveedor.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEditarProveedor.ForeColor = Color.FromArgb(87, 99, 110);
            btnEditarProveedor.Location = new Point(356, 3);
            btnEditarProveedor.Name = "btnEditarProveedor";
            btnEditarProveedor.Size = new Size(136, 43);
            btnEditarProveedor.TabIndex = 20;
            btnEditarProveedor.Text = "Ver Proveedor";
            btnEditarProveedor.UseVisualStyleBackColor = false;
            btnEditarProveedor.Click += btnEditarProveedor_Click;
            // 
            // gbxFiltro
            // 
            gbxFiltro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbxFiltro.Controls.Add(rbMostrarDeshabilitados);
            gbxFiltro.Controls.Add(rbMostrarHabilitados);
            gbxFiltro.Controls.Add(rbMostrarTodos);
            gbxFiltro.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbxFiltro.ForeColor = SystemColors.ControlDarkDark;
            gbxFiltro.Location = new Point(12, 61);
            gbxFiltro.MaximumSize = new Size(533, 53);
            gbxFiltro.Name = "gbxFiltro";
            gbxFiltro.Size = new Size(511, 53);
            gbxFiltro.TabIndex = 52;
            gbxFiltro.TabStop = false;
            gbxFiltro.Text = "Filtros";
            // 
            // rbMostrarDeshabilitados
            // 
            rbMostrarDeshabilitados.AutoSize = true;
            rbMostrarDeshabilitados.Location = new Point(125, 21);
            rbMostrarDeshabilitados.Name = "rbMostrarDeshabilitados";
            rbMostrarDeshabilitados.Size = new Size(121, 22);
            rbMostrarDeshabilitados.TabIndex = 30;
            rbMostrarDeshabilitados.Text = "Deshabilitados";
            rbMostrarDeshabilitados.UseVisualStyleBackColor = true;
            // 
            // rbMostrarHabilitados
            // 
            rbMostrarHabilitados.AutoSize = true;
            rbMostrarHabilitados.Checked = true;
            rbMostrarHabilitados.Location = new Point(18, 21);
            rbMostrarHabilitados.Name = "rbMostrarHabilitados";
            rbMostrarHabilitados.Size = new Size(101, 22);
            rbMostrarHabilitados.TabIndex = 29;
            rbMostrarHabilitados.TabStop = true;
            rbMostrarHabilitados.Text = "Habilitados";
            rbMostrarHabilitados.UseVisualStyleBackColor = true;
            // 
            // rbMostrarTodos
            // 
            rbMostrarTodos.AutoSize = true;
            rbMostrarTodos.Location = new Point(252, 21);
            rbMostrarTodos.Name = "rbMostrarTodos";
            rbMostrarTodos.Size = new Size(120, 22);
            rbMostrarTodos.TabIndex = 28;
            rbMostrarTodos.Text = "Mostrar Todos";
            rbMostrarTodos.UseVisualStyleBackColor = true;
            // 
            // panelBusqueda
            // 
            panelBusqueda.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelBusqueda.BackColor = Color.FromArgb(189, 215, 238);
            panelBusqueda.Controls.Add(txtBuscar);
            panelBusqueda.Controls.Add(btnbuscar);
            panelBusqueda.Location = new Point(12, 12);
            panelBusqueda.MaximumSize = new Size(660, 43);
            panelBusqueda.MinimumSize = new Size(426, 43);
            panelBusqueda.Name = "panelBusqueda";
            panelBusqueda.Size = new Size(492, 43);
            panelBusqueda.TabIndex = 51;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.BorderStyle = BorderStyle.None;
            txtBuscar.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(18, 12);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar Proveedores...";
            txtBuscar.Size = new Size(405, 20);
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
            btnbuscar.Location = new Point(429, 12);
            btnbuscar.Name = "btnbuscar";
            btnbuscar.Size = new Size(48, 20);
            btnbuscar.TabIndex = 0;
            btnbuscar.UseVisualStyleBackColor = false;
            btnbuscar.Click += btnbuscar_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            flowLayoutPanel1.Controls.Add(btnSeleccionarProveedor);
            flowLayoutPanel1.Controls.Add(btnAgregarProveedor);
            flowLayoutPanel1.Controls.Add(btnEditarProveedor);
            flowLayoutPanel1.Controls.Add(btnSalir);
            flowLayoutPanel1.Location = new Point(12, 535);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(641, 53);
            flowLayoutPanel1.TabIndex = 53;
            // 
            // btnSeleccionarProveedor
            // 
            btnSeleccionarProveedor.BackColor = Color.FromArgb(149, 195, 172);
            btnSeleccionarProveedor.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSeleccionarProveedor.ForeColor = SystemColors.ButtonFace;
            btnSeleccionarProveedor.Location = new Point(3, 3);
            btnSeleccionarProveedor.Name = "btnSeleccionarProveedor";
            btnSeleccionarProveedor.Size = new Size(183, 43);
            btnSeleccionarProveedor.TabIndex = 23;
            btnSeleccionarProveedor.Text = "Seleccionar Proveedor";
            btnSeleccionarProveedor.UseVisualStyleBackColor = false;
            btnSeleccionarProveedor.Click += btnSeleccionarProveedor_Click;
            // 
            // lstSugerencias
            // 
            lstSugerencias.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lstSugerencias.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstSugerencias.ForeColor = Color.DimGray;
            lstSugerencias.FormattingEnabled = true;
            lstSugerencias.ItemHeight = 18;
            lstSugerencias.Location = new Point(30, 45);
            lstSugerencias.MaximumSize = new Size(573, 22);
            lstSugerencias.MinimumSize = new Size(339, 22);
            lstSugerencias.Name = "lstSugerencias";
            lstSugerencias.Size = new Size(405, 22);
            lstSugerencias.TabIndex = 54;
            lstSugerencias.Visible = false;
            lstSugerencias.MouseClick += lstSugerencias_MouseClick;
            // 
            // pnlLimpiarFiltros
            // 
            pnlLimpiarFiltros.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlLimpiarFiltros.BackColor = Color.FromArgb(189, 215, 238);
            pnlLimpiarFiltros.Controls.Add(btnLimpiarFiltros);
            pnlLimpiarFiltros.Controls.Add(pbxClean);
            pnlLimpiarFiltros.Location = new Point(635, 12);
            pnlLimpiarFiltros.Name = "pnlLimpiarFiltros";
            pnlLimpiarFiltros.Size = new Size(166, 43);
            pnlLimpiarFiltros.TabIndex = 55;
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
            // frmProveedor
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            ClientSize = new Size(813, 590);
            Controls.Add(pnlLimpiarFiltros);
            Controls.Add(lstSugerencias);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel1);
            Controls.Add(gbxFiltro);
            Controls.Add(panelBusqueda);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmProveedor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Proveedores";
            FormClosing += frmProveedores_FormClosing;
            Load += frmProveedores_Load;
            panel1.ResumeLayout(false);
            panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).EndInit();
            gbxFiltro.ResumeLayout(false);
            gbxFiltro.PerformLayout();
            panelBusqueda.ResumeLayout(false);
            panelBusqueda.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            pnlLimpiarFiltros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbxClean).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel10;
        private DataGridView dgvProveedores;
        private Button btnSalir;
        private Button btnAgregarProveedor;
        private Button btnEditarProveedor;
        private GroupBox gbxFiltro;
        private RadioButton rbMostrarDeshabilitados;
        private RadioButton rbMostrarHabilitados;
        private RadioButton rbMostrarTodos;
        private Panel panelBusqueda;
        private TextBox txtBuscar;
        private Button btnbuscar;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn Categoria;
        private DataGridViewTextBoxColumn PorcentajeGanancia;
        private DataGridViewCheckBoxColumn dataGridViewTextBoxColumn3;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnSeleccionarProveedor;
        private ListBox lstSugerencias;
        private Panel pnlLimpiarFiltros;
        private Button btnLimpiarFiltros;
        private PictureBox pbxClean;
    }
}