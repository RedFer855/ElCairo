using CapaDeDatos.Datos;
using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.InterfacesUsuarios.Inventario;
using ModernMenuUI.ServiciosUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI
{
    public partial class frmProductos : Form
    {
        private BuscadorInteractivo<Producto> _buscadorCtrl;
        // VARIABLES DE UI Y LOGICA DE NEGOCIO
        private int? _filtroMarcaId = null;
        private int? _filtroCategoriaId = null;
        private readonly ServiciosUI.ServicioPermisosUI _servicioPermisos = new ServiciosUI.ServicioPermisosUI();
        private readonly ProductoRepositorio productoRepositorio;
        private Producto ProductoSeleccionado;

        // NUEVA VARIABLE GESTOR REALTIME
        private GestorRealtime<Producto> _gestorRealtime;

        private List<Producto> _listaMaestraProductos = new List<Producto>();

        // VARIABLES DE BUSQUEDA
        private CancellationTokenSource _ctsBusqueda;
        private string sugerenciaActual = "";
        private bool _ignorarTextChanged = false;
        private bool _usuarioSeleccionoConMouse = false;
        private const int MAX_SUGGESTIONS = 10;

        public frmProductos()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            productoRepositorio = new ProductoRepositorio();
            dgvProductos.AutoGenerateColumns = false;

            RegistrarBotonesConPermisos();
            _servicioPermisos.AplicarPermisos();
            this.FormClosing += frmProductos_FormClosing;

            // Hack para DoubleBuffered en Grid
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.SetProperty,
                null, dgvProductos, new object[] { true });

            dgvProductos.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 230, 241);

            // --- CONFIGURACION GESTOR REALTIME (NUEVO) ---
            _gestorRealtime = new GestorRealtime<Producto>();

            // Evento: Cuando hay cambios en la BD (Insert/Update/Delete)
            _gestorRealtime.OnCambioBaseDatos += (change) =>
            {
                System.Diagnostics.Debug.WriteLine($"Cambio BD detectado: {change.Event}");
                RecargarInterfaz();
            };

            // Evento: Cuando vuelve el internet y se reconecta
            _gestorRealtime.OnReconexionExitosa += () =>
            {
                System.Diagnostics.Debug.WriteLine("Reconexión exitosa -> Recargando Grid Productos");
                RecargarInterfaz();
            };
        }

        private async void frmProductos_Load(object sender, EventArgs e)
        {
            // Carga inicial de datos
            await CargarProductosMaestros();
            RefrescarGrid();

            // Iniciar suscripción Realtime
            await _gestorRealtime.SuscribirAsync();
        }

        private async void frmProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Limpiar suscripción al cerrar
            await _gestorRealtime.DesuscribirAsync();
        }

        // METODO AUXILIAR PARA RECARGAR DESDE HILOS SEGUROS
        private void RecargarInterfaz()
        {
            if (this.IsDisposed || !this.IsHandleCreated) return;

            this.BeginInvoke((MethodInvoker)(async () =>
            {
                if (this.IsDisposed) return;
                await CargarProductosMaestros();
                RefrescarGrid();
            }));
        }

        // MAPEO PERMISOS
        private void RegistrarBotonesConPermisos()
        {
            _servicioPermisos.RegistrarBoton(btnNuevoProducto, "insert_inventario");
            _servicioPermisos.RegistrarBoton(btnEditarProducto, "update_inventario");
            _servicioPermisos.RegistrarBoton(btnAgregarCategoria, "update_inventario");
            _servicioPermisos.RegistrarBoton(btnAgregarMarca, "update_inventario");
            _servicioPermisos.RegistrarBoton(btnIngresarPerdida, "update_inventario");
        }

        // BUSCAR LOGICA
        private List<Producto> BuscarProductos(string textoBusqueda)
        {
            string busqueda = textoBusqueda.ToLower().Trim();

            bool? estado = null;
            if (rbMostrarHabilitados.Checked) estado = true;
            if (rbMostrardeshabilitados.Checked) estado = false;

            IEnumerable<Producto> listaFiltrada = _listaMaestraProductos;

            if (estado.HasValue)
            {
                listaFiltrada = listaFiltrada.Where(p => p.EstadoProducto == estado.Value);
            }

            if (_filtroMarcaId.HasValue)
            {
                listaFiltrada = listaFiltrada.Where(p => p.IdMarca == _filtroMarcaId.Value);
            }

            if (_filtroCategoriaId.HasValue)
            {
                listaFiltrada = listaFiltrada.Where(p => p.IdCategoria == _filtroCategoriaId.Value);
            }

            if (string.IsNullOrEmpty(busqueda))
            {
                return listaFiltrada.ToList();
            }

            var resultados = listaFiltrada.Where(producto =>
                    (producto.NombreProducto != null && producto.NombreProducto.ToLower().Contains(busqueda)) ||
                    (producto.Categoria.NombreCategoria != null && producto.Categoria.NombreCategoria.ToLower().Contains(busqueda)) ||
                    (producto.Marca.NombreMarca != null && producto.Marca.NombreMarca.ToLower().Contains(busqueda)) ||
                    (producto.CodigoBarraProducto != null && producto.CodigoBarraProducto.ToLower().Contains(busqueda))
                ).ToList();

            return resultados;
        }

        // BUSCAR ESCANER
        private bool EsCodigoBarra(string texto)
        {
            return texto.All(char.IsDigit) && texto.Length >= 8 && texto.Length <= 13;
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return || e.KeyChar == '\r')
            {
                string entrada = txtBuscar.Text.Trim();

                if (EsCodigoBarra(entrada))
                {
                    btnBuscar.PerformClick();
                    e.Handled = true;
                }
            }
        }

        // AJUSTE DE ALTURA DE SUGERENCIAS DE BUSQUEDA
        private void AjustarAlturaListBox(int numeroDeResultados)
        {
            int alturaItem = lstSugerencias.ItemHeight;
            int alturaMaxima = (alturaItem * MAX_SUGGESTIONS) + 10;
            int alturaNecesaria = (alturaItem * numeroDeResultados) + 10;
            lstSugerencias.Height = Math.Min(alturaNecesaria, alturaMaxima);
        }

        // SELECCIONAR PRODUCTOS EN GRID
        private void SeleccionarProductoEnGrid(Producto productoBuscado)
        {
            if (productoBuscado == null) return;

            var listaDelGrid = dgvProductos.DataSource as List<Producto>;
            if (listaDelGrid == null) return;

            int indice = listaDelGrid.FindIndex(p => p.IdProducto == productoBuscado.IdProducto);

            if (indice != -1 && indice < dgvProductos.Rows.Count)
            {
                dgvProductos.ClearSelection();
                dgvProductos.Rows[indice].Selected = true;
                dgvProductos.FirstDisplayedScrollingRowIndex = indice;
            }
        }

        // CARGAR TABLA 
        private async Task CargarProductosMaestros()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                _listaMaestraProductos = await productoRepositorio.ObtenerTodosLosProductos(null);
            }
            catch (OperationCanceledException)
            {
                // Manejo silencioso o log
            }
            catch (Exception ex)
            {
                // Solo mostramos mensaje si es un error crítico no controlado por el Gestor
                System.Diagnostics.Debug.WriteLine($"Error cargar productos: {ex.Message}");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        // REFRESCAR TABLA FILTROS DE ESTADO
        private void RefrescarGrid()
        {
            this.Cursor = Cursors.WaitCursor;
            gbxEstado.Enabled = false;

            bool? estado = null;
            if (rbMostrarHabilitados.Checked) estado = true;
            if (rbMostrardeshabilitados.Checked) estado = false;

            bool filtroActivo = (rbMostrarTodos.Checked) ||
                                (rbMostrardeshabilitados.Checked) ||
                                (_filtroMarcaId.HasValue) ||
                                (_filtroCategoriaId.HasValue);

            pnlLimpiarFiltros.Visible = filtroActivo;

            List<Producto> listaFiltrada;

            if (estado == null)
            {
                listaFiltrada = _listaMaestraProductos;
            }
            else
            {
                listaFiltrada = _listaMaestraProductos.Where(p => p.EstadoProducto == estado).ToList();
            }
            if (_filtroMarcaId.HasValue)
            {
                listaFiltrada = listaFiltrada.Where(p => p.IdMarca == _filtroMarcaId.Value).ToList();
            }

            if (_filtroCategoriaId.HasValue)
            {
                listaFiltrada = listaFiltrada.Where(p => p.IdCategoria == _filtroCategoriaId.Value).ToList();
            }

            dgvProductos.DataSource = null;
            dgvProductos.DataSource = listaFiltrada;

            if (dgvProductos.Rows.Count > 0)
                dgvProductos.ClearSelection();

            gbxEstado.Enabled = true;
            this.Cursor = Cursors.Default;
        }

        // EVENTO DE CONTROLES
        private void rbMostrarTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked) RefrescarGrid();
        }

        private void rbMostrarHabilitados_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked) RefrescarGrid();
        }

        private void rbMostrardeshabilitados_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked) RefrescarGrid();
        }

        private async void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            frmAgregarEditarProducto NuevoProducto = new frmAgregarEditarProducto();
            DialogResult resultado = NuevoProducto.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                await CargarProductosMaestros();
                RefrescarGrid();
            }
        }

        private async void btnEditarProducto_Click(object sender, EventArgs e)
        {
            if (ProductoSeleccionado != null)
            {
                frmAgregarEditarProducto EditarProducto = new frmAgregarEditarProducto(ProductoSeleccionado);
                DialogResult resultado = EditarProducto.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    await CargarProductosMaestros();
                    RefrescarGrid();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void HoraFecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss tt", new CultureInfo("es-ES"));
            lblFecha.Text = DateTime.Now.ToString("dddd dd 'de' MMMM 'del' yyyy", new CultureInfo("es-ES"));
        }

        // --- EVENTOS BUSQUEDA ---
        private async void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                return;
            }

            _ctsBusqueda?.Cancel();
            _ctsBusqueda = new CancellationTokenSource();

            try
            {
                await Task.Delay(300, _ctsBusqueda.Token);

                List<Producto> resultados = BuscarProductos(txtBuscar.Text);
                List<Producto> top10 = resultados.Take(10).ToList();

                if (resultados.Count > 0 && !string.IsNullOrEmpty(txtBuscar.Text))
                {
                    lstSugerencias.DataSource = null;
                    lstSugerencias.DataSource = top10;
                    //lstSugerencias.DisplayMember = "NombreProducto";

                    AjustarAlturaListBox(resultados.Count);

                    lstSugerencias.Visible = true;
                }
                else
                {
                    lstSugerencias.Visible = false;
                }
            }
            catch (TaskCanceledException)
            {
                // Búsqueda cancelada
            }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (!lstSugerencias.Visible) return;

            if (e.KeyCode == Keys.Down)
            {
                int newIndex = Math.Min(lstSugerencias.SelectedIndex + 1, lstSugerencias.Items.Count - 1);
                if (newIndex >= 0)
                    lstSugerencias.SelectedIndex = newIndex;

                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                int newIndex = Math.Max(lstSugerencias.SelectedIndex - 1, 0);
                if (newIndex >= 0)
                    lstSugerencias.SelectedIndex = newIndex;
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (lstSugerencias.SelectedItem != null)
                {
                    Producto productoSel = lstSugerencias.SelectedItem as Producto;
                    txtBuscar.Text = productoSel.ToString();
                    txtBuscar.SelectionStart = txtBuscar.Text.Length;

                    lstSugerencias.Visible = false;
                    _ctsBusqueda?.Cancel();
                    SeleccionarProductoEnGrid(productoSel);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
        }

        private async void txtBuscar_Leave(object sender, EventArgs e)
        {
            await Task.Delay(200);
            if (!lstSugerencias.Focused)
            {
                lstSugerencias.Visible = false;
            }
        }

        private void lstSugerencias_MouseClick(object sender, MouseEventArgs e)
        {
            if (lstSugerencias.SelectedItem != null)
            {
                Producto productoSel = lstSugerencias.SelectedItem as Producto;
                txtBuscar.Text = productoSel.ToString();
                txtBuscar.SelectionStart = txtBuscar.Text.Length;
                lstSugerencias.Visible = false;
                _ctsBusqueda?.Cancel();
                SeleccionarProductoEnGrid(productoSel);
                txtBuscar.Text = "";
            }
        }

        private void lstSugerencias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && lstSugerencias.SelectedItem != null)
            {
                Producto productoSel = lstSugerencias.SelectedItem as Producto;
                if (productoSel != null)
                {
                    _ignorarTextChanged = true;
                    txtBuscar.Text = productoSel.ToString();
                    txtBuscar.SelectionStart = txtBuscar.Text.Length;
                    txtBuscar.SelectionLength = 0;
                    _ignorarTextChanged = false;

                    lstSugerencias.Visible = false;
                    sugerenciaActual = "";
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void lstSugerencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_usuarioSeleccionoConMouse) return;

            if (lstSugerencias.SelectedItem != null)
            {
                Producto productoSel = lstSugerencias.SelectedItem as Producto;
                if (productoSel != null)
                {
                    txtBuscar.Text = productoSel.ToString();
                    lstSugerencias.Visible = false;
                }
            }
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                var filaSeleccionada = dgvProductos.SelectedRows[0];
                Producto producto = filaSeleccionada.DataBoundItem as Producto;

                if (producto != null)
                {
                    ProductoSeleccionado = producto;
                }
            }
            else
            {
                ProductoSeleccionado = null;
            }
        }

        // BOTONES ACCIONES
        private void btnSalir_Click(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            this.Close();
        }

        private void btnMarca_Click(object sender, EventArgs e)
        {
            using (var marcasForm = new frmMarcas())
            {
                if (marcasForm.ShowDialog() == DialogResult.OK)
                {
                    txtFiltroMarca.Text = marcasForm.MarcaSeleccionada.NombreMarca;
                    _filtroMarcaId = marcasForm.MarcaSeleccionada.IdMarca;
                    RefrescarGrid();
                }
            }
        }

        private void btnIngresarPerdida_Click(object sender, EventArgs e)
        {
            frmAgregarEditarProducto perdida = new frmAgregarEditarProducto();
            perdida.ShowDialog();
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            frmCategorias categorias = new frmCategorias();
            categorias.ShowDialog();
        }

        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            frmMarcas marcas = new frmMarcas();
            marcas.ShowDialog();
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            using (var categoriasForm = new frmCategorias())
            {
                if (categoriasForm.ShowDialog() == DialogResult.OK)
                {
                    txtFiltroCategoria.Text = categoriasForm.CategoriaSeleccionada.NombreCategoria;
                    _filtroCategoriaId = categoriasForm.CategoriaSeleccionada.IdCategoria;
                    RefrescarGrid();
                }
            }
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            _filtroMarcaId = null;
            _filtroCategoriaId = null;

            txtFiltroMarca.Text = "";
            txtFiltroCategoria.Text = "";

            txtBuscar.Text = "";
            rbMostrarHabilitados.Checked = true;

            RefrescarGrid();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(busqueda)) return;

            // 1. Primero intentamos buscar EXACTAMENTE por Código de Barras (Prioridad Alta)
            // Usamos FirstOrDefault porque el código de barras debería ser único.
            Producto productoPorCodigo = _listaMaestraProductos.FirstOrDefault(p =>
                p.CodigoBarraProducto != null && p.CodigoBarraProducto.Equals(busqueda));

            if (productoPorCodigo != null)
            {
                // Si encontramos por código, mostramos solo ese
                dgvProductos.DataSource = new List<Producto> { productoPorCodigo };
                pnlLimpiarFiltros.Visible = true;
            }
            else
            {
                // 2. Si no es código, buscamos por TEXTO CONCATENADO (Nombre + Marca + Presentación...)
                // Usamos 'Where' en lugar de 'FirstOrDefault' para traer TODAS las coincidencias
                // y usamos .ToString() para buscar en toda la información junta.

                var productosEncontrados = _listaMaestraProductos.Where(p =>
                    p.ToString().IndexOf(busqueda, StringComparison.OrdinalIgnoreCase) >= 0
                ).ToList();

                if (productosEncontrados.Count > 0)
                {
                    dgvProductos.DataSource = null; // Limpiamos primero
                    dgvProductos.DataSource = productosEncontrados; // Mostramos todos los que coincidan
                    pnlLimpiarFiltros.Visible = true;
                }
                else
                {
                    MessageBox.Show("No se encontraron productos con esa descripción.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Opcional: Si no encuentra nada, ¿quieres recargar todo?
                    // RefrescarGrid(); 
                }
            }

            // Limpieza final de UI
            txtBuscar.Clear();
            lstSugerencias.Visible = false;
        }
    }
}