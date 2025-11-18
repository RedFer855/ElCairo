using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using CapaDeDatos.Modelados.Compras;
using CapaDeDatos.Modelados.UsuariosEmpleados;
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

        public static async Task<Usuario> getUserId(string user_id)
        {
            var supabase = await CapaDeDatos.Datos.Conexion.GetClientAsync();
            if (user_id == null)
            {
                throw new Exception("No hay usuario autenticado en la sesión actual.");
            }
            try
            {

                var respEmpleado = await supabase
                .From<Usuario>()
                .Select("id_empleado")
                .Filter("user_id", Operator.Equals, user_id)
                .Get();

                return respEmpleado.Models.FirstOrDefault();
                /*como estoy consultando una lista y quiero la primera coincidencia
                 debo de retornar un valor lista, no un valor de la varaible
                 */

            }
            catch (Exception ex)
            {
                MessageBox.Show($"no se pudo buscar el usuario{ex.Message}");
                return null;
            }


        }
    }
}