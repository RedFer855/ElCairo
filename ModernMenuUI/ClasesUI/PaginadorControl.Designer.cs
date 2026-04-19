namespace ModernMenuUI.ClasesUI
{
    partial class PaginadorControl
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
            btnPrimera = new Button();
            btnAnterior = new Button();
            btnSiguiente = new Button();
            btnUltima = new Button();
            lblInfo = new Label();
            lblTamanio = new Label();
            cmbTamanioPagina = new ComboBox();
            SuspendLayout();
            // 
            // btnPrimera
            // 
            btnPrimera.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPrimera.BackColor = Color.FromArgb(148, 168, 187);
            btnPrimera.Cursor = Cursors.Hand;
            btnPrimera.FlatStyle = FlatStyle.Flat;
            btnPrimera.Font = new Font("Itim", 9F);
            btnPrimera.ForeColor = Color.White;
            btnPrimera.Location = new Point(178, 6);
            btnPrimera.Margin = new Padding(3, 4, 3, 4);
            btnPrimera.Name = "btnPrimera";
            btnPrimera.Size = new Size(51, 25);
            btnPrimera.TabIndex = 0;
            btnPrimera.Text = "<<";
            btnPrimera.UseVisualStyleBackColor = false;
            // 
            // btnAnterior
            // 
            btnAnterior.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAnterior.BackColor = Color.FromArgb(148, 168, 187);
            btnAnterior.Cursor = Cursors.Hand;
            btnAnterior.FlatStyle = FlatStyle.Flat;
            btnAnterior.Font = new Font("Itim", 9F);
            btnAnterior.ForeColor = Color.White;
            btnAnterior.Location = new Point(235, 6);
            btnAnterior.Margin = new Padding(3, 4, 3, 4);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(51, 25);
            btnAnterior.TabIndex = 1;
            btnAnterior.Text = "<";
            btnAnterior.UseVisualStyleBackColor = false;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSiguiente.BackColor = Color.FromArgb(148, 168, 187);
            btnSiguiente.Cursor = Cursors.Hand;
            btnSiguiente.FlatStyle = FlatStyle.Flat;
            btnSiguiente.Font = new Font("Itim", 9F);
            btnSiguiente.ForeColor = Color.White;
            btnSiguiente.Location = new Point(435, 6);
            btnSiguiente.Margin = new Padding(3, 4, 3, 4);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(51, 25);
            btnSiguiente.TabIndex = 2;
            btnSiguiente.Text = ">";
            btnSiguiente.UseVisualStyleBackColor = false;
            // 
            // btnUltima
            // 
            btnUltima.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUltima.BackColor = Color.FromArgb(148, 168, 187);
            btnUltima.Cursor = Cursors.Hand;
            btnUltima.FlatStyle = FlatStyle.Flat;
            btnUltima.Font = new Font("Itim", 9F);
            btnUltima.ForeColor = Color.White;
            btnUltima.Location = new Point(492, 6);
            btnUltima.Margin = new Padding(3, 4, 3, 4);
            btnUltima.Name = "btnUltima";
            btnUltima.Size = new Size(51, 25);
            btnUltima.TabIndex = 3;
            btnUltima.Text = ">>";
            btnUltima.UseVisualStyleBackColor = false;
            // 
            // lblInfo
            // 
            lblInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblInfo.Font = new Font("Itim", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInfo.ForeColor = Color.FromArgb(87, 99, 110);
            lblInfo.Location = new Point(292, 6);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(137, 25);
            lblInfo.TabIndex = 4;
            lblInfo.Text = "Página 0 de 0";
            lblInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTamanio
            // 
            lblTamanio.Font = new Font("Itim", 9.749999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTamanio.ForeColor = Color.FromArgb(87, 99, 110);
            lblTamanio.Location = new Point(7, 6);
            lblTamanio.Name = "lblTamanio";
            lblTamanio.Size = new Size(70, 26);
            lblTamanio.TabIndex = 5;
            lblTamanio.Text = "Por página:";
            lblTamanio.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbTamanioPagina
            // 
            cmbTamanioPagina.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTamanioPagina.Font = new Font("Itim", 10.5F);
            cmbTamanioPagina.FormattingEnabled = true;
            cmbTamanioPagina.Items.AddRange(new object[] { "50", "100", "200", "500" });
            cmbTamanioPagina.Location = new Point(83, 6);
            cmbTamanioPagina.Margin = new Padding(3, 4, 3, 4);
            cmbTamanioPagina.Name = "cmbTamanioPagina";
            cmbTamanioPagina.Size = new Size(79, 25);
            cmbTamanioPagina.TabIndex = 6;
            // 
            // PaginadorControl
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(189, 215, 238);
            Controls.Add(cmbTamanioPagina);
            Controls.Add(lblTamanio);
            Controls.Add(lblInfo);
            Controls.Add(btnUltima);
            Controls.Add(btnSiguiente);
            Controls.Add(btnAnterior);
            Controls.Add(btnPrimera);
            Font = new Font("Itim", 10.5F);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(550, 38);
            Name = "PaginadorControl";
            Size = new Size(550, 38);
            ResumeLayout(false);
        }

        #endregion

        private Button btnPrimera;
        private Button btnAnterior;
        private Button btnSiguiente;
        private Button btnUltima;
        private Label lblInfo;
        private Label lblTamanio;
        private ComboBox cmbTamanioPagina;
    }
}
