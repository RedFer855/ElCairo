using CapaDeDatos.Modelados;
using CapaDeDatos.Modelados.Ventas;
using CapaDominio;
using ModernMenuUI.ClasesUI;
using System;

namespace ModernMenuUI.Servicios
{
    public static class FacturaMapper
    {
        private static int _contadorFactura = 247; // ← temporal hasta integrar con BD

        public static Factura DesdeCarrito(
            CarritoManager carrito,
            Cliente cliente,
            ConfiguracionEmpresa empresa)
        {
            _contadorFactura++;
            string secuencial = _contadorFactura.ToString("D7");

            // Parsear rango autorizado (formato: "DESDE AL HASTA")
            string rangoDesde = "";
            string rangoHasta = "";
            if (!string.IsNullOrEmpty(empresa.RangoAutorizado))
            {
                var partes = empresa.RangoAutorizado.Split(
                    new[] { " AL ", " al " }, StringSplitOptions.RemoveEmptyEntries);
                if (partes.Length >= 2)
                {
                    rangoDesde = partes[0].Trim();
                    rangoHasta = partes[1].Trim();
                }
                else
                {
                    rangoDesde = empresa.RangoAutorizado;
                }
            }

            var factura = new Factura
            {
                // Datos del emisor
                NombreEmisor            = empresa.NombreEmpresa ?? "",
                RTNEmisor               = empresa.RtnEmpresa ?? "",
                DireccionEmisor         = empresa.DireccionEmpresa ?? "",
                TelefonoEmisor          = empresa.TelefonoEmpresa ?? "",
                CorreoEmisor            = empresa.CorreoEmpresa ?? "",
                CAI                     = empresa.CaiEmpresa ?? "",
                RangoDesde              = rangoDesde,
                RangoHasta              = rangoHasta,
                FechaLimiteEmision      = empresa.FechaLimiteEmision,

                // Número de factura
                NumeroFacturaPrefijo    = "000-001-01-0",
                NumeroFacturaSecuencial = secuencial,
                NumeroFactura           = $"000-001-01-0 {secuencial}",
                FechaEmision            = DateTime.Now,

                // Datos del cliente
                NombreCliente           = cliente?.NombreCliente ?? "Consumidor Final",
                RTNCliente              = cliente?.RtnCliente ?? "",
            };

            foreach (var item in carrito.Items)
            {
                factura.Items.Add(new ItemFactura
                {
                    CodigoBarra    = item.CodigoBarra,
                    Descripcion    = item.NombreProducto,
                    PrecioUnitario = item.PrecioVenta,
                    Cantidad       = item.Cantidad,
                    Descuento      = 0
                });
            }

            return factura;
        }
    }
}
