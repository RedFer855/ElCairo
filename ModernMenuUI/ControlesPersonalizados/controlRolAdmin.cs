using ModernMenuUI.ClasesUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI
{
    public partial class controlRolAdmin : UserControl
    {
        public controlRolAdmin()
        {
            InitializeComponent();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            ManejarFormularios.Instancia.AbrirFormularioEncima(new frmAgregarEditarRol());
        }
    }
}
