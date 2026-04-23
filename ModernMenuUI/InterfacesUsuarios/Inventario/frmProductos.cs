using CapaDeDatos.Modelados.Paginacion;
using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.ClasesUI.Extenciones;
using ModernMenuUI.InterfacesUsuarios.Inventario;
using Supabase.Realtime.PostgresChanges;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI
{
    public partial class frmProductos : Form
    {
        private readonly ProductoRepositorio _productoRepositorio;
        private readonly ServiciosUI.ServicioPermisosUI _servicioPermisos;

        // Estado actual de filtros + paginación
        private readonly FiltrosProducto _filtros = new FiltrosProducto
        {
            Estado = true,
            Pagina = 1,
            TamanioPagina = 100
        };

        private Producto _productoSeleccionado;

        // Cancelación para búsquedas concurrentes
        private CancellationTokenSource _ctsPagina;
        private CancellationTokenSource _ctsSugerencias;

        // Debounce para búsqueda/sugerencias (no consultar por cada tecla)
        private readonly System.Windows.Forms.Timer _timerDebounce;

        // Realtime
        private Action<PostgresChangesResponse> _handlerCambio;

        public frmProductos()
        {
            InitializeComponent();

            _productoRepositorio = new ProductoRepositorio();
            _servicioPermisos = new ServiciosUI.ServicioPermisosUI();

            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.ActivarDobleBuffer();
            dgvProductos.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                Color.FromArgb(220, 230, 241);

            RegistrarBotonesConPermisos();
            _servicioPermisos.AplicarPermisos();
            ConfigurarEventosUnificados();

            ConfigurarPaginador(); 

            _timerDebounce = new System.Windows.Forms.Timer { Interval = 350 };
            _timerDebounce.Tick += TimerDebounce_Tick;

            _handlerCambio = (c) => RecargarInterfazSafe();
            RealtimeManager.OnProductoChanged += _handlerCambio;
        }

        // =========================================================
        // CICLO DE VIDA
        // =========================================================
        private async void frmProductos_Load(object sender, EventArgs e)
        {
            await CargarPaginaAsync();
        }

        private void frmProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_handlerCambio != null)
                    RealtimeManager.OnProductoChanged -= _handlerCambio;

                _ctsPagina?.Cancel();
                _ctsPagina?.Dispose();
                _ctsPagina = null;

                _ctsSugerencias?.Cancel();
                _ctsSugerencias?.Dispose();
                _ctsSugerencias = null;

                _timerDebounce.Stop();
                _timerDebounce.Tick -= TimerDebounce_Tick;
                _timerDebounce.Dispose();
            }
            catch { /* silencioso al cerrar */ }
        }

        // =========================================================
        // PAGINADOR
        // =========================================================
        private void ConfigurarPaginador()
        {
            paginadorProductos.PaginaCambiada += async (s, nueva) =>
            {
                _filtros.Pagina = nueva;
                await CargarPaginaAsync();
            };

            paginadorProductos.TamanioPaginaCambiado += async (s, tam) =>
            {
                _filtros.TamanioPagina = tam;
                _filtros.Pagina = 1;
                await CargarPaginaAsync();
            };
        }

        // =========================================================
        // MÉTODO CENTRAL: carga una página del servidor
        // =========================================================
        private async Task CargarPaginaAsync()
        {
            _ctsPagina?.Cancel();
            _ctsPagina?.Dispose();
            _ctsPagina = new CancellationTokenSource();
            var token = _ctsPagina.Token;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                gbxEstado.Enabled = false;

                var resultado = await _productoRepositorio
                    .ObtenerProductosPaginadosAsync(_filtros, token);

                if (token.IsCancellationRequested) return;

                dgvProductos.DataSource = null;
                dgvProductos.DataSource = resultado.Items;

                paginadorProductos.Actualizar(
                    resultado.PaginaActual,
                    resultado.TotalPaginas,
                    resultado.TotalRegistros);

                ActualizarTotalProductos(resultado.TotalRegistros);
                pnlLimpiarFiltros.Visible = HayFiltrosActivos();

                if (resultado.Items.Count > 0)
                    dgvProductos.ClearSelection();
            }
            catch (OperationCanceledException)
            {
                // Esperado — el usuario escribió algo más
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo cargar la página.\n\nDetalle: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                gbxEstado.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        private void RecargarInterfazSafe()
        {
            if (!this.IsDisposed && this.IsHandleCreated)
                this.BeginInvoke((MethodInvoker)(async () => await CargarPaginaAsync()));
        }

        private void ActualizarTotalProductos(long total)
        {
            lblTotalProductos.Text = $"Total de Productos{Environment.NewLine}{total:N0}";
        }

        private bool HayFiltrosActivos()
        {
            return !string.IsNullOrWhiteSpace(_filtros.TextoBusqueda)
                || _filtros.IdMarca.HasValue
                || _filtros.IdCategoria.HasValue
                || _filtros.Estado != true;
        }

        // =========================================================
        // BUSCADOR con sugerencias (top 10)
        // =========================================================
        private async void TimerDebounce_Tick(object sender, EventArgs e)
        {
            _timerDebounce.Stop();
            string texto = txtBuscar.Text?.Trim();

            if (string.IsNullOrEmpty(texto))
            {
                lstSugerencias.Visible = false;
                return;
            }

            _ctsSugerencias?.Cancel();
            _ctsSugerencias?.Dispose();
            _ctsSugerencias = new CancellationTokenSource();

            try
            {
                var sugerencias = await _productoRepositorio.ObtenerSugerenciasAsync(
                    texto, _filtros.Estado, 10, _ctsSugerencias.Token);

                if (_ctsSugerencias.IsCancellationRequested) return;

                if (sugerencias.Count > 0)
                {
                    lstSugerencias.DataSource = null;
                    lstSugerencias.DataSource = sugerencias;
                    // ← NombreCompleto muestra el nombre concatenado visualmente
                    lstSugerencias.DisplayMember = "NombreCompleto";

                    int alto = (lstSugerencias.ItemHeight * sugerencias.Count) + 6;
                    lstSugerencias.Height = Math.Min(alto, 250);
                    lstSugerencias.Visible = true;
                    lstSugerencias.BringToFront();
                }
                else
                {
                    lstSugerencias.Visible = false;
                }
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error sugerencias: {ex.Message}");
                lstSugerencias.Visible = false;
            }
        }

        private async void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _timerDebounce.Stop();
                lstSugerencias.Visible = false;
                _filtros.TextoBusqueda = txtBuscar.Text?.Trim();
                _filtros.Pagina = 1;
                await CargarPaginaAsync();
                return;
            }

            if (e.KeyCode == Keys.Down && lstSugerencias.Visible
                && lstSugerencias.Items.Count > 0)
            {
                lstSugerencias.Focus();
                lstSugerencias.SelectedIndex = 0;
                return;
            }

            if (e.KeyCode == Keys.Escape)
            {
                lstSugerencias.Visible = false;
                return;
            }

            _timerDebounce.Stop();
            _timerDebounce.Start();
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            // nada — KeyUp maneja todo
        }

        private async void txtBuscar_Leave(object sender, EventArgs e)
        {
            await Task.Delay(200);
            if (!this.IsDisposed && !lstSugerencias.Focused)
                lstSugerencias.Visible = false;
        }

        private async void lstSugerencias_MouseClick(object sender, MouseEventArgs e)
        {
            await AplicarSugerenciaSeleccionada();
        }

        private async void lstSugerencias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await AplicarSugerenciaSeleccionada();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                lstSugerencias.Visible = false;
                txtBuscar.Focus();
            }
        }
        private async Task AplicarSugerenciaSeleccionada()
        {
            // ← Ahora es Producto, no string
            if (lstSugerencias.SelectedItem is Producto productoSeleccionado)
            {
                // Mostrar el nombre completo en el textbox visualmente
                txtBuscar.Text = productoSeleccionado.NombreCompleto;
                lstSugerencias.Visible = false;

                // ← FILTRAR SOLO POR NombreProducto REAL (no el concatenado)
                _filtros.TextoBusqueda = productoSeleccionado.NombreProducto;
                _filtros.Pagina = 1;
                await CargarPaginaAsync();
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            _timerDebounce.Stop();
            lstSugerencias.Visible = false;
            _filtros.TextoBusqueda = txtBuscar.Text?.Trim();
            _filtros.Pagina = 1;
            await CargarPaginaAsync();
        }

        // =========================================================
        // FILTROS
        // =========================================================
        private void ConfigurarEventosUnificados()
        {
            rbMostrarTodos.CheckedChanged += FiltroEstado_Changed;
            rbMostrarHabilitados.CheckedChanged += FiltroEstado_Changed;
            rbMostrardeshabilitados.CheckedChanged += FiltroEstado_Changed;
        }

        private async void FiltroEstado_Changed(object sender, EventArgs e)
        {
            if (!(sender is RadioButton rb) || !rb.Checked) return;

            if (rbMostrarHabilitados.Checked) _filtros.Estado = true;
            else if (rbMostrardeshabilitados.Checked) _filtros.Estado = false;
            else _filtros.Estado = null;

            _filtros.Pagina = 1;
            await CargarPaginaAsync();
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            _productoSeleccionado = dgvProductos.SelectedRows.Count > 0
                ? dgvProductos.SelectedRows[0].DataBoundItem as Producto
                : null;
        }

        private async void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            _filtros.TextoBusqueda = null;
            _filtros.IdMarca = null;
            _filtros.IdCategoria = null;
            _filtros.Estado = true;
            _filtros.Pagina = 1;

            txtFiltroMarca.Text = "";
            txtFiltroCategoria.Text = "";
            txtBuscar.Text = "";
            lstSugerencias.Visible = false;
            rbMostrarHabilitados.Checked = true;

            await CargarPaginaAsync();
        }

        // =========================================================
        // CRUD
        // =========================================================
        private async void btnNuevoProducto_Click(object sender, EventArgs e)
            => await AbrirEditorProducto(null);

        private async void btnEditarProducto_Click(object sender, EventArgs e)
        {
            if (_productoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un producto primero.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            await AbrirEditorProducto(_productoSeleccionado);
        }

        private async Task AbrirEditorProducto(Producto prod)
        {
            using (var frm = prod == null
                ? new frmAgregarEditarProducto()
                : new frmAgregarEditarProducto(prod))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    await CargarPaginaAsync();
            }
        }

        // =========================================================
        // FILTROS DE MARCA / CATEGORÍA
        // =========================================================
        private async void btnMarca_Click(object sender, EventArgs e)
        {
            using (var frm = new frmMarcas())
            {
                if (frm.ShowDialog() == DialogResult.OK && frm.MarcaSeleccionada != null)
                {
                    txtFiltroMarca.Text = frm.MarcaSeleccionada.NombreMarca;
                    _filtros.IdMarca = frm.MarcaSeleccionada.IdMarca;
                    _filtros.Pagina = 1;
                    await CargarPaginaAsync();
                }
            }
        }

        private async void btnCategoria_Click(object sender, EventArgs e)
        {
            using (var frm = new frmCategorias())
            {
                if (frm.ShowDialog() == DialogResult.OK && frm.CategoriaSeleccionada != null)
                {
                    txtFiltroCategoria.Text = frm.CategoriaSeleccionada.NombreCategoria;
                    _filtros.IdCategoria = frm.CategoriaSeleccionada.IdCategoria;
                    _filtros.Pagina = 1;
                    await CargarPaginaAsync();
                }
            }
        }

        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            using (var frm = new frmMarcas()) frm.ShowDialog();
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            using (var frm = new frmCategorias()) frm.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            this.Close();
        }

        private void RegistrarBotonesConPermisos()
        {
            _servicioPermisos.RegistrarBoton(btnNuevoProducto, "create_inventario");
            _servicioPermisos.RegistrarBoton(btnEditarProducto, "update_inventario");
            _servicioPermisos.RegistrarBoton(btnAgregarCategoria, "update_inventario");
            _servicioPermisos.RegistrarBoton(btnAgregarMarca, "update_inventario");
        }

        private void rbMostrarHabilitados_CheckedChanged(object sender, EventArgs e) { }
    }
}