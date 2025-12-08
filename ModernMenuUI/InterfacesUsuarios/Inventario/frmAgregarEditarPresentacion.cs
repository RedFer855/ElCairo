using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using DocumentFormat.OpenXml.Wordprocessing;
using iText.StyledXmlParser.Jsoup.Helper;
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
    /// Las presentaciones definen el formato de empaque (ej: "Caja de 12", "Paquete de 6", "Individual").
    /// Soporta dos modos: Creación (nueva presentación) y Edición (modificar presentación existente).
    /// </summary>
    public partial class frmAgregarEditarPresentacion : Form
    {
        #region Campos Privados

        /// <summary>
        /// Presentación que se está editando.
        /// Si es null, el formulario está en modo "Agregar nueva presentación".
        /// Si tiene valor, el formulario está en modo "Editar presentación existente".
        /// </summary>
        private Presentacion _presentacionSeleccionada;

        #endregion

        #region Constructores

        /// <summary>
        /// Inicializa el formulario en modo "Agregar nueva presentación".
        /// El botón "Guardar" está visible y el título indica la acción de agregar.
        /// </summary>
        public frmAgregarEditarPresentacion()
        {
            InitializeComponent();

            // Configurar interfaz para modo agregar
            btnGuardarPresentacion.Visible = true;
            lblNombreModulo.Text = "AGREGAR PRESENTACIÓN";
        }

        /// <summary>
        /// Inicializa el formulario en modo "Editar presentación existente".
        /// Los campos se cargan con los datos de la presentación seleccionada.
        /// </summary>
        /// <param name="presentacionParaEditar">Presentación a editar con sus datos actuales</param>
        public frmAgregarEditarPresentacion(Presentacion presentacionParaEditar)
        {
            InitializeComponent();

            // Guardar referencia de la presentación a editar
            _presentacionSeleccionada = presentacionParaEditar;

            // Cargar datos en los controles del formulario
            txtNombrePresentacion.Text = _presentacionSeleccionada.NombrePresentacion;
            txtDescripcionPresentacion.Text = _presentacionSeleccionada.DetallePresentacion;

            // Configurar RadioButtons según el estado actual de la presentación
            if (_presentacionSeleccionada.EstadoPresentacion)
                rbActivo.Checked = true;   // Presentación habilitada
            else
                rbInactivo.Checked = true; // Presentación deshabilitada

            // Cambiar título para indicar modo edición
            lblNombreModulo.Text = "EDITAR PRESENTACIÓN";
        }

        #endregion

        #region Eventos de Botones

        /// <summary>
        /// Maneja el clic del botón "Guardar Presentación".
        /// Valida los datos ingresados y ejecuta INSERT (modo agregar) o UPDATE (modo editar).
        /// Incluye validaciones de campos requeridos, longitud y estado seleccionado.
        /// </summary>
        /// <param name="sender">Botón guardar presentación (btnGuardarPresentacion)</param>
        /// <param name="e">Argumentos del evento</param>
        private async void btnGuardarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Crear objeto temporal con los datos del formulario
                Presentacion presentacionTemp = new Presentacion
                {
                    NombrePresentacion = txtNombrePresentacion.Text.Trim(),
                    DetallePresentacion = txtDescripcionPresentacion.Text.Trim(),
                    EstadoPresentacion = rbActivo.Checked
                };

                // 2. Ejecutar validaciones de negocio (campos requeridos, longitud, formato)
                var resultado = ServicioValidacionesIngresoDatos
                                .EjecutarValidacionesPresentacion(presentacionTemp);

                if (resultado.Error)
                {
                    MessageBox.Show(resultado.Mensaje,
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 3. Validar que se haya seleccionado un estado (Activo/Inactivo)
                if (!rbActivo.Checked && !rbInactivo.Checked)
                {
                    MessageBox.Show("Debe seleccionar un estado.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 4. Deshabilitar botón y mostrar cursor de espera durante el proceso
                btnGuardarPresentacion.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                // 5. Crear instancia del repositorio
                PresentacionRepositorio repo = new PresentacionRepositorio();

                // 6. Determinar si es INSERT o UPDATE según si existe presentación seleccionada
                if (_presentacionSeleccionada == null)
                {
                    // === MODO AGREGAR: Insertar nueva presentación ===

                    // Asignar estado basado en RadioButton seleccionado
                    presentacionTemp.EstadoPresentacion = rbActivo.Checked;

                    // Ejecutar inserción en base de datos
                    await repo.InsertarPresentacion(presentacionTemp);

                    MessageBox.Show("Presentación guardada correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // === MODO EDITAR: Actualizar presentación existente ===

                    // Asignar ID de la presentación que se está editando
                    presentacionTemp.IdPresentacionProducto =
                        _presentacionSeleccionada.IdPresentacionProducto;

                    // Actualizar estado basado en RadioButton seleccionado
                    presentacionTemp.EstadoPresentacion = rbActivo.Checked;

                    // Ejecutar actualización en base de datos
                    await repo.ActualizarPresentacion(presentacionTemp);

                    MessageBox.Show("Presentación actualizada correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // 7. Establecer DialogResult para notificar al formulario padre que hubo cambios
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // Capturar cualquier error durante el proceso de guardado
                MessageBox.Show("Error al guardar/actualizar: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Rehabilitar botón y restaurar cursor siempre
                btnGuardarPresentacion.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Maneja el clic del botón "Modificar Presentación".
        /// Habilita la edición de campos mostrando el botón "Guardar" y ocultando "Modificar".
        /// Nota: Actualmente los campos no están bloqueados en el constructor de edición,
        /// por lo que este botón solo cambia la visibilidad de botones.
        /// </summary>
        /// <param name="sender">Botón modificar presentación (btnModificarPresentacion)</param>
        /// <param name="e">Argumentos del evento</param>
        private void btnModificarPresentacion_Click(object sender, EventArgs e)
        {
            // Mostrar botón Guardar para confirmar cambios
            btnGuardarPresentacion.Visible = true;

            // Ocultar botón Modificar (ya no es necesario)
            btnModificarPresentacion.Visible = false;
        }

        #endregion
    }
}