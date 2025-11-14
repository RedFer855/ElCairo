using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supabase.Realtime;
using static Supabase.Realtime.PostgresChanges.PostgresChangesOptions;
using CapaDeDatos.Repositorios;
using CapaDeDatos.Modelados;
using CapaDeDatos.Datos;

namespace ModernMenuUI
{
    public partial class frmGestionCompra : Form
    {
        private readonly ProductoRepositorio _productoRepo;
        private Supabase.Client? _supabaseClient;
        private RealtimeChannel? _productoSubscription;
        private List<Producto> _productosCache = new List<Producto>();
        public frmGestionCompra()
        {
            InitializeComponent();
            _productoRepo = new ProductoRepositorio();
            Color grisTexto = ColorTranslator.FromHtml("#57636e");

            //dgvProductos.AutoGenerateColumns = false;  // usamos columnas manuales
            //dgvCarrito.AutoGenerateColumns = false;

            // Si quieres estilo en el RowHeader
            dgvProductos.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#DCE6F1");
            dgvProductos.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#57636e");
            dgvProductos.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvProductos.DefaultCellStyle.ForeColor = grisTexto;
            dgvProductos.DefaultCellStyle.BackColor = Color.White;
            dgvProductos.RowsDefaultCellStyle.ForeColor = grisTexto;
            dgvProductos.AlternatingRowsDefaultCellStyle.ForeColor = grisTexto;
            dgvProductos.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgvCarrito.DefaultCellStyle.ForeColor = grisTexto;
            dgvCarrito.RowsDefaultCellStyle.ForeColor = grisTexto;
            dgvCarrito.AlternatingRowsDefaultCellStyle.ForeColor = grisTexto;

            dgvProductos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 220, 240);
            dgvProductos.DefaultCellStyle.SelectionForeColor = Color.Black;

            clsAnmaciones.ActivarDoubleBuffering(dgvProductos);
            clsAnmaciones.ActivarDoubleBuffering(dgvCarrito);

            txtBuscar.PlaceholderText = "Buscar producto...";
            txtBuscar.ForeColor = Color.Black;

            dgvProductos.ClearSelection();

            this.FormClosing += frmGestionCompra_FormClosing;
           // dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //dgvProductos.Rows.Clear(); // Limpia las filas actuales

            //dgvProductos.DefaultCellStyle.ForeColor = Color.DimGray;

           
        }

        private async Task CargarProductosAsync()
        {
            try
            {
                // Traemos TODOS los productos (o solo activos si tu repo ya filtra)
                List<Producto> listaDeProductos = await _productoRepo.ObtenerTodosLosProductos();

                _productosCache = listaDeProductos ?? new List<Producto>();

                dgvProductos.Rows.Clear();

                foreach (var p in _productosCache)
                {
                    dgvProductos.Rows.Add(
                        p.IdProducto,          // Código
                        p.NombreProducto,      // Producto
                        p.PrecioCompra,        // 👈 precio de compra
                        p.CantidadProducto     // Stock (cantidad_producto)
                    );
                }

                dgvProductos.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}",
                    "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task DesecharSuscripcionProductosAsync()
        {
            if (_productoSubscription != null)
            {
                try
                {
                    await Task.Run(() => _productoSubscription.Unsubscribe());
                }
                catch { }
                _productoSubscription = null;
            }
        }

        private async Task IniciarSuscripcionProductosAsync()
        {
            await DesecharSuscripcionProductosAsync();

            try
            {
                _supabaseClient = await Conexion.ConnectWithTimeoutAsync(10);

                _productoSubscription = await _supabaseClient
                    .From<Producto>()
                    .On(ListenType.All, (sender, change) =>
                    {
                        if (!this.IsHandleCreated || this.IsDisposed)
                            return;

                        this.BeginInvoke((MethodInvoker)(async () =>
                        {
                            if (this.IsDisposed) return;
                            await CargarProductosAsync();   // recargar grid al vuelo
                        }));
                    });

                System.Diagnostics.Debug.WriteLine("Suscripción a Productos en Compras creada.");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error suscribiendo productos en Compras: {ex.Message}");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text) ||
        string.IsNullOrWhiteSpace(txtProducto.Text))
            {
                MessageBox.Show("Por favor seleccione un producto.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nudCantidad.Value <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int codigo = Convert.ToInt32(txtCodigo.Text);
            int cantidad = (int)nudCantidad.Value;

            AgregarAlCarrito(codigo, cantidad);

            // Limpiar selección / campos
            nudCantidad.Value = 1;
            txtCodigo.Text = "";
            txtProducto.Text = "";
            txtPrecio.Text = "";
            dgvProductos.ClearSelection();
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
        private async void frmGestionCompra_Load(object sender, EventArgs e)
        {
            await CargarProductosAsync();
            await IniciarSuscripcionProductosAsync();
        }

        private async void frmGestionCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            await DesecharSuscripcionProductosAsync();
        }
        private void ActualizarTotales()
        {
            decimal subtotal = 0;

            foreach (DataGridViewRow row in dgvCarrito.Rows)
            {
                if (row.IsNewRow) continue;

                decimal precio = Convert.ToDecimal(row.Cells[2].Value);   // Precio
                int cantidad = Convert.ToInt32(row.Cells[3].Value);       // Cantidad

                subtotal += precio * cantidad;
            }

            decimal impuesto = subtotal * 0.15m;
            decimal total = subtotal + impuesto;

            txtSubTotal.Text = subtotal.ToString("L0.00");
            txtImpuesto.Text = impuesto.ToString("L0.00");
            txtTotal.Text = total.ToString("L0.00");
        }
        private void AgregarAlCarrito(int codigoProducto, int cantidadAgregar)
        {
            // 🔹 Límite de productos distintos en el carrito
            int limiteProductos = 3;
            int productosActuales = dgvCarrito.Rows.Count;

            bool productoYaExiste = dgvCarrito.Rows
                .Cast<DataGridViewRow>()
                .Any(r => !r.IsNewRow && Convert.ToInt32(r.Cells[0].Value) == codigoProducto);

            if (productosActuales >= limiteProductos && !productoYaExiste)
            {
                MessageBox.Show(
                    $"Solo puedes agregar hasta {limiteProductos} productos diferentes al carrito.",
                    "Límite alcanzado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            Image Eliminar = Properties.Resources.eliminar__1_;
            Image Restar = Properties.Resources.signo_menos__1_;
            Image Sumar = Properties.Resources.mas__2_;

            // 🔹 Buscar producto en dgvProductos
            DataGridViewRow producto = dgvProductos.Rows
                .Cast<DataGridViewRow>()
                .FirstOrDefault(r => !r.IsNewRow &&
                                     Convert.ToInt32(r.Cells[0].Value) == codigoProducto);

            if (producto == null)
            {
                MessageBox.Show("Producto no encontrado.");
                return;
            }

            string descripcion = producto.Cells[1].Value.ToString();
            decimal precio = Convert.ToDecimal(producto.Cells[2].Value);
            int stock = Convert.ToInt32(producto.Cells[3].Value);

            // 🔹 Si ya está en el carrito, solo sumamos cantidad
            foreach (DataGridViewRow fila in dgvCarrito.Rows)
            {
                if (!fila.IsNewRow && Convert.ToInt32(fila.Cells[0].Value) == codigoProducto)
                {
                    int cantidadActual = Convert.ToInt32(fila.Cells[3].Value);
                    int nuevaCantidad = cantidadActual + cantidadAgregar;

                    if (nuevaCantidad > stock)
                    {
                        fila.Cells[3].Value = stock;
                        MessageBox.Show(
                            $"Stock insuficiente. Solo hay {stock} unidades disponibles.",
                            "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        fila.Cells[3].Value = nuevaCantidad;
                    }

                    ActualizarTotales();
                    ActualizarImagenCarrito();
                    return;
                }
            }

            // 🔹 Si no estaba en el carrito, agregamos nueva fila
            int cantidadFinal = cantidadAgregar;
            if (cantidadFinal > stock)
            {
                cantidadFinal = stock;
                MessageBox.Show(
                    $"Stock insuficiente. Solo hay {stock} unidades disponibles.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            dgvCarrito.Rows.Add(
                codigoProducto,
                descripcion,
                precio,
                cantidadFinal,
                Eliminar,
                Restar,
                Sumar
            );

            ActualizarTotales();
            ActualizarImagenCarrito();
        }
        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null && dgvProductos.CurrentRow.Selected)
            {
                txtCodigo.Text = dgvProductos.CurrentRow.Cells[0].Value?.ToString();
                txtProducto.Text = dgvProductos.CurrentRow.Cells[1].Value?.ToString();
                txtPrecio.Text = dgvProductos.CurrentRow.Cells[2].Value?.ToString();
            }
            else
            {
                txtCodigo.Text = "";
                txtProducto.Text = "";
                txtPrecio.Text = "";
            }
        }

        private void dgvCarrito_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvCarrito.RowCount)
                return;

            // Código del producto en el carrito
            int codigoProducto = Convert.ToInt32(dgvCarrito.Rows[e.RowIndex].Cells[0].Value);

            // Buscar stock en dgvProductos
            int stock = 0;
            foreach (DataGridViewRow fila in dgvProductos.Rows)
            {
                if (!fila.IsNewRow && Convert.ToInt32(fila.Cells[0].Value) == codigoProducto)
                {
                    stock = Convert.ToInt32(fila.Cells[3].Value); // Stock
                    break;
                }
            }

            // Eliminar
            if (e.ColumnIndex == 4)
            {
                if (dgvCarrito.CurrentRow != null)
                    dgvCarrito.Rows.Remove(dgvCarrito.CurrentRow);

                ActualizarTotales();
                ActualizarImagenCarrito();
                return;
            }

            // Restar
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
                    MessageBox.Show("La cantidad no puede ser menor a 1",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return;
            }

            // Sumar
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
                    MessageBox.Show(
                        $"Stock insuficiente. Solo hay {stock} unidades disponibles.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
