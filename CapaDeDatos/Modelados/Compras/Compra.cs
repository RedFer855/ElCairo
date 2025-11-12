using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados.Compras
{
    [Table("compras")]
    public class Compra : BaseModel
    {
        [PrimaryKey("id_compra", false)]
        public int Id { get; set; }

        [Column("id_proveedor")]
        public int IdProveedor { get; set; }

        [Column("fecha_compra")]
        public DateTime FechaCompra { get; set; }

        [Column("total_compra")]
        public decimal TotalCompra { get; set; }
    }

}
