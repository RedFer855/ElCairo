using System;
using System.Windows.Forms;
using CapaDominio.Entidades;
using CapaDominio.Servicios;

namespace ModernMenuUI.InterfacesUsuarios.Inventario
{
    public partial class frmAgregarEditarGananciaModo : Form
    {
        private bool actualizando = false;
        private readonly decimal TOLERANCIA = 0.005m; // evita micro-reasignaciones por redondeo

        public frmAgregarEditarGananciaModo()
        {
            InitializeComponent();
            ConfigurarNudPorDefecto();
        }

        private void ConfigurarNudPorDefecto()
        {
            // Ajusta según necesites; importante: permitir negativos si quieres pérdidas
            nudPrecioCompra.DecimalPlaces = 2;
            nudPrecioCompra.Minimum = 0m;
            nudPrecioCompra.Maximum = 999_999m;
            nudPrecioCompra.Increment = 0.01m;

            nudPrecioCosto.DecimalPlaces = 2;
            nudPrecioCosto.Minimum = 0m;
            nudPrecioCosto.Maximum = 999_999m;
            nudPrecioCosto.Increment = 0.01m;

            // Por defecto permitimos pérdidas (ganancia negativa). Si no quieres pérdidas pon Minimum = 0.
            nudGanancia.DecimalPlaces = 2;
            nudGanancia.Minimum = -1000m; // permite hasta -1000% (pérdida)
            nudGanancia.Maximum = 1000m;
            nudGanancia.Increment = 0.01m;

            nudPrecioFinal.DecimalPlaces = 2;
            nudPrecioFinal.Minimum = 0m;
            nudPrecioFinal.Maximum = 999_999m;
            nudPrecioFinal.Increment = 0.01m;
        }



        // Eventos: todos llaman al método central
        private void nudPrecioCompra_ValueChanged(object sender, EventArgs e)
        {
            if (actualizando) return;
            actualizando = true;
            // el precio de compra es la fuente para costo
            AsignarNudSeguro(nudPrecioCosto, nudPrecioCompra.Value);
            actualizando = false;
            Calcular();
        }

        private void nudPrecioCosto_ValueChanged(object sender, EventArgs e) => Calcular();
        private void nudGanancia_ValueChanged(object sender, EventArgs e) => Calcular();
        private void nudPrecioFinal_ValueChanged(object sender, EventArgs e) => Calcular();

        private void rbGanancia_CheckedChanged(object sender, EventArgs e)
        {
            nudGanancia.Enabled = rbGanancia.Checked;
            nudPrecioFinal.Enabled = !rbGanancia.Checked;
            Calcular();
        }

        private void rbPrecio_CheckedChanged(object sender, EventArgs e)
        {
            nudPrecioFinal.Enabled = rbPrecio.Checked;
            nudGanancia.Enabled = !rbPrecio.Checked;
            Calcular();
        }

        // Método central que usa la lógica de negocio y actualiza controles de forma segura
        private void Calcular()
        {
            if (actualizando) return;

            decimal costo = nudPrecioCosto.Value;
            if (costo <= 0m) return; // según tus reglas: no calcular si costo es 0

            actualizando = true;
            try
            {
                if (rbGanancia.Checked)
                {
                    // fuente: porcentaje ganancia -> calcular precio final
                    decimal porcentaje = nudGanancia.Value;
                    ResultadoCalculoGanancia res = CalculoGananciaPrecioCosto.CalcularPrecioDesdeGanancia(costo, porcentaje);

                    if (!res.Success)
                    {
                        // mostrar advertencia si corresponde y ajustar límites si es necesario
                        MessageBox.Show(res.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        // si excede limites, clamp en la UI:
                        if (porcentaje > nudGanancia.Maximum) AsignarNudSeguro(nudGanancia, nudGanancia.Maximum);
                        else if (porcentaje < nudGanancia.Minimum) AsignarNudSeguro(nudGanancia, nudGanancia.Minimum);

                        // no asignamos precio inválido
                    }
                    else
                    {
                        AsignarNudSeguro(nudPrecioFinal, res.PrecioFinal);
                        // opcional: actualizar nudGanancia con valor redondeado por si cambió
                        AsignarNudSeguro(nudGanancia, res.PorcentajeGanancia);
                    }
                }
                else // modo precio (rbPrecio.Checked)
                {
                    decimal precio = nudPrecioFinal.Value;
                    ResultadoCalculoGanancia res = CalculoGananciaPrecioCosto.CalcularGananciaDesdePrecio(costo, precio);

                    if (!res.Success)
                    {
                        MessageBox.Show(res.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        // si precio > max, ajustar
                        if (precio > nudPrecioFinal.Maximum) AsignarNudSeguro(nudPrecioFinal, nudPrecioFinal.Maximum);
                    }
                    else
                    {
                        // asignamos la ganancia calculada sin lanzar excepción (clamp interno)
                        AsignarNudSeguro(nudGanancia, res.PorcentajeGanancia);
                        // opcional: actualizar nudPrecioFinal con valor redondeado por si cambió
                        AsignarNudSeguro(nudPrecioFinal, res.PrecioFinal);
                    }
                }
            }
            finally
            {
                actualizando = false;
            }
        }

        // Helper: asigna valor a un NumericUpDown de forma segura (clamp + redondeo + tolerancia)
        private void AsignarNudSeguro(NumericUpDown nud, decimal valor)
        {
            // clamp al rango del control
            if (valor < nud.Minimum) valor = nud.Minimum;
            if (valor > nud.Maximum) valor = nud.Maximum;

            // redondeo según DecimalPlaces del control
            decimal redondeado = Math.Round(valor, nud.DecimalPlaces, MidpointRounding.AwayFromZero);

            // si la diferencia es insignificante evitamos reasignar (evita 9.18 -> 9.16 por micro-fluctuación)
            if (Math.Abs(nud.Value - redondeado) < TOLERANCIA) return;

            nud.Value = redondeado;
        }

        private void btnGananciaFijaInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Modo Ganancia: define un porcentaje de ganancia. Si cambia el costo, el sistema recalcula el precio manteniendo ese porcentaje.",
                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPrecioFijoInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Modo Precio: define un precio fijo. Si cambia el costo, el sistema recalcula la ganancia.",
                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGuardarProducto_Click(object sender, EventArgs e)
        {

        }
    }


}