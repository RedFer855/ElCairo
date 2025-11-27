namespace ModernMenuUI.InterfacesUsuarios.Inventario
{
    partial class frmAgregarEditarCategoria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarEditarCategoria));
            lblNombreModulo = new Label();
            lblEstado = new Label();
            rbdActivo = new RadioButton();
            flpAjustarBotones = new FlowLayoutPanel();
            btnGuardarCategoria = new Button();
            btnVolver = new Button();
            btnModificarCategoria = new Button();
            rbdInactivo = new RadioButton();
            txtDescripcionCategoria = new TextBox();
            pbxImagenMarca = new PictureBox();
            txtNombreCategoria = new TextBox();
            gbxEstado = new GroupBox();
            label8 = new Label();
            label2 = new Label();
            panel2 = new Panel();
            panBarraControl = new Panel();
            panBarraControl.SuspendLayout();
            flpAjustarBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxImagenMarca).BeginInit();
            gbxEstado.SuspendLayout();
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
            panBarraControl.Margin = new Padding(4);
            panBarraControl.Name = "panBarraControl";
            panBarraControl.Size = new Size(846, 46);
            panBarraControl.TabIndex = 19;
            // 
            // lblNombreModulo
            // 
            lblNombreModulo.Dock = DockStyle.Fill;
            lblNombreModulo.Font = new Font("Itim", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombreModulo.ForeColor = Color.White;
            lblNombreModulo.Location = new Point(0, 0);
            lblNombreModulo.Margin = new Padding(4, 0, 4, 0);
            lblNombreModulo.Name = "lblNombreModulo";
            lblNombreModulo.Size = new Size(846, 46);
            lblNombreModulo.TabIndex = 14;
            lblNombreModulo.Text = "EDITAR CATEGORÍA";
            lblNombreModulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEstado.ForeColor = Color.FromArgb(87, 99, 110);
            lblEstado.Location = new Point(74, 312);
            lblEstado.Margin = new Padding(4, 0, 4, 0);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(70, 23);
            lblEstado.TabIndex = 18;
            lblEstado.Text = "Estado:";
            // 
            // rbdActivo
            // 
            rbdActivo.AutoSize = true;
            rbdActivo.Location = new Point(8, 19);
            rbdActivo.Margin = new Padding(4);
            rbdActivo.Name = "rbdActivo";
            rbdActivo.Size = new Size(84, 28);
            rbdActivo.TabIndex = 7;
            rbdActivo.TabStop = true;
            rbdActivo.Text = "Activo";
            rbdActivo.UseVisualStyleBackColor = true;
            // 
            // flpAjustarBotones
            // 
            flpAjustarBotones.Controls.Add(btnGuardarCategoria);
            flpAjustarBotones.Controls.Add(btnVolver);
            flpAjustarBotones.Controls.Add(btnModificarCategoria);
            flpAjustarBotones.Location = new Point(15, 354);
            flpAjustarBotones.Margin = new Padding(4);
            flpAjustarBotones.Name = "flpAjustarBotones";
            flpAjustarBotones.Size = new Size(369, 46);
            flpAjustarBotones.TabIndex = 25;
            // 
            // btnGuardarCategoria
            // 
            btnGuardarCategoria.BackColor = Color.FromArgb(149, 195, 172);
            btnGuardarCategoria.BackgroundImageLayout = ImageLayout.None;
            btnGuardarCategoria.FlatAppearance.BorderSize = 0;
            btnGuardarCategoria.Font = new Font("Itim", 11.9999981F);
            btnGuardarCategoria.ForeColor = SystemColors.ButtonFace;
            btnGuardarCategoria.ImageAlign = ContentAlignment.BottomLeft;
            btnGuardarCategoria.Location = new Point(4, 4);
            btnGuardarCategoria.Margin = new Padding(4);
            btnGuardarCategoria.Name = "btnGuardarCategoria";
            btnGuardarCategoria.Size = new Size(111, 41);
            btnGuardarCategoria.TabIndex = 9;
            btnGuardarCategoria.Text = "Guardar";
            btnGuardarCategoria.UseVisualStyleBackColor = false;
            btnGuardarCategoria.Visible = false;
            btnGuardarCategoria.Click += btnGuardarCategoria_Click;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.FromArgb(148, 168, 187);
            btnVolver.BackgroundImageLayout = ImageLayout.None;
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.Font = new Font("Itim", 11.9999981F);
            btnVolver.ForeColor = SystemColors.ButtonFace;
            btnVolver.ImageAlign = ContentAlignment.BottomLeft;
            btnVolver.Location = new Point(123, 4);
            btnVolver.Margin = new Padding(4);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(119, 41);
            btnVolver.TabIndex = 0;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnModificarCategoria
            // 
            btnModificarCategoria.BackColor = Color.FromArgb(74, 148, 225);
            btnModificarCategoria.BackgroundImageLayout = ImageLayout.None;
            btnModificarCategoria.FlatAppearance.BorderSize = 0;
            btnModificarCategoria.Font = new Font("Itim", 11.9999981F);
            btnModificarCategoria.ForeColor = SystemColors.ButtonFace;
            btnModificarCategoria.ImageAlign = ContentAlignment.BottomLeft;
            btnModificarCategoria.Location = new Point(250, 4);
            btnModificarCategoria.Margin = new Padding(4);
            btnModificarCategoria.Name = "btnModificarCategoria";
            btnModificarCategoria.Size = new Size(90, 41);
            btnModificarCategoria.TabIndex = 19;
            btnModificarCategoria.Text = "Editar";
            btnModificarCategoria.UseVisualStyleBackColor = false;
            btnModificarCategoria.Click += btnModificarCategoria_Click;
            // 
            // rbdInactivo
            // 
            rbdInactivo.AutoSize = true;
            rbdInactivo.Location = new Point(149, 19);
            rbdInactivo.Margin = new Padding(4);
            rbdInactivo.Name = "rbdInactivo";
            rbdInactivo.Size = new Size(100, 28);
            rbdInactivo.TabIndex = 8;
            rbdInactivo.TabStop = true;
            rbdInactivo.Text = "Inactivo";
            rbdInactivo.UseVisualStyleBackColor = true;
            // 
            // txtDescripcionCategoria
            // 
            txtDescripcionCategoria.BackColor = Color.White;
            txtDescripcionCategoria.BorderStyle = BorderStyle.None;
            txtDescripcionCategoria.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDescripcionCategoria.Location = new Point(152, 108);
            txtDescripcionCategoria.Margin = new Padding(4);
            txtDescripcionCategoria.Multiline = true;
            txtDescripcionCategoria.Name = "txtDescripcionCategoria";
            txtDescripcionCategoria.PlaceholderText = "(Ingrese una Descripción)";
            txtDescripcionCategoria.Size = new Size(382, 175);
            txtDescripcionCategoria.TabIndex = 24;
            // 
            // pbxImagenMarca
            // 
            pbxImagenMarca.Image = (Image)resources.GetObject("pbxImagenMarca.Image");
            pbxImagenMarca.Location = new Point(565, 75);
            pbxImagenMarca.Margin = new Padding(4);
            pbxImagenMarca.Name = "pbxImagenMarca";
            pbxImagenMarca.Size = new Size(240, 208);
            pbxImagenMarca.SizeMode = PictureBoxSizeMode.Zoom;
            pbxImagenMarca.TabIndex = 21;
            pbxImagenMarca.TabStop = false;
            // 
            // txtNombreCategoria
            // 
            txtNombreCategoria.BackColor = Color.White;
            txtNombreCategoria.BorderStyle = BorderStyle.None;
            txtNombreCategoria.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombreCategoria.Location = new Point(152, 75);
            txtNombreCategoria.Margin = new Padding(4);
            txtNombreCategoria.Name = "txtNombreCategoria";
            txtNombreCategoria.PlaceholderText = "(Ingrese el nombre de la Categoría)";
            txtNombreCategoria.Size = new Size(382, 24);
            txtNombreCategoria.TabIndex = 1;
            // 
            // gbxEstado
            // 
            gbxEstado.Controls.Add(rbdInactivo);
            gbxEstado.Controls.Add(rbdActivo);
            gbxEstado.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbxEstado.ForeColor = Color.DimGray;
            gbxEstado.Location = new Point(152, 290);
            gbxEstado.Margin = new Padding(4);
            gbxEstado.Name = "gbxEstado";
            gbxEstado.Padding = new Padding(4);
            gbxEstado.Size = new Size(319, 56);
            gbxEstado.TabIndex = 7;
            gbxEstado.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(87, 99, 110);
            label8.Location = new Point(49, 76);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(96, 23);
            label8.TabIndex = 12;
            label8.Text = "Categoría:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(87, 99, 110);
            label2.Location = new Point(34, 109);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(112, 23);
            label2.TabIndex = 14;
            label2.Text = "Descripción:";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(189, 215, 238);
            panel2.Controls.Add(flpAjustarBotones);
            panel2.Controls.Add(txtDescripcionCategoria);
            panel2.Controls.Add(pbxImagenMarca);
            panel2.Controls.Add(txtNombreCategoria);
            panel2.Controls.Add(gbxEstado);
            panel2.Controls.Add(lblEstado);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new Size(846, 410);
            panel2.TabIndex = 18;
            // 
            // frmAgregarEditarCategoria
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(846, 410);
            Controls.Add(panBarraControl);
            Controls.Add(panel2);
            Margin = new Padding(4);
            Name = "frmAgregarEditarCategoria";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Categorías";
            Load += frmAgregarEditarCategoria_Load;
            panBarraControl.ResumeLayout(false);
            flpAjustarBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbxImagenMarca).EndInit();
            gbxEstado.ResumeLayout(false);
            gbxEstado.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label lblEstado;
        private RadioButton rbdActivo;
        private FlowLayoutPanel flpAjustarBotones;
        private Button btnGuardarCategoria;
        private Button btnVolver;
        private Button btnModificarCategoria;
        private RadioButton rbdInactivo;
        private TextBox txtDescripcionCategoria;
        private PictureBox pbxImagenMarca;
        private TextBox txtNombreCategoria;
        private GroupBox gbxEstado;
        private Label label8;
        private Label label2;
        public Label lblNombreModulo;
        private Panel panel2;
    }
}