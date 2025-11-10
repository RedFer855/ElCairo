namespace ModernMenuUI
{
    partial class controlBotonesMenuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(controlBotonesMenuPrincipal));
            pbxIcono = new PictureBox();
            pnlTitulo = new Panel();
            lblTitulo = new Label();
            ((System.ComponentModel.ISupportInitialize)pbxIcono).BeginInit();
            pnlTitulo.SuspendLayout();
            SuspendLayout();
            // 
            // pbxIcono
            // 
            pbxIcono.Dock = DockStyle.Left;
            pbxIcono.Image = (Image)resources.GetObject("pbxIcono.Image");
            pbxIcono.Location = new Point(0, 0);
            pbxIcono.Name = "pbxIcono";
            pbxIcono.Size = new Size(100, 80);
            pbxIcono.SizeMode = PictureBoxSizeMode.Zoom;
            pbxIcono.TabIndex = 0;
            pbxIcono.TabStop = false;
            // 
            // pnlTitulo
            // 
            pnlTitulo.Controls.Add(lblTitulo);
            pnlTitulo.Dock = DockStyle.Fill;
            pnlTitulo.Location = new Point(100, 0);
            pnlTitulo.Name = "pnlTitulo";
            pnlTitulo.Size = new Size(200, 80);
            pnlTitulo.TabIndex = 1;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Itim", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(87, 99, 110);
            lblTitulo.Location = new Point(6, 25);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(65, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Titulo";
            // 
            // controlBotonesMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(189, 215, 238);
            Controls.Add(pnlTitulo);
            Controls.Add(pbxIcono);
            Name = "controlBotonesMenuPrincipal";
            Size = new Size(300, 80);
            ((System.ComponentModel.ISupportInitialize)pbxIcono).EndInit();
            pnlTitulo.ResumeLayout(false);
            pnlTitulo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbxIcono;
        private Panel pnlTitulo;
        private Label lblTitulo;
    }
}
