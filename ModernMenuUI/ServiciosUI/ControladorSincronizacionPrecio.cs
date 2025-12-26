using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI.ClasesUI
{
    internal class ControladorSincronizacionPrecio : IDisposable
    {
        private readonly NumericUpDown _nudCosto;
        private readonly NumericUpDown _nudPrecioVenta;
        private readonly NumericUpDown _nudPorcentajeGanancia;
        private readonly ConfiguracionSincronizacionPrecio _config;

        private bool _actualizando;

        // ===== CONSTRUCTOR PRIVADO =====
        private ControladorSincronizacionPrecio(
            NumericUpDown nudCosto,
            NumericUpDown nudPrecioVenta,
            NumericUpDown nudPorcentajeGanancia,
            ConfiguracionSincronizacionPrecio configuracion)
        {
            _nudCosto = nudCosto;
            _nudPrecioVenta = nudPrecioVenta;
            _nudPorcentajeGanancia = nudPorcentajeGanancia;
            _config = configuracion ?? new ConfiguracionSincronizacionPrecio();

            ConfigurarControles();

            _nudCosto.ValueChanged += AlCambiarCosto;
            _nudPrecioVenta.ValueChanged += AlCambiarPrecioVenta;
            _nudPorcentajeGanancia.ValueChanged += AlCambiarPorcentaje;
        }

        // ===== FACTORY (UNA SOLA LÍNEA) =====
        public static ControladorSincronizacionPrecio Crear(
            NumericUpDown nudCosto,
            NumericUpDown nudPrecioVenta,
            NumericUpDown nudPorcentajeGanancia,
            Action<ConfiguracionSincronizacionPrecio> configurar)
        {
            var config = new ConfiguracionSincronizacionPrecio();
            configurar?.Invoke(config);

            return new ControladorSincronizacionPrecio(
                nudCosto,
                nudPrecioVenta,
                nudPorcentajeGanancia,
                config
            );
        }

        // ===== CONFIGURACIÓN INICIAL =====
        private void ConfigurarControles()
        {
            _nudCosto.DecimalPlaces = _config._decimalesMoneda;
            _nudPrecioVenta.DecimalPlaces = _config._decimalesMoneda;

            _nudCosto.Minimum = _config._costoMinimo;

            _nudPorcentajeGanancia.Maximum = _config._porcentajeMaximo;
            _nudPorcentajeGanancia.Minimum =
                _config._permitirGananciaNegativa
                    ? -_config._porcentajeMaximo
                    : 0;
        }

        // ===== EVENTOS =====

        private void AlCambiarCosto(object sender, EventArgs e)
        {
            if (_actualizando) return;
            _actualizando = true;

            decimal nuevoPrecio =
                _nudCosto.Value * (1 + _nudPorcentajeGanancia.Value / 100);

            _nudPrecioVenta.Value =
                LimitarValor(_nudPrecioVenta, nuevoPrecio);

            _actualizando = false;
        }

        private void AlCambiarPrecioVenta(object sender, EventArgs e)
        {
            if (_actualizando) return;

            if (_nudCosto.Value == 0)
            {
                _config._alError?.Invoke(
                    "El precio de costo no puede ser 0."
                );
                return;
            }

            _actualizando = true;

            decimal nuevoPorcentaje =
                (_nudPrecioVenta.Value - _nudCosto.Value)
                / _nudCosto.Value * 100;

            _nudPorcentajeGanancia.Value =
                LimitarValor(_nudPorcentajeGanancia, nuevoPorcentaje);

            _actualizando = false;
        }

        private void AlCambiarPorcentaje(object sender, EventArgs e)
        {
            if (_actualizando) return;
            _actualizando = true;

            decimal nuevoPrecio =
                _nudCosto.Value * (1 + _nudPorcentajeGanancia.Value / 100);

            _nudPrecioVenta.Value =
                LimitarValor(_nudPrecioVenta, nuevoPrecio);

            _actualizando = false;
        }

        // ===== UTILIDAD =====
        private decimal LimitarValor(NumericUpDown nud, decimal valor)
        {
            if (valor < nud.Minimum) return nud.Minimum;
            if (valor > nud.Maximum) return nud.Maximum;
            return valor;
        }

        // ===== LIMPIEZA =====
        public void Dispose()
        {
            _nudCosto.ValueChanged -= AlCambiarCosto;
            _nudPrecioVenta.ValueChanged -= AlCambiarPrecioVenta;
            _nudPorcentajeGanancia.ValueChanged -= AlCambiarPorcentaje;
        }
    }
}

