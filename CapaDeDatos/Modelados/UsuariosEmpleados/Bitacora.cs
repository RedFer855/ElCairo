using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados.UsuariosEmpleados
{
    [Table("bitacora_empleado")]
    public class Bitacora : BaseModel
    {
        [Column("id_bitacora")]
        public int IdBitacoraEmpleado { get; set; }

        [Column("id_empleado")]
        public int IdEmpleado { get; set; }

        public Usuario Usuario { get; set; }

        public string NombreEmpleado => Usuario?.AliasUsuario ?? "Desconocido";

        [Column("estado_anterior")]
        public string EstadoAnterior { get; set; }

        [Column("estado_actual")]
        public string EstadoActual { get; set; }

        [Column("campo_afectado")]
        public string CampoAfectado { get; set; }

        [Column("fecha_hora")]
        public DateTime FechaHora { get; set; }

        [Column("accion")]
        public string AccionRealizada { get; set; }

        [Column("modulo")]
        public string Modulo { get; set; }

        [Column("usuario_host")]
        public string UsuarioHost { get; set; }
       
        [Column("nombre_host")]
        public string NombreHost { get; set; }


    }
}
