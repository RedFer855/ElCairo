using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using CapaDeDatos.Modelados.UsuariosEmpleados;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.ClasesUI.Extenciones;
using ModernMenuUI.InterfacesUsuarios.Usuarios;
using ModernMenuUI.ServiciosUI;
using Supabase.Realtime.PostgresChanges;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI
{
    public partial class frmEmpleado : Form
    {
        private readonly EmpleadoRepositorio _empleadoRepo;
        private readonly ServicioPermisosUI _servicioPermisos;

        private BuscadorInteractivo<Empleado> _buscadorCtrl;
        private List<Empleado> _listaMaestra = new List<Empleado>();
        private Empleado EmpleadoSeleccionado = null;

        private bool? _filtroEstado = null;

        private Action<PostgresChangesResponse> _handlerCambio;

        public frmEmpleado()
        {
            InitializeComponent();

            _empleadoRepo = new EmpleadoRepositorio();
            _servicioPermisos = new ServicioPermisosUI();

            dgvEmpleados.AutoGenerateColumns = false;
            dgvEmpleados.ActivarDobleBuffer();
            dgvEmpleados.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 230, 241);

            ConfigurarEventosUnificados();

            _handlerCambio = (c) => RecargarInterfazSafe();
            RealtimeManager.OnEmpleadoChanged += _handlerCambio;
        }

        private async void frmEmpleado_Load(object sender, EventArgs e)
        {
            await InicializarDatosYBuscador();
        }

        private void frmEmpleado_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_handlerCambio != null)
                    RealtimeManager.OnEmpleadoChanged -= _handlerCambio;
            }
            catch { }
        }

        private async Task InicializarDatosYBuscador()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _listaMaestra = await _empleadoRepo.ObtenerTodosLosEmpleados();

                _buscadorCtrl = new BuscadorInteractivo<Empleado>(
                    txtBuscar,
                    lstSugerencias,
                    dgvEmpleados,
                    _listaMaestra,

                    (emp, txt) =>
                        emp.Id.ToString() == txt ||
                        (emp.DniEmpleado != null && emp.DniEmpleado == txt),

                    (emp, txt) =>
                    {
                        if (!emp.EstadoEmpleado) return false;

                        bool porNombre =
                            (emp.NombreEmpleado + " " + emp.ApellidoEmpleado)
                                .IndexOf(txt, StringComparison.OrdinalIgnoreCase) >= 0;

                        bool porDni =
                            emp.DniEmpleado != null &&
                            emp.DniEmpleado.Contains(txt);

                        return porNombre || porDni;
                    },

                    (emp) => $"{emp.NombreEmpleado} {emp.ApellidoEmpleado}",

                    (busquedaActiva) =>
                    {
                        pnlLimpiarFiltros.Visible = busquedaActiva;
                        if (!busquedaActiva) RefrescarGrid();
                    },

                    (txt) => txt.All(char.IsDigit)
                );

                RefrescarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudieron cargar los empleados.\n\nDetalle: {ex.Message}",
                    "Error de Carga",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally { this.Cursor = Cursors.Default; }
        }

        private async Task CargarEmpleadosMaestros()
        {
            try
            {
                _listaMaestra = await _empleadoRepo.ObtenerTodosLosEmpleados();
                _buscadorCtrl?.ActualizarDatosMaestros(_listaMaestra);
                RefrescarGrid();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error recarga empleados: {ex.Message}");
            }
        }

        private void RecargarInterfazSafe()
        {
            if (!this.IsDisposed && this.IsHandleCreated)
                this.BeginInvoke((MethodInvoker)(async () => await CargarEmpleadosMaestros()));
        }

        private async void txtBuscar_KeyUp(object sender, KeyEventArgs e) => await _buscadorCtrl.ManejarKeyUpAsync(e);
        private void txtBuscar_KeyDown(object sender, KeyEventArgs e) => _buscadorCtrl.ManejarKeyDown(e);
        private void txtBuscar_Leave(object sender, EventArgs e) => _buscadorCtrl.ManejarLeave();
        private void lstSugerencias_MouseClick(object sender, MouseEventArgs e) => _buscadorCtrl.ManejarClickLista();
        private void lstSugerencias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) _buscadorCtrl.ManejarClickLista();
        }
        private void btnBuscar_Click(object sender, EventArgs e) => _buscadorCtrl.ManejarKeyDown(new KeyEventArgs(Keys.Enter));

        private void RefrescarGrid()
        {
            gbxFiltros.Enabled = false;

            var query = _listaMaestra.AsEnumerable();

            if (rbMostrarHabilitados.Checked) query = query.Where(e => e.EstadoEmpleado == true);
            else if (rbMostrarDeshabilitados.Checked) query = query.Where(e => e.EstadoEmpleado == false);

            var listaFinal = query.ToList();
            dgvEmpleados.DataSource = listaFinal;

            bool hayFiltrosExtras = !rbMostrarHabilitados.Checked;
            pnlLimpiarFiltros.Visible = hayFiltrosExtras;

            if (listaFinal.Count > 0)
                dgvEmpleados.ClearSelection();

            gbxFiltros.Enabled = true;
        }

        private void ConfigurarEventosUnificados()
        {
            rbMostrarTodos.CheckedChanged += FiltroEstado_Changed;
            rbMostrarHabilitados.CheckedChanged += FiltroEstado_Changed;
            rbMostrarDeshabilitados.CheckedChanged += FiltroEstado_Changed;
        }

        private void FiltroEstado_Changed(object sender, EventArgs e)
        {
            if (sender is RadioButton rb && rb.Checked)
                RefrescarGrid();
        }

        private void dgvEmpleados_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count > 0)
                EmpleadoSeleccionado = dgvEmpleados.SelectedRows[0].DataBoundItem as Empleado;
            else
                EmpleadoSeleccionado = null;
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            rbMostrarHabilitados.Checked = true;
            _buscadorCtrl.LimpiarBusqueda();
            RefrescarGrid();
        }

        private async void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            var frm = new frmAgregarEditarEmpleado();
            if (frm.ShowDialog() == DialogResult.OK)
                await CargarEmpleadosMaestros();
        }

        private async void btnEditarEmpleado_Click(object sender, EventArgs e)
        {
            if (EmpleadoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un empleado primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var frm = new frmAgregarEditarEmpleado(EmpleadoSeleccionado);
            if (frm.ShowDialog() == DialogResult.OK)
                await CargarEmpleadosMaestros();
        }

        private async void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            if (EmpleadoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un empleado primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                var client = await Conexion.GetClientAsync();
                var authUser = client.Auth.CurrentUser;

                if (authUser == null)
                {
                    MessageBox.Show("No hay sesión activa de Supabase.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var usuarioActualSistema = await client
                    .From<Usuario>()
                    .Where(u => u.Uuid == authUser.Id)
                    .Single();

                this.Cursor = Cursors.Default;

                var frm = new frmCrearUsuario(EmpleadoSeleccionado, usuarioActualSistema);
                frm.ShowDialog();

                await CargarEmpleadosMaestros();
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show($"Error al preparar creación de usuario: {ex.Message}");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            this.Close();
        }

        private void rbMostrarHabilitados_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}