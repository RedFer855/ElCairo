namespace ModernMenuUI
{
    partial class FormInicioUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInicioUsuarios));
            panLogo = new Panel();
            pictureBox1 = new PictureBox();
            panDatosIngreso = new Panel();
            txtContra = new TextBox();
            txtUsuario = new TextBox();
            label4 = new Label();
            panel5 = new Panel();
            panel6 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            btnAcceder = new Button();
            label3 = new Label();
            panBarraControl = new Panel();
            btnMinimizar = new Button();
            btnCerrar = new Button();
            pictureBox2 = new PictureBox();
            panLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panDatosIngreso.SuspendLayout();
            panel5.SuspendLayout();
            panel3.SuspendLayout();
            panBarraControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panLogo
            // 
            panLogo.BackColor = Color.FromArgb(189, 215, 238);
            panLogo.BackgroundImage = Properties.Resources.imglogin;
            panLogo.Controls.Add(pictureBox2);
            panLogo.Controls.Add(pictureBox1);
            panLogo.Dock = DockStyle.Left;
            panLogo.Location = new Point(0, 0);
            panLogo.Name = "panLogo";
            panLogo.Size = new Size(250, 330);
            panLogo.TabIndex = 0;
            panLogo.MouseDown += panLogo_MouseDown;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(250, 260);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            // 
            // panDatosIngreso
            // 
            panDatosIngreso.BackColor = Color.FromArgb(15, 15, 15);
            panDatosIngreso.Controls.Add(txtContra);
            panDatosIngreso.Controls.Add(txtUsuario);
            panDatosIngreso.Controls.Add(label4);
            panDatosIngreso.Controls.Add(panel5);
            panDatosIngreso.Controls.Add(panel3);
            panDatosIngreso.Controls.Add(btnAcceder);
            panDatosIngreso.Dock = DockStyle.Fill;
            panDatosIngreso.Location = new Point(250, 0);
            panDatosIngreso.Name = "panDatosIngreso";
            panDatosIngreso.Size = new Size(530, 330);
            panDatosIngreso.TabIndex = 1;
            panDatosIngreso.MouseDown += panDatosIngreso_MouseDown;
            // 
            // txtContra
            // 
            txtContra.BackColor = Color.FromArgb(15, 15, 15);
            txtContra.BorderStyle = BorderStyle.None;
            txtContra.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContra.ForeColor = Color.FromArgb(142, 142, 142);
            txtContra.Location = new Point(54, 138);
            txtContra.Name = "txtContra";
            txtContra.Size = new Size(420, 20);
            txtContra.TabIndex = 8;
            txtContra.Text = "CONTRASEÑA";
            txtContra.Enter += txtContra_Enter;
            txtContra.Leave += txtContra_Leave;
            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = Color.FromArgb(15, 15, 15);
            txtUsuario.BorderStyle = BorderStyle.None;
            txtUsuario.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsuario.ForeColor = Color.FromArgb(142, 142, 142);
            txtUsuario.Location = new Point(54, 97);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(420, 20);
            txtUsuario.TabIndex = 7;
            txtUsuario.Text = "USUARIO";
            txtUsuario.Enter += txtUsuario_Enter;
            txtUsuario.Leave += txtUsuario_Leave;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.FromArgb(142, 142, 142);
            label4.Location = new Point(186, 278);
            label4.Name = "label4";
            label4.Size = new Size(161, 15);
            label4.TabIndex = 5;
            label4.Text = "¿Has olvidado tu contraseña?";
            // 
            // panel5
            // 
            panel5.BackColor = Color.DimGray;
            panel5.Controls.Add(panel6);
            panel5.Location = new Point(54, 164);
            panel5.Name = "panel5";
            panel5.Size = new Size(420, 2);
            panel5.TabIndex = 3;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(142, 142, 142);
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(420, 2);
            panel6.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.BackColor = Color.DimGray;
            panel3.Controls.Add(panel4);
            panel3.Location = new Point(54, 125);
            panel3.Name = "panel3";
            panel3.Size = new Size(420, 2);
            panel3.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(142, 142, 142);
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(420, 2);
            panel4.TabIndex = 2;
            // 
            // btnAcceder
            // 
            btnAcceder.BackColor = Color.FromArgb(40, 40, 40);
            btnAcceder.FlatAppearance.BorderSize = 0;
            btnAcceder.FlatStyle = FlatStyle.Flat;
            btnAcceder.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAcceder.ForeColor = Color.White;
            btnAcceder.Location = new Point(56, 205);
            btnAcceder.Name = "btnAcceder";
            btnAcceder.Size = new Size(418, 40);
            btnAcceder.TabIndex = 0;
            btnAcceder.Text = "ACCEDER";
            btnAcceder.UseVisualStyleBackColor = false;
            btnAcceder.Click += btnAcceder_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(142, 142, 142);
            label3.Location = new Point(176, 9);
            label3.Name = "label3";
            label3.Size = new Size(185, 24);
            label3.TabIndex = 7;
            label3.Text = "INICIO DE SESIÓN";
            // 
            // panBarraControl
            // 
            panBarraControl.BackColor = Color.FromArgb(15, 15, 15);
            panBarraControl.Controls.Add(label3);
            panBarraControl.Controls.Add(btnMinimizar);
            panBarraControl.Controls.Add(btnCerrar);
            panBarraControl.Dock = DockStyle.Top;
            panBarraControl.Location = new Point(250, 0);
            panBarraControl.Name = "panBarraControl";
            panBarraControl.Size = new Size(530, 35);
            panBarraControl.TabIndex = 2;
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
            btnMinimizar.Location = new Point(440, 0);
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.Size = new Size(45, 35);
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
            btnCerrar.Location = new Point(485, 0);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(45, 35);
            btnCerrar.TabIndex = 0;
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = Properties.Resources.el_cairo_2__1__12;
            pictureBox2.Location = new Point(0, 75);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(250, 170);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // FormInicioUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 330);
            Controls.Add(panBarraControl);
            Controls.Add(panDatosIngreso);
            Controls.Add(panLogo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormInicioUsuarios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormInicioUsurio";
            panLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panDatosIngreso.ResumeLayout(false);
            panDatosIngreso.PerformLayout();
            panel5.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panBarraControl.ResumeLayout(false);
            panBarraControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
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
        private Label label4;
        private TextBox txtUsuario;
        private TextBox txtContra;
        private Panel panBarraControl;
        private Button btnCerrar;
        private Label label3;
        private Button btnMinimizar;
        private PictureBox pictureBox2;
    }
}