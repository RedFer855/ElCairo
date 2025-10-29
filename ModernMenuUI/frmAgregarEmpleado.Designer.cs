namespace ModernMenuUI
{
    partial class frmAgregarEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarEmpleado));
            lblNombreModulo = new Label();
            btnCerrar = new Button();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            txtCorreo = new TextBox();
            txtTelefono = new TextBox();
            label9 = new Label();
            label8 = new Label();
            txtDni = new TextBox();
            label2 = new Label();
            label1 = new Label();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            radioButton1 = new RadioButton();
            label3 = new Label();
            txtDireccion = new TextBox();
            groupBox1 = new GroupBox();
            radioButton2 = new RadioButton();
            btnAgregar = new Button();
            panel2 = new Panel();
            btnVover = new Button();
            btnGuardarEmpleado = new Button();
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
            panBarraControl.Controls.Add(btnCerrar);
            panBarraControl.Dock = DockStyle.Top;
            panBarraControl.ForeColor = Color.Coral;
            panBarraControl.Location = new Point(0, 0);
            panBarraControl.Name = "panBarraControl";
            panBarraControl.Size = new Size(508, 62);
            panBarraControl.TabIndex = 13;
            // 
            // lblNombreModulo
            // 
            lblNombreModulo.AutoSize = true;
            lblNombreModulo.Font = new Font("Itim", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombreModulo.ForeColor = Color.White;
            lblNombreModulo.Location = new Point(142, 16);
            lblNombreModulo.Name = "lblNombreModulo";
            lblNombreModulo.Size = new Size(215, 29);
            lblNombreModulo.TabIndex = 8;
            lblNombreModulo.Text = "EDITAR EMPLEADO";
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.FromArgb(148, 168, 187);
            btnCerrar.Dock = DockStyle.Right;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCerrar.ForeColor = Color.FromArgb(167, 191, 211);
            btnCerrar.Image = (Image)resources.GetObject("btnCerrar.Image");
            btnCerrar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCerrar.Location = new Point(443, 0);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Padding = new Padding(11, 0, 0, 0);
            btnCerrar.Size = new Size(65, 62);
            btnCerrar.TabIndex = 3;
            btnCerrar.TextAlign = ContentAlignment.MiddleLeft;
            btnCerrar.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(87, 99, 110);
            label6.Location = new Point(14, 199);
            label6.Name = "label6";
            label6.Size = new Size(57, 18);
            label6.TabIndex = 27;
            label6.Text = "Correo:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(87, 99, 110);
            label5.Location = new Point(14, 284);
            label5.Name = "label5";
            label5.Size = new Size(57, 18);
            label5.TabIndex = 26;
            label5.Text = "Estado:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(87, 99, 110);
            label4.Location = new Point(14, 163);
            label4.Name = "label4";
            label4.Size = new Size(68, 18);
            label4.TabIndex = 25;
            label4.Text = "Teléfono:";
            // 
            // txtCorreo
            // 
            txtCorreo.BackColor = Color.White;
            txtCorreo.BorderStyle = BorderStyle.None;
            txtCorreo.Enabled = false;
            txtCorreo.Font = new Font("Itim", 13F);
            txtCorreo.Location = new Point(116, 196);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.ReadOnly = true;
            txtCorreo.Size = new Size(315, 21);
            txtCorreo.TabIndex = 23;
            // 
            // txtTelefono
            // 
            txtTelefono.BackColor = Color.White;
            txtTelefono.BorderStyle = BorderStyle.None;
            txtTelefono.Enabled = false;
            txtTelefono.Font = new Font("Itim", 13F);
            txtTelefono.Location = new Point(116, 160);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.ReadOnly = true;
            txtTelefono.Size = new Size(315, 21);
            txtTelefono.TabIndex = 22;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Comic Sans MS", 12F);
            label9.ForeColor = Color.FromArgb(87, 99, 110);
            label9.Location = new Point(10, 9);
            label9.Name = "label9";
            label9.Size = new Size(153, 23);
            label9.TabIndex = 20;
            label9.Text = "Datos del Producto:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(87, 99, 110);
            label8.Location = new Point(12, 49);
            label8.Name = "label8";
            label8.Size = new Size(38, 18);
            label8.TabIndex = 19;
            label8.Text = "DNI:";
            // 
            // txtDni
            // 
            txtDni.BackColor = Color.White;
            txtDni.BorderStyle = BorderStyle.None;
            txtDni.Enabled = false;
            txtDni.Font = new Font("Itim", 13F);
            txtDni.Location = new Point(116, 46);
            txtDni.Name = "txtDni";
            txtDni.ReadOnly = true;
            txtDni.Size = new Size(315, 21);
            txtDni.TabIndex = 18;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(87, 99, 110);
            label2.Location = new Point(13, 126);
            label2.Name = "label2";
            label2.Size = new Size(65, 18);
            label2.TabIndex = 16;
            label2.Text = "Apellido:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(87, 99, 110);
            label1.Location = new Point(12, 90);
            label1.Name = "label1";
            label1.Size = new Size(64, 18);
            label1.TabIndex = 15;
            label1.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.White;
            txtNombre.BorderStyle = BorderStyle.None;
            txtNombre.Enabled = false;
            txtNombre.Font = new Font("Itim", 13F);
            txtNombre.Location = new Point(116, 87);
            txtNombre.Name = "txtNombre";
            txtNombre.ReadOnly = true;
            txtNombre.Size = new Size(315, 21);
            txtNombre.TabIndex = 13;
            // 
            // txtApellido
            // 
            txtApellido.BackColor = Color.White;
            txtApellido.BorderStyle = BorderStyle.None;
            txtApellido.Enabled = false;
            txtApellido.Font = new Font("Itim", 13F);
            txtApellido.Location = new Point(116, 123);
            txtApellido.Name = "txtApellido";
            txtApellido.ReadOnly = true;
            txtApellido.Size = new Size(315, 21);
            txtApellido.TabIndex = 12;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(8, 22);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(59, 19);
            radioButton1.TabIndex = 28;
            radioButton1.TabStop = true;
            radioButton1.Text = "Activo";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(87, 99, 110);
            label3.Location = new Point(14, 238);
            label3.Name = "label3";
            label3.Size = new Size(73, 18);
            label3.TabIndex = 32;
            label3.Text = "Dirección:";
            // 
            // txtDireccion
            // 
            txtDireccion.BackColor = Color.White;
            txtDireccion.BorderStyle = BorderStyle.None;
            txtDireccion.Enabled = false;
            txtDireccion.Font = new Font("Itim", 13F);
            txtDireccion.Location = new Point(116, 235);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.ReadOnly = true;
            txtDireccion.Size = new Size(315, 21);
            txtDireccion.TabIndex = 31;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Location = new Point(116, 262);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(315, 54);
            groupBox1.TabIndex = 30;
            groupBox1.TabStop = false;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(124, 21);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(67, 19);
            radioButton2.TabIndex = 29;
            radioButton2.TabStop = true;
            radioButton2.Text = "Inactivo";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(149, 195, 172);
            btnAgregar.BackgroundImage = (Image)resources.GetObject("btnAgregar.BackgroundImage");
            btnAgregar.BackgroundImageLayout = ImageLayout.None;
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.Font = new Font("Itim", 18.25F);
            btnAgregar.ForeColor = SystemColors.ButtonFace;
            btnAgregar.ImageAlign = ContentAlignment.BottomLeft;
            btnAgregar.Location = new Point(108, 383);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Padding = new Padding(40, 0, 0, 0);
            btnAgregar.Size = new Size(225, 46);
            btnAgregar.TabIndex = 10;
            btnAgregar.Text = "Guardar";
            btnAgregar.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(189, 215, 238);
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(btnVover);
            panel2.Controls.Add(btnGuardarEmpleado);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(txtDireccion);
            panel2.Controls.Add(groupBox1);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(txtCorreo);
            panel2.Controls.Add(txtTelefono);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(txtDni);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtNombre);
            panel2.Controls.Add(txtApellido);
            panel2.Controls.Add(btnAgregar);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 62);
            panel2.Name = "panel2";
            panel2.Size = new Size(508, 388);
            panel2.TabIndex = 14;
            // 
            // btnVover
            // 
            btnVover.BackColor = Color.FromArgb(148, 168, 187);
            btnVover.BackgroundImageLayout = ImageLayout.None;
            btnVover.FlatAppearance.BorderSize = 0;
            btnVover.Font = new Font("Itim", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnVover.ForeColor = SystemColors.ButtonFace;
            btnVover.ImageAlign = ContentAlignment.BottomLeft;
            btnVover.Location = new Point(77, 334);
            btnVover.Name = "btnVover";
            btnVover.Size = new Size(106, 40);
            btnVover.TabIndex = 34;
            btnVover.Text = "Salir";
            btnVover.UseVisualStyleBackColor = false;
            // 
            // btnGuardarEmpleado
            // 
            btnGuardarEmpleado.BackColor = Color.FromArgb(149, 195, 172);
            btnGuardarEmpleado.BackgroundImageLayout = ImageLayout.None;
            btnGuardarEmpleado.FlatAppearance.BorderSize = 0;
            btnGuardarEmpleado.Font = new Font("Itim", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardarEmpleado.ForeColor = SystemColors.ButtonFace;
            btnGuardarEmpleado.ImageAlign = ContentAlignment.BottomLeft;
            btnGuardarEmpleado.Location = new Point(230, 334);
            btnGuardarEmpleado.Name = "btnGuardarEmpleado";
            btnGuardarEmpleado.Size = new Size(153, 40);
            btnGuardarEmpleado.TabIndex = 33;
            btnGuardarEmpleado.Text = "Guardar";
            btnGuardarEmpleado.UseVisualStyleBackColor = false;
            btnGuardarEmpleado.Click += btnGuardarEmpleado_Click;
            // 
            // frmAgregarEmpleado
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(508, 450);
            Controls.Add(panel2);
            Controls.Add(panBarraControl);
            Name = "frmAgregarEmpleado";
            Text = "frmAgregarEmpleado";
            panBarraControl.ResumeLayout(false);
            panBarraControl.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox txtCorreo;
        private TextBox txtTelefono;
        private Label label9;
        private Label label8;
        private TextBox txtDni;
        private Label label2;
        private Label label1;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private RadioButton radioButton1;
        private Label label3;
        private TextBox txtDireccion;
        private GroupBox groupBox1;
        private RadioButton radioButton2;
        private Button btnAgregar;
        private Panel panel2;
        public Label lblNombreModulo;
        private Button btnCerrar;
        private Button btnVover;
        private Button btnGuardarEmpleado;
    }
}