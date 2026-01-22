using System;
using System.Windows.Forms;

namespace ModernMenuUI.ClasesUI
{
    /// <summary>
    /// Controla la sincronización entre:
    /// - Costo
    /// - Precio de venta
    /// - Porcentaje de ganancia
    /// 
    /// Reglas:
    /// - Ganancia máxima: 1000%
    /// - No se permiten ganancias negativas
    /// - Precio de venta nunca menor al costo
    /// - Al llegar a 1000%, el precio se congela (solo permite bajar)
    /// - Evita errores por redondeo
    /// - Evita MessageBox duplicados (muestra la advertencia solo una vez mientras permanezca la condición)
    /// </summary>
    internal class ControladorSincronizacionPrecio : IDisposable
    {
        private readonly NumericUpDown _nudCosto;
        private readonly NumericUpDown _nudPrecioFinal;
        private readonly NumericUpDown _nudPrecioVenta;
        private readonly NumericUpDown _nudPorcentajeGanancia;
        private readonly ConfiguracionSincronizacionPrecio _config;

        private bool _actualizando;

        // ===== TOPE 1000% =====
        private bool _topeActivo;
        private decimal _precioMaximo;

        // ===== CONTROL DE ALERTAS (MOSTRAR SOLO UNA VEZ MIENTRAS LA CONDICIÓN PERSISTE) =====
        private bool _alertaTopeMostrada;
        private bool _alertaPrecioCostoMostrada;

        // ================= CONSTRUCTOR =================
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
            _nudPorcentajeGanancia.MouseWheel += BloquearWheelPorcentaje;
        }

        // ================= FACTORY =================
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

        // ================= CONFIG =================
        private void ConfigurarControles()
        {
            _nudCosto.DecimalPlaces = _config._decimalesMoneda;
            _nudPrecioVenta.DecimalPlaces = _config._decimalesMoneda;

            _nudPorcentajeGanancia.DecimalPlaces = 2;
            _nudPorcentajeGanancia.Minimum = 0;
            _nudPorcentajeGanancia.Maximum = 1000;

            _nudCosto.Minimum = _config._costoMinimo;

            // Inicialmente aseguramos que el mínimo de precio de venta sea como el costo actual
            _nudPrecioVenta.Minimum = _nudCosto.Value;
        }

        // ================= EVENTOS =================

        private void AlCambiarCosto(object sender, EventArgs e)
        {
            if (_actualizando) return;
            _actualizando = true;

            // Aseguramos que el precio de venta no pueda bajar por debajo del costo actual
            _nudPrecioVenta.Minimum = _nudCosto.Value;

            // Recalcular precio máximo por tope (11x = 1000%)
            _precioMaximo = _nudCosto.Value * 11m;

            // Calculamos el nuevo precio según el porcentaje actual (redondeando al número de decimales de moneda)
            decimal nuevoPrecio = Math.Round(_nudCosto.Value * (1 + _nudPorcentajeGanancia.Value / 100m), _config._decimalesMoneda);

            if (_topeActivo && nuevoPrecio > _precioMaximo)
            {
                // Si ya estaba en tope, mantener el tope
                _nudPrecioVenta.Value = _precioMaximo;
                // Mostrar alerta solo si no se había mostrado ya mientras persiste la condición
                if (!_alertaTopeMostrada)
                {
                    Alerta("La ganancia máxima permitida es 1000%.");
                    _alertaTopeMostrada = true;
                }
            }
            else
            {
                _nudPrecioVenta.Value = LimitarValor(_nudPrecioVenta, nuevoPrecio);
            }

            // Si el precio ahora está por encima del costo, podemos permitir volver a mostrar la alerta de costo en el futuro
            if (_nudPrecioVenta.Value > _nudCosto.Value)
                _alertaPrecioCostoMostrada = false;

            _actualizando = false;
        }

        private void AlCambiarPrecioVenta(object sender, EventArgs e)
        {
            if (_actualizando) return;

            // Si intento poner precio por debajo del costo, lo forzamos al costo y mostramos una sola advertencia
            if (_nudPrecioVenta.Value < _nudCosto.Value)
            {
                _actualizando = true;
                _nudPrecioVenta.Value = _nudCosto.Value;

                if (!_alertaPrecioCostoMostrada)
                {
                    Alerta("El precio de venta no puede ser menor al costo.");
                    _alertaPrecioCostoMostrada = true;
                }

                _actualizando = false;
                return;
            }

            // Evitar división por cero al calcular porcentaje
            if (_nudCosto.Value == 0)
            {
                if (!_alertaPrecioCostoMostrada)
                {
                    Alerta("El costo no puede ser 0.");
                    _alertaPrecioCostoMostrada = true;
                }
                return;
            }

            _actualizando = true;

            // Recalcular precio máximo
            _precioMaximo = _nudCosto.Value * 11m;

            if (_nudPrecioVenta.Value > _precioMaximo)
            {
                _nudPrecioVenta.Value = _precioMaximo;
                // Establecemos el porcentaje al tope
                _nudPorcentajeGanancia.Value = 1000m;
                _topeActivo = true;

                if (!_alertaTopeMostrada)
                {
                    Alerta("La ganancia máxima permitida es 1000%.");
                    _alertaTopeMostrada = true;
                }
            }
            else
            {
                // Calcular nuevo porcentaje (redondeado a 2 decimales porque el control tiene 2)
                decimal nuevoPorcentaje =
                    Math.Round(((_nudPrecioVenta.Value - _nudCosto.Value) / _nudCosto.Value) * 100m, 2);

                _nudPorcentajeGanancia.Value =
                    LimitarValor(_nudPorcentajeGanancia, nuevoPorcentaje);

                // Si bajó del tope, permitimos que la alerta del tope se muestre otra vez en el futuro
                if (_nudPorcentajeGanancia.Value < 1000m)
                {
                    _topeActivo = false;
                    _alertaTopeMostrada = false;
                }
            }

            // Si el precio está por encima del costo, resetear la bandera de alerta por precio=costo
            if (_nudPrecioVenta.Value > _nudCosto.Value)
                _alertaPrecioCostoMostrada = false;

            _actualizando = false;
        }

        private void AlCambiarPrecioFinal(object sender, EventArgs e)
        {
            if (_actualizando) return;

            // Si intento poner precio por debajo del costo, lo forzamos al costo y mostramos una sola advertencia
            if (_nudPrecioVenta.Value < _nudCosto.Value)
            {
                _actualizando = true;
                _nudPrecioVenta.Value = _nudCosto.Value;

                if (!_alertaPrecioCostoMostrada)
                {
                    Alerta("El precio de venta no puede ser menor al costo.");
                    _alertaPrecioCostoMostrada = true;
                }

                _actualizando = false;
                return;
            }

            // Evitar división por cero al calcular porcentaje
            if (_nudCosto.Value == 0)
            {
                if (!_alertaPrecioCostoMostrada)
                {
                    Alerta("El costo no puede ser 0.");
                    _alertaPrecioCostoMostrada = true;
                }
                return;
            }

            _actualizando = true;

            // Recalcular precio máximo
            _precioMaximo = _nudCosto.Value * 11m;

            if (_nudPrecioVenta.Value > _precioMaximo)
            {
                _nudPrecioVenta.Value = _precioMaximo;
                // Establecemos el porcentaje al tope
                _nudPorcentajeGanancia.Value = 1000m;
                _topeActivo = true;

                if (!_alertaTopeMostrada)
                {
                    Alerta("La ganancia máxima permitida es 1000%.");
                    _alertaTopeMostrada = true;
                }
            }
            else
            {
                // Calcular nuevo porcentaje (redondeado a 2 decimales porque el control tiene 2)
                decimal nuevoPorcentaje =
                    Math.Round(((_nudPrecioVenta.Value - _nudCosto.Value) / _nudCosto.Value) * 100m, 2);

                _nudPorcentajeGanancia.Value =
                    LimitarValor(_nudPorcentajeGanancia, nuevoPorcentaje);

                // Si bajó del tope, permitimos que la alerta del tope se muestre otra vez en el futuro
                if (_nudPorcentajeGanancia.Value < 1000m)
                {
                    _topeActivo = false;
                    _alertaTopeMostrada = false;
                }
            }

            // Si el precio está por encima del costo, resetear la bandera de alerta por precio=costo
            if (_nudPrecioVenta.Value > _nudCosto.Value)
                _alertaPrecioCostoMostrada = false;

            _actualizando = false;
        }

        private void AlCambiarPorcentaje(object sender, EventArgs e)
        {
            if (_actualizando) return;
            _actualizando = true;

            if (_nudPorcentajeGanancia.Value >= 1000m)
            {
                // Forzar tope a 1000%
                _nudPorcentajeGanancia.Value = 1000m;
                _precioMaximo = _nudCosto.Value * 11m;
                _nudPrecioVenta.Value = _precioMaximo;
                _topeActivo = true;

                if (!_alertaTopeMostrada)
                {
                    Alerta("La ganancia máxima permitida es 1000%.");
                    _alertaTopeMostrada = true;
                }
            }
            else
            {
                // Salió del tope => permitir avisar otra vez en el futuro
                _topeActivo = false;
                _alertaTopeMostrada = false;

                decimal nuevoPrecio =
                    Math.Round(_nudCosto.Value * (1 + _nudPorcentajeGanancia.Value / 100m), _config._decimalesMoneda);

                _nudPrecioVenta.Value =
                    LimitarValor(_nudPrecioVenta, nuevoPrecio);
            }

            // Si el precio resultante es mayor que el costo, podemos volver a mostrar la alerta de precio=costo en el futuro
            if (_nudPrecioVenta.Value > _nudCosto.Value)
                _alertaPrecioCostoMostrada = false;

            _actualizando = false;
        }

        private void BloquearWheelPorcentaje(object sender, MouseEventArgs e)
        {
            // Si ya estamos en el tope y el usuario intenta subir más con la rueda, bloqueamos y mostramos solo una vez la alerta.
            if (_nudPorcentajeGanancia.Value >= 1000m && e.Delta > 0)
            {
                // Intentamos castear a HandledMouseEventArgs (normalmente el args real en MouseWheel es HandledMouseEventArgs)
                var handled = e as HandledMouseEventArgs;
                if (handled != null)
                    handled.Handled = true;

                if (!_alertaTopeMostrada)
                {
                    Alerta("La ganancia máxima permitida es 1000%.");
                    _alertaTopeMostrada = true;
                }
            }
        }

        // ================= UTILIDADES =================

        private decimal LimitarValor(NumericUpDown nud, decimal valor)
        {
            if (valor < nud.Minimum) return nud.Minimum;
            if (valor > nud.Maximum) return nud.Maximum;
            return valor;
        }

        /// <summary>
        /// Muestra la alerta (usa el delegado de configuración si existe).
        /// Esta función no tiene lógica de "solo una vez" —esa lógica se controla con las banderas específicas
        /// (_alertaTopeMostrada / _alertaPrecioCostoMostrada) en los lugares donde corresponde.
        /// </summary>
        private void Alerta(string mensaje)
        {
            if (_config?._alError != null)
                _config._alError.Invoke(mensaje);
            else
                MessageBox.Show(
                    mensaje,
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
        }

        // ================= LIMPIEZA =================
        public void Dispose()
        {
            _nudCosto.ValueChanged -= AlCambiarCosto;
            _nudPrecioVenta.ValueChanged -= AlCambiarPrecioVenta;
            _nudPorcentajeGanancia.ValueChanged -= AlCambiarPorcentaje;
            _nudPorcentajeGanancia.MouseWheel -= BloquearWheelPorcentaje;
        }
    }
}
