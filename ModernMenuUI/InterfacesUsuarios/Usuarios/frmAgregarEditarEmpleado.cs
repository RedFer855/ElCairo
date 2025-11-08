using CapaDeDatos.Modelados;
using CapaDeDatos.Repositorios;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.InterfacesUsuarios.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI
{
    public partial class frmAgregarEditarEmpleado : Form
    {
        private Empleado _empleadoActual;
        // Constructor 1: Para "AGREGAR" (no recibe nada)

        public frmAgregarEditarEmpleado()
        {
            InitializeComponent();
            _empleadoActual = null; // Lo dejamos nulo
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
            // 1. VALIDACIÓN (Para ambos modos)
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtDni.Text))
            {
                MessageBox.Show("Nombre, Apellido y DNI son obligatorios.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Deshabilitamos el botón para evitar doble clic
            btnGuardarEmpleado.Enabled = false;

            try
            {
                if (_empleadoActual == null)
                {
                    // --- MODO AGREGAR ---
                    // 2. Creación del objeto nuevo
                    Empleado nuevoEmpleado = new Empleado
                    {
                        Nombre = txtNombre.Text.Trim(),
                        Apellido = txtApellido.Text.Trim(),
                        Dni = txtDni.Text.Trim(),
                        Telefono = txtTelefono.Text.Trim(),
                        Email = txtCorreo.Text.Trim(),
                        Direccion = txtDireccion.Text.Trim()
                    };

                    // 3. Llamada al Repositorio (INSERTAR)
                    await EmpleadoRepositorio.InsertarEmpleado(nuevoEmpleado);

                    MessageBox.Show("¡Empleado guardado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Cerramos el form al terminar
                }
                else
                {
                    // --- MODO MODIFICAR ---
                    // 2. Actualizamos el objeto existente
                    _empleadoActual.Nombre = txtNombre.Text.Trim();
                    _empleadoActual.Apellido = txtApellido.Text.Trim();
                    _empleadoActual.Dni = txtDni.Text.Trim();
                    _empleadoActual.Telefono = txtTelefono.Text.Trim();
                    _empleadoActual.Email = txtCorreo.Text.Trim();
                    _empleadoActual.Direccion = txtDireccion.Text.Trim();

                    // 3. Llamada al Repositorio (ACTUALIZAR)
                    await EmpleadoRepositorio.ActualizarEmpleado(_empleadoActual);

                    MessageBox.Show("¡Empleado actualizado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Cerramos el form al terminar
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el empleado: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Si no se cerró el formulario (por un error), reactivamos el botón
                if (!this.IsDisposed)
                {
                    btnGuardarEmpleado.Enabled = true;
                }
            }
        }

        private void frmAgregarEmpleado_Load(object sender, EventArgs e)
        {
            // Comprobamos si estamos en modo "Editar"
            if (_empleadoActual != null)
            {
                // --- MODO EDITAR (Inicia en "Solo Lectura") ---
                clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "EDITAR EMPLEADO");

                // Cargar datos
                txtDni.Text = _empleadoActual.Dni;
                txtNombre.Text = _empleadoActual.Nombre;
                txtApellido.Text = _empleadoActual.Apellido;
                txtTelefono.Text = _empleadoActual.Telefono;
                txtDireccion.Text = _empleadoActual.Direccion;
                txtCorreo.Text = _empleadoActual.Email;

                // Poner en modo "Solo Lectura"
                txtDni.ReadOnly = true;
                txtNombre.ReadOnly = true;
                txtApellido.ReadOnly = true;
                txtTelefono.ReadOnly = true;
                txtDireccion.ReadOnly = true;
                txtCorreo.ReadOnly = true; // Asegúrate de incluir el correo

                // Configurar botones para "Ver"
                btnGuardarEmpleado.Visible = false;
                btnModificar.Visible = true;
                btnModificar.Enabled = true;
            }
            else
            {
                // --- MODO AGREGAR ---
                clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "AGREGUE UN EMPLEADO NUEVO");

                // Los TextBoxes ya estarán editables por defecto.

                // Configurar botones para "Guardar"
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
            txtCorreo.ReadOnly = false; // <-- AÑADE ESTE
            btnVolver.Focus();

            btnModificar.Enabled = false;
            btnModificar.Visible = false;
            btnGuardarEmpleado.Visible = true;
        }
    }
}
