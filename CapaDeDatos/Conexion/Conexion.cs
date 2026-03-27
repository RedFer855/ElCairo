using DotNetEnv;
using Supabase;
using System;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace CapaDeDatos.Datos
{
    public static class Conexion
    {
        private static Client _supabaseClient;
        private static readonly SemaphoreSlim _semaforoConexion = new SemaphoreSlim(1, 1);

        private static bool _envCargado = false;
        private static string _supabaseUrl;
        private static string _supabaseKey;

        public static Client ClienteActual => _supabaseClient;

        public static async Task<Client> GetClientAsync()
        {
            if (_supabaseClient != null)
                return _supabaseClient;

            await _semaforoConexion.WaitAsync();

            try
            {
                // Doble verificación por si otra llamada ya creó el cliente
                if (_supabaseClient != null)
                    return _supabaseClient;

                CargarConfiguracionSiHaceFalta();

                var options = new SupabaseOptions
                {
                    AutoRefreshToken = false,

                    // Déjalo en true si ya estás usando realtime con tu GestorRealtime
                    // y no quieres arriesgar compatibilidad.
                    AutoConnectRealtime = true,

                    SessionHandler = null
                };

                var cliente = new Client(_supabaseUrl, _supabaseKey, options);
                await cliente.InitializeAsync();

                _supabaseClient = cliente;
                return _supabaseClient;
            }
            finally
            {
                _semaforoConexion.Release();
            }
        }

        public static async Task<Client> ConnectWithTimeoutAsync(int timeoutSeconds = 3)
        {
            if (timeoutSeconds <= 0)
                throw new ArgumentOutOfRangeException(nameof(timeoutSeconds), "El tiempo debe ser mayor que 0.");

            var connectionTask = GetClientAsync();
            var timeoutTask = Task.Delay(TimeSpan.FromSeconds(timeoutSeconds));

            var completedTask = await Task.WhenAny(connectionTask, timeoutTask);

            if (completedTask == timeoutTask)
                throw new TimeoutException($"El servidor no respondió en {timeoutSeconds} segundos.");

            return await connectionTask;
        }

        private static void CargarConfiguracionSiHaceFalta()
        {
            if (!_envCargado)
            {
                Env.Load();
                _envCargado = true;
            }

            if (string.IsNullOrWhiteSpace(_supabaseUrl))
                _supabaseUrl = ConfigurationManager.AppSettings["SUPABASE_URL"];

            if (string.IsNullOrWhiteSpace(_supabaseKey))
                _supabaseKey = ConfigurationManager.AppSettings["SUPABASE_KEY"];

            if (string.IsNullOrWhiteSpace(_supabaseUrl) || string.IsNullOrWhiteSpace(_supabaseKey))
                throw new ApplicationException("SUPABASE_URL o SUPABASE_KEY no están configuradas.");
        }

        public static void ReiniciarCliente()
        {
            _supabaseClient = null;
        }
    }
}