using CapaDeDatos.Datos;
using CapaDeDatos.Modelados.Inventario;
using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Repositorios;
using CapaDominio.Enums;
using CapaDominio.Servicios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.Adapters;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.ClasesUI.Extenciones;
using ModernMenuUI.InterfacesUsuarios.Inventario;
using ModernMenuUI.ServiciosUI;
using ModernMenuUI.ServiciosUI.GridFormatters;
using Org.BouncyCastle.Crypto.Digests;
using Supabase.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI
{
    /// <summary>
    /// Formulario principal para gestionar el inventario por bodega.
    /// Provee:
    /// - Carga y refresco de inventario.
    /// - Filtrado por bodega y por estado de stock.
    /// - Búsqueda interactiva con sugerencias.
    /// - Integración con Realtime para recargar cuando cambian los datos.
    /// - Acciones para crear bodegas y limpiar filtros.
    /// </summary>
    public partial class frmInventarioBodega : Form
    {
        /// <summary>Repositorio para acceder a datos de inventario.</summary>
        private readonly InventarioRepositorio _inventarioRepo = new();

        /// <summary>Repositorio para acceder a datos de bodegas.</summary>
        private readonly BodegaRepositorio _bodegaRepo = new();

        /// <summary>Servicio UI que aplica permisos y registra botones.</summary>
        private readonly ServicioPermisosUI _permUI = new();

        /// <summary>Gestor realtime para inventario (suscripciones y eventos).</summary>
        private readonly GestorRealtime<Inventario> _rtInventario;

        /// <summary>Gestor realtime para bodegas (suscripciones y eventos).</summary>
        private readonly GestorRealtime<Bodega> _rtBodega;

        /// <summary>Controlador de búsquedas interactivas y sugerencias.</summary>
        private BuscadorInteractivo<Inventario> _buscador;

        /// <summary>Lista maestra de inventario en memoria.</summary>
        private List<Inventario> _maestro = new();
        /// <summary>Indica si el formulario está en modo solo lectura .</summary>
        private bool _modoSoloLectura = false;

        /// <summary>
        /// Constructor: inicializa componentes, config de DataGridView y suscripciones de eventos locales.
        /// No realiza cargas de datos — eso ocurre en el Load.
        /// </summary>

        public frmInventarioBodega(bool modoSoloLectura) : this()
        {
            _modoSoloLectura = modoSoloLectura;
        }

        public frmInventarioBodega()
        {
            InitializeComponent();

            dgvProducto.AutoGenerateColumns = false;
            dgvProducto.EnableHeadersVisualStyles = false;
            dgvProducto.ActivarDobleBuffer();

            this.FormClosing += frmInventarioBodega_FormClosing;

            _rtInventario = new();
            _rtBodega = new();

            // Cuando haya cambios remotos, recargar UI de forma segura
            _rtInventario.OnCambioBaseDatos += (_) => RecargarUI();
            _rtInventario.OnReconexionExitosa += () => RecargarUI();
            _rtBodega.OnCambioBaseDatos += (_) => RecargarUI();
            _rtBodega.OnReconexionExitosa += () => RecargarUI();

            _permUI.AplicarPermisos();
            _permUI.RegistrarBoton(btnCambiarBodega, "update_inventario");
            _permUI.RegistrarBoton(btnCrearBodega, "update_inventario");
        }
       

        /// <summary>
        /// Evento Load del formulario. Carga datos iniciales, bodegas, configura controles y suscribe a realtime.
        /// </summary>
        private async void frmInventarioBodega_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            // Cargar datos iniciales
            await CargarDatos();
            await CargarBodegas(); // Carga el Grid
            ConfigurarComboEstado();

            // Iniciar suscripciones Realtime
            txtBodegaActual.Text = ServicioSesionUsuario.ObtenerNombreBodega();

            await _rtInventario.SuscribirAsync();
            await _rtBodega.SuscribirAsync();


        }

        private async Task CargarNormal()
        {
            await CargarDatos();
            await CargarBodegas();
            ConfigurarComboEstado();
            ConectarEventosUI();

            txtBodegaActual.Text = ServicioSesionUsuario.ObtenerNombreBodega();

            await _rtInventario.SuscribirAsync();
            await _rtBodega.SuscribirAsync();

            RefrescarGrid();
            Cursor = Cursors.Default;
        }

        /// <sumary>
        /// Funcion para quitar cosas dentro del form 
        /// </sumary> 
        private async Task AplicarModoSoloLectura()
        {
            //dgv();
            botones();
        }

        protected async void botones()
        {
            this.SuspendLayout();
            btnCambiarBodega.Visible = false;
            btnCrearBodega.Visible = false;
            label1.Visible = false;
            cmbEstado.Visible = false;
            cmbBodega.Visible = false;
            label8.Visible = false;
            pnlLimpiarFiltros.Visible = false;
            btnLimpiarFiltros.Visible = false;
            pbxClean.Visible = false;
            this.ResumeLayout();
        }

        protected async void dgv()
        {
            /*
            dgvProducto.SuspendLayout();
            // Ocultar columnas del DGV
            dgvProducto.Columns["Anaquel"].Visible = false;
            dgvProducto.Columns["StockMinimo"].Visible = false;
            dgvProducto.Columns["StockTotal"].Visible = false;
            dgvProducto.Columns["Categoria"].Visible = false;
            dgvProducto.Columns["Presentacion"].Visible = false;
            dgvProducto.Columns["EstadoBodega"].Visible = true;
            dgvProducto.CellFormatting -= dgvProducto_CellFormatting;
            //cambiar el property value     
            dgvProducto.Columns["Producto"].DataPropertyName = "NombreDepartamento"; 
            dgvProducto.Columns["Marca"].DataPropertyName = "DireccionSucursal";
            dgvProducto.Columns["ContenidoProducto"].DataPropertyName = "TelefonoSucursal"; // ojo el guion bajo

            //cambiar el nomrbe de HeaderText
            dgvProducto.Columns["Producto"].HeaderText = "Nombre departamento";
            dgvProducto.Columns["Marca"].HeaderText = "Direccion sucursal";
            dgvProducto.Columns["ContenidoProducto"].HeaderText = "Telefono sucursal";

            //cambiar a checkbox
            //dgvProducto.Columns["ContenidoProducto"].ColumnType = new DataGridViewCheckBoxCell();
            dgvProducto.ResumeLayout();*/


        }

        /// <summary>
        /// Evento FormClosing: intenta desuscribir de realtime limpiamente.
        /// </summary>
        private async void frmInventarioBodega_FormClosing(object sender, FormClosingEventArgs e)
        {
            try { await _rtInventario.DesuscribirAsync(); } catch { }
            try { await _rtBodega.DesuscribirAsync(); } catch { }
        }

        /// <summary>
        /// Solo las bodegas con sus datos
        /// </summary>

        private async Task cargarbodegas()
        {
            //dgvProducto.SuspendLayout();

            var lista = await _bodegaRepo.obtenerBodegas();
            dgvProducto.Columns.Clear();
            dgvProducto.CellFormatting -= dgvProducto_CellFormatting;
            dgvProducto.AutoGenerateColumns = false;

            dgvProducto.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Bodega",
                DataPropertyName = "NombreBodega"
            });

            dgvProducto.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Departamento",
                DataPropertyName = "NombreDepartamento"
            });

            dgvProducto.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Dirección",
                DataPropertyName = "DireccionSucursal"
            });

            dgvProducto.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Teléfono",
                DataPropertyName = "TelefonoSucursal"
            });
            dgvProducto.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                HeaderText = "Estado",
                DataPropertyName = "EstadoBodega"
            });
            dgvProducto.DataSource = lista;

            //dgvProducto.ResumeLayout();

        }

        private void ResetGrid()
        {
            dgvProducto.DataSource = null;
            dgvProducto.Columns.Clear();
            dgvProducto.AutoGenerateColumns = false;
            dgvProducto.CellFormatting -= dgvProducto_CellFormatting;
        }

        /// <summary>
        /// Carga los datos maestros de inventario y configura el buscador interactivo.
        /// Este método sólo obtiene los datos en memoria; el refresco visual queda en RefrescarGrid.
        /// </summary>
        private async Task CargarDatos()
        {
            _maestro = await _inventarioRepo.ObtenerTodoElInventario();

            _buscador = new BuscadorInteractivo<Inventario>(
                txtBuscar,
                lstSugerencias,
                dgvProducto,
                _maestro,
                (i, txt) => !string.IsNullOrWhiteSpace(i.CodigoBarraProducto) && i.CodigoBarraProducto.Equals(txt, StringComparison.OrdinalIgnoreCase),
                (i, txt) =>
                {
                    txt = txt.ToLowerInvariant();
                    string blob = $"{i.NombreProducto} {i.NombreMarca} {i.NombreCategoria} {i.NombrePresentacion} {i.ContenidoProducto}";
                    return !string.IsNullOrWhiteSpace(blob) && blob.ToLowerInvariant().Contains(txt);
                },
                (i) => $"{i.NombreProducto} {(string.IsNullOrEmpty(i.CodigoBarraProducto) ? "" : $"[{i.CodigoBarraProducto}]")} {i.NombreMarca} {i.NombrePresentacion}",
                (activo) =>
                {
                    pnlLimpiarFiltros.Visible = activo;
                    if (!activo) RefrescarGrid();
                },
                (txt) => txt.All(char.IsDigit) && txt.Length >= 8 && txt.Length <= 13
            );

            RefrescarGrid();
        }

        /// <summary>
        /// Recarga la lista maestra desde repositorio y actualiza el buscador si existe.
        /// </summary>
        private async Task RecargarDatos()
        {
            _maestro = await _inventarioRepo.ObtenerTodoElInventario();
            _buscador?.ActualizarDatosMaestros(_maestro);
            RefrescarGrid();
        }

        /// <summary>
        /// Método seguro invocado por eventos realtime para recargar UI en el hilo de la interfaz.
        /// Se encarga también de recargar la lista de bodegas antes de refrescar datos.
        /// </summary>
        private void RecargarUI()
        {
            if (!IsHandleCreated || IsDisposed) return;

            BeginInvoke(async () =>
            {
                await CargarBodegas();
                await RecargarDatos();
                RefrescarGrid();
            });
        }

        /// <summary>
        /// Carga la lista de bodegas al combobox, preservando la selección actual si existe.
        /// </summary>
        private async Task CargarBodegas()
        {
            var selected = cmbBodega.SelectedValue;

            var lista = await _bodegaRepo.ObtenerTodasLasBodegasAsync();
            lista.Insert(0, new Bodega { IdBodega = 0, NombreBodega = "Todas las bodegas" });

            cmbBodega.SelectedIndexChanged -= cmbBodega_SelectedIndexChanged;

            cmbBodega.DataSource = null;
            cmbBodega.DataSource = lista;
            cmbBodega.DisplayMember = "NombreBodega";
            cmbBodega.ValueMember = "IdBodega";

            if (selected != null)
            {
                if (int.TryParse(selected.ToString(), out int idSel) && lista.Any(b => b.IdBodega == idSel))
                    cmbBodega.SelectedValue = idSel;
                else
                    cmbBodega.SelectedIndex = 0;
            }
            else
                cmbBodega.SelectedIndex = 0;

            cmbBodega.SelectedIndexChanged += cmbBodega_SelectedIndexChanged;
        }

        /// <summary>
        /// Llena y asigna los items del combo de estado (Todos / Crítico / Advertencia / Normal).
        /// </summary>
        private void ConfigurarComboEstado()
        {
            cmbEstado.SelectedIndexChanged -= cmbEstado_SelectedIndexChanged;

            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("Todos");
            cmbEstado.Items.Add("Crítico");
            cmbEstado.Items.Add("Advertencia");
            cmbEstado.Items.Add("Normal");
            cmbEstado.SelectedIndex = 0;

            cmbEstado.SelectedIndexChanged += cmbEstado_SelectedIndexChanged;
        }

        /// <summary>
        /// Conecta (y asegura desconexión previa) los manejadores de eventos de UI para evitar duplicados.
        /// Centraliza la unión de los eventos del buscador, listbox y combos.
        /// </summary>
        private void ConectarEventosUI()
        {
            cmbBodega.SelectedIndexChanged -= cmbBodega_SelectedIndexChanged;
            cmbBodega.SelectedIndexChanged += cmbBodega_SelectedIndexChanged;

            cmbEstado.SelectedIndexChanged -= cmbEstado_SelectedIndexChanged;
            cmbEstado.SelectedIndexChanged += cmbEstado_SelectedIndexChanged;

            txtBuscar.KeyUp -= txtBuscar_KeyUp;
            txtBuscar.KeyUp += txtBuscar_KeyUp;

            txtBuscar.KeyDown -= txtBuscar_KeyDown;
            txtBuscar.KeyDown += txtBuscar_KeyDown;

            txtBuscar.Leave -= txtBuscar_Leave;
            txtBuscar.Leave += txtBuscar_Leave;

            lstSugerencias.MouseClick -= lstSugerencias_MouseClick;
            lstSugerencias.MouseClick += lstSugerencias_MouseClick;

            lstSugerencias.KeyDown -= lstSugerencias_KeyDown;
            lstSugerencias.KeyDown += lstSugerencias_KeyDown;

            btnBuscar.Click -= btnBuscar_Click;
            btnBuscar.Click += btnBuscar_Click;
        }

        /// <summary>
        /// Handler para cambio de selección en el combo de bodegas.
        /// Simplemente refresca la grilla aplicando filtros.
        /// </summary>
        private void cmbBodega_SelectedIndexChanged(object sender, EventArgs e) => RefrescarGrid();

        /// <summary>
        /// Handler para cambio de selección en el combo de estado.
        /// Simplemente refresca la grilla aplicando filtros.
        /// </summary>
        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e) => RefrescarGrid();

        /// <summary>
        /// Delegados para el buscador interactivo — encapsulan llamadas al controlador de búsqueda.
        /// </summary>
        private void txtBuscar_KeyUp(object sender, KeyEventArgs e) => _ = _buscador?.ManejarKeyUpAsync(e);
        private void txtBuscar_KeyDown(object sender, KeyEventArgs e) => _buscador?.ManejarKeyDown(e);
        private void txtBuscar_Leave(object sender, EventArgs e) => _buscador?.ManejarLeave();
        private void lstSugerencias_MouseClick(object sender, MouseEventArgs e) => _buscador?.ManejarClickLista();
        private void lstSugerencias_KeyDown(object sender, KeyEventArgs e) { if (e.KeyCode == Keys.Enter) _buscador?.ManejarClickLista(); }
        private void btnBuscar_Click(object sender, EventArgs e) => _buscador?.ManejarKeyDown(new KeyEventArgs(Keys.Enter));

        /// <summary>
        /// Obtiene el estado de stock desde la capa de dominio (usa adapters y evaluador).
        /// </summary>
        private EstadoStock EstadoDominio(Inventario inv)
        {
            var dom = InventarioAdapter.Map(inv);
            return EvaluadorStock.ObtenerEstado(dom);
        }

        /// <summary>
        /// Refresca la grilla aplicando los filtros activos:
        /// - filtro por bodega (cmbBodega)
        /// - filtro por estado de stock (cmbEstado)
        /// Además muestra/oculta pnlLimpiarFiltros en función de si hay filtros activos.
        /// </summary>
        private void RefrescarGrid()
        {
            if (_maestro == null) return;

            var lista = _maestro.AsEnumerable();

            int idBodega = 0;
            try
            {
                if (cmbBodega.SelectedValue is int vd) idBodega = vd;
                else if (cmbBodega.SelectedItem is Bodega b) idBodega = b.IdBodega;
                else if (cmbBodega.SelectedValue != null) int.TryParse(cmbBodega.SelectedValue.ToString(), out idBodega);
            }
            catch { idBodega = 0; }

            bool filtroBodegaActivo = idBodega != 0;
            if (filtroBodegaActivo) lista = lista.Where(x => x.IdBodegaInventario == idBodega);

            bool filtroEstadoActivo = cmbEstado.SelectedIndex != 0;
            if (filtroEstadoActivo)
            {
                switch (cmbEstado.SelectedIndex)
                {
                    case 1: lista = lista.Where(x => EstadoDominio(x) == EstadoStock.Critico); break;
                    case 2: lista = lista.Where(x => EstadoDominio(x) == EstadoStock.Advertencia); break;
                    case 3: lista = lista.Where(x => EstadoDominio(x) == EstadoStock.Normal); break;
                }
            }

            var resultado = lista.ToList();

            dgvProducto.DataSource = null;
            dgvProducto.DataSource = resultado;

            if (dgvProducto.Rows.Count > 0) dgvProducto.ClearSelection();

            pnlLimpiarFiltros.Visible = filtroBodegaActivo || filtroEstadoActivo;
        }

        /// <summary>
        /// Formatea la fila de la grilla delegando al InventarioGridFormatter (colores, estilos).
        /// </summary>
        private void dgvProducto_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            InventarioGridFormatter.AplicarFormato(dgvProducto.Rows[e.RowIndex]);
        }

        /// <summary>
        /// Maneja el botón "Limpiar filtros": restablece combo bodega y estado y limpia la búsqueda.
        /// </summary>
        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            _buscador?.LimpiarBusqueda();

            if (cmbBodega.Items.Count > 0) cmbBodega.SelectedIndex = 0;
            cmbEstado.SelectedIndex = 0;

            pnlLimpiarFiltros.Visible = false;

            RefrescarGrid();
        }

        /// <summary>
        /// Botón salir: vuelve al menú principal.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            Close();
        }

        /// <summary>
        /// Abre el formulario para crear una nueva bodega. Si se creó, recarga bodegas e inventario.
        /// </summary>
        private async void btnCrearBodega_Click(object sender, EventArgs e)
        {
            using var frm = new frmAgregarEditarBodega();
            var res = frm.ShowDialog();
            if (res == DialogResult.OK)
            {
                await CargarBodegas();
                await RecargarDatos();
            }
        }
    }
}
