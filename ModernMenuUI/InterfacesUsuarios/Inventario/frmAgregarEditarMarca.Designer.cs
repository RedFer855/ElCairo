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
            flpAjustarBotones = new FlowLayoutPanel();
            btnGuardarMarca = new Button();
            btnModificarMarca = new Button();
            btnVolver = new Button();
            txtProveedor = new TextBox();
            btnBuscarProv = new Button();
            pbxImagenMarca = new PictureBox();
            txtNombreMarca = new TextBox();
            gbxEstado = new GroupBox();
            rbInactivo = new RadioButton();
            rbActivo = new RadioButton();
            lblEstado = new Label();
            label8 = new Label();
            label2 = new Label();
            panBarraControl = new Panel();
            panBarraControl.SuspendLayout();
            panel2.SuspendLayout();
            flpAjustarBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxImagenMarca).BeginInit();
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
            panel2.Controls.Add(flpAjustarBotones);
            panel2.Controls.Add(txtProveedor);
            panel2.Controls.Add(btnBuscarProv);
            panel2.Controls.Add(pbxImagenMarca);
            panel2.Controls.Add(txtNombreMarca);
            panel2.Controls.Add(gbxEstado);
            panel2.Controls.Add(lblEstado);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 37);
            panel2.Name = "panel2";
            panel2.Size = new Size(571, 201);
            panel2.TabIndex = 16;
            panel2.Paint += panel2_Paint;
            // 
            // flpAjustarBotones
            // 
            flpAjustarBotones.Controls.Add(btnGuardarMarca);
            flpAjustarBotones.Controls.Add(btnModificarMarca);
            flpAjustarBotones.Controls.Add(btnVolver);
            flpAjustarBotones.Location = new Point(19, 152);
            flpAjustarBotones.Name = "flpAjustarBotones";
            flpAjustarBotones.Size = new Size(295, 37);
            flpAjustarBotones.TabIndex = 25;
            // 
            // btnGuardarMarca
            // 
            btnGuardarMarca.BackColor = Color.FromArgb(149, 195, 172);
            btnGuardarMarca.BackgroundImageLayout = ImageLayout.None;
            btnGuardarMarca.FlatAppearance.BorderSize = 0;
            btnGuardarMarca.Font = new Font("Itim", 11.9999981F);
            btnGuardarMarca.ForeColor = SystemColors.ButtonFace;
            btnGuardarMarca.ImageAlign = ContentAlignment.BottomLeft;
            btnGuardarMarca.Location = new Point(3, 3);
            btnGuardarMarca.Name = "btnGuardarMarca";
            btnGuardarMarca.Size = new Size(89, 33);
            btnGuardarMarca.TabIndex = 9;
            btnGuardarMarca.Text = "Guardar";
            btnGuardarMarca.UseVisualStyleBackColor = false;
            btnGuardarMarca.Visible = false;
            btnGuardarMarca.Click += btnGuardarMarca_Click;
            // 
            // btnModificarMarca
            // 
            btnModificarMarca.BackColor = Color.FromArgb(74, 148, 225);
            btnModificarMarca.BackgroundImageLayout = ImageLayout.None;
            btnModificarMarca.FlatAppearance.BorderSize = 0;
            btnModificarMarca.Font = new Font("Itim", 11.9999981F);
            btnModificarMarca.ForeColor = SystemColors.ButtonFace;
            btnModificarMarca.ImageAlign = ContentAlignment.BottomLeft;
            btnModificarMarca.Location = new Point(98, 3);
            btnModificarMarca.Name = "btnModificarMarca";
            btnModificarMarca.Size = new Size(72, 33);
            btnModificarMarca.TabIndex = 19;
            btnModificarMarca.Text = "Editar";
            btnModificarMarca.UseVisualStyleBackColor = false;
            btnModificarMarca.Click += btnModificarMarca_Click;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.FromArgb(148, 168, 187);
            btnVolver.BackgroundImageLayout = ImageLayout.None;
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.Font = new Font("Itim", 11.9999981F);
            btnVolver.ForeColor = SystemColors.ButtonFace;
            btnVolver.ImageAlign = ContentAlignment.BottomLeft;
            btnVolver.Location = new Point(176, 3);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(95, 33);
            btnVolver.TabIndex = 0;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // txtProveedor
            // 
            txtProveedor.BackColor = Color.White;
            txtProveedor.BorderStyle = BorderStyle.None;
            txtProveedor.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProveedor.Location = new Point(150, 47);
            txtProveedor.Name = "txtProveedor";
            txtProveedor.PlaceholderText = "(Seleccione Buscar)";
            txtProveedor.Size = new Size(201, 20);
            txtProveedor.TabIndex = 24;
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
            // pbxImagenMarca
            // 
            pbxImagenMarca.Image = (Image)resources.GetObject("pbxImagenMarca.Image");
            pbxImagenMarca.Location = new Point(423, 21);
            pbxImagenMarca.Name = "pbxImagenMarca";
            pbxImagenMarca.Size = new Size(136, 157);
            pbxImagenMarca.SizeMode = PictureBoxSizeMode.Zoom;
            pbxImagenMarca.TabIndex = 21;
            pbxImagenMarca.TabStop = false;
            // 
            // txtNombreMarca
            // 
            txtNombreMarca.BackColor = Color.White;
            txtNombreMarca.BorderStyle = BorderStyle.None;
            txtNombreMarca.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombreMarca.Location = new Point(150, 20);
            txtNombreMarca.Name = "txtNombreMarca";
            txtNombreMarca.Size = new Size(255, 20);
            txtNombreMarca.TabIndex = 1;
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
            rbInactivo.Location = new Point(119, 15);
            rbInactivo.Name = "rbInactivo";
            rbInactivo.Size = new Size(82, 23);
            rbInactivo.TabIndex = 8;
            rbInactivo.Text = "Inactivo";
            rbInactivo.UseVisualStyleBackColor = true;
            // 
            // rbActivo
            // 
            rbActivo.AutoSize = true;
            rbActivo.Checked = true;
            rbActivo.Location = new Point(6, 15);
            rbActivo.Name = "rbActivo";
            rbActivo.Size = new Size(70, 23);
            rbActivo.TabIndex = 7;
            rbActivo.TabStop = true;
            rbActivo.Text = "Activo";
            rbActivo.UseVisualStyleBackColor = true;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEstado.ForeColor = Color.FromArgb(87, 99, 110);
            lblEstado.Location = new Point(87, 91);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(57, 18);
            lblEstado.TabIndex = 18;
            lblEstado.Text = "Estado:";
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
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
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
            flpAjustarBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbxImagenMarca).EndInit();
            gbxEstado.ResumeLayout(false);
            gbxEstado.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private PictureBox pbxImagenMarca;
        private Button btnModificarMarca;
        private TextBox txtNombreMarca;
        private Button btnVolver;
        private Button btnGuardarMarca;
        private GroupBox gbxEstado;
        private RadioButton rbInactivo;
        private RadioButton rbActivo;
        private Label lblEstado;
        private Label label8;
        private Label label2;
        public Label lblNombreModulo;
        private TextBox txtProveedor;
        private FlowLayoutPanel flpAjustarBotones;
        private Button btnBuscarProv;
    }
}