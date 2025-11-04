using Supabase.Postgrest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados
{
    [Table("bitacora_empleado")]
    public class Bitocora_Empleado : BaseModel
    {
        [Column("id_bitacora")]
        public int Id_Bitacora_Empleado { get; set; }

        [Column("id_empleado")]
        public int Id_Empleado { get; set; }

        [Column("estado_anterior")]
        public string Estado_Anterior { get; set; }

        [Column("estado_actual")]
        public string Estado_Actual { get; set; }

        [Column("campo_afectado")]
        public string Campo_Afectado { get; set; }

        [Column("fecha_hora")]
        public DateTime Fecha_Hora { get; set; }

        [Column("campo_extra")]
        public string Accion_Realizada { get; set; }

        [Column("id_accion")]
        public int Id_Accion { get; set; }


        [Column("id_modulo")]
        public int Id_Modulo { get; set; }

    }
}
