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
            lblNombreModulo = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            txtCorreo = new TextBox();
            txtTelefono = new TextBox();
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
            panel2 = new Panel();
            btnUsuario = new Button();
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
            panBarraControl.Dock = DockStyle.Top;
            panBarraControl.ForeColor = Color.Coral;
            panBarraControl.Location = new Point(0, 0);
            panBarraControl.Name = "panBarraControl";
            panBarraControl.Size = new Size(508, 41);
            panBarraControl.TabIndex = 13;
            // 
            // lblNombreModulo
            // 
            lblNombreModulo.Dock = DockStyle.Fill;
            lblNombreModulo.Font = new Font("Itim", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombreModulo.ForeColor = Color.White;
            lblNombreModulo.Location = new Point(0, 0);
            lblNombreModulo.Name = "lblNombreModulo";
            lblNombreModulo.Size = new Size(508, 41);
            lblNombreModulo.TabIndex = 13;
            lblNombreModulo.Text = "EDITAR EMPLEADO";
            lblNombreModulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(87, 99, 110);
            label6.Location = new Point(40, 191);
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
            label5.Location = new Point(40, 326);
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
            label4.Location = new Point(40, 158);
            label4.Name = "label4";
            label4.Size = new Size(68, 18);
            label4.TabIndex = 25;
            label4.Text = "Teléfono:";
            // 
            // txtCorreo
            // 
            txtCorreo.BackColor = Color.White;
            txtCorreo.BorderStyle = BorderStyle.None;
            txtCorreo.Font = new Font("Itim", 13F);
            txtCorreo.Location = new Point(142, 189);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(315, 21);
            txtCorreo.TabIndex = 5;
            // 
            // txtTelefono
            // 
            txtTelefono.BackColor = Color.White;
            txtTelefono.BorderStyle = BorderStyle.None;
            txtTelefono.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTelefono.Location = new Point(142, 156);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.PlaceholderText = "(Número de Teléfono sin espacios guiones)";
            txtTelefono.Size = new Size(315, 20);
            txtTelefono.TabIndex = 4;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(87, 99, 110);
            label8.Location = new Point(40, 51);
            label8.Name = "label8";
            label8.Size = new Size(38, 18);
            label8.TabIndex = 19;
            label8.Text = "DNI:";
            // 
            // txtDni
            // 
            txtDni.BackColor = Color.White;
            txtDni.BorderStyle = BorderStyle.None;
            txtDni.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDni.Location = new Point(142, 49);
            txtDni.Name = "txtDni";
            txtDni.PlaceholderText = "(Ingrese Dni sin espacios ni guiones)";
            txtDni.Size = new Size(315, 20);
            txtDni.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(87, 99, 110);
            label2.Location = new Point(40, 124);
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
            label1.Location = new Point(38, 91);
            label1.Name = "label1";
            label1.Size = new Size(64, 18);
            label1.TabIndex = 15;
            label1.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.White;
            txtNombre.BorderStyle = BorderStyle.None;
            txtNombre.Font = new Font("Itim", 13F);
            txtNombre.Location = new Point(142, 88);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(315, 21);
            txtNombre.TabIndex = 1;
            // 
            // txtApellido
            // 
            txtApellido.BackColor = Color.White;
            txtApellido.BorderStyle = BorderStyle.None;
            txtApellido.Font = new Font("Itim", 13F);
            txtApellido.Location = new Point(142, 121);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(315, 21);
            txtApellido.TabIndex = 3;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(8, 21);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(70, 23);
            radioButton1.TabIndex = 8;
            radioButton1.TabStop = true;
            radioButton1.Text = "Activo";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(87, 99, 110);
            label3.Location = new Point(40, 229);
            label3.Name = "label3";
            label3.Size = new Size(73, 18);
            label3.TabIndex = 32;
            label3.Text = "Dirección:";
            // 
            // txtDireccion
            // 
            txtDireccion.BackColor = Color.White;
            txtDireccion.BorderStyle = BorderStyle.None;
            txtDireccion.Font = new Font("Itim", 13F);
            txtDireccion.Location = new Point(142, 226);
            txtDireccion.Multiline = true;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(315, 72);
            txtDireccion.TabIndex = 6;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.DimGray;
            groupBox1.Location = new Point(142, 304);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(315, 51);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
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
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(189, 215, 238);
            panel2.Controls.Add(btnUsuario);
            panel2.Controls.Add(txtNombre);
            panel2.Controls.Add(txtDni);
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
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtApellido);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 41);
            panel2.Name = "panel2";
            panel2.Size = new Size(508, 434);
            panel2.TabIndex = 14;
            // 
            // btnUsuario
            // 
            btnUsuario.BackColor = Color.FromArgb(13, 90, 169);
            btnUsuario.BackgroundImageLayout = ImageLayout.None;
            btnUsuario.FlatAppearance.BorderSize = 0;
            btnUsuario.Font = new Font("Itim", 11.9999981F);
            btnUsuario.ForeColor = SystemColors.ButtonFace;
            btnUsuario.ImageAlign = ContentAlignment.BottomLeft;
            btnUsuario.Location = new Point(150, 376);
            btnUsuario.Name = "btnUsuario";
            btnUsuario.Size = new Size(198, 37);
            btnUsuario.TabIndex = 33;
            btnUsuario.Text = "Usuario del Empleado";
            btnUsuario.UseVisualStyleBackColor = false;
            btnUsuario.Click += btnUsuario_Click;
            // 
            // btnVover
            // 
            btnVover.BackColor = Color.FromArgb(148, 168, 187);
            btnVover.BackgroundImageLayout = ImageLayout.None;
            btnVover.FlatAppearance.BorderSize = 0;
            btnVover.Font = new Font("Itim", 11.9999981F);
            btnVover.ForeColor = SystemColors.ButtonFace;
            btnVover.ImageAlign = ContentAlignment.BottomLeft;
            btnVover.Location = new Point(362, 376);
            btnVover.Name = "btnVover";
            btnVover.Size = new Size(95, 37);
            btnVover.TabIndex = 10;
            btnVover.Text = "Salir";
            btnVover.UseVisualStyleBackColor = false;
            btnVover.Click += btnVover_Click;
            // 
            // btnGuardarEmpleado
            // 
            btnGuardarEmpleado.BackColor = Color.FromArgb(149, 195, 172);
            btnGuardarEmpleado.BackgroundImageLayout = ImageLayout.None;
            btnGuardarEmpleado.FlatAppearance.BorderSize = 0;
            btnGuardarEmpleado.Font = new Font("Itim", 11.9999981F);
            btnGuardarEmpleado.ForeColor = SystemColors.ButtonFace;
            btnGuardarEmpleado.ImageAlign = ContentAlignment.BottomLeft;
            btnGuardarEmpleado.Location = new Point(36, 376);
            btnGuardarEmpleado.Name = "btnGuardarEmpleado";
            btnGuardarEmpleado.Size = new Size(103, 37);
            btnGuardarEmpleado.TabIndex = 11;
            btnGuardarEmpleado.Text = "Guardar";
            btnGuardarEmpleado.UseVisualStyleBackColor = false;
            btnGuardarEmpleado.Click += btnGuardarEmpleado_Click;
            // 
            // frmAgregarEmpleado
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(508, 475);
            Controls.Add(panel2);
            Controls.Add(panBarraControl);
            DoubleBuffered = true;
            Font = new Font("Itim", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAgregarEmpleado";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Datos de Empleados";
            Load += frmAgregarEmpleado_Load;
            panBarraControl.ResumeLayout(false);
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
        private Panel panel2;
        public Label lblNombreModulo;
        private Button btnVover;
        private Button btnGuardarEmpleado;
        private Button btnUsuario;
    }
}