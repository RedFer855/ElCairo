namespace ModernMenuUI.InterfacesUsuarios.Inventario
{
    partial class ProductosCartas
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
            label1 = new Label();
            lblNombreModulo = new Label();
            GridColumnas = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 28);
            label1.Name = "label1";
            label1.Size = new Size(0, 18);
            label1.TabIndex = 0;
            // 
            // lblNombreModulo
            // 
            lblNombreModulo.BackColor = Color.FromArgb(148, 168, 187);
            lblNombreModulo.Dock = DockStyle.Top;
            lblNombreModulo.Font = new Font("Itim", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombreModulo.ForeColor = Color.White;
            lblNombreModulo.Location = new Point(0, 0);
            lblNombreModulo.Name = "lblNombreModulo";
            lblNombreModulo.Size = new Size(1181, 68);
            lblNombreModulo.TabIndex = 9;
            lblNombreModulo.Text = "SELECCIONE UNA IMAGEN ";
            lblNombreModulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GridColumnas
            // 
            GridColumnas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            GridColumnas.Location = new Point(0, 84);
            GridColumnas.Name = "GridColumnas";
            GridColumnas.Size = new Size(1181, 556);
            GridColumnas.TabIndex = 10;
            // 
            // ProductosCartas
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1181, 641);
            Controls.Add(GridColumnas);
            Controls.Add(lblNombreModulo);
            Controls.Add(label1);
            Font = new Font("Itim", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ProductosCartas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Imagenes";
            Load += ProductosCartas_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        public Label lblNombreModulo;
        private FlowLayoutPanel GridColumnas;
    }
}