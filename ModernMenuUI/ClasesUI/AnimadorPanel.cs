using System;
using System.Windows.Forms;


namespace ModernMenuUI.ClasesUI
{
    internal class AnimadorPanel : IDisposable
    {
        private readonly System.Windows.Forms.Timer timer;

        private readonly Panel panel;
        private readonly int anchoPanel;
        private readonly int paso;

        private bool overlayMode;

        private enum EstadoAnimacion
        {
            Ninguno,
            Abriendo,
            Cerrando
        }

        private EstadoAnimacion estado = EstadoAnimacion.Ninguno;

        // Eventos
        public Action AlTerminarAbrir;
        public Action AlTerminarCerrar;

        public AnimadorPanel(Panel panel, int anchoPanel, int paso, bool overlay = true)
        {
            this.panel = panel;
            this.anchoPanel = anchoPanel;
            this.paso = paso;
            this.overlayMode = overlay;

            // Configuración del panel
            panel.Dock = DockStyle.None;
            panel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panel.Width = anchoPanel;
            panel.Visible = false;

            // Timer único
            timer = new System.Windows.Forms.Timer
            {
                Interval = 15 // ~60 FPS
            };
            timer.Tick += Timer_Tick;

            if (panel.Parent != null)
            {
                panel.Left = panel.Parent.ClientSize.Width;
                panel.Parent.SizeChanged += Parent_SizeChanged;
            }
        }

        private void Parent_SizeChanged(object sender, EventArgs e)
        {
            if (panel.Parent == null) return;

            int pw = panel.Parent.ClientSize.Width;

            if (!panel.Visible || estado == EstadoAnimacion.Cerrando)
                panel.Left = pw;
            else
                panel.Left = Math.Max(0, pw - anchoPanel);
        }

        // ===================== API =====================

        public void Abrir()
        {
            if (estado == EstadoAnimacion.Abriendo) return;

            panel.Visible = true;
            panel.BringToFront();

            if (panel.Parent != null && estado == EstadoAnimacion.Ninguno)
                panel.Left = panel.Parent.ClientSize.Width;

            estado = EstadoAnimacion.Abriendo;
            timer.Start();
        }

        public void Cerrar()
        {
            if (estado == EstadoAnimacion.Cerrando) return;

            estado = EstadoAnimacion.Cerrando;
            timer.Start();
        }

        // ===================== TIMER =====================

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (panel.Parent == null) return;

            int parentWidth = panel.Parent.ClientSize.Width;
            int leftAbierto = Math.Max(0, parentWidth - anchoPanel);
            int leftCerrado = parentWidth;

            if (estado == EstadoAnimacion.Abriendo)
            {
                panel.Left = Math.Max(leftAbierto, panel.Left - paso);

                if (panel.Left == leftAbierto)
                    FinalizarAbrir();
            }
            else if (estado == EstadoAnimacion.Cerrando)
            {
                panel.Left = Math.Min(leftCerrado, panel.Left + paso);

                if (panel.Left == leftCerrado)
                    FinalizarCerrar();
            }
        }

        // ===================== FINALIZADORES =====================

        private void FinalizarAbrir()
        {
            timer.Stop();
            estado = EstadoAnimacion.Ninguno;
            AlTerminarAbrir?.Invoke();
        }

        private void FinalizarCerrar()
        {
            timer.Stop();
            estado = EstadoAnimacion.Ninguno;
            panel.Visible = false;
            AlTerminarCerrar?.Invoke();
        }

        // ===================== CLEANUP =====================

        public void Dispose()
        {
            timer.Stop();
            timer.Dispose();

            if (panel?.Parent != null)
                panel.Parent.SizeChanged -= Parent_SizeChanged;
        }
    }
}
