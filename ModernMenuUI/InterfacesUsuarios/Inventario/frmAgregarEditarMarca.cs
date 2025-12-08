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

    public partial class frmAgregarEditarMarca : Form
    {
        private int _idProveedorSeleccionado;
        private Marca _marcaSeleccionada;   
        public frmAgregarEditarMarca()
        {
            InitializeComponent();
            btnGuardarMarca.Visible = true;
            lblNombreModulo.Text = "AGREGAR MARCA";
        }

        public frmAgregarEditarMarca(Marca _marcaParaEditar)
        {
            InitializeComponent();
            // Asignamos a nuestra variable local _marcaSeleccionada
            _marcaSeleccionada = _marcaParaEditar;

            // --- LLENAR LOS CAMPOS CON LOS DATOS ---
            txtNombreMarca.Text = _marcaSeleccionada.NombreMarca;

            // Cargar el proveedor 
            txtProveedor.Text = _marcaSeleccionada.NombreProveedor;
            _idProveedorSeleccionado = _marcaSeleccionada.IdProveedor;

            // Cargar RadioButtons
            if (_marcaSeleccionada.EstadoMarca)
                rbActivo.Checked = true;
            else
                rbInactivo.Checked = true;
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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

        private async void btnGuardarMarca_Click(object sender, EventArgs e)
        {
            try
            {
                // VALIDACIONES PREVIAS
                if (_idProveedorSeleccionado <= 0)
                {
                    MessageBox.Show("Debe seleccionar un proveedor.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Construimos el objeto base (lo llamaré _marcaTemporal para diferenciarlo del objeto original cargado)
                MarcaInsertar _marcaTemporal = new MarcaInsertar
                {
                    NombreMarca = txtNombreMarca.Text.Trim(),
                    IdProveedor = _idProveedorSeleccionado
                };

                // Validaciones
                var resultado = ServicioValidacionesIngresoDatos.EjecutarValidacionesMarca(_marcaTemporal);
                if (resultado.Error)
                {
                    MessageBox.Show(resultado.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                btnGuardarMarca.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                // --- LÓGICA DECISIVA: ¿INSERTAR O ACTUALIZAR? ---
                // Verificamos si _marcaSeleccionada es null para saber si es nuevo
                if (_marcaSeleccionada == null)
                {
                    // === MODO INSERTAR ===
                    _marcaTemporal.EstadoMarca = rbActivo.Checked;
                    _marcaTemporal.IdEstado = rbInactivo.Checked ? 2 : 1;

                    await MarcaRepositorio.InsertarMarca(_marcaTemporal);
                    MessageBox.Show("Marca guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // === MODO ACTUALIZAR ===

                    // 1. ¡PASO CRUCIAL! Asignar el ID original al objeto temporal
                    _marcaTemporal.IdMarca = _marcaSeleccionada.IdMarca;

                    // 2. Asignar el resto de estados
                    _marcaTemporal.EstadoMarca = rbActivo.Checked;
                    _marcaTemporal.IdEstado = rbInactivo.Checked ? 2 : 1;

                    // 3. Llamar al método nuevo
                    await MarcaRepositorio.ActualizarMarca(_marcaTemporal);

                    MessageBox.Show("Marca actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar/actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGuardarMarca.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        private void btnModificarMarca_Click(object sender, EventArgs e)
        {
            btnGuardarMarca.Visible = true;
            btnModificarMarca.Visible = false;
        }


    }
}
