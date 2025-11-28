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

            // Eventos para campos de solo lectura
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
                // 1. Validar que se haya seleccionado un estado
                if (!rbActivo.Checked && !rbInactivo.Checked)
                {
                    MessageBox.Show("Debe seleccionar un estado (Activo/Inactivo).", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnGuardarEmpleado.Enabled = true; // Reactivar botón
                    return;
                }

                Empleado nuevoEmpleado = new Empleado
                {
                    NombreEmpleado = txtNombre.Text.Trim(),
                    ApellidoEmpleado = txtApellido.Text.Trim(),
                    DniEmpleado = txtDni.Text.Trim(),
                    TelefonoEmpleado = txtTelefono.Text.Trim(),
                    EmailEmpleado = txtCorreo.Text.Trim(),
                    DireccionEmpleado = txtDireccion.Text.Trim(),

                    // CORRECCION 1: Asignar el valor del estado basado en el RadioButton
                    EstadoEmpleado = rbActivo.Checked
                };

                var resultadoValidacion = ServicioValidacionesIngresoDatos.EjecutarValidacionesEmpleado(nuevoEmpleado);

                if (resultadoValidacion.Error)
                {
                    MessageBox.Show(resultadoValidacion.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnGuardarEmpleado.Enabled = true;
                    return;
                }

                if (_empleadoActual == null)
                {
                    // --- AGREGAR ---
                    await EmpleadoRepositorio.InsertarEmpleado(nuevoEmpleado);

                    MessageBox.Show("¡Empleado guardado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // Importante para que el grid se actualice al cerrar
                    this.Close();
                }
                else
                {
                    // --- EDITAR ---
                    _empleadoActual.NombreEmpleado = txtNombre.Text.Trim();
                    _empleadoActual.ApellidoEmpleado = txtApellido.Text.Trim();
                    _empleadoActual.DniEmpleado = txtDni.Text.Trim();
                    _empleadoActual.TelefonoEmpleado = txtTelefono.Text.Trim();
                    _empleadoActual.EmailEmpleado = txtCorreo.Text.Trim();
                    _empleadoActual.DireccionEmpleado = txtDireccion.Text.Trim();

                    // CORRECCION 2: Actualizar el estado también al editar
                    _empleadoActual.EstadoEmpleado = rbActivo.Checked;

                    await EmpleadoRepositorio.ActualizarEmpleado(_empleadoActual);

                    MessageBox.Show("¡Empleado actualizado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // Importante para que el grid se actualice al cerrar
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

                txtDni.Text = _empleadoActual.DniEmpleado;
                txtNombre.Text = _empleadoActual.NombreEmpleado;
                txtApellido.Text = _empleadoActual.ApellidoEmpleado;
                txtTelefono.Text = _empleadoActual.TelefonoEmpleado;
                txtDireccion.Text = _empleadoActual.DireccionEmpleado;
                txtCorreo.Text = _empleadoActual.EmailEmpleado;

                if (_empleadoActual.EstadoEmpleado)
                {
                    rbActivo.Checked = true;
                }
                else
                {
                    rbInactivo.Checked = true;
                }

                txtDni.ReadOnly = true;
                txtNombre.ReadOnly = true;
                txtApellido.ReadOnly = true;
                txtTelefono.ReadOnly = true;
                txtDireccion.ReadOnly = true;
                txtCorreo.ReadOnly = true;            
                gbxEstado.Enabled = false; 
                btnGuardarEmpleado.Visible = false;
                btnModificarEmpleado.Visible = true;
                btnModificarEmpleado.Enabled = true;
            }
            else
            {
                clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "AGREGUE UN EMPLEADO NUEVO");

                txtCorreo.Enabled = true;
                btnGuardarEmpleado.Visible = true;
                btnModificarEmpleado.Visible = false;

                // Por defecto al agregar nuevo, sugerimos Activo
                rbActivo.Checked = true;
            }
        }

        private void btnVover_Click(object sender, EventArgs e)
        {
            this.Close();
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
            // Habilitar campos
            txtApellido.ReadOnly = false;
            txtTelefono.ReadOnly = false;
            txtDireccion.ReadOnly = false;
            txtNombre.ReadOnly = false;
            txtDni.ReadOnly = false;
            txtCorreo.ReadOnly = false;

            // Habilitar selección de estado
            gbxEstado.Enabled = true; // O rbActivo.Enabled = true; rbInactivo.Enabled = true;

            btnVolver.Focus();

            btnModificarEmpleado.Enabled = false;
            btnModificarEmpleado.Visible = false;
            btnGuardarEmpleado.Visible = true;
        }
    }
}