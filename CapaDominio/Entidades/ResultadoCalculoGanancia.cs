using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace CapaDominio.Entidades
{
    public class ResultadoCalculoGanancia
    {
        public bool Success { get; init; }
        public string Message { get; init; } = string.Empty;

        // Nombre en español
        public decimal PrecioFinal { get; init; } = 0m;
        public decimal PorcentajeGanancia { get; init; } = 0m;
    }
}