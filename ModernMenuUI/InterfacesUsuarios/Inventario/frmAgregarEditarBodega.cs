using CapaDeDatos.Modelados.Inventario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI.InterfacesUsuarios.Inventario
{
    public partial class frmAgregarEditarBodega : Form
    {
        public frmAgregarEditarBodega()
        {
            InitializeComponent();
        }

        public frmAgregarEditarBodega(Bodega _nuevaBodega)
        {
            InitializeComponent();
            txtNombreBodega.Text = _nuevaBodega.NombreBodega;
                
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardarBodega_Click(object sender, EventArgs e)
        {

        }
    }
}
