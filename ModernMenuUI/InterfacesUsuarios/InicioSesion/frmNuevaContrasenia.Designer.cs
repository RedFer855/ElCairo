namespace ModernMenuUI.InterfacesUsuarios.InicioSesion
{
    partial class frmNuevaContrasenia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuevaContrasenia));
            panDatosIngreso = new Panel();
            btnVerConfirmacion = new Button();
            btnVerNueva = new Button();
            panBarraControl = new Panel();
            btnMinimizar = new Button();
            btnCerrar = new Button();
            txtConfirContra = new TextBox();
            panel1 = new Panel();
            panel2 = new Panel();
            lblRegresar = new Label();
            lblTitulo = new Label();
            txtNuevaContra = new TextBox();
            panel3 = new Panel();
            panel4 = new Panel();
            btnCambiar = new Button();
            pbxLogoEmpresa = new PictureBox();
            panLogo = new Panel();
            panDatosIngreso.SuspendLayout();
            panBarraControl.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxLogoEmpresa).BeginInit();
            panLogo.SuspendLayout();
            SuspendLayout();
            // 
            // panDatosIngreso
            // 
            panDatosIngreso.BackColor = Color.FromArgb(15, 15, 15);
            panDatosIngreso.Controls.Add(btnVerConfirmacion);
            panDatosIngreso.Controls.Add(btnVerNueva);
            panDatosIngreso.Controls.Add(panBarraControl);
            panDatosIngreso.Controls.Add(txtConfirContra);
            panDatosIngreso.Controls.Add(panel1);
            panDatosIngreso.Controls.Add(lblRegresar);
            panDatosIngreso.Controls.Add(lblTitulo);
            panDatosIngreso.Controls.Add(txtNuevaContra);
            panDatosIngreso.Controls.Add(panel3);
            panDatosIngreso.Controls.Add(btnCambiar);
            panDatosIngreso.Dock = DockStyle.Fill;
            panDatosIngreso.Location = new Point(250, 0);
            panDatosIngreso.Margin = new Padding(4, 3, 4, 3);
            panDatosIngreso.Name = "panDatosIngreso";
            panDatosIngreso.Size = new Size(625, 422);
            panDatosIngreso.TabIndex = 7;
            // 
            // btnVerConfirmacion
            // 
            btnVerConfirmacion.BackColor = Color.FromArgb(15, 15, 15);
            btnVerConfirmacion.BackgroundImage = Properties.Resources.ojo;
            btnVerConfirmacion.BackgroundImageLayout = ImageLayout.Stretch;
            btnVerConfirmacion.FlatAppearance.BorderSize = 0;
            btnVerConfirmacion.FlatStyle = FlatStyle.Flat;
            btnVerConfirmacion.ForeColor = SystemColors.ControlText;
            btnVerConfirmacion.Location = new Point(506, 204);
            btnVerConfirmacion.Margin = new Padding(3, 2, 3, 2);
            btnVerConfirmacion.Name = "btnVerConfirmacion";
            btnVerConfirmacion.Size = new Size(30, 26);
            btnVerConfirmacion.TabIndex = 13;
            btnVerConfirmacion.UseVisualStyleBackColor = false;
            btnVerConfirmacion.MouseDown += btnVerConfirmacion_MouseDown;
            btnVerConfirmacion.MouseUp += btnVerConfirmacion_MouseUp;
            // 
            // btnVerNueva
            // 
            btnVerNueva.BackColor = Color.FromArgb(15, 15, 15);
            btnVerNueva.BackgroundImage = Properties.Resources.ojo;
            btnVerNueva.BackgroundImageLayout = ImageLayout.Stretch;
            btnVerNueva.FlatAppearance.BorderSize = 0;
            btnVerNueva.FlatStyle = FlatStyle.Flat;
            btnVerNueva.ForeColor = SystemColors.ControlText;
            btnVerNueva.Location = new Point(506, 149);
            btnVerNueva.Margin = new Padding(3, 2, 3, 2);
            btnVerNueva.Name = "btnVerNueva";
            btnVerNueva.Size = new Size(30, 26);
            btnVerNueva.TabIndex = 12;
            btnVerNueva.UseVisualStyleBackColor = false;
            btnVerNueva.MouseDown += btnVerNueva_MouseDown;
            btnVerNueva.MouseUp += btnVerNueva_MouseUp;
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
            panBarraControl.TabIndex = 11;
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
            // txtConfirContra
            // 
            txtConfirContra.BackColor = Color.FromArgb(15, 15, 15);
            txtConfirContra.BorderStyle = BorderStyle.None;
            txtConfirContra.Font = new Font("Century Gothic", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtConfirContra.ForeColor = Color.FromArgb(142, 142, 142);
            txtConfirContra.Location = new Point(82, 206);
            txtConfirContra.Margin = new Padding(4, 3, 4, 3);
            txtConfirContra.Name = "txtConfirContra";
            txtConfirContra.Size = new Size(459, 25);
            txtConfirContra.TabIndex = 10;
            txtConfirContra.Text = "Confirmar Contraseña...";
            txtConfirContra.Enter += txtConfirContra_Enter;
            txtConfirContra.Leave += txtConfirContra_Leave;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DimGray;
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(82, 235);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(459, 2);
            panel1.TabIndex = 9;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(142, 142, 142);
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(459, 2);
            panel2.TabIndex = 2;
            // 
            // lblRegresar
            // 
            lblRegresar.AutoSize = true;
            lblRegresar.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRegresar.ForeColor = Color.FromArgb(142, 142, 142);
            lblRegresar.Location = new Point(238, 340);
            lblRegresar.Margin = new Padding(4, 0, 4, 0);
            lblRegresar.Name = "lblRegresar";
            lblRegresar.Size = new Size(160, 20);
            lblRegresar.TabIndex = 8;
            lblRegresar.Text = "REGRESAR AL INICIO";
            lblRegresar.Click += lblRegresar_Click;
            lblRegresar.MouseEnter += lblRegresar_MouseEnter;
            lblRegresar.MouseLeave += lblRegresar_MouseLeave;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(142, 142, 142);
            lblTitulo.Location = new Point(129, 82);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(332, 24);
            lblTitulo.TabIndex = 7;
            lblTitulo.Text = "INGRESAR NUEVA CONTRASEÑA";
            lblTitulo.Click += lblTitulo_Click;
            // 
            // txtNuevaContra
            // 
            txtNuevaContra.BackColor = Color.FromArgb(15, 15, 15);
            txtNuevaContra.BorderStyle = BorderStyle.None;
            txtNuevaContra.Font = new Font("Century Gothic", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNuevaContra.ForeColor = Color.FromArgb(142, 142, 142);
            txtNuevaContra.Location = new Point(82, 151);
            txtNuevaContra.Margin = new Padding(4, 3, 4, 3);
            txtNuevaContra.Name = "txtNuevaContra";
            txtNuevaContra.Size = new Size(459, 25);
            txtNuevaContra.TabIndex = 7;
            txtNuevaContra.Text = "Nueva Contraseña...";
            txtNuevaContra.Enter += txtNuevaContra_Enter;
            txtNuevaContra.Leave += txtNuevaContra_Leave;
            // 
            // panel3
            // 
            panel3.BackColor = Color.DimGray;
            panel3.Controls.Add(panel4);
            panel3.Location = new Point(81, 180);
            panel3.Margin = new Padding(4, 3, 4, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(459, 2);
            panel3.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(142, 142, 142);
            panel4.Location = new Point(0, 0);
            panel4.Margin = new Padding(4, 3, 4, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(459, 2);
            panel4.TabIndex = 2;
            // 
            // btnCambiar
            // 
            btnCambiar.BackColor = Color.FromArgb(40, 40, 40);
            btnCambiar.FlatAppearance.BorderSize = 0;
            btnCambiar.FlatStyle = FlatStyle.Flat;
            btnCambiar.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCambiar.ForeColor = Color.White;
            btnCambiar.Location = new Point(183, 280);
            btnCambiar.Margin = new Padding(4, 3, 4, 3);
            btnCambiar.Name = "btnCambiar";
            btnCambiar.Size = new Size(274, 38);
            btnCambiar.TabIndex = 0;
            btnCambiar.Text = "CAMBIAR CONTRASEÑA";
            btnCambiar.UseVisualStyleBackColor = false;
            btnCambiar.Click += btnCambiar_Click;
            // 
            // pbxLogoEmpresa
            // 
            pbxLogoEmpresa.BackColor = Color.Transparent;
            pbxLogoEmpresa.Dock = DockStyle.Fill;
            pbxLogoEmpresa.Image = Properties.Resources.el_cairo_2__1__12;
            pbxLogoEmpresa.Location = new Point(0, 0);
            pbxLogoEmpresa.Margin = new Padding(4, 3, 4, 3);
            pbxLogoEmpresa.Name = "pbxLogoEmpresa";
            pbxLogoEmpresa.Size = new Size(250, 422);
            pbxLogoEmpresa.SizeMode = PictureBoxSizeMode.Zoom;
            pbxLogoEmpresa.TabIndex = 9;
            pbxLogoEmpresa.TabStop = false;
            // 
            // panLogo
            // 
            panLogo.BackColor = Color.FromArgb(189, 215, 238);
            panLogo.BackgroundImage = Properties.Resources.imglogin;
            panLogo.Controls.Add(pbxLogoEmpresa);
            panLogo.Dock = DockStyle.Left;
            panLogo.Location = new Point(0, 0);
            panLogo.Margin = new Padding(4, 3, 4, 3);
            panLogo.Name = "panLogo";
            panLogo.Size = new Size(250, 422);
            panLogo.TabIndex = 6;
            // 
            // frmNuevaContrasenia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(875, 422);
            Controls.Add(panDatosIngreso);
            Controls.Add(panLogo);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmNuevaContrasenia";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmNuevaContrasenia";
            panDatosIngreso.ResumeLayout(false);
            panDatosIngreso.PerformLayout();
            panBarraControl.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbxLogoEmpresa).EndInit();
            panLogo.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panDatosIngreso;
        private Label lblRegresar;
        private Label lblTitulo;
        private TextBox txtNuevaContra;
        private Panel panel3;
        private Panel panel4;
        private Button btnCambiar;
        private PictureBox pbxLogoEmpresa;
        private Panel panLogo;
        private TextBox txtConfirContra;
        private Panel panel1;
        private Panel panel2;
        private Panel panBarraControl;
        private Button btnMinimizar;
        private Button btnCerrar;
        private Button btnVerConfirmacion;
        private Button btnVerNueva;
    }
}