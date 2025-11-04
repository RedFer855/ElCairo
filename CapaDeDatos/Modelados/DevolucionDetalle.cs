using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados
{
    [Table("devolucion_detalle")]
    public class DevolucionDetalle : BaseModel
    {
        [PrimaryKey("id_devolucion_detalle", false)]
        public int Id { get; set; }

        [Column("id_devolucion")]
        public int IdDevolucion { get; set; }

        [Column("id_producto")]
        public int IdProducto { get; set; }

        [Column("cantidad")]
        public int Cantidad { get; set; }
    }

}
