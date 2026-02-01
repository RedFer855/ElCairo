namespace ModernMenuUI.InterfacesUsuarios.Inventario
{
    partial class ProductoTarjeta
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
            panel1 = new Panel();
            imgProdTarjeta = new PictureBox();
            btnAgregar = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imgProdTarjeta).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(189, 215, 238);
            panel1.Controls.Add(imgProdTarjeta);
            panel1.Controls.Add(btnAgregar);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 323);
            panel1.TabIndex = 0;
            // 
            // imgProdTarjeta
            // 
            imgProdTarjeta.BackColor = Color.FromArgb(148, 168, 187);
            imgProdTarjeta.Enabled = false;
            imgProdTarjeta.Location = new Point(26, 18);
            imgProdTarjeta.Name = "imgProdTarjeta";
            imgProdTarjeta.Size = new Size(199, 229);
            imgProdTarjeta.SizeMode = PictureBoxSizeMode.Zoom;
            imgProdTarjeta.TabIndex = 1;
            imgProdTarjeta.TabStop = false;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(149, 195, 172);
            btnAgregar.Cursor = Cursors.Hand;
            btnAgregar.Font = new Font("Itim", 11.9999981F);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(26, 253);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(199, 52);
            btnAgregar.TabIndex = 0;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            // 
            // ProductoTarjeta
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "ProductoTarjeta";
            Size = new Size(254, 328);
            Load += ProductoTarjeta_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)imgProdTarjeta).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnAgregar;
        private PictureBox imgProdTarjeta;
    }
}
