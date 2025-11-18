using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados.Inventario.Productos
{
    [Table("reservacion_producto")]
    public class ReservacionProducto : BaseModel
    {
        [PrimaryKey("id_reservacion_producto", false)]
        public int IdReservacionProducto { get; set; }

        [Column("id_empleado")]
        public int IdEmpleadoReservacionProducto { get; set; }

        [Column("id_producto")]
        public int IdProductoReservacionProducto { get; set; }

        [Column("id_anaquel_bodega")]
        public int IdAnaquelBodegaReservacionProducto { get; set; }

        [Column("fecha_reservacion")]
        public DateTime FechaReservacionReservacionProducto { get; set; }

        [Column("cantidad_reservada")]
        public int CantidadReservadaReservacionProducto { get; set; }

        [Column("id_estado_reservacion")]
        public int IdEstadoReservacionReservacionProducto { get; set; }

        
        [Column("observacion_reservacion")]
        public string ObservacionReservacionReservacionProducto { get; set; }
    }

}
