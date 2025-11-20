using CapaDeDatos.Reportes; // O donde esté tu clase clsOrdenCompra
using ClosedXML.Excel; // Para Excel
using QuestPDF.Fluent; // ¡El nuevo para PDF!
using QuestPDF.Helpers; // ¡El nuevo para PDF!
using QuestPDF.Infrastructure; // ¡El nuevo para PDF!
using System;
using System.Collections.Generic;
using System.Diagnostics; // Para abrir el archivo
using System.IO; // Para guardar archivos
using System.Windows.Forms;

namespace ModernMenuUI.InterfacesUsuarios.Compras
{
    public partial class frmReporteOrdenCompra : Form
    {
        private List<clsOrdenCompra> _listaItems;
        private string _subtotal;
        private string _impuesto;
        private string _totalGeneral;
        private string _nombreProveedor;
        private string _nombreUsuario;

        public frmReporteOrdenCompra(List<clsOrdenCompra> items, string sub, string imp, string total, string proveedor, string usuario)
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
        private byte[] ObtenerLogoEnBytes()
        {
            // 1. Obtener la imagen usando el nombre EXACTO del recurso
            // (Fíjate que es el nombre que sale en la ventana .resx, no el nombre del archivo .png)
            var imagen = Properties.Resources.logo_ElCairo;

            using (var ms = new MemoryStream())
            {
                imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
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
            string fechaActual = DateTime.Now.ToString("g");
            string fechaParaNombre = DateTime.Now.ToString("yyyyMMdd_HHmm");

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true })
            {
                sfd.FileName = $"OrdenCompra_{_nombreProveedor}_{fechaParaNombre}.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // 1. OBTENER LOGO
                        byte[] logoBytes = null;
                        try { logoBytes = ObtenerLogoEnBytes(); } catch { }

                        // 2. CREAR DOCUMENTO
                        var document = Document.Create(container =>
                        {
                            container.Page(page =>
                            {
                                page.Margin(40);

                                // --- 3. HEADER INVERTIDO (Texto izquierda, Logo derecha) ---
                                page.Header().Row(row =>
                                {
                                    // A) COLUMNA IZQUIERDA: TEXTOS (Alineados a la Izquierda)
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

                                    // B) COLUMNA DERECHA: EL LOGO
                                    if (logoBytes != null)
                                    {
                                        row.ConstantItem(20); // Espacio de separación
                                        row.ConstantItem(80).Image(logoBytes, ImageScaling.FitArea);
                                    }
                                });
                                // ---------------------------------------------------------

                                // 4. TABLA DE PRODUCTOS (Igual que antes)
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

                                // 5. FOOTER
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

                        // 6. GENERAR
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
            /* string fechaActual = DateTime.Now.ToString("g"); // Formato: 14/11/2025 11:53 p. m.
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

                                         col.Item().Text($"Generado por: {_nombreUsuario}")
                                             .FontSize(10).FontColor(Colors.Grey.Medium);
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
             }*/
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string fechaActual = DateTime.Now.ToString("g");
            string fechaParaNombre = DateTime.Now.ToString("yyyyMMdd_HHmm");

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", ValidateNames = true })
            {
                sfd.FileName = $"OrdenCompra_{_nombreProveedor}_{fechaParaNombre}.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("OrdenCompra");

                            // 👇 --- 1. AGREGAR LOGO (BLOQUE NUEVO) --- 👇
                            try
                            {
                                // Obtenemos los bytes usando tu método auxiliar
                                byte[] imagenBytes = ObtenerLogoEnBytes();

                                using (var logoStream = new MemoryStream(imagenBytes))
                                {
                                    // Insertamos la imagen
                                    worksheet.AddPicture(logoStream)
                                        .MoveTo(worksheet.Cell("E1")) // La ponemos en E1 (esquina derecha)
                                        .Scale(0.15); // Ajusta el tamaño (0.15 = 15% del original)
                                }
                            }
                            catch
                            {
                                // Si falla la imagen (no existe recurso), no hacemos nada y seguimos.
                            }
                            // 👆 --------------------------------------- 👆

                            // 2. Título y Fecha
                            worksheet.Cell("A1").Value = "Orden de Compra";
                            worksheet.Cell("A1").Style.Font.Bold = true;
                            worksheet.Cell("A1").Style.Font.FontSize = 16;

                            worksheet.Cell("A2").Value = $"Fecha de Emisión: {fechaActual}";

                            // 3. Proveedor
                            worksheet.Cell("A3").Value = $"Proveedor: {_nombreProveedor}";
                            worksheet.Cell("A3").Style.Font.Bold = true;

                            // 4. Usuario
                            worksheet.Cell("A4").Value = $"Generado por: {_nombreUsuario}";
                            worksheet.Cell("A4").Style.Font.Italic = true;

                            // 5. Tabla (En A6)
                            worksheet.Cell("A6").InsertTable(_listaItems);

                            // 6. Totales
                            int lastRow = worksheet.LastRowUsed().RowNumber();
                            worksheet.Cell(lastRow + 2, 4).Value = "Subtotal:";
                            worksheet.Cell(lastRow + 2, 5).Value = _subtotal;
                            worksheet.Cell(lastRow + 3, 4).Value = "Impuesto:";
                            worksheet.Cell(lastRow + 3, 5).Value = _impuesto;
                            worksheet.Cell(lastRow + 4, 4).Value = "Total General:";
                            worksheet.Cell(lastRow + 4, 5).Value = _totalGeneral;

                            // Ajustar columnas
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
            /*string fechaActual = DateTime.Now.ToString("g"); // Formato: 14/11/2025 11:53 p. m.
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

                            worksheet.Cell("A4").Value = $"Generado por: {_nombreUsuario}";
                            worksheet.Cell("A4").Style.Font.Italic = true;
                            // ---------------------------------------------

                            // --- CAMBIO: Movemos la tabla para que empiece en A4 ---
                            // (Dejando espacio para el título y la fecha)
                            worksheet.Cell("A6").InsertTable(_listaItems);

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
            }*/
        }
    }
}
