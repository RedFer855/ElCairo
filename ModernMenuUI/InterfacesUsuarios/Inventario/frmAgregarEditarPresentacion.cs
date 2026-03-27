using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using Serilog;
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
    /// <summary>
    /// Formulario para agregar o editar presentaciones de productos.
    /// Permite:
    ///  - Registrar nuevas presentaciones.
    ///  - Editar presentaciones existentes.
    ///  - Validar datos antes de guardar.
    ///  - Gestionar estados (Activo / Inactivo).
    /// </summary>
    public partial class frmAgregarEditarPresentacion : Form
    {
        /// <summary>
        /// Presentación seleccionada para edición.
        /// Si es null, el formulario funciona en modo "agregar".
        /// </summary>
        private Presentacion _presentacionSeleccionada;

        private static readonly Serilog.ILogger _log = new Serilog.LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/Presentacion.txt", rollingInterval: Serilog.RollingInterval.Day)
    .CreateLogger();

        /// <summary>
        /// Constructor por defecto para agregar una nueva presentación.
        /// Configura el formulario en modo "insertar".
        /// </summary>
        public frmAgregarEditarPresentacion()
        {
            InitializeComponent();

            btnGuardarPresentacion.Visible = true;
            lblNombreModulo.Text = "AGREGAR PRESENTACIÓN";
        }

        /// <summary>
        /// Constructor utilizado para editar una presentación existente.
        /// Carga automáticamente los datos en los controles del formulario.
        /// </summary>
        /// <param name="presentacionParaEditar">Objeto Presentación que contiene la información a editar.</param>
        public frmAgregarEditarPresentacion(Presentacion presentacionParaEditar)
        {
            InitializeComponent();

            _presentacionSeleccionada = presentacionParaEditar;

            // Cargar campos
            txtNombrePresentacion.Text = _presentacionSeleccionada.NombrePresentacion;
            txtDescripcionPresentacion.Text = _presentacionSeleccionada.DetallePresentacion;

            // Estado
            if (_presentacionSeleccionada.EstadoPresentacion)
                rbActivo.Checked = true;
            else
                rbInactivo.Checked = true;

            lblNombreModulo.Text = "EDITAR PRESENTACIÓN";
        }

        /// <summary>
        /// Evento que maneja la acción de guardar o actualizar la presentación.
        /// Determina automáticamente si debe insertar o actualizar según el contexto.
        /// </summary>
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

                var resultado = ServicioValidacionesIngresoDatos.EjecutarValidacionesPresentacion(presentacionTemp);
                if (resultado.Error)
                {
                    _log.Warning("Validación de presentación fallida: {Mensaje}", resultado.Mensaje);
                    MessageBox.Show(resultado.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!rbActivo.Checked && !rbInactivo.Checked)
                {
                    _log.Warning("Intento de guardar presentación sin estado seleccionado: {Nombre}", presentacionTemp.NombrePresentacion);
                    MessageBox.Show("Debe seleccionar un estado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                btnGuardarPresentacion.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                PresentacionRepositorio repo = new PresentacionRepositorio();

                if (_presentacionSeleccionada == null)
                {
                    _log.Information("Insertando nueva presentación: {Nombre}", presentacionTemp.NombrePresentacion);
                    await repo.InsertarPresentacion(presentacionTemp);
                    _log.Information("Presentación guardada correctamente: {Nombre}", presentacionTemp.NombrePresentacion);

                    MessageBox.Show("Presentación guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    presentacionTemp.IdPresentacionProducto = _presentacionSeleccionada.IdPresentacionProducto;

                    _log.Information("Actualizando presentación ID {Id}: {Nombre}", presentacionTemp.IdPresentacionProducto, presentacionTemp.NombrePresentacion);
                    await repo.ActualizarPresentacion(presentacionTemp);
                    _log.Information("Presentación actualizada correctamente: {Nombre}", presentacionTemp.NombrePresentacion);

                    MessageBox.Show("Presentación actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                _log.Error(ex, "Error inesperado al guardar/actualizar presentación: {Nombre}", txtNombrePresentacion.Text);
                MessageBox.Show("Error al guardar/actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGuardarPresentacion.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Activa el modo edición si está deshabilitado.
        /// Permite modificar los campos llenados automáticamente.
        /// </summary>
        private void btnModificarPresentacion_Click(object sender, EventArgs e)
        {
            btnGuardarPresentacion.Visible = true;
            btnModificarPresentacion.Visible = false;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
