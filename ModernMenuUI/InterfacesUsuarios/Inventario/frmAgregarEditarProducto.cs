using CapaDeDatos.Modelados;
using CapaDeDatos.Repositorios;
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
    public partial class Editar_Producto : Form
    {
        private int idMarcaSeleccionada = 0;
        private int idCategoriaSeleccionada = 0;
        private readonly ProductoRepositorio _productoRepo = new ProductoRepositorio();
        private Producto _productoActual;

        public Editar_Producto()
        {
            InitializeComponent();
            _productoActual = null;
        }
        public Editar_Producto(Producto productoAEditar)
        {
            InitializeComponent();
            _productoActual = productoAEditar; // Modo "Editar"
        }

        private void lblNombreModulo_Click(object sender, EventArgs e)
        {

        }

        private void Editar_Producto_MouseDown(object sender, MouseEventArgs e)
        {
            clsAnmaciones.MoverFormulario(this.Handle);
        }

        private void panBarraControl_MouseDown(object sender, MouseEventArgs e)
        {
            clsAnmaciones.MoverFormulario(this.Handle);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Editar_Producto_Load(object sender, EventArgs e)
        {
            if (_productoActual != null)
            {
                // --- ¡SÍ, ESTAMOS EDITANDO! ---
                // (Aquí llenamos los campos con los datos guardados)

                this.Text = "Modificar Producto";
                btnGuardar.Text = "Actualizar"; // (Asumiendo que tu botón se llama btnGuardar)

                // Llenamos los TextBoxes
                txtNombreProducto.Text = _productoActual.NombreProducto;
                txtPrecioVenta.Text = _productoActual.PrecioVenta.ToString();
                txtPrecioCompra.Text = _productoActual.PrecioCompra.ToString();
                txtCantidad.Text = _productoActual.CantidadProducto.ToString();
                txtCodBarra.Text = _productoActual.CodigoBarraProducto;
                txtGanancia.Text = _productoActual.PorcentajeGananciaProducto.ToString();
                txtPrecioCosto.Text = _productoActual.PrecioCosto.ToString();

                // Llenamos el Estado (la opción previamente elegida)
                if (_productoActual.EstadoProducto == true)
                {
                    rbActivo.Checked = true;
                }
                else
                {
                    rbInactivo.Checked = true; // (Asegúrate de tener un 'rbInactivo')
                }

                // Llenamos los TextBoxes de Marca y Categoría
                // (Usando las propiedades 'NombreMarca' y 'NombreCategoria' de tu modelo)
                txtMarca.Text = _productoActual.NombreMarca;
                txtCategoria.Text = _productoActual.NombreCategoria;

                // (También guardamos los IDs internamente)
                this.idMarcaSeleccionada = _productoActual.IdMarca;
                this.idCategoriaSeleccionada = _productoActual.IdCategoria;
            }
            else
            {
                // --- NO, ESTAMOS EN MODO AGREGAR ---
                // (Dejamos los campos vacíos, listos para un nuevo producto)
                this.Text = "Agregar Producto Nuevo";
                btnGuardar.Text = "Guardar";
                rbActivo.Checked = true; // Dejamos "Activo" por defecto
            }
        }

        private void btnVerMarca_Click(object sender, EventArgs e)
        {
            frmBuscarMarca formBusqueda = new frmBuscarMarca();

            // Muestra el formulario y "pausa" el código aquí
            DialogResult resultado = formBusqueda.ShowDialog();

            //  Cuando el usuario selecciona una marca, el 'DialogResult' es 'OK'
            if (resultado == DialogResult.OK)
            {
                // Lee los datos públicos que el formulario de búsqueda expuso
                // ¡Y aquí pones el nombre en el TextBox!
                txtMarca.Text = formBusqueda.NombreMarcaSeleccionada;

                // Guarda el ID para cuando presiones "Guardar Producto"
                this.idMarcaSeleccionada = formBusqueda.IdMarcaSeleccionada;
            }
        }

        private void btnVerCategoria_Click(object sender, EventArgs e)
        {
            frmBuscarCategoria formBusqueda = new frmBuscarCategoria();

            // Muestra el formulario y "pausa" el código aquí
            DialogResult resultado = formBusqueda.ShowDialog();

            // Cuando el usuario selecciona una categoría, el 'DialogResult' es 'OK'
            if (resultado == DialogResult.OK)
            {
                //  Lee los datos públicos que el formulario de búsqueda expuso
                // ¡Y aquí pones el nombre en el TextBox!
                txtCategoria.Text = formBusqueda.NombreCategoriaSeleccionada;

                // Guarda el ID para cuando presiones "Guardar Producto"
                this.idCategoriaSeleccionada = formBusqueda.IdCategoriaSeleccionada;
            }
        }

        private async void button9_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreProducto.Text)|| string.IsNullOrWhiteSpace(txtGanancia.Text))
            {
                MessageBox.Show("El nombre del producto es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.idMarcaSeleccionada == 0 || this.idCategoriaSeleccionada == 0)
            {
                MessageBox.Show("Debe seleccionar una Marca y una Categoría usando los botones 'Ver'.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            btnGuardar.Enabled = false;

            try
            {
                // --- 👇 ¡AQUÍ ESTÁ LA LÓGICA DE DECISIÓN! ---
                if (_productoActual == null)
                {
                    // --- MODO AGREGAR (INSERT) ---
                    Producto nuevoProducto = new Producto
                    {
                        CodigoBarraProducto = txtCodBarra.Text.Trim(),
                        NombreProducto = txtNombreProducto.Text.Trim(),
                        PorcentajeGananciaProducto = decimal.Parse(txtGanancia.Text),
                        PrecioCompra = decimal.Parse(txtPrecioCompra.Text),
                        PrecioCosto = decimal.Parse(txtPrecioCosto.Text),
                        PrecioVenta = decimal.Parse(txtPrecioVenta.Text),
                        CantidadProducto = int.Parse(txtCantidad.Text),
                        EstadoProducto = rbActivo.Checked,
                        IdEstado = rbActivo.Checked ? 1 : 2,
                        IdMarca = this.idMarcaSeleccionada,
                        IdCategoria = this.idCategoriaSeleccionada,
                        IdPresentacion = 1,
                        IdTamanio = 1
                    };

                    await _productoRepo.InsertarProducto(nuevoProducto);
                    MessageBox.Show("¡Producto guardado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // --- MODO EDITAR (UPDATE) ---
                    // Llena el objeto EXISTENTE
                    _productoActual.CodigoBarraProducto = txtCodBarra.Text.Trim();
                    _productoActual.NombreProducto = txtNombreProducto.Text.Trim();
                    _productoActual.PorcentajeGananciaProducto = decimal.Parse(txtGanancia.Text);
                    _productoActual.PrecioCompra = decimal.Parse(txtPrecioCompra.Text);
                    _productoActual.PrecioCosto = decimal.Parse(txtPrecioCosto.Text);
                    _productoActual.PrecioVenta = decimal.Parse(txtPrecioVenta.Text);
                    _productoActual.CantidadProducto = int.Parse(txtCantidad.Text);
                    _productoActual.EstadoProducto = rbActivo.Checked;
                    _productoActual.IdEstado = rbActivo.Checked ? 1 : 2;
                    _productoActual.IdMarca = this.idMarcaSeleccionada;
                    _productoActual.IdCategoria = this.idCategoriaSeleccionada;
                    _productoActual.IdPresentacion = 1; 
                    _productoActual.IdTamanio = 1;

                    // Llama al método Actualizar del Repositorio
                    await ProductoRepositorio.ActualizarProducto(_productoActual);
                    MessageBox.Show("¡Producto actualizado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //Envía la señal de "Éxito" al formulario principal
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Error de formato. Asegúrese de que 'Precio', 'Ganancia' y 'Cantidad' sean números válidos.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el producto: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGuardar.Enabled = true;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        
    }
}
