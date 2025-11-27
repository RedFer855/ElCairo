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
            btnVolver = new Button();
            btnModificarPresentacion = new Button();
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
            panBarraControl.Name = "panBarraControl";
            panBarraControl.Size = new Size(657, 37);
            panBarraControl.TabIndex = 21;
            // 
            // lblNombreModulo
            // 
            lblNombreModulo.Dock = DockStyle.Fill;
            lblNombreModulo.Font = new Font("Itim", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombreModulo.ForeColor = Color.White;
            lblNombreModulo.Location = new Point(0, 0);
            lblNombreModulo.Name = "lblNombreModulo";
            lblNombreModulo.Size = new Size(657, 37);
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
            panel2.Location = new Point(0, 37);
            panel2.Name = "panel2";
            panel2.Size = new Size(657, 283);
            panel2.TabIndex = 20;
            // 
            // flpAjustarBotones
            // 
            flpAjustarBotones.Controls.Add(btnGuardarPresentacion);
            flpAjustarBotones.Controls.Add(btnVolver);
            flpAjustarBotones.Controls.Add(btnModificarPresentacion);
            flpAjustarBotones.Location = new Point(10, 235);
            flpAjustarBotones.Name = "flpAjustarBotones";
            flpAjustarBotones.Size = new Size(295, 37);
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
            btnGuardarPresentacion.Location = new Point(3, 3);
            btnGuardarPresentacion.Name = "btnGuardarPresentacion";
            btnGuardarPresentacion.Size = new Size(89, 33);
            btnGuardarPresentacion.TabIndex = 9;
            btnGuardarPresentacion.Text = "Guardar";
            btnGuardarPresentacion.UseVisualStyleBackColor = false;
            btnGuardarPresentacion.Visible = false;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.FromArgb(148, 168, 187);
            btnVolver.BackgroundImageLayout = ImageLayout.None;
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.Font = new Font("Itim", 11.9999981F);
            btnVolver.ForeColor = SystemColors.ButtonFace;
            btnVolver.ImageAlign = ContentAlignment.BottomLeft;
            btnVolver.Location = new Point(98, 3);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(95, 33);
            btnVolver.TabIndex = 0;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            // 
            // btnModificarPresentacion
            // 
            btnModificarPresentacion.BackColor = Color.FromArgb(74, 148, 225);
            btnModificarPresentacion.BackgroundImageLayout = ImageLayout.None;
            btnModificarPresentacion.FlatAppearance.BorderSize = 0;
            btnModificarPresentacion.Font = new Font("Itim", 11.9999981F);
            btnModificarPresentacion.ForeColor = SystemColors.ButtonFace;
            btnModificarPresentacion.ImageAlign = ContentAlignment.BottomLeft;
            btnModificarPresentacion.Location = new Point(199, 3);
            btnModificarPresentacion.Name = "btnModificarPresentacion";
            btnModificarPresentacion.Size = new Size(72, 33);
            btnModificarPresentacion.TabIndex = 19;
            btnModificarPresentacion.Text = "Editar";
            btnModificarPresentacion.UseVisualStyleBackColor = false;
            // 
            // txtDescripcionPresentacion
            // 
            txtDescripcionPresentacion.BackColor = Color.White;
            txtDescripcionPresentacion.BorderStyle = BorderStyle.None;
            txtDescripcionPresentacion.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDescripcionPresentacion.Location = new Point(120, 38);
            txtDescripcionPresentacion.Multiline = true;
            txtDescripcionPresentacion.Name = "txtDescripcionPresentacion";
            txtDescripcionPresentacion.PlaceholderText = "(Ingrese una Descripción)";
            txtDescripcionPresentacion.Size = new Size(306, 140);
            txtDescripcionPresentacion.TabIndex = 24;
            // 
            // pbxImagenMarca
            // 
            pbxImagenMarca.Image = (Image)resources.GetObject("pbxImagenMarca.Image");
            pbxImagenMarca.Location = new Point(450, 12);
            pbxImagenMarca.Name = "pbxImagenMarca";
            pbxImagenMarca.Size = new Size(192, 259);
            pbxImagenMarca.SizeMode = PictureBoxSizeMode.Zoom;
            pbxImagenMarca.TabIndex = 21;
            pbxImagenMarca.TabStop = false;
            // 
            // txtNombrePresentacion
            // 
            txtNombrePresentacion.BackColor = Color.White;
            txtNombrePresentacion.BorderStyle = BorderStyle.None;
            txtNombrePresentacion.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombrePresentacion.Location = new Point(120, 12);
            txtNombrePresentacion.Name = "txtNombrePresentacion";
            txtNombrePresentacion.PlaceholderText = "(Ingrese el nombre de la presentacion)";
            txtNombrePresentacion.Size = new Size(306, 20);
            txtNombrePresentacion.TabIndex = 1;
            // 
            // gbxEstado
            // 
            gbxEstado.Controls.Add(rbInactivo);
            gbxEstado.Controls.Add(rbActivo);
            gbxEstado.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbxEstado.ForeColor = Color.DimGray;
            gbxEstado.Location = new Point(120, 184);
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
            rbInactivo.TabStop = true;
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
            lblEstado.Location = new Point(57, 202);
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
            label8.Location = new Point(15, 13);
            label8.Name = "label8";
            label8.Size = new Size(99, 18);
            label8.TabIndex = 12;
            label8.Text = "Presentación:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(87, 99, 110);
            label2.Location = new Point(25, 39);
            label2.Name = "label2";
            label2.Size = new Size(89, 18);
            label2.TabIndex = 14;
            label2.Text = "Descripción:";
            // 
            // frmAgregarEditarPresentacion
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(657, 320);
            Controls.Add(panel2);
            Controls.Add(panBarraControl);
            Name = "frmAgregarEditarPresentacion";
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