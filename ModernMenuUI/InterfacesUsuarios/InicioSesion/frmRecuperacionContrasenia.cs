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
    public partial class frmRecuperacionContrasenia : Form
    {
        public frmRecuperacionContrasenia()
        {
            InitializeComponent();
        }

        private void pbxLogoEmpresa_MouseDown(object sender, MouseEventArgs e)
        {
            clsAnmaciones.MoverFormulario(this.Handle);
        }

        private void panDatosIngreso_MouseDown(object sender, MouseEventArgs e)
        {
            clsAnmaciones.MoverFormulario(this.Handle);
        }

        private void panBarraControl_MouseDown(object sender, MouseEventArgs e)
        {
            clsAnmaciones.MoverFormulario(this.Handle);
        }

        private void lblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            clsAnmaciones.MoverFormulario(this.Handle);
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblRegresar_MouseEnter(object sender, EventArgs e)
        {
            lblRegresar.ForeColor = Color.Blue;
            lblRegresar.Font = new Font(lblRegresar.Font, FontStyle.Underline);
        }

        private void lblRegresar_MouseLeave(object sender, EventArgs e)
        {
            lblRegresar.ForeColor = Color.DimGray;
            lblRegresar.Font = new Font(lblRegresar.Font, FontStyle.Regular);
        }

        private void panBarraControl_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
