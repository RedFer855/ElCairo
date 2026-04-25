using System;
using CapaDominio.Entidades;

namespace CapaDominio.Servicios
{
    public static class CalculoGananciaPrecioCosto
    {
        private const decimal MAX_GANANCIA = 1000m;
        private const decimal MAX_PRECIO = 999_999m;

        // Calcula precio final desde costo + porcentaje
        public static ResultadoCalculoGanancia CalcularPrecioDesdeGanancia(decimal costo, decimal porcentajeGanancia)
        {
            if (costo <= 0m)
            {
                return new ResultadoCalculoGanancia { Success = false, Message = "El costo debe ser mayor que 0." };
            }

            if (Math.Abs(porcentajeGanancia) > MAX_GANANCIA)
            {
                return new ResultadoCalculoGanancia { Success = false, Message = $"El porcentaje de ganancia no puede exceder ±{MAX_GANANCIA}%." };
            }

            decimal precio = costo * (1m + (porcentajeGanancia / 100m));
            precio = Decimal.Round(precio, 4, MidpointRounding.AwayFromZero); // precisión interna

            if (precio > MAX_PRECIO)
            {
                return new ResultadoCalculoGanancia { Success = false, Message = $"El precio final ({precio:N2}) supera el máximo permitido {MAX_PRECIO:N2}." };
            }

            return new ResultadoCalculoGanancia
            {
                Success = true,
                PrecioFinal = Decimal.Round(precio, 2, MidpointRounding.AwayFromZero),
                PorcentajeGanancia = Decimal.Round(porcentajeGanancia, 2, MidpointRounding.AwayFromZero)
            };
        }

        // Calcula porcentaje de ganancia desde costo + precio final
        public static ResultadoCalculoGanancia CalcularGananciaDesdePrecio(decimal costo, decimal precioFinal)
        {
            if (costo <= 0m)
            {
                return new ResultadoCalculoGanancia { Success = false, Message = "El costo debe ser mayor que 0." };
            }

            if (precioFinal <= 0m)
            {
                return new ResultadoCalculoGanancia { Success = false, Message = "El precio final debe ser mayor que 0." };
            }

            if (precioFinal > MAX_PRECIO)
            {
                return new ResultadoCalculoGanancia { Success = false, Message = $"El precio final supera el máximo permitido {MAX_PRECIO:N2}." };
            }

            decimal ganancia = ((precioFinal - costo) / costo) * 100m;
            // más precisión interna para evitar fluctuaciones por redondeo
            ganancia = Decimal.Round(ganancia, 4, MidpointRounding.AwayFromZero);

            if (Math.Abs(ganancia) > MAX_GANANCIA)
            {
                return new ResultadoCalculoGanancia { Success = false, Message = $"La ganancia resultante ({ganancia:N2}%) supera ±{MAX_GANANCIA}%." };
            }

            return new ResultadoCalculoGanancia
            {
                Success = true,
                PrecioFinal = Decimal.Round(precioFinal, 2, MidpointRounding.AwayFromZero),
                PorcentajeGanancia = Decimal.Round(ganancia, 2, MidpointRounding.AwayFromZero)
            };
        }
    }
}