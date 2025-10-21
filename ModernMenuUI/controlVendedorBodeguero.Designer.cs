namespace ModernMenuUI
{
    partial class controlVendedorBodeguero
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(controlVendedorBodeguero));
            btnInfo = new Button();
            lblNombreRol = new Label();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnInfo
            // 
            btnInfo.BackColor = SystemColors.ActiveCaption;
            btnInfo.BackgroundImage = (Image)resources.GetObject("btnInfo.BackgroundImage");
            btnInfo.BackgroundImageLayout = ImageLayout.Zoom;
            btnInfo.FlatAppearance.BorderColor = Color.White;
            btnInfo.FlatAppearance.BorderSize = 0;
            btnInfo.FlatStyle = FlatStyle.Flat;
            btnInfo.Location = new Point(133, 6);
            btnInfo.Name = "btnInfo";
            btnInfo.Size = new Size(35, 40);
            btnInfo.TabIndex = 1;
            btnInfo.UseVisualStyleBackColor = false;
            btnInfo.Click += btnInfo_Click;
            // 
            // lblNombreRol
            // 
            lblNombreRol.BackColor = Color.Transparent;
            lblNombreRol.Font = new Font("Itim", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombreRol.Location = new Point(12, 11);
            lblNombreRol.Name = "lblNombreRol";
            lblNombreRol.Size = new Size(115, 35);
            lblNombreRol.TabIndex = 0;
            lblNombreRol.Text = "Rol: Vendedor\r\n(Por defecto)";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.GradientInactiveCaption;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(180, 106);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(btnInfo);
            panel1.Controls.Add(lblNombreRol);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 106);
            panel1.Name = "panel1";
            panel1.Size = new Size(180, 54);
            panel1.TabIndex = 8;
            // 
            // controlVendedorBodeguero
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Name = "controlVendedorBodeguero";
            Size = new Size(180, 160);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnInfo;
        private Label lblNombreRol;
        private PictureBox pictureBox1;
        private Panel panel1;
    }
}
