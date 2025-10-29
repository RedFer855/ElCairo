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
    // 2. MODELO EMPLEADO (AHORA DENTRO DEL NAMESPACE PRINCIPAL)
    [Table("empleado")] // El nombre de tu tabla
    public class Empleado : BaseModel
    {
        [PrimaryKey("id_empleado", true)]
        public int Id { get; set; }

        [Column("nombre_empleado")]
        public string Nombre { get; set; }

        [Column("apellido_empleado")]
        public string Apellido { get; set; }

        [Column("dni_empleado")]
        public string Dni { get; set; }

        [Column("telefono_empleado")]
        public string Telefono { get; set; }

        [Column("email_empleado")]
        public string Email { get; set; }

        [Column("direccion_empleado")]
        public string Direccion { get; set; }
    }

    // CLASE DE MODELO (sin cambios)
    [Table("usuario")]
    public class Usuario_ : BaseModel
    {
        [Column("alias_usuario")]
        public string Name { get; set; }

        [Column("contrasenia_usuario")]
        public string password { get; set; } // Contraseña en texto plano (Inseguro)
    }

    public class clsConexion
    {
        public static Supabase.Client _supabaseClient { get; private set; }

        // MÉTODOS AUXILIARES: Creación de Cliente y Manejo de Timeout

        // 1. Obtiene o inicializa el cliente (sin manejo de timeout aquí)
        public static async Task<Client> GetClientAsync()
        {
            if (_supabaseClient != null)
            {
                return _supabaseClient;
            }

            DotNetEnv.Env.Load();
            string supabaseUrl = Environment.GetEnvironmentVariable("SUPABASE_URL");
            string supabaseKey = Environment.GetEnvironmentVariable("SUPABASE_KEY");

            if (string.IsNullOrEmpty(supabaseUrl) || string.IsNullOrEmpty(supabaseKey))
            {
                // Lanza una excepción para que el formulario sepa que el error es de configuración
                throw new ApplicationException("SUPABASE_URL o SUPABASE_KEY no están configuradas.");
            }

            var options = new SupabaseOptions { AutoRefreshToken = true, AutoConnectRealtime = true };
            _supabaseClient = new Supabase.Client(supabaseUrl, supabaseKey, options);
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

        // 3. LÓGICA PRINCIPAL DE INICIO DE SESIÓN
        public static async Task<Usuario_> Iniciar_Sesion(string username, string Password_)
        {
            try
            {
                // 1. Intentar la conexión con límite de tiempo
                var client = await ConnectWithTimeoutAsync(10);

                // 2. Búsqueda y comparación de credenciales
                var response = await client.From<Usuario_>()
                    .Where(x => x.Name == username)
                    .Where(x => x.password == Password_)
                    .Get();

                return response.Models.FirstOrDefault();
            }
            catch (TimeoutException tex)
            {
                // El servidor tardó demasiado. Relanza para que el formulario lo maneje.
                throw tex;
            }
            catch (ApplicationException aex)
            {
                // Variables de entorno. Relanza para manejo fatal.
                throw aex;
            }
            catch (Exception ex)
            {
                // Captura CUALQUIER otro error, que probablemente sea de red (Wi-Fi apagado, DNS, etc.)
                // **IMPORTANTE:** Relanzamos la excepción para que el formulario sepa que es un fallo de red.
                // Si no relanzas, el formulario asume que el resultado es 'null' (credenciales inválidas).

                // Loguea el error real (opcional pero recomendado)
                Console.WriteLine($"Error de Red/Sistema: {ex.Message}");

                // Relanzar el error genérico como un error de conexión para distinguirlo del login fallido.
                throw new System.Net.WebException("Fallo al establecer la conexión con el servidor. Verifique su conexión a Internet.", ex);
            }
        }

        public static async Task InsertarEmpleado(Empleado nuevoEmpleado)
        {
            try
            {
                var client = await ConnectWithTimeoutAsync(10);
                await client.From<Empleado>().Insert(nuevoEmpleado);
            }
            catch (System.Net.WebException ex)
            {
                throw new Exception("Error de red al guardar empleado: " + ex.Message, ex);
            }
            catch (TimeoutException ex)
            {
                throw new Exception("El servidor tardó demasiado en responder.", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de Supabase: {ex.Message}");
                throw new Exception("Error al guardar el empleado en la base de datos.", ex);
            }
        }
    }
}

