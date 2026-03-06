namespace ModernMenuUI
{
    partial class frmUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuario));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            button4 = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnSalir = new Button();
            btnEditarUsuarios = new Button();
            groupBox1 = new GroupBox();
            rdbDeshabilitados = new RadioButton();
            rdbHabilitados = new RadioButton();
            rdbTodos = new RadioButton();
            panelBusqueda = new Panel();
            txtBuscar = new TextBox();
            btnbuscar = new Button();
            panel1 = new Panel();
            panel10 = new Panel();
            dgvUsuario = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            Categoria = new DataGridViewTextBoxColumn();
            EstadoUsuario = new DataGridViewCheckBoxColumn();
            tableLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            panelBusqueda.SuspendLayout();
            panel1.SuspendLayout();
            panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuario).BeginInit();
            SuspendLayout();
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button4.Location = new Point(656, 116);
            button4.Margin = new Padding(4);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 5;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 37.5F));
            tableLayoutPanel1.Controls.Add(btnSalir, 1, 0);
            tableLayoutPanel1.Controls.Add(btnEditarUsuarios, 0, 0);
            tableLayoutPanel1.Location = new Point(22, 702);
            tableLayoutPanel1.Margin = new Padding(4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(435, 62);
            tableLayoutPanel1.TabIndex = 43;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(148, 168, 187);
            btnSalir.Dock = DockStyle.Fill;
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
            btnSalir.Click += btnSalir_Click_1;
            // 
            // btnEditarUsuarios
            // 
            btnEditarUsuarios.BackColor = Color.FromArgb(189, 215, 238);
            btnEditarUsuarios.Dock = DockStyle.Fill;
            btnEditarUsuarios.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEditarUsuarios.ForeColor = Color.FromArgb(87, 99, 110);
            btnEditarUsuarios.Location = new Point(4, 4);
            btnEditarUsuarios.Margin = new Padding(4);
            btnEditarUsuarios.Name = "btnEditarUsuarios";
            btnEditarUsuarios.Size = new Size(263, 54);
            btnEditarUsuarios.TabIndex = 20;
            btnEditarUsuarios.Text = "Editar Usuario";
            btnEditarUsuarios.UseVisualStyleBackColor = false;
            btnEditarUsuarios.Click += btnEditarUsuarios_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(rdbDeshabilitados);
            groupBox1.Controls.Add(rdbHabilitados);
            groupBox1.Controls.Add(rdbTodos);
            groupBox1.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = SystemColors.ControlDarkDark;
            groupBox1.Location = new Point(22, 78);
            groupBox1.Margin = new Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4);
            groupBox1.Size = new Size(898, 66);
            groupBox1.TabIndex = 42;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtro";
            // 
            // rdbDeshabilitados
            // 
            rdbDeshabilitados.AutoSize = true;
            rdbDeshabilitados.Location = new Point(426, 26);
            rdbDeshabilitados.Margin = new Padding(4);
            rdbDeshabilitados.Name = "rdbDeshabilitados";
            rdbDeshabilitados.Size = new Size(220, 27);
            rdbDeshabilitados.TabIndex = 30;
            rdbDeshabilitados.Text = "Mostrar Deshabilitados";
            rdbDeshabilitados.UseVisualStyleBackColor = true;
            // 
            // rdbHabilitados
            // 
            rdbHabilitados.AutoSize = true;
            rdbHabilitados.Checked = true;
            rdbHabilitados.Location = new Point(198, 26);
            rdbHabilitados.Margin = new Padding(4);
            rdbHabilitados.Name = "rdbHabilitados";
            rdbHabilitados.Size = new Size(194, 27);
            rdbHabilitados.TabIndex = 29;
            rdbHabilitados.TabStop = true;
            rdbHabilitados.Text = "Mostrar Habilitados";
            rdbHabilitados.UseVisualStyleBackColor = true;
            // 
            // rdbTodos
            // 
            rdbTodos.AutoSize = true;
            rdbTodos.Location = new Point(22, 26);
            rdbTodos.Margin = new Padding(4);
            rdbTodos.Name = "rdbTodos";
            rdbTodos.Size = new Size(150, 27);
            rdbTodos.TabIndex = 28;
            rdbTodos.Text = "Mostrar Todos";
            rdbTodos.UseVisualStyleBackColor = true;
            // 
            // panelBusqueda
            // 
            panelBusqueda.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelBusqueda.BackColor = Color.FromArgb(189, 215, 238);
            panelBusqueda.Controls.Add(txtBuscar);
            panelBusqueda.Controls.Add(btnbuscar);
            panelBusqueda.Location = new Point(22, 15);
            panelBusqueda.Margin = new Padding(4);
            panelBusqueda.Name = "panelBusqueda";
            panelBusqueda.Size = new Size(898, 54);
            panelBusqueda.TabIndex = 41;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.BorderStyle = BorderStyle.None;
            txtBuscar.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(22, 15);
            txtBuscar.Margin = new Padding(4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar Usuarios...";
            txtBuscar.Size = new Size(782, 24);
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
            btnbuscar.Location = new Point(820, 15);
            btnbuscar.Margin = new Padding(4);
            btnbuscar.Name = "btnbuscar";
            btnbuscar.Size = new Size(60, 25);
            btnbuscar.TabIndex = 0;
            btnbuscar.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(189, 215, 238);
            panel1.Controls.Add(panel10);
            panel1.Location = new Point(22, 155);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(898, 526);
            panel1.TabIndex = 40;
            // 
            // panel10
            // 
            panel10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel10.AutoScroll = true;
            panel10.Controls.Add(dgvUsuario);
            panel10.Location = new Point(20, 22);
            panel10.Margin = new Padding(4);
            panel10.Name = "panel10";
            panel10.Size = new Size(860, 481);
            panel10.TabIndex = 17;
            // 
            // dgvUsuario
            // 
            dgvUsuario.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dgvUsuario.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvUsuario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuario.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvUsuario.BackgroundColor = Color.FromArgb(189, 215, 238);
            dgvUsuario.BorderStyle = BorderStyle.None;
            dgvUsuario.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvUsuario.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle2.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvUsuario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvUsuario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuario.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, Categoria, EstadoUsuario });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle4.Padding = new Padding(5);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvUsuario.DefaultCellStyle = dataGridViewCellStyle4;
            dgvUsuario.Dock = DockStyle.Fill;
            dgvUsuario.EnableHeadersVisualStyles = false;
            dgvUsuario.GridColor = Color.FromArgb(189, 215, 238);
            dgvUsuario.Location = new Point(0, 0);
            dgvUsuario.Margin = new Padding(4);
            dgvUsuario.Name = "dgvUsuario";
            dgvUsuario.ReadOnly = true;
            dgvUsuario.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(102, 102, 102);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvUsuario.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvUsuario.RowHeadersWidth = 30;
            dgvUsuario.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvUsuario.RowTemplate.Height = 50;
            dgvUsuario.Size = new Size(860, 481);
            dgvUsuario.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "IdUsuario";
            dataGridViewCellStyle3.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.Padding = new Padding(0, 1, 0, 0);
            dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewTextBoxColumn1.FillWeight = 50F;
            dataGridViewTextBoxColumn1.HeaderText = "Id";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Resizable = DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "AliasUsuario";
            dataGridViewTextBoxColumn2.FillWeight = 70F;
            dataGridViewTextBoxColumn2.HeaderText = "Usuario";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // Categoria
            // 
            Categoria.DataPropertyName = "RolUsuario";
            Categoria.FillWeight = 80F;
            Categoria.HeaderText = "Rol";
            Categoria.MinimumWidth = 6;
            Categoria.Name = "Categoria";
            Categoria.ReadOnly = true;
            // 
            // EstadoUsuario
            // 
            EstadoUsuario.DataPropertyName = "EstadoUsuario";
            EstadoUsuario.FillWeight = 60F;
            EstadoUsuario.HeaderText = "Estado";
            EstadoUsuario.MinimumWidth = 6;
            EstadoUsuario.Name = "EstadoUsuario";
            EstadoUsuario.ReadOnly = true;
            EstadoUsuario.Resizable = DataGridViewTriState.True;
            EstadoUsuario.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // frmUsuario
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(935, 780);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(groupBox1);
            Controls.Add(panelBusqueda);
            Controls.Add(panel1);
            Controls.Add(button4);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "frmUsuario";
            Text = "frmUsuario";
            tableLayoutPanel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panelBusqueda.ResumeLayout(false);
            panelBusqueda.PerformLayout();
            panel1.ResumeLayout(false);
            panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsuario).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button button4;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnSalir;
        private Button btnEditarUsuarios;
        private GroupBox groupBox1;
        private RadioButton rdbDeshabilitados;
        private RadioButton rdbHabilitados;
        private RadioButton rdbTodos;
        private Panel panelBusqueda;
        private TextBox txtBuscar;
        private Button btnbuscar;
        private Panel panel1;
        private Panel panel10;
        private DataGridView dgvProductos;
        private DataGridView dgvUsuario;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn Categoria;
        private DataGridViewCheckBoxColumn EstadoUsuario;
    }
}