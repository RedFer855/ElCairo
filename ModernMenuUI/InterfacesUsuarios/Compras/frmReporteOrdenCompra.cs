using CapaDeDatos.Reportes;
using Microsoft.Reporting.WinForms;
using Supabase.Gotrue.Mfa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI.InterfacesUsuarios.Compras
{
    public partial class frmReporteOrdenCompra : Form
    {
        // Aquí guardaremos los datos que nos pasen al crear el formulario
        private List<clsOrdenCompra> _listaItems;
        private string _subtotal;
        private string _impuesto;
        private string _totalGeneral;

        public frmReporteOrdenCompra(List<clsOrdenCompra> items, string sub, string imp, string total)
        {
            InitializeComponent();
            _listaItems = items;
            _subtotal = sub;
            _impuesto = imp;
            _totalGeneral = total;

            // Código para asegurar que el control se vea
            // (esto ya lo tenías y está perfecto)
            if (this.reportViewer1 != null)
            {
                this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
                if (!this.Controls.Contains(this.reportViewer1))
                {
                    this.Controls.Add(this.reportViewer1);
                }
            }
        }

        private void frmReporteOrdenCompra_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Especifica la ruta de tu archivo de reporte .rdlc
                // (Recuerda poner su propiedad "Copy to Output Directory" en "Copy if newer")
                reportViewer1.LocalReport.ReportPath = @"ReporteOrdenCompra.rdlc";
                reportViewer1.LocalReport.DataSources.Clear();

                // 2. Crea el Origen de Datos (DataSource) para la TABLA de items
                //    ¡¡AQUÍ ESTÁ LA CORRECCIÓN!!
                //    Usamos "OrdenCompra", que es el nombre de tu DataSet.
                ReportDataSource rds = new ReportDataSource("OrdenCompra", _listaItems);
                reportViewer1.LocalReport.DataSources.Add(rds);

                // 3. Pasa los totales (Subtotal, Impuesto, Total) como PARÁMETROS
                // "pSubtotal", "pImpuesto", "pTotalGeneral" deben ser los MISMOS nombres
                // que le pusiste a los Parámetros dentro del diseñador del .rdlc
                ReportParameter pSubtotal = new ReportParameter("pSubtotal", _subtotal);
                ReportParameter pImpuesto = new ReportParameter("pImpuesto", _impuesto);
                ReportParameter pTotalGeneral = new ReportParameter("pTotalGeneral", _totalGeneral);

                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pSubtotal, pImpuesto, pTotalGeneral });

                // 4. Actualiza (refresca) el visor para que muestre los datos
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                // Es una buena práctica agregar un try-catch aquí
                // por si el archivo .rdlc no se encuentra o un parámetro/dataset no coincide.
                MessageBox.Show("Error al cargar el reporte: " + ex.Message, "Error de Reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
