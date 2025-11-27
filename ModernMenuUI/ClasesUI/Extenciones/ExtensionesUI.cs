using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModernMenuUI.ClasesUI.Extenciones
{
    public static class ExtensionesUI
    {
        public static void ActivarDobleBuffer(this DataGridView dgv)
        {
            // Validación de seguridad: Si dgv es nulo, no hacemos nada
            if (dgv == null) return;

            // Validación de entorno: En sesiones remotas (RDP) el doble buffer puede ser lento
            if (SystemInformation.TerminalServerSession) return;

            // Magia de Reflexión: Accedemos a la propiedad protegida "DoubleBuffered"
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                BindingFlags.NonPublic |
                BindingFlags.Instance |
                BindingFlags.SetProperty,
                null, dgv, new object[] { true });
        }
    }
}
