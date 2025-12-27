namespace ModernMenuUI
{
    partial class frmRecuperacionContrasenia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecuperacionContrasenia));
            btnCerrar = new Button();
            panBarraControl = new Panel();
            lblTitulo = new Label();
            btnMinimizar = new Button();
            btnAcceder = new Button();
            pbxLogoEmpresa = new PictureBox();
            panLogo = new Panel();
            panDatosIngreso = new Panel();
            groupBox1 = new GroupBox();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            textBox3 = new TextBox();
            panel7 = new Panel();
            panel8 = new Panel();
            textBox2 = new TextBox();
            panel1 = new Panel();
            panel2 = new Panel();
            textBox1 = new TextBox();
            txtUsuario = new TextBox();
            panel5 = new Panel();
            panel6 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panBarraControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxLogoEmpresa).BeginInit();
            panLogo.SuspendLayout();
            panDatosIngreso.SuspendLayout();
            groupBox1.SuspendLayout();
            panel7.SuspendLayout();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            panel3.SuspendLayout();
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
            panBarraControl.Controls.Add(lblTitulo);
            panBarraControl.Controls.Add(btnMinimizar);
            panBarraControl.Controls.Add(btnCerrar);
            panBarraControl.Dock = DockStyle.Top;
            panBarraControl.Location = new Point(250, 0);
            panBarraControl.Name = "panBarraControl";
            panBarraControl.Size = new Size(550, 35);
            panBarraControl.TabIndex = 5;
            panBarraControl.MouseDown += panBarraControl_MouseDown;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(142, 142, 142);
            lblTitulo.Location = new Point(87, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(349, 24);
            lblTitulo.TabIndex = 7;
            lblTitulo.Text = "RECUPERACION DE CONTRASEÑA";
            lblTitulo.MouseDown += lblTitulo_MouseDown;
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
            // btnAcceder
            // 
            btnAcceder.BackColor = Color.FromArgb(40, 40, 40);
            btnAcceder.FlatAppearance.BorderSize = 0;
            btnAcceder.FlatStyle = FlatStyle.Flat;
            btnAcceder.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAcceder.ForeColor = Color.White;
            btnAcceder.Location = new Point(54, 379);
            btnAcceder.Name = "btnAcceder";
            btnAcceder.Size = new Size(418, 40);
            btnAcceder.TabIndex = 0;
            btnAcceder.Text = "SOLICITAR ACCESO";
            btnAcceder.UseVisualStyleBackColor = false;
            // 
            // pbxLogoEmpresa
            // 
            pbxLogoEmpresa.BackColor = Color.Transparent;
            pbxLogoEmpresa.Dock = DockStyle.Fill;
            pbxLogoEmpresa.Image = Properties.Resources.el_cairo_2__1__12;
            pbxLogoEmpresa.Location = new Point(0, 0);
            pbxLogoEmpresa.Name = "pbxLogoEmpresa";
            pbxLogoEmpresa.Size = new Size(250, 450);
            pbxLogoEmpresa.SizeMode = PictureBoxSizeMode.Zoom;
            pbxLogoEmpresa.TabIndex = 9;
            pbxLogoEmpresa.TabStop = false;
            pbxLogoEmpresa.MouseDown += pbxLogoEmpresa_MouseDown;
            // 
            // panLogo
            // 
            panLogo.BackColor = Color.FromArgb(189, 215, 238);
            panLogo.BackgroundImage = Properties.Resources.imglogin;
            panLogo.Controls.Add(pbxLogoEmpresa);
            panLogo.Dock = DockStyle.Left;
            panLogo.Location = new Point(0, 0);
            panLogo.Name = "panLogo";
            panLogo.Size = new Size(250, 450);
            panLogo.TabIndex = 3;
            // 
            // panDatosIngreso
            // 
            panDatosIngreso.BackColor = Color.FromArgb(15, 15, 15);
            panDatosIngreso.Controls.Add(groupBox1);
            panDatosIngreso.Controls.Add(textBox3);
            panDatosIngreso.Controls.Add(panel7);
            panDatosIngreso.Controls.Add(textBox2);
            panDatosIngreso.Controls.Add(panel1);
            panDatosIngreso.Controls.Add(textBox1);
            panDatosIngreso.Controls.Add(txtUsuario);
            panDatosIngreso.Controls.Add(panel5);
            panDatosIngreso.Controls.Add(panel3);
            panDatosIngreso.Controls.Add(btnAcceder);
            panDatosIngreso.Dock = DockStyle.Fill;
            panDatosIngreso.Location = new Point(250, 0);
            panDatosIngreso.Name = "panDatosIngreso";
            panDatosIngreso.Size = new Size(550, 450);
            panDatosIngreso.TabIndex = 4;
            panDatosIngreso.MouseDown += panDatosIngreso_MouseDown;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = SystemColors.ControlDarkDark;
            groupBox1.Location = new Point(54, 257);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(418, 98);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Seleccione método de recuperación:";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(21, 56);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(190, 24);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "Enviar códio al correo";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(21, 29);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(191, 24);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Enviar código por SMS";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.FromArgb(15, 15, 15);
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox3.ForeColor = Color.FromArgb(142, 142, 142);
            textBox3.Location = new Point(52, 206);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(420, 20);
            textBox3.TabIndex = 12;
            textBox3.Text = "Apellidos...";
            // 
            // panel7
            // 
            panel7.BackColor = Color.DimGray;
            panel7.Controls.Add(panel8);
            panel7.Location = new Point(52, 232);
            panel7.Name = "panel7";
            panel7.Size = new Size(420, 2);
            panel7.TabIndex = 11;
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(142, 142, 142);
            panel8.Location = new Point(0, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(420, 2);
            panel8.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(15, 15, 15);
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.ForeColor = Color.FromArgb(142, 142, 142);
            textBox2.Location = new Point(52, 153);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(420, 20);
            textBox2.TabIndex = 10;
            textBox2.Text = "Nombres...";
            // 
            // panel1
            // 
            panel1.BackColor = Color.DimGray;
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(52, 179);
            panel1.Name = "panel1";
            panel1.Size = new Size(420, 2);
            panel1.TabIndex = 9;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(142, 142, 142);
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(420, 2);
            panel2.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(15, 15, 15);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.ForeColor = Color.FromArgb(142, 142, 142);
            textBox1.Location = new Point(52, 103);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(420, 20);
            textBox1.TabIndex = 8;
            textBox1.Text = "No de Teléfono...";
            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = Color.FromArgb(15, 15, 15);
            txtUsuario.BorderStyle = BorderStyle.None;
            txtUsuario.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsuario.ForeColor = Color.FromArgb(142, 142, 142);
            txtUsuario.Location = new Point(52, 58);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(420, 20);
            txtUsuario.TabIndex = 7;
            txtUsuario.Text = "Correo...";
            // 
            // panel5
            // 
            panel5.BackColor = Color.DimGray;
            panel5.Controls.Add(panel6);
            panel5.Location = new Point(52, 129);
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
            panel3.Location = new Point(52, 84);
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
            // frmRecuperacionContrasenia
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(800, 450);
            Controls.Add(panBarraControl);
            Controls.Add(panDatosIngreso);
            Controls.Add(panLogo);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmRecuperacionContrasenia";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RecuperacionContrasenia";
            panBarraControl.ResumeLayout(false);
            panBarraControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbxLogoEmpresa).EndInit();
            panLogo.ResumeLayout(false);
            panDatosIngreso.ResumeLayout(false);
            panDatosIngreso.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel7.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnCerrar;
        private Panel panBarraControl;
        private Label lblTitulo;
        private Button btnMinimizar;
        private Button btnAcceder;
        private PictureBox pbxLogoEmpresa;
        private Panel panLogo;
        private Panel panDatosIngreso;
        private TextBox txtUsuario;
        private Panel panel5;
        private Panel panel6;
        private Panel panel3;
        private Panel panel4;
        private TextBox textBox3;
        private Panel panel7;
        private Panel panel8;
        private TextBox textBox2;
        private Panel panel1;
        private Panel panel2;
        private TextBox textBox1;
        private GroupBox groupBox1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
    }
}