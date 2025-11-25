using CapaDeDatos.Datos;
using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.ServiciosUI;
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
        #region 1. Campos y Dependencias
        private readonly CategoriaRepositorio _categoriaRepositorio;
        private readonly GestorRealtime<Categoria> _gestorRealtime;
        private BuscadorInteractivo<Categoria> _buscadorCtrl;

        private List<Categoria> _listaCompletaCategorias = new List<Categoria>();

        private Categoria _categoriaSeleccionada;
        public Categoria CategoriaSeleccionada { get; private set; }
        #endregion

        #region 2. Constructores
        public frmCategorias()
        {
            InitializeComponent();
            ConfigurarFormulario();

            _categoriaRepositorio = new CategoriaRepositorio();
            _gestorRealtime = new GestorRealtime<Categoria>();

            btnAgregarCategoria.Visible = false;
            btnModificarCategoria.Visible = false;
            if (pnlLimpiarFiltros != null) pnlLimpiarFiltros.Visible = false;

            ConfigurarRealtime();
        }

        public frmCategorias(bool tipo)
        {
            InitializeComponent();
            ConfigurarFormulario();

            _categoriaRepositorio = new CategoriaRepositorio();
            _gestorRealtime = new GestorRealtime<Categoria>();

            FormBorderStyle = FormBorderStyle.None;
            btnSeleccionarCategoria.Visible = false;
            if (pnlLimpiarFiltros != null) pnlLimpiarFiltros.Visible = false;

            ConfigurarRealtime();
        }

        private void ConfigurarFormulario()
        {
            this.DoubleBuffered = true;
            dgvCategorias.AutoGenerateColumns = false;
            ConfigurarEventosUnificados();

            // IMPORTANTE: NO agregamos TextChanged para que no filtre al escribir
        }

        private void ConfigurarRealtime()
        {
            _gestorRealtime.OnCambioBaseDatos += (c) => RecargarInterfazSafe();
            _gestorRealtime.OnReconexionExitosa += () => RecargarInterfazSafe();
        }
        #endregion

        #region 3. Carga y Lógica Principal
        private async void frmCategorias_Load(object sender, EventArgs e)
        {
            if (!rbMostrarTodos.Checked && !rbMostrarHabilitados.Checked && !rbMostrarDeshabilitados.Checked)
            {
                rbMostrarTodos.Checked = true;
            }

            await InicializarDatosYBuscador();
            await _gestorRealtime.SuscribirAsync();
        }

        private async void frmCategorias_FormClosing(object sender, FormClosingEventArgs e)
        {
            await _gestorRealtime.DesuscribirAsync();
        }

        private void RecargarInterfazSafe()
        {
            if (!this.IsDisposed && this.IsHandleCreated)
                this.BeginInvoke((MethodInvoker)(async () => await CargarCategoriasMaestras()));
        }

        private async Task InicializarDatosYBuscador()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                _listaCompletaCategorias = await _categoriaRepositorio.ObtenerTodasLasCategorias(null);

                _buscadorCtrl = new BuscadorInteractivo<Categoria>(
                    txtBuscar,
                    lstSugerencias,
                    dgvCategorias,
                    _listaCompletaCategorias,
                    (c, term) => c.IdCategoria.ToString() == term,
                    (c, term) => c.NombreCategoria != null && c.NombreCategoria.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0,
                    (c) => c.NombreCategoria,
                    (buscando) =>
                    {
                        if (pnlLimpiarFiltros != null) pnlLimpiarFiltros.Visible = buscando;
                        // Solo refrescamos si LIMPIA la búsqueda (buscando = false)
                        if (!buscando) RefrescarGrid();
                    },
                    (txt) => false
                );

                RefrescarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally { this.Cursor = Cursors.Default; }
        }

        private async Task CargarCategoriasMaestras()
        {
            _listaCompletaCategorias = await _categoriaRepositorio.ObtenerTodasLasCategorias(null);
            if (_buscadorCtrl != null) _buscadorCtrl.ActualizarDatosMaestros(_listaCompletaCategorias);
            RefrescarGrid();
        }

        private void RefrescarGrid()
        {
            if (_listaCompletaCategorias == null) return;
            this.Cursor = Cursors.WaitCursor;

            // 1. Filtro Estado
            IEnumerable<Categoria> query = _listaCompletaCategorias;

            if (rbMostrarHabilitados.Checked)
                query = query.Where(c => c.EstadoCategoria == true);
            else if (rbMostrarDeshabilitados.Checked)
                query = query.Where(c => c.EstadoCategoria == false);

            // Actualizar buscador
            if (_buscadorCtrl != null) _buscadorCtrl.ActualizarDatosMaestros(query.ToList());

            // 2. Filtro Texto (Solo aplica cuando llamamos a este método manualmente)
            string texto = txtBuscar.Text.Trim();
            if (!string.IsNullOrEmpty(texto))
            {
                query = query.Where(c => c.NombreCategoria != null &&
                                         c.NombreCategoria.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            // 3. Grid
            var listaFinal = query.ToList();
            dgvCategorias.DataSource = null;
            dgvCategorias.DataSource = listaFinal;

            // Botón Limpiar
            if (pnlLimpiarFiltros != null)
            {
                bool hayFiltros = !rbMostrarHabilitados.Checked || !string.IsNullOrEmpty(texto);
                pnlLimpiarFiltros.Visible = hayFiltros;
            }

            if (dgvCategorias.Rows.Count > 0) dgvCategorias.ClearSelection();
            this.Cursor = Cursors.Default;
        }

        private void ConfigurarEventosUnificados()
        {
            rbMostrarTodos.CheckedChanged += (s, e) => { if (((RadioButton)s).Checked) RefrescarGrid(); };
            rbMostrarHabilitados.CheckedChanged += (s, e) => { if (((RadioButton)s).Checked) RefrescarGrid(); };
            rbMostrarDeshabilitados.CheckedChanged += (s, e) => { if (((RadioButton)s).Checked) RefrescarGrid(); };
        }
        #endregion

        #region 4. Eventos Buscador (Lógica Mantenida + Refresco Manual)

        // Eventos delegados al BuscadorInteractivo
        private async void txtBuscar_KeyUp(object sender, KeyEventArgs e) => await _buscadorCtrl.ManejarKeyUpAsync(e);

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e) => _buscadorCtrl.ManejarKeyDown(e);

        private void lstSugerencias_MouseClick(object sender, MouseEventArgs e) => _buscadorCtrl.ManejarClickLista();

        private void lstSugerencias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) _buscadorCtrl.ManejarClickLista();
        }
        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            _buscadorCtrl.LimpiarBusqueda();
            rbMostrarHabilitados.Checked = true;
            if (pnlLimpiarFiltros != null) pnlLimpiarFiltros.Visible = false;
            RefrescarGrid();
        }
        #endregion

        #region 5. CRUD y Selección
        private async void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            if (new frmAgregarEditarCategoria().ShowDialog() == DialogResult.OK) await CargarCategoriasMaestras();
        }

        private async void btnModificarCategoria_Click(object sender, EventArgs e)
        {
            if (_categoriaSeleccionada != null)
            {
                if (new frmAgregarEditarCategoria(_categoriaSeleccionada).ShowDialog() == DialogResult.OK) await CargarCategoriasMaestras();
            }
            else
            {
                MessageBox.Show("Seleccione una categoría.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvCategorias_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count > 0)
                _categoriaSeleccionada = dgvCategorias.SelectedRows[0].DataBoundItem as Categoria;
            else
                _categoriaSeleccionada = null;
        }

        private void btnSeleccionarCategoria_Click(object sender, EventArgs e) => ConfirmarSeleccion();
        private void dgvCategorias_CellDoubleClick(object sender, DataGridViewCellEventArgs e) => ConfirmarSeleccion();

        private void ConfirmarSeleccion()
        {
            if (dgvCategorias.SelectedRows.Count > 0)
            {
                CategoriaSeleccionada = dgvCategorias.SelectedRows[0].DataBoundItem as Categoria;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e) => this.Close();
        #endregion
    }
}