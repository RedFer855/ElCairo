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
using CapaDeDatos.Modelados;
using CapaDeDatos.Repositorios;

namespace ModernMenuUI
{
    public partial class frmFacturacion : Form
    {
        private readonly ProductoRepositorio _productoRepo;
        public frmFacturacion()
        {
            InitializeComponent();
            _productoRepo = new ProductoRepositorio();
            // ===== ESTILO BARRA LATERAL (RowHeader) =====
            dgvProductos.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#DCE6F1");
            dgvProductos.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#57636e");
            dgvProductos.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            clsAnmaciones.ActivarDoubleBuffering(dgvCarrito);
            clsAnmaciones.ActivarDoubleBuffering(dgvProductos);
            txtBuscar.PlaceholderText = "Buscar producto...";
            txtBuscar.ForeColor = Color.White; // Esto cambia el color del texto normal
            dgvProductos.ClearSelection();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            this.Close();
        }

        private void buscar_Click(object sender, EventArgs e)
        {

        }

        private void ActualizarTotales()
        {
            // 1. Inicia el subtotal en 0
            decimal subtotal = 0;

            // 2. Recorre cada fila en el DataGridView del carrito
            foreach (DataGridViewRow fila in dgvCarrito.Rows)
            {
                // Asegúrate de que la fila no sea nula (pasa a veces)
                if (fila.Cells[2].Value != null && fila.Cells[3].Value != null)
                {
                    // 3. Obtiene el Precio (de la celda 2) y la Cantidad (de la celda 3)
                    // (Basado en tu método AgregarAlCarrito)
                    decimal precio = Convert.ToDecimal(fila.Cells[2].Value);
                    int cantidad = Convert.ToInt32(fila.Cells[3].Value);

                    // 4. Suma el total de esta fila al subtotal general
                    subtotal += (precio * cantidad);
                }
            }

            // 5. Muestra los resultados en los TextBoxes
            // "N2" formatea el número con 2 decimales (ej. "150.00")
            txtSubtotal.Text = subtotal.ToString("N2");

            // Como aún no manejamos impuestos, el Total es igual al Subtotal
            txtTotal.Text = subtotal.ToString("N2");

            // Dejamos el impuesto en 0 por ahora
            txtImpuesto.Text = (0.00).ToString("N2");
        }

        private async Task CargarProductosAsync()
        {
            try
            {
                // Llama al repositorio para obtener los productos reales
                List<Producto> listaDeProductos = await _productoRepo.ObtenerTodosLosProductos();

                dgvProductos.Rows.Clear(); // Limpia las filas (como ya hacías)

                if (listaDeProductos != null)
                {
                    // Recorre la lista de productos y los añade uno por uno
                    // Esto mantiene tu lógica de 'Cells[x].Value' funcionando
                    foreach (var producto in listaDeProductos)
                    {
                        // Asegúrate de que el orden sea el mismo que en tu 'CargarDatos'
                        // (Código, Producto, Precio, Stock)
                        dgvProductos.Rows.Add(
                            producto.IdProducto,
                            producto.NombreProducto,
                            producto.PrecioVenta, // Usa el Precio de Venta
                            producto.CantidadProducto // Este es el Stock
                        );
                    }
                }
                dgvProductos.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                ActualizarTotales();
            }

            // Columna restar
            if (e.ColumnIndex == 5)
            {
                int cantidad = Convert.ToInt32(dgvCarrito.Rows[e.RowIndex].Cells[3].Value);
                if (cantidad > 1)
                {
                    dgvCarrito.Rows[e.RowIndex].Cells[3].Value = cantidad - 1;
                    ActualizarTotales();
                }
                else
                {
                    MessageBox.Show("La cantidad no puede ser menor a 1", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }


            // Columna sumar
            if (e.ColumnIndex == 6)
            {
                int cantidad = Convert.ToInt32(dgvCarrito.Rows[e.RowIndex].Cells[3].Value);

                if (cantidad < stock)
                {
                    dgvCarrito.Rows[e.RowIndex].Cells[3].Value = cantidad + 1;
                    ActualizarTotales();
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
            if (nudCantidad.Value <= 0)
            {
                MessageBox.Show($"No puede ingresar 0 o negativo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (nudCantidad.Value <= 0 || txtCodigo.Text == "" && txtProducto.Text == "")
                    MessageBox.Show($"Por favor seleccione un Producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    AgregarAlCarrito(Convert.ToInt32(txtCodigo.Text), Convert.ToInt32(nudCantidad.Text));
                nudCantidad.Value = 1;
                txtCodigo.Text = null;
                txtProducto.Text = null;
                dgvProductos.ClearSelection();
                txtPrecio.Text = null;
                ActualizarTotales();
                ActualizarImagenCarrito();
            }


        }

        private void dgvCarrito_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                // Solo recalcular si cambia la columna de cantidad (3) o precio (2)
                if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
                {
                    double precio = Convert.ToDouble(dgvCarrito.Rows[e.RowIndex].Cells[2].Value);
                    double cantidad = Convert.ToDouble(dgvCarrito.Rows[e.RowIndex].Cells[3].Value);
                }
            }
        }

        private void ActualizarImagenCarrito()
        {
            // Si no hay filas visibles (ni productos)
            if (dgvCarrito.Rows.Count == 0)
            {
                pbxCarritoVacio.Visible = true;
                //lblCarritoVacio.Visible = true;
            }
            else
            {
                pbxCarritoVacio.Visible = false;
                //lblCarritoVacio.Visible = false;
            }
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private async void Gestion_de_Ventas_Load(object sender, EventArgs e)
        {
            await CargarProductosAsync();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (dgvCarrito.Rows.Count == 0)
            {
                MessageBox.Show("No hay productos en el carrito para facturar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmacion = MessageBox.Show($"¿Desea facturar un total de {txtTotal.Text}?", "Confirmar Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacion == DialogResult.No)
            {
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            try
            {
                // --- 2. GUARDAR LA VENTA (Maestra) ---
                // (Debes cambiar IdCliente, IdRutasVenta e IdEmpleado por los IDs reales 
                // de tu sistema, por ejemplo, el del empleado que está logueado)
                Venta nuevaVenta = new Venta
                {
                    FechaVenta = DateTime.Now,
                    IdCliente = 4, // (ID 1 = Consumidor Final, por defecto)
                    IdRutasVenta = 1, // (ID 1 = Ruta Mostrador, por defecto)
                    IdEmpleado = 12  // (ID 1 = Admin, por defecto)
                };

                // Llama al repositorio estático y obtiene el ID de la venta creada
                int idVentaNueva = await VentaRepositorio.InsertarVenta(nuevaVenta);


                // --- 3. GUARDAR DETALLES Y ACTUALIZAR STOCK ---
                foreach (DataGridViewRow fila in dgvCarrito.Rows)
                {
                    int idProducto = Convert.ToInt32(fila.Cells[0].Value);
                    int cantidadVendida = Convert.ToInt32(fila.Cells[3].Value);
                    decimal precioVenta = Convert.ToDecimal(fila.Cells[2].Value);

                    // --- 3A. GUARDAR DETALLE VENTA ---
                    DetalleVenta detalle = new DetalleVenta
                    {
                        IdVenta = idVentaNueva, // El ID que obtuvimos en el paso 2
                        IdProducto = idProducto,
                        CantidadVenta = cantidadVendida,
                        IdBodega = 1
                    };

                    // Llama al repositorio estático de detalles
                    await DetalleVentaRepositorio.InsertarDetalleVenta(detalle);

                    // --- 3B. ACTUALIZAR STOCK EN 'producto' ---
                    // (Llama al método que ya existe en ProductoRepositorio)
                    await _productoRepo.ActualizarStockProducto(idProducto, cantidadVendida);
                }

                // --- 4. LIMPIAR EL FORMULARIO ---
                dgvCarrito.Rows.Clear();
                ActualizarTotales();
                ActualizarImagenCarrito(); //
                MessageBox.Show("¡Venta facturada con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // --- 5. REFRESCAR LA LISTA DE PRODUCTOS ---
                // (Esto actualizará el stock en 'dgvProductos' y ocultará los 
                // productos que llegaron a 0)
                await CargarProductosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al facturar la venta: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}

