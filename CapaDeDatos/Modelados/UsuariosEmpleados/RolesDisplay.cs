using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados.UsuariosEmpleados
{
    [Table("roles")]
    public class RolesDisplay : BaseModel
    {
        [PrimaryKey("id_rol", false)]
        public int IdRol { get; set; }

        [Column("nombre_rol")]
        public string NombreRol { get; set; }

        [Column("id_estado")]
        public int IdEstadoRol { get; set; }

        [Column("estado_rol")]
        public bool EstadoRolRol { get; set; }
    }

}
