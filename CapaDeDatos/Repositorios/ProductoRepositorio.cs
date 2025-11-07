using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using Supabase;
using Supabase.Interfaces; 
using Supabase.Postgrest;
using Supabase.Postgrest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Repositorios
{
    public class ProductoRepositorio
    {
        private async Task<Supabase.Client> GetClient()
        {
            return await Conexion.ConnectWithTimeoutAsync(10);
        }
        public async Task<List<Producto>> ObtenerTodosLosProductos(bool? estado = null, int? marcaId = null, int? categoriaId = null)
        {
            try
            {
                var client = await GetClient();

                // 1. Inicia la consulta desde la tabla
                IPostgrestTable<Producto> query = client.From<Producto>();

                // 2. Aplica los filtros (sin el casteo incorrecto)
                if (estado.HasValue)
                {
                    query = query.Where(x => x.EstadoProducto == estado.Value);
                }

                if (marcaId.HasValue && marcaId.Value > 0)
                {
                    query = query.Where(x => x.IdMarca == marcaId.Value);
                }

                if (categoriaId.HasValue && categoriaId.Value > 0)
                {
                    query = query.Where(x => x.IdCategoria == categoriaId.Value);
                }

                // 3. Ordena el resultado
                query = query.Order("id_producto", Supabase.Postgrest.Constants.Ordering.Ascending);

                // 4. Ejecuta el SELECT y el GET al final
                //    (Usamos el 'Select' con alias para que cargue los objetos 'Marca' y 'Categoria')
                var response = await query
                    .Select("*, marca(*), categoria(*)")
                    .Get();

                if (response != null && response.Models != null)
                {
                    return response.Models;
                }

                return new List<Producto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de Supabase al obtener productos: {ex.Message}");
                throw;
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
                throw;// new Exception("No se pudo guardar el producto. Verifique los datos y la conexión.", ex);
            }
        }

        public static async Task ActualizarProducto(Producto productoActualizado)
        {
            try
            {
                var client = await Conexion.ConnectWithTimeoutAsync(10);

                // Llama al método .Update() de Supabase
                await client.From<Producto>().Update(productoActualizado);
            }
            catch (Exception ex)
            {
                // ... (tu manejo de errores) ...
                throw;
            }
        }
    }
}
