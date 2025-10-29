using CapaDeDatos;
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
        public frmAgregarEmpleado()
        {
            InitializeComponent();
        }

        private async void btnGuardarEmpleado_Click(object sender, EventArgs e)
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
        }
    }
}
