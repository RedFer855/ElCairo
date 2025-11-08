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
    public partial class frmAgregarEditarRol : Form
    {
        public frmAgregarEditarRol()
        {
            InitializeComponent();
        }

        private void lblNombreModulo_Click(object sender, EventArgs e)
        {
            clsAnmaciones.MoverFormulario(this.Handle);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panBarraControl_MouseDown(object sender, MouseEventArgs e)
        {
            clsAnmaciones.MoverFormulario(this.Handle);
        }

        private void btnDehabilitarCompras_Click(object sender, EventArgs e)
        {
            // Recorre todos los controles dentro del GroupBox
            foreach (Control control in gbxCompras.Controls)
            {
                // Verifica si el control es un CheckBox
                if (control is CheckBox chk)
                {
                    chk.Checked = false; // Desmarca la casilla
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
