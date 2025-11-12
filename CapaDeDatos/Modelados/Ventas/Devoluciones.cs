using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados.Ventas
{
    [Table("devoluciones")]
    public class Devolucion : BaseModel
    {
        [PrimaryKey("id_devolucion", false)]
        public int Id { get; set; }

        [Column("id_venta")]
        public int IdVenta { get; set; }

        [Column("fecha_devolucion")]
        public DateTime FechaDevolucion { get; set; }
    }

}
