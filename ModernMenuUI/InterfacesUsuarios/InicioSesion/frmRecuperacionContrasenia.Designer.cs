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
            lblTitulo = new Label();
            btnAcceder = new Button();
            pbxLogoEmpresa = new PictureBox();
            panLogo = new Panel();
            panDatosIngreso = new Panel();
            lblRegresar = new Label();
            txtUsuario = new TextBox();
            panel3 = new Panel();
            panel4 = new Panel();
            btnCerrar = new Button();
            btnMinimizar = new Button();
            panBarraControl = new Panel();
            ((System.ComponentModel.ISupportInitialize)pbxLogoEmpresa).BeginInit();
            panLogo.SuspendLayout();
            panDatosIngreso.SuspendLayout();
            panel3.SuspendLayout();
            panBarraControl.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(142, 142, 142);
            lblTitulo.Location = new Point(100, 95);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(349, 24);
            lblTitulo.TabIndex = 7;
            lblTitulo.Text = "RECUPERACIÓN DE CONTRASEÑA";
            lblTitulo.Click += this.lblTitulo_Click;
            lblTitulo.MouseDown += lblTitulo_MouseDown;
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
            btnAcceder.Text = "ENVIAR CÓDIGO";
            btnAcceder.UseVisualStyleBackColor = false;
            btnAcceder.Click += this.btnAcceder_Click;
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
            pbxLogoEmpresa.Click += this.pbxLogoEmpresa_Click;
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
            panLogo.Paint += this.panLogo_Paint;
            // 
            // panDatosIngreso
            // 
            panDatosIngreso.BackColor = Color.FromArgb(15, 15, 15);
            panDatosIngreso.Controls.Add(lblRegresar);
            panDatosIngreso.Controls.Add(lblTitulo);
            panDatosIngreso.Controls.Add(txtUsuario);
            panDatosIngreso.Controls.Add(panel3);
            panDatosIngreso.Controls.Add(btnAcceder);
            panDatosIngreso.Dock = DockStyle.Fill;
            panDatosIngreso.Location = new Point(250, 0);
            panDatosIngreso.Name = "panDatosIngreso";
            panDatosIngreso.Size = new Size(550, 450);
            panDatosIngreso.TabIndex = 4;
            panDatosIngreso.Paint += this.panDatosIngreso_Paint;
            panDatosIngreso.MouseDown += panDatosIngreso_MouseDown;
            // 
            // lblRegresar
            // 
            lblRegresar.AutoSize = true;
            lblRegresar.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRegresar.ForeColor = Color.FromArgb(142, 142, 142);
            lblRegresar.Location = new Point(192, 346);
            lblRegresar.Name = "lblRegresar";
            lblRegresar.Size = new Size(160, 20);
            lblRegresar.TabIndex = 8;
            lblRegresar.Text = "REGRESAR AL INICIO";
            lblRegresar.Click += lblRegresar_Click;
            lblRegresar.MouseEnter += lblRegresar_MouseEnter;
            lblRegresar.MouseLeave += lblRegresar_MouseLeave;
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
            txtUsuario.TextChanged += this.txtUsuario_TextChanged;
            // 
            // panel3
            // 
            panel3.BackColor = Color.DimGray;
            panel3.Controls.Add(panel4);
            panel3.Location = new Point(64, 202);
            panel3.Name = "panel3";
            panel3.Size = new Size(420, 2);
            panel3.TabIndex = 1;
            panel3.Paint += this.panel3_Paint;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(142, 142, 142);
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(420, 2);
            panel4.TabIndex = 2;
            panel4.Paint += this.panel4_Paint;
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
            btnCerrar.Size = new Size(45, 47);
            btnCerrar.TabIndex = 0;
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
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
            btnMinimizar.Size = new Size(45, 47);
            btnMinimizar.TabIndex = 1;
            btnMinimizar.UseVisualStyleBackColor = false;
            btnMinimizar.Click += btnMinimizar_Click;
            // 
            // panBarraControl
            // 
            panBarraControl.BackColor = Color.FromArgb(15, 15, 15);
            panBarraControl.CausesValidation = false;
            panBarraControl.Controls.Add(btnMinimizar);
            panBarraControl.Controls.Add(btnCerrar);
            panBarraControl.Dock = DockStyle.Top;
            panBarraControl.Location = new Point(250, 0);
            panBarraControl.Name = "panBarraControl";
            panBarraControl.Size = new Size(550, 47);
            panBarraControl.TabIndex = 5;
            panBarraControl.Paint += panBarraControl_Paint;
            panBarraControl.MouseDown += panBarraControl_MouseDown;
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
            Name = "frmRecuperacionContrasenia";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RecuperacionContrasenia";
            ((System.ComponentModel.ISupportInitialize)pbxLogoEmpresa).EndInit();
            panLogo.ResumeLayout(false);
            panDatosIngreso.ResumeLayout(false);
            panDatosIngreso.PerformLayout();
            panel3.ResumeLayout(false);
            panBarraControl.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Label lblTitulo;
        private Button btnAcceder;
        private PictureBox pbxLogoEmpresa;
        private Panel panLogo;
        private Panel panDatosIngreso;
        private TextBox txtUsuario;
        private Panel panel3;
        private Panel panel4;
        private Label lblRegresar;
        private Button btnCerrar;
        private Button btnMinimizar;
        private Panel panBarraControl;
    }
}