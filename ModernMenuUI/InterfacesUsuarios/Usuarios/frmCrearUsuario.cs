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
    /// <summary>
    /// Formulario encargado de crear un nuevo usuario del sistema,
    /// asignándole credenciales y un rol vinculado a un empleado ya existente.
    /// 
    /// Este formulario:
    /// - Carga roles permitidos según el usuario que ejecuta la acción.
    /// - Valida contraseña con lógica del dominio.
    /// - Crea usuario en Supabase Auth.
    /// - Registra el usuario en tu tabla interna mediante RPC.
    /// - Mantiene sesión del usuario logueado mientras crea otro.
    /// </summary>
    public partial class frmCrearUsuario : Form
    {
        /// <summary>
        /// Empleado al cual se le va a crear una cuenta de usuario.
        /// </summary>
        private Empleado _usuarioActual;

        /// <summary>
        /// Usuario actual que está creando/modificando (usuario del sistema activo).
        /// </summary>
        private Usuario _usuario;

        // =====================================================================
        // CONSTRUCTORES
        // =====================================================================

        /// <summary>
        /// Constructor básico para crear un usuario sin datos previos.
        /// </summary>
        public frmCrearUsuario()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor usado cuando se conoce el empleado al que se le creará usuario
        /// y el usuario actual del sistema que ejecuta este formulario.
        /// </summary>
        public frmCrearUsuario(Empleado usuario, Usuario actualuser)
        {
            InitializeComponent();
            _usuarioActual = usuario;
            _usuario = actualuser;
        }

        // =====================================================================
        // LOAD DEL FORMULARIO
        // =====================================================================

        /// <summary>
        /// Carga inicial:
        /// - Obtiene roles permitidos según el usuario actual.
        /// - Rellena combo de roles.
        /// - Precarga correo del empleado si existe.
        /// </summary>
        private async void frmCrearUsuario_Load(object sender, EventArgs e)
        {
            UsuarioRepositorio us = new UsuarioRepositorio();

            // Todos los roles existentes
            var roles = await us.ObtenerTodosLosUsuariosRoles();

            // Roles filtrados según permisos del usuario actual
            var rolesPermitidos = await us.ObtenerRolesSegunUsuario(_usuario.RolUsuario);

            // Cargar roles permitidos al combo
            cmbRol.DataSource = rolesPermitidos;
            cmbRol.DisplayMember = "NombreRolRol";   // Nombre visible en lista
            cmbRol.ValueMember = "IdRol";             // Valor real (llave)

            // Precargar correo desde el empleado
            if (_usuarioActual != null)
            {
                txtCorreo.Text = _usuarioActual.EmailEmpleado;
            }
        }

        // =====================================================================
        // BOTÓN GUARDAR / CREAR USUARIO
        // =====================================================================

        /// <summary>
        /// Ejecuta la creación del usuario:
        /// - Valida contraseña.
        /// - Inserta usuario en Supabase Auth.
        /// - Restaura sesión original para no desconectar al usuario actual.
        /// - Llama RPC para registrar el usuario en la tabla interna.
        /// </summary>
        private async void btnGuardarEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                btnGuardarEmpleado.Enabled = false;

                string correo = txtCorreo.Text.Trim();
                string contra = txtContrasenia.Text.Trim();
                int rolSeleccionado = (int)cmbRol.SelectedValue;
                int idEmpleado = _usuarioActual.Id;

                // ---------------------------------------------------------
                // VALIDACIÓN: Contraseña
                // ---------------------------------------------------------
                var v1 = ServicioValidacionesIngresoDatos.ValidarContrasenia(contra, "La contraseña");
                if (v1.Error)
                {
                    MessageBox.Show(v1.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnGuardarEmpleado.Enabled = true;
                    return;
                }

                UsuarioRepositorio repo = new UsuarioRepositorio();

                // ---------------------------------------------------------
                // 1. Crear usuario en Supabase Auth
                // ---------------------------------------------------------
                var client = await Conexion.GetClientAsync();

                // Guardamos la sesión actual para evitar cierre de sesión
                var sessionOriginal = client.Auth.CurrentSession;

                // Crear usuario en auth
                await repo.RegistrarUsuario(correo, contra);
                //hacer una validacion para hacer una consulta a la tabla de usuarios y verificar 
                //que el correo que se esta ingresando no exista en la tabla, por que si este existe 
                //va a pasar un error que nos va a cerrar la sesion del usuario que esta creando el nuevo usuario

                // Restaurar sesión original (muy importante)
                await client.Auth.SetSession(
                    sessionOriginal.AccessToken,
                    sessionOriginal.RefreshToken
                );

                // ---------------------------------------------------------
                // Validación extra: debe existir empleado asociado
                // ---------------------------------------------------------
                if (_usuarioActual == null)
                {
                    MessageBox.Show("No se pudo registrar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ---------------------------------------------------------
                // 2. Registrar el usuario en la tabla interna mediante RPC
                // ---------------------------------------------------------
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
                // Reestablecer sesión original si hubo error inesperado
                var client = await Conexion.GetClientAsync();
                var sessionOriginal = client.Auth.CurrentSession;

                await client.Auth.SetSession(
                    sessionOriginal.AccessToken,
                    sessionOriginal.RefreshToken
                );

                // ---------------------------------------------------------
                // ERRORES COMUNES
                // ---------------------------------------------------------
                if (ex.Message.Contains("\"code\":422") || ex.Message.Contains("\"error_code\":\"user_already_exists\""))
                {
                    MessageBox.Show(
                        "El usuario ya existe en la base de datos.\nPor favor seleccione uno diferente",
                        "Usuario duplicado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation
                    );
                }
                else
                {
                    MessageBox.Show(
                        "Ocurrió un error: " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            finally
            {
                if (!this.IsDisposed)
                    btnGuardarEmpleado.Enabled = true;
            }
        }
    }
}
