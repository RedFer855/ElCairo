using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernMenuUI.Utilidades
{
    public static class SessionData
    {
        // Aquí guardaremos el ID de la bodega actual
        public static int IdBodegaActual { get; set; } = 0;

        // Opcional: Guardar el nombre para mostrarlo en etiquetas
        public static string NombreBodegaActual { get; set; } = string.Empty;

        // Método para limpiar datos al cerrar sesión
        public static void LimpiarSesion()
        {
            IdBodegaActual = 0;
            NombreBodegaActual = string.Empty;
        }
    }
}
