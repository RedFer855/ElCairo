using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernMenuUI.ClasesUI
{
    public class CalculadoraResolucion
    {
        // TAMAÑOS BASE (Diseñados en 1080p según tus instrucciones)
        private const int BaseRefWidth = 1920; // Ancho Monitor Full HD
        private const int BaseOpen = 300;      // Tu medida en 1080p
        private const int BaseClosed = 100;    // Tu medida en 1080p

        // LÍMITES (Para evitar extremos feos en 720p o 4K)
        private const int MinOpen = 200;       // Nunca menos de esto (para que quepa texto)
        private const int MaxOpen = 450;       // Nunca más de esto (aunque sea 4K)

        // CONFIGURACIÓN BASE PARA NOTIFICACIONES (Referencia 1080p)
        private const int BaseNotifWidth = 350; // Ancho ideal en Full HD

        // Definimos límites para que no se vea ni muy flaco ni gigante
        private const int MinNotif = 300; // Mínimo para ver bien el texto
        private const int MaxNotif = 500; // Máximo en 4K


        // Estructura para devolver ambos valores juntos
        public struct DimensionesMenu
        {
            public int AnchoAbierto;
            public int AnchoCerrado;
        }

        public static int ObtenerAnchoNotificaciones()
        {
            int monitorActual = Screen.PrimaryScreen.Bounds.Width;

            // Usamos la misma constante BaseRefWidth (1920) que ya tenías arriba
            double factor = (double)monitorActual / 1920;

            // Calculamos el ancho ideal escalado
            int anchoCalculado = (int)Math.Round(BaseNotifWidth * factor);

            // Aplicamos límites (Clamp)
            return Math.Max(MinNotif, Math.Min(MaxNotif, anchoCalculado));
        }

        /// <summary>
        /// Calcula los tamaños basándose en la resolución REAL del monitor principal.
        /// </summary>
        public static DimensionesMenu ObtenerDimensionesOptimas()
        {
            // 1. Obtener ancho físico del monitor principal
            int monitorActual = Screen.PrimaryScreen.Bounds.Width;

            // 2. Factor de escala: (MonitorActual / 1920)
            // Ejemplo: Si es 4K (3840), el factor será 2.0. Si es 720p (1280), será 0.66
            double factor = (double)monitorActual / BaseRefWidth;

            // 3. Calcular nuevos tamaños aplicando el factor
            int nuevoAbierto = (int)Math.Round(BaseOpen * factor);
            int nuevoCerrado = (int)Math.Round(BaseClosed * factor);

            // 4. Aplicar límites de seguridad (Clamping)
            // Para el abierto: Respetamos minimos y maximos lógicos
            nuevoAbierto = Math.Max(MinOpen, Math.Min(MaxOpen, nuevoAbierto));

            // Para el cerrado: Aseguramos que al menos tenga 70px para los iconos
            nuevoCerrado = Math.Max(70, nuevoCerrado);

            return new DimensionesMenu
            {
                AnchoAbierto = nuevoAbierto,
                AnchoCerrado = nuevoCerrado
            };
        }
    }
}
