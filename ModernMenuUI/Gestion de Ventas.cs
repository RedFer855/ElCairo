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
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.UserPaint |
                 ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();


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

            Image Eliminar = Properties.Resources.eliminar__1_;
            Image Restar = Properties.Resources.signo_menos__1_;
            Image Sumar = Properties.Resources.mas__2_;

            dgvCarrito.Rows.Add(1, "Manzana", 10, 20, Eliminar, Restar, Sumar);
            dgvCarrito.Rows.Add(2, "Pan", 5, 4, Eliminar, Restar, Sumar);
            dgvCarrito.Rows.Add(3, "Leche", 8, 70, Eliminar, Restar, Sumar);
            dgvCarrito.Rows.Add(4, "Manzana", 10, 4, Eliminar, Restar, Sumar);
            dgvCarrito.Rows.Add(5, "Pan", 5, 7, Eliminar, Restar, Sumar);
            dgvCarrito.Rows.Add(6, "Leche", 8, 4, Eliminar, Restar, Sumar);
            dgvCarrito.Rows.Add(7, "Arroz", 8, 4, Eliminar, Restar, Sumar);
        }

       

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null && dgvProductos.CurrentRow.Selected)
            {
                txtProducto.Text = dgvProductos.CurrentRow.Cells[1].Value.ToString(); // Descripción
                txtPrecio.Text = dgvProductos.CurrentRow.Cells[2].Value.ToString();   // Precio
                txtCodigo.Text = dgvProductos.CurrentRow.Cells[0].Value.ToString();    // Código
            }
            else
            {
                txtProducto.Text = "";
                txtPrecio.Text = "";
                txtCodigo.Text = "";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dgvCarrito_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            
        }


        private void dgvCarrito_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 4)
            {
                dgvCarrito[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.LightBlue;
            }
        }

        private void dgvCarrito_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 4)
            {
                dgvCarrito[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;
            }
        }

        private void dgvCarrito_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex == 5) // columna específica
            {
                dgvCarrito[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Gray; // color oscuro al presionar
            }


        }

        private void dgvCarrito_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {


            if (e.RowIndex >= 0 && e.RowIndex < dgvCarrito.RowCount && e.ColumnIndex >= 4 && e.ColumnIndex <= 6 && e.ColumnIndex < dgvCarrito.ColumnCount)
            {
                // Restaurar color si lo necesitas
                dgvCarrito[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;

                // Quitar la selección solo de esa celda
                dgvCarrito[e.ColumnIndex, e.RowIndex].Selected = false;

            }

        }

        private void dgvCarrito_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvCarrito.RowCount)
                return;

            int stock = 0;

            // Obtener el stock del producto desde dgvProductos
            int codigoProducto = Convert.ToInt32(dgvCarrito.Rows[e.RowIndex].Cells[0].Value);
            for (int i = 0; i < dgvProductos.Rows.Count; i++)
            {
                if ((int)dgvProductos.Rows[i].Cells[0].Value == codigoProducto)
                {
                    stock = Convert.ToInt32(dgvProductos.Rows[i].Cells[3].Value);
                    break;
                }
            }

            // Columna eliminar
            if (e.ColumnIndex == 4)
            {
                if (dgvCarrito.CurrentRow != null)
                    dgvCarrito.Rows.Remove(dgvCarrito.CurrentRow);
            }

            // Columna restar
            if (e.ColumnIndex == 5)
            {
                int cantidad = Convert.ToInt32(dgvCarrito.Rows[e.RowIndex].Cells[3].Value);
                if (cantidad > 1)
                    dgvCarrito.Rows[e.RowIndex].Cells[3].Value = cantidad - 1;
                else
                    MessageBox.Show("La cantidad no puede ser menor a 1", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Columna sumar
            if (e.ColumnIndex == 6)
            {
                int cantidad = Convert.ToInt32(dgvCarrito.Rows[e.RowIndex].Cells[3].Value);

                if (cantidad < stock)
                {
                    dgvCarrito.Rows[e.RowIndex].Cells[3].Value = cantidad + 1;
                }
                else
                {
                    MessageBox.Show($"Stock insuficiente. Solo hay {stock} unidades disponibles.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void AgregarAlCarrito(int codigoProducto, int cantidadAgregar)
        {
            Image Eliminar = Properties.Resources.eliminar__1_;
            Image Restar = Properties.Resources.signo_menos__1_;
            Image Sumar = Properties.Resources.mas__2_;

            // Buscar producto en dgvProductos
            DataGridViewRow producto = null;
            for (int i = 0; i < dgvProductos.Rows.Count; i++)
            {
                if ((int)dgvProductos.Rows[i].Cells[0].Value == codigoProducto)
                {
                    producto = dgvProductos.Rows[i];
                    break;
                }
            }

            if (producto == null)
            {
                MessageBox.Show("Producto no encontrado.");
                return;
            }

            string descripcion = producto.Cells[1].Value.ToString();
            decimal precio = Convert.ToDecimal(producto.Cells[2].Value);
            int stock = Convert.ToInt32(producto.Cells[3].Value);

            // Revisar si ya está en el carrito
            for (int i = 0; i < dgvCarrito.Rows.Count; i++)
            {
                if ((int)dgvCarrito.Rows[i].Cells[0].Value == codigoProducto)
                {
                    int cantidadActual = Convert.ToInt32(dgvCarrito.Rows[i].Cells[3].Value);
                    int nuevaCantidad = cantidadActual + cantidadAgregar;

                    if (nuevaCantidad > stock)
                    {
                        dgvCarrito.Rows[i].Cells[3].Value = stock;
                        MessageBox.Show($"Stock insuficiente. Solo hay {stock} unidades disponibles.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        dgvCarrito.Rows[i].Cells[3].Value = nuevaCantidad;
                    }

                    return;
                }
            }

            // Si no está en el carrito, agregar nueva fila
            int cantidadFinal = cantidadAgregar;
            if (cantidadFinal > stock)
            {
                cantidadFinal = stock;
                MessageBox.Show($"Stock insuficiente. Solo hay {stock} unidades disponibles.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            dgvCarrito.Rows.Add(codigoProducto, descripcion, precio, cantidadFinal, Eliminar, Restar, Sumar);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarAlCarrito(Convert.ToInt32(txtCodigo.Text), Convert.ToInt32(txtCantidad.Text));
        }
    }
}

