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
    public partial class frmInicioBodega : Form
    {
        public frmInicioBodega()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            Form formcarga = new frmPantallaDeCarga();
            this.Visible = false;
            formcarga.ShowDialog();
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panBarraControl_MouseDown(object sender, MouseEventArgs e)
        {
            Clase_Animaciones.MoverFormulario(this.Handle);
        }
    }
}
