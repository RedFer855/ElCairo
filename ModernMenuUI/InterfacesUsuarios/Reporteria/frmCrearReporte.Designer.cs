namespace ModernMenuUI.InterfacesUsuarios.Reporteria
{
    partial class frmCrearReporte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCrearReporte));
            btnReporteInventarioBajo = new controlBotonesMenuPrincipal();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1 = new Panel();
            label1 = new Label();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnReporteInventarioBajo
            // 
            btnReporteInventarioBajo.BackColor = Color.FromArgb(189, 215, 238);
            btnReporteInventarioBajo.ColorClick = Color.FromArgb(200, 212, 222);
            btnReporteInventarioBajo.ColorHover = Color.FromArgb(170, 193, 214);
            btnReporteInventarioBajo.ColorNormal = Color.FromArgb(189, 215, 238);
            btnReporteInventarioBajo.ColorTexto = Color.FromArgb(87, 99, 110);
            btnReporteInventarioBajo.Imagen = (Image)resources.GetObject("btnReporteInventarioBajo.Imagen");
            btnReporteInventarioBajo.Location = new Point(3, 3);
            btnReporteInventarioBajo.Name = "btnReporteInventarioBajo";
            btnReporteInventarioBajo.Size = new Size(300, 80);
            btnReporteInventarioBajo.TabIndex = 0;
            btnReporteInventarioBajo.Texto = "Inventario Bajo";
            btnReporteInventarioBajo.Click += btnReporteInventarioBajo_Click;
            btnReporteInventarioBajo.MouseClick += btnReporteInventarioBajo_MouseClick;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnReporteInventarioBajo);
            flowLayoutPanel1.Location = new Point(12, 67);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(776, 371);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(148, 168, 187);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(15, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(773, 49);
            panel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Itim", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(15, 13);
            label1.Name = "label1";
            label1.Size = new Size(243, 25);
            label1.TabIndex = 0;
            label1.Text = "REPORTES DEL SISTEMA";
            // 
            // frmCrearReporte
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(flowLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmCrearReporte";
            Text = "frmCrearReporte";
            flowLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private controlBotonesMenuPrincipal btnReporteInventarioBajo;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
        private Label label1;
    }
}