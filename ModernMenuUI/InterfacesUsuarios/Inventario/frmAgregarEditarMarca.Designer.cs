namespace ModernMenuUI.InterfacesUsuarios.Inventario
{
    partial class frmAgregarEditarMarca
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
            Panel panBarraControl;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarEditarMarca));
            lblNombreModulo = new Label();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            btnModificarProveedor = new Button();
            txtNombre = new TextBox();
            btnVolver = new Button();
            btnGuardarMarca = new Button();
            label8 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            btnbuscar = new Button();
            gbxEstado = new GroupBox();
            rbInactivo = new RadioButton();
            rbActivo = new RadioButton();
            label5 = new Label();
            panBarraControl = new Panel();
            panBarraControl.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            gbxEstado.SuspendLayout();
            SuspendLayout();
            // 
            // panBarraControl
            // 
            panBarraControl.BackColor = Color.FromArgb(148, 168, 187);
            panBarraControl.Controls.Add(lblNombreModulo);
            panBarraControl.Dock = DockStyle.Top;
            panBarraControl.ForeColor = Color.Coral;
            panBarraControl.Location = new Point(0, 0);
            panBarraControl.Name = "panBarraControl";
            panBarraControl.Size = new Size(708, 38);
            panBarraControl.TabIndex = 17;
            // 
            // lblNombreModulo
            // 
            lblNombreModulo.Dock = DockStyle.Fill;
            lblNombreModulo.Font = new Font("Itim", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombreModulo.ForeColor = Color.White;
            lblNombreModulo.Location = new Point(0, 0);
            lblNombreModulo.Name = "lblNombreModulo";
            lblNombreModulo.Size = new Size(708, 38);
            lblNombreModulo.TabIndex = 14;
            lblNombreModulo.Text = "AGREGAR MARCA";
            lblNombreModulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(189, 215, 238);
            panel2.Controls.Add(gbxEstado);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(btnbuscar);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(btnModificarProveedor);
            panel2.Controls.Add(txtNombre);
            panel2.Controls.Add(btnVolver);
            panel2.Controls.Add(btnGuardarMarca);
            panel2.Controls.Add(label8);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 38);
            panel2.Name = "panel2";
            panel2.Size = new Size(708, 348);
            panel2.TabIndex = 16;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(494, 54);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(182, 179);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 21;
            pictureBox1.TabStop = false;
            // 
            // btnModificarProveedor
            // 
            btnModificarProveedor.BackColor = Color.FromArgb(149, 195, 172);
            btnModificarProveedor.BackgroundImageLayout = ImageLayout.None;
            btnModificarProveedor.FlatAppearance.BorderSize = 0;
            btnModificarProveedor.Font = new Font("Itim", 11.9999981F);
            btnModificarProveedor.ForeColor = SystemColors.ButtonFace;
            btnModificarProveedor.ImageAlign = ContentAlignment.BottomLeft;
            btnModificarProveedor.Location = new Point(127, 245);
            btnModificarProveedor.Name = "btnModificarProveedor";
            btnModificarProveedor.Size = new Size(89, 35);
            btnModificarProveedor.TabIndex = 19;
            btnModificarProveedor.Text = "Modificar";
            btnModificarProveedor.UseVisualStyleBackColor = false;
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.White;
            txtNombre.BorderStyle = BorderStyle.None;
            txtNombre.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.Location = new Point(198, 68);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "(Marca)";
            txtNombre.Size = new Size(289, 24);
            txtNombre.TabIndex = 1;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.FromArgb(148, 168, 187);
            btnVolver.BackgroundImageLayout = ImageLayout.None;
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.Font = new Font("Itim", 11.9999981F);
            btnVolver.ForeColor = SystemColors.ButtonFace;
            btnVolver.ImageAlign = ContentAlignment.BottomLeft;
            btnVolver.Location = new Point(222, 245);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(95, 35);
            btnVolver.TabIndex = 0;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnGuardarMarca
            // 
            btnGuardarMarca.BackColor = Color.FromArgb(149, 195, 172);
            btnGuardarMarca.BackgroundImageLayout = ImageLayout.None;
            btnGuardarMarca.FlatAppearance.BorderSize = 0;
            btnGuardarMarca.Font = new Font("Itim", 11.9999981F);
            btnGuardarMarca.ForeColor = SystemColors.ButtonFace;
            btnGuardarMarca.ImageAlign = ContentAlignment.BottomLeft;
            btnGuardarMarca.Location = new Point(15, 245);
            btnGuardarMarca.Name = "btnGuardarMarca";
            btnGuardarMarca.Size = new Size(106, 35);
            btnGuardarMarca.TabIndex = 9;
            btnGuardarMarca.Text = "Guardar";
            btnGuardarMarca.UseVisualStyleBackColor = false;
            btnGuardarMarca.Click += btnGuardarProveedor_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(87, 99, 110);
            label8.Location = new Point(3, 68);
            label8.Name = "label8";
            label8.Size = new Size(183, 23);
            label8.TabIndex = 12;
            label8.Text = "Nombre del la Marca:";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.White;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(117, 137);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "(Buscar Proveedor)";
            textBox1.Size = new Size(289, 24);
            textBox1.TabIndex = 22;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(87, 99, 110);
            label1.Location = new Point(12, 137);
            label1.Name = "label1";
            label1.Size = new Size(99, 23);
            label1.TabIndex = 23;
            label1.Text = "Proveedor:";
            // 
            // btnbuscar
            // 
            btnbuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnbuscar.BackColor = Color.FromArgb(168, 191, 212);
            btnbuscar.BackgroundImage = (Image)resources.GetObject("btnbuscar.BackgroundImage");
            btnbuscar.BackgroundImageLayout = ImageLayout.Zoom;
            btnbuscar.FlatAppearance.BorderSize = 0;
            btnbuscar.FlatStyle = FlatStyle.Flat;
            btnbuscar.Location = new Point(412, 137);
            btnbuscar.Margin = new Padding(3, 4, 3, 4);
            btnbuscar.Name = "btnbuscar";
            btnbuscar.Size = new Size(55, 27);
            btnbuscar.TabIndex = 24;
            btnbuscar.UseVisualStyleBackColor = false;
            // 
            // gbxEstado
            // 
            gbxEstado.Controls.Add(rbInactivo);
            gbxEstado.Controls.Add(rbActivo);
            gbxEstado.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbxEstado.ForeColor = Color.DimGray;
            gbxEstado.Location = new Point(190, 174);
            gbxEstado.Name = "gbxEstado";
            gbxEstado.Size = new Size(214, 48);
            gbxEstado.TabIndex = 25;
            gbxEstado.TabStop = false;
            // 
            // rbInactivo
            // 
            rbInactivo.AutoSize = true;
            rbInactivo.Location = new Point(124, 19);
            rbInactivo.Name = "rbInactivo";
            rbInactivo.Size = new Size(100, 28);
            rbInactivo.TabIndex = 8;
            rbInactivo.TabStop = true;
            rbInactivo.Text = "Inactivo";
            rbInactivo.UseVisualStyleBackColor = true;
            // 
            // rbActivo
            // 
            rbActivo.AutoSize = true;
            rbActivo.Location = new Point(8, 20);
            rbActivo.Name = "rbActivo";
            rbActivo.Size = new Size(84, 28);
            rbActivo.TabIndex = 7;
            rbActivo.TabStop = true;
            rbActivo.Text = "Activo";
            rbActivo.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(87, 99, 110);
            label5.Location = new Point(127, 193);
            label5.Name = "label5";
            label5.Size = new Size(70, 23);
            label5.TabIndex = 26;
            label5.Text = "Estado:";
            // 
            // frmAgregarEditarMarca
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(708, 386);
            Controls.Add(panel2);
            Controls.Add(panBarraControl);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmAgregarEditarMarca";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmAgregarEditarMarca";
            panBarraControl.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            gbxEstado.ResumeLayout(false);
            gbxEstado.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private PictureBox pictureBox1;
        private Button btnModificarProveedor;
        private TextBox txtNombre;
        private Button btnVolver;
        private Button btnGuardarMarca;
        private Label label8;
        public Label lblNombreModulo;
        private Label label1;
        private TextBox textBox1;
        private Button btnbuscar;
        private GroupBox gbxEstado;
        private RadioButton rbInactivo;
        private RadioButton rbActivo;
        private Label label5;
    }
}