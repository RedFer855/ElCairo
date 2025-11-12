using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados.Reporteria.Reporteria
{
    [Table("detalle_reporte")]
    public class DetalleReporte : BaseModel
    {
        [PrimaryKey("id_detalle_reporte", false)]
        public int Id { get; set; }

        [Column("id_reporte")]
        public int IdReporte { get; set; }

        [Column("descripcion")]
        public string Descripcion { get; set; }
    }

}
