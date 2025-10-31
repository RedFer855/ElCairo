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
        public async Task<List<Producto>> ObtenerTodosLosProductos()
        {
            try
            {
                // 1. Obtiene la conexión
                var client = await GetClient();

                // 2. Realiza la consulta (SELECT * FROM producto)
                // Se cambia Empleado por Producto
                var response = await client.From<Producto>().Get();

                // 3. Devuelve la lista de modelos (objetos Producto)
                if (response != null && response.Models != null)
                {
                    return response.Models;
                }

                // Devuelve una lista vacía si no hay respuesta
                return new List<Producto>();
            }
            catch (Exception ex)
            {
                // 4. Manejo de errores
                Console.WriteLine($"Error de Supabase al obtener productos: {ex.Message}");
                // Relanza la excepción para que el formulario (la UI) pueda
                // mostrar un mensaje de error al usuario.
                throw new Exception("No se pudieron cargar los productos. Verifique la conexión.", ex);
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
    }
}
