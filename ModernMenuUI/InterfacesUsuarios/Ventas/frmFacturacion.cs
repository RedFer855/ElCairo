using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using CapaDeDatos.Modelados.Inventario;
using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Modelados.UsuariosEmpleados;
using CapaDeDatos.Modelados.Ventas;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.Properties;
using Supabase.Realtime;
using Supabase.Realtime.PostgresChanges;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ModernMenuUI.frmInicioBodega;
using static Supabase.Postgrest.Constants;

namespace ModernMenuUI
{
    public partial class frmFacturacion : Form
    {
        // REPOSITORIOS
        private readonly ProductoRepositorio _productoRepo; // Se mantiene aunque no se use, por si acaso
        private InventarioRepositorio _inventarioRepo = new InventarioRepositorio();
        private ClienteRepositorio _clienteRepo = new ClienteRepositorio();

        // CACHÉ DE DATOS
        private List<Producto> _productosCache = new List<Producto>();
        private List<Cliente> _todosLosClientes = new List<Cliente>();

        // ESTADO
        private Cliente _clienteSeleccionado = null;

        // REALTIME (Lógica MER)
        private GestorRealtime<Inventario> _gestorInventario;
        private GestorRealtime<Producto> _gestorProducto;

        public frmFacturacion()
        {
            InitializeComponent();
            ConfigurarFormulario(); // Configura Realtime y Eventos

            // ESTILOS VISUALES (Lógica Master)
            dgvProductos.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#DCE6F1");
            dgvProductos.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#57636e");
            dgvProductos.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            clsAnmaciones.ActivarDoubleBuffering(dgvCarrito);
            clsAnmaciones.ActivarDoubleBuffering(dgvProductos);

            txtBuscar.PlaceholderText = "Buscar producto...";
            txtBuscar.ForeColor = Color.Black;
            dgvProductos.ClearSelection();

            // VINCULACIÓN DE EVENTOS (Crítico para que funcione)
            this.Load += Gestion_de_Ventas_Load;
            // this.FormClosing ya se vincula en ConfigurarFormulario para evitar duplicados
            this.dgvProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellClick);
            this.nudCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudCantidad_KeyPress);
            this.nudCantidad.Leave += new System.EventHandler(this.nudCantidad_Leave);
        }

        // =======================================================
        // 1. CONFIGURACIÓN Y REALTIME (Lógica MER Optimizada)
        // =======================================================
        private void ConfigurarFormulario()
        {
            this.DoubleBuffered = true;
            this.FormClosing -= frmFacturacion_FormClosing;
            this.FormClosing += frmFacturacion_FormClosing;

            // GESTOR DE INVENTARIO (Cambios de Stock)
            _gestorInventario = new GestorRealtime<Inventario>();
            _gestorInventario.OnCambioBaseDatos += (change) =>
            {
                try
                {
                    var cambioInv = change.Model<Inventario>();
                    if (cambioInv != null && cambioInv.IdBodegaInventario == SessionData.IdBodegaActual)
                    {
                        this.Invoke((MethodInvoker)(() =>
                        {
                            var prod = _productosCache.FirstOrDefault(p => p.IdProducto == cambioInv.IdProductoInventario);
                            if (prod != null)
                            {
                                prod.StockEnBodega = cambioInv.StockProductoBodegaInventario;
                                RefrescarGridVisualmente();
                                System.Diagnostics.Debug.WriteLine($"Realtime: Stock actualizado a {prod.StockEnBodega}");
                            }
                            else
                            {
                                RecargarInterfaz();
                            }
                        }));
                    }
                }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine("Error RT Inventario: " + ex.Message); }
            };

            // GESTOR DE PRODUCTO (Cambios de Precio/Nombre)
            _gestorProducto = new GestorRealtime<Producto>();
            _gestorProducto.OnCambioBaseDatos += (change) =>
            {
                try
                {
                    var cambioProd = change.Model<Producto>();
                    if (cambioProd != null)
                    {
                        this.Invoke((MethodInvoker)(() =>
                        {
                            var prod = _productosCache.FirstOrDefault(p => p.IdProducto == cambioProd.IdProducto);
                            if (prod != null)
                            {
                                prod.NombreProducto = cambioProd.NombreProducto;
                                prod.PrecioVenta = cambioProd.PrecioVenta;
                                prod.PrecioCompra = cambioProd.PrecioCompra;
                                RefrescarGridVisualmente();
                                System.Diagnostics.Debug.WriteLine($"Realtime: Producto '{prod.NombreProducto}' actualizado.");
                            }
                            else
                            {
                                RecargarInterfaz();
                            }
                        }));
                    }
                }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine("Error RT Producto: " + ex.Message); }
            };

            _gestorInventario.OnReconexionExitosa += () => this.Invoke((MethodInvoker)(() => RecargarInterfaz()));
        }

        private void RefrescarGridVisualmente()
        {
            if (!string.IsNullOrEmpty(txtBuscar.Text.Trim()))
                txtBuscar_TextChanged(null, null);
            else
                RefrescarGrid(_productosCache);
        }

        private void RecargarInterfaz()
        {
            if (this.IsDisposed || !this.IsHandleCreated) return;
            this.BeginInvoke((MethodInvoker)(async () =>
            {
                if (this.IsDisposed) return;
                await Task.Delay(500);
                await CargarProductosDeBodega();
                RefrescarGridVisualmente();
            }));
        }

        // =======================================================
        // 2. CARGA DE DATOS (Lógica Master + MER)
        // =======================================================
        private async void Gestion_de_Ventas_Load(object sender, EventArgs e)
        {
            await CargarProductosDeBodega();
            try
            {
                _todosLosClientes = await _clienteRepo.ObtenerTodosLosClientes();
                lstSugerencias.Visible = false;
                lstClientes.Visible = false;
            }
            catch { }

            // Iniciar Realtime
            System.Diagnostics.Debug.WriteLine("Iniciando suscripción a Realtime...");
            await _gestorInventario.SuscribirAsync();
            await _gestorProducto.SuscribirAsync();
        }

        private async Task CargarProductosDeBodega()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                int idBodega = CapaServiciosSeguridadValidacion.ServicioSesionUsuario.ObtenerIdBodega();
                _productosCache = await _inventarioRepo.ObtenerProductosDeBodega(idBodega);
                RefrescarGrid(_productosCache);
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

        private void RefrescarGrid(List<Producto> listaMostrar)
        {
            dgvProductos.DataSource = null;
            dgvProductos.Rows.Clear();
            foreach (var p in listaMostrar)
            {
                dgvProductos.Rows.Add(
                    p.IdProducto,
                    p.NombreProducto,
                    p.PrecioCompra, // O PrecioVenta, verifica cuál usas en Master
                    p.StockEnBodega
                );
            }
            dgvProductos.ClearSelection();
        }

        // =======================================================
        // 3. CARRITO Y VALIDACIONES (Lógica MER: Stock Seguro)
        // =======================================================
        private void AgregarAlCarrito(int codigoProducto, int cantidadAgregar)
        {
            int limiteProductos = 3;
            int productosActuales = dgvCarrito.Rows.Count;

            bool productoYaExiste = dgvCarrito.Rows
                .Cast<DataGridViewRow>()
                .Any(r => !r.IsNewRow && (int)r.Cells[0].Value == codigoProducto);

            if (productosActuales >= limiteProductos && !productoYaExiste)
            {
                MessageBox.Show($"Solo puedes agregar hasta {limiteProductos} productos diferentes al carrito.", "Límite alcanzado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Image Eliminar = Properties.Resources.eliminar__1_;
            Image Restar = Properties.Resources.signo_menos__1_;
            Image Sumar = Properties.Resources.mas__2_;

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

            // --- VALIDACIÓN MER: STOCK 0 ---
            if (stock <= 0)
            {
                MessageBox.Show($"No hay stock disponible para este producto.", "Stock Agotado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Actualizar existente
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

            // Agregar nuevo
            int cantidadFinal = cantidadAgregar;
            if (cantidadFinal > stock)
            {
                cantidadFinal = stock;
                MessageBox.Show($"Stock insuficiente. Solo se agregaron {stock} unidades.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (cantidadFinal > 0)
            {
                dgvCarrito.Rows.Add(codigoProducto, descripcion, precio, cantidadFinal, Eliminar, Restar, Sumar);
            }
        }

        // =======================================================
        // 4. BÚSQUEDA Y NAVEGACIÓN (Lógica MER: Teclado)
        // =======================================================
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.ToLower().Trim();

            if (string.IsNullOrWhiteSpace(texto) || _productosCache == null || _productosCache.Count == 0)
            {
                lstSugerencias.Visible = false;
                // Si borra texto, restaura grid completo
                if (string.IsNullOrWhiteSpace(texto)) RefrescarGrid(_productosCache);
                return;
            }

            var resultados = _productosCache
                .Where(p => p.NombreProducto != null && p.NombreProducto.ToLower().Contains(texto))
                .ToList();

            // Filtra visualmente el Grid también (Mejora UX)
            RefrescarGrid(resultados);

            if (resultados.Count > 0)
            {
                var topResultados = resultados.Take(10).ToList();
                lstSugerencias.DataSource = null;
                lstSugerencias.DataSource = topResultados;
                lstSugerencias.DisplayMember = "NombreProducto";
                lstSugerencias.ValueMember = "IdProducto";

                int alturaItem = lstSugerencias.ItemHeight;
                lstSugerencias.Height = Math.Min((topResultados.Count * alturaItem) + 5, 150);
                lstSugerencias.Visible = true;
                lstSugerencias.BringToFront(); // Asegurar que se vea encima del grid
            }
            else
            {
                lstSugerencias.Visible = false;
            }
        }
        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            // A. Navegación con Flechas (Solo si la lista es visible)
            if (lstSugerencias.Visible)
            {
                if (e.KeyCode == Keys.Down)
                {
                    int newIndex = Math.Min(lstSugerencias.SelectedIndex + 1, lstSugerencias.Items.Count - 1);
                    if (newIndex >= 0) lstSugerencias.SelectedIndex = newIndex;
                    e.Handled = true;
                    return;
                }
                else if (e.KeyCode == Keys.Up)
                {
                    int newIndex = Math.Max(lstSugerencias.SelectedIndex - 1, 0);
                    if (newIndex >= 0) lstSugerencias.SelectedIndex = newIndex;
                    e.Handled = true;
                    return;
                }
            }

            // B. Lógica del ENTER (Selección)
            if (e.KeyCode == Keys.Enter)
            {
                Producto productoASeleccionar = null;

                // Opción 1: El usuario eligió explícitamente de la lista de sugerencias
                if (lstSugerencias.Visible && lstSugerencias.SelectedItem != null)
                {
                    productoASeleccionar = lstSugerencias.SelectedItem as Producto;
                }
                // Opción 2: El usuario dio Enter directo (tomar el primero del Grid filtrado)
                else if (dgvProductos.Rows.Count > 0)
                {
                    // Obtenemos el ID del primer producto visible en el Grid
                    if (dgvProductos.Rows[0].Cells[0].Value != null)
                    {
                        int idPrimerProducto = Convert.ToInt32(dgvProductos.Rows[0].Cells[0].Value);

                        // Buscamos el objeto completo en la memoria caché
                        productoASeleccionar = _productosCache.FirstOrDefault(p => p.IdProducto == idPrimerProducto);
                    }
                }

                // Si encontramos un producto válido, ejecutamos la selección
                if (productoASeleccionar != null)
                {
                    SeleccionarProducto(productoASeleccionar);

                    // Evitamos el sonido "Ding"
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }

            /* // Lógica MER para navegación
             if (!lstSugerencias.Visible) return;

             if (e.KeyCode == Keys.Down)
             {
                 int newIndex = Math.Min(lstSugerencias.SelectedIndex + 1, lstSugerencias.Items.Count - 1);
                 if (newIndex >= 0) lstSugerencias.SelectedIndex = newIndex;
                 e.Handled = true;
             }
             else if (e.KeyCode == Keys.Up)
             {
                 int newIndex = Math.Max(lstSugerencias.SelectedIndex - 1, 0);
                 if (newIndex >= 0) lstSugerencias.SelectedIndex = newIndex;
                 e.Handled = true;
             }
             else if (e.KeyCode == Keys.Enter)
             {
                 if (lstSugerencias.SelectedItem is Producto productoSel)
                 {
                     SeleccionarProducto(productoSel);
                     e.Handled = true;
                     e.SuppressKeyPress = true;
                 }
             }*/
        }
        private void lstSugerencias_DoubleClick(object sender, EventArgs e)
        {
            if (lstSugerencias.SelectedItem is Producto productoSel)
            {
                SeleccionarProducto(productoSel);
            }
        }
        private void SeleccionarProducto(Producto productoSel)
        {
            // A. Llenar los campos de texto
            txtCodigo.Text = productoSel.IdProducto.ToString();
            txtProducto.Text = productoSel.NombreProducto;
            txtPrecio.Text = productoSel.PrecioVenta.ToString("N2");

            // B. Si el grid estaba filtrado (tenía menos filas que el total), 
            // lo restauramos para poder encontrar el producto seleccionado.
            if (dgvProductos.Rows.Count != _productosCache.Count)
            {
                RefrescarGrid(_productosCache);
            }

            // C. AQUÍ ESTÁ LA SOLUCIÓN: Llamamos al método que tiene 0 referencias
            // Lo envolvemos en BeginInvoke para darle tiempo al Grid de "respirar" y pintarse
            this.BeginInvoke((MethodInvoker)(() =>
            {
                SeleccionarProductoEnGrid(productoSel.IdProducto);
            }));

            // D. Preparar el campo de cantidad (Foco para el usuario)
            nudCantidad.Value = 1;
            nudCantidad.Focus();
            nudCantidad.Select(0, nudCantidad.Text.Length);

            // E. Limpiar buscador y lista
            lstSugerencias.Visible = false;
            txtBuscar.Text = "";
            /*// 1. Llenar campos
            txtCodigo.Text = productoSel.IdProducto.ToString();
            txtProducto.Text = productoSel.NombreProducto;
            txtPrecio.Text = productoSel.PrecioVenta.ToString("N2");

            // 2. IMPORTANTE: Restaurar el Grid COMPLETO primero
            // Usamos la caché completa para asegurar que el producto exista en la lista visible
            if (dgvProductos.Rows.Count != _productosCache.Count)
            {
                RefrescarGrid(_productosCache);
            }

            // 3. Ahora que el grid está lleno, buscamos y seleccionamos la fila
            // Forzamos el proceso de selección visual
            bool encontrado = false;
            dgvProductos.ClearSelection(); // Limpiar cualquier selección previa

            foreach (DataGridViewRow fila in dgvProductos.Rows)
            {
                if (fila.Cells[0].Value != null &&
                    Convert.ToInt32(fila.Cells[0].Value) == productoSel.IdProducto)
                {
                    fila.Selected = true; // Marcar azul
                    dgvProductos.CurrentCell = fila.Cells[0]; // Mover el foco interno del grid a esa celda
                    dgvProductos.FirstDisplayedScrollingRowIndex = fila.Index; // Scroll hasta que se vea
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                // Si por alguna razón rara no está, mensaje de debug (opcional)
                System.Diagnostics.Debug.WriteLine($"Producto {productoSel.IdProducto} no encontrado en grid visual.");
            }

            // 4. Preparar cantidad (Foco final para el usuario)
            nudCantidad.Value = 1;
            nudCantidad.Focus();
            nudCantidad.Select(0, nudCantidad.Text.Length);

            // 5. Limpieza visual
            lstSugerencias.Visible = false;
            txtBuscar.Text = "";*/

        }
        private void SeleccionarProductoEnGrid(int idProducto)
        {
            // Protección: Si el grid está vacío, no hacemos nada
            if (dgvProductos.Rows.Count == 0) return;

            dgvProductos.ClearSelection(); // Limpiar selecciones viejas

            foreach (DataGridViewRow fila in dgvProductos.Rows)
            {
                // Verificamos que la celda del ID (índice 0) tenga valor
                if (fila.Cells[0].Value != null &&
                    Convert.ToInt32(fila.Cells[0].Value) == idProducto)
                {
                    // 1. Marcar la fila completa como seleccionada (Azul)
                    fila.Selected = true;

                    // 2. Mover el "foco" interno del grid a la primera celda de esa fila
                    dgvProductos.CurrentCell = fila.Cells[0];

                    // 3. Hacer scroll automático si la fila está muy abajo
                    dgvProductos.FirstDisplayedScrollingRowIndex = fila.Index;

                    break; // Ya lo encontramos, dejamos de buscar
                }
            }
            /*if (dgvProductos.Rows.Count == 0) return;
            dgvProductos.ClearSelection();
            foreach (DataGridViewRow fila in dgvProductos.Rows)
            {
                if (fila.Cells[0].Value != null && Convert.ToInt32(fila.Cells[0].Value) == idProducto)
                {
                    fila.Selected = true;
                    dgvProductos.FirstDisplayedScrollingRowIndex = fila.Index;
                    break;
                }
            }*/
        }
        // =======================================================
        // 5. EVENTOS RESTANTES (Clientes, Botones, Limpieza)
        // =======================================================

        // Clientes (Lógica Master con ajuste de nombres de propiedades)
        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            string texto = txtCliente.Text.ToLower().Trim();
            if (string.IsNullOrEmpty(texto))
            {
                lstClientes.Visible = false;
                _clienteSeleccionado = null;
                return;
            }

            var resultados = _todosLosClientes
                .Where(c => c.NombreCliente != null && c.NombreCliente.ToLower().Contains(texto))
                .Take(10).ToList();

            if (resultados.Count > 0)
            {
                lstClientes.DataSource = null;
                lstClientes.DataSource = resultados;
                lstClientes.DisplayMember = "NombreCliente";
                lstClientes.ValueMember = "IdCliente";

                int alturaItem = lstClientes.ItemHeight;
                lstClientes.Height = Math.Min((resultados.Count * alturaItem) + 10, 150);
                lstClientes.Visible = true;
                lstClientes.BringToFront();
            }
            else
            {
                lstClientes.Visible = false;
            }
        }
        private void lstClientes_MouseClick(object sender, MouseEventArgs e)
        {
            if (lstClientes.SelectedItem is Cliente cliente) SeleccionarCliente(cliente);
        }
        private void lstClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && lstClientes.SelectedItem is Cliente cliente)
            {
                SeleccionarCliente(cliente);
            }
        }
        private void txtCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && lstClientes.Visible) lstClientes.Focus();
            else if (e.KeyCode == Keys.Enter && lstClientes.Visible && lstClientes.Items.Count > 0)
            {
                SeleccionarCliente((Cliente)lstClientes.Items[0]);
                e.SuppressKeyPress = true;
            }
        }
        private void SeleccionarCliente(Cliente cliente)
        {
            txtCliente.Text = cliente.NombreCliente;
            _clienteSeleccionado = cliente;
            lstClientes.Visible = false;
            txtCliente.SelectionStart = txtCliente.Text.Length;
            txtCliente.Focus();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nudCantidad.Text))
            {
                nudCantidad.Value = 0; 
            }
            if (nudCantidad.Value <= 0)
            {
                MessageBox.Show($"No puede ingresar 0 o negativo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (string.IsNullOrEmpty(txtCodigo.Text))
                    MessageBox.Show($"Por favor seleccione un Producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    AgregarAlCarrito(Convert.ToInt32(txtCodigo.Text), Convert.ToInt32(nudCantidad.Text));

                // Limpieza post-agregar
                nudCantidad.Value = 1;
                txtCodigo.Text = null;
                txtProducto.Text = null;
                dgvProductos.ClearSelection();
                txtPrecio.Text = null;
                ActualizarTotales();
                ActualizarImagenCarrito();
            }
        }

        // Resto de eventos de Master (CellClick, MouseEnter, Facturar...) se mantienen igual
        // Solo asegúrate de que btnFacturar use _clienteSeleccionado.IdCliente

        private void ActualizarImagenCarrito()
        {
            pbxCarritoVacio.Visible = (dgvCarrito.Rows.Count == 0);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            this.Close();
        }

        private async void frmFacturacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            await _gestorInventario.DesuscribirAsync();
            await _gestorProducto.DesuscribirAsync();
        }

        private void lstSugerencias_Leave(object sender, EventArgs e)
        {
            lstSugerencias.Visible = false;
            // No borramos texto aquí para no molestar si el usuario hace clic fuera por error
        }

        // EVENTOS DGV CARRITO (Visuales)
        private void dgvCarrito_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 4) dgvCarrito[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.LightBlue;
        }
        private void dgvCarrito_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 4) dgvCarrito[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;
        }
        private void dgvCarrito_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 5) dgvCarrito[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Gray;
        }
        private void dgvCarrito_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 4 && e.ColumnIndex <= 6)
            {
                dgvCarrito[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;
                dgvCarrito[e.ColumnIndex, e.RowIndex].Selected = false;
            }
        }

        private void dgvCarrito_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvCarrito.RowCount) return;

            int stock = 0;
            int codigoProducto = Convert.ToInt32(dgvCarrito.Rows[e.RowIndex].Cells[0].Value);

            // Buscar stock en memoria
            var prod = _productosCache.FirstOrDefault(p => p.IdProducto == codigoProducto);
            if (prod != null) stock = prod.StockEnBodega;

            if (e.ColumnIndex == 4) // Eliminar
            {
                dgvCarrito.Rows.RemoveAt(e.RowIndex);
                ActualizarTotales();
                ActualizarImagenCarrito();
            }
            else if (e.ColumnIndex == 5) // Restar
            {
                int cantidad = Convert.ToInt32(dgvCarrito.Rows[e.RowIndex].Cells[3].Value);
                if (cantidad > 1)
                {
                    dgvCarrito.Rows[e.RowIndex].Cells[3].Value = cantidad - 1;
                    ActualizarTotales();
                }
                else MessageBox.Show("La cantidad no puede ser menor a 1", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (e.ColumnIndex == 6) // Sumar
            {
                int cantidad = Convert.ToInt32(dgvCarrito.Rows[e.RowIndex].Cells[3].Value);
                if (cantidad < stock)
                {
                    dgvCarrito.Rows[e.RowIndex].Cells[3].Value = cantidad + 1;
                    ActualizarTotales();
                }
                else MessageBox.Show($"Stock insuficiente. Solo hay {stock} unidades.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnFacturar_Click(object sender, EventArgs e)
        {
            if (dgvCarrito.Rows.Count == 0)
            {
                MessageBox.Show("El carrito está vacío.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_clienteSeleccionado == null)
            {
                MessageBox.Show("Seleccione un cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCliente.Focus();
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                var supabase = await Conexion.GetClientAsync();
                var usuarioAuth = supabase.Auth.CurrentUser;
                if (usuarioAuth == null) throw new Exception("No hay usuario autenticado.");

                var respEmpleado = await supabase.From<Usuario>()
                    .Select("id_empleado")
                    .Filter("user_id", Operator.Equals, usuarioAuth.Id)
                    .Get();

                if (respEmpleado.Models.Count == 0) throw new Exception("Usuario sin empleado vinculado.");

                int idEmpleado = respEmpleado.Models.First().IdUsuario;
                int idBodega = CapaServiciosSeguridadValidacion.ServicioSesionUsuario.ObtenerIdBodega();

                var detalles = dgvCarrito.Rows.Cast<DataGridViewRow>()
                    .Where(r => !r.IsNewRow)
                    .Select(r => new
                    {
                        id_producto = Convert.ToInt32(r.Cells[0].Value),
                        cantidad_venta = Convert.ToInt32(r.Cells[3].Value),
                        id_bodega = idBodega
                    }).ToList();

                var parametros = new
                {
                    p_id_cliente = _clienteSeleccionado.IdCliente,
                    p_id_rutas = (int?)null,
                    p_id_empleado = idEmpleado,
                    p_fecha_venta = DateTime.UtcNow,
                    p_detalles = detalles
                };

                await supabase.Rpc("registrar_venta", parametros);

                this.Cursor = Cursors.Default;
                MessageBox.Show("Venta registrada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCarrito();
                txtBuscar.Text = "";
                txtCliente.Text = "";
                _clienteSeleccionado = null;

                // No necesitamos recargar explícitamente porque el Realtime actualizará el stock solo, 
                // pero por seguridad de consistencia visual lo hacemos.
                await CargarProductosDeBodega();
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Error al facturar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ActualizarTotales()
        {
            decimal subtotal = 0;

            foreach (DataGridViewRow fila in dgvCarrito.Rows)
            {
                // Aseguramos que las celdas no sean nulas
                if (fila.Cells[2].Value != null && fila.Cells[3].Value != null)
                {
                    decimal precio = Convert.ToDecimal(fila.Cells[2].Value);
                    int cantidad = Convert.ToInt32(fila.Cells[3].Value);

                    subtotal += (precio * cantidad);
                }
            }

            // Cálculo de impuesto (ajusta el 0.15m según tu país si es necesario)
            decimal impuesto = subtotal * 0.15m;
            decimal total = subtotal + impuesto;

            txtSubtotal.Text = subtotal.ToString("N2");
            txtImpuesto.Text = impuesto.ToString("N2");
            txtTotal.Text = total.ToString("N2");
        }
        private void LimpiarCarrito()
        {
            dgvCarrito.Rows.Clear();
            ActualizarTotales();
            ActualizarImagenCarrito();

            txtCodigo.Text = "";
            txtProducto.Text = "";
            txtPrecio.Text = "";
            nudCantidad.Value = 1;

            dgvProductos.ClearSelection();
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null && dgvProductos.CurrentRow.Selected)
            {
                // Asumiendo orden: 0=ID, 1=Nombre, 2=Precio
                // Verifica que estos índices coincidan con tu diseño visual
                if (dgvProductos.CurrentRow.Cells[0].Value != null)
                    txtCodigo.Text = dgvProductos.CurrentRow.Cells[0].Value.ToString();

                if (dgvProductos.CurrentRow.Cells[1].Value != null)
                    txtProducto.Text = dgvProductos.CurrentRow.Cells[1].Value.ToString();

                if (dgvProductos.CurrentRow.Cells[2].Value != null)
                    txtPrecio.Text = dgvProductos.CurrentRow.Cells[2].Value.ToString();
            }
            else
            {
                txtProducto.Text = "";
                txtPrecio.Text = "";
                txtCodigo.Text = "";
            }
        }

        private void dgvCarrito_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Si se edita una celda directamente en el grid, recalculamos totales
            if (e.RowIndex >= 0)
            {
                // Si cambia Precio (2) o Cantidad (3)
                if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
                {
                    try
                    {
                        ActualizarTotales();
                    }
                    catch { /* Ignorar errores de formato mientras escriben */ }
                }
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Validar que no sea clic en la cabecera (-1)
            if (e.RowIndex < 0) return;

            // 2. Obtener la fila donde se hizo clic
            DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];

            // 3. Llenar los datos (Misma lógica que tenías en SelectionChanged)
            if (fila.Cells[0].Value != null)
                txtCodigo.Text = fila.Cells[0].Value.ToString();

            if (fila.Cells[1].Value != null)
                txtProducto.Text = fila.Cells[1].Value.ToString();

            if (fila.Cells[2].Value != null)
                txtPrecio.Text = fila.Cells[2].Value.ToString();

            // 4. Preparar la cantidad y el foco
            nudCantidad.Value = 1;
            nudCantidad.Focus();
            nudCantidad.Select(0, nudCantidad.Text.Length);
        }

        private void nudCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 1. Si es una tecla de control (Backspace, Enter, etc.), dejarla pasar
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // 2. Si es un dígito (0-9), dejarlo pasar
            if (char.IsDigit(e.KeyChar))
            {
                return;
            }

            // 3. Si es cualquier otra cosa (puntos, comas, letras), BLOQUEARLO
            // e.Handled = true le dice al sistema "ignora esta tecla"
            e.Handled = true;
        }

        private void nudCantidad_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nudCantidad.Text) || nudCantidad.Value == 0)
            {
                nudCantidad.Value = 1;
            }
        }
    }
}

