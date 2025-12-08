namespace ModernMenuUI.InterfacesUsuarios.Ventas
{
    partial class frmAgregarEditarClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarEditarClientes));
            lblNombreModulo = new Label();
            panel2 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnGuardarCliente = new Button();
            btnModificar = new Button();
            btnVolver = new Button();
            txtRtn = new TextBox();
            label9 = new Label();
            pictureBox1 = new PictureBox();
            txtNombre = new TextBox();
            txtDni = new TextBox();
            label3 = new Label();
            txtDireccion = new TextBox();
            groupBox1 = new GroupBox();
            rbdInactivo = new RadioButton();
            rbdActivo = new RadioButton();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            txtCorreo = new TextBox();
            txtTelefono = new TextBox();
            label8 = new Label();
            label1 = new Label();
            panBarraControl = new Panel();
            panBarraControl.SuspendLayout();
            panel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panBarraControl
            // 
            panBarraControl.BackColor = Color.FromArgb(148, 168, 187);
            panBarraControl.Controls.Add(lblNombreModulo);
            panBarraControl.Dock = DockStyle.Top;
            panBarraControl.ForeColor = Color.Coral;
            panBarraControl.Location = new Point(0, 0);
            panBarraControl.Margin = new Padding(3, 2, 3, 2);
            panBarraControl.Name = "panBarraControl";
            panBarraControl.Size = new Size(679, 31);
            panBarraControl.TabIndex = 15;
            // 
            // lblNombreModulo
            // 
            lblNombreModulo.Dock = DockStyle.Fill;
            lblNombreModulo.Font = new Font("Itim", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombreModulo.ForeColor = Color.White;
            lblNombreModulo.Location = new Point(0, 0);
            lblNombreModulo.Name = "lblNombreModulo";
            lblNombreModulo.Size = new Size(679, 31);
            lblNombreModulo.TabIndex = 14;
            lblNombreModulo.Text = "EDITAR CLIENTE";
            lblNombreModulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(189, 215, 238);
            panel2.Controls.Add(flowLayoutPanel1);
            panel2.Controls.Add(txtRtn);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(txtNombre);
            panel2.Controls.Add(txtDni);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(txtDireccion);
            panel2.Controls.Add(groupBox1);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(txtCorreo);
            panel2.Controls.Add(txtTelefono);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 31);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(679, 362);
            panel2.TabIndex = 14;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnGuardarCliente);
            flowLayoutPanel1.Controls.Add(btnModificar);
            flowLayoutPanel1.Controls.Add(btnVolver);
            flowLayoutPanel1.Location = new Point(17, 302);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(443, 44);
            flowLayoutPanel1.TabIndex = 24;
            // 
            // btnGuardarCliente
            // 
            btnGuardarCliente.BackColor = Color.FromArgb(149, 195, 172);
            btnGuardarCliente.BackgroundImageLayout = ImageLayout.None;
            btnGuardarCliente.FlatAppearance.BorderSize = 0;
            btnGuardarCliente.Font = new Font("Itim", 12F);
            btnGuardarCliente.ForeColor = SystemColors.ButtonFace;
            btnGuardarCliente.ImageAlign = ContentAlignment.BottomLeft;
            btnGuardarCliente.Location = new Point(3, 2);
            btnGuardarCliente.Margin = new Padding(3, 2, 3, 2);
            btnGuardarCliente.Name = "btnGuardarCliente";
            btnGuardarCliente.Size = new Size(87, 39);
            btnGuardarCliente.TabIndex = 9;
            btnGuardarCliente.Text = "Guardar";
            btnGuardarCliente.UseVisualStyleBackColor = false;
            btnGuardarCliente.Visible = false;
            btnGuardarCliente.Click += btnGuardarCliente_Click;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.FromArgb(113, 96, 232);
            btnModificar.BackgroundImageLayout = ImageLayout.None;
            btnModificar.FlatAppearance.BorderSize = 0;
            btnModificar.Font = new Font("Itim", 11.9999981F);
            btnModificar.ForeColor = SystemColors.ButtonFace;
            btnModificar.ImageAlign = ContentAlignment.BottomLeft;
            btnModificar.Location = new Point(96, 2);
            btnModificar.Margin = new Padding(3, 2, 3, 2);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(89, 39);
            btnModificar.TabIndex = 11;
            btnModificar.Text = "Editar";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.FromArgb(148, 168, 187);
            btnVolver.BackgroundImageLayout = ImageLayout.None;
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.Font = new Font("Itim", 11.9999981F);
            btnVolver.ForeColor = SystemColors.ButtonFace;
            btnVolver.ImageAlign = ContentAlignment.BottomLeft;
            btnVolver.Location = new Point(191, 2);
            btnVolver.Margin = new Padding(3, 2, 3, 2);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(72, 39);
            btnVolver.TabIndex = 12;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            // 
            // txtRtn
            // 
            txtRtn.BackColor = Color.White;
            txtRtn.BorderStyle = BorderStyle.None;
            txtRtn.Font = new Font("Itim", 13F);
            txtRtn.Location = new Point(100, 50);
            txtRtn.Margin = new Padding(3, 2, 3, 2);
            txtRtn.Name = "txtRtn";
            txtRtn.Size = new Size(300, 21);
            txtRtn.TabIndex = 2;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(87, 99, 110);
            label9.Location = new Point(55, 52);
            label9.Name = "label9";
            label9.Size = new Size(39, 18);
            label9.TabIndex = 23;
            label9.Text = "RTN:";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(419, 20);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(250, 250);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 21;
            pictureBox1.TabStop = false;
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.White;
            txtNombre.BorderStyle = BorderStyle.None;
            txtNombre.Font = new Font("Itim", 13F);
            txtNombre.Location = new Point(100, 80);
            txtNombre.Margin = new Padding(3, 2, 3, 2);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(300, 21);
            txtNombre.TabIndex = 3;
            // 
            // txtDni
            // 
            txtDni.BackColor = Color.White;
            txtDni.BorderStyle = BorderStyle.None;
            txtDni.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDni.Location = new Point(100, 20);
            txtDni.Margin = new Padding(3, 2, 3, 2);
            txtDni.Name = "txtDni";
            txtDni.PlaceholderText = "(Ingrese el DNI sin espacios ni guiones)";
            txtDni.Size = new Size(300, 20);
            txtDni.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(87, 99, 110);
            label3.Location = new Point(20, 172);
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
            txtDireccion.Location = new Point(100, 170);
            txtDireccion.Margin = new Padding(3, 2, 3, 2);
            txtDireccion.Multiline = true;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(300, 54);
            txtDireccion.TabIndex = 6;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbdInactivo);
            groupBox1.Controls.Add(rbdActivo);
            groupBox1.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.DimGray;
            groupBox1.Location = new Point(100, 228);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(187, 55);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            // 
            // rbdInactivo
            // 
            rbdInactivo.AutoSize = true;
            rbdInactivo.Location = new Point(108, 15);
            rbdInactivo.Margin = new Padding(3, 2, 3, 2);
            rbdInactivo.Name = "rbdInactivo";
            rbdInactivo.Size = new Size(82, 23);
            rbdInactivo.TabIndex = 8;
            rbdInactivo.Text = "Inactivo";
            rbdInactivo.UseVisualStyleBackColor = true;
            // 
            // rbdActivo
            // 
            rbdActivo.AutoSize = true;
            rbdActivo.Checked = true;
            rbdActivo.Location = new Point(7, 16);
            rbdActivo.Margin = new Padding(3, 2, 3, 2);
            rbdActivo.Name = "rbdActivo";
            rbdActivo.Size = new Size(70, 23);
            rbdActivo.TabIndex = 7;
            rbdActivo.TabStop = true;
            rbdActivo.Text = "Activo";
            rbdActivo.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(87, 99, 110);
            label6.Location = new Point(37, 142);
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
            label5.Location = new Point(30, 243);
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
            label4.Location = new Point(26, 111);
            label4.Name = "label4";
            label4.Size = new Size(68, 18);
            label4.TabIndex = 15;
            label4.Text = "Teléfono:";
            // 
            // txtCorreo
            // 
            txtCorreo.BackColor = Color.White;
            txtCorreo.BorderStyle = BorderStyle.None;
            txtCorreo.Font = new Font("Itim", 13F);
            txtCorreo.Location = new Point(100, 140);
            txtCorreo.Margin = new Padding(3, 2, 3, 2);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.ReadOnly = true;
            txtCorreo.Size = new Size(300, 21);
            txtCorreo.TabIndex = 5;
            // 
            // txtTelefono
            // 
            txtTelefono.BackColor = Color.White;
            txtTelefono.BorderStyle = BorderStyle.None;
            txtTelefono.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTelefono.Location = new Point(100, 110);
            txtTelefono.Margin = new Padding(3, 2, 3, 2);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.PlaceholderText = "(Número de Teléfono sin espacios guiones)";
            txtTelefono.Size = new Size(300, 20);
            txtTelefono.TabIndex = 4;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(87, 99, 110);
            label8.Location = new Point(56, 20);
            label8.Name = "label8";
            label8.Size = new Size(38, 18);
            label8.TabIndex = 12;
            label8.Text = "DNI:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(87, 99, 110);
            label1.Location = new Point(30, 82);
            label1.Name = "label1";
            label1.Size = new Size(64, 18);
            label1.TabIndex = 13;
            label1.Text = "Nombre:";
            // 
            // frmAgregarEditarClientes
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(679, 393);
            Controls.Add(panel2);
            Controls.Add(panBarraControl);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmAgregarEditarClientes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Clientes";
            Load += frmAgregarEditarClientes_Load;
            panBarraControl.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private PictureBox pictureBox1;
        private Button btnModificar;
        private TextBox txtNombre;
        private TextBox txtDni;
        private Button btnVolver;
        private Button btnGuardarCliente;
        private Label label3;
        private TextBox txtDireccion;
        private GroupBox groupBox1;
        private RadioButton rbdInactivo;
        private RadioButton rbdActivo;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox txtCorreo;
        private TextBox txtTelefono;
        private Label label8;
        private Label label1;
        public Label lblNombreModulo;
        private TextBox txtRtn;
        private Label label9;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}