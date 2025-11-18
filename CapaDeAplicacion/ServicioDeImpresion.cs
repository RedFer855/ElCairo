using CapaDeDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Printing;
using System.Drawing;


namespace CapaDeAplicacion
{
    public class ServicioDeImpresion
    {
        public void ImprimirTicket(Factura factura, System.Drawing.Image logo = null)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += (sender, e) =>
            {
                Graphics g = e.Graphics;
                int y = 10;

                if (logo != null)
                    g.DrawImage(logo, 0, y, 100, 50);
                y += 60;

                g.DrawString(factura.NombreEmisor, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 0, y);
                y += 15;
                g.DrawString($"Factura #: {factura.NumeroFactura}", new Font("Arial", 8), Brushes.Black, 0, y);
                y += 15;

                foreach (var item in factura.Items)
                {
                    g.DrawString($"{item.Cantidad} x {item.Descripcion} @ {item.PrecioUnitario:C}", new Font("Arial", 8), Brushes.Black, 0, y);
                    y += 15;
                }
                g.DrawString($"TOTAL: {factura.Total:C}", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 0, y);
            };

            pd.Print();
        }
    }
}
