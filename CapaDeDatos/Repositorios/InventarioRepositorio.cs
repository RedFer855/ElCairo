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
    public class InventarioRepositorio
    {
        // INSERTAR REGISTRO DE INVENTARIO
        public static async Task InsertarInventario(Inventario nuevoInventario)
        {
            try
            {
                var client = await Conexion.ConnectWithTimeoutAsync(10);
                await client.From<Inventario>().Insert(nuevoInventario);
            }
            catch (WebException ex)
            {
                throw new Exception("Error de red al guardar en inventario: " + ex.Message, ex);
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
        public async Task<List<Inventario>> ObtenerTodosLosInventarios()
        {
            try
            {
                var client = await GetClient();
                var response = await client.From<Inventario>().Get();
                return response?.Models ?? new List<Inventario>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener inventario: {ex.Message}");
                throw new Exception("No se pudo cargar el inventario.", ex);
            }
        }

        // OBTENER POR ID (Asumiendo que la PK es id_inventario)
        public async Task<Inventario> ObtenerInventarioPorId(int id)
        {
            var client = await GetClient();
            var response = await client.From<Inventario>()
                .Filter("id_inventario", Operator.Equals, id)
                .Get();
            return response.Models.FirstOrDefault();
        }

        // ACTUALIZAR
        public static async Task ActualizarInventario(Inventario inventarioActualizado)
        {
            var client = await Conexion.ConnectWithTimeoutAsync(10);
            await client.From<Inventario>().Update(inventarioActualizado);
        }

        // ELIMINAR
        public static async Task EliminarInventario(int id)
        {
            var client = await Conexion.ConnectWithTimeoutAsync(10);
            await client.From<Inventario>()
                .Filter("id_inventario", Operator.Equals, id)
                .Delete();
        }
    }
}
