using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supabase;
using Supabase.Gotrue;

namespace CapaServiciosSeguridadValidacion
{
    public static class ServicioSesionUsuario
    {
        // 1. Un lugar privado y estático para guardar el usuario autenticado
        private static User UsuarioActual;
        private static String Rol;


        public static void IniciarSesion(User usuarioAutenticado, string rol)
        {
            UsuarioActual = usuarioAutenticado;
            Rol = rol;
        }

       
        public static void CerrarSesion()
        {
            UsuarioActual = null;
        }

        public static string ObtenerEmailUsuario()
        {
            if (UsuarioActual != null)
            {
                return UsuarioActual.Email;
            }
            return "Usuario Desconocido";
        }

        public static string ObtenerRolUsuario()
        {
            if (UsuarioActual != null)
            {
                return "Rol: " + Rol;
            }
            return "Rol Desconocido";
        }
        public static string ObtenerIdUsuario()
        {
            return UsuarioActual?.Id ?? string.Empty;
        }

        public static bool SesionActiva
        {
            get { return UsuarioActual != null; }
        }
    }
}
