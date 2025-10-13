using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI
{
    public partial class Gestion_de_Compra : Form
    {
        public Gestion_de_Compra()
        {
            InitializeComponent();
            dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvProductos.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#DCE6F1");
            dgvProductos.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#57636e");
            dgvProductos.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvProductos.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvProductos.Rows.Clear(); // Limpia las filas actuales

            dgvProductos.DefaultCellStyle.ForeColor = Color.DimGray;

            dgvProductos.Rows.Add(1, "Manzana", 10, 20);
            dgvProductos.Rows.Add(2, "Pan", 5, 43);
            dgvProductos.Rows.Add(3, "Leche", 8, 70);
            dgvProductos.Rows.Add(4, "Pera", 10, 29);
            dgvProductos.Rows.Add(5, "Semitas", 5, 89);
            dgvProductos.Rows.Add(6, "Ensure", 8, 48);
            dgvProductos.Rows.Add(7, "Bolsa de Frijoles", 8, 90);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            Clase_Animaciones.NombreMenuPrincipal();
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }
    }
}
