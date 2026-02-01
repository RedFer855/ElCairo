namespace ModernMenuUI
{
    partial class frmAgregarEditarEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarEditarEmpleado));
            lblNombreModulo = new Label();
            txtApellido = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label8 = new Label();
            txtTelefono = new TextBox();
            txtCorreo = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            gbxEstado = new GroupBox();
            rbInactivo = new RadioButton();
            rbActivo = new RadioButton();
            txtDireccion = new TextBox();
            label3 = new Label();
            btnGuardarEmpleado = new Button();
            btnVolver = new Button();
            txtDni = new TextBox();
            txtNombre = new TextBox();
            btnModificarEmpleado = new Button();
            label7 = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panBarraControl = new Panel();
            panBarraControl.SuspendLayout();
            gbxEstado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
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
            panBarraControl.Size = new Size(744, 41);
            panBarraControl.TabIndex = 13;
            // 
            // lblNombreModulo
            // 
            lblNombreModulo.Dock = DockStyle.Fill;
            lblNombreModulo.Font = new Font("Itim", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombreModulo.ForeColor = Color.White;
            lblNombreModulo.Location = new Point(0, 0);
            lblNombreModulo.Name = "lblNombreModulo";
            lblNombreModulo.Size = new Size(744, 41);
            lblNombreModulo.TabIndex = 14;
            lblNombreModulo.Text = "EDITAR EMPLEADO";
            lblNombreModulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtApellido
            // 
            txtApellido.BackColor = Color.White;
            txtApellido.BorderStyle = BorderStyle.None;
            txtApellido.Font = new Font("Itim", 13F);
            txtApellido.Location = new Point(121, 99);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(315, 26);
            txtApellido.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(87, 99, 110);
            label1.Location = new Point(17, 69);
            label1.Name = "label1";
            label1.Size = new Size(81, 23);
            label1.TabIndex = 13;
            label1.Text = "Nombre:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(87, 99, 110);
            label2.Location = new Point(19, 102);
            label2.Name = "label2";
            label2.Size = new Size(81, 23);
            label2.TabIndex = 14;
            label2.Text = "Apellido:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(87, 99, 110);
            label8.Location = new Point(19, 29);
            label8.Name = "label8";
            label8.Size = new Size(48, 23);
            label8.TabIndex = 12;
            label8.Text = "DNI:";
            // 
            // txtTelefono
            // 
            txtTelefono.BackColor = Color.White;
            txtTelefono.BorderStyle = BorderStyle.None;
            txtTelefono.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTelefono.Location = new Point(121, 134);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.PlaceholderText = "(Número de Teléfono sin espacios guiones)";
            txtTelefono.Size = new Size(315, 24);
            txtTelefono.TabIndex = 4;
            // 
            // txtCorreo
            // 
            txtCorreo.BackColor = Color.White;
            txtCorreo.BorderStyle = BorderStyle.None;
            txtCorreo.Font = new Font("Itim", 13F);
            txtCorreo.Location = new Point(121, 167);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(214, 26);
            txtCorreo.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(87, 99, 110);
            label4.Location = new Point(19, 136);
            label4.Name = "label4";
            label4.Size = new Size(85, 23);
            label4.TabIndex = 15;
            label4.Text = "Teléfono:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(87, 99, 110);
            label5.Location = new Point(19, 304);
            label5.Name = "label5";
            label5.Size = new Size(70, 23);
            label5.TabIndex = 18;
            label5.Text = "Estado:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(87, 99, 110);
            label6.Location = new Point(19, 169);
            label6.Name = "label6";
            label6.Size = new Size(71, 23);
            label6.TabIndex = 16;
            label6.Text = "Correo:";
            // 
            // gbxEstado
            // 
            gbxEstado.Controls.Add(rbInactivo);
            gbxEstado.Controls.Add(rbActivo);
            gbxEstado.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbxEstado.ForeColor = Color.DimGray;
            gbxEstado.Location = new Point(121, 282);
            gbxEstado.Name = "gbxEstado";
            gbxEstado.Size = new Size(214, 51);
            gbxEstado.TabIndex = 7;
            gbxEstado.TabStop = false;
            // 
            // rbInactivo
            // 
            rbInactivo.AutoSize = true;
            rbInactivo.Location = new Point(124, 20);
            rbInactivo.Name = "rbInactivo";
            rbInactivo.Size = new Size(100, 28);
            rbInactivo.TabIndex = 8;
            rbInactivo.Text = "Inactivo";
            rbInactivo.UseVisualStyleBackColor = true;
            // 
            // rbActivo
            // 
            rbActivo.AutoSize = true;
            rbActivo.Checked = true;
            rbActivo.Location = new Point(8, 21);
            rbActivo.Name = "rbActivo";
            rbActivo.Size = new Size(84, 28);
            rbActivo.TabIndex = 7;
            rbActivo.TabStop = true;
            rbActivo.Text = "Activo";
            rbActivo.UseVisualStyleBackColor = true;
            // 
            // txtDireccion
            // 
            txtDireccion.BackColor = Color.White;
            txtDireccion.BorderStyle = BorderStyle.None;
            txtDireccion.Font = new Font("Itim", 13F);
            txtDireccion.Location = new Point(121, 204);
            txtDireccion.Multiline = true;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(315, 72);
            txtDireccion.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(87, 99, 110);
            label3.Location = new Point(19, 207);
            label3.Name = "label3";
            label3.Size = new Size(94, 23);
            label3.TabIndex = 17;
            label3.Text = "Dirección:";
            // 
            // btnGuardarEmpleado
            // 
            btnGuardarEmpleado.BackColor = Color.FromArgb(149, 195, 172);
            btnGuardarEmpleado.BackgroundImageLayout = ImageLayout.None;
            btnGuardarEmpleado.FlatAppearance.BorderSize = 0;
            btnGuardarEmpleado.Font = new Font("Itim", 11.9999981F);
            btnGuardarEmpleado.ForeColor = SystemColors.ButtonFace;
            btnGuardarEmpleado.ImageAlign = ContentAlignment.BottomLeft;
            btnGuardarEmpleado.Location = new Point(3, 3);
            btnGuardarEmpleado.Name = "btnGuardarEmpleado";
            btnGuardarEmpleado.Size = new Size(89, 37);
            btnGuardarEmpleado.TabIndex = 9;
            btnGuardarEmpleado.Text = "Guardar";
            btnGuardarEmpleado.UseVisualStyleBackColor = false;
            btnGuardarEmpleado.Visible = false;
            btnGuardarEmpleado.Click += btnGuardarEmpleado_Click;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.FromArgb(148, 168, 187);
            btnVolver.BackgroundImageLayout = ImageLayout.None;
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.Font = new Font("Itim", 11.9999981F);
            btnVolver.ForeColor = SystemColors.ButtonFace;
            btnVolver.ImageAlign = ContentAlignment.BottomLeft;
            btnVolver.Location = new Point(193, 3);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(95, 37);
            btnVolver.TabIndex = 0;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVover_Click;
            // 
            // txtDni
            // 
            txtDni.BackColor = Color.White;
            txtDni.BorderStyle = BorderStyle.None;
            txtDni.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDni.Location = new Point(121, 27);
            txtDni.Name = "txtDni";
            txtDni.PlaceholderText = "(Ingrese DniEmpleado sin espacios ni guiones)";
            txtDni.Size = new Size(315, 24);
            txtDni.TabIndex = 1;
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.White;
            txtNombre.BorderStyle = BorderStyle.None;
            txtNombre.Font = new Font("Itim", 13F);
            txtNombre.Location = new Point(121, 66);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(315, 26);
            txtNombre.TabIndex = 2;
            // 
            // btnModificarEmpleado
            // 
            btnModificarEmpleado.BackColor = Color.FromArgb(0, 95, 184);
            btnModificarEmpleado.BackgroundImageLayout = ImageLayout.None;
            btnModificarEmpleado.FlatAppearance.BorderSize = 0;
            btnModificarEmpleado.Font = new Font("Itim", 11.9999981F);
            btnModificarEmpleado.ForeColor = SystemColors.ButtonFace;
            btnModificarEmpleado.ImageAlign = ContentAlignment.BottomLeft;
            btnModificarEmpleado.Location = new Point(98, 3);
            btnModificarEmpleado.Name = "btnModificarEmpleado";
            btnModificarEmpleado.Size = new Size(89, 37);
            btnModificarEmpleado.TabIndex = 19;
            btnModificarEmpleado.Text = "Editar";
            btnModificarEmpleado.UseVisualStyleBackColor = false;
            btnModificarEmpleado.Click += btnModificar_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Itim", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(87, 99, 110);
            label7.Location = new Point(341, 172);
            label7.Name = "label7";
            label7.Size = new Size(115, 18);
            label7.TabIndex = 20;
            label7.Text = "(No Modificable)";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(459, 29);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(258, 247);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 21;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(189, 215, 238);
            panel2.Controls.Add(flowLayoutPanel1);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(txtNombre);
            panel2.Controls.Add(txtDni);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(txtDireccion);
            panel2.Controls.Add(gbxEstado);
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
            panel2.Size = new Size(744, 421);
            panel2.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnGuardarEmpleado);
            flowLayoutPanel1.Controls.Add(btnModificarEmpleado);
            flowLayoutPanel1.Controls.Add(btnVolver);
            flowLayoutPanel1.Location = new Point(8, 372);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(327, 46);
            flowLayoutPanel1.TabIndex = 22;
            // 
            // frmAgregarEditarEmpleado
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(744, 462);
            Controls.Add(panel2);
            Controls.Add(panBarraControl);
            DoubleBuffered = true;
            Font = new Font("Itim", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAgregarEditarEmpleado";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Datos de Empleados";
            Load += frmAgregarEmpleado_Load;
            panBarraControl.ResumeLayout(false);
            gbxEstado.ResumeLayout(false);
            gbxEstado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Label label9;
        public Label lblNombreModulo;
        private Panel panel1;
        private TextBox txtApellido;
        private Label label1;
        private Label label2;
        private Label label8;
        private TextBox txtTelefono;
        private TextBox txtCorreo;
        private Label label4;
        private Label label5;
        private Label label6;
        private GroupBox gbxEstado;
        private RadioButton rbInactivo;
        private RadioButton rbActivo;
        private TextBox txtDireccion;
        private Label label3;
        private Button btnGuardarEmpleado;
        private Button btnVolver;
        private TextBox txtDni;
        private TextBox txtNombre;
        private Button btnUsuario;
        private Button btnModificarEmpleado;
        private Label label7;
        private PictureBox pictureBox1;
        private Panel panel2;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}