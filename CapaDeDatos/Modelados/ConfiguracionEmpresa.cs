using Newtonsoft.Json;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;

namespace CapaDeDatos.Modelados
{
    [Table("configuracion_empresa")]
    public class ConfiguracionEmpresa : BaseModel
    {
        [PrimaryKey("id_empresa", false)]
        [JsonProperty("id_empresa")]
        public int IdEmpresa { get; set; }

        [Column("nombre_empresa")]
        [JsonProperty("nombre_empresa")]
        public string NombreEmpresa { get; set; }

        [Column("rtn_empresa")]
        [JsonProperty("rtn_empresa")]
        public string RtnEmpresa { get; set; }

        [Column("direccion_empresa")]
        [JsonProperty("direccion_empresa")]
        public string DireccionEmpresa { get; set; }

        [Column("telefono_empresa")]
        [JsonProperty("telefono_empresa")]
        public string TelefonoEmpresa { get; set; }

        [Column("correo_empresa")]
        [JsonProperty("correo_empresa")]
        public string CorreoEmpresa { get; set; }

        [Column("cai_empresa")]
        [JsonProperty("cai_empresa")]
        public string CaiEmpresa { get; set; }

        [Column("rango_autorizado")]
        [JsonProperty("rango_autorizado")]
        public string RangoAutorizado { get; set; }

        [Column("fecha_limite_emision")]
        [JsonProperty("fecha_limite_emision")]
        public DateTime? FechaLimiteEmision { get; set; }

        [Column("id_estado")]
        [JsonProperty("id_estado")]
        public int IdEstado { get; set; }

        [Column("estado")]
        [JsonProperty("estado")]
        public bool Estado { get; set; }
    }
}
