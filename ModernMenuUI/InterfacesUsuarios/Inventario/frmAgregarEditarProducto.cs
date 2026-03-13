using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.InterfacesUsuarios.Inventario;
using CapaDominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
        /// Guarda la configuración devuelta por el formulario de ganancia.
        /// </summary>
        private ConfiguracionGananciaProducto _configGananciaProducto;

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

            CargarPresentacionEnControles(productoseleccionado.ContenidoProducto);
        }

        protected override async void OnShown(EventArgs e)
        {

        }

        private async void frmAgregarEditarProducto_Load(object sender, EventArgs e)
        {
            rbActivo.Checked = true;
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
            Imagen_Producto.Image = imagen;
        }

        private void ProductoCartas_urlImagen(object sender, string url)
        {
            _nombreArchivo = url;
            _byteImagen = null;
        }

        private void Editar_Producto_MouseDown(object sender, MouseEventArgs e)
        {
            clsAnmaciones.MoverFormulario(this.Handle);
        }

        private void panBarraControl_MouseDown(object sender, MouseEventArgs e)
        {
            clsAnmaciones.MoverFormulario(this.Handle);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            RepositorioImgenSupabase repositorioImg = new RepositorioImgenSupabase();
            ProductoRepositorio repo = new ProductoRepositorio();

            try
            {
                decimal precioCompra = 0m;
                decimal precioVenta = 0m;
                decimal precioCosto = 0m;
                decimal porcentajeGananciaProducto = 0m;
                int tipoCalculoGananciaProducto = 0;
                int cantidad = 0;
                int contenido = int.Parse(txtContenido.Text);

                if (_productoSeleccionado != null)
                {
                    precioCompra = _productoSeleccionado.PrecioCompra;
                    precioVenta = _productoSeleccionado.PrecioVenta;
                    precioCosto = _productoSeleccionado.PrecioCosto;
                    cantidad = _productoSeleccionado.CantidadProducto;
                }

                if (_productoSeleccionado == null)
                {
                    if (_configGananciaProducto == null)
                    {
                        MessageBox.Show(
                            "Debe configurar el modo de ganancia antes de guardar el producto.",
                            "Validación",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }

                    precioCompra = _configGananciaProducto.PrecioCompra;
                    precioCosto = _configGananciaProducto.PrecioCosto;
                    precioVenta = _configGananciaProducto.PrecioFinal;
                    porcentajeGananciaProducto = _configGananciaProducto.PorcentajeGanancia;
                    tipoCalculoGananciaProducto = _configGananciaProducto.TipoCalculoGananciaProducto;
                }
                else
                {
                    decimal.TryParse(txtPrecioCompra.Text, out precioCompra);
                    decimal.TryParse(txtPrecioVenta.Text, out precioVenta);
                    decimal.TryParse(txtPrecio.Text, out precioCosto);
                }

                ProductoInsertar _productoInsertar = new ProductoInsertar
                {
                    NombreProducto = txtNombreProducto.Text.Trim(),
                    CodigoBarraProducto = txtCodBarra.Text.Trim(),

                    IdMarca = _idMarcaSeleccionada,
                    IdCategoria = _idCategoriaSeleccionada,
                    IdPresentacion = _idPresentacionSeleccionada,
                    ContenidoProducto = $"{txtContenido.Text.Trim()} {cmbUnidadContenido.SelectedItem?.ToString().Trim()}".Trim(),

                    PrecioCompra = precioCompra,
                    PrecioVenta = precioVenta,
                    PrecioCosto = precioCosto,
                    PorcentajeGananciaProducto = porcentajeGananciaProducto,
                    TipoCalculoGananciaProducto = tipoCalculoGananciaProducto,
                    CantidadProducto = cantidad,

                    ProductoPath = _nombreArchivo,
                };

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

                if (contenido <= 0)
                {
                    MessageBox.Show("Contenido no puede ser menor o igual a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _productoInsertar.EstadoProducto = rbHabilitado.Checked;
                _productoInsertar.IdEstado = rbHabilitado.Checked ? 1 : 2;

                btnGuardarProducto.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                if (_productoSeleccionado == null)
                {
                    if (_byteImagen != null)
                    {
                        await repositorioImg.IngresarImagen(_byteImagen, _nombreArchivo);
                    }

                    await repo.InsertarProducto(_productoInsertar);
                    MessageBox.Show("Producto guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
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

        private void btnBuscarCategoria_Click(object sender, EventArgs e)
        {
            using (var categoriasForm = new frmCategorias())
            {
                if (categoriasForm.ShowDialog() == DialogResult.OK)
                {
                    txtCategoria.Text = categoriasForm.CategoriaSeleccionada.NombreCategoria;
                    _idCategoriaSeleccionada = categoriasForm.CategoriaSeleccionada.IdCategoria;
                }
            }
        }

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

        private void CargarPresentacionEnControles(string presentacion)
        {
            presentacion = presentacion?.Trim() ?? "";

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

        private void btnModificarProducto_Click(object sender, EventArgs e)
        {
            btnGuardarProducto.Visible = true;
            btnModificarProducto.Visible = false;
        }

        private void cmbUnidadContenido_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void Imagen_Producto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openfile = new OpenFileDialog())
            {
                openfile.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.webp";
                openfile.Title = "Seleccionar imagen del producto";

                if (openfile.ShowDialog() == DialogResult.OK)
                {
                    Imagen_Producto.Image = Image.FromFile(openfile.FileName);
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnModoGanancia_Click(object sender, EventArgs e)
        {
            using (frmAgregarEditarGananciaModo modoGanancia = new frmAgregarEditarGananciaModo())
            {
                if (modoGanancia.ShowDialog() == DialogResult.OK)
                {
                    _configGananciaProducto = modoGanancia.DatosGanancia;

                    if (_configGananciaProducto != null)
                    {
                        txtPrecioCompra.Text = _configGananciaProducto.PrecioCompra.ToString("0.00");
                        txtPrecio.Text = _configGananciaProducto.PrecioCosto.ToString("0.00");
                        txtPrecioVenta.Text = _configGananciaProducto.PrecioFinal.ToString("0.00");
                    }
                }
            }
        }
    }
}