namespace ModernMenuUI.InterfacesUsuarios.MenuPrincipal_Ajustes
{
    partial class frmConfiguracionInicial
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtUsuario = new TextBox();
            txtContraUsuario = new TextBox();
            txtBodega = new TextBox();
            txtContraBodega = new TextBox();
            label5 = new Label();
            label6 = new Label();
            btnCrear = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(57, 117);
            label1.Name = "label1";
            label1.Size = new Size(167, 20);
            label1.TabIndex = 0;
            label1.Text = "Cree un usuario(correo):";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 168);
            label2.Name = "label2";
            label2.Size = new Size(146, 20);
            label2.TabIndex = 1;
            label2.Text = "Cree una contraseña:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(74, 294);
            label3.Name = "label3";
            label3.Size = new Size(150, 20);
            label3.TabIndex = 2;
            label3.Text = "Registre una bodega:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(31, 332);
            label4.Name = "label4";
            label4.Size = new Size(252, 20);
            label4.TabIndex = 3;
            label4.Text = "Cree una contraseña para la bodega:";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(240, 114);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(175, 27);
            txtUsuario.TabIndex = 4;
            // 
            // txtContraUsuario
            // 
            txtContraUsuario.Location = new Point(240, 165);
            txtContraUsuario.Name = "txtContraUsuario";
            txtContraUsuario.Size = new Size(175, 27);
            txtContraUsuario.TabIndex = 5;
            // 
            // txtBodega
            // 
            txtBodega.Location = new Point(300, 291);
            txtBodega.Name = "txtBodega";
            txtBodega.Size = new Size(175, 27);
            txtBodega.TabIndex = 6;
            // 
            // txtContraBodega
            // 
            txtContraBodega.Location = new Point(300, 329);
            txtContraBodega.Name = "txtContraBodega";
            txtContraBodega.Size = new Size(175, 27);
            txtContraBodega.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(116, 53);
            label5.Name = "label5";
            label5.Size = new Size(167, 20);
            label5.TabIndex = 8;
            label5.Text = "REGISTRE UN USUARIO:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(137, 236);
            label6.Name = "label6";
            label6.Size = new Size(174, 20);
            label6.TabIndex = 9;
            label6.Text = "REGISTRE UNA BODEGA:";
            // 
            // btnCrear
            // 
            btnCrear.Location = new Point(616, 217);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(94, 29);
            btnCrear.TabIndex = 10;
            btnCrear.Text = "CREAR";
            btnCrear.UseVisualStyleBackColor = true;
            btnCrear.Click += btnCrear_Click;
            // 
            // frmConfiguracionInicial
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCrear);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(txtContraBodega);
            Controls.Add(txtBodega);
            Controls.Add(txtContraUsuario);
            Controls.Add(txtUsuario);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmConfiguracionInicial";
            Text = "frmConfiguracionInicial";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtUsuario;
        private TextBox txtContraUsuario;
        private TextBox txtBodega;
        private TextBox txtContraBodega;
        private Label label5;
        private Label label6;
        private Button btnCrear;
    }
}