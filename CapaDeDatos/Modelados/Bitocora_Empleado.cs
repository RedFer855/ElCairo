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
        
        [Column("Id_Empleado")]
        public int Id_Empleado { get; set; }
        
        [Column("Estado_Anterior")]
        public string Estado_Anterior { get; set; }

        [Column("Estado_Actual")]
        public string Estado_Actual { get; set; }

        [Column("Campo_Afectado")]
        public string Campo_Afectado { get; set; }

        [Column("Fecha_Hora")]
        public DateTime Fecha_Hora { get; set; }

        [Column("Campo_Extra")]
        public string Campo_Extra { get; set; }

        [Column("Id_Accion")]
        public int Id_Accion { get; set; }

        [Column("Id_Modulo")]
        public int Id_Modulo { get; set; }
        
    }
}
