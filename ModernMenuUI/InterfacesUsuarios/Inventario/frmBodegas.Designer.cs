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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
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
            panel1.Location = new Point(74, 56);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(874, 352);
            panel1.TabIndex = 34;
            // 
            // dgvProducto
            // 
            dgvProducto.AllowUserToAddRows = false;
            dgvProducto.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dgvProducto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvProducto.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProducto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducto.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvProducto.BackgroundColor = Color.FromArgb(189, 215, 238);
            dgvProducto.BorderStyle = BorderStyle.None;
            dgvProducto.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProducto.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvProducto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvProducto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducto.Columns.AddRange(new DataGridViewColumn[] { Codigo, Bodega, Departamento, Direccion, Telefono, EstadoBodega });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(87, 99, 110);
            dataGridViewCellStyle3.NullValue = "(Vacío)";
            dataGridViewCellStyle3.Padding = new Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvProducto.DefaultCellStyle = dataGridViewCellStyle3;
            dgvProducto.EnableHeadersVisualStyles = false;
            dgvProducto.GridColor = Color.FromArgb(189, 215, 238);
            dgvProducto.Location = new Point(16, 16);
            dgvProducto.Margin = new Padding(4, 3, 4, 3);
            dgvProducto.Name = "dgvProducto";
            dgvProducto.ReadOnly = true;
            dgvProducto.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(220, 230, 241);
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(102, 102, 102);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(148, 168, 187);
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvProducto.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvProducto.RowHeadersWidth = 30;
            dgvProducto.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvProducto.RowTemplate.Height = 50;
            dgvProducto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducto.Size = new Size(841, 300);
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
            Bodega.Width = 98;
            // 
            // Departamento
            // 
            Departamento.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Departamento.DataPropertyName = "NombreDepartamento";
            Departamento.HeaderText = "Departamento";
            Departamento.MinimumWidth = 6;
            Departamento.Name = "Departamento";
            Departamento.ReadOnly = true;
            Departamento.Width = 145;
            // 
            // Direccion
            // 
            Direccion.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Direccion.DataPropertyName = "NombrePresentacion";
            Direccion.HeaderText = "Dirección";
            Direccion.MinimumWidth = 6;
            Direccion.Name = "Direccion";
            Direccion.ReadOnly = true;
            Direccion.Width = 108;
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
            flowLayoutPanel1.Location = new Point(11, 414);
            flowLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(338, 80);
            flowLayoutPanel1.TabIndex = 45;
            // 
            // btnCrearBodega
            // 
            btnCrearBodega.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCrearBodega.BackColor = Color.FromArgb(149, 195, 172);
            btnCrearBodega.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCrearBodega.ForeColor = Color.White;
            btnCrearBodega.ImageAlign = ContentAlignment.TopCenter;
            btnCrearBodega.Location = new Point(4, 3);
            btnCrearBodega.Margin = new Padding(4, 3, 4, 3);
            btnCrearBodega.Name = "btnCrearBodega";
            btnCrearBodega.Size = new Size(159, 48);
            btnCrearBodega.TabIndex = 42;
            btnCrearBodega.Text = "Crear Bodega";
            btnCrearBodega.UseVisualStyleBackColor = false;
            btnCrearBodega.Click += btnCrearBodega_Click;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSalir.BackColor = Color.FromArgb(148, 168, 187);
            btnSalir.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.White;
            btnSalir.ImageAlign = ContentAlignment.TopCenter;
            btnSalir.Location = new Point(171, 3);
            btnSalir.Margin = new Padding(4, 3, 4, 3);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(159, 48);
            btnSalir.TabIndex = 39;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // frmBodegas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1034, 519);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmBodegas";
            Text = "frmBodegas";
            FormClosed += frmBodegas_FormClosed;
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