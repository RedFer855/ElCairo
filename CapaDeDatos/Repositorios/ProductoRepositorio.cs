using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Repositorios
{
    public class ProductoRepositorio
    {
        // Método privado para obtener el cliente (asume que tu clase Conexion existe)
        private async Task<Client> GetClient()
        {
            return await Conexion.ConnectWithTimeoutAsync(10);
        }
        public async Task<List<Producto>> ObtenerTodosLosProductos(bool? estado = null, int? marcaId = null, int? categoriaId = null)
        {
            try
            {
                var client = await GetClient();

                // 1. Prepara la consulta base
                var queryBuilder = client.From<Producto>();

                // 2. APLICA LA ORDENACIÓN (para evitar que el DGV se desordene)
                // Usamos 'id_producto' como campo de ordenación ascendente.
                queryBuilder.Order("id_producto", Supabase.Postgrest.Constants.Ordering.Ascending);

                // 3. APLICA LOS FILTROS (¡SIN CASTING!)

                if (estado.HasValue)
                {
                    // Nota: .Where() retorna el mismo tipo (Table<T>), el casting era innecesario.
                    queryBuilder = (Supabase.Interfaces.ISupabaseTable<Producto, Supabase.Realtime.RealtimeChannel>)queryBuilder.Where(x => x.EstadoProducto == estado.Value);
                }

                // --- Filtro de Marca ---
                if (marcaId.HasValue && marcaId.Value > 0)
                {
                    queryBuilder = (Supabase.Interfaces.ISupabaseTable<Producto, Supabase.Realtime.RealtimeChannel>)queryBuilder.Where(x => x.IdMarca == marcaId.Value);
                }

                // --- Filtro de Categoría ---
                if (categoriaId.HasValue && categoriaId.Value > 0)
                {
                    queryBuilder = (Supabase.Interfaces.ISupabaseTable<Producto, Supabase.Realtime.RealtimeChannel>)queryBuilder.Where(x => x.IdCategoria == categoriaId.Value);
                }

                // 4. EJECUTA EL SELECT (CON LOS JOINS)
                var response = await queryBuilder.Select("*, marca(*), categoria(*)").Get();

                // 5. Devuelve la lista de modelos
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
            // Verificación para asegurar que el objeto no sea nulo
            if (nuevoProducto == null)
            {
                throw new ArgumentNullException(nameof(nuevoProducto), "El producto a insertar no puede ser nulo.");
            }

            try
            {
                // 1. Obtiene la conexión
                var client = await GetClient();

                // 2. Realiza la operación de inserción
                // El cliente de Supabase puede insertar un solo objeto o una lista
                var response = await client.From<Producto>().Insert(nuevoProducto);

                // 3. Verifica y devuelve el producto insertado
                if (response?.Models != null && response.Models.Count > 0)
                {
                    // Devuelve el primer producto de la respuesta,
                    // que ahora incluirá el ID autogenerado (si aplica).
                    return response.Models.First();
                }

                // Si la respuesta es nula o no contiene modelos, algo falló.
                throw new Exception("La base de datos no devolvió el producto insertado.");
            }
            catch (Exception ex)
            {
                // 4. Manejo de errores
                Console.WriteLine($"Error de Supabase al insertar producto: {ex.Message}");
                // Relanza para que la UI (el formulario) pueda manejarlo
                throw new Exception("No se pudo guardar el producto. Verifique los datos y la conexión.", ex);
            }
        }

        public async Task<Producto> ModificarProducto(Producto editproducto, int idProd)
        {
            // 1. Verificación de seguridad
            if (editproducto == null)
            {
                throw new ArgumentNullException(nameof(editproducto), "El producto a modificar no puede ser nulo.");
            }

            try
            {
                // 2. Obtiene la conexión
                var client = await GetClient();

                // 3. Realiza la operación de actualización
                // .Where() selecciona la fila por el idProd
                // .Update(editproducto) aplica todos los cambios del objeto 'editproducto' a esa fila
                var response = await client.From<Producto>()
                    .Where(x => x.IdProducto == idProd)
                    .Update(editproducto);

                // 4. Verifica y devuelve el producto modificado
                if (response?.Models != null && response.Models.Count > 0)
                {
                    // Devuelve el primer producto de la respuesta (el actualizado)
                    return response.Models.First();
                }

                // Si la respuesta es nula o no contiene modelos, algo falló o no se encontró.
                throw new Exception("La base de datos no devolvió el producto modificado o no se encontró el ID.");
            }
            catch (Exception ex)
            {
                // 5. Manejo de errores
                Console.WriteLine($"Error de Supabase al modificar producto: {ex.Message}");
                // Relanza para que la UI (el formulario) pueda manejarlo
                throw new Exception("No se pudo modificar el producto. Verifique los datos y la conexión.", ex);
            }
        }
    }
}
