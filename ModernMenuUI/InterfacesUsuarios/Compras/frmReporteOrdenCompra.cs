using CapaDeDatos.Reportes; // O donde esté tu clase clsOrdenCompra
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClosedXML.Excel; // Para Excel
using System.IO; // Para guardar archivos
using System.Diagnostics; // Para abrir el archivo
using QuestPDF.Fluent; // ¡El nuevo para PDF!
using QuestPDF.Helpers; // ¡El nuevo para PDF!
using QuestPDF.Infrastructure; // ¡El nuevo para PDF!

namespace ModernMenuUI.InterfacesUsuarios.Compras
{
    public partial class frmReporteOrdenCompra : Form
    {
        private List<clsOrdenCompra> _listaItems;
        private string _subtotal;
        private string _impuesto;
        private string _totalGeneral;
        private string _nombreProveedor;

        public frmReporteOrdenCompra(List<clsOrdenCompra> items, string sub, string imp, string total, string proveedor)
        {
            InitializeComponent();
            _listaItems = items;
            _subtotal = sub;
            _impuesto = imp;
            _totalGeneral = total;
            _nombreProveedor = proveedor;

            QuestPDF.Settings.License = LicenseType.Community;
        }

        private void frmReporteOrdenCompra_Load(object sender, EventArgs e)
        {
            dgvCarrito.DataSource = _listaItems;

            // Ajustar columnas para que se vean bien
            dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvCarrito.Columns["TotalLinea"].HeaderText = "Total Línea";
            dgvCarrito.Columns["Codigo"].HeaderText = "Código";
            dgvCarrito.Columns["Precio"].HeaderText = "Precio Unitario";
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            string fechaActual = DateTime.Now.ToString("g"); // Formato: 14/11/2025 11:53 p. m.
            string fechaParaNombre = DateTime.Now.ToString("yyyyMMdd_HHmm");

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true })
            {
                // --- CAMBIO: Añadimos la fecha al nombre del archivo ---
                sfd.FileName = $"OrdenCompra_{fechaParaNombre}.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var document = Document.Create(container =>
                        {
                            container.Page(page =>
                            {
                                page.Margin(40); // Margen de la página

                                // --- CAMBIO: Encabezado con Título y Fecha ---
                                page.Header()
                                    .AlignCenter()
                                    .Column(col => // Usamos una columna para apilar el título y la fecha
                                    {
                                        // Título
                                        col.Item().Text("Orden de Compra")
                                            .SemiBold().FontSize(24).FontColor(Colors.Blue.Medium);

                                        // Fecha (justo debajo del título)
                                        col.Item().Text($"Fecha de Emisión: {fechaActual}")
                                            .FontSize(12);

                                        col.Item().Text($"Proveedor: {_nombreProveedor}")
                                            .FontSize(14).SemiBold().FontColor(Colors.Grey.Darken2).AlignCenter();
                                    });
                                // ---------------------------------------------

                                // 2. Contenido (la tabla)
                                page.Content()
                                    .PaddingTop(10) // Espacio entre encabezado y tabla
                                    .Table(table =>
                                    {
                                        // ... (toda tu lógica de tabla sigue igual) ...
                                        table.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(1.5f); // Código
                                            columns.RelativeColumn(4);    // Producto
                                            columns.RelativeColumn(2);    // Precio
                                            columns.RelativeColumn(1.5f); // Cantidad
                                            columns.RelativeColumn(2);    // Total Línea
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

                                // 6. Pie de página (Totales)
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

                        // Generar y guardar el PDF
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
            string fechaActual = DateTime.Now.ToString("g"); // Formato: 14/11/2025 11:53 p. m.
            string fechaParaNombre = DateTime.Now.ToString("yyyyMMdd_HHmm");

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", ValidateNames = true })
            {
                // --- CAMBIO: Añadimos la fecha al nombre del archivo ---
                sfd.FileName = $"OrdenCompra_{fechaParaNombre}.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("OrdenCompra");

                            // --- NUEVO: Título y Fecha en el documento ---
                            worksheet.Cell("A1").Value = "Orden de Compra";
                            worksheet.Cell("A1").Style.Font.Bold = true;
                            worksheet.Cell("A1").Style.Font.FontSize = 16;

                            worksheet.Cell("A2").Value = $"Fecha de Emisión: {fechaActual}";

                            worksheet.Cell("A3").Value = $"Proveedor: {_nombreProveedor}";
                            worksheet.Cell("A3").Style.Font.Bold = true;
                            // ---------------------------------------------

                            // --- CAMBIO: Movemos la tabla para que empiece en A4 ---
                            // (Dejando espacio para el título y la fecha)
                            worksheet.Cell("A4").InsertTable(_listaItems);

                            // --- Añadir los totales al final ---
                            // (Esta lógica sigue funcionando igual)
                            int lastRow = worksheet.LastRowUsed().RowNumber();
                            worksheet.Cell(lastRow + 2, 4).Value = "Subtotal:";
                            worksheet.Cell(lastRow + 2, 5).Value = _subtotal;
                            worksheet.Cell(lastRow + 3, 4).Value = "Impuesto:";
                            worksheet.Cell(lastRow + 3, 5).Value = _impuesto;
                            worksheet.Cell(lastRow + 4, 4).Value = "Total General:";
                            worksheet.Cell(lastRow + 4, 5).Value = _totalGeneral;

                            // Ajustar el ancho de las columnas
                            worksheet.Columns().AdjustToContents();

                            workbook.SaveAs(sfd.FileName);
                        }
                        MessageBox.Show("¡Exportado a Excel con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al exportar a Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
