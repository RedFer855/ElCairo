using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI.InterfacesUsuarios.Inventario
{
    public partial class frmAgregarEditarCategoria : Form
    {
        public frmAgregarEditarCategoria(Categoria _categoriaSeleccionada)
        {
            InitializeComponent();
        }

        public frmAgregarEditarCategoria()
        {
            InitializeComponent();
            btnGuardarCategoria.Visible = true;
            lblNombreModulo.Text = "AGREGAR CATEGORÍA";
        }
        public frmAgregarEditarCategoria(Categoria categoriaParaEditar)
        {
            InitializeComponent();

            _categoriaSeleccionada = categoriaParaEditar;

            // Cargar campos
            txtNombreCategoria.Text = _categoriaSeleccionada.NombreCategoria;
            txtDescripcionCategoria.Text = _categoriaSeleccionada.DescripcionCategoria;

            // Estado
            if (_categoriaSeleccionada.EstadoCategoria)
                rbdActivo.Checked = true;
            else
                rbdInactivo.Checked = true;

            lblNombreModulo.Text = "EDITAR CATEGORÍA";
        }

        private async void btnGuardarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                Categoria categoriaTemp = new Categoria
                {
                    NombreCategoria = txtNombreCategoria.Text.Trim(),
                    DescripcionCategoria = txtDescripcionCategoria.Text.Trim(),
                    EstadoCategoria = rbdActivo.Checked
                };

                var resultado = ServicioValidacionesIngresoDatos.EjecutarValidacionesCategoria(categoriaTemp);
                
                if (resultado.Error)
                {
                    MessageBox.Show(resultado.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!rbdActivo.Checked && !rbdInactivo.Checked)
                {
                    MessageBox.Show("Debe seleccionar un estado.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                btnGuardarCategoria.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                if (_categoriaSeleccionada == null)
                {
                    categoriaTemp.IdEstado = rbdInactivo.Checked ? 2 : 1;

                    await CategoriaRepositorio.InsertarCategoria(categoriaTemp);

                    MessageBox.Show("Categoría guardada correctamente.",
                                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
             
                    categoriaTemp.IdCategoria = _categoriaSeleccionada.IdCategoria;

                    categoriaTemp.IdEstado = rbdInactivo.Checked ? 2 : 1;
                    categoriaTemp.EstadoCategoria = rbdActivo.Checked;

                    await CategoriaRepositorio.ActualizarCategoria(categoriaTemp);

                    MessageBox.Show("Categoría actualizada correctamente.",
                                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar/actualizar: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGuardarCategoria.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        private void frmAgregarEditarCategoria_Load(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificarCategoria_Click(object sender, EventArgs e)
        {
            btnGuardarCategoria.Visible = true;
            btnModificarCategoria.Visible = false;
        }
    }
}
