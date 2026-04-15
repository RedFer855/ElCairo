using CapaDeDatos.Datos;
using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.ServiciosUI;
using Supabase.Realtime.PostgresChanges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI.InterfacesUsuarios.Inventario
{
    public partial class frmCategorias : Form
    {
        private readonly CategoriaRepositorio _categoriaRepositorio;
        private BuscadorInteractivo<Categoria> _buscadorCtrl;
        private List<Categoria> _listaCompletaCategorias = new List<Categoria>();
        private Categoria _categoriaSeleccionada;
        private bool _cerrando = false;

        private Action<PostgresChangesResponse> _handlerCambio;

        public Categoria CategoriaSeleccionada { get; private set; }

        public frmCategorias()
        {
            InitializeComponent();
            ConfigurarFormulario();

            _categoriaRepositorio = new CategoriaRepositorio();

            if (pnlLimpiarFiltros != null)
                pnlLimpiarFiltros.Visible = false;

            this.FormClosed += frmCategorias_FormClosed;

            ConfigurarRealtime();
        }

        public frmCategorias(bool tipo)
        {
            InitializeComponent();
            ConfigurarFormulario();

            _categoriaRepositorio = new CategoriaRepositorio();

            FormBorderStyle = FormBorderStyle.None;
            btnSeleccionarCategoria.Visible = false;

            if (pnlLimpiarFiltros != null)
                pnlLimpiarFiltros.Visible = false;

            this.FormClosed += frmCategorias_FormClosed;

            ConfigurarRealtime();
        }

        private void ConfigurarFormulario()
        {
            this.DoubleBuffered = true;
            dgvCategorias.AutoGenerateColumns = false;
            ConfigurarEventosUnificados();
        }

        private void ConfigurarRealtime()
        {
            _handlerCambio = (c) => RecargarInterfazSafe();
            RealtimeManager.OnCategoriaChanged += _handlerCambio;
        }

        private async void frmCategorias_Load(object sender, EventArgs e)
        {
            if (!rbMostrarTodos.Checked && !rbMostrarHabilitados.Checked && !rbMostrarDeshabilitados.Checked)
                rbMostrarTodos.Checked = true;

            await InicializarDatosYBuscador();
        }

        private void frmCategorias_FormClosed(object sender, FormClosedEventArgs e)
        {
            _cerrando = true;

            try
            {
                if (_handlerCambio != null)
                    RealtimeManager.OnCategoriaChanged -= _handlerCambio;

                _buscadorCtrl?.Dispose();
                _buscadorCtrl = null;
            }
            catch { }

            _handlerCambio = null;
            _categoriaSeleccionada = null;

            _listaCompletaCategorias?.Clear();
            _listaCompletaCategorias = null;

            lstSugerencias.DataSource = null;
            dgvCategorias.DataSource = null;
        }

        private void RecargarInterfazSafe()
        {
            if (_cerrando || this.IsDisposed || !this.IsHandleCreated) return;

            try
            {
                this.BeginInvoke((MethodInvoker)(async () =>
                {
                    if (_cerrando || this.IsDisposed) return;
                    await CargarCategoriasMaestras();
                }));
            }
            catch { }
        }

        // -------------------------------------------------------------
        // CARGA DE DATOS
        // -------------------------------------------------------------
        private async Task InicializarDatosYBuscador()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _listaCompletaCategorias = await _categoriaRepositorio.ObtenerTodasLasCategorias(null);

                InicializarBuscador();
                RefrescarGrid();
            }
            finally
            {
                if (!this.IsDisposed)
                    this.Cursor = Cursors.Default;
            }
        }

        private async Task CargarCategoriasMaestras()
        {
            if (_cerrando || this.IsDisposed) return;

            _listaCompletaCategorias = await _categoriaRepositorio.ObtenerTodasLasCategorias(null);

            if (_cerrando || this.IsDisposed) return;

            RefrescarGrid();
            ActualizarBuscador();
        }

        // -------------------------------------------------------------
        // FILTRO + BUSCADOR (igual que en frmUsuario)
        // -------------------------------------------------------------
        private List<Categoria> ObtenerCategoriasSegunFiltro()
        {
            if (_listaCompletaCategorias == null)
                return new List<Categoria>();

            IEnumerable<Categoria> query = _listaCompletaCategorias;

            if (rbMostrarHabilitados.Checked)
                query = query.Where(c => c.EstadoCategoria);
            else if (rbMostrarDeshabilitados.Checked)
                query = query.Where(c => !c.EstadoCategoria);
            // Si es "Todos", no se filtra

            return query.ToList();
        }

        private void InicializarBuscador()
        {
            _buscadorCtrl?.Dispose();

            _buscadorCtrl = new BuscadorInteractivo<Categoria>(
                txtBuscar,
                lstSugerencias,
                dgvCategorias,
                ObtenerCategoriasSegunFiltro(),

                // BÚSQUEDA EXACTA
                (c, t) => c.IdCategoria.ToString() == t,

                // BÚSQUEDA PARCIAL (sin forzar estado — lo controla el filtro)
                (c, t) =>
                    c.NombreCategoria != null &&
                    c.NombreCategoria.IndexOf(t, StringComparison.OrdinalIgnoreCase) >= 0,

                // TEXTO MOSTRADO
                (c) => c.NombreCategoria,

                // EVENTO FILTRO ACTIVO
                (b) =>
                {
                    if (pnlLimpiarFiltros != null)
                        pnlLimpiarFiltros.Visible = b;

                    if (!b)
                        RefrescarGrid();
                },

                // SOLO NÚMEROS
                (txt) => false
            );
        }

        private void ActualizarBuscador()
        {
            if (_buscadorCtrl == null) return;
            _buscadorCtrl.ActualizarDatosMaestros(ObtenerCategoriasSegunFiltro());
        }

        // -------------------------------------------------------------
        // GRID
        // -------------------------------------------------------------
        private void RefrescarGrid()
        {
            if (_cerrando || IsDisposed || _listaCompletaCategorias == null)
                return;

            this.Cursor = Cursors.WaitCursor;

            try
            {
                var listaFinal = ObtenerCategoriasSegunFiltro();

                dgvCategorias.SuspendLayout();
                try
                {
                    dgvCategorias.DataSource = null;
                    dgvCategorias.DataSource = listaFinal;

                    if (dgvCategorias.Rows.Count > 0)
                        dgvCategorias.ClearSelection();
                }
                finally
                {
                    dgvCategorias.ResumeLayout();
                }

                if (pnlLimpiarFiltros != null)
                {
                    bool hayFiltros = rbMostrarHabilitados.Checked ||
                                      rbMostrarDeshabilitados.Checked;

                    pnlLimpiarFiltros.Visible = hayFiltros;
                }
            }
            finally
            {
                if (!IsDisposed)
                    this.Cursor = Cursors.Default;
            }
        }

        // -------------------------------------------------------------
        // RADIO BUTTONS
        // -------------------------------------------------------------
        private void ConfigurarEventosUnificados()
        {
            rbMostrarTodos.CheckedChanged += (s, e) =>
            {
                if (((RadioButton)s).Checked)
                {
                    RefrescarGrid();
                    ActualizarBuscador();
                }
            };

            rbMostrarHabilitados.CheckedChanged += (s, e) =>
            {
                if (((RadioButton)s).Checked)
                {
                    RefrescarGrid();
                    ActualizarBuscador();
                }
            };

            rbMostrarDeshabilitados.CheckedChanged += (s, e) =>
            {
                if (((RadioButton)s).Checked)
                {
                    RefrescarGrid();
                    ActualizarBuscador();
                }
            };
        }

        // -------------------------------------------------------------
        // BUSCADOR (eventos UI)
        // -------------------------------------------------------------
        private async void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if (_buscadorCtrl != null)
                await _buscadorCtrl.ManejarKeyUpAsync(e);
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            _buscadorCtrl?.ManejarKeyDown(e);
        }

        private void lstSugerencias_MouseClick(object sender, MouseEventArgs e)
        {
            _buscadorCtrl?.ManejarClickLista();
        }

        private void lstSugerencias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                _buscadorCtrl?.ManejarClickLista();
        }

        // -------------------------------------------------------------
        // BOTONES
        // -------------------------------------------------------------
        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            _buscadorCtrl?.LimpiarBusqueda();
            rbMostrarHabilitados.Checked = true;

            if (pnlLimpiarFiltros != null)
                pnlLimpiarFiltros.Visible = false;

            RefrescarGrid();
            ActualizarBuscador();
        }

        private async void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            using var frm = new frmAgregarEditarCategoria();

            if (frm.ShowDialog() == DialogResult.OK && !_cerrando && !IsDisposed)
                await CargarCategoriasMaestras();
        }

        private async void btnModificarCategoria_Click(object sender, EventArgs e)
        {
            if (_categoriaSeleccionada != null)
            {
                using var frm = new frmAgregarEditarCategoria(_categoriaSeleccionada);

                if (frm.ShowDialog() == DialogResult.OK && !_cerrando && !IsDisposed)
                    await CargarCategoriasMaestras();
            }
            else
            {
                MessageBox.Show("Seleccione una categoría.", "Aviso", MessageBoxButtons.OK);
            }
        }

        private void dgvCategorias_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count > 0)
                _categoriaSeleccionada = dgvCategorias.SelectedRows[0].DataBoundItem as Categoria;
            else
                _categoriaSeleccionada = null;
        }

        private void btnSeleccionarCategoria_Click(object sender, EventArgs e)
        {
            ConfirmarSeleccion();
        }

        private void dgvCategorias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ConfirmarSeleccion();
        }

        private void ConfirmarSeleccion()
        {
            if (dgvCategorias.SelectedRows.Count > 0)
            {
                CategoriaSeleccionada = dgvCategorias.SelectedRows[0].DataBoundItem as Categoria;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}