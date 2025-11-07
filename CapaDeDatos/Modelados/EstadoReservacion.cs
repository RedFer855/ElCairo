using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados
{
    [Table("estado_reservacion")]
    public class EstadoReservacion : BaseModel
    {
        [PrimaryKey("id_estado", false)]
        public int Id { get; set; }

        [Column("nombre_estado")]
        public string NombreEstado { get; set; }
    }

}
