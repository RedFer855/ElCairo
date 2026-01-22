using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI.InterfacesUsuarios.PrimerInicio
{
    public partial class frmBienvenida : Form
    {
        public frmBienvenida()
        {
            InitializeComponent();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            frmConfiguracionCredenciales frmConfigCredenciales = new frmConfiguracionCredenciales();
            frmConfigCredenciales.ShowDialog();
            this.Close();
        }
    }
}
