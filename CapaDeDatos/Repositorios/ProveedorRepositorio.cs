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

        private async Task<Supabase.Client> GetClient()
        {
            return await Conexion.ConnectWithTimeoutAsync();
        }

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
                throw; 
            }
        }


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
        public static async Task<int?> ObtenerIdProveedorPorNombreAsync(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return null;

            try
            {
                var client = await CapaDeDatos.Datos.Conexion.GetClientAsync();
                    //buscando por el nombre exacto
                    var respExact = await client
                    .From<Proveedor>()
                    .Where(p => p.NombreProveedor == nombre)
                    .Limit(1)
                    .Get();

                var provExact = respExact.Models?.FirstOrDefault();
                if (provExact != null)
                    return provExact.IdProveedor;

                var respLike = await client
                    .From<Proveedor>()
                    .Filter(p => p.NombreProveedor, Supabase.Postgrest.Constants.Operator.ILike, $"%{nombre}%")
                    .Limit(1)
                    .Get();

                var provLike = respLike.Models?.FirstOrDefault();
                if (provLike != null)
                    return provLike.IdProveedor;

                // No encontrado
                return null;
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("La consulta fue cancelada o excedió el tiempo de espera.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error consultando proveedores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        public static async Task<Proveedor> CargarProveedorPorIdAsync(int idProveedor)
        {
            try
            {
                var client = await CapaDeDatos.Datos.Conexion.GetClientAsync();
                var resp = await client
                    .From<Proveedor>()
                    .Where(p => p.IdProveedor == idProveedor)
                    .Limit(1)
                    .Get();
                MessageBox.Show(resp.ToString());

                return resp.Models?.FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

    }
}