using CapaDeDatos.Datos;
using CapaDeDatos.Modelados.Inventario;
using CapaDeDatos.Modelados.ModeladosVistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Repositorios
{
    public class ReportesRepositorio
    {
        private async Task<Supabase.Client> GetClient()
        {
            return await Conexion.ConnectWithTimeoutAsync();
        }
        public async Task<List<Bodega>> ObtenerBodegasActivas()
        {
            var client = await GetClient(); // Tu método de conexión existente
            var response = await client.From<Bodega>()
                .Where(b => b.EstadoBodega == true)
                .Get();

            return response.Models.OrderBy(b => b.NombreBodega).ToList();
        }
        public async Task<List<VistaStockCritico>> ObtenerStockCritico(int idBodega)
        {
            var client = await GetClient();
            var response = await client.From<VistaStockCritico>()
                .Where(v => v.IdBodega == idBodega)
                .Get();

            return response.Models;
        }
    }
}
