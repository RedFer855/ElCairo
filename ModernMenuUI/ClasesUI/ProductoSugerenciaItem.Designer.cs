namespace ModernMenuUI.ClasesUI
{
    partial class ProductoSugerenciaItem
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
            pbxImagen = new PictureBox();
            lblNombre = new Label();
            lblStock = new Label();
            lblPrecio = new Label();
            lblNoDisponible = new Label();
            btnAgregar = new Button();
            ((System.ComponentModel.ISupportInitialize)pbxImagen).BeginInit();
            SuspendLayout();
            // 
            // pbxImagen
            // 
            pbxImagen.BackColor = Color.WhiteSmoke;
            pbxImagen.Image = Properties.Resources.sin_imagen;
            pbxImagen.Location = new Point(5, 5);
            pbxImagen.Name = "pbxImagen";
            pbxImagen.Size = new Size(80, 80);
            pbxImagen.SizeMode = PictureBoxSizeMode.Zoom;
            pbxImagen.TabIndex = 0;
            pbxImagen.TabStop = false;
            // 
            // lblNombre
            // 
            lblNombre.AutoEllipsis = true;
            lblNombre.Font = new Font("Itim", 10F);
            lblNombre.ForeColor = Color.FromArgb(87, 99, 110);
            lblNombre.Location = new Point(95, 5);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(260, 40);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre del Producto";
            // 
            // lblStock
            // 
            lblStock.AutoEllipsis = true;
            lblStock.Font = new Font("Itim", 10F);
            lblStock.ForeColor = Color.FromArgb(87, 99, 110);
            lblStock.Location = new Point(95, 68);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(100, 25);
            lblStock.TabIndex = 2;
            lblStock.Text = "Stock: 0";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoEllipsis = true;
            lblPrecio.Font = new Font("Itim", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrecio.ForeColor = Color.FromArgb(149, 195, 172);
            lblPrecio.Location = new Point(95, 48);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(150, 20);
            lblPrecio.TabIndex = 3;
            lblPrecio.Text = "L0.00";
            // 
            // lblNoDisponible
            // 
            lblNoDisponible.AutoEllipsis = true;
            lblNoDisponible.BackColor = Color.White;
            lblNoDisponible.Font = new Font("Itim", 9F);
            lblNoDisponible.ForeColor = Color.FromArgb(220, 90, 90);
            lblNoDisponible.Location = new Point(250, 48);
            lblNoDisponible.Name = "lblNoDisponible";
            lblNoDisponible.Size = new Size(100, 25);
            lblNoDisponible.TabIndex = 4;
            lblNoDisponible.Text = "NO DISPONIBLE";
            lblNoDisponible.TextAlign = ContentAlignment.MiddleCenter;
            lblNoDisponible.Visible = false;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(149, 195, 172);
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Itim", 10F, FontStyle.Bold);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(360, 5);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 80);
            btnAgregar.TabIndex = 5;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            // 
            // ProductoSugerenciaItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(btnAgregar);
            Controls.Add(lblNoDisponible);
            Controls.Add(lblPrecio);
            Controls.Add(lblStock);
            Controls.Add(lblNombre);
            Controls.Add(pbxImagen);
            Cursor = Cursors.Hand;
            Name = "ProductoSugerenciaItem";
            Size = new Size(438, 88);
            ((System.ComponentModel.ISupportInitialize)pbxImagen).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbxImagen;
        private Label lblNombre;
        private Label lblStock;
        private Label lblPrecio;
        private Label lblNoDisponible;
        private Button btnAgregar;
    }
}
