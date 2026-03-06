using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernMenuUI.ClasesUI
{
    public class ManejarFormularios
    {
        private static ManejarFormularios instancia;
        private Form formularioActivo;
        private Panel panelContenedor;

        // Constructor privado para evitar instanciación externa
        private ManejarFormularios(Panel panel)
        {
            panelContenedor = panel;
        }

        // Método para inicializar la instancia con el panel del MenuPrincipal
        public static void Inicializar(Panel panel)
        {
            if (instancia == null)
                instancia = new ManejarFormularios(panel);
        }

        // Propiedad para acceder a la instancia desde cualquier parte
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
            if (formularioActivo != null)
            {
                formularioActivo.Close();
                panelContenedor.Controls.Clear();
            }

            formularioActivo = formularioHijo;
            formularioHijo.TopLevel = false;
            formularioHijo.Dock = DockStyle.Fill;
            panelContenedor.Controls.Clear();
            panelContenedor.Controls.Add(formularioHijo);
            panelContenedor.Tag = formularioHijo;
            formularioHijo.BringToFront();
            formularioHijo.Show();
        }

        public void AbrirFormularioEncima(Form formularioHijo)
        {
            formularioActivo = formularioHijo;
            formularioHijo.TopLevel = false;
            formularioHijo.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(formularioHijo);
            panelContenedor.Tag = formularioHijo;
            formularioHijo.BringToFront();
            formularioHijo.Show();
        }

    }
}
