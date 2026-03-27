namespace ModernMenuUI
{
    partial class frmIniciosesion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIniciosesion));
            panLogo = new Panel();
            pbxContenedorImagen = new PictureBox();
            pictureBox1 = new PictureBox();
            panDatosIngreso = new Panel();
            btnBiometrico = new Button();
            btnVer = new Button();
            pbxCargando = new PictureBox();
            lblMensajeError = new Label();
            txtContrasenia = new TextBox();
            txtUsuario = new TextBox();
            lblRecuperarContrasenia = new Label();
            panel5 = new Panel();
            panel6 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            btnAcceder = new Button();
            label3 = new Label();
            panBarraControl = new Panel();
            btnMinimizar = new Button();
            btnCerrar = new Button();
            panLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxContenedorImagen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panDatosIngreso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxCargando).BeginInit();
            panel5.SuspendLayout();
            panel3.SuspendLayout();
            panBarraControl.SuspendLayout();
            SuspendLayout();
            // 
            // panLogo
            // 
            panLogo.BackColor = Color.FromArgb(189, 215, 238);
            panLogo.BackgroundImage = Properties.Resources.imglogin;
            panLogo.Controls.Add(pbxContenedorImagen);
            panLogo.Controls.Add(pictureBox1);
            panLogo.Dock = DockStyle.Left;
            panLogo.Location = new Point(0, 0);
            panLogo.Margin = new Padding(3, 4, 3, 4);
            panLogo.Name = "panLogo";
            panLogo.Size = new Size(286, 450);
            panLogo.TabIndex = 0;
            panLogo.MouseDown += panLogo_MouseDown;
            // 
            // pbxContenedorImagen
            // 
            pbxContenedorImagen.BackColor = Color.Transparent;
            pbxContenedorImagen.Dock = DockStyle.Fill;
            pbxContenedorImagen.Image = Properties.Resources.el_cairo_2__1__12;
            pbxContenedorImagen.Location = new Point(0, 0);
            pbxContenedorImagen.Margin = new Padding(3, 4, 3, 4);
            pbxContenedorImagen.Name = "pbxContenedorImagen";
            pbxContenedorImagen.Size = new Size(286, 450);
            pbxContenedorImagen.SizeMode = PictureBoxSizeMode.Zoom;
            pbxContenedorImagen.TabIndex = 9;
            pbxContenedorImagen.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(286, 450);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            // 
            // panDatosIngreso
            // 
            panDatosIngreso.BackColor = Color.FromArgb(15, 15, 15);
            panDatosIngreso.Controls.Add(btnBiometrico);
            panDatosIngreso.Controls.Add(btnVer);
            panDatosIngreso.Controls.Add(pbxCargando);
            panDatosIngreso.Controls.Add(lblMensajeError);
            panDatosIngreso.Controls.Add(txtContrasenia);
            panDatosIngreso.Controls.Add(txtUsuario);
            panDatosIngreso.Controls.Add(lblRecuperarContrasenia);
            panDatosIngreso.Controls.Add(panel5);
            panDatosIngreso.Controls.Add(panel3);
            panDatosIngreso.Controls.Add(btnAcceder);
            panDatosIngreso.Dock = DockStyle.Fill;
            panDatosIngreso.Location = new Point(286, 0);
            panDatosIngreso.Margin = new Padding(0);
            panDatosIngreso.Name = "panDatosIngreso";
            panDatosIngreso.Size = new Size(594, 450);
            panDatosIngreso.TabIndex = 8;
            panDatosIngreso.MouseDown += panDatosIngreso_MouseDown;
            // 
            // btnBiometrico
            // 
            btnBiometrico.BackColor = Color.FromArgb(40, 40, 40);
            btnBiometrico.BackgroundImage = (Image)resources.GetObject("btnBiometrico.BackgroundImage");
            btnBiometrico.BackgroundImageLayout = ImageLayout.Zoom;
            btnBiometrico.FlatAppearance.BorderSize = 0;
            btnBiometrico.FlatStyle = FlatStyle.Flat;
            btnBiometrico.Font = new Font("Microsoft Sans Serif", 12F);
            btnBiometrico.Location = new Point(486, 312);
            btnBiometrico.Margin = new Padding(0);
            btnBiometrico.Name = "btnBiometrico";
            btnBiometrico.Size = new Size(53, 52);
            btnBiometrico.TabIndex = 21;
            btnBiometrico.UseVisualStyleBackColor = false;
            btnBiometrico.Click += btnBiometrico_Click;
            // 
            // btnVer
            // 
            btnVer.BackColor = Color.FromArgb(15, 15, 15);
            btnVer.BackgroundImage = Properties.Resources.ojo;
            btnVer.BackgroundImageLayout = ImageLayout.Stretch;
            btnVer.FlatAppearance.BorderSize = 0;
            btnVer.FlatStyle = FlatStyle.Flat;
            btnVer.ForeColor = SystemColors.ControlText;
            btnVer.Location = new Point(492, 177);
            btnVer.Name = "btnVer";
            btnVer.Size = new Size(34, 34);
            btnVer.TabIndex = 5;
            btnVer.UseVisualStyleBackColor = false;
            btnVer.MouseDown += btnVer_MouseDown;
            btnVer.MouseUp += btnVer_MouseUp;
            // 
            // pbxCargando
            // 
            pbxCargando.Image = (Image)resources.GetObject("pbxCargando.Image");
            pbxCargando.Location = new Point(267, 227);
            pbxCargando.Margin = new Padding(3, 4, 3, 4);
            pbxCargando.Name = "pbxCargando";
            pbxCargando.Size = new Size(50, 50);
            pbxCargando.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxCargando.TabIndex = 20;
            pbxCargando.TabStop = false;
            pbxCargando.Visible = false;
            // 
            // lblMensajeError
            // 
            lblMensajeError.BackColor = Color.Transparent;
            lblMensajeError.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMensajeError.ForeColor = Color.DarkRed;
            lblMensajeError.Location = new Point(114, 284);
            lblMensajeError.Name = "lblMensajeError";
            lblMensajeError.Size = new Size(359, 24);
            lblMensajeError.TabIndex = 19;
            lblMensajeError.Text = "Credenciales incorrectas ingrese nuevamente...";
            lblMensajeError.TextAlign = ContentAlignment.TopCenter;
            lblMensajeError.Visible = false;
            // 
            // txtContrasenia
            // 
            txtContrasenia.BackColor = Color.FromArgb(15, 15, 15);
            txtContrasenia.BorderStyle = BorderStyle.None;
            txtContrasenia.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContrasenia.ForeColor = Color.FromArgb(142, 142, 142);
            txtContrasenia.Location = new Point(59, 181);
            txtContrasenia.Margin = new Padding(3, 4, 3, 4);
            txtContrasenia.Name = "txtContrasenia";
            txtContrasenia.Size = new Size(427, 30);
            txtContrasenia.TabIndex = 4;
            txtContrasenia.Text = "CONTRASEÑA";
            txtContrasenia.Enter += txtContra_Enter;
            txtContrasenia.KeyDown += txtContrasenia_KeyDown;
            txtContrasenia.Leave += txtContra_Leave;
            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = Color.FromArgb(15, 15, 15);
            txtUsuario.BorderStyle = BorderStyle.None;
            txtUsuario.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsuario.ForeColor = Color.FromArgb(142, 142, 142);
            txtUsuario.Location = new Point(59, 119);
            txtUsuario.Margin = new Padding(3, 4, 3, 4);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(480, 30);
            txtUsuario.TabIndex = 3;
            txtUsuario.Text = "USUARIO";
            txtUsuario.Enter += txtUsuario_Enter;
            txtUsuario.KeyDown += txtUsuario_KeyDown;
            txtUsuario.Leave += txtUsuario_Leave;
            // 
            // lblRecuperarContrasenia
            // 
            lblRecuperarContrasenia.AutoSize = true;
            lblRecuperarContrasenia.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRecuperarContrasenia.ForeColor = Color.FromArgb(142, 142, 142);
            lblRecuperarContrasenia.Location = new Point(201, 388);
            lblRecuperarContrasenia.Name = "lblRecuperarContrasenia";
            lblRecuperarContrasenia.Size = new Size(259, 25);
            lblRecuperarContrasenia.TabIndex = 7;
            lblRecuperarContrasenia.Text = "¿Has olvidado tu contraseña?";
            lblRecuperarContrasenia.Click += lblRecuperarContrasenia_Click;
            lblRecuperarContrasenia.MouseEnter += lblRecuperarContrasenia_MouseEnter;
            lblRecuperarContrasenia.MouseLeave += lblRecuperarContrasenia_MouseLeave;
            // 
            // panel5
            // 
            panel5.BackColor = Color.DimGray;
            panel5.Controls.Add(panel6);
            panel5.Location = new Point(59, 216);
            panel5.Margin = new Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(480, 3);
            panel5.TabIndex = 3;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(142, 142, 142);
            panel6.Location = new Point(0, 0);
            panel6.Margin = new Padding(3, 4, 3, 4);
            panel6.Name = "panel6";
            panel6.Size = new Size(480, 3);
            panel6.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.BackColor = Color.DimGray;
            panel3.Controls.Add(panel4);
            panel3.Location = new Point(59, 156);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(480, 3);
            panel3.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(142, 142, 142);
            panel4.Location = new Point(0, 0);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(480, 3);
            panel4.TabIndex = 2;
            // 
            // btnAcceder
            // 
            btnAcceder.BackColor = Color.FromArgb(40, 40, 40);
            btnAcceder.FlatAppearance.BorderSize = 0;
            btnAcceder.FlatStyle = FlatStyle.Flat;
            btnAcceder.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAcceder.ForeColor = Color.White;
            btnAcceder.Location = new Point(59, 312);
            btnAcceder.Margin = new Padding(3, 4, 3, 4);
            btnAcceder.Name = "btnAcceder";
            btnAcceder.Size = new Size(414, 53);
            btnAcceder.TabIndex = 6;
            btnAcceder.Text = "ACCEDER";
            btnAcceder.UseVisualStyleBackColor = false;
            btnAcceder.Click += btnAcceder_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(142, 142, 142);
            label3.Location = new Point(201, 12);
            label3.Name = "label3";
            label3.Size = new Size(235, 33);
            label3.TabIndex = 10;
            label3.Text = "INICIO DE SESIÓN";
            // 
            // panBarraControl
            // 
            panBarraControl.BackColor = Color.FromArgb(15, 15, 15);
            panBarraControl.Controls.Add(label3);
            panBarraControl.Controls.Add(btnMinimizar);
            panBarraControl.Controls.Add(btnCerrar);
            panBarraControl.Dock = DockStyle.Top;
            panBarraControl.Location = new Point(286, 0);
            panBarraControl.Margin = new Padding(3, 4, 3, 4);
            panBarraControl.Name = "panBarraControl";
            panBarraControl.Size = new Size(594, 47);
            panBarraControl.TabIndex = 9;
            panBarraControl.MouseDown += panBarraControl_MouseDown;
            // 
            // btnMinimizar
            // 
            btnMinimizar.BackColor = Color.FromArgb(15, 15, 15);
            btnMinimizar.BackgroundImage = (Image)resources.GetObject("btnMinimizar.BackgroundImage");
            btnMinimizar.BackgroundImageLayout = ImageLayout.Center;
            btnMinimizar.DialogResult = DialogResult.Retry;
            btnMinimizar.Dock = DockStyle.Right;
            btnMinimizar.FlatAppearance.BorderSize = 0;
            btnMinimizar.FlatStyle = FlatStyle.Flat;
            btnMinimizar.Location = new Point(492, 0);
            btnMinimizar.Margin = new Padding(3, 4, 3, 4);
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.Size = new Size(51, 47);
            btnMinimizar.TabIndex = 1;
            btnMinimizar.UseVisualStyleBackColor = false;
            btnMinimizar.Click += btnMinimizar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.FromArgb(15, 15, 15);
            btnCerrar.BackgroundImage = (Image)resources.GetObject("btnCerrar.BackgroundImage");
            btnCerrar.BackgroundImageLayout = ImageLayout.Center;
            btnCerrar.DialogResult = DialogResult.Retry;
            btnCerrar.Dock = DockStyle.Right;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Location = new Point(543, 0);
            btnCerrar.Margin = new Padding(3, 4, 3, 4);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(51, 47);
            btnCerrar.TabIndex = 2;
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // frmIniciosesion
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(880, 450);
            Controls.Add(panBarraControl);
            Controls.Add(panDatosIngreso);
            Controls.Add(panLogo);
            Font = new Font("Microsoft Sans Serif", 6.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmIniciosesion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormInicioUsurio";
            Load += frmIniciosesion_Load;
            panLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbxContenedorImagen).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panDatosIngreso.ResumeLayout(false);
            panDatosIngreso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbxCargando).EndInit();
            panel5.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panBarraControl.ResumeLayout(false);
            panBarraControl.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panLogo;
        private Panel panDatosIngreso;
        private Button btnAcceder;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private PictureBox pictureBox1;
        private Label lblRecuperarContrasenia;
        private TextBox txtUsuario;
        private TextBox txtContrasenia;
        private Panel panBarraControl;
        private Button btnCerrar;
        private Label label3;
        private Button btnMinimizar;
        private PictureBox pbxContenedorImagen;
        private Label lblMensajeError;
        private PictureBox pbxCargando;
        private Button btnVer;
        private Button btnBiometrico;
    }
}