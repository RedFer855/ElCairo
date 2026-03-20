namespace ModernMenuUI.InterfacesUsuarios.Inventario
{
    partial class frmAgregarEditarBodega
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
            rbInactivo = new RadioButton();
            rbActivo = new RadioButton();
            flpAjustarBotones = new FlowLayoutPanel();
            btnGuardarBodega = new Button();
            btnModificarBodega = new Button();
            btnVolver = new Button();
            txtContrasenia = new TextBox();
            txtNombreBodega = new TextBox();
            gbxEstado = new GroupBox();
            label2 = new Label();
            label8 = new Label();
            panel2 = new Panel();
            label1 = new Label();
            panBarraControl = new Panel();
            panBarraControl.SuspendLayout();
            flpAjustarBotones.SuspendLayout();
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
            panBarraControl.Margin = new Padding(3, 4, 3, 4);
            panBarraControl.Name = "panBarraControl";
            panBarraControl.Size = new Size(477, 49);
            panBarraControl.TabIndex = 19;
            // 
            // lblNombreModulo
            // 
            lblNombreModulo.Dock = DockStyle.Fill;
            lblNombreModulo.Font = new Font("Itim", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombreModulo.ForeColor = Color.White;
            lblNombreModulo.Location = new Point(0, 0);
            lblNombreModulo.Name = "lblNombreModulo";
            lblNombreModulo.Size = new Size(477, 49);
            lblNombreModulo.TabIndex = 14;
            lblNombreModulo.Text = "CREAR BODEGA";
            lblNombreModulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // rbInactivo
            // 
            rbInactivo.AutoSize = true;
            rbInactivo.Location = new Point(136, 20);
            rbInactivo.Margin = new Padding(3, 4, 3, 4);
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
            rbActivo.Location = new Point(7, 20);
            rbActivo.Margin = new Padding(3, 4, 3, 4);
            rbActivo.Name = "rbActivo";
            rbActivo.Size = new Size(84, 28);
            rbActivo.TabIndex = 7;
            rbActivo.TabStop = true;
            rbActivo.Text = "Activo";
            rbActivo.UseVisualStyleBackColor = true;
            // 
            // flpAjustarBotones
            // 
            flpAjustarBotones.Controls.Add(btnGuardarBodega);
            flpAjustarBotones.Controls.Add(btnModificarBodega);
            flpAjustarBotones.Controls.Add(btnVolver);
            flpAjustarBotones.Location = new Point(85, 237);
            flpAjustarBotones.Margin = new Padding(3, 4, 3, 4);
            flpAjustarBotones.Name = "flpAjustarBotones";
            flpAjustarBotones.Size = new Size(315, 49);
            flpAjustarBotones.TabIndex = 25;
            // 
            // btnGuardarBodega
            // 
            btnGuardarBodega.BackColor = Color.FromArgb(149, 195, 172);
            btnGuardarBodega.BackgroundImageLayout = ImageLayout.None;
            btnGuardarBodega.FlatAppearance.BorderSize = 0;
            btnGuardarBodega.Font = new Font("Itim", 11.9999981F);
            btnGuardarBodega.ForeColor = SystemColors.ButtonFace;
            btnGuardarBodega.ImageAlign = ContentAlignment.BottomLeft;
            btnGuardarBodega.Location = new Point(3, 4);
            btnGuardarBodega.Margin = new Padding(3, 4, 3, 4);
            btnGuardarBodega.Name = "btnGuardarBodega";
            btnGuardarBodega.Size = new Size(102, 44);
            btnGuardarBodega.TabIndex = 9;
            btnGuardarBodega.Text = "Guardar";
            btnGuardarBodega.UseVisualStyleBackColor = false;
            btnGuardarBodega.Visible = false;
            btnGuardarBodega.Click += btnGuardarBodega_Click;
            // 
            // btnModificarBodega
            // 
            btnModificarBodega.BackColor = Color.FromArgb(74, 148, 225);
            btnModificarBodega.BackgroundImageLayout = ImageLayout.None;
            btnModificarBodega.FlatAppearance.BorderSize = 0;
            btnModificarBodega.Font = new Font("Itim", 11.9999981F);
            btnModificarBodega.ForeColor = SystemColors.ButtonFace;
            btnModificarBodega.ImageAlign = ContentAlignment.BottomLeft;
            btnModificarBodega.Location = new Point(111, 4);
            btnModificarBodega.Margin = new Padding(3, 4, 3, 4);
            btnModificarBodega.Name = "btnModificarBodega";
            btnModificarBodega.Size = new Size(82, 44);
            btnModificarBodega.TabIndex = 19;
            btnModificarBodega.Text = "Editar";
            btnModificarBodega.UseVisualStyleBackColor = false;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.FromArgb(148, 168, 187);
            btnVolver.BackgroundImageLayout = ImageLayout.None;
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.Font = new Font("Itim", 11.9999981F);
            btnVolver.ForeColor = SystemColors.ButtonFace;
            btnVolver.ImageAlign = ContentAlignment.BottomLeft;
            btnVolver.Location = new Point(199, 4);
            btnVolver.Margin = new Padding(3, 4, 3, 4);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(109, 44);
            btnVolver.TabIndex = 0;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // txtContrasenia
            // 
            txtContrasenia.BackColor = Color.White;
            txtContrasenia.BorderStyle = BorderStyle.None;
            txtContrasenia.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContrasenia.Location = new Point(142, 120);
            txtContrasenia.Margin = new Padding(3, 4, 3, 4);
            txtContrasenia.Name = "txtContrasenia";
            txtContrasenia.PlaceholderText = "Ingrese la contraseña";
            txtContrasenia.Size = new Size(291, 24);
            txtContrasenia.TabIndex = 24;
            // 
            // txtNombreBodega
            // 
            txtNombreBodega.BackColor = Color.White;
            txtNombreBodega.BorderStyle = BorderStyle.None;
            txtNombreBodega.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombreBodega.Location = new Point(142, 84);
            txtNombreBodega.Margin = new Padding(3, 4, 3, 4);
            txtNombreBodega.Name = "txtNombreBodega";
            txtNombreBodega.PlaceholderText = "Ingrese el nombre de la bodega";
            txtNombreBodega.Size = new Size(291, 24);
            txtNombreBodega.TabIndex = 1;
            // 
            // gbxEstado
            // 
            gbxEstado.Controls.Add(rbInactivo);
            gbxEstado.Controls.Add(rbActivo);
            gbxEstado.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbxEstado.ForeColor = Color.DimGray;
            gbxEstado.Location = new Point(142, 155);
            gbxEstado.Margin = new Padding(3, 4, 3, 4);
            gbxEstado.Name = "gbxEstado";
            gbxEstado.Padding = new Padding(3, 4, 3, 4);
            gbxEstado.Size = new Size(291, 60);
            gbxEstado.TabIndex = 7;
            gbxEstado.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(87, 99, 110);
            label2.Location = new Point(37, 121);
            label2.Name = "label2";
            label2.Size = new Size(110, 23);
            label2.TabIndex = 14;
            label2.Text = "Contraseña:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(87, 99, 110);
            label8.Location = new Point(65, 84);
            label8.Name = "label8";
            label8.Size = new Size(76, 23);
            label8.TabIndex = 12;
            label8.Text = "Bodega:";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(189, 215, 238);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(flpAjustarBotones);
            panel2.Controls.Add(txtContrasenia);
            panel2.Controls.Add(txtNombreBodega);
            panel2.Controls.Add(gbxEstado);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(477, 324);
            panel2.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(87, 99, 110);
            label1.Location = new Point(70, 175);
            label1.Name = "label1";
            label1.Size = new Size(70, 23);
            label1.TabIndex = 26;
            label1.Text = "Estado:";
            // 
            // frmAgregarEditarBodega
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(477, 324);
            Controls.Add(panBarraControl);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAgregarEditarBodega";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bodegas";
            panBarraControl.ResumeLayout(false);
            flpAjustarBotones.ResumeLayout(false);
            gbxEstado.ResumeLayout(false);
            gbxEstado.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private RadioButton rbInactivo;
        private RadioButton rbActivo;
        private FlowLayoutPanel flpAjustarBotones;
        private Button btnGuardarBodega;
        private Button btnModificarBodega;
        private Button btnVolver;
        private TextBox txtContrasenia;
        private TextBox txtNombreBodega;
        private GroupBox gbxEstado;
        private Label label2;
        public Label lblNombreModulo;
        private Label label8;
        private Panel panel2;
        private Label label1;
    }
}