using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static Supabase.Postgrest.Constants;

namespace CapaDeDatos.Repositorios
{
    public class RutaRepositorio
    {
        // INSERTAR RUTA
        public static async Task InsertarRuta(Ruta nuevaRuta)
        {
            try
            {
                var client = await Conexion.ConnectWithTimeoutAsync(10);
                await client.From<Ruta>().Insert(nuevaRuta);
            }
            catch (WebException ex)
            {
                throw new Exception("Error de red al guardar ruta: " + ex.Message, ex);
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

        private async Task<Client> GetClient() => await Conexion.ConnectWithTimeoutAsync(10);

        // OBTENER TODOS
        public async Task<List<Ruta>> ObtenerTodasLasRutas()
        {
            try
            {
                var client = await GetClient();
                var response = await client.From<Ruta>().Get();
                return response?.Models ?? new List<Ruta>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener rutas: {ex.Message}");
                throw new Exception("No se pudieron cargar las rutas.", ex);
            }
        }

        // OBTENER POR ID (Asumiendo que la PK es id_rutas)
        public async Task<Ruta> ObtenerRutaPorId(int id)
        {
            var client = await GetClient();
            var response = await client.From<Ruta>()
                .Filter("id_rutas", Operator.Equals, id)
                .Get();
            return response.Models.FirstOrDefault();
        }

        // ACTUALIZAR
        public static async Task ActualizarRuta(Ruta rutaActualizada)
        {
            var client = await Conexion.ConnectWithTimeoutAsync(10);
            await client.From<Ruta>().Update(rutaActualizada);
        }

        // ELIMINAR
        public static async Task EliminarRuta(int id)
        {
            var client = await Conexion.ConnectWithTimeoutAsync(10);
            await client.From<Ruta>()
                .Filter("id_rutas", Operator.Equals, id)
                .Delete();
        }
    }
}