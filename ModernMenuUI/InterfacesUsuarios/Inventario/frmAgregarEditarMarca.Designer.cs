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
            textBox1 = new TextBox();
            btnBuscarProv = new Button();
            pictureBox1 = new PictureBox();
            btnModificarMarca = new Button();
            txtDni = new TextBox();
            btnVolver = new Button();
            btnGuardarMarca = new Button();
            gbxEstado = new GroupBox();
            rbInactivo = new RadioButton();
            rbActivo = new RadioButton();
            label5 = new Label();
            label8 = new Label();
            label2 = new Label();
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
            panBarraControl.Size = new Size(571, 37);
            panBarraControl.TabIndex = 17;
            // 
            // lblNombreModulo
            // 
            lblNombreModulo.Dock = DockStyle.Fill;
            lblNombreModulo.Font = new Font("Itim", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombreModulo.ForeColor = Color.White;
            lblNombreModulo.Location = new Point(0, 0);
            lblNombreModulo.Name = "lblNombreModulo";
            lblNombreModulo.Size = new Size(571, 37);
            lblNombreModulo.TabIndex = 14;
            lblNombreModulo.Text = "EDITAR MARCA";
            lblNombreModulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(189, 215, 238);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(btnBuscarProv);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(btnModificarMarca);
            panel2.Controls.Add(txtDni);
            panel2.Controls.Add(btnVolver);
            panel2.Controls.Add(btnGuardarMarca);
            panel2.Controls.Add(gbxEstado);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 37);
            panel2.Name = "panel2";
            panel2.Size = new Size(571, 201);
            panel2.TabIndex = 16;
            panel2.Paint += panel2_Paint;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.White;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(150, 47);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "(Seleccione Buscar)";
            textBox1.Size = new Size(201, 20);
            textBox1.TabIndex = 24;
            // 
            // btnBuscarProv
            // 
            btnBuscarProv.BackColor = Color.FromArgb(168, 191, 212);
            btnBuscarProv.BackgroundImage = (Image)resources.GetObject("btnBuscarProv.BackgroundImage");
            btnBuscarProv.BackgroundImageLayout = ImageLayout.Zoom;
            btnBuscarProv.FlatAppearance.BorderSize = 0;
            btnBuscarProv.FlatStyle = FlatStyle.Flat;
            btnBuscarProv.Location = new Point(357, 46);
            btnBuscarProv.Name = "btnBuscarProv";
            btnBuscarProv.Size = new Size(48, 21);
            btnBuscarProv.TabIndex = 23;
            btnBuscarProv.UseVisualStyleBackColor = false;
            btnBuscarProv.Click += btnBuscarProv_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(423, 21);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(136, 157);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 21;
            pictureBox1.TabStop = false;
            // 
            // btnModificarMarca
            // 
            btnModificarMarca.BackColor = Color.FromArgb(74, 148, 225);
            btnModificarMarca.BackgroundImageLayout = ImageLayout.None;
            btnModificarMarca.FlatAppearance.BorderSize = 0;
            btnModificarMarca.Font = new Font("Itim", 11.9999981F);
            btnModificarMarca.ForeColor = SystemColors.ButtonFace;
            btnModificarMarca.ImageAlign = ContentAlignment.BottomLeft;
            btnModificarMarca.Location = new Point(114, 156);
            btnModificarMarca.Name = "btnModificarMarca";
            btnModificarMarca.Size = new Size(72, 33);
            btnModificarMarca.TabIndex = 19;
            btnModificarMarca.Text = "Editar";
            btnModificarMarca.UseVisualStyleBackColor = false;
            // 
            // txtDni
            // 
            txtDni.BackColor = Color.White;
            txtDni.BorderStyle = BorderStyle.None;
            txtDni.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDni.Location = new Point(150, 20);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(255, 20);
            txtDni.TabIndex = 1;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.FromArgb(148, 168, 187);
            btnVolver.BackgroundImageLayout = ImageLayout.None;
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.Font = new Font("Itim", 11.9999981F);
            btnVolver.ForeColor = SystemColors.ButtonFace;
            btnVolver.ImageAlign = ContentAlignment.BottomLeft;
            btnVolver.Location = new Point(192, 156);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(95, 33);
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
            btnGuardarMarca.Location = new Point(19, 156);
            btnGuardarMarca.Name = "btnGuardarMarca";
            btnGuardarMarca.Size = new Size(89, 33);
            btnGuardarMarca.TabIndex = 9;
            btnGuardarMarca.Text = "Guardar";
            btnGuardarMarca.UseVisualStyleBackColor = false;
            btnGuardarMarca.Visible = false;
            // 
            // gbxEstado
            // 
            gbxEstado.Controls.Add(rbInactivo);
            gbxEstado.Controls.Add(rbActivo);
            gbxEstado.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbxEstado.ForeColor = Color.DimGray;
            gbxEstado.Location = new Point(150, 73);
            gbxEstado.Name = "gbxEstado";
            gbxEstado.Size = new Size(255, 45);
            gbxEstado.TabIndex = 7;
            gbxEstado.TabStop = false;
            // 
            // rbInactivo
            // 
            rbInactivo.AutoSize = true;
            rbInactivo.Location = new Point(124, 18);
            rbInactivo.Name = "rbInactivo";
            rbInactivo.Size = new Size(82, 23);
            rbInactivo.TabIndex = 8;
            rbInactivo.TabStop = true;
            rbInactivo.Text = "Inactivo";
            rbInactivo.UseVisualStyleBackColor = true;
            // 
            // rbActivo
            // 
            rbActivo.AutoSize = true;
            rbActivo.Location = new Point(8, 19);
            rbActivo.Name = "rbActivo";
            rbActivo.Size = new Size(70, 23);
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
            label5.Location = new Point(87, 91);
            label5.Name = "label5";
            label5.Size = new Size(57, 18);
            label5.TabIndex = 18;
            label5.Text = "Estado:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(87, 99, 110);
            label8.Location = new Point(19, 21);
            label8.Name = "label8";
            label8.Size = new Size(125, 18);
            label8.TabIndex = 12;
            label8.Text = "Nombre de Marca:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(87, 99, 110);
            label2.Location = new Point(66, 51);
            label2.Name = "label2";
            label2.Size = new Size(78, 18);
            label2.TabIndex = 14;
            label2.Text = "Proveedor:";
            // 
            // frmAgregarEditarMarca
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(571, 238);
            Controls.Add(panel2);
            Controls.Add(panBarraControl);
            Font = new Font("Itim", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAgregarEditarMarca";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Marca";
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
        private Button btnModificarMarca;
        private TextBox txtNombre;
        private TextBox txtDni;
        private Button btnVolver;
        private Button btnGuardarMarca;
        private GroupBox gbxEstado;
        private RadioButton rbInactivo;
        private RadioButton rbActivo;
        private Label label5;
        private Label label8;
        private Label label2;
        private Label label1;
        public Label lblNombreModulo;
        private Button btnBuscarProv;
        private TextBox textBox1;
    }
}