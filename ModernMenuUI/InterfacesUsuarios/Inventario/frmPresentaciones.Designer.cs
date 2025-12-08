namespace ModernMenuUI.InterfacesUsuarios.Inventario
{
    partial class frmPresentaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPresentaciones));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panelBusqueda = new Panel();
            txtBuscar = new TextBox();
            btnbuscar = new Button();
            panelCarrito = new Panel();
            panel10 = new Panel();
            dgvPresentaciones = new DataGridView();
            IdPresentacion = new DataGridViewTextBoxColumn();
            NombrePresentacion = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            EstadoPresentacion = new DataGridViewCheckBoxColumn();
            gbxEstado = new GroupBox();
            rbMostrarDeshabilitados = new RadioButton();
            rbMostrarTodos = new RadioButton();
            rbMostrarHabilitados = new RadioButton();
            btnAgregarPresentacion = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnModificarPresentacion = new Button();
            btnSeleccionarPresentacion = new Button();
            btnSalir = new Button();
            panel1 = new Panel();
            pnlLimpiarFiltros = new Panel();
            btnLimpiarFiltros = new Button();
            pbxClean = new PictureBox();
            lstSugerencias = new ListBox();
            panelBusqueda.SuspendLayout();
            panelCarrito.SuspendLayout();
            panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPresentaciones).BeginInit();
            gbxEstado.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            pnlLimpiarFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxClean).BeginInit();
            SuspendLayout();
            // 
            // panelBusqueda
            // 
            panelBusqueda.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelBusqueda.BackColor = Color.FromArgb(189, 215, 238);
            panelBusqueda.Controls.Add(txtBuscar);
            panelBusqueda.Controls.Add(btnbuscar);
            panelBusqueda.Location = new Point(12, 11);
            panelBusqueda.MaximumSize = new Size(700, 43);
            panelBusqueda.MinimumSize = new Size(330, 43);
            panelBusqueda.Name = "panelBusqueda";
            panelBusqueda.Size = new Size(495, 43);
            panelBusqueda.TabIndex = 46;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtBuscar.BorderStyle = BorderStyle.None;
            txtBuscar.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(18, 12);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar Presentaciones...";
            txtBuscar.Size = new Size(402, 20);
            txtBuscar.TabIndex = 1;
            txtBuscar.KeyDown += txtBuscar_KeyDown;
            txtBuscar.KeyUp += txtBuscar_KeyUp;
            // 
            // btnbuscar
            // 
            btnbuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnbuscar.BackColor = Color.FromArgb(168, 191, 212);
            btnbuscar.BackgroundImage = (Image)resources.GetObject("btnbuscar.BackgroundImage");
            btnbuscar.BackgroundImageLayout = ImageLayout.Zoom;
            btnbuscar.FlatAppearance.BorderSize = 0;
            btnbuscar.FlatStyle = FlatStyle.Flat;
            btnbuscar.Location = new Point(426, 12);
            btnbuscar.Name = "btnbuscar";
            btnbuscar.Size = new Size(48, 20);
            btnbuscar.TabIndex = 0;
            btnbuscar.UseVisualStyleBackColor = false;
            // 
            // panelCarrito
            // 
            panelCarrito.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelCarrito.BackColor = Color.FromArgb(189, 215, 238);
            panelCarrito.Controls.Add(panel10);
            panelCarrito.Location = new Point(15, 14);
            panelCarrito.Name = "panelCarrito";
            panelCarrito.Size = new Size(648, 264);
            panelCarrito.TabIndex = 13;
            // 
            // panel10
            // 
            panel10.AutoScroll = true;
            panel10.Controls.Add(dgvPresentaciones);
            panel10.Dock = DockStyle.Fill;
            panel10.Location = new Point(0, 0);
            panel10.Name = "panel10";
            panel10.Size = new Size(648, 264);
            panel10.TabIndex = 17;
            // 
            // dgvPresentaciones
            // 
            dgvPresentaciones.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dgvPresentaciones.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvPresentaciones.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvPresentaciones.BackgroundColor = Color.FromArgb(189, 215, 238);
            dgvPresentaciones.BorderStyle = BorderStyle.None;
            dgvPresentaciones.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPresentaciones.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle2.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle2.SelectionBackColor = Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvPresentaciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvPresentaciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPresentaciones.Columns.AddRange(new DataGridViewColumn[] { IdPresentacion, NombrePresentacion, dataGridViewTextBoxColumn4, EstadoPresentacion });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle3.Padding = new Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvPresentaciones.DefaultCellStyle = dataGridViewCellStyle3;
            dgvPresentaciones.Dock = DockStyle.Fill;
            dgvPresentaciones.EnableHeadersVisualStyles = false;
            dgvPresentaciones.GridColor = Color.FromArgb(189, 215, 238);
            dgvPresentaciones.Location = new Point(0, 0);
            dgvPresentaciones.Name = "dgvPresentaciones";
            dgvPresentaciones.ReadOnly = true;
            dgvPresentaciones.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle4.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(102, 102, 102);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvPresentaciones.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvPresentaciones.RowHeadersWidth = 30;
            dgvPresentaciones.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvPresentaciones.RowTemplate.Height = 50;
            dgvPresentaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPresentaciones.Size = new Size(648, 264);
            dgvPresentaciones.TabIndex = 1;
            dgvPresentaciones.CellDoubleClick += dgvPresentaciones_CellDoubleClick;
            dgvPresentaciones.SelectionChanged += dgvPresentaciones_SelectionChanged;
            // 
            // IdPresentacion
            // 
            IdPresentacion.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            IdPresentacion.DataPropertyName = "IdPresentacionProducto";
            IdPresentacion.HeaderText = "Código";
            IdPresentacion.Name = "IdPresentacion";
            IdPresentacion.ReadOnly = true;
            IdPresentacion.Width = 89;
            // 
            // NombrePresentacion
            // 
            NombrePresentacion.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            NombrePresentacion.DataPropertyName = "NombrePresentacion";
            NombrePresentacion.HeaderText = "Presentacion";
            NombrePresentacion.Name = "NombrePresentacion";
            NombrePresentacion.ReadOnly = true;
            NombrePresentacion.Width = 131;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn4.DataPropertyName = "DetallePresentacion";
            dataGridViewTextBoxColumn4.FillWeight = 120F;
            dataGridViewTextBoxColumn4.HeaderText = "Detalles";
            dataGridViewTextBoxColumn4.MinimumWidth = 100;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // EstadoPresentacion
            // 
            EstadoPresentacion.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            EstadoPresentacion.DataPropertyName = "EstadoPresentacion";
            EstadoPresentacion.HeaderText = "Estado";
            EstadoPresentacion.Name = "EstadoPresentacion";
            EstadoPresentacion.ReadOnly = true;
            EstadoPresentacion.Resizable = DataGridViewTriState.True;
            EstadoPresentacion.SortMode = DataGridViewColumnSortMode.Automatic;
            EstadoPresentacion.Width = 89;
            // 
            // gbxEstado
            // 
            gbxEstado.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbxEstado.Controls.Add(rbMostrarDeshabilitados);
            gbxEstado.Controls.Add(rbMostrarTodos);
            gbxEstado.Controls.Add(rbMostrarHabilitados);
            gbxEstado.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbxEstado.ForeColor = Color.DimGray;
            gbxEstado.Location = new Point(12, 60);
            gbxEstado.Name = "gbxEstado";
            gbxEstado.Size = new Size(678, 53);
            gbxEstado.TabIndex = 45;
            gbxEstado.TabStop = false;
            gbxEstado.Text = "Filtros de Búsqueda:";
            // 
            // rbMostrarDeshabilitados
            // 
            rbMostrarDeshabilitados.AutoSize = true;
            rbMostrarDeshabilitados.Location = new Point(122, 22);
            rbMostrarDeshabilitados.Name = "rbMostrarDeshabilitados";
            rbMostrarDeshabilitados.Size = new Size(121, 22);
            rbMostrarDeshabilitados.TabIndex = 30;
            rbMostrarDeshabilitados.Text = "Deshabilitados";
            rbMostrarDeshabilitados.UseVisualStyleBackColor = true;
            // 
            // rbMostrarTodos
            // 
            rbMostrarTodos.AutoSize = true;
            rbMostrarTodos.Location = new Point(249, 22);
            rbMostrarTodos.Name = "rbMostrarTodos";
            rbMostrarTodos.Size = new Size(120, 22);
            rbMostrarTodos.TabIndex = 29;
            rbMostrarTodos.Text = "Mostrar Todos";
            rbMostrarTodos.UseVisualStyleBackColor = true;
            // 
            // rbMostrarHabilitados
            // 
            rbMostrarHabilitados.AutoSize = true;
            rbMostrarHabilitados.Checked = true;
            rbMostrarHabilitados.Location = new Point(15, 21);
            rbMostrarHabilitados.Name = "rbMostrarHabilitados";
            rbMostrarHabilitados.Size = new Size(101, 22);
            rbMostrarHabilitados.TabIndex = 28;
            rbMostrarHabilitados.TabStop = true;
            rbMostrarHabilitados.Text = "Habilitados";
            rbMostrarHabilitados.UseVisualStyleBackColor = true;
            // 
            // btnAgregarPresentacion
            // 
            btnAgregarPresentacion.BackColor = Color.FromArgb(149, 195, 172);
            btnAgregarPresentacion.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregarPresentacion.ForeColor = SystemColors.ButtonFace;
            btnAgregarPresentacion.Location = new Point(3, 3);
            btnAgregarPresentacion.Name = "btnAgregarPresentacion";
            btnAgregarPresentacion.Size = new Size(180, 44);
            btnAgregarPresentacion.TabIndex = 35;
            btnAgregarPresentacion.Text = "Agregar Presentación";
            btnAgregarPresentacion.UseVisualStyleBackColor = false;
            btnAgregarPresentacion.Click += btnAgregarPresentacion_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            flowLayoutPanel1.Controls.Add(btnAgregarPresentacion);
            flowLayoutPanel1.Controls.Add(btnModificarPresentacion);
            flowLayoutPanel1.Controls.Add(btnSeleccionarPresentacion);
            flowLayoutPanel1.Controls.Add(btnSalir);
            flowLayoutPanel1.Location = new Point(12, 416);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(677, 51);
            flowLayoutPanel1.TabIndex = 44;
            // 
            // btnModificarPresentacion
            // 
            btnModificarPresentacion.BackColor = Color.FromArgb(148, 168, 187);
            btnModificarPresentacion.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnModificarPresentacion.ForeColor = SystemColors.ButtonFace;
            btnModificarPresentacion.Location = new Point(189, 3);
            btnModificarPresentacion.Name = "btnModificarPresentacion";
            btnModificarPresentacion.Size = new Size(149, 44);
            btnModificarPresentacion.TabIndex = 36;
            btnModificarPresentacion.Text = "Ver Presentación";
            btnModificarPresentacion.UseVisualStyleBackColor = false;
            btnModificarPresentacion.Click += btnModificarPresentacion_Click;
            // 
            // btnSeleccionarPresentacion
            // 
            btnSeleccionarPresentacion.BackColor = Color.FromArgb(149, 195, 172);
            btnSeleccionarPresentacion.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSeleccionarPresentacion.ForeColor = SystemColors.ButtonFace;
            btnSeleccionarPresentacion.Location = new Point(344, 3);
            btnSeleccionarPresentacion.Name = "btnSeleccionarPresentacion";
            btnSeleccionarPresentacion.Size = new Size(200, 44);
            btnSeleccionarPresentacion.TabIndex = 38;
            btnSeleccionarPresentacion.Text = "Seleccionar Presentación";
            btnSeleccionarPresentacion.UseVisualStyleBackColor = false;
            btnSeleccionarPresentacion.Click += btnSeleccionarPresentacion_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(148, 168, 187);
            btnSalir.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = SystemColors.ButtonFace;
            btnSalir.Location = new Point(550, 3);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(91, 44);
            btnSalir.TabIndex = 37;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(189, 215, 238);
            panel1.Controls.Add(panelCarrito);
            panel1.Location = new Point(12, 119);
            panel1.Name = "panel1";
            panel1.Size = new Size(678, 291);
            panel1.TabIndex = 43;
            // 
            // pnlLimpiarFiltros
            // 
            pnlLimpiarFiltros.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlLimpiarFiltros.BackColor = Color.FromArgb(189, 215, 238);
            pnlLimpiarFiltros.Controls.Add(btnLimpiarFiltros);
            pnlLimpiarFiltros.Controls.Add(pbxClean);
            pnlLimpiarFiltros.Location = new Point(523, 11);
            pnlLimpiarFiltros.Name = "pnlLimpiarFiltros";
            pnlLimpiarFiltros.Size = new Size(166, 43);
            pnlLimpiarFiltros.TabIndex = 47;
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
            // lstSugerencias
            // 
            lstSugerencias.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lstSugerencias.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstSugerencias.ForeColor = Color.DimGray;
            lstSugerencias.FormattingEnabled = true;
            lstSugerencias.ItemHeight = 18;
            lstSugerencias.Location = new Point(30, 44);
            lstSugerencias.MinimumSize = new Size(243, 22);
            lstSugerencias.Name = "lstSugerencias";
            lstSugerencias.Size = new Size(402, 22);
            lstSugerencias.TabIndex = 48;
            lstSugerencias.Visible = false;
            lstSugerencias.MouseClick += lstSugerencias_MouseClick;
            lstSugerencias.KeyDown += lstSugerencias_KeyDown;
            // 
            // frmPresentaciones
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            ClientSize = new Size(702, 476);
            Controls.Add(lstSugerencias);
            Controls.Add(pnlLimpiarFiltros);
            Controls.Add(panelBusqueda);
            Controls.Add(gbxEstado);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(700, 475);
            Name = "frmPresentaciones";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Presentaciones";
            FormClosing += frmPresentaciones_FormClosing;
            Load += frmPresentaciones_Load;
            panelBusqueda.ResumeLayout(false);
            panelBusqueda.PerformLayout();
            panelCarrito.ResumeLayout(false);
            panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPresentaciones).EndInit();
            gbxEstado.ResumeLayout(false);
            gbxEstado.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            pnlLimpiarFiltros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbxClean).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panelBusqueda;
        private TextBox txtBuscar;
        private Button btnbuscar;
        private Panel panelCarrito;
        private Panel panel10;
        private DataGridView dgvPresentaciones;
        private GroupBox gbxEstado;
        private RadioButton rbMostrarDeshabilitados;
        private RadioButton rbMostrarTodos;
        private RadioButton rbMostrarHabilitados;
        private Button btnAgregarPresentacion;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnModificarPresentacion;
        private Button btnSeleccionarPresentacion;
        private Button btnSalir;
        private Panel panel1;
        private DataGridViewTextBoxColumn IdPresentacion;
        private DataGridViewTextBoxColumn NombrePresentacion;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewCheckBoxColumn EstadoPresentacion;
        private Panel pnlLimpiarFiltros;
        private Button btnLimpiarFiltros;
        private PictureBox pbxClean;
        private ListBox lstSugerencias;
    }
}