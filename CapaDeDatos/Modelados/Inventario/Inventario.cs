using CapaDeDatos.Modelados.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados.Inventario
{
    [Table("inventario")]
    public class Inventario : BaseModel
    {

        [PrimaryKey("id_producto")]
        public int IdProductoInventario { get; set; }

        public Producto producto { get; set; }

        [PrimaryKey("id_bodega")]
        public int IdBodegaInventario { get; set; }

        public Bodega bodega { get; set; }

        [Column("stock_producto_bodega")]
        public int StockProductoBodegaInventario { get; set; }

        [Column("stock_minimo_producto_bodega")]
        public int StockMinimoProductoBodegaInventario { get; set; }

        public string NombreProducto
        {
            get { return producto?.NombreProducto ?? "N/A"; }
        }

        public string NombreBodega
        {
            get { return bodega?.NombreBodega ?? "N/A"; }
        }

        public string CodigoBarraProducto
        {
            get { return producto?.CodigoBarraProducto ?? "N/A"; }
        }

        public string NombreCategoria
        {
            get { return producto?.NombreCategoria ?? "N/A"; }
        }

        public string NombreMarca
        {
            get { return producto?.NombreMarca ?? "N/A"; }

        }

        public string NombrePresentacion
        {
            get { return producto?.NombrePresentacion ?? "N/A"; }
        }

        public string ContenidoProducto
        {
            get { return producto?.ContenidoProducto ?? "N/A"; }
        }

        public override string ToString()
        {
            // Esto une las palabras con espacio, ignorando las que sean nulas o vacías
            return string.Join(" ", new[] { NombreProducto, NombreMarca, NombrePresentacion, ContenidoProducto }
                   .Where(s => !string.IsNullOrEmpty(s)));
        }
    }    
}
