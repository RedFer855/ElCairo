namespace ModernMenuUI.InterfacesUsuarios.Inventario
{
    partial class frmBodegas
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            panel1 = new Panel();
            dgvProducto = new DataGridView();
            Codigo = new DataGridViewTextBoxColumn();
            Bodega = new DataGridViewTextBoxColumn();
            Departamento = new DataGridViewTextBoxColumn();
            Direccion = new DataGridViewTextBoxColumn();
            Telefono = new DataGridViewTextBoxColumn();
            EstadoBodega = new DataGridViewCheckBoxColumn();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnCrearBodega = new Button();
            btnSalir = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducto).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(189, 215, 238);
            panel1.Controls.Add(dgvProducto);
            panel1.Location = new Point(84, 75);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(999, 469);
            panel1.TabIndex = 34;
            // 
            // dgvProducto
            // 
            dgvProducto.AllowUserToAddRows = false;
            dgvProducto.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dgvProducto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvProducto.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProducto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducto.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvProducto.BackgroundColor = Color.FromArgb(189, 215, 238);
            dgvProducto.BorderStyle = BorderStyle.None;
            dgvProducto.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProducto.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle6.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvProducto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvProducto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducto.Columns.AddRange(new DataGridViewColumn[] { Codigo, Bodega, Departamento, Direccion, Telefono, EstadoBodega });
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.White;
            dataGridViewCellStyle7.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle7.NullValue = "(Vacío)";
            dataGridViewCellStyle7.Padding = new Padding(5);
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle7.SelectionForeColor = Color.White;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            dgvProducto.DefaultCellStyle = dataGridViewCellStyle7;
            dgvProducto.EnableHeadersVisualStyles = false;
            dgvProducto.GridColor = Color.FromArgb(189, 215, 238);
            dgvProducto.Location = new Point(18, 21);
            dgvProducto.Margin = new Padding(4);
            dgvProducto.Name = "dgvProducto";
            dgvProducto.ReadOnly = true;
            dgvProducto.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle8.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(102, 102, 102);
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            dgvProducto.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dgvProducto.RowHeadersWidth = 30;
            dgvProducto.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvProducto.RowTemplate.Height = 50;
            dgvProducto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducto.Size = new Size(961, 400);
            dgvProducto.TabIndex = 14;
            // 
            // Codigo
            // 
            Codigo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Codigo.DataPropertyName = "IdBodega";
            Codigo.HeaderText = "Código";
            Codigo.MinimumWidth = 130;
            Codigo.Name = "Codigo";
            Codigo.ReadOnly = true;
            Codigo.Resizable = DataGridViewTriState.False;
            Codigo.Visible = false;
            // 
            // Bodega
            // 
            Bodega.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Bodega.DataPropertyName = "NombreBodega";
            Bodega.HeaderText = "Bodega";
            Bodega.MinimumWidth = 6;
            Bodega.Name = "Bodega";
            Bodega.ReadOnly = true;
            Bodega.Resizable = DataGridViewTriState.False;
            Bodega.Width = 111;
            // 
            // Departamento
            // 
            Departamento.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Departamento.DataPropertyName = "NombreDepartamento";
            Departamento.HeaderText = "Departamento";
            Departamento.MinimumWidth = 6;
            Departamento.Name = "Departamento";
            Departamento.ReadOnly = true;
            Departamento.Width = 173;
            // 
            // Direccion
            // 
            Direccion.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Direccion.DataPropertyName = "NombrePresentacion";
            Direccion.HeaderText = "Dirección";
            Direccion.MinimumWidth = 6;
            Direccion.Name = "Direccion";
            Direccion.ReadOnly = true;
            Direccion.Width = 127;
            // 
            // Telefono
            // 
            Telefono.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Telefono.DataPropertyName = "TelefonoSucursal";
            Telefono.HeaderText = "Telefono";
            Telefono.MinimumWidth = 6;
            Telefono.Name = "Telefono";
            Telefono.ReadOnly = true;
            // 
            // EstadoBodega
            // 
            EstadoBodega.DataPropertyName = "EstadoBodega";
            EstadoBodega.HeaderText = "Estado";
            EstadoBodega.MinimumWidth = 6;
            EstadoBodega.Name = "EstadoBodega";
            EstadoBodega.ReadOnly = true;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            flowLayoutPanel1.Controls.Add(btnCrearBodega);
            flowLayoutPanel1.Controls.Add(btnSalir);
            flowLayoutPanel1.Location = new Point(13, 552);
            flowLayoutPanel1.Margin = new Padding(4);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(386, 107);
            flowLayoutPanel1.TabIndex = 45;
            // 
            // btnCrearBodega
            // 
            btnCrearBodega.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCrearBodega.BackColor = Color.FromArgb(149, 195, 172);
            btnCrearBodega.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCrearBodega.ForeColor = Color.White;
            btnCrearBodega.ImageAlign = ContentAlignment.TopCenter;
            btnCrearBodega.Location = new Point(4, 4);
            btnCrearBodega.Margin = new Padding(4);
            btnCrearBodega.Name = "btnCrearBodega";
            btnCrearBodega.Size = new Size(182, 64);
            btnCrearBodega.TabIndex = 42;
            btnCrearBodega.Text = "Crear Bodega";
            btnCrearBodega.UseVisualStyleBackColor = false;
            btnCrearBodega.Click += btnCrearBodega_Click;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSalir.BackColor = Color.FromArgb(148, 168, 187);
            btnSalir.Font = new Font("Itim", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.White;
            btnSalir.ImageAlign = ContentAlignment.TopCenter;
            btnSalir.Location = new Point(194, 4);
            btnSalir.Margin = new Padding(4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(182, 64);
            btnSalir.TabIndex = 39;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // frmBodegas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1182, 692);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmBodegas";
            Text = "frmBodegas";
            FormClosing += frmBodegas_FormClosing;
            Load += frmBodegas_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProducto).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dgvProducto;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnCrearBodega;
        private Button btnSalir;
        private DataGridViewTextBoxColumn Codigo;
        private DataGridViewTextBoxColumn Bodega;
        private DataGridViewTextBoxColumn Departamento;
        private DataGridViewTextBoxColumn Direccion;
        private DataGridViewTextBoxColumn Telefono;
        private DataGridViewCheckBoxColumn EstadoBodega;
    }
}