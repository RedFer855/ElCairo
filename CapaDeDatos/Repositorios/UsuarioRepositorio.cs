using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using Supabase.Gotrue;
using Supabase.Gotrue.Exceptions;
using Supabase.Postgrest.Exceptions;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Supabase.Postgrest.Constants;

namespace CapaDeDatos.Repositorios
{
    public class UsuarioRepositorio
    {
        // Helper para obtener el cliente, igual que en EmpleadoRepositorio
        public async Task<Supabase.Client> GetClient()
        {
            return await Conexion.ConnectWithTimeoutAsync(3);
        }
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

        public async Task ActualizarUsuario(Usuario usuarioActualizado)
        {
            /* try
             {
                 var client = await GetClient();

                 // Actualiza en tu tabla usuario
                      var response = await client
                     .From<Usuario>()
                     .Filter("user_id", Operator.Equals, usuarioActualizado.Uuid)
                     .Update(usuarioActualizado);

                 if (response.Models == null || response.Models.Count == 0)
                     throw new Exception("No se pudo actualizar el usuario. Verifica el UUID.");

                 // 🔹 Sincroniza también en Supabase Auth usando tu procedimiento almacenado
                 var user = client.Auth.CurrentUser;
                 if (user != null)
                 {
                     await client.Rpc("sync_usuario_email", new
                     {
                         p_user_id = user.Id,
                         p_nuevo_email = usuarioActualizado.AliasUsuario
                     });
                 }
             }
             catch (PostgrestException ex)
             {
                 throw new Exception($"Error de base de datos al actualizar usuario: {ex.Message}", ex);
             }
             catch (Exception ex)
             {
                 throw new Exception("Error inesperado al actualizar el usuario.", ex);
             }*/
        }

        /*private Usuario MapearCambiosAUsuario(string uuid, Dictionary<string, object> cambios)
        {
           /* var usuario = new Usuario
            {
                Uuid = uuid
            };

            if (cambios.ContainsKey("alias_usuario"))
                usuario.AliasUsuario = cambios["alias_usuario"]?.ToString();

            if (cambios.ContainsKey("id_rol"))
                usuario.RolUsuario = Convert.ToInt32(cambios["id_rol"]);

            if (cambios.ContainsKey("estado_usuario"))
                usuario.EstadoUsuario = Convert.ToBoolean(cambios["estado_usuario"]);

            if (cambios.ContainsKey("id_estado"))
                usuario.IdEstado = Convert.ToInt32(cambios["id_estado"]);

            return usuario;
        }*/

        public async Task ActualizarUsuarioParcial(string uuid, Dictionary<string, object> cambios)
        {
            try
            {
                var client = await GetClient();

                if (cambios == null || cambios.Count == 0)
                    return; // Nada que actualizar

                // Ejecuta un update directo pasando solo los campos cambiados
                var response = await client
                    .From<Usuario>()
                    .Filter("user_id", Operator.Equals, uuid)
                    .Update();

                if (response.Models == null || response.Models.Count == 0)
                    throw new Exception("No se pudo actualizar el usuario. Verifica el UUID o las políticas RLS.");
            }
            catch (PostgrestException ex)
            {
                throw new Exception($"Error de base de datos al actualizar usuario: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado al actualizar el usuario: {ex.Message}", ex);
            }
        }
    }
}
