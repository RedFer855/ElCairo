using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados
{
    [Table("cliente")]
    public class Cliente : BaseModel
    {
        [PrimaryKey("id_cliente", false)]
        public int Id { get; set; }

        [Column("nombre_cliente")]
        public string Nombre { get; set; }

        [Column("apellido_cliente")]
        public string Apellido { get; set; }

        [Column("telefono_cliente")]
        public string Telefono { get; set; }

        [Column("email_cliente")]
        public string Email { get; set; }

        [Column("direccion_cliente")]
        public string Direccion { get; set; }
    }

}
