using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados.UsuariosEmpleados
{
    [Table("modulos")]
    public class Modulo : BaseModel
    {
        [PrimaryKey("id_modulo", false)]
        public int IdModulo { get; set; }

        [Column("nombre_modulo")]
        public string NombreModuloModulo { get; set; }
    }

}
