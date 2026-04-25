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