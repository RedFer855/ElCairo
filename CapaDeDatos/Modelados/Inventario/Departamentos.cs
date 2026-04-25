using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Supabase.Postgrest.Attributes; // Asegúrese de tener esto para [Table] y [Column]
using Supabase.Postgrest.Models;
using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;

namespace CapaDeDatos.Modelados.Inventario
{
    [Table("departamentos")]
    public class Departamentos : BaseModel
    {
        [PrimaryKey("id_departamento", false)]
        public short IdDepartamento { get; set; }

        [Column("nombre_departamento")]
        public string NombreDepartamento { get; set; }

    }
}
