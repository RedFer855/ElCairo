using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados
{
    [Table("compras")]
    public class Compra : BaseModel
    {
        [PrimaryKey("id_compra", false)]
        public int IdCompra { get; set; }

        [Column("id_proveedor")]
        public int IdProveedor { get; set; }

        [Column("id_empleado")]
        public int IdEmpleado { get; set; }

        [Column("fecha_compra")]
        public DateTime FechaCompra { get; set; }

    }

}
