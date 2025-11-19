using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeDatos.Modelados.UsuariosEmpleados;
using CapaDeDatos.Repositorios;

namespace ModernMenuUI.InterfacesUsuarios.Usuarios
{
    public partial class frmAgregarEditarUsuario : Form
    {
        private Usuario _usuarioActual;

        public frmAgregarEditarUsuario()
        {
            InitializeComponent();
        }
        public frmAgregarEditarUsuario(Usuario usuario)
        {
            InitializeComponent();
            _usuarioActual = usuario;
        }
        private async void btnGuardarEmpleado_Click(object sender, EventArgs e)
        {
            UsuarioRepositorio user = new UsuarioRepositorio();

            var cambios = new UsuarioRepositorio.CambiosUsuario
            {
                NuevoRol = cmbRol.SelectedIndex,
                NuevoEstado = rdbActivo.Checked
            };


            await user.OtrosValores(cambios);
        }

        private void frmAgregarEditarUsuario_Load(object sender, EventArgs e)
        {
            UsuarioRepositorio us = new UsuarioRepositorio();
            if (_usuarioActual!=null)
            {
                txtCorreo.Text = _usuarioActual.AliasUsuario;
                cmbRol.Items.Add(us.ObtenerTodosLosUsuariosRoles().Result);
                rdbActivo.Checked = _usuarioActual.EstadoUsuario;
            }
        }
    }
}
