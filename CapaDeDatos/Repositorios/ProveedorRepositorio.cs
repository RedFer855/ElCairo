using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace CapaDeDatos.Repositorios
{
    public class ProveedorRepositorio
    {
        // INSERTAR UN PROVEEDOR (Estático)
        public static async Task InsertarProveedor(Proveedor nuevoProveedor)
        {
            try
            {
                var client = await Conexion.ConnectWithTimeoutAsync(10);
                await client.From<Proveedor>().Insert(nuevoProveedor);
            }
            catch (System.Net.WebException ex)
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
                throw; // Relanza la excepción original
            }
        }

        // ACTUALIZAR UN PROVEEDOR (Estático)
        public static async Task ActualizarProveedor(Proveedor proveedorActualizado)
        {
            try
            {
                var client = await Conexion.ConnectWithTimeoutAsync(10);
                await client.From<Proveedor>().Update(proveedorActualizado);
            }
            catch (System.Net.WebException ex)
            {
                throw new Exception("Error de red al actualizar proveedor: " + ex.Message, ex);
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

        // Método de instancia para obtener el cliente
        private async Task<Supabase.Client> GetClient()
        {
            return await Conexion.ConnectWithTimeoutAsync();
        }

        // OBTENER TODOS LOS PROVEEDORES (Método de instancia)
        public async Task<List<Proveedor>> ObtenerTodosLosProveedores(CancellationToken cancellationToken = default)
        {
            try
            {
                var client = await GetClient();
                var queryBuilder = client.From<Proveedor>();
                queryBuilder.Order("id_proveedor", Supabase.Postgrest.Constants.Ordering.Ascending);

                var response = await queryBuilder.Get(cancellationToken);

                return response.Models ?? new List<Proveedor>();
            }
            catch (OperationCanceledException ex) when (cancellationToken.IsCancellationRequested)
            {
                throw new TimeoutException("La consulta de proveedores fue cancelada por timeout.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron cargar los proveedores. Verifique la conexión.", ex);
            }
        }

        // (Opcional) MÉTODO ELIMINAR (Estático)
        // public static async Task EliminarProveedor(int id)
        // {
        //     ... (lógica de eliminación) ...
        // }
    }
}