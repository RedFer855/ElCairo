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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ModernMenuUI
{
    public partial class controlPanelRolesDinamicos : UserControl
    {

        public controlPanelRolesDinamicos()
        {
            InitializeComponent();

        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            clsManejarFormularios.Instancia.AbrirFormularioEncima(new frmAgregarEditarRol());

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
