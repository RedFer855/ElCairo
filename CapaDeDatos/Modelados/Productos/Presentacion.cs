using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados.Productos
{
    [Table("presentacion")]
    public class Presentacion : BaseModel
    {
        [PrimaryKey("id_presentacion", false)]
        public int IdPresentacionProducto { get; set; }

        [Column("nombre_presentacion")]
        public string NombrePresentacion { get; set; }

        [Column("detalle_presentacion")]
        public string DetallePresentacion { get; set; }

        [Column("estado_presentacion")]
        public bool EstadoPresentacion { get; set; }    
        public override string ToString()
        {
            return NombrePresentacion;
        }

    }
}
