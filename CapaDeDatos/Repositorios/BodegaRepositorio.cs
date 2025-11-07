using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using Supabase.Realtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Repositorios
{
    public class BodegaRepositorio
    {
        private async Task<Supabase.Client> GetClient()
        {
            return await Conexion.ConnectWithTimeoutAsync();
        }

        // ---------------------------------------------
        // Método 1: Obtener Datos (para llenar ComboBox)
        // ---------------------------------------------
        public async Task<List<Bodega>> ObtenerTodasLasBodegasAsync()
        {
            var client = await GetClient();

            // Asume que tu tabla se llama 'bodega' y tu modelo es 'Bodega.cs'
            var response = await client.From<Bodega>().Get();

            return response.Models;
        }

        // ---------------------------------------------
        // Método 2: Suscripción a Realtime
        // ---------------------------------------------
        public async Task<RealtimeChannel> SuscribirseABodegasAsync(Supabase.Client client)
        {
            // El canal escucha a la tabla 'bodega'
            var channel = client.Realtime.Channel("public:bodega");
            await channel.Subscribe();
            return channel;
        }
    }
}
