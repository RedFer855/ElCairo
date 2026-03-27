using CapaDeDatos.Datos;
using CapaDeDatos.Modelados.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Supabase.Postgrest.Constants;

namespace CapaDeDatos.Repositorios
{
    public class ProductoRepositorio
    {
        // Aquí ya NO usamos timeout en cada consulta.
        // Dejamos que Conexion maneje el cliente singleton.
        private Task<Client> GetClient()
        {
            return Conexion.GetClientAsync();
        }

        public async Task<List<Producto>> ObtenerTodosLosProductos(bool? estado = null, int? marcaId = null, int? categoriaId = null)
        {
            try
            {
                var client = await GetClient();

                var queryBuilder = client.From<Producto>();
                queryBuilder.Order("id_producto", Ordering.Ascending);

                if (estado.HasValue)
                {
                    queryBuilder = (Supabase.Interfaces.ISupabaseTable<Producto, Supabase.Realtime.RealtimeChannel>)
                        queryBuilder.Where(x => x.EstadoProducto == estado.Value);
                }

                if (marcaId.HasValue && marcaId.Value > 0)
                {
                    queryBuilder = (Supabase.Interfaces.ISupabaseTable<Producto, Supabase.Realtime.RealtimeChannel>)
                        queryBuilder.Where(x => x.IdMarca == marcaId.Value);
                }

                if (categoriaId.HasValue && categoriaId.Value > 0)
                {
                    queryBuilder = (Supabase.Interfaces.ISupabaseTable<Producto, Supabase.Realtime.RealtimeChannel>)
                        queryBuilder.Where(x => x.IdCategoria == categoriaId.Value);
                }

                // Corregido: quitado el paréntesis extra
                var response = await queryBuilder
                    .Select("*,presentacion(*), marca(*), categoria(*)")
                    .Get();

                return response?.Models ?? new List<Producto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de Supabase al obtener productos: {ex.Message}");
                throw;
            }
        }

        public async Task<ProductoInsertar> InsertarProducto(ProductoInsertar nuevoProducto)
        {
            if (nuevoProducto == null)
                throw new ArgumentNullException(nameof(nuevoProducto), "El producto a insertar no puede ser nulo.");

            try
            {
                var client = await GetClient();

                var response = await client
                    .From<ProductoInsertar>()
                    .Insert(nuevoProducto);

                if (response?.Models != null && response.Models.Count > 0)
                    return response.Models.First();

                throw new Exception("La base de datos no devolvió el producto insertado.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de Supabase al insertar producto: {ex.Message}");
                throw;
            }
        }

        public async Task<ProductoInsertar> ActualizarProducto(ProductoInsertar productoEditar)
        {
            if (productoEditar == null)
                throw new ArgumentNullException(nameof(productoEditar), "El producto a modificar no puede ser nulo.");

            try
            {
                var client = await GetClient();

                var response = await client
                    .From<ProductoInsertar>()
                    .Update(productoEditar);

                if (response?.Models != null && response.Models.Count > 0)
                    return response.Models.First();

                throw new Exception("La base de datos no devolvió el producto modificado o no se encontró el ID.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de Supabase al modificar producto: {ex.Message}");
                throw;
            }
        }

        public async Task<List<Producto>> ObtenerProductosPorMarcasAsync(List<int> idMarcas)
        {
            if (idMarcas == null || idMarcas.Count == 0)
                return new List<Producto>();

            var client = await GetClient();

            var resp = await client
                .From<Producto>()
                .Select("*, marca(*), categoria(*)")
                .Filter("id_marca", Operator.In, idMarcas)
                .Get();

            return resp?.Models ?? new List<Producto>();
        }

        public async Task<List<Producto>> ObtenerActivos(bool estado = true, int? marcaId = null, int? categoriaId = null)
        {
            try
            {
                var client = await GetClient();

                var query = client.From<Producto>()
                    .Order("id_producto", Ordering.Ascending);

                query = query.Filter("estado_producto", Operator.Equals, estado.ToString().ToLower());

                if (marcaId.HasValue && marcaId.Value > 0)
                    query = query.Filter("id_marca", Operator.Equals, marcaId.Value);

                if (categoriaId.HasValue && categoriaId.Value > 0)
                    query = query.Filter("id_categoria", Operator.Equals, categoriaId.Value);

                var response = await query
                    .Select("*, marca(*), categoria(*),presentacion(*)")
                    .Get();

                return response?.Models ?? new List<Producto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener productos activos: {ex.Message}");
                throw;
            }
        }
    }
}