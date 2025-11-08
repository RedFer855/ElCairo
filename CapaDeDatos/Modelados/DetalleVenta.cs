using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados
{
    [Table("detalle_venta")]
    public class DetalleVenta : BaseModel
    {
        // ---
        // NOTA: Esta tabla no tiene una clave primaria 'id_detalle_venta' visible.
        // Se asume que 'id_venta' y 'id_producto' juntas son la clave.
        // Para insertar (INSERT), esto funcionará perfectamente.
        // ---

        [Column("id_venta")]
        public int IdVenta { get; set; }

        [Column("id_producto")]
        public int IdProducto { get; set; }

        // Esta es la columna que causaba el error
        [Column("cantidad_venta")]
        public int CantidadVenta { get; set; }

        [Column("id_bodega")]
        public int IdBodega { get; set; }

    }
}
