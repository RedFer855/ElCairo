namespace ModernMenuUI.InterfacesUsuarios.Inventario
{
    partial class frmAgregarProducto
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
            txtDni = new TextBox();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            txtNombre = new TextBox();
            btnVover = new Button();
            btnGuardarEmpleado = new Button();
            label6 = new Label();
            label5 = new Label();
            txtCorreo = new TextBox();
            txtTelefono = new TextBox();
            label9 = new Label();
            label8 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtApellido = new TextBox();
            lblNombreModulo = new Label();
            label3 = new Label();
            txtDireccion = new TextBox();
            groupBox1 = new GroupBox();
            label4 = new Label();
            panel2 = new Panel();
            panBarraControl = new Panel();
            groupBox1.SuspendLayout();
            panBarraControl.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // txtDni
            // 
            txtDni.BackColor = Color.White;
            txtDni.BorderStyle = BorderStyle.None;
            txtDni.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDni.Location = new Point(142, 49);
            txtDni.Name = "txtDni";
            txtDni.PlaceholderText = "(Ingrese Dni sin espacios ni guiones)";
            txtDni.Size = new Size(315, 24);
            txtDni.TabIndex = 0;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(124, 20);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(100, 28);
            radioButton2.TabIndex = 9;
            radioButton2.TabStop = true;
            radioButton2.Text = "Inactivo";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(8, 21);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(84, 28);
            radioButton1.TabIndex = 8;
            radioButton1.TabStop = true;
            radioButton1.Text = "Activo";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.White;
            txtNombre.BorderStyle = BorderStyle.None;
            txtNombre.Font = new Font("Itim", 13F);
            txtNombre.Location = new Point(142, 88);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(315, 26);
            txtNombre.TabIndex = 1;
            // 
            // btnVover
            // 
            btnVover.BackColor = Color.FromArgb(148, 168, 187);
            btnVover.BackgroundImageLayout = ImageLayout.None;
            btnVover.FlatAppearance.BorderSize = 0;
            btnVover.Font = new Font("Itim", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnVover.ForeColor = SystemColors.ButtonFace;
            btnVover.ImageAlign = ContentAlignment.BottomLeft;
            btnVover.Location = new Point(79, 372);
            btnVover.Name = "btnVover";
            btnVover.Size = new Size(157, 37);
            btnVover.TabIndex = 10;
            btnVover.Text = "Salir";
            btnVover.UseVisualStyleBackColor = false;
            // 
            // btnGuardarEmpleado
            // 
            btnGuardarEmpleado.BackColor = Color.FromArgb(149, 195, 172);
            btnGuardarEmpleado.BackgroundImageLayout = ImageLayout.None;
            btnGuardarEmpleado.FlatAppearance.BorderSize = 0;
            btnGuardarEmpleado.Font = new Font("Itim", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardarEmpleado.ForeColor = SystemColors.ButtonFace;
            btnGuardarEmpleado.ImageAlign = ContentAlignment.BottomLeft;
            btnGuardarEmpleado.Location = new Point(242, 372);
            btnGuardarEmpleado.Name = "btnGuardarEmpleado";
            btnGuardarEmpleado.Size = new Size(153, 37);
            btnGuardarEmpleado.TabIndex = 11;
            btnGuardarEmpleado.Text = "Guardar";
            btnGuardarEmpleado.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(87, 99, 110);
            label6.Location = new Point(40, 191);
            label6.Name = "label6";
            label6.Size = new Size(71, 23);
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
            label5.Size = new Size(70, 23);
            label5.TabIndex = 26;
            label5.Text = "Estado:";
            // 
            // txtCorreo
            // 
            txtCorreo.BackColor = Color.White;
            txtCorreo.BorderStyle = BorderStyle.None;
            txtCorreo.Font = new Font("Itim", 13F);
            txtCorreo.Location = new Point(142, 189);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(315, 26);
            txtCorreo.TabIndex = 5;
            // 
            // txtTelefono
            // 
            txtTelefono.BackColor = Color.White;
            txtTelefono.BorderStyle = BorderStyle.None;
            txtTelefono.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTelefono.Location = new Point(142, 156);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.PlaceholderText = "(Codigo de Barra del Producto)";
            txtTelefono.Size = new Size(315, 24);
            txtTelefono.TabIndex = 4;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Comic Sans MS", 12F);
            label9.ForeColor = Color.FromArgb(87, 99, 110);
            label9.Location = new Point(36, 15);
            label9.Name = "label9";
            label9.Size = new Size(193, 28);
            label9.TabIndex = 20;
            label9.Text = "Datos del Producto:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(87, 99, 110);
            label8.Location = new Point(40, 51);
            label8.Name = "label8";
            label8.Size = new Size(81, 23);
            label8.TabIndex = 19;
            label8.Text = "Nombre:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(87, 99, 110);
            label2.Location = new Point(40, 124);
            label2.Name = "label2";
            label2.Size = new Size(95, 23);
            label2.TabIndex = 16;
            label2.Text = "Categoria:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(87, 99, 110);
            label1.Location = new Point(38, 91);
            label1.Name = "label1";
            label1.Size = new Size(66, 23);
            label1.TabIndex = 15;
            label1.Text = "Marca:";
            // 
            // txtApellido
            // 
            txtApellido.BackColor = Color.White;
            txtApellido.BorderStyle = BorderStyle.None;
            txtApellido.Font = new Font("Itim", 13F);
            txtApellido.Location = new Point(142, 121);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(315, 26);
            txtApellido.TabIndex = 3;
            // 
            // lblNombreModulo
            // 
            lblNombreModulo.Dock = DockStyle.Fill;
            lblNombreModulo.Font = new Font("Itim", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombreModulo.ForeColor = Color.White;
            lblNombreModulo.Location = new Point(0, 0);
            lblNombreModulo.Name = "lblNombreModulo";
            lblNombreModulo.Size = new Size(488, 41);
            lblNombreModulo.TabIndex = 13;
            lblNombreModulo.Text = "EDITAR PRODUCTO";
            lblNombreModulo.TextAlign = ContentAlignment.MiddleCenter;
            lblNombreModulo.Click += lblNombreModulo_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(87, 99, 110);
            label3.Location = new Point(40, 229);
            label3.Name = "label3";
            label3.Size = new Size(94, 23);
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
            // panBarraControl
            // 
            panBarraControl.BackColor = Color.FromArgb(148, 168, 187);
            panBarraControl.Controls.Add(lblNombreModulo);
            panBarraControl.Dock = DockStyle.Top;
            panBarraControl.ForeColor = Color.Coral;
            panBarraControl.Location = new Point(0, 0);
            panBarraControl.Name = "panBarraControl";
            panBarraControl.Size = new Size(488, 41);
            panBarraControl.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(87, 99, 110);
            label4.Location = new Point(40, 158);
            label4.Name = "label4";
            label4.Size = new Size(72, 23);
            label4.TabIndex = 25;
            label4.Text = "Codigo:";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(189, 215, 238);
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
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtApellido);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(488, 450);
            panel2.TabIndex = 16;
            // 
            // frmAgregarProducto
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(488, 450);
            Controls.Add(panBarraControl);
            Controls.Add(panel2);
            Name = "frmAgregarProducto";
            Text = "frmAgregarProducto";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panBarraControl.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtDni;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private TextBox txtNombre;
        private Button btnVover;
        private Button btnGuardarEmpleado;
        private Label label6;
        private Label label5;
        private TextBox txtCorreo;
        private TextBox txtTelefono;
        private Label label9;
        private Label label8;
        private Label label2;
        private Label label1;
        private TextBox txtApellido;
        public Label lblNombreModulo;
        private Label label3;
        private TextBox txtDireccion;
        private GroupBox groupBox1;
        private Label label4;
        private Panel panel2;
    }
}