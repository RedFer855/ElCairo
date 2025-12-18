using CapaDeNegocio.Entidades;
using CapaDeNegocio.Servicios;
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Globalization;
using System.IO;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace CapaInfraestructura.Reportes
{
    public class PdfInvoiceGenerator : IInvoicePdfGenerator
    {
        private readonly byte[] _logoBytes;
        private readonly CultureInfo _culture;

        public PdfInvoiceGenerator(byte[] logoBytes = null, CultureInfo culture = null)
        {
            // logoBytes puede venir desde Resources (pre-convertido a PNG bytes)
            _logoBytes = logoBytes;
            _culture = culture ?? new CultureInfo("es-HN");
        }

        public async Task<string> GenerateAndOpenPdfAsync(Factura factura, string rutaSalida = null)
        {
            if (factura == null) throw new ArgumentNullException(nameof(factura));
            //if (!factura.EsValida()) throw new ArgumentException("Factura inválida. Debe tener al menos 1 item.");

            rutaSalida ??= Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                            "Facturas",
                            $"Factura_{DateTime.Now:yyyyMMdd_HHmmss}_{Guid.NewGuid().ToString().Substring(0, 6)}.pdf");

            Directory.CreateDirectory(Path.GetDirectoryName(rutaSalida));

            // Ejecutar la creación del PDF en un hilo de fondo
            await Task.Run(() =>
            {
                using (FileStream fs = new FileStream(rutaSalida, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    PdfWriter writer = new PdfWriter(fs);
                    using (PdfDocument pdf = new PdfDocument(writer))
                    using (iText.Layout.Document doc = new iText.Layout.Document(pdf, iText.Kernel.Geom.PageSize.A4))
                    {
                        doc.SetMargins(20, 20, 20, 20);

                        // Logo (si existe)
                        if (_logoBytes != null && _logoBytes.Length > 0)
                        {
                            try
                            {
                                var img = new iText.Layout.Element.Image(ImageDataFactory.Create(_logoBytes)).ScaleToFit(120, 60);
                                doc.Add(img);
                            }
                            catch { /* Si falla la imagen, no interrumpir la generación */ }
                        }

                        var fontNormal = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                        var fontBold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                        var fontItalic = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_OBLIQUE);

                        doc.Add(new Paragraph("FACTURA").SetFont(fontBold).SetFontSize(20).SetTextAlignment(TextAlignment.CENTER));
                        doc.Add(new Paragraph($"Fecha: {factura.FechaEmision:dd/MM/yyyy HH:mm}").SetFont(fontNormal));
                        doc.Add(new Paragraph($"Cliente: {factura.NombreCliente}").SetFont(fontNormal));
                        doc.Add(new Paragraph($"RTN: {factura.RTNCliente}").SetFont(fontNormal));
                        doc.Add(new Paragraph($"Dirección: {factura.DireccionCliente}").SetFont(fontNormal));
                        doc.Add(new Paragraph(" "));

                        Table t = new Table(UnitValue.CreatePercentArray(new float[] { 55, 15, 15, 15 })).UseAllAvailableWidth();
                        t.AddHeaderCell(new Cell().Add(new Paragraph("Producto").SetFont(fontBold)));
                        t.AddHeaderCell(new Cell().Add(new Paragraph("Cant.").SetFont(fontBold)));
                        t.AddHeaderCell(new Cell().Add(new Paragraph("Precio").SetFont(fontBold)));
                        t.AddHeaderCell(new Cell().Add(new Paragraph("Total").SetFont(fontBold)));

                        foreach (var item in factura.Items)
                        {
                            t.AddCell(new Cell().Add(new Paragraph(item.Descripcion ?? "").SetFont(fontNormal)));
                            t.AddCell(new Cell().Add(new Paragraph(item.Cantidad.ToString()).SetFont(fontNormal)));
                            t.AddCell(new Cell().Add(new Paragraph(item.PrecioUnitario.ToString("C2", _culture)).SetFont(fontNormal)));
                            t.AddCell(new Cell().Add(new Paragraph(item.TotalLinea.ToString("C2", _culture)).SetFont(fontNormal)));
                        }

                        doc.Add(t);

                        //doc.Add(new Paragraph($"\nSubtotal: {factura.SubTotal.ToString("C2", _culture)}"));
                       // doc.Add(new Paragraph($"ISV (15%): {factura.ISV.ToString("C2", _culture)}"));
                        doc.Add(new Paragraph($"TOTAL: {factura.Total.ToString("C2", _culture)}").SetFont(fontBold));
                        doc.Add(new Paragraph("\nGracias por su compra!").SetFont(fontItalic).SetTextAlignment(TextAlignment.CENTER));

                        doc.Close();
                    }
                }

                // Abrir archivo (intento no bloqueante)
                try
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = rutaSalida,
                        UseShellExecute = true
                    });
                }
                catch
                {
                    // Si falla abrir, no lanzamos excepción al llamador.
                }
            });

            return rutaSalida;
        }
    }
}

