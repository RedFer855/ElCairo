using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; 

namespace CapaDominio
{

    public class Factura
    {
        public string NombreEmisor { get; set; }
        public string RTNEmisor { get; set; }
        public string DireccionEmisor { get; set; }
        public string TelefonoEmisor { get; set; }
        public string CorreoEmisor { get; set; }
        public string CAI { get; set; }
        public DateTime FechaEmision { get; set; }
        public string NumeroFactura { get; set; }

        public string NombreCliente { get; set; }
        public string RTNCliente { get; set; }
        public string DireccionCliente { get; set; }

        public List<ItemFactura> Items { get; set; } = new List<ItemFactura>();

        public decimal SubTotal => Items.Sum(i => i.TotalLinea);
        public decimal ISV => SubTotal * 0.15m;
        public decimal Total => SubTotal + ISV;

        public Image Logo { get; set; }

        public bool EsValida() => !string.IsNullOrEmpty(NombreCliente) && Items.Count > 0;
    }

    public class ItemFactura
    {
        public string CodigoBarra { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal TotalLinea => Cantidad * PrecioUnitario;
    }

}
