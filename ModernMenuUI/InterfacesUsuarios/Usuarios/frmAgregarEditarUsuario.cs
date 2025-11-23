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
using ModernMenuUI.ClasesUI;

namespace ModernMenuUI.InterfacesUsuarios.Usuarios
{
    public partial class frmAgregarEditarUsuario : Form
    {
        private Usuario _usuarioEditado;          // Usuario que se está editando
        private Usuario _usuarioActualSistema;    // Usuario logueado
        private AnimadorPanel _animadorPanel;

        public frmAgregarEditarUsuario()
        {
            InitializeComponent();
        }
        public frmAgregarEditarUsuario(Usuario editado, Usuario actual)
        {
            InitializeComponent();
            _usuarioEditado = editado;
            _usuarioActualSistema = actual;
        }

        private async void btnGuardarEmpleado_Click(object sender, EventArgs e)
        {
            UsuarioRepositorio userRepo = new UsuarioRepositorio();

            int idActual = _usuarioActualSistema.IdUsuario;
            int rolActual = _usuarioActualSistema.RolUsuario;

            int idEditado = _usuarioEditado.IdUsuario;
            int rolOriginalEditado = _usuarioEditado.RolUsuario;

            // ----------------------------
            // VALIDACIÓN: SelectedValue seguro
            // ----------------------------
            if (cmbRol.SelectedValue == null)
            {
                MessageBox.Show("Debes seleccionar un rol válido antes de guardar.");
                return;
            }

            int nuevoRol = Convert.ToInt32(cmbRol.SelectedValue);
            bool nuevoEstado = rdbActivo.Checked;

            var cambios = new UsuarioRepositorio.CambiosUsuario
            {
                IdEmpleado = idEditado,
                NuevoRol = nuevoRol,
                NuevoEstado = nuevoEstado
            };

            bool esAdmin = rolActual == 1;

            // -----------------------------------------------------
            //               VALIDACIONES DE PERMISOS
            // -----------------------------------------------------

            // 1. Admin NO puede cambiar su propio rol
            if (esAdmin && idActual == idEditado)
            {
                MessageBox.Show("No puedes cambiar tu propio rol.");
                return;
            }

            // 2. Admin NO puede asignar rol SuperAdmin (4)
            if (esAdmin && nuevoRol == 4)
            {
                MessageBox.Show("No tienes permiso para asignar el rol SuperAdmin.");
                return;
            }

            // 3. Admin NO puede modificar a un SuperAdmin
            if (esAdmin && rolOriginalEditado == 4)
            {
                MessageBox.Show("No puedes modificar un usuario SuperAdmin.");
                return;
            }

            // 4. Admin NO puede modificar a otro admin
            if (esAdmin && rolOriginalEditado == 1)
            {
                MessageBox.Show("No puedes modificar usuarios administradores.");
                return;
            }

            // 5. Admin SOLO puede asignar roles 2 y 3
            if (esAdmin && !(nuevoRol == 2 || nuevoRol == 3))
            {
                MessageBox.Show("Solo puedes asignar roles de vendedor o cajero.");
                return;
            }

            // Si SuperAdmin, no hay restricciones

            await userRepo.OtrosValores(cambios);

            MessageBox.Show("Cambios guardados correctamente.");
        }

        private async void frmAgregarEditarUsuario_Load(object sender, EventArgs e)
        {
            UsuarioRepositorio userRepo = new UsuarioRepositorio();

            // Obtener todos los roles sin filtrar
            var roles = await userRepo.ObtenerTodosLosUsuariosRoles();

            // Cargar roles completos al combo (para evitar SelectedValue null)
            cmbRol.DataSource = roles;
            cmbRol.DisplayMember = "NombreRol";
            cmbRol.ValueMember = "IdRol";

            // Cargar datos del usuario que estamos editando
            if (_usuarioEditado != null)
            {
                txtCorreo.Text = _usuarioEditado.AliasUsuario;
                rdbActivo.Checked = _usuarioEditado.EstadoUsuario;

                // Seleccionar el rol actual del usuario editado
                cmbRol.SelectedValue = _usuarioEditado.RolUsuario;
            }

        }
    }
}
