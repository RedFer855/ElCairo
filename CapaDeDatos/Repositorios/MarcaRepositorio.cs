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

                var response = await queryBuilder.Select("*").Get();

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
    }
}
