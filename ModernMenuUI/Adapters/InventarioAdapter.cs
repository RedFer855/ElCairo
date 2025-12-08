using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos.Modelados.Inventario;
using CapaDominio.Entidades;

namespace ModernMenuUI.Adapters
{
    public static class InventarioAdapter
    {
        public static InventarioDominio Map(Inventario inv)
        {
            return new InventarioDominio
            {
                Stock = inv.StockProductoBodegaInventario,
                StockMinimo = inv.StockMinimoProductoBodegaInventario
            };
        }
    }
}
