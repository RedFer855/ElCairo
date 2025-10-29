using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class Empleado : BaseModel
    {
        // 3. Define la llave primaria
        [PrimaryKey("id_empleado", true)]
        public int Id { get; set; }

        // 4. Mapea cada columna de la base de datos a una propiedad
        [Column("nombre_empleado")]
        public string Nombre { get; set; }

        // ¡AQUÍ ESTÁ LA CORRECCIÓN IMPORTANTE!
        // El nombre debe ser idéntico al de tu base de datos (con la 'e')
        [Column("apellido_empled`o`")]
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
