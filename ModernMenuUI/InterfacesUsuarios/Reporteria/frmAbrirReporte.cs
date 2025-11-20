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
    public partial class frmAbrirReporte : Form
    {
        // 1. Instancia del nuevo repositorio
        private readonly ReportesRepositorio _repo;

        // 2. Lista para almacenar los datos
        private List<VistaStockCritico> _datosStockCritico;

        public frmAbrirReporte()
        {
            InitializeComponent();

            // Evitar que el DataGrid genere columnas automáticas feas
            dgvStockCritico.AutoGenerateColumns = false;

            // Inicializar repositorio y lista
            _repo = new ReportesRepositorio();
            _datosStockCritico = new List<VistaStockCritico>();

            // Configurar licencia de QuestPDF
            QuestPDF.Settings.License = LicenseType.Community;
        }

        // --- EVENTO LOAD: Cargar las bodegas al iniciar ---
        private async void frmAbrirReporte_Load(object sender, EventArgs e)
        {
            // Deshabilitar botones de exportación hasta que haya datos
            btnExportarPDF.Enabled = false;
            btnExportarExcel.Enabled = false;

            try
            {
                // Usamos el método de tu ReportesRepositorio
                var bodegas = await _repo.ObtenerBodegasActivas();

                // Llenar ComboBox
                cmbBodegas.DataSource = bodegas;
                cmbBodegas.DisplayMember = "NombreBodega"; // Asegúrate que esta propiedad exista en tu modelo Bodega
                cmbBodegas.ValueMember = "IdBodega";       // Asegúrate que esta propiedad exista en tu modelo Bodega

                cmbBodegas.SelectedIndex = -1;
                cmbBodegas.Text = "Seleccione una bodega...";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las bodegas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

   

        // --- BOTÓN EXCEL (ClosedXML) ---
        private void btnExportarExcel_Click(object sender, EventArgs e)
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
                        // Preparamos la fecha para el reporte
                        string fechaReporte = DateTime.Now.ToString("dd/MM/yyyy");

                        Document.Create(container =>
                        {
                            container.Page(page =>
                            {
                                page.Margin(30); // Margen un poco más pequeño para que quepa la nueva columna
                                page.Size(PageSizes.A4);

                                // --- ENCABEZADO ---
                                page.Header().Column(col =>
                                {
                                    col.Item().Text($"Reporte de Stock Crítico - Bodega: {cmbBodegas.Text}")
                                       .SemiBold().FontSize(20).FontColor(Colors.Blue.Medium);

                                    col.Item().Text($"Fecha de Generación: {fechaReporte}")
                                       .FontSize(10).FontColor(Colors.Grey.Medium);
                                });

                                // --- CONTENIDO ---
                                page.Content().PaddingTop(10).Table(table =>
                                {
                                    // 1. DEFINICIÓN DE COLUMNAS (Ahora son 5 columnas)
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn(2); // Código de Barras
                                        columns.RelativeColumn(4); // Producto (más ancho)
                                        columns.RelativeColumn(1); // Actual
                                        columns.RelativeColumn(1); // Mínimo
                                        columns.RelativeColumn(1); // Diferencia
                                    });

                                    // 2. ENCABEZADOS DE TABLA
                                    table.Header(header =>
                                    {
                                        // Estilo base para ahorrar código repetido
                                        IContainer EstiloHeader(IContainer c) => c.Background(Colors.Blue.Lighten1).Padding(5);

                                        header.Cell().Element(EstiloHeader).Text("Cód. Barra").Bold().FontColor(Colors.White);
                                        header.Cell().Element(EstiloHeader).Text("Producto").Bold().FontColor(Colors.White);
                                        header.Cell().Element(EstiloHeader).AlignRight().Text("Actual").Bold().FontColor(Colors.White);
                                        header.Cell().Element(EstiloHeader).AlignRight().Text("Mínimo").Bold().FontColor(Colors.White);
                                        header.Cell().Element(EstiloHeader).AlignRight().Text("Dif.").Bold().FontColor(Colors.White);
                                    });

                                    // 3. DATOS DE LA TABLA
                                    foreach (var item in _datosStockCritico)
                                    {
                                        // Estilo base para bordes
                                        IContainer EstiloCelda(IContainer c) => c.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5);

                                        // Celda 1: Código
                                        table.Cell().Element(EstiloCelda).Text(item.CodigoBarraProducto ?? "S/C").FontSize(9);

                                        // Celda 2: Producto
                                        table.Cell().Element(EstiloCelda).Text(item.NombreProducto).FontSize(9);

                                        // Celda 3: Actual
                                        table.Cell().Element(EstiloCelda).AlignRight().Text(item.CantidadActual.ToString()).FontSize(9);

                                        // Celda 4: Mínimo
                                        table.Cell().Element(EstiloCelda).AlignRight().Text(item.StockMinimo.ToString()).FontSize(9);

                                        // Celda 5: Diferencia (En Rojo y Negrita)
                                        table.Cell().Element(EstiloCelda).AlignRight()
                                             .Text(item.Diferencia.ToString())
                                             .FontColor(Colors.Red.Medium).Bold().FontSize(9);
                                    }
                                });

                                // --- PIE DE PÁGINA ---
                                page.Footer().AlignCenter().Text(x =>
                                {
                                    x.Span("Página ");
                                    x.CurrentPageNumber();
                                    x.Span(" de ");
                                    x.TotalPages();
                                });
                            });
                        }).GeneratePdf(sfd.FileName);

                        MessageBox.Show("Reporte de PDF guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Abrir el archivo automáticamente
                        try { Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true }); } catch { }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al guardar el PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // --- BOTÓN PDF (QuestPDF) ---
        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            if (!_datosStockCritico.Any()) return;

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivo PDF (*.pdf)|*.pdf";
                sfd.FileName = $"Stock_Critico_{cmbBodegas.Text}_{DateTime.Now:yyyyMMdd}.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Crear documento PDF
                        Document.Create(container =>
                        {
                            container.Page(page =>
                            {
                                page.Margin(30);
                                page.Size(PageSizes.A4);

                                // --- ENCABEZADO DEL PDF ---
                                page.Header().Row(row =>
                                {
                                    row.RelativeItem().Column(col =>
                                    {
                                        col.Item().Text("Reporte Stock Crítico").FontSize(20).SemiBold().FontColor(Colors.Blue.Medium);
                                        col.Item().Text($"Bodega: {cmbBodegas.Text}").FontSize(14);
                                        col.Item().Text($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}").FontSize(10).FontColor(Colors.Grey.Medium);
                                    });
                                });

                                // --- CONTENIDO (TABLA) ---
                                page.Content().PaddingVertical(10).Table(table =>
                                {
                                    // Definir columnas (Anchos relativos)
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn(3); // Producto
                                        columns.RelativeColumn(1); // Actual
                                        columns.RelativeColumn(1); // Mínimo
                                        columns.RelativeColumn(1); // Diferencia
                                    });

                                    // Cabeceras de la tabla
                                    table.Header(header =>
                                    {
                                        header.Cell().Element(CellStyle).Text("Producto");
                                        header.Cell().Element(CellStyle).Text("Actual");
                                        header.Cell().Element(CellStyle).Text("Mínimo");
                                        header.Cell().Element(CellStyle).Text("Diferencia");

                                        // Estilo local para cabeceras
                                        static IContainer CellStyle(IContainer container)
                                        {
                                            return container.Background(Colors.Grey.Lighten3).Padding(5).BorderBottom(1).BorderColor(Colors.Grey.Darken1);
                                        }
                                    });

                                    // Filas de datos
                                    foreach (var item in _datosStockCritico)
                                    {
                                        table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(item.NombreProducto);
                                        table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).AlignRight().Text(item.CantidadActual.ToString());
                                        table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).AlignRight().Text(item.StockMinimo.ToString());

                                        // Resaltar la diferencia en rojo
                                        table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).AlignRight().Text(item.Diferencia.ToString()).FontColor(Colors.Red.Medium).Bold();
                                    }
                                });

                                // --- PIE DE PÁGINA ---
                                page.Footer().AlignCenter().Text(x =>
                                {
                                    x.Span("Página ");
                                    x.CurrentPageNumber();
                                });
                            });
                        }).GeneratePdf(sfd.FileName);

                        MessageBox.Show("PDF generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Abrir archivo
                        Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al generar PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void btnGenerarReporte_Click_1(object sender, EventArgs e)
        {
            if (cmbBodegas.SelectedIndex == -1 || cmbBodegas.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione una bodega.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Intentar obtener el ID seleccionado
            if (int.TryParse(cmbBodegas.SelectedValue.ToString(), out int idBodega))
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    // Llamada al repositorio
                    _datosStockCritico = await _repo.ObtenerStockCritico(idBodega);

                    // Asignar al Grid
                    dgvStockCritico.DataSource = _datosStockCritico;

                    if (!_datosStockCritico.Any())
                    {
                        MessageBox.Show("No se encontraron productos con stock crítico en esta bodega.", "Todo bien", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Activar botones si hay datos
                    btnExportarPDF.Enabled = _datosStockCritico.Any();
                    btnExportarExcel.Enabled = _datosStockCritico.Any();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al generar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }
    }
}
