using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    internal class UsuarioRepositorio
    {
        public static async Task<Usuario_> Iniciar_Sesion(string username, string Password_)
        {
            try
            {
                // 1. Intentar la conexión con límite de tiempo
                var client = await Conexion.ConnectWithTimeoutAsync(10);

                // 2. Búsqueda y comparación de credenciales
                var response = await client.From<Usuario_>()
                    .Where(x => x.Name == username)
                    .Where(x => x.password == Password_)
                    .Get();

                return response.Models.FirstOrDefault();
            }
            catch (TimeoutException tex)
            {
                // El servidor tardó demasiado. Relanza para que el formulario lo maneje.
                throw tex;
            }
            catch (ApplicationException aex)
            {
                // Variables de entorno. Relanza para manejo fatal.
                throw aex;
            }
            catch (Exception ex)
            {
                // Captura CUALQUIER otro error, que probablemente sea de red (Wi-Fi apagado, DNS, etc.)
                // **IMPORTANTE:** Relanzamos la excepción para que el formulario sepa que es un fallo de red.
                // Si no relanzas, el formulario asume que el resultado es 'null' (credenciales inválidas).

                // Loguea el error real (opcional pero recomendado)
                Console.WriteLine($"Error de Red/Sistema: {ex.Message}");

                // Relanzar el error genérico como un error de conexión para distinguirlo del login fallido.
                throw new System.Net.WebException("Fallo al establecer la conexión con el servidor. Verifique su conexión a Internet.", ex);
            }
        }
    }
}
