using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using Sprache;
using Supabase.Gotrue.Mfa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Supabase.Postgrest.Constants;

namespace CapaDeDatos.Repositorios
{
    public class CompraRepositorio
    {
        private static async Task<Client> GetClient()
        {
            return await Conexion.ConnectWithTimeoutAsync(10);
        }
        public async Task<Compra> InsertarCompra(Compra nuevaCompra)
        {
            try
            {
                var client = await GetClient();

                var compraResp = await client.From<Compra>().Insert(nuevaCompra);
                int idCompra = compraResp.Models.First().IdCompra;


                if (compraResp?.Models != null && compraResp.Models.Count > 0)
                {
                    return compraResp.Models.First();
                }

                throw new Exception("La base de datos no devolvió la compra.");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar compra: {ex.Message}");
                throw;
            }
        }

        public static async Task<int?> ObtenerCompraId(int idUsuario)
        {
            try
            {
                var client = await GetClient();

                var comprasResp = await client
                    .From<Compra>()
                    .Select("id_compra")
                    .Filter("id_empleado", Operator.Equals, idUsuario)
                    .Order("id_compra", Ordering.Descending)
                    .Limit(1)
                    .Get();

                var compra = comprasResp.Models.FirstOrDefault();
               
                return compra?.IdCompra; // agarra el int ? de la compra
            }
            catch (Exception ex)
            {
               MessageBox.Show($"Error al obtener el ID de la compra: {ex.Message}");
                throw;
            }
        }

    }
}
