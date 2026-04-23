namespace ModernMenuUI.ClasesUI
{
    partial class BarraProductosSugeridos
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
            lblTitulo = new Label();
            flowContenedor = new FlowLayoutPanel();
            lblVacio = new Label();
            flowContenedor.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Itim", 11F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(87, 99, 110);
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Padding = new Padding(10, 0, 0, 0);
            lblTitulo.Size = new Size(460, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Productos más vendidos";
            lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // flowContenedor
            // 
            flowContenedor.AutoScroll = true;
            flowContenedor.Controls.Add(lblVacio);
            flowContenedor.Dock = DockStyle.Fill;
            flowContenedor.FlowDirection = FlowDirection.TopDown;
            flowContenedor.Location = new Point(0, 30);
            flowContenedor.Name = "flowContenedor";
            flowContenedor.Padding = new Padding(5);
            flowContenedor.Size = new Size(460, 270);
            flowContenedor.TabIndex = 1;
            flowContenedor.WrapContents = false;
            // 
            // lblVacio
            // 
            lblVacio.AutoSize = true;
            lblVacio.Dock = DockStyle.Fill;
            lblVacio.Font = new Font("Segoe UI", 10F);
            lblVacio.ForeColor = Color.FromArgb(87, 99, 110);
            lblVacio.Location = new Point(8, 5);
            lblVacio.Name = "lblVacio";
            lblVacio.Size = new Size(202, 19);
            lblVacio.TabIndex = 0;
            lblVacio.Text = "No hay productos para mostrar";
            lblVacio.TextAlign = ContentAlignment.MiddleCenter;
            lblVacio.Visible = false;
            // 
            // BarraProductosSugeridos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flowContenedor);
            Controls.Add(lblTitulo);
            ForeColor = Color.FromArgb(220, 230, 241);
            Name = "BarraProductosSugeridos";
            Size = new Size(460, 300);
            flowContenedor.ResumeLayout(false);
            flowContenedor.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitulo;
        private FlowLayoutPanel flowContenedor;
        private Label lblVacio;
    }
}
