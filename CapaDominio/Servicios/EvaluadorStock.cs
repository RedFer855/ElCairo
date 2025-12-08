using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio.Entidades;
using CapaDominio.Enums;

namespace CapaDominio.Servicios
{
    public static class EvaluadorStock
    {
        private const double RangoAdvertencia = 0.20; 

        public static EstadoStock ObtenerEstado(InventarioDominio inv)
        {
            if (inv.Stock <= inv.StockMinimo)
                return EstadoStock.Critico;

            double limiteAdvertencia = inv.StockMinimo + (inv.StockMinimo * RangoAdvertencia);

            if (inv.Stock < limiteAdvertencia)
                return EstadoStock.Advertencia;

            return EstadoStock.Normal;
        }
    }
}
