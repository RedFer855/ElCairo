using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados
{
    [Table("producto")] // El nombre exacto de tu tabla
    public class Producto: BaseModel
    {
        [PrimaryKey("id_producto", false)] // 'false' para que la BD genere el ID
        public int Id { get; set; }

        [Column("nombre_producto")]
        public string Nombre { get; set; }

        [Column("id_marca")]
        public int IdMarca { get; set; }

        [Column("id_categoria")]
        public int IdCategoria { get; set; }

        [Column("codigo_barra_producto")]
        public string CodigoBarra { get; set; }

        [Column("id_presentacion")]
        public int IdPresentacion { get; set; }

        [Column("id_tamanio")]
        public int IdTamanio { get; set; }

        [Column("precio_compra")]
        public decimal PrecioCompra { get; set; } // 'numeric' se mapea a 'decimal'

        [Column("precio_costo")]
        public decimal PrecioCosto { get; set; }

        [Column("precio_venta")]
        public decimal PrecioVenta { get; set; }

        [Column("porcentaje_ganancia_producto")] // Nombre completo corregido
        public decimal PorcentajeGanancia { get; set; }

        [Column("id_estado")]
        public int IdEstado { get; set; }

        [Column("estado_producto")]
        public bool? Estado { get; set; } // Corregido a 'bool?' porque es 'nullable'

        [Column("cantidad_producto")] 
        public int Cantidad { get; set; }
    }
}
