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
            panelBusqueda.SuspendLayout();
            panelCarrito.SuspendLayout();
            panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPresentaciones).BeginInit();
            gbxEstado.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelBusqueda
            // 
            panelBusqueda.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelBusqueda.BackColor = Color.FromArgb(189, 215, 238);
            panelBusqueda.Controls.Add(txtBuscar);
            panelBusqueda.Controls.Add(btnbuscar);
            panelBusqueda.Location = new Point(15, 14);
            panelBusqueda.Margin = new Padding(4, 4, 4, 4);
            panelBusqueda.MaximumSize = new Size(875, 54);
            panelBusqueda.MinimumSize = new Size(412, 54);
            panelBusqueda.Name = "panelBusqueda";
            panelBusqueda.Size = new Size(609, 54);
            panelBusqueda.TabIndex = 46;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtBuscar.BorderStyle = BorderStyle.None;
            txtBuscar.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(22, 15);
            txtBuscar.Margin = new Padding(4, 4, 4, 4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar Presentaciones...";
            txtBuscar.Size = new Size(492, 24);
            txtBuscar.TabIndex = 1;
            // 
            // btnbuscar
            // 
            btnbuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnbuscar.BackColor = Color.FromArgb(168, 191, 212);
            btnbuscar.BackgroundImage = (Image)resources.GetObject("btnbuscar.BackgroundImage");
            btnbuscar.BackgroundImageLayout = ImageLayout.Zoom;
            btnbuscar.FlatAppearance.BorderSize = 0;
            btnbuscar.FlatStyle = FlatStyle.Flat;
            btnbuscar.Location = new Point(522, 15);
            btnbuscar.Margin = new Padding(4, 4, 4, 4);
            btnbuscar.Name = "btnbuscar";
            btnbuscar.Size = new Size(60, 25);
            btnbuscar.TabIndex = 0;
            btnbuscar.UseVisualStyleBackColor = false;
            // 
            // panelCarrito
            // 
            panelCarrito.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelCarrito.BackColor = Color.FromArgb(189, 215, 238);
            panelCarrito.Controls.Add(panel10);
            panelCarrito.Location = new Point(19, 18);
            panelCarrito.Margin = new Padding(4, 4, 4, 4);
            panelCarrito.Name = "panelCarrito";
            panelCarrito.Size = new Size(810, 330);
            panelCarrito.TabIndex = 13;
            // 
            // panel10
            // 
            panel10.AutoScroll = true;
            panel10.Controls.Add(dgvPresentaciones);
            panel10.Dock = DockStyle.Fill;
            panel10.Location = new Point(0, 0);
            panel10.Margin = new Padding(4, 4, 4, 4);
            panel10.Name = "panel10";
            panel10.Size = new Size(810, 330);
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
            dgvPresentaciones.Margin = new Padding(4, 4, 4, 4);
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
            dgvPresentaciones.Size = new Size(810, 330);
            dgvPresentaciones.TabIndex = 1;
            dgvPresentaciones.CellDoubleClick += dgvPresentaciones_CellDoubleClick;
            // 
            // IdPresentacion
            // 
            IdPresentacion.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            IdPresentacion.DataPropertyName = "IdPresentacionProducto";
            IdPresentacion.HeaderText = "Código";
            IdPresentacion.MinimumWidth = 6;
            IdPresentacion.Name = "IdPresentacion";
            IdPresentacion.ReadOnly = true;
            IdPresentacion.Width = 106;
            // 
            // NombrePresentacion
            // 
            NombrePresentacion.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            NombrePresentacion.DataPropertyName = "NombrePresentacion";
            NombrePresentacion.HeaderText = "Presentacion";
            NombrePresentacion.MinimumWidth = 6;
            NombrePresentacion.Name = "NombrePresentacion";
            NombrePresentacion.ReadOnly = true;
            NombrePresentacion.Width = 159;
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
            EstadoPresentacion.MinimumWidth = 6;
            EstadoPresentacion.Name = "EstadoPresentacion";
            EstadoPresentacion.ReadOnly = true;
            EstadoPresentacion.Resizable = DataGridViewTriState.True;
            EstadoPresentacion.SortMode = DataGridViewColumnSortMode.Automatic;
            EstadoPresentacion.Width = 105;
            // 
            // gbxEstado
            // 
            gbxEstado.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbxEstado.Controls.Add(rbMostrarDeshabilitados);
            gbxEstado.Controls.Add(rbMostrarTodos);
            gbxEstado.Controls.Add(rbMostrarHabilitados);
            gbxEstado.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbxEstado.ForeColor = Color.DimGray;
            gbxEstado.Location = new Point(15, 75);
            gbxEstado.Margin = new Padding(4, 4, 4, 4);
            gbxEstado.Name = "gbxEstado";
            gbxEstado.Padding = new Padding(4, 4, 4, 4);
            gbxEstado.Size = new Size(848, 66);
            gbxEstado.TabIndex = 45;
            gbxEstado.TabStop = false;
            gbxEstado.Text = "Filtros de Búsqueda:";
            // 
            // rbMostrarDeshabilitados
            // 
            rbMostrarDeshabilitados.AutoSize = true;
            rbMostrarDeshabilitados.Location = new Point(152, 28);
            rbMostrarDeshabilitados.Margin = new Padding(4, 4, 4, 4);
            rbMostrarDeshabilitados.Name = "rbMostrarDeshabilitados";
            rbMostrarDeshabilitados.Size = new Size(149, 27);
            rbMostrarDeshabilitados.TabIndex = 30;
            rbMostrarDeshabilitados.Text = "Deshabilitados";
            rbMostrarDeshabilitados.UseVisualStyleBackColor = true;
            rbMostrarDeshabilitados.CheckedChanged += rbMostrarDeshabilitados_CheckedChanged;
            // 
            // rbMostrarTodos
            // 
            rbMostrarTodos.AutoSize = true;
            rbMostrarTodos.Location = new Point(311, 28);
            rbMostrarTodos.Margin = new Padding(4, 4, 4, 4);
            rbMostrarTodos.Name = "rbMostrarTodos";
            rbMostrarTodos.Size = new Size(150, 27);
            rbMostrarTodos.TabIndex = 29;
            rbMostrarTodos.Text = "Mostrar Todos";
            rbMostrarTodos.UseVisualStyleBackColor = true;
            rbMostrarTodos.CheckedChanged += rbMostrarTodos_CheckedChanged;
            // 
            // rbMostrarHabilitados
            // 
            rbMostrarHabilitados.AutoSize = true;
            rbMostrarHabilitados.Checked = true;
            rbMostrarHabilitados.Location = new Point(19, 26);
            rbMostrarHabilitados.Margin = new Padding(4, 4, 4, 4);
            rbMostrarHabilitados.Name = "rbMostrarHabilitados";
            rbMostrarHabilitados.Size = new Size(124, 27);
            rbMostrarHabilitados.TabIndex = 28;
            rbMostrarHabilitados.TabStop = true;
            rbMostrarHabilitados.Text = "Habilitados";
            rbMostrarHabilitados.UseVisualStyleBackColor = true;
            rbMostrarHabilitados.CheckedChanged += rbMostrarHabilitados_CheckedChanged;
            // 
            // btnAgregarPresentacion
            // 
            btnAgregarPresentacion.BackColor = Color.FromArgb(149, 195, 172);
            btnAgregarPresentacion.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregarPresentacion.ForeColor = SystemColors.ButtonFace;
            btnAgregarPresentacion.Location = new Point(4, 4);
            btnAgregarPresentacion.Margin = new Padding(4, 4, 4, 4);
            btnAgregarPresentacion.Name = "btnAgregarPresentacion";
            btnAgregarPresentacion.Size = new Size(225, 55);
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
            flowLayoutPanel1.Location = new Point(15, 520);
            flowLayoutPanel1.Margin = new Padding(4, 4, 4, 4);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(846, 64);
            flowLayoutPanel1.TabIndex = 44;
            // 
            // btnModificarPresentacion
            // 
            btnModificarPresentacion.BackColor = Color.FromArgb(149, 195, 172);
            btnModificarPresentacion.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnModificarPresentacion.ForeColor = SystemColors.ButtonFace;
            btnModificarPresentacion.Location = new Point(237, 4);
            btnModificarPresentacion.Margin = new Padding(4, 4, 4, 4);
            btnModificarPresentacion.Name = "btnModificarPresentacion";
            btnModificarPresentacion.Size = new Size(225, 55);
            btnModificarPresentacion.TabIndex = 36;
            btnModificarPresentacion.Text = "Modificar Presentación";
            btnModificarPresentacion.UseVisualStyleBackColor = false;
            // 
            // btnSeleccionarPresentacion
            // 
            btnSeleccionarPresentacion.BackColor = Color.FromArgb(149, 195, 172);
            btnSeleccionarPresentacion.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSeleccionarPresentacion.ForeColor = SystemColors.ButtonFace;
            btnSeleccionarPresentacion.Location = new Point(470, 4);
            btnSeleccionarPresentacion.Margin = new Padding(4, 4, 4, 4);
            btnSeleccionarPresentacion.Name = "btnSeleccionarPresentacion";
            btnSeleccionarPresentacion.Size = new Size(250, 55);
            btnSeleccionarPresentacion.TabIndex = 38;
            btnSeleccionarPresentacion.Text = "Seleccionar Presentación";
            btnSeleccionarPresentacion.UseVisualStyleBackColor = false;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(148, 168, 187);
            btnSalir.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = SystemColors.ButtonFace;
            btnSalir.Location = new Point(728, 4);
            btnSalir.Margin = new Padding(4, 4, 4, 4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(114, 55);
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
            panel1.Location = new Point(15, 149);
            panel1.Margin = new Padding(4, 4, 4, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(848, 364);
            panel1.TabIndex = 43;
            // 
            // frmPresentaciones
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            ClientSize = new Size(878, 595);
            Controls.Add(panelBusqueda);
            Controls.Add(gbxEstado);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 4, 4, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(870, 582);
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
    }
}