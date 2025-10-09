using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;

namespace ModernMenuUI
{
    internal class AnimadorPanel
    {
        private Panel panel;
        private Timer timerAbrir;
        private Timer timerCerrar;
        private int anchoMin, anchoMax;
        private int paso;
        private bool animando = false; // Para bloquear clicks rápidos

        public AnimadorPanel(Panel panel, int anchoMin, int anchoMax, int paso)
        {
            this.panel = panel;
            this.anchoMin = anchoMin;
            this.anchoMax = anchoMax;
            this.paso = paso;

            timerAbrir = new Timer();
            timerCerrar = new Timer();
            timerAbrir.Interval = 10;
            timerCerrar.Interval = 10;

            timerAbrir.Tick += TimerAbrir_Tick;
            timerCerrar.Tick += TimerCerrar_Tick;
        }

        public void Abrir()
        {
            if (animando) return; // Bloquea si ya está animando
            animando = true;
            panel.Visible = true; // Asegurarse que sea visible
            timerAbrir.Start();
        }

        public void Cerrar()
        {
            if (animando) return; // Bloquea si ya está animando
            animando = true;
            timerCerrar.Start();
        }

        private void TimerAbrir_Tick(object sender, EventArgs e)
        {
            if (panel.Width < anchoMax)
            {
                panel.Width += paso;
            }
            else
            {
                timerAbrir.Stop();
                animando = false; // Desbloquea clicks
            }
        }

        private void TimerCerrar_Tick(object sender, EventArgs e)
        {
            if (panel.Width > anchoMin)
            {
                panel.Width -= paso;
            }
            else
            {
                timerCerrar.Stop();
                panel.Visible = false; // Oculta al cerrar
                animando = false; // Desbloquea clicks
            }
        }
    }
}
