namespace ModernMenuUI.InterfacesUsuarios.Inventario
{
    partial class frmBodegas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBodegas));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            lstSugerencias = new ListBox();
            btnLimpiarFiltros = new Button();
            pnlLimpiarFiltros = new Panel();
            pbxClean = new PictureBox();
            panel1 = new Panel();
            panelCarrito = new Panel();
            panel10 = new Panel();
            dgvCategorias = new DataGridView();
            IdMarca = new DataGridViewTextBoxColumn();
            Tipo = new DataGridViewTextBoxColumn();
            NombreBodega = new DataGridViewTextBoxColumn();
            Descripcion = new DataGridViewTextBoxColumn();
            EstadoBodega = new DataGridViewCheckBoxColumn();
            panelBusqueda = new Panel();
            txtBuscar = new TextBox();
            btnbuscar = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnModificarBodega = new Button();
            btnSeleccionarCategoria = new Button();
            btnSalir = new Button();
            gbxEstado = new GroupBox();
            rbMostrarDeshabilitados = new RadioButton();
            rbMostrarTodos = new RadioButton();
            rbMostrarHabilitados = new RadioButton();
            btnAgregarBodega = new Button();
            pnlLimpiarFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxClean).BeginInit();
            panel1.SuspendLayout();
            panelCarrito.SuspendLayout();
            panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).BeginInit();
            panelBusqueda.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            gbxEstado.SuspendLayout();
            SuspendLayout();
            // 
            // lstSugerencias
            // 
            lstSugerencias.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lstSugerencias.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstSugerencias.ForeColor = Color.DimGray;
            lstSugerencias.FormattingEnabled = true;
            lstSugerencias.ItemHeight = 18;
            lstSugerencias.Location = new Point(27, 45);
            lstSugerencias.MinimumSize = new Size(243, 22);
            lstSugerencias.Name = "lstSugerencias";
            lstSugerencias.Size = new Size(483, 22);
            lstSugerencias.TabIndex = 64;
            lstSugerencias.Visible = false;
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
            // 
            // pnlLimpiarFiltros
            // 
            pnlLimpiarFiltros.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlLimpiarFiltros.BackColor = Color.FromArgb(189, 215, 238);
            pnlLimpiarFiltros.Controls.Add(btnLimpiarFiltros);
            pnlLimpiarFiltros.Controls.Add(pbxClean);
            pnlLimpiarFiltros.Location = new Point(580, 12);
            pnlLimpiarFiltros.Name = "pnlLimpiarFiltros";
            pnlLimpiarFiltros.Size = new Size(166, 43);
            pnlLimpiarFiltros.TabIndex = 63;
            pnlLimpiarFiltros.Visible = false;
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
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(189, 215, 238);
            panel1.Controls.Add(panelCarrito);
            panel1.Location = new Point(12, 120);
            panel1.Name = "panel1";
            panel1.Size = new Size(734, 289);
            panel1.TabIndex = 59;
            // 
            // panelCarrito
            // 
            panelCarrito.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelCarrito.BackColor = Color.FromArgb(189, 215, 238);
            panelCarrito.Controls.Add(panel10);
            panelCarrito.Location = new Point(15, 14);
            panelCarrito.Name = "panelCarrito";
            panelCarrito.Size = new Size(705, 259);
            panelCarrito.TabIndex = 13;
            // 
            // panel10
            // 
            panel10.AutoScroll = true;
            panel10.Controls.Add(dgvCategorias);
            panel10.Dock = DockStyle.Fill;
            panel10.Location = new Point(0, 0);
            panel10.Name = "panel10";
            panel10.Size = new Size(705, 259);
            panel10.TabIndex = 17;
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
            dgvCategorias.Columns.AddRange(new DataGridViewColumn[] { IdMarca, Tipo, NombreBodega, Descripcion, EstadoBodega });
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
            dgvCategorias.Size = new Size(705, 259);
            dgvCategorias.TabIndex = 1;
            // 
            // IdMarca
            // 
            IdMarca.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            IdMarca.DataPropertyName = "IdBodega";
            IdMarca.HeaderText = "Código";
            IdMarca.Name = "IdMarca";
            IdMarca.ReadOnly = true;
            IdMarca.Width = 89;
            // 
            // Tipo
            // 
            Tipo.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Tipo.HeaderText = "Tipo";
            Tipo.Name = "Tipo";
            Tipo.ReadOnly = true;
            Tipo.Width = 71;
            // 
            // NombreBodega
            // 
            NombreBodega.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            NombreBodega.DataPropertyName = "NombreBodega";
            NombreBodega.HeaderText = "Nombre";
            NombreBodega.Name = "NombreBodega";
            NombreBodega.ReadOnly = true;
            NombreBodega.Width = 96;
            // 
            // Descripcion
            // 
            Descripcion.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Descripcion.DataPropertyName = "DescripcionCategoria";
            Descripcion.HeaderText = "Descripción";
            Descripcion.Name = "Descripcion";
            Descripcion.ReadOnly = true;
            // 
            // EstadoBodega
            // 
            EstadoBodega.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            EstadoBodega.DataPropertyName = "EstadoBodega";
            EstadoBodega.HeaderText = "Estado";
            EstadoBodega.Name = "EstadoBodega";
            EstadoBodega.ReadOnly = true;
            EstadoBodega.Resizable = DataGridViewTriState.True;
            EstadoBodega.SortMode = DataGridViewColumnSortMode.Automatic;
            EstadoBodega.Width = 89;
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
            panelBusqueda.Size = new Size(562, 43);
            panelBusqueda.TabIndex = 62;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtBuscar.BorderStyle = BorderStyle.None;
            txtBuscar.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(15, 12);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar Bodegas y Puntos de Venta...";
            txtBuscar.Size = new Size(483, 20);
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
            btnbuscar.Location = new Point(504, 12);
            btnbuscar.Name = "btnbuscar";
            btnbuscar.Size = new Size(50, 20);
            btnbuscar.TabIndex = 0;
            btnbuscar.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            flowLayoutPanel1.Controls.Add(btnAgregarBodega);
            flowLayoutPanel1.Controls.Add(btnModificarBodega);
            flowLayoutPanel1.Controls.Add(btnSeleccionarCategoria);
            flowLayoutPanel1.Controls.Add(btnSalir);
            flowLayoutPanel1.Location = new Point(12, 415);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(734, 51);
            flowLayoutPanel1.TabIndex = 60;
            // 
            // btnModificarBodega
            // 
            btnModificarBodega.BackColor = Color.FromArgb(148, 168, 187);
            btnModificarBodega.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnModificarBodega.ForeColor = SystemColors.ButtonFace;
            btnModificarBodega.Location = new Point(188, 3);
            btnModificarBodega.Name = "btnModificarBodega";
            btnModificarBodega.Size = new Size(128, 44);
            btnModificarBodega.TabIndex = 36;
            btnModificarBodega.Text = "Ver Bodega";
            btnModificarBodega.UseVisualStyleBackColor = false;
            btnModificarBodega.Click += btnModificarBodega_Click;
            // 
            // btnSeleccionarCategoria
            // 
            btnSeleccionarCategoria.BackColor = Color.FromArgb(149, 195, 172);
            btnSeleccionarCategoria.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSeleccionarCategoria.ForeColor = SystemColors.ButtonFace;
            btnSeleccionarCategoria.Location = new Point(322, 3);
            btnSeleccionarCategoria.Name = "btnSeleccionarCategoria";
            btnSeleccionarCategoria.Size = new Size(179, 44);
            btnSeleccionarCategoria.TabIndex = 38;
            btnSeleccionarCategoria.Text = "Seleccionar Bodega";
            btnSeleccionarCategoria.UseVisualStyleBackColor = false;
            btnSeleccionarCategoria.Click += btnSeleccionarCategoria_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(148, 168, 187);
            btnSalir.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = SystemColors.ButtonFace;
            btnSalir.Location = new Point(507, 3);
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
            gbxEstado.Controls.Add(rbMostrarDeshabilitados);
            gbxEstado.Controls.Add(rbMostrarTodos);
            gbxEstado.Controls.Add(rbMostrarHabilitados);
            gbxEstado.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbxEstado.ForeColor = Color.DimGray;
            gbxEstado.Location = new Point(12, 61);
            gbxEstado.Name = "gbxEstado";
            gbxEstado.Size = new Size(734, 53);
            gbxEstado.TabIndex = 61;
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
            // btnAgregarBodega
            // 
            btnAgregarBodega.BackColor = Color.FromArgb(149, 195, 172);
            btnAgregarBodega.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregarBodega.ForeColor = SystemColors.ButtonFace;
            btnAgregarBodega.Location = new Point(3, 3);
            btnAgregarBodega.Name = "btnAgregarBodega";
            btnAgregarBodega.Size = new Size(179, 44);
            btnAgregarBodega.TabIndex = 39;
            btnAgregarBodega.Text = "Agegar Bodega";
            btnAgregarBodega.UseVisualStyleBackColor = false;
            btnAgregarBodega.Click += btnAgregarBodega_Click;
            // 
            // frmBodegas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(758, 478);
            Controls.Add(lstSugerencias);
            Controls.Add(pnlLimpiarFiltros);
            Controls.Add(panel1);
            Controls.Add(panelBusqueda);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(gbxEstado);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmBodegas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bodegas";
            pnlLimpiarFiltros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbxClean).EndInit();
            panel1.ResumeLayout(false);
            panelCarrito.ResumeLayout(false);
            panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).EndInit();
            panelBusqueda.ResumeLayout(false);
            panelBusqueda.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            gbxEstado.ResumeLayout(false);
            gbxEstado.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListBox lstSugerencias;
        private Button btnLimpiarFiltros;
        private Panel pnlLimpiarFiltros;
        private PictureBox pbxClean;
        private Panel panel1;
        private Panel panelCarrito;
        private Panel panel10;
        private DataGridView dgvCategorias;
        private Button btnAgregarCategoria;
        private Panel panelBusqueda;
        private TextBox txtBuscar;
        private Button btnbuscar;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnModificarBodega;
        private Button btnSeleccionarCategoria;
        private Button btnSalir;
        private GroupBox gbxEstado;
        private RadioButton rbMostrarDeshabilitados;
        private RadioButton rbMostrarTodos;
        private RadioButton rbMostrarHabilitados;
        private DataGridViewTextBoxColumn IdMarca;
        private DataGridViewTextBoxColumn Tipo;
        private DataGridViewTextBoxColumn NombreBodega;
        private DataGridViewTextBoxColumn Descripcion;
        private DataGridViewCheckBoxColumn EstadoBodega;
        private Button btnAgregarBodega;
    }
}