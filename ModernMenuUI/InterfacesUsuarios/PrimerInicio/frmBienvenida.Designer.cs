namespace ModernMenuUI.InterfacesUsuarios.PrimerInicio
{
    partial class frmBienvenida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBienvenida));
            panDatosIngreso = new Panel();
            pictureBox1 = new PictureBox();
            richTextBox1 = new RichTextBox();
            label1 = new Label();
            btnAcceder = new Button();
            panel1 = new Panel();
            btnSalir = new Button();
            panDatosIngreso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panDatosIngreso
            // 
            panDatosIngreso.BackColor = SystemColors.Control;
            panDatosIngreso.Controls.Add(btnSalir);
            panDatosIngreso.Controls.Add(pictureBox1);
            panDatosIngreso.Controls.Add(richTextBox1);
            panDatosIngreso.Controls.Add(label1);
            panDatosIngreso.Controls.Add(btnAcceder);
            panDatosIngreso.Dock = DockStyle.Fill;
            panDatosIngreso.Location = new Point(0, 0);
            panDatosIngreso.Margin = new Padding(0);
            panDatosIngreso.Name = "panDatosIngreso";
            panDatosIngreso.Size = new Size(911, 467);
            panDatosIngreso.TabIndex = 9;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.inventario_disponible__4_;
            pictureBox1.Location = new Point(292, 170);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(616, 172);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = SystemColors.Control;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox1.Location = new Point(318, 67);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(551, 108);
            richTextBox1.TabIndex = 9;
            richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(318, 25);
            label1.Name = "label1";
            label1.Size = new Size(184, 24);
            label1.TabIndex = 7;
            label1.Text = "Estimado Usuario:";
            // 
            // btnAcceder
            // 
            btnAcceder.BackColor = Color.FromArgb(40, 40, 40);
            btnAcceder.FlatAppearance.BorderSize = 0;
            btnAcceder.FlatStyle = FlatStyle.Flat;
            btnAcceder.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAcceder.ForeColor = Color.White;
            btnAcceder.Location = new Point(639, 384);
            btnAcceder.Margin = new Padding(3, 4, 3, 4);
            btnAcceder.Name = "btnAcceder";
            btnAcceder.Size = new Size(128, 53);
            btnAcceder.TabIndex = 6;
            btnAcceder.Text = "Siguiente";
            btnAcceder.UseVisualStyleBackColor = false;
            btnAcceder.Click += btnAcceder_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(15, 15, 15);
            panel1.Dock = DockStyle.Left;
            panel1.ForeColor = SystemColors.ControlText;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(289, 467);
            panel1.TabIndex = 21;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(224, 79, 95);
            btnSalir.BackgroundImageLayout = ImageLayout.Zoom;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(773, 384);
            btnSalir.Margin = new Padding(3, 4, 3, 4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(115, 53);
            btnSalir.TabIndex = 11;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            // 
            // frmBienvenida
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(911, 467);
            Controls.Add(panel1);
            Controls.Add(panDatosIngreso);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmBienvenida";
            Text = "Form1";
            panDatosIngreso.ResumeLayout(false);
            panDatosIngreso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panDatosIngreso;
        private Label label1;
        private Button btnAcceder;
        private Panel panel1;
        private RichTextBox richTextBox1;
        private PictureBox pictureBox1;
        private Button btnSalir;
    }
}