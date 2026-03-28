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
            //CategoriaSeleccionada = null;
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

        private async Task InicializarDatosYBuscador()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _listaCompletaCategorias = await _categoriaRepositorio.ObtenerTodasLasCategorias(null);

                _buscadorCtrl?.Dispose();
                _buscadorCtrl = new BuscadorInteractivo<Categoria>(
                    txtBuscar,
                    lstSugerencias,
                    dgvCategorias,
                    _listaCompletaCategorias,
                    (c, t) => c.IdCategoria.ToString() == t,
                    (c, t) => c.NombreCategoria != null && c.NombreCategoria.IndexOf(t, StringComparison.OrdinalIgnoreCase) >= 0,
                    (c) => c.NombreCategoria,
                    (b) =>
                    {
                        if (pnlLimpiarFiltros != null)
                            pnlLimpiarFiltros.Visible = b;

                        if (!b)
                            RefrescarGrid();
                    },
                    (txt) => false
                );

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

            if (_buscadorCtrl != null)
                _buscadorCtrl.ActualizarDatosMaestros(_listaCompletaCategorias);

            RefrescarGrid();
        }

        private void RefrescarGrid()
        {
            if (_cerrando || IsDisposed || _listaCompletaCategorias == null)
                return;

            this.Cursor = Cursors.WaitCursor;

            try
            {
                IEnumerable<Categoria> query = _listaCompletaCategorias;

                if (rbMostrarHabilitados.Checked)
                    query = query.Where(c => c.EstadoCategoria);
                else if (rbMostrarDeshabilitados.Checked)
                    query = query.Where(c => !c.EstadoCategoria);

                string texto = txtBuscar.Text.Trim();

                if (!string.IsNullOrWhiteSpace(texto))
                {
                    query = query.Where(c =>
                        !string.IsNullOrWhiteSpace(c.NombreCategoria) &&
                        c.NombreCategoria.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0);
                }

                var listaFinal = query.ToList();

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
                                      rbMostrarDeshabilitados.Checked ||
                                      !string.IsNullOrWhiteSpace(texto);

                    pnlLimpiarFiltros.Visible = hayFiltros;
                }
            }
            finally
            {
                if (!IsDisposed)
                    this.Cursor = Cursors.Default;
            }
        }

        private void ConfigurarEventosUnificados()
        {
            rbMostrarTodos.CheckedChanged += (s, e) =>
            {
                if (((RadioButton)s).Checked)
                    RefrescarGrid();
            };

            rbMostrarHabilitados.CheckedChanged += (s, e) =>
            {
                if (((RadioButton)s).Checked)
                    RefrescarGrid();
            };

            rbMostrarDeshabilitados.CheckedChanged += (s, e) =>
            {
                if (((RadioButton)s).Checked)
                    RefrescarGrid();
            };
        }

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

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            _buscadorCtrl?.LimpiarBusqueda();
            rbMostrarHabilitados.Checked = true;

            if (pnlLimpiarFiltros != null)
                pnlLimpiarFiltros.Visible = false;

            RefrescarGrid();
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