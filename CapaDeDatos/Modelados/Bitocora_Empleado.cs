using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados
{
    internal class Bitocora_Empleado
    {
        public class BitacoraEmpleado
        {
            public int Id_Bitacora { get; set; }
            public int Id_Empleado { get; set; }
            public string Estado_Anterior { get; set; }
            public string Estado_Actual { get; set; }
            public string Campo_Afectado { get; set; }
            public DateTime Fecha_Hora { get; set; }
            public string Campo_Extra { get; set; }
            public int Id_Accion { get; set; }
            public int Id_Modulo { get; set; }
        }
    }
}
