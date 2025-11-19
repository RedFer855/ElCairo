using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernMenuUI.Utilidades
{
    public static class SessionData
    {
        public static int IdBodegaActual { get; set; } = 0;

        public static string NombreBodegaActual { get; set; } = string.Empty;

        public static void LimpiarSesion()
        {
            IdBodegaActual = 0;
            NombreBodegaActual = string.Empty;
        }
    }
}
