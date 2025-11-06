using CapaDeDatos.Modelados;
using CapaDeDatos.Repositorios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModernMenuUI.InterfacesUsuarios.Compras
{
    public partial class frmAgregarEditarProveedor : Form
    {
        private Proveedor _proveedorActual;
        public frmAgregarEditarProveedor()
        {
            InitializeComponent();
            _proveedorActual = null;
        }
        public frmAgregarEditarProveedor(Proveedor proveedor)
        {
            InitializeComponent();
            _proveedorActual = proveedor; // Modo Editar

        }


        private void frmAgregarEditarProveedor_Load(object sender, EventArgs e)
        {

        }

        private async void btnGuardarProveedor_Click(object sender, EventArgs e)
        {
            {
                // 1. VALIDACIÓN
                if (string.IsNullOrEmpty(txtTelefono.Text))
                {
                    MessageBox.Show("El nombre es obligatorio.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Deshabilitar el botón para evitar doble clic
                btnGuardarProveedor.Enabled = false;

                try
                {
                    if (_proveedorActual == null)
                    {
                        // --- MODO AGREGAR ---
                        Proveedor nuevoProveedor = new Proveedor
                        {
                            NombreProveedorProveedor = txtTelefono.Text.Trim(),
                            TelefonoProveedorProveedor = txtTelefono.Text.Trim(),
                            DireccionProveedorProveedor = txtDireccion.Text.Trim(),
                            EstadoProveedorProveedor = rbActivo.Checked,
                            IdEstadoProveedor = rbActivo.Checked ? 1 : 2 // Asumiendo 1=Activo, 2=Inactivo
                        };

                        await ProveedorRepositorio.InsertarProveedor(nuevoProveedor);
                        MessageBox.Show("¡Proveedor guardado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // --- MODO ACTUALIZAR ---
                        // Poblamos el objeto existente
                        _proveedorActual.NombreProveedorProveedor = txtTelefono.Text.Trim();
                        _proveedorActual.TelefonoProveedorProveedor = txtTelefono.Text.Trim();
                        _proveedorActual.DireccionProveedorProveedor = txtDireccion.Text.Trim();
                        _proveedorActual.EstadoProveedorProveedor = rbActivo.Checked;
                        _proveedorActual.IdEstadoProveedor = rbActivo.Checked ? 1 : 2;

                        await ProveedorRepositorio.ActualizarProveedor(_proveedorActual);
                        MessageBox.Show("¡Proveedor actualizado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Si todo salió bien, cerramos el formulario
                    this.DialogResult = DialogResult.OK; // Opcional
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar el proveedor: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Vuelve a habilitar el botón
                    btnGuardarProveedor.Enabled = true;
                }
            }

        private void frmAgregarProveedorescs_Load(object sender, EventArgs e)
        {
            if (_proveedorActual != null)
            {
                // MODO EDITAR: Llenar los campos
                lblNombreModulo.Text = "EDITAR PROVEEDOR";
                txtTelefono.Text = _proveedorActual.NombreProveedorProveedor;
                txtTelefono.Text = _proveedorActual.TelefonoProveedorProveedor;
                txtDireccion.Text = _proveedorActual.DireccionProveedorProveedor;

                // Asignar RadioButtons
                if (_proveedorActual.EstadoProveedorProveedor)
                {
                    rbActivo.Checked = true;
                }
                else
                {
                    rbInactivo.Checked = true;
                }

                // (Opcional) Lógica de botones de Modificar/Guardar
                // btnGuardar.Visible = false;
                // btnModificar.Visible = true;
            }
            else
            {
                // MODO AGREGAR: Dejar campos vacíos
                lblNombreModulo.Text = "AGREGUE UN PROVEEDOR NUEVO";
                rbActivo.Checked = true; // Valor por defecto
                // btnGuardar.Visible = true;
                // btnModificar.Visible = false;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    
    }
}
