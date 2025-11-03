using CapaDeDatos.Modelados;
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

namespace ModernMenuUI
{
    public partial class frmAgregarEmpleado : Form
    {
        public frmAgregarEmpleado()
        {
            InitializeComponent();
            txtDni.Focus();
        }

        private async void btnGuardarEmpleado_Click(object sender, EventArgs e)
        {
            // 1. VALIDACIÓN (Simple)
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtDni.Text))
            {
                MessageBox.Show("Nombre, Apellido y DNI son obligatorios.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nuevonombre = txtNombre.Text.Trim(); 
            string nuevoapellido = txtApellido.Text.Trim();
            string nuevoDni = txtDni.Text.Trim();
            string nuevoTelefono = txtTelefono.Text.Trim();
            string nuevoEmail = txtCorreo.Text.Trim();
            string nuevaDireccion = txtDireccion.Text.Trim();

            // 2. CREACIÓN DEL OBJETO (ACTUALIZADO)
            Empleado nuevoEmpleado = new Empleado
            {
                Nombre = nuevonombre,
                Apellido = nuevoapellido,
                Dni = nuevoDni,
                Telefono = nuevoTelefono,
                Email = nuevoEmail,       // Tu TextBox se llama txtCorreo, está bien.
                Direccion = nuevaDireccion
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

        private void frmAgregarEmpleado_Load(object sender, EventArgs e)
        {
            clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "AGREGUE UN EMPLEADO NUEVO");
            
        }

        private void btnVover_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
