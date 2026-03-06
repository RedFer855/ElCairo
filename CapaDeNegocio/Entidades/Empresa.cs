using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocio.Entidades
{
    public class Empresa
    {
        public string Nombre { get; set; }
        public string RTN { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string CAI { get; set; }
        public string RangoAutorizado { get; set; }
        public DateTime FechaLimiteEmision { get; set; }
    }

    // Clase temporal con datos manuales. Más adelante reemplazar por EmpresaService que lea de BD.
    public static class EmpresaConfig
    {
        public static Empresa ObtenerEmpresaManual()
        {
            return new Empresa
            {
                Nombre = "EL CAIRO S.A",
                RTN = "01010101010101",
                Direccion = "Tegucigalpa, Honduras",
                Telefono = "504-9999-9999",
                Correo = "info@elcairo.com",
                CAI = "A1B2-C3D4-E5F6",
                RangoAutorizado = "000-001-01-00000001 al 00000099",
                FechaLimiteEmision = new DateTime(2026, 12, 31)
            };
        }
    }
}
