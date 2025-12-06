using CapaDeDatos.Datos;
using CapaDeDatos.Modelados.Inventario;
using CapaDeDatos.Modelados.UsuariosEmpleados;
using Supabase.Gotrue;
using Supabase.Gotrue.Exceptions;
using Supabase.Postgrest.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Supabase.Postgrest.Constants;


namespace CapaDeDatos.Repositorios
{
    public class UsuarioRepositorio
    {
        public async Task<Supabase.Client> GetClient()
        {
            return await Conexion.ConnectWithTimeoutAsync(3);
        }

        public async Task RegistrarUsuario(string email, string password)
        {
            try
            {
                var client = await GetClient();
                await client.Auth.SignUp(email, password);
                //return session;
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

        public async Task UsuarioEmail(string Email_Nuevo)
        {
            try
            {
                var client = await GetClient();

                var attrs = new UserAttributes { Email = Email_Nuevo };
                var response = await client.Auth.Update(attrs);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el correo {ex.Message}");
            }
        }
        public async Task OtrosValores(CambiosUsuario cambios)
        {
            CambiosUsuario cambiosUsuario = cambios;
            try
            {
                var client = await GetClient();
                var result = await client.From<Usuario>()
                                        .Where(u => u.IdUsuario == cambiosUsuario.IdEmpleado)
                                        .Set(u => u.RolUsuario, cambiosUsuario.NuevoRol)
                                        .Set(u => u.EstadoUsuario, cambiosUsuario.NuevoEstado)
                                        .Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el rol o el estado del Usuario {ex.Message}");
            }
            finally
            {
                MessageBox.Show("Usuario actualizado exitosamente");
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

        //esto es para obtener los roles y despues cargarlos en el dgv, falta hacer un join para cargar solo los nombres 
        public async Task<List<Rol>> ObtenerTodosLosUsuariosRoles(CancellationToken cancellationToken = default)
        {
            try
            {
                var client = await GetClient();
                var roles = await client.From<Rol>().Get();
                return roles.Models;
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

        public async Task<List<Rol>> ObtenerRolesSegunUsuario(int rolUsuarioActual)
        {
            try
            {
                var client = await GetClient();
                var roles = await client.From<Rol>().Get();
                var lista = roles.Models;

                // Si es Administrador (1)
                if (rolUsuarioActual == 1)
                {
                    // Solo vendedor (2) y cajero (3)
                    lista = lista.Where(r => r.IdRol == 2 || r.IdRol == 3).ToList();
                }

                // Si es SuperAdmin (4), devolver todos
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al cargar roles: {ex.Message}");
            }
        }

        public class CambiosUsuario
        {
            public int IdEmpleado { get; set; }
            public int NuevoRol { get; set; }
            public bool NuevoEstado { get; set; }
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

        public async Task<bool> VerificarPrimerUsoAsync()
        {
            try
            {
                var client = await GetClient();

                // 🚨 CORRECCIÓN CLAVE: El método Rpc<bool> devuelve directamente el valor bool.
                // No hay necesidad de acceder a .Models ni a .First().

                // La variable 'esPrimerUso' será true o false, según la función de Postgres.
                bool esPrimerUso = await client.Rpc<bool>("verificar_primer_uso", null);

                // Retornamos directamente el resultado de la función SQL.
                return esPrimerUso;
            }
            catch (Exception ex)
            {
                // En caso de error de conexión/permisos, lanzamos la excepción.
                throw new Exception($"Error al llamar a la función de verificación de estado: {ex.Message}");
            }
        }


        public async Task<Usuario> CrearUsuarioAdminFinalAsync(string email, string password)
        {
            try
            {
                var client = await GetClient();

                // 1. CREAR LA CUENTA EN SUPABASE AUTH (GoTrue)
                // Esto crea el registro en la tabla de autenticación de Supabase.
                var session = await client.Auth.SignUp(email, password);

                if (session.User == null)
                    throw new Exception("Supabase Auth no devolvió un usuario válido.");

                // 2. CREAR EL PERFIL EN TU TABLA 'usuario' (Postgrest)
                var perfilACrear = new Usuario
                {
                    // Usamos el UUID de Supabase Auth para vincular
                    Uuid = session.User.Id,
                    AliasUsuario = email,
                    RolUsuario = 4, // Asumimos 4 es el ID del rol SuperAdministrador (INT)
                    EstadoUsuario = true
                    // La contraseña NO se guarda aquí, ya la maneja Supabase Auth.
                };

                // Inserta el perfil en tu tabla 'usuario'
                var response = await client.From<Usuario>().Insert(perfilACrear);

                // Devuelve el modelo insertado (perfil) que tiene el ID_EMPLEADO generado
                return response.Models.FirstOrDefault();
            }
            catch (GotrueException ex)
            {
                throw new Exception($"Error de autenticación al crear admin: {ex.Message}");
            }
            catch (PostgrestException ex)
            {
                throw new Exception($"Error de BD al crear perfil de admin: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado en creación de admin: {ex.Message}");
            }
        }

    }
}