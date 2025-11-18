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
        // 👇 ESTA ES LA QUE TE FALTA O ESTÁ MAL ESCRITA
        [PrimaryKey("id_producto", false)]
        public int IdProducto { get; set; }

        [Column("id_bodega")]
        public int IdBodega { get; set; }

        // Esta la usamos para obtener la cantidad real
        [Column("stock_producto_bodega")]
        public int StockActual { get; set; }

        [Column("stock_minimo_producto_bodega")]
        public int StockMinimo { get; set; }
    }

}
