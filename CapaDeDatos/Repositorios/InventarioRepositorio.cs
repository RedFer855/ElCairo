using CapaDeDatos.Datos;
using CapaDeDatos.Modelados.Inventario;
using CapaDeDatos.Modelados.ModeladosVistas;
using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Modelados.Paginacion;
using Newtonsoft.Json;
using Supabase.Realtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Supabase.Postgrest.Constants;

namespace CapaDeDatos.Repositorios
{
    public class InventarioRepositorio
    {
        private async Task<Supabase.Client> GetClient()
        {
            return await Conexion.ConnectWithTimeoutAsync();
        }

        public async Task<List<Inventario>> ObtenerTodoElInventario(
            CancellationToken cancellationToken = default)
        {
            try
            {
                var client = await GetClient();
                var response = await client
                    .From<Inventario>()
                    .Select("*, producto(*, marca(*), categoria(*), presentacion(*)), bodega(*)")
                    .Order("id_producto", Ordering.Ascending)
                    .Get(cancellationToken);

                return response.Models ?? new List<Inventario>();
            }
            catch (OperationCanceledException ex) when (cancellationToken.IsCancellationRequested)
            {
                throw new TimeoutException(
                    "La consulta de inventario fue cancelada por timeout.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "No se pudo cargar el inventario. Verifique la conexión.", ex);
            }
        }

        public async Task<List<Producto>> ObtenerProductosDeBodega(int idBodega)
        {
            try
            {
                var supabase = await Conexion.GetClientAsync();

                var respuestaInventario = await supabase
                    .From<Inventario>()
                    .Select("*")
                    .Filter("id_bodega", Operator.Equals, idBodega)
                    .Get();

                var listaInventario = respuestaInventario.Models;
                if (listaInventario.Count == 0) return new List<Producto>();

                var idsProductos = listaInventario
                    .Select(x => x.IdProductoInventario).ToList();

                var respuestaProductos = await supabase
                    .From<Producto>()
                    .Select("*")
                    .Filter("id_producto", Operator.In, idsProductos)
                    .Order("nombre_producto", Ordering.Ascending)
                    .Get();

                var listaProductos = respuestaProductos.Models;

                foreach (var prod in listaProductos)
                {
                    var datoInventario = listaInventario
                        .FirstOrDefault(inv => inv.IdProductoInventario == prod.IdProducto);
                    if (datoInventario != null)
                        prod.StockEnBodega = datoInventario.StockProductoBodegaInventario;
                }

                return listaProductos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error cargando inventario: " + ex.Message);
            }
        }

        /// <summary>
        /// Scanner: busca UN producto exacto por código de barras
        /// SOLO si tiene stock en esta bodega.
        /// </summary>
        public async Task<Producto> BuscarPorCodigoBarraEnBodegaAsync(
            string codigoBarra, int idBodega, CancellationToken ct = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(codigoBarra)) return null;

                var client = await GetClient();
                var response = await client
                    .From<Inventario>()
                    .Select("stock_producto_bodega, producto!inner(*, marca(*), categoria(*), presentacion(*))")
                    .Filter("id_bodega", Operator.Equals, idBodega)
                    .Filter("producto.codigo_barra_producto", Operator.Equals, codigoBarra.Trim())
                    .Limit(1)
                    .Get(ct);

                var inv = response?.Models?.FirstOrDefault();
                if (inv?.producto == null) return null;

                inv.producto.StockEnBodega = inv.StockProductoBodegaInventario;
                return inv.producto;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error buscar código: " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Autocomplete: top 10 productos que coinciden con el texto
        /// y tienen stock > 0 en esta bodega.
        /// </summary>
        public async Task<List<Producto>> ObtenerSugerenciasBodegaAsync(
            string texto, int idBodega, int limite = 10,
            CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(texto)) return new List<Producto>();

            try
            {
                var client = await GetClient();

                var response = await client.Rpc("buscar_productos_bodega", new
                {
                    p_texto = texto.Trim(),
                    p_id_bodega = idBodega,
                    p_limite = limite
                });

                if (string.IsNullOrEmpty(response?.Content))
                    return new List<Producto>();

                // ← Usar System.Text.Json con PropertyNameCaseInsensitive
                var resultados = System.Text.Json.JsonSerializer
                    .Deserialize<List<BusquedaProductoResult>>(
                        response.Content,
                        new System.Text.Json.JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });

                return resultados?.Select(r => new Producto
                {
                    IdProducto = r.IdProducto,
                    NombreProducto = r.NombreProducto,
                    CodigoBarraProducto = r.CodigoBarra,
                    PrecioVenta = r.PrecioVenta,
                    ContenidoProducto = r.Contenido,
                    StockEnBodega = r.Stock
                }).ToList() ?? new List<Producto>();
            }
            catch (OperationCanceledException) { throw; }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error sugerencias: {ex.Message}");
                return new List<Producto>();
            }
        }

        /// <summary>
        /// Top N productos más vendidos en esta bodega con stock actual.
        /// </summary>
        public async Task<List<ProductoPopular>> ObtenerMasVendidosBodegaAsync(
            int idBodega, int limite = 20)
        {
            try
            {
                var client = await GetClient();
                var response = await client.Rpc("obtener_productos_mas_vendidos",
                    new { p_id_bodega = idBodega, p_limite = limite });

                if (string.IsNullOrEmpty(response?.Content))
                    return new List<ProductoPopular>();

                // DEBUG TEMPORAL — ver JSON crudo
                System.Diagnostics.Debug.WriteLine(
                    "JSON más vendidos: " + response.Content.Substring(0,
                        Math.Min(300, response.Content.Length)));

                // ← Usar Newtonsoft.Json (mismo que usa Supabase internamente)
                return JsonConvert.DeserializeObject<List<ProductoPopular>>(
                    response.Content) ?? new List<ProductoPopular>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error RPC más vendidos: " + ex.Message);
                return new List<ProductoPopular>();
            }
        }
    }

    // DTO interno para deserializar resultado de buscar_productos_bodega
    internal class BusquedaProductoResult
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string CodigoBarra { get; set; }
        public decimal PrecioVenta { get; set; }
        public string Contenido { get; set; }
        public int Stock { get; set; }
    }
}