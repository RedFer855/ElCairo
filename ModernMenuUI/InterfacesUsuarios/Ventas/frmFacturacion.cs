using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using CapaDeDatos.Modelados.Inventario;
using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Modelados.UsuariosEmpleados;
using CapaDeDatos.Modelados.Ventas;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using Microsoft.VisualBasic.ApplicationServices;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.Properties;
using Supabase.Realtime;
using Supabase.Realtime.Interfaces;
using Supabase.Realtime.PostgresChanges;
using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing;
using System.Linq;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using static ModernMenuUI.frmInicioBodega;
using static Supabase.Postgrest.Constants;
using static Supabase.Realtime.PostgresChanges.PostgresChangesOptions;

namespace ModernMenuUI
{
    public partial class frmFacturacion : Form
    {
        private readonly ProductoRepositorio _productoRepo;
        private Supabase.Client? _supabaseClient;
        private RealtimeChannel? _productoSubscription;
        private List<Producto> _productosCache = new List<Producto>();
        private InventarioRepositorio _inventarioRepo = new InventarioRepositorio();
        private ClienteRepositorio _clienteRepo = new ClienteRepositorio();
        private List<Cliente> _todosLosClientes = new List<Cliente>(); // La caché
        private Cliente _clienteSeleccionado = null; // Aquí guardaremos al elegido

        private GestorRealtime<Inventario> _gestorInventario;
        private GestorRealtime<Producto> _gestorProducto;

        public frmFacturacion()
        {
            InitializeComponent();
            ConfigurarFormulario();
            // _productoRepo = new ProductoRepositorio();
            _inventarioRepo = new InventarioRepositorio();
            // ===== ESTILO BARRA LATERAL (RowHeader) =====
            dgvProductos.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#DCE6F1");
            dgvProductos.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#57636e");
            dgvProductos.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            clsAnmaciones.ActivarDoubleBuffering(dgvCarrito);
            clsAnmaciones.ActivarDoubleBuffering(dgvProductos);
            txtBuscar.PlaceholderText = "Buscar producto...";
            txtBuscar.ForeColor = Color.Black; // Esto cambia el color del texto normal
            dgvProductos.ClearSelection();
            this.Load += Gestion_de_Ventas_Load;
            this.FormClosing += frmFacturacion_FormClosing;

        }


        // FUNCIONES
        private void RefrescarGridVisualmente()
        {
            // Si el usuario está buscando, reaplicamos filtro sobre la memoria actualizada
            if (!string.IsNullOrEmpty(txtBuscar.Text.Trim()))
            {
                txtBuscar_TextChanged(null, null);
            }
            else
            {
                // Si no, refrescamos todo el grid con la memoria actualizada
                RefrescarGrid(_productosCache);
            }
        }
        private void ConfigurarFormulario()
        {
            this.DoubleBuffered = true;
            this.FormClosing -= frmFacturacion_FormClosing;
            this.FormClosing += frmFacturacion_FormClosing;

            // =======================================================
            // 1. GESTOR DE INVENTARIO (Para cambios de STOCK)
            // =======================================================
            _gestorInventario = new GestorRealtime<Inventario>();

            _gestorInventario.OnCambioBaseDatos += (change) =>
            {
                try
                {
                    var cambioInv = change.Model<Inventario>();
                    // Validar bodega
                    if (cambioInv != null && cambioInv.IdBodegaInventario == SessionData.IdBodegaActual)
                    {
                        this.Invoke((MethodInvoker)(() =>
                        {
                            // Buscar producto en memoria (Cache)
                            var prod = _productosCache.FirstOrDefault(p => p.IdProducto == cambioInv.IdProductoInventario);

                            if (prod != null)
                            {
                                // ACTUALIZAR MEMORIA (STOCK)
                                prod.StockEnBodega = cambioInv.StockProductoBodegaInventario;
                                RefrescarGridVisualmente(); // Repintar
                                System.Diagnostics.Debug.WriteLine($"Realtime: Stock actualizado a {prod.StockEnBodega}");
                            }
                            else
                            {
                                // Si no existe en lista (producto nuevo en inventario), recarga completa
                                RecargarInterfaz();
                            }
                        }));
                    }
                }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine("Error RT Inventario: " + ex.Message); }
            };

            // =======================================================
            // 2. GESTOR DE PRODUCTO (Para cambios de PRECIO/NOMBRE)
            // =======================================================
            _gestorProducto = new GestorRealtime<Producto>(); // <--- Instancia nueva

            _gestorProducto.OnCambioBaseDatos += (change) =>
            {
                try
                {
                    var cambioProd = change.Model<Producto>();
                    if (cambioProd != null)
                    {
                        this.Invoke((MethodInvoker)(() =>
                        {
                            // Buscar producto en memoria
                            var prod = _productosCache.FirstOrDefault(p => p.IdProducto == cambioProd.IdProducto);

                            if (prod != null)
                            {
                                // ACTUALIZAR MEMORIA (DATOS BASE)
                                // Actualizamos lo que suele cambiar el administrador
                                prod.NombreProducto = cambioProd.NombreProducto;
                                prod.PrecioVenta = cambioProd.PrecioVenta;
                                prod.PrecioCompra = cambioProd.PrecioCompra;

                                RefrescarGridVisualmente(); // Repintar
                                System.Diagnostics.Debug.WriteLine($"Realtime: Producto '{prod.NombreProducto}' actualizado.");
                            }
                            else
                            {
                                // Producto nuevo creado globalmente -> Recargar para ver si entra en esta bodega
                                RecargarInterfaz();
                            }
                        }));
                    }
                }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine("Error RT Producto: " + ex.Message); }
            };

            // Manejo de reconexión (Basta con uno o ambos)
            _gestorInventario.OnReconexionExitosa += () => this.Invoke((MethodInvoker)(() => RecargarInterfaz()));
        }
        /* private void ConfigurarFormulario()
         {
             this.DoubleBuffered = true;
             this.FormClosing += frmFacturacion_FormClosing;

             // 1. Instanciar Gestor
             _gestorInventario = new GestorRealtime<Inventario>();

             // 2. Suscribir evento de cambio
             _gestorInventario.OnCambioBaseDatos += (change) =>
             {
                 var dato = change.Model<Inventario>();
                 // Validar que el cambio sea de nuestra bodega actual
                 if (dato == null || dato.IdBodegaInventario == SessionData.IdBodegaActual)
                 {
                     System.Diagnostics.Debug.WriteLine($"Stock actualizado: {change.Event}");
                     RecargarInterfaz();
                 }
             };

             // 3. Reconexión
             _gestorInventario.OnReconexionExitosa += () =>
             {
                 System.Diagnostics.Debug.WriteLine("Reconexión -> Recargando Inventario");
                 RecargarInterfaz();
             };
         }*/
        private void RecargarInterfaz()
        {
            // Validaciones de seguridad de hilos (Thread Safety)
            if (this.IsDisposed || !this.IsHandleCreated) return;

            this.BeginInvoke((MethodInvoker)(async () =>
            {
                if (this.IsDisposed) return;

                await Task.Delay(500);

                // Recargamos los datos de la BD
                await CargarProductosDeBodega();

                // Aplicamos el filtro actual (si el usuario estaba buscando algo, no se lo quitamos)
                string textoBusqueda = txtBuscar.Text.Trim();
                if (!string.IsNullOrEmpty(textoBusqueda))
                {
                    txtBuscar_TextChanged(null, null); // Re-aplica el filtro
                }
                else
                {
                    RefrescarGrid(_productosCache); // Muestra todo
                }
            }));
        }
        private void RefrescarGrid(List<Producto> listaMostrar)
        {
            dgvProductos.DataSource = null; // Si usabas DataSource directo, limpiar
            dgvProductos.Rows.Clear();

            foreach (var p in listaMostrar)
            {
                dgvProductos.Rows.Add(
                    p.IdProducto,
                    p.NombreProducto,
                    p.PrecioCompra, // O PrecioVenta
                    p.StockEnBodega
                );
            }
            dgvProductos.ClearSelection();
        }
        private void SeleccionarCliente(Cliente cliente)
        {
            txtCliente.Text = cliente.Nombre;
            _clienteSeleccionado = cliente; // ¡IMPORTANTE! Guardamos el objeto
            lstClientes.Visible = false;
            txtCliente.SelectionStart = txtCliente.Text.Length; // Cursor al final
            txtCliente.Focus();
        }

        /* private async Task DesecharSuscripcionProductosAsync()
         {
             if (_productoSubscription != null)
             {
                 try
                 {
                     await Task.Run(() => _productoSubscription.Unsubscribe());
                     System.Diagnostics.Debug.WriteLine("Suscripción a Inventario en Facturación desechada.");
                 }
                 catch (Exception ex)
                 {
                     System.Diagnostics.Debug.WriteLine($"Error al desuscribir productos en Facturación: {ex.Message}");
                 }

                 _productoSubscription = null;
             }
         }*/

        /* private async Task IniciarSuscripcionProductosAsync()
         {
             await DesecharSuscripcionProductosAsync();

             try
             {
                 _supabaseClient = await Conexion.GetClientAsync();

                 int idBodega = CapaServiciosSeguridadValidacion.ServicioSesionUsuario.ObtenerIdBodega();

                 _productoSubscription = await _supabaseClient
                     .From<Inventario>()
                    .On(ListenType.All, (IRealtimeChannel sender, PostgresChangesResponse change) =>
                    {
                        var modeloCambiado = change.Model<Inventario>();
                        if (modeloCambiado != null && modeloCambiado.IdBodegaInventario != idBodega)
                        {
                            return;
                        }

                        if (!this.IsHandleCreated || this.IsDisposed)
                            return;

                        this.BeginInvoke((MethodInvoker)(async () =>
                        {
                            if (this.IsDisposed) return;

                            System.Diagnostics.Debug.WriteLine("Cambio de stock detectado. Recargando...");

                            await CargarProductosDeBodega();
                        }));
                    });

                 System.Diagnostics.Debug.WriteLine($"Suscripción a Inventario (Bodega {idBodega}) iniciada.");
             }
             catch (Exception ex)
             {
                 System.Diagnostics.Debug.WriteLine($"Error al suscribir inventario: {ex.Message}");
             }
         }*/

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

            txtSubtotal.Text = subtotal.ToString("N2");
            txtImpuesto.Text = impuesto.ToString("N2");
            txtTotal.Text = total.ToString("N2");
        }

        private async Task CargarProductosDeBodega()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // 1. Obtener el ID de la bodega desde la sesión (Login)
                int idBodega = CapaServiciosSeguridadValidacion.ServicioSesionUsuario.ObtenerIdBodega();

                // 2. Obtener SOLO los productos de esa bodega
                _productosCache = await _inventarioRepo.ObtenerProductosDeBodega(idBodega);

                // 3. Mostrar en el Grid
                dgvProductos.DataSource = null;
                dgvProductos.Rows.Clear();

                foreach (var p in _productosCache)
                {
                    dgvProductos.Rows.Add(
                        p.IdProducto,
                        p.NombreProducto,
                        p.PrecioCompra, // O PrecioVenta
                        p.StockEnBodega // <--- ¡OJO! Usamos el stock específico de esta bodega
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void AgregarAlCarrito(int codigoProducto, int cantidadAgregar)
        {
            int limiteProductos = 3;
            int productosActuales = dgvCarrito.Rows.Count;

            // Si ya llegó al límite y el producto no está en el carrito
            bool productoYaExiste = dgvCarrito.Rows
                .Cast<DataGridViewRow>()
                .Any(r => !r.IsNewRow && (int)r.Cells[0].Value == codigoProducto);

            if (productosActuales >= limiteProductos && !productoYaExiste)
            {
                MessageBox.Show(
                    $"Solo puedes agregar hasta {limiteProductos} productos diferentes al carrito.",
                    "Límite alcanzado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return; //  Detiene el método
            }

            Image Eliminar = Properties.Resources.eliminar__1_;
            Image Restar = Properties.Resources.signo_menos__1_;
            Image Sumar = Properties.Resources.mas__2_;

            // Buscar producto en dgvProductos
            DataGridViewRow producto = null;
            for (int i = 0; i < dgvProductos.Rows.Count; i++)
            {
                if ((int)dgvProductos.Rows[i].Cells[0].Value == codigoProducto)
                {
                    producto = dgvProductos.Rows[i];
                    break;
                }
            }

            if (producto == null)
            {
                MessageBox.Show("Producto no encontrado.");
                return;
            }

            string descripcion = producto.Cells[1].Value.ToString();
            decimal precio = Convert.ToDecimal(producto.Cells[2].Value);
            int stock = Convert.ToInt32(producto.Cells[3].Value);

            // Revisar si ya está en el carrito
            for (int i = 0; i < dgvCarrito.Rows.Count; i++)
            {
                if ((int)dgvCarrito.Rows[i].Cells[0].Value == codigoProducto)
                {
                    int cantidadActual = Convert.ToInt32(dgvCarrito.Rows[i].Cells[3].Value);
                    int nuevaCantidad = cantidadActual + cantidadAgregar;

                    if (nuevaCantidad > stock)
                    {
                        dgvCarrito.Rows[i].Cells[3].Value = stock;
                        MessageBox.Show($"Stock insuficiente. Solo hay {stock} unidades disponibles.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        dgvCarrito.Rows[i].Cells[3].Value = nuevaCantidad;
                    }

                    return;
                }
            }
            // Si no está en el carrito, agregar nueva fila
            int cantidadFinal = cantidadAgregar;
            if (cantidadFinal > stock)
            {
                cantidadFinal = stock;
                MessageBox.Show($"Stock insuficiente. Solo hay {stock} unidades disponibles.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            dgvCarrito.Rows.Add(codigoProducto, descripcion, precio, cantidadFinal, Eliminar, Restar, Sumar);
        }

        private void LimpiarCarrito()
        {
            dgvCarrito.Rows.Clear();      // borra todos los productos del carrito
            ActualizarTotales();          // deja subtotal, total e impuesto en 0
            ActualizarImagenCarrito();    // muestra la imagen de carrito vacío
            txtCodigo.Text = "";
            txtProducto.Text = "";
            txtPrecio.Text = "";
            nudCantidad.Value = 1;
            dgvProductos.ClearSelection();
        }

        // EVENTOS
        private void lstSugerencias_Leave(object sender, EventArgs e)
        {
            lstSugerencias.Visible = false;
            txtBuscar.Text = "";
        }

        private void lstSugerencias_DoubleClick(object sender, EventArgs e)
        {
            if (lstSugerencias.SelectedItem is Producto productoSeleccionado)
            {
                int idBuscado = productoSeleccionado.IdProducto;

                // 2. Recorrer el DataGridView para encontrar la fila
                bool encontrado = false;

                foreach (DataGridViewRow fila in dgvProductos.Rows)
                {
                    // Asegúrate de que la celda 0 es el ID (ajusta el índice si es diferente)
                    if (fila.Cells[0].Value != null &&
                        Convert.ToInt32(fila.Cells[0].Value) == idBuscado)
                    {
                        // ¡ENCONTRADO!

                        // A. Limpiar selecciones anteriores
                        dgvProductos.ClearSelection();

                        // B. Seleccionar la fila
                        fila.Selected = true;

                        // C. Hacer scroll hasta la fila (poniendo la celda activa)
                        dgvProductos.CurrentCell = fila.Cells[0];

                        // D. Llenar los campos de texto automáticamente (Opcional pero recomendado)
                        txtCodigo.Text = productoSeleccionado.IdProducto.ToString();
                        txtProducto.Text = productoSeleccionado.NombreProducto;
                        txtPrecio.Text = productoSeleccionado.PrecioVenta.ToString();
                        nudCantidad.Value = 1; // Resetear cantidad
                        nudCantidad.Focus();   // Mover foco para que solo tenga que dar Enter

                        encontrado = true;
                        break; // Salimos del ciclo
                    }
                }

                if (!encontrado)
                {
                    MessageBox.Show("El producto no se encuentra visible en la lista actual (tal vez tiene stock 0 o está filtrado).", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // 3. Ocultar la lista de sugerencias
                lstSugerencias.Visible = false;
                txtBuscar.Text = "";
            }
            /*if (lstSugerencias.SelectedItem is Producto producto)
            {
                // Llenar los textbox del producto
                txtCodigo.Text = producto.IdProducto.ToString();
                txtProducto.Text = producto.NombreProducto;
                txtPrecio.Text = producto.PrecioVenta.ToString("N2");

                // Buscar y seleccionar la fila correspondiente en dgvProductos
                foreach (DataGridViewRow fila in dgvProductos.Rows)
                {
                    if (fila.Cells[0].Value != null && (int)fila.Cells[0].Value == producto.IdProducto)
                    {
                        fila.Selected = true;
                        dgvProductos.CurrentCell = fila.Cells[0];
                        break;
                    }
                }

                // Ocultar las sugerencias
                lstSugerencias.Visible = false;
            }*/
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.ToLower().Trim();

            // 1. Validaciones iniciales
            if (string.IsNullOrWhiteSpace(texto) || _productosCache == null || _productosCache.Count == 0)
            {
                lstSugerencias.Visible = false;
                return;
            }

            // 2. Filtrar la lista (Busca coincidencias parciales)
            var resultados = _productosCache
                .Where(p => p.NombreProducto != null && p.NombreProducto.ToLower().Contains(texto))
                .Take(10) // Máximo 10 sugerencias
                .ToList();

            // 3. Si no hay resultados, ocultamos
            if (resultados.Count == 0)
            {
                lstSugerencias.Visible = false;
                return;
            }

            // 4. Mostrar resultados (IMPORTANTE: El orden de estas líneas)
            lstSugerencias.DataSource = null; // <--- ¡Limpiar antes de asignar!
            lstSugerencias.DataSource = resultados;
            lstSugerencias.DisplayMember = "NombreProducto";
            lstSugerencias.ValueMember = "IdProducto";

            // 5. Ajuste visual (Altura dinámica)
            int alturaItem = lstSugerencias.ItemHeight;
            // Calcula altura: (cantidad * altura de item) + un pequeño borde. Máximo 150px.
            lstSugerencias.Height = Math.Min((resultados.Count * alturaItem) + 5, 150);

            lstSugerencias.Visible = true;
            /*string texto = txtBuscar.Text.Trim();

            if (string.IsNullOrWhiteSpace(texto) || _productosCache == null || _productosCache.Count == 0)
            {
                lstSugerencias.Visible = false;
                return;
            }

            // Buscar coincidencias por nombre
            var resultados = _productosCache
                .Where(p => p.NombreProducto.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0)
                .Take(10) // máximo 10 sugerencias
                .ToList();

            if (resultados.Count == 0)
            {
                lstSugerencias.Visible = false;
                return;
            }

            // Cargar sugerencias
            lstSugerencias.DataSource = resultados;
            lstSugerencias.DisplayMember = "NombreProducto";
            lstSugerencias.ValueMember = "IdProducto";
            lstSugerencias.Visible = true;*/
        }

        private async void frmFacturacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            //await DesecharSuscripcionProductosAsync();
            await _gestorInventario.DesuscribirAsync();
            await _gestorProducto.DesuscribirAsync();
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null && dgvProductos.CurrentRow.Selected)
            {
                txtProducto.Text = dgvProductos.CurrentRow.Cells[1].Value.ToString(); // Descripción
                txtPrecio.Text = dgvProductos.CurrentRow.Cells[2].Value.ToString();   // Precio
                txtCodigo.Text = dgvProductos.CurrentRow.Cells[0].Value.ToString();    // Código
            }
            else
            {
                txtProducto.Text = "";
                txtPrecio.Text = "";
                txtCodigo.Text = "";
            }
        }

        private void dgvCarrito_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 4)
            {
                dgvCarrito[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.LightBlue;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            this.Close();
        }

        private void dgvCarrito_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 4)
            {
                dgvCarrito[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;
            }
        }

        private void dgvCarrito_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 5) // columna específica
            {
                dgvCarrito[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Gray; // color oscuro al presionar
            }
        }

        private void dgvCarrito_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvCarrito.RowCount && e.ColumnIndex >= 4 && e.ColumnIndex <= 6 && e.ColumnIndex < dgvCarrito.ColumnCount)
            {
                // Restaurar color si lo necesitas
                dgvCarrito[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;

                // Quitar la selección solo de esa celda
                dgvCarrito[e.ColumnIndex, e.RowIndex].Selected = false;
            }
        }

        private void dgvCarrito_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvCarrito.RowCount)
                return;

            int stock = 0;

            // Obtener el stock del producto desde dgvProductos
            int codigoProducto = Convert.ToInt32(dgvCarrito.Rows[e.RowIndex].Cells[0].Value);
            for (int i = 0; i < dgvProductos.Rows.Count; i++)
            {
                if ((int)dgvProductos.Rows[i].Cells[0].Value == codigoProducto)
                {
                    stock = Convert.ToInt32(dgvProductos.Rows[i].Cells[3].Value);
                    break;
                }
            }

            // Columna eliminar
            if (e.ColumnIndex == 4)
            {
                if (dgvCarrito.CurrentRow != null)
                    dgvCarrito.Rows.Remove(dgvCarrito.CurrentRow);
                ActualizarTotales();
            }

            // Columna restar
            if (e.ColumnIndex == 5)
            {
                int cantidad = Convert.ToInt32(dgvCarrito.Rows[e.RowIndex].Cells[3].Value);
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

            // Columna sumar
            if (e.ColumnIndex == 6)
            {
                int cantidad = Convert.ToInt32(dgvCarrito.Rows[e.RowIndex].Cells[3].Value);

                if (cantidad < stock)
                {
                    dgvCarrito.Rows[e.RowIndex].Cells[3].Value = cantidad + 1;
                    ActualizarTotales();
                }
                else
                {
                    MessageBox.Show($"Stock insuficiente. Solo hay {stock} unidades disponibles.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (nudCantidad.Value <= 0)
            {
                MessageBox.Show($"No puede ingresar 0 o negativo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (nudCantidad.Value <= 0 || txtCodigo.Text == "" && txtProducto.Text == "")
                    MessageBox.Show($"Por favor seleccione un Producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    AgregarAlCarrito(Convert.ToInt32(txtCodigo.Text), Convert.ToInt32(nudCantidad.Text));
                nudCantidad.Value = 1;
                txtCodigo.Text = null;
                txtProducto.Text = null;
                dgvProductos.ClearSelection();
                txtPrecio.Text = null;
                ActualizarTotales();
                ActualizarImagenCarrito();
            }

        }

        private void dgvCarrito_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                // Solo recalcular si cambia la columna de cantidad (3) o precio (2)
                if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
                {
                    double precio = Convert.ToDouble(dgvCarrito.Rows[e.RowIndex].Cells[2].Value);
                    double cantidad = Convert.ToDouble(dgvCarrito.Rows[e.RowIndex].Cells[3].Value);
                }
            }
        }

        private void ActualizarImagenCarrito()
        {
            // Si no hay filas visibles (ni productos)
            if (dgvCarrito.Rows.Count == 0)
            {
                pbxCarritoVacio.Visible = true;
                //lblCarritoVacio.Visible = true;
            }
            else
            {
                pbxCarritoVacio.Visible = false;
                //lblCarritoVacio.Visible = false;
            }
        }
        private void lstClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && lstClientes.SelectedItem != null)
            {
                SeleccionarCliente((Cliente)lstClientes.SelectedItem);
            }
        }
        private void txtCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && lstClientes.Visible)
            {
                lstClientes.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (lstClientes.Visible && lstClientes.Items.Count > 0)
                {
                    var cliente = (Cliente)lstClientes.Items[0];
                    SeleccionarCliente(cliente);
                    e.SuppressKeyPress = true;
                }
            }
        }
        private void lstClientes_MouseClick(object sender, MouseEventArgs e)
        {
            if (lstClientes.SelectedItem is Cliente cliente)
            {
                // 1. Llenar el TextBox visualmente (Nombre + Apellido)
                txtCliente.Text = $"{cliente.Nombre} {cliente.Apellido}";

                // 2. Guardar el objeto en la variable para usarlo al Facturar
                _clienteSeleccionado = cliente;

                // 3. Ocultar la lista
                lstClientes.Visible = false;
            }
            /*if (lstClientes.SelectedItem is Cliente cliente)
            {
                SeleccionarCliente(cliente);
            }*/
        }
        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            string texto = txtCliente.Text.ToLower().Trim();

            // 1. Si está vacío, ocultamos la lista y limpiamos la selección
            if (string.IsNullOrEmpty(texto))
            {
                lstClientes.Visible = false;
                _clienteSeleccionado = null;
                return;
            }

            // 2. Filtrar la lista en memoria (Por Nombre o Apellido)
            // Usamos el modelo nuevo de la rama master (Nombre, Apellido)
            var resultados = _todosLosClientes
                .Where(c => (c.Nombre != null && c.Nombre.ToLower().Contains(texto)) ||
                            (c.Apellido != null && c.Apellido.ToLower().Contains(texto)))
                .Take(10) // Limitamos a 10 para que no sea una lista gigante
                .ToList();

            // 3. Mostrar resultados
            if (resultados.Count > 0)
            {
                lstClientes.DataSource = null;
                lstClientes.DataSource = resultados;

                // IMPORTANTE: Configurar qué mostrar
                // Como queremos ver Nombre y Apellido, a veces es mejor sobreescribir el método ToString()
                // en la clase Cliente, pero por ahora mostraremos solo el Nombre.
                lstClientes.DisplayMember = "Nombre";
                lstClientes.ValueMember = "Id";

                // Ajustar altura visualmente
                int alturaItem = lstClientes.ItemHeight;
                lstClientes.Height = Math.Min((resultados.Count * alturaItem) + 10, 150);

                lstClientes.Visible = true;
                lstClientes.BringToFront(); // Asegura que flote encima
            }
            else
            {
                lstClientes.Visible = false;
            }
            /* string texto = txtBuscar.Text.Trim();

             if (string.IsNullOrWhiteSpace(texto) || _todosLosClientes == null)
             {
                 lstSugerencias.Visible = false;
                 _clienteSeleccionado = null;
                 return;
             }

             // 1. FILTRAR (Usando .Nombre y .Apellido)
             var resultados = _todosLosClientes
                 .Where(c => (c.Nombre != null && c.Nombre.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0) ||
                             (c.Apellido != null && c.Apellido.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0))
                 .Take(10)
                 .ToList();

             if (resultados.Count > 0)
             {
                 lstSugerencias.DataSource = null;
                 lstSugerencias.DataSource = resultados;

                 // 2. CAMBIO IMPORTANTE: Usar los nombres de propiedades NUEVOS
                 lstSugerencias.DisplayMember = "Nombre"; // Propiedad de tu clase
                 lstSugerencias.ValueMember = "Id";       // Propiedad de tu clase

                 lstSugerencias.Visible = true;
                 lstSugerencias.Height = Math.Min((resultados.Count * 20) + 10, 150); // Ajuste visual simple
                 lstSugerencias.BringToFront();
             }
             else
             {
                 lstSugerencias.Visible = false;
             }*/


            /*//MessageBox.Show("Clientes cargados: " + _todosLosClientes.Count);
            string texto = txtCliente.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(texto))
            {
                lstClientes.Visible = false;
                _clienteSeleccionado = null; // Limpiamos si borra el texto
                return;
            }

            // Filtramos la lista en memoria
            var resultados = _todosLosClientes
                .Where(c => c.Nombre.ToLower().Contains(texto))
                .ToList();
            if (resultados.Count > 0)
            {
                lstClientes.DataSource = null;
                lstClientes.DataSource = resultados;
                lstClientes.DisplayMember = "NombreCliente";
                lstClientes.ValueMember = "IdCliente";

                // Ajuste visual de altura
                int alturaItem = lstClientes.ItemHeight;
                lstClientes.Height = Math.Min((resultados.Count * alturaItem) + 10, 150);

                lstClientes.Visible = true;
            }
            else
            {
                lstClientes.Visible = false;
            }*/
        }

        private async void Gestion_de_Ventas_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("¡El formulario ha cargado y va a suscribirse!");
            // 1. Carga inicial
            await CargarProductosDeBodega();

            // 2. Carga de clientes (tu código original)
            try
            {
                _todosLosClientes = await _clienteRepo.ObtenerTodosLosClientes();
                lstSugerencias.Visible = false;
            }
            catch { }

            // 3. IMPORTANTE: Iniciar la escucha de Realtime
            System.Diagnostics.Debug.WriteLine("Iniciando suscripción a Realtime...");
            await _gestorInventario.SuscribirAsync();
            await _gestorProducto.SuscribirAsync();
            /* await CargarProductosDeBodega();

             try
             {
                 _todosLosClientes = await _clienteRepo.ObtenerTodosLosClientes();
                 lstSugerencias.Visible = false;
             }
             catch (Exception ex) { /* manejo error */
        }

        // await CargarRutasAsync();

        // 2. ACTIVAR REALTIME (Igual que en frmCategorias)*/
        //await _gestorInventario.SuscribirAsync();




        /* await CargarProductosDeBodega();
         // await CargarProductosAsync();
         try
         {
             // Asegúrate de tener _clienteRepo instanciado arriba
             _todosLosClientes = await _clienteRepo.ObtenerTodosLosClientes();
         }
         catch (Exception ex)
         {
             MessageBox.Show("Error al cargar clientes: " + ex.Message);
         }
         await IniciarSuscripcionProductosAsync();*/



        private async void btnFacturar_Click(object sender, EventArgs e)
        {
            if (dgvCarrito.Rows.Count == 0)
            {
                MessageBox.Show("El carrito está vacío. Agregue productos para facturar.",
                                "Carrito Vacio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. VALIDACIÓN DEL CLIENTE (Usando la variable del buscador)
            if (_clienteSeleccionado == null)
            {
                MessageBox.Show("Debe buscar y seleccionar un Cliente.",
                                "Falta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBuscar.Focus(); // (O el nombre de tu textbox de cliente)
                return;
            }

            // 3. VALIDACIÓN DE SESIÓN DE BODEGA
            if (CapaServiciosSeguridadValidacion.ServicioSesionUsuario.ObtenerIdBodega() == -1)
            {
                MessageBox.Show("Error de Sesión: No se detecta la bodega actual.",
                                "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // (YA NO VALIDAMOS LA RUTA AQUÍ PORQUE DIJISTE QUE ES OPCIONAL)

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // --- OBTENER DATOS DE USUARIO/EMPLEADO ---
                var supabase = await Conexion.GetClientAsync();
                var usuarioAuth = supabase.Auth.CurrentUser;
                if (usuarioAuth == null) throw new Exception("No hay usuario autenticado.");

                var respEmpleado = await supabase
                    .From<Usuario>()
                    .Select("id_empleado")
                    .Filter("user_id", Operator.Equals, usuarioAuth.Id)
                    .Get();

                if (respEmpleado.Models == null || respEmpleado.Models.Count == 0)
                {
                    MessageBox.Show("El usuario actual no tiene un 'id_empleado' vinculado.");
                    return;
                }
                int idEmpleado = respEmpleado.Models.First().IdUsuario;

                // --- PREPARAR DETALLES ---
                int idBodegaVenta = CapaServiciosSeguridadValidacion.ServicioSesionUsuario.ObtenerIdBodega();

                var detallesVenta = dgvCarrito.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => !r.IsNewRow)
                    .Select(r => new
                    {
                        id_producto = Convert.ToInt32(r.Cells[0].Value),
                        cantidad_venta = Convert.ToInt32(r.Cells[3].Value),
                        id_bodega = idBodegaVenta
                    })
                    .ToList();

                // --- ARMAR PARÁMETROS ---
                var parametros = new
                {
                    p_id_cliente = _clienteSeleccionado.Id,
                    p_id_rutas = (int?)null,
                    p_id_empleado = idEmpleado,
                    p_fecha_venta = DateTime.UtcNow,
                    p_detalles = detallesVenta
                };

                // --- ENVIAR A SUPABASE ---
                await supabase.Rpc("registrar_venta", parametros);

                // --- FINALIZAR ---
                this.Cursor = Cursors.Default;
                MessageBox.Show($"¡Venta registrada a {_clienteSeleccionado.Nombre} exitosamente!",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCarrito();

                txtBuscar.Text = "";
                txtCliente.Text = "";
                _clienteSeleccionado = null;

                await CargarProductosDeBodega();
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show($"Error al registrar venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            // 1. Si la lista no se ve, no hacemos nada (dejamos que el evento fluya)
            if (!lstSugerencias.Visible) return;

            // --- FLECHA ABAJO (Bajar en la lista) ---
            if (e.KeyCode == Keys.Down)
            {
                // Calcula el siguiente índice sin pasarse del final
                int newIndex = Math.Min(lstSugerencias.SelectedIndex + 1, lstSugerencias.Items.Count - 1);

                if (newIndex >= 0)
                    lstSugerencias.SelectedIndex = newIndex;

                e.Handled = true; // Evita que el cursor se mueva en el TextBox
            }
            // --- FLECHA ARRIBA (Subir en la lista) ---
            else if (e.KeyCode == Keys.Up)
            {
                // Calcula el índice anterior sin bajar de 0
                int newIndex = Math.Max(lstSugerencias.SelectedIndex - 1, 0);

                if (newIndex >= 0)
                    lstSugerencias.SelectedIndex = newIndex;

                e.Handled = true;
            }
            // --- ENTER (Seleccionar producto para facturar) ---
            else if (e.KeyCode == Keys.Enter)
            {
                if (lstSugerencias.SelectedItem != null)
                {
                    // A. Obtener el objeto seleccionado
                    Producto productoSel = lstSugerencias.SelectedItem as Producto;

                    if (productoSel != null)
                    {
                        // B. Llenar los campos de facturación automáticamente
                        txtCodigo.Text = productoSel.IdProducto.ToString();
                        txtProducto.Text = productoSel.NombreProducto;
                        txtPrecio.Text = productoSel.PrecioVenta.ToString("N2"); // Formato moneda

                        // C. Seleccionarlo visualmente en el Grid (Opcional, por estética)
                        SeleccionarProductoEnGrid(productoSel.IdProducto);

                        // D. Preparar para agregar cantidad
                        nudCantidad.Value = 1;
                        nudCantidad.Focus();     // Mover el foco a cantidad
                        nudCantidad.Select(0, nudCantidad.Text.Length); // Seleccionar el número "1" para sobrescribir fácil
                    }

                    // E. Limpieza final
                    lstSugerencias.Visible = false;
                    txtBuscar.Text = ""; // Limpiamos el buscador para la siguiente búsqueda

                    // F. Detener el "Ding" y el evento
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
        }
        private void SeleccionarProductoEnGrid(int idProducto)
        {
            // Validar que el grid tenga datos
            if (dgvProductos.Rows.Count == 0) return;

            dgvProductos.ClearSelection();

            foreach (DataGridViewRow fila in dgvProductos.Rows)
            {
                // Asumiendo que la celda 0 es el ID
                if (fila.Cells[0].Value != null && Convert.ToInt32(fila.Cells[0].Value) == idProducto)
                {
                    fila.Selected = true;

                    // Hace scroll hasta la fila para asegurar que se vea
                    dgvProductos.FirstDisplayedScrollingRowIndex = fila.Index;
                    break;
                }
            }
        }
    }
}

