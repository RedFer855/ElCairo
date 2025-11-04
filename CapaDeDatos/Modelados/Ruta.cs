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
        // Clave Primaria (PK)
        [PrimaryKey("id_rutas", false)]
        public int IdRuta { get; set; }

        // Nombre de las Rutas
        [Column("nombre_rutas")]
        public string NombreRutasRuta { get; set; }

        // Descripción
        [Column("descripcion_ruta")]
        public string DescripcionRutaRuta { get; set; }

        // Latitud (usamos decimal para 'numeric')
        [Column("latitud_ruta")]
        public decimal LatitudRutaRuta { get; set; }

        // Longitud (usamos decimal para 'numeric')
        [Column("longitud_ruta")]
        public decimal LongitudRutaRuta { get; set; }

        // FK Empleado
        [Column("id_empleado")]
        public int IdEmpleadoRuta { get; set; }

        // FK Estado
        [Column("id_estado")]
        public int IdEstadoRuta { get; set; }

        // Estado Booleano
        [Column("estado_ruta")]
        public bool EstadoRutaRuta { get; set; }
    }

}
