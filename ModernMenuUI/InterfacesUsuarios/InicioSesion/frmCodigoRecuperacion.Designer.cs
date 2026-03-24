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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCodigoRecuperacion));
            btnVerificar = new Button();
            panel3 = new Panel();
            panel4 = new Panel();
            txtCodigo = new TextBox();
            lblTitulo = new Label();
            lblRegresar = new Label();
            panDatosIngreso = new Panel();
            lblContadorReenvio = new Label();
            btnReenviar = new Button();
            panBarraControl = new Panel();
            btnMinimizar = new Button();
            btnCerrar = new Button();
            panLogo = new Panel();
            pbxLogoEmpresa = new PictureBox();
            timerReenvio = new System.Windows.Forms.Timer(components);
            panel3.SuspendLayout();
            panDatosIngreso.SuspendLayout();
            panBarraControl.SuspendLayout();
            panLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxLogoEmpresa).BeginInit();
            SuspendLayout();
            // 
            // btnVerificar
            // 
            btnVerificar.BackColor = Color.FromArgb(40, 40, 40);
            btnVerificar.FlatAppearance.BorderSize = 0;
            btnVerificar.FlatStyle = FlatStyle.Flat;
            btnVerificar.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnVerificar.ForeColor = Color.White;
            btnVerificar.Location = new Point(103, 211);
            btnVerificar.Name = "btnVerificar";
            btnVerificar.Size = new Size(418, 40);
            btnVerificar.TabIndex = 0;
            btnVerificar.Text = "VERFICAR CÓDIGO";
            btnVerificar.UseVisualStyleBackColor = false;
            btnVerificar.Click += btnVerificar_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.DimGray;
            panel3.Controls.Add(panel4);
            panel3.Location = new Point(104, 170);
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
            // txtCodigo
            // 
            txtCodigo.BackColor = Color.FromArgb(15, 15, 15);
            txtCodigo.BorderStyle = BorderStyle.None;
            txtCodigo.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCodigo.ForeColor = Color.FromArgb(142, 142, 142);
            txtCodigo.Location = new Point(104, 136);
            txtCodigo.MaxLength = 6;
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(420, 30);
            txtCodigo.TabIndex = 7;
            txtCodigo.Text = "Código...";
            txtCodigo.TextAlign = HorizontalAlignment.Center;
            txtCodigo.Enter += txtCodigo_Enter;
            txtCodigo.Leave += txtCodigo_Leave;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(142, 142, 142);
            lblTitulo.Location = new Point(200, 76);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(219, 24);
            lblTitulo.TabIndex = 7;
            lblTitulo.Text = "INGRESE EL CÓDIGO";
            lblTitulo.Click += lblTitulo_Click;
            // 
            // lblRegresar
            // 
            lblRegresar.AutoSize = true;
            lblRegresar.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRegresar.ForeColor = Color.FromArgb(142, 142, 142);
            lblRegresar.Location = new Point(271, 342);
            lblRegresar.Name = "lblRegresar";
            lblRegresar.Size = new Size(83, 20);
            lblRegresar.TabIndex = 8;
            lblRegresar.Text = "REGRESAR";
            lblRegresar.Click += lblRegresar_Click;
            lblRegresar.MouseEnter += lblRegresar_MouseEnter;
            lblRegresar.MouseLeave += lblRegresar_MouseLeave;
            // 
            // panDatosIngreso
            // 
            panDatosIngreso.BackColor = Color.FromArgb(15, 15, 15);
            panDatosIngreso.Controls.Add(lblContadorReenvio);
            panDatosIngreso.Controls.Add(btnReenviar);
            panDatosIngreso.Controls.Add(panBarraControl);
            panDatosIngreso.Controls.Add(lblRegresar);
            panDatosIngreso.Controls.Add(lblTitulo);
            panDatosIngreso.Controls.Add(txtCodigo);
            panDatosIngreso.Controls.Add(panel3);
            panDatosIngreso.Controls.Add(btnVerificar);
            panDatosIngreso.Dock = DockStyle.Fill;
            panDatosIngreso.Location = new Point(250, 0);
            panDatosIngreso.Name = "panDatosIngreso";
            panDatosIngreso.Size = new Size(625, 422);
            panDatosIngreso.TabIndex = 7;
            // 
            // lblContadorReenvio
            // 
            lblContadorReenvio.AutoSize = true;
            lblContadorReenvio.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblContadorReenvio.ForeColor = Color.FromArgb(142, 142, 142);
            lblContadorReenvio.Location = new Point(273, 284);
            lblContadorReenvio.Name = "lblContadorReenvio";
            lblContadorReenvio.Size = new Size(0, 20);
            lblContadorReenvio.TabIndex = 11;
            // 
            // btnReenviar
            // 
            btnReenviar.BackColor = Color.FromArgb(40, 40, 40);
            btnReenviar.FlatAppearance.BorderSize = 0;
            btnReenviar.FlatStyle = FlatStyle.Flat;
            btnReenviar.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReenviar.ForeColor = Color.White;
            btnReenviar.Location = new Point(103, 273);
            btnReenviar.Name = "btnReenviar";
            btnReenviar.Size = new Size(151, 40);
            btnReenviar.TabIndex = 10;
            btnReenviar.Text = "REENVIAR";
            btnReenviar.UseVisualStyleBackColor = false;
            btnReenviar.Click += btnReenviar_Click;
            // 
            // panBarraControl
            // 
            panBarraControl.BackColor = Color.FromArgb(15, 15, 15);
            panBarraControl.CausesValidation = false;
            panBarraControl.Controls.Add(btnMinimizar);
            panBarraControl.Controls.Add(btnCerrar);
            panBarraControl.Dock = DockStyle.Top;
            panBarraControl.Location = new Point(0, 0);
            panBarraControl.Margin = new Padding(4, 3, 4, 3);
            panBarraControl.Name = "panBarraControl";
            panBarraControl.Size = new Size(625, 47);
            panBarraControl.TabIndex = 9;
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
            btnMinimizar.Location = new Point(527, 0);
            btnMinimizar.Margin = new Padding(4, 3, 4, 3);
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.Size = new Size(49, 47);
            btnMinimizar.TabIndex = 1;
            btnMinimizar.UseVisualStyleBackColor = false;
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
            btnCerrar.Location = new Point(576, 0);
            btnCerrar.Margin = new Padding(4, 3, 4, 3);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(49, 47);
            btnCerrar.TabIndex = 0;
            btnCerrar.UseVisualStyleBackColor = false;
            // 
            // panLogo
            // 
            panLogo.BackColor = Color.FromArgb(189, 215, 238);
            panLogo.BackgroundImage = Properties.Resources.imglogin;
            panLogo.Controls.Add(pbxLogoEmpresa);
            panLogo.Dock = DockStyle.Left;
            panLogo.Location = new Point(0, 0);
            panLogo.Name = "panLogo";
            panLogo.Size = new Size(250, 422);
            panLogo.TabIndex = 6;
            // 
            // pbxLogoEmpresa
            // 
            pbxLogoEmpresa.BackColor = Color.Transparent;
            pbxLogoEmpresa.Dock = DockStyle.Fill;
            pbxLogoEmpresa.Image = Properties.Resources.el_cairo_2__1__12;
            pbxLogoEmpresa.Location = new Point(0, 0);
            pbxLogoEmpresa.Name = "pbxLogoEmpresa";
            pbxLogoEmpresa.Size = new Size(250, 422);
            pbxLogoEmpresa.SizeMode = PictureBoxSizeMode.Zoom;
            pbxLogoEmpresa.TabIndex = 9;
            pbxLogoEmpresa.TabStop = false;
            // 
            // timerReenvio
            // 
            timerReenvio.Interval = 1000;
            timerReenvio.Tick += timerReenvio_Tick;
            // 
            // frmCodigoRecuperacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(875, 422);
            ControlBox = false;
            Controls.Add(panDatosIngreso);
            Controls.Add(panLogo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmCodigoRecuperacion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmCodigoRecuperacion";
            Load += frmCodigoRecuperacion_Load;
            panel3.ResumeLayout(false);
            panDatosIngreso.ResumeLayout(false);
            panDatosIngreso.PerformLayout();
            panBarraControl.ResumeLayout(false);
            panLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbxLogoEmpresa).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnVerificar;
        private Panel panel3;
        private Panel panel4;
        private TextBox txtCodigo;
        private Label lblTitulo;
        private Label lblRegresar;
        private Panel panDatosIngreso;
        private Panel panLogo;
        private PictureBox pbxLogoEmpresa;
        private Panel panBarraControl;
        private Button btnMinimizar;
        private Button btnCerrar;
        private Button btnReenviar;
        private Label lblContadorReenvio;
        private System.Windows.Forms.Timer timerReenvio;
    }
}