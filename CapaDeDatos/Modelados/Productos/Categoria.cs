using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados.Productos
{
    [Table("categoria")]
    public class Categoria : BaseModel
    {
        [PrimaryKey("id_categoria", false)]
        public int IdCategoria { get; set; }

        [Column("nombre_categoria")]
        public string NombreCategoria { get; set; }

        [Column("descripcion_categoria")]
        public string DescripcionCategoria { get; set; }

        [Column("estado_categoria")]
        public bool EstadoCategoria { get; set; }

        [Column("id_estado")]
        public int IdEstado { get; set; }

        public override string ToString()
        {
            return NombreCategoria;
        }
    }
}
