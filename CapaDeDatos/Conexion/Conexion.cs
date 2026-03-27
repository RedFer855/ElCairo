using DotNetEnv;
using Supabase;
using System;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace CapaDeDatos.Datos
{
    public class Conexion
    {
        private static Client _supabaseClient;
        private static readonly SemaphoreSlim _semaforoConexion = new SemaphoreSlim(1, 1);
        private static bool _envCargado = false;

        public static Client SupabaseClient => _supabaseClient;

        public static async Task<Client> GetClientAsync()
        {
            if (_supabaseClient != null)
                return _supabaseClient;

            await _semaforoConexion.WaitAsync();
            try
            {
                if (_supabaseClient != null)
                    return _supabaseClient;

                if (!_envCargado)
                {
                    Env.Load();
                    _envCargado = true;
                }

                string supabaseUrl = ConfigurationManager.AppSettings["SUPABASE_URL"];
                string supabaseKey = ConfigurationManager.AppSettings["SUPABASE_KEY"];

                if (string.IsNullOrWhiteSpace(supabaseUrl) || string.IsNullOrWhiteSpace(supabaseKey))
                    throw new ApplicationException("SUPABASE_URL o SUPABASE_KEY no están configuradas.");

                var options = new SupabaseOptions
                {
                    AutoRefreshToken = false,
                    AutoConnectRealtime = true,
                    SessionHandler = null
                };

                _supabaseClient = new Client(supabaseUrl, supabaseKey, options);
                await _supabaseClient.InitializeAsync();

                return _supabaseClient;
            }
            finally
            {
                _semaforoConexion.Release();
            }
        }

        public static async Task<Client> ConnectWithTimeoutAsync(int timeoutSeconds = 3)
        {
            var connectionTask = GetClientAsync();
            var timeoutTask = Task.Delay(TimeSpan.FromSeconds(timeoutSeconds));

            var completedTask = await Task.WhenAny(connectionTask, timeoutTask);

            if (completedTask == timeoutTask)
                throw new TimeoutException($"El servidor no respondió en {timeoutSeconds} segundos.");

            return await connectionTask;
        }
    }
}