namespace ModernMenuUI.InterfacesUsuarios.Inventario
{
    partial class frmMarcas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMarcas));
            panel1 = new Panel();
            panelCarrito = new Panel();
            panel10 = new Panel();
            dgvMarcas = new DataGridView();
            IdMarca = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            Proveedor = new DataGridViewTextBoxColumn();
            EstadoProducto = new DataGridViewCheckBoxColumn();
            btnAgregarMarca = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnModificarMArca = new Button();
            btnSeleccionarMarca = new Button();
            btnSalir = new Button();
            gbxEstado = new GroupBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            txtMarca = new TextBox();
            btnProveedores = new Button();
            label1 = new Label();
            rbMostrarDeshablitados = new RadioButton();
            rbMostrarTodos = new RadioButton();
            rbMostrarHablilitados = new RadioButton();
            panelBusqueda = new Panel();
            txtBuscar = new TextBox();
            btnbuscar = new Button();
            panel1.SuspendLayout();
            panelCarrito.SuspendLayout();
            panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMarcas).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            gbxEstado.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panelBusqueda.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(189, 215, 238);
            panel1.Controls.Add(panelCarrito);
            panel1.Location = new Point(12, 121);
            panel1.Name = "panel1";
            panel1.Size = new Size(692, 282);
            panel1.TabIndex = 34;
            // 
            // panelCarrito
            // 
            panelCarrito.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelCarrito.BackColor = Color.FromArgb(189, 215, 238);
            panelCarrito.Controls.Add(panel10);
            panelCarrito.Location = new Point(15, 19);
            panelCarrito.Name = "panelCarrito";
            panelCarrito.Size = new Size(659, 243);
            panelCarrito.TabIndex = 13;
            // 
            // panel10
            // 
            panel10.AutoScroll = true;
            panel10.Controls.Add(dgvMarcas);
            panel10.Dock = DockStyle.Fill;
            panel10.Location = new Point(0, 0);
            panel10.Name = "panel10";
            panel10.Size = new Size(659, 243);
            panel10.TabIndex = 17;
            // 
            // dgvMarcas
            // 
            dgvMarcas.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dgvMarcas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvMarcas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvMarcas.BackgroundColor = Color.FromArgb(189, 215, 238);
            dgvMarcas.BorderStyle = BorderStyle.None;
            dgvMarcas.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMarcas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle2.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle2.SelectionBackColor = Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvMarcas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvMarcas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMarcas.Columns.AddRange(new DataGridViewColumn[] { IdMarca, dataGridViewTextBoxColumn4, Proveedor, EstadoProducto });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle3.Padding = new Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvMarcas.DefaultCellStyle = dataGridViewCellStyle3;
            dgvMarcas.Dock = DockStyle.Fill;
            dgvMarcas.EnableHeadersVisualStyles = false;
            dgvMarcas.GridColor = Color.FromArgb(189, 215, 238);
            dgvMarcas.Location = new Point(0, 0);
            dgvMarcas.Name = "dgvMarcas";
            dgvMarcas.ReadOnly = true;
            dgvMarcas.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle4.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(102, 102, 102);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvMarcas.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvMarcas.RowHeadersWidth = 30;
            dgvMarcas.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvMarcas.RowTemplate.Height = 50;
            dgvMarcas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMarcas.Size = new Size(659, 243);
            dgvMarcas.TabIndex = 1;
            dgvMarcas.CellDoubleClick += dgvMarcas_CellDoubleClick;
            // 
            // IdMarca
            // 
            IdMarca.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            IdMarca.DataPropertyName = "NombreMarca";
            IdMarca.HeaderText = "Código";
            IdMarca.Name = "IdMarca";
            IdMarca.ReadOnly = true;
            IdMarca.Width = 89;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn4.DataPropertyName = "NombreMarca";
            dataGridViewTextBoxColumn4.FillWeight = 120F;
            dataGridViewTextBoxColumn4.HeaderText = "Marca";
            dataGridViewTextBoxColumn4.MinimumWidth = 100;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // Proveedor
            // 
            Proveedor.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Proveedor.DataPropertyName = "NombreProveedor";
            Proveedor.HeaderText = "Proveedor";
            Proveedor.Name = "Proveedor";
            Proveedor.ReadOnly = true;
            // 
            // EstadoProducto
            // 
            EstadoProducto.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            EstadoProducto.DataPropertyName = "EstadoMarca";
            EstadoProducto.HeaderText = "Estado";
            EstadoProducto.Name = "EstadoProducto";
            EstadoProducto.ReadOnly = true;
            EstadoProducto.Resizable = DataGridViewTriState.True;
            EstadoProducto.SortMode = DataGridViewColumnSortMode.Automatic;
            EstadoProducto.Width = 89;
            // 
            // btnAgregarMarca
            // 
            btnAgregarMarca.BackColor = Color.FromArgb(149, 195, 172);
            btnAgregarMarca.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregarMarca.ForeColor = SystemColors.ButtonFace;
            btnAgregarMarca.Location = new Point(3, 3);
            btnAgregarMarca.Name = "btnAgregarMarca";
            btnAgregarMarca.Size = new Size(124, 44);
            btnAgregarMarca.TabIndex = 35;
            btnAgregarMarca.Text = "Agregar Marca";
            btnAgregarMarca.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            flowLayoutPanel1.Controls.Add(btnAgregarMarca);
            flowLayoutPanel1.Controls.Add(btnModificarMArca);
            flowLayoutPanel1.Controls.Add(btnSeleccionarMarca);
            flowLayoutPanel1.Controls.Add(btnSalir);
            flowLayoutPanel1.Location = new Point(12, 418);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(527, 51);
            flowLayoutPanel1.TabIndex = 36;
            // 
            // btnModificarMArca
            // 
            btnModificarMArca.BackColor = Color.FromArgb(149, 195, 172);
            btnModificarMArca.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnModificarMArca.ForeColor = SystemColors.ButtonFace;
            btnModificarMArca.Location = new Point(133, 3);
            btnModificarMArca.Name = "btnModificarMArca";
            btnModificarMArca.Size = new Size(129, 44);
            btnModificarMArca.TabIndex = 36;
            btnModificarMArca.Text = "Modificar Marca";
            btnModificarMArca.UseVisualStyleBackColor = false;
            // 
            // btnSeleccionarMarca
            // 
            btnSeleccionarMarca.BackColor = Color.FromArgb(149, 195, 172);
            btnSeleccionarMarca.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSeleccionarMarca.ForeColor = SystemColors.ButtonFace;
            btnSeleccionarMarca.Location = new Point(268, 3);
            btnSeleccionarMarca.Name = "btnSeleccionarMarca";
            btnSeleccionarMarca.Size = new Size(153, 44);
            btnSeleccionarMarca.TabIndex = 38;
            btnSeleccionarMarca.Text = "Seleccionar Marca";
            btnSeleccionarMarca.UseVisualStyleBackColor = false;
            btnSeleccionarMarca.Click += btnSeleccionarMarca_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(148, 168, 187);
            btnSalir.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = SystemColors.ButtonFace;
            btnSalir.Location = new Point(427, 3);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(91, 44);
            btnSalir.TabIndex = 37;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // gbxEstado
            // 
            gbxEstado.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbxEstado.Controls.Add(tableLayoutPanel2);
            gbxEstado.Controls.Add(rbMostrarDeshablitados);
            gbxEstado.Controls.Add(rbMostrarTodos);
            gbxEstado.Controls.Add(rbMostrarHablilitados);
            gbxEstado.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbxEstado.ForeColor = Color.DimGray;
            gbxEstado.Location = new Point(12, 62);
            gbxEstado.Name = "gbxEstado";
            gbxEstado.Size = new Size(692, 53);
            gbxEstado.TabIndex = 37;
            gbxEstado.TabStop = false;
            gbxEstado.Text = "Filtros de Búsqueda:";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 32F));
            tableLayoutPanel2.Controls.Add(txtMarca, 1, 0);
            tableLayoutPanel2.Controls.Add(btnProveedores, 2, 0);
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Location = new Point(382, 17);
            tableLayoutPanel2.MaximumSize = new Size(420, 30);
            tableLayoutPanel2.MinimumSize = new Size(301, 30);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(302, 30);
            tableLayoutPanel2.TabIndex = 39;
            // 
            // txtMarca
            // 
            txtMarca.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMarca.Location = new Point(103, 3);
            txtMarca.Name = "txtMarca";
            txtMarca.PlaceholderText = "(Todos los Proveedores)";
            txtMarca.ReadOnly = true;
            txtMarca.Size = new Size(164, 25);
            txtMarca.TabIndex = 34;
            // 
            // btnProveedores
            // 
            btnProveedores.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnProveedores.BackColor = Color.FromArgb(168, 191, 212);
            btnProveedores.BackgroundImage = (Image)resources.GetObject("btnProveedores.BackgroundImage");
            btnProveedores.BackgroundImageLayout = ImageLayout.Zoom;
            btnProveedores.FlatAppearance.BorderSize = 0;
            btnProveedores.FlatStyle = FlatStyle.Flat;
            btnProveedores.Location = new Point(274, 3);
            btnProveedores.Name = "btnProveedores";
            btnProveedores.Size = new Size(25, 24);
            btnProveedores.TabIndex = 2;
            btnProveedores.UseVisualStyleBackColor = false;
            btnProveedores.Click += btnProveedores_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(94, 30);
            label1.TabIndex = 35;
            label1.Text = "Proveedores:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // rbMostrarDeshablitados
            // 
            rbMostrarDeshablitados.AutoSize = true;
            rbMostrarDeshablitados.Location = new Point(122, 22);
            rbMostrarDeshablitados.Name = "rbMostrarDeshablitados";
            rbMostrarDeshablitados.Size = new Size(121, 22);
            rbMostrarDeshablitados.TabIndex = 30;
            rbMostrarDeshablitados.Text = "Deshabilitados";
            rbMostrarDeshablitados.UseVisualStyleBackColor = true;
            rbMostrarDeshablitados.CheckedChanged += rbMostrarDeshablitados_CheckedChanged_1;
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
            // rbMostrarHablilitados
            // 
            rbMostrarHablilitados.AutoSize = true;
            rbMostrarHablilitados.Checked = true;
            rbMostrarHablilitados.Location = new Point(15, 21);
            rbMostrarHablilitados.Name = "rbMostrarHablilitados";
            rbMostrarHablilitados.Size = new Size(101, 22);
            rbMostrarHablilitados.TabIndex = 28;
            rbMostrarHablilitados.TabStop = true;
            rbMostrarHablilitados.Text = "Habilitados";
            rbMostrarHablilitados.UseVisualStyleBackColor = true;
            rbMostrarHablilitados.CheckedChanged += rbMostrarHablilitados_CheckedChanged_1;
            // 
            // panelBusqueda
            // 
            panelBusqueda.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelBusqueda.BackColor = Color.FromArgb(189, 215, 238);
            panelBusqueda.Controls.Add(txtBuscar);
            panelBusqueda.Controls.Add(btnbuscar);
            panelBusqueda.Location = new Point(15, 12);
            panelBusqueda.MaximumSize = new Size(700, 43);
            panelBusqueda.MinimumSize = new Size(330, 43);
            panelBusqueda.Name = "panelBusqueda";
            panelBusqueda.Size = new Size(530, 43);
            panelBusqueda.TabIndex = 38;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtBuscar.BorderStyle = BorderStyle.None;
            txtBuscar.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(18, 12);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar Marcas...";
            txtBuscar.Size = new Size(443, 20);
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
            btnbuscar.Location = new Point(467, 12);
            btnbuscar.Name = "btnbuscar";
            btnbuscar.Size = new Size(48, 20);
            btnbuscar.TabIndex = 0;
            btnbuscar.UseVisualStyleBackColor = false;
            // 
            // frmMarcas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(716, 481);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panelBusqueda);
            Controls.Add(gbxEstado);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(716, 481);
            Name = "frmMarcas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Marcas";
            FormClosing += frmMarcas_FormClosing;
            Load += frmMarcas_Load;
            panel1.ResumeLayout(false);
            panelCarrito.ResumeLayout(false);
            panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMarcas).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            gbxEstado.ResumeLayout(false);
            gbxEstado.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            panelBusqueda.ResumeLayout(false);
            panelBusqueda.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panelCarrito;
        private Panel panel10;
        private DataGridView dgvMarcas;
        private Button btnAgregarMarca;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnModificarMArca;
        private Button btnSalir;
        private GroupBox gbxEstado;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox txtMarca;
        private Button btnProveedores;
        private RadioButton rbMostrarDeshablitados;
        private RadioButton rbMostrarTodos;
        private RadioButton rbMostrarHablilitados;
        private Label label1;
        private Panel panelBusqueda;
        private TextBox txtBuscar;
        private Button btnbuscar;
        private Button btnSeleccionarMarca;
        private DataGridViewTextBoxColumn IdMarca;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn Proveedor;
        private DataGridViewCheckBoxColumn EstadoProducto;
    }
}