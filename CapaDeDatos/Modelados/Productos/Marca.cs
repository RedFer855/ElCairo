using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados.Productos
{
    [Table("marca")]
    public class Marca : BaseModel
    {
        [PrimaryKey("id_marca", false)]
        public int IdMarca { get; set; }

        [Column("nombre_marca")]
        public string NombreMarca { get; set; }

        [Column("id_proveedor")]
        public int IdProveedor { get; set; }

        [Column("estado_marca")]
        public bool EstadoMarca { get; set; }

        [Column("id_estado")]
        public int IdEstado { get; set; }
    }
}
