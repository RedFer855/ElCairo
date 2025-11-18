using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados.Inventario.Productos
{
    [Table("producto")]
    public class Producto : BaseModel
    {
        // "id_producto" es la Primary Key
        [PrimaryKey("id_producto", false)] 
        public int IdProducto { get; set; }

        // "nombre_producto" (character varying)
        [Column("nombre_producto")]
        public string NombreProducto { get; set; }

        // "id_marca" (integer)
        [Column("id_marca")]
        public int IdMarca { get; set; }
        public Marca Marca { get; set; }

        public string NombreMarca
        {
            get
            {
                return Marca?.NombreMarca ?? "Sin Marca";
            }
        }

        [Column("id_categoria")]
        public int IdCategoria { get; set; }

        public Categoria Categoria { get; set; }

        public string NombreCategoria
        {
            get
            {
                return Categoria?.NombreCategoria ?? "Sin Categoria";
            }
        }

        // "codigo_barra_producto" (character varying)
        [Column("codigo_barra_producto")]
        public string CodigoBarraProducto { get; set; }

        // "id_presentacion" (integer)
        [Column("id_presentacion")]
        public int IdPresentacion { get; set; }

        // "id_tamanio" (integer)
        [Column("contenido_producto")]
        public string ContenidoProducto { get; set; }

        // "precio_compra" (numeric) -> decimal es mejor para dinero
        [Column("precio_compra")]
        public decimal PrecioCompra { get; set; }

        // "precio_costo" (numeric)
        [Column("precio_costo")]
        public decimal PrecioCosto { get; set; }

        // "precio_venta" (numeric)
        [Column("precio_venta")]
        public decimal PrecioVenta { get; set; }

        // "porcentaje_ganancia_producto" (numeric)
        [Column("porcentaje_ganancia_producto")]
        public decimal PorcentajeGananciaProducto { get; set; }

        // "id_estado" (integer)
        [Column("id_estado")]
        public int IdEstado { get; set; }

        // "estado_producto" (boolean)
        [Column("estado_producto")]
        public bool EstadoProducto { get; set; }

        // "cantidad_producto" (integer)
        [Column("cantidad_producto")]
        public int CantidadProducto { get; set; }
    }
}
