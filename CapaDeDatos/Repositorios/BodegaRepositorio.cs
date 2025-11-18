using CapaDeDatos.Datos;
using Supabase.Realtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Supabase.Postgrest.Constants;
using BCrypt.Net;
using CapaDeDatos.Modelados.Inventario;

namespace CapaDeDatos.Repositorios
{
    public class BodegaRepositorio
    {
        private async Task<Supabase.Client> GetClient()
        {
            return await Conexion.ConnectWithTimeoutAsync();
        }

        public async Task<List<Bodega>> ObtenerTodasLasBodegasAsync()
        {
            var client = await GetClient();
            var response = await client.From<Bodega>().Get();

            return response.Models;
        }

        public static async Task<bool> IniciarSesion(string idBodega, string passwordInput)
        {
            try
            {
                var supabaseClient = await Conexion.ConnectWithTimeoutAsync(10);

                var bodegas = await supabaseClient
                    .From<Bodega>()
                    .Filter("id_bodega", Operator.Equals, idBodega)
                    .Get();

                var bodega = bodegas.Models.FirstOrDefault();
                if (bodega == null)
                {
                    MessageBox.Show("Credenciales incorrectas o bodega no encontrada");
                    return false;
                }

                if (!bodega.EstadoBodega)
                {
                    MessageBox.Show("La bodega está inactiva");
                    return false;
                }

                bool ok = PasswordHasher.VerifyHash(bodega.ContraseniaBodega, passwordInput);
                if (!ok)
                {
 
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar Bodega: {ex.Message}");
                return false;
            }
        }

        public static async Task<Bodega?> ObtenerBodegaPorIdAsync(string idBodega)
        {
            try
            {
                var supabaseClient = await Conexion.ConnectWithTimeoutAsync(3);

                var response = await supabaseClient
                    .From<Bodega>()
                    .Filter("id_bodega", Operator.Equals, idBodega)
                    .Get();

                var bodega = response.Models.FirstOrDefault();

                return bodega;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener datos de la bodega: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        protected static class PasswordHasher
        {
            public static string HashPassword(string plainPassword)
            {
                return BCrypt.Net.BCrypt.HashPassword(plainPassword);
            }

            public static bool VerifyHash(string storedHash, string passwordInput)
            {
                return BCrypt.Net.BCrypt.Verify(passwordInput, storedHash);
            }
        }
    }
}
