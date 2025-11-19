namespace ModernMenuUI.InterfacesUsuarios.Inventario
{
    partial class frmCategorias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCategorias));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            txtBuscar = new TextBox();
            btnbuscar = new Button();
            rbMostrarDeshabilitados = new RadioButton();
            rbMostrarTodos = new RadioButton();
            rbMostrarHabilitados = new RadioButton();
            gbxEstado = new GroupBox();
            btnModificarCategoria = new Button();
            btnSeleccionarCategoria = new Button();
            btnSalir = new Button();
            panelBusqueda = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnAgregarCategoria = new Button();
            dgvCategorias = new DataGridView();
            panel10 = new Panel();
            panelCarrito = new Panel();
            panel1 = new Panel();
            IdMarca = new DataGridViewTextBoxColumn();
            Categoría = new DataGridViewTextBoxColumn();
            Descripcion = new DataGridViewTextBoxColumn();
            EstadoProducto = new DataGridViewCheckBoxColumn();
            gbxEstado.SuspendLayout();
            panelBusqueda.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).BeginInit();
            panel10.SuspendLayout();
            panelCarrito.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtBuscar.BorderStyle = BorderStyle.None;
            txtBuscar.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(18, 12);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar Categorías...";
            txtBuscar.Size = new Size(312, 20);
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
            btnbuscar.Location = new Point(336, 12);
            btnbuscar.Name = "btnbuscar";
            btnbuscar.Size = new Size(48, 20);
            btnbuscar.TabIndex = 0;
            btnbuscar.UseVisualStyleBackColor = false;
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
            rbMostrarDeshabilitados.CheckedChanged += rbMostrarDeshabilitados_CheckedChanged;
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
            rbMostrarTodos.CheckedChanged += rbMostrarTodos_CheckedChanged_1;
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
            rbMostrarHabilitados.CheckedChanged += rbMostrarHabilitados_CheckedChanged;
            // 
            // gbxEstado
            // 
            gbxEstado.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbxEstado.Controls.Add(rbMostrarDeshabilitados);
            gbxEstado.Controls.Add(rbMostrarTodos);
            gbxEstado.Controls.Add(rbMostrarHabilitados);
            gbxEstado.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbxEstado.ForeColor = Color.DimGray;
            gbxEstado.Location = new Point(12, 63);
            gbxEstado.Name = "gbxEstado";
            gbxEstado.Size = new Size(596, 53);
            gbxEstado.TabIndex = 45;
            gbxEstado.TabStop = false;
            gbxEstado.Text = "Filtros de Búsqueda:";
            // 
            // btnModificarCategoria
            // 
            btnModificarCategoria.BackColor = Color.FromArgb(149, 195, 172);
            btnModificarCategoria.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnModificarCategoria.ForeColor = SystemColors.ButtonFace;
            btnModificarCategoria.Location = new Point(156, 3);
            btnModificarCategoria.Name = "btnModificarCategoria";
            btnModificarCategoria.Size = new Size(161, 44);
            btnModificarCategoria.TabIndex = 36;
            btnModificarCategoria.Text = "Modificar Categoría";
            btnModificarCategoria.UseVisualStyleBackColor = false;
            // 
            // btnSeleccionarCategoria
            // 
            btnSeleccionarCategoria.BackColor = Color.FromArgb(149, 195, 172);
            btnSeleccionarCategoria.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSeleccionarCategoria.ForeColor = SystemColors.ButtonFace;
            btnSeleccionarCategoria.Location = new Point(323, 3);
            btnSeleccionarCategoria.Name = "btnSeleccionarCategoria";
            btnSeleccionarCategoria.Size = new Size(179, 44);
            btnSeleccionarCategoria.TabIndex = 38;
            btnSeleccionarCategoria.Text = "Seleccionar Categoría";
            btnSeleccionarCategoria.UseVisualStyleBackColor = false;
            btnSeleccionarCategoria.Click += btnSeleccionarCategoria_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(148, 168, 187);
            btnSalir.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = SystemColors.ButtonFace;
            btnSalir.Location = new Point(508, 3);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(91, 44);
            btnSalir.TabIndex = 37;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // panelBusqueda
            // 
            panelBusqueda.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelBusqueda.BackColor = Color.FromArgb(189, 215, 238);
            panelBusqueda.Controls.Add(txtBuscar);
            panelBusqueda.Controls.Add(btnbuscar);
            panelBusqueda.Location = new Point(12, 14);
            panelBusqueda.MaximumSize = new Size(700, 43);
            panelBusqueda.MinimumSize = new Size(330, 43);
            panelBusqueda.Name = "panelBusqueda";
            panelBusqueda.Size = new Size(396, 43);
            panelBusqueda.TabIndex = 46;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            flowLayoutPanel1.Controls.Add(btnAgregarCategoria);
            flowLayoutPanel1.Controls.Add(btnModificarCategoria);
            flowLayoutPanel1.Controls.Add(btnSeleccionarCategoria);
            flowLayoutPanel1.Controls.Add(btnSalir);
            flowLayoutPanel1.Location = new Point(12, 417);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(776, 51);
            flowLayoutPanel1.TabIndex = 44;
            // 
            // btnAgregarCategoria
            // 
            btnAgregarCategoria.BackColor = Color.FromArgb(149, 195, 172);
            btnAgregarCategoria.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregarCategoria.ForeColor = SystemColors.ButtonFace;
            btnAgregarCategoria.Location = new Point(3, 3);
            btnAgregarCategoria.Name = "btnAgregarCategoria";
            btnAgregarCategoria.Size = new Size(147, 44);
            btnAgregarCategoria.TabIndex = 35;
            btnAgregarCategoria.Text = "Agregar Categoría";
            btnAgregarCategoria.UseVisualStyleBackColor = false;
            // 
            // dgvCategorias
            // 
            dgvCategorias.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dgvCategorias.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvCategorias.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvCategorias.BackgroundColor = Color.FromArgb(189, 215, 238);
            dgvCategorias.BorderStyle = BorderStyle.None;
            dgvCategorias.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCategorias.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle2.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle2.SelectionBackColor = Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvCategorias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategorias.Columns.AddRange(new DataGridViewColumn[] { IdMarca, Categoría, Descripcion, EstadoProducto });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle3.Padding = new Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvCategorias.DefaultCellStyle = dataGridViewCellStyle3;
            dgvCategorias.Dock = DockStyle.Fill;
            dgvCategorias.EnableHeadersVisualStyles = false;
            dgvCategorias.GridColor = Color.FromArgb(189, 215, 238);
            dgvCategorias.Location = new Point(0, 0);
            dgvCategorias.Name = "dgvCategorias";
            dgvCategorias.ReadOnly = true;
            dgvCategorias.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle4.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(102, 102, 102);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvCategorias.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvCategorias.RowHeadersWidth = 30;
            dgvCategorias.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvCategorias.RowTemplate.Height = 50;
            dgvCategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategorias.Size = new Size(570, 262);
            dgvCategorias.TabIndex = 1;
            dgvCategorias.CellDoubleClick += dgvCategorias_CellDoubleClick;
            // 
            // panel10
            // 
            panel10.AutoScroll = true;
            panel10.Controls.Add(dgvCategorias);
            panel10.Dock = DockStyle.Fill;
            panel10.Location = new Point(0, 0);
            panel10.Name = "panel10";
            panel10.Size = new Size(570, 262);
            panel10.TabIndex = 17;
            // 
            // panelCarrito
            // 
            panelCarrito.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelCarrito.BackColor = Color.FromArgb(189, 215, 238);
            panelCarrito.Controls.Add(panel10);
            panelCarrito.Location = new Point(15, 14);
            panelCarrito.Name = "panelCarrito";
            panelCarrito.Size = new Size(570, 262);
            panelCarrito.TabIndex = 13;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(189, 215, 238);
            panel1.Controls.Add(panelCarrito);
            panel1.Location = new Point(12, 122);
            panel1.Name = "panel1";
            panel1.Size = new Size(596, 289);
            panel1.TabIndex = 43;
            // 
            // IdMarca
            // 
            IdMarca.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            IdMarca.DataPropertyName = "IdCategoria";
            IdMarca.HeaderText = "Código";
            IdMarca.Name = "IdMarca";
            IdMarca.ReadOnly = true;
            IdMarca.Width = 89;
            // 
            // Categoría
            // 
            Categoría.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Categoría.DataPropertyName = "NombreCategoria";
            Categoría.HeaderText = "Categoría";
            Categoría.Name = "Categoría";
            Categoría.ReadOnly = true;
            Categoría.Width = 108;
            // 
            // Descripcion
            // 
            Descripcion.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Descripcion.DataPropertyName = "DescripcionCategoria";
            Descripcion.HeaderText = "Descripción";
            Descripcion.Name = "Descripcion";
            Descripcion.ReadOnly = true;
            // 
            // EstadoProducto
            // 
            EstadoProducto.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            EstadoProducto.DataPropertyName = "EstadoCategoria";
            EstadoProducto.HeaderText = "Estado";
            EstadoProducto.Name = "EstadoProducto";
            EstadoProducto.ReadOnly = true;
            EstadoProducto.Resizable = DataGridViewTriState.True;
            EstadoProducto.SortMode = DataGridViewColumnSortMode.Automatic;
            EstadoProducto.Width = 89;
            // 
            // frmCategorias
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(620, 480);
            Controls.Add(gbxEstado);
            Controls.Add(panelBusqueda);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(620, 480);
            Name = "frmCategorias";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Categorías";
            FormClosing += frmCategorias_FormClosing;
            Load += frmCategorias_Load;
            gbxEstado.ResumeLayout(false);
            gbxEstado.PerformLayout();
            panelBusqueda.ResumeLayout(false);
            panelBusqueda.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).EndInit();
            panel10.ResumeLayout(false);
            panelCarrito.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtBuscar;
        private Button btnbuscar;
        private RadioButton rbMostrarDeshabilitados;
        private RadioButton rbMostrarTodos;
        private RadioButton rbMostrarHabilitados;
        private GroupBox gbxEstado;
        private Button btnModificarCategoria;
        private Button btnSeleccionarCategoria;
        private Button btnSalir;
        private Panel panelBusqueda;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnAgregarCategoria;
        private DataGridView dgvCategorias;
        private Panel panel10;
        private Panel panelCarrito;
        private Panel panel1;
        private DataGridViewTextBoxColumn IdMarca;
        private DataGridViewTextBoxColumn Categoría;
        private DataGridViewTextBoxColumn Descripcion;
        private DataGridViewCheckBoxColumn EstadoProducto;
    }
}