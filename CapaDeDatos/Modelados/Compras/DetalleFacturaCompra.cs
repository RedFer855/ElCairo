using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados.Compras
{
    [Table("detalle_factura_compra")]
    public class DetalleFacturaCompra : BaseModel
    {
        [PrimaryKey("id_detalle_compra", false)]
        public int Id { get; set; }

        [Column("id_compra")]
        public int IdCompra { get; set; }

        [Column("id_producto")]
        public int IdProducto { get; set; }

        [Column("cantidad")]
        public int Cantidad { get; set; }

        [Column("precio_unitario")]
        public decimal PrecioUnitario { get; set; }
    }

}
