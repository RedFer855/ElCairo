using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.InterfacesUsuarios.Inventario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI
{
    /// <summary>
    /// Formulario para agregar o editar productos.
    /// - En modo "agregar" muestra controles vacíos y guarda un nuevo producto.
    /// - En modo "editar" carga un producto en los controles y actualiza al guardar.
    /// Mantiene validaciones básicas, manejo de errores y llamadas al repositorio.
    /// </summary>
    public partial class frmAgregarEditarProducto : Form
    {
        /// <summary>
        /// Producto en edición. Si es null, el formulario está en modo "agregar".
        /// </summary>
        private Producto _productoSeleccionado;

        /// <summary>
        /// Id de la marca seleccionada en el selector externo.
        /// </summary>
        private int _idMarcaSeleccionada;

        /// <summary>
        /// Id de la categoría seleccionada en el selector externo.
        /// </summary>
        private int _idCategoriaSeleccionada;

        /// <summary>
        /// Id de la presentación seleccionada en el selector externo.
        /// </summary>
        private int _idPresentacionSeleccionada;

        /// <summary>
        /// Variables para la imagen de los productos.
        /// </summary>
        private string _nombreArchivo;
        private byte[] _byteImagen;

        /// <summary>
        /// Constructor para crear un nuevo producto.
        /// Configura el formulario en modo "AGREGAR".
        /// </summary>
        public frmAgregarEditarProducto()
        {
            InitializeComponent();
            lblNombreModulo.Text = "AGREGAR PRODUCTO";
            btnGuardarProducto.Visible = true;
            btnModificarProducto.Visible = false;
        }
        RepositorioImgenSupabase repositorioImg = new RepositorioImgenSupabase();
        public event EventHandler<Image> ImagenSeleccionada;

        /// <summary>
        /// Constructor para editar un producto existente.
        /// Carga los valores del producto en los controles del formulario.
        /// </summary>
        /// <param name="productoseleccionado">Producto a editar.</param>
        public frmAgregarEditarProducto(Producto productoseleccionado)
        {
            InitializeComponent();

            _productoSeleccionado = productoseleccionado;

            // Cargar valores en controles
            txtNombreProducto.Text = productoseleccionado.NombreProducto;
            txtMarca.Text = productoseleccionado.NombreMarca;
            txtCategoria.Text = productoseleccionado.NombreCategoria;
            txtPrecio.Text = productoseleccionado.PrecioCosto.ToString();
            txtPrecioCompra.Text = productoseleccionado.PrecioCompra.ToString();
            txtPrecioVenta.Text = productoseleccionado.PrecioVenta.ToString();
            txtCodBarra.Text = productoseleccionado.CodigoBarraProducto;
            txtPresentacion.Text = productoseleccionado.NombrePresentacion.ToString();
            txtCantidad.Text = productoseleccionado.CantidadProducto.ToString();
            _idMarcaSeleccionada = productoseleccionado.IdMarca;
            _idCategoriaSeleccionada = productoseleccionado.IdCategoria;
            _idPresentacionSeleccionada = productoseleccionado.IdPresentacion;

            if (productoseleccionado.EstadoProducto)
            {
                rbHabilitado.Checked = true;
            }
            else
            {
                rbDeshabilitado.Checked = true;
            }

            lblNota.Visible = false;

            CargarPresentacionEnControles(productoseleccionado.ContenidoProducto);

        }
        
        protected override async void OnShown(EventArgs e)
        {

        }

        private async void frmAgregarEditarProducto_Load(object sender, EventArgs e)
        {
            await CargarImagenProductoAsync();
        }
        private async Task CargarImagenProductoAsync()
        {
            if (_productoSeleccionado == null)
                return;

            if (string.IsNullOrWhiteSpace(_productoSeleccionado.ImagenProducto))
            {
                MessageBox.Show($"imagen del producto : {_productoSeleccionado.ImagenProducto}");
                return;
            }


            try
                {
                    var imagen = await repositorioImg.LeerImagenes(_productoSeleccionado.ImagenProducto);
                    Imagen_Producto.Image = imagen;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "No se pudo cargar la imagen del producto.\n" + ex.Message,
                        "Imagen",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
        }

        private void ProductosCartas_ImagenSeleccionada(object sender, Image imagen)
        {
            // Mostrar imagen seleccionada en el PictureBox principal
            Imagen_Producto.Image = imagen;

            // Guardar datos para el guardado del producto
            //_byteImagen = bytes;
            //_nombreArchivo = nombreArchivo;
        }

        private void ProductoCartas_urlImagen(object sender, string url)
        {
            _nombreArchivo = url;
            _byteImagen = null; // No es necesario subir bytes si es una imagen existente
        }

        /// <summary>
        /// Maneja arrastre del formulario (mover ventana).
        /// </summary>
        private void Editar_Producto_MouseDown(object sender, MouseEventArgs e)
        {
            clsAnmaciones.MoverFormulario(this.Handle);
        }

        /// <summary>
        /// Maneja arrastre de la barra de control (mover ventana).
        /// </summary>
        private void panBarraControl_MouseDown(object sender, MouseEventArgs e)
        {
            clsAnmaciones.MoverFormulario(this.Handle);
        }

        /// <summary>
        /// Cierra el formulario al presionar el botón "Volver".
        /// </summary>
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evento que guarda o actualiza el producto.
        /// - Construye un objeto <see cref="ProductoInsertar"/> con datos validados.
        /// - Si <see cref="_productoSeleccionado"/> es null inserta, si no actualiza.
        /// - Mantiene manejo de errores específico para clave duplicada (23505).
        /// </summary>
        private async void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            //llamadas a repositorios
            RepositorioImgenSupabase repositorioImg = new RepositorioImgenSupabase();
            ProductoRepositorio repo = new ProductoRepositorio();

            try
            {

                // VARIABLES PARA LOS DATOS NUMÉRICOS
                decimal precioCompra = 0;
                decimal precioVenta = 0;
                decimal precioCosto = 0;
                int cantidad = 0;

                // Si estamos EDITANDO, recuperamos los valores originales para NO perderlos
                if (_productoSeleccionado != null)
                {
                    precioCompra = _productoSeleccionado.PrecioCompra;
                    precioVenta = _productoSeleccionado.PrecioVenta;
                    precioCosto = _productoSeleccionado.PrecioCosto;
                    cantidad = _productoSeleccionado.CantidadProducto;
                }
                // 1. CONSTRUIR OBJETO CON LOS DATOS SEGUROS
                ProductoInsertar _productoInsertar = new ProductoInsertar
                {
                    NombreProducto = txtNombreProducto.Text.Trim(),
                    CodigoBarraProducto = txtCodBarra.Text.Trim(),

                    IdMarca = _idMarcaSeleccionada,
                    IdCategoria = _idCategoriaSeleccionada,
                    IdPresentacion = _idPresentacionSeleccionada,
                    ContenidoProducto = $"{txtContenido.Text.Trim()} {cmbUnidadContenido.SelectedItem?.ToString().Trim()}".Trim(),

                    // ASIGNACIÓN SEGURA (Desde el objeto original, no del TXT)
                    PrecioCompra = precioCompra,
                    PrecioVenta = precioVenta,
                    PrecioCosto = precioCosto,
                    CantidadProducto = cantidad,
                    ProductoPath = _nombreArchivo,
                };

                // 2. VALIDACIONES
                var resultado = ServicioValidacionesIngresoDatos.EjecutarValidacionesProducto(_productoInsertar);

                if (resultado.Error)
                {
                    MessageBox.Show(resultado.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cmbUnidadContenido.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione una unidad de contenido válida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                

                // 3. ASIGNAR ESTADO
                _productoInsertar.EstadoProducto = rbHabilitado.Checked;
                _productoInsertar.IdEstado = rbHabilitado.Checked ? 1 : 2;

                // 4. PREPARAR INTERFAZ
                btnGuardarProducto.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                // Preparar imagen para mostrar después
                // var imagen = await repositorioImg.LeerImagenes(_productoInsertar.ProductoPath);

                // 5. LÓGICA DECISIVA
                if (_productoSeleccionado == null)
                {
                    // INSERTAR
                    if (_byteImagen != null)
                    {
                        // Imagen LOCAL → subir
                        await repositorioImg.IngresarImagen(_byteImagen, _nombreArchivo);
                    }
                    // Imagen del SELECTOR → no hacer nada (solo URL)


                    await repo.InsertarProducto(_productoInsertar);
                    MessageBox.Show("Producto guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // ACTUALIZAR
                    _productoInsertar.IdProducto = _productoSeleccionado.IdProducto;

                    if (_byteImagen != null)
                    {
                        await repositorioImg.IngresarImagen(_byteImagen, _nombreArchivo);
                    }

                    await repo.ActualizarProducto(_productoInsertar);
                    MessageBox.Show("Producto actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("23505") || ex.Message.Contains("duplicate key value"))
                {
                    MessageBox.Show(
                        "El producto o código de barra ya existe. Por favor ingrese uno diferente.",
                        "Código o producto duplicado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
                else
                {
                    MessageBox.Show(
                        "Ocurrió un error: " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            finally
            {
                btnGuardarProducto.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Abre el formulario de selección de categoría y asigna la categoría seleccionada al control.
        /// </summary>
        private void btnBuscarCategoria_Click(object sender, EventArgs e)
        {
            using (var categoriasForm = new frmCategorias())
            {
                if (categoriasForm.ShowDialog() == DialogResult.OK)
                {
                    // Suponiendo que tu frmCategorias tiene la propiedad pública CategoriaSeleccionada
                    txtCategoria.Text = categoriasForm.CategoriaSeleccionada.NombreCategoria;
                    _idCategoriaSeleccionada = categoriasForm.CategoriaSeleccionada.IdCategoria;
                }
            }
        }

        /// <summary>
        /// Abre el formulario de selección de marca y asigna la marca seleccionada al control.
        /// </summary>
        private void btnBuscarMarca_Click(object sender, EventArgs e)
        {
            using (var marcasForm = new frmMarcas())
            {
                if (marcasForm.ShowDialog() == DialogResult.OK)
                {
                    txtMarca.Text = marcasForm.MarcaSeleccionada.NombreMarca;
                    _idMarcaSeleccionada = marcasForm.MarcaSeleccionada.IdMarca;
                }
            }
        }

        /// <summary>
        /// Abre el formulario de selección de presentaciones y asigna la seleccionada al control.
        /// </summary>
        private void btnBuscarPresentacion_Click(object sender, EventArgs e)
        {
            using (var presentacionesForm = new frmPresentaciones())
            {
                if (presentacionesForm.ShowDialog() == DialogResult.OK)
                {
                    txtPresentacion.Text = presentacionesForm.PresentacionSeleccionada.NombrePresentacion;
                    _idPresentacionSeleccionada = presentacionesForm.PresentacionSeleccionada.IdPresentacionProducto;
                }
            }
        }

        /// <summary>
        /// Rellena los controles de "contenido" a partir del texto guardado en la entidad.
        /// - Espera cadenas en formato: "<valor> <unidad>" (ej. "250 ml").
        /// - Si no puede parsear, deja los controles vacíos.
        /// </summary>
        /// <param name="presentacion">Texto guardado en ContenidoProducto.</param>
        private void CargarPresentacionEnControles(string presentacion)
        {
            presentacion = presentacion?.Trim() ?? "";

            // Dividir en 2 partes máximo (valor y unidad)
            var partes = presentacion.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);

            if (partes.Length == 2)
            {
                string valor = partes[0];
                string unidadOriginal = partes[1].ToLower();

                txtContenido.Text = valor;

                int index = -1;
                for (int i = 0; i < cmbUnidadContenido.Items.Count; i++)
                {
                    if (cmbUnidadContenido.Items[i].ToString().ToLower() == unidadOriginal)
                    {
                        index = i;
                        break;
                    }
                }

                cmbUnidadContenido.SelectedIndex = index;
            }
            else
            {
                txtContenido.Text = "";
                cmbUnidadContenido.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Habilita el botón guardar y oculta el botón modificar (cambia a modo edición visual).
        /// </summary>
        private void btnModificarProducto_Click(object sender, EventArgs e)
        {
            btnGuardarProducto.Visible = true;
            btnModificarProducto.Visible = false;
        }

        /// <summary>
        /// Evento del combobox de unidad de contenido. Actualmente vacío — reservado por si se requiere lógica adicional.
        /// </summary>
        private void cmbUnidadContenido_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void Imagen_Producto_Click(object sender, EventArgs e)
        {
            //file dialog (sacando la imagen de los archivos
            using (OpenFileDialog openfile = new OpenFileDialog())
            {
                openfile.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.webp";
                openfile.Title = "Seleccionar imagen del producto";

                if (openfile.ShowDialog() == DialogResult.OK)
                {
                    // Mostrar imagen en el PictureBox
                    Imagen_Producto.Image = Image.FromFile(openfile.FileName);

                    // Guardar datos en memoria
                    _byteImagen = File.ReadAllBytes(openfile.FileName);
                    _nombreArchivo = $"{Guid.NewGuid()}{Path.GetExtension(openfile.FileName)}";
                }
            }
        }

        private void btnImagenes_Click(object sender, EventArgs e)
        {
            ProductosCartas productosCartas = new ProductosCartas();
            productosCartas.ImagenSeleccionada += ProductoCartas_urlImagen;
            productosCartas.ImagenSeleccionada_ += ProductosCartas_ImagenSeleccionada;
            productosCartas.ShowDialog();
        }
    }
}
