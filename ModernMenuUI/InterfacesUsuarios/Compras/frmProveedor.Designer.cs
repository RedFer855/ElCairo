namespace ModernMenuUI.InterfacesUsuarios.Compras
{
    partial class frmProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProveedor));
            Panel panBarraControl;
            pictureBox1 = new PictureBox();
            btnModificarProveedor = new Button();
            txtNombre = new TextBox();
            txtDni = new TextBox();
            btnVolver = new Button();
            btnGuardarProveedor = new Button();
            rbInactivo = new RadioButton();
            rbActivo = new RadioButton();
            gbxEstado = new GroupBox();
            label5 = new Label();
            label8 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtApellido = new TextBox();
            lblNombreModulo = new Label();
            panel2 = new Panel();
            panBarraControl = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            gbxEstado.SuspendLayout();
            panBarraControl.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(494, 54);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(182, 179);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 21;
            pictureBox1.TabStop = false;
            // 
            // btnModificarProveedor
            // 
            btnModificarProveedor.BackColor = Color.FromArgb(149, 195, 172);
            btnModificarProveedor.BackgroundImageLayout = ImageLayout.None;
            btnModificarProveedor.FlatAppearance.BorderSize = 0;
            btnModificarProveedor.Font = new Font("Itim", 11.9999981F);
            btnModificarProveedor.ForeColor = SystemColors.ButtonFace;
            btnModificarProveedor.ImageAlign = ContentAlignment.BottomLeft;
            btnModificarProveedor.Location = new Point(127, 245);
            btnModificarProveedor.Name = "btnModificarProveedor";
            btnModificarProveedor.Size = new Size(89, 35);
            btnModificarProveedor.TabIndex = 19;
            btnModificarProveedor.Text = "Modificar";
            btnModificarProveedor.UseVisualStyleBackColor = false;
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.White;
            txtNombre.BorderStyle = BorderStyle.None;
            txtNombre.Font = new Font("Itim", 13F);
            txtNombre.Location = new Point(190, 104);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(289, 21);
            txtNombre.TabIndex = 2;
            // 
            // txtDni
            // 
            txtDni.BackColor = Color.White;
            txtDni.BorderStyle = BorderStyle.None;
            txtDni.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDni.Location = new Point(190, 67);
            txtDni.Name = "txtDni";
            txtDni.PlaceholderText = "(Empresa)";
            txtDni.Size = new Size(289, 20);
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
            btnVolver.Location = new Point(222, 245);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(95, 35);
            btnVolver.TabIndex = 0;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            // 
            // btnGuardarProveedor
            // 
            btnGuardarProveedor.BackColor = Color.FromArgb(149, 195, 172);
            btnGuardarProveedor.BackgroundImageLayout = ImageLayout.None;
            btnGuardarProveedor.FlatAppearance.BorderSize = 0;
            btnGuardarProveedor.Font = new Font("Itim", 11.9999981F);
            btnGuardarProveedor.ForeColor = SystemColors.ButtonFace;
            btnGuardarProveedor.ImageAlign = ContentAlignment.BottomLeft;
            btnGuardarProveedor.Location = new Point(29, 245);
            btnGuardarProveedor.Name = "btnGuardarProveedor";
            btnGuardarProveedor.Size = new Size(89, 35);
            btnGuardarProveedor.TabIndex = 9;
            btnGuardarProveedor.Text = "Guardar";
            btnGuardarProveedor.UseVisualStyleBackColor = false;
            btnGuardarProveedor.Visible = false;
            // 
            // rbInactivo
            // 
            rbInactivo.AutoSize = true;
            rbInactivo.Location = new Point(124, 19);
            rbInactivo.Name = "rbInactivo";
            rbInactivo.Size = new Size(82, 21);
            rbInactivo.TabIndex = 8;
            rbInactivo.TabStop = true;
            rbInactivo.Text = "Inactivo";
            rbInactivo.UseVisualStyleBackColor = true;
            // 
            // rbActivo
            // 
            rbActivo.AutoSize = true;
            rbActivo.Location = new Point(8, 20);
            rbActivo.Name = "rbActivo";
            rbActivo.Size = new Size(70, 21);
            rbActivo.TabIndex = 7;
            rbActivo.TabStop = true;
            rbActivo.Text = "Activo";
            rbActivo.UseVisualStyleBackColor = true;
            // 
            // gbxEstado
            // 
            gbxEstado.Controls.Add(rbInactivo);
            gbxEstado.Controls.Add(rbActivo);
            gbxEstado.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbxEstado.ForeColor = Color.DimGray;
            gbxEstado.Location = new Point(190, 176);
            gbxEstado.Name = "gbxEstado";
            gbxEstado.Size = new Size(214, 48);
            gbxEstado.TabIndex = 7;
            gbxEstado.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(87, 99, 110);
            label5.Location = new Point(127, 195);
            label5.Name = "label5";
            label5.Size = new Size(57, 18);
            label5.TabIndex = 18;
            label5.Text = "Estado:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(87, 99, 110);
            label8.Location = new Point(29, 69);
            label8.Name = "label8";
            label8.Size = new Size(155, 18);
            label8.TabIndex = 12;
            label8.Text = "Nombre del Proveedor:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(87, 99, 110);
            label2.Location = new Point(111, 137);
            label2.Name = "label2";
            label2.Size = new Size(73, 18);
            label2.TabIndex = 14;
            label2.Text = "Dirección:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(87, 99, 110);
            label1.Location = new Point(116, 104);
            label1.Name = "label1";
            label1.Size = new Size(68, 18);
            label1.TabIndex = 13;
            label1.Text = "Telefono:";
            // 
            // txtApellido
            // 
            txtApellido.BackColor = Color.White;
            txtApellido.BorderStyle = BorderStyle.None;
            txtApellido.Font = new Font("Itim", 13F);
            txtApellido.Location = new Point(190, 134);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(289, 21);
            txtApellido.TabIndex = 3;
            // 
            // lblNombreModulo
            // 
            lblNombreModulo.Dock = DockStyle.Fill;
            lblNombreModulo.Font = new Font("Itim", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombreModulo.ForeColor = Color.White;
            lblNombreModulo.Location = new Point(0, 0);
            lblNombreModulo.Name = "lblNombreModulo";
            lblNombreModulo.Size = new Size(688, 38);
            lblNombreModulo.TabIndex = 14;
            lblNombreModulo.Text = "EDITAR PROVEEDOR";
            lblNombreModulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panBarraControl
            // 
            panBarraControl.BackColor = Color.FromArgb(148, 168, 187);
            panBarraControl.Controls.Add(lblNombreModulo);
            panBarraControl.Dock = DockStyle.Top;
            panBarraControl.ForeColor = Color.Coral;
            panBarraControl.Location = new Point(0, 0);
            panBarraControl.Name = "panBarraControl";
            panBarraControl.Size = new Size(688, 38);
            panBarraControl.TabIndex = 15;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(189, 215, 238);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(btnModificarProveedor);
            panel2.Controls.Add(txtNombre);
            panel2.Controls.Add(txtDni);
            panel2.Controls.Add(btnVolver);
            panel2.Controls.Add(btnGuardarProveedor);
            panel2.Controls.Add(gbxEstado);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtApellido);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(688, 290);
            panel2.TabIndex = 14;
            // 
            // frmProveedor
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(688, 290);
            Controls.Add(panBarraControl);
            Controls.Add(panel2);
            Font = new Font("Itim", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmProveedor";
            Text = "Proveedor";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            gbxEstado.ResumeLayout(false);
            gbxEstado.PerformLayout();
            panBarraControl.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnModificarProveedor;
        private TextBox txtNombre;
        private TextBox txtDni;
        private Button btnVolver;
        private Button btnGuardarProveedor;
        private RadioButton rbInactivo;
        private RadioButton rbActivo;
        private GroupBox gbxEstado;
        private Label label5;
        private Label label8;
        private Label label2;
        private Label label1;
        private TextBox txtApellido;
        public Label lblNombreModulo;
        private Panel panel2;
    }
}