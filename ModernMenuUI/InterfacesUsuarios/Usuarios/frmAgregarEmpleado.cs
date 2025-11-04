using CapaDeDatos.Modelados;
using CapaDeDatos.Repositorios;
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
    public partial class frmAgregarEmpleado : Form
    {
        private Empleado _empleadoActual;
        // Constructor 1: Para "AGREGAR" (no recibe nada)

        public frmAgregarEmpleado()
        {
            InitializeComponent();
            _empleadoActual = null; // Lo dejamos nulo
        }
        public frmAgregarEmpleado(Empleado empleado)
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
            if (_empleadoActual != null)
            {
                // 1. VALIDACIÓN (Simple)
                if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtDni.Text))
                {
                    MessageBox.Show("Nombre, Apellido y DNI son obligatorios.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                // 2. CREACIÓN DEL OBJETO (ACTUALIZADO)
                Empleado nuevoEmpleado = new Empleado
                {
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Dni = txtDni.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Email = txtCorreo.Text.Trim(),       // Tu TextBox se llama txtCorreo, está bien.
                    Direccion = txtDireccion.Text.Trim()
                };

                // 3. LLAMADA A LA CAPA DE DATOS
                try
                {
                    // ERROR 3: El botón se llama 'btnGuardar', no 'btnGuardarEmpleado'
                    btnGuardarEmpleado.Enabled = false;

                    // Ahora la llamada 'await' funcionará correctamente
                    await EmpleadoRepositorio.InsertarEmpleado(nuevoEmpleado);

                    MessageBox.Show("¡Empleado guardado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar el empleado: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // ERROR 3 (corregido)
                    btnGuardarEmpleado.Enabled = true;
                }
            } else
            {
                btnGuardarEmpleado.Visible = false;
                btnModificar.Visible = true;   
                btnModificar.Enabled = true;
                MessageBox.Show("¡Empleado creado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

        private void frmAgregarEmpleado_Load(object sender, EventArgs e)
        {

            // Comprobamos si estamos en modo "Editar"
            if (_empleadoActual != null)
            {

                txtDni.Text = _empleadoActual.Dni;
                txtNombre.Text = _empleadoActual.Nombre;
                txtApellido.Text = _empleadoActual.Apellido;
                txtTelefono.Text = _empleadoActual.Telefono;
                txtDireccion.Text = _empleadoActual.Direccion;
                txtCorreo.Text = _empleadoActual.Email;

            }
            else
            {
                // MODO AGREGAR: Dejamos todo vacío
                clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "AGREGUE UN EMPLEADO NUEVO");
                // btnGuardar.Text = "Guardar";

                // Los TextBoxes ya estarán vacíos por defecto.
            }
        }



        private void btnVover_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            frmAgregarUsuario Usu = new frmAgregarUsuario();
            Usu.ShowDialog();
        }

        private void TextBox_ReadOnlyClick(object sender, EventArgs e)
        {
            // El parámetro 'sender' es una referencia al control que disparó el evento.
            // Lo convertimos al tipo TextBox.
            TextBox currentTextBox = sender as TextBox;

            // Se realiza una doble verificación: 
            // 1. Que la conversión fue exitosa (currentTextBox no es null).
            // 2. Que el TextBox está actualmente en modo de solo lectura.
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
            txtDni.Focus();

            btnModificar.Enabled = false;
            btnModificar.Visible = false;
            btnGuardarEmpleado.Visible = true;
        }
    }
}
