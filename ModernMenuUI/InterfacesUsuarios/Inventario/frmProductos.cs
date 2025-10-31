using CapaDeDatos.Modelados;
using CapaDeDatos.Repositorios;
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

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

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

        private void button3_Click(object sender, EventArgs e)
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
        private async void CargarProductos()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor; // Pone el cursor de espera

                // 1. Llama al método del repositorio
                List<Producto> listaDeProductos = await _productoRepo.ObtenerTodosLosProductos();

                // 2. Asigna los datos al DataGridView (asumo que se llama 'dgvProductos')
                dgvProductos.DataSource = null;
                dgvProductos.DataSource = listaDeProductos;
            }
            catch (Exception ex)
            {
                // Muestra el error que viene del repositorio
                MessageBox.Show(ex.Message, "Error al cargar productos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default; // Devuelve el cursor
            }
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }
    }

}
