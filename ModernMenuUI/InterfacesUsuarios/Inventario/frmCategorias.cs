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

namespace ModernMenuUI.InterfacesUsuarios.Inventario
{
    /// <summary>
    /// Formulario para gestionar categorías de productos.
    /// Permite visualizar, buscar, filtrar, agregar y modificar categorías con sincronización en tiempo real.
    /// </summary>
    public partial class frmCategorias : Form
    {
        /// <summary>
        /// Repositorio de acceso a datos para operaciones CRUD de categorías.
        /// </summary>
        private readonly CategoriaRepositorio _categoriaRepositorio;

        /// <summary>
        /// Gestor de suscripción a cambios en tiempo real de la tabla de categorías.
        /// </summary>
        private readonly GestorRealtime<Categoria> _gestorRealtime;

        /// <summary>
        /// Control buscador interactivo que maneja búsqueda, filtrado y sugerencias.
        /// </summary>
        private BuscadorInteractivo<Categoria> _buscadorCtrl;

        /// <summary>
        /// Lista maestra que contiene todas las categorías cargadas desde la base de datos.
        /// </summary>
        private List<Categoria> _listaCompletaCategorias = new List<Categoria>();

        /// <summary>
        /// Categoría actualmente seleccionada en el DataGridView.
        /// </summary>
        private Categoria _categoriaSeleccionada;

        /// <summary>
        /// Obtiene la categoría seleccionada cuando el formulario se cierra con DialogResult.OK.
        /// </summary>
        public Categoria CategoriaSeleccionada { get; private set; }

        /// <summary>
        /// Inicializa una nueva instancia de frmCategorias para gestión administrativa.
        /// Configura controles, repositorios y gestor de tiempo real.
        /// </summary>
        public frmCategorias()
        {
            InitializeComponent();
            ConfigurarFormulario();
            _categoriaRepositorio = new CategoriaRepositorio();
            _gestorRealtime = new GestorRealtime<Categoria>();

            btnAgregarCategoria.Visible = false;
            btnModificarCategoria.Visible = false;
            if (pnlLimpiarFiltros != null) pnlLimpiarFiltros.Visible = false;

            ConfigurarRealtime();
        }

        /// <summary>
        /// Inicializa una nueva instancia de frmCategorias para selección (diálogo modal).
        /// Oculta bordes de formulario y botones de administración.
        /// </summary>
        /// <param name="tipo">Indicador de modo selección; no se usa directamente pero diferencia la sobrecarga.</param>
        public frmCategorias(bool tipo)
        {
            InitializeComponent();
            ConfigurarFormulario();
            _categoriaRepositorio = new CategoriaRepositorio();
            _gestorRealtime = new GestorRealtime<Categoria>();

            FormBorderStyle = FormBorderStyle.None;
            btnSeleccionarCategoria.Visible = false;
            if (pnlLimpiarFiltros != null) pnlLimpiarFiltros.Visible = false;

            ConfigurarRealtime();
        }

        /// <summary>
        /// Configura las propiedades visuales y eventos generales del formulario.
        /// </summary>
        private void ConfigurarFormulario()
        {
            this.DoubleBuffered = true;
            dgvCategorias.AutoGenerateColumns = false;
            ConfigurarEventosUnificados();
        }

        /// <summary>
        /// Configura los eventos del gestor de tiempo real para recargar datos al detectar cambios.
        /// </summary>
        private void ConfigurarRealtime()
        {
            _gestorRealtime.OnCambioBaseDatos += (c) => RecargarInterfazSafe();
            _gestorRealtime.OnReconexionExitosa += () => RecargarInterfazSafe();
        }

        /// <summary>
        /// Se ejecuta cuando el formulario se carga; inicializa datos y suscripción a cambios en tiempo real.
        /// </summary>
        private async void frmCategorias_Load(object sender, EventArgs e)
        {
            if (!rbMostrarTodos.Checked && !rbMostrarHabilitados.Checked && !rbMostrarDeshabilitados.Checked)
                rbMostrarTodos.Checked = true;

            await InicializarDatosYBuscador();
            await _gestorRealtime.SuscribirAsync();
        }

        /// <summary>
        /// Se ejecuta cuando el formulario se cierra; desuscribe de cambios en tiempo real.
        /// </summary>
        private async void frmCategorias_FormClosing(object sender, FormClosingEventArgs e)
        {
            await _gestorRealtime.DesuscribirAsync();
        }

        /// <summary>
        /// Recarga la interfaz de forma segura desde cualquier hilo, respetando el ciclo de vida del formulario.
        /// </summary>
        private void RecargarInterfazSafe()
        {
            if (!this.IsDisposed && this.IsHandleCreated)
                this.BeginInvoke((MethodInvoker)(async () => await CargarCategoriasMaestras()));
        }

        /// <summary>
        /// Inicializa la lista de categorías desde la base de datos y crea el buscador interactivo.
        /// </summary>
        private async Task InicializarDatosYBuscador()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _listaCompletaCategorias = await _categoriaRepositorio.ObtenerTodasLasCategorias(null);

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
                        if (pnlLimpiarFiltros != null) pnlLimpiarFiltros.Visible = b;
                        if (!b) RefrescarGrid();
                    },
                    (txt) => false
                );

                RefrescarGrid();
            }
            finally { this.Cursor = Cursors.Default; }
        }

        /// <summary>
        /// Carga todas las categorías desde la base de datos y actualiza el buscador y grid.
        /// </summary>
        private async Task CargarCategoriasMaestras()
        {
            _listaCompletaCategorias = await _categoriaRepositorio.ObtenerTodasLasCategorias(null);
            if (_buscadorCtrl != null) _buscadorCtrl.ActualizarDatosMaestros(_listaCompletaCategorias);
            RefrescarGrid();
        }

        /// <summary>
        /// Actualiza el DataGridView aplicando filtros de estado y búsqueda texto.
        /// </summary>
        private void RefrescarGrid()
        {
            if (_listaCompletaCategorias == null) return;

            this.Cursor = Cursors.WaitCursor;

            IEnumerable<Categoria> query = _listaCompletaCategorias;

            if (rbMostrarHabilitados.Checked)
                query = query.Where(c => c.EstadoCategoria);
            else if (rbMostrarDeshabilitados.Checked)
                query = query.Where(c => !c.EstadoCategoria);

            if (_buscadorCtrl != null)
                _buscadorCtrl.ActualizarDatosMaestros(query.ToList());

            string texto = txtBuscar.Text.Trim();
            if (!string.IsNullOrEmpty(texto))
                query = query.Where(c => c.NombreCategoria != null &&
                                         c.NombreCategoria.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0);

            var listaFinal = query.ToList();
            dgvCategorias.DataSource = null;
            dgvCategorias.DataSource = listaFinal;

            if (pnlLimpiarFiltros != null)
            {
                bool hayFiltros = !rbMostrarHabilitados.Checked || !string.IsNullOrEmpty(texto);
                pnlLimpiarFiltros.Visible = hayFiltros;
            }

            if (dgvCategorias.Rows.Count > 0) dgvCategorias.ClearSelection();

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Configura los controladores de eventos para los RadioButtons de filtro de estado.
        /// </summary>
        private void ConfigurarEventosUnificados()
        {
            rbMostrarTodos.CheckedChanged += (s, e) => { if (((RadioButton)s).Checked) RefrescarGrid(); };
            rbMostrarHabilitados.CheckedChanged += (s, e) => { if (((RadioButton)s).Checked) RefrescarGrid(); };
            rbMostrarDeshabilitados.CheckedChanged += (s, e) => { if (((RadioButton)s).Checked) RefrescarGrid(); };
        }

        /// <summary>
        /// Se ejecuta cuando el usuario presiona una tecla en el cuadro de búsqueda; dispara búsqueda asíncrona.
        /// </summary>
        private async void txtBuscar_KeyUp(object sender, KeyEventArgs e) => await _buscadorCtrl.ManejarKeyUpAsync(e);

        /// <summary>
        /// Se ejecuta cuando se presiona una tecla en el cuadro de búsqueda; maneja navegación y confirmación.
        /// </summary>
        private void txtBuscar_KeyDown(object sender, KeyEventArgs e) => _buscadorCtrl.ManejarKeyDown(e);

        /// <summary>
        /// Se ejecuta cuando el usuario hace clic en la lista de sugerencias; confirma la selección.
        /// </summary>
        private void lstSugerencias_MouseClick(object sender, MouseEventArgs e) => _buscadorCtrl.ManejarClickLista();

        /// <summary>
        /// Se ejecuta cuando el usuario presiona una tecla en la lista de sugerencias; acepta con Enter.
        /// </summary>
        private void lstSugerencias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) _buscadorCtrl.ManejarClickLista();
        }

        /// <summary>
        /// Limpia el filtro de búsqueda y recarga el grid con todas las categorías habilitadas.
        /// </summary>
        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            _buscadorCtrl.LimpiarBusqueda();
            rbMostrarHabilitados.Checked = true;
            if (pnlLimpiarFiltros != null) pnlLimpiarFiltros.Visible = false;
            RefrescarGrid();
        }

        /// <summary>
        /// Abre el diálogo para agregar una nueva categoría y recarga datos si la operación es exitosa.
        /// </summary>
        private async void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            if (new frmAgregarEditarCategoria().ShowDialog() == DialogResult.OK)
                await CargarCategoriasMaestras();
        }

        /// <summary>
        /// Abre el diálogo para editar la categoría seleccionada y recarga datos si la operación es exitosa.
        /// </summary>
        private async void btnModificarCategoria_Click(object sender, EventArgs e)
        {
            if (_categoriaSeleccionada != null)
            {
                if (new frmAgregarEditarCategoria(_categoriaSeleccionada).ShowDialog() == DialogResult.OK)
                    await CargarCategoriasMaestras();
            }
            else MessageBox.Show("Seleccione una categoría.", "Aviso", MessageBoxButtons.OK);
        }

        /// <summary>
        /// Se ejecuta cuando cambia la selección en el DataGridView; actualiza la categoría seleccionada.
        /// </summary>
        private void dgvCategorias_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count > 0)
                _categoriaSeleccionada = dgvCategorias.SelectedRows[0].DataBoundItem as Categoria;
            else
                _categoriaSeleccionada = null;
        }

        /// <summary>
        /// Se ejecuta al hacer clic en el botón Seleccionar; confirma la selección y cierra el diálogo.
        /// </summary>
        private void btnSeleccionarCategoria_Click(object sender, EventArgs e) => ConfirmarSeleccion();

        /// <summary>
        /// Se ejecuta al hacer doble clic en una fila del DataGridView; confirma la selección.
        /// </summary>
        private void dgvCategorias_CellDoubleClick(object sender, DataGridViewCellEventArgs e) => ConfirmarSeleccion();

        /// <summary>
        /// Confirma la selección actual y cierra el formulario con DialogResult.OK.
        /// </summary>
        private void ConfirmarSeleccion()
        {
            if (dgvCategorias.SelectedRows.Count > 0)
            {
                CategoriaSeleccionada = dgvCategorias.SelectedRows[0].DataBoundItem as Categoria;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// Se ejecuta al hacer clic en el botón Salir; cierra el formulario.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e) => this.Close();
    }
}
