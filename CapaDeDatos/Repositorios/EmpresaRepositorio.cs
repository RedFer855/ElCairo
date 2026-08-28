using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CapaDeDatos.Repositorios
{
    public class EmpresaRepositorio
    {
        // ← Fallback con valores de demo. Se usa solo si la BD no responde.
        private static readonly ConfiguracionEmpresa _fallback = new ConfiguracionEmpresa
        {
            NombreEmpresa       = "Distribuidora El Cairo S. de R.L.",
            RtnEmpresa          = "0801-1999-123456",
            DireccionEmpresa    = "Tegucigalpa, Francisco Morazán, Honduras",
            TelefonoEmpresa     = "(504) 2222-3333",
            CorreoEmpresa       = "facturacion@elcairo.hn",
            CaiEmpresa          = "000000-000000-000000-000000-000000-00",
            RangoAutorizado     = "000-001-01-00000001 AL 000-001-01-00001000",
            FechaLimiteEmision  = new System.DateTime(2026, 12, 31),
            Estado              = true
        };

        public async Task<ConfiguracionEmpresa> ObtenerConfiguracionAsync()
        {
            try
            {
                var client = await Conexion.ConnectWithTimeoutAsync(3);
                var response = await client
                    .From<ConfiguracionEmpresa>()
                    .Where(e => e.Estado == true)
                    .Limit(1)
                    .Get();

                return response?.Models?.FirstOrDefault() ?? _fallback;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"EmpresaRepositorio fallback: {ex.Message}");
                return _fallback;
            }
        }
    }
}
