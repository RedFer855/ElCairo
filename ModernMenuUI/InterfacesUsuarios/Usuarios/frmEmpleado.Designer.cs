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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpleado));
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dgvEmpleados = new DataGridView();
            panel10 = new Panel();
            txtBuscar = new TextBox();
            panel1 = new Panel();
            btnbuscar = new Button();
            panelBusqueda = new Panel();
            rdbDeshabilitados = new RadioButton();
            rdbHabilitados = new RadioButton();
            rdbTodos = new RadioButton();
            groupBox1 = new GroupBox();
            btnSalir = new Button();
            btnAgregarEmpleado = new Button();
            btnNuevo = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            button4 = new Button();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            Categoria = new DataGridViewTextBoxColumn();
            PorcentajeGanancia = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).BeginInit();
            panel10.SuspendLayout();
            panel1.SuspendLayout();
            panelBusqueda.SuspendLayout();
            groupBox1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
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
            dgvEmpleados.Size = new Size(708, 400);
            dgvEmpleados.TabIndex = 1;
            dgvEmpleados.CellContentClick += dgvEmpleados_CellContentClick;
            dgvEmpleados.SelectionChanged += dgvEmpleados_SelectionChanged;
            // 
            // panel10
            // 
            panel10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel10.AutoScroll = true;
            panel10.Controls.Add(dgvEmpleados);
            panel10.Location = new Point(18, 13);
            panel10.Name = "panel10";
            panel10.Size = new Size(708, 400);
            panel10.TabIndex = 17;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.BorderStyle = BorderStyle.None;
            txtBuscar.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(18, 12);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar Usuarios...";
            txtBuscar.Size = new Size(631, 20);
            txtBuscar.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(189, 215, 238);
            panel1.Controls.Add(panel10);
            panel1.Location = new Point(12, 129);
            panel1.Name = "panel1";
            panel1.Size = new Size(742, 427);
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
            btnbuscar.Location = new Point(678, 12);
            btnbuscar.Name = "btnbuscar";
            btnbuscar.Size = new Size(48, 20);
            btnbuscar.TabIndex = 0;
            btnbuscar.UseVisualStyleBackColor = false;
            // 
            // panelBusqueda
            // 
            panelBusqueda.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelBusqueda.BackColor = Color.FromArgb(189, 215, 238);
            panelBusqueda.Controls.Add(txtBuscar);
            panelBusqueda.Controls.Add(btnbuscar);
            panelBusqueda.Location = new Point(12, 12);
            panelBusqueda.Name = "panelBusqueda";
            panelBusqueda.Size = new Size(742, 43);
            panelBusqueda.TabIndex = 46;
            // 
            // rdbDeshabilitados
            // 
            rdbDeshabilitados.AutoSize = true;
            rdbDeshabilitados.Location = new Point(341, 21);
            rdbDeshabilitados.Name = "rdbDeshabilitados";
            rdbDeshabilitados.Size = new Size(178, 22);
            rdbDeshabilitados.TabIndex = 30;
            rdbDeshabilitados.Text = "Mostrar Deshabilitados";
            rdbDeshabilitados.UseVisualStyleBackColor = true;
            // 
            // rdbHabilitados
            // 
            rdbHabilitados.AutoSize = true;
            rdbHabilitados.Checked = true;
            rdbHabilitados.Location = new Point(158, 21);
            rdbHabilitados.Name = "rdbHabilitados";
            rdbHabilitados.Size = new Size(156, 22);
            rdbHabilitados.TabIndex = 29;
            rdbHabilitados.TabStop = true;
            rdbHabilitados.Text = "Mostrar Habilitados";
            rdbHabilitados.UseVisualStyleBackColor = true;
            // 
            // rdbTodos
            // 
            rdbTodos.AutoSize = true;
            rdbTodos.Location = new Point(18, 21);
            rdbTodos.Name = "rdbTodos";
            rdbTodos.Size = new Size(120, 22);
            rdbTodos.TabIndex = 28;
            rdbTodos.Text = "Mostrar Todos";
            rdbTodos.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(rdbDeshabilitados);
            groupBox1.Controls.Add(rdbHabilitados);
            groupBox1.Controls.Add(rdbTodos);
            groupBox1.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = SystemColors.ControlDarkDark;
            groupBox1.Location = new Point(12, 67);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(742, 53);
            groupBox1.TabIndex = 47;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtro";
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSalir.BackColor = Color.FromArgb(148, 168, 187);
            btnSalir.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.White;
            btnSalir.ImageAlign = ContentAlignment.TopCenter;
            btnSalir.Location = new Point(220, 3);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(125, 44);
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
            btnAgregarEmpleado.Location = new Point(3, 3);
            btnAgregarEmpleado.Name = "btnAgregarEmpleado";
            btnAgregarEmpleado.Size = new Size(211, 44);
            btnAgregarEmpleado.TabIndex = 22;
            btnAgregarEmpleado.Text = "Agregar Empleado";
            btnAgregarEmpleado.UseVisualStyleBackColor = false;
            btnAgregarEmpleado.Click += btnAgregarEmpleado_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnNuevo.BackColor = Color.FromArgb(189, 215, 238);
            btnNuevo.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNuevo.ForeColor = Color.FromArgb(87, 99, 110);
            btnNuevo.Location = new Point(3, 53);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(211, 44);
            btnNuevo.TabIndex = 20;
            btnNuevo.Text = "Editar Empleado";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 37.5F));
            tableLayoutPanel1.Controls.Add(btnSalir, 1, 0);
            tableLayoutPanel1.Controls.Add(btnAgregarEmpleado, 0, 0);
            tableLayoutPanel1.Controls.Add(btnNuevo, 0, 1);
            tableLayoutPanel1.Location = new Point(12, 567);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(348, 100);
            tableLayoutPanel1.TabIndex = 48;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button4.Location = new Point(514, 98);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 44;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewTextBoxColumn1.DataPropertyName = "Dni";
            dataGridViewCellStyle3.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.Padding = new Padding(0, 1, 0, 0);
            dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewTextBoxColumn1.FillWeight = 60F;
            dataGridViewTextBoxColumn1.HeaderText = "DNI";
            dataGridViewTextBoxColumn1.MinimumWidth = 45;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Width = 70;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewTextBoxColumn2.DataPropertyName = "Nombre";
            dataGridViewTextBoxColumn2.FillWeight = 35.1780434F;
            dataGridViewTextBoxColumn2.HeaderText = "Nombre";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Width = 96;
            // 
            // Categoria
            // 
            Categoria.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Categoria.DataPropertyName = "Apellido";
            Categoria.FillWeight = 40.203476F;
            Categoria.HeaderText = "Apellido";
            Categoria.Name = "Categoria";
            Categoria.ReadOnly = true;
            Categoria.Width = 99;
            // 
            // PorcentajeGanancia
            // 
            PorcentajeGanancia.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            PorcentajeGanancia.DataPropertyName = "Telefono";
            PorcentajeGanancia.FillWeight = 40.203476F;
            PorcentajeGanancia.HeaderText = "Teléfono";
            PorcentajeGanancia.Name = "PorcentajeGanancia";
            PorcentajeGanancia.ReadOnly = true;
            PorcentajeGanancia.Width = 101;
            // 
            // Email
            // 
            Email.DataPropertyName = "Email";
            Email.FillWeight = 40.203476F;
            Email.HeaderText = "Correo";
            Email.Name = "Email";
            Email.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.DataPropertyName = "Direccion";
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
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn3.Resizable = DataGridViewTriState.True;
            dataGridViewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridViewTextBoxColumn3.Width = 89;
            // 
            // frmEmpleado
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(766, 679);
            Controls.Add(panel1);
            Controls.Add(panelBusqueda);
            Controls.Add(groupBox1);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(button4);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmEmpleado";
            Text = "frmEmpleado";
            Load += FrmEmpleados_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).EndInit();
            panel10.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panelBusqueda.ResumeLayout(false);
            panelBusqueda.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dgvEmpleados;
        private Panel panel10;
        private TextBox txtBuscar;
        private Panel panel1;
        private Button btnbuscar;
        private Panel panelBusqueda;
        private RadioButton rdbDeshabilitados;
        private RadioButton rdbHabilitados;
        private RadioButton rdbTodos;
        private GroupBox groupBox1;
        private Button btnSalir;
        private Button btnAgregarEmpleado;
        private Button btnNuevo;
        private TableLayoutPanel tableLayoutPanel1;
        private Button button4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn Categoria;
        private DataGridViewTextBoxColumn PorcentajeGanancia;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewCheckBoxColumn dataGridViewTextBoxColumn3;
    }
}