namespace ModernMenuUI
{
    partial class RecuperacionContrasenia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecuperacionContrasenia));
            btnCerrar = new Button();
            panBarraControl = new Panel();
            label3 = new Label();
            btnMinimizar = new Button();
            pictureBox1 = new PictureBox();
            btnAcceder = new Button();
            pictureBox2 = new PictureBox();
            panLogo = new Panel();
            panDatosIngreso = new Panel();
            panel4 = new Panel();
            panel3 = new Panel();
            panel6 = new Panel();
            panel5 = new Panel();
            txtUsuario = new TextBox();
            panBarraControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panLogo.SuspendLayout();
            panDatosIngreso.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
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
            btnCerrar.Location = new Point(505, 0);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(45, 35);
            btnCerrar.TabIndex = 0;
            btnCerrar.UseVisualStyleBackColor = false;
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
            panBarraControl.Size = new Size(550, 35);
            panBarraControl.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(142, 142, 142);
            label3.Location = new Point(87, 9);
            label3.Name = "label3";
            label3.Size = new Size(349, 24);
            label3.TabIndex = 7;
            label3.Text = "RECUPERACION DE CONTRASEÑA";
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
            btnMinimizar.Location = new Point(460, 0);
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.Size = new Size(45, 35);
            btnMinimizar.TabIndex = 1;
            btnMinimizar.UseVisualStyleBackColor = false;
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
            // 
            // btnAcceder
            // 
            btnAcceder.BackColor = Color.FromArgb(40, 40, 40);
            btnAcceder.FlatAppearance.BorderSize = 0;
            btnAcceder.FlatStyle = FlatStyle.Flat;
            btnAcceder.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAcceder.ForeColor = Color.White;
            btnAcceder.Location = new Point(52, 249);
            btnAcceder.Name = "btnAcceder";
            btnAcceder.Size = new Size(418, 40);
            btnAcceder.TabIndex = 0;
            btnAcceder.Text = "ACCEDER";
            btnAcceder.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = Properties.Resources.el_cairo_2__1__12;
            pictureBox2.Location = new Point(0, 136);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(250, 170);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
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
            panLogo.Size = new Size(250, 450);
            panLogo.TabIndex = 3;
            // 
            // panDatosIngreso
            // 
            panDatosIngreso.BackColor = Color.FromArgb(15, 15, 15);
            panDatosIngreso.Controls.Add(txtUsuario);
            panDatosIngreso.Controls.Add(panel5);
            panDatosIngreso.Controls.Add(panel3);
            panDatosIngreso.Controls.Add(btnAcceder);
            panDatosIngreso.Dock = DockStyle.Fill;
            panDatosIngreso.Location = new Point(250, 0);
            panDatosIngreso.Name = "panDatosIngreso";
            panDatosIngreso.Size = new Size(550, 450);
            panDatosIngreso.TabIndex = 4;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(142, 142, 142);
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(420, 2);
            panel4.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.BackColor = Color.DimGray;
            panel3.Controls.Add(panel4);
            panel3.Location = new Point(52, 117);
            panel3.Name = "panel3";
            panel3.Size = new Size(420, 2);
            panel3.TabIndex = 1;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(142, 142, 142);
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(420, 2);
            panel6.TabIndex = 2;
            // 
            // panel5
            // 
            panel5.BackColor = Color.DimGray;
            panel5.Controls.Add(panel6);
            panel5.Location = new Point(52, 162);
            panel5.Name = "panel5";
            panel5.Size = new Size(420, 2);
            panel5.TabIndex = 3;
            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = Color.FromArgb(15, 15, 15);
            txtUsuario.BorderStyle = BorderStyle.None;
            txtUsuario.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsuario.ForeColor = Color.FromArgb(142, 142, 142);
            txtUsuario.Location = new Point(52, 91);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(420, 20);
            txtUsuario.TabIndex = 7;
            txtUsuario.Text = "Correo...";
            // 
            // RecuperacionContrasenia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panBarraControl);
            Controls.Add(panDatosIngreso);
            Controls.Add(panLogo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RecuperacionContrasenia";
            Text = "RecuperacionContrasenia";
            panBarraControl.ResumeLayout(false);
            panBarraControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panLogo.ResumeLayout(false);
            panDatosIngreso.ResumeLayout(false);
            panDatosIngreso.PerformLayout();
            panel3.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnCerrar;
        private Panel panBarraControl;
        private Label label3;
        private Button btnMinimizar;
        private PictureBox pictureBox1;
        private Button btnAcceder;
        private PictureBox pictureBox2;
        private Panel panLogo;
        private Panel panDatosIngreso;
        private TextBox txtUsuario;
        private Panel panel5;
        private Panel panel6;
        private Panel panel3;
        private Panel panel4;
    }
}