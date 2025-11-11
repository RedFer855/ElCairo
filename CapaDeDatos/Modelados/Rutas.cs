using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados
{
    [Table("rutas")]
    public class Ruta : BaseModel
    {
        [PrimaryKey("id_rutas", false)]
        public int IdRuta { get; set; }

        [Column("nombre_rutas")]
        public string NombreRuta { get; set; }

        [Column("descripcion_ruta")]
        public string DescripcionRuta { get; set; }

        [Column("latitud_ruta")]
        public decimal LatitudRuta { get; set; }

        [Column("longitud_ruta")]
        public decimal LongitudRuta { get; set; }

        [Column("id_empleado")]
        public int IdEmpleadoRuta { get; set; }

        [Column("id_estado")]
        public int IdEstadoRuta { get; set; }

        [Column("estado_ruta")]
        public bool EstadoRuta { get; set; }
    }

}
