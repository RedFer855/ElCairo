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
            txtCorreo = new TextBox();
            btnGuardarEmpleado = new Button();
            label3 = new Label();
            groupBox1 = new GroupBox();
            radioButton1 = new RadioButton();
            label5 = new Label();
            label1 = new Label();
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
            panBarraControl.Margin = new Padding(3, 4, 3, 4);
            panBarraControl.Name = "panBarraControl";
            panBarraControl.Size = new Size(568, 55);
            panBarraControl.TabIndex = 15;
            // 
            // lblNombreModulo
            // 
            lblNombreModulo.Dock = DockStyle.Fill;
            lblNombreModulo.Font = new Font("Itim", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombreModulo.ForeColor = Color.White;
            lblNombreModulo.Location = new Point(0, 0);
            lblNombreModulo.Name = "lblNombreModulo";
            lblNombreModulo.Size = new Size(568, 55);
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
            btnVolver.Location = new Point(298, 324);
            btnVolver.Margin = new Padding(3, 4, 3, 4);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(109, 49);
            btnVolver.TabIndex = 10;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(142, 27);
            radioButton2.Margin = new Padding(3, 4, 3, 4);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(100, 28);
            radioButton2.TabIndex = 9;
            radioButton2.TabStop = true;
            radioButton2.Text = "Inactivo";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // txtCorreo
            // 
            txtCorreo.BackColor = Color.White;
            txtCorreo.BorderStyle = BorderStyle.None;
            txtCorreo.Font = new Font("Itim", 13F);
            txtCorreo.Location = new Point(174, 79);
            txtCorreo.Margin = new Padding(3, 4, 3, 4);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(352, 26);
            txtCorreo.TabIndex = 1;
            // 
            // btnGuardarEmpleado
            // 
            btnGuardarEmpleado.BackColor = Color.FromArgb(149, 195, 172);
            btnGuardarEmpleado.BackgroundImageLayout = ImageLayout.None;
            btnGuardarEmpleado.FlatAppearance.BorderSize = 0;
            btnGuardarEmpleado.Font = new Font("Itim", 11.9999981F);
            btnGuardarEmpleado.ForeColor = SystemColors.ButtonFace;
            btnGuardarEmpleado.ImageAlign = ContentAlignment.BottomLeft;
            btnGuardarEmpleado.Location = new Point(174, 324);
            btnGuardarEmpleado.Margin = new Padding(3, 4, 3, 4);
            btnGuardarEmpleado.Name = "btnGuardarEmpleado";
            btnGuardarEmpleado.Size = new Size(118, 49);
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
            label3.Location = new Point(38, 175);
            label3.Name = "label3";
            label3.Size = new Size(137, 23);
            label3.TabIndex = 32;
            label3.Text = "Rol del Usuario:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.DimGray;
            groupBox1.Location = new Point(174, 213);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(352, 68);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(9, 28);
            radioButton1.Margin = new Padding(3, 4, 3, 4);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(84, 28);
            radioButton1.TabIndex = 8;
            radioButton1.TabStop = true;
            radioButton1.Text = "Activo";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(87, 99, 110);
            label5.Location = new Point(97, 240);
            label5.Name = "label5";
            label5.Size = new Size(70, 23);
            label5.TabIndex = 26;
            label5.Text = "Estado:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(87, 99, 110);
            label1.Location = new Point(106, 83);
            label1.Name = "label1";
            label1.Size = new Size(54, 23);
            label1.TabIndex = 15;
            label1.Text = "Alias:";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(189, 215, 238);
            panel2.Controls.Add(cmbRol);
            panel2.Controls.Add(txtCorreo);
            panel2.Controls.Add(btnVolver);
            panel2.Controls.Add(btnGuardarEmpleado);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(groupBox1);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(568, 403);
            panel2.TabIndex = 16;
            // 
            // cmbRol
            // 
            cmbRol.FormattingEnabled = true;
            cmbRol.Location = new Point(174, 175);
            cmbRol.Margin = new Padding(3, 4, 3, 4);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(351, 28);
            cmbRol.TabIndex = 34;
            cmbRol.SelectedIndexChanged += cmbRol_SelectedIndexChanged;
            cmbRol.DataContextChanged += cmbRol_DataContextChanged;
            // 
            // frmAgregarEditarUsuario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(568, 403);
            Controls.Add(panBarraControl);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
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
        private Button btnGuardarEmpleado;
        private Label label3;
        private GroupBox groupBox1;
        private RadioButton radioButton1;
        private Label label5;
        private TextBox txtCorreo;
        private Label label1;
        public Label lblNombreModulo;
        private Panel panel2;
        private ComboBox cmbRol;
    }
}