using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados.ModeladosVistas
{
    [Table("vista_stock_critico")]
    public class VistaStockCritico : BaseModel
    {
        [Column("nombre_producto")]
        public string NombreProducto { get; set; }

        [Column("nombre_bodega")]
        public string NombreBodega { get; set; }

        [Column("cantidad_actual")]
        public int CantidadActual { get; set; }

        [Column("stock_minimo")]
        public int StockMinimo { get; set; }

        [Column("diferencia")]
        public int Diferencia { get; set; }

        [Column("id_bodega")]
        public int IdBodega { get; set; }
    

        [Column("codigo_barra_producto")]
        public string CodigoBarraProducto { get; set; }
    }

}
