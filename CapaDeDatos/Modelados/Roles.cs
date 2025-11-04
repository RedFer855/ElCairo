using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados
{
    [Table("roles")]
    public class Rol : BaseModel
    {
        // Clave Primaria (PK)
        [PrimaryKey("id_rol", false)]
        public int IdRol { get; set; }

        // Nombre del Rol
        [Column("nombre_rol")]
        public string NombreRol { get; set; }

        // FK Estado
        [Column("id_estado")]
        public int IdEstadoRol { get; set; }

        // Estado Booleano
        [Column("estado_rol")]
        public bool EstadoRolRol { get; set; }
    }

}
