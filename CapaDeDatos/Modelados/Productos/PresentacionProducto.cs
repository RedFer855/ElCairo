using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados.Productos
{
    [Table("presentacion_producto")]
    public class PresentacionProducto : BaseModel
    {
        [PrimaryKey("id_presentacion", false)]
        public int IdPresentacionProducto { get; set; }

        [Column("descripcion_presentacion")]
        public string DescripcionPresentacionPresentacionProducto { get; set; }
    }

}
