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

            Empleado nuevoEmpleado = new Empleado
            {
                Nombre = nuevonombre,
                Apellido = nuevoapellido,
                Dni = nuevoDni,
                Telefono = nuevoTelefono,
                Email = nuevoEmail,       
                Direccion = nuevaDireccion
            };

            try
            {
                btnGuardarEmpleado.Enabled = false;

                await EmpleadoRepositorio.InsertarEmpleado(nuevoEmpleado);
                
                // Registro en bitácora
                string nombreComputadora = Environment.MachineName; //con esta onda agarro los datos de la computadora lol
                string usuarioWindows = Environment.UserName;
                await BitacoraRepositorio.BitacoraService.RegistrarBitacoraAsync
                    (
                       await CapaDeDatos.Datos.Conexion.GetClientAsync(),
                       "El empleado"+nuevonombre+" "+nuevoapellido+" ha sido agregado.",
                        DateTime.Now.ToString(),
                        $"PC: {nombreComputadora}, Usuario: {usuarioWindows}"
                    );

                MessageBox.Show("¡Empleado guardado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el empleado: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
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
