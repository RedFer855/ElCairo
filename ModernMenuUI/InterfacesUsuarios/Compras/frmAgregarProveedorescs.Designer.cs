namespace ModernMenuUI.InterfacesUsuarios.Compras
{
    partial class frmAgregarProveedorescs
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
            btnUsuario = new Button();
            txtNombre = new TextBox();
            panel2 = new Panel();
            btnVolver = new Button();
            btnGuardarEmpleado = new Button();
            label3 = new Label();
            txtDireccion = new TextBox();
            groupBox1 = new GroupBox();
            rbInactivo = new RadioButton();
            rbActivo = new RadioButton();
            label5 = new Label();
            label4 = new Label();
            txtTelefono = new TextBox();
            label1 = new Label();
            panBarraControl = new Panel();
            panBarraControl.SuspendLayout();
            panel2.SuspendLayout();
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
            panBarraControl.Size = new Size(470, 41);
            panBarraControl.TabIndex = 15;
            // 
            // lblNombreModulo
            // 
            lblNombreModulo.Dock = DockStyle.Fill;
            lblNombreModulo.Font = new Font("Itim", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombreModulo.ForeColor = Color.White;
            lblNombreModulo.Location = new Point(0, 0);
            lblNombreModulo.Name = "lblNombreModulo";
            lblNombreModulo.Size = new Size(470, 41);
            lblNombreModulo.TabIndex = 14;
            lblNombreModulo.Text = "AGREGAR PROVEEDOR";
            lblNombreModulo.TextAlign = ContentAlignment.MiddleCenter;
            lblNombreModulo.Click += lblNombreModulo_Click;
            // 
            // btnUsuario
            // 
            btnUsuario.BackColor = Color.FromArgb(148, 168, 187);
            btnUsuario.BackgroundImageLayout = ImageLayout.None;
            btnUsuario.FlatAppearance.BorderSize = 0;
            btnUsuario.Font = new Font("Itim", 11.9999981F);
            btnUsuario.ForeColor = SystemColors.ButtonFace;
            btnUsuario.ImageAlign = ContentAlignment.BottomLeft;
            btnUsuario.Location = new Point(169, 337);
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
            txtNombre.Location = new Point(121, 66);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(315, 26);
            txtNombre.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(189, 215, 238);
            panel2.Controls.Add(btnUsuario);
            panel2.Controls.Add(txtNombre);
            panel2.Controls.Add(btnVolver);
            panel2.Controls.Add(btnGuardarEmpleado);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(txtDireccion);
            panel2.Controls.Add(groupBox1);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(txtTelefono);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 41);
            panel2.Name = "panel2";
            panel2.Size = new Size(470, 409);
            panel2.TabIndex = 14;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.FromArgb(148, 168, 187);
            btnVolver.BackgroundImageLayout = ImageLayout.None;
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.Font = new Font("Itim", 11.9999981F);
            btnVolver.ForeColor = SystemColors.ButtonFace;
            btnVolver.ImageAlign = ContentAlignment.BottomLeft;
            btnVolver.Location = new Point(328, 339);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(95, 37);
            btnVolver.TabIndex = 0;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnGuardarEmpleado
            // 
            btnGuardarEmpleado.BackColor = Color.FromArgb(149, 195, 172);
            btnGuardarEmpleado.BackgroundImageLayout = ImageLayout.None;
            btnGuardarEmpleado.FlatAppearance.BorderSize = 0;
            btnGuardarEmpleado.Font = new Font("Itim", 11.9999981F);
            btnGuardarEmpleado.ForeColor = SystemColors.ButtonFace;
            btnGuardarEmpleado.ImageAlign = ContentAlignment.BottomLeft;
            btnGuardarEmpleado.Location = new Point(17, 339);
            btnGuardarEmpleado.Name = "btnGuardarEmpleado";
            btnGuardarEmpleado.Size = new Size(139, 37);
            btnGuardarEmpleado.TabIndex = 9;
            btnGuardarEmpleado.Text = "Guardar";
            btnGuardarEmpleado.UseVisualStyleBackColor = false;
            btnGuardarEmpleado.Click += btnGuardarEmpleado_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(87, 99, 110);
            label3.Location = new Point(17, 143);
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
            txtDireccion.Location = new Point(121, 143);
            txtDireccion.Multiline = true;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(315, 72);
            txtDireccion.TabIndex = 6;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbInactivo);
            groupBox1.Controls.Add(rbActivo);
            groupBox1.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.DimGray;
            groupBox1.Location = new Point(121, 230);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(237, 51);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            // 
            // rbInactivo
            // 
            rbInactivo.AutoSize = true;
            rbInactivo.Location = new Point(124, 20);
            rbInactivo.Name = "rbInactivo";
            rbInactivo.Size = new Size(100, 28);
            rbInactivo.TabIndex = 8;
            rbInactivo.TabStop = true;
            rbInactivo.Text = "Inactivo";
            rbInactivo.UseVisualStyleBackColor = true;
            // 
            // rbActivo
            // 
            rbActivo.AutoSize = true;
            rbActivo.Location = new Point(8, 21);
            rbActivo.Name = "rbActivo";
            rbActivo.Size = new Size(84, 28);
            rbActivo.TabIndex = 7;
            rbActivo.TabStop = true;
            rbActivo.Text = "Activo";
            rbActivo.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(87, 99, 110);
            label5.Location = new Point(32, 258);
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
            label4.Location = new Point(17, 107);
            label4.Name = "label4";
            label4.Size = new Size(85, 23);
            label4.TabIndex = 15;
            label4.Text = "Teléfono:";
            label4.Click += label4_Click;
            // 
            // txtTelefono
            // 
            txtTelefono.BackColor = Color.White;
            txtTelefono.BorderStyle = BorderStyle.None;
            txtTelefono.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTelefono.Location = new Point(121, 107);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.PlaceholderText = "(Número de Teléfono sin espacios guiones)";
            txtTelefono.Size = new Size(315, 24);
            txtTelefono.TabIndex = 4;
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
            // frmAgregarProveedorescs
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(470, 450);
            Controls.Add(panel2);
            Controls.Add(panBarraControl);
            Name = "frmAgregarProveedorescs";
            Text = "frmAgregarProveedorescs";
            Load += frmAgregarProveedorescs_Load;
            panBarraControl.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnUsuario;
        private TextBox txtNombre;
        private Panel panel2;
        private Button btnVolver;
        private Button btnGuardarEmpleado;
        private Label label3;
        private TextBox txtDireccion;
        private GroupBox groupBox1;
        private RadioButton rbInactivo;
        private RadioButton rbActivo;
        private Label label5;
        private Label label4;
        private TextBox txtTelefono;
        private Label label1;
        public Label lblNombreModulo;
    }
}