namespace ModernMenuUI
{
    partial class frmInicioBodega
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInicioBodega));
            panLogo = new Panel();
            lblMensajeError = new Label();
            txtContrasenia = new TextBox();
            label1 = new Label();
            txtCodigoBodega = new TextBox();
            btnAcceder = new Button();
            panBarraControl = new Panel();
            btnMinimizar = new Button();
            btnCerrar = new Button();
            panLogo.SuspendLayout();
            panBarraControl.SuspendLayout();
            SuspendLayout();
            // 
            // panLogo
            // 
            panLogo.BackColor = Color.FromArgb(189, 215, 238);
            panLogo.BackgroundImage = Properties.Resources.imglogin;
            panLogo.Controls.Add(lblMensajeError);
            panLogo.Controls.Add(txtContrasenia);
            panLogo.Controls.Add(label1);
            panLogo.Controls.Add(txtCodigoBodega);
            panLogo.Controls.Add(btnAcceder);
            panLogo.Dock = DockStyle.Fill;
            panLogo.Location = new Point(0, 35);
            panLogo.Name = "panLogo";
            panLogo.Size = new Size(638, 295);
            panLogo.TabIndex = 3;
            // 
            // lblMensajeError
            // 
            lblMensajeError.AutoSize = true;
            lblMensajeError.BackColor = Color.Transparent;
            lblMensajeError.Font = new Font("Itim", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMensajeError.ForeColor = Color.Red;
            lblMensajeError.Location = new Point(167, 195);
            lblMensajeError.Name = "lblMensajeError";
            lblMensajeError.Size = new Size(293, 14);
            lblMensajeError.TabIndex = 18;
            lblMensajeError.Text = "Código o contraseña incorrectos ingrese nuevamente...";
            lblMensajeError.TextAlign = ContentAlignment.TopCenter;
            lblMensajeError.Visible = false;
            // 
            // txtContrasenia
            // 
            txtContrasenia.BackColor = Color.White;
            txtContrasenia.BorderStyle = BorderStyle.None;
            txtContrasenia.Font = new Font("Itim", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContrasenia.ForeColor = Color.DimGray;
            txtContrasenia.Location = new Point(206, 151);
            txtContrasenia.Name = "txtContrasenia";
            txtContrasenia.Size = new Size(215, 23);
            txtContrasenia.TabIndex = 17;
            txtContrasenia.Text = "CONTRASEÑA";
            txtContrasenia.Enter += txtContrasenia_Enter;
            txtContrasenia.Leave += txtContrasenia_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(20, 20, 20);
            label1.Location = new Point(137, 52);
            label1.Name = "label1";
            label1.Size = new Size(359, 38);
            label1.TabIndex = 16;
            label1.Text = "Por favor, Ingrese el código de la bodega en la que \r\nel sistema realizará las acciones...\r\n";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtCodigoBodega
            // 
            txtCodigoBodega.BackColor = Color.White;
            txtCodigoBodega.BorderStyle = BorderStyle.None;
            txtCodigoBodega.Font = new Font("Itim", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCodigoBodega.ForeColor = Color.DimGray;
            txtCodigoBodega.Location = new Point(206, 110);
            txtCodigoBodega.Name = "txtCodigoBodega";
            txtCodigoBodega.Size = new Size(215, 23);
            txtCodigoBodega.TabIndex = 15;
            txtCodigoBodega.Text = "CÓDIGO";
            txtCodigoBodega.Enter += txtCodigoBodega_Enter;
            txtCodigoBodega.Leave += txtCodigoBodega_Leave;
            // 
            // btnAcceder
            // 
            btnAcceder.BackColor = Color.FromArgb(87, 99, 110);
            btnAcceder.FlatAppearance.BorderSize = 0;
            btnAcceder.FlatStyle = FlatStyle.Flat;
            btnAcceder.Font = new Font("Itim", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAcceder.ForeColor = Color.White;
            btnAcceder.Location = new Point(206, 231);
            btnAcceder.Name = "btnAcceder";
            btnAcceder.Size = new Size(215, 40);
            btnAcceder.TabIndex = 10;
            btnAcceder.Text = "ACCEDER";
            btnAcceder.UseVisualStyleBackColor = false;
            btnAcceder.Click += btnAcceder_Click;
            // 
            // panBarraControl
            // 
            panBarraControl.BackColor = Color.FromArgb(87, 99, 110);
            panBarraControl.Controls.Add(btnMinimizar);
            panBarraControl.Controls.Add(btnCerrar);
            panBarraControl.Dock = DockStyle.Top;
            panBarraControl.Location = new Point(0, 0);
            panBarraControl.Name = "panBarraControl";
            panBarraControl.Size = new Size(638, 35);
            panBarraControl.TabIndex = 5;
            panBarraControl.MouseDown += panBarraControl_MouseDown;
            // 
            // btnMinimizar
            // 
            btnMinimizar.BackColor = Color.FromArgb(87, 99, 110);
            btnMinimizar.BackgroundImage = (Image)resources.GetObject("btnMinimizar.BackgroundImage");
            btnMinimizar.BackgroundImageLayout = ImageLayout.Center;
            btnMinimizar.DialogResult = DialogResult.Retry;
            btnMinimizar.Dock = DockStyle.Right;
            btnMinimizar.FlatAppearance.BorderSize = 0;
            btnMinimizar.FlatStyle = FlatStyle.Flat;
            btnMinimizar.Location = new Point(548, 0);
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.Size = new Size(45, 35);
            btnMinimizar.TabIndex = 1;
            btnMinimizar.UseVisualStyleBackColor = false;
            btnMinimizar.Click += btnMinimizar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.FromArgb(87, 99, 110);
            btnCerrar.BackgroundImage = (Image)resources.GetObject("btnCerrar.BackgroundImage");
            btnCerrar.BackgroundImageLayout = ImageLayout.Center;
            btnCerrar.DialogResult = DialogResult.Retry;
            btnCerrar.Dock = DockStyle.Right;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Location = new Point(593, 0);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(45, 35);
            btnCerrar.TabIndex = 0;
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // frmInicioBodega
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(638, 330);
            Controls.Add(panLogo);
            Controls.Add(panBarraControl);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmInicioBodega";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmInicioBodega";
            panLogo.ResumeLayout(false);
            panLogo.PerformLayout();
            panBarraControl.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panLogo;
        private Panel panBarraControl;
        private Button btnMinimizar;
        private Button btnCerrar;
        private TextBox txtCodigoBodega;
        private Button btnAcceder;
        private Label label1;
        private TextBox txtContrasenia;
        private Label lblMensajeError;
    }
}