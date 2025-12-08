using CapaDeDatos.Modelados.Ventas;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.InterfacesUsuarios.Ventas;
using ModernMenuUI.ServiciosUI;
using System.Data;
using ModernMenuUI.ClasesUI.Extenciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace ModernMenuUI
{
    public partial class frmClientes : Form
    {
        private readonly ClienteRepositorio _clienteRepositorio;
        private readonly ServiciosUI.ServicioPermisosUI _servicioPermisos;
        private readonly ServicioVerificacionConexion _monitorConexion = new ServicioVerificacionConexion();
        private BuscadorInteractivo<Cliente> _buscadorCtrl;
        private List<Cliente> _listaMaestraClientes = new List<Cliente>();
        private Cliente _clienteSeleccionado;

        public frmClientes()
        {
            InitializeComponent();
            _clienteRepositorio = new ClienteRepositorio();
            _servicioPermisos = new ServiciosUI.ServicioPermisosUI();
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.ActivarDobleBuffer();
            dgvClientes.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 230, 241);
            RegistrarBotonesConPermisos();
            _servicioPermisos.AplicarPermisos();
            ConfigurarEventosUnificados();
            this.Load += frmClientes_Load;
            this.FormClosing += frmClientes_FormClosing;
        }

        private async void frmClientes_Load(object sender, EventArgs e)
        {
            _monitorConexion.EstadoDeRedCambiado += MonitorConexion_EstadoDeRedCambiado;
            await InicializarDatosYBuscador();
        }

        private async void frmClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            try { _monitorConexion.EstadoDeRedCambiado -= MonitorConexion_EstadoDeRedCambiado; } catch { }
            await Task.CompletedTask;
        }

        private async Task InicializarDatosYBuscador()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                _listaMaestraClientes = await _clienteRepositorio.ObtenerTodosLosClientes();
                _buscadorCtrl = new BuscadorInteractivo<Cliente>(
                    txtBuscar,
                    lstSugerencias,
                    dgvClientes,
                    _listaMaestraClientes,
                    (c, txt) => !string.IsNullOrWhiteSpace(c.DniCliente) && c.DniCliente.Equals(txt, StringComparison.OrdinalIgnoreCase),
                    (c, txt) =>
                    {
                        var display = $"{c.NombreCliente} {c.DniCliente} {c.CorreoCliente} {c.TelefonoCliente}".ToLowerInvariant();
                        return display.Contains(txt.ToLowerInvariant());
                    },
                    (c) => $"{c.NombreCliente} {(string.IsNullOrWhiteSpace(c.DniCliente) ? "" : $" - {c.DniCliente}")}",
                    (busquedaActiva) =>
                    {
                        pnlLimpiarFiltros.Visible = busquedaActiva;
                        if (!busquedaActiva) RefrescarGrid();
                    },
                    (txt) => txt.All(char.IsDigit) && txt.Length >= 6 && txt.Length <= 13
                );
                RefrescarGrid();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error carga clientes: {ex.Message}");
                MessageBox.Show($"No se pudieron cargar los clientes.\nDetalle: {ex.Message}", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { this.Cursor = Cursors.Default; }
        }

        private async Task CargarClientesMaestros()
        {
            try
            {
                _listaMaestraClientes = await _clienteRepositorio.ObtenerTodosLosClientes();
                _buscadorCtrl?.ActualizarDatosMaestros(_listaMaestraClientes);
                RefrescarGrid();
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine($"Error recarga clientes: {ex.Message}"); }
        }

        private void RecargarInterfazSafe()
        {
            if (!this.IsDisposed && this.IsHandleCreated)
                this.BeginInvoke((MethodInvoker)(async () => await CargarClientesMaestros()));
        }

        private async void txtBuscar_KeyUp(object sender, KeyEventArgs e) => await _buscadorCtrl.ManejarKeyUpAsync(e);
        private void txtBuscar_KeyDown(object sender, KeyEventArgs e) => _buscadorCtrl.ManejarKeyDown(e);
        private void txtBuscar_Leave(object sender, EventArgs e) => _buscadorCtrl.ManejarLeave();
        private void lstSugerencias_KeyDown(object sender, KeyEventArgs e) { if (e.KeyCode == Keys.Enter) _buscadorCtrl.ManejarClickLista(); }
        private void btnBuscar_Click(object sender, EventArgs e) => _buscadorCtrl.ManejarKeyDown(new KeyEventArgs(Keys.Enter));

        private void RefrescarGrid()
        {
            try { gbxEstado.Enabled = false; } catch { }
            var query = _listaMaestraClientes.AsEnumerable();
            if (rbHabilitados != null && rbHabilitados.Checked) query = query.Where(c => c.EstadoCliente == true);
            else if (rbDeshabilitados != null && rbDeshabilitados.Checked) query = query.Where(c => c.EstadoCliente == false);
            var listaFinal = query.ToList();
            dgvClientes.DataSource = listaFinal;

            bool hayFiltrosExtras =
                (rbDeshabilitados != null && rbDeshabilitados.Checked) ||
                (rbTodos != null && rbTodos.Checked);

            pnlLimpiarFiltros.Visible = hayFiltrosExtras;

            if (listaFinal.Count > 0) dgvClientes.ClearSelection();
            try { gbxEstado.Enabled = true; } catch { }
        }

        private void ConfigurarEventosUnificados()
        {
            try
            {
                if (rbTodos != null) rbTodos.CheckedChanged += FiltroEstado_Changed;
                if (rbHabilitados != null) rbHabilitados.CheckedChanged += FiltroEstado_Changed;
                if (rbDeshabilitados != null) rbDeshabilitados.CheckedChanged += FiltroEstado_Changed;
            }
            catch { }
        }

        private void FiltroEstado_Changed(object sender, EventArgs e)
        {
            if (sender is RadioButton rb && rb.Checked) RefrescarGrid();
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
                _clienteSeleccionado = dgvClientes.SelectedRows[0].DataBoundItem as Cliente;
            else
                _clienteSeleccionado = null;
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            try { rbHabilitados.Checked = true; } catch { }
            _buscadorCtrl?.LimpiarBusqueda();
            RefrescarGrid();
        }

        private async void btnCliente_Click(object sender, EventArgs e)
        {
            var frm = new frmAgregarEditarClientes(habilitarCorreo: true);
            if (frm.ShowDialog() == DialogResult.OK) await CargarClientesMaestros();
        }

        private async void btnVerCliente_Click(object sender, EventArgs e)
        {
            if (_clienteSeleccionado == null)
            {
                MessageBox.Show("Seleccione un cliente primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var frm = new frmAgregarEditarClientes(_clienteSeleccionado);
            if (frm.ShowDialog() == DialogResult.OK) await CargarClientesMaestros();
        }

        private void RegistrarBotonesConPermisos()
        {
            _servicioPermisos.RegistrarBoton(btnAgregarCliente, "create_venta");
            _servicioPermisos.RegistrarBoton(btnVerCliente, "select_venta");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            this.Close();
        }

        private async void MonitorConexion_EstadoDeRedCambiado(NetworkStatus status)
        {
            if (!this.IsHandleCreated || this.IsDisposed) return;
            if (status == NetworkStatus.Internet)
            {
                this.BeginInvoke((MethodInvoker)(async () =>
                {
                    if (!this.IsDisposed) await CargarClientesMaestros();
                }));
            }
        }
    }
}
