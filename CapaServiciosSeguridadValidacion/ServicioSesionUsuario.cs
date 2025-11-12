using CapaDeDatos.Modelados.UsuariosEmpleados;
using Supabase;
using Supabase.Gotrue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaServiciosSeguridadValidacion
{
    public static class ServicioSesionUsuario
    {
        private static User UsuarioActual;
        private static String Rol;


        public static UsuarioContexto Contexto { get; private set; }


        public static void IniciarSesion(User usuarioAutenticado, string rol)
        {
            UsuarioActual = usuarioAutenticado;
            Rol = rol;
        }

        public static void IniciarSesion(User usuarioAutenticado, UsuarioContexto contexto)
        {
            UsuarioActual = usuarioAutenticado;
            Contexto = contexto; // Guarda el nuevo contexto


            if (contexto != null && contexto.Rol != null)
            {
                Rol = contexto.Rol.NombreRolRol; 
            }
        }

        // 5. MÉTODO CERRAR SESIÓN (Se actualiza)
        public static void CerrarSesion()
        {
            UsuarioActual = null;
            Rol = null; // Limpia el campo antiguo
            Contexto = null; // <-- AÑADIDO: Limpia el campo nuevo
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
            if (UsuarioActual == null)
            {
                return "Rol Desconocido";
            }

            // Prioridad 1: Intenta usar el nuevo Contexto
            if (Contexto != null && Contexto.Rol != null)
            {
                return "Rol: " + Contexto.Rol.NombreRolRol;
            }

            // Prioridad 2: Si no, usa el string 'Rol' antiguo
            if (!string.IsNullOrEmpty(Rol))
            {
                return "Rol: " + Rol;
            }

            return "Rol no asignado";
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
