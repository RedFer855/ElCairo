using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using Serilog;
using System;
using System.Windows.Forms;

namespace ModernMenuUI.InterfacesUsuarios.Inventario
{
    public partial class frmAgregarEditarCategoria : Form
    {
        private Categoria _categoriaSeleccionada;
        private static readonly Serilog.ILogger _log = new Serilog.LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/Categoria.txt", rollingInterval: Serilog.RollingInterval.Day)
    .CreateLogger();

        /// <summary>
        /// Inicializa el formulario para agregar una nueva categoría.
        /// </summary>
        public frmAgregarEditarCategoria()
        {
            InitializeComponent();
            btnGuardarCategoria.Visible = true;
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

            txtNombreCategoria.Text = _categoriaSeleccionada.NombreCategoria;
            txtDescripcionCategoria.Text = _categoriaSeleccionada.DescripcionCategoria;

            if (_categoriaSeleccionada.EstadoCategoria)
                rbActivo.Checked = true;
            else
                rbInactivo.Checked = true;

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
                    _log.Warning("Validación de categoría fallida: {Mensaje}", resultado.Mensaje);
                    MessageBox.Show(resultado.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!rbActivo.Checked && !rbInactivo.Checked)
                {
                    _log.Warning("Intento de guardar categoría sin estado seleccionado: {Nombre}", categoriaTemp.NombreCategoria);
                    MessageBox.Show("Debe seleccionar un estado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                btnGuardarCategoria.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                if (_categoriaSeleccionada == null)
                {
                    categoriaTemp.IdEstado = rbInactivo.Checked ? 2 : 1;

                    _log.Information("Insertando nueva categoría: {Nombre}", categoriaTemp.NombreCategoria);
                    await CategoriaRepositorio.InsertarCategoria(categoriaTemp);
                    _log.Information("Categoría guardada correctamente: {Nombre}", categoriaTemp.NombreCategoria);

                    MessageBox.Show("Categoría guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    categoriaTemp.IdCategoria = _categoriaSeleccionada.IdCategoria;
                    categoriaTemp.IdEstado = rbInactivo.Checked ? 2 : 1;
                    categoriaTemp.EstadoCategoria = rbActivo.Checked;

                    _log.Information("Actualizando categoría ID {Id}: {Nombre}", categoriaTemp.IdCategoria, categoriaTemp.NombreCategoria);
                    await CategoriaRepositorio.ActualizarCategoria(categoriaTemp);
                    _log.Information("Categoría actualizada correctamente: {Nombre}", categoriaTemp.NombreCategoria);

                    MessageBox.Show("Categoría actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                _log.Error(ex, "Error inesperado al guardar/actualizar categoría: {Nombre}", txtNombreCategoria.Text);
                MessageBox.Show("Error al guardar o actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGuardarCategoria.Enabled = true;
                this.Cursor = Cursors.Default;
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
