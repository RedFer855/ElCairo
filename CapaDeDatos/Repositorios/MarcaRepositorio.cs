using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Supabase.Postgrest.Constants;

namespace CapaDeDatos.Repositorios
{
    public class MarcaRepositorio
    {
        // INSERTAR MARCA
        public static async Task InsertarMarca(Marca nuevaMarca)
        {
            try
            {
                var client = await Conexion.ConnectWithTimeoutAsync(10);
                await client.From<Marca>().Insert(nuevaMarca);
            }
            catch (WebException ex)
            {
                throw new Exception("Error de red al guardar la marca: " + ex.Message, ex);
            }
            catch (TimeoutException ex)
            {
                throw new Exception("El servidor tardó demasiado en responder.", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de Supabase: {ex.Message}");
                throw;
            }
        }

        private async Task<Supabase.Client> GetClient() => await Conexion.ConnectWithTimeoutAsync(10);

        // OBTENER TODAS LAS MARCAS
        public async Task<List<Marca>> ObtenerTodasLasMarcas()
        {
            try
            {
                var client = await GetClient();
                var response = await client.From<Marca>().Get();
                return response?.Models ?? new List<Marca>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener marcas: {ex.Message}");
                throw new Exception("No se pudieron cargar las marcas.", ex);
            }
        }

        // OBTENER POR ID (Usando la PK 'id_marca' que modelamos)
        public async Task<Marca> ObtenerMarcaPorId(int id)
        {
            var client = await GetClient();
            var response = await client.From<Marca>()
                .Filter("id_marca", Operator.Equals, id)
                .Get();
            return response.Models.FirstOrDefault();
        }

        // ACTUALIZAR MARCA
        public static async Task ActualizarMarca(Marca marcaActualizada)
        {
            var client = await Conexion.ConnectWithTimeoutAsync(10);
            await client.From<Marca>().Update(marcaActualizada);
        }

        // ELIMINAR MARCA
        public static async Task EliminarMarca(int id)
        {
            var client = await Conexion.ConnectWithTimeoutAsync(10);
            await client.From<Marca>()
                .Filter("id_marca", Operator.Equals, id)
                .Delete();
        }
    }
}
