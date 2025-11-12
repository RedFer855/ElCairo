using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados.Inventario
{
    [Table("bodega")]
    public class Bodega : BaseModel
    {
        [PrimaryKey("id_bodega", false)]
        public int IdBodega { get; set; }

        [Column("Contrasenia_Bodega")]
        public string ContraseniaBodega { get; set; }

        [Column("estado_bodega")]

        public bool EstadoBodega { get; set; }

        [Column("nombre_bodega")]
        public string NombreBodega { get; set; }
    }

}
