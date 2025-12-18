using CapaDeNegocio.Entidades;
using FastReport;
using FastReport.Data;
using FastReport.Export.PdfSimple;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ModernMenuUI.ServiciosUI
{
    public class FacturaReportService
    {
        public void MostrarFactura()
        {
            try
            {
                Factura factura = new Factura
                {
                    NombreEmisor = "EL CAIRO S.A",
                    RTNEmisor = "01010101010101",
                    DireccionEmisor = "Tegucigalpa, Honduras",
                    TelefonoEmisor = "504-9999-9999",
                    CorreoEmisor = "info@elcairo.com",
                    CAI = "A1B2-C3D4-E5F6",
                    RangoAutorizado = "000-001-01-00000001 al 00000099",
                    FechaLimiteEmision = new DateTime(2026, 12, 31),
                    NumeroFactura = "000-001-01-00000025",
                    FechaEmision = DateTime.Now,
                    NombreCliente = "Supermercado La Colonia",
                    RTNCliente = "08011999123456",
                    DireccionCliente = "Comayagüela, M.D.C."
                };

                // EXENTO (0%) – con descuento
                factura.Items.Add(new ItemFactura
                {
                    Cantidad = 5,
                    Descripcion = "Tomate fresco (libra)",
                    PrecioUnitario = 20m,     // 5 × 20 = 100
                    Descuentos = 10m,         // descuento directo
                    TasaImpuesto = 0m,
                    EsExonerado = false
                });

                // GRAVADO 15% – con descuento
                factura.Items.Add(new ItemFactura
                {
                    Cantidad = 2,
                    Descripcion = "Perfume Árabe",
                    PrecioUnitario = 1500m,   // 2 × 1500 = 3000
                    Descuentos = 300m,        // descuento
                    TasaImpuesto = 0.15m,
                    EsExonerado = false
                });

                // GRAVADO 18% – con descuento
                factura.Items.Add(new ItemFactura
                {
                    Cantidad = 1,
                    Descripcion = "Licor importado",
                    PrecioUnitario = 2200m,   // 1 × 2200 = 2200
                    Descuentos = 200m,        // descuento
                    TasaImpuesto = 0.18m,
                    EsExonerado = false
                });


                Report rpt = new Report();

                string rutaReporte = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "..", "..", "..",
                    "InterfacesUsuarios", "Reportes", "Factura.frx"
                );

                rpt.Load(Path.GetFullPath(rutaReporte));

                DataTable dtItems = new DataTable("Items");
                dtItems.Columns.Add("Cantidad", typeof(int));
                dtItems.Columns.Add("Descripcion", typeof(string));
                dtItems.Columns.Add("PrecioUnitario", typeof(decimal));
                dtItems.Columns.Add("TasaImpuesto", typeof(decimal));
                dtItems.Columns.Add("Subtotal", typeof(decimal));
                dtItems.Columns.Add("ISV", typeof(decimal));
                dtItems.Columns.Add("TotalLinea", typeof(decimal));

                foreach (var item in factura.Items)
                {
                    dtItems.Rows.Add(
                        item.Cantidad,
                        item.Descripcion,
                        item.PrecioUnitario,
                        item.TasaImpuesto,
                        item.Subtotal,
                        item.ISV,
                        item.TotalLinea
                    );
                }

                rpt.RegisterData(dtItems, "Items");

                var itemsSource = rpt.GetDataSource("Items") as TableDataSource;
                if (itemsSource == null)
                    throw new Exception("TableDataSource 'Items' no encontrado en el .frx");

                itemsSource.Enabled = true;

                rpt.SetParameterValue("NombreEmisor", factura.NombreEmisor);
                rpt.SetParameterValue("RTNEmisor", factura.RTNEmisor);
                rpt.SetParameterValue("DireccionEmisor", factura.DireccionEmisor);
                rpt.SetParameterValue("TelefonoEmisor", factura.TelefonoEmisor);
                rpt.SetParameterValue("CorreoEmisor", factura.CorreoEmisor);
                rpt.SetParameterValue("CAI", factura.CAI);
                rpt.SetParameterValue("RangoAutorizado", factura.RangoAutorizado);
                rpt.SetParameterValue("FechaLimiteEmision", factura.FechaLimiteEmision);
                rpt.SetParameterValue("NumeroFactura", factura.NumeroFactura);
                rpt.SetParameterValue("FechaEmision", factura.FechaEmision);
                rpt.SetParameterValue("NombreCliente", factura.NombreCliente);
                rpt.SetParameterValue("RTNCliente", factura.RTNCliente);
                rpt.SetParameterValue("DireccionCliente", factura.DireccionCliente);
                rpt.SetParameterValue("ImporteExento", factura.ImporteExento);
                rpt.SetParameterValue("ImporteGravado15", factura.ImporteGravado15);
                rpt.SetParameterValue("ImporteGravado18", factura.ImporteGravado18);
                rpt.SetParameterValue("ISV15", factura.ISV15);
                rpt.SetParameterValue("ISV18", factura.ISV18);
                rpt.SetParameterValue("Total", factura.Total);

                rpt.Prepare();

                string rutaPdf = Path.Combine(Path.GetTempPath(), "Factura_Simulada.pdf");

                PDFSimpleExport pdfExport = new PDFSimpleExport
                {
                    ShowProgress = false
                };

                rpt.Export(pdfExport, rutaPdf);

                Process.Start(new ProcessStartInfo
                {
                    FileName = rutaPdf,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
