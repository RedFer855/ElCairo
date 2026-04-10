namespace ModernMenuUI
{
    partial class frmEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpleado));
            dgvEmpleados = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            Categoria = new DataGridViewTextBoxColumn();
            PorcentajeGanancia = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewCheckBoxColumn();
            panel10 = new Panel();
            txtBuscar = new TextBox();
            panel1 = new Panel();
            btnbuscar = new Button();
            panelBusqueda = new Panel();
            rbMostrarDeshabilitados = new RadioButton();
            rbMostrarHabilitados = new RadioButton();
            rbMostrarTodos = new RadioButton();
            gbxFiltros = new GroupBox();
            btnSalir = new Button();
            btnAgregarEmpleado = new Button();
            btnEditarEmpleado = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnCrearUsuario = new Button();
            button4 = new Button();
            pnlLimpiarFiltros = new Panel();
            btnLimpiarFiltros = new Button();
            pbxClean = new PictureBox();
            lstSugerencias = new ListBox();
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).BeginInit();
            panel10.SuspendLayout();
            panel1.SuspendLayout();
            panelBusqueda.SuspendLayout();
            gbxFiltros.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            pnlLimpiarFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxClean).BeginInit();
            SuspendLayout();
            // 
            // dgvEmpleados
            // 
            dgvEmpleados.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dgvEmpleados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmpleados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvEmpleados.BackgroundColor = Color.FromArgb(189, 215, 238);
            dgvEmpleados.BorderStyle = BorderStyle.None;
            dgvEmpleados.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvEmpleados.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle2.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvEmpleados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvEmpleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmpleados.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, Categoria, PorcentajeGanancia, Email, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn3 });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle4.Padding = new Padding(5);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvEmpleados.DefaultCellStyle = dataGridViewCellStyle4;
            dgvEmpleados.Dock = DockStyle.Fill;
            dgvEmpleados.EnableHeadersVisualStyles = false;
            dgvEmpleados.GridColor = Color.FromArgb(189, 215, 238);
            dgvEmpleados.Location = new Point(0, 0);
            dgvEmpleados.Margin = new Padding(4);
            dgvEmpleados.Name = "dgvEmpleados";
            dgvEmpleados.ReadOnly = true;
            dgvEmpleados.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle5.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(102, 102, 102);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvEmpleados.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvEmpleados.RowHeadersWidth = 30;
            dgvEmpleados.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvEmpleados.RowTemplate.Height = 50;
            dgvEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmpleados.Size = new Size(885, 500);
            dgvEmpleados.TabIndex = 1;
            dgvEmpleados.SelectionChanged += dgvEmpleados_SelectionChanged;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewTextBoxColumn1.DataPropertyName = "DniEmpleado";
            dataGridViewCellStyle3.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.Padding = new Padding(0, 1, 0, 0);
            dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewTextBoxColumn1.FillWeight = 60F;
            dataGridViewTextBoxColumn1.HeaderText = "DNI";
            dataGridViewTextBoxColumn1.MinimumWidth = 45;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Width = 81;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewTextBoxColumn2.DataPropertyName = "NombreEmpleado";
            dataGridViewTextBoxColumn2.FillWeight = 35.1780434F;
            dataGridViewTextBoxColumn2.HeaderText = "NombreEmpleado";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Width = 201;
            // 
            // Categoria
            // 
            Categoria.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Categoria.DataPropertyName = "ApellidoEmpleado";
            Categoria.FillWeight = 40.203476F;
            Categoria.HeaderText = "Apellido";
            Categoria.MinimumWidth = 6;
            Categoria.Name = "Categoria";
            Categoria.ReadOnly = true;
            Categoria.Width = 119;
            // 
            // PorcentajeGanancia
            // 
            PorcentajeGanancia.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            PorcentajeGanancia.DataPropertyName = "TelefonoEmpleado";
            PorcentajeGanancia.FillWeight = 40.203476F;
            PorcentajeGanancia.HeaderText = "Teléfono";
            PorcentajeGanancia.MinimumWidth = 6;
            PorcentajeGanancia.Name = "PorcentajeGanancia";
            PorcentajeGanancia.ReadOnly = true;
            PorcentajeGanancia.Width = 121;
            // 
            // Email
            // 
            Email.DataPropertyName = "EmailEmpleado";
            Email.FillWeight = 40.203476F;
            Email.HeaderText = "Correo";
            Email.MinimumWidth = 6;
            Email.Name = "Email";
            Email.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.DataPropertyName = "DireccionEmpleado";
            dataGridViewTextBoxColumn4.FillWeight = 70F;
            dataGridViewTextBoxColumn4.HeaderText = "Dirección";
            dataGridViewTextBoxColumn4.MinimumWidth = 20;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewTextBoxColumn3.DataPropertyName = "EstadoEmpleado";
            dataGridViewTextBoxColumn3.FillWeight = 40.203476F;
            dataGridViewTextBoxColumn3.HeaderText = "Estado";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn3.Resizable = DataGridViewTriState.True;
            dataGridViewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridViewTextBoxColumn3.Width = 105;
            // 
            // panel10
            // 
            panel10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel10.AutoScroll = true;
            panel10.Controls.Add(dgvEmpleados);
            panel10.Location = new Point(22, 16);
            panel10.Margin = new Padding(4);
            panel10.Name = "panel10";
            panel10.Size = new Size(885, 500);
            panel10.TabIndex = 17;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.BorderStyle = BorderStyle.None;
            txtBuscar.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(22, 15);
            txtBuscar.Margin = new Padding(4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar Empleados...";
            txtBuscar.Size = new Size(478, 24);
            txtBuscar.TabIndex = 1;
            txtBuscar.KeyDown += txtBuscar_KeyDown;
            txtBuscar.KeyUp += txtBuscar_KeyUp;
            txtBuscar.Leave += txtBuscar_Leave;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(189, 215, 238);
            panel1.Controls.Add(panel10);
            panel1.Location = new Point(15, 161);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(928, 534);
            panel1.TabIndex = 45;
            // 
            // btnbuscar
            // 
            btnbuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnbuscar.BackColor = Color.FromArgb(168, 191, 212);
            btnbuscar.BackgroundImage = (Image)resources.GetObject("btnbuscar.BackgroundImage");
            btnbuscar.BackgroundImageLayout = ImageLayout.Zoom;
            btnbuscar.FlatAppearance.BorderSize = 0;
            btnbuscar.FlatStyle = FlatStyle.Flat;
            btnbuscar.Location = new Point(508, 15);
            btnbuscar.Margin = new Padding(4);
            btnbuscar.Name = "btnbuscar";
            btnbuscar.Size = new Size(60, 25);
            btnbuscar.TabIndex = 0;
            btnbuscar.UseVisualStyleBackColor = false;
            btnbuscar.Visible = false;
            btnbuscar.Click += btnBuscar_Click;
            // 
            // panelBusqueda
            // 
            panelBusqueda.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelBusqueda.BackColor = Color.FromArgb(189, 215, 238);
            panelBusqueda.Controls.Add(txtBuscar);
            panelBusqueda.Controls.Add(btnbuscar);
            panelBusqueda.Location = new Point(15, 15);
            panelBusqueda.Margin = new Padding(4);
            panelBusqueda.Name = "panelBusqueda";
            panelBusqueda.Size = new Size(586, 54);
            panelBusqueda.TabIndex = 46;
            // 
            // rbMostrarDeshabilitados
            // 
            rbMostrarDeshabilitados.AutoSize = true;
            rbMostrarDeshabilitados.Location = new Point(156, 26);
            rbMostrarDeshabilitados.Margin = new Padding(4);
            rbMostrarDeshabilitados.Name = "rbMostrarDeshabilitados";
            rbMostrarDeshabilitados.Size = new Size(149, 27);
            rbMostrarDeshabilitados.TabIndex = 30;
            rbMostrarDeshabilitados.Text = "Deshabilitados";
            rbMostrarDeshabilitados.UseVisualStyleBackColor = true;
            // 
            // rbMostrarHabilitados
            // 
            rbMostrarHabilitados.AutoSize = true;
            rbMostrarHabilitados.Checked = true;
            rbMostrarHabilitados.Location = new Point(22, 26);
            rbMostrarHabilitados.Margin = new Padding(4);
            rbMostrarHabilitados.Name = "rbMostrarHabilitados";
            rbMostrarHabilitados.Size = new Size(124, 27);
            rbMostrarHabilitados.TabIndex = 29;
            rbMostrarHabilitados.TabStop = true;
            rbMostrarHabilitados.Text = "Habilitados";
            rbMostrarHabilitados.UseVisualStyleBackColor = true;
            rbMostrarHabilitados.CheckedChanged += rbMostrarHabilitados_CheckedChanged;
            // 
            // rbMostrarTodos
            // 
            rbMostrarTodos.AutoSize = true;
            rbMostrarTodos.Location = new Point(315, 26);
            rbMostrarTodos.Margin = new Padding(4);
            rbMostrarTodos.Name = "rbMostrarTodos";
            rbMostrarTodos.Size = new Size(150, 27);
            rbMostrarTodos.TabIndex = 28;
            rbMostrarTodos.Text = "Mostrar Todos";
            rbMostrarTodos.UseVisualStyleBackColor = true;
            // 
            // gbxFiltros
            // 
            gbxFiltros.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbxFiltros.Controls.Add(rbMostrarDeshabilitados);
            gbxFiltros.Controls.Add(rbMostrarHabilitados);
            gbxFiltros.Controls.Add(rbMostrarTodos);
            gbxFiltros.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbxFiltros.ForeColor = SystemColors.ControlDarkDark;
            gbxFiltros.Location = new Point(15, 84);
            gbxFiltros.Margin = new Padding(4);
            gbxFiltros.Name = "gbxFiltros";
            gbxFiltros.Padding = new Padding(4);
            gbxFiltros.Size = new Size(928, 66);
            gbxFiltros.TabIndex = 47;
            gbxFiltros.TabStop = false;
            gbxFiltros.Text = "Filtro";
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSalir.BackColor = Color.FromArgb(148, 168, 187);
            btnSalir.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.White;
            btnSalir.ImageAlign = ContentAlignment.TopCenter;
            btnSalir.Location = new Point(275, 4);
            btnSalir.Margin = new Padding(4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(156, 54);
            btnSalir.TabIndex = 18;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnAgregarEmpleado
            // 
            btnAgregarEmpleado.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAgregarEmpleado.BackColor = Color.FromArgb(149, 195, 172);
            btnAgregarEmpleado.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregarEmpleado.ForeColor = SystemColors.ButtonFace;
            btnAgregarEmpleado.Location = new Point(4, 4);
            btnAgregarEmpleado.Margin = new Padding(4);
            btnAgregarEmpleado.Name = "btnAgregarEmpleado";
            btnAgregarEmpleado.Size = new Size(263, 54);
            btnAgregarEmpleado.TabIndex = 22;
            btnAgregarEmpleado.Text = "Agregar Empleado";
            btnAgregarEmpleado.UseVisualStyleBackColor = false;
            btnAgregarEmpleado.Click += btnAgregarEmpleado_Click;
            // 
            // btnEditarEmpleado
            // 
            btnEditarEmpleado.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEditarEmpleado.BackColor = Color.FromArgb(189, 215, 238);
            btnEditarEmpleado.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEditarEmpleado.ForeColor = Color.FromArgb(87, 99, 110);
            btnEditarEmpleado.Location = new Point(4, 66);
            btnEditarEmpleado.Margin = new Padding(4);
            btnEditarEmpleado.Name = "btnEditarEmpleado";
            btnEditarEmpleado.Size = new Size(263, 55);
            btnEditarEmpleado.TabIndex = 20;
            btnEditarEmpleado.Text = "Editar Empleado";
            btnEditarEmpleado.UseVisualStyleBackColor = false;
            btnEditarEmpleado.Click += btnEditarEmpleado_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 37.5F));
            tableLayoutPanel1.Controls.Add(btnCrearUsuario, 1, 1);
            tableLayoutPanel1.Controls.Add(btnSalir, 1, 0);
            tableLayoutPanel1.Controls.Add(btnAgregarEmpleado, 0, 0);
            tableLayoutPanel1.Controls.Add(btnEditarEmpleado, 0, 1);
            tableLayoutPanel1.Location = new Point(15, 709);
            tableLayoutPanel1.Margin = new Padding(4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(435, 125);
            tableLayoutPanel1.TabIndex = 48;
            // 
            // btnCrearUsuario
            // 
            btnCrearUsuario.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCrearUsuario.BackColor = Color.FromArgb(149, 195, 172);
            btnCrearUsuario.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCrearUsuario.ForeColor = SystemColors.ButtonFace;
            btnCrearUsuario.Location = new Point(275, 66);
            btnCrearUsuario.Margin = new Padding(4);
            btnCrearUsuario.Name = "btnCrearUsuario";
            btnCrearUsuario.Size = new Size(156, 55);
            btnCrearUsuario.TabIndex = 23;
            btnCrearUsuario.Text = "Crear Usuario";
            btnCrearUsuario.UseVisualStyleBackColor = false;
            btnCrearUsuario.Click += btnCrearUsuario_Click;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button4.Location = new Point(642, 122);
            button4.Margin = new Padding(4);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 44;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = true;
            // 
            // pnlLimpiarFiltros
            // 
            pnlLimpiarFiltros.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlLimpiarFiltros.BackColor = Color.FromArgb(189, 215, 238);
            pnlLimpiarFiltros.Controls.Add(btnLimpiarFiltros);
            pnlLimpiarFiltros.Controls.Add(pbxClean);
            pnlLimpiarFiltros.Location = new Point(735, 15);
            pnlLimpiarFiltros.Margin = new Padding(4);
            pnlLimpiarFiltros.Name = "pnlLimpiarFiltros";
            pnlLimpiarFiltros.Size = new Size(208, 54);
            pnlLimpiarFiltros.TabIndex = 49;
            pnlLimpiarFiltros.Visible = false;
            // 
            // btnLimpiarFiltros
            // 
            btnLimpiarFiltros.BackColor = Color.FromArgb(148, 168, 187);
            btnLimpiarFiltros.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLimpiarFiltros.ForeColor = Color.White;
            btnLimpiarFiltros.ImageAlign = ContentAlignment.TopCenter;
            btnLimpiarFiltros.Location = new Point(4, 6);
            btnLimpiarFiltros.Margin = new Padding(4);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(146, 40);
            btnLimpiarFiltros.TabIndex = 34;
            btnLimpiarFiltros.Text = "Limpiar Filtros";
            btnLimpiarFiltros.UseVisualStyleBackColor = false;
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;
            // 
            // pbxClean
            // 
            pbxClean.Image = (Image)resources.GetObject("pbxClean.Image");
            pbxClean.Location = new Point(151, 10);
            pbxClean.Margin = new Padding(4);
            pbxClean.Name = "pbxClean";
            pbxClean.Size = new Size(56, 30);
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
            lstSugerencias.ItemHeight = 23;
            lstSugerencias.Location = new Point(38, 56);
            lstSugerencias.Margin = new Padding(4);
            lstSugerencias.MinimumSize = new Size(303, 26);
            lstSugerencias.Name = "lstSugerencias";
            lstSugerencias.Size = new Size(476, 27);
            lstSugerencias.TabIndex = 59;
            lstSugerencias.Visible = false;
            lstSugerencias.MouseClick += lstSugerencias_MouseClick;
            lstSugerencias.KeyDown += lstSugerencias_KeyDown;
            lstSugerencias.KeyUp += txtBuscar_KeyUp;
            // 
            // frmEmpleado
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            ClientSize = new Size(958, 849);
            Controls.Add(lstSugerencias);
            Controls.Add(pnlLimpiarFiltros);
            Controls.Add(panel1);
            Controls.Add(panelBusqueda);
            Controls.Add(gbxFiltros);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(button4);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "frmEmpleado";
            Text = "frmEmpleado";
            FormClosing += frmEmpleado_FormClosing;
            Load += frmEmpleado_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).EndInit();
            panel10.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panelBusqueda.ResumeLayout(false);
            panelBusqueda.PerformLayout();
            gbxFiltros.ResumeLayout(false);
            gbxFiltros.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            pnlLimpiarFiltros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbxClean).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dgvEmpleados;
        private Panel panel10;
        private TextBox txtBuscar;
        private Panel panel1;
        private Button btnbuscar;
        private Panel panelBusqueda;
        private RadioButton rbMostrarDeshabilitados;
        private RadioButton rbMostrarHabilitados;
        private RadioButton rbMostrarTodos;
        private GroupBox gbxFiltros;
        private Button btnSalir;
        private Button btnAgregarEmpleado;
        private Button btnEditarEmpleado;
        private TableLayoutPanel tableLayoutPanel1;
        private Button button4;
        private Button btnCrearUsuario;
        private Panel pnlLimpiarFiltros;
        private Button btnLimpiarFiltros;
        private PictureBox pbxClean;
        private ListBox lstSugerencias;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn Categoria;
        private DataGridViewTextBoxColumn PorcentajeGanancia;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewCheckBoxColumn dataGridViewTextBoxColumn3;
    }
}