using CapaDeDatos.Datos;
using CapaDeDatos.Modelados.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Repositorios
{
    public class PresentacionRepositorio
    {
        private async Task<Client> GetClient()
        {
            return await Conexion.ConnectWithTimeoutAsync(3);
        }

        public async Task<List<Presentacion>> ObtenerTodasLasPresentaciones()
        {
            try
            {
                var client = await GetClient();

                // Construir query
                var queryBuilder = client.From<Presentacion>();
                queryBuilder.Order("nombre_presentacion", Supabase.Postgrest.Constants.Ordering.Ascending);

                // Obtener datos
                var response = await queryBuilder.Select("*").Get();

                if (response?.Models != null)
                    return response.Models;

                return new List<Presentacion>();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo obtener la lista de presentaciones. Verifique la conexión.", ex);
            }
        }
    }
}
