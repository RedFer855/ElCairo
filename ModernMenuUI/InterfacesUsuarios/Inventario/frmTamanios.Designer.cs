namespace ModernMenuUI.InterfacesUsuarios.Inventario
{
    partial class frmTamanios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTamanios));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panelBusqueda = new Panel();
            txtBuscar = new TextBox();
            btnbuscar = new Button();
            panelCarrito = new Panel();
            panel10 = new Panel();
            dgvTamanios = new DataGridView();
            gbxEstado = new GroupBox();
            rbMostrardeshabilitados = new RadioButton();
            rbMostrarTodos = new RadioButton();
            rbMostrarHabilitados = new RadioButton();
            btnAgregarMarca = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnModificarMArca = new Button();
            button1 = new Button();
            btnSalir = new Button();
            panel1 = new Panel();
            IdTamanio = new DataGridViewTextBoxColumn();
            DescripcionTamanio = new DataGridViewTextBoxColumn();
            Unidad = new DataGridViewTextBoxColumn();
            EstadoProducto = new DataGridViewCheckBoxColumn();
            panelBusqueda.SuspendLayout();
            panelCarrito.SuspendLayout();
            panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTamanios).BeginInit();
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
            panelBusqueda.Location = new Point(12, 12);
            panelBusqueda.MaximumSize = new Size(700, 43);
            panelBusqueda.MinimumSize = new Size(330, 43);
            panelBusqueda.Name = "panelBusqueda";
            panelBusqueda.Size = new Size(406, 43);
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
            txtBuscar.PlaceholderText = "Buscar Tamaños...";
            txtBuscar.Size = new Size(319, 20);
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
            btnbuscar.Location = new Point(343, 12);
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
            panelCarrito.Size = new Size(574, 305);
            panelCarrito.TabIndex = 13;
            // 
            // panel10
            // 
            panel10.AutoScroll = true;
            panel10.Controls.Add(dgvTamanios);
            panel10.Dock = DockStyle.Fill;
            panel10.Location = new Point(0, 0);
            panel10.Name = "panel10";
            panel10.Size = new Size(574, 305);
            panel10.TabIndex = 17;
            // 
            // dgvTamanios
            // 
            dgvTamanios.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dgvTamanios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvTamanios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvTamanios.BackgroundColor = Color.FromArgb(189, 215, 238);
            dgvTamanios.BorderStyle = BorderStyle.None;
            dgvTamanios.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTamanios.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle2.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle2.SelectionBackColor = Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvTamanios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvTamanios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTamanios.Columns.AddRange(new DataGridViewColumn[] { IdTamanio, DescripcionTamanio, Unidad, EstadoProducto });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle3.Padding = new Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvTamanios.DefaultCellStyle = dataGridViewCellStyle3;
            dgvTamanios.Dock = DockStyle.Fill;
            dgvTamanios.EnableHeadersVisualStyles = false;
            dgvTamanios.GridColor = Color.FromArgb(189, 215, 238);
            dgvTamanios.Location = new Point(0, 0);
            dgvTamanios.Name = "dgvTamanios";
            dgvTamanios.ReadOnly = true;
            dgvTamanios.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(102, 102, 102);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvTamanios.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvTamanios.RowHeadersWidth = 30;
            dgvTamanios.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvTamanios.RowTemplate.Height = 50;
            dgvTamanios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTamanios.Size = new Size(574, 305);
            dgvTamanios.TabIndex = 1;
            // 
            // gbxEstado
            // 
            gbxEstado.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbxEstado.Controls.Add(rbMostrardeshabilitados);
            gbxEstado.Controls.Add(rbMostrarTodos);
            gbxEstado.Controls.Add(rbMostrarHabilitados);
            gbxEstado.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbxEstado.ForeColor = Color.DimGray;
            gbxEstado.Location = new Point(12, 61);
            gbxEstado.Name = "gbxEstado";
            gbxEstado.Size = new Size(604, 53);
            gbxEstado.TabIndex = 45;
            gbxEstado.TabStop = false;
            gbxEstado.Text = "Filtros de Búsqueda:";
            // 
            // rbMostrardeshabilitados
            // 
            rbMostrardeshabilitados.AutoSize = true;
            rbMostrardeshabilitados.Location = new Point(122, 22);
            rbMostrardeshabilitados.Name = "rbMostrardeshabilitados";
            rbMostrardeshabilitados.Size = new Size(121, 22);
            rbMostrardeshabilitados.TabIndex = 30;
            rbMostrardeshabilitados.Text = "Deshabilitados";
            rbMostrardeshabilitados.UseVisualStyleBackColor = true;
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
            // btnAgregarMarca
            // 
            btnAgregarMarca.BackColor = Color.FromArgb(149, 195, 172);
            btnAgregarMarca.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregarMarca.ForeColor = SystemColors.ButtonFace;
            btnAgregarMarca.Location = new Point(3, 3);
            btnAgregarMarca.Name = "btnAgregarMarca";
            btnAgregarMarca.Size = new Size(147, 44);
            btnAgregarMarca.TabIndex = 35;
            btnAgregarMarca.Text = "Agregar Tamaño";
            btnAgregarMarca.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            flowLayoutPanel1.Controls.Add(btnAgregarMarca);
            flowLayoutPanel1.Controls.Add(btnModificarMArca);
            flowLayoutPanel1.Controls.Add(button1);
            flowLayoutPanel1.Controls.Add(btnSalir);
            flowLayoutPanel1.Location = new Point(12, 468);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(604, 51);
            flowLayoutPanel1.TabIndex = 44;
            // 
            // btnModificarMArca
            // 
            btnModificarMArca.BackColor = Color.FromArgb(149, 195, 172);
            btnModificarMArca.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnModificarMArca.ForeColor = SystemColors.ButtonFace;
            btnModificarMArca.Location = new Point(156, 3);
            btnModificarMArca.Name = "btnModificarMArca";
            btnModificarMArca.Size = new Size(161, 44);
            btnModificarMArca.TabIndex = 36;
            btnModificarMArca.Text = "Modificar Tamaño";
            btnModificarMArca.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(149, 195, 172);
            button1.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(323, 3);
            button1.Name = "button1";
            button1.Size = new Size(179, 44);
            button1.TabIndex = 38;
            button1.Text = "Seleccionar Tamaño";
            button1.UseVisualStyleBackColor = false;
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
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(189, 215, 238);
            panel1.Controls.Add(panelCarrito);
            panel1.Location = new Point(12, 120);
            panel1.Name = "panel1";
            panel1.Size = new Size(604, 334);
            panel1.TabIndex = 43;
            // 
            // IdTamanio
            // 
            IdTamanio.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            IdTamanio.DataPropertyName = "IdTamanio";
            IdTamanio.HeaderText = "Código";
            IdTamanio.Name = "IdTamanio";
            IdTamanio.ReadOnly = true;
            IdTamanio.Width = 89;
            // 
            // DescripcionTamanio
            // 
            DescripcionTamanio.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DescripcionTamanio.DataPropertyName = "DescripcionTamanio";
            DescripcionTamanio.HeaderText = "Tamaño";
            DescripcionTamanio.Name = "DescripcionTamanio";
            DescripcionTamanio.ReadOnly = true;
            DescripcionTamanio.Width = 95;
            // 
            // Unidad
            // 
            Unidad.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Unidad.DataPropertyName = "UnidadMedidaTamanio";
            Unidad.HeaderText = "Unidad de Medida";
            Unidad.Name = "Unidad";
            Unidad.ReadOnly = true;
            // 
            // EstadoProducto
            // 
            EstadoProducto.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            EstadoProducto.DataPropertyName = "EstadoProducto";
            EstadoProducto.HeaderText = "Estado";
            EstadoProducto.Name = "EstadoProducto";
            EstadoProducto.ReadOnly = true;
            EstadoProducto.Resizable = DataGridViewTriState.True;
            EstadoProducto.SortMode = DataGridViewColumnSortMode.Automatic;
            EstadoProducto.Width = 89;
            // 
            // frmTamanios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(628, 531);
            Controls.Add(panelBusqueda);
            Controls.Add(gbxEstado);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(628, 531);
            Name = "frmTamanios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tamaños";
            panelBusqueda.ResumeLayout(false);
            panelBusqueda.PerformLayout();
            panelCarrito.ResumeLayout(false);
            panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTamanios).EndInit();
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
        private DataGridView dgvTamanios;
        private GroupBox gbxEstado;
        private RadioButton rbMostrardeshabilitados;
        private RadioButton rbMostrarTodos;
        private RadioButton rbMostrarHabilitados;
        private Button btnAgregarMarca;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnModificarMArca;
        private Button button1;
        private Button btnSalir;
        private Panel panel1;
        private DataGridViewTextBoxColumn IdTamanio;
        private DataGridViewTextBoxColumn DescripcionTamanio;
        private DataGridViewTextBoxColumn Unidad;
        private DataGridViewCheckBoxColumn EstadoProducto;
    }
}