namespace ModernMenuUI.InterfacesUsuarios.Compras
{
    partial class frmAgregarEditarProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarEditarProveedor));
            lblNombreModulo = new Label();
            pictureBox1 = new PictureBox();
            btnEditarProveedor = new Button();
            txtTelefono = new TextBox();
            txtNombreProveedor = new TextBox();
            btnVolver = new Button();
            btnGuardarProveedor = new Button();
            rbInactivo = new RadioButton();
            rbActivo = new RadioButton();
            gbxEstado = new GroupBox();
            label5 = new Label();
            label8 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtDireccion = new TextBox();
            panel2 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panBarraControl = new Panel();
            panBarraControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            gbxEstado.SuspendLayout();
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
            panBarraControl.Size = new Size(688, 38);
            panBarraControl.TabIndex = 15;
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
            // btnEditarProveedor
            // 
            btnEditarProveedor.BackColor = Color.FromArgb(113, 96, 232);
            btnEditarProveedor.BackgroundImageLayout = ImageLayout.None;
            btnEditarProveedor.FlatAppearance.BorderSize = 0;
            btnEditarProveedor.Font = new Font("Itim", 11.9999981F);
            btnEditarProveedor.ForeColor = SystemColors.ButtonFace;
            btnEditarProveedor.ImageAlign = ContentAlignment.BottomLeft;
            btnEditarProveedor.Location = new Point(98, 3);
            btnEditarProveedor.Name = "btnEditarProveedor";
            btnEditarProveedor.Size = new Size(89, 35);
            btnEditarProveedor.TabIndex = 19;
            btnEditarProveedor.Text = "Editar";
            btnEditarProveedor.UseVisualStyleBackColor = false;
            btnEditarProveedor.Click += btnEditarProveedor_Click;
            // 
            // txtTelefono
            // 
            txtTelefono.BackColor = Color.White;
            txtTelefono.BorderStyle = BorderStyle.None;
            txtTelefono.Font = new Font("Itim", 13F);
            txtTelefono.Location = new Point(190, 104);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(289, 26);
            txtTelefono.TabIndex = 2;
            // 
            // txtNombreProveedor
            // 
            txtNombreProveedor.BackColor = Color.White;
            txtNombreProveedor.BorderStyle = BorderStyle.None;
            txtNombreProveedor.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombreProveedor.Location = new Point(190, 67);
            txtNombreProveedor.Name = "txtNombreProveedor";
            txtNombreProveedor.PlaceholderText = "(Empresa)";
            txtNombreProveedor.Size = new Size(289, 24);
            txtNombreProveedor.TabIndex = 1;
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
            btnVolver.Size = new Size(71, 35);
            btnVolver.TabIndex = 0;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnGuardarProveedor
            // 
            btnGuardarProveedor.BackColor = Color.FromArgb(149, 195, 172);
            btnGuardarProveedor.BackgroundImageLayout = ImageLayout.None;
            btnGuardarProveedor.FlatAppearance.BorderSize = 0;
            btnGuardarProveedor.Font = new Font("Itim", 11.9999981F);
            btnGuardarProveedor.ForeColor = SystemColors.ButtonFace;
            btnGuardarProveedor.ImageAlign = ContentAlignment.BottomLeft;
            btnGuardarProveedor.Location = new Point(3, 3);
            btnGuardarProveedor.Name = "btnGuardarProveedor";
            btnGuardarProveedor.Size = new Size(89, 35);
            btnGuardarProveedor.TabIndex = 9;
            btnGuardarProveedor.Text = "Guardar";
            btnGuardarProveedor.UseVisualStyleBackColor = false;
            btnGuardarProveedor.Click += btnGuardarProveedor_Click;
            // 
            // rbInactivo
            // 
            rbInactivo.AutoSize = true;
            rbInactivo.Location = new Point(124, 19);
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
            rbActivo.Checked = true;
            rbActivo.Location = new Point(8, 20);
            rbActivo.Name = "rbActivo";
            rbActivo.Size = new Size(84, 28);
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
            gbxEstado.Location = new Point(190, 228);
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
            label5.Location = new Point(127, 247);
            label5.Name = "label5";
            label5.Size = new Size(70, 23);
            label5.TabIndex = 18;
            label5.Text = "Estado:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(87, 99, 110);
            label8.Location = new Point(0, 68);
            label8.Name = "label8";
            label8.Size = new Size(197, 23);
            label8.TabIndex = 12;
            label8.Text = "Nombre del Proveedor:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(87, 99, 110);
            label2.Location = new Point(90, 137);
            label2.Name = "label2";
            label2.Size = new Size(94, 23);
            label2.TabIndex = 14;
            label2.Text = "Dirección:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(87, 99, 110);
            label1.Location = new Point(99, 104);
            label1.Name = "label1";
            label1.Size = new Size(85, 23);
            label1.TabIndex = 13;
            label1.Text = "Telefono:";
            // 
            // txtDireccion
            // 
            txtDireccion.BackColor = Color.White;
            txtDireccion.BorderStyle = BorderStyle.None;
            txtDireccion.Font = new Font("Itim", 13F);
            txtDireccion.Location = new Point(190, 134);
            txtDireccion.Multiline = true;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.ScrollBars = ScrollBars.Both;
            txtDireccion.Size = new Size(289, 88);
            txtDireccion.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(189, 215, 238);
            panel2.Controls.Add(flowLayoutPanel1);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(txtTelefono);
            panel2.Controls.Add(txtNombreProveedor);
            panel2.Controls.Add(gbxEstado);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtDireccion);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(688, 351);
            panel2.TabIndex = 14;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnGuardarProveedor);
            flowLayoutPanel1.Controls.Add(btnEditarProveedor);
            flowLayoutPanel1.Controls.Add(btnVolver);
            flowLayoutPanel1.Location = new Point(12, 292);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(274, 47);
            flowLayoutPanel1.TabIndex = 22;
            // 
            // frmAgregarEditarProveedor
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(688, 351);
            Controls.Add(panBarraControl);
            Controls.Add(panel2);
            Font = new Font("Itim", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAgregarEditarProveedor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Proveedor";
            Load += frmAgregarEditarProveedor_Load;
            panBarraControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            gbxEstado.ResumeLayout(false);
            gbxEstado.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnEditarProveedor;
        private TextBox txtTelefono;
        private TextBox txtNombreProveedor;
        private Button btnVolver;
        private Button btnGuardarProveedor;
        private RadioButton rbInactivo;
        private RadioButton rbActivo;
        private GroupBox gbxEstado;
        private Label label5;
        private Label label8;
        private Label label2;
        private Label label1;
        private TextBox txtDireccion;
        public Label lblNombreModulo;
        private Panel panel2;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}