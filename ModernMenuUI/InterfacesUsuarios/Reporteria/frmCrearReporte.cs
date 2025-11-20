using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI.InterfacesUsuarios.Reporteria
{
    public partial class frmCrearReporte : Form
    {
        public frmCrearReporte()
        {
            InitializeComponent();
        }

        private void btnReporteInventarioBajo_Click(object sender, EventArgs e)
        {
            frmAbrirReporte AbrirReporte = new frmAbrirReporte();
            AbrirReporte.ShowDialog();
        }

        private void btnReporteInventarioBajo_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
