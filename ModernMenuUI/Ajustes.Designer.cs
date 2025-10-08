namespace ModernMenuUI
{
    partial class Ajustes
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
            chkAnimaciones = new CheckBox();
            chkModoOscuro = new CheckBox();
            panelAjustes = new Panel();
            labelAnimaciones = new Label();
            panelAjustes.SuspendLayout();
            SuspendLayout();
            // 
            // chkAnimaciones
            // 
            chkAnimaciones.AutoSize = true;
            chkAnimaciones.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkAnimaciones.Location = new Point(12, 56);
            chkAnimaciones.Name = "chkAnimaciones";
            chkAnimaciones.Size = new Size(249, 22);
            chkAnimaciones.TabIndex = 0;
            chkAnimaciones.Text = "Habilitar Animaciones del sistema";
            chkAnimaciones.UseVisualStyleBackColor = true;
            chkAnimaciones.CheckedChanged += chkAnimaciones_CheckedChanged;
            // 
            // chkModoOscuro
            // 
            chkModoOscuro.AutoSize = true;
            chkModoOscuro.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkModoOscuro.Location = new Point(12, 84);
            chkModoOscuro.Name = "chkModoOscuro";
            chkModoOscuro.Size = new Size(174, 22);
            chkModoOscuro.TabIndex = 1;
            chkModoOscuro.Text = "Habilitar Modo Oscuro";
            chkModoOscuro.UseVisualStyleBackColor = true;
            chkModoOscuro.CheckedChanged += chkModoOscuro_CheckedChanged;
            // 
            // panelAjustes
            // 
            panelAjustes.Controls.Add(labelAnimaciones);
            panelAjustes.Controls.Add(chkAnimaciones);
            panelAjustes.Controls.Add(chkModoOscuro);
            panelAjustes.Dock = DockStyle.Fill;
            panelAjustes.Location = new Point(0, 0);
            panelAjustes.Name = "panelAjustes";
            panelAjustes.Size = new Size(748, 624);
            panelAjustes.TabIndex = 2;
            panelAjustes.Paint += panelAjustes_Paint;
            // 
            // labelAnimaciones
            // 
            labelAnimaciones.AutoSize = true;
            labelAnimaciones.Font = new Font("Itim", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelAnimaciones.Location = new Point(12, 21);
            labelAnimaciones.Name = "labelAnimaciones";
            labelAnimaciones.Size = new Size(233, 23);
            labelAnimaciones.TabIndex = 3;
            labelAnimaciones.Text = "Ajustes de Interfaz Gráfica:";
            // 
            // Ajustes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(748, 624);
            Controls.Add(panelAjustes);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Ajustes";
            Text = "Ajus";
            panelAjustes.ResumeLayout(false);
            panelAjustes.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private CheckBox chkAnimaciones;
        private CheckBox chkModoOscuro;
        private Panel panelAjustes;
        private Label labelAnimaciones;
    }
}