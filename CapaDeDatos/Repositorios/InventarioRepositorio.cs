using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using CapaDeDatos.Modelados.ModeladosVistas;
using Supabase.Realtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Supabase.Postgrest.Constants;

namespace CapaDeDatos.Repositorios
{
    public class InventarioRepositorio
    {
        private async Task<Supabase.Client> GetClient()
        {
            return await Conexion.ConnectWithTimeoutAsync();
        }

        public async Task<List<Inventario>> ObtenerTodoElInventario(CancellationToken cancellationToken = default)
        {
            try
            {
                var client = await GetClient();
                var queryBuilder = client.From<Inventario>();

                queryBuilder.Select("*, producto(*), bodega(*)");

                queryBuilder.Order("id_producto", Supabase.Postgrest.Constants.Ordering.Ascending);

                var response = await queryBuilder.Get(cancellationToken);

                return response.Models ?? new List<Inventario>();
            }
            catch (OperationCanceledException ex) when (cancellationToken.IsCancellationRequested)
            {
                throw new TimeoutException("La consulta de inventario fue cancelada por timeout.", ex);
            }
            catch (Exception ex)
            {
                throw;// new Exception("No se pudo cargar el inventario. Verifique la conexión.", ex);
            }
        }

        public async Task<RealtimeChannel> SuscribirseAInventarioAsync(Supabase.Client client)
        {
            var channel = client.Realtime.Channel("public:inventario");
            await channel.Subscribe();
            return channel;
        }
    }
}