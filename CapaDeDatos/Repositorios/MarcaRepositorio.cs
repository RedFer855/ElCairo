using CapaDeDatos.Datos;
using CapaDeDatos.Modelados.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Repositorios
{
    public class MarcaRepositorio
    {
        private async Task<Client> GetClient()
        {
            return await Conexion.ConnectWithTimeoutAsync(3);
        }

        public async Task<List<Marca>> ObtenerTodasLasMarcas(bool? estadoMarca = null)
        {
            try
            {
                var client = await GetClient();
                var queryBuilder = client.From<Marca>();

                queryBuilder.Order("id_marca", Supabase.Postgrest.Constants.Ordering.Ascending);

                if (estadoMarca.HasValue)
                {
                    queryBuilder = (Supabase.Interfaces.ISupabaseTable<Marca, Supabase.Realtime.RealtimeChannel>)queryBuilder.Where(m => m.EstadoMarca == estadoMarca.Value);

                }

                var response = await queryBuilder.Select("*, Proveedor:proveedores(*)").Get();

                if (response?.Models != null)
                {
                    return response.Models;
                }

                return new List<Marca>();
            }
            catch (Exception ex)
            {
                throw new Exception("No se obtuvo respuesta. Verifique los datos y la conexión.", ex);
            }
        }
        public static async Task<List<Marca>> ObtenerMarcasPorProveedorAsync(int idProveedor)
        {
            var client = await Conexion.ConnectWithTimeoutAsync(10);

            var resp = await client
                .From<Marca>()
                .Where(m => m.IdProveedor == idProveedor)
                .Get();

            return resp.Models ?? new List<Marca>();
        }

        public static async Task InsertarMarca(MarcaInsertar nuevaMarca)
        {
            try
            {
                var client = await Conexion.ConnectWithTimeoutAsync(10);
                await client.From<MarcaInsertar>().Insert(nuevaMarca);
            }
            catch (System.Net.WebException ex)
            {
                throw new Exception("Error de red al guardar marca: " + ex.Message, ex);
            }
            catch (TimeoutException ex)
            {
                throw new Exception("El servidor tardó demasiado en responder.", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de Supabase: {ex.Message}");
                throw; //new Exception("Error al guardar la marca en la base de datos.", ex);
            }
        }

        public static async Task<MarcaInsertar> ActualizarMarca(MarcaInsertar marcaEditar)
        {
            if (marcaEditar == null)
                throw new ArgumentNullException(nameof(marcaEditar), "La marca a actualizar no puede ser nula.");

            try
            {
                var client = await Conexion.ConnectWithTimeoutAsync(10);

                // Al tener [PrimaryKey] en el modelo, .Update() genera automáticamente
                // el "WHERE id_marca = marcaEditar.IdMarca"
                var response = await client
                    .From<MarcaInsertar>()
                    .Update(marcaEditar);

                if (response?.Models != null && response.Models.Count > 0)
                    return response.Models.First();

                throw new Exception("La base de datos no devolvió la marca actualizada.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de Supabase al actualizar marca: {ex.Message}");
                throw;
            }
        }
    }
}
