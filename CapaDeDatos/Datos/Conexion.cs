using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetEnv;
using Supabase;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;



namespace CapaDeDatos.Datos
{

    public class Conexion
    {
        public static Client _supabaseClient { get; private set; }
        //public static Client Instance => _supabaseClient;


        // MÉTODOS DE CONEXION: Creación de Cliente y Manejo de Timeout

        // 1. Obtiene o inicializa el cliente (sin manejo de timeout aquí)
        public static async Task<Client> GetClientAsync()
        {
            if (_supabaseClient != null)
            {
                return _supabaseClient;
            }

            Env.Load();
            string supabaseUrl = Environment.GetEnvironmentVariable("SUPABASE_URL");
            string supabaseKey = Environment.GetEnvironmentVariable("SUPABASE_KEY");

            if (string.IsNullOrEmpty(supabaseUrl) || string.IsNullOrEmpty(supabaseKey))
            {
                // Lanza una excepción para que el formulario sepa que el error es de configuración
                throw new ApplicationException("SUPABASE_URL o SUPABASE_KEY no están configuradas.");
            }

            var options = new SupabaseOptions { AutoRefreshToken = true, AutoConnectRealtime = true };
            _supabaseClient = new Client(supabaseUrl, supabaseKey, options);
            await _supabaseClient.InitializeAsync();

            return _supabaseClient;
        }

        // 2. Conecta con un Timeout: Método para limitar el tiempo de espera.
        public static async Task<Client> ConnectWithTimeoutAsync(int timeoutSeconds = 10)
        {
            var connectionTask = GetClientAsync();
            var timeoutTask = Task.Delay(TimeSpan.FromSeconds(timeoutSeconds));

            var completedTask = await Task.WhenAny(connectionTask, timeoutTask);

            if (completedTask == timeoutTask)
            {
                // Lanza excepción de timeout
                throw new TimeoutException($"El servidor no respondió en {timeoutSeconds} segundos.");
            }

            // Si la conexión fue exitosa, devuelve el cliente
            return await connectionTask;
        }
    }
}