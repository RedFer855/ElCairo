using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using CapaDeDatos.Reportes;
using CapaDeDatos.Repositorios;
using ModernMenuUI.InterfacesUsuarios.Compras;
using Supabase.Realtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Supabase.Postgrest.Constants;
using static Supabase.Realtime.PostgresChanges.PostgresChangesOptions;

namespace ModernMenuUI
{
    public partial class frmGestionCompra : Form
    {
        private readonly ProductoRepositorio _productoRepo;
        private Supabase.Client? _supabaseClient;
        private RealtimeChannel? _productoSubscription;
        private List<Producto> _productosCache = new List<Producto>();
        private List<Proveedor> _todosLosProveedores = new List<Proveedor>();
        private Proveedor _proveedorSeleccionado = null;
        private readonly ProveedorRepositorio proveedorRepositorio;
        public frmGestionCompra()
        {
            InitializeComponent();
            _productoRepo = new ProductoRepositorio();
            Color grisTexto = ColorTranslator.FromHtml("#57636e");

            //dgvProductos.AutoGenerateColumns = false;  // usamos columnas manuales
            //dgvCarrito.AutoGenerateColumns = false;

            // Si quieres estilo en el RowHeader
            dgvProductos.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#DCE6F1");
            dgvProductos.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#57636e");
            dgvProductos.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvProductos.DefaultCellStyle.ForeColor = grisTexto;
            dgvProductos.DefaultCellStyle.BackColor = Color.White;
            dgvProductos.RowsDefaultCellStyle.ForeColor = grisTexto;
            dgvProductos.AlternatingRowsDefaultCellStyle.ForeColor = grisTexto;
            dgvProductos.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgvCarrito.DefaultCellStyle.ForeColor = grisTexto;
            dgvCarrito.RowsDefaultCellStyle.ForeColor = grisTexto;
            dgvCarrito.AlternatingRowsDefaultCellStyle.ForeColor = grisTexto;

            dgvProductos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 220, 240);
            dgvProductos.DefaultCellStyle.SelectionForeColor = Color.Black;

            clsAnmaciones.ActivarDoubleBuffering(dgvProductos);
            clsAnmaciones.ActivarDoubleBuffering(dgvCarrito);

            txtBuscar.PlaceholderText = "Buscar producto...";
            txtBuscar.ForeColor = Color.Black;

            dgvProductos.ClearSelection();

            this.FormClosing += frmGestionCompra_FormClosing;
            proveedorRepositorio = new ProveedorRepositorio();
            // dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //dgvProductos.Rows.Clear(); // Limpia las filas actuales

            //dgvProductos.DefaultCellStyle.ForeColor = Color.DimGray;


        }
       
        private async Task<string> ObtenerNombreUsuarioActual()
        {
            try
            {
                var supabase = await Conexion.GetClientAsync();
                var authUser = supabase.Auth.CurrentUser;

                if (authUser == null) return "Usuario Invitado";

                // Buscamos directamente en la tabla 'usuario' usando el ID de Auth
                // y traemos el campo 'alias_usuario'
                var respUsuario = await supabase
                    .From<Usuario>()
                    .Select("alias_usuario") // Solo necesitamos esta columna
                    .Filter("user_id", Operator.Equals, authUser.Id)
                    .Single();

                if (respUsuario != null && !string.IsNullOrEmpty(respUsuario.AliasUsuario))
                {
                    // ¡ÉXITO! Devolvemos el alias (ej. "juanperez2025")
                    return respUsuario.AliasUsuario;
                }

                // Si no tiene alias, devolvemos el email como respaldo
                return authUser.Email;
            }
            catch (Exception ex)
            {
                // Si falla la base de datos, al menos mostramos el email de la sesión actual
                var client = CapaDeDatos.Datos.Conexion.GetClientAsync().Result;
                var email = client?.Auth.CurrentUser?.Email;
                return email ?? $"Error: {ex.Message}";
            }
        }

        private async Task CargarProductosAsync()
        {
            try
            {
                // Traemos TODOS los productos (o solo activos si tu repo ya filtra)
                List<Producto> listaDeProductos = await _productoRepo.ObtenerTodosLosProductos();

                _productosCache = listaDeProductos ?? new List<Producto>();

                dgvProductos.Rows.Clear();

                foreach (var p in _productosCache)
                {
                    dgvProductos.Rows.Add(
                        p.IdProducto,          // Código
                        p.NombreProducto,      // Producto
                        p.PrecioCompra,        // 👈 precio de compra
                        p.CantidadProducto     // Stock (cantidad_producto)
                    );
                }

                dgvProductos.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}",
                    "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task DesecharSuscripcionProductosAsync()
        {
            if (_productoSubscription != null)
            {
                try
                {
                    await Task.Run(() => _productoSubscription.Unsubscribe());
                }
                catch { }
                _productoSubscription = null;
            }
        }

        private async Task IniciarSuscripcionProductosAsync()
        {
            await DesecharSuscripcionProductosAsync();

            try
            {
                _supabaseClient = await Conexion.ConnectWithTimeoutAsync(10);

                _productoSubscription = await _supabaseClient
                    .From<Producto>()
                    .On(ListenType.All, (sender, change) =>
                    {
                        if (!this.IsHandleCreated || this.IsDisposed)
                            return;

                        this.BeginInvoke((MethodInvoker)(async () =>
                        {
                            if (this.IsDisposed) return;
                            await CargarProductosAsync();   // recargar grid al vuelo
                        }));
                    });

                System.Diagnostics.Debug.WriteLine("Suscripción a Productos en Compras creada.");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error suscribiendo productos en Compras: {ex.Message}");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                string.IsNullOrWhiteSpace(txtProducto.Text))
            {
                MessageBox.Show("Por favor seleccione un producto.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nudCantidad.Value <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int codigo = Convert.ToInt32(txtCodigo.Text);
            int cantidad = (int)nudCantidad.Value;

            AgregarAlCarrito(codigo, cantidad);

            // Limpiar selección / campos
            nudCantidad.Value = 1;
            txtCodigo.Text = "";
            txtProducto.Text = "";
            txtPrecio.Text = "";
            dgvProductos.ClearSelection();
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
        private async void frmGestionCompra_Load(object sender, EventArgs e)
        {
            await CargarProductosAsync();
            await IniciarSuscripcionProductosAsync();
            try
            {
                // 1. Cargar proveedores desde Supabase (usando tu repositorio)
                // Asegúrate de que tu ProveedorRepositorio tenga un método para traer todos
                _todosLosProveedores = await proveedorRepositorio.ObtenerTodosLosProveedores();

                // Ocultar la lista al inicio
                lstSugerencias.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar proveedores: " + ex.Message);
            }
        }

        private async void frmGestionCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            await DesecharSuscripcionProductosAsync();
        }
        private void ActualizarTotales()
        {
            decimal subtotal = 0;

            foreach (DataGridViewRow row in dgvCarrito.Rows)
            {
                if (row.IsNewRow) continue;

                decimal precio = Convert.ToDecimal(row.Cells[2].Value);   // Precio
                int cantidad = Convert.ToInt32(row.Cells[3].Value);       // Cantidad

                subtotal += precio * cantidad;
            }

            decimal impuesto = subtotal * 0.15m;
            decimal total = subtotal + impuesto;

            txtSubTotal.Text = subtotal.ToString("L0.00");
            txtImpuesto.Text = impuesto.ToString("L0.00");
            txtTotal.Text = total.ToString("L0.00");
        }
        private void AgregarAlCarrito(int codigoProducto, int cantidadAgregar)
        {
            // 🔹 Límite de productos distintos en el carrito
            int limiteProductos = 100;
            int productosActuales = dgvCarrito.Rows.Count;

            bool productoYaExiste = dgvCarrito.Rows
                .Cast<DataGridViewRow>()
                .Any(r => !r.IsNewRow && Convert.ToInt32(r.Cells[0].Value) == codigoProducto);

            if (productosActuales >= limiteProductos && !productoYaExiste)
            {
                MessageBox.Show(
                    $"Solo puedes agregar hasta {limiteProductos} productos diferentes al carrito.",
                    "Límite alcanzado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            Image Eliminar = Properties.Resources.eliminar__1_;
            Image Restar = Properties.Resources.signo_menos__1_;
            Image Sumar = Properties.Resources.mas__2_;

            // 🔹 Buscar producto en dgvProductos
            DataGridViewRow producto = dgvProductos.Rows
                .Cast<DataGridViewRow>()
                .FirstOrDefault(r => !r.IsNewRow &&
                                     Convert.ToInt32(r.Cells[0].Value) == codigoProducto);

            if (producto == null)
            {
                MessageBox.Show("Producto no encontrado.");
                return;
            }

            string descripcion = producto.Cells[1].Value.ToString();
            decimal precio = Convert.ToDecimal(producto.Cells[2].Value);
            int stock = Convert.ToInt32(producto.Cells[3].Value);

            // 🔹 Si ya está en el carrito, solo sumamos cantidad
            foreach (DataGridViewRow fila in dgvCarrito.Rows)
            {
                if (!fila.IsNewRow && Convert.ToInt32(fila.Cells[0].Value) == codigoProducto)
                {
                    int cantidadActual = Convert.ToInt32(fila.Cells[3].Value);
                    int nuevaCantidad = cantidadActual + cantidadAgregar;

                    if (nuevaCantidad > stock)
                    {
                        fila.Cells[3].Value = stock;
                        MessageBox.Show(
                            $"Stock insuficiente. Solo hay {stock} unidades disponibles.",
                            "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        fila.Cells[3].Value = nuevaCantidad;
                    }

                    ActualizarTotales();
                    ActualizarImagenCarrito();
                    return;
                }
            }

            // 🔹 Si no estaba en el carrito, agregamos nueva fila
            int cantidadFinal = cantidadAgregar;
            if (cantidadFinal > stock)
            {
                cantidadFinal = stock;
                MessageBox.Show(
                    $"Stock insuficiente. Solo hay {stock} unidades disponibles.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            dgvCarrito.Rows.Add(
                codigoProducto,
                descripcion,
                precio,
                cantidadFinal,
                Eliminar,
                Restar,
                Sumar
            );

            ActualizarTotales();
            ActualizarImagenCarrito();
        }
        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null && dgvProductos.CurrentRow.Selected)
            {
                txtCodigo.Text = dgvProductos.CurrentRow.Cells[0].Value?.ToString();
                txtProducto.Text = dgvProductos.CurrentRow.Cells[1].Value?.ToString();
                txtPrecio.Text = dgvProductos.CurrentRow.Cells[2].Value?.ToString();
            }
            else
            {
                txtCodigo.Text = "";
                txtProducto.Text = "";
                txtPrecio.Text = "";
            }
        }

        private void dgvCarrito_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvCarrito.RowCount)
                return;

            // Código del producto en el carrito
            int codigoProducto = Convert.ToInt32(dgvCarrito.Rows[e.RowIndex].Cells[0].Value);

            // Buscar stock en dgvProductos
            int stock = 0;
            foreach (DataGridViewRow fila in dgvProductos.Rows)
            {
                if (!fila.IsNewRow && Convert.ToInt32(fila.Cells[0].Value) == codigoProducto)
                {
                    stock = Convert.ToInt32(fila.Cells[3].Value); // Stock
                    break;
                }
            }

            // Eliminar
            if (e.ColumnIndex == 4)
            {
                if (dgvCarrito.CurrentRow != null)
                    dgvCarrito.Rows.Remove(dgvCarrito.CurrentRow);

                ActualizarTotales();
                ActualizarImagenCarrito();
                return;
            }

            // Restar
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
                    MessageBox.Show("La cantidad no puede ser menor a 1",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return;
            }

            // Sumar
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
                    MessageBox.Show(
                        $"Stock insuficiente. Solo hay {stock} unidades disponibles.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // 1. VALIDAR CARRITO VACÍO
            if (dgvCarrito.Rows.Count == 0)
            {
                MessageBox.Show("El carrito está vacío. Agregue productos para generar la orden.",
                                "Carrito Vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. VALIDAR PROVEEDOR (Usando el Label o la Variable)
            // Si el label dice "---" o está vacío, es que no se ha seleccionado a nadie
            if (lblProveedorActual.Text == "---" || string.IsNullOrEmpty(lblProveedorActual.Text) || _proveedorSeleccionado == null)
            {
                MessageBox.Show("Por favor busque y seleccione un proveedor antes de generar el reporte.",
                                "Falta Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProveedor.Focus(); // Mandamos el cursor al buscador
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            string nombreUsuario = await ObtenerNombreUsuarioActual(); 
            this.Cursor = Cursors.Default;

            List<clsOrdenCompra> itemsParaReporte = new List<clsOrdenCompra>();

            // 3. LEER EL CARRITO FILA POR FILA
            foreach (DataGridViewRow row in dgvCarrito.Rows)
            {
                if (row.IsNewRow) continue;

                clsOrdenCompra item = new clsOrdenCompra();
                // Asegúrate que los nombres de columnas ("colCodigo", etc.) sean los de tu diseño
                item.Codigo = row.Cells["colCodigo"].Value.ToString();
                item.Producto = row.Cells["colProducto"].Value.ToString();
                item.Precio = Convert.ToDecimal(row.Cells["colPrecio"].Value);
                item.Cantidad = Convert.ToInt32(row.Cells["colCantidad"].Value);

                itemsParaReporte.Add(item);
            }

            // 4. LEER LOS TOTALES
            string sub = txtSubTotal.Text;
            string imp = txtImpuesto.Text;
            string total = txtTotal.Text;

            // 5. OBTENER EL NOMBRE DEL PROVEEDOR (DESDE EL LABEL)
            // Aquí tomamos exactamente lo que el usuario ve en el Label de selección
            string nombreProveedor = lblProveedorActual.Text;

            // 6. CREAR Y MOSTRAR EL REPORTE
            // Pasamos los 5 argumentos: Lista, Subtotal, Impuesto, Total, Proveedor
            frmReporteOrdenCompra frmReporte = new frmReporteOrdenCompra(itemsParaReporte, sub, imp, total, nombreProveedor, nombreUsuario);

            frmReporte.ShowDialog();
        }

        private void txtProveedor_TextChanged(object sender, EventArgs e)
        {
            string texto = txtProveedor.Text.ToLower().Trim();

            // 1. Si está vacío, limpiamos y ocultamos
            if (string.IsNullOrEmpty(texto))
            {
                lstSugerencias.Visible = false;
                _proveedorSeleccionado = null; // Reiniciamos la selección
                return;
            }

            // 2. Filtramos la lista que ya tenemos en memoria
            var resultados = _todosLosProveedores
                .Where(p => p.NombreProveedor.ToLower().Contains(texto)) // Filtra por nombre
                .ToList();

            // 3. Si hay resultados, mostramos la lista
            if (resultados.Count > 0)
            {
                lstSugerencias.DataSource = null; // Limpiar anterior
                lstSugerencias.DataSource = resultados;
                lstSugerencias.DisplayMember = "NombreProveedor"; // Qué campo mostrar
                lstSugerencias.ValueMember = "IdProveedor";       // Qué campo vale (el ID)

                lstSugerencias.Visible = true;

                // Ajustar altura (opcional, visualmente agradable)
                int alturaItem = lstSugerencias.ItemHeight;
                lstSugerencias.Height = (resultados.Count * alturaItem) + 10;
            }
            else
            {
                lstSugerencias.Visible = false;
            }
        }

        private void lstSugerencias_Click(object sender, EventArgs e)
        {
            if (lstSugerencias.SelectedItem is Proveedor proveedor)
            {
                // 2. Rellenar el TextBox con el nombre completo
                txtProveedor.Text = proveedor.NombreProveedor;

                // 3. GUARDAR EL PROVEEDOR EN LA VARIABLE (Esto es lo importante)
                _proveedorSeleccionado = proveedor;

                // 4. Ocultar la lista
                lstSugerencias.Visible = false;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void LimpiarCarrito()
        {
            // 1. Borrar todas las filas del DataGridView del carrito
            dgvCarrito.Rows.Clear();

            // 2. Recalcular los totales (al estar vacío, se pondrán en 0.00)
            ActualizarTotales();

            // 3. Mostrar la imagen de "Carrito Vacío" (si tienes ese método implementado)
            ActualizarImagenCarrito();

            // 4. Limpiar los campos de selección de producto (Opcional, por estética)
            txtCodigo.Text = "";
            txtProducto.Text = "";
            txtPrecio.Text = "";
            nudCantidad.Value = 1;

            // 5. Quitar la selección de la tabla de productos
            dgvProductos.ClearSelection();
            lblProveedorActual.Text = "---";
            _proveedorSeleccionado = null;
            txtProveedor.Text = "";
        }
        

        private bool ValidarYLimpiarCarrito(string nuevoProveedorNombre)
        {
            // 1. VERIFICAR SI EL CARRITO ESTÁ REALMENTE VACÍO
            // (Contamos solo las filas que no son la fila nueva de ingreso)
            int cantidadProductos = 0;
            foreach (DataGridViewRow row in dgvCarrito.Rows)
            {
                if (!row.IsNewRow) cantidadProductos++;
            }

            // Si no hay productos, no hay conflicto. Pasa adelante.
            if (cantidadProductos == 0) return true;

            // 2. OBTENER EL PROVEEDOR ACTUAL (DESDE EL LABEL)
            // Limpiamos cualquier prefijo por si acaso tu label dice "Proveedor: Kevin"
            string proveedorActual = lblProveedorActual.Text
                                        .Replace("Proveedor:", "")
                                        .Replace("Proveedor Actual:", "")
                                        .Trim();
            /*MessageBox.Show($"COMPARACIÓN DE SEGURIDAD:\n\n" +
                    $"Label (Limpio): '{proveedorActual}'\n" +
                    $"Nuevo Intento: '{nuevoProveedorNombre}'\n\n" +
                    $"¿Son iguales?: {proveedorActual.Equals(nuevoProveedorNombre.Trim(), StringComparison.OrdinalIgnoreCase)}");*/

            // Si el label dice "---" o está vacío, asumimos que no hay dueño.
            if (string.IsNullOrEmpty(proveedorActual) || proveedorActual == "---") return true;

            // 3. COMPARACIÓN: ¿Es el mismo proveedor?
            if (proveedorActual.Equals(nuevoProveedorNombre.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                return true; // Son iguales, no hacemos nada.
            }

            // 4. ¡CONFLICTO DETECTADO! (Hay productos y los nombres son diferentes)
            var respuesta = MessageBox.Show(
                $"El carrito tiene productos de: {proveedorActual}.\n" +
                $"Estás intentando cambiar a: {nuevoProveedorNombre}.\n\n" +
                "Si cambias, EL CARRITO SE VACIARÁ.\n" +
                "¿Deseas continuar?",
                "Cambio de Proveedor",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (respuesta == DialogResult.Yes)
            {
                LimpiarCarrito();
                return true; // Usuario aceptó borrar y continuar
            }
            else
            {
                // Usuario dijo NO. Revertimos el buscador al nombre original.
                txtProveedor.Text = proveedorActual;
                return false; // Cancelamos la búsqueda
            }
            /* // 1. Si el carrito está vacío, no hay problema, dejamos pasar.
             if (dgvCarrito.Rows.Count == 0)
             {
                 return true;
             }

             // 2. Si ya hay un proveedor seleccionado, verificamos si es el mismo
             if (_proveedorSeleccionado != null)
             {
                 // Si el nombre es igual (ignorando mayúsculas), no hacemos nada, dejamos pasar.
                 if (_proveedorSeleccionado.NombreProveedor.Equals(nuevoProveedorNombre, StringComparison.OrdinalIgnoreCase))
                 {
                     return true;
                 }
             }

             // 3. ¡CONFLICTO! Hay productos y el usuario quiere cambiar de proveedor.
             var respuesta = MessageBox.Show(
                 $"El carrito actual tiene productos del proveedor: {(_proveedorSeleccionado?.NombreProveedor ?? "Desconocido")}.\n\n" +
                 "Una Orden de Compra no puede mezclar proveedores.\n" +
                 "Si continúas, EL CARRITO SE VACIARÁ automáticamente.\n\n" +
                 $"¿Deseas cambiar al proveedor '{nuevoProveedorNombre}' y borrar el carrito?",
                 "Cambio de Proveedor Detectado",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Warning);

             if (respuesta == DialogResult.Yes)
             {
                 // 4. Usuario dijo SÍ: Limpiamos todo y dejamos pasar.
                 LimpiarCarrito();
                 return true;
             }
             else
             {
                 // 5. Usuario dijo NO: Cancelamos la operación.
                 if (_proveedorSeleccionado != null)
                 {
                     txtProveedor.Text = _proveedorSeleccionado.NombreProveedor;
                 }
                 return false;
             }*/
        }
        
        private async void btnBuscarProv_Click(object sender, EventArgs e)
        {
            string nombreBusqueda = txtProveedor.Text.Trim(); // Tu textbox de búsqueda

            // 1. Si limpian la caja, reseteamos todo
            if (string.IsNullOrEmpty(nombreBusqueda))
            {
                if (!ValidarYLimpiarCarrito("")) return; // Validamos antes de borrar

                await CargarProductosAsync(); // Carga todos
                RefrescarGrid();
                _proveedorSeleccionado = null;
                lblProveedorActual.Text = "---";
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            try
            {
                // 2. BUSCAR EN LA LISTA DE MEMORIA (Es más rápido que ir a la BD)
                // Buscamos el objeto proveedor que coincida con el nombre escrito
                var proveedorEncontrado = _todosLosProveedores
                    .FirstOrDefault(p => p.NombreProveedor.Equals(nombreBusqueda, StringComparison.OrdinalIgnoreCase));

                // Si no está en memoria (raro), lo buscamos en BD por si acaso
                if (proveedorEncontrado == null)
                {
                    var resultadosBD = await proveedorRepositorio.BuscarProveedoresPorNombre(nombreBusqueda);
                    if (resultadosBD != null && resultadosBD.Count > 0)
                        proveedorEncontrado = resultadosBD.First();
                }

                // Si después de todo no existe...
                if (proveedorEncontrado == null)
                {
                    MessageBox.Show("No se encontró ese proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Cursor = Cursors.Default;
                    return;
                }

                // 3. VALIDACIÓN DE SEGURIDAD (El momento clave)
                // Comparamos el nombre del proveedor encontrado contra el Label actual
                if (!ValidarYLimpiarCarrito(proveedorEncontrado.NombreProveedor))
                {
                    this.Cursor = Cursors.Default;
                    return; // Usuario canceló
                }

                // 4. APLICAR EL CAMBIO (Usuario aceptó o carrito estaba vacío)
                _proveedorSeleccionado = proveedorEncontrado;
                lblProveedorActual.Text = _proveedorSeleccionado.NombreProveedor; // Actualizamos el Label Visual

                // 5. FILTRAR PRODUCTOS
                var productosDelProveedor = await _productoRepo.ObtenerCatalogoPorProveedorAsync(_proveedorSeleccionado.IdProveedor);

                if (productosDelProveedor.Count > 0)
                {
                    _productosCache = productosDelProveedor;
                    RefrescarGrid();
                    MessageBox.Show($"Filtro aplicado: {_proveedorSeleccionado.NombreProveedor}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"El proveedor {_proveedorSeleccionado.NombreProveedor} no tiene productos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvProductos.DataSource = null;
                    dgvProductos.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            /*string nombreBusqueda = txtProveedor.Text.Trim();

            // 1. CASO: BUSCADOR VACÍO (RESETEAR)
            if (string.IsNullOrEmpty(nombreBusqueda))
            {
                // Si hay productos, preguntamos antes de limpiar
                if (!ValidarYLimpiarCarrito("")) return;

                await CargarProductosAsync();
                RefrescarGrid();
                _proveedorSeleccionado = null;
                lblProveedorActual.Text = "---"; // Reseteamos el label
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            try
            {
                // Variable temporal para el proveedor encontrado
                Proveedor proveedorEncontrado = null;

                // 2. BUSCAR EL PROVEEDOR (EN MEMORIA O EN BD)

                // A) Si ya es el que tenemos en la variable interna
                if (_proveedorSeleccionado != null &&
                    _proveedorSeleccionado.NombreProveedor.Equals(nombreBusqueda, StringComparison.OrdinalIgnoreCase))
                {
                    proveedorEncontrado = _proveedorSeleccionado;
                }
                // B) Si no, buscamos en la base de datos
                else
                {
                    var resultados = await proveedorRepositorio.BuscarProveedoresPorNombre(nombreBusqueda);

                    if (resultados != null && resultados.Count > 0)
                    {
                        proveedorEncontrado = resultados.First();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún proveedor con ese nombre.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return; // Salimos aquí, el cursor se restaura en el finally
                    }
                }

                // 3. VALIDACIÓN DE SEGURIDAD (EL CAMBIO IMPORTANTE)
                // Validamos usando el nombre REAL del proveedor que encontramos en la BD
                if (!ValidarYLimpiarCarrito(proveedorEncontrado.NombreProveedor))
                {
                    return; // El usuario dijo "No" a borrar el carrito
                }

                // 4. APLICAR CAMBIOS (Solo si pasó la validación)
                _proveedorSeleccionado = proveedorEncontrado;
                lblProveedorActual.Text = _proveedorSeleccionado.NombreProveedor; // Actualizamos el Label Visual

                // 5. CARGAR PRODUCTOS DEL PROVEEDOR
                var productosDelProveedor = await _productoRepo.ObtenerProductosPorProveedorAsync(_proveedorSeleccionado.IdProveedor);

                if (productosDelProveedor.Count > 0)
                {
                    _productosCache = productosDelProveedor; // Actualizamos memoria

                    // CORRECCIÓN: NO usamos DataSource directo, usamos tu método auxiliar
                    RefrescarGrid();

                    MessageBox.Show($"Se encontraron {productosDelProveedor.Count} productos de {_proveedorSeleccionado.NombreProveedor}.", "Filtro Aplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"El proveedor {_proveedorSeleccionado.NombreProveedor} no tiene productos registrados.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiamos la tabla visualmente
                    dgvProductos.DataSource = null;
                    dgvProductos.Rows.Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }*/

        }
        private void RefrescarGrid()
        {
            // 1. Desvinculamos el DataSource para poder manipular las filas manualmente
            dgvProductos.DataSource = null;

            // 2. Limpiamos las filas anteriores
            dgvProductos.Rows.Clear();

            // 3. Recorremos la lista (que puede ser la filtrada o la completa)
            //    y agregamos las filas manuales respetando tus columnas diseñadas.
            foreach (var p in _productosCache)
            {
                dgvProductos.Rows.Add(
                    p.IdProducto,       // Columna 0: Código
                    p.NombreProducto,   // Columna 1: Producto
                    p.PrecioCompra,     // Columna 2: Precio
                    p.CantidadProducto  // Columna 3: Stock
                );
            }

            // 4. Ajustes visuales finales
            if (dgvProductos.Rows.Count > 0)
            {
                dgvProductos.ClearSelection();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void lstSugerencias_MouseClick(object sender, MouseEventArgs e)
        {
           /* if (lstSugerencias.SelectedItem is Proveedor nuevoProveedor)
            {
                // Validamos contra el proveedor ANTERIOR (que todavía está en _proveedorSeleccionado)
                if (!ValidarYLimpiarCarrito(nuevoProveedor.NombreProveedor))
                {
                    // Si el usuario dijo "NO", ocultamos la lista y restauramos el texto viejo
                    lstSugerencias.Visible = false;
                    if (_proveedorSeleccionado != null)
                        txtProveedor.Text = _proveedorSeleccionado.NombreProveedor;
                    return;
                }

                // Si pasó la validación (dijo "SÍ" o el carrito estaba vacío):
                _proveedorSeleccionado = nuevoProveedor;
                txtProveedor.Text = nuevoProveedor.NombreProveedor;

                // Ocultamos la lista
                lstSugerencias.Visible = false;

            }*/
           
        }

        private void lstSugerencias_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
