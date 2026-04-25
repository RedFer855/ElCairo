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

namespace ModernMenuUI.InterfacesUsuarios.Compras
{
    public partial class frmProveedor : Form
    {
        private readonly ProveedorRepositorio _repositorioProveedor;

        private BuscadorInteractivo<Proveedor> _buscadorProveedores;
        private List<Proveedor> _listaMaestraProveedores = new List<Proveedor>();
        private Proveedor _proveedorSeleccionadoInterno;

        public Proveedor ProveedorSeleccionado { get; private set; }

        private bool _modoForm = false;

        private Action<PostgresChangesResponse> _handlerCambioProveedor;

        public frmProveedor()
        {
            InitializeComponent();
            ConfigurarFormulario();

            _repositorioProveedor = new ProveedorRepositorio();

            ConfigurarRealtime();
        }

        public frmProveedor(bool _modoForm)
        {
            InitializeComponent();
            ConfigurarFormulario();
            this._modoForm = _modoForm;

            _repositorioProveedor = new ProveedorRepositorio();

            FormBorderStyle = FormBorderStyle.None;
            btnSeleccionarProveedor.Visible = false;

            ConfigurarRealtime();
        }

        private void ConfigurarFormulario()
        {
            this.DoubleBuffered = true;
            dgvProveedores.AutoGenerateColumns = false;
        }

        private void ConfigurarRealtime()
        {
            _handlerCambioProveedor = (c) => RecargarInterfazSafe();

            RealtimeManager.OnProveedorChanged += _handlerCambioProveedor;
        }

        private async void frmProveedores_Load(object sender, EventArgs e)
        {
            ConfigurarEventosFiltros();
            await InicializarDatosYBuscador();
        }

        private void frmProveedores_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_handlerCambioProveedor != null)
                    RealtimeManager.OnProveedorChanged -= _handlerCambioProveedor;
            }
            catch { }
        }

        private void RecargarInterfazSafe()
        {
            if (this.IsDisposed) return;
            if (!this.IsHandleCreated) return;

            try
            {
                this.BeginInvoke((MethodInvoker)(async () => await CargarDatosMaestros()));
            }
            catch { }
        }

        private async Task InicializarDatosYBuscador()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                _listaMaestraProveedores = await _repositorioProveedor.ObtenerTodosLosProveedores();

                _buscadorProveedores = new BuscadorInteractivo<Proveedor>(
                    txtBuscar,
                    lstSugerencias,
                    dgvProveedores,
                    _listaMaestraProveedores,

                    (p, term) =>
                    {
                        if (int.TryParse(term, out int id))
                            return p.IdProveedor == id;
                        return false;
                    },

                    (p, term) =>
                        p.NombreProveedor != null &&
                        p.NombreProveedor.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0,

                    (p) => p.NombreProveedor,

                    (busquedaActiva) =>
                    {
                        pnlLimpiarFiltros.Visible = busquedaActiva;
                        if (!busquedaActiva) RefrescarGrid();
                    },

                    (txt) => false
                );

                RefrescarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inicializando datos: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private async Task CargarDatosMaestros()
        {
            try
            {
                _listaMaestraProveedores = await _repositorioProveedor.ObtenerTodosLosProveedores();

                if (_buscadorProveedores != null)
                {
                    _buscadorProveedores.ActualizarDatosMaestros(_listaMaestraProveedores);
                }

                RefrescarGrid();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error recargando proveedores: {ex.Message}");
            }
        }

        private void RefrescarGrid()
        {
            if (_listaMaestraProveedores == null) return;
            this.Cursor = Cursors.WaitCursor;

            IEnumerable<Proveedor> query = _listaMaestraProveedores;

            if (rbMostrarHabilitados.Checked)
            {
                query = query.Where(p => p.EstadoProveedor == true);
            }
            else if (rbMostrarDeshabilitados.Checked)
            {
                query = query.Where(p => p.EstadoProveedor == false);
            }

            var listaFinal = query.ToList();
            dgvProveedores.DataSource = null;
            dgvProveedores.DataSource = listaFinal;

            bool hayFiltrosActivos = !rbMostrarHabilitados.Checked || !string.IsNullOrEmpty(txtBuscar.Text);
            pnlLimpiarFiltros.Visible = hayFiltrosActivos;

            if (dgvProveedores.Rows.Count > 0)
                dgvProveedores.ClearSelection();

            this.Cursor = Cursors.Default;
        }

        private void ConfigurarEventosFiltros()
        {
            rbMostrarTodos.CheckedChanged += (s, e) => { if (rbMostrarTodos.Checked) RefrescarGrid(); };
            rbMostrarHabilitados.CheckedChanged += (s, e) => { if (rbMostrarHabilitados.Checked) RefrescarGrid(); };
            rbMostrarDeshabilitados.CheckedChanged += (s, e) => { if (rbMostrarDeshabilitados.Checked) RefrescarGrid(); };
        }

        private async void txtBuscar_KeyUp(object sender, KeyEventArgs e) => await _buscadorProveedores.ManejarKeyUpAsync(e);

        private async void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            _buscadorProveedores.ManejarKeyDown(e);

            if (e.KeyCode == Keys.Enter && _modoForm && !lstSugerencias.Visible)
            {
                e.Handled = true;
                string nombre = txtBuscar.Text?.Trim();
                if (!string.IsNullOrEmpty(nombre))
                {
                    await IntentarSeleccionarProveedorPorNombreAsync(nombre);
                }
            }
        }

        private void txtBuscar_Leave(object sender, EventArgs e) => _buscadorProveedores.ManejarLeave();
        private void lstSugerencias_MouseClick(object sender, MouseEventArgs e) => _buscadorProveedores.ManejarClickLista();

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            _buscadorProveedores.LimpiarBusqueda();
            rbMostrarHabilitados.Checked = true;
            pnlLimpiarFiltros.Visible = false;
            RefrescarGrid();
        }

        private async void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            frmAgregarEditarProveedor nuevoProv = new frmAgregarEditarProveedor();
            if (nuevoProv.ShowDialog() == DialogResult.OK)
            {
                await CargarDatosMaestros();
            }
        }

        private async void btnEditarProveedor_Click(object sender, EventArgs e)
        {
            if (_proveedorSeleccionadoInterno != null)
            {
                frmAgregarEditarProveedor editarForm = new frmAgregarEditarProveedor(_proveedorSeleccionadoInterno);
                if (editarForm.ShowDialog() == DialogResult.OK)
                {
                    await CargarDatosMaestros();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un proveedor de la lista para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvProveedores_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count > 0)
            {
                _proveedorSeleccionadoInterno = dgvProveedores.SelectedRows[0].DataBoundItem as Proveedor;
            }
            else
            {
                _proveedorSeleccionadoInterno = null;
            }
        }

        private void dgvProveedores_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_modoForm && e.RowIndex >= 0 && e.RowIndex < dgvProveedores.Rows.Count)
            {
                var prov = dgvProveedores.Rows[e.RowIndex].DataBoundItem as Proveedor;
                if (prov != null)
                {
                    _proveedorSeleccionadoInterno = prov;
                    ConfirmarSeleccion();
                }
            }
        }

        private void btnSeleccionarProveedor_Click(object sender, EventArgs e)
        {
            ConfirmarSeleccion();
        }

        private void dgvProveedores_DoubleClick(object sender, EventArgs e)
        {
            ConfirmarSeleccion();
        }

        private void ConfirmarSeleccion()
        {
            if (_proveedorSeleccionadoInterno != null)
            {
                ProveedorSeleccionado = _proveedorSeleccionadoInterno;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un proveedor de la lista.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async Task IntentarSeleccionarProveedorPorNombreAsync(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                var id = await ProveedorRepositorio.ObtenerIdProveedorPorNombreAsync(nombre);
                if (id == null)
                {
                    MessageBox.Show("No se encontró un proveedor con ese nombre.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var prov = _listaMaestraProveedores.FirstOrDefault(p => p.IdProveedor == id.Value);

                if (prov == null)
                {
                    prov = await ProveedorRepositorio.CargarProveedorPorIdAsync(id.Value);
                    if (prov != null) _listaMaestraProveedores.Add(prov);
                }

                if (prov == null)
                {
                    MessageBox.Show("Error cargando la información del proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _proveedorSeleccionadoInterno = prov;
                ConfirmarSeleccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error buscando el proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void lstSugerencias_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void rbMostrarHabilitados_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}