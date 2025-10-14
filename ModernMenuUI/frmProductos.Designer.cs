namespace ModernMenuUI
{
    partial class Gestion_de_Inventario
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gestion_de_Inventario));
            panelCarrito = new Panel();
            panel10 = new Panel();
            dgvProductos = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            Categoria = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            PorcentajeGanancia = new DataGridViewTextBoxColumn();
            PrecioCompra = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            PrecioVenta = new DataGridViewTextBoxColumn();
            panelBusqueda = new Panel();
            txtBuscar = new TextBox();
            btnbuscar = new Button();
            btnNuevoProducto = new Button();
            btnSalir = new Button();
            button1 = new Button();
            groupBox1 = new GroupBox();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            lblFecha = new Label();
            lblHora = new Label();
            HoraFecha = new System.Windows.Forms.Timer(components);
            tableLayoutPanel1 = new TableLayoutPanel();
            button4 = new Button();
            btnNuevo = new Button();
            panel1 = new Panel();
            panelCarrito.SuspendLayout();
            panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            panelBusqueda.SuspendLayout();
            groupBox1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelCarrito
            // 
            panelCarrito.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelCarrito.BackColor = Color.FromArgb(189, 215, 238);
            panelCarrito.Controls.Add(panel10);
            panelCarrito.Location = new Point(15, 17);
            panelCarrito.Name = "panelCarrito";
            panelCarrito.Size = new Size(711, 358);
            panelCarrito.TabIndex = 13;
            // 
            // panel10
            // 
            panel10.AutoScroll = true;
            panel10.Controls.Add(dgvProductos);
            panel10.Dock = DockStyle.Fill;
            panel10.Location = new Point(0, 0);
            panel10.Name = "panel10";
            panel10.Size = new Size(711, 358);
            panel10.TabIndex = 17;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dgvProductos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvProductos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvProductos.BackgroundColor = Color.FromArgb(189, 215, 238);
            dgvProductos.BorderStyle = BorderStyle.None;
            dgvProductos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProductos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle2.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, Categoria, dataGridViewTextBoxColumn4, PorcentajeGanancia, PrecioCompra, dataGridViewTextBoxColumn3, PrecioVenta });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle4.Padding = new Padding(5);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvProductos.DefaultCellStyle = dataGridViewCellStyle4;
            dgvProductos.EnableHeadersVisualStyles = false;
            dgvProductos.GridColor = Color.FromArgb(189, 215, 238);
            dgvProductos.Location = new Point(0, 0);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(102, 102, 102);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvProductos.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvProductos.RowHeadersWidth = 30;
            dgvProductos.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvProductos.RowTemplate.Height = 50;
            dgvProductos.Size = new Size(711, 358);
            dgvProductos.TabIndex = 1;
            dgvProductos.SelectionChanged += dgvProductos_SelectionChanged;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle3.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.Padding = new Padding(0, 1, 0, 0);
            dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewTextBoxColumn1.FillWeight = 80F;
            dataGridViewTextBoxColumn1.HeaderText = "Código";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Producto";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // Categoria
            // 
            Categoria.FillWeight = 80F;
            Categoria.HeaderText = "Categoría";
            Categoria.Name = "Categoria";
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.FillWeight = 70F;
            dataGridViewTextBoxColumn4.HeaderText = "Marca";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // PorcentajeGanancia
            // 
            PorcentajeGanancia.FillWeight = 80F;
            PorcentajeGanancia.HeaderText = "Ganancia";
            PorcentajeGanancia.Name = "PorcentajeGanancia";
            // 
            // PrecioCompra
            // 
            PrecioCompra.FillWeight = 80F;
            PrecioCompra.HeaderText = "Precio Compra";
            PrecioCompra.Name = "PrecioCompra";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.FillWeight = 80F;
            dataGridViewTextBoxColumn3.HeaderText = "Precio Costo";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // PrecioVenta
            // 
            PrecioVenta.FillWeight = 80F;
            PrecioVenta.HeaderText = "Precio Venta";
            PrecioVenta.Name = "PrecioVenta";
            // 
            // panelBusqueda
            // 
            panelBusqueda.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelBusqueda.BackColor = Color.FromArgb(189, 215, 238);
            panelBusqueda.Controls.Add(txtBuscar);
            panelBusqueda.Controls.Add(btnbuscar);
            panelBusqueda.Location = new Point(12, 32);
            panelBusqueda.Name = "panelBusqueda";
            panelBusqueda.Size = new Size(742, 43);
            panelBusqueda.TabIndex = 14;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.BorderStyle = BorderStyle.None;
            txtBuscar.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(18, 12);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar Productos...";
            txtBuscar.Size = new Size(657, 20);
            txtBuscar.TabIndex = 1;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // btnbuscar
            // 
            btnbuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnbuscar.BackColor = Color.FromArgb(168, 191, 212);
            btnbuscar.BackgroundImage = (Image)resources.GetObject("btnbuscar.BackgroundImage");
            btnbuscar.BackgroundImageLayout = ImageLayout.Zoom;
            btnbuscar.FlatAppearance.BorderSize = 0;
            btnbuscar.FlatStyle = FlatStyle.Flat;
            btnbuscar.Location = new Point(681, 12);
            btnbuscar.Name = "btnbuscar";
            btnbuscar.Size = new Size(48, 20);
            btnbuscar.TabIndex = 0;
            btnbuscar.UseVisualStyleBackColor = false;
            // 
            // btnNuevoProducto
            // 
            btnNuevoProducto.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnNuevoProducto.BackColor = Color.FromArgb(149, 195, 172);
            btnNuevoProducto.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNuevoProducto.ForeColor = SystemColors.ButtonFace;
            btnNuevoProducto.Location = new Point(3, 3);
            btnNuevoProducto.Name = "btnNuevoProducto";
            btnNuevoProducto.Size = new Size(143, 44);
            btnNuevoProducto.TabIndex = 17;
            btnNuevoProducto.Text = "Nuevo Producto";
            btnNuevoProducto.UseVisualStyleBackColor = false;
            btnNuevoProducto.Click += btnNuevoProducto_Click;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSalir.BackColor = Color.FromArgb(148, 168, 187);
            btnSalir.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.White;
            btnSalir.ImageAlign = ContentAlignment.TopCenter;
            btnSalir.Location = new Point(301, 3);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(97, 44);
            btnSalir.TabIndex = 18;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.BackColor = Color.FromArgb(149, 195, 172);
            button1.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(152, 3);
            button1.Name = "button1";
            button1.Size = new Size(143, 44);
            button1.TabIndex = 21;
            button1.Text = "Agregar Marca";
            button1.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = SystemColors.ControlDarkDark;
            groupBox1.Location = new Point(12, 85);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(742, 53);
            groupBox1.TabIndex = 28;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtro";
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(341, 21);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(178, 22);
            radioButton3.TabIndex = 30;
            radioButton3.Text = "Mostrar Deshabilitados";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Checked = true;
            radioButton2.Location = new Point(158, 21);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(156, 22);
            radioButton2.TabIndex = 29;
            radioButton2.TabStop = true;
            radioButton2.Text = "Mostrar Habilitados";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(18, 21);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(120, 22);
            radioButton1.TabIndex = 28;
            radioButton1.Text = "Mostrar Todos";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // lblFecha
            // 
            lblFecha.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Itim", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFecha.ForeColor = Color.FromArgb(148, 168, 187);
            lblFecha.Location = new Point(481, 645);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(67, 25);
            lblFecha.TabIndex = 30;
            lblFecha.Text = "label3";
            // 
            // lblHora
            // 
            lblHora.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblHora.AutoSize = true;
            lblHora.Font = new Font("Itim", 20.2499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHora.ForeColor = Color.FromArgb(148, 168, 187);
            lblHora.Location = new Point(481, 607);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(87, 33);
            lblHora.TabIndex = 29;
            lblHora.Text = "label3";
            // 
            // HoraFecha
            // 
            HoraFecha.Enabled = true;
            HoraFecha.Tick += HoraFecha_Tick;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 102F));
            tableLayoutPanel1.Controls.Add(button4, 0, 1);
            tableLayoutPanel1.Controls.Add(btnNuevo, 1, 1);
            tableLayoutPanel1.Controls.Add(btnNuevoProducto, 0, 0);
            tableLayoutPanel1.Controls.Add(btnSalir, 2, 0);
            tableLayoutPanel1.Controls.Add(button1, 1, 0);
            tableLayoutPanel1.Location = new Point(12, 563);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(401, 100);
            tableLayoutPanel1.TabIndex = 31;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button4.BackColor = Color.FromArgb(149, 195, 172);
            button4.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.ForeColor = SystemColors.ButtonFace;
            button4.Location = new Point(3, 53);
            button4.Name = "button4";
            button4.Size = new Size(143, 44);
            button4.TabIndex = 22;
            button4.Text = "Agregar Categoria";
            button4.UseVisualStyleBackColor = false;
            // 
            // btnNuevo
            // 
            btnNuevo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnNuevo.BackColor = Color.FromArgb(189, 215, 238);
            btnNuevo.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNuevo.ForeColor = Color.FromArgb(87, 99, 110);
            btnNuevo.Location = new Point(152, 53);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(143, 44);
            btnNuevo.TabIndex = 20;
            btnNuevo.Text = "Editar Producto";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += button3_Click_1;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(189, 215, 238);
            panel1.Controls.Add(panelCarrito);
            panel1.Location = new Point(15, 158);
            panel1.Name = "panel1";
            panel1.Size = new Size(739, 388);
            panel1.TabIndex = 32;
            // 
            // Gestion_de_Inventario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(766, 679);
            Controls.Add(panel1);
            Controls.Add(lblFecha);
            Controls.Add(lblHora);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(groupBox1);
            Controls.Add(panelBusqueda);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Gestion_de_Inventario";
            Text = "Gestion_de_Inventario";
            panelCarrito.ResumeLayout(false);
            panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            panelBusqueda.ResumeLayout(false);
            panelBusqueda.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelCarrito;
        private Panel panel10;
        private DataGridView dgvProductos;
        private Panel panelBusqueda;
        private TextBox txtBuscar;
        private Button btnbuscar;
        private Button btnNuevoProducto;
        private Button btnSalir;
        private Button button1;
        private GroupBox groupBox1;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Label lblFecha;
        private Label lblHora;
        private System.Windows.Forms.Timer HoraFecha;
        private TableLayoutPanel tableLayoutPanel1;
        private Button button4;
        private Button btnNuevo;
        private Panel panel1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn Categoria;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn PorcentajeGanancia;
        private DataGridViewTextBoxColumn PrecioCompra;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn PrecioVenta;
    }
}