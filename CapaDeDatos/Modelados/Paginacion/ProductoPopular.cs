using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados.Paginacion
{
    public class ProductoPopular
    {
        [JsonProperty("id_producto")]
        public int IdProducto { get; set; }

        [JsonProperty("codigo_barra")]
        public string CodigoBarra { get; set; }

        [JsonProperty("nombre_producto")]
        public string NombreProducto { get; set; }

        [JsonProperty("nombre_marca")]
        public string NombreMarca { get; set; }

        [JsonProperty("contenido")]
        public string Contenido { get; set; }

        [JsonProperty("imagen_url")]
        public string ImagenUrl { get; set; }

        [JsonProperty("precio_venta")]
        public decimal PrecioVenta { get; set; }

        [JsonProperty("total_vendido")]
        public long TotalVendido { get; set; }

        [JsonProperty("stock_actual")]
        public int StockActual { get; set; }
    }
}