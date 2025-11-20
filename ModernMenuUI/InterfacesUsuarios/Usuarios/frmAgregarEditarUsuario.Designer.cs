namespace ModernMenuUI.InterfacesUsuarios.Usuarios
{
    partial class frmAgregarEditarUsuario
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
            Panel panBarraControl;
            lblNombreModulo = new Label();
            btnVolver = new Button();
            radioButton2 = new RadioButton();
            btnGuardarEmpleado = new Button();
            label3 = new Label();
            groupBox1 = new GroupBox();
            rdbActivo = new RadioButton();
            label6 = new Label();
            label5 = new Label();
            txtCorreo = new TextBox();
            panel2 = new Panel();
            cmbRol = new ComboBox();
            panBarraControl = new Panel();
            panBarraControl.SuspendLayout();
            groupBox1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panBarraControl
            // 
            panBarraControl.BackColor = Color.FromArgb(148, 168, 187);
            panBarraControl.Controls.Add(lblNombreModulo);
            panBarraControl.Dock = DockStyle.Top;
            panBarraControl.ForeColor = Color.Coral;
            panBarraControl.Location = new Point(0, 0);
            panBarraControl.Name = "panBarraControl";
            panBarraControl.Size = new Size(497, 41);
            panBarraControl.TabIndex = 15;
            // 
            // lblNombreModulo
            // 
            lblNombreModulo.Dock = DockStyle.Fill;
            lblNombreModulo.Font = new Font("Itim", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombreModulo.ForeColor = Color.White;
            lblNombreModulo.Location = new Point(0, 0);
            lblNombreModulo.Name = "lblNombreModulo";
            lblNombreModulo.Size = new Size(497, 41);
            lblNombreModulo.TabIndex = 13;
            lblNombreModulo.Text = "USUARIO";
            lblNombreModulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.FromArgb(148, 168, 187);
            btnVolver.BackgroundImageLayout = ImageLayout.None;
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.Font = new Font("Itim", 11.9999981F);
            btnVolver.ForeColor = SystemColors.ButtonFace;
            btnVolver.ImageAlign = ContentAlignment.BottomLeft;
            btnVolver.Location = new Point(254, 243);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(95, 37);
            btnVolver.TabIndex = 10;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(124, 20);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(82, 23);
            radioButton2.TabIndex = 9;
            radioButton2.TabStop = true;
            radioButton2.Text = "Inactivo";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // btnGuardarEmpleado
            // 
            btnGuardarEmpleado.BackColor = Color.FromArgb(149, 195, 172);
            btnGuardarEmpleado.BackgroundImageLayout = ImageLayout.None;
            btnGuardarEmpleado.FlatAppearance.BorderSize = 0;
            btnGuardarEmpleado.Font = new Font("Itim", 11.9999981F);
            btnGuardarEmpleado.ForeColor = SystemColors.ButtonFace;
            btnGuardarEmpleado.ImageAlign = ContentAlignment.BottomLeft;
            btnGuardarEmpleado.Location = new Point(130, 243);
            btnGuardarEmpleado.Name = "btnGuardarEmpleado";
            btnGuardarEmpleado.Size = new Size(103, 37);
            btnGuardarEmpleado.TabIndex = 11;
            btnGuardarEmpleado.Text = "Guardar";
            btnGuardarEmpleado.UseVisualStyleBackColor = false;
            btnGuardarEmpleado.Click += btnGuardarEmpleado_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(87, 99, 110);
            label3.Location = new Point(26, 103);
            label3.Name = "label3";
            label3.Size = new Size(109, 18);
            label3.TabIndex = 32;
            label3.Text = "Rol del Usuario:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(rdbActivo);
            groupBox1.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.DimGray;
            groupBox1.Location = new Point(152, 131);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(308, 51);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            // 
            // rdbActivo
            // 
            rdbActivo.AutoSize = true;
            rdbActivo.Location = new Point(8, 21);
            rdbActivo.Name = "rdbActivo";
            rdbActivo.Size = new Size(70, 23);
            rdbActivo.TabIndex = 8;
            rdbActivo.TabStop = true;
            rdbActivo.Text = "Activo";
            rdbActivo.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(87, 99, 110);
            label6.Location = new Point(17, 60);
            label6.Name = "label6";
            label6.Size = new Size(118, 18);
            label6.TabIndex = 27;
            label6.Text = "Correo enlazado:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(87, 99, 110);
            label5.Location = new Point(78, 147);
            label5.Name = "label5";
            label5.Size = new Size(57, 18);
            label5.TabIndex = 26;
            label5.Text = "Estado:";
            // 
            // txtCorreo
            // 
            txtCorreo.BackColor = Color.White;
            txtCorreo.BorderStyle = BorderStyle.None;
            txtCorreo.Enabled = false;
            txtCorreo.Font = new Font("Itim", 13F);
            txtCorreo.Location = new Point(152, 60);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.ReadOnly = true;
            txtCorreo.Size = new Size(308, 21);
            txtCorreo.TabIndex = 5;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(189, 215, 238);
            panel2.Controls.Add(cmbRol);
            panel2.Controls.Add(btnVolver);
            panel2.Controls.Add(btnGuardarEmpleado);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(groupBox1);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(txtCorreo);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(497, 302);
            panel2.TabIndex = 16;
            // 
            // cmbRol
            // 
            cmbRol.FormattingEnabled = true;
            cmbRol.Location = new Point(152, 102);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(308, 23);
            cmbRol.TabIndex = 34;
            // 
            // frmAgregarEditarUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(497, 302);
            Controls.Add(panBarraControl);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAgregarEditarUsuario";
            Text = "Usuario";
            Load += frmAgregarEditarUsuario_Load;
            panBarraControl.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnVolver;
        private RadioButton radioButton2;
        private TextBox txtNombre;
        private Button btnGuardarEmpleado;
        private Label label3;
        private GroupBox groupBox1;
        private RadioButton rdbActivo;
        private Label label6;
        private Label label5;
        private TextBox txtCorreo;
        private Label label1;
        public Label lblNombreModulo;
        private Panel panel2;
        private ComboBox cmbRol;
    }
}