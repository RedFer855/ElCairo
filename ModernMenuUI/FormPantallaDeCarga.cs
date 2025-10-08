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
    public partial class FormPantallaDeCarga : Form
    {
        private System.Windows.Forms.Timer temporizador;
        public FormPantallaDeCarga()
        {
            InitializeComponent();
            // Inicializar el temporizador
            temporizador = new System.Windows.Forms.Timer();
            temporizador.Interval = 10; // velocidad del progreso
            temporizador.Tick += temporizador_Tick;
            pbInicioSistema.Value = 0; // iniciar desde 0
            temporizador.Start();    // iniciar animación

        }


        private void temporizador_Tick(object sender, EventArgs e)
        {
            if (pbInicioSistema.Value < pbInicioSistema.Maximum)
            {
                pbInicioSistema.Value += 1; // avanza el progreso
            }
            else
            {
                temporizador.Stop();// detener el timer
                this.Visible = false;// ocultar pantalla de carga

                // Abrir MenuPrincipal
                MenuPrincipal formularioPrincipal = new MenuPrincipal();
                formularioPrincipal.StartPosition = FormStartPosition.CenterScreen;
                formularioPrincipal.WindowState = FormWindowState.Maximized;
                formularioPrincipal.ShowDialog();
            }
        }

        private void pbInicioSistema_Click(object sender, EventArgs e)
        {

        }
    }
}
