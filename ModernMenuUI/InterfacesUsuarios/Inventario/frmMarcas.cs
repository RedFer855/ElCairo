using CapaDeDatos.Datos;
using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.ClasesUI.Extenciones;
using ModernMenuUI.InterfacesUsuarios.Compras;
using ModernMenuUI.ServiciosUI;
using Supabase.Realtime.PostgresChanges;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI.InterfacesUsuarios.Inventario
{
    public partial class frmMarcas : Form
    {
        private readonly MarcaRepositorio _marcaRepositorio;
        private BuscadorInteractivo<Marca> _buscadorCtrl;
        private List<Marca> _listaMaestraMarcas = new List<Marca>();
        private Marca _marcaSeleccionada;

        private int? _filtroProveedorId = null;

        private Action<PostgresChangesResponse> _handlerCambio;

        public Marca MarcaSeleccionada { get; private set; }

        public frmMarcas()
        {
            InitializeComponent();
            ConfigurarFormulario();

            _marcaRepositorio = new MarcaRepositorio();

            ConfigurarRealtime();
        }

        public frmMarcas(bool tipo)
        {
            InitializeComponent();
            ConfigurarFormulario();

            _marcaRepositorio = new MarcaRepositorio();
            btnSeleccionarMarca.Visible = false;

            ConfigurarRealtime();
        }

        private void ConfigurarFormulario()
        {
            this.DoubleBuffered = true;
            dgvMarcas.AutoGenerateColumns = false;

            ConfigurarEventosUnificados();
        }

        private void ConfigurarRealtime()
        {
            _handlerCambio = (c) => RecargarInterfazSafe();
            RealtimeManager.OnMarcaChanged += _handlerCambio;
        }

        private async void frmMarcas_Load(object sender, EventArgs e)
        {
            await InicializarDatosYBuscador();
        }

        private void frmMarcas_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_handlerCambio != null)
                    RealtimeManager.OnMarcaChanged -= _handlerCambio;
            }
            catch { }
        }

        private void RecargarInterfazSafe()
        {
            if (!this.IsDisposed && this.IsHandleCreated)
            {
                this.BeginInvoke((MethodInvoker)(async () =>
                    await CargarMarcasMaestras()
                ));
            }
        }

        // -------------------------------------------------------------
        // CARGA DE DATOS
        // -------------------------------------------------------------
        private async Task InicializarDatosYBuscador()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _listaMaestraMarcas = await _marcaRepositorio.ObtenerTodasLasMarcas(null);

                InicializarBuscador();
                RefrescarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inicializando datos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private async Task CargarMarcasMaestras()
        {
            try
            {
                _listaMaestraMarcas = await _marcaRepositorio.ObtenerTodasLasMarcas(null);
                RefrescarGrid();
                ActualizarBuscador();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error recargando marcas: {ex.Message}");
            }
        }

        // -------------------------------------------------------------
        // FILTROS COMBINADOS (estado + proveedor)
        // -------------------------------------------------------------
        private List<Marca> ObtenerMarcasSegunFiltro()
        {
            if (_listaMaestraMarcas == null)
                return new List<Marca>();

            IEnumerable<Marca> query = _listaMaestraMarcas;

            if (rbMostrarHablilitados.Checked)
                query = query.Where(m => m.EstadoMarca == true);
            else if (rbMostrarDeshablitados.Checked)
                query = query.Where(m => m.EstadoMarca == false);

            if (_filtroProveedorId.HasValue)
                query = query.Where(m => m.IdProveedor == _filtroProveedorId.Value);

            return query.ToList();
        }

        private void InicializarBuscador()
        {
            _buscadorCtrl = new BuscadorInteractivo<Marca>(
                txtBuscar,
                lstSugerencias,
                dgvMarcas,
                ObtenerMarcasSegunFiltro(),

                // BÚSQUEDA EXACTA
                (m, term) => m.IdMarca.ToString() == term,

                // BÚSQUEDA PARCIAL (sin forzar estado — lo controla el filtro)
                (m, term) =>
                {
                    bool porNombreMarca = m.NombreMarca != null &&
                        m.NombreMarca.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0;

                    bool porProveedor = m.NombreProveedor != null &&
                        m.NombreProveedor.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0;

                    return porNombreMarca || porProveedor;
                },

                // TEXTO MOSTRADO
                (m) => m.NombreMarca,

                // EVENTO FILTRO ACTIVO
                (busquedaActiva) =>
                {
                    if (pnlLimpiarFiltros != null)
                        pnlLimpiarFiltros.Visible = busquedaActiva || HayFiltrosExtras();

                    if (!busquedaActiva)
                        RefrescarGrid();
                },

                // SOLO NÚMEROS
                (txt) => false
            );
        }

        private void ActualizarBuscador()
        {
            if (_buscadorCtrl == null) return;
            _buscadorCtrl.ActualizarDatosMaestros(ObtenerMarcasSegunFiltro());
        }

        private bool HayFiltrosExtras()
        {
            return !rbMostrarHablilitados.Checked || _filtroProveedorId.HasValue;
        }

        // -------------------------------------------------------------
        // GRID
        // -------------------------------------------------------------
        private void RefrescarGrid()
        {
            if (_listaMaestraMarcas == null) return;

            this.Cursor = Cursors.WaitCursor;

            var listaFinal = ObtenerMarcasSegunFiltro();

            dgvMarcas.DataSource = null;
            dgvMarcas.DataSource = listaFinal;

            if (pnlLimpiarFiltros != null)
                pnlLimpiarFiltros.Visible = HayFiltrosExtras();

            if (dgvMarcas.Rows.Count > 0)
                dgvMarcas.ClearSelection();

            this.Cursor = Cursors.Default;
        }

        // -------------------------------------------------------------
        // RADIO BUTTONS
        // -------------------------------------------------------------
        private void ConfigurarEventosUnificados()
        {
            rbMostrarTodos.CheckedChanged += FiltroEstado_Changed;
            rbMostrarHablilitados.CheckedChanged += FiltroEstado_Changed;
            rbMostrarDeshablitados.CheckedChanged += FiltroEstado_Changed;
        }

        private void FiltroEstado_Changed(object sender, EventArgs e)
        {
            if (sender is RadioButton rb && rb.Checked)
            {
                RefrescarGrid();
                ActualizarBuscador();
            }
        }

        // -------------------------------------------------------------
        // BUSCADOR (eventos UI)
        // -------------------------------------------------------------
        private async void txtBuscar_KeyUp(object sender, KeyEventArgs e) =>
            await _buscadorCtrl.ManejarKeyUpAsync(e);

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e) =>
            _buscadorCtrl.ManejarKeyDown(e);

        private void lstSugerencias_MouseClick(object sender, MouseEventArgs e) =>
            _buscadorCtrl.ManejarClickLista();

        private void lstSugerencias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                _buscadorCtrl.ManejarClickLista();
        }

        private void btnBuscar_Click(object sender, EventArgs e) =>
            _buscadorCtrl.ManejarKeyDown(new KeyEventArgs(Keys.Enter));

        // -------------------------------------------------------------
        // BOTONES
        // -------------------------------------------------------------
        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            _buscadorCtrl.LimpiarBusqueda();
            rbMostrarHablilitados.Checked = true;

            _filtroProveedorId = null;
            txtFiltroProveedor.Text = "";

            if (pnlLimpiarFiltros != null)
                pnlLimpiarFiltros.Visible = false;

            RefrescarGrid();
            ActualizarBuscador();
        }

        private async void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            frmAgregarEditarMarca nuevaMarca = new frmAgregarEditarMarca();

            if (nuevaMarca.ShowDialog() == DialogResult.OK)
                await CargarMarcasMaestras();
        }

        private async void btnModificarMarca_Click(object sender, EventArgs e)
        {
            if (_marcaSeleccionada != null)
            {
                frmAgregarEditarMarca editarForm = new frmAgregarEditarMarca(_marcaSeleccionada);

                if (editarForm.ShowDialog() == DialogResult.OK)
                    await CargarMarcasMaestras();
            }
            else
            {
                MessageBox.Show("Seleccione una marca primero.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvMarcas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMarcas.SelectedRows.Count > 0)
                _marcaSeleccionada = dgvMarcas.SelectedRows[0].DataBoundItem as Marca;
            else
                _marcaSeleccionada = null;
        }

        private void btnSeleccionarMarca_Click(object sender, EventArgs e)
        {
            ConfirmarSeleccion();
        }

        private void dgvMarcas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ConfirmarSeleccion();
        }

        private void ConfirmarSeleccion()
        {
            if (dgvMarcas.SelectedRows.Count > 0)
            {
                MarcaSeleccionada = dgvMarcas.SelectedRows[0].DataBoundItem as Marca;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        // -------------------------------------------------------------
        // FILTRO POR PROVEEDOR
        // -------------------------------------------------------------
        private void btnProveedores_Click(object sender, EventArgs e)
        {
            using (var frm = new frmProveedor(true))
            {
                if (frm.ShowDialog() == DialogResult.OK && frm.ProveedorSeleccionado != null)
                {
                    txtFiltroProveedor.Text = frm.ProveedorSeleccionado.NombreProveedor;
                    _filtroProveedorId = frm.ProveedorSeleccionado.IdProveedor;
                    RefrescarGrid();
                    ActualizarBuscador();
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}