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

namespace ModernMenuUI.InterfacesUsuarios.Inventario
{
    public partial class frmAgregarEditarMarca : Form
    {
        public frmAgregarEditarMarca()
        {
            InitializeComponent();
        }

        private async void btnGuardarProveedor_Click(object sender, EventArgs e)
        {
            // 1. VALIDACIÓN
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre de la marca es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Deshabilita el botón para evitar doble clic
            btnGuardarMarca.Enabled = false;

            try
            {
                // 2. CREACIÓN DEL OBJETO
                Marca nuevaMarca = new Marca
                {
                    // Asignamos el nombre desde el TextBox
                    NombreMarca = txtNombre.Text.Trim(),

                    // --- ¡IMPORTANTE! Asignamos valores por defecto ---
                    // Tu tabla 'marca' requiere estos campos.
                    // Ajusta estos IDs según sea necesario.

                    EstadoMarca = true, // Por defecto, la nueva marca estará "Activa"
                    IdEstado = 1,       // Asumiendo que '1' es el ID de "Activo" en tu BD
                    IdProveedor = 1     // Asumiendo un Proveedor por defecto (ej. '1').
                                        // Si este campo puede ser nulo, puedes omitirlo.
                };

                // 3. LLAMADA AL REPOSITORIO
                await MarcaRepositorio.InsertarMarca(nuevaMarca);

                MessageBox.Show("¡Marca guardada exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 4. ENVÍA LA SEÑAL DE ÉXITO Y CIERRA
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la marca: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Vuelve a habilitar el botón, pase lo que pase
                btnGuardarMarca.Enabled = true;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            // Envía la señal de "Cancelar" y cierra
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
