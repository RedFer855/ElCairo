using CapaDeDatos.Modelados;
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
        // 1. CAMPOS EXISTENTES (No se tocan)
        private static User UsuarioActual;
        private static String Rol;

        // 2. CAMPO NUEVO (Se añade)
        // Guardará el contexto completo con permisos
        public static UsuarioContexto Contexto { get; private set; }

        // 3. MÉTODO EXISTENTE (No se toca)
        // Tu código antiguo puede seguir llamando a este método sin problemas.
        public static void IniciarSesion(User usuarioAutenticado, string rol)
        {
            UsuarioActual = usuarioAutenticado;
            Rol = rol;
        }

        // 4. MÉTODO NUEVO (Se añade)
        // Este es el que llamará tu 'frmInicioSesion'
        public static void IniciarSesion(User usuarioAutenticado, UsuarioContexto contexto)
        {
            UsuarioActual = usuarioAutenticado;
            Contexto = contexto; // Guarda el nuevo contexto

            // (Opcional, pero recomendado)
            // También actualiza el 'Rol' antiguo para mantener consistencia
            if (contexto != null && contexto.Rol != null)
            {
                Rol = contexto.Rol.NombreRolRol; // Asumiendo que tu modelo Rol tiene 'NombreRolRol'
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

        // 6. OBTENER ROL (Se hace más inteligente)
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
