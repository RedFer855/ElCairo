namespace ModernMenuUI
{
    partial class frmAgregarEditarProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarEditarProducto));
            pnlEditarProducto = new Panel();
            button1 = new Button();
            fpnlDinamico = new FlowLayoutPanel();
            pnlDatosGenerales = new Panel();
            txtCategoria = new TextBox();
            label15 = new Label();
            label13 = new Label();
            txtMarca = new TextBox();
            label12 = new Label();
            txtContenido = new TextBox();
            txtPresentacion = new TextBox();
            cmbUnidadContenido = new ComboBox();
            label16 = new Label();
            txtCodBarra = new TextBox();
            label22 = new Label();
            label18 = new Label();
            label19 = new Label();
            txtNombreProducto = new TextBox();
            btnBuscarCategoria = new Button();
            btnBuscarPresentacion = new Button();
            btnBuscarMarca = new Button();
            pnlCantidad = new Panel();
            label25 = new Label();
            nudCantidad = new NumericUpDown();
            label9 = new Label();
            pnlCompras = new Panel();
            label23 = new Label();
            label21 = new Label();
            nudPrecioCosto = new NumericUpDown();
            label11 = new Label();
            nudPrecioCompra = new NumericUpDown();
            label20 = new Label();
            pnlVentas = new Panel();
            label2 = new Label();
            gbxTipoGanancia = new GroupBox();
            rbPorcentual = new RadioButton();
            rbFija = new RadioButton();
            label24 = new Label();
            label14 = new Label();
            nudPorcentajeGanancia = new NumericUpDown();
            nudPrecioVenta = new NumericUpDown();
            label17 = new Label();
            panel3 = new Panel();
            groupBox1 = new GroupBox();
            radioButton3 = new RadioButton();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            label1 = new Label();
            gbxEstadoProductoNuevo = new GroupBox();
            rbDeshabilitado = new RadioButton();
            rbHabilitado = new RadioButton();
            lblEstado = new Label();
            pbxImagenProducto = new PictureBox();
            tipEditar = new ToolTip(components);
            tipCompras = new ToolTip(components);
            hpVentaGanancia = new HelpProvider();
            tipGanancia = new ToolTip(components);
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnGuardarProducto = new Button();
            btnModificarProducto = new Button();
            btnModificarImagen = new Button();
            panel2 = new Panel();
            flpVerEditar = new FlowLayoutPanel();
            pnlVisualizacion = new Panel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            lblCodigoBarraProducto = new Label();
            lblNombreProducto = new Label();
            lblDescripccion = new Label();
            lblCantidad = new Label();
            lblPrecioVenta = new Label();
            pbxImagenProductoVer = new PictureBox();
            label3 = new Label();
            pnlEditarProducto.SuspendLayout();
            fpnlDinamico.SuspendLayout();
            pnlDatosGenerales.SuspendLayout();
            pnlCantidad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            pnlCompras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPrecioCosto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecioCompra).BeginInit();
            pnlVentas.SuspendLayout();
            gbxTipoGanancia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPorcentajeGanancia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecioVenta).BeginInit();
            panel3.SuspendLayout();
            groupBox1.SuspendLayout();
            gbxEstadoProductoNuevo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxImagenProducto).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            flpVerEditar.SuspendLayout();
            pnlVisualizacion.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxImagenProductoVer).BeginInit();
            SuspendLayout();
            // 
            // pnlEditarProducto
            // 
            pnlEditarProducto.BackColor = Color.FromArgb(189, 215, 238);
            pnlEditarProducto.Controls.Add(button1);
            pnlEditarProducto.Controls.Add(fpnlDinamico);
            pnlEditarProducto.Controls.Add(gbxEstadoProductoNuevo);
            pnlEditarProducto.Controls.Add(lblEstado);
            pnlEditarProducto.Controls.Add(pbxImagenProducto);
            pnlEditarProducto.Location = new Point(0, 0);
            pnlEditarProducto.Margin = new Padding(0);
            pnlEditarProducto.Name = "pnlEditarProducto";
            pnlEditarProducto.Size = new Size(840, 497);
            pnlEditarProducto.TabIndex = 41;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(149, 195, 172);
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatAppearance.BorderSize = 0;
            button1.Font = new Font("Itim", 11.9999981F);
            button1.ForeColor = SystemColors.ButtonFace;
            button1.ImageAlign = ContentAlignment.BottomLeft;
            button1.Location = new Point(471, 380);
            button1.Name = "button1";
            button1.Size = new Size(350, 35);
            button1.TabIndex = 68;
            button1.Text = "Agregar o Modificar Imagen";
            button1.UseVisualStyleBackColor = false;
            // 
            // fpnlDinamico
            // 
            fpnlDinamico.Controls.Add(pnlDatosGenerales);
            fpnlDinamico.Controls.Add(pnlCantidad);
            fpnlDinamico.Controls.Add(pnlCompras);
            fpnlDinamico.Controls.Add(pnlVentas);
            fpnlDinamico.Controls.Add(panel3);
            fpnlDinamico.Location = new Point(18, 20);
            fpnlDinamico.Name = "fpnlDinamico";
            fpnlDinamico.Size = new Size(439, 474);
            fpnlDinamico.TabIndex = 67;
            // 
            // pnlDatosGenerales
            // 
            pnlDatosGenerales.Controls.Add(txtCategoria);
            pnlDatosGenerales.Controls.Add(label15);
            pnlDatosGenerales.Controls.Add(label13);
            pnlDatosGenerales.Controls.Add(txtMarca);
            pnlDatosGenerales.Controls.Add(label12);
            pnlDatosGenerales.Controls.Add(txtContenido);
            pnlDatosGenerales.Controls.Add(txtPresentacion);
            pnlDatosGenerales.Controls.Add(cmbUnidadContenido);
            pnlDatosGenerales.Controls.Add(label16);
            pnlDatosGenerales.Controls.Add(txtCodBarra);
            pnlDatosGenerales.Controls.Add(label22);
            pnlDatosGenerales.Controls.Add(label18);
            pnlDatosGenerales.Controls.Add(label19);
            pnlDatosGenerales.Controls.Add(txtNombreProducto);
            pnlDatosGenerales.Controls.Add(btnBuscarCategoria);
            pnlDatosGenerales.Controls.Add(btnBuscarPresentacion);
            pnlDatosGenerales.Controls.Add(btnBuscarMarca);
            pnlDatosGenerales.Location = new Point(0, 0);
            pnlDatosGenerales.Margin = new Padding(0);
            pnlDatosGenerales.Name = "pnlDatosGenerales";
            pnlDatosGenerales.Size = new Size(439, 176);
            pnlDatosGenerales.TabIndex = 62;
            // 
            // txtCategoria
            // 
            txtCategoria.BackColor = Color.White;
            txtCategoria.BorderStyle = BorderStyle.None;
            txtCategoria.Font = new Font("Itim", 11.9999981F);
            txtCategoria.ForeColor = Color.DimGray;
            txtCategoria.Location = new Point(151, 60);
            txtCategoria.Name = "txtCategoria";
            txtCategoria.PlaceholderText = "Seleccione Buscar...";
            txtCategoria.ReadOnly = true;
            txtCategoria.Size = new Size(221, 20);
            txtCategoria.TabIndex = 3;
            tipEditar.SetToolTip(txtCategoria, "Para editar este producto, presione el botón Editar.");
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Itim", 11.9999981F);
            label15.ForeColor = Color.FromArgb(87, 99, 110);
            label15.Location = new Point(61, 60);
            label15.Name = "label15";
            label15.Size = new Size(79, 19);
            label15.TabIndex = 0;
            label15.Text = "Categoría:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Itim", 11.9999981F);
            label13.ForeColor = Color.FromArgb(87, 99, 110);
            label13.Location = new Point(85, 90);
            label13.Name = "label13";
            label13.Size = new Size(55, 19);
            label13.TabIndex = 0;
            label13.Text = "Marca:";
            // 
            // txtMarca
            // 
            txtMarca.BackColor = Color.White;
            txtMarca.BorderStyle = BorderStyle.None;
            txtMarca.Font = new Font("Itim", 11.9999981F);
            txtMarca.ForeColor = Color.DimGray;
            txtMarca.Location = new Point(151, 90);
            txtMarca.Name = "txtMarca";
            txtMarca.PlaceholderText = "Seleccione Buscar..";
            txtMarca.ReadOnly = true;
            txtMarca.Size = new Size(221, 20);
            txtMarca.TabIndex = 5;
            tipEditar.SetToolTip(txtMarca, "Para editar este producto, presione el botón Editar.");
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Itim", 11.9999981F);
            label12.ForeColor = Color.FromArgb(87, 99, 110);
            label12.Location = new Point(38, 120);
            label12.Name = "label12";
            label12.Size = new Size(102, 19);
            label12.TabIndex = 0;
            label12.Text = "Presentación:";
            // 
            // txtContenido
            // 
            txtContenido.BackColor = Color.White;
            txtContenido.BorderStyle = BorderStyle.None;
            txtContenido.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContenido.ForeColor = Color.DimGray;
            txtContenido.Location = new Point(151, 150);
            txtContenido.Name = "txtContenido";
            txtContenido.PlaceholderText = "Cantidad...";
            txtContenido.Size = new Size(108, 20);
            txtContenido.TabIndex = 9;
            tipEditar.SetToolTip(txtContenido, "Para editar este producto, presione el botón Editar.");
            // 
            // txtPresentacion
            // 
            txtPresentacion.BackColor = Color.White;
            txtPresentacion.BorderStyle = BorderStyle.None;
            txtPresentacion.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPresentacion.ForeColor = Color.DimGray;
            txtPresentacion.Location = new Point(151, 120);
            txtPresentacion.Name = "txtPresentacion";
            txtPresentacion.PlaceholderText = "Seleccione Buscar...";
            txtPresentacion.ReadOnly = true;
            txtPresentacion.Size = new Size(221, 20);
            txtPresentacion.TabIndex = 7;
            tipEditar.SetToolTip(txtPresentacion, "Para editar este producto, presione el botón Editar.");
            // 
            // cmbUnidadContenido
            // 
            cmbUnidadContenido.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbUnidadContenido.ForeColor = Color.DimGray;
            cmbUnidadContenido.FormattingEnabled = true;
            cmbUnidadContenido.Items.AddRange(new object[] { "Unidad", "mg", "kg", "g", "lb", "oz", "ml", "cl", "l", "fl(oz)" });
            cmbUnidadContenido.Location = new Point(349, 150);
            cmbUnidadContenido.Name = "cmbUnidadContenido";
            cmbUnidadContenido.Size = new Size(77, 26);
            cmbUnidadContenido.TabIndex = 10;
            tipEditar.SetToolTip(cmbUnidadContenido, "Para editar este producto, presione el botón Editar.");
            cmbUnidadContenido.SelectedIndexChanged += cmbUnidadContenido_SelectedIndexChanged;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Itim", 11.9999981F);
            label16.ForeColor = Color.FromArgb(87, 99, 110);
            label16.Location = new Point(17, 0);
            label16.Name = "label16";
            label16.Size = new Size(123, 19);
            label16.TabIndex = 0;
            label16.Text = "Código de Barra:";
            // 
            // txtCodBarra
            // 
            txtCodBarra.BackColor = Color.White;
            txtCodBarra.BorderStyle = BorderStyle.None;
            txtCodBarra.Font = new Font("Itim", 11.9999981F);
            txtCodBarra.ForeColor = Color.DimGray;
            txtCodBarra.Location = new Point(151, 0);
            txtCodBarra.MaxLength = 13;
            txtCodBarra.Name = "txtCodBarra";
            txtCodBarra.PlaceholderText = "Ingrese o Escanee el Código...";
            txtCodBarra.Size = new Size(275, 20);
            txtCodBarra.TabIndex = 1;
            tipEditar.SetToolTip(txtCodBarra, "Para editar este producto, presione el botón Editar.");
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Itim", 11.9999981F);
            label22.ForeColor = Color.FromArgb(87, 99, 110);
            label22.Location = new Point(265, 150);
            label22.Name = "label22";
            label22.Size = new Size(78, 19);
            label22.TabIndex = 0;
            label22.Text = "Unidades:";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Itim", 11.9999981F);
            label18.ForeColor = Color.FromArgb(87, 99, 110);
            label18.Location = new Point(64, 30);
            label18.Name = "label18";
            label18.Size = new Size(76, 19);
            label18.TabIndex = 0;
            label18.Text = "Producto:";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Itim", 11.9999981F);
            label19.ForeColor = Color.FromArgb(87, 99, 110);
            label19.Location = new Point(56, 150);
            label19.Name = "label19";
            label19.Size = new Size(84, 19);
            label19.TabIndex = 0;
            label19.Text = "Contenido:";
            // 
            // txtNombreProducto
            // 
            txtNombreProducto.BackColor = Color.White;
            txtNombreProducto.BorderStyle = BorderStyle.None;
            txtNombreProducto.Font = new Font("Itim", 11.9999981F);
            txtNombreProducto.ForeColor = Color.DimGray;
            txtNombreProducto.Location = new Point(151, 30);
            txtNombreProducto.MaxLength = 500;
            txtNombreProducto.Name = "txtNombreProducto";
            txtNombreProducto.PlaceholderText = "Ingrese Nombre del Producto..";
            txtNombreProducto.Size = new Size(275, 20);
            txtNombreProducto.TabIndex = 2;
            tipEditar.SetToolTip(txtNombreProducto, "Para editar este producto, presione el botón Editar.");
            // 
            // btnBuscarCategoria
            // 
            btnBuscarCategoria.BackColor = Color.FromArgb(168, 191, 212);
            btnBuscarCategoria.BackgroundImage = (Image)resources.GetObject("btnBuscarCategoria.BackgroundImage");
            btnBuscarCategoria.BackgroundImageLayout = ImageLayout.Zoom;
            btnBuscarCategoria.FlatAppearance.BorderSize = 0;
            btnBuscarCategoria.FlatStyle = FlatStyle.Flat;
            btnBuscarCategoria.Location = new Point(378, 60);
            btnBuscarCategoria.Name = "btnBuscarCategoria";
            btnBuscarCategoria.Size = new Size(48, 20);
            btnBuscarCategoria.TabIndex = 4;
            tipEditar.SetToolTip(btnBuscarCategoria, "Para editar este producto, presione el botón Editar.");
            btnBuscarCategoria.UseVisualStyleBackColor = false;
            btnBuscarCategoria.Click += btnBuscarCategoria_Click;
            // 
            // btnBuscarPresentacion
            // 
            btnBuscarPresentacion.BackColor = Color.FromArgb(168, 191, 212);
            btnBuscarPresentacion.BackgroundImage = (Image)resources.GetObject("btnBuscarPresentacion.BackgroundImage");
            btnBuscarPresentacion.BackgroundImageLayout = ImageLayout.Zoom;
            btnBuscarPresentacion.FlatAppearance.BorderSize = 0;
            btnBuscarPresentacion.FlatStyle = FlatStyle.Flat;
            btnBuscarPresentacion.Location = new Point(378, 120);
            btnBuscarPresentacion.Name = "btnBuscarPresentacion";
            btnBuscarPresentacion.Size = new Size(48, 20);
            btnBuscarPresentacion.TabIndex = 8;
            tipEditar.SetToolTip(btnBuscarPresentacion, "Para editar este producto, presione el botón Editar.");
            btnBuscarPresentacion.UseVisualStyleBackColor = false;
            btnBuscarPresentacion.Click += btnBuscarPresentacion_Click;
            // 
            // btnBuscarMarca
            // 
            btnBuscarMarca.BackColor = Color.FromArgb(168, 191, 212);
            btnBuscarMarca.BackgroundImage = (Image)resources.GetObject("btnBuscarMarca.BackgroundImage");
            btnBuscarMarca.BackgroundImageLayout = ImageLayout.Zoom;
            btnBuscarMarca.FlatAppearance.BorderSize = 0;
            btnBuscarMarca.FlatStyle = FlatStyle.Flat;
            btnBuscarMarca.Location = new Point(378, 90);
            btnBuscarMarca.Name = "btnBuscarMarca";
            btnBuscarMarca.Size = new Size(48, 20);
            btnBuscarMarca.TabIndex = 6;
            tipEditar.SetToolTip(btnBuscarMarca, "Para editar este producto, presione el botón Editar.");
            btnBuscarMarca.UseVisualStyleBackColor = false;
            btnBuscarMarca.Click += btnBuscarMarca_Click;
            // 
            // pnlCantidad
            // 
            pnlCantidad.Controls.Add(label25);
            pnlCantidad.Controls.Add(nudCantidad);
            pnlCantidad.Controls.Add(label9);
            pnlCantidad.Location = new Point(0, 180);
            pnlCantidad.Margin = new Padding(0, 4, 0, 0);
            pnlCantidad.Name = "pnlCantidad";
            pnlCantidad.Size = new Size(439, 25);
            pnlCantidad.TabIndex = 11;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new Font("Itim", 11.9999981F);
            label25.ForeColor = Color.FromArgb(87, 99, 110);
            label25.Location = new Point(304, 1);
            label25.Name = "label25";
            label25.Size = new Size(122, 19);
            label25.TabIndex = 66;
            label25.Text = "(No Modificable)";
            tipCompras.SetToolTip(label25, "Incremente la Cantidad Ingresando una Compra.");
            // 
            // nudCantidad
            // 
            nudCantidad.Enabled = false;
            nudCantidad.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudCantidad.ForeColor = Color.DimGray;
            nudCantidad.InterceptArrowKeys = false;
            nudCantidad.Location = new Point(151, 0);
            nudCantidad.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(147, 25);
            nudCantidad.TabIndex = 12;
            tipEditar.SetToolTip(nudCantidad, "Para editar este producto, presione el botón Editar.");
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Itim", 11.9999981F);
            label9.ForeColor = Color.FromArgb(87, 99, 110);
            label9.Location = new Point(64, 1);
            label9.Name = "label9";
            label9.Size = new Size(76, 19);
            label9.TabIndex = 40;
            label9.Text = "Cantidad:";
            // 
            // pnlCompras
            // 
            pnlCompras.Controls.Add(label23);
            pnlCompras.Controls.Add(label21);
            pnlCompras.Controls.Add(nudPrecioCosto);
            pnlCompras.Controls.Add(label11);
            pnlCompras.Controls.Add(nudPrecioCompra);
            pnlCompras.Controls.Add(label20);
            pnlCompras.Location = new Point(0, 215);
            pnlCompras.Margin = new Padding(0, 10, 0, 0);
            pnlCompras.Name = "pnlCompras";
            pnlCompras.Size = new Size(439, 60);
            pnlCompras.TabIndex = 13;
            tipCompras.SetToolTip(pnlCompras, "Estos valores solo pueden modificarse ingresando una compra.");
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Itim", 11.9999981F);
            label23.ForeColor = Color.FromArgb(87, 99, 110);
            label23.Location = new Point(304, 35);
            label23.Name = "label23";
            label23.Size = new Size(122, 19);
            label23.TabIndex = 66;
            label23.Text = "(No Modificable)";
            tipCompras.SetToolTip(label23, "Este valor se Calcula al ingresar una Compra.");
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Itim", 11.9999981F);
            label21.ForeColor = Color.FromArgb(87, 99, 110);
            label21.Location = new Point(304, 1);
            label21.Name = "label21";
            label21.Size = new Size(122, 19);
            label21.TabIndex = 65;
            label21.Text = "(No Modificable)";
            tipCompras.SetToolTip(label21, "Estos valores solo pueden modificarse ingresando una compra.");
            // 
            // nudPrecioCosto
            // 
            nudPrecioCosto.DecimalPlaces = 2;
            nudPrecioCosto.Enabled = false;
            nudPrecioCosto.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudPrecioCosto.ForeColor = Color.DimGray;
            nudPrecioCosto.InterceptArrowKeys = false;
            nudPrecioCosto.Location = new Point(151, 35);
            nudPrecioCosto.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudPrecioCosto.Name = "nudPrecioCosto";
            nudPrecioCosto.Size = new Size(147, 25);
            nudPrecioCosto.TabIndex = 15;
            tipEditar.SetToolTip(nudPrecioCosto, "Para editar este producto, presione el botón Editar.");
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Itim", 11.9999981F);
            label11.ForeColor = Color.FromArgb(87, 99, 110);
            label11.Location = new Point(8, 1);
            label11.Name = "label11";
            label11.Size = new Size(133, 19);
            label11.TabIndex = 38;
            label11.Text = "Precio de Compra:";
            // 
            // nudPrecioCompra
            // 
            nudPrecioCompra.DecimalPlaces = 2;
            nudPrecioCompra.Enabled = false;
            nudPrecioCompra.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudPrecioCompra.ForeColor = Color.DimGray;
            nudPrecioCompra.InterceptArrowKeys = false;
            nudPrecioCompra.Location = new Point(151, 0);
            nudPrecioCompra.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudPrecioCompra.Name = "nudPrecioCompra";
            nudPrecioCompra.Size = new Size(147, 25);
            nudPrecioCompra.TabIndex = 14;
            tipEditar.SetToolTip(nudPrecioCompra, "Para editar este producto, presione el botón Editar.");
            nudPrecioCompra.ValueChanged += nudPrecioCompra_ValueChanged;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Itim", 11.9999981F);
            label20.ForeColor = Color.FromArgb(87, 99, 110);
            label20.Location = new Point(21, 35);
            label20.Name = "label20";
            label20.Size = new Size(119, 19);
            label20.TabIndex = 63;
            label20.Text = "Precio de Costo:";
            tipCompras.SetToolTip(label20, "Este campo es Calculado.");
            // 
            // pnlVentas
            // 
            pnlVentas.Controls.Add(label2);
            pnlVentas.Controls.Add(gbxTipoGanancia);
            pnlVentas.Controls.Add(label24);
            pnlVentas.Controls.Add(label14);
            pnlVentas.Controls.Add(nudPorcentajeGanancia);
            pnlVentas.Controls.Add(nudPrecioVenta);
            pnlVentas.Controls.Add(label17);
            pnlVentas.Location = new Point(0, 285);
            pnlVentas.Margin = new Padding(0, 10, 0, 0);
            pnlVentas.Name = "pnlVentas";
            pnlVentas.Size = new Size(439, 103);
            pnlVentas.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Itim", 11.9999981F);
            label2.ForeColor = Color.FromArgb(87, 99, 110);
            label2.Location = new Point(8, 75);
            label2.Name = "label2";
            label2.Size = new Size(131, 19);
            label2.TabIndex = 69;
            label2.Text = "Tipo de Ganancia:";
            // 
            // gbxTipoGanancia
            // 
            gbxTipoGanancia.Controls.Add(rbPorcentual);
            gbxTipoGanancia.Controls.Add(rbFija);
            gbxTipoGanancia.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbxTipoGanancia.ForeColor = Color.DimGray;
            gbxTipoGanancia.Location = new Point(151, 60);
            gbxTipoGanancia.Name = "gbxTipoGanancia";
            hpVentaGanancia.SetShowHelp(gbxTipoGanancia, true);
            gbxTipoGanancia.Size = new Size(168, 40);
            gbxTipoGanancia.TabIndex = 32;
            gbxTipoGanancia.TabStop = false;
            tipGanancia.SetToolTip(gbxTipoGanancia, "Seleccione como se calcula la ganancia del producto.");
            // 
            // rbPorcentual
            // 
            rbPorcentual.AutoSize = true;
            rbPorcentual.Location = new Point(67, 15);
            rbPorcentual.Name = "rbPorcentual";
            rbPorcentual.Size = new Size(102, 23);
            rbPorcentual.TabIndex = 17;
            rbPorcentual.Text = "Porcentual";
            tipGanancia.SetToolTip(rbPorcentual, "El porcentaje de ganancia se mantiene fijo y el precio de venta se calcula según el costo.");
            rbPorcentual.UseVisualStyleBackColor = true;
            // 
            // rbFija
            // 
            rbFija.AutoSize = true;
            rbFija.Location = new Point(10, 15);
            rbFija.Name = "rbFija";
            rbFija.Size = new Size(51, 23);
            rbFija.TabIndex = 16;
            rbFija.Text = "Fija";
            tipGanancia.SetToolTip(rbFija, "El precio de venta se mantiene fijo y el porcentaje de ganancia se calcula según el costo.");
            rbFija.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Itim", 11.9999981F);
            label24.ForeColor = Color.FromArgb(87, 99, 110);
            label24.Location = new Point(235, 35);
            label24.Name = "label24";
            label24.Size = new Size(20, 19);
            label24.TabIndex = 62;
            label24.Text = "%";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Itim", 11.9999981F);
            label14.ForeColor = Color.FromArgb(87, 99, 110);
            label14.Location = new Point(61, 35);
            label14.Name = "label14";
            label14.Size = new Size(78, 19);
            label14.TabIndex = 61;
            label14.Text = "Ganancia:";
            // 
            // nudPorcentajeGanancia
            // 
            nudPorcentajeGanancia.DecimalPlaces = 2;
            nudPorcentajeGanancia.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudPorcentajeGanancia.ForeColor = Color.DimGray;
            nudPorcentajeGanancia.InterceptArrowKeys = false;
            nudPorcentajeGanancia.Location = new Point(151, 35);
            nudPorcentajeGanancia.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudPorcentajeGanancia.Name = "nudPorcentajeGanancia";
            nudPorcentajeGanancia.Size = new Size(85, 25);
            nudPorcentajeGanancia.TabIndex = 15;
            tipEditar.SetToolTip(nudPorcentajeGanancia, "Para editar este producto, presione el botón Editar.");
            // 
            // nudPrecioVenta
            // 
            nudPrecioVenta.DecimalPlaces = 2;
            nudPrecioVenta.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudPrecioVenta.ForeColor = Color.DimGray;
            nudPrecioVenta.InterceptArrowKeys = false;
            nudPrecioVenta.Location = new Point(151, 0);
            nudPrecioVenta.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudPrecioVenta.Name = "nudPrecioVenta";
            nudPrecioVenta.Size = new Size(147, 25);
            nudPrecioVenta.TabIndex = 14;
            tipEditar.SetToolTip(nudPrecioVenta, "Para editar este producto, presione el botón Editar.");
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Itim", 11.9999981F);
            label17.ForeColor = Color.FromArgb(87, 99, 110);
            label17.Location = new Point(32, 1);
            label17.Name = "label17";
            label17.Size = new Size(107, 19);
            label17.TabIndex = 16;
            label17.Text = "Precio sin ISV:";
            // 
            // panel3
            // 
            panel3.Controls.Add(label3);
            panel3.Controls.Add(groupBox1);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(0, 398);
            panel3.Margin = new Padding(0, 10, 0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(439, 76);
            panel3.TabIndex = 63;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.DimGray;
            groupBox1.Location = new Point(151, -8);
            groupBox1.Name = "groupBox1";
            hpVentaGanancia.SetShowHelp(groupBox1, true);
            groupBox1.Size = new Size(209, 40);
            groupBox1.TabIndex = 33;
            groupBox1.TabStop = false;
            tipGanancia.SetToolTip(groupBox1, "Seleccione como se calcula la ganancia del producto.");
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(149, 15);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(54, 23);
            radioButton3.TabIndex = 18;
            radioButton3.Text = "18%";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(90, 15);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(53, 23);
            radioButton1.TabIndex = 17;
            radioButton1.Text = "15%";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(10, 15);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(75, 23);
            radioButton2.TabIndex = 16;
            radioButton2.Text = "Exento";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(87, 99, 110);
            label1.Location = new Point(61, 7);
            label1.Name = "label1";
            label1.Size = new Size(78, 19);
            label1.TabIndex = 70;
            label1.Text = "Impuesto:";
            // 
            // gbxEstadoProductoNuevo
            // 
            gbxEstadoProductoNuevo.Controls.Add(rbDeshabilitado);
            gbxEstadoProductoNuevo.Controls.Add(rbHabilitado);
            gbxEstadoProductoNuevo.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbxEstadoProductoNuevo.ForeColor = Color.DimGray;
            gbxEstadoProductoNuevo.Location = new Point(576, 418);
            gbxEstadoProductoNuevo.Name = "gbxEstadoProductoNuevo";
            gbxEstadoProductoNuevo.Size = new Size(196, 40);
            gbxEstadoProductoNuevo.TabIndex = 30;
            gbxEstadoProductoNuevo.TabStop = false;
            // 
            // rbDeshabilitado
            // 
            rbDeshabilitado.AutoSize = true;
            rbDeshabilitado.Location = new Point(89, 15);
            rbDeshabilitado.Name = "rbDeshabilitado";
            rbDeshabilitado.Size = new Size(82, 23);
            rbDeshabilitado.TabIndex = 22;
            rbDeshabilitado.Text = "Inactivo";
            rbDeshabilitado.UseVisualStyleBackColor = true;
            // 
            // rbHabilitado
            // 
            rbHabilitado.AutoSize = true;
            rbHabilitado.Checked = true;
            rbHabilitado.Location = new Point(7, 15);
            rbHabilitado.Name = "rbHabilitado";
            rbHabilitado.Size = new Size(70, 23);
            rbHabilitado.TabIndex = 21;
            rbHabilitado.TabStop = true;
            rbHabilitado.Text = "Activo";
            rbHabilitado.UseVisualStyleBackColor = true;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEstado.ForeColor = Color.FromArgb(87, 99, 110);
            lblEstado.Location = new Point(504, 433);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(60, 19);
            lblEstado.TabIndex = 26;
            lblEstado.Text = "Estado:";
            // 
            // pbxImagenProducto
            // 
            pbxImagenProducto.BackColor = Color.White;
            pbxImagenProducto.BorderStyle = BorderStyle.FixedSingle;
            pbxImagenProducto.Image = (Image)resources.GetObject("pbxImagenProducto.Image");
            pbxImagenProducto.Location = new Point(471, 20);
            pbxImagenProducto.Name = "pbxImagenProducto";
            pbxImagenProducto.Size = new Size(350, 350);
            pbxImagenProducto.SizeMode = PictureBoxSizeMode.Zoom;
            pbxImagenProducto.TabIndex = 43;
            pbxImagenProducto.TabStop = false;
            // 
            // tipEditar
            // 
            tipEditar.AutoPopDelay = 5000;
            tipEditar.InitialDelay = 300;
            tipEditar.ReshowDelay = 100;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            flowLayoutPanel1.Controls.Add(btnGuardarProducto);
            flowLayoutPanel1.Controls.Add(btnModificarProducto);
            flowLayoutPanel1.Controls.Add(btnModificarImagen);
            flowLayoutPanel1.Location = new Point(0, 497);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(457, 35);
            flowLayoutPanel1.TabIndex = 51;
            // 
            // btnGuardarProducto
            // 
            btnGuardarProducto.BackColor = Color.FromArgb(149, 195, 172);
            btnGuardarProducto.BackgroundImageLayout = ImageLayout.None;
            btnGuardarProducto.FlatAppearance.BorderSize = 0;
            btnGuardarProducto.Font = new Font("Itim", 11.9999981F);
            btnGuardarProducto.ForeColor = SystemColors.ButtonFace;
            btnGuardarProducto.ImageAlign = ContentAlignment.BottomLeft;
            btnGuardarProducto.Location = new Point(3, 3);
            btnGuardarProducto.Name = "btnGuardarProducto";
            btnGuardarProducto.Size = new Size(142, 30);
            btnGuardarProducto.TabIndex = 47;
            btnGuardarProducto.Text = "Guardar";
            btnGuardarProducto.UseVisualStyleBackColor = false;
            btnGuardarProducto.Visible = false;
            btnGuardarProducto.Click += btnGuardarProducto_Click;
            // 
            // btnModificarProducto
            // 
            btnModificarProducto.BackColor = Color.FromArgb(74, 148, 225);
            btnModificarProducto.BackgroundImageLayout = ImageLayout.None;
            btnModificarProducto.FlatAppearance.BorderSize = 0;
            btnModificarProducto.Font = new Font("Itim", 11.9999981F);
            btnModificarProducto.ForeColor = SystemColors.ButtonFace;
            btnModificarProducto.ImageAlign = ContentAlignment.BottomLeft;
            btnModificarProducto.Location = new Point(151, 3);
            btnModificarProducto.Name = "btnModificarProducto";
            btnModificarProducto.Size = new Size(124, 31);
            btnModificarProducto.TabIndex = 48;
            btnModificarProducto.Text = "Editar";
            btnModificarProducto.UseVisualStyleBackColor = false;
            btnModificarProducto.Click += btnModificarProducto_Click;
            // 
            // btnModificarImagen
            // 
            btnModificarImagen.BackColor = Color.FromArgb(148, 168, 187);
            btnModificarImagen.BackgroundImageLayout = ImageLayout.None;
            btnModificarImagen.FlatAppearance.BorderSize = 0;
            btnModificarImagen.Font = new Font("Itim", 11.9999981F);
            btnModificarImagen.ForeColor = SystemColors.ButtonFace;
            btnModificarImagen.ImageAlign = ContentAlignment.BottomLeft;
            btnModificarImagen.Location = new Point(281, 3);
            btnModificarImagen.Name = "btnModificarImagen";
            btnModificarImagen.Size = new Size(97, 30);
            btnModificarImagen.TabIndex = 46;
            btnModificarImagen.Text = "Volver";
            btnModificarImagen.UseVisualStyleBackColor = false;
            btnModificarImagen.Click += btnVolver_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(189, 215, 238);
            panel2.Controls.Add(flpVerEditar);
            panel2.Controls.Add(flowLayoutPanel1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(840, 532);
            panel2.TabIndex = 12;
            // 
            // flpVerEditar
            // 
            flpVerEditar.Controls.Add(pnlEditarProducto);
            flpVerEditar.Controls.Add(pnlVisualizacion);
            flpVerEditar.Location = new Point(0, 0);
            flpVerEditar.Margin = new Padding(0);
            flpVerEditar.Name = "flpVerEditar";
            flpVerEditar.Size = new Size(840, 497);
            flpVerEditar.TabIndex = 71;
            // 
            // pnlVisualizacion
            // 
            pnlVisualizacion.BackColor = Color.White;
            pnlVisualizacion.Controls.Add(flowLayoutPanel2);
            pnlVisualizacion.Controls.Add(lblPrecioVenta);
            pnlVisualizacion.Controls.Add(pbxImagenProductoVer);
            pnlVisualizacion.Location = new Point(0, 497);
            pnlVisualizacion.Margin = new Padding(0);
            pnlVisualizacion.Name = "pnlVisualizacion";
            pnlVisualizacion.Size = new Size(840, 460);
            pnlVisualizacion.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(lblCodigoBarraProducto);
            flowLayoutPanel2.Controls.Add(lblNombreProducto);
            flowLayoutPanel2.Controls.Add(lblDescripccion);
            flowLayoutPanel2.Controls.Add(lblCantidad);
            flowLayoutPanel2.Location = new Point(396, 14);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(440, 379);
            flowLayoutPanel2.TabIndex = 74;
            // 
            // lblCodigoBarraProducto
            // 
            lblCodigoBarraProducto.FlatStyle = FlatStyle.Flat;
            lblCodigoBarraProducto.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCodigoBarraProducto.ForeColor = Color.FromArgb(4, 120, 237);
            lblCodigoBarraProducto.Location = new Point(3, 0);
            lblCodigoBarraProducto.Name = "lblCodigoBarraProducto";
            lblCodigoBarraProducto.Size = new Size(437, 35);
            lblCodigoBarraProducto.TabIndex = 70;
            lblCodigoBarraProducto.Text = "Código de Barra:";
            // 
            // lblNombreProducto
            // 
            lblNombreProducto.AutoEllipsis = true;
            lblNombreProducto.AutoSize = true;
            lblNombreProducto.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombreProducto.ForeColor = Color.Black;
            lblNombreProducto.Location = new Point(3, 35);
            lblNombreProducto.MaximumSize = new Size(492, 56);
            lblNombreProducto.Name = "lblNombreProducto";
            lblNombreProducto.Size = new Size(433, 56);
            lblNombreProducto.TabIndex = 72;
            lblNombreProducto.Text = "Nombre: Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s";
            // 
            // lblDescripccion
            // 
            lblDescripccion.AutoEllipsis = true;
            lblDescripccion.Font = new Font("Segoe UI", 10F);
            lblDescripccion.ForeColor = Color.DimGray;
            lblDescripccion.Location = new Point(3, 91);
            lblDescripccion.Name = "lblDescripccion";
            lblDescripccion.Size = new Size(437, 210);
            lblDescripccion.TabIndex = 71;
            lblDescripccion.Text = resources.GetString("lblDescripccion.Text");
            // 
            // lblCantidad
            // 
            lblCantidad.Font = new Font("Segoe UI Symbol", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCantidad.ForeColor = Color.FromArgb(74, 157, 91);
            lblCantidad.Location = new Point(3, 301);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(437, 24);
            lblCantidad.TabIndex = 73;
            lblCantidad.Text = "Disponible: ";
            // 
            // lblPrecioVenta
            // 
            lblPrecioVenta.AutoSize = true;
            lblPrecioVenta.Font = new Font("Segoe UI Symbol", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrecioVenta.ForeColor = Color.FromArgb(4, 120, 237);
            lblPrecioVenta.Location = new Point(396, 398);
            lblPrecioVenta.Name = "lblPrecioVenta";
            lblPrecioVenta.RightToLeft = RightToLeft.Yes;
            lblPrecioVenta.Size = new Size(98, 45);
            lblPrecioVenta.TabIndex = 68;
            lblPrecioVenta.Text = "L0,00";
            lblPrecioVenta.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pbxImagenProductoVer
            // 
            pbxImagenProductoVer.BackColor = Color.White;
            pbxImagenProductoVer.BorderStyle = BorderStyle.FixedSingle;
            pbxImagenProductoVer.Image = (Image)resources.GetObject("pbxImagenProductoVer.Image");
            pbxImagenProductoVer.Location = new Point(3, 15);
            pbxImagenProductoVer.Name = "pbxImagenProductoVer";
            pbxImagenProductoVer.Size = new Size(390, 428);
            pbxImagenProductoVer.SizeMode = PictureBoxSizeMode.Zoom;
            pbxImagenProductoVer.TabIndex = 69;
            pbxImagenProductoVer.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(87, 99, 110);
            label3.Location = new Point(61, 43);
            label3.Name = "label3";
            label3.Size = new Size(93, 19);
            label3.TabIndex = 71;
            label3.Text = "Precio Final:";
            // 
            // frmAgregarEditarProducto
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            ClientSize = new Size(840, 532);
            Controls.Add(panel2);
            Font = new Font("Itim", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAgregarEditarProducto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Producto";
            Load += frmAgregarEditarProducto_Load;
            MouseDown += Editar_Producto_MouseDown;
            pnlEditarProducto.ResumeLayout(false);
            pnlEditarProducto.PerformLayout();
            fpnlDinamico.ResumeLayout(false);
            pnlDatosGenerales.ResumeLayout(false);
            pnlDatosGenerales.PerformLayout();
            pnlCantidad.ResumeLayout(false);
            pnlCantidad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            pnlCompras.ResumeLayout(false);
            pnlCompras.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPrecioCosto).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecioCompra).EndInit();
            pnlVentas.ResumeLayout(false);
            pnlVentas.PerformLayout();
            gbxTipoGanancia.ResumeLayout(false);
            gbxTipoGanancia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPorcentajeGanancia).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecioVenta).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            gbxEstadoProductoNuevo.ResumeLayout(false);
            gbxEstadoProductoNuevo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbxImagenProducto).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            flpVerEditar.ResumeLayout(false);
            pnlVisualizacion.ResumeLayout(false);
            pnlVisualizacion.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbxImagenProductoVer).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlEditarProducto;
        private Label label9;
        private Label label11;
        private TextBox txtPresentacion;
        private Label label12;
        private TextBox txtMarca;
        private Label label13;
        private Label label15;
        private TextBox txtCategoria;
        private Label label16;
        private TextBox txtCodBarra;
        private Label label17;
        private Label label18;
        private TextBox txtNombreProducto;
        private Label label19;
        private PictureBox pbxImagenProducto;
        private Button btnBuscarMarca;
        private Button btnBuscarCategoria;
        private Button btnBuscarPresentacion;
        private ComboBox cmbUnidadContenido;
        private Label label22;
        private TextBox txtContenido;
        private NumericUpDown nudPrecioCompra;
        private NumericUpDown nudPrecioVenta;
        private NumericUpDown nudCantidad;
        private Panel pnlVentas;
        private NumericUpDown numericUpDown1;
        private Label label20;
        private Panel pnlDatosGenerales;
        private Panel pnlCompras;
        private FlowLayoutPanel fpnlDinamico;
        private ToolTip tipEditar;
        private Panel pnlCantidad;
        private NumericUpDown nudPrecioCosto;
        private Label label14;
        private NumericUpDown nudPorcentajeGanancia;
        private Label label23;
        private ToolTip tipCompras;
        private Label label21;
        private Label label24;
        private Label label25;
        private HelpProvider hpVentaGanancia;
        private GroupBox gbxTipoGanancia;
        private RadioButton rbPorcentual;
        private RadioButton rbFija;
        private ToolTip tipGanancia;
        private Label label2;
        private Button button1;
        private GroupBox gbxEstadoProductoNuevo;
        private RadioButton rbDeshabilitado;
        private RadioButton rbHabilitado;
        private Label lblEstado;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnGuardarProducto;
        private Button btnModificarProducto;
        private Button btnModificarImagen;
        private Panel panel2;
        private FlowLayoutPanel flpVerEditar;
        private Panel pnlVisualizacion;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label lblCodigoBarraProducto;
        private Label lblNombreProducto;
        private Label lblDescripccion;
        private Label lblCantidad;
        private Label lblPrecioVenta;
        private PictureBox pbxImagenProductoVer;
        private Panel panel3;
        private Label label1;
        private GroupBox groupBox1;
        private RadioButton radioButton3;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Label label3;
    }
}