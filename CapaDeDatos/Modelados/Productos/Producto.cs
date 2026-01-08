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


namespace CapaDeDatos.Modelados.Productos
{
    [Table("producto")]
    public class Producto : BaseModel
    {
        [PrimaryKey("id_producto", false)]
        public int IdProducto { get; set; }

        [Column("nombre_producto")]
        public string NombreProducto { get; set; }

        [Column("id_marca")]
        public int IdMarca { get; set; }
        public Marca Marca { get; set; }

        public string NombreMarca => Marca?.NombreMarca ?? "Sin Marca";

        [Column("id_categoria")]
        public int IdCategoria { get; set; }
        [Column("categoria")]
        public Categoria Categoria { get; set; }

        public string NombreCategoria => Categoria?.NombreCategoria ?? "Sin Categoria";

        [Column("codigo_barra_producto")]
        public string CodigoBarraProducto { get; set; }

        [Column("id_presentacion")]
        public int IdPresentacion { get; set; }

        public Presentacion Presentacion { get; set; }

        public string NombrePresentacion => Presentacion?.NombrePresentacion ?? "Sin Presentación";

        [Column("precio_compra")]
        public decimal PrecioCompra { get; set; }

        [Column("precio_costo")]
        public decimal PrecioCosto { get; set; }

        [Column("contenido_producto")]
        public string ContenidoProducto { get; set; }

        [Column("precio_venta")]
        public decimal PrecioVenta { get; set; }

        [Column("porcentaje_ganancia_producto")]
        public decimal PorcentajeGananciaProducto { get; set; }

        [Column("id_estado")]
        public int IdEstado { get; set; }

        [Column("estado_producto")]
        public bool EstadoProducto { get; set; }

        [Column("cantidad_producto")]
        public int CantidadProducto { get; set; }

        [Column("producto_path")]
        public string? ImagenProducto { get; set; } 

        [Column("id_proveedor")]
        public int IdProveedorProducto { get; set; }

        public int StockEnBodega { get; set; }

        public override string ToString()
        {
            // Esto une las palabras con espacio, ignorando las que sean nulas o vacías
            return string.Join(" ", new[] { NombreProducto, NombreMarca, NombrePresentacion, ContenidoProducto }
                   .Where(s => !string.IsNullOrEmpty(s)));
        }
    }
}
