using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace ModernMenuUI.ClasesUI
{
    internal class AnimadorPanel
    {
        private Panel panel;
        private Timer timerAbrir;
        private Timer timerCerrar;
        private int anchoMin, anchoMax;
        private int paso;
        private bool animando = false;
        private bool overlayMode = false;

        // Eventos para avisar al formulario
        public Action AlTerminarAbrir;
        public Action AlTerminarCerrar;

        public AnimadorPanel(Panel panel, int anchoMin, int anchoMax, int paso, bool overlay = false)
        {
            this.panel = panel;
            this.anchoMin = anchoMin;
            this.anchoMax = anchoMax;
            this.paso = paso;
            this.overlayMode = overlay;

            timerAbrir = new Timer();
            timerCerrar = new Timer();
            timerAbrir.Interval = 10;
            timerCerrar.Interval = 10;

            timerAbrir.Tick += TimerAbrir_Tick;
            timerCerrar.Tick += TimerCerrar_Tick;

            if (overlayMode && panel.Parent != null)
            {
                // Evitamos layout continuo: desactivamos Dock y posicionamos como overlay
                panel.Dock = DockStyle.None;
                panel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
                panel.Width = anchoMax;
                panel.Left = panel.Parent.ClientSize.Width; // fuera de la vista (cerrado)
                panel.Visible = false;
                panel.Parent.SizeChanged += Parent_SizeChanged;
            }
        }

        private void Parent_SizeChanged(object sender, EventArgs e)
        {
            if (!overlayMode || panel.Parent == null) return;
            int pw = panel.Parent.ClientSize.Width;
            if (!panel.Visible || panel.Left >= pw)
                panel.Left = pw;
            else
                panel.Left = Math.Max(0, pw - panel.Width);
        }

        public void Abrir()
        {
            if (animando) return;
            animando = true;

            panel.Visible = true;
            panel.BringToFront();

            if (overlayMode && panel.Parent != null)
                panel.Left = panel.Parent.ClientSize.Width;

            timerAbrir.Start();
        }

        public void Cerrar()
        {
            if (animando) return;
            animando = true;
            timerCerrar.Start();
        }

        private void TimerAbrir_Tick(object sender, EventArgs e)
        {
            if (overlayMode)
            {
                if (panel.Parent == null) return;
                int parentWidth = panel.Parent.ClientSize.Width;
                int targetLeft = Math.Max(0, parentWidth - anchoMax);
                if (panel.Left > targetLeft)
                    panel.Left = Math.Max(targetLeft, panel.Left - paso);
                else
                {
                    timerAbrir.Stop();
                    animando = false;
                    AlTerminarAbrir?.Invoke();
                }
                return;
            }

            // modo original (ancho)
            if (panel.Width < anchoMax)
            {
                if (panel.Width + paso >= anchoMax)
                    panel.Width = anchoMax;
                else
                    panel.Width += paso;
            }
            else
            {
                timerAbrir.Stop();
                animando = false;
                AlTerminarAbrir?.Invoke();
            }
        }

        private void TimerCerrar_Tick(object sender, EventArgs e)
        {
            if (overlayMode)
            {
                if (panel.Parent == null) return;
                int parentWidth = panel.Parent.ClientSize.Width;
                int closedLeft = parentWidth;
                if (panel.Left < closedLeft)
                    panel.Left = Math.Min(closedLeft, panel.Left + paso);
                else
                {
                    timerCerrar.Stop();
                    animando = false;
                    panel.Visible = false;
                    AlTerminarCerrar?.Invoke();
                }
                return;
            }

            // modo original (ancho)
            if (panel.Width > anchoMin)
            {
                if (panel.Width - paso <= anchoMin)
                    panel.Width = anchoMin;
                else
                    panel.Width -= paso;
            }
            else
            {
                timerCerrar.Stop();
                animando = false;
                if (anchoMin == 0)
                    panel.Visible = false;
                AlTerminarCerrar?.Invoke();
            }
        }
    }
}
