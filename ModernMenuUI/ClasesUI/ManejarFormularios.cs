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
                    throw new Exception("ManejarFormularios no ha sido inicializado. Llama Inicializar(panel) desde MenuPrincipal.");
                return instancia;
            }
        }

        public void AbrirFormulario(Form formularioHijo)
        {
            CerrarFormularioActivo();

            formularioActivo = formularioHijo;

            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;

            panelContenedor.Controls.Add(formularioHijo);
            panelContenedor.Tag = formularioHijo;

            formularioHijo.BringToFront();
            formularioHijo.Show();
        }

        public void AbrirFormularioEncima(Form formularioHijo)
        {
            // Si de verdad quieres solo uno encima del otro visualmente,
            // igual debes cerrar el actual para no acumular memoria.
            CerrarFormularioActivo();

            formularioActivo = formularioHijo;

            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;

            panelContenedor.Controls.Add(formularioHijo);
            panelContenedor.Tag = formularioHijo;

            formularioHijo.BringToFront();
            formularioHijo.Show();
        }

        public void CerrarFormularioActivo()
        {
            if (formularioActivo == null)
                return;

            try
            {
                if (panelContenedor.Controls.Contains(formularioActivo))
                    panelContenedor.Controls.Remove(formularioActivo);

                formularioActivo.Hide();
                formularioActivo.Close();
                formularioActivo.Dispose();
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