using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados
{
    [Table("estado")]
    public class Estado : BaseModel
    {
        [PrimaryKey("id_estado", false)]
        public int IdEstado { get; set; }

        [Column("descripcion_estado")]
        public string DescripcionEstado { get; set; }
    }
}
