using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados.Productos
{
    public class Impuesto
    {
        [PrimaryKey("id_impuesto", false)]
        public int IdImpuesto { get; set; }

        [Column("descripcion_impuesto")]
        public string DescripcionImpuesto { get; set; }

        [Column("porcentaje_impuesto")]
        public decimal PorcentajeImpuesto { get; set; } 
    }
}
