namespace ModernMenuUI
{
    partial class frmBitacora
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
            Panel panBarraControl;
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panel3 = new Panel();
            lblNombreModulo = new Label();
            panel1 = new Panel();
            panel10 = new Panel();
            dgvBitacora = new DataGridView();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            panelBusqueda = new Panel();
            txtBuscar = new TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnNuevoRol = new Button();
            btnSalir = new Button();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            Fecha = new DataGridViewTextBoxColumn();
            aliasUsuario = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            Modulo = new DataGridViewTextBoxColumn();
            EstadoAnterior = new DataGridViewTextBoxColumn();
            EstadoActual = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            Estado = new DataGridViewTextBoxColumn();
            User = new DataGridViewTextBoxColumn();
            UsuarioId = new DataGridViewTextBoxColumn();
            panBarraControl = new Panel();
            panBarraControl.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBitacora).BeginInit();
            panelBusqueda.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panBarraControl
            // 
            panBarraControl.BackColor = Color.FromArgb(189, 215, 238);
            panBarraControl.Controls.Add(panel3);
            panBarraControl.Dock = DockStyle.Top;
            panBarraControl.ForeColor = Color.Coral;
            panBarraControl.Location = new Point(0, 0);
            panBarraControl.Margin = new Padding(4);
            panBarraControl.Name = "panBarraControl";
            panBarraControl.Size = new Size(958, 39);
            panBarraControl.TabIndex = 53;
            // 
            // panel3
            // 
            panel3.Controls.Add(lblNombreModulo);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(4);
            panel3.Name = "panel3";
            panel3.Size = new Size(272, 39);
            panel3.TabIndex = 9;
            // 
            // lblNombreModulo
            // 
            lblNombreModulo.AutoSize = true;
            lblNombreModulo.Font = new Font("Itim", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombreModulo.ForeColor = Color.White;
            lblNombreModulo.Location = new Point(4, 0);
            lblNombreModulo.Margin = new Padding(4, 0, 4, 0);
            lblNombreModulo.Name = "lblNombreModulo";
            lblNombreModulo.Size = new Size(159, 35);
            lblNombreModulo.TabIndex = 8;
            lblNombreModulo.Text = "BITACORA";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(189, 215, 238);
            panel1.Controls.Add(panel10);
            panel1.Location = new Point(30, 194);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(896, 514);
            panel1.TabIndex = 46;
            // 
            // panel10
            // 
            panel10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel10.AutoScroll = true;
            panel10.Controls.Add(dgvBitacora);
            panel10.Location = new Point(24, 25);
            panel10.Margin = new Padding(4);
            panel10.Name = "panel10";
            panel10.Size = new Size(850, 470);
            panel10.TabIndex = 17;
            // 
            // dgvBitacora
            // 
            dgvBitacora.AllowUserToAddRows = false;
            dgvBitacora.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dgvBitacora.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvBitacora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBitacora.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvBitacora.BackgroundColor = Color.FromArgb(189, 215, 238);
            dgvBitacora.BorderStyle = BorderStyle.None;
            dgvBitacora.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvBitacora.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle2.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle2.SelectionBackColor = Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvBitacora.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvBitacora.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBitacora.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, Fecha, aliasUsuario, dataGridViewTextBoxColumn2, Modulo, EstadoAnterior, EstadoActual, dataGridViewTextBoxColumn3, Estado, User, UsuarioId });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle4.NullValue = "NULL";
            dataGridViewCellStyle4.Padding = new Padding(5);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvBitacora.DefaultCellStyle = dataGridViewCellStyle4;
            dgvBitacora.Dock = DockStyle.Fill;
            dgvBitacora.EnableHeadersVisualStyles = false;
            dgvBitacora.GridColor = Color.FromArgb(189, 215, 238);
            dgvBitacora.Location = new Point(0, 0);
            dgvBitacora.Margin = new Padding(4);
            dgvBitacora.Name = "dgvBitacora";
            dgvBitacora.ReadOnly = true;
            dgvBitacora.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(102, 102, 102);
            dataGridViewCellStyle5.SelectionBackColor = Color.Transparent;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvBitacora.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvBitacora.RowHeadersWidth = 30;
            dgvBitacora.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvBitacora.RowTemplate.Height = 50;
            dgvBitacora.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBitacora.Size = new Size(850, 470);
            dgvBitacora.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarFont = new Font("Itim", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker1.Location = new Point(30, 158);
            dateTimePicker1.Margin = new Padding(4);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(249, 27);
            dateTimePicker1.TabIndex = 47;
            dateTimePicker1.Visible = false;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CalendarFont = new Font("Itim", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker2.Location = new Point(332, 158);
            dateTimePicker2.Margin = new Padding(4);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(249, 27);
            dateTimePicker2.TabIndex = 48;
            dateTimePicker2.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 120);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(93, 20);
            label1.TabIndex = 50;
            label1.Text = "Fecha Inicial:";
            label1.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(332, 120);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 51;
            label2.Text = "Fecha final:";
            label2.Visible = false;
            // 
            // panelBusqueda
            // 
            panelBusqueda.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelBusqueda.BackColor = Color.FromArgb(189, 215, 238);
            panelBusqueda.Controls.Add(txtBuscar);
            panelBusqueda.Location = new Point(30, 62);
            panelBusqueda.Margin = new Padding(4);
            panelBusqueda.Name = "panelBusqueda";
            panelBusqueda.Size = new Size(896, 54);
            panelBusqueda.TabIndex = 54;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.BorderStyle = BorderStyle.None;
            txtBuscar.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(22, 15);
            txtBuscar.Margin = new Padding(4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar Usuarios...";
            txtBuscar.Size = new Size(851, 24);
            txtBuscar.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 101F));
            tableLayoutPanel1.Controls.Add(btnNuevoRol, 0, 0);
            tableLayoutPanel1.Controls.Add(btnSalir, 1, 0);
            tableLayoutPanel1.Location = new Point(30, 754);
            tableLayoutPanel1.Margin = new Padding(4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(309, 55);
            tableLayoutPanel1.TabIndex = 55;
            // 
            // btnNuevoRol
            // 
            btnNuevoRol.BackColor = Color.FromArgb(149, 195, 172);
            btnNuevoRol.Dock = DockStyle.Fill;
            btnNuevoRol.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNuevoRol.ForeColor = SystemColors.ButtonFace;
            btnNuevoRol.Location = new Point(4, 4);
            btnNuevoRol.Margin = new Padding(4);
            btnNuevoRol.Name = "btnNuevoRol";
            btnNuevoRol.Size = new Size(200, 47);
            btnNuevoRol.TabIndex = 17;
            btnNuevoRol.Text = "Imprimir Reporte";
            btnNuevoRol.UseVisualStyleBackColor = false;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(148, 168, 187);
            btnSalir.Dock = DockStyle.Fill;
            btnSalir.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.White;
            btnSalir.ImageAlign = ContentAlignment.TopCenter;
            btnSalir.Location = new Point(212, 4);
            btnSalir.Margin = new Padding(4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(93, 47);
            btnSalir.TabIndex = 18;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewTextBoxColumn1.DataPropertyName = "IdBitacoraEmpleado";
            dataGridViewCellStyle3.Font = new Font("Itim", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.Padding = new Padding(0, 1, 0, 0);
            dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewTextBoxColumn1.FillWeight = 50F;
            dataGridViewTextBoxColumn1.HeaderText = "Id";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Visible = false;
            dataGridViewTextBoxColumn1.Width = 65;
            // 
            // Fecha
            // 
            Fecha.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Fecha.DataPropertyName = "FechaHora";
            Fecha.FillWeight = 70F;
            Fecha.HeaderText = "Fecha";
            Fecha.MinimumWidth = 6;
            Fecha.Name = "Fecha";
            Fecha.ReadOnly = true;
            Fecha.Width = 95;
            // 
            // aliasUsuario
            // 
            aliasUsuario.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            aliasUsuario.DataPropertyName = "NombreEmpleado";
            aliasUsuario.HeaderText = "Nombre";
            aliasUsuario.MinimumWidth = 6;
            aliasUsuario.Name = "aliasUsuario";
            aliasUsuario.ReadOnly = true;
            aliasUsuario.Width = 116;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewTextBoxColumn2.DataPropertyName = "AccionRealizada";
            dataGridViewTextBoxColumn2.FillWeight = 60F;
            dataGridViewTextBoxColumn2.HeaderText = "Accion";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Width = 104;
            // 
            // Modulo
            // 
            Modulo.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Modulo.DataPropertyName = "Modulo";
            Modulo.FillWeight = 60F;
            Modulo.HeaderText = "Modulo";
            Modulo.MinimumWidth = 6;
            Modulo.Name = "Modulo";
            Modulo.ReadOnly = true;
            Modulo.Width = 111;
            // 
            // EstadoAnterior
            // 
            EstadoAnterior.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            EstadoAnterior.DataPropertyName = "EstadoAnterior";
            EstadoAnterior.FillWeight = 80F;
            EstadoAnterior.HeaderText = "Estado Anterior";
            EstadoAnterior.MinimumWidth = 6;
            EstadoAnterior.Name = "EstadoAnterior";
            EstadoAnterior.ReadOnly = true;
            EstadoAnterior.Width = 167;
            // 
            // EstadoActual
            // 
            EstadoActual.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            EstadoActual.DataPropertyName = "EstadoActual";
            EstadoActual.FillWeight = 80F;
            EstadoActual.HeaderText = "Estado Actual";
            EstadoActual.MinimumWidth = 6;
            EstadoActual.Name = "EstadoActual";
            EstadoActual.ReadOnly = true;
            EstadoActual.Width = 153;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewTextBoxColumn3.DataPropertyName = "CampoAfectado";
            dataGridViewTextBoxColumn3.FillWeight = 80F;
            dataGridViewTextBoxColumn3.HeaderText = "Campo Afectado";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn3.Width = 174;
            // 
            // Estado
            // 
            Estado.DataPropertyName = "NombreHost";
            Estado.FillWeight = 60F;
            Estado.HeaderText = "NombreEmpleado Host";
            Estado.MinimumWidth = 6;
            Estado.Name = "Estado";
            Estado.ReadOnly = true;
            // 
            // User
            // 
            User.DataPropertyName = "UsuarioHost";
            User.HeaderText = "Usuario del Host";
            User.MinimumWidth = 6;
            User.Name = "User";
            User.ReadOnly = true;
            // 
            // UsuarioId
            // 
            UsuarioId.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            UsuarioId.DataPropertyName = "IdUsuario";
            UsuarioId.HeaderText = "Usuarioid";
            UsuarioId.MinimumWidth = 6;
            UsuarioId.Name = "UsuarioId";
            UsuarioId.ReadOnly = true;
            UsuarioId.Visible = false;
            UsuarioId.Width = 129;
            // 
            // frmBitacora
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(958, 849);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panelBusqueda);
            Controls.Add(panBarraControl);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "frmBitacora";
            Text = "frmBitacora";
            Load += frmBitacora_Load;
            panBarraControl.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBitacora).EndInit();
            panelBusqueda.ResumeLayout(false);
            panelBusqueda.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel10;
        private DataGridView dgvBitacora;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label label1;
        private Label label2;
        private Panel panel3;
        public Label lblNombreModulo;
        private Panel panelBusqueda;
        private TextBox txtBuscar;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnNuevoRol;
        private Button btnSalir;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn Fecha;
        private DataGridViewTextBoxColumn aliasUsuario;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn Modulo;
        private DataGridViewTextBoxColumn EstadoAnterior;
        private DataGridViewTextBoxColumn EstadoActual;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn Estado;
        private DataGridViewTextBoxColumn User;
        private DataGridViewTextBoxColumn UsuarioId;
    }
}