using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados.UsuariosEmpleados
{
    [Table("acciones")]
    public class acciones : BaseModel
    {
        [PrimaryKey("id_accion", false)]
        public int Id { get; set; }

        [Column("nombre_accion")]
        public string NombreAccion { get; set; }

        [Column("id_modulo")]
        public int IdModulo { get; set; }
    }
}



