using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados.ModeladosVistas
{
    [Table("vista_inventario_completo")]
    public class VistaInventario : BaseModel
    {
        [PrimaryKey("id_inventario", false)]
        public int IdInventario { get; set; }

        [Column("id_producto")]
        public int IdProducto { get; set; }

        [Column("id_bodega")]
        public int IdBodega { get; set; }

        // --- CAMPOS "PLANOS" (YA NO ESTÁN ANIDADOS) ---

        [Column("nombre_producto")]
        public string NombreProducto { get; set; }

        [Column("nombre_bodega")]
        public string NombreBodega { get; set; }

        [Column("stock_producto_bodega")]
        public int StockActual { get; set; } // Le puedes poner el nombre que quieras

        [Column("stock_minimo_producto_bodega")]
        public int StockMinimo { get; set; } // Le puedes poner el nombre que quieras

        // --- ¡EL CAMPO CALCULADO! ---
        [Column("nivel_stock")]
        public string NivelStock { get; set; }
    }
}
