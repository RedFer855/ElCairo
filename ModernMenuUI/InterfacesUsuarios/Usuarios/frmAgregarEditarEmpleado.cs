using CapaDeDatos.Modelados;
using CapaDeDatos.Repositorios;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.InterfacesUsuarios.Usuarios;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CapaServiciosSeguridadValidacion;

namespace ModernMenuUI
{
    public partial class frmAgregarEditarEmpleado : Form
    {
        private Empleado _empleadoActual;

        public frmAgregarEditarEmpleado()
        {
            InitializeComponent();
            _empleadoActual = null;
        }

        public frmAgregarEditarEmpleado(Empleado empleado)
        {
            InitializeComponent();
            _empleadoActual = empleado;

            txtApellido.Click += TextBox_ReadOnlyClick;
            txtTelefono.Click += TextBox_ReadOnlyClick;
            txtDireccion.Click += TextBox_ReadOnlyClick;
            txtNombre.Click += TextBox_ReadOnlyClick;
            txtDni.Click += TextBox_ReadOnlyClick;
            btnVolver.Focus();
        }

        private async void btnGuardarEmpleado_Click(object sender, EventArgs e)
        {
            btnGuardarEmpleado.Enabled = false;

            try
            {
                var v1 = ServicioValidacionesIngresoDatos.ValidarCampoVacio(txtNombre.Text, "el nombre");
                if (v1.Error) { MessageBox.Show(v1.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); btnGuardarEmpleado.Enabled = true; return; }

                var v2 = ServicioValidacionesIngresoDatos.ValidarCampoVacio(txtApellido.Text, "el apellido");
                if (v2.Error) { MessageBox.Show(v2.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); btnGuardarEmpleado.Enabled = true; return; }

                var v3 = ServicioValidacionesIngresoDatos.ValidarCampoVacio(txtDni.Text, "el DNI");
                if (v3.Error) { MessageBox.Show(v3.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); btnGuardarEmpleado.Enabled = true; return; }

                // Validar solo números → DNI
                var v4 = ServicioValidacionesIngresoDatos.ValidarEnteroValido(txtDni.Text, "DNI");
                if (v4.Error) { MessageBox.Show(v4.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); btnGuardarEmpleado.Enabled = true; return; }

                // Validar solo números → Teléfono (si no viene vacío)
                if (!string.IsNullOrWhiteSpace(txtTelefono.Text))
                {
                    var v5 = ServicioValidacionesIngresoDatos.ValidarEnteroValido(txtTelefono.Text, "Teléfono");
                    if (v5.Error) { MessageBox.Show(v5.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); btnGuardarEmpleado.Enabled = true; return; }
                }

                if (_empleadoActual == null)
                {
                    // --- AGREGAR ---
                    Empleado nuevoEmpleado = new Empleado
                    {
                        Nombre = txtNombre.Text.Trim(),
                        Apellido = txtApellido.Text.Trim(),
                        Dni = txtDni.Text.Trim(),
                        Telefono = txtTelefono.Text.Trim(),
                        Email = txtCorreo.Text.Trim(),
                        Direccion = txtDireccion.Text.Trim()
                    };

                    await EmpleadoRepositorio.InsertarEmpleado(nuevoEmpleado);

                    MessageBox.Show("¡Empleado guardado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    // --- EDITAR ---
                    _empleadoActual.Nombre = txtNombre.Text.Trim();
                    _empleadoActual.Apellido = txtApellido.Text.Trim();
                    _empleadoActual.Dni = txtDni.Text.Trim();
                    _empleadoActual.Telefono = txtTelefono.Text.Trim();
                    _empleadoActual.Email = txtCorreo.Text.Trim();
                    _empleadoActual.Direccion = txtDireccion.Text.Trim();

                    await EmpleadoRepositorio.ActualizarEmpleado(_empleadoActual);

                    MessageBox.Show("¡Empleado actualizado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el empleado: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!this.IsDisposed)
                    btnGuardarEmpleado.Enabled = true;
            }
        }

        private void frmAgregarEmpleado_Load(object sender, EventArgs e)
        {
            if (_empleadoActual != null)
            {
                clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "EDITAR EMPLEADO");

                txtDni.Text = _empleadoActual.Dni;
                txtNombre.Text = _empleadoActual.Nombre;
                txtApellido.Text = _empleadoActual.Apellido;
                txtTelefono.Text = _empleadoActual.Telefono;
                txtDireccion.Text = _empleadoActual.Direccion;
                txtCorreo.Text = _empleadoActual.Email;

                txtDni.ReadOnly = true;
                txtNombre.ReadOnly = true;
                txtApellido.ReadOnly = true;
                txtTelefono.ReadOnly = true;
                txtDireccion.ReadOnly = true;
                txtCorreo.ReadOnly = true;

                btnGuardarEmpleado.Visible = false;
                btnModificar.Visible = true;
                btnModificar.Enabled = true;
            }
            else
            {
                clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "AGREGUE UN EMPLEADO NUEVO");

                txtCorreo.Enabled = true;
                btnGuardarEmpleado.Visible = true;
                btnModificar.Visible = false;
            }
        }

        private void btnVover_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            frmAgregarEditarUsuario Usu = new frmAgregarEditarUsuario();
            Usu.ShowDialog();
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            txtApellido.ReadOnly = false;
            txtTelefono.ReadOnly = false;
            txtDireccion.ReadOnly = false;
            txtNombre.ReadOnly = false;
            txtDni.ReadOnly = false;
            txtCorreo.ReadOnly = false;

            btnVolver.Focus();

            btnModificar.Enabled = false;
            btnModificar.Visible = false;
            btnGuardarEmpleado.Visible = true;
        }
    }
}
