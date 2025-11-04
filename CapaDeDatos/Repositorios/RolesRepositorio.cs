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
    public class RolesRepositorio
    {
        // INSERTAR ROL
        public static async Task InsertarRol(Rol nuevoRol)
        {
            try
            {
                var client = await Conexion.ConnectWithTimeoutAsync(10);
                await client.From<Rol>().Insert(nuevoRol);
            }
            catch (WebException ex)
            {
                throw new Exception("Error de red al guardar rol: " + ex.Message, ex);
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
        public async Task<List<Rol>> ObtenerTodosLosRoles()
        {
            try
            {
                var client = await GetClient();
                var response = await client.From<Rol>().Get();
                return response?.Models ?? new List<Rol>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener roles: {ex.Message}");
                throw new Exception("No se pudieron cargar los roles.", ex);
            }
        }

        // OBTENER POR ID (Asumiendo que la PK es id_rol)
        public async Task<Rol> ObtenerRolPorId(int id)
        {
            var client = await GetClient();
            var response = await client.From<Rol>()
                .Filter("id_rol", Operator.Equals, id)
                .Get();
            return response.Models.FirstOrDefault();
        }

        // ACTUALIZAR
        public static async Task ActualizarRol(Rol rolActualizado)
        {
            var client = await Conexion.ConnectWithTimeoutAsync(10);
            await client.From<Rol>().Update(rolActualizado);
        }

        // ELIMINAR
        public static async Task EliminarRol(int id)
        {
            var client = await Conexion.ConnectWithTimeoutAsync(10);
            await client.From<Rol>()
                .Filter("id_rol", Operator.Equals, id)
                .Delete();
        }
    }
}
