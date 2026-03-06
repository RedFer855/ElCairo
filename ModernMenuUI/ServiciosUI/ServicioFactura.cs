// ModernMenuUI/ServiciosUI/FacturaReportService.cs
using CapaDeNegocio.Entidades;
using FastReport;
using FastReport.Data;
using FastReport.Export.PdfSimple;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace ModernMenuUI.ServiciosUI
{
    public class FacturaReportService
    {
        /// <summary>
        /// Genera y abre un PDF de la factura. Lanza excepciones en caso de error.
        /// </summary>
        public async Task<string> MostrarFacturaAsync(Factura factura)
        {
            if (factura == null) throw new ArgumentNullException(nameof(factura));
            if (factura.Items == null || factura.Items.Count == 0) throw new Exception("La factura no contiene productos.");

            string rutaPdf = Path.Combine(Path.GetTempPath(), $"Factura_{factura.NumeroFactura}_{DateTime.Now:yyyyMMddHHmmss}.pdf");

            await Task.Run(() =>
            {
                using var rpt = new Report();
                string rutaReporte = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "..", "..", "..",
                    "InterfacesUsuarios", "Reportes", "Factura.frx"
                );

                rpt.Load(Path.GetFullPath(rutaReporte));

                DataTable dtItems = CrearTablaItems(factura);
                rpt.RegisterData(dtItems, "Items");

                var itemsSource = rpt.GetDataSource("Items") as TableDataSource;
                if (itemsSource == null) throw new Exception("TableDataSource 'Items' no encontrado en el reporte.");

                itemsSource.Enabled = true;
                CargarParametros(rpt, factura);

                rpt.Prepare();

                using var pdfExport = new PDFSimpleExport { ShowProgress = false };
                rpt.Export(pdfExport, rutaPdf);
            });

            // Abrir el PDF en el SO
            Process.Start(new ProcessStartInfo
            {
                FileName = rutaPdf,
                UseShellExecute = true
            });

            return rutaPdf;
        }

        private DataTable CrearTablaItems(Factura factura)
        {
            DataTable dt = new DataTable("Items");
            dt.Columns.Add("Cantidad", typeof(int));
            dt.Columns.Add("Descripcion", typeof(string));
            dt.Columns.Add("PrecioUnitario", typeof(decimal));
            dt.Columns.Add("TasaImpuesto", typeof(decimal));
            dt.Columns.Add("Subtotal", typeof(decimal));
            dt.Columns.Add("ISV", typeof(decimal));
            dt.Columns.Add("TotalLinea", typeof(decimal));

            foreach (var item in factura.Items)
            {
                dt.Rows.Add(
                    item.Cantidad,
                    item.Descripcion,
                    item.PrecioUnitario,
                    item.TasaImpuesto,
                    item.Subtotal,
                    item.ISV,
                    item.TotalLinea
                );
            }

            return dt;
        }

        private void CargarParametros(Report rpt, Factura f)
        {
            rpt.SetParameterValue("NombreEmisor", f.NombreEmisor);
            rpt.SetParameterValue("RTNEmisor", f.RTNEmisor);
            rpt.SetParameterValue("DireccionEmisor", f.DireccionEmisor);
            rpt.SetParameterValue("TelefonoEmisor", f.TelefonoEmisor);
            rpt.SetParameterValue("CorreoEmisor", f.CorreoEmisor);
            rpt.SetParameterValue("CAI", f.CAI);
            rpt.SetParameterValue("RangoAutorizado", f.RangoAutorizado);
            rpt.SetParameterValue("FechaLimiteEmision", f.FechaLimiteEmision);
            rpt.SetParameterValue("NumeroFactura", f.NumeroFactura);
            rpt.SetParameterValue("FechaEmision", f.FechaEmision);
            rpt.SetParameterValue("NombreCliente", f.NombreCliente);
            rpt.SetParameterValue("RTNCliente", f.RTNCliente);
            rpt.SetParameterValue("DireccionCliente", f.DireccionCliente);

            rpt.SetParameterValue("ImporteExento", f.ImporteExento);
            rpt.SetParameterValue("ImporteGravado15", f.ImporteGravado15);
            rpt.SetParameterValue("ImporteGravado18", f.ImporteGravado18);
            rpt.SetParameterValue("ISV15", f.ISV15);
            rpt.SetParameterValue("ISV18", f.ISV18);
            rpt.SetParameterValue("Total", f.Total);
        }

        internal void MostrarFacturaAsync()
        {
            throw new NotImplementedException();
        }
    }
}
