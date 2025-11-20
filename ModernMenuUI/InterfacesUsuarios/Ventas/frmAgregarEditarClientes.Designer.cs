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
            txtRtn = new TextBox();
            label9 = new Label();
            pictureBox1 = new PictureBox();
            label7 = new Label();
            btnModificar = new Button();
            btnUsuario = new Button();
            txtNombre = new TextBox();
            txtDni = new TextBox();
            btnVolver = new Button();
            btnGuardarCliente = new Button();
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
            panBarraControl.Name = "panBarraControl";
            panBarraControl.Size = new Size(693, 41);
            panBarraControl.TabIndex = 15;
            // 
            // lblNombreModulo
            // 
            lblNombreModulo.Dock = DockStyle.Fill;
            lblNombreModulo.Font = new Font("Itim", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombreModulo.ForeColor = Color.White;
            lblNombreModulo.Location = new Point(0, 0);
            lblNombreModulo.Name = "lblNombreModulo";
            lblNombreModulo.Size = new Size(693, 41);
            lblNombreModulo.TabIndex = 14;
            lblNombreModulo.Text = "EDITAR CLIENTE";
            lblNombreModulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(189, 215, 238);
            panel2.Controls.Add(txtRtn);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(btnModificar);
            panel2.Controls.Add(btnUsuario);
            panel2.Controls.Add(txtNombre);
            panel2.Controls.Add(txtDni);
            panel2.Controls.Add(btnVolver);
            panel2.Controls.Add(btnGuardarCliente);
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
            panel2.Location = new Point(0, 41);
            panel2.Name = "panel2";
            panel2.Size = new Size(693, 479);
            panel2.TabIndex = 14;
            // 
            // txtRtn
            // 
            txtRtn.BackColor = Color.White;
            txtRtn.BorderStyle = BorderStyle.None;
            txtRtn.Font = new Font("Itim", 13F);
            txtRtn.Location = new Point(121, 57);
            txtRtn.Name = "txtRtn";
            txtRtn.Size = new Size(315, 26);
            txtRtn.TabIndex = 2;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(87, 99, 110);
            label9.Location = new Point(19, 60);
            label9.Name = "label9";
            label9.Size = new Size(50, 23);
            label9.TabIndex = 23;
            label9.Text = "RTN:";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(459, 111);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(180, 155);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 21;
            pictureBox1.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Itim", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(87, 99, 110);
            label7.Location = new Point(339, 162);
            label7.Name = "label7";
            label7.Size = new Size(115, 18);
            label7.TabIndex = 20;
            label7.Text = "(No Modificable)";
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.FromArgb(149, 195, 172);
            btnModificar.BackgroundImageLayout = ImageLayout.None;
            btnModificar.FlatAppearance.BorderSize = 0;
            btnModificar.Font = new Font("Itim", 11.9999981F);
            btnModificar.ForeColor = SystemColors.ButtonFace;
            btnModificar.ImageAlign = ContentAlignment.BottomLeft;
            btnModificar.Location = new Point(228, 415);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(89, 37);
            btnModificar.TabIndex = 11;
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
            btnUsuario.Location = new Point(119, 415);
            btnUsuario.Name = "btnUsuario";
            btnUsuario.Size = new Size(101, 37);
            btnUsuario.TabIndex = 10;
            btnUsuario.Text = "Ver Usuario";
            btnUsuario.UseVisualStyleBackColor = false;
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.White;
            txtNombre.BorderStyle = BorderStyle.None;
            txtNombre.Font = new Font("Itim", 13F);
            txtNombre.Location = new Point(121, 89);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(315, 26);
            txtNombre.TabIndex = 3;
            // 
            // txtDni
            // 
            txtDni.BackColor = Color.White;
            txtDni.BorderStyle = BorderStyle.None;
            txtDni.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDni.Location = new Point(121, 27);
            txtDni.Name = "txtDni";
            txtDni.PlaceholderText = "(Ingrese Dni sin espacios ni guiones)";
            txtDni.Size = new Size(315, 24);
            txtDni.TabIndex = 1;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.FromArgb(148, 168, 187);
            btnVolver.BackgroundImageLayout = ImageLayout.None;
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.Font = new Font("Itim", 11.9999981F);
            btnVolver.ForeColor = SystemColors.ButtonFace;
            btnVolver.ImageAlign = ContentAlignment.BottomLeft;
            btnVolver.Location = new Point(323, 415);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(95, 37);
            btnVolver.TabIndex = 12;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            // 
            // btnGuardarCliente
            // 
            btnGuardarCliente.BackColor = Color.FromArgb(149, 195, 172);
            btnGuardarCliente.BackgroundImageLayout = ImageLayout.None;
            btnGuardarCliente.FlatAppearance.BorderSize = 0;
            btnGuardarCliente.Font = new Font("Itim", 11.9999981F);
            btnGuardarCliente.ForeColor = SystemColors.ButtonFace;
            btnGuardarCliente.ImageAlign = ContentAlignment.BottomLeft;
            btnGuardarCliente.Location = new Point(24, 415);
            btnGuardarCliente.Name = "btnGuardarCliente";
            btnGuardarCliente.Size = new Size(89, 37);
            btnGuardarCliente.TabIndex = 9;
            btnGuardarCliente.Text = "Guardar";
            btnGuardarCliente.UseVisualStyleBackColor = false;
            btnGuardarCliente.Visible = false;
            btnGuardarCliente.Click += btnGuardarCliente_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(87, 99, 110);
            label3.Location = new Point(17, 197);
            label3.Name = "label3";
            label3.Size = new Size(94, 23);
            label3.TabIndex = 17;
            label3.Text = "Dirección:";
            // 
            // txtDireccion
            // 
            txtDireccion.BackColor = Color.White;
            txtDireccion.BorderStyle = BorderStyle.None;
            txtDireccion.Font = new Font("Itim", 13F);
            txtDireccion.Location = new Point(119, 194);
            txtDireccion.Multiline = true;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(315, 72);
            txtDireccion.TabIndex = 6;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbdInactivo);
            groupBox1.Controls.Add(rbdActivo);
            groupBox1.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.DimGray;
            groupBox1.Location = new Point(119, 272);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(214, 51);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            // 
            // rbdInactivo
            // 
            rbdInactivo.AutoSize = true;
            rbdInactivo.Location = new Point(124, 20);
            rbdInactivo.Name = "rbdInactivo";
            rbdInactivo.Size = new Size(100, 28);
            rbdInactivo.TabIndex = 8;
            rbdInactivo.TabStop = true;
            rbdInactivo.Text = "Inactivo";
            rbdInactivo.UseVisualStyleBackColor = true;
            // 
            // rbdActivo
            // 
            rbdActivo.AutoSize = true;
            rbdActivo.Location = new Point(8, 21);
            rbdActivo.Name = "rbdActivo";
            rbdActivo.Size = new Size(84, 28);
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
            label6.Location = new Point(17, 159);
            label6.Name = "label6";
            label6.Size = new Size(71, 23);
            label6.TabIndex = 16;
            label6.Text = "Correo:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(87, 99, 110);
            label5.Location = new Point(19, 300);
            label5.Name = "label5";
            label5.Size = new Size(70, 23);
            label5.TabIndex = 18;
            label5.Text = "Estado:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(87, 99, 110);
            label4.Location = new Point(17, 126);
            label4.Name = "label4";
            label4.Size = new Size(85, 23);
            label4.TabIndex = 15;
            label4.Text = "Teléfono:";
            // 
            // txtCorreo
            // 
            txtCorreo.BackColor = Color.White;
            txtCorreo.BorderStyle = BorderStyle.None;
            txtCorreo.Font = new Font("Itim", 13F);
            txtCorreo.Location = new Point(119, 157);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.ReadOnly = true;
            txtCorreo.Size = new Size(214, 26);
            txtCorreo.TabIndex = 5;
            // 
            // txtTelefono
            // 
            txtTelefono.BackColor = Color.White;
            txtTelefono.BorderStyle = BorderStyle.None;
            txtTelefono.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTelefono.Location = new Point(119, 125);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.PlaceholderText = "(Número de Teléfono sin espacios guiones)";
            txtTelefono.Size = new Size(315, 24);
            txtTelefono.TabIndex = 4;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(87, 99, 110);
            label1.Location = new Point(17, 92);
            label1.Name = "label1";
            label1.Size = new Size(81, 23);
            label1.TabIndex = 13;
            label1.Text = "Nombre:";
            // 
            // frmAgregarEditarClientes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(693, 520);
            Controls.Add(panel2);
            Controls.Add(panBarraControl);
            Name = "frmAgregarEditarClientes";
            Text = "frmAgregarEditarClientes";
            Load += frmAgregarEditarClientes_Load;
            panBarraControl.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private PictureBox pictureBox1;
        private Label label7;
        private Button btnModificar;
        private Button btnUsuario;
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
    }
}