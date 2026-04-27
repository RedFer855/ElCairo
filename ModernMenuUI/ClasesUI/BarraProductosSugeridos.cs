using CapaDeDatos.Modelados.Paginacion;
using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI.ClasesUI
{

    public partial class BarraProductosSugeridos : UserControl
    {

        // Agregar esta propiedad pública
        public bool ModoTabular { get; set; } = false;

        private readonly InventarioRepositorio _inventarioRepo = new InventarioRepositorio();

        public event EventHandler<Producto> ProductoSeleccionado;

        public BarraProductosSugeridos()
        {
            InitializeComponent();
        }

        // =========================================================
        // CARGA MÁS VENDIDOS
        // =========================================================
        public async Task CargarMasVendidosAsync(int idBodega, int limite = 20)
        {
            lblTitulo.Text = "⭐ Productos más vendidos";

            try
            {
                var populares = await _inventarioRepo
                    .ObtenerMasVendidosBodegaAsync(idBodega, limite);

                // DEBUG TEMPORAL — ver qué campos llegan
                if (populares.Count > 0)
                {
                    var p = populares[0];
                    System.Diagnostics.Debug.WriteLine(
                        $"Primer popular: Nombre={p.NombreProducto} " +
                        $"Marca={p.NombreMarca} " +
                        $"Contenido={p.Contenido} " +
                        $"Precio={p.PrecioVenta} " +
                        $"Stock={p.StockActual}");
                }

                var productos = populares.Select(pp => new Producto
                {
                    IdProducto = pp.IdProducto,
                    CodigoBarraProducto = pp.CodigoBarra,
                    NombreProducto = string.Join(" ", new[]
                    {
                        pp.NombreProducto,   // ← 1. Nombre
                        pp.NombreMarca,      // ← 2. Marca
                        pp.Contenido         // ← 3. Contenido
                    }.Where(s => !string.IsNullOrWhiteSpace(s))),
                                    ImagenProducto = pp.ImagenUrl,
                                    PrecioVenta = pp.PrecioVenta,
                                    StockEnBodega = pp.StockActual
                }).ToList();

                await MostrarProductosAsync(productos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error más vendidos: " + ex.Message);
                MostrarVacio();
            }
        }

        // =========================================================
        // MOSTRAR SUGERENCIAS DEL BUSCADOR
        // =========================================================
        public async Task MostrarSugerenciasAsync(List<Producto> productos)
        {
            lblTitulo.Text = $"🔍 {productos?.Count ?? 0} resultado(s)";
            await MostrarProductosAsync(productos);
        }

        // =========================================================
        // MOSTRAR LISTA DE PRODUCTOS
        // =========================================================
        private async Task MostrarProductosAsync(List<Producto> productos)
        {
            LimpiarItems();

            if (productos == null || productos.Count == 0)
            {
                MostrarVacio();
                return;
            }

            lblVacio.Visible = false;
            flowContenedor.Visible = false; // ocultar mientras carga

            var tareas = new List<Task>();

            foreach (var p in productos)
            {
                var item = new ProductoSugerenciaItem
                {
                    Margin = new Padding(3, 3, 3, 3)
                };

                item.ProductoAgregado += (s, prod) =>
                    ProductoSeleccionado?.Invoke(this, prod);

                flowContenedor.Controls.Add(item);
                tareas.Add(item.CargarAsync(p));
            }

            // Esperar que carguen todas las imágenes
            await Task.WhenAll(tareas);

            // Asignar ancho correcto a todos una sola vez
            flowContenedor.Visible = true;
            flowContenedor.PerformLayout();

            if (ModoTabular)
            {
                // Modo grid: ancho fijo por tarjeta, FlowLayoutPanel envuelve solo
                foreach (Control ctrl in flowContenedor.Controls)
                    ctrl.Width = 440; // ← ancho de tarjeta en grid
            }
            else
            {
                // Modo lista: ancho completo (comportamiento actual en ventas)
                int anchoItem = flowContenedor.ClientSize.Width
                                - SystemInformation.VerticalScrollBarWidth - 10;
                foreach (Control ctrl in flowContenedor.Controls)
                    ctrl.Width = anchoItem;
            }
        }

        // =========================================================
        // HELPERS
        // =========================================================
        private void LimpiarItems()
        {
            foreach (Control ctrl in flowContenedor.Controls)
                ctrl.Dispose();
            flowContenedor.Controls.Clear();
        }

        private void MostrarVacio()
        {
            LimpiarItems();
            lblVacio.Visible = true;
            flowContenedor.Visible = false;
        }

        public void Limpiar()
        {
            LimpiarItems();
            lblTitulo.Text = "⭐ Productos más vendidos";
        }
    }
}