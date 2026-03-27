using ModernMenuUI.ClasesUI;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ModernMenuUI
{
    public partial class frmRol : Form
    {
        private int contadorRoles = 0;
        private bool _cerrando = false;

        public frmRol()
        {
            InitializeComponent();

            this.FormClosing += frmRol_FormClosing;
            this.FormClosed += frmRol_FormClosed;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            this.Close();
        }

        private void btnNuevoRol_Click(object sender, EventArgs e)
        {
            if (_cerrando) return;

            if (contadorRoles >= 6)
            {
                MessageBox.Show(
                    "Solo puede tener 6 roles dinámicos.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string nombrePanel = $"pnlRolDinamico{contadorRoles + 1}";
            Control panelDestino = pnlContenedorRoles.Controls[nombrePanel];

            if (panelDestino == null)
            {
                MessageBox.Show(
                    $"No se encontró el panel {nombrePanel}.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            for (int i = panelDestino.Controls.Count - 1; i >= 0; i--)
            {
                Control ctrl = panelDestino.Controls[i];
                panelDestino.Controls.RemoveAt(i);
                ctrl.Dispose();
            }

            controlPanelRolesDinamicos nuevoRol = new controlPanelRolesDinamicos
            {
                Dock = DockStyle.Fill,
                Name = $"controlPanelRolesDinamicos{contadorRoles + 1}"
            };

            panelDestino.Controls.Add(nuevoRol);
            contadorRoles++;
        }

        private void frmRol_FormClosing(object sender, FormClosingEventArgs e)
        {
            _cerrando = true;
        }

        private void frmRol_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                foreach (Control panel in pnlContenedorRoles.Controls.OfType<Control>())
                {
                    for (int i = panel.Controls.Count - 1; i >= 0; i--)
                    {
                        Control ctrl = panel.Controls[i];
                        panel.Controls.RemoveAt(i);
                        ctrl.Dispose();
                    }
                }
            }
            catch { }
        }
    }
}