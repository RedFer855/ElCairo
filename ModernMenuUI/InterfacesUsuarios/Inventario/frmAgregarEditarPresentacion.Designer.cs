namespace ModernMenuUI.InterfacesUsuarios.Inventario
{
    partial class frmAgregarEditarPresentacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarEditarPresentacion));
            lblNombreModulo = new Label();
            panel2 = new Panel();
            flpAjustarBotones = new FlowLayoutPanel();
            btnGuardarPresentacion = new Button();
            btnModificarPresentacion = new Button();
            btnVolver = new Button();
            txtDescripcionPresentacion = new TextBox();
            pbxImagenMarca = new PictureBox();
            txtNombrePresentacion = new TextBox();
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
            panBarraControl.Margin = new Padding(4, 4, 4, 4);
            panBarraControl.Name = "panBarraControl";
            panBarraControl.Size = new Size(821, 46);
            panBarraControl.TabIndex = 21;
            // 
            // lblNombreModulo
            // 
            lblNombreModulo.Dock = DockStyle.Fill;
            lblNombreModulo.Font = new Font("Itim", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombreModulo.ForeColor = Color.White;
            lblNombreModulo.Location = new Point(0, 0);
            lblNombreModulo.Margin = new Padding(4, 0, 4, 0);
            lblNombreModulo.Name = "lblNombreModulo";
            lblNombreModulo.Size = new Size(821, 46);
            lblNombreModulo.TabIndex = 14;
            lblNombreModulo.Text = "EDITAR PRESENTACIÓN";
            lblNombreModulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(189, 215, 238);
            panel2.Controls.Add(flpAjustarBotones);
            panel2.Controls.Add(txtDescripcionPresentacion);
            panel2.Controls.Add(pbxImagenMarca);
            panel2.Controls.Add(txtNombrePresentacion);
            panel2.Controls.Add(gbxEstado);
            panel2.Controls.Add(lblEstado);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 46);
            panel2.Margin = new Padding(4, 4, 4, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(821, 354);
            panel2.TabIndex = 20;
            // 
            // flpAjustarBotones
            // 
            flpAjustarBotones.Controls.Add(btnGuardarPresentacion);
            flpAjustarBotones.Controls.Add(btnModificarPresentacion);
            flpAjustarBotones.Controls.Add(btnVolver);
            flpAjustarBotones.Location = new Point(12, 294);
            flpAjustarBotones.Margin = new Padding(4, 4, 4, 4);
            flpAjustarBotones.Name = "flpAjustarBotones";
            flpAjustarBotones.Size = new Size(369, 46);
            flpAjustarBotones.TabIndex = 25;
            // 
            // btnGuardarPresentacion
            // 
            btnGuardarPresentacion.BackColor = Color.FromArgb(149, 195, 172);
            btnGuardarPresentacion.BackgroundImageLayout = ImageLayout.None;
            btnGuardarPresentacion.FlatAppearance.BorderSize = 0;
            btnGuardarPresentacion.Font = new Font("Itim", 11.9999981F);
            btnGuardarPresentacion.ForeColor = SystemColors.ButtonFace;
            btnGuardarPresentacion.ImageAlign = ContentAlignment.BottomLeft;
            btnGuardarPresentacion.Location = new Point(4, 4);
            btnGuardarPresentacion.Margin = new Padding(4, 4, 4, 4);
            btnGuardarPresentacion.Name = "btnGuardarPresentacion";
            btnGuardarPresentacion.Size = new Size(111, 41);
            btnGuardarPresentacion.TabIndex = 9;
            btnGuardarPresentacion.Text = "Guardar";
            btnGuardarPresentacion.UseVisualStyleBackColor = false;
            btnGuardarPresentacion.Visible = false;
            btnGuardarPresentacion.Click += btnGuardarCategoria_Click;
            // 
            // btnModificarPresentacion
            // 
            btnModificarPresentacion.BackColor = Color.FromArgb(74, 148, 225);
            btnModificarPresentacion.BackgroundImageLayout = ImageLayout.None;
            btnModificarPresentacion.FlatAppearance.BorderSize = 0;
            btnModificarPresentacion.Font = new Font("Itim", 11.9999981F);
            btnModificarPresentacion.ForeColor = SystemColors.ButtonFace;
            btnModificarPresentacion.ImageAlign = ContentAlignment.BottomLeft;
            btnModificarPresentacion.Location = new Point(123, 4);
            btnModificarPresentacion.Margin = new Padding(4, 4, 4, 4);
            btnModificarPresentacion.Name = "btnModificarPresentacion";
            btnModificarPresentacion.Size = new Size(90, 41);
            btnModificarPresentacion.TabIndex = 19;
            btnModificarPresentacion.Text = "Editar";
            btnModificarPresentacion.UseVisualStyleBackColor = false;
            btnModificarPresentacion.Click += btnModificarPresentacion_Click;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.FromArgb(148, 168, 187);
            btnVolver.BackgroundImageLayout = ImageLayout.None;
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.Font = new Font("Itim", 11.9999981F);
            btnVolver.ForeColor = SystemColors.ButtonFace;
            btnVolver.ImageAlign = ContentAlignment.BottomLeft;
            btnVolver.Location = new Point(221, 4);
            btnVolver.Margin = new Padding(4, 4, 4, 4);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(119, 41);
            btnVolver.TabIndex = 0;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // txtDescripcionPresentacion
            // 
            txtDescripcionPresentacion.BackColor = Color.White;
            txtDescripcionPresentacion.BorderStyle = BorderStyle.None;
            txtDescripcionPresentacion.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDescripcionPresentacion.Location = new Point(150, 48);
            txtDescripcionPresentacion.Margin = new Padding(4, 4, 4, 4);
            txtDescripcionPresentacion.Multiline = true;
            txtDescripcionPresentacion.Name = "txtDescripcionPresentacion";
            txtDescripcionPresentacion.PlaceholderText = "(Ingrese una Descripción)";
            txtDescripcionPresentacion.Size = new Size(382, 175);
            txtDescripcionPresentacion.TabIndex = 24;
            // 
            // pbxImagenMarca
            // 
            pbxImagenMarca.Image = (Image)resources.GetObject("pbxImagenMarca.Image");
            pbxImagenMarca.Location = new Point(562, 15);
            pbxImagenMarca.Margin = new Padding(4, 4, 4, 4);
            pbxImagenMarca.Name = "pbxImagenMarca";
            pbxImagenMarca.Size = new Size(240, 324);
            pbxImagenMarca.SizeMode = PictureBoxSizeMode.Zoom;
            pbxImagenMarca.TabIndex = 21;
            pbxImagenMarca.TabStop = false;
            // 
            // txtNombrePresentacion
            // 
            txtNombrePresentacion.BackColor = Color.White;
            txtNombrePresentacion.BorderStyle = BorderStyle.None;
            txtNombrePresentacion.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombrePresentacion.Location = new Point(150, 15);
            txtNombrePresentacion.Margin = new Padding(4, 4, 4, 4);
            txtNombrePresentacion.Name = "txtNombrePresentacion";
            txtNombrePresentacion.PlaceholderText = "(Ingrese el nombre de la presentacion)";
            txtNombrePresentacion.Size = new Size(382, 24);
            txtNombrePresentacion.TabIndex = 1;
            // 
            // gbxEstado
            // 
            gbxEstado.Controls.Add(rbInactivo);
            gbxEstado.Controls.Add(rbActivo);
            gbxEstado.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbxEstado.ForeColor = Color.DimGray;
            gbxEstado.Location = new Point(150, 230);
            gbxEstado.Margin = new Padding(4, 4, 4, 4);
            gbxEstado.Name = "gbxEstado";
            gbxEstado.Padding = new Padding(4, 4, 4, 4);
            gbxEstado.Size = new Size(319, 56);
            gbxEstado.TabIndex = 7;
            gbxEstado.TabStop = false;
            // 
            // rbInactivo
            // 
            rbInactivo.AutoSize = true;
            rbInactivo.Location = new Point(149, 19);
            rbInactivo.Margin = new Padding(4, 4, 4, 4);
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
            rbActivo.Checked = true;
            rbActivo.Location = new Point(8, 19);
            rbActivo.Margin = new Padding(4, 4, 4, 4);
            rbActivo.Name = "rbActivo";
            rbActivo.Size = new Size(84, 28);
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
            lblEstado.Location = new Point(71, 252);
            lblEstado.Margin = new Padding(4, 0, 4, 0);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(70, 23);
            lblEstado.TabIndex = 18;
            lblEstado.Text = "Estado:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(87, 99, 110);
            label8.Location = new Point(19, 16);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(123, 23);
            label8.TabIndex = 12;
            label8.Text = "Presentación:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(87, 99, 110);
            label2.Location = new Point(31, 49);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(112, 23);
            label2.TabIndex = 14;
            label2.Text = "Descripción:";
            // 
            // frmAgregarEditarPresentacion
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(821, 400);
            Controls.Add(panel2);
            Controls.Add(panBarraControl);
            Margin = new Padding(4, 4, 4, 4);
            Name = "frmAgregarEditarPresentacion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Presentación";
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
        private FlowLayoutPanel flpAjustarBotones;
        private Button btnGuardarPresentacion;
        private Button btnVolver;
        private Button btnModificarPresentacion;
        private TextBox txtDescripcionPresentacion;
        private PictureBox pbxImagenMarca;
        private TextBox txtNombrePresentacion;
        private GroupBox gbxEstado;
        private RadioButton rbInactivo;
        private RadioButton rbActivo;
        private Label lblEstado;
        private Label label8;
        private Label label2;
        public Label lblNombreModulo;
    }
}