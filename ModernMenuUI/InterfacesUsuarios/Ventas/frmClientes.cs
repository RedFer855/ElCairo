using CapaDeDatos.Modelados.Ventas;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.ClasesUI.Extenciones;
using ModernMenuUI.InterfacesUsuarios.Ventas;
using ModernMenuUI.ServiciosUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI
{
    /// <summary>
    /// Formulario principal de mantenimiento de Clientes.
    /// Permite:
    /// - Listar clientes
    /// - Filtrar por estado (Habilitado / Deshabilitado / Todos)
    /// - Buscar de forma interactiva
    /// - Agregar, ver o seleccionar clientes
    /// - Sincronización en tiempo real mediante Supabase Realtime
    /// - Modo selección para integrarse con ventas
    /// </summary>
    public partial class frmClientes : Form
    {
        // ============================================================
        // 1. CAMPOS Y DEPENDENCIAS
        // ============================================================

        /// <summary>
        /// Indica si el formulario está funcionando como selector (para ventas).
        /// </summary>
        private readonly bool _modoSeleccion = false;

        /// <summary>
        /// Repositorio encargado de acceder a la tabla de Clientes.
        /// </summary>
        private readonly ClienteRepositorio _clienteRepositorio;

        /// <summary>
        /// Servicio que determina si ciertos botones deben habilitarse o no.
        /// </summary>
        private readonly ServiciosUI.ServicioPermisosUI _servicioPermisos;

        /// <summary>
        /// Controlador de eventos Realtime para refrescar clientes automáticamente.
        /// </summary>
        private readonly GestorRealtime<Cliente> _gestorRealtime;

        /// <summary>
        /// Controlador de búsqueda inteligente para clientes.
        /// </summary>
        private BuscadorInteractivo<Cliente> _buscadorCtrl;

        private List<Cliente> _listaMaestraClientes = new List<Cliente>();
        private Cliente _clienteSeleccionado;

        /// <summary>
        /// Cliente devuelto al formulario llamante cuando está en modo selección.
        /// </summary>
        public Cliente _clienteSeleccionadoFinal;



        // ============================================================
        // 2. CONSTRUCTORES
        // ============================================================

        /// <summary>
        /// Constructor normal del módulo de clientes.
        /// </summary>
        public frmClientes()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.None;

            _clienteRepositorio = new ClienteRepositorio();
            _servicioPermisos = new ServiciosUI.ServicioPermisosUI();
            _gestorRealtime = new GestorRealtime<Cliente>();

            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.ActivarDobleBuffer();
            dgvClientes.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 230, 241);

            RegistrarBotonesConPermisos();
            _servicioPermisos.AplicarPermisos();

            ConfigurarEventosUnificados();

            // Eventos Realtime
            _gestorRealtime.OnCambioBaseDatos += (c) => RecargarInterfazSafe();
            _gestorRealtime.OnReconexionExitosa += () => RecargarInterfazSafe();

            this.Load += frmClientes_Load;
            this.FormClosing += frmClientes_FormClosing;
        }

        /// <summary>
        /// Constructor en modo selección de clientes (para ventas).
        /// </summary>
        public frmClientes(bool _modoSeleccion)
        {
            InitializeComponent();
            this._modoSeleccion = _modoSeleccion;
            btnSeleccionarCliente.Visible = _modoSeleccion;

            _clienteRepositorio = new ClienteRepositorio();
            _servicioPermisos = new ServiciosUI.ServicioPermisosUI();
            _gestorRealtime = new GestorRealtime<Cliente>();

            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.ActivarDobleBuffer();
            dgvClientes.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 230, 241);

            RegistrarBotonesConPermisos();
            _servicioPermisos.AplicarPermisos();

            ConfigurarEventosUnificados();

            _gestorRealtime.OnCambioBaseDatos += (c) => RecargarInterfazSafe();
            _gestorRealtime.OnReconexionExitosa += () => RecargarInterfazSafe();

            this.Load += frmClientes_Load;
            this.FormClosing += frmClientes_FormClosing;
        }



        // ============================================================
        // 3. EVENTOS PRINCIPALES DEL FORMULARIO
        // ============================================================

        /// <summary>
        /// Evento Load: inicializa datos, búsqueda y conexión realtime.
        /// </summary>
        private async void frmClientes_Load(object sender, EventArgs e)
        {
            await InicializarDatosYBuscador();
            await _gestorRealtime.SuscribirAsync();
        }

        /// <summary>
        /// Evento FormClosing: desuscribe del canal realtime correctamente.
        /// </summary>
        private async void frmClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            await _gestorRealtime.DesuscribirAsync();
        }



        // ============================================================
        // 4. CARGA DE INFORMACIÓN Y BÚSQUEDA
        // ============================================================

        /// <summary>
        /// Carga la lista completa de clientes y configura el buscador interactivo.
        /// </summary>
        private async Task InicializarDatosYBuscador()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // Datos principales
                _listaMaestraClientes = await _clienteRepositorio.ObtenerTodosLosClientes();

                // Configuración del Buscador Interactivo
                _buscadorCtrl = new BuscadorInteractivo<Cliente>(
                    txtBuscar,
                    lstSugerencias,
                    dgvClientes,
                    _listaMaestraClientes,

                    // Coincidencia exacta por DNI
                    (c, txt) =>
                        !string.IsNullOrWhiteSpace(c.DniCliente) &&
                        c.DniCliente.Equals(txt, StringComparison.OrdinalIgnoreCase),

                    // Coincidencia parcial por nombre, teléfono o correo
                    (c, txt) =>
                    {
                        var display = $"{c.NombreCliente} {c.DniCliente} {c.CorreoCliente} {c.TelefonoCliente}".ToLowerInvariant();
                        return display.Contains(txt.ToLowerInvariant());
                    },

                    // Cómo se muestra cada sugerencia
                    (c) => $"{c.NombreCliente} {(string.IsNullOrWhiteSpace(c.DniCliente) ? "" : $" - {c.DniCliente}")}",

                    // Mostrar/Ocultar panel de filtros
                    (busquedaActiva) =>
                    {
                        pnlLimpiarFiltros.Visible = busquedaActiva;
                        if (!busquedaActiva) RefrescarGrid();
                    },

                    // Validación del texto de búsqueda
                    (txt) => txt.All(char.IsDigit) && txt.Length >= 6 && txt.Length <= 13
                );

                RefrescarGrid();
            }
            finally { this.Cursor = Cursors.Default; }
        }

        /// <summary>
        /// Recarga lista maestra y actualiza el buscador.
        /// </summary>
        private async Task CargarClientesMaestros()
        {
            _listaMaestraClientes = await _clienteRepositorio.ObtenerTodosLosClientes();
            _buscadorCtrl?.ActualizarDatosMaestros(_listaMaestraClientes);
            RefrescarGrid();
        }

        /// <summary>
        /// Solicita refrescar la interfaz desde el hilo principal (safe-thread).
        /// </summary>
        private void RecargarInterfazSafe()
        {
            if (!this.IsDisposed && this.IsHandleCreated)
                this.BeginInvoke((MethodInvoker)(async () => await CargarClientesMaestros()));
        }



        // ============================================================
        // 5. BÚSQUEDA: EVENTOS DEL BUSCADOR
        // ============================================================

        private async void txtBuscar_KeyUp(object sender, KeyEventArgs e) => await _buscadorCtrl.ManejarKeyUpAsync(e);
        private void txtBuscar_KeyDown(object sender, KeyEventArgs e) => _buscadorCtrl.ManejarKeyDown(e);
        private void txtBuscar_Leave(object sender, EventArgs e) => _buscadorCtrl.ManejarLeave();
        private void lstSugerencias_KeyDown(object sender, KeyEventArgs e) { if (e.KeyCode == Keys.Enter) _buscadorCtrl.ManejarClickLista(); }
        private void btnBuscar_Click(object sender, EventArgs e) => _buscadorCtrl.ManejarKeyDown(new KeyEventArgs(Keys.Enter));
        private void lstSugerencias_MouseClick(object sender, MouseEventArgs e) => _buscadorCtrl?.ManejarClickLista();



        // ============================================================
        // 6. FILTRADO Y GRID
        // ============================================================

        /// <summary>
        /// Refresca la tabla según estado seleccionado y búsqueda activa.
        /// </summary>
        private void RefrescarGrid()
        {
            try { gbxEstado.Enabled = false; } catch { }

            var query = _listaMaestraClientes.AsEnumerable();

            if (rbHabilitados != null && rbHabilitados.Checked)
                query = query.Where(c => c.EstadoCliente == true);
            else if (rbDeshabilitados != null && rbDeshabilitados.Checked)
                query = query.Where(c => c.EstadoCliente == false);

            var listaFinal = query.ToList();
            dgvClientes.DataSource = listaFinal;

            pnlLimpiarFiltros.Visible =
                (rbDeshabilitados != null && rbDeshabilitados.Checked) ||
                (rbTodos != null && rbTodos.Checked);

            if (listaFinal.Count > 0)
                dgvClientes.ClearSelection();

            try { gbxEstado.Enabled = true; } catch { }
        }

        /// <summary>
        /// Une los radioButtons al mismo evento para simplificar lógica.
        /// </summary>
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
            if (sender is RadioButton rb && rb.Checked)
                RefrescarGrid();
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            _clienteSeleccionado =
                dgvClientes.SelectedRows.Count > 0
                ? dgvClientes.SelectedRows[0].DataBoundItem as Cliente
                : null;
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            try { rbHabilitados.Checked = true; } catch { }
            _buscadorCtrl?.LimpiarBusqueda();
            RefrescarGrid();
        }



        // ============================================================
        // 7. CRUD DE CLIENTES
        // ============================================================

        /// <summary>
        /// Abre el formulario para agregar un cliente nuevo.
        /// </summary>
        private async void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            var frm = new frmAgregarEditarClientes(habilitarCorreo: true);
            if (frm.ShowDialog() == DialogResult.OK)
                await CargarClientesMaestros();
        }

        /// <summary>
        /// Permite ver o editar un cliente existente.
        /// </summary>
        private async void btnVerCliente_Click(object sender, EventArgs e)
        {
            if (_clienteSeleccionado == null)
            {
                MessageBox.Show("Seleccione un cliente primero.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var frm = new frmAgregarEditarClientes(_clienteSeleccionado);
            if (frm.ShowDialog() == DialogResult.OK)
                await CargarClientesMaestros();
        }



        // ============================================================
        // 8. PERMISOS Y BOTONES
        // ============================================================

        /// <summary>
        /// Registra qué botones deben evaluarse respecto a permisos.
        /// </summary>
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



        // ============================================================
        // 9. MODO SELECCIÓN (Para módulo de ventas)
        // ============================================================

        /// <summary>
        /// Devuelve el cliente seleccionado al formulario padre.
        /// </summary>
        private void btnSeleccionarCliente_Click(object sender, EventArgs e)
        {
            if (_clienteSeleccionado == null)
            {
                MessageBox.Show("Seleccione un cliente de la tabla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _clienteSeleccionadoFinal = _clienteSeleccionado;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_modoSeleccion == true)
            {
                if (_clienteSeleccionado == null)
                {
                    MessageBox.Show("Seleccione un cliente de la tabla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _clienteSeleccionadoFinal = _clienteSeleccionado;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
