using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernMenuUI.ClasesUI
{
    /// <summary>
    /// Representa un producto dentro del carrito de facturación.
    /// </summary>
    public class ItemCarrito
    {
        public string CodigoBarra { get; set; }
        public string NombreProducto { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Cantidad { get; set; }
        public int StockDisponible { get; set; }
        public int IdProducto { get; set; }

        public decimal TotalLinea => PrecioVenta * Cantidad;
    }
}
