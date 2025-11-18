using CapaDeDatos.Datos;
using CapaDeDatos.Modelados.Inventario.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                var response = await queryBuilder.Select("*, marca(*), categoria(*)").Get();

                if (response != null && response.Models != null)
                {
                    return response.Models;
                }

                return new List<Producto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de Supabase al obtener productos: {ex.Message}");
                throw new Exception("No se obtuvo respuesta. Verifique los datos y la conexión.", ex);
            }
        }
        public async Task<Producto> InsertarProducto(Producto nuevoProducto)
        {
            if (nuevoProducto == null)
            {
                throw new ArgumentNullException(nameof(nuevoProducto), "El producto a insertar no puede ser nulo.");
            }

            try
            {
                var client = await GetClient();

                var response = await client.From<Producto>().Insert(nuevoProducto);

                if (response?.Models != null && response.Models.Count > 0)
                {
                    return response.Models.First();
                }

                throw new Exception("La base de datos no devolvió el producto insertado.");
            }
            catch (Exception ex)
            { 
                Console.WriteLine($"Error de Supabase al insertar producto: {ex.Message}");
                throw new Exception("No se pudo guardar el producto. Verifique los datos y la conexión.", ex);
            }
        }

        public async Task<Producto> ModificarProducto(Producto editproducto, int idProd)
        {
            
            if (editproducto == null)
            {
                throw new ArgumentNullException(nameof(editproducto), "El producto a modificar no puede ser nulo.");
            }

            try
            {
                var client = await GetClient();
                var response = await client.From<Producto>()
                    .Where(x => x.IdProducto == idProd)
                    .Update(editproducto);

                if (response?.Models != null && response.Models.Count > 0)
                {
                    
                    return response.Models.First();
                }

                throw new Exception("La base de datos no devolvió el producto modificado o no se encontró el ID.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de Supabase al modificar producto: {ex.Message}");
                throw new Exception("No se pudo modificar el producto. Verifique los datos y la conexión.", ex);
            }
        }
    }
}
