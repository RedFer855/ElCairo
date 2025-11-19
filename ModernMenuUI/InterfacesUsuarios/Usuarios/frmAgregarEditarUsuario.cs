using System;
using System.Linq;
using System.Windows.Forms;
using CapaDeDatos.Modelados.UsuariosEmpleados;
using CapaDeDatos.Repositorios;

namespace ModernMenuUI.InterfacesUsuarios.Usuarios
{
    public partial class frmAgregarEditarUsuario : Form
    {
        private Usuario usuarioEditado;          // Usuario que se está editando
        private Usuario usuarioActualSistema;    // Usuario logueado

        public frmAgregarEditarUsuario()
        {
            InitializeComponent();
        }

        // Constructor correcto: se recibe usuario editado y usuario actual del sistema
        public frmAgregarEditarUsuario(Usuario editado, Usuario actual)
        {
            InitializeComponent();
            usuarioEditado = editado;               // Usuario que será editado
            usuarioActualSistema = actual;          // Usuario logueado
        }

        private async void frmAgregarEditarUsuario_Load(object sender, EventArgs e)
        {
            UsuarioRepositorio userRepo = new UsuarioRepositorio();

            // Obtener todos los roles
            var roles = await userRepo.ObtenerTodosLosUsuariosRoles();
            int rolActualSistema = usuarioActualSistema.RolUsuario;

            // Si el usuario logueado es Admin (1), solo mostrar vendedor y cajero
            if (rolActualSistema == 1)
            {
                roles = roles.Where(r => r.IdRol == 2 || r.IdRol == 3).ToList();
            }

            // Cargar roles en el combo
            cmbRol.DataSource = roles;
            cmbRol.DisplayMember = "NombreRol";
            cmbRol.ValueMember = "IdRol";

            // Cargar datos del usuario que estamos editando
            if (usuarioEditado != null)
            {
                txtCorreo.Text = usuarioEditado.AliasUsuario;
                rdbActivo.Checked = usuarioEditado.EstadoUsuario;
                cmbRol.SelectedValue = usuarioEditado.RolUsuario;
            }
        }

        private async void btnGuardarEmpleado_Click(object sender, EventArgs e)
        {
            UsuarioRepositorio userRepo = new UsuarioRepositorio();

            // Usuario logueado
            int idActual = usuarioActualSistema.IdUsuario;
            int rolActual = usuarioActualSistema.RolUsuario;

            // Usuario editado
            int idEditado = usuarioEditado.IdUsuario;
            int rolOriginalEditado = usuarioEditado.RolUsuario;

            // Nuevos valores
            int nuevoRol = (int)cmbRol.SelectedValue;
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

            // 1. Un admin NO puede cambiar su propio rol
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
    }
}
