using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
using Sprache;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ModernMenuUI.InterfacesUsuarios.Compras
{
    /// <summary>
    /// Formulario para agregar o editar un proveedor.
    /// Soporta modo creación y modo edición; realiza validaciones y persiste cambios mediante <see cref="ProveedorRepositorio"/>.
    /// </summary>
    public partial class frmAgregarEditarProveedor : Form
    {
        /// <summary>
        /// Instancia del proveedor que se está editando. Si es null, el formulario está en modo creación.
        /// </summary>
        private Proveedor _proveedorActual;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="frmAgregarEditarProveedor"/> en modo creación.
        /// </summary>
        public frmAgregarEditarProveedor()
        {
            InitializeComponent();
            btnGuardarProveedor.Enabled = true;
            btnEditarProveedor.Enabled = false;
        }

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="frmAgregarEditarProveedor"/> en modo edición con el proveedor proporcionado.
        /// </summary>
        /// <param name="proveedor">Proveedor a editar.</param>
        public frmAgregarEditarProveedor(Proveedor proveedor)
        {
            _proveedorActual = proveedor;

            InitializeComponent();
            btnEditarProveedor.Enabled = true;
            btnGuardarProveedor.Enabled = false;
        }

        /// <summary>
        /// Establece los campos de texto como sólo lectura o editables, y ajusta su color de fondo.
        /// </summary>
        /// <param name="estado">True para poner los campos como sólo lectura; false para permitir edición.</param>
        private void SetReadOnlyMode(bool estado)
        {
            txtNombreProveedor.ReadOnly = estado;
            txtTelefono.ReadOnly = estado;
            txtDireccion.ReadOnly = estado;

            Color back = estado ? Color.LightGray : Color.White;

            txtNombreProveedor.BackColor = back;
            txtTelefono.BackColor = back;
            txtDireccion.BackColor = back;
        }

        /// <summary>
        /// Muestra un mensaje informativo cuando el usuario intenta editar campos bloqueados.
        /// </summary>
        private void BloqueoMensaje_Click(object sender, EventArgs e)
        {
            if (txtNombreProveedor.ReadOnly)
            {
                MessageBox.Show("Presione el botón EDITAR para modificar el proveedor.",
                    "Edición bloqueada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Maneja la inicialización del formulario al cargarse. Configura la interfaz según el modo (nuevo/editar).
        /// </summary>
        private void frmAgregarEditarProveedor_Load(object sender, EventArgs e)
        {
            if (_proveedorActual != null)
            {
                clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "EDITAR PROVEEDOR");

                txtNombreProveedor.Text = _proveedorActual.NombreProveedor;
                txtTelefono.Text = _proveedorActual.TelefonoProveedor;
                txtDireccion.Text = _proveedorActual.DireccionProveedor;

                rbActivo.Checked = _proveedorActual.EstadoProveedor;
                rbInactivo.Checked = !_proveedorActual.EstadoProveedor;

                btnGuardarProveedor.Visible = false;
                btnEditarProveedor.Visible = true;

                // Bloquear campos al inicio
                SetReadOnlyMode(true);

                txtNombreProveedor.Click += BloqueoMensaje_Click;
                txtTelefono.Click += BloqueoMensaje_Click;
                txtDireccion.Click += BloqueoMensaje_Click;
            }
            else
            {
                clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "GUARDAR PROVEEDOR");

                btnEditarProveedor.Visible = false;
                btnGuardarProveedor.Visible = true;

                SetReadOnlyMode(false);
            }
        }

        /// <summary>
        /// Activa la edición de los campos permitiendo guardar los cambios.
        /// </summary>
        private void btnEditarProveedor_Click(object sender, EventArgs e)
        {
            SetReadOnlyMode(false);

            btnGuardarProveedor.Visible = true;
            btnGuardarProveedor.Enabled = true;

            btnEditarProveedor.Visible = false;

            MessageBox.Show("Ahora puede editar los datos del proveedor.",
                "Modo edición activado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Valida y guarda o actualiza el proveedor actual en la base de datos de forma asíncrona.
        /// </summary>
        private async void btnGuardarProveedor_Click(object sender, EventArgs e)
        {
            btnGuardarProveedor.Enabled = false;
            this.Cursor = Cursors.WaitCursor;

            try
            {
                Proveedor proveedorTemp = new Proveedor
                {
                    NombreProveedor = txtNombreProveedor.Text.Trim(),
                    TelefonoProveedor = txtTelefono.Text.Trim(),
                    DireccionProveedor = txtDireccion.Text.Trim(),
                    IdEstadoProveedor = rbActivo.Checked ? 1 : 2,
                    EstadoProveedor = rbActivo.Checked
                };
/*
                if (txtDireccion.Text.Length>300)
                {
                    MessageBox.Show("La dirección no puede superar los 300 caracteres.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
*/
                // VALIDAR proveedor (igual que validas Marca)
                var resultado = ServicioValidacionesIngresoDatos.EjecutarValidacionesProveedor(proveedorTemp);

                if (resultado.Error)
                {
                    MessageBox.Show(resultado.Mensaje, "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ProveedorRepositorio _repoProv = new ProveedorRepositorio();

                if (_proveedorActual == null)
                {
                    await _repoProv.InsertarProveedor(proveedorTemp);

                    MessageBox.Show("Proveedor guardado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    proveedorTemp.IdProveedor = _proveedorActual.IdProveedor;

                    await _repoProv.ActualizarProveedor(proveedorTemp);

                    MessageBox.Show("Proveedor actualizado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el proveedor: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGuardarProveedor.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

    }
}
