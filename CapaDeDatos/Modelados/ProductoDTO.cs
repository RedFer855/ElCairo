using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados
{
    [Table("producto")]
    public class ProductoDTO : BaseModel
    {
        // --- 👇 2. AÑADE '[JsonPropertyName]' A CADA CAMPO ---

        [PrimaryKey("id_producto", false)]
        [JsonPropertyName("id_producto")]
        public int IdProducto { get; set; }

        [Column("nombre_producto")]
        [JsonPropertyName("nombre_producto")]
        public string NombreProducto { get; set; }

        [Column("id_marca")]
        [JsonPropertyName("id_marca")]
        public int IdMarca { get; set; }

        [Column("id_categoria")]
        [JsonPropertyName("id_categoria")]
        public int IdCategoria { get; set; }

        [Column("codigo_barra_producto")]
        [JsonPropertyName("codigo_barra_producto")]
        public string CodigoBarraProducto { get; set; }

        [Column("id_presentacion")]
        [JsonPropertyName("id_presentacion")]
        public int IdPresentacion { get; set; }

        [Column("id_tamanio")]
        [JsonPropertyName("id_tamanio")]
        public int IdTamanio { get; set; }

        [Column("precio_compra")]
        [JsonPropertyName("precio_compra")]
        public decimal PrecioCompra { get; set; }

        [Column("precio_costo")]
        [JsonPropertyName("precio_costo")]
        public decimal PrecioCosto { get; set; }

        [Column("precio_venta")]
        [JsonPropertyName("precio_venta")]
        public decimal PrecioVenta { get; set; }

        [Column("porcentaje_ganancia_producto")]
        [JsonPropertyName("porcentaje_ganancia_producto")]
        public decimal PorcentajeGananciaProducto { get; set; }

        [Column("id_estado")]
        [JsonPropertyName("id_estado")]
        public int IdEstado { get; set; }

        [Column("estado_producto")]
        [JsonPropertyName("estado_producto")]
        public bool EstadoProducto { get; set; }

        [Column("cantidad_producto")]
        [JsonPropertyName("cantidad_producto")]
        public int cantidad_producto { get; set; }
    }
}
