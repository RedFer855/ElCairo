using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.InterfacesUsuarios.Inventario;
using CapaDominio.Entidades;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sprache;

namespace ModernMenuUI
{
    public partial class frmAgregarEditarProducto : Form
    {
        private Producto _productoSeleccionado;
        private int _idMarcaSeleccionada;
        private int _idCategoriaSeleccionada;
        private int _idPresentacionSeleccionada;

        private string _nombreArchivo;
        private byte[] _byteImagen;

        private ConfiguracionGananciaProducto _configGananciaProducto;

        private readonly RepositorioImgenSupabase repositorioImg = new RepositorioImgenSupabase();

        public event EventHandler<Image> ImagenSeleccionada;

        public frmAgregarEditarProducto()
        {
            InitializeComponent();
            lblNombreModulo.Text = "AGREGAR PRODUCTO";
            btnGuardarProducto.Visible = true;
            btnModificarProducto.Visible = false;
        }

        public frmAgregarEditarProducto(Producto productoseleccionado)
        {
            InitializeComponent();

            _productoSeleccionado = productoseleccionado;

            txtNombreProducto.Text = productoseleccionado.NombreProducto;
            txtMarca.Text = productoseleccionado.NombreMarca;
            txtCategoria.Text = productoseleccionado.NombreCategoria;
            txtPrecioCosto.Text = productoseleccionado.PrecioCosto.ToString("0.00");
            txtPrecioCompra.Text = productoseleccionado.PrecioCompra.ToString("0.00");
            txtPrecioVenta.Text = productoseleccionado.PrecioVenta.ToString("0.00");
            txtTipoGanancia.Text = productoseleccionado.TipoCalculoGananciaProducto.ToString();
            txtCodBarra.Text = productoseleccionado.CodigoBarraProducto;
            txtPresentacion.Text = productoseleccionado.NombrePresentacion?.ToString();
            //txtCantidad.Text = productoseleccionado.CantidadProducto.ToString();

            _idMarcaSeleccionada = productoseleccionado.IdMarca;
            _idCategoriaSeleccionada = productoseleccionado.IdCategoria;
            _idPresentacionSeleccionada = productoseleccionado.IdPresentacion;

            _nombreArchivo = productoseleccionado.ImagenProducto;

            _configGananciaProducto = new ConfiguracionGananciaProducto
            {
                PrecioCompra = productoseleccionado.PrecioCompra,
                PrecioCosto = productoseleccionado.PrecioCosto,
                PrecioFinal = productoseleccionado.PrecioVenta,
                PorcentajeGanancia = productoseleccionado.PorcentajeGananciaProducto,
                TipoCalculoGananciaProducto = productoseleccionado.TipoCalculoGananciaProducto,
                UsaModoGanancia = productoseleccionado.TipoCalculoGananciaProducto == 1,
                UsaModoPrecio = productoseleccionado.TipoCalculoGananciaProducto == 2
            };

            if (productoseleccionado.EstadoProducto)
                rbHabilitado.Checked = true;
            else
                rbDeshabilitado.Checked = true;

            CargarPresentacionEnControles(productoseleccionado.ContenidoProducto);

            lblNombreModulo.Text = "EDITAR PRODUCTO";
            btnGuardarProducto.Visible = true;
            btnModificarProducto.Visible = false;
        }

        private async void frmAgregarEditarProducto_Load(object sender, EventArgs e)
        {
            if (_productoSeleccionado == null)
            {
                rbHabilitado.Checked = true;
            }

            await CargarImagenProductoAsync();

        }

        private async Task CargarImagenProductoAsync()
        {
            if (_productoSeleccionado == null)
                return;

            if (string.IsNullOrWhiteSpace(_productoSeleccionado.ImagenProducto))
                return;

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
            Close();
        }

        private async void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            ProductoRepositorio repo = new ProductoRepositorio();

            try
            {
                decimal precioCompra = 0m;
                decimal precioVenta = 0m;
                decimal precioCosto = 0m;
                decimal porcentajeGananciaProducto = 0m;
                int tipoCalculoGananciaProducto = 0;
                int cantidad = 0;
                int contenido = 0;

                if (!int.TryParse(txtContenido.Text.Trim(), out contenido))
                {
                    MessageBox.Show(
                        "El contenido debe ser numérico.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    txtContenido.Focus();
                    return;
                }

                if (_productoSeleccionado != null)
                {
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

                    txtTipoGanancia.Text = tipoCalculoGananciaProducto.ToString();
                }
                else
                {
                    if (!decimal.TryParse(txtPrecioCompra.Text.Trim(), out precioCompra))
                    {
                        MessageBox.Show("Precio de compra inválido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPrecioCompra.Focus();
                        return;
                    }

                    if (!decimal.TryParse(txtPrecioVenta.Text.Trim(), out precioVenta))
                    {
                        MessageBox.Show("Precio de venta inválido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPrecioVenta.Focus();
                        return;
                    }

                    if (!decimal.TryParse(txtPrecioCosto.Text.Trim(), out precioCosto))
                    {
                        MessageBox.Show("Precio costo inválido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPrecioCosto.Focus();
                        return;
                    }

                    if (!int.TryParse(txtTipoGanancia.Text.Trim(), out tipoCalculoGananciaProducto))
                    {
                        MessageBox.Show(
                            "No se pudo obtener el tipo de cálculo de ganancia.",
                            "Validación",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }

                    if (_configGananciaProducto != null)
                        porcentajeGananciaProducto = _configGananciaProducto.PorcentajeGanancia;
                    else
                        porcentajeGananciaProducto = _productoSeleccionado.PorcentajeGananciaProducto;
                }

                if (cmbUnidadContenido.SelectedIndex == -1)
                {
                    MessageBox.Show(
                        "Seleccione una unidad de contenido válida.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                if (contenido <= 0)
                {
                    MessageBox.Show(
                        "Contenido no puede ser menor o igual a 0.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

               // int cantidadP = Convert.ToInt32(txtCantidad.Value);

                ProductoInsertar productoInsertar = new ProductoInsertar
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
                    //CantidadProducto = cantidadP,
                    ProductoPath = _nombreArchivo,
                    EstadoProducto = rbHabilitado.Checked,
                    IdEstado = rbHabilitado.Checked ? 1 : 2
                };

                var resultado = ServicioValidacionesIngresoDatos.EjecutarValidacionesProducto(productoInsertar);

                if (resultado.Error)
                {
                    MessageBox.Show(resultado.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                btnGuardarProducto.Enabled = false;
                Cursor = Cursors.WaitCursor;

                if (_byteImagen != null && !string.IsNullOrWhiteSpace(_nombreArchivo))
                {
                    await repositorioImg.IngresarImagen(_byteImagen, _nombreArchivo);
                }

                if (_productoSeleccionado == null)
                {
                    await repo.InsertarProducto(productoInsertar);
                    MessageBox.Show("Producto guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    productoInsertar.IdProducto = _productoSeleccionado.IdProducto;
                    await repo.ActualizarProducto(productoInsertar);
                    MessageBox.Show("Producto actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                DialogResult = DialogResult.OK;
                Close();
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
                Cursor = Cursors.Default;
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

        private void btnModoGanancia_Click(object sender, EventArgs e)
        {
            frmAgregarEditarGananciaModo modoGanancia;

            if (_productoSeleccionado != null)
            {
                ConfiguracionGananciaProducto datosEditar = new ConfiguracionGananciaProducto
                {
                    PrecioCompra = decimal.TryParse(txtPrecioCompra.Text, out decimal pc) ? pc : 0m,
                    PrecioCosto = decimal.TryParse(txtPrecioCosto.Text, out decimal pco) ? pco : 0m,
                    PrecioFinal = decimal.TryParse(txtPrecioVenta.Text, out decimal pv) ? pv : 0m,
                    PorcentajeGanancia = _configGananciaProducto != null
                        ? _configGananciaProducto.PorcentajeGanancia
                        : _productoSeleccionado.PorcentajeGananciaProducto,
                    TipoCalculoGananciaProducto = int.TryParse(txtTipoGanancia.Text, out int tg)
                        ? tg
                        : _productoSeleccionado.TipoCalculoGananciaProducto,
                    UsaModoGanancia = (int.TryParse(txtTipoGanancia.Text, out int tg2) ? tg2 : _productoSeleccionado.TipoCalculoGananciaProducto) == 1,
                    UsaModoPrecio = (int.TryParse(txtTipoGanancia.Text, out int tg3) ? tg3 : _productoSeleccionado.TipoCalculoGananciaProducto) == 2
                };

                modoGanancia = new frmAgregarEditarGananciaModo(true, datosEditar);
            }
            else
            {
                modoGanancia = new frmAgregarEditarGananciaModo();
            }

            using (modoGanancia)
            {
                if (modoGanancia.ShowDialog() == DialogResult.OK)
                {
                    if (modoGanancia.DatosGanancia != null)
                    {
                        MessageBox.Show(
                            "DATOS RECIBIDOS DESDE EL FORM DE GANANCIA:\n\n" +
                            $"PrecioCompra: {modoGanancia.DatosGanancia.PrecioCompra:0.00}\n" +
                            $"PrecioCosto: {modoGanancia.DatosGanancia.PrecioCosto:0.00}\n" +
                            $"PrecioFinal: {modoGanancia.DatosGanancia.PrecioFinal:0.00}\n" +
                            $"PorcentajeGanancia: {modoGanancia.DatosGanancia.PorcentajeGanancia:0.00}\n" +
                            $"TipoCalculoGananciaProducto: {modoGanancia.DatosGanancia.TipoCalculoGananciaProducto}\n" +
                            $"UsaModoGanancia: {modoGanancia.DatosGanancia.UsaModoGanancia}\n" +
                            $"UsaModoPrecio: {modoGanancia.DatosGanancia.UsaModoPrecio}",
                            "Depuración",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    else
                    {
                        MessageBox.Show(
                            "DatosGanancia llegó en NULL.",
                            "Depuración",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }

                    _configGananciaProducto = modoGanancia.DatosGanancia;

                    if (_configGananciaProducto != null)
                    {
                        txtPrecioCompra.Text = _configGananciaProducto.PrecioCompra.ToString("0.00");
                        txtPrecioCosto.Text = _configGananciaProducto.PrecioCosto.ToString("0.00");
                        txtPrecioVenta.Text = _configGananciaProducto.PrecioFinal.ToString("0.00");
                        txtTipoGanancia.Text = _configGananciaProducto.TipoCalculoGananciaProducto.ToString();
                    }
                }
                else
                {
                    MessageBox.Show(
                        "El formulario de ganancia no devolvió OK.",
                        "Depuración",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
        }
    }
}