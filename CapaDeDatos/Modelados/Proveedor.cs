using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados
{
    [Table("proveedores")]
    public class Proveedor : BaseModel
    {
        // Mapeo Correcto: id_proveedor -> IdProveedor
        [PrimaryKey("id_proveedor", false)]
        public int IdProveedor { get; set; }

        // Mapeo Correcto: nombre_proveedor -> NombreProveedorProveedor
        [Column("nombre_proveedor")]
        public string NombreProveedor { get; set; }

        // Mapeo Correcto: telefono_proveedor -> TelefonoProveedorProveedor
        [Column("telefono_proveedor")]
        public string TelefonoProveedor { get; set; }

        // Mapeo Correcto: direccion_proveedor -> DireccionProveedorProveedor
        [Column("direccion_proveedor")]
        public string DireccionProveedor { get; set; }

        // Mapeo Correcto: id_estado -> IdEstadoProveedor
        [Column("id_estado")]
        public int IdEstadoProveedor { get; set; }

        // Mapeo Correcto: estado_proveedor -> EstadoProveedorProveedor
        [Column("estado_proveedor")]
        public bool EstadoProveedor { get; set; }
    }

}
