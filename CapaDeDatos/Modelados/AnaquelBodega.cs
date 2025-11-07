using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados
{
    [Table("anaquel_bodega")]
    public class AnaquelBodega : BaseModel
    {
        [PrimaryKey("id_anaquel", false)]
        public int Id { get; set; }

        [Column("id_bodega")]
        public int IdBodega { get; set; }

        [Column("descripcion")]
        public string Descripcion { get; set; }
    }

}
