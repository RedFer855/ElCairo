using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using DocumentFormat.OpenXml.Office2013.Drawing.Chart;
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
        /// Constructor para crear un nuevo producto.
        /// Configura el formulario en modo "AGREGAR".
        /// </summary>
        public frmAgregarEditarProducto()
        {
            InitializeComponent();
            nudCantidad.Enabled = true;
            nudPrecioCompra.Enabled = true;
            btnGuardarProducto.Visible = true;
            btnModificarProducto.Visible = false;
        }

        /// <summary>
        /// Constructor para editar un producto existente.
        /// Carga los valores del producto en los controles del formulario.
        /// </summary>
        /// <param name="productoseleccionado">Producto a editar.</param>
        public frmAgregarEditarProducto(Producto productoseleccionado)
        {
            this.Text = "Ver Producto";
            InitializeComponent();
            pnlVisualizacion.Visible = true;
            pnlEditarProducto.Visible = false;

            _productoSeleccionado = productoseleccionado;

            txtNombreProducto.Text = productoseleccionado.NombreProducto;
            txtMarca.Text = productoseleccionado.NombreMarca;
            txtCategoria.Text = productoseleccionado.NombreCategoria;
            nudPrecioCompra.Text = productoseleccionado.PrecioCompra.ToString();
            nudPrecioVenta.Text = productoseleccionado.PrecioVenta.ToString();
            txtCodBarra.Text = productoseleccionado.CodigoBarraProducto;
            txtPresentacion.Text = productoseleccionado.NombrePresentacion.ToString();
            nudCantidad.Text = productoseleccionado.CantidadProducto.ToString();
            _idMarcaSeleccionada = productoseleccionado.IdMarca;
            _idCategoriaSeleccionada = productoseleccionado.IdCategoria;
            _idPresentacionSeleccionada = productoseleccionado.IdPresentacion;
            nudPrecioCosto.Value = productoseleccionado.PrecioCosto;
            nudPorcentajeGanancia.Value = productoseleccionado.PorcentajeGananciaProducto;

            if (productoseleccionado.TipoGananciaProducto == 1)
            {
                rbFija.Checked = true;
            }
            else
            {
                rbPorcentual.Checked = true;
            }

            if (productoseleccionado.EstadoProducto)
            {
                rbHabilitado.Checked = true;
            }
            else
            {
                rbDeshabilitado.Checked = true;
            }

            lblPrecioVenta.Text = "L" + nudPrecioVenta.Value;
            lblNombreProducto.Text = txtNombreProducto.Text + " " + txtMarca.Text + " " + txtPresentacion.Text + " " + productoseleccionado.ContenidoProducto.ToString();
            lblCodigoBarraProducto.Text = "Código de barra: " + txtCodBarra.Text;

            CargarPresentacionEnControles(productoseleccionado.ContenidoProducto);
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
            try
            {
                // VARIABLES PARA LOS DATOS NUMÉRICOS
                decimal precioCompra = 0;
                decimal precioVenta = 0;
                decimal precioCosto = 0;
                decimal porcentajeGanancia = 0;
                int cantidad = 0;

                // Si estamos EDITANDO, recuperamos los valores originales para NO perderlos
                if (_productoSeleccionado != null)
                {
                    precioCompra = _productoSeleccionado.PrecioCompra;
                    precioVenta = _productoSeleccionado.PrecioVenta;
                    precioCosto = _productoSeleccionado.PrecioCosto;
                    cantidad = _productoSeleccionado.CantidadProducto;
                    porcentajeGanancia = _productoSeleccionado.PorcentajeGananciaProducto;
                }
                else
                {
                    cantidad = (int)nudCantidad.Value;
                    precioCompra = nudPrecioCompra.Value;
                    precioVenta = nudPrecioVenta.Value;
                }

                ProductoInsertar _productoInsertar = new ProductoInsertar
                {
                    NombreProducto = txtNombreProducto.Text.Trim(),
                    CodigoBarraProducto = txtCodBarra.Text.Trim(),
                    IdMarca = _idMarcaSeleccionada,
                    IdCategoria = _idCategoriaSeleccionada,
                    IdPresentacion = _idPresentacionSeleccionada,
                    ContenidoProducto = $"{txtContenido.Text.Trim()} {cmbUnidadContenido.SelectedItem?.ToString().Trim()}".Trim(),
                    PrecioVenta = nudPrecioVenta.Value,
                    PorcentajeGananciaProducto = nudPorcentajeGanancia.Value,
                    PrecioCompra = precioCompra,
                    PrecioCosto = precioCosto,
                    CantidadProducto = cantidad

                };

                _productoInsertar.EstadoProducto = rbHabilitado.Checked;
                _productoInsertar.IdEstado = rbHabilitado.Checked ? 1 : 2;
                _productoInsertar.TipoGananciaProducto = rbFija.Checked ? 1 : 2;

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


                btnGuardarProducto.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                ProductoRepositorio repo = new ProductoRepositorio();

                if (_productoSeleccionado == null)
                {
                    // MODO INSERTAR
                    await repo.InsertarProducto(_productoInsertar);
                    MessageBox.Show("Producto guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // MODO ACTUALIZAR
                    _productoInsertar.IdProducto = _productoSeleccionado.IdProducto;
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
            this.Text = "Editar Producto";
            pnlVisualizacion.Visible = false;
            pnlEditarProducto.Visible = true;

            nudPrecioVenta.Enabled = true;

            btnGuardarProducto.Visible = true;
            btnModificarProducto.Visible = false;
            pnlDatosGenerales.Enabled = true;
        }

        /// <summary>
        /// Evento del combobox de unidad de contenido. Actualmente vacío — reservado por si se requiere lógica adicional.
        /// </summary>
        private void cmbUnidadContenido_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmAgregarEditarProducto_Load(object sender, EventArgs e)
        {
            var controladorPrecio =
            ControladorSincronizacionPrecio.Crear(
                nudPrecioCosto,
                nudPrecioVenta,
                nudPorcentajeGanancia,
                c => c
                    .DecimalesMoneda(2)
                    .CostoMinimo(0)
                    .PorcentajeMaximo(1000)
                    .PermitirGananciaNegativa(true)
                    .AlError(m => MessageBox.Show(m, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning))
            );

        }

        private void nudPrecioCompra_ValueChanged(object sender, EventArgs e)
        {
            if (_productoSeleccionado == null)
            {
                nudPrecioCosto.Value = nudPrecioCompra.Value;
            }
        }

    }
}
