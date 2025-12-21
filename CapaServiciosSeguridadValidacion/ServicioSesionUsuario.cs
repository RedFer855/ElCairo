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

        public static void IniciarSesion(User usuarioAutenticado, UsuarioContexto contexto)
        {
            UsuarioActual = usuarioAutenticado;
            Contexto = contexto;

            if (contexto != null && contexto.Rol != null)
            {
                Rol = contexto.Rol.NombreRolRol;
            }
        }


        public static void AsignarBodegaActual(Bodega bodega)
        {
            BodegaActual = bodega;
        }
        public static void CerrarSesion()
        {
            UsuarioActual = null;
            Contexto = null;
            Rol = null;
            BodegaActual = null;
        }

        public static string ObtenerEmailUsuario()
        {
            return UsuarioActual?.Email ?? "Usuario Desconocido";
        }

        public static string ObtenerRolUsuario()
        {
            if (UsuarioActual == null) return "Rol Desconocido";

            if (Contexto?.Rol != null) return "Rol: " + Contexto.Rol.NombreRolRol;

            if (!string.IsNullOrEmpty(Rol)) return "Rol: " + Rol;

            return "Rol no asignado";
        }

        public static string ObtenerIdUsuario()
        {
            return UsuarioActual?.Id ?? string.Empty;
        }

        public static bool SesionActiva => UsuarioActual != null;

        public static string ObtenerNombreBodega()
        {
            return BodegaActual?.NombreBodega ?? "Bodega Desconocida";
        }

        public static int ObtenerIdBodega()
        {
            return BodegaActual?.IdBodega ?? -1;
        }
    }
}
