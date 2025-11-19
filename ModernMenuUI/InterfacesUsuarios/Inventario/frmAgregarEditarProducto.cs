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
            txtPresentacion.Text = productoseleccionado.NombrePresentacion.ToString();
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

            CargarPresentacionEnControles(productoseleccionado.ContenidoProducto);
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
                // Construir objeto Producto solo con valores del formulario
                Producto temp = new Producto
                {
                    NombreProducto = txtNombreProducto.Text.Trim(),
                    CodigoBarraProducto = txtCodBarra.Text.Trim(),
                    IdMarca = _idMarcaSeleccionada,
                    IdCategoria = _idCategoriaSeleccionada,
                    IdPresentacion = _idPresentacionSeleccionada,
                    IdTamanio = _idTamanioSeleccionado,
                    ContenidoProducto = $"{txtContenido.Text.Trim()} {cmbUnidadContenido.SelectedItem?.ToString().Trim()}".Trim()
                };

                // Ejecutar validaciones (TODO se maneja en la clase)
                var resultado = ServicioValidacionesIngresoDatos.EjecutarValidacionesProducto(temp);
                if (resultado.Error)
                {
                    MessageBox.Show(resultado.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Asignar estado después de pasar validaciones
                temp.EstadoProducto = rbHabilitado.Checked;
                temp.IdEstado = rbHabilitado.Checked ? 1 : 0;

                // Guardar en la BD
                btnGuardarProducto.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                ProductoRepositorio repo = new ProductoRepositorio();
                var resultadoInsert = await repo.InsertarProducto(temp);

                MessageBox.Show("Producto guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    // Suponiendo que tu frmCategorias tiene la propiedad pública CategoriaSeleccionada
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
    }
}
