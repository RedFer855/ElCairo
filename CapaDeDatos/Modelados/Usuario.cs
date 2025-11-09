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
        // Clave Primaria (PK)
        [PrimaryKey("id_empleado", false)]
        public int IdEmpleado { get; set; }

        // Alias del Usuario
        [Column("alias_usuario")]
        public string AliasUsuario { get; set; }

        // FK Rol
        [Column("id_rol")]
        public int IdRol { get; set; }

        // FK Estado
        [Column("id_estado")]
        public int IdEstado { get; set; }

        // Estado Booleano
        [Column("estado_usuario")]
        public bool EstadoUsuario { get; set; }

        // ID de Supabase Auth (uuid se mapea a Guid)
        [Column("user_id")]
        public Guid UserId { get; set; }
    }
}
