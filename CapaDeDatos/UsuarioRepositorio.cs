using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class UsuarioRepositorio
    {
        private async Task<Client> GetClient()
        {
            return await Conexion.ConnectWithTimeoutAsync(10);
        }
        public async Task<Usuario> Iniciar_Sesion(string username, string password)
        {
            try
            {
                // 1. Intentar la conexión con límite de tiempo
                var client = await GetClient();

                // 2. Búsqueda y comparación de credenciales
                var response = await client.From<Usuario>()
                    .Where(x => x.Name == username)
                    .Where(x => x.password == password)
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
                
                Console.WriteLine($"Error de Red/Sistema: {ex.Message}");

                throw; /*new System.Net.WebException("Fallo al establecer la conexión con el servidor. Verifique su conexión a Internet.", ex);*/
            }
        }
    }
}
