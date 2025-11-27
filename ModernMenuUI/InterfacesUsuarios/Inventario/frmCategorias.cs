using CapaDeDatos.Datos;
using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using Supabase.Realtime.PostgresChanges;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI.InterfacesUsuarios.Inventario
{
    public partial class frmCategorias : Form
    {
        private GestorRealtime<Categoria> _gestorRealtime;
        private CategoriaRepositorio _categoriaRepositorio;
        private List<Categoria> _listaMaestraCategorias = new List<Categoria>();
        private Categoria _categoriaSeleccionada;

        public Categoria CategoriaSeleccionada { get; private set; }

        public frmCategorias()
        {
            InitializeComponent();
            ConfigurarFormulario();
            btnAgregarCategoria.Visible = false;
            btnModificarCategoria.Visible = false;
        }

        public frmCategorias(bool tipo)
        {
            InitializeComponent();
            ConfigurarFormulario();
            FormBorderStyle = FormBorderStyle.None;
            btnSeleccionarCategoria.Visible = false;
        }

        private void ConfigurarFormulario()
        {
            this.DoubleBuffered = true;
            _categoriaRepositorio = new CategoriaRepositorio();
            dgvCategorias.AutoGenerateColumns = false;
            this.FormClosing += frmCategorias_FormClosing;

            _gestorRealtime = new GestorRealtime<Categoria>();

            _gestorRealtime.OnCambioBaseDatos += (change) =>
            {
                System.Diagnostics.Debug.WriteLine($"Cambio BD: {change.Event}");
                RecargarInterfaz();
            };

            _gestorRealtime.OnReconexionExitosa += () =>
            {
                System.Diagnostics.Debug.WriteLine("Reconexión exitosa -> Recargando Grid");
                RecargarInterfaz();
            };
        }

        private async void frmCategorias_Load(object sender, EventArgs e)
        {
            if (!rbMostrarTodos.Checked && !rbMostrarHabilitados.Checked && !rbMostrarDeshabilitados.Checked)
            {
                rbMostrarTodos.Checked = true;
            }

            await CargarCategoriasMaestras();
            RefrescarGrid();

            await _gestorRealtime.SuscribirAsync();
        }

        private async void frmCategorias_FormClosing(object sender, FormClosingEventArgs e)
        {
            await _gestorRealtime.DesuscribirAsync();
        }

        private void RecargarInterfaz()
        {
            if (this.IsDisposed || !this.IsHandleCreated) return;

            this.BeginInvoke((MethodInvoker)(async () =>
            {
                if (this.IsDisposed) return;
                await CargarCategoriasMaestras();
                RefrescarGrid();
            }));
        }

        private async Task CargarCategoriasMaestras()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                _listaMaestraCategorias = await _categoriaRepositorio.ObtenerTodasLasCategorias(null);
            }
            catch (Exception ex)
            {
                // Opcional: Solo mostrar error si NO es cancelación de tarea
                System.Diagnostics.Debug.WriteLine($"Error carga: {ex.Message}");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void RefrescarGrid()
        {
            this.Cursor = Cursors.WaitCursor;

            bool? estado = null;
            if (rbMostrarHabilitados.Checked) estado = true;
            if (rbMostrarDeshabilitados.Checked) estado = false;

            List<Categoria> listaFiltrada;

            if (estado == null)
                listaFiltrada = _listaMaestraCategorias;
            else
                listaFiltrada = _listaMaestraCategorias.Where(c => c.EstadoCategoria == estado).ToList();

            dgvCategorias.DataSource = null;
            dgvCategorias.DataSource = listaFiltrada;

            if (dgvCategorias.Rows.Count > 0)
                dgvCategorias.ClearSelection();

            this.Cursor = Cursors.Default;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // --- EVENTOS DE UI (RadioButtons, Clicks) ---
        private void rbMostrarHabilitados_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMostrarHabilitados.Checked) RefrescarGrid();
        }
        private void rbMostrarDeshabilitados_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMostrarDeshabilitados.Checked) RefrescarGrid();
        }
        private void rbMostrarTodos_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbMostrarTodos.Checked) RefrescarGrid();
        }

        private void SeleccionarRegistro()
        {
            if (dgvCategorias.SelectedRows.Count > 0)
            {
                CategoriaSeleccionada = dgvCategorias.SelectedRows[0].DataBoundItem as Categoria;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnSeleccionarCategoria_Click(object sender, EventArgs e) => SeleccionarRegistro();

        private void dgvCategorias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) SeleccionarRegistro();
        }

        private async void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            frmAgregarEditarCategoria _nuevaCategoria = new frmAgregarEditarCategoria();

            DialogResult resultado = _nuevaCategoria.ShowDialog();

            if (resultado == DialogResult.OK)
            {

                await CargarCategoriasMaestras();

                RefrescarGrid();

            }
        }

        private async void btnModificarCategoria_Click(object sender, EventArgs e)
        {
            if (_categoriaSeleccionada != null)
            {
                // Pasamos _marcaSeleccionada al constructor
                frmAgregarEditarCategoria editarForm = new frmAgregarEditarCategoria(_categoriaSeleccionada);
                DialogResult resultado = editarForm.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    await CargarCategoriasMaestras();
                    RefrescarGrid();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una marca primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private async void dgvCategorias_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count > 0)
            {
                _categoriaSeleccionada = dgvCategorias.SelectedRows[0].DataBoundItem as Categoria;
            }
            else
            {
                _categoriaSeleccionada = null;
            }
        }
    }
}