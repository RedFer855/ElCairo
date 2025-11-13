using CapaDeDatos.Modelados;
using CapaDeDatos.Repositorios;
using System;
using System.Threading.Tasks;

namespace CapaServiciosSeguridadValidacion
{
    public class ServicioUsuarios
    {
        /*private readonly UsuarioRepositorio _usuarioRepo;
        private readonly SeguridadRepositorio _seguridadRepo;

        public ServicioUsuarios()
        {
            _usuarioRepo = new UsuarioRepositorio();
            _seguridadRepo = new SeguridadRepositorio();
        }

        private bool PuedeAsignarRol(int idRolAsignable, int idRolActual)
        {
            // SuperAdministrador puede asignar cualquier rol
            if (idRolActual == 4) return true;

            // Administrador solo puede asignar Cajero (2) y Vendedor (3)
            if (idRolActual == 1 && (idRolAsignable == 2 || idRolAsignable == 3)) return true;

            // Otros no pueden asignar nada
            return false;
        }
        public async Task ActualizarUsuarioConValidacionAsync(Usuario usuarioEditado, UsuarioContexto usuarioActual)
        {
            // 🔒 No puede cambiarse su propio rol
            if (usuarioActual.UsuarioId == usuarioEditado.Uuid &&
                usuarioEditado.RolUsuario != usuarioActual.Rol.IdRol)
            {
                throw new InvalidOperationException("No puedes cambiar tu propio rol.");
            }

            // 🔒 No puede asignar un rol que no está permitido
            if (!PuedeAsignarRol(usuarioEditado.RolUsuario, usuarioActual.Rol.IdRol))
            {
                throw new UnauthorizedAccessException("No tienes permiso para asignar ese rol.");
            }

            // 🔒 No puede modificar a otro usuario con rol igual o superior (excepto si es SuperAdministrador)
            var rolActualDelEditado = await _seguridadRepo.ObtenerRolDeUsuario(usuarioEditado.Uuid);
            if (!PuedeAsignarRol(rolActualDelEditado.IdRol, usuarioActual.Rol.IdRol))
            {
                throw new UnauthorizedAccessException("No puedes modificar a un usuario con rol igual o superior al tuyo.");
            }

            // ✅ Si pasa todas las validaciones, se actualiza
            await _usuarioRepo.ActualizarUsuario(usuarioEditado);
        }
        public async Task ActualizarUsuarioParcialAsync(string uuid, Dictionary<string, object> cambios, UsuarioContexto usuarioSesion)
        {
            // Si se intenta cambiar el rol
            if (cambios.ContainsKey("id_rol"))
            {
                int nuevoRol = Convert.ToInt32(cambios["id_rol"]);

                // Caso: Administrador en sesión
                if (usuarioSesion.Rol.IdRol == 1) // Administrador
                {
                    // No puede cambiar su propio rol
                    if (usuarioSesion.UsuarioId == uuid)
                        throw new Exception("Un Administrador no puede cambiar su propio rol ni editarse a sí mismo.");

                    // No puede degradar/promover a otro Administrador
                    if (nuevoRol == 1)
                        throw new Exception("Un Administrador no puede asignar el rol de Administrador a otro usuario.");

                    // Solo puede modificar usuarios de rol inferior
                    // (ejemplo: Cajero=2, Vendedor=3)
                    if (nuevoRol < usuarioSesion.Rol.IdRol)
                        throw new Exception("Un Administrador no puede modificar usuarios de su mismo nivel o superior.");
                }

                // Caso: SuperAdministrador en sesión
                if (usuarioSesion.Rol.IdRol == 4) // SuperAdministrador
                {
                    // SuperAdmin puede modificar cualquier usuario
                    // No se aplican restricciones adicionales
                }

                // Caso: otros roles
                if (usuarioSesion.Rol.IdRol != 1 && usuarioSesion.Rol.IdRol != 4)
                {
                    throw new Exception("Solo Administradores o SuperAdministradores pueden modificar usuarios.");
                }
            }

            // 🔹 Ejecutar el update si pasó las validaciones
            var repo = new UsuarioRepositorio();
            await repo.ActualizarUsuarioParcial(uuid, cambios);
        }
    }*/
    }
}
