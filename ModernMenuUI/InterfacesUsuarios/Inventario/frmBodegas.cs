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
                        if (!m.EstadoBodega) return false;

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

            IEnumerable<Bodega> query = _listaMaestraBodegas;

            // 🔹 Filtro por estado
            if (rbMostrarHabilitados.Checked)
                query = query.Where(m => m.EstadoBodega);
            else if (rbMostrarDeshabilitados.Checked)
                query = query.Where(m => !m.EstadoBodega);

            // 🔹 Filtro por búsqueda
            string textoBusqueda = txtBuscar.Text.Trim();
            if (!string.IsNullOrEmpty(textoBusqueda))
            {
                query = query.Where(m =>
                    m.NombreBodega != null &&
                    m.NombreBodega.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0
                );
            }

            var listaFinal = query.ToList();

            dgvProducto.DataSource = null;
            dgvProducto.DataSource = listaFinal;

            if (dgvProducto.Rows.Count > 0)
                dgvProducto.ClearSelection();

            if (pnlLimpiarFiltros != null)
                pnlLimpiarFiltros.Visible =
                    !rbMostrarHabilitados.Checked ||
                    !string.IsNullOrEmpty(textoBusqueda);
        }


        private async Task CargarBodegas(CancellationToken ct = default)
        {
            if (_cerrandoFormulario || IsDisposed) return;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (var cts = CancellationTokenSource.CreateLinkedTokenSource(ct))
                {
                    cts.CancelAfter(TimeSpan.FromSeconds(10));

                    // 🔹 Guardar lista maestra
                    _listaMaestraBodegas = await bodegaRepositorio.ObtenerTodasLasBodegasAsync();
                }

                if (_cerrandoFormulario || IsDisposed) return;

                // 🔹 Actualizar buscador + refrescar con filtros
                _buscadorCtrl?.ActualizarDatosMaestros(_listaMaestraBodegas);
                RefrescarGrid();

                if (dgvProducto.Rows.Count > 0)
                    dgvProducto.ClearSelection();
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("No se pudo conectar con el servidor (tiempo de espera agotado).",
                                "Error de Red", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar bodegas: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!IsDisposed)
                    this.Cursor = Cursors.Default;
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

        private void rbMostrarHabilitados_CheckedChanged(object sender, EventArgs e)
        {
            RefrescarGrid();
        }

        private void rbMostrarDeshabilitados_CheckedChanged(object sender, EventArgs e)
        {
            RefrescarGrid();
        }

        private void rbMostrarTodos_CheckedChanged(object sender, EventArgs e)
        {
            RefrescarGrid();
        }
    }
}