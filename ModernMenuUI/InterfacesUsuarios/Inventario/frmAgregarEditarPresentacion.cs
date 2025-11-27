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
    public partial class frmAgregarEditarPresentacion : Form
    {
        private Presentacion _presentacionSeleccionada;

        public frmAgregarEditarPresentacion()
        {
            InitializeComponent();

            btnGuardarPresentacion.Visible = true;
            lblNombreModulo.Text = "AGREGAR PRESENTACIÓN";
        }
        public frmAgregarEditarPresentacion(Presentacion presentacionParaEditar)
        {
            InitializeComponent();

            _presentacionSeleccionada = presentacionParaEditar;

            // Cargar campos en el formulario
            txtNombrePresentacion.Text = _presentacionSeleccionada.NombrePresentacion;
            txtDescripcionPresentacion.Text = _presentacionSeleccionada.DetallePresentacion;

            // Estado
            if (_presentacionSeleccionada.EstadoPresentacion)
                rbActivo.Checked = true;
            else
                rbInactivo.Checked = true;

            lblNombreModulo.Text = "EDITAR PRESENTACIÓN";
        }

        private async void btnGuardarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                Presentacion presentacionTemp = new Presentacion
                {
                    NombrePresentacion = txtNombrePresentacion.Text.Trim(),
                    DetallePresentacion = txtDescripcionPresentacion.Text.Trim(),
                    EstadoPresentacion = rbActivo.Checked
                };
                var resultado = ServicioValidacionesIngresoDatos
                                .EjecutarValidacionesPresentacion(presentacionTemp);

                if (resultado.Error)
                {
                    MessageBox.Show(resultado.Mensaje,
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!rbActivo.Checked && !rbInactivo.Checked)
                {
                    MessageBox.Show("Debe seleccionar un estado.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                btnGuardarPresentacion.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                PresentacionRepositorio repo = new PresentacionRepositorio();

                if (_presentacionSeleccionada == null)
                {
                    // === INSERTAR ===
                    presentacionTemp.EstadoPresentacion = rbActivo.Checked;

                    await repo.InsertarPresentacion(presentacionTemp);

                    MessageBox.Show("Presentación guardada correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // === ACTUALIZAR ===

                    presentacionTemp.IdPresentacionProducto =
                        _presentacionSeleccionada.IdPresentacionProducto;

                    presentacionTemp.EstadoPresentacion = rbActivo.Checked;

                    await repo.ActualizarPresentacion(presentacionTemp);

                    MessageBox.Show("Presentación actualizada correctamente.",
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
                btnGuardarPresentacion.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        private void btnModificarPresentacion_Click(object sender, EventArgs e)
        {
            btnGuardarPresentacion.Visible = true;
            btnModificarPresentacion.Visible = false;
        }
    }
}