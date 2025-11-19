using CapaDeDatos.Modelados;
using CapaDeDatos.Modelados.UsuariosEmpleados;
using CapaDeDatos.Repositorios;
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
    public partial class frmCrearUsuario : Form
    {
        private Empleado _usuarioActual;
        private Usuario _usuario;
        public frmCrearUsuario()
        {
            InitializeComponent();
        }
        public frmCrearUsuario(Empleado usuario, Usuario actual_user)
        {
            InitializeComponent();
            _usuarioActual = usuario;
            _usuario = actual_user;
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnGuardarEmpleado_Click(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "" || txtContrasenia.Text == "")
            {
                MessageBox.Show("Correo o Contraseña vacios, ingrese un valor valido");
            }
            else
            {
                string correo = txtCorreo.Text.Trim();
                string contra = txtContrasenia.Text.Trim();

                UsuarioRepositorio user = new UsuarioRepositorio();
                
                await user.RegistrarUsuario(correo, contra);
                MessageBox.Show("Confirme su correo en su bandeja del email de su empleado.");

                this.Close();
               
            }
        }

        private async void CrearUsuario_Load(object sender, EventArgs e)
        {
            UsuarioRepositorio us = new UsuarioRepositorio();


            var roles = await us.ObtenerTodosLosUsuariosRoles();

            var rolesPermitidos = await us.ObtenerRolesSegunUsuario(_usuario.RolUsuario);

            cmbRol.DataSource = rolesPermitidos;
            cmbRol.DisplayMember = "Nombre";
            cmbRol.ValueMember = "IdRol";


            if (_usuarioActual != null)
            {
                txtCorreo.Text = _usuarioActual.Email;
                //rdbActivo.Checked = _usuarioActual.EstadoUsuario;
                //cmbRol.SelectedValue = _usuarioActual.RolUsuario;
            }
        }
    }
}
