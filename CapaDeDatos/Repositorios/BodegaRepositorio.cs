using BCrypt.Net;
using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using Supabase.Realtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Supabase.Postgrest.Constants;

namespace CapaDeDatos.Repositorios
{
    public class BodegaRepositorio
    {
        private async Task<Supabase.Client> GetClient()
        {
            return await Conexion.ConnectWithTimeoutAsync();
        }
        public static async Task<bool> IniciarSesion(string idBodega, string passwordInput)
        {
            try
            {
                var supabaseClient = await Conexion.ConnectWithTimeoutAsync(10);

                // Filtrar por ID de bodega (seguro contra inyecciones)
                var bodegas = await supabaseClient
                    .From<Bodega>()
                    .Filter("id_bodega", Operator.Equals, idBodega)
                    .Get();

                var bodega = bodegas.Models.FirstOrDefault();
                if (bodega == null)
                {
                    MessageBox.Show("Credenciales incorrectas o bodega no encontrada", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return false;
                }

                if (!bodega.EstadoBodega)
                {
                    MessageBox.Show("La bodega está inactiva", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return false;
                }

                bool ok = PasswordHasher.VerifyHash(bodega.ContraseniaBodega, passwordInput);
                if (!ok)
                {
                    MessageBox.Show("Credenciales incorrectas", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return false;
                }
                // Si llegó hasta aquí, el login fue exitoso
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar Bodega o Codigo no valido","Error",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                return false;
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
