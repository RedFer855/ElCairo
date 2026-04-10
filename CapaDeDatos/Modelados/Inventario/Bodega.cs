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
    [Table("bodega")]
    public class Bodega : BaseModel
    {
        [PrimaryKey("id_bodega", false)]
        public int IdBodega { get; set; }

        [Column("Contrasenia_Bodega")]
        public string ContraseniaBodega { get; set; }

        [Column("nombre_bodega")]
        public string NombreBodega { get; set; }

        [Column("id_departamento")]
        public short IdDepartamento { get; set; }
        public Departamentos Departamento { get; set; }
        public string NombreDepartamento_ => Departamento?.NombreDepartamento ?? "Sin Departamento";

        [Column("direccion_sucursal")]
        public string DireccionSucursal { get; set; }

        [Column("telefono_sucursal")]
        public string TelefonoSucursal { get; set; }

        [Column("estado_bodega")]
        public bool EstadoBodega  { get; set; }

        public override string ToString()
        {
            return NombreBodega;
        }

    }

}
