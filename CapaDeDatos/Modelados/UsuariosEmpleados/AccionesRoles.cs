using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados.UsuariosEmpleados
{
    
    
        [Table("acciones_roles")]
        public class AccionRol : BaseModel
        {
            [PrimaryKey("id_accion_rol", false)]
            public int Id { get; set; }

            [Column("id_accion")]
            public int IdAccion { get; set; }

            [Column("id_rol")]
            public int IdRol { get; set; }
        }

    
}
