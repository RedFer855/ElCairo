using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.InterfacesUsuarios.Compras;
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
    /// Formulario para agregar o editar marcas asociadas a proveedores.
    /// Este módulo permite:
    ///  - Registrar nuevas marcas.
    ///  - Editar marcas existentes.
    ///  - Seleccionar proveedor desde un formulario modal.
    ///  - Validar datos antes de insertarlos o actualizarlos en la base de datos.
    /// </summary>
    public partial class frmAgregarEditarMarca : Form
    {
        /// <summary>
        /// Almacena el ID del proveedor seleccionado desde el formulario de proveedores.
        /// </summary>
        private int _idProveedorSeleccionado;

        /// <summary>
        /// Marca seleccionada en modo edición. Si es null, el formulario está en modo agregar.
        /// </summary>
        private Marca _marcaSeleccionada;

        /// <summary>
        /// Constructor principal utilizado para agregar nuevas marcas.
        /// Configura visibilidad de botones y rotula el módulo.
        /// </summary>
        public frmAgregarEditarMarca()
        {
            InitializeComponent();
            btnGuardarMarca.Visible = true;
            lblNombreModulo.Text = "AGREGAR MARCA";
        }

        /// <summary>
        /// Constructor alternativo utilizado cuando se desea editar una marca existente.
        /// Carga automáticamente los datos de la marca recibida.
        /// </summary>
        /// <param name="_marcaParaEditar">Objeto marca que contiene los datos a modificar.</param>
        public frmAgregarEditarMarca(Marca _marcaParaEditar)
        {
            InitializeComponent();

            // Asignar objeto local
            _marcaSeleccionada = _marcaParaEditar;

            // Cargar datos del formulario
            txtNombreMarca.Text = _marcaSeleccionada.NombreMarca;
            txtProveedor.Text = _marcaSeleccionada.NombreProveedor;
            _idProveedorSeleccionado = _marcaSeleccionada.IdProveedor;

            // Cargar estado
            if (_marcaSeleccionada.EstadoMarca)
                rbActivo.Checked = true;
            else
                rbInactivo.Checked = true;
        }

        private void panel2_Paint(object sender, PaintEventArgs e) { }

        /// <summary>
        /// Cierra el formulario sin guardar cambios.
        /// </summary>
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Abre el formulario de proveedores en modo selección.
        /// Permite escoger un proveedor y traer sus datos de vuelta.
        /// </summary>
        private void btnBuscarProv_Click(object sender, EventArgs e)
        {
            using (var formSeleccion = new frmProveedor())
            {
                if (formSeleccion.ShowDialog() == DialogResult.OK)
                {
                    if (formSeleccion.ProveedorSeleccionado != null)
                    {
                        txtProveedor.Text = formSeleccion.ProveedorSeleccionado.NombreProveedor;
                        _idProveedorSeleccionado = formSeleccion.ProveedorSeleccionado.IdProveedor;
                    }
                }
            }
        }

        /// <summary>
        /// Maneja tanto la creación como la actualización de una marca.
        /// Aplica validaciones y llama a los repositorios según corresponda.
        /// </summary>
        private async void btnGuardarMarca_Click(object sender, EventArgs e)
        {
            try
            {
                // VALIDAR QUE HAYA PROVEEDOR SELECCIONADO
                if (_idProveedorSeleccionado <= 0)
                {
                    MessageBox.Show("Debe seleccionar un proveedor.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear objeto intermedio para validaciones e inserción
                MarcaInsertar _marcaTemporal = new MarcaInsertar
                {
                    NombreMarca = txtNombreMarca.Text.Trim(),
                    IdProveedor = _idProveedorSeleccionado
                };

                // Ejecutar validaciones personalizadas
                var resultado = ServicioValidacionesIngresoDatos.EjecutarValidacionesMarca(_marcaTemporal);
                if (resultado.Error)
                {
                    MessageBox.Show(resultado.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                btnGuardarMarca.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                // --- INSERTAR O ACTUALIZAR SEGÚN EL CONTEXTO ---
                if (_marcaSeleccionada == null)
                {
                    // ----------------------- MODO INSERTAR -----------------------
                    _marcaTemporal.EstadoMarca = rbActivo.Checked;
                    _marcaTemporal.IdEstado = rbInactivo.Checked ? 2 : 1;

                    await MarcaRepositorio.InsertarMarca(_marcaTemporal);

                    MessageBox.Show("Marca guardada correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // ----------------------- MODO ACTUALIZAR -----------------------
                    _marcaTemporal.IdMarca = _marcaSeleccionada.IdMarca; // ID original a actualizar
                    _marcaTemporal.EstadoMarca = rbActivo.Checked;
                    _marcaTemporal.IdEstado = rbInactivo.Checked ? 2 : 1;

                    await MarcaRepositorio.ActualizarMarca(_marcaTemporal);

                    MessageBox.Show("Marca actualizada correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                btnGuardarMarca.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Permite pasar de modo lectura a edición manualmente.
        /// </summary>
        private void btnModificarMarca_Click(object sender, EventArgs e)
        {
            btnGuardarMarca.Visible = true;
            btnModificarMarca.Visible = false;
        }
    }
}
