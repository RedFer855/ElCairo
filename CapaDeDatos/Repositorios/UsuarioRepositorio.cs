using CapaDeDatos.Datos;
using CapaDeDatos.Modelados.UsuariosEmpleados;
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
        public async Task<Supabase.Client> GetClient()
        {
            return await Conexion.ConnectWithTimeoutAsync(3);
        }

        public async Task<Session> RegistrarUsuario(string email, string password)
        {
            try
            {
                var client = await GetClient();
                var session = await client.Auth.SignUp(email, password);
                return session;
            }
            catch (GotrueException ex)
            {

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

        public static async Task ActualizarUsuario(Usuario UsuarioActualizado)
        {
            try
            {
                var client = await Conexion.ConnectWithTimeoutAsync(10);
                await client.From<Usuario>().Update(UsuarioActualizado);
            }
            catch (System.Net.WebException ex)
            {
                throw new Exception("Error de red al actualizar usuario: " + ex.Message, ex);
            }
            catch (TimeoutException ex)
            {
                throw new Exception("El servidor tardó demasiado en responder.", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de Supabase al actualizar: {ex.Message}");
                throw; //new Exception("Error al actualizar el empleado en la base de datos.", ex);
            }
        }

        public async Task<Usuario> ObtenerDatosUsuario(string uuid, CancellationToken cancellationToken = default)
        {
            try
            {
                var client = await GetClient(); // Asumo que ya tienes este helper
                var response = await client.From<Usuario>()
                    .Where(u => u.Uuid == uuid) // Filtra por el UUID de Auth
                    .Single(cancellationToken); // Espera un único resultado

                return response;
            }
            catch (PostgrestException ex)
            {
                // Error de base de datos (ej. no encontrado, o RLS lo impide)
                throw new Exception($"Error de base de datos al cargar usuario: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo cargar el usuario. Verifique la conexión.", ex);
            }
        }
        // Asegúrate de: using Supabase.Gotrue;

        public async Task<User> IniciarSesionConToken(string refreshToken)
        {
            var client = await GetClient();
            try
            {
                string tokenFalsoCaducado = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjEsInN1YiI6IjEyMyJ9.falsesig";                // 1. Inyectamos la sesión manualmente usando el Refresh Token
                await client.Auth.SetSession(
                    accessToken: tokenFalsoCaducado,
                    refreshToken: refreshToken,     // Tenemos el de la huella
                    forceAccessTokenRefresh: true   // ¡Dame uno nuevo ya!
                );

                // 2. Obtenemos el usuario SIN await (porque es una propiedad)
                var user = client.Auth.CurrentUser;

                if (user == null) throw new Exception("Usuario no encontrado.");

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception($"SUPABASE ERROR: {ex.Message}");
            }
        }
    }
}