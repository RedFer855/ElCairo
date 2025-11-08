using CapaDeDatos.Modelados;
using ModernMenuUI.ClasesUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI.InterfacesUsuarios.Compras
{
    public partial class frmAgregarEditarProveedor : Form
    {
        Proveedor ProveedorActual;
        public frmAgregarEditarProveedor()
        {
            InitializeComponent();
        }

        public frmAgregarEditarProveedor(Proveedor proveedor)
        {
            ProveedorActual = proveedor;

            InitializeComponent();
        }

        private void btnGuardarProveedor_Click(object sender, EventArgs e)
        {

        }

        private void frmAgregarEditarProveedor_Load(object sender, EventArgs e)
        {
            if (ProveedorActual != null)
            {
                clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "EDITAR EMPLEADO");

                txtDireccion.Text = ProveedorActual.DireccionProveedor;
                txtNombreProveedor.Text = ProveedorActual.NombreProveedor;
                txtTelefono.Text = ProveedorActual.TelefonoProveedor;


                if (ProveedorActual.EstadoProveedor == true)
                {
                    rbActivo.Checked = true;
                }

                if (rbInactivo.Checked == false)
                {
                    rbInactivo.Checked = true;
                }

                btnGuardarProveedor.Visible = false;
                btnModificarProveedor.Visible = true;
                btnModificarProveedor.Enabled = true;

            }
            else
            {
                clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "GUARDAR PROVEEDOR");
                btnModificarProveedor.Visible = false;
                btnModificarProveedor.Enabled = false;
                btnGuardarProveedor.Visible = true;
                btnGuardarProveedor.Enabled = true;
            }
        }
    }
}
