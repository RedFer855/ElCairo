using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados.Ventas
{
    [Table("cliente")]
    public class Cliente : BaseModel
    {
        [PrimaryKey("id_cliente", false)]
        public int IdCliente { get; set; }

        [Column("nombre_cliente")]
        public string NombreCliente { get; set; }
        
        [Column("correo_cliente")]
        public string CorreoCliente { get; set; }

        [Column("direccion_cliente")]
        public string DireccionCliente { get; set; }

        [Column("telefono_cliente")]
        public string TelefonoCliente { get; set; }

        [Column("dni_cliente")]
        public string DniCliente { get; set; }

        [Column("rtn_cliente")]
        public string RtnCliente { get; set; }

        [Column("estado_cliente")]
        public bool EstadoCliente { get; set; }

        public override string ToString()
        {
            return NombreCliente;
        }

    }

}
