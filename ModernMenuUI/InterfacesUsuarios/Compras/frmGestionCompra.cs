using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Repositorios;
using CapaDominio.Reportes;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.InterfacesUsuarios.Compras;
using Sprache;
using Supabase;
using Supabase.Realtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Supabase.Postgrest.Constants;
using static Supabase.Realtime.PostgresChanges.PostgresChangesOptions;


namespace ModernMenuUI
{
    public partial class frmGestionCompra : Form
    {
        #region Campos
        private readonly ProductoRepositorio _productoRepositorio;
        private readonly ProveedorRepositorio _proveedorRepositorio;
        private readonly ServicioVerificacionConexion _monitorConexion = new ServicioVerificacionConexion();

        private List<Proveedor> _listaMaestraProveedores = new List<Proveedor>();
        private List<Producto> _listaMaestraProductos = new List<Producto>();

        private Producto _productoSeleccionado;
        private Proveedor _proveedorSeleccionado = null;

        private Supabase.Client? _supabaseClient;
        private Supabase.Realtime.RealtimeChannel? _productosSubscription;
        private CancellationTokenSource _ctsBusqueda;
        private bool _ignorarTextChanged = false;
        private bool _usuarioSeleccionoConMouse = false;
        private string _sugerenciaActual = "";
        private const int MAX_SUGGESTIONS = 10;
        private decimal precio_nuevo = 0;
        #endregion

        #region Constructor
        public frmGestionCompra()
        {
            InitializeComponent();

            // Configuraciones UI
            this.DoubleBuffered = true;
            dgvProductos.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#DCE6F1");
            dgvProductos.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#57636e");
            dgvProductos.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            _productoRepositorio = new ProductoRepositorio();
            _proveedorRepositorio = new ProveedorRepositorio();

            dgvProductos.AutoGenerateColumns = false;
        }
        #endregion

        #region Load y Suscripciones Realtime
        private async void frmGestionCompra_Load(object sender, EventArgs e)
        {
            _monitorConexion.EstadoDeRedCambiado += MonitorConexion_EstadoDeRedCambiado;
            await CargarProveedoresMaestros();
            _listaMaestraProductos.Clear();
            dgvProductos.DataSource = null;
            await IniciarSuscripcionProductos();
        }

        private async Task CargarProductosMaestros()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                _listaMaestraProductos = await _productoRepositorio.ObtenerActivos(true);
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("No se pudo conectar con el servidor (tiempo de espera agotado).", "Error de Red", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar productos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private async Task CargarProveedoresMaestros()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
                _listaMaestraProveedores = await _proveedorRepositorio.ObtenerTodosLosProveedores(cts.Token);
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("No se pudo conectar con el servidor (tiempo de espera agotado).", "Error de Red", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar proveedores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void RefrescarGrid()
        {
            this.Cursor = Cursors.WaitCursor;
            bool? estado = true;

            var listaFiltrada = _listaMaestraProductos
                .Where(p => p.EstadoProducto == estado)
                .ToList();

            dgvProductos.DataSource = listaFiltrada;

            if (dgvProductos.Rows.Count > 0)
                dgvProductos.ClearSelection();

            this.Cursor = Cursors.Default;
        }

        private async Task DesecharSuscripcion()
        {
            if (_productosSubscription != null)
            {
                try
                {
                    await Task.Run(() => _productosSubscription.Unsubscribe());
                    System.Diagnostics.Debug.WriteLine("Suscripción de Productos desechada.");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error al desechar suscripción Productos: {ex.Message}");
                }
                _productosSubscription = null;
            }
        }

        private async Task IniciarSuscripcionProductos()
        {
            await DesecharSuscripcion();

            try
            {
                _supabaseClient = await Conexion.ConnectWithTimeoutAsync(3);

                _productosSubscription = await _supabaseClient.From<Producto>()
                    .On(ListenType.All, (sender, change) =>
                    {
                        try
                        {
                            if (this == null || this.IsDisposed || !this.IsHandleCreated) return;

                            this.BeginInvoke((MethodInvoker)(async () =>
                            {
                                if (this.IsDisposed) return;
                                System.Diagnostics.Debug.WriteLine($"Cambio detectado: {change.Event} en Productos.");

                                await CargarProductosMaestros();
                                RefrescarGrid();
                            }));
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"Error manejando evento Realtime Productos: {ex.Message}");
                        }
                    });

                System.Diagnostics.Debug.WriteLine("Suscripción a Realtime (Productos) creada.");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al suscribir a Realtime (Productos): {ex.Message}");
            }
        }

        private async void MonitorConexion_EstadoDeRedCambiado(NetworkStatus status)
        {
            if (!this.IsHandleCreated || this.IsDisposed) return;

            if (status == NetworkStatus.Internet)
            {
                this.BeginInvoke((MethodInvoker)(async () =>
                {
                    if (this.IsDisposed) return;
                    System.Diagnostics.Debug.WriteLine("Red recuperada. Recargando Productos y Realtime...");
                    await IniciarSuscripcionProductos();
                }));
            }
        }
        #endregion

        #region UI Básicos y Selección Producto
        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            this.Close();
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null && dgvProductos.CurrentRow.Selected)
            {
                txtCodigo.Text = dgvProductos.CurrentRow.Cells[0].Value?.ToString() ?? "";
                txtProducto.Text = dgvProductos.CurrentRow.Cells[1].Value?.ToString() ?? "";
                txtPrecio.Text = dgvProductos.CurrentRow.Cells[4].Value?.ToString() ?? "";
            }
            else
            {
                txtProducto.Text = "";
                txtPrecio.Text = "";
                txtCodigo.Text = "";
            }
        }
        #endregion

        #region Eventos Carrito (mouse / click / agregar)
        private void dgvCarrito_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 4 && e.RowIndex < dgvCarrito.RowCount && e.ColumnIndex < dgvCarrito.ColumnCount)
                dgvCarrito[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.LightBlue;
        }

        private void dgvCarrito_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 4 && e.RowIndex < dgvCarrito.RowCount && e.ColumnIndex < dgvCarrito.ColumnCount)
                dgvCarrito[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;
        }

        private void dgvCarrito_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 5 && e.RowIndex < dgvCarrito.RowCount)
                dgvCarrito[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Gray;
        }

        private void dgvCarrito_CellMouseUp(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvCarrito.RowCount && e.ColumnIndex >= 4 && e.ColumnIndex <= 6 && e.ColumnIndex < dgvCarrito.ColumnCount)
            {
                dgvCarrito[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;
                dgvCarrito[e.ColumnIndex, e.RowIndex].Selected = false;
            }
        }

        private void dgvCarrito_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Validar que se hizo clic dentro de una fila válida
            if (e.RowIndex < 0 || e.RowIndex >= dgvCarrito.RowCount) return;

            // --- COLUMNA 4: ELIMINAR ---
            if (e.ColumnIndex == 4)
            {
                if (dgvCarrito.CurrentRow != null)
                {
                    dgvCarrito.Rows.RemoveAt(e.RowIndex);
                    ActualizarTotales();
                }

                return;
            }

            // --- COLUMNA 5: RESTAR ---
            if (e.ColumnIndex == 5)
            {
                // Leemos la cantidad actual (Celda 3)
                if (int.TryParse(dgvCarrito.Rows[e.RowIndex].Cells[3].Value?.ToString(), out int cantidad))
                {
                    if (cantidad > 1)
                    {
                        dgvCarrito.Rows[e.RowIndex].Cells[3].Value = cantidad - 1;
                        ActualizarTotales();
                    }
                    else
                    {
                        MessageBox.Show("La cantidad no puede ser menor a 1", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                return;
            }

            // --- COLUMNA 6: SUMAR (Posición Original) ---
            if (e.ColumnIndex == 6)
            {
                if (int.TryParse(dgvCarrito.Rows[e.RowIndex].Cells[3].Value?.ToString(), out int cantidad))
                {
                    if (cantidad < 400)
                    {
                        dgvCarrito.Rows[e.RowIndex].Cells[3].Value = cantidad + 1;
                        ActualizarTotales();
                    }
                    else
                    {
                        MessageBox.Show("La cantidad máxima por producto es 400.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                return;
            }
        }

        private void AgregarAlCarrito(string codigoBarra, int cantidadAgregar)
        {
            // 1. Validaciones básicas
            if (string.IsNullOrWhiteSpace(codigoBarra)) return;
            string codigoBuscado = codigoBarra.Trim();

            // 2. Recursos
            Image Eliminar = Properties.Resources.eliminar__1_;
            Image Restar = Properties.Resources.signo_menos__1_;
            Image Sumar = Properties.Resources.mas__2_;

            // 3. Buscar producto en la Grilla de Productos (dgvProductos)
            DataGridViewRow producto = null;
            foreach (DataGridViewRow fila in dgvProductos.Rows)
            {
                string valCelda = fila.Cells[0].Value?.ToString();
                if (!string.IsNullOrEmpty(valCelda) &&
                    valCelda.Trim().Equals(codigoBuscado, StringComparison.OrdinalIgnoreCase))
                {
                    producto = fila;
                    break;
                }
            }

            if (producto == null)
            {
                MessageBox.Show($"Producto '{codigoBarra}' no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Obtener datos
            string descripcion = producto.Cells[1].Value?.ToString() ?? "";
            decimal costo = 0;
            decimal.TryParse(producto.Cells[4].Value?.ToString(), out costo);

            // 5. Verificar si ya existe en el Carrito (para sumar)
            foreach (DataGridViewRow filaCarrito in dgvCarrito.Rows)
            {
                string codCarrito = filaCarrito.Cells[0].Value?.ToString();
                if (codCarrito != null && codCarrito.Equals(codigoBuscado, StringComparison.OrdinalIgnoreCase))
                {
                    int cantActual = Convert.ToInt32(filaCarrito.Cells[3].Value);
                    int nuevaCant = cantActual + cantidadAgregar;

                    if (nuevaCant > 400) nuevaCant = 400;

                    filaCarrito.Cells[3].Value = nuevaCant;
                    return; // Ya actualizamos, salimos.
                }
            }

            // 6. Agregar nueva fila (ESTRUCTURA ORIGINAL DE 7 COLUMNAS)
            int cantidadFinal = Math.Min(cantidadAgregar, 400);

            // Índices: 0=Código, 1=Desc, 2=Precio, 3=Cant, 4=Del, 5=Restar, 6=Sumar
            if (txtNuevoPrecio.Enabled == false)
            {
                dgvCarrito.Rows.Add(codigoBuscado, descripcion, costo, cantidadFinal, Eliminar, Restar, Sumar);
            }
            else
            {
                decimal precioNuevo = txtNuevoPrecio.Value;
                dgvCarrito.Rows.Add(codigoBuscado, descripcion, precioNuevo, cantidadFinal, Eliminar, Restar, Sumar);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var datoscompra = ((int)nudCantidad.Value, txtCodigo.Text, txtProducto.Text);

            var resultado = ServicioValidacionesIngresoDatos.EjecutarValidacionesCompra(datoscompra);
            if (resultado.Error)
            {
                MessageBox.Show(resultado.Mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- CAMBIO AQUÍ ---
            // Pasamos txtCodigo.Text directamente (es string), ya no lo convertimos a Int32
            if (txtNuevoPrecio.Enabled == false && !chkprecioNuevo.Checked)
            {
                AgregarAlCarrito(txtCodigo.Text, Convert.ToInt32(nudCantidad.Value));

                // Reiniciar controles
                nudCantidad.Value = 1;
                //txtNuevoPrecio.Value = 1;
                txtCodigo.Text = null;
                txtProducto.Text = null;
                dgvProductos.ClearSelection();
                chkprecioNuevo.Checked = false;
                txtPrecio.Text = null;
                ActualizarTotales();
                ActualizarImagenCarrito();

            }
            else
            {
                precio_nuevo = txtNuevoPrecio.Value;


                if (precio_nuevo == 0)
                {
                    MessageBox.Show("Error, campo vacio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                AgregarAlCarrito(txtCodigo.Text, Convert.ToInt32(nudCantidad.Value));

                //reiniciar controles

                nudCantidad.Value = 1;
                txtCodigo.Text = null;
                txtProducto.Text = null;
                dgvProductos.ClearSelection();
                txtNuevoPrecio.Enabled = false;
                //chkprecioNuevo.Checked = false;

                //guardar datos en los subtotales
                ActualizarTotales();
            }
        }
        #endregion

        #region Registrar Compra
        private async void btnAgregarCompra_Click(object sender, EventArgs e)
        {

            //Variables

            var supabase = await CapaDeDatos.Datos.Conexion.GetClientAsync();
            var Actual = supabase.Auth.CurrentUser;
            var idProveedor = _proveedorSeleccionado?.IdProveedor;
            var respEmpleado = await CompraRepositorio.getUserId(Actual.Id);
            int idEmpleado = respEmpleado.IdUsuario;
            int idBodega = CapaServiciosSeguridadValidacion.ServicioSesionUsuario.ObtenerIdBodega();
            var detalles = dgvCarrito.Rows
                .Cast<DataGridViewRow>()
                .Where(r => !r.IsNewRow)
                .Select(r => new
                {
                    id_producto = Convert.ToString(r.Cells[0].Value),
                    cantidad_compra = Convert.ToInt32(r.Cells[3].Value)
                }).ToList();

            //validaciones locales, estoy viendo como putas ponerlas en la capa de validaciones sin que se vuelva un quilombo, por ahora las dejo aquí
            if (_proveedorSeleccionado == null)
            {
                MessageBox.Show("Por favor seleccione un proveedor antes de registrar la compra.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgvCarrito.Rows.Count == 0)
            {
                MessageBox.Show($"Por favor seleccione un Producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Actual == null)
            {
                throw new Exception("No hay usuario autenticado en la sesión actual.");
            }


            if (respEmpleado == null)
            {
                MessageBox.Show("No se encontró empleado asociado al usuario autenticado.");
                return;
            }

            try
            {
                //MessageBox.Show($"Enabled: {txtNuevoPrecio.Enabled} | Checked: {chkprecioNuevo.Checked}");
                if (precio_nuevo != 0)
                {
                    decimal precioNuevo = txtNuevoPrecio.Value;

                    foreach (DataGridViewRow row in dgvCarrito.Rows)
                    {
                        if (row.IsNewRow) continue;

                        this.Cursor = Cursors.WaitCursor;

                        string codigoBarra = row.Cells[0].Value.ToString();
                        int cantidadIngresar = Convert.ToInt32(row.Cells[3].Value);

                        //Preparar parámetros para la función RPC
                        var parametrosPrecio = new
                        {
                            p_id_empleado = idEmpleado,
                            p_id_producto = codigoBarra,
                            p_cantidad_ingresar = cantidadIngresar,
                            p_precio_nuevo = precioNuevo,
                            p_id_bodega = idBodega
                        };

                        await supabase.Rpc("actualizar_precios_producto_tras_compra", parametrosPrecio);
                        MessageBox.Show("Precio ingresado correctamente y compra realizada sin errores.", "Compra ingresada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    this.Cursor = Cursors.WaitCursor;
                    //Preparar parámetros para la función RPC
                    var parametros = new
                    {
                        p_id_empleado = idEmpleado,
                        p_id_proveedor = idProveedor,
                        p_id_bodega = idBodega,
                        p_fecha_compra = DateTime.UtcNow,
                        p_detalles = detalles
                    };
                    await supabase.Rpc("registrar_compra_nuevo_inv", parametros);

                    MessageBox.Show($"Compra registrada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar la compra: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                limpiarcosas();
            }
        }
        private void limpiarcosas()
        {
            this.Cursor = Cursors.Default;
            dgvCarrito.Rows.Clear();
            _proveedorSeleccionado = null;
            txtNombreProveedor.Text = "";
            txtSubTotal.Text = "0.00";
            txtImpuesto.Text = "0.00";
            txtTotal.Text = "0.00";
            nudCantidad.Value = 1;
            _listaMaestraProductos.Clear();
            dgvProductos.DataSource = null;
            dgvProductos.Rows.Clear();
            chkprecioNuevo.CheckedChanged -= chkprecioNuevo_CheckedChanged;
            chkprecioNuevo.Checked = false;
            chkprecioNuevo.CheckedChanged += chkprecioNuevo_CheckedChanged;
            txtNuevoPrecio.Enabled = false;
            txtNuevoPrecio.Value = 1;
            ActualizarImagenCarrito();
        }
        #endregion

        private void ActualizarTotales()
        {
            decimal subtotal = 0;

            foreach (DataGridViewRow fila in dgvCarrito.Rows)
            {
                if (fila.Cells[2].Value != null && fila.Cells[3].Value != null)
                {
                    decimal precio = Convert.ToDecimal(fila.Cells[2].Value);
                    int cantidad = Convert.ToInt32(fila.Cells[3].Value);

                    subtotal += (precio * cantidad);
                }
            }

            decimal impuesto = subtotal * 0.15m;

            decimal total = subtotal + impuesto;

            txtSubTotal.Text = subtotal.ToString("N2");
            txtImpuesto.Text = impuesto.ToString("N2");
            txtTotal.Text = total.ToString("N2");
        }

        #region UI Helpers
        private void ActualizarImagenCarrito()
        {
            pbxCarritoVacio.Visible = dgvCarrito.Rows.Count == 0;
        }
        #endregion

        #region Búsqueda y Sugerencias Proveedores
        // Filtra la lista maestra de proveedores (sin usar teléfono)
        private List<Proveedor> BuscarProveedores(string textoBusqueda)
        {
            string busqueda = textoBusqueda?.ToLower().Trim() ?? "";

            if (string.IsNullOrEmpty(busqueda))
            {
                return _listaMaestraProveedores.Where(p => p.EstadoProveedor == true).ToList();
            }

            var resultados = _listaMaestraProveedores.Where(proveedor =>
                    proveedor.EstadoProveedor == true &&
                    (
                        (!string.IsNullOrEmpty(proveedor.NombreProveedor) && proveedor.NombreProveedor.ToLower().Contains(busqueda)) ||
                        (!string.IsNullOrEmpty(proveedor.DireccionProveedor) && proveedor.DireccionProveedor.ToLower().Contains(busqueda))
                    )
                ).ToList();

            return resultados;
        }

        private List<Producto> BuscarProductos(string textoBusqueda)
        {
            string busqueda = textoBusqueda?.ToLower().Trim() ?? "";

            if (string.IsNullOrEmpty(busqueda))
                return _listaMaestraProductos;

            return _listaMaestraProductos
                .Where(p =>
                    (p.NombreProducto != null && p.NombreProducto.ToLower().Contains(busqueda)) ||
                    (p.CodigoBarraProducto != null && p.CodigoBarraProducto.ToLower().Contains(busqueda))
                )
                .ToList();
        }

        private void AjustarAlturaListBox(int numeroDeResultados)
        {
            int alturaItem = lstSugerencias.ItemHeight;
            int alturaMaxima = (alturaItem * MAX_SUGGESTIONS) + 10;
            int alturaNecesaria = (alturaItem * numeroDeResultados) + 10;
            lstSugerencias.Height = Math.Min(alturaNecesaria, alturaMaxima);

            lstSugerenciasCompra.Height = Math.Min(alturaNecesaria, alturaMaxima);
        }

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

                List<Proveedor> resultados = BuscarProveedores(txtNombreProveedor.Text);
                List<Proveedor> top10 = resultados.Take(MAX_SUGGESTIONS).ToList();

                if (resultados.Count > 0 && !string.IsNullOrEmpty(txtNombreProveedor.Text))
                {
                    lstSugerencias.DataSource = null;
                    lstSugerencias.DataSource = top10;
                    lstSugerencias.DisplayMember = "NombreProveedor";
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
                // Búsqueda cancelada por el usuario: normal
            }
        }

        private async void txtBuscarProductos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                return;

            _ctsBusqueda?.Cancel();
            _ctsBusqueda = new CancellationTokenSource();

            try
            {
                await Task.Delay(300, _ctsBusqueda.Token);

                var resultados = BuscarProductos(txtBuscarProducto.Text);
                var top = resultados.Take(10).ToList();

                if (top.Count > 0 && !string.IsNullOrEmpty(txtBuscarProducto.Text))
                {
                    lstSugerenciasCompra.DataSource = null;
                    lstSugerenciasCompra.DataSource = top;
                    lstSugerenciasCompra.DisplayMember = "NombreProducto";

                    AjustarAlturaListBox(top.Count);
                    lstSugerenciasCompra.Visible = true;
                }
                else
                {
                    lstSugerenciasCompra.Visible = false;
                }
            }
            catch (TaskCanceledException) { }
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
                _ = EjecutarBusqueda();

                if (lstSugerencias.SelectedItem != null)
                {
                    Proveedor proveedorSel = lstSugerencias.SelectedItem as Proveedor;
                    txtNombreProveedor.Text = proveedorSel?.NombreProveedor ?? "";
                    txtNombreProveedor.SelectionStart = txtNombreProveedor.Text.Length;
                    lstSugerencias.Visible = false;
                    _ctsBusqueda?.Cancel();
                    _proveedorSeleccionado = proveedorSel;
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void txtBuscarProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (!lstSugerenciasCompra.Visible) return;

            if (e.KeyCode == Keys.Down)
            {
                int i = Math.Min(lstSugerenciasCompra.SelectedIndex + 1, lstSugerenciasCompra.Items.Count - 1);
                if (i >= 0) lstSugerenciasCompra.SelectedIndex = i;
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                int i = Math.Max(lstSugerenciasCompra.SelectedIndex - 1, 0);
                if (i >= 0) lstSugerenciasCompra.SelectedIndex = i;
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (lstSugerenciasCompra.SelectedItem is Producto prod)
                {
                    txtBuscarProducto.Text = prod.NombreProducto;

                    txtCodigo.Text = prod.CodigoBarraProducto;
                    txtProducto.Text = prod.NombreProducto;
                    txtPrecio.Text = prod.PrecioVenta.ToString();

                    lstSugerenciasCompra.Visible = false;
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private async Task EjecutarBusqueda()
        {
            try
            {
                await HandleBuscarProveedorAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error durante la búsqueda del proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (_ignorarTextChanged) return;
            _sugerenciaActual = "";
            _proveedorSeleccionado = null;
        }

        private async void txtBuscar_Leave(object sender, EventArgs e)
        {
            await Task.Delay(150);
            if (!lstSugerencias.Focused)
            {
                lstSugerencias.Visible = false;
            }
        }

        private async void txtBuscarProductos_Leave(object sender, EventArgs e)
        {
            await Task.Delay(150);
            if (!lstSugerenciasCompra.Focused)
                lstSugerenciasCompra.Visible = false;
        }

        private void lstSugerencias_MouseClick(object sender, MouseEventArgs e)
        {
            if (lstSugerencias.SelectedItem != null)
            {
                Proveedor proveedorSel = lstSugerencias.SelectedItem as Proveedor;
                txtNombreProveedor.Text = proveedorSel?.NombreProveedor ?? "";
                txtNombreProveedor.SelectionStart = txtNombreProveedor.Text.Length;
                lstSugerencias.Visible = false;
                _ctsBusqueda?.Cancel();
                _proveedorSeleccionado = proveedorSel;
            }
        }

        private void lstSugerenciasCompra_MouseClick(object sender, MouseEventArgs e)
        {
            if (lstSugerenciasCompra.SelectedItem is Producto prod)
            {
                txtBuscarProducto.Text = prod.NombreProducto;
                txtBuscarProducto.SelectionStart = txtBuscarProducto.Text.Length;

                lstSugerenciasCompra.Visible = false;

                // Cargar en inputs (igual que tu grid)
                txtCodigo.Text = prod.CodigoBarraProducto;
                txtProducto.Text = prod.NombreProducto;
                txtPrecio.Text = prod.PrecioVenta.ToString();
            }
        }

        private void lstSugerencias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && lstSugerencias.SelectedItem != null)
            {
                Proveedor proveedorSel = lstSugerencias.SelectedItem as Proveedor;
                if (proveedorSel != null)
                {
                    _ignorarTextChanged = true;
                    txtNombreProveedor.Text = proveedorSel.NombreProveedor;
                    txtNombreProveedor.SelectionStart = txtNombreProveedor.Text.Length;
                    txtNombreProveedor.SelectionLength = 0;
                    _ignorarTextChanged = false;

                    lstSugerencias.Visible = false;
                    _sugerenciaActual = "";
                    _proveedorSeleccionado = proveedorSel;
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
                Proveedor proveedorSel = lstSugerencias.SelectedItem as Proveedor;
                if (proveedorSel != null)
                {
                    txtNombreProveedor.Text = proveedorSel.NombreProveedor;
                    lstSugerencias.Visible = false;
                    _proveedorSeleccionado = proveedorSel;
                }
            }
        }

        private void lstSugerencias_MouseDown(object sender, MouseEventArgs e)
        {
            _usuarioSeleccionoConMouse = true;
        }

        private void lstSugerencias_MouseUp(object sender, MouseEventArgs e)
        {
            Task.Run(async () =>
            {
                await Task.Delay(50);
                _usuarioSeleccionoConMouse = false;
            });
        }
        #endregion

        #region Buscar Proveedor (botones)
        // Método helper para evitar duplicación entre dos botones que hacían lo mismo.
        private async Task HandleBuscarProveedorAsync()
        {
            string nombre = txtNombreProveedor.Text?.Trim() ?? "";

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Ingrese el nombre del proveedor para buscar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            try
            {
                // 1. Obtener id del proveedor por nombre
                var idProveedor = await ProveedorRepositorio.ObtenerIdProveedorPorNombreAsync(nombre);

                if (idProveedor == null)
                {
                    MessageBox.Show("No se encontró un proveedor con ese nombre.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 2. Cargar proveedor (desde memoria o Supabase)
                _proveedorSeleccionado = _listaMaestraProveedores
                    .FirstOrDefault(p => p.IdProveedor == idProveedor.Value);

                if (_proveedorSeleccionado == null)
                {
                    _proveedorSeleccionado = await ProveedorRepositorio.CargarProveedorPorIdAsync(idProveedor.Value);
                    if (_proveedorSeleccionado != null)
                        _listaMaestraProveedores.Add(_proveedorSeleccionado);
                }

                if (_proveedorSeleccionado == null)
                {
                    MessageBox.Show("Error cargando la información del proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 3. Obtener marcas asociadas al proveedor
                var marcas = await MarcaRepositorio.ObtenerMarcasPorProveedorAsync(_proveedorSeleccionado.IdProveedor);

                if (marcas == null || marcas.Count == 0)
                {
                    MessageBox.Show("El proveedor no tiene marcas asociadas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 4. Obtener productos por hoja de marcas
                var idMarcas = marcas.Select(m => m.IdMarca).ToList();
                var productos = await _productoRepositorio.ObtenerProductosPorMarcasAsync(idMarcas);

                // 5. Actualizar grid
                _listaMaestraProductos = productos;
                RefrescarGrid();
                /*
                 *Esto es solo si se quiere mostrar el mensaje de que se selecciono un proveedor
                 *
                 *   MessageBox.Show(
                 *       $"Proveedor seleccionado:\nID: {_proveedorSeleccionado.IdProveedor}\nNombre: {_proveedorSeleccionado.NombreProveedor}",
                 *       "Proveedor encontrado",
                 *       MessageBoxButtons.OK,
                 *       MessageBoxIcon.Information
                 *   );
                 */
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        private async void btnBuscarProv_Click(object sender, EventArgs e)
        {
            using (var frm = new frmProveedor())
            {
                var result = frm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    var prov = frm.ProveedorSeleccionado;
                    txtNombreProveedor.Text = prov.NombreProveedor;
                    await HandleBuscarProveedorAsync();
                }
            }

        }
        #endregion

        private async void btnImprimirOrden_Click(object sender, EventArgs e)
        {
            if (dgvCarrito.Rows.Count == 0)
            {
                MessageBox.Show("El carrito está vacío. Agregue productos para generar la orden.",
                                "Carrito Vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombreProveedor.Text))
            {
                MessageBox.Show("Por favor escriba o seleccione un proveedor antes de generar el reporte.",
                                "Falta Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreProveedor.Focus();
                return;
            }

            // 3. OBTENER EL NOMBRE DEL USUARIO
            this.Cursor = Cursors.WaitCursor;
            string nombreUsuario = CapaServiciosSeguridadValidacion.ServicioSesionUsuario.ObtenerEmailUsuario();
            this.Cursor = Cursors.Default;

            List<OrdenCompra> itemsParaReporte = new List<OrdenCompra>();

            // 4. LEER EL CARRITO (CORREGIDO)
            foreach (DataGridViewRow row in dgvCarrito.Rows)
            {
                if (row.IsNewRow) continue;

                OrdenCompra item = new OrdenCompra();

                // --- CAMBIOS AQUÍ: Usar índices en lugar de nombres ---
                // Índice 0: Código de Barra (String)
                item.Codigo = row.Cells[0].Value?.ToString() ?? "";

                // Índice 1: Descripción/Producto
                item.Producto = row.Cells[1].Value?.ToString() ?? "";

                // Índice 2: Precio/Costo
                item.Precio = Convert.ToDecimal(row.Cells[2].Value ?? 0);

                // Índice 3: Cantidad
                item.Cantidad = Convert.ToInt32(row.Cells[3].Value ?? 0);

                itemsParaReporte.Add(item);
            }

            // ... (El resto del método paso 5, 6 y 7 queda igual) ...

            // 5. LEER LOS TOTALES
            string sub = txtSubTotal.Text;
            string imp = txtImpuesto.Text;
            string total = txtTotal.Text;

            // 6. OBTENER EL PROVEEDOR
            string nombreProveedor = txtNombreProveedor.Text.Trim();

            // 7. CREAR Y MOSTRAR EL REPORTE
            frmReporteOrdenCompra frmReporte = new frmReporteOrdenCompra(
                itemsParaReporte,
                sub,
                imp,
                total,
                nombreProveedor,
                nombreUsuario
            );

            frmReporte.ShowDialog();
        }

        private async void txtBuscarProv_Enter(object sender, EventArgs e)
        {

        }

        private void chkprecioNuevo_CheckedChanged(object sender, EventArgs e)
        {
            if (_proveedorSeleccionado == null)
            {
                chkprecioNuevo.CheckedChanged -= chkprecioNuevo_CheckedChanged;
                chkprecioNuevo.Checked = false;
                chkprecioNuevo.CheckedChanged += chkprecioNuevo_CheckedChanged;

                MessageBox.Show("Porfavor seleccione un proveedor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                txtNuevoPrecio.Enabled = chkprecioNuevo.Checked;
                if (!chkprecioNuevo.Checked)
                {
                    txtNuevoPrecio.Value = 1;
                    txtNuevoPrecio.Enabled = false;
                }
            }

        }

        private void btnBuscarProductos_Click(object sender, EventArgs e)
        {

        }
    }

}
