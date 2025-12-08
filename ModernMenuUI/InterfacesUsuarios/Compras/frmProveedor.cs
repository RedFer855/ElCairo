using CapaDeDatos.Datos;
using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.ServiciosUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI.InterfacesUsuarios.Compras
{
    /// <summary>
    /// Formulario para gestionar proveedores.
    /// Proporciona funcionalidades para listar, buscar, filtrar, agregar, editar y seleccionar proveedores con soporte de sincronización en tiempo real.
    /// </summary>
    public partial class frmProveedor : Form
    {
        #region 1. Campos y Dependencias

        /// <summary>
        /// Repositorio responsable de las operaciones de datos para <see cref="Proveedor"/>.
        /// </summary>
        private readonly ProveedorRepositorio _repositorioProveedor;

        /// <summary>
        /// Gestor que mantiene suscripción a cambios en la base de datos en tiempo real para la entidad <see cref="Proveedor"/>.
        /// </summary>
        private readonly GestorRealtime<Proveedor> _gestorRealtime;

        /// <summary>
        /// Control lógico encargado de manejar búsqueda interactiva, sugerencias y navegación.
        /// </summary>
        private BuscadorInteractivo<Proveedor> _buscadorProveedores;

        /// <summary>
        /// Lista maestra en memoria con todos los proveedores cargados desde la fuente de datos.
        /// </summary>
        private List<Proveedor> _listaMaestraProveedores = new List<Proveedor>();

        /// <summary>
        /// Proveedor seleccionado internamente en el DataGridView.
        /// </summary>
        private Proveedor _proveedorSeleccionadoInterno;

        /// <summary>
        /// Proveedor seleccionado que puede ser consultado desde fuera del formulario cuando se cierra con DialogResult.OK.
        /// </summary>
        public Proveedor ProveedorSeleccionado { get; private set; }

        private bool _modoForm = false;

        #endregion

        #region 2. Constructores

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="frmProveedor"/> en modo de administración.
        /// </summary>
        public frmProveedor()
        {
            InitializeComponent();
            ConfigurarFormulario();

            _repositorioProveedor = new ProveedorRepositorio();
            _gestorRealtime = new GestorRealtime<Proveedor>();

            ConfigurarRealtime();
        }

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="frmProveedor"/> en modo selección (diálogo).
        /// </summary>
        /// <param name="tipo">Parámetro que indica el modo; se mantiene para compatibilidad con la sobrecarga.</param>
        public frmProveedor(bool _modoForm)
        {
            InitializeComponent();
            ConfigurarFormulario();
            this._modoForm = _modoForm;
            _repositorioProveedor = new ProveedorRepositorio();
            _gestorRealtime = new GestorRealtime<Proveedor>();

            FormBorderStyle = FormBorderStyle.None;
            btnSeleccionarProveedor.Visible = false;

            ConfigurarRealtime();
        }

        /// <summary>
        /// Configura propiedades visuales y comportamiento inicial del formulario.
        /// </summary>
        private void ConfigurarFormulario()
        {
            this.DoubleBuffered = true;
            dgvProveedores.AutoGenerateColumns = false;
        }

        /// <summary>
        /// Conecta los manejadores del gestor de tiempo real con métodos de recarga segura.
        /// </summary>
        private void ConfigurarRealtime()
        {
            _gestorRealtime.OnCambioBaseDatos += (c) => RecargarInterfazSafe();
            _gestorRealtime.OnReconexionExitosa += () => RecargarInterfazSafe();
        }

        #endregion

        #region 3. Ciclo de Vida

        /// <summary>
        /// Evento que se ejecuta al cargar el formulario; configura filtros, inicializa datos y suscribe al gestor realtime.
        /// </summary>
        private async void frmProveedores_Load(object sender, EventArgs e)
        {
            ConfigurarEventosFiltros();
            await InicializarDatosYBuscador();
            await _gestorRealtime.SuscribirAsync();
        }

        /// <summary>
        /// Evento que se ejecuta cuando el formulario se está cerrando; desuscribe del gestor realtime de forma asíncrona.
        /// </summary>
        private async void frmProveedores_FormClosing(object sender, FormClosingEventArgs e)
        {
            await _gestorRealtime.DesuscribirAsync();
        }

        #endregion

        #region 4. Lógica de Datos y Buscador

        /// <summary>
        /// Recarga la interfaz de manera segura desde hilos que no son el hilo de la UI.
        /// </summary>
        private void RecargarInterfazSafe()
        {
            if (!this.IsDisposed && this.IsHandleCreated)
            {
                this.BeginInvoke((MethodInvoker)(async () => await CargarDatosMaestros()));
            }
        }

        /// <summary>
        /// Inicializa la lista de proveedores desde el repositorio y configura el <see cref="BuscadorInteractivo{Proveedor}"/>.
        /// </summary>
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
                    (p, term) => p.IdProveedor.ToString() == term,
                    (p, term) => p.NombreProveedor != null && p.NombreProveedor.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0,
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
                MessageBox.Show($"Error inicializando datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Carga la lista maestra de proveedores desde el repositorio y actualiza el buscador y el grid.
        /// </summary>
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

        /// <summary>
        /// Refresca la vista del DataGridView aplicando filtros de estado y texto de búsqueda.
        /// </summary>
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

        /// <summary>
        /// Configura manejadores de eventos para los RadioButtons que filtran la lista por estado.
        /// </summary>
        private void ConfigurarEventosFiltros()
        {
            rbMostrarTodos.CheckedChanged += (s, e) => { if (rbMostrarTodos.Checked) RefrescarGrid(); };
            rbMostrarHabilitados.CheckedChanged += (s, e) => { if (rbMostrarHabilitados.Checked) RefrescarGrid(); };
            rbMostrarDeshabilitados.CheckedChanged += (s, e) => { if (rbMostrarDeshabilitados.Checked) RefrescarGrid(); };
        }
        #endregion

        #region 5. Eventos del Buscador y Limpieza

        /// <summary>
        /// Maneja la pulsación de teclas en el cuadro de búsqueda (evento KeyUp) y delega al buscador interactivo.
        /// </summary>
        private async void txtBuscar_KeyUp(object sender, KeyEventArgs e) => await _buscadorProveedores.ManejarKeyUpAsync(e);

        /// <summary>
        /// Maneja eventos KeyDown en el cuadro de búsqueda para navegación y entradas especiales.
        /// Además corrige el bug donde el usuario presiona Enter antes de que aparezcan las sugerencias.
        /// Si estamos en modo selección (modal) y no hay sugerencias visibles, intentamos resolver el nombre directamente.
        /// </summary>
        private async void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            // Si el buscador está manejando la navegación de flechas / enter, delegamos primero.
            _buscadorProveedores.ManejarKeyDown(e);

            // Si el usuario presionó Enter y estamos en modo selección,
            // y las sugerencias NO están visibles (o no se poblaron aún),
            // intentamos buscar por nombre completo y seleccionar automáticamente.
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

        /// <summary>
        /// Maneja el evento Leave del cuadro de búsqueda para ocultar sugerencias y cancelar búsquedas activas.
        /// </summary>
        private void txtBuscar_Leave(object sender, EventArgs e) => _buscadorProveedores.ManejarLeave();

        /// <summary>
        /// Maneja clics en la lista de sugerencias y delega la selección al buscador interactivo.
        /// </summary>
        private void lstSugerencias_MouseClick(object sender, MouseEventArgs e) => _buscadorProveedores.ManejarClickLista();

        /// <summary>
        /// Limpia filtros de búsqueda y restablece la vista de proveedores.
        /// </summary>
        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            _buscadorProveedores.LimpiarBusqueda();
            rbMostrarHabilitados.Checked = true;
            pnlLimpiarFiltros.Visible = false;
            RefrescarGrid();
        }

        #endregion

        #region 6. Acciones CRUD y Selección

        /// <summary>
        /// Abre el formulario para agregar un nuevo proveedor y recarga los datos si la operación fue exitosa.
        /// </summary>
        private async void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            frmAgregarEditarProveedor nuevoProv = new frmAgregarEditarProveedor();
            if (nuevoProv.ShowDialog() == DialogResult.OK)
            {
                await CargarDatosMaestros();
            }
        }

        /// <summary>
        /// Abre el formulario de edición para el proveedor seleccionado. Si no hay selección, muestra un aviso.
        /// </summary>
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

        /// <summary>
        /// Actualiza la referencia interna al proveedor seleccionado cuando cambia la selección del DataGridView.
        /// </summary>
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

        /// <summary>
        /// Maneja el clic del mouse sobre el DataGridView.
        /// Si estamos en modo selección (modal), un único click en una fila selecciona y cierra (comportamiento pedido).
        /// </summary>
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

        /// <summary>
        /// Maneja la acción del botón seleccionar proveedor y confirma la selección actual.
        /// </summary>
        private void btnSeleccionarProveedor_Click(object sender, EventArgs e)
        {
            ConfirmarSeleccion();
        }

        /// <summary>
        /// Maneja el doble clic sobre el DataGridView para confirmar la selección.
        /// </summary>
        private void dgvProveedores_DoubleClick(object sender, EventArgs e)
        {
            ConfirmarSeleccion();
        }

        /// <summary>
        /// Confirma la selección actual y cierra el formulario estableciendo DialogResult.OK.
        /// </summary>
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

        /// <summary>
        /// Intenta resolver un proveedor por nombre (vía repositorio) y si lo encuentra lo selecciona y cierra.
        /// Usado para el caso donde el usuario presionó Enter antes de que cargaran las sugerencias.
        /// </summary>
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

                // buscar en la memoria primero
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

        /// <summary>
        /// Cierra el formulario.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void btnbuscar_Click(object sender, EventArgs e)
        {

        }
    }
}
