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
        [PrimaryKey("Id_Bitacora", false)]
        public int Id_Bitacora { get; set; }

        [Column("descripcion_cambio")]
        public string Descripcion { get; set; }

        [Column("fecha_hora")]
        public DateTime Fecha_Hora { get; set; } = DateTime.Now;
        [Column("datos_comp")]
        public string datos_comp { get; set; }

    }
}
