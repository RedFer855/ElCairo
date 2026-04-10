using CapaDeDatos.Datos;
using CapaDeDatos.Modelados.Inventario;
using CapaDeDatos.Modelados.ModeladosVistas;
using CapaDeDatos.Modelados.Productos;
using Supabase.Realtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Supabase.Postgrest.Constants;

namespace CapaDeDatos.Repositorios
{
    public class InventarioRepositorio
    {
        private async Task<Supabase.Client> GetClient()
        {
            return await Conexion.ConnectWithTimeoutAsync();
        }

        public async Task<List<Inventario>> ObtenerTodoElInventario(CancellationToken cancellationToken = default)
        {
            try
            {
                var client = await GetClient();
                var response = await client
                                        .From<Inventario>()
                                        .Select("*, producto(*, marca(*), categoria(*), presentacion(*)), bodega(*)")
                                        .Order("id_producto", Supabase.Postgrest.Constants.Ordering.Ascending)
                                        .Get(cancellationToken);

                return response.Models ?? new List<Inventario>();
            }
            catch (OperationCanceledException ex) when (cancellationToken.IsCancellationRequested)
            {
                throw new TimeoutException("La consulta de inventario fue cancelada por timeout.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo cargar el inventario. Verifique la conexión.", ex);
            }
        }

        public async Task<List<Producto>> ObtenerProductosDeBodega(int idBodega)
        {
            try
            {
                var supabase = await Conexion.GetClientAsync();

                // 1. Consultar la tabla 'inventario' para esta bodega
                var respuestaInventario = await supabase
                    .From<Inventario>()
                    .Select("*")
                    .Filter("id_bodega", Supabase.Postgrest.Constants.Operator.Equals, idBodega)
                    .Get();

                var listaInventario = respuestaInventario.Models;

                // Si la bodega está vacía, devolvemos lista vacía
                if (listaInventario.Count == 0) return new List<Producto>();

                // 2. Sacar los IDs de los productos que encontramos
                var idsProductos = listaInventario.Select(x => x.IdProductoInventario).ToList();

                // 3. Consultar la tabla 'producto' solo para esos IDs
                var respuestaProductos = await supabase
                    .From<Producto>()
                    .Select("*")
                    .Filter("id_producto", Supabase.Postgrest.Constants.Operator.In, idsProductos)
                    .Order("nombre_producto", Supabase.Postgrest.Constants.Ordering.Ascending)
                    .Get();

                var listaProductos = respuestaProductos.Models;

                // 4. "Unir" los datos: Poner el stock correcto en cada producto
                foreach (var prod in listaProductos)
                {
                    // Buscamos cuánto stock tiene este producto en el inventario que bajamos
                    var datoInventario = listaInventario.FirstOrDefault(inv => inv.IdProductoInventario == prod.IdProducto);
                    if (datoInventario != null)
                    {
                        prod.StockEnBodega = datoInventario.StockProductoBodegaInventario;
                    }
                }

                return listaProductos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error cargando inventario: " + ex.Message);
            }
        }
    }
}