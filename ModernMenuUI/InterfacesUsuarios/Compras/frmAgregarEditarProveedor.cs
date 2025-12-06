using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ModernMenuUI.InterfacesUsuarios.Compras
{
    public partial class frmAgregarEditarProveedor : Form
    {
        private Proveedor _proveedorActual;

        public frmAgregarEditarProveedor()
        {
            InitializeComponent();
            btnGuardarProveedor.Enabled = true;
            btnEditarProveedor.Enabled = false;
        }

        public frmAgregarEditarProveedor(Proveedor proveedor)
        {
            _proveedorActual = proveedor;

            InitializeComponent();
            btnEditarProveedor.Enabled = true;
            btnGuardarProveedor.Enabled = false;
        }


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


        private void BloqueoMensaje_Click(object sender, EventArgs e)
        {
            if (txtNombreProveedor.ReadOnly)
            {
                MessageBox.Show("Presione el botón EDITAR para modificar el proveedor.",
                    "Edición bloqueada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmAgregarEditarProveedor_Load(object sender, EventArgs e)
        {
            if (_proveedorActual != null)
            {
                // Modo EDITAR
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
                // Modo NUEVO
                clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "GUARDAR PROVEEDOR");

                btnEditarProveedor.Visible = false;
                btnGuardarProveedor.Visible = true;

                SetReadOnlyMode(false);
            }
        }

        private void btnEditarProveedor_Click(object sender, EventArgs e)
        {
            SetReadOnlyMode(false);

            btnGuardarProveedor.Visible = true;
            btnGuardarProveedor.Enabled = true;

            btnEditarProveedor.Visible = false;

            MessageBox.Show("Ahora puede editar los datos del proveedor.",
                "Modo edición activado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnGuardarProveedor_Click(object sender, EventArgs e)
        {
            btnGuardarProveedor.Enabled = false;
            this.Cursor = Cursors.WaitCursor;

            try
            {
                // Crear proveedor temporal
                Proveedor proveedorTemp = new Proveedor
                {
                    NombreProveedor = txtNombreProveedor.Text.Trim(),
                    TelefonoProveedor = txtTelefono.Text.Trim(),
                    DireccionProveedor = txtDireccion.Text.Trim(),
                    IdEstadoProveedor = rbActivo.Checked ? 1 : 2,
                    EstadoProveedor = rbActivo.Checked
                };

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
