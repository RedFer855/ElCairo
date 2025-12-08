using CapaDeDatos.Repositorios;
using CapaDeDatos.Modelados.Inventario;       // Para el modelo Bodega
using CapaDeDatos.Modelados.ModeladosVistas;  // Para VistaStockCritico
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.Helpers;
using System.Diagnostics;

namespace ModernMenuUI.InterfacesUsuarios.Reporteria
{
    /// <summary>
    /// Formulario encargado de generar reportes de Stock Crítico por bodega.
    /// Ofrece:
    /// - Selección de bodegas activas.
    /// - Visualización en DataGridView.
    /// - Exportación a PDF (QuestPDF).
    /// - Exportación a Excel (ClosedXML).
    /// </summary>
    public partial class frmAbrirReporte : Form
    {
        // =========================================================================
        // 1. CAMPOS Y DEPENDENCIAS
        // =========================================================================

        /// <summary>
        /// Repositorio encargado de obtener bodegas activas y datos del reporte.
        /// </summary>
        private readonly ReportesRepositorio _repo;

        /// <summary>
        /// Lista local con los productos en estado crítico recibidos desde la BD.
        /// </summary>
        private List<VistaStockCritico> _datosStockCritico;

        // =========================================================================
        // 2. CONSTRUCTOR
        // =========================================================================

        /// <summary>
        /// Inicializa el formulario, configura controles, repositorios y licencia PDF.
        /// </summary>
        public frmAbrirReporte()
        {
            InitializeComponent();

            // Evitar columnas automáticas innecesarias.
            dgvStockCritico.AutoGenerateColumns = false;

            _repo = new ReportesRepositorio();
            _datosStockCritico = new List<VistaStockCritico>();

            // Configurar QuestPDF (modo Community)
            QuestPDF.Settings.License = LicenseType.Community;
        }

        // =========================================================================
        // 3. CARGA INICIAL DEL FORMULARIO
        // =========================================================================

        /// <summary>
        /// Carga las bodegas activas al abrir el formulario
        /// y deshabilita las opciones de exportación hasta que haya resultados.
        /// </summary>
        private async void frmAbrirReporte_Load(object sender, EventArgs e)
        {
            btnExportarPDF.Enabled = false;
            btnExportarExcel.Enabled = false;

            try
            {
                // Carga de bodegas desde el repositorio
                var bodegas = await _repo.ObtenerBodegasActivas();

                cmbBodegas.DataSource = bodegas;
                cmbBodegas.DisplayMember = "NombreBodega";
                cmbBodegas.ValueMember = "IdBodega";

                cmbBodegas.SelectedIndex = -1;
                cmbBodegas.Text = "Seleccione una bodega...";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las bodegas: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================================
        // 4. EXPORTACIÓN A EXCEL
        // =========================================================================

        /// <summary>
        /// Exporta los datos del reporte a Excel utilizando ClosedXML.
        /// Incluye:
        /// - Título estilizado.
        /// - Fecha de generación.
        /// - Tabla con estilo profesional.
        /// </summary>
        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (!_datosStockCritico.Any()) return;

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivos de Excel (*.xlsx)|*.xlsx";
                sfd.FileName = $"Stock_Critico_{cmbBodegas.Text}_{DateTime.Now:yyyyMMdd}.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("Stock Crítico");

                            // ----------------------
                            // TÍTULO PRINCIPAL
                            // ----------------------
                            worksheet.Cell("A1").Value = $"Reporte de Stock Crítico - Bodega: {cmbBodegas.Text}";
                            worksheet.Range("A1:E1").Merge();

                            var titulo = worksheet.Cell("A1").Style;
                            titulo.Font.Bold = true;
                            titulo.Font.FontSize = 14;
                            titulo.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            titulo.Fill.BackgroundColor = XLColor.LightBlue;

                            worksheet.Cell("A2").Value = $"Fecha de Generación: {DateTime.Now:dd/MM/yyyy}";

                            // ----------------------
                            // PROYECCIÓN PARA ORDEN Y NOMBRES PERSONALIZADOS
                            // ----------------------
                            var reporteExcel = _datosStockCritico.Select(x => new
                            {
                                Código = x.CodigoBarraProducto ?? "S/C",
                                Producto = x.NombreProducto,
                                Stock_Actual = x.CantidadActual,
                                Mínimo = x.StockMinimo,
                                Diferencia = x.Diferencia
                            }).ToList();

                            // ----------------------
                            // TABLA EN A4
                            // ----------------------
                            var table = worksheet.Cell(4, 1).InsertTable(reporteExcel);
                            table.Theme = XLTableTheme.TableStyleMedium9;

                            worksheet.Columns().AdjustToContents();

                            workbook.SaveAs(sfd.FileName);
                        }

                        MessageBox.Show("Reporte exportado correctamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Intentar abrir el archivo automáticamente
                        try { Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true }); } catch { }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al exportar Excel: {ex.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // =========================================================================
        // 5. EXPORTACIÓN A PDF
        // =========================================================================

        /// <summary>
        /// Genera un archivo PDF del reporte utilizando QuestPDF.
        /// Se incluye:
        /// - Encabezado con título y fecha.
        /// - Tabla con cinco columnas.
        /// - Colores profesionales y borde inferior por fila.
        /// - Pie de página con numeración.
        /// </summary>
        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            if (!_datosStockCritico.Any()) return;

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivo PDF (*.pdf)|*.pdf";
                sfd.FileName = $"Reporte_Stock_Critico_{cmbBodegas.Text}_{DateTime.Now:yyyyMMdd}.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string fechaReporte = DateTime.Now.ToString("dd/MM/yyyy");

                        // Construcción dinámica del PDF
                        Document.Create(container =>
                        {
                            container.Page(page =>
                            {
                                page.Margin(30);
                                page.Size(PageSizes.A4);

                                // ---------------------------
                                // ENCABEZADO
                                // ---------------------------
                                page.Header().Column(col =>
                                {
                                    col.Item().Text($"Reporte de Stock Crítico - Bodega: {cmbBodegas.Text}")
                                       .SemiBold().FontSize(20).FontColor(Colors.Blue.Medium);

                                    col.Item().Text($"Fecha de Generación: {fechaReporte}")
                                       .FontSize(10).FontColor(Colors.Grey.Medium);
                                });

                                // ---------------------------
                                // TABLA CON DATOS
                                // ---------------------------
                                page.Content().PaddingTop(10).Table(table =>
                                {
                                    // Columnas
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn(2);
                                        columns.RelativeColumn(4);
                                        columns.RelativeColumn(1);
                                        columns.RelativeColumn(1);
                                        columns.RelativeColumn(1);
                                    });

                                    // Encabezado
                                    table.Header(header =>
                                    {
                                        IContainer EstiloHeader(IContainer c) =>
                                            c.Background(Colors.Blue.Lighten1).Padding(5);

                                        header.Cell().Element(EstiloHeader).Text("Cód. Barra").Bold().FontColor(Colors.White);
                                        header.Cell().Element(EstiloHeader).Text("Producto").Bold().FontColor(Colors.White);
                                        header.Cell().Element(EstiloHeader).AlignRight().Text("Actual").Bold().FontColor(Colors.White);
                                        header.Cell().Element(EstiloHeader).AlignRight().Text("Mínimo").Bold().FontColor(Colors.White);
                                        header.Cell().Element(EstiloHeader).AlignRight().Text("Dif.").Bold().FontColor(Colors.White);
                                    });

                                    // Filas
                                    foreach (var item in _datosStockCritico)
                                    {
                                        IContainer EstiloCelda(IContainer c) =>
                                            c.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5);

                                        table.Cell().Element(EstiloCelda).Text(item.CodigoBarraProducto ?? "S/C").FontSize(9);
                                        table.Cell().Element(EstiloCelda).Text(item.NombreProducto).FontSize(9);
                                        table.Cell().Element(EstiloCelda).AlignRight().Text(item.CantidadActual.ToString()).FontSize(9);
                                        table.Cell().Element(EstiloCelda).AlignRight().Text(item.StockMinimo.ToString()).FontSize(9);

                                        table.Cell().Element(EstiloCelda)
                                              .AlignRight().Text(item.Diferencia.ToString())
                                              .FontColor(Colors.Red.Medium).Bold().FontSize(9);
                                    }
                                });

                                // ---------------------------
                                // PIE DE PÁGINA
                                // ---------------------------
                                page.Footer().AlignCenter().Text(x =>
                                {
                                    x.Span("Página ");
                                    x.CurrentPageNumber();
                                    x.Span(" de ");
                                    x.TotalPages();
                                });
                            });
                        }).GeneratePdf(sfd.FileName);

                        MessageBox.Show("PDF generado correctamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        try { Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true }); } catch { }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al generar PDF: {ex.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // =========================================================================
        // 6. GENERAR REPORTE DESDE BOTÓN
        // =========================================================================

        /// <summary>
        /// Obtiene el stock crítico de la bodega seleccionada y lo carga en el grid.
        /// Luego habilita/deshabilita los botones de exportación.
        /// </summary>
        private async void btnGenerarReporte_Click_1(object sender, EventArgs e)
        {
            if (cmbBodegas.SelectedIndex == -1 || cmbBodegas.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione una bodega.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (int.TryParse(cmbBodegas.SelectedValue.ToString(), out int idBodega))
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    _datosStockCritico = await _repo.ObtenerStockCritico(idBodega);

                    dgvStockCritico.DataSource = _datosStockCritico;

                    if (!_datosStockCritico.Any())
                    {
                        MessageBox.Show(
                            "No se encontraron productos en stock crítico en esta bodega.",
                            "Todo bien",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    btnExportarPDF.Enabled = _datosStockCritico.Any();
                    btnExportarExcel.Enabled = _datosStockCritico.Any();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al generar el reporte: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally { this.Cursor = Cursors.Default; }
            }
        }
    }
}
