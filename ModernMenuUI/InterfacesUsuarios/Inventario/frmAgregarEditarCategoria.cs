using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using System;
using System.Windows.Forms;

namespace ModernMenuUI.InterfacesUsuarios.Inventario
{
    public partial class frmAgregarEditarCategoria : Form
    {
        private Categoria _categoriaSeleccionada;

        /// <summary>
        /// Inicializa el formulario para agregar una nueva categoría.
        /// </summary>
        public frmAgregarEditarCategoria()
        {
            InitializeComponent();
            btnGuardarCategoria.Visible = true;
            btnModificarCategoria.Visible = false;
            lblNombreModulo.Text = "AGREGAR CATEGORÍA";
        }

        /// <summary>
        /// Inicializa el formulario para editar una categoría existente.
        /// </summary>
        /// <param name="categoriaParaEditar">Objeto categoría que será editado.</param>
        public frmAgregarEditarCategoria(Categoria categoriaParaEditar)
        {
            InitializeComponent();

            _categoriaSeleccionada = categoriaParaEditar;

            if (_categoriaSeleccionada != null)
            {
                txtNombreCategoria.Text = _categoriaSeleccionada.NombreCategoria ?? string.Empty;
                txtDescripcionCategoria.Text = _categoriaSeleccionada.DescripcionCategoria ?? string.Empty;

                if (_categoriaSeleccionada.EstadoCategoria)
                    rbActivo.Checked = true;
                else
                    rbInactivo.Checked = true;
            }

            btnGuardarCategoria.Visible = true;
            btnModificarCategoria.Visible = false;
            lblNombreModulo.Text = "EDITAR CATEGORÍA";
        }

        /// <summary>
        /// Valida los datos ingresados y guarda o actualiza la categoría.
        /// </summary>
        private async void btnGuardarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                Categoria categoriaTemp = new Categoria
                {
                    NombreCategoria = txtNombreCategoria.Text.Trim(),
                    DescripcionCategoria = txtDescripcionCategoria.Text.Trim(),
                    EstadoCategoria = rbActivo.Checked
                };

                var resultado = ServicioValidacionesIngresoDatos.EjecutarValidacionesCategoria(categoriaTemp);

                if (resultado.Error)
                {
                    MessageBox.Show(resultado.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!rbActivo.Checked && !rbInactivo.Checked)
                {
                    MessageBox.Show("Debe seleccionar un estado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                btnGuardarCategoria.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                if (_categoriaSeleccionada == null)
                {
                    categoriaTemp.IdEstado = rbInactivo.Checked ? 2 : 1;
                    await CategoriaRepositorio.InsertarCategoria(categoriaTemp);

                    MessageBox.Show("Categoría guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    categoriaTemp.IdCategoria = _categoriaSeleccionada.IdCategoria;
                    categoriaTemp.IdEstado = rbInactivo.Checked ? 2 : 1;
                    categoriaTemp.EstadoCategoria = rbActivo.Checked;

                    await CategoriaRepositorio.ActualizarCategoria(categoriaTemp);

                    MessageBox.Show("Categoría actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar o actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!IsDisposed)
                {
                    btnGuardarCategoria.Enabled = true;
                    this.Cursor = Cursors.Default;
                }
            }
        }

        /// <summary>
        /// Cierra el formulario sin realizar cambios.
        /// </summary>
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Habilita el botón de guardar cuando se desea modificar una categoría.
        /// </summary>
        private void btnModificarCategoria_Click(object sender, EventArgs e)
        {
            btnGuardarCategoria.Visible = true;
            btnModificarCategoria.Visible = false;
        }
    }
}