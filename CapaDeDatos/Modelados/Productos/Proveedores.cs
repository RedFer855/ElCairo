using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados.Productos
{
    [Table("proveedores")]
    public class Proveedor : BaseModel
    {
        [PrimaryKey("id_proveedor", false)]
        public int IdProveedor { get; set; }

        [Column("nombre_proveedor")]
        public string NombreProveedor { get; set; }

        [Column("telefono_proveedor")]
        public string TelefonoProveedor { get; set; }

        [Column("direccion_proveedor")]
        public string DireccionProveedor { get; set; }

        [Column("id_estado")]
        public int IdEstadoProveedor { get; set; }

        [Column("estado_proveedor")]
        public bool EstadoProveedor { get; set; }
    }

}
