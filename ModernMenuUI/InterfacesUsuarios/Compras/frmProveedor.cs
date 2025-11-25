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
    public partial class frmProveedor : Form
    {
        #region 1. Campos y Dependencias
        private readonly ProveedorRepositorio _repositorioProveedor;
        private readonly GestorRealtime<Proveedor> _gestorRealtime;
        private BuscadorInteractivo<Proveedor> _buscadorProveedores;

        private List<Proveedor> _listaMaestraProveedores = new List<Proveedor>();
        private Proveedor _proveedorSeleccionadoInterno;

        public Proveedor ProveedorSeleccionado { get; private set; }
        #endregion

        #region 2. Constructores
        public frmProveedor()
        {
            InitializeComponent();
            ConfigurarFormulario();

            _repositorioProveedor = new ProveedorRepositorio();
            _gestorRealtime = new GestorRealtime<Proveedor>();

            ConfigurarRealtime();
        }

        public frmProveedor(bool tipo)
        {
            InitializeComponent();
            ConfigurarFormulario();

            _repositorioProveedor = new ProveedorRepositorio();
            _gestorRealtime = new GestorRealtime<Proveedor>();

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
            _gestorRealtime.OnCambioBaseDatos += (c) => RecargarInterfazSafe();
            _gestorRealtime.OnReconexionExitosa += () => RecargarInterfazSafe();
        }
        #endregion

        #region 3. Ciclo de Vida
        private async void frmProveedores_Load(object sender, EventArgs e)
        {
            ConfigurarEventosFiltros();
            await InicializarDatosYBuscador();
            await _gestorRealtime.SuscribirAsync();
        }

        private async void frmProveedores_FormClosing(object sender, FormClosingEventArgs e)
        {
            await _gestorRealtime.DesuscribirAsync();
        }
        #endregion

        #region 4. Lógica de Datos y Buscador
        private void RecargarInterfazSafe()
        {
            if (!this.IsDisposed && this.IsHandleCreated)
            {
                this.BeginInvoke((MethodInvoker)(async () => await CargarDatosMaestros()));
            }
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
                    (p, term) => p.IdProveedor.ToString() == term,
                    (p, term) => p.NombreProveedor != null && p.NombreProveedor.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0,
                    (p) => p.NombreProveedor,
                    (busquedaActiva) =>
                    {
                        // Callback: Controla visibilidad del panel de limpiar filtros
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

            // Filtros de RadioButtons
            if (rbMostrarHabilitados.Checked)
            {
                query = query.Where(p => p.EstadoProveedor == true);
            }
            else if (rbMostrarDeshabilitados.Checked)
            {
                query = query.Where(p => p.EstadoProveedor == false);
            }

            // Asignar al Grid
            var listaFinal = query.ToList();
            dgvProveedores.DataSource = null;
            dgvProveedores.DataSource = listaFinal;

            // Lógica para mostrar/ocultar el botón de Limpiar Filtros
            // Si NO está marcado el filtro por defecto (Habilitados) O hay texto en búsqueda -> Mostrar botón
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
        #endregion

        #region 5. Eventos del Buscador y Limpieza
        private async void txtBuscar_KeyUp(object sender, KeyEventArgs e) => await _buscadorProveedores.ManejarKeyUpAsync(e);
        private void txtBuscar_KeyDown(object sender, KeyEventArgs e) => _buscadorProveedores.ManejarKeyDown(e);
        private void txtBuscar_Leave(object sender, EventArgs e) => _buscadorProveedores.ManejarLeave();
        private void lstSugerencias_MouseClick(object sender, MouseEventArgs e) => _buscadorProveedores.ManejarClickLista();

        // LOGICA DEL BOTÓN LIMPIAR FILTROS
        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            // 1. Resetear el buscador
            _buscadorProveedores.LimpiarBusqueda();

            // 2. Resetear el RadioButton al estado por defecto (Habilitados)
            rbMostrarHabilitados.Checked = true;

            // 3. Ocultar el panel (aunque RefrescarGrid lo hará, es bueno forzarlo visualmente rápido)
            pnlLimpiarFiltros.Visible = false;

            // 4. Refrescar la tabla
            RefrescarGrid();
        }
        #endregion

        #region 6. Acciones CRUD y Selección
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
            if (dgvProveedores.SelectedRows.Count > 0)
            {
                ProveedorSeleccionado = dgvProveedores.SelectedRows[0].DataBoundItem as Proveedor;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                if (this.ActiveControl == btnSeleccionarProveedor)
                    MessageBox.Show("Por favor, seleccione un proveedor de la lista.");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}