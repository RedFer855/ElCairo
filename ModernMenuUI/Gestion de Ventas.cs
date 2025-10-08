using Microsoft.VisualBasic.ApplicationServices;
using ModernMenuUI.Properties;
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
    public partial class Gestion_de_Ventas : Form
    {
        public Gestion_de_Ventas()
        {
            InitializeComponent();


            CargarDatos();
            // ===== ESTILO BARRA LATERAL (RowHeader) =====
            dgvProductos.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#DCE6F1");
            dgvProductos.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#57636e");
            dgvProductos.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            Clase_Animaciones.ActivarDoubleBuffering(dgvCarrito);
            

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void buscar_Click(object sender, EventArgs e)
        {

        }
        private void CargarDatos()
        {
            // Primero, permite que se ajusten todas
            dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;



            dgvProductos.Rows.Clear(); // Limpia las filas actuales

            dgvProductos.Rows.Add(1, "Manzana", 10, 20);
            dgvProductos.Rows.Add(2, "Pan", 5, 4);
            dgvProductos.Rows.Add(3, "Leche", 8, 70);
            dgvProductos.Rows.Add(4, "Manzana", 10, 4);
            dgvProductos.Rows.Add(5, "Pan", 5, 7);
            dgvProductos.Rows.Add(6, "Leche", 8, 4);
            dgvProductos.Rows.Add(7, "Arroz", 8, 4);

            Image Eliminar = Image.FromFile("C:\\Users\\fbara\\OneDrive\\Desktop\\PROYECTOS\\ModernMenuUI - copia\\ModernMenuUI\\Resources\\eliminar (1).png");
            Image Restar = Image.FromFile("C:\\Users\\fbara\\OneDrive\\Desktop\\PROYECTOS\\ModernMenuUI - copia\\ModernMenuUI\\Resources\\signo-menos (1).png");
            Image Sumar = Image.FromFile("C:\\Users\\fbara\\OneDrive\\Desktop\\PROYECTOS\\ModernMenuUI - copia\\ModernMenuUI\\Resources\\mas (2).png");

            dgvCarrito.Rows.Add(1, "Manzana Manzana, Manazana", 10, 20, Eliminar, Restar, Sumar);
            dgvCarrito.Rows.Add(2, "Pan", 5, 4, Eliminar, Restar, Sumar);
            dgvCarrito.Rows.Add(3, "Leche", 8, 70, Eliminar, Restar, Sumar);
            dgvCarrito.Rows.Add(4, "Manzana", 10, 4, Eliminar, Restar, Sumar);
            dgvCarrito.Rows.Add(5, "Pan", 5, 7, Eliminar, Restar, Sumar);
            dgvCarrito.Rows.Add(6, "Leche", 8, 4, Eliminar, Restar, Sumar);
            dgvCarrito.Rows.Add(7, "Arroz", 8, 4, Eliminar, Restar, Sumar);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null && dgvProductos.CurrentRow.Selected)
            {
                // Mostrar el valor de la columna "Nombre"

                txtProducto.Text = dgvProductos.CurrentRow.Cells["Producto"].Value.ToString();
                txtPrecio.Text = dgvProductos.CurrentRow.Cells["Precio"].Value.ToString();
            }
            else
            {
                // Si no hay fila seleccionada, dejar vacío
                txtProducto.Text = "";
                txtPrecio.Text = "";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dgvCarrito_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
