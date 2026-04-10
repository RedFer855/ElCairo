using CapaDeDatos.Modelados.Inventario;
using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.ClasesUI.Extenciones;
using ModernMenuUI.ServiciosUI;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI.InterfacesUsuarios.Inventario
{
    public partial class frmBodegas : Form
    {
        private bool _cerrandoFormulario = false;
        private bool _columnasConfiguradas = false;
        private BuscadorInteractivo<Bodega> _buscadorCtrl;
        private readonly BodegaRepositorio bodegaRepositorio = new();
        private List<Bodega> _listaMaestraBodegas = new List<Bodega>();



        private Action<Supabase.Realtime.PostgresChanges.PostgresChangesResponse>? _handlerCambioBD;

        public frmBodegas()
        {
            InitializeComponent();

            dgvProducto.AutoGenerateColumns = false;
            dgvProducto.EnableHeadersVisualStyles = false;
            dgvProducto.ActivarDobleBuffer();

            ConfigurarColumnasGrid();

            this.FormClosed += frmBodegas_FormClosed;

            _handlerCambioBD = (_) => RecargarUI();
            RealtimeManager.OnBodegaChanged += _handlerCambioBD;
        }


        private async void frmBodegas_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            await InicializarDatosYBuscador();
            try
            {
                await RealtimeManager.IniciarAsync();
                await CargarBodegas();
            }
            finally
            {
                if (!IsDisposed)
                    this.Cursor = Cursors.Default;
            }
        }

        private void ConfigurarColumnasGrid()
        {
            if (_columnasConfiguradas) return;

            dgvProducto.Columns.Clear();
            dgvProducto.AutoGenerateColumns = false;

            dgvProducto.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colBodega",
                HeaderText = "Bodega",
                DataPropertyName = "NombreBodega"
            });

            dgvProducto.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colDepartamento",
                HeaderText = "Departamento",
                DataPropertyName = "NombreDepartamento"
            });

            dgvProducto.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colDireccion",
                HeaderText = "Dirección",
                DataPropertyName = "DireccionSucursal"
            });

            dgvProducto.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colTelefono",
                HeaderText = "Teléfono",
                DataPropertyName = "TelefonoSucursal"
            });

            dgvProducto.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                Name = "colEstado",
                HeaderText = "Estado",
                DataPropertyName = "EstadoBodega"
            });

            _columnasConfiguradas = true;
        }

        private async Task InicializarDatosYBuscador()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _listaMaestraBodegas = await bodegaRepositorio.ObtenerTodasLasBodegasAsync();

                _buscadorCtrl = new BuscadorInteractivo<Bodega>(
                    txtBuscar,
                    lstSugerencias,
                    dgvProducto,
                    _listaMaestraBodegas,

                    (m, term) => m.IdBodega.ToString() == term,

                    (m, term) =>
                    {
                        if(!m.EstadoBodega) return false;

                        bool porNombreMarca = m.NombreBodega != null &&
                            m.NombreBodega.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0;

                       // bool porProveedor = m.NombreDepartamento != null &&
                         //   m.NombreDepartamento.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0;

                        return porNombreMarca /*|| porProveedor*/;
                    },

                    (m) => m.NombreBodega,

                    (busquedaActiva) =>
                    {
                        if (pnlLimpiarFiltros != null)
                            pnlLimpiarFiltros.Visible = busquedaActiva;

                        if (!busquedaActiva)
                            RefrescarGrid();
                    },

                    (txt) => false
                );

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

        private void RefrescarGrid()
        {
            if (_listaMaestraBodegas == null) return;

            this.Cursor = Cursors.WaitCursor;

            IEnumerable<Bodega> query = _listaMaestraBodegas;

            if (rbMostrarHabilitados.Checked)
                query = query.Where(m => m.EstadoBodega == true);
            else if (rbMostrarDeshabilitados.Checked)
                query = query.Where(m => m.EstadoBodega == false);

            string textoBusqueda = txtBuscar.Text.Trim();
            if (!string.IsNullOrEmpty(textoBusqueda))
            {
                query = query.Where(m =>
                    (m.NombreBodega != null &&
                     m.NombreBodega.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0)
                    /*||
                    (m.NombreDepartamento != null &&
                     m.NombreDepartamento.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0)*/
                );
            }

            var listaFinal = query.ToList();

            dgvProducto.DataSource = null;
            dgvProducto.DataSource = listaFinal;

            bool hayFiltrosActivos =
                !rbMostrarHabilitados.Checked ||
                !string.IsNullOrEmpty(textoBusqueda);

            if (pnlLimpiarFiltros != null)
                pnlLimpiarFiltros.Visible = hayFiltrosActivos;

            if (dgvProducto.Rows.Count > 0)
                dgvProducto.ClearSelection();

            this.Cursor = Cursors.Default;
        }


        private async Task CargarBodegas()
        {
            if (_cerrandoFormulario || IsDisposed) return;

            var lista = await bodegaRepositorio.obtenerBodegas();

            if (_cerrandoFormulario || IsDisposed) return;

            dgvProducto.SuspendLayout();
            try
            {
                dgvProducto.DataSource = null;
                dgvProducto.DataSource = lista;

                if (dgvProducto.Rows.Count > 0)
                    dgvProducto.ClearSelection();
            }
            finally
            {
                dgvProducto.ResumeLayout();
            }
        }

        private void RecargarUI()
        {
            if (_cerrandoFormulario || !IsHandleCreated || IsDisposed) return;

            try
            {
                BeginInvoke((MethodInvoker)(async () =>
                {
                    if (_cerrandoFormulario || IsDisposed) return;
                    await CargarBodegas();
                }));
            }
            catch
            {
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            Close();
        }

        private async void btnCrearBodega_Click(object sender, EventArgs e)
        {
            using var frm = new frmAgregarEditarBodega();
            var res = frm.ShowDialog();

            if (res == DialogResult.OK && !_cerrandoFormulario && !IsDisposed)
            {
                await CargarBodegas();
            }
        }

        private void frmBodegas_FormClosed(object sender, FormClosedEventArgs e)
        {
            _cerrandoFormulario = true;

            try
            {
                if (_handlerCambioBD != null)
                    RealtimeManager.OnBodegaChanged -= _handlerCambioBD;
            }
            catch
            {
            }

            _handlerCambioBD = null;
            dgvProducto.DataSource = null;
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            _buscadorCtrl?.ManejarKeyDown(e);
        }

        private async void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if (_buscadorCtrl != null)
                await _buscadorCtrl.ManejarKeyUpAsync(e);
        }

        private void lstSugerencias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                _buscadorCtrl.ManejarClickLista();
        }
    }
}