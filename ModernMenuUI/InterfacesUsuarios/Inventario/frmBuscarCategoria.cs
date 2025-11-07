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
    public partial class frmBuscarCategoria : Form
    {
        public int IdCategoriaSeleccionada { get; private set; }
        public string NombreCategoriaSeleccionada { get; private set; }

        // El repositorio para cargar los datos
        private readonly CategoriaRepositorio _categoriaRepo;
        public frmBuscarCategoria()
        {
            InitializeComponent();
            _categoriaRepo = new CategoriaRepositorio(); // Inicializa la instancia

            // Opcional: Configurar el DataGridView
            dgvCategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategorias.MultiSelect = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private async Task CargarCategorias()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                // Llama al repositorio para obtener los datos
                var listaDeCategorias = await _categoriaRepo.ObtenerTodasLasCategorias();

                // Carga los datos en el DataGridView
                dgvCategorias.DataSource = listaDeCategorias;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private async void frmBuscarCategoria_Load(object sender, EventArgs e)
        {
            await CargarCategorias();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            // Asegurarse de que el usuario haya seleccionado una fila
            if (dgvCategorias.SelectedRows.Count > 0)
            {
                var filaSeleccionada = dgvCategorias.SelectedRows[0];

                // Convertir la fila de datos de vuelta al objeto 'Categoria'
                Categoria categoriaSeleccionada = filaSeleccionada.DataBoundItem as Categoria;

                if (categoriaSeleccionada != null)
                {
                    // 4. Guardar los datos en las propiedades públicas
                    this.IdCategoriaSeleccionada = categoriaSeleccionada.IdCategoria;
                    // Debes crear el modelo 'Categoria.cs' con su propiedad (ej. 'NombreCategoria')
                    this.NombreCategoriaSeleccionada = categoriaSeleccionada.NombreCategoria;

                    // 5. Enviar la señal "OK" y cerrar
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una categoría de la lista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
