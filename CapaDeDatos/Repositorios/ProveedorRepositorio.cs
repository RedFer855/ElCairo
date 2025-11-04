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
    public class ProveedorRepositorio
    {
        // INSERTAR PROVEEDOR
        public static async Task InsertarProveedor(Proveedor nuevoProveedor)
        {
            try
            {
                var client = await Conexion.ConnectWithTimeoutAsync(10);
                await client.From<Proveedor>().Insert(nuevoProveedor);
            }
            catch (WebException ex)
            {
                throw new Exception("Error de red al guardar proveedor: " + ex.Message, ex);
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
        public async Task<List<Proveedor>> ObtenerTodosLosProveedores()
        {
            try
            {
                var client = await GetClient();
                var response = await client.From<Proveedor>().Get();
                return response?.Models ?? new List<Proveedor>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener proveedores: {ex.Message}");
                throw new Exception("No se pudieron cargar los proveedores.", ex);
            }
        }

        // OBTENER POR ID (Asumiendo que la PK es id_proveedor)
        public async Task<Proveedor> ObtenerProveedorPorId(int id)
        {
            var client = await GetClient();
            var response = await client.From<Proveedor>()
                .Filter("id_proveedor", Operator.Equals, id)
                .Get();
            return response.Models.FirstOrDefault();
        }

        // ACTUALIZAR
        public static async Task ActualizarProveedor(Proveedor proveedorActualizado)
        {
            var client = await Conexion.ConnectWithTimeoutAsync(10);
            await client.From<Proveedor>().Update(proveedorActualizado);
        }

        // ELIMINAR
        public static async Task EliminarProveedor(int id)
        {
            var client = await Conexion.ConnectWithTimeoutAsync(10);
            await client.From<Proveedor>()
                .Filter("id_proveedor", Operator.Equals, id)
                .Delete();
        }
    }
}