using CapaDeDatos.Modelados.Ventas;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
using System;
using System.Windows.Forms;

namespace ModernMenuUI.InterfacesUsuarios.Ventas
{
    public partial class frmAgregarEditarClientes : Form
    {
        private Cliente _clienteActual;
        public frmAgregarEditarClientes(bool habilitarCorreo = false)
        {
            InitializeComponent();
            _clienteActual = null;

            // Si venimos desde "Agregar Cliente", habilitar correo
            if (habilitarCorreo)
                txtCorreo.ReadOnly = false;
        }
        public frmAgregarEditarClientes(Cliente cliente)
        {
            InitializeComponent();
            _clienteActual = cliente;

            txtDni.Click += TextBox_ReadOnlyClick;
            txtRtn.Click += TextBox_ReadOnlyClick;
            txtNombre.Click += TextBox_ReadOnlyClick;
            txtTelefono.Click += TextBox_ReadOnlyClick;
            txtCorreo.Click += TextBox_ReadOnlyClick;
            txtDireccion.Click += TextBox_ReadOnlyClick;

            btnVolver.Focus();
        }

        private async void btnGuardarCliente_Click(object sender, EventArgs e)
        {
            btnGuardarCliente.Enabled = false;
            if (txtCorreo.Text ==""||txtDireccion.Text==""||txtDni.Text==""||txtNombre.Text==""||txtRtn.Text=="")
            {
                MessageBox.Show("Ingrese el valor faltante para poder ingresar el cliete");
            } else {
                try
                {
                    // --- Validaciones ---
                    /*var v1 = ServicioValidacionesIngresoDatos.ValidarCampoVacio(txtNombre.Text, "el nombre");
                    if (v1.Error) { MessageBox.Show(v1.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); btnGuardarCliente.Enabled = true; return; }

                    var v2 = ServicioValidacionesIngresoDatos.ValidarCampoVacio(txtDni.Text, "el DNI");
                    if (v2.Error) { MessageBox.Show(v2.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); btnGuardarCliente.Enabled = true; return; }

                    var v3 = ServicioValidacionesIngresoDatos.ValidarEnteroValido(txtDni.Text, "DNI");
                    if (v3.Error) { MessageBox.Show(v3.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); btnGuardarCliente.Enabled = true; return; }

                    if (!string.IsNullOrWhiteSpace(txtTelefono.Text))
                    {
                        var v4 = ServicioValidacionesIngresoDatos.ValidarEnteroValido(txtTelefono.Text, "Teléfono");
                        if (v4.Error) { MessageBox.Show(v4.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); btnGuardarCliente.Enabled = true; return; }
                    }*/

                    if (_clienteActual == null)
                    {
                        // === AGREGAR ===
                        Cliente nuevoCliente = new Cliente
                        {
                            NombreCliente = txtNombre.Text.Trim(),
                            DniCliente = txtDni.Text.Trim(),
                            RtnCliente = txtRtn.Text.Trim(),
                            TelefonoCliente = txtTelefono.Text.Trim(),
                            CorreoCliente = txtCorreo.Text.Trim(),
                            DireccionCliente = txtDireccion.Text.Trim(),
                            EstadoCliente = rbdActivo.Checked
                        };

                        await ClienteRepositorio.InsertarCliente(nuevoCliente);

                        MessageBox.Show("¡Cliente guardado exitosamente!", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                    else
                    {
                        // === EDITAR ===
                        _clienteActual.NombreCliente = txtNombre.Text.Trim();
                        _clienteActual.DniCliente = txtDni.Text.Trim();
                        _clienteActual.RtnCliente = txtRtn.Text.Trim();
                        _clienteActual.TelefonoCliente = txtTelefono.Text.Trim();
                        _clienteActual.CorreoCliente = txtCorreo.Text.Trim();
                        _clienteActual.DireccionCliente = txtDireccion.Text.Trim();
                        _clienteActual.EstadoCliente = rbdActivo.Checked;

                        await ClienteRepositorio.ActualizarCliente(_clienteActual);

                        MessageBox.Show("¡Cliente actualizado exitosamente!", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar el cliente: {ex.Message}",
                        "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (!this.IsDisposed)
                        btnGuardarCliente.Enabled = true;
                }
            }
        }

        private void frmAgregarEditarClientes_Load(object sender, EventArgs e)
        {
            if (_clienteActual != null)
            {
                clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "EDITAR CLIENTE");

                txtDni.Text = _clienteActual.DniCliente;
                txtRtn.Text = _clienteActual.RtnCliente;
                txtNombre.Text = _clienteActual.NombreCliente;
                txtTelefono.Text = _clienteActual.TelefonoCliente;
                txtCorreo.Text = _clienteActual.CorreoCliente;
                txtDireccion.Text = _clienteActual.DireccionCliente;

                rbdActivo.Checked = _clienteActual.EstadoCliente;
                rbdInactivo.Checked = !_clienteActual.EstadoCliente;

                // DESHABILITAR
                txtDni.ReadOnly = true;
                txtRtn.ReadOnly = true;
                txtNombre.ReadOnly = true;
                txtTelefono.ReadOnly = true;
                txtCorreo.ReadOnly = true;
                txtDireccion.ReadOnly = true;

                btnGuardarCliente.Visible = false;
                btnModificar.Visible = true;
                btnModificar.Enabled = true;
            }
            else
            {
                clsAnmaciones.CambiarNombreMenu(lblNombreModulo, "AGREGAR CLIENTE NUEVO");

                btnGuardarCliente.Visible = true;
                btnModificar.Visible = false;
            }
        }
        private void TextBox_ReadOnlyClick(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null && tb.ReadOnly)
            {
                MessageBox.Show("Presione primero el botón Modificar.",
                    "Campo deshabilitado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            txtDni.ReadOnly = false;
            txtRtn.ReadOnly = false;
            txtNombre.ReadOnly = false;
            txtTelefono.ReadOnly = false;
            txtCorreo.ReadOnly = false;
            txtDireccion.ReadOnly = false;

            rbdActivo.Enabled = true;
            rbdInactivo.Enabled = true;

            btnModificar.Enabled = false;
            btnModificar.Visible = false;
            btnGuardarCliente.Visible = true;
        }
    }
}
