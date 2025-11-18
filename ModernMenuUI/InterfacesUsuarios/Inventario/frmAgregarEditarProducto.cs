using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Repositorios;
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
    public partial class frmAgregarEditarProducto : Form
    {
        private Producto _productoActual;
        private int _idMarcaSeleccionada;
        private int _idCategoriaSeleccionada;
        private int _idPresentacionSeleccionada;
        private int _idTamanioSeleccionado;

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
            _productoActual = productoseleccionado;
            txtNombreProducto.Text = productoseleccionado.NombreProducto;
            txtMarca.Text = productoseleccionado.NombreMarca;
            txtCategoria.Text = productoseleccionado.NombreCategoria;
            txtPrecio.Text = productoseleccionado.PrecioCosto.ToString();
            txtPrecioCompra.Text = productoseleccionado.PrecioCompra.ToString();
            txtPrecioVenta.Text = productoseleccionado.PrecioVenta.ToString();
            txtCodBarra.Text = productoseleccionado.CodigoBarraProducto;
            txtPresentacion.Text = productoseleccionado.IdPresentacion.ToString();
            txtCantidad.Text = productoseleccionado.CantidadProducto.ToString();
            if (productoseleccionado.EstadoProducto)
            {
                rbHabilitado.Checked = true;
            }
            else
            {
                rbDeshabilitado.Checked = true;
            }
            pnlNota.Visible = false;
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
            try
            {
                // Validaciones mínimas
                if (string.IsNullOrWhiteSpace(txtNombreProducto.Text))
                {
                    MessageBox.Show("Debe ingresar el nombre del producto.");
                    return;
                }

                if (_idMarcaSeleccionada <= 0)
                {
                    MessageBox.Show("Debe seleccionar una marca.");
                    return;
                }

                if (_idCategoriaSeleccionada <= 0)
                {
                    MessageBox.Show("Debe seleccionar una categoría.");
                    return;
                }

                if (_idPresentacionSeleccionada <= 0)
                {
                    MessageBox.Show("Debe seleccionar una presentación.");
                    return;
                }

                if (_idTamanioSeleccionado <= 0)
                {
                    MessageBox.Show("Debe seleccionar un tamaño.");
                    return;
                }

                // Convertir precios
                if (!decimal.TryParse(txtPrecioCompra.Text, out decimal precioCompra))
                {
                    MessageBox.Show("Precio de compra inválido.");
                    return;
                }

                if (!decimal.TryParse(txtPrecio.Text, out decimal precioCosto))
                {
                    MessageBox.Show("Precio costo inválido.");
                    return;
                }

                if (!decimal.TryParse(txtPrecioVenta.Text, out decimal precioVenta))
                {
                    MessageBox.Show("Precio venta inválido.");
                    return;
                }

                if (!int.TryParse(txtCantidad.Text, out int cantidad))
                {
                    MessageBox.Show("Cantidad inválida.");
                    return;
                }

                // Crear nuevo producto
                Producto nuevoProducto = new Producto
                {
                    NombreProducto = txtNombreProducto.Text,
                    CodigoBarraProducto = txtCodBarra.Text,
                    IdMarca = _idMarcaSeleccionada,
                    IdCategoria = _idCategoriaSeleccionada,
                    IdPresentacion = _idPresentacionSeleccionada,
                    IdTamanio = _idTamanioSeleccionado,

                    PrecioCompra = precioCompra,
                    PrecioCosto = precioCosto,
                    PrecioVenta = precioVenta,
                    CantidadProducto = cantidad,
                    EstadoProducto = rbHabilitado.Checked,   // true = habilitado
                    IdEstado = rbHabilitado.Checked ? 1 : 0  // si usas id_estado
                };

                ProductoRepositorio repo = new ProductoRepositorio();
                var resultado = await repo.InsertarProducto(nuevoProducto);

                MessageBox.Show("Producto guardado correctamente.",
                                 "Éxito",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void btnBuscarCategoria_Click(object sender, EventArgs e)
        {
            frmCategorias categoriaSeleccionada = new frmCategorias();
            categoriaSeleccionada.ShowDialog();
        }

        private void btnBuscarMarca_Click(object sender, EventArgs e)
        {
            frmMarcas marcaSeleccionada = new frmMarcas();
            marcaSeleccionada.ShowDialog();
        }

        private void btnBuscarPresentacion_Click(object sender, EventArgs e)
        {
            frmPresentaciones presentacionSeleccionada = new frmPresentaciones();
            presentacionSeleccionada.ShowDialog();
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }
    }
}
