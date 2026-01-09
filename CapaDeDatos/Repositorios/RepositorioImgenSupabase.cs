using CapaDeDatos.Datos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Supabase.Postgrest.Constants;

namespace CapaDeDatos.Repositorios
{
    public class RepositorioImgenSupabase
    {
        private async Task<Client> GetClient()
        {
            return await Conexion.ConnectWithTimeoutAsync(3);
        }

        public async Task IngresarImagen(byte[] bytes, string imagen)
        {
            try
            {
                var client = await GetClient();

                await client.Storage.From("imagenes_productos").Upload(bytes, imagen);
                MessageBox.Show("Imagen ingresada correctamente");
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo ingresar la imagen. Verifique los datos y la conexión.", ex);
            }
        }

        public async Task<Image> LeerImagenes(string nombreArchivo)
        {
            try
            {
                var cliente = await GetClient();

                var bytes = await cliente.Storage
                                         .From("imagenes_productos")
                                         .Download(nombreArchivo, (sender, progress) => Debug.WriteLine($"{progress}%"));

                using (var ms = new MemoryStream(bytes))
                using (var imgTemp = Image.FromStream(ms))
                {
                    // Clonar la imagen para evitar dependencia del stream
                    return new Bitmap(imgTemp);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo leer la imagen desde Supabase.", ex);
            }
        }
    }
}
