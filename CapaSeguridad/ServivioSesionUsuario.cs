using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supabase.Gotrue;
using Supabase;

namespace CapaSeguridad
{
    internal class ServivioSesionUsuario
    {
        public static class ServicioSesionUsuario
        {
            // 1. Un lugar privado y estático para guardar el usuario autenticado
            private static User _usuarioActual;

            /// <summary>
            /// Inicia la sesión. Se debe llamar 1 VEZ al hacer login.
            /// </summary>
            public static void IniciarSesion(User usuarioAutenticado)
            {
                _usuarioActual = usuarioAutenticado;
            }

            /// <summary>
            /// Cierra la sesión. Se debe llamar al hacer logout.
            /// </summary>
            public static void CerrarSesion()
            {
                _usuarioActual = null;
            }

            /// <summary>
            /// Método seguro para que la UI obtenga el email del usuario actual.
            /// </summary>
            public static string ObtenerEmailUsuario()
            {
                if (_usuarioActual != null)
                {
                    return _usuarioActual.Email;
                }
                return "Usuario Desconocido";
            }

            /// <summary>
            /// Método seguro para que la UI obtenga el ID (UUID) del usuario.
            /// </summary>
            public static string ObtenerIdUsuario()
            {
                return _usuarioActual?.Id ?? string.Empty;
            }

            /// <summary>
            /// Verifica si hay una sesión activa.
            /// </summary>
            public static bool SesionActiva
            {
                get { return _usuarioActual != null; }
            }
        }
    }
}
