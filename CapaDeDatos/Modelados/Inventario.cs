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
        // Mapeo Correcto: id_inventario -> IdInventario
        [PrimaryKey("id_inventario", false)]
        public int IdInventario { get; set; }

        // Mapeo Correcto: id_producto -> IdProductoInventario
        [Column("id_producto")]
        public int IdProductoInventario { get; set; }

        // Mapeo Correcto: id_bodega -> IdBodegaInventario
        [Column("id_bodega")]
        public int IdBodegaInventario { get; set; }

        // Mapeo Correcto: stock_producto_bodega -> StockProductoBodegaInventario
        [Column("stock_producto_bodega")]
        public int StockProductoBodegaInventario { get; set; }

        // Mapeo Correcto: stock_minimo_producto_bodega -> StockMinimoProductoBodegaInventario
        [Column("stock_minimo_producto_bodega")]
        public int StockMinimoProductoBodegaInventario { get; set; }
    }

}
