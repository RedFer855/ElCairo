using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supabase;
using Supabase.Postgrest.Attributes;


namespace CapaDeDatos.Modelados
{
    [Table("usuario")]
    public class Usuario : BaseModel
    {
        [PrimaryKey("user_id", false)] // Le decimos que 'user_id' es la PK
        [Column("id_empleado")]
        public int EmpleadoUsuario { get; set; } // Tipo: int

        [Column("alias_usuario")]
        public string AliasUsuario { get; set; } // Tipo: string

        [Column("id_rol")]
        public int RolUsuario { get; set; } // Tipo: int

        [Column("estado_usuario")]
        public bool EstadoUsuario { get; set; } // Tipo: bool

        [Column("user_id")]
        public string Uuid { get; set; } // Tipo: string (para el UUID)
    }
}
