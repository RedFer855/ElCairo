using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using CapaDeDatos.Modelados.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Repositorios
{
    public class ClienteRepositorio
    {
       
        private static async Task<Client> GetClient()
        {
            return await Conexion.ConnectWithTimeoutAsync(3);
        }


        public async Task<List<Cliente>> ObtenerTodosLosClientes()
        {
            try
            {
                var client = await GetClient();

                var query = client
                    .From<Cliente>()
                    .Order("id_cliente", Supabase.Postgrest.Constants.Ordering.Ascending);

                var response = await query.Get();

                return response?.Models ?? new List<Cliente>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener clientes: {ex.Message}");
                throw;
            }
        }




        public static async Task<Cliente> InsertarCliente(Cliente nuevoCliente)
        {
            if (nuevoCliente == null)
                throw new ArgumentNullException(nameof(nuevoCliente));

            try
            {
                var client = await GetClient();

                var response = await client
                    .From<Cliente>()
                    .Insert(nuevoCliente);

                if (response?.Models != null && response.Models.Count > 0)
                    return response.Models.First();

                throw new Exception("La base de datos no devolvió el cliente insertado.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar cliente: {ex.Message}");
                throw;
            }
        }

        
        public static async Task<Cliente> ActualizarCliente(Cliente clienteEditar)
        {
            if (clienteEditar == null)
                throw new ArgumentNullException(nameof(clienteEditar));

            try
            {
                var client = await GetClient();

                
                var response = await client
                    .From<Cliente>()
                    .Update(clienteEditar);

                if (response?.Models != null && response.Models.Count > 0)
                    return response.Models.First();

                throw new Exception("La base de datos no devolvió el cliente actualizado.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al modificar cliente: {ex.Message}");
                throw;
            }
        }

        public async Task<List<Cliente>> ObtenerActivos(string estado = "activo")
        {
            try
            {
                var client = await GetClient();

                var query = client.From<Cliente>()
                                  .Order("id_cliente", Supabase.Postgrest.Constants.Ordering.Ascending)
                                  .Filter("estado_cliente",
                                        Supabase.Postgrest.Constants.Operator.Equals,
                                        estado);

                var response = await query.Get();

                return response?.Models ?? new List<Cliente>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener clientes activos: {ex.Message}");
                throw;
            }
        }
    }
}