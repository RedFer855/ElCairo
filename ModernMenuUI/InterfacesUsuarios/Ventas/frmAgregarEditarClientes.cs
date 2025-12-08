using CapaDeDatos.Modelados.Ventas;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
using System;
using System.Windows.Forms;

namespace ModernMenuUI.InterfacesUsuarios.Ventas
{
    /// <summary>
    /// Formulario para agregar o editar clientes.
    /// Controla validaciones, permisos, bloqueo de campos,
    /// y operaciones CRUD contra el repositorio de clientes.
    /// </summary>
    public partial class frmAgregarEditarClientes : Form
    {
        /// <summary>
        /// Si es null → modo AGREGAR.
        /// Si tiene valor → modo EDITAR.
        /// </summary>
        private Cliente _clienteActual;

        // ============================================================
        //  CONSTRUCTORES
        // ============================================================

        /// <summary>
        /// Constructor para AGREGAR un cliente.
        /// </summary>
        /// <param name="habilitarCorreo">Permite habilitar el campo correo si se desea.</param>
        public frmAgregarEditarClientes(bool habilitarCorreo = false)
        {
            InitializeComponent();
            _clienteActual = null;

            // Permite activar el correo opcionalmente
            if (habilitarCorreo)
                txtCorreo.ReadOnly = false;

            // Permiso asignado para GUARDAR nuevos clientes
            btnGuardarCliente.Tag = "insert_clientes";
        }

        /// <summary>
        /// Constructor para EDITAR un cliente existente.
        /// Bloquea campos hasta presionar "Modificar".
        /// </summary>
        public frmAgregarEditarClientes(Cliente cliente)
        {
            InitializeComponent();
            _clienteActual = cliente;

            // Asociamos eventos de clic para bloquear elementos hasta activar el modo edición
            txtDni.Click += TextBox_ReadOnlyClick;
            txtRtn.Click += TextBox_ReadOnlyClick;
            txtNombre.Click += TextBox_ReadOnlyClick;
            txtTelefono.Click += TextBox_ReadOnlyClick;
            txtCorreo.Click += TextBox_ReadOnlyClick;
            txtDireccion.Click += TextBox_ReadOnlyClick;

            rbdActivo.Click += Estado_ReadOnlyClick;
            rbdInactivo.Click += Estado_ReadOnlyClick;

            btnVolver.Focus();

            // Permisos asignados para edición
            btnModificar.Tag = "update_clientes";
            btnGuardarCliente.Tag = "update_clientes";
        }


        // ============================================================
        //  GUARDAR CLIENTE (AGREGAR / EDITAR)
        // ============================================================

        /// <summary>
        /// Maneja el guardado tanto para agregar como para editar un cliente.
        /// Aplica validación, guarda datos y maneja errores PostgreSQL.
        /// </summary>
        private async void btnGuardarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (_clienteActual == null)
                {
                    // ----------------------------------------------------
                    // AGREGAR CLIENTE
                    // ----------------------------------------------------
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

                    // Validación unificada
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
                    // ----------------------------------------------------
                    // EDITAR CLIENTE EXISTENTE
                    // ----------------------------------------------------
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

                // ----------------------------------------------------
                // Manejo de errores PostgreSQL (CODE 23505 → duplicado)
                // ----------------------------------------------------
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


        // ============================================================
        //  LOAD DEL FORMULARIO
        // ============================================================

        /// <summary>
        /// Carga datos al entrar en modo edición o prepara la UI para modo agregar.
        /// </summary>
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

                // Bloquear campos
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


        // ============================================================
        //  CONTROL DE BLOQUEO DE CAMPOS
        // ============================================================

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


        // ============================================================
        //  BOTÓN MODIFICAR
        // ============================================================

        /// <summary>
        /// Habilita la edición de los campos en modo EDITAR.
        /// </summary>
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

            // Se retiran validadores de clic de bloqueo
            rbdActivo.Click -= Estado_ReadOnlyClick;
            rbdInactivo.Click -= Estado_ReadOnlyClick;

            btnModificar.Enabled = false;
            btnModificar.Visible = false;
            btnGuardarCliente.Visible = true;
        }


        // ============================================================
        //  BOTÓN VOLVER
        // ============================================================

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
