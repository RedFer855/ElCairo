using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados
{
    [Table("ventas")]
    public class Venta : BaseModel
    {
        [PrimaryKey("id_venta", false)]
        public int IdVenta { get; set; }

        [Column("id_cliente")]
        public int IdCliente { get; set; }

        [Column("id_rutas")]
        public int IdRutasVenta { get; set; }

        [Column("id_empleado")]
        public int IdEmpleado { get; set; }

        [Column("fecha_venta")]
        public DateTime FechaVenta { get; set; }
    }

}
