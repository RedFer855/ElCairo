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
    public partial class frmBuscarMarca : Form
    {

        // --- 1. Propiedades Públicas ---
        // El formulario 'frmAgregarProducto' leerá estos valores
        // cuando este formulario se cierre.
        public int IdMarcaSeleccionada { get; private set; }
        public string NombreMarcaSeleccionada { get; private set; }

        // El repositorio para cargar los datos
        private readonly MarcaRepositorio _marcaRepo;
        public frmBuscarMarca()
        {
            InitializeComponent();
            _marcaRepo = new MarcaRepositorio(); // Inicializa la instancia

            // Opcional: Configurar el DataGridView para selección limpia
            // dgvMarcas.AutoGenerateColumns = false; // (Si configuras las columnas manualmente)
            dgvMarcas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMarcas.MultiSelect = false;
        }

        private async void frmBuscarMarca_Load(object sender, EventArgs e)
        {
            await CargarMarcas();
        }
        private async Task CargarMarcas()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                // Llama al repositorio (instancia) para obtener los datos
                var listaDeMarcas = await _marcaRepo.ObtenerTodasLasMarcas();

                // Carga los datos en el DataGridView
                dgvMarcas.DataSource = listaDeMarcas;

                // (Opcional) Ajustar columnas si usas AutoGenerateColumns = true
                // dgvMarcas.Columns["IdMarca"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las marcas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            // Asegurarse de que el usuario haya seleccionado una fila
            if (dgvMarcas.SelectedRows.Count > 0)
            {
                // Obtener la fila seleccionada
                var filaSeleccionada = dgvMarcas.SelectedRows[0];

                // Convertir la fila de datos de vuelta al objeto 'Marca'
                Marca marcaSeleccionada = filaSeleccionada.DataBoundItem as Marca;

                if (marcaSeleccionada != null)
                {
                    // 4. Guardar los datos en las propiedades públicas
                    // (Aquí "agarramos" el nombre y el ID)
                    this.IdMarcaSeleccionada = marcaSeleccionada.IdMarca;
                    this.NombreMarcaSeleccionada = marcaSeleccionada.NombreMarca;

                    // 5. Enviar la señal "OK" y cerrar
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una marca de la lista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
