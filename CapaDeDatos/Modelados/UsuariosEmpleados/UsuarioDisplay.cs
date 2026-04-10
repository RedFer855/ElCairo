using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supabase;
using Supabase.Postgrest.Attributes;

namespace CapaDeDatos.Modelados.UsuariosEmpleados
{
    [Table("usuario")]

    public class UsuarioDisplay : BaseModel
    {
        [PrimaryKey("id_empleado", false)]
        public int IdUsuario { get; set; }

        [Column("alias_usuario")]
        public string AliasUsuario { get; set; }

        [Column("id_rol")]
        public int RolUsuario { get; set; }

        public Rol Roles { get; set; }
        public string NombreRol => Roles?.NombreRolRol ?? "Desconocido";

        [Column("estado_usuario")]
        public bool EstadoUsuario { get; set; }

        [Column("user_id")]
        public string Uuid { get; set; }
    }
}
