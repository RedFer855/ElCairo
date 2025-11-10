namespace ModernMenuUI.InterfacesUsuarios.Ventas
{
    partial class frmCierreDiario
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
            btnSalir = new Button();
            btnSeleccionar = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSalir.BackColor = Color.FromArgb(148, 168, 187);
            btnSalir.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.White;
            btnSalir.ImageAlign = ContentAlignment.TopCenter;
            btnSalir.Location = new Point(231, 835);
            btnSalir.Margin = new Padding(3, 4, 3, 4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(167, 72);
            btnSalir.TabIndex = 52;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            // 
            // btnSeleccionar
            // 
            btnSeleccionar.BackColor = Color.FromArgb(149, 195, 172);
            btnSeleccionar.BackgroundImageLayout = ImageLayout.None;
            btnSeleccionar.FlatAppearance.BorderSize = 0;
            btnSeleccionar.Font = new Font("Itim", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSeleccionar.ForeColor = SystemColors.ButtonFace;
            btnSeleccionar.ImageAlign = ContentAlignment.BottomLeft;
            btnSeleccionar.Location = new Point(23, 835);
            btnSeleccionar.Margin = new Padding(3, 4, 3, 4);
            btnSeleccionar.Name = "btnSeleccionar";
            btnSeleccionar.Size = new Size(182, 72);
            btnSeleccionar.TabIndex = 53;
            btnSeleccionar.Text = "Seleccionar";
            btnSeleccionar.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(189, 215, 238);
            panel1.Location = new Point(13, 384);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(775, 423);
            panel1.TabIndex = 51;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(189, 215, 238);
            panel2.Location = new Point(23, 56);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(739, 301);
            panel2.TabIndex = 52;
            // 
            // frmCierreDiario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 974);
            Controls.Add(panel2);
            Controls.Add(btnSalir);
            Controls.Add(panel1);
            Controls.Add(btnSeleccionar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmCierreDiario";
            Text = "frmCierreDiario";
            ResumeLayout(false);
        }

        #endregion

        private Button btnSalir;
        private Button btnSeleccionar;
        private Panel panel1;
        private Panel panel2;
    }
}