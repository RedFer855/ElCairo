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

    }
}
