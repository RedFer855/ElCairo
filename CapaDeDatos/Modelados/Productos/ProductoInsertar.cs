using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados.Productos
{
    [Table("producto")]
    public class ProductoInsertar : BaseModel
    {
        [PrimaryKey("id_producto", false)]
        public int IdProducto { get; set; }

        [Column("nombre_producto")]
        public string NombreProducto { get; set; }

        [Column("id_marca")]
        public int IdMarca { get; set; }

        [Column("id_categoria")]
        public int IdCategoria { get; set; }

        [Column("codigo_barra_producto")]
        public string CodigoBarraProducto { get; set; }

        [Column("id_presentacion")]
        public int IdPresentacion { get; set; }

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
        
        [Column("imagen_producto")]
        public string? ImagenProducto { get; set; }

        [Column("id_estado")]
        public int IdEstado { get; set; }

        [Column("estado_producto")]
        public bool EstadoProducto { get; set; }

        [Column("cantidad_producto")]
        public int CantidadProducto { get; set; }

        [Column("tipo_calculo_ganancia_producto")]
        public int TipoGananciaProducto { get; set; }

    }

}
