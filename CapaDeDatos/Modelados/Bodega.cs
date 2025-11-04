using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados
{
    [Table("bodega")]
    public class Bodega : BaseModel
    {
        [PrimaryKey("id_bodega", false)]
        public int Id { get; set; }

        [Column("nombre_bodega")]
        public string NombreBodega { get; set; }

        [Column("ubicacion")]
        public string Ubicacion { get; set; }
    }

}
