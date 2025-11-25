using CapaDeDatos.Datos;
using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.ClasesUI.Extenciones;
using ModernMenuUI.InterfacesUsuarios.Compras;
using ModernMenuUI.ServiciosUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI.InterfacesUsuarios.Inventario
{
    public partial class frmMarcas : Form
    {
        #region 1. Campos y Dependencias
        private readonly MarcaRepositorio _marcaRepositorio;
        private readonly GestorRealtime<Marca> _gestorRealtime;

        private BuscadorInteractivo<Marca> _buscadorCtrl; 

        private List<Marca> _listaMaestraMarcas = new List<Marca>();
        private Marca _marcaSeleccionada;

        public Marca MarcaSeleccionada { get; private set; }
        #endregion

        #region 2. Constructor y Load
        public frmMarcas()
        {
            InitializeComponent();
            ConfigurarFormulario();

            _marcaRepositorio = new MarcaRepositorio();
            _gestorRealtime = new GestorRealtime<Marca>();

            // Configuración específica de Marcas
            btnAgregarMarca.Visible = false;
            btnModificarMarca.Visible = false;

            ConfigurarRealtime();
        }

        public frmMarcas(bool tipo)
        {
            InitializeComponent();
            ConfigurarFormulario();

            _marcaRepositorio = new MarcaRepositorio();
            _gestorRealtime = new GestorRealtime<Marca>();

            // Modo Selección
            FormBorderStyle = FormBorderStyle.None;
            btnSeleccionarMarca.Visible = false;

            ConfigurarRealtime();
        }

        private void ConfigurarFormulario()
        {
            this.DoubleBuffered = true;
            dgvMarcas.AutoGenerateColumns = false;

            ConfigurarEventosUnificados();
        }

        private void ConfigurarRealtime()
        {
            _gestorRealtime.OnCambioBaseDatos += (c) => RecargarInterfazSafe();
            _gestorRealtime.OnReconexionExitosa += () => RecargarInterfazSafe();
        }

        private async void frmMarcas_Load(object sender, EventArgs e)
        {
            await InicializarDatosYBuscador();
            await _gestorRealtime.SuscribirAsync();
        }

        private async void frmMarcas_FormClosing(object sender, FormClosingEventArgs e)
        {
            await _gestorRealtime.DesuscribirAsync();
        }
        #endregion

        #region 3. Lógica de Carga y Realtime
        private void RecargarInterfazSafe()
        {
            if (!this.IsDisposed && this.IsHandleCreated)
            {
                this.BeginInvoke((MethodInvoker)(async () => await CargarMarcasMaestras()));
            }
        }

        private async Task InicializarDatosYBuscador()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                _listaMaestraMarcas = await _marcaRepositorio.ObtenerTodasLasMarcas(null);

                // --- CONFIGURACIÓN DEL BUSCADOR ---
                _buscadorCtrl = new BuscadorInteractivo<Marca>(
                    txtBuscar,
                    lstSugerencias,
                    dgvMarcas,
                    _listaMaestraMarcas,
                    // 1. Criterio Exacto (ID)
                    (m, term) => m.IdMarca.ToString() == term,

                    // 2. Criterio Parcial (NOMBRE MARCA O NOMBRE PROVEEDOR)
                    (m, term) =>
                    {
                        bool porNombre = m.NombreMarca != null &&
                                         m.NombreMarca.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0;

                        // Aquí agregamos la búsqueda por PROVEEDOR
                        bool porProv = m.NombreProveedor != null &&
                                       m.NombreProveedor.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0;

                        return porNombre || porProv;
                    },

                    // 3. Visualización: SOLO NOMBRE MARCA (Lo que pediste)
                    (m) => m.NombreMarca,

                    // 4. Callback UI
                    (busquedaActiva) =>
                    {
                        if (pnlLimpiarFiltros != null)
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

        private async Task CargarMarcasMaestras()
        {
            try
            {
                _listaMaestraMarcas = await _marcaRepositorio.ObtenerTodasLasMarcas(null);

                if (_buscadorCtrl != null)
                {
                    _buscadorCtrl.ActualizarDatosMaestros(_listaMaestraMarcas);
                }

                RefrescarGrid();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error recargando marcas: {ex.Message}");
            }
        }
        #endregion

        #region 4. Búsqueda (Delegada al Controlador - Base Original)
        // Usamos la sintaxis lambda de una línea como en tu form Productos original

        private async void txtBuscar_KeyUp(object sender, KeyEventArgs e) => await _buscadorCtrl.ManejarKeyUpAsync(e);

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e) => _buscadorCtrl.ManejarKeyDown(e);

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
            if (_listaMaestraMarcas == null) return;

            this.Cursor = Cursors.WaitCursor;

            IEnumerable<Marca> query = _listaMaestraMarcas;

            if (rbMostrarHablilitados.Checked)
            {
                query = query.Where(m => m.EstadoMarca == true);
            }
            else if (rbMostrarDeshablitados.Checked)
            {
                query = query.Where(m => m.EstadoMarca == false);
            }
        
            string textoBusqueda = txtBuscar.Text.Trim();

            if (!string.IsNullOrEmpty(textoBusqueda))
            {

                query = query.Where(m =>
                    (m.NombreMarca != null && m.NombreMarca.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (m.NombreProveedor != null && m.NombreProveedor.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0)
                );
            }

            var listaFinal = query.ToList();

            dgvMarcas.DataSource = null;
            dgvMarcas.DataSource = listaFinal;

            bool hayFiltrosActivos = !rbMostrarHablilitados.Checked || !string.IsNullOrEmpty(textoBusqueda);
            if (pnlLimpiarFiltros != null) pnlLimpiarFiltros.Visible = hayFiltrosActivos;

            if (dgvMarcas.Rows.Count > 0) dgvMarcas.ClearSelection();

            this.Cursor = Cursors.Default;
        }

        private void ConfigurarEventosUnificados()
        {
            rbMostrarTodos.CheckedChanged += FiltroEstado_Changed;
            rbMostrarHablilitados.CheckedChanged += FiltroEstado_Changed;
            rbMostrarDeshablitados.CheckedChanged += FiltroEstado_Changed;
        }

        private void FiltroEstado_Changed(object sender, EventArgs e)
        {
            if (sender is RadioButton rb && rb.Checked) RefrescarGrid();
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            _buscadorCtrl.LimpiarBusqueda();
            rbMostrarHablilitados.Checked = true;
            if (pnlLimpiarFiltros != null) pnlLimpiarFiltros.Visible = false;
            RefrescarGrid();
        }
        #endregion

        #region 6. Acciones CRUD y Selección
        private async void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            frmAgregarEditarMarca nuevaMarca = new frmAgregarEditarMarca();
            if (nuevaMarca.ShowDialog() == DialogResult.OK)
            {
                await CargarMarcasMaestras();
            }
        }

        private async void btnModificarMarca_Click(object sender, EventArgs e)
        {
            if (_marcaSeleccionada != null)
            {
                frmAgregarEditarMarca editarForm = new frmAgregarEditarMarca(_marcaSeleccionada);
                if (editarForm.ShowDialog() == DialogResult.OK)
                {
                    await CargarMarcasMaestras();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una marca primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvMarcas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMarcas.SelectedRows.Count > 0)
            {
                _marcaSeleccionada = dgvMarcas.SelectedRows[0].DataBoundItem as Marca;
            }
            else
            {
                _marcaSeleccionada = null;
            }
        }

        private void btnSeleccionarMarca_Click(object sender, EventArgs e)
        {
            ConfirmarSeleccion();
        }

        private void dgvMarcas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ConfirmarSeleccion();
        }

        private void ConfirmarSeleccion()
        {
            if (dgvMarcas.SelectedRows.Count > 0)
            {
                MarcaSeleccionada = dgvMarcas.SelectedRows[0].DataBoundItem as Marca;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            frmProveedor provNuevo = new frmProveedor();
            provNuevo.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}