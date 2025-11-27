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
        private Producto _productoSeleccionado;
        private int _idMarcaSeleccionada;
        private int _idCategoriaSeleccionada;
        private int _idPresentacionSeleccionada;
       

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
                // VARIABLES PARA LOS DATOS NUMÉRICOS
                decimal precioCompra = 0;
                decimal precioVenta = 0;
                decimal precioCosto = 0;
                int cantidad = 0;

                // --- LÓGICA DE PROTECCIÓN DE DATOS ---
                // Si estamos EDITANDO, recuperamos los valores originales para NO perderlos (NO borrarlos)
                if (_productoSeleccionado != null)
                {
                    precioCompra = _productoSeleccionado.PrecioCompra;
                    precioVenta = _productoSeleccionado.PrecioVenta;
                    precioCosto = _productoSeleccionado.PrecioCosto;
                    cantidad = _productoSeleccionado.CantidadProducto;
                }
                // Si es NUEVO, se van en 0 (porque se calculan luego o inician vacíos)

                // 1. CONSTRUIR OBJETO CON LOS DATOS SEGUROS
                ProductoInsertar _productoInsertar = new ProductoInsertar
                {
                    NombreProducto = txtNombreProducto.Text.Trim(),
                    CodigoBarraProducto = txtCodBarra.Text.Trim(),

                    IdMarca = _idMarcaSeleccionada,
                    IdCategoria = _idCategoriaSeleccionada,
                    IdPresentacion = _idPresentacionSeleccionada,
                    ContenidoProducto = $"{txtContenido.Text.Trim()} {cmbUnidadContenido.SelectedItem?.ToString().Trim()}".Trim(),

                    // --- ASIGNACIÓN SEGURA (Desde el objeto original, no del TXT) ---
                    PrecioCompra = precioCompra,
                    PrecioVenta = precioVenta,
                    PrecioCosto = precioCosto,
                    CantidadProducto = cantidad
                };
           
                // 2. VALIDACIONES
                var resultado = ServicioValidacionesIngresoDatos.EjecutarValidacionesProducto(_productoInsertar);
                if (resultado.Error)
                {
                    MessageBox.Show(resultado.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 3. ASIGNAR ESTADO
                _productoInsertar.EstadoProducto = rbHabilitado.Checked;
                _productoInsertar.IdEstado = rbHabilitado.Checked ? 1 : 2;

                // 4. PREPARAR INTERFAZ
                btnGuardarProducto.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                ProductoRepositorio repo = new ProductoRepositorio();

                // --- 5. LÓGICA DECISIVA ---
                if (_productoSeleccionado == null)
                {
                    // === MODO INSERTAR ===
                    await repo.InsertarProducto(_productoInsertar);
                    MessageBox.Show("Producto guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // === MODO ACTUALIZAR ===
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
                    // Otros errores
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

        private void btnModificarProducto_Click(object sender, EventArgs e)
        {
            btnGuardarProducto.Visible = true;
            btnModificarProducto.Visible = false;
        }
    }
}
