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
            if (habilitarCorreo) txtCorreo.ReadOnly = false;

            // MAPEO DE PERMISOS PARA AGREGAR
            btnGuardarCliente.Tag = "insert_clientes";
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

            rbdActivo.Click += Estado_ReadOnlyClick;
            rbdInactivo.Click += Estado_ReadOnlyClick;

            btnVolver.Focus();

            // MAPEO DE PERMISOS PARA EDITAR
            btnModificar.Tag = "update_clientes";
            btnGuardarCliente.Tag = "update_clientes";
        }

        private async void btnGuardarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (_clienteActual == null)
                {
                    // =========== AGREGAR ===========
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

                    var validacion = ServicioValidacionesIngresoDatos.EjecutarValidacionesClinte(nuevoCliente);
                    if (validacion.Error)
                    {
                        MessageBox.Show(validacion.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnGuardarCliente.Enabled = true;
                        return;
                    }

                    await ClienteRepositorio.InsertarCliente(nuevoCliente);

                    MessageBox.Show("¡Cliente guardado exitosamente!", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    // =========== EDITAR ===========
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
                string mensaje = ex.Message;

                // Error PostgreSQL de clave duplicada (23505)
                if (mensaje.Contains("23505"))
                {
                    if (mensaje.Contains("dni_cliente"))
                    {
                        MessageBox.Show("El DNI ingresado ya está registrado en otro cliente.",
                            "DNI duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (mensaje.Contains("rtn_cliente"))
                    {
                        MessageBox.Show("El RTN ingresado ya está registrado en otro cliente.",
                            "RTN duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Un dato único ya está registrado en otro cliente.\nVerifique los campos.",
                            "Dato duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show($"Ocurrió un error al guardar el cliente:\n{ex.Message}",
                        "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                if (!this.IsDisposed)
                    btnGuardarCliente.Enabled = true;
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

                txtDni.ReadOnly = true;
                txtRtn.ReadOnly = true;
                txtNombre.ReadOnly = true;
                txtTelefono.ReadOnly = true;
                txtCorreo.ReadOnly = true;
                txtDireccion.ReadOnly = true;

                rbdActivo.Enabled = true;
                rbdInactivo.Enabled = true;

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
                MessageBox.Show("Presione primero el botón Editar.",
                    "Campo deshabilitado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Estado_ReadOnlyClick(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null && btnModificar.Visible == true)
            {
                MessageBox.Show("Presione primero el botón Editar.",
                    "Estado bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rb.Checked = !rb.Checked;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            // Habilitar edición
            txtDni.ReadOnly = false;
            txtRtn.ReadOnly = false;
            txtNombre.ReadOnly = false;
            txtTelefono.ReadOnly = false;
            txtCorreo.ReadOnly = false;
            txtDireccion.ReadOnly = false;

            rbdActivo.Enabled = true;
            rbdInactivo.Enabled = true;

            rbdActivo.Click -= Estado_ReadOnlyClick;
            rbdInactivo.Click -= Estado_ReadOnlyClick;

            btnModificar.Enabled = false;
            btnModificar.Visible = false;
            btnGuardarCliente.Visible = true;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
