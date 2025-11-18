using CapaDeDatos.Modelados.Inventario;
using CapaDeDatos.Modelados.UsuariosEmpleados;
using CapaDeDatos.Repositorios;
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
        // Usuario autenticado
        private static User UsuarioActual;

        // Contexto con roles y permisos
        public static UsuarioContexto Contexto { get; private set; }

        // Bodega seleccionada
        public static Bodega BodegaActual { get; private set; }

        // Rol del usuario
        private static string Rol;

        /// <summary>
        /// Inicializa sesión con usuario y contexto.
        /// </summary>
        public static void IniciarSesion(User usuarioAutenticado, UsuarioContexto contexto)
        {
            UsuarioActual = usuarioAutenticado;
            Contexto = contexto;

            if (contexto != null && contexto.Rol != null)
            {
                Rol = contexto.Rol.NombreRolRol;
            }
        }

        /// <summary>
        /// Asigna la bodega actual seleccionada.
        /// </summary>
        public static void AsignarBodegaActual(Bodega bodega)
        {
            BodegaActual = bodega;
        }

        /// <summary>
        /// Cierra sesión y limpia toda la información.
        /// </summary>
        public static void CerrarSesion()
        {
            UsuarioActual = null;
            Contexto = null;
            Rol = null;
            BodegaActual = null;
        }

        /// <summary>
        /// Obtiene el email del usuario actual.
        /// </summary>
        public static string ObtenerEmailUsuario()
        {
            return UsuarioActual?.Email ?? "Usuario Desconocido";
        }

        /// <summary>
        /// Obtiene el rol del usuario actual.
        /// </summary>
        public static string ObtenerRolUsuario()
        {
            if (UsuarioActual == null) return "Rol Desconocido";

            if (Contexto?.Rol != null) return "Rol: " + Contexto.Rol.NombreRolRol;

            if (!string.IsNullOrEmpty(Rol)) return "Rol: " + Rol;

            return "Rol no asignado";
        }

        /// <summary>
        /// Obtiene el ID del usuario actual.
        /// </summary>
        public static string ObtenerIdUsuario()
        {
            return UsuarioActual?.Id ?? string.Empty;
        }

        /// <summary>
        /// Indica si hay sesión activa.
        /// </summary>
        public static bool SesionActiva => UsuarioActual != null;

        /// <summary>
        /// Devuelve el nombre de la bodega actual.
        /// </summary>
        public static string ObtenerNombreBodega()
        {
            return "Bodega: " + BodegaActual?.NombreBodega ?? "Bodega Desconocida";
        }

        /// <summary>
        /// Devuelve el ID de la bodega actual.
        /// </summary>
        public static int ObtenerIdBodega()
        {
            return BodegaActual?.IdBodega ?? -1;
        }
    }
}
