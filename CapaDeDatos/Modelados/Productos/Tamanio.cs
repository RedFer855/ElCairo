using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados.Productos
{
    [Table("tamanio")]
    public class Tamanio : BaseModel
    {
        [PrimaryKey("id_tamanio", false)]
        public int IdTamanio { get; set; }

        [Column("descripcion_tamanio")]
        public string DescripcionTamanio { get; set; }

        [Column("unidad_medida")]
        public string UnidadMedidaTamanio { get; set; }
    }

}
