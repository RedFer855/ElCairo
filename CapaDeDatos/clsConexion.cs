using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetEnv;
using Supabase;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;



namespace CapaDeDatos
{
    [Table("usuario")]
    public class Usuario_ : BaseModel
    {
        [Column("alias_usuario")]
        public string Name { get; set; }

        [Column("contrasenia_usuario")]
        public string password { get; set; }
    }
    public class clsConexion
    {

        public static Supabase.Client _supabaseClient { get; private set; }


        [STAThread]
        public static async Task<Client> GetClientAsync()
        {

            DotNetEnv.Env.Load();
            string supabaseUrl = Environment.GetEnvironmentVariable("SUPABASE_URL");
            string supabaseKey = Environment.GetEnvironmentVariable("SUPABASE_KEY");

            var options = new SupabaseOptions
            {
                AutoRefreshToken = true,
                AutoConnectRealtime = true
            };


            if (string.IsNullOrEmpty(supabaseUrl) || string.IsNullOrEmpty(supabaseKey))
            {
                MessageBox.Show("Las variables de entorno SUPABASE_URL o SUPABASE_KEY no están configuradas.", "Error de configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null; // Termina la aplicación si faltan credenciales
            }

            _supabaseClient = new Supabase.Client(supabaseUrl, supabaseKey, options);
            //inicializa al cliente para que pueda conectars
            await _supabaseClient.InitializeAsync();
            
            return _supabaseClient;
        }
        public static async Task<Usuario_> Iniciar_Sesion(string username, string Password_)
        {
            try
            {
                var response = await _supabaseClient.From<Usuario_>()
                    .Where(x => x.Name == username)
                    .Where(x => x.password == Password_)
                    .Get();

                return response.Models.FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hubo un problema al buscar la tabla {ex.Message}");
                return null;
            }
        }

    }


}

