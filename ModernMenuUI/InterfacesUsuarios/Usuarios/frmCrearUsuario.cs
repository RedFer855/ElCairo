using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using CapaDeDatos.Modelados.UsuariosEmpleados;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
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
        public frmCrearUsuario(Empleado usuario, Usuario actualuser)
        {
            InitializeComponent();
            _usuarioActual = usuario;
            _usuario = actualuser;

        }

        private async void frmCrearUsuario_Load(object sender, EventArgs e)
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

        private async void btnGuardarEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                btnGuardarEmpleado.Enabled = false;

                string correo = txtCorreo.Text.Trim();
                string contra = txtContrasenia.Text.Trim();
                int rolSeleccionado = (int)cmbRol.SelectedValue;
                int idEmpleado = _usuarioActual.Id;

                var v1 = ServicioValidacionesIngresoDatos.ValidarContrasenia(contra, "La contraseña");
                if (v1.Error)
                {
                    MessageBox.Show(v1.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnGuardarEmpleado.Enabled = true;
                    return;
                }

                UsuarioRepositorio repo = new UsuarioRepositorio();
                var client = await Conexion.GetClientAsync();

                
                var respuesta = await repo.RegistrarUsuario(correo, contra);

                if (respuesta?.User == null)
                {
                    MessageBox.Show("No se pudo registrar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string uuidNuevoUsuario = respuesta.User.Id;

                
                var result = await client.Rpc("crear_usuario_empleado", new
                {
                    p_id_empleado = idEmpleado,
                    p_email = correo,
                    p_rol = rolSeleccionado
                });

                MessageBox.Show(
                    "Usuario creado correctamente.",
                    "Usuario Creado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el usuario: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!this.IsDisposed)
                    btnGuardarEmpleado.Enabled = true;
            }
        }
    }
}
