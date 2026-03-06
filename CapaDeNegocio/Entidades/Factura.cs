// CapaDeNegocio/Entidades/FacturaItems.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace CapaDeNegocio.Entidades
{
    public class ItemFactura
    {
        public int IdProducto { get; set; }            // agrego id para referencia
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Descuentos { get; set; } = 0m;
        public decimal TasaImpuesto { get; set; } = 0m; // 0.15m, 0.18m, 0m
        public bool EsExonerado { get; set; } = false;

        public decimal Subtotal => Math.Round((Cantidad * PrecioUnitario) - Descuentos, 2);
        public decimal ISV => EsExonerado ? 0m : Math.Round(Subtotal * TasaImpuesto, 2);
        public decimal TotalLinea => Math.Round(Subtotal + ISV, 2);
    }

    public class Factura
    {
        public string NombreEmisor { get; set; }
        public string RTNEmisor { get; set; }
        public string DireccionEmisor { get; set; }
        public string TelefonoEmisor { get; set; }
        public string CorreoEmisor { get; set; }
        public string CAI { get; set; }
        public string RangoAutorizado { get; set; }
        public DateTime FechaLimiteEmision { get; set; }
        public string NumeroFactura { get; set; }
        public DateTime FechaEmision { get; set; } = DateTime.Now;
        public string NombreCliente { get; set; }
        public string RTNCliente { get; set; }
        public string DireccionCliente { get; set; }
        public List<ItemFactura> Items { get; set; } = new();

        public decimal SubTotal => Items.Sum(i => i.Subtotal);
        public decimal TotalDescuentos => Items.Sum(i => i.Descuentos);
        public decimal ImporteExonerado => Items.Where(i => i.EsExonerado).Sum(i => i.Subtotal);
        public decimal ImporteExento => Items.Where(i => !i.EsExonerado && i.TasaImpuesto == 0m).Sum(i => i.Subtotal);
        public decimal ImporteGravado15 => Items.Where(i => !i.EsExonerado && i.TasaImpuesto == 0.15m).Sum(i => i.Subtotal);
        public decimal ImporteGravado18 => Items.Where(i => !i.EsExonerado && i.TasaImpuesto == 0.18m).Sum(i => i.Subtotal);

        public decimal ISV15 => Math.Round(ImporteGravado15 * 0.15m, 2);
        public decimal ISV18 => Math.Round(ImporteGravado18 * 0.18m, 2);
        public decimal Total => Math.Round(ImporteExonerado + ImporteExento + ImporteGravado15 + ImporteGravado18 + ISV15 + ISV18, 2);

        public byte[] LogoBytes { get; set; }

        public bool EsValida()
        {
            return Items != null && Items.Count > 0 && !string.IsNullOrWhiteSpace(NumeroFactura);
        }
    }
}
