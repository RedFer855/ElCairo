using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio.Entidades
{
    public class ConfiguracionGananciaProducto
    {
        public decimal PrecioCompra { get; set; }
        public decimal PrecioCosto { get; set; }
        public decimal PorcentajeGanancia { get; set; }
        public decimal PrecioFinal { get; set; }

        public bool UsaModoGanancia { get; set; }
        public bool UsaModoPrecio { get; set; }

        public int TipoCalculoGananciaProducto { get; set; }
    }
}