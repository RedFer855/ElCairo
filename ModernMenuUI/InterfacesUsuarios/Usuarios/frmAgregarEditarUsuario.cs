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
    /// <summary>
    /// Formulario que permite editar roles y estado de un usuario del sistema.
    /// Implementa validaciones de permisos según el rol del usuario logueado.
    /// </summary>
    public partial class frmAgregarEditarUsuario : Form
    {
        /// <summary>Usuario que se está editando.</summary>
        private Usuario _usuarioEditado;

        /// <summary>Usuario actualmente logueado en el sistema.</summary>
        private Usuario _usuarioActualSistema;

        /// <summary>Controlador auxiliar para animaciones (si aplica).</summary>
        private AnimadorPanel _animadorPanel;

        // =====================================================================
        // 1. Constructores
        // =====================================================================

        /// <summary>
        /// Constructor vacío para inicializar el formulario sin valores previos.
        /// </summary>
        public frmAgregarEditarUsuario()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor usado al editar un usuario.
        /// </summary>
        /// <param name="editado">Usuario que será modificado.</param>
        /// <param name="actual">Usuario que está logueado y ejecutando la acción.</param>
        public frmAgregarEditarUsuario(Usuario editado, Usuario actual)
        {
            InitializeComponent();
            _usuarioEditado = editado;
            _usuarioActualSistema = actual;
        }

        // =====================================================================
        // 2. Guardar cambios de usuario
        // =====================================================================

        /// <summary>
        /// Evento que guarda los cambios realizados al usuario seleccionado.
        /// Aplica validaciones estrictas de permisos:
        /// - Un admin no puede cambiar su propio rol.
        /// - Un admin no puede modificar ni asignar SuperAdmin.
        /// - Un admin no puede modificar a otros administradores.
        /// - Un admin solo puede asignar roles básicos (2 y 3).
        /// </summary>
        private async void btnGuardarEmpleado_Click(object sender, EventArgs e)
        {
            UsuarioRepositorio userRepo = new UsuarioRepositorio();

            int idActual = _usuarioActualSistema.IdUsuario;
            int rolActual = _usuarioActualSistema.RolUsuario;

            int idEditado = _usuarioEditado.IdUsuario;
            int rolOriginalEditado = _usuarioEditado.RolUsuario;

            // ===========================
            // Validación del Combo Rol
            // ===========================
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

            bool esAdmin = rolActual == 1; // Rol 1 = Administrador

            // =====================================================================
            // VALIDACIONES DE PERMISOS (APLICAN SOLO SI EL ACTUAL ES ADMIN)
            // =====================================================================

            // 1. El admin no puede cambiar su propio rol
            if (esAdmin && idActual == idEditado)
            {
                MessageBox.Show("No puedes cambiar tu propio rol.");
                return;
            }

            // 2. Admin NO puede asignar rol SuperAdmin (rol 4)
            if (esAdmin && nuevoRol == 4)
            {
                MessageBox.Show("No tienes permiso para asignar el rol SuperAdmin.");
                return;
            }

            // 3. Admin NO puede modificar un SuperAdmin existente
            if (esAdmin && rolOriginalEditado == 4)
            {
                MessageBox.Show("No puedes modificar un usuario SuperAdmin.");
                return;
            }

            // 4. Admin NO puede modificar otros administradores
            if (esAdmin && rolOriginalEditado == 1)
            {
                MessageBox.Show("No puedes modificar usuarios administradores.");
                return;
            }

            // 5. Admin SOLO puede asignar vendedores/cajeros (roles 2 y 3)
            if (esAdmin && !(nuevoRol == 2 || nuevoRol == 3))
            {
                MessageBox.Show("Solo puedes asignar roles de vendedor o cajero.");
                return;
            }

            // Nota: Si es SuperAdmin, no se restringe nada.

            // =====================================================================
            // Guardar cambios
            // =====================================================================
            await userRepo.OtrosValores(cambios);

            MessageBox.Show("Cambios guardados correctamente.");
            this.Close();
        }

        // =====================================================================
        // 3. Load del formulario
        // =====================================================================

        /// <summary>
        /// Carga inicial del formulario:
        /// - Obtiene roles disponibles desde la BD.
        /// - Llena el ComboBox de roles.
        /// - Carga los valores del usuario a editar.
        /// </summary>
        private async void frmAgregarEditarUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("ENTRÓ AL LOAD");
                UsuarioRepositorio userRepo = new UsuarioRepositorio();

                // Obtener todos los roles disponibles
                var roles = await userRepo.ObtenerTodosLosUsuariosRoles();
                MessageBox.Show(roles[0].NombreRolRol);

                cmbRol.DataSource = null;
                cmbRol.DisplayMember = "NombreRolRol";
                cmbRol.ValueMember = "IdRol";
                cmbRol.DataSource = roles;

                // Si estamos editando, cargar valores originales
                if (_usuarioEditado != null)
                {
                    txtCorreo.Text = _usuarioEditado.AliasUsuario;
                    rdbActivo.Checked = _usuarioEditado.EstadoUsuario;

                    // Seleccionar el rol del usuario editado
                    cmbRol.SelectedValue = _usuarioEditado.RolUsuario;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos del usuario: {ex.Message}");
            }

        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
