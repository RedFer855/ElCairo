using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Reportes
{
    public class clsOrdenCompra
    {
        public string Codigo { get; set; }
        public string Producto { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

        // El reporte puede calcular esto, o lo puedes pasar tú
        public decimal TotalLinea => Precio * Cantidad;
    }
}
