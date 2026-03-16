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

    public class BodegaVista
    {
        public int IdBodega { get; set; }
        public string NombreBodega { get; set; }
        public string NombreDepartamento { get; set; }
        public string DireccionSucursal { get; set; }
        public string TelefonoSucursal { get; set; }
        public bool EstadoBodega { get; set; }
    }
}
