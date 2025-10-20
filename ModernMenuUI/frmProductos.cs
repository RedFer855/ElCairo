using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI
{
    public partial class frmProductos : Form
    {
        Form formularioactivo = null;
        public frmProductos()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            // ===== ESTILO BARRA LATERAL (RowHeader) =====
            dgvProductos.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#DCE6F1");
            dgvProductos.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#57636e");
            dgvProductos.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            // Ejemplo de 20 productos distintos
            dgvProductos.Rows.Add(1, "Manzana", "Frutas", "Cfruit", 10, 5, 8.0, 8.0, 8.8);
            dgvProductos.Rows.Add(2, "Pera", "Frutas", "Cfruit", "10%", 8.0, 8.0, 8.8);
            dgvProductos.Rows.Add(3, "Banana", "Frutas", "Cfruit", "15%", 5.0, 5.0, 5.75);
            dgvProductos.Rows.Add(4, "Lechuga", "Verduras", "Veggy", "20%", 3.0, 3.0, 3.6);
            dgvProductos.Rows.Add(5, "Tomate", "Verduras", "Veggy", "12%", 4.0, 4.0, 4.48);
            dgvProductos.Rows.Add(6, "Cebolla", "Verduras", "Veggy", "10%", 2.5, 2.5, 2.75);
            dgvProductos.Rows.Add(7, "Arroz", "Cereales", "GranoPlus", "8%", 15.0, 15.0, 16.2);
            dgvProductos.Rows.Add(8, "Frijol", "Cereales", "GranoPlus", "10%", 12.0, 12.0, 13.2);
            dgvProductos.Rows.Add(9, "Lenteja", "Cereales", "GranoPlus", "12%", 14.0, 14.0, 15.68);
            dgvProductos.Rows.Add(10, "Leche", "Lácteos", "Lacto", "15%", 20.0, 20.0, 23.0);
            dgvProductos.Rows.Add(11, "Queso", "Lácteos", "Lacto", "20%", 25.0, 25.0, 30.0);
            dgvProductos.Rows.Add(12, "Yogurt", "Lácteos", "Lacto", "10%", 18.0, 18.0, 19.8);
            dgvProductos.Rows.Add(13, "Pan", "Panadería", "Bake", "12%", 10.0, 10.0, 11.2);
            dgvProductos.Rows.Add(14, "Galleta", "Panadería", "Bake", "15%", 8.0, 8.0, 9.2);
            dgvProductos.Rows.Add(15, "Chocolate", "Dulces", "Sweet", "25%", 5.0, 5.0, 6.25);
            dgvProductos.Rows.Add(16, "Caramelo", "Dulces", "Sweet", "30%", 2.0, 2.0, 2.6);
            dgvProductos.Rows.Add(17, "Refresco", "Bebidas", "DrinkIt", "20%", 10.0, 10.0, 12.0);
            dgvProductos.Rows.Add(18, "Jugo", "Bebidas", "DrinkIt", "18%", 12.0, 12.0, 14.16);
            dgvProductos.Rows.Add(19, "Agua", "Bebidas", "DrinkIt", "10%", 5.0, 5.0, 5.5);
            dgvProductos.Rows.Add(20, "Café", "Bebidas", "CafePlus", "25%", 15.0, 15.0, 18.75);

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            this.Close();
        }

        private void HoraFecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss tt", new CultureInfo("es-ES"));
            lblFecha.Text = DateTime.Now.ToString("dddd dd 'de' MMMM 'del' yyyy", new CultureInfo("es-ES"));
        }

        private void AbrirFormularioHijo(Form Formulariohijo)
        {
            Editar_Producto formHijo = new Editar_Producto();
            formHijo.StartPosition = FormStartPosition.CenterParent;

            // Evento que detecta cuando el formulario pierde foco
            formHijo.Deactivate += (s, ev) =>
            {
                System.Media.SystemSounds.Exclamation.Play(); // Sonido de advertencia
            };

            formHijo.ShowDialog(); // Modal
        }
        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new Editar_Producto());
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            btnNuevo.Enabled = dgvProductos.SelectedRows.Count > 0;
        }
    }

}
