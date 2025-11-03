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
        private static User _usuarioActual;

       
        public static void IniciarSesion(User usuarioAutenticado)
        {
            _usuarioActual = usuarioAutenticado;
        }

       
        public static void CerrarSesion()
        {
            _usuarioActual = null;
        }

        public static string ObtenerEmailUsuario()
        {
            if (_usuarioActual != null)
            {
                return _usuarioActual.Email;
            }
            return "Usuario Desconocido";
        }

        public static string ObtenerIdUsuario()
        {
            return _usuarioActual?.Id ?? string.Empty;
        }

        public static bool SesionActiva
        {
            get { return _usuarioActual != null; }
        }
    }
}
