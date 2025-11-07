using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using Supabase.Gotrue;
using Supabase.Gotrue.Exceptions;
using Supabase.Postgrest.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Repositorios
{
    public class UsuarioRepositorio
    {
        // Helper para obtener el cliente, igual que en EmpleadoRepositorio
        private async Task<Supabase.Client> GetClient()
        {
            return await Conexion.ConnectWithTimeoutAsync(3);
        }

        /// <summary>
        /// Registra un nuevo usuario en Supabase Auth.
        /// </summary>
        public async Task<Session> RegistrarUsuario(string email, string password)
        {
            try
            {
                var client = await GetClient();
                // Opcionalmente puedes pasar datos extra aquí (ej. nombre)
                // var options = new SignUpOptions { Data = new Dictionary<string, object> { { "nombre_completo", "..." } } };
                var session = await client.Auth.SignUp(email, password);
                return session;
            }
            catch (GotrueException ex)
            {
                // Errores de registro (ej. "User already registered")
                throw new Exception($"Error de registro: {ex.Message}", ex);
            }
            catch (System.Net.WebException ex)
            {
                throw new Exception("Error de red al intentar registrarse: " + ex.Message, ex);
            }
            catch (TimeoutException ex)
            {
                throw new Exception("El servidor de registro tardó demasiado en responder.", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado en Registro: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene los datos de un usuario desde una tabla 'usuarios' (lógica de Postgrest).
        /// Asume que tienes un modelo 'Usuario.cs' similar a 'Empleado.cs'.
        /// </summary>
        public async Task<Usuario> ObtenerDatosUsuario(string uuid, CancellationToken cancellationToken = default)
        {
            // Esta lógica es casi idéntica a 'ObtenerTodosLosEmpleados'
            try
            {
                var client = await GetClient();
                var response = await client.From<Usuario>()
                                         .Where(u => u.Uuid == uuid) // Asumiendo que 'Usuario' tiene una prop 'Uuid'
                                         .Single(cancellationToken);

                return response;
            }
            catch (PostgrestException ex)
            {
                // Error de base de datos (ej. no encontrado, o RLS lo impide)
                throw new Exception($"Error de base de datos al cargar usuario: {ex.Message}", ex);
            }
            catch (OperationCanceledException ex) when (cancellationToken.IsCancellationRequested)
            {
                throw new TimeoutException("Tiempo de espera agotado...", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo cargar el usuario. Verifique la conexión.", ex);
            }
        }

        public async Task<List<Usuario>> ObtenerTodosLosUsuarios(CancellationToken cancellationToken = default)
        {
            try
            {
                var client = await GetClient();

                var queryBuilder = client.From<Usuario>()
                                         .Order("alias_usuario", Supabase.Postgrest.Constants.Ordering.Ascending);

                var response = await queryBuilder.Get(cancellationToken);
                return response.Models ?? new List<Usuario>();
            }
            catch (PostgrestException ex)
            {
                throw new Exception($"Error de base de datos al cargar usuarios: {ex.Message}", ex);
            }
            catch (OperationCanceledException)
            {
                throw new TimeoutException("La consulta de usuarios fue cancelada por timeout.");
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron cargar los usuarios. Verifique la conexión.", ex);
            }
        }


    }
}
