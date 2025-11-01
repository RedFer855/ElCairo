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
        public string Nombre { get; set; }

        [Column("apellido_empleado")]
        public string Apellido { get; set; }

        [Column("dni_empleado")]
        public string Dni { get; set; }

        [Column("telefono_empleado")]
        public string Telefono { get; set; }

        [Column("email_empleado")]
        public string Email { get; set; }

        [Column("direccion_empleado")]
        public string Direccion { get; set; }
    }


}
