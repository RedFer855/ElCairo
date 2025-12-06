using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetEnv;
using Supabase;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using static Supabase.Realtime.PostgresChanges.PostgresChangesOptions;
using System.Configuration;


namespace CapaDeDatos.Datos
{

    public class Conexion
    {
        public static Client _supabaseClient { get; private set; }
      
        public static async Task<Client> GetClientAsync()
        {
            if (_supabaseClient != null)
            {
                return _supabaseClient;
            }

            string supabaseUrl = ConfigurationManager.AppSettings["SupabaseUrl"];
            string supabaseKey = ConfigurationManager.AppSettings["SupabaseKey"];
            /*Env.Load();
            string supabaseUrl = Environment.GetEnvironmentVariable("SUPABASE_URL");
            string supabaseKey = Environment.GetEnvironmentVariable("SUPABASE_KEY");*/

            if (string.IsNullOrEmpty(supabaseUrl) || string.IsNullOrEmpty(supabaseKey))
            {
                throw new ApplicationException("SUPABASE_URL o SUPABASE_KEY no están configuradas.");
            }

            var options = new SupabaseOptions
            {
                AutoRefreshToken = false,
                AutoConnectRealtime = true,
                SessionHandler = null // <-- ESTO ES LO IMPORTANTE
            };
            _supabaseClient = new Client(supabaseUrl, supabaseKey, options);
            await _supabaseClient.InitializeAsync();

            return _supabaseClient;

        }

        public static async Task<Client> ConnectWithTimeoutAsync(int timeoutSeconds = 3)
        {
            var connectionTask = GetClientAsync();
            var timeoutTask = Task.Delay(TimeSpan.FromSeconds(timeoutSeconds));

            var completedTask = await Task.WhenAny(connectionTask, timeoutTask);

            if (completedTask == timeoutTask)
            {
                throw new TimeoutException($"El servidor no respondió en {timeoutSeconds} segundos.");
            }

            return await connectionTask;
        }
    }
}