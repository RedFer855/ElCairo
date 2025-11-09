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
            label2 = new Label();
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
            panLogo.Location = new Point(0, 44);
            panLogo.Margin = new Padding(4);
            panLogo.Name = "panLogo";
            panLogo.Size = new Size(596, 318);
            panLogo.TabIndex = 3;
            // 
            // lblMensajeError
            // 
            lblMensajeError.AutoSize = true;
            lblMensajeError.BackColor = Color.Transparent;
            lblMensajeError.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMensajeError.ForeColor = Color.Red;
            lblMensajeError.Location = new Point(109, 188);
            lblMensajeError.Margin = new Padding(4, 0, 4, 0);
            lblMensajeError.Name = "lblMensajeError";
            lblMensajeError.Size = new Size(386, 19);
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
            txtContrasenia.Location = new Point(92, 144);
            txtContrasenia.Margin = new Padding(4);
            txtContrasenia.Name = "txtContrasenia";
            txtContrasenia.Size = new Size(405, 23);
            txtContrasenia.TabIndex = 17;
            txtContrasenia.Text = "CONTRASEÑA";
            txtContrasenia.Enter += txtContrasenia_Enter;
            txtContrasenia.Leave += txtContrasenia_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Itim", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(50, 50, 50);
            label1.Location = new Point(92, 35);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(417, 46);
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
            txtCodigoBodega.Location = new Point(92, 113);
            txtCodigoBodega.Margin = new Padding(4);
            txtCodigoBodega.Name = "txtCodigoBodega";
            txtCodigoBodega.Size = new Size(405, 23);
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
            btnAcceder.Location = new Point(157, 221);
            btnAcceder.Margin = new Padding(4);
            btnAcceder.Name = "btnAcceder";
            btnAcceder.Size = new Size(276, 51);
            btnAcceder.TabIndex = 10;
            btnAcceder.Text = "ACCEDER";
            btnAcceder.UseVisualStyleBackColor = false;
            btnAcceder.Click += btnAcceder_Click;
            // 
            // panBarraControl
            // 
            panBarraControl.BackColor = Color.FromArgb(87, 99, 110);
            panBarraControl.Controls.Add(label2);
            panBarraControl.Controls.Add(btnMinimizar);
            panBarraControl.Controls.Add(btnCerrar);
            panBarraControl.Dock = DockStyle.Top;
            panBarraControl.Location = new Point(0, 0);
            panBarraControl.Margin = new Padding(4);
            panBarraControl.Name = "panBarraControl";
            panBarraControl.Size = new Size(596, 44);
            panBarraControl.TabIndex = 5;
            panBarraControl.MouseDown += panBarraControl_MouseDown;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Itim", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(0, 0);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(480, 44);
            label2.TabIndex = 19;
            label2.Text = "     INGRESE A UNA BODEGA";
            label2.TextAlign = ContentAlignment.MiddleLeft;
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
            btnMinimizar.Location = new Point(480, 0);
            btnMinimizar.Margin = new Padding(4);
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.Size = new Size(58, 44);
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
            btnCerrar.Location = new Point(538, 0);
            btnCerrar.Margin = new Padding(4);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(58, 44);
            btnCerrar.TabIndex = 0;
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // frmInicioBodega
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(596, 362);
            Controls.Add(panLogo);
            Controls.Add(panBarraControl);
            Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
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
        private Label label2;
    }
}