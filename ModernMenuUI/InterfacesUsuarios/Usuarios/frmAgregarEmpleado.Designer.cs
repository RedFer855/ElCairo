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
            btnModificar = new Button();
            btnUsuario = new Button();
            btnVolver = new Button();
            btnGuardarEmpleado = new Button();
            label7 = new Label();
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
            panBarraControl.Size = new Size(460, 41);
            panBarraControl.TabIndex = 13;
            // 
            // lblNombreModulo
            // 
            lblNombreModulo.Dock = DockStyle.Fill;
            lblNombreModulo.Font = new Font("Itim", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombreModulo.ForeColor = Color.White;
            lblNombreModulo.Location = new Point(0, 0);
            lblNombreModulo.Name = "lblNombreModulo";
            lblNombreModulo.Size = new Size(460, 41);
            lblNombreModulo.TabIndex = 14;
            lblNombreModulo.Text = "EDITAR EMPLEADO";
            lblNombreModulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(87, 99, 110);
            label6.Location = new Point(19, 169);
            label6.Name = "label6";
            label6.Size = new Size(57, 18);
            label6.TabIndex = 16;
            label6.Text = "Correo:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(87, 99, 110);
            label5.Location = new Point(19, 304);
            label5.Name = "label5";
            label5.Size = new Size(57, 18);
            label5.TabIndex = 18;
            label5.Text = "Estado:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(87, 99, 110);
            label4.Location = new Point(19, 136);
            label4.Name = "label4";
            label4.Size = new Size(68, 18);
            label4.TabIndex = 15;
            label4.Text = "Teléfono:";
            // 
            // txtCorreo
            // 
            txtCorreo.BackColor = Color.White;
            txtCorreo.BorderStyle = BorderStyle.None;
            txtCorreo.Enabled = false;
            txtCorreo.Font = new Font("Itim", 13F);
            txtCorreo.Location = new Point(121, 167);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.ReadOnly = true;
            txtCorreo.Size = new Size(214, 21);
            txtCorreo.TabIndex = 5;
            // 
            // txtTelefono
            // 
            txtTelefono.BackColor = Color.White;
            txtTelefono.BorderStyle = BorderStyle.None;
            txtTelefono.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTelefono.Location = new Point(121, 134);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.PlaceholderText = "(Número de Teléfono sin espacios guiones)";
            txtTelefono.ReadOnly = true;
            txtTelefono.Size = new Size(315, 20);
            txtTelefono.TabIndex = 4;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(87, 99, 110);
            label8.Location = new Point(19, 29);
            label8.Name = "label8";
            label8.Size = new Size(38, 18);
            label8.TabIndex = 12;
            label8.Text = "DNI:";
            // 
            // txtDni
            // 
            txtDni.BackColor = Color.White;
            txtDni.BorderStyle = BorderStyle.None;
            txtDni.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDni.Location = new Point(121, 27);
            txtDni.Name = "txtDni";
            txtDni.PlaceholderText = "(Ingrese Dni sin espacios ni guiones)";
            txtDni.ReadOnly = true;
            txtDni.Size = new Size(315, 20);
            txtDni.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(87, 99, 110);
            label2.Location = new Point(19, 102);
            label2.Name = "label2";
            label2.Size = new Size(65, 18);
            label2.TabIndex = 14;
            label2.Text = "Apellido:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(87, 99, 110);
            label1.Location = new Point(17, 69);
            label1.Name = "label1";
            label1.Size = new Size(64, 18);
            label1.TabIndex = 13;
            label1.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.White;
            txtNombre.BorderStyle = BorderStyle.None;
            txtNombre.Font = new Font("Itim", 13F);
            txtNombre.Location = new Point(121, 66);
            txtNombre.Name = "txtNombre";
            txtNombre.ReadOnly = true;
            txtNombre.Size = new Size(315, 21);
            txtNombre.TabIndex = 2;
            // 
            // txtApellido
            // 
            txtApellido.BackColor = Color.White;
            txtApellido.BorderStyle = BorderStyle.None;
            txtApellido.Font = new Font("Itim", 13F);
            txtApellido.Location = new Point(121, 99);
            txtApellido.Name = "txtApellido";
            txtApellido.ReadOnly = true;
            txtApellido.Size = new Size(315, 21);
            txtApellido.TabIndex = 3;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(8, 21);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(70, 23);
            radioButton1.TabIndex = 7;
            radioButton1.TabStop = true;
            radioButton1.Text = "Activo";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(87, 99, 110);
            label3.Location = new Point(19, 207);
            label3.Name = "label3";
            label3.Size = new Size(73, 18);
            label3.TabIndex = 17;
            label3.Text = "Dirección:";
            // 
            // txtDireccion
            // 
            txtDireccion.BackColor = Color.White;
            txtDireccion.BorderStyle = BorderStyle.None;
            txtDireccion.Font = new Font("Itim", 13F);
            txtDireccion.Location = new Point(121, 204);
            txtDireccion.Multiline = true;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.ReadOnly = true;
            txtDireccion.Size = new Size(315, 72);
            txtDireccion.TabIndex = 6;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.DimGray;
            groupBox1.Location = new Point(121, 282);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(214, 51);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(124, 20);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(82, 23);
            radioButton2.TabIndex = 8;
            radioButton2.TabStop = true;
            radioButton2.Text = "Inactivo";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(189, 215, 238);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(btnModificar);
            panel2.Controls.Add(btnUsuario);
            panel2.Controls.Add(txtNombre);
            panel2.Controls.Add(txtDni);
            panel2.Controls.Add(btnVolver);
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
            panel2.Size = new Size(460, 434);
            panel2.TabIndex = 0;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.FromArgb(149, 195, 172);
            btnModificar.BackgroundImageLayout = ImageLayout.None;
            btnModificar.FlatAppearance.BorderSize = 0;
            btnModificar.Font = new Font("Itim", 11.9999981F);
            btnModificar.ForeColor = SystemColors.ButtonFace;
            btnModificar.ImageAlign = ContentAlignment.BottomLeft;
            btnModificar.Location = new Point(26, 376);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(89, 37);
            btnModificar.TabIndex = 19;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnUsuario
            // 
            btnUsuario.BackColor = Color.FromArgb(148, 168, 187);
            btnUsuario.BackgroundImageLayout = ImageLayout.None;
            btnUsuario.FlatAppearance.BorderSize = 0;
            btnUsuario.Font = new Font("Itim", 11.9999981F);
            btnUsuario.ForeColor = SystemColors.ButtonFace;
            btnUsuario.ImageAlign = ContentAlignment.BottomLeft;
            btnUsuario.Location = new Point(121, 376);
            btnUsuario.Name = "btnUsuario";
            btnUsuario.Size = new Size(101, 37);
            btnUsuario.TabIndex = 10;
            btnUsuario.Text = "Ver Usuario";
            btnUsuario.UseVisualStyleBackColor = false;
            btnUsuario.Click += btnUsuario_Click;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.FromArgb(148, 168, 187);
            btnVolver.BackgroundImageLayout = ImageLayout.None;
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.Font = new Font("Itim", 11.9999981F);
            btnVolver.ForeColor = SystemColors.ButtonFace;
            btnVolver.ImageAlign = ContentAlignment.BottomLeft;
            btnVolver.Location = new Point(341, 376);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(95, 37);
            btnVolver.TabIndex = 0;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVover_Click;
            // 
            // btnGuardarEmpleado
            // 
            btnGuardarEmpleado.BackColor = Color.FromArgb(149, 195, 172);
            btnGuardarEmpleado.BackgroundImageLayout = ImageLayout.None;
            btnGuardarEmpleado.FlatAppearance.BorderSize = 0;
            btnGuardarEmpleado.Font = new Font("Itim", 11.9999981F);
            btnGuardarEmpleado.ForeColor = SystemColors.ButtonFace;
            btnGuardarEmpleado.ImageAlign = ContentAlignment.BottomLeft;
            btnGuardarEmpleado.Location = new Point(24, 376);
            btnGuardarEmpleado.Name = "btnGuardarEmpleado";
            btnGuardarEmpleado.Size = new Size(89, 37);
            btnGuardarEmpleado.TabIndex = 9;
            btnGuardarEmpleado.Text = "Guardar";
            btnGuardarEmpleado.UseVisualStyleBackColor = false;
            btnGuardarEmpleado.Visible = false;
            btnGuardarEmpleado.Click += btnGuardarEmpleado_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Itim", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(87, 99, 110);
            label7.Location = new Point(341, 172);
            label7.Name = "label7";
            label7.Size = new Size(92, 14);
            label7.TabIndex = 20;
            label7.Text = "(No Modificable)";
            // 
            // frmAgregarEmpleado
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(460, 475);
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
        private Button btnVolver;
        private Button btnGuardarEmpleado;
        private Button btnUsuario;
        private Button btnModificar;
        private Panel panel1;
        private Label label7;
    }
}