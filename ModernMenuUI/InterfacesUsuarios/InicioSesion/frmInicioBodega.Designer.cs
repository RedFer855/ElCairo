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
            btnVer = new Button();
            panel2 = new Panel();
            panel4 = new Panel();
            lblMensajeError = new Label();
            txtContrasenia = new TextBox();
            panBarraControl = new Panel();
            label2 = new Label();
            btnMinimizar = new Button();
            btnCerrar = new Button();
            txtCodigoBodega = new TextBox();
            btnAcceder = new Button();
            panel1 = new Panel();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panLogo.SuspendLayout();
            panBarraControl.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panLogo
            // 
            panLogo.BackColor = Color.FromArgb(15, 15, 15);
            panLogo.Controls.Add(btnVer);
            panLogo.Controls.Add(panel2);
            panLogo.Controls.Add(panel4);
            panLogo.Controls.Add(lblMensajeError);
            panLogo.Controls.Add(txtContrasenia);
            panLogo.Controls.Add(panBarraControl);
            panLogo.Controls.Add(txtCodigoBodega);
            panLogo.Controls.Add(btnAcceder);
            panLogo.Dock = DockStyle.Fill;
            panLogo.Location = new Point(269, 0);
            panLogo.Margin = new Padding(4);
            panLogo.Name = "panLogo";
            panLogo.Size = new Size(536, 362);
            panLogo.TabIndex = 3;
            // 
            // btnVer
            // 
            btnVer.BackgroundImage = (Image)resources.GetObject("btnVer.BackgroundImage");
            btnVer.BackgroundImageLayout = ImageLayout.Zoom;
            btnVer.FlatStyle = FlatStyle.Flat;
            btnVer.ForeColor = Color.FromArgb(15, 15, 15);
            btnVer.Location = new Point(420, 124);
            btnVer.Name = "btnVer";
            btnVer.Size = new Size(37, 36);
            btnVer.TabIndex = 21;
            btnVer.UseVisualStyleBackColor = true;
            btnVer.MouseDown += btnVer_MouseDown;
            btnVer.MouseUp += btnVer_MouseUp;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(142, 142, 142);
            panel2.Location = new Point(77, 162);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(380, 3);
            panel2.TabIndex = 20;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(142, 142, 142);
            panel4.Location = new Point(77, 109);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(380, 3);
            panel4.TabIndex = 19;
            // 
            // lblMensajeError
            // 
            lblMensajeError.BackColor = Color.Transparent;
            lblMensajeError.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMensajeError.ForeColor = Color.FromArgb(134, 27, 45);
            lblMensajeError.Location = new Point(77, 238);
            lblMensajeError.Margin = new Padding(4, 0, 4, 0);
            lblMensajeError.Name = "lblMensajeError";
            lblMensajeError.Size = new Size(386, 19);
            lblMensajeError.TabIndex = 18;
            lblMensajeError.Text = "Código o contraseña incorrectos ingrese nuevamente...";
            lblMensajeError.TextAlign = ContentAlignment.MiddleCenter;
            lblMensajeError.Visible = false;
            // 
            // txtContrasenia
            // 
            txtContrasenia.BackColor = Color.FromArgb(15, 15, 15);
            txtContrasenia.BorderStyle = BorderStyle.None;
            txtContrasenia.Font = new Font("Century Gothic", 14.25F);
            txtContrasenia.ForeColor = Color.FromArgb(142, 142, 142);
            txtContrasenia.Location = new Point(77, 130);
            txtContrasenia.Margin = new Padding(4);
            txtContrasenia.Name = "txtContrasenia";
            txtContrasenia.Size = new Size(328, 24);
            txtContrasenia.TabIndex = 17;
            txtContrasenia.Text = "CONTRASEÑA";
            txtContrasenia.Enter += txtContrasenia_Enter;
            txtContrasenia.KeyDown += txtContrasenia_KeyDown;
            txtContrasenia.Leave += txtContrasenia_Leave;
            // 
            // panBarraControl
            // 
            panBarraControl.BackColor = Color.FromArgb(15, 15, 15);
            panBarraControl.Controls.Add(label2);
            panBarraControl.Controls.Add(btnMinimizar);
            panBarraControl.Controls.Add(btnCerrar);
            panBarraControl.Dock = DockStyle.Top;
            panBarraControl.ForeColor = SystemColors.ControlText;
            panBarraControl.Location = new Point(0, 0);
            panBarraControl.Margin = new Padding(4);
            panBarraControl.Name = "panBarraControl";
            panBarraControl.Size = new Size(536, 44);
            panBarraControl.TabIndex = 5;
            panBarraControl.MouseDown += panBarraControl_MouseDown;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(142, 142, 142);
            label2.Location = new Point(0, 0);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Padding = new Padding(80, 0, 0, 0);
            label2.Size = new Size(420, 44);
            label2.TabIndex = 19;
            label2.Text = "INICIO POR BODEGA";
            label2.TextAlign = ContentAlignment.MiddleCenter;
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
            btnMinimizar.Location = new Point(420, 0);
            btnMinimizar.Margin = new Padding(4);
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.Size = new Size(58, 44);
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
            btnCerrar.Location = new Point(478, 0);
            btnCerrar.Margin = new Padding(4);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(58, 44);
            btnCerrar.TabIndex = 0;
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // txtCodigoBodega
            // 
            txtCodigoBodega.BackColor = Color.FromArgb(15, 15, 15);
            txtCodigoBodega.BorderStyle = BorderStyle.None;
            txtCodigoBodega.Font = new Font("Century Gothic", 14.25F);
            txtCodigoBodega.ForeColor = Color.FromArgb(142, 142, 142);
            txtCodigoBodega.Location = new Point(77, 77);
            txtCodigoBodega.Margin = new Padding(4);
            txtCodigoBodega.Name = "txtCodigoBodega";
            txtCodigoBodega.Size = new Size(380, 24);
            txtCodigoBodega.TabIndex = 15;
            txtCodigoBodega.Text = "CÓDIGO";
            txtCodigoBodega.Enter += txtCodigoBodega_Enter;
            txtCodigoBodega.KeyDown += txtCodigoBodega_KeyDown;
            txtCodigoBodega.Leave += txtCodigoBodega_Leave;
            // 
            // btnAcceder
            // 
            btnAcceder.BackColor = Color.FromArgb(40, 40, 40);
            btnAcceder.FlatAppearance.BorderSize = 0;
            btnAcceder.FlatStyle = FlatStyle.Flat;
            btnAcceder.Font = new Font("Century Gothic", 14.25F);
            btnAcceder.ForeColor = Color.White;
            btnAcceder.Location = new Point(129, 272);
            btnAcceder.Margin = new Padding(4);
            btnAcceder.Name = "btnAcceder";
            btnAcceder.Size = new Size(276, 51);
            btnAcceder.TabIndex = 10;
            btnAcceder.Text = "ACCEDER";
            btnAcceder.UseVisualStyleBackColor = false;
            btnAcceder.Click += btnAcceder_Click;
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.imglogin;
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(269, 362);
            panel1.TabIndex = 6;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(0, 210);
            pictureBox2.Margin = new Padding(80);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(269, 124);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = Properties.Resources.el_cairo_2__1__1__1_;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(269, 204);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // frmInicioBodega
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(805, 362);
            Controls.Add(panLogo);
            Controls.Add(panel1);
            Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "frmInicioBodega";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmInicioBodega";
            Load += frmInicioBodega_Load;
            panLogo.ResumeLayout(false);
            panLogo.PerformLayout();
            panBarraControl.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panLogo;
        private Panel panBarraControl;
        private Button btnMinimizar;
        private Button btnCerrar;
        private TextBox txtCodigoBodega;
        private Button btnAcceder;
        private TextBox txtContrasenia;
        private Label lblMensajeError;
        private Label label2;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Panel panel4;
        private Panel panel2;
        private PictureBox pictureBox2;
        private Button btnVer;
    }
}