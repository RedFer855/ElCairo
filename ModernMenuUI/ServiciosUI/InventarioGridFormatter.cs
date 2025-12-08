using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using CapaDeDatos.Modelados.Inventario;
using CapaDominio.Servicios;
using CapaDominio.Entidades;
using CapaDominio.Enums;
using ModernMenuUI.Adapters;

namespace ModernMenuUI.ServiciosUI.GridFormatters
{
    public static class InventarioGridFormatter
    {
        private static readonly Color TextoGris = Color.FromArgb(95, 108, 121);
        private static readonly Color FondoVerde = Color.FromArgb(207, 239, 207);
        private static readonly Color FondoRojo = Color.FromArgb(239, 207, 207);
        private static readonly Color FondoAmarillo = Color.FromArgb(255, 245, 157);

        public static void AplicarFormato(DataGridViewRow row)
        {
            if (row?.DataBoundItem is not Inventario inv)
                return;

            var dom = InventarioAdapter.Map(inv);
            var estado = EvaluadorStock.ObtenerEstado(dom);

            switch (estado)
            {
                case EstadoStock.Critico:
                    row.DefaultCellStyle.BackColor = FondoRojo;
                    break;

                case EstadoStock.Advertencia:
                    row.DefaultCellStyle.BackColor = FondoAmarillo;
                    break;

                default:
                    row.DefaultCellStyle.BackColor = FondoVerde;
                    break;
            }

            row.DefaultCellStyle.ForeColor = TextoGris;
        }
    }
}

