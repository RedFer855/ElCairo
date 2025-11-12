using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados.Reporteria.Reporteria
{
    [Table("tipo_reportes")]
    public class TipoReporte : BaseModel
    {
        [PrimaryKey("id_tipo_reportes", false)]
        public int IdTipoReporte { get; set; }

        [Column("nombre_tipo_reportes")]
        public string NombreTipoReporte { get; set; }
    }

}
