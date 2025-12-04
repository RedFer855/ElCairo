using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaDeDatos.Modelados
{
    [Table("fn_cierre_diario")]
    public class CierreDiarioResult : BaseModel
    {
        [PrimaryKey("idventa", false)]
        [Column("idventa")]
        public int IdVenta { get; set; }


        [Column("fecha_venta")]
        public DateTime FechaVenta { get; set; }

        [Column("producto")]
        public string Producto { get; set; }

        [Column("cantidad")]
        public int Cantidad { get; set; }

        [Column("precio")]
        public decimal Precio { get; set; }

        [Column("subtotal")]
        public decimal Subtotal { get; set; }
    }
}