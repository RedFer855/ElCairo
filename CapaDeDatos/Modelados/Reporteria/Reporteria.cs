using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados.Reporteria.Reporteria
{
    [Table("reporteria")]
    public class Reporteria : BaseModel
    {
        [PrimaryKey("id_reporteria", false)]
        public int IdReporteria { get; set; }

        [Column("id_empleado")]
        public int IdEmpleadoReporteria { get; set; }

        [Column("id_modulo")]
        public int IdModuloReporteria { get; set; }

        [Column("fecha_generacion")]
        public DateTime FechaGeneracionReporteria { get; set; } // Mapeo de 'date' a DateTime

        [Column("id_tipo_formato")]
        public int IdTipoFormatoReporteria { get; set; }

        [Column("id_tipo_reportes")]
        public int IdTipoReportesReporteria { get; set; }
    }

}
