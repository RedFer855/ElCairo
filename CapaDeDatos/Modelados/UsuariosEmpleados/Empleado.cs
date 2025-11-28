using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados
{
    [Table("empleado")]
    public class Empleado : BaseModel
    {
        [PrimaryKey("id_empleado", false)]
        public int Id { get; set; }

        [Column("nombre_empleado")]
        public string NombreEmpleado { get; set; }

        [Column("apellido_empleado")]
        public string ApellidoEmpleado { get; set; }

        [Column("dni_empleado")]
        public string DniEmpleado { get; set; }

        [Column("telefono_empleado")]
        public string TelefonoEmpleado { get; set; }

        [Column("email_empleado")]
        public string EmailEmpleado { get; set; }

        [Column("direccion_empleado")]
        public string DireccionEmpleado { get; set; }
        
        [Column("estado_empleado")]
        public bool EstadoEmpleado { get; set; }

        public override string ToString()
        {
            return NombreEmpleado + ApellidoEmpleado;
        }
    }


}
