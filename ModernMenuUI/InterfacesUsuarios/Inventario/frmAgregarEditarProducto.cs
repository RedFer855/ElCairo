using CapaDeDatos.Modelados.Productos;
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

namespace ModernMenuUI
{
    public partial class frmAgregarEditarProducto : Form
    {
        private Producto ProductoActual;
        public frmAgregarEditarProducto()
        {
            InitializeComponent();
            lblNombreModulo.Text = "AGREGAR PRODUCTO";
        }

        public frmAgregarEditarProducto(Producto productoseleccionado)
        {
            InitializeComponent();
            ProductoActual = productoseleccionado;
            txtProducto.Text = productoseleccionado.NombreProducto;
            txtMarca.Text = productoseleccionado.NombreMarca;
            txtCategoria.Text = productoseleccionado.NombreCategoria;
        }

        private void Editar_Producto_MouseDown(object sender, MouseEventArgs e)
        {
            clsAnmaciones.MoverFormulario(this.Handle);
        }

        private void panBarraControl_MouseDown(object sender, MouseEventArgs e)
        {
            clsAnmaciones.MoverFormulario(this.Handle);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
