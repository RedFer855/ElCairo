using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Repositorios
{
    public class UsuarioRepositorio
    {
        private async Task<Client> GetClient()
        {
            // Llama al método estático de tu clase Conexion.cs
            return await Conexion.ConnectWithTimeoutAsync(10);
        }

        // VER UN EMPLEADO
        public async Task<List<Usuario>> ObtenerTodosLosUsuarios()
        {
            try
            {
                // 1. Obtiene la conexión
                var client = await GetClient();

                // 2. Realiza la consulta (SELECT * FROM usuario)
                var response = await client.From<Usuario>().Get();

                // 3. Devuelve la lista de modelos (objetos usuario)
                if (response != null && response.Models != null)
                {
                    return response.Models;
                }

                // Devuelve una lista vacía si no hay respuesta
                return new List<Usuario>();
            }
            catch (Exception ex)
            {
                // 4. Manejo de errores
                Console.WriteLine($"Error de Supabase al obtener usuarios: {ex.Message}");
                // Relanza la excepción para que el formulario (la UI) pueda
                // mostrar un mensaje de error al usuario.
                throw new Exception("No se pudieron cargar los usuarios. Verifique la conexión.", ex);
            }
        }

    }
}
