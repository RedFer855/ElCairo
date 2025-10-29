using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supabase;
using Supabase.Postgrest.Attributes;


namespace CapaDeDatos
{
    [Table("usuario")]
    public class Usuario: BaseModel
    {
        [Column("alias_usuario")]
        public string Name { get; set; }

        [Column("contrasenia_usuario")]
        public string password { get; set; }
    }
}
