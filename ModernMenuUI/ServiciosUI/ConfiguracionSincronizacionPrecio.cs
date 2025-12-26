using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernMenuUI.ClasesUI
{
    internal class ConfiguracionSincronizacionPrecio
    {
        public bool _permitirGananciaNegativa { get; set; } = false;
        public int _decimalesMoneda { get; set; } = 2;
        public decimal _porcentajeMaximo { get; set; } = 1000;
        public decimal _costoMinimo { get; set; } = 0;
        public Action<string> _alError { get; set; }

        // ===== API FLUIDA =====

        public ConfiguracionSincronizacionPrecio PermitirGananciaNegativa(bool valor)
        {
            _permitirGananciaNegativa = valor;
            return this;
        }

        public ConfiguracionSincronizacionPrecio DecimalesMoneda(int valor)
        {
            _decimalesMoneda = valor;
            return this;
        }

        public ConfiguracionSincronizacionPrecio PorcentajeMaximo(decimal valor)
        {
            _porcentajeMaximo = valor;
            return this;
        }

        public ConfiguracionSincronizacionPrecio CostoMinimo(decimal valor)
        {
            _costoMinimo = valor;
            return this;
        }

        public ConfiguracionSincronizacionPrecio AlError(Action<string> accion)
        {
            _alError = accion;
            return this;
        }
    }
}

