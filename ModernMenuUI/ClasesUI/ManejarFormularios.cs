using System;
using System.Windows.Forms;

namespace ModernMenuUI.ClasesUI
{
    public class ManejarFormularios
    {
        private static ManejarFormularios instancia;
        private Form formularioActivo;
        private readonly Panel panelContenedor;

        private ManejarFormularios(Panel panel)
        {
            panelContenedor = panel;
        }

        public static void Inicializar(Panel panel)
        {
            if (instancia == null)
                instancia = new ManejarFormularios(panel);
        }

        public static ManejarFormularios Instancia
        {
            get
            {
                if (instancia == null)
                    throw new Exception("clsManejarFormularios no ha sido inicializado. Llama Inicializar(panel) desde MenuPrincipal.");
                return instancia;
            }
        }

        public void AbrirFormulario(Form formularioHijo)
        {
            if (formularioHijo == null || formularioHijo.IsDisposed)
                return;

            CerrarFormularioActual();

            formularioActivo = formularioHijo;
            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;

            panelContenedor.SuspendLayout();
            try
            {
                panelContenedor.Controls.Add(formularioHijo);
                panelContenedor.Tag = formularioHijo;

                formularioHijo.BringToFront();
                formularioHijo.Show();
            }
            finally
            {
                panelContenedor.ResumeLayout();
            }
        }

        public void AbrirFormularioEncima(Form formularioHijo)
        {
            if (formularioHijo == null || formularioHijo.IsDisposed)
                return;

            CerrarFormularioActual();

            formularioActivo = formularioHijo;
            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;

            panelContenedor.SuspendLayout();
            try
            {
                panelContenedor.Controls.Add(formularioHijo);
                panelContenedor.Tag = formularioHijo;

                formularioHijo.BringToFront();
                formularioHijo.Show();
            }
            finally
            {
                panelContenedor.ResumeLayout();
            }
        }

        public void CerrarFormularioActual()
        {
            if (formularioActivo == null)
                return;

            try
            {
                if (panelContenedor.Controls.Contains(formularioActivo))
                    panelContenedor.Controls.Remove(formularioActivo);

                if (!formularioActivo.IsDisposed)
                {
                    formularioActivo.Close();
                    formularioActivo.Dispose();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al cerrar formulario activo: {ex.Message}");
            }
            finally
            {
                formularioActivo = null;
                panelContenedor.Tag = null;
            }
        }
    }
}