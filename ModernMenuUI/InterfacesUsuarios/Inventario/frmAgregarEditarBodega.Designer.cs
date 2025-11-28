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
            btnModificarBodega = new Button();
            btnGuardarBodega = new Button();
            btnVolver = new Button();
            txtContrasenia = new TextBox();
            txtNombreBodega = new TextBox();
            gbxEstado = new GroupBox();
            label2 = new Label();
            label8 = new Label();
            panel2 = new Panel();
            txtCodigoBodega = new TextBox();
            label3 = new Label();
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
            panBarraControl.Name = "panBarraControl";
            panBarraControl.Size = new Size(417, 37);
            panBarraControl.TabIndex = 19;
            // 
            // lblNombreModulo
            // 
            lblNombreModulo.Dock = DockStyle.Fill;
            lblNombreModulo.Font = new Font("Itim", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombreModulo.ForeColor = Color.White;
            lblNombreModulo.Location = new Point(0, 0);
            lblNombreModulo.Name = "lblNombreModulo";
            lblNombreModulo.Size = new Size(417, 37);
            lblNombreModulo.TabIndex = 14;
            lblNombreModulo.Text = "EDITAR BODEGA";
            lblNombreModulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // rbInactivo
            // 
            rbInactivo.AutoSize = true;
            rbInactivo.Location = new Point(119, 15);
            rbInactivo.Name = "rbInactivo";
            rbInactivo.Size = new Size(82, 23);
            rbInactivo.TabIndex = 8;
            rbInactivo.TabStop = true;
            rbInactivo.Text = "Inactivo";
            rbInactivo.UseVisualStyleBackColor = true;
            // 
            // rbActivo
            // 
            rbActivo.AutoSize = true;
            rbActivo.Location = new Point(6, 15);
            rbActivo.Name = "rbActivo";
            rbActivo.Size = new Size(70, 23);
            rbActivo.TabIndex = 7;
            rbActivo.TabStop = true;
            rbActivo.Text = "Activo";
            rbActivo.UseVisualStyleBackColor = true;
            // 
            // flpAjustarBotones
            // 
            flpAjustarBotones.Controls.Add(btnModificarBodega);
            flpAjustarBotones.Controls.Add(btnGuardarBodega);
            flpAjustarBotones.Controls.Add(btnVolver);
            flpAjustarBotones.Location = new Point(37, 213);
            flpAjustarBotones.Name = "flpAjustarBotones";
            flpAjustarBotones.Size = new Size(295, 37);
            flpAjustarBotones.TabIndex = 25;
            // 
            // btnModificarBodega
            // 
            btnModificarBodega.BackColor = Color.FromArgb(74, 148, 225);
            btnModificarBodega.BackgroundImageLayout = ImageLayout.None;
            btnModificarBodega.FlatAppearance.BorderSize = 0;
            btnModificarBodega.Font = new Font("Itim", 11.9999981F);
            btnModificarBodega.ForeColor = SystemColors.ButtonFace;
            btnModificarBodega.ImageAlign = ContentAlignment.BottomLeft;
            btnModificarBodega.Location = new Point(3, 3);
            btnModificarBodega.Name = "btnModificarBodega";
            btnModificarBodega.Size = new Size(72, 33);
            btnModificarBodega.TabIndex = 19;
            btnModificarBodega.Text = "Editar";
            btnModificarBodega.UseVisualStyleBackColor = false;
            // 
            // btnGuardarBodega
            // 
            btnGuardarBodega.BackColor = Color.FromArgb(149, 195, 172);
            btnGuardarBodega.BackgroundImageLayout = ImageLayout.None;
            btnGuardarBodega.FlatAppearance.BorderSize = 0;
            btnGuardarBodega.Font = new Font("Itim", 11.9999981F);
            btnGuardarBodega.ForeColor = SystemColors.ButtonFace;
            btnGuardarBodega.ImageAlign = ContentAlignment.BottomLeft;
            btnGuardarBodega.Location = new Point(81, 3);
            btnGuardarBodega.Name = "btnGuardarBodega";
            btnGuardarBodega.Size = new Size(89, 33);
            btnGuardarBodega.TabIndex = 9;
            btnGuardarBodega.Text = "Guardar";
            btnGuardarBodega.UseVisualStyleBackColor = false;
            btnGuardarBodega.Visible = false;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.FromArgb(148, 168, 187);
            btnVolver.BackgroundImageLayout = ImageLayout.None;
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.Font = new Font("Itim", 11.9999981F);
            btnVolver.ForeColor = SystemColors.ButtonFace;
            btnVolver.ImageAlign = ContentAlignment.BottomLeft;
            btnVolver.Location = new Point(176, 3);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(95, 33);
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
            txtContrasenia.Location = new Point(126, 114);
            txtContrasenia.Name = "txtContrasenia";
            txtContrasenia.PlaceholderText = "(Seleccione Buscar)";
            txtContrasenia.Size = new Size(255, 20);
            txtContrasenia.TabIndex = 24;
            // 
            // txtNombreBodega
            // 
            txtNombreBodega.BackColor = Color.White;
            txtNombreBodega.BorderStyle = BorderStyle.None;
            txtNombreBodega.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombreBodega.Location = new Point(126, 87);
            txtNombreBodega.Name = "txtNombreBodega";
            txtNombreBodega.Size = new Size(255, 20);
            txtNombreBodega.TabIndex = 1;
            // 
            // gbxEstado
            // 
            gbxEstado.Controls.Add(rbInactivo);
            gbxEstado.Controls.Add(rbActivo);
            gbxEstado.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbxEstado.ForeColor = Color.DimGray;
            gbxEstado.Location = new Point(126, 140);
            gbxEstado.Name = "gbxEstado";
            gbxEstado.Size = new Size(255, 45);
            gbxEstado.TabIndex = 7;
            gbxEstado.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(87, 99, 110);
            label2.Location = new Point(33, 115);
            label2.Name = "label2";
            label2.Size = new Size(87, 18);
            label2.TabIndex = 14;
            label2.Text = "Contraseña:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(87, 99, 110);
            label8.Location = new Point(59, 87);
            label8.Name = "label8";
            label8.Size = new Size(61, 18);
            label8.TabIndex = 12;
            label8.Text = "Bodega:";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(189, 215, 238);
            panel2.Controls.Add(txtCodigoBodega);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(flpAjustarBotones);
            panel2.Controls.Add(txtContrasenia);
            panel2.Controls.Add(txtNombreBodega);
            panel2.Controls.Add(gbxEstado);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(417, 267);
            panel2.TabIndex = 18;
            // 
            // txtCodigoBodega
            // 
            txtCodigoBodega.BackColor = Color.White;
            txtCodigoBodega.BorderStyle = BorderStyle.None;
            txtCodigoBodega.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCodigoBodega.Location = new Point(126, 61);
            txtCodigoBodega.Name = "txtCodigoBodega";
            txtCodigoBodega.Size = new Size(255, 20);
            txtCodigoBodega.TabIndex = 27;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(87, 99, 110);
            label3.Location = new Point(63, 61);
            label3.Name = "label3";
            label3.Size = new Size(58, 18);
            label3.TabIndex = 28;
            label3.Text = "Código:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(87, 99, 110);
            label1.Location = new Point(63, 155);
            label1.Name = "label1";
            label1.Size = new Size(57, 18);
            label1.TabIndex = 26;
            label1.Text = "Estado:";
            // 
            // frmAgregarEditarBodega
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(417, 267);
            Controls.Add(panBarraControl);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
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
        private TextBox txtCodigoBodega;
        private Label label3;
    }
}