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

        [PrimaryKey("id_producto")]
        public int IdProductoInventario { get; set; }

        // Objeto anidado para el JOIN de Producto
        public Producto producto { get; set; }

        [PrimaryKey("id_bodega")]
        public int IdBodegaInventario { get; set; }

        
        // Objeto anidado para el JOIN de Bodega
        public Bodega bodega { get; set; }

        

        [Column("stock_producto_bodega")]
        public int StockProductoBodegaInventario { get; set; }

        [Column("stock_minimo_producto_bodega")]
        public int StockMinimoProductoBodegaInventario { get; set; }

        // Propiedad de ayuda para el DataGridView (si AutoGenerateColumns = true)
        public string NombreProducto
        {
            get { return producto?.NombreProducto ?? "N/A"; }
        }
        
        // Propiedad de ayuda para el DataGridView
        public string NombreBodega
        {
            get { return bodega?.NombreBodega ?? "N/A"; }
        }
        
    }

}
