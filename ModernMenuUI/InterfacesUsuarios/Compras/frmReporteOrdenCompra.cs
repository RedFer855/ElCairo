using CapaDominio.Reportes;
using ClosedXML.Excel;
using QuestPDF; 
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI.InterfacesUsuarios.Compras
{
    /// <summary>
    /// Formulario para generar y exportar reportes de órdenes de compra en formato PDF y Excel.
    /// Permite visualizar los detalles de la orden en un DataGridView y exportar a PDF o Excel con logo y totales.
    /// </summary>
    public partial class frmReporteOrdenCompra : Form
    {
        /// <summary>
        /// Lista de items (artículos) que componen la orden de compra.
        /// </summary>
        private List<OrdenCompra> _listaItems;

        /// <summary>
        /// Valor del subtotal formateado como string para incluir en el reporte.
        /// </summary>
        private string _subtotal;

        /// <summary>
        /// Valor del impuesto formateado como string para incluir en el reporte.
        /// </summary>
        private string _impuesto;

        /// <summary>
        /// Valor del total general formateado como string para incluir en el reporte.
        /// </summary>
        private string _totalGeneral;

        /// <summary>
        /// Nombre del proveedor que aparecerá en la orden de compra.
        /// </summary>
        private string _nombreProveedor;

        /// <summary>
        /// Nombre del usuario que genera la orden de compra.
        /// </summary>
        private string _nombreUsuario;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="frmReporteOrdenCompra"/> con los datos de la orden de compra.
        /// </summary>
        /// <param name="items">Lista de items (productos) de la orden de compra.</param>
        /// <param name="sub">Subtotal de la orden formateado como string.</param>
        /// <param name="imp">Impuesto (ISV) de la orden formateado como string.</param>
        /// <param name="total">Total general de la orden formateado como string.</param>
        /// <param name="proveedor">Nombre del proveedor de la orden.</param>
        /// <param name="usuario">Nombre del usuario que genera la orden.</param>
        public frmReporteOrdenCompra(List<OrdenCompra> items, string sub, string imp, string total, string proveedor, string usuario)
        {
            InitializeComponent();
            _listaItems = items;
            _subtotal = sub;
            _impuesto = imp;
            _totalGeneral = total;
            _nombreProveedor = proveedor;
            _nombreUsuario = usuario;

            QuestPDF.Settings.License = LicenseType.Community;
        }

        /// <summary>
        /// Obtiene el logo de la empresa desde los recursos del proyecto y lo convierte a bytes para su inserción en reportes.
        /// </summary>
        /// <returns>Array de bytes con la imagen del logo en formato PNG.</returns>
        private byte[] ObtenerLogoEnBytes()
        {
            var imagen = Properties.Resources.logo_ElCairo;

            using (var ms = new MemoryStream())
            {
                imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Evento que se ejecuta al cargar el formulario; inicializa el DataGridView con los items de la orden de compra.
        /// </summary>
        private void frmReporteOrdenCompra_Load(object sender, EventArgs e)
        {
            dgvCarrito.DataSource = _listaItems;

            dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvCarrito.Columns["TotalLinea"].HeaderText = "Total Línea";
            dgvCarrito.Columns["Codigo"].HeaderText = "Código";
            dgvCarrito.Columns["Precio"].HeaderText = "Precio Unitario";
        }

        /// <summary>
        /// Genera y exporta la orden de compra a un archivo PDF con encabezado, tabla de items, pie de página y logo.
        /// El usuario selecciona la ubicación y nombre del archivo mediante un diálogo de guardado.
        /// </summary>
        private void btnPDF_Click(object sender, EventArgs e)
        {
            string fechaActual = DateTime.Now.ToString("g");
            string fechaParaNombre = DateTime.Now.ToString("yyyyMMdd_HHmm");

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true })
            {
                sfd.FileName = $"OrdenCompra_{_nombreProveedor}_{fechaParaNombre}.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    // ====== INICIO MÉTRICAS ======
                    System.Diagnostics.Stopwatch swTotal = new System.Diagnostics.Stopwatch();
                    System.Diagnostics.Stopwatch swPaso = new System.Diagnostics.Stopwatch();
                    swTotal.Start();

                    try
                    {
                        // PASO A: Obtener logo
                        swPaso.Start();
                        byte[] logoBytes = null;
                        try { logoBytes = ObtenerLogoEnBytes(); } catch { }
                        swPaso.Stop();
                        long tiempoLogo = swPaso.ElapsedMilliseconds;
                        swPaso.Reset();

                        // PASO B: Generar PDF
                        swPaso.Start();
                        var document = Document.Create(container =>
                        {
                            container.Page(page =>
                            {
                                page.Margin(40);

                                page.Header().Row(row =>
                                {
                                    row.RelativeItem().Column(col =>
                                    {
                                        col.Item().AlignLeft().Text("Orden de Compra")
                                            .SemiBold().FontSize(24).FontColor(Colors.Blue.Medium);
                                        col.Item().AlignLeft().Text($"Fecha de Emisión: {fechaActual}")
                                            .FontSize(10);
                                        col.Item().AlignLeft().Text($"Proveedor: {_nombreProveedor}")
                                            .FontSize(14).SemiBold().FontColor(Colors.Grey.Darken2);
                                        col.Item().AlignLeft().Text($"Generado por: {_nombreUsuario}")
                                            .FontSize(10).FontColor(Colors.Grey.Medium);
                                    });

                                    if (logoBytes != null)
                                    {
                                        row.ConstantItem(20);
                                        row.ConstantItem(80).Image(logoBytes, ImageScaling.FitArea);
                                    }
                                });

                                page.Content()
                                    .PaddingTop(20)
                                    .Table(table =>
                                    {
                                        table.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(1.5f);
                                            columns.RelativeColumn(4);
                                            columns.RelativeColumn(2);
                                            columns.RelativeColumn(1.5f);
                                            columns.RelativeColumn(2);
                                        });

                                        table.Header(header =>
                                        {
                                            header.Cell().Background(Colors.Blue.Medium).Padding(5).Text("Código").FontColor(Colors.White).Bold();
                                            header.Cell().Background(Colors.Blue.Medium).Padding(5).Text("Producto").FontColor(Colors.White).Bold();
                                            header.Cell().Background(Colors.Blue.Medium).Padding(5).Text("Precio").FontColor(Colors.White).Bold();
                                            header.Cell().Background(Colors.Blue.Medium).Padding(5).Text("Cantidad").FontColor(Colors.White).Bold();
                                            header.Cell().Background(Colors.Blue.Medium).Padding(5).Text("Total Línea").FontColor(Colors.White).Bold();
                                        });

                                        foreach (var item in _listaItems)
                                        {
                                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(5).Text(item.Codigo);
                                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(5).Text(item.Producto);
                                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(5).Text(item.Precio.ToString("F2"));
                                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(5).Text(item.Cantidad.ToString());
                                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(5).Text(item.TotalLinea.ToString("F2"));
                                        }
                                    });

                                page.Footer()
                                    .AlignRight()
                                    .Column(col =>
                                    {
                                        col.Item().Text($"Subtotal: {_subtotal}").FontSize(12);
                                        col.Item().Text($"Impuesto: {_impuesto}").FontSize(12);
                                        col.Item().Text($"Total General: {_totalGeneral}").FontSize(14).Bold();
                                    });
                            });
                        });

                        document.GeneratePdf(sfd.FileName);
                        swPaso.Stop();
                        long tiempoPDF = swPaso.ElapsedMilliseconds;

                        swTotal.Stop();
                        string resumen =
                            $"--- MÉTRICAS DE RENDIMIENTO ---\n" +
                            $"Obtención de Logo: {tiempoLogo} ms\n" +
                            $"Generación PDF: {tiempoPDF} ms\n" +
                            $"Tiempo Total: {swTotal.ElapsedMilliseconds} ms\n" +
                            $"-------------------------------";
                        MessageBox.Show(resumen, "Evaluación del Sistema",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        MessageBox.Show("¡Exportado a PDF con éxito!", "Éxito",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        swTotal.Stop();
                        MessageBox.Show($"FALLO DETECTADO:\n" +
                                        $"Tiempo hasta el error: {swTotal.ElapsedMilliseconds} ms\n" +
                                        $"Error: {ex.Message}", "Análisis de Fiabilidad",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Genera y exporta la orden de compra a un archivo Excel con formato, logo, tabla de items y totales.
        /// El usuario selecciona la ubicación y nombre del archivo mediante un diálogo de guardado.
        /// </summary>
        private void btnExcel_Click(object sender, EventArgs e)
        {
            string fechaActual = DateTime.Now.ToString("g");
            string fechaParaNombre = DateTime.Now.ToString("yyyyMMdd_HHmm");

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", ValidateNames = true })
            {
                sfd.FileName = $"OrdenCompra_{_nombreProveedor}_{fechaParaNombre}.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    // ====== INICIO MÉTRICAS ======
                    System.Diagnostics.Stopwatch swTotal = new System.Diagnostics.Stopwatch();
                    System.Diagnostics.Stopwatch swPaso = new System.Diagnostics.Stopwatch();
                    swTotal.Start();

                    try
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("OrdenCompra");

                            // PASO A: Obtener logo
                            swPaso.Start();
                            try
                            {
                                byte[] imagenBytes = ObtenerLogoEnBytes();
                                using (var logoStream = new MemoryStream(imagenBytes))
                                {
                                    worksheet.AddPicture(logoStream)
                                        .MoveTo(worksheet.Cell("E1"))
                                        .Scale(0.15);
                                }
                            }
                            catch { }
                            swPaso.Stop();
                            long tiempoLogo = swPaso.ElapsedMilliseconds;
                            swPaso.Reset();

                            // PASO B: Construir contenido Excel
                            swPaso.Start();
                            worksheet.Cell("A1").Value = "Orden de Compra";
                            worksheet.Cell("A1").Style.Font.Bold = true;
                            worksheet.Cell("A1").Style.Font.FontSize = 16;
                            worksheet.Cell("A2").Value = $"Fecha de Emisión: {fechaActual}";
                            worksheet.Cell("A3").Value = $"Proveedor: {_nombreProveedor}";
                            worksheet.Cell("A3").Style.Font.Bold = true;
                            worksheet.Cell("A4").Value = $"Generado por: {_nombreUsuario}";
                            worksheet.Cell("A4").Style.Font.Italic = true;
                            worksheet.Cell("A6").InsertTable(_listaItems);
                            int lastRow = worksheet.LastRowUsed().RowNumber();
                            worksheet.Cell(lastRow + 2, 4).Value = "Subtotal:";
                            worksheet.Cell(lastRow + 2, 5).Value = _subtotal;
                            worksheet.Cell(lastRow + 3, 4).Value = "Impuesto:";
                            worksheet.Cell(lastRow + 3, 5).Value = _impuesto;
                            worksheet.Cell(lastRow + 4, 4).Value = "Total General:";
                            worksheet.Cell(lastRow + 4, 5).Value = _totalGeneral;
                            worksheet.Columns().AdjustToContents();
                            swPaso.Stop();
                            long tiempoContenido = swPaso.ElapsedMilliseconds;
                            swPaso.Reset();

                            // PASO C: Guardar archivo
                            swPaso.Start();
                            workbook.SaveAs(sfd.FileName);
                            swPaso.Stop();
                            long tiempoGuardado = swPaso.ElapsedMilliseconds;

                            swTotal.Stop();
                            string resumen =
                                $"--- MÉTRICAS DE RENDIMIENTO ---\n" +
                                $"Obtención de Logo: {tiempoLogo} ms\n" +
                                $"Construcción Contenido: {tiempoContenido} ms\n" +
                                $"Guardado de Archivo: {tiempoGuardado} ms\n" +
                                $"Tiempo Total: {swTotal.ElapsedMilliseconds} ms\n" +
                                $"-------------------------------";
                            MessageBox.Show(resumen, "Evaluación del Sistema",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        MessageBox.Show("¡Exportado a Excel con éxito!", "Éxito",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        swTotal.Stop();
                        MessageBox.Show($"FALLO DETECTADO:\n" +
                                        $"Tiempo hasta el error: {swTotal.ElapsedMilliseconds} ms\n" +
                                        $"Error: {ex.Message}", "Análisis de Fiabilidad",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
