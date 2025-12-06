using BCrypt.Net;
using CapaDeDatos.Datos;
using CapaDeDatos.Modelados.Inventario;
using Supabase.Postgrest.Exceptions;
using System.Security.Cryptography;
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

        public async Task<List<Bodega>> ObtenerBodegasActivas()
        {
            var client = await GetClient();
            var response = await client.From<Bodega>()
                .Where(b => b.EstadoBodega == true) // Asume que el modelo Bodega tiene 'EstadoBodega'
                .Get();
            return response.Models.OrderBy(b => b.NombreBodega).ToList();
        }

        public async Task<Bodega> CrearBodegaAsync(Bodega nuevaBodega)
        {
            try
            {
                var client = await GetClient();

                // Inserta el registro y recupera la respuesta
                var response = await client.From<Bodega>().Insert(nuevaBodega);

                // Devuelve el modelo insertado, que contiene el ID generado por Supabase
                return response.Models.FirstOrDefault();
            }
            catch (PostgrestException ex)
            {
                // Manejar errores de la BD (RLS, duplicados, etc.)
                throw new Exception($"Error de base de datos al crear bodega: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado al crear bodega: {ex.Message}");
            }
        }
        public static string HashPassword(string password)
        {
            // Usa tu algoritmo de hasheo preferido (ej. SHA256, BCrypt, etc.)
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public async Task<Bodega> CrearBodegaFinalAsync(string nombreBodega, string contrasenaHash)
        {
            try
            {
                var client = await GetClient();

                // No hay hasheo aquí. Simplemente se usa el hash recibido.
                var nuevaBodega = new Bodega
                {
                    NombreBodega = nombreBodega,

                    // 🚨 CORRECCIÓN: Usamos la propiedad REAL de tu modelo.
                    ContraseniaBodega = contrasenaHash
                };

                var response = await client.From<Bodega>().Insert(nuevaBodega);
                return response.Models.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear bodega: {ex.Message}");
            }
        }

    }
}
