using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using CapaDeDatos.Modelados.UsuariosEmpleados;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.ClasesUI.Extenciones;
using ModernMenuUI.InterfacesUsuarios.Usuarios;
using ModernMenuUI.ServiciosUI;
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
        #region 1. Campos y Dependencias
        private readonly EmpleadoRepositorio _empleadoRepo;
        private readonly ServicioPermisosUI _servicioPermisos;
        private readonly GestorRealtime<Empleado> _gestorRealtime;

        private BuscadorInteractivo<Empleado> _buscadorCtrl;

        private List<Empleado> _listaMaestra = new List<Empleado>();
        private Empleado EmpleadoSeleccionado = null;

        private bool? _filtroEstado = null;
        #endregion

        #region 2. Constructor y Load
        public frmEmpleado()
        {
            InitializeComponent();

            // A. Inicialización
            _empleadoRepo = new EmpleadoRepositorio();
            _servicioPermisos = new ServicioPermisosUI();
            _gestorRealtime = new GestorRealtime<Empleado>();

            // B. Configuración Grid 
            dgvEmpleados.AutoGenerateColumns = false;
            dgvEmpleados.ActivarDobleBuffer();
            dgvEmpleados.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 230, 241);

            // C. Permisos y Eventos (Mantenido comentado por solicitud)
            //RegistrarBotonesConPermisos();
            //_servicioPermisos.AplicarPermisos();

            ConfigurarEventosUnificados();

            // D. Realtime -> eventos
            _gestorRealtime.OnCambioBaseDatos += (c) => RecargarInterfazSafe();
            _gestorRealtime.OnReconexionExitosa += () => RecargarInterfazSafe();
        }

        private async void frmEmpleado_Load(object sender, EventArgs e)
        {
            await InicializarDatosYBuscador();
            await _gestorRealtime.SuscribirAsync();
        }

        private async void frmEmpleado_FormClosing(object sender, FormClosingEventArgs e)
        {
            await _gestorRealtime.DesuscribirAsync();
        }
        #endregion

        #region 3. Carga y Realtime
        private async Task InicializarDatosYBuscador()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _listaMaestra = await _empleadoRepo.ObtenerTodosLosEmpleados();

                // Buscador interactivo configurado
                _buscadorCtrl = new BuscadorInteractivo<Empleado>(
                    txtBuscar,
                    lstSugerencias,
                    dgvEmpleados,
                    _listaMaestra,

                    // 1. CRITERIO EXACTO (Al dar Enter o Clic en botón buscar)
                    // Busca por ID (int) o por DNI (string exacto)
                    (emp, txt) => emp.Id.ToString() == txt || (emp.DniEmpleado != null && emp.DniEmpleado == txt),

                    // 2. CRITERIO PARCIAL (Filtrado mientras escribes)
                    // Busca coincidencias en Nombre, Apellido O en el DNI (Contains)
                    (emp, txt) => (emp.NombreEmpleado + " " + emp.ApellidoEmpleado).IndexOf(txt, StringComparison.OrdinalIgnoreCase) >= 0
                               || (emp.DniEmpleado != null && emp.DniEmpleado.Contains(txt)),

                    // 3. DISPLAY (Lo que se ve en la lista de sugerencias)
                    (emp) => $"{emp.NombreEmpleado} {emp.ApellidoEmpleado}",

                    // 4. ACCION VISUAL (Mostrar/Ocultar panel de filtros)
                    (busquedaActiva) => {
                        pnlLimpiarFiltros.Visible = busquedaActiva;
                        if (!busquedaActiva) RefrescarGrid();
                    },

                    // 5. VALIDACION DE ENTRADA (Permite dígitos para ID/DNI)
                    // Nota: Si tus DNI tienen guiones, quita el .All(char.IsDigit) o adáptalo.
                    (txt) => txt.All(char.IsDigit)
                );

                RefrescarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudieron cargar los empleados.\nPosible causa: Internet inestable o servidor.\n\nDetalle: {ex.Message}",
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
        #endregion

        #region 4. Búsqueda
        private async void txtBuscar_KeyUp(object sender, KeyEventArgs e) => await _buscadorCtrl.ManejarKeyUpAsync(e);
        private void txtBuscar_KeyDown(object sender, KeyEventArgs e) => _buscadorCtrl.ManejarKeyDown(e);
        private void txtBuscar_Leave(object sender, EventArgs e) => _buscadorCtrl.ManejarLeave();
        private void lstSugerencias_MouseClick(object sender, MouseEventArgs e) => _buscadorCtrl.ManejarClickLista();
        private void lstSugerencias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) _buscadorCtrl.ManejarClickLista();
        }
        private void btnBuscar_Click(object sender, EventArgs e) => _buscadorCtrl.ManejarKeyDown(new KeyEventArgs(Keys.Enter));
        #endregion

        #region 5. Filtrado y Grid
        private void RefrescarGrid()
        {
            gbxFiltros.Enabled = false;

            var query = _listaMaestra.AsEnumerable();

            if (rbMostrarHabilitados.Checked) query = query.Where(e => e.EstadoEmpleado == true);
            else if (rbMostrarDeshabilitados.Checked) query = query.Where(e => e.EstadoEmpleado == false);

            var listaFinal = query.ToList();
            dgvEmpleados.DataSource = listaFinal;

            bool hayFiltrosExtras = !rbMostrarHabilitados.Checked;
            if (hayFiltrosExtras) pnlLimpiarFiltros.Visible = true;

            if (listaFinal.Count > 0) dgvEmpleados.ClearSelection();
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
            if (sender is RadioButton rb && rb.Checked) RefrescarGrid();
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
        #endregion

        #region 6. CRUD y Acciones
        private async void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            var frm = new frmAgregarEditarEmpleado();
            if (frm.ShowDialog() == DialogResult.OK) await CargarEmpleadosMaestros();
        }

        private async void btnEditarEmpleado_Click(object sender, EventArgs e)
        {
            if (EmpleadoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un empleado primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var frm = new frmAgregarEditarEmpleado(EmpleadoSeleccionado);
            if (frm.ShowDialog() == DialogResult.OK) await CargarEmpleadosMaestros();
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
        #endregion

        #region 7. UI y Permisos
        private void btnSalir_Click(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            this.Close();
        }

        //private void RegistrarBotonesConPermisos()
        //{
        //    _servicioPermisos.RegistrarBoton(btnAgregarEmpleado, "insert_empleados");
        //    _servicioPermisos.RegistrarBoton(btnEditarEmpleado, "update_empleados");
        //    _servicioPermisos.RegistrarBoton(btnCrearUsuario, "insert_usuarios");
        //}
        #endregion
    }
}