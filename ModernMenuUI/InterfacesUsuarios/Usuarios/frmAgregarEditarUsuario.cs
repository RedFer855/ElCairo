using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using CapaDeDatos.Repositorios;
using ModernMenuUI.InterfacesUsuarios.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI.InterfacesUsuarios.Usuarios
{
    public partial class frmAgregarEditarUsuario : Form
    {
        private Usuario _usuarioActual;
        //private Cliente supabase;
        public frmAgregarEditarUsuario()
        {
            InitializeComponent();
            _usuarioActual = null;
        }
        public frmAgregarEditarUsuario(Usuario usuario)
        {
            InitializeComponent();
            _usuarioActual = usuario;
            txtCorreo.Click += TextBox_ReadOnlyClick;

        }

        private void frmAgregarEditarUsuario_Load(object sender, EventArgs e)
        {
            if (_usuarioActual != null)
            {
                txtCorreo.Text = _usuarioActual.AliasUsuario;

            }
        }

        private void btnGuardarEmpleado_Click(object sender, EventArgs e)
        {

        }
        private void TextBox_ReadOnlyClick(object sender, EventArgs e)
        {

            TextBox currentTextBox = sender as TextBox;

            if (currentTextBox != null && currentTextBox.ReadOnly)
            {
                MessageBox.Show(
                    "Presione primero el botón Modificar.",
                    "Campo Deshabilitado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private async void cmbRol_DataContextChanged(object sender, EventArgs e)
        {
           
        }
        
    }
}
