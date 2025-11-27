using System;
using System.Drawing;
using System.Windows.Forms;

namespace ModernMenuUI.ClasesUI
{
    public class CalculadoraResolucion
    {
        // TUS MEDIDAS EXACTAS (Base 1080p al 100%)
        private const int BaseAbierto = 300;
        private const int BaseCerrado = 100;
        private const int BaseNotif = 350;

        public struct DimensionesMenu
        {
            public int AnchoAbierto;
            public int AnchoCerrado;
        }

        // Detecta si la pantalla está al 100%, 125%, 320%, etc.
        private static float ObtenerFactorEscala()
        {
            using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
            {
                // 96 DPI es el 100%. 
                return g.DpiX / 96.0f;
            }
        }

        public static int ObtenerAnchoNotificaciones()
        {
            return (int)(BaseNotif * ObtenerFactorEscala());
        }

        public static DimensionesMenu ObtenerDimensionesOptimas()
        {
            float factor = ObtenerFactorEscala();

            return new DimensionesMenu
            {
                // En tu PC (100%): 300 * 1 = 300
                // En PC amigo (320%): 300 * 3.2 = 960 (Necesario para que quepa el texto grande)
                AnchoAbierto = (int)(BaseAbierto * factor),
                AnchoCerrado = (int)(BaseCerrado * factor)
            };
        }
    }
}