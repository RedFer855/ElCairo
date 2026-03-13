namespace ModernMenuUI.InterfacesUsuarios.Inventario
{
    partial class frmAgregarEditarGananciaModo
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
            panel1 = new Panel();
            btnGuardarProducto = new Button();
            label3 = new Label();
            nudPrecioCosto = new NumericUpDown();
            label20 = new Label();
            nudPrecioCompra = new NumericUpDown();
            label11 = new Label();
            nudGanancia = new NumericUpDown();
            label2 = new Label();
            nudPrecioFinal = new NumericUpDown();
            groupBox1 = new GroupBox();
            btnPrecioFijoInfo = new Button();
            btnGananciaFijaInfo = new Button();
            rbPrecio = new RadioButton();
            rbGanancia = new RadioButton();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPrecioCosto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecioCompra).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudGanancia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecioFinal).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(189, 215, 238);
            panel1.Controls.Add(btnGuardarProducto);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(nudPrecioCosto);
            panel1.Controls.Add(label20);
            panel1.Controls.Add(nudPrecioCompra);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(nudGanancia);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(nudPrecioFinal);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(590, 481);
            panel1.TabIndex = 0;
            // 
            // btnGuardarProducto
            // 
            btnGuardarProducto.BackColor = Color.FromArgb(149, 195, 172);
            btnGuardarProducto.BackgroundImageLayout = ImageLayout.None;
            btnGuardarProducto.FlatAppearance.BorderSize = 0;
            btnGuardarProducto.Font = new Font("Itim", 11.9999981F);
            btnGuardarProducto.ForeColor = SystemColors.ButtonFace;
            btnGuardarProducto.ImageAlign = ContentAlignment.BottomLeft;
            btnGuardarProducto.Location = new Point(65, 409);
            btnGuardarProducto.Name = "btnGuardarProducto";
            btnGuardarProducto.Size = new Size(89, 40);
            btnGuardarProducto.TabIndex = 72;
            btnGuardarProducto.Text = "Guardar";
            btnGuardarProducto.UseVisualStyleBackColor = false;
            btnGuardarProducto.Click += btnGuardarProducto_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Itim", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(65, 24);
            label3.Name = "label3";
            label3.Size = new Size(312, 29);
            label3.TabIndex = 68;
            label3.Text = "Ingreso de Precio y Ganancia";
            // 
            // nudPrecioCosto
            // 
            nudPrecioCosto.DecimalPlaces = 2;
            nudPrecioCosto.Enabled = false;
            nudPrecioCosto.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudPrecioCosto.ForeColor = Color.DimGray;
            nudPrecioCosto.Location = new Point(239, 152);
            nudPrecioCosto.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudPrecioCosto.Name = "nudPrecioCosto";
            nudPrecioCosto.Size = new Size(275, 25);
            nudPrecioCosto.TabIndex = 71;
            nudPrecioCosto.ValueChanged += nudPrecioCosto_ValueChanged;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Itim", 11.9999981F);
            label20.ForeColor = Color.Black;
            label20.Location = new Point(76, 153);
            label20.Name = "label20";
            label20.Size = new Size(119, 19);
            label20.TabIndex = 70;
            label20.Text = "Precio de Costo:";
            // 
            // nudPrecioCompra
            // 
            nudPrecioCompra.DecimalPlaces = 2;
            nudPrecioCompra.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudPrecioCompra.ForeColor = Color.DimGray;
            nudPrecioCompra.Location = new Point(239, 114);
            nudPrecioCompra.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudPrecioCompra.Name = "nudPrecioCompra";
            nudPrecioCompra.Size = new Size(275, 25);
            nudPrecioCompra.TabIndex = 69;
            nudPrecioCompra.ValueChanged += nudPrecioCompra_ValueChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Itim", 11.9999981F);
            label11.ForeColor = Color.Black;
            label11.Location = new Point(65, 115);
            label11.Name = "label11";
            label11.Size = new Size(133, 19);
            label11.TabIndex = 67;
            label11.Text = "Precio de Compra:";
            // 
            // nudGanancia
            // 
            nudGanancia.DecimalPlaces = 2;
            nudGanancia.Font = new Font("Itim", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudGanancia.ForeColor = Color.DimGray;
            nudGanancia.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            nudGanancia.Location = new Point(239, 288);
            nudGanancia.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudGanancia.Name = "nudGanancia";
            nudGanancia.Size = new Size(275, 30);
            nudGanancia.TabIndex = 63;
            nudGanancia.ValueChanged += nudGanancia_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(68, 341);
            label2.Name = "label2";
            label2.Size = new Size(88, 18);
            label2.TabIndex = 62;
            label2.Text = "Precio Final:";
            // 
            // nudPrecioFinal
            // 
            nudPrecioFinal.DecimalPlaces = 2;
            nudPrecioFinal.Font = new Font("Itim", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudPrecioFinal.ForeColor = Color.DimGray;
            nudPrecioFinal.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            nudPrecioFinal.Location = new Point(239, 335);
            nudPrecioFinal.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudPrecioFinal.Name = "nudPrecioFinal";
            nudPrecioFinal.Size = new Size(275, 30);
            nudPrecioFinal.TabIndex = 61;
            nudPrecioFinal.ValueChanged += nudPrecioFinal_ValueChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnPrecioFijoInfo);
            groupBox1.Controls.Add(btnGananciaFijaInfo);
            groupBox1.Controls.Add(rbPrecio);
            groupBox1.Controls.Add(rbGanancia);
            groupBox1.Location = new Point(68, 204);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(503, 78);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Seleccione un Modo de Ganancia:";
            // 
            // btnPrecioFijoInfo
            // 
            btnPrecioFijoInfo.BackColor = Color.FromArgb(0, 108, 190);
            btnPrecioFijoInfo.ForeColor = Color.White;
            btnPrecioFijoInfo.Location = new Point(398, 38);
            btnPrecioFijoInfo.Name = "btnPrecioFijoInfo";
            btnPrecioFijoInfo.Size = new Size(24, 24);
            btnPrecioFijoInfo.TabIndex = 3;
            btnPrecioFijoInfo.Text = "i";
            btnPrecioFijoInfo.UseVisualStyleBackColor = false;
            btnPrecioFijoInfo.Click += btnPrecioFijoInfo_Click;
            // 
            // btnGananciaFijaInfo
            // 
            btnGananciaFijaInfo.BackColor = Color.FromArgb(0, 108, 190);
            btnGananciaFijaInfo.ForeColor = Color.White;
            btnGananciaFijaInfo.Location = new Point(136, 38);
            btnGananciaFijaInfo.Name = "btnGananciaFijaInfo";
            btnGananciaFijaInfo.Size = new Size(24, 24);
            btnGananciaFijaInfo.TabIndex = 2;
            btnGananciaFijaInfo.Text = "i";
            btnGananciaFijaInfo.UseVisualStyleBackColor = false;
            btnGananciaFijaInfo.Click += btnGananciaFijaInfo_Click;
            // 
            // rbPrecio
            // 
            rbPrecio.AutoSize = true;
            rbPrecio.Location = new Point(298, 38);
            rbPrecio.Name = "rbPrecio";
            rbPrecio.Size = new Size(94, 22);
            rbPrecio.TabIndex = 1;
            rbPrecio.TabStop = true;
            rbPrecio.Text = "Precio Fijo";
            rbPrecio.UseVisualStyleBackColor = true;
            rbPrecio.CheckedChanged += rbPrecio_CheckedChanged;
            // 
            // rbGanancia
            // 
            rbGanancia.AutoSize = true;
            rbGanancia.Location = new Point(17, 38);
            rbGanancia.Name = "rbGanancia";
            rbGanancia.Size = new Size(113, 22);
            rbGanancia.TabIndex = 0;
            rbGanancia.TabStop = true;
            rbGanancia.Text = "Ganancia Fija";
            rbGanancia.UseVisualStyleBackColor = true;
            rbGanancia.CheckedChanged += rbGanancia_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(68, 294);
            label1.Name = "label1";
            label1.Size = new Size(86, 18);
            label1.TabIndex = 1;
            label1.Text = "Ganancia %:";
            // 
            // frmAgregarEditarGananciaModo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(590, 481);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAgregarEditarGananciaModo";
            Text = "Ganancia de Productos";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPrecioCosto).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecioCompra).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudGanancia).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecioFinal).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private GroupBox groupBox1;
        private TrackBar trackBar1;
        private Button btnPrecioFijoInfo;
        private Button btnGananciaFijaInfo;
        private RadioButton rbPrecio;
        private RadioButton rbGanancia;
        private NumericUpDown nudPrecioFinal;
        private NumericUpDown nudGanancia;
        private Label label2;
        private Label label1;
        private NumericUpDown nudPrecioCosto;
        private Label label20;
        private NumericUpDown nudPrecioCompra;
        private Label label11;
        private Label label3;
        private Button btnGuardarProducto;
    }
}