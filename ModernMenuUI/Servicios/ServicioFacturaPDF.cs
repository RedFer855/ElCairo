using CapaDominio;
using PuppeteerSharp;
using PuppeteerSharp.Media;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModernMenuUI.Servicios
{
    public class ServicioFacturaPDF
    {
        // Ruta de la plantilla HTML (relativa al ejecutable)
        private static readonly string _rutaPlantilla = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "Recursos", "factura_sar_honduras.html");

        // Carpeta destino de PDFs
        private static readonly string _carpetaPDF = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "ElCairo", "Facturas");

        // Browser singleton para reutilización entre facturas
        private static IBrowser _browser = null;
        private static readonly SemaphoreSlim _browserLock = new SemaphoreSlim(1, 1);

        /// <summary>
        /// Genera el PDF de la factura a partir de la plantilla HTML.
        /// Retorna la ruta del archivo generado.
        /// </summary>
        public async Task<string> GenerarAsync(Factura factura, Image logoImage = null)
        {
            Directory.CreateDirectory(_carpetaPDF);

            string nombreArchivo = $"Factura_{factura.NumeroFacturaSecuencial}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
            string rutaPDF = Path.Combine(_carpetaPDF, nombreArchivo);

            // 1. Cargar plantilla HTML
            string htmlTemplate = CargarPlantilla();

            // 2. Convertir logo a base64 si existe
            string logoBase64 = ConvertirLogoBase64(logoImage);

            // 3. Reemplazar todos los placeholders
            string htmlFinal = ReemplazarPlaceholders(htmlTemplate, factura, logoBase64);

            // 4. Generar PDF con PuppeteerSharp
            await GenerarPDFConPuppeteerAsync(htmlFinal, rutaPDF);

            return rutaPDF;
        }

        /// <summary>
        /// Abre el PDF con el visor del sistema operativo.
        /// </summary>
        public void AbrirPDF(string rutaPDF)
        {
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = rutaPDF,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al abrir PDF: {ex.Message}");
            }
        }

        // ─────────────────────────────────────────────────
        // MÉTODOS PRIVADOS
        // ─────────────────────────────────────────────────

        private string CargarPlantilla()
        {
            if (File.Exists(_rutaPlantilla))
                return File.ReadAllText(_rutaPlantilla, Encoding.UTF8);

            // Fallback: buscar en directorio de desarrollo
            string rutaDesarrollo = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "..", "..", "..", "..", "Recursos", "factura_sar_honduras.html");

            if (File.Exists(rutaDesarrollo))
                return File.ReadAllText(Path.GetFullPath(rutaDesarrollo), Encoding.UTF8);

            throw new FileNotFoundException(
                $"Plantilla de factura no encontrada. Buscada en:\n{_rutaPlantilla}\n{rutaDesarrollo}");
        }

        private string ConvertirLogoBase64(Image logoImage)
        {
            if (logoImage == null) return "";
            try
            {
                using var ms = new MemoryStream();
                logoImage.Save(ms, ImageFormat.Png);
                return Convert.ToBase64String(ms.ToArray());
            }
            catch
            {
                return "";
            }
        }

        private string ReemplazarPlaceholders(string html, Factura f, string logoBase64)
        {
            // Generar filas de productos
            var sbFilas = new StringBuilder();
            foreach (var item in f.Items)
            {
                decimal descuento = item.Descuento > 0 ? item.Descuento : 0;
                decimal total = (item.PrecioUnitario * item.Cantidad) - descuento;
                sbFilas.AppendLine(
                    $"<tr>" +
                    $"<td class=\"td-cantidad\">{item.Cantidad}</td>" +
                    $"<td class=\"td-descripcion\">{System.Net.WebUtility.HtmlEncode(item.Descripcion)}</td>" +
                    $"<td class=\"td-precio\">L. {item.PrecioUnitario:N2}</td>" +
                    $"<td class=\"td-descuento\">L. {descuento:N2}</td>" +
                    $"<td class=\"td-total\">L. {total:N2}</td>" +
                    $"</tr>");
            }

            // Generar filas vacías de relleno (mínimo 18 filas total)
            int filasVacias = Math.Max(0, 18 - f.Items.Count);
            var sbVacias = new StringBuilder();
            for (int i = 0; i < filasVacias; i++)
                sbVacias.AppendLine(
                    "<tr class=\"fila-vacia\">" +
                    "<td class=\"td-cantidad\"></td>" +
                    "<td class=\"td-descripcion\"></td>" +
                    "<td class=\"td-precio\"></td>" +
                    "<td class=\"td-descuento\"></td>" +
                    "<td class=\"td-total\"></td>" +
                    "</tr>");

            // Calcular totales SAR
            decimal subtotal    = f.Items.Sum(i => i.PrecioUnitario * i.Cantidad);
            decimal totalDesc   = f.Items.Sum(i => i.Descuento > 0 ? i.Descuento : 0);
            decimal baseGravada = subtotal - totalDesc;
            decimal isv15       = Math.Round(baseGravada * 0.15m, 2);
            decimal totalPagar  = baseGravada + isv15;

            // Reemplazos
            return html
                // Logo
                .Replace("{{LOGO_BASE64}}", logoBase64)

                // Empresa
                .Replace("{{NOMBRE_EMPRESA}}",      f.NombreEmisor ?? "")
                .Replace("{{RTN_EMPRESA}}",          f.RTNEmisor ?? "")
                .Replace("{{DIRECCION_EMPRESA}}",    f.DireccionEmisor ?? "")
                .Replace("{{TELEFONO_EMPRESA}}",     f.TelefonoEmisor ?? "")
                .Replace("{{CORREO_EMPRESA}}",       f.CorreoEmisor ?? "")
                .Replace("{{CAI_EMPRESA}}",          f.CAI ?? "")
                .Replace("{{RANGO_DESDE}}",          f.RangoDesde ?? "")
                .Replace("{{RANGO_HASTA}}",          f.RangoHasta ?? "")
                .Replace("{{FECHA_LIMITE_EMISION}}", f.FechaLimiteEmision?.ToString("dd/MM/yyyy") ?? "")

                // Factura
                .Replace("{{NUMERO_FACTURA_PREFIJO}}",    f.NumeroFacturaPrefijo ?? "000-001-01-0")
                .Replace("{{NUMERO_FACTURA_SECUENCIAL}}", f.NumeroFacturaSecuencial ?? "0000001")
                .Replace("{{FECHA_EMISION}}",             f.FechaEmision.ToString("dd 'de' MMMM 'de' yyyy",
                                                            new System.Globalization.CultureInfo("es-HN")))

                // Cliente
                .Replace("{{NOMBRE_CLIENTE}}", f.NombreCliente ?? "Consumidor Final")
                .Replace("{{RTN_CLIENTE}}",    f.RTNCliente ?? "")

                // Productos
                .Replace("{{FILAS_PRODUCTOS}}", sbFilas.ToString())
                .Replace("{{FILAS_VACIAS}}",    sbVacias.ToString())

                // Totales
                .Replace("{{SUBTOTAL}}",           $"L. {subtotal:N2}")
                .Replace("{{TOTAL_DESCUENTOS}}",   $"L. {totalDesc:N2}")
                .Replace("{{TOTAL_EN_LETRAS}}",    ConvertirNumeroALetras(totalPagar))
                .Replace("{{IMPORTE_EXONERADO}}",  "0.00")
                .Replace("{{IMPORTE_EXENTO}}",     "0.00")
                .Replace("{{IMPORTE_GRAVADO_15}}", $"{baseGravada:N2}")
                .Replace("{{IMPORTE_GRAVADO_18}}", "0.00")
                .Replace("{{ISV_15}}",             $"{isv15:N2}")
                .Replace("{{ISV_18}}",             "0.00")
                .Replace("{{TOTAL_A_PAGAR}}",      $"{totalPagar:N2}")

                // Correlativas (vacías por defecto para venta normal)
                .Replace("{{CORRELATIVO_COMPRA_EXENTA}}",        "")
                .Replace("{{CORRELATIVO_REGISTRO_EXONERADO}}",   "")
                .Replace("{{CORRELATIVO_SAG}}",                  "")

                // Imprenta
                .Replace("{{NOMBRE_IMPRENTA}}",      "Imprenta Comercial S.A.")
                .Replace("{{RTN_IMPRENTA}}",         "05019008765432")
                .Replace("{{CERTIFICADO_IMPRENTA}}", "0000000000005");
        }

        public static async Task PreCalentarAsync()
        {
            await ObtenerBrowserAsync();
        }

        private static async Task<IBrowser> ObtenerBrowserAsync()
        {
            if (_browser != null && !_browser.IsClosed)
                return _browser;

            await _browserLock.WaitAsync();
            try
            {
                if (_browser != null && !_browser.IsClosed)
                    return _browser;

                await new BrowserFetcher().DownloadAsync();

                _browser = await Puppeteer.LaunchAsync(new LaunchOptions
                {
                    Headless = true,
                    Args = new[] { "--no-sandbox", "--disable-setuid-sandbox",
                                   "--disable-dev-shm-usage" }
                });

                return _browser;
            }
            finally
            {
                _browserLock.Release();
            }
        }

        private async Task GenerarPDFConPuppeteerAsync(string htmlContent, string rutaDestino)
        {
            var browser = await ObtenerBrowserAsync();
            await using var page = await browser.NewPageAsync();

            await page.SetContentAsync(htmlContent, new NavigationOptions
            {
                WaitUntil = new[] { WaitUntilNavigation.Networkidle2 }
            });

            await page.PdfAsync(rutaDestino, new PdfOptions
            {
                Format = PaperFormat.Letter,
                PrintBackground = true,
                PreferCSSPageSize = false,
                MarginOptions = new MarginOptions
                {
                    Top    = "8mm",
                    Bottom = "8mm",
                    Left   = "6mm",
                    Right  = "6mm"
                }
            });
        }

        /// <summary>
        /// Convierte un número decimal a texto en español hondureño.
        /// Ej: 1097.75 → "MIL NOVENTA Y SIETE LEMPIRAS CON 75/100"
        /// </summary>
        private string ConvertirNumeroALetras(decimal numero)
        {
            long entero = (long)numero;
            int centavos = (int)Math.Round((numero - entero) * 100);

            string[] unidades = { "", "UNO", "DOS", "TRES", "CUATRO", "CINCO",
                                   "SEIS", "SIETE", "OCHO", "NUEVE", "DIEZ",
                                   "ONCE", "DOCE", "TRECE", "CATORCE", "QUINCE",
                                   "DIECISÉIS", "DIECISIETE", "DIECIOCHO", "DIECINUEVE" };
            string[] decenas = { "", "DIEZ", "VEINTE", "TREINTA", "CUARENTA",
                                  "CINCUENTA", "SESENTA", "SETENTA", "OCHENTA", "NOVENTA" };

            string letras = ConvertirEnteroALetras(entero, unidades, decenas);
            return $"{letras} LEMPIRAS CON {centavos:D2}/100";
        }

        private string ConvertirEnteroALetras(long n, string[] unidades, string[] decenas)
        {
            if (n == 0) return "CERO";
            if (n < 0)  return "MENOS " + ConvertirEnteroALetras(-n, unidades, decenas);
            if (n < 20) return unidades[n];
            if (n < 100)
            {
                string dec = decenas[n / 10];
                return n % 10 == 0 ? dec : dec + " Y " + unidades[n % 10];
            }
            if (n < 1000)
            {
                if (n == 100) return "CIEN";
                string[] centenas = { "", "CIENTO", "DOSCIENTOS", "TRESCIENTOS",
                                       "CUATROCIENTOS", "QUINIENTOS", "SEISCIENTOS",
                                       "SETECIENTOS", "OCHOCIENTOS", "NOVECIENTOS" };
                string resto = n % 100 == 0 ? "" : " " + ConvertirEnteroALetras(n % 100, unidades, decenas);
                return centenas[n / 100] + resto;
            }
            if (n < 1000000)
            {
                long miles = n / 1000;
                string prefijo = miles == 1 ? "MIL" : ConvertirEnteroALetras(miles, unidades, decenas) + " MIL";
                string resto = n % 1000 == 0 ? "" : " " + ConvertirEnteroALetras(n % 1000, unidades, decenas);
                return prefijo + resto;
            }
            long millones = n / 1000000;
            string prefijoM = millones == 1 ? "UN MILLÓN" : ConvertirEnteroALetras(millones, unidades, decenas) + " MILLONES";
            string restoM = n % 1000000 == 0 ? "" : " " + ConvertirEnteroALetras(n % 1000000, unidades, decenas);
            return prefijoM + restoM;
        }
    }
}
