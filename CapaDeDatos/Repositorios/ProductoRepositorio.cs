using CapaDeDatos.Datos;
using CapaDeDatos.Modelados.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Supabase.Postgrest.Constants;

namespace CapaDeDatos.Repositorios
{
    public class ProductoRepositorio
    {
        private async Task<Client> GetClient()
        {
            return await Conexion.ConnectWithTimeoutAsync(3);
        }

        public async Task<List<Producto>> ObtenerTodosLosProductos(bool? estado = null, int? marcaId = null, int? categoriaId = null)
        {
            try
            {
                var client = await GetClient();
                var queryBuilder = client.From<Producto>();
                queryBuilder.Order("id_producto", Supabase.Postgrest.Constants.Ordering.Ascending);


                if (estado.HasValue)
                {
                    queryBuilder = (Supabase.Interfaces.ISupabaseTable<Producto, Supabase.Realtime.RealtimeChannel>)queryBuilder.Where(x => x.EstadoProducto == estado.Value);
                }

                if (marcaId.HasValue && marcaId.Value > 0)
                {
                    queryBuilder = (Supabase.Interfaces.ISupabaseTable<Producto, Supabase.Realtime.RealtimeChannel>)queryBuilder.Where(x => x.IdMarca == marcaId.Value);
                }

                if (categoriaId.HasValue && categoriaId.Value > 0)
                {
                    queryBuilder = (Supabase.Interfaces.ISupabaseTable<Producto, Supabase.Realtime.RealtimeChannel>)queryBuilder.Where(x => x.IdCategoria == categoriaId.Value);
                }

                var response = await queryBuilder.Select("*,presentacion(*), marca(*), categoria(*))").Get();

                if (response != null && response.Models != null)
                {
                    return response.Models;
                }

                return new List<Producto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de Supabase al obtener productos: {ex.Message}");
                throw;// new Exception("No se obtuvo respuesta. Verifique los datos y la conexión.", ex);
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
                throw;// new Exception("No se pudo guardar el producto. Verifique los datos y la conexión.", ex);
            }
        }


        public async Task<ProductoInsertar> ActualizarProducto(ProductoInsertar _productoEditar)
        {
            if (_productoEditar == null)
                throw new ArgumentNullException(nameof(_productoEditar), "El producto a modificar no puede ser nulo.");

            try
            {
                var client = await GetClient();

                // OPTIMIZACIÓN:
                // 1. No necesitamos pasar el ID aparte, ya viene dentro de '_productoEditar.IdProducto'.
                // 2. No necesitamos .Where(), Supabase usa el [PrimaryKey] del modelo para saber a quién actualizar.

                var response = await client
                    .From<ProductoInsertar>()
                    .Update(_productoEditar);

                if (response?.Models != null && response.Models.Count > 0)
                    return response.Models.First();

                throw new Exception("La base de datos no devolvió el producto modificado o no se encontró el ID.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de Supabase al modificar producto: {ex.Message}");
                throw;// new Exception("No se pudo modificar el producto. Verifique los datos y la conexión.", ex);
            }
        }


        public async Task<List<Producto>> ObtenerProductosPorProveedorAsync(int idProveedor)
        {
            try
            {
                var client = await GetClient();

                // 🔹 Trae todos los productos cuya marca pertenece al proveedor dado
                var queryBuilder = client
                    .From<Producto>()
                    .Select("*, marca!inner(id_marca, nombre_marca, id_proveedor), categoria(*)")
                    .Filter("marca.id_proveedor", Supabase.Postgrest.Constants.Operator.Equals, idProveedor)
                    .Order("id_producto", Supabase.Postgrest.Constants.Ordering.Ascending);

                var response = await queryBuilder.Get();

                if (response != null && response.Models != null)
                    return response.Models;

                return new List<Producto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de Supabase al obtener productos por proveedor: {ex.Message}");
                throw;
            }
        }
        public async Task<List<Producto>> ObtenerProductosPorMarcasAsync(List<int> idMarcas)
        {
            if (idMarcas == null || idMarcas.Count == 0)
                return new List<Producto>();

            var client = await Conexion.ConnectWithTimeoutAsync(10);

            var resp = await client
                            .From<Producto>()
                            .Select("*, marca(*), categoria(*)")     // 👈 IMPORTANTE: JOIN
                            .Filter("id_marca", Operator.In, idMarcas)
                            .Get();


            return resp.Models ?? new List<Producto>();
        }

        public async Task<List<Producto>> ObtenerActivos(bool estado = true, int? marcaId = null, int? categoriaId = null)
        {
            try
            {
                var client = await GetClient();
                var query = client.From<Producto>()
                                  .Order("id_producto", Supabase.Postgrest.Constants.Ordering.Ascending);

                // Solo productos activos
                query = query.Filter("estado_producto", Supabase.Postgrest.Constants.Operator.Equals, estado.ToString().ToLower());//estado a string por que postgresql no maneja datos bool en sus consultas

                if (marcaId.HasValue && marcaId.Value > 0)
                    query = query.Filter("id_marca", Supabase.Postgrest.Constants.Operator.Equals, marcaId.Value);

                if (categoriaId.HasValue && categoriaId.Value > 0)
                    query = query.Filter("id_categoria", Supabase.Postgrest.Constants.Operator.Equals, categoriaId.Value);

                var response = await query.Select("*, marca(*), categoria(*),presentacion(*)").Get();

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
