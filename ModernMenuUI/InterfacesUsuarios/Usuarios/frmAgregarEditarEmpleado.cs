using CapaDeDatos.Modelados;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.InterfacesUsuarios.Usuarios;
using Supabase.Postgrest.Exceptions;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ModernMenuUI
{
    /// <summary>
    /// Formulario para agregar o editar empleados en el sistema.
    /// Permite:
    /// - Registrar nuevos empleados.
    /// - Mostrar datos existentes en modo lectura.
    /// - Habilitar edición bajo solicitud.
    /// - Validar datos.
    /// - Insertar o actualizar en la base de datos.
    /// </summary>
    public partial class frmAgregarEditarEmpleado : Form
    {
        /// <summary>
        /// Contiene el empleado a editar. Si es null, el formulario trabaja en modo "Agregar".
        /// </summary>
        private Empleado _empleadoActual;

        // ======================================================================
        // 1. Constructores
        // ======================================================================

        /// <summary>
        /// Constructor para agregar un nuevo empleado.
        /// </summary>
        public frmAgregarEditarEmpleado()
        {
            InitializeComponent();
            _empleadoActual = null;
            txtCorreo.ReadOnly = false;
        }

        /// <summary>
        /// Constructor para editar un empleado existente.
        /// Se cargan valores y se configura el formulario en modo "Lectura".
        /// </summary>
        public frmAgregarEditarEmpleado(Empleado empleado)
        {
            InitializeComponent();
            _empleadoActual = empleado;

            // Campos bloqueados en modo lectura hasta presionar "Modificar"

            txtApellido.Click += TextBox_ReadOnlyClick;
            txtTelefono.Click += TextBox_ReadOnlyClick;
            txtDireccion.Click += TextBox_ReadOnlyClick;
            txtNombre.Click += TextBox_ReadOnlyClick;
            txtDni.Click += TextBox_ReadOnlyClick;
            btnVolver.Focus();
        }

        // ======================================================================
        // 2. Botón Guardar (Agregar / Editar)
        // ======================================================================

        /// <summary>
        /// Guarda el empleado.
        /// Si _empleadoActual es null → Inserta.
        /// Si existe → Actualiza.
        /// Incluye validaciones y manejo de errores (Postgrest duplicados).
        /// </summary>
        private async void btnGuardarEmpleado_Click(object sender, EventArgs e)
        {
            btnGuardarEmpleado.Enabled = false;

            try
            {
                // Validar selección de estado
                if (!rbActivo.Checked && !rbInactivo.Checked)
                {
                    MessageBox.Show("Debe seleccionar un estado (Activo/Inactivo).",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnGuardarEmpleado.Enabled = true;
                    return;
                }

                // Crear objeto empleado nuevo (para insertar o modificar)
                Empleado nuevoEmpleado = new Empleado
                {
                    NombreEmpleado = txtNombre.Text.Trim(),
                    ApellidoEmpleado = txtApellido.Text.Trim(),
                    DniEmpleado = txtDni.Text.Trim(),
                    TelefonoEmpleado = txtTelefono.Text.Trim(),
                    EmailEmpleado = txtCorreo.Text.Trim(),
                    DireccionEmpleado = txtDireccion.Text.Trim(),
                    EstadoEmpleado = rbActivo.Checked
                };

                // Validación general
                var resultadoValidacion =
                    ServicioValidacionesIngresoDatos.EjecutarValidacionesEmpleado(nuevoEmpleado);

                if (resultadoValidacion.Error)
                {
                    MessageBox.Show(resultadoValidacion.Mensaje, "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnGuardarEmpleado.Enabled = true;
                    return;
                }

                // ============================================================
                // PARA AGREGAR
                // ============================================================
                if (_empleadoActual == null)
                {
                    await EmpleadoRepositorio.InsertarEmpleado(nuevoEmpleado);

                    MessageBox.Show("¡Empleado guardado exitosamente!", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                // ============================================================
                // PARA EDITAR
                // ============================================================
                else
                {
                    _empleadoActual.NombreEmpleado = txtNombre.Text.Trim();
                    _empleadoActual.ApellidoEmpleado = txtApellido.Text.Trim();
                    _empleadoActual.DniEmpleado = txtDni.Text.Trim();
                    _empleadoActual.TelefonoEmpleado = txtTelefono.Text.Trim();
                    _empleadoActual.EmailEmpleado = txtCorreo.Text.Trim();
                    _empleadoActual.DireccionEmpleado = txtDireccion.Text.Trim();
                    _empleadoActual.EstadoEmpleado = rbActivo.Checked;

                    await EmpleadoRepositorio.ActualizarEmpleado(_empleadoActual);

                    MessageBox.Show("¡Empleado actualizado exitosamente!", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (PostgrestException pex)
            {
                // Error de clave duplicada en Supabase
                if (pex.Message == "23505" || pex.Message == "duplicate key")
                {
                    MessageBox.Show("El correo ingresado ya está registrado.",
                        "Usuario duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Error al guardar el empleado:\n" + pex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                if (!this.IsDisposed)
                    btnGuardarEmpleado.Enabled = true;
            }
        }

        // ======================================================================
        // 3. Configuración inicial al cargar el formulario
        // ======================================================================

        /// <summary>
        /// Carga datos en pantalla. Modo edición habilita campos de lectura.
        /// </summary>
        private void frmAgregarEmpleado_Load(object sender, EventArgs e)
        {
            if (_empleadoActual != null)
            {
                clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "EDITAR EMPLEADO");

                // Cargar datos en los campos
                txtDni.Text = _empleadoActual.DniEmpleado;
                txtNombre.Text = _empleadoActual.NombreEmpleado;
                txtApellido.Text = _empleadoActual.ApellidoEmpleado;
                txtTelefono.Text = _empleadoActual.TelefonoEmpleado;
                txtDireccion.Text = _empleadoActual.DireccionEmpleado;
                txtCorreo.Text = _empleadoActual.EmailEmpleado;

                // Cargar estado
                rbActivo.Checked = _empleadoActual.EstadoEmpleado;
                rbInactivo.Checked = !_empleadoActual.EstadoEmpleado;

                // Bloquear campos
                txtDni.ReadOnly =
                txtNombre.ReadOnly =
                txtApellido.ReadOnly =
                txtTelefono.ReadOnly =
                txtDireccion.ReadOnly =
                txtCorreo.ReadOnly = true;

                gbxEstado.Enabled = false;

                // Mostrar botón Modificar
                btnGuardarEmpleado.Visible = false;
                btnModificarEmpleado.Visible = true;
                btnModificarEmpleado.Enabled = true;
            }
            else
            {
                clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "AGREGUE UN EMPLEADO NUEVO");

                btnGuardarEmpleado.Visible = true;
                btnModificarEmpleado.Visible = false;

                rbActivo.Checked = true; // Por defecto
            }
        }

        // ======================================================================
        // 4. Botones y Eventos Auxiliares
        // ======================================================================

        private void btnVover_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Muestra mensaje cuando un usuario intenta modificar un campo bloqueado.
        /// </summary>
        private void TextBox_ReadOnlyClick(object sender, EventArgs e)
        {
            if (sender is TextBox tb && tb.ReadOnly)
            {
                MessageBox.Show("Presione primero el botón Modificar.",
                    "Campo Deshabilitado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Habilita todos los campos para poder editar los datos del empleado.
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            txtApellido.ReadOnly = false;
            txtTelefono.ReadOnly = false;
            txtDireccion.ReadOnly = false;
            txtNombre.ReadOnly = false;
            txtDni.ReadOnly = false;
            txtCorreo.ReadOnly = false;

            gbxEstado.Enabled = true;

            btnVolver.Focus();
            btnModificarEmpleado.Enabled = false;
            btnModificarEmpleado.Visible = false;
            btnGuardarEmpleado.Visible = true;
        }
    }
}
