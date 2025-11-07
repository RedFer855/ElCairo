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
    public class Usuario: BaseModel
    {
        [PrimaryKey("id_empleado", false)]
        public int Id { get; set; }

        [Column("alias_usuario")]
        public string Alias { get; set; }

        [Column("id_rol")]
        public string Rol { get; set; }

        [Column("estado_usuario")]
        public bool Estado { get; set; }



    }
}
