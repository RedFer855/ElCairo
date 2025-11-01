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
    public partial class frmInventarioBodega : Form
    {
        public frmInventarioBodega()
        {
            InitializeComponent();
            Random rnd = new Random();

            dgvProductos.Rows.Add(1, "Manzana", "Frutas", "Cfruit", 10, 5, "Bodega 1");
            dgvProductos.Rows.Add(2, "Pera", "Frutas", "Cfruit", 3, 4, "Bodega 2");
            dgvProductos.Rows.Add(3, "Banana", "Frutas", "Cfruit", 15, 6, "Bodega 3");
            dgvProductos.Rows.Add(4, "Lechuga", "Verduras", "Veggy", 20, 8, "Bodega 4");
            dgvProductos.Rows.Add(5, "Tomate", "Verduras", "Veggy", 25, 10, "Bodega 1");
            dgvProductos.Rows.Add(6, "Cebolla", "Verduras", "Veggy", 18, 6, "Bodega 2");
            dgvProductos.Rows.Add(7, "Arroz", "Cereales", "GranoPlus", 30, 12, "Bodega 3");
            dgvProductos.Rows.Add(8, "Frijol", "Cereales", "GranoPlus", 22, 10, "Bodega 4");
            dgvProductos.Rows.Add(9, "Lenteja", "Cereales", "GranoPlus", 16, 8, "Bodega 1");
            dgvProductos.Rows.Add(10, "Leche", "Lácteos", "Lacto", 12, 4, "Bodega 2");
            dgvProductos.Rows.Add(11, "Queso", "Lácteos", "Lacto", 14, 5, "Bodega 3");
            dgvProductos.Rows.Add(12, "Yogurt", "Lácteos", "Lacto", 18, 7, "Bodega 4");
            dgvProductos.Rows.Add(13, "Pan", "Panadería", "Bake", 25, 10, "Bodega 1");
            dgvProductos.Rows.Add(14, "Galleta", "Panadería", "Bake", 30, 12, "Bodega 2");
            dgvProductos.Rows.Add(15, "Chocolate", "Dulces", "Sweet", 20, 8, "Bodega 3");
            dgvProductos.Rows.Add(16, "Caramelo", "Dulces", "Sweet", 35, 15, "Bodega 4");
            dgvProductos.Rows.Add(17, "Refresco", "Bebidas", "DrinkIt", 28, 10, "Bodega 1");
            dgvProductos.Rows.Add(18, "Jugo", "Bebidas", "DrinkIt", 24, 9, "Bodega 2");
            dgvProductos.Rows.Add(19, "Agua", "Bebidas", "DrinkIt", 40, 20, "Bodega 3");
            dgvProductos.Rows.Add(20, "Café", "Bebidas", "CafePlus", 15, 6, "Bodega 4");
            cmbBodega.Items.Add("Todas");
            cmbBodega.Items.Add("Bodega 1");
            cmbBodega.Items.Add("Bodega 2");
            cmbBodega.Items.Add("Bodega 3");
            cmbBodega.Items.Add("Bodega 4");
            cmbBodega.SelectedIndex = 0;

            cmbEstado.Items.Add("Todos");
            cmbEstado.Items.Add("Bajo");     // rojo
            cmbEstado.Items.Add("Medio");    // amarillo
            cmbEstado.Items.Add("Alto");     // verde
            cmbEstado.SelectedIndex = 0;


        }

        // ======== MÉTODO PARA COLOREAR FILAS =========
        void FiltrarYColorear()
        {
            string bodegaSeleccionada = cmbBodega.SelectedItem?.ToString() ?? "Todas";
            string estadoSeleccionado = cmbEstado.SelectedItem?.ToString() ?? "Todos";

            foreach (DataGridViewRow fila in dgvProductos.Rows)
            {
                if (fila.IsNewRow) continue;

                string bodega = fila.Cells["Bodega"].Value.ToString();
                int stockActual = Convert.ToInt32(fila.Cells[4].Value);
                int stockMinimo = Convert.ToInt32(fila.Cells[5].Value);

                // Determinar color lógico
                string estadoFila = "";
                if (stockActual < stockMinimo)
                    estadoFila = "Bajo";
                else if (stockActual >= stockMinimo && stockActual <= stockMinimo + 10)
                    estadoFila = "Medio";
                else
                    estadoFila = "Alto";


                // Aplicar visibilidad según filtros
                bool visiblePorBodega = (bodegaSeleccionada == "Todas" || bodega == bodegaSeleccionada);
                bool visiblePorEstado = (estadoSeleccionado == "Todos" || estadoFila == estadoSeleccionado);
                fila.Visible = visiblePorBodega && visiblePorEstado;

                // Aplicar color solo si es visible
                if (fila.Visible)
                {
                    if (estadoFila == "Bajo")
                        fila.DefaultCellStyle.BackColor = Color.FromArgb(255, 221, 221); //Rojo
                    else if (estadoFila == "Medio")
                        fila.DefaultCellStyle.BackColor = Color.FromArgb(252, 239, 220); // Amarillo
                    else if (estadoFila == "Alto")
                        fila.DefaultCellStyle.BackColor = Color.FromArgb(223, 244, 216); // Verde
                    else
                        MessageBox.Show("Nuevo estado");
                }
            }
        }


        // ======== FILTRAR AL CAMBIAR LA BODEGA =========

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            this.Close();
        }

        private void cmbBodega_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBodega.SelectedItem == null) return;

            string seleccion = cmbBodega.SelectedItem.ToString();

            foreach (DataGridViewRow fila in dgvProductos.Rows)
            {
                if (fila.IsNewRow) continue;
                string bodega = fila.Cells["Bodega"].Value.ToString();
                fila.Visible = (seleccion == "Todas" || bodega == seleccion);
            }
            FiltrarYColorear();
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarYColorear();
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCambioBodega_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
