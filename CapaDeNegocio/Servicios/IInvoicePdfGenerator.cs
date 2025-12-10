using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocio.Servicios
{
    public interface IInvoicePdfGenerator
    {
        /// <summary>
        /// Genera la factura en PDF y abre el archivo resultante (opcional).
        /// Implementación debe ser eficiente: escribir directo a disco y cachear recursos pesados.
        /// </summary>
        /// <param name="factura">Modelo de factura (CapaDominio.Entidades.Factura)</param>
        /// <param name="rutaSalida">Ruta completa donde guardar el PDF. Si es null, la implementación crea una por defecto.</param>
        Task<string> GenerateAndOpenPdfAsync(CapaDeNegocio.Entidades.Factura factura, string rutaSalida = null);
    }
}

