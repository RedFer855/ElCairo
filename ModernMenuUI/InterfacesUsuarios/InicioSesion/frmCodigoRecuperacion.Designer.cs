namespace ModernMenuUI.InterfacesUsuarios.InicioSesion
{
    partial class frmCodigoRecuperacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCodigoRecuperacion));
            panDatosIngreso = new Panel();
            panel1 = new Panel();
            button1 = new Button();
            button2 = new Button();
            lblRegresar = new Label();
            lblTitulo = new Label();
            txtUsuario = new TextBox();
            panel3 = new Panel();
            panel4 = new Panel();
            btnAcceder = new Button();
            panLogo = new Panel();
            pbxLogoEmpresa = new PictureBox();
            panDatosIngreso.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxLogoEmpresa).BeginInit();
            SuspendLayout();
            // 
            // panDatosIngreso
            // 
            panDatosIngreso.BackColor = Color.FromArgb(15, 15, 15);
            panDatosIngreso.Controls.Add(panel1);
            panDatosIngreso.Controls.Add(lblRegresar);
            panDatosIngreso.Controls.Add(lblTitulo);
            panDatosIngreso.Controls.Add(txtUsuario);
            panDatosIngreso.Controls.Add(panel3);
            panDatosIngreso.Controls.Add(btnAcceder);
            panDatosIngreso.Dock = DockStyle.Fill;
            panDatosIngreso.Location = new Point(250, 0);
            panDatosIngreso.Name = "panDatosIngreso";
            panDatosIngreso.Size = new Size(550, 450);
            panDatosIngreso.TabIndex = 7;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(15, 15, 15);
            panel1.CausesValidation = false;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(button2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(550, 47);
            panel1.TabIndex = 9;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(15, 15, 15);
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Center;
            button1.DialogResult = DialogResult.Retry;
            button1.Dock = DockStyle.Right;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(460, 0);
            button1.Name = "button1";
            button1.Size = new Size(45, 47);
            button1.TabIndex = 1;
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(15, 15, 15);
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.BackgroundImageLayout = ImageLayout.Center;
            button2.DialogResult = DialogResult.Retry;
            button2.Dock = DockStyle.Right;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(505, 0);
            button2.Name = "button2";
            button2.Size = new Size(45, 47);
            button2.TabIndex = 0;
            button2.UseVisualStyleBackColor = false;
            // 
            // lblRegresar
            // 
            lblRegresar.AutoSize = true;
            lblRegresar.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRegresar.ForeColor = Color.FromArgb(142, 142, 142);
            lblRegresar.Location = new Point(227, 343);
            lblRegresar.Name = "lblRegresar";
            lblRegresar.Size = new Size(83, 20);
            lblRegresar.TabIndex = 8;
            lblRegresar.Text = "REGRESAR";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(142, 142, 142);
            lblTitulo.Location = new Point(167, 97);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(219, 24);
            lblTitulo.TabIndex = 7;
            lblTitulo.Text = "INGRESE EL CÓDIGO";
            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = Color.FromArgb(15, 15, 15);
            txtUsuario.BorderStyle = BorderStyle.None;
            txtUsuario.Font = new Font("Century Gothic", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsuario.ForeColor = Color.FromArgb(142, 142, 142);
            txtUsuario.Location = new Point(64, 176);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(420, 25);
            txtUsuario.TabIndex = 7;
            txtUsuario.Text = "Correo...";
            // 
            // panel3
            // 
            panel3.BackColor = Color.DimGray;
            panel3.Controls.Add(panel4);
            panel3.Location = new Point(64, 202);
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
            btnAcceder.Location = new Point(64, 267);
            btnAcceder.Name = "btnAcceder";
            btnAcceder.Size = new Size(418, 40);
            btnAcceder.TabIndex = 0;
            btnAcceder.Text = "VERIFICAR CÓDIGO";
            btnAcceder.UseVisualStyleBackColor = false;
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
            panLogo.TabIndex = 6;
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
            // 
            // frmCodigoRecuperacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(panDatosIngreso);
            Controls.Add(panLogo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmCodigoRecuperacion";
            Text = "frmCodigoRecuperacion";
            panDatosIngreso.ResumeLayout(false);
            panDatosIngreso.PerformLayout();
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbxLogoEmpresa).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panDatosIngreso;
        private Label lblRegresar;
        private Label lblTitulo;
        private TextBox txtUsuario;
        private Panel panel3;
        private Panel panel4;
        private Button btnAcceder;
        private Panel panLogo;
        private PictureBox pbxLogoEmpresa;
        private Panel panel1;
        private Button button1;
        private Button button2;
    }
}