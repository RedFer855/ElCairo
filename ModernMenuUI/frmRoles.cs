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
    public partial class frmRoles : Form
    {
        private int contadorRoles = 0; // contador global
        private clsManejarFormularios manejador;
        public frmRoles()
        {
            InitializeComponent();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            this.Close();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnNuevoRol_Click(object sender, EventArgs e)
        {
            if (contadorRoles >= 6)
            {
                MessageBox.Show
                (
                    "Solo puede tener 6 roles dinámicos.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            // Obtener el panel destino por nombre dinámico
            string nombrePanel = $"pnlRolDinamico{contadorRoles + 1}";
            Control panelDestino = pnlContenedorRoles.Controls[nombrePanel];

            if (panelDestino != null)
            {
                // Limpiar contenido anterior si lo hubiera
                panelDestino.Controls.Clear();

                // Crear y agregar el control personalizado
                controlPanelRolesDinamicos nuevoRol = new controlPanelRolesDinamicos();
                nuevoRol.Dock = DockStyle.Fill; // ocupa todo el panel
                nuevoRol.Name = $"controlPanelRolesDinamicos{contadorRoles + 1}";

                panelDestino.Controls.Add(nuevoRol);
                contadorRoles++;
            }
            else
            {
                MessageBox.Show($"No se encontró el panel {nombrePanel}.");
            }
        }
    }
}
