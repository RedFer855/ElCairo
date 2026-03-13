using System;
using System.Windows.Forms;
using CapaDominio.Entidades;
using CapaDominio.Servicios;

namespace ModernMenuUI.InterfacesUsuarios.Inventario
{
    public partial class frmAgregarEditarGananciaModo : Form
    {
        private bool actualizando = false;
        private readonly decimal TOLERANCIA = 0.005m;

        public ConfiguracionGananciaProducto DatosGanancia { get; private set; }

        public frmAgregarEditarGananciaModo()
        {
            InitializeComponent();
            ConfigurarNudPorDefecto();
        }

        private void ConfigurarNudPorDefecto()
        {
            nudPrecioCompra.DecimalPlaces = 2;
            nudPrecioCompra.Minimum = 0m;
            nudPrecioCompra.Maximum = 999999m;
            nudPrecioCompra.Increment = 0.01m;

            nudPrecioCosto.DecimalPlaces = 2;
            nudPrecioCosto.Minimum = 0m;
            nudPrecioCosto.Maximum = 999999m;
            nudPrecioCosto.Increment = 0.01m;

            nudGanancia.DecimalPlaces = 2;
            nudGanancia.Minimum = 0m;
            nudGanancia.Maximum = 1000m;
            nudGanancia.Increment = 0.01m;

            nudPrecioFinal.DecimalPlaces = 2;
            nudPrecioFinal.Minimum = 0m;
            nudPrecioFinal.Maximum = 999999m;
            nudPrecioFinal.Increment = 0.01m;

            nudGanancia.Enabled = rbGanancia.Checked;
            nudPrecioFinal.Enabled = rbPrecio.Checked;
        }

        private void nudPrecioCompra_ValueChanged(object sender, EventArgs e)
        {
            if (actualizando) return;

            actualizando = true;
            AsignarNudSeguro(nudPrecioCosto, nudPrecioCompra.Value);
            actualizando = false;

            Calcular();
        }

        private void nudPrecioCosto_ValueChanged(object sender, EventArgs e)
        {
            if (actualizando) return;
            Calcular();
        }

        private void nudGanancia_ValueChanged(object sender, EventArgs e)
        {
            if (actualizando) return;
            Calcular();
        }

        private void nudPrecioFinal_ValueChanged(object sender, EventArgs e)
        {
            if (actualizando) return;
            Calcular();
        }

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

        private void Calcular()
        {
            if (actualizando) return;

            decimal costo = nudPrecioCosto.Value;

            if (costo <= 0m)
            {
                actualizando = true;
                try
                {
                    AsignarNudSeguro(nudGanancia, 0m);
                    AsignarNudSeguro(nudPrecioFinal, 0m);
                }
                finally
                {
                    actualizando = false;
                }
                return;
            }

            actualizando = true;
            try
            {
                if (rbGanancia.Checked)
                {
                    decimal porcentaje = nudGanancia.Value;

                    if (porcentaje < 0m)
                        porcentaje = 0m;

                    ResultadoCalculoGanancia res =
                        CalculoGananciaPrecioCosto.CalcularPrecioDesdeGanancia(costo, porcentaje);

                    if (!res.Success)
                    {
                        MessageBox.Show(
                            res.Message,
                            "Advertencia",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        AsignarNudSeguro(nudGanancia, porcentaje);
                    }
                    else
                    {
                        decimal porcentajeSeguro = res.PorcentajeGanancia < 0m ? 0m : res.PorcentajeGanancia;
                        decimal precioFinalSeguro = res.PrecioFinal < 0m ? 0m : res.PrecioFinal;

                        AsignarNudSeguro(nudGanancia, porcentajeSeguro);
                        AsignarNudSeguro(nudPrecioFinal, precioFinalSeguro);
                    }
                }
                else
                {
                    decimal precio = nudPrecioFinal.Value;

                    if (precio < 0m)
                        precio = 0m;

                    ResultadoCalculoGanancia res =
                        CalculoGananciaPrecioCosto.CalcularGananciaDesdePrecio(costo, precio);

                    if (!res.Success)
                    {
                        MessageBox.Show(
                            res.Message,
                            "Advertencia",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        AsignarNudSeguro(nudPrecioFinal, precio);
                    }
                    else
                    {
                        decimal gananciaSegura = res.PorcentajeGanancia < 0m ? 0m : res.PorcentajeGanancia;
                        decimal precioFinalSeguro = res.PrecioFinal < 0m ? 0m : res.PrecioFinal;

                        AsignarNudSeguro(nudGanancia, gananciaSegura);
                        AsignarNudSeguro(nudPrecioFinal, precioFinalSeguro);
                    }
                }
            }
            finally
            {
                actualizando = false;
            }
        }

        private void AsignarNudSeguro(NumericUpDown nud, decimal valor)
        {
            if (valor < 0m)
                valor = 0m;

            if (valor < nud.Minimum)
                valor = nud.Minimum;

            if (valor > nud.Maximum)
                valor = nud.Maximum;

            decimal redondeado = Math.Round(
                valor,
                nud.DecimalPlaces,
                MidpointRounding.AwayFromZero
            );

            if (Math.Abs(nud.Value - redondeado) < TOLERANCIA)
                return;

            nud.Value = redondeado;
        }

        private void btnGananciaFijaInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Modo Ganancia: define un porcentaje de ganancia. Si cambia el costo, el sistema recalcula el precio manteniendo ese porcentaje.",
                "Información",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnPrecioFijoInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Modo Precio: define un precio fijo. Si cambia el costo, el sistema recalcula la ganancia.",
                "Información",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            decimal precioCompra = nudPrecioCompra.Value;
            decimal precioCosto = nudPrecioCosto.Value;
            decimal porcentajeGanancia = nudGanancia.Value;
            decimal precioFinal = nudPrecioFinal.Value;

            if (precioCompra <= 0m)
            {
                MessageBox.Show(
                    "El precio de compra debe ser mayor que 0.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                nudPrecioCompra.Focus();
                return;
            }

            if (precioCosto <= 0m)
            {
                MessageBox.Show(
                    "El precio costo debe ser mayor que 0.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                nudPrecioCosto.Focus();
                return;
            }

            if (precioFinal <= 0m)
            {
                MessageBox.Show(
                    "El precio final debe ser mayor que 0.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                nudPrecioFinal.Focus();
                return;
            }

            if (precioFinal < precioCompra)
            {
                MessageBox.Show(
                    "No se puede guardar un precio final menor al precio de compra.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                nudPrecioFinal.Focus();
                return;
            }

            int tipoCalculo = rbGanancia.Checked ? 1 : 2;

            DatosGanancia = new ConfiguracionGananciaProducto
            {
                PrecioCompra = precioCompra,
                PrecioCosto = precioCosto,
                PorcentajeGanancia = porcentajeGanancia,
                PrecioFinal = precioFinal,
                UsaModoGanancia = rbGanancia.Checked,
                UsaModoPrecio = rbPrecio.Checked,
                TipoCalculoGananciaProducto = tipoCalculo
            };

            MessageBox.Show(
                "Datos enviados en el objeto:\n\n" +
                $"PrecioCompra: {DatosGanancia.PrecioCompra:0.00}\n" +
                $"PrecioCosto: {DatosGanancia.PrecioCosto:0.00}\n" +
                $"PorcentajeGanancia: {DatosGanancia.PorcentajeGanancia:0.00}\n" +
                $"PrecioFinal: {DatosGanancia.PrecioFinal:0.00}\n" +
                $"UsaModoGanancia: {DatosGanancia.UsaModoGanancia}\n" +
                $"UsaModoPrecio: {DatosGanancia.UsaModoPrecio}\n" +
                $"TipoCalculoGananciaProducto: {DatosGanancia.TipoCalculoGananciaProducto}",
                "Objeto creado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}