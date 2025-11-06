using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using CapaDeDatos.Repositorios;
using ModernMenuUI.InterfacesUsuarios.Inventario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI
{
    public partial class frmProductos : Form
    {
        private readonly ProductoRepositorio _productoRepo;
        private readonly MarcaRepositorio _marcaRepo;
        Form formularioactivo = null;
        public frmProductos()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            // ===== ESTILO BARRA LATERAL (RowHeader) =====
            dgvProductos.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#DCE6F1");
            dgvProductos.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#57636e");
            dgvProductos.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            _productoRepo = new ProductoRepositorio();
            dgvProductos.AutoGenerateColumns = false;


            _marcaRepo = new MarcaRepositorio();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            this.Close();
        }

        private void HoraFecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss tt", new CultureInfo("es-ES"));
            lblFecha.Text = DateTime.Now.ToString("dddd dd 'de' MMMM 'del' yyyy", new CultureInfo("es-ES"));
        }

        private void AbrirFormularioHijo(Form Formulariohijo)
        {
            Editar_Producto formHijo = new Editar_Producto();
            formHijo.StartPosition = FormStartPosition.CenterParent;

            // Evento que detecta cuando el formulario pierde foco
            formHijo.Deactivate += (s, ev) =>
            {
                System.Media.SystemSounds.Exclamation.Play(); // Sonido de advertencia
            };

            formHijo.ShowDialog(); // Modal
        }
        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new Editar_Producto());
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            btnNuevo.Enabled = dgvProductos.SelectedRows.Count > 0;
        }
        // 1. REEMPLAZA tu método 'CargarProductos'
        private async Task CargarProductos(bool? estado = null) // Ahora acepta un filtro
        {
            try
            {
                this.Cursor = Cursors.WaitCursor; // Pone el cursor de espera
                gbxEstado.Enabled = false;     // Deshabilita los radio buttons

                // 2. Llama al método del repositorio con el filtro
                // (Debes modificar tu _productoRepo.ObtenerProductos para que acepte el 'estado')
                List<Producto> listaDeProductos = await _productoRepo.ObtenerTodosLosProductos(estado);

                // 3. Asigna los datos al DataGridView
                dgvProductos.DataSource = null;
                dgvProductos.DataSource = listaDeProductos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar productos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default; // Devuelve el cursor
                gbxEstado.Enabled = true;     // Vuelve a habilitar los radio buttons
            }
        }

        private async void frmProductos_Load(object sender, EventArgs e)
        {
            CargarProductos(null);
            await CargarMarcasAsync();
        }

        private async void rbMostrarTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                await CargarProductos(null); // 'null' significa Todos
            }
        }

        private async void rbMostrarHabilitados_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                await CargarProductos(true); // 'true' significa Habilitados
            }
        }

        private async void rbMostrardeshabilitados_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                await CargarProductos(false); // 'false' significa Deshabilitados
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            /*frmAgregarEditarMarca marca = new frmAgregarEditarMarca();
            marca.ShowDialog();*/

            frmAgregarEditarMarca formDeIngreso = new frmAgregarEditarMarca();

            // Muestra el formulario como un diálogo y "pausa" este código
            DialogResult resultado = formDeIngreso.ShowDialog();

            // 5. ¡AQUÍ ESTÁ LA MAGIA!
            //    Comprueba la "señal" (OK o Cancel) que envió el formulario pequeño
            if (resultado == DialogResult.OK)
            {
                // 6. Si la señal fue "OK", refresca el ComboBox
                MessageBox.Show("Marca agregada. Refrescando lista...", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Vuelve a llamar al método de carga
                await CargarMarcasAsync();
            }

            // Si el usuario presionó "Cancelar", no hace nada.
        }

        private async Task CargarMarcasAsync()
        {
            try
            {
                // Llama al repositorio (Capa de Datos) para obtener la lista
                // (Usando la instancia _marcaRepo)
                var listaDeMarcas = await _marcaRepo.ObtenerTodasLasMarcas();

                // Configura el ComboBox
                // (Asumiendo que tu ComboBox se llama cmbMarca)

                // Le dice al ComboBox qué datos usar
                cmbMarca.DataSource = listaDeMarcas;

                // Le dice qué propiedad del modelo 'Marca' mostrar al usuario
                // (Usa el nombre de la propiedad de tu clase C#)
                cmbMarca.DisplayMember = "NombreMarcaMarca";

                // Le dice qué propiedad usar como valor interno (el ID)
                cmbMarca.ValueMember = "IdMarca";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las marcas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
