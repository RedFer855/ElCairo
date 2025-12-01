using CapaDeDatos.Modelados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel; 
using QuestPDF.Fluent; 
using QuestPDF.Helpers; 
using QuestPDF.Infrastructure; 
using System.Diagnostics; 
using System.IO;

namespace ModernMenuUI.InterfacesUsuarios.Ventas
{
    public partial class frmImprimirCierre : Form
    {
        private List<CierreDiarioResult> _datosVentas;
        private string _totalVentas;
        private string _alias;
        private string _fecha;
        public frmImprimirCierre(List<CierreDiarioResult> datos, string total, string alias, string fecha)
        {
            InitializeComponent();

            _datosVentas = datos;
            _totalVentas = total;
            _alias = alias;
            _fecha = fecha;

            this.Load += frmImprimirCierre_Load;

            QuestPDF.Settings.License = LicenseType.Community;
        }

        private void frmImprimirCierre_Load(object sender, EventArgs e)
        {
            this.Text = $"Reporte de Cierre Diario: {_alias} ({_fecha})";

            // Asignar los datos al nuevo DataGridView
            //    Asegúrate de que 'dgvReporteCierre' existe en el diseñador
            if (dgvCierreDiario != null)
            {
                dgvCierreDiario.AutoGenerateColumns = true; // Para que muestre todas las propiedades de CierreDiarioResult
                dgvCierreDiario.DataSource = _datosVentas;
                dgvCierreDiario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (dgvCierreDiario.Columns.Contains("BaseUrl"))
                    dgvCierreDiario.Columns["BaseUrl"].Visible = false;

                if (dgvCierreDiario.Columns.Contains("RequestClientOptions"))
                    dgvCierreDiario.Columns["RequestClientOptions"].Visible = false;

                if (dgvCierreDiario.Columns.Contains("TableName"))
                    dgvCierreDiario.Columns["TableName"].Visible = false;

                if (dgvCierreDiario.Columns.Contains("PrimaryKey"))
                    dgvCierreDiario.Columns["PrimaryKey"].Visible = false;

                // Ocultar columnas que puedan ser metadatos o irrelevantes (si existen en CierreDiarioResult)
                if (dgvCierreDiario.Columns.Contains("FechaVenta"))
                    dgvCierreDiario.Columns["FechaVenta"].Visible = false;

                // Si tienes los otros campos, úsalos:
                // lblTotalGeneral.Text = _totalVentas;
            }
            else
            {
                MessageBox.Show("Error: El control 'dgvReporteCierre' no se encontró. Verifica el nombre en el diseñador.", "Error de Configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            string fechaParaNombre = DateTime.Parse(_fecha).ToString("yyyyMMdd");

            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "PDF file|*.pdf",
                ValidateNames = true,
                FileName = $"CierreDiario_{_alias}_{fechaParaNombre}.pdf"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var document = Document.Create(container =>
                        {
                            container.Page(page =>
                            {
                                page.Margin(40);

                                // 1. HEADER
                                page.Header().Column(col =>
                                {
                                    // Aplicamos PaddingBottom al Item que contiene el texto, no al Text() (Corregido el CS1929)
                                    col.Item().PaddingBottom(5).Text("REPORTE DE CIERRE DIARIO").SemiBold().FontSize(24).FontColor(Colors.Blue.Medium);
                                    col.Item().PaddingTop(5).Text($"Fecha del Cierre: {_fecha}").FontSize(14);
                                    col.Item().Text($"Empleado: {_alias}").FontSize(12).FontColor(Colors.Grey.Darken2);
                                    col.Item().PaddingBottom(10).Text($"Reporte generado el: {DateTime.Now:g}").FontSize(10);
                                });

                                // 2. TABLA DE VENTAS
                                page.Content()
                                    .Table(table =>
                                    {
                                        // 2.1 Definición de Columnas (4 columnas: Producto, Cantidad, Precio, Subtotal)
                                        table.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(4);
                                            columns.RelativeColumn(2);
                                            columns.RelativeColumn(2);
                                            columns.RelativeColumn(2);
                                        });

                                        // 2.2 Encabezados (Header)
                                        table.Header(header =>
                                        {
                                            header.Cell().Background(Colors.Blue.Medium).Padding(5).Text("Producto").FontColor(Colors.White).Bold();
                                            header.Cell().Background(Colors.Blue.Medium).Padding(5).Text("Cantidad").FontColor(Colors.White).Bold();
                                            header.Cell().Background(Colors.Blue.Medium).Padding(5).Text("Precio Unitario").FontColor(Colors.White).Bold();
                                            header.Cell().Background(Colors.Blue.Medium).Padding(5).Text("Subtotal").FontColor(Colors.White).Bold().AlignRight();
                                        });

                                        // 2.3 Filas de datos (Usamos v.Cantidad y v.Precio)
                                        foreach (var item in _datosVentas)
                                        {
                                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(5).Text(item.Producto);
                                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(5).Text(item.Cantidad.ToString());
                                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(5).Text(item.Precio.ToString("C2"));
                                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(5).Text(item.Subtotal.ToString("C2")).AlignRight();
                                        }

                                        // 2.4 Fila de Total
                                        table.Cell().ColumnSpan(3).PaddingTop(10).AlignRight().Text("TOTAL VENDIDO:").Bold().FontSize(12);
                                        table.Cell().PaddingTop(10).Background(Colors.Yellow.Lighten4).Text(_totalVentas).Bold().FontSize(12).AlignRight();
                                    });

                                // 3. FOOTER (Paginación)
                                /*page.Footer().AlignRight().Text(x =>
                                {
                                    x.CurrentPageNumber();
                                    x.Span(" de ");
                                    x.TotalPages();
                                }).FontSize(10);*/
                            });
                        });

                        // Generar y guardar el archivo PDF
                        document.GeneratePdf(sfd.FileName);
                        MessageBox.Show("¡Exportado a PDF con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al exportar a PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string fechaParaNombre = DateTime.Parse(_fecha).ToString("yyyyMMdd");

            using (var sfd = new SaveFileDialog()
            {
                Filter = "Archivos de Excel (*.xlsx)|*.xlsx",
                FileName = $"CierreDiario_{_alias}_{fechaParaNombre}.xlsx",
                ValidateNames = true
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("Cierre Diario");

                            // 1. Encabezado del Reporte
                            worksheet.Cell("A1").Value = "REPORTE DE CIERRE DIARIO";
                            worksheet.Cell("A1").Style.Font.Bold = true;
                            worksheet.Cell("A1").Style.Font.FontSize = 16;

                            worksheet.Cell("A3").Value = "Empleado:";
                            worksheet.Cell("B3").Value = _alias;
                            worksheet.Cell("A4").Value = "Fecha del Cierre:";
                            worksheet.Cell("B4").Value = _fecha;

                            // 2. Tabla de Datos (Comienza en A6)
                            // Usamos las propiedades exactas de tu modelo: Producto, Cantidad, Precio y Subtotal
                            worksheet.Cell("A6").InsertTable(_datosVentas.Select(v => new {
                                Producto = v.Producto,
                                Cantidad = v.Cantidad,
                                Precio_Unitario = v.Precio,
                                Subtotal = v.Subtotal
                            }));

                            // 3. Totales
                            int lastRow = worksheet.LastRowUsed().RowNumber();
                            worksheet.Cell(lastRow + 2, 3).Value = "TOTAL VENTAS:";
                            worksheet.Cell(lastRow + 2, 4).Value = _totalVentas;
                            worksheet.Cell(lastRow + 2, 4).Style.Font.Bold = true;
                            worksheet.Cell(lastRow + 2, 4).Style.Fill.BackgroundColor = XLColor.Yellow;

                            // 4. Auto-ajustar y guardar
                            worksheet.Columns().AdjustToContents();
                            workbook.SaveAs(sfd.FileName);
                        }

                        MessageBox.Show("Datos exportados a Excel con éxito.", "Exportación Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al exportar a Excel: {ex.Message}", "Error de Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
