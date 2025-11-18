using CapaDeDominio;
using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeAplicacion
{
    public class ServicioPdf
    {
        public void GenerarPDF(Factura factura, string ruta, System.Drawing.Image logo = null)
        {
            PdfWriter writer = new PdfWriter(ruta);
            PdfDocument pdf = new PdfDocument(writer);
            Document doc = new Document(pdf);

            if (logo != null)
            {
                using (var ms = new System.IO.MemoryStream())
                {
                    logo.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    var imageData = ImageDataFactory.Create(ms.ToArray());
                    doc.Add(new iText.Layout.Element.Image(imageData).ScaleToFit(100, 50));
                }
            }

            doc.Add(new Paragraph($"Factura #: {factura.NumeroFactura}"));
            doc.Add(new Paragraph($"TOTAL: {factura.Total:C}"));

            doc.Close();
        }

    }
}
