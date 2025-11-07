using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados
{
    [Table("inventario")]
    public class Inventario : BaseModel
    {
        [PrimaryKey("id_inventario", false)]
        public int IdInventario { get; set; }

        [Column("id_producto")]
        public int IdProductoInventario { get; set; }

        [Column("id_bodega")]
        public int IdBodegaInventario { get; set; }

        [Column("stock_producto_bodega")]
        public int StockProductoBodegaInventario { get; set; }

        [Column("stock_minimo_producto_bodega")]
        public int StockMinimoProductoBodegaInventario { get; set; }
    }

}
