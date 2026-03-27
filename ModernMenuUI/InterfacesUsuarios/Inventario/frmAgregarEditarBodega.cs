using CapaDeDatos.Datos;
using CapaDeDatos.Modelados.Inventario;
using CapaServiciosSeguridadValidacion;
using System;
using System.Windows.Forms;

namespace ModernMenuUI.InterfacesUsuarios.Inventario
{
    /// <summary>
    /// Formulario encargado de agregar y editar bodegas dentro del sistema.
    /// Permite registrar nuevas bodegas o modificar una bodega existente,
    /// aplicando validaciones antes de enviar los datos a Supabase mediante funciones RPC.
    /// </summary>
    public partial class frmAgregarEditarBodega : Form
    {
        private readonly Bodega _bodegaEdicion;

        /// <summary>
        /// Constructor para el modo creación de bodega.
        /// </summary>
        public frmAgregarEditarBodega()
        {
            InitializeComponent();
            btnGuardarBodega.Visible = true;
            btnModificarBodega.Visible = false;
        }

        /// <summary>
        /// Constructor para el modo edición de bodega.
        /// </summary>
        /// <param name="nuevaBodega">Objeto bodega que se desea editar.</param>
        public frmAgregarEditarBodega(Bodega nuevaBodega)
        {
            InitializeComponent();

            _bodegaEdicion = nuevaBodega;

            if (_bodegaEdicion != null)
            {
                txtNombreBodega.Text = _bodegaEdicion.NombreBodega ?? string.Empty;
                txtContrasenia.Text = _bodegaEdicion.ContraseniaBodega ?? string.Empty;

                if (_bodegaEdicion.EstadoBodega)
                    rbActivo.Checked = true;
                else
                    rbInactivo.Checked = true;
            }

            btnGuardarBodega.Visible = false;
            btnModificarBodega.Visible = true;
        }

        /// <summary>
        /// Cierra el formulario y regresa a la ventana anterior.
        /// </summary>
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evento que maneja la creación de una nueva bodega.
        /// Valida los datos ingresados y ejecuta la función RPC 'insertar_bodega' en Supabase.
        /// </summary>
        private async void btnGuardarBodega_Click(object sender, EventArgs e)
        {
            Bodega bodega = new Bodega
            {
                NombreBodega = txtNombreBodega.Text.Trim(),
                ContraseniaBodega = txtContrasenia.Text.Trim(),
                EstadoBodega = rbActivo.Checked
            };

            var resultado = ServicioValidacionesIngresoDatos.EjecutarValidacionesBodega(bodega);
            if (resultado.Error)
            {
                MessageBox.Show(resultado.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!rbActivo.Checked && !rbInactivo.Checked)
            {
                MessageBox.Show("Seleccione un estado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var supabase = await Conexion.GetClientAsync();

                await supabase.Rpc("insertar_bodega", new
                {
                    p_nombre_bodega = bodega.NombreBodega,
                    p_contrasenia = bodega.ContraseniaBodega,
                    p_estado_bodega = rbActivo.Checked,
                    p_id_estado = rbActivo.Checked ? 1 : 2
                });

                MessageBox.Show("Bodega guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la bodega: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que maneja la modificación de una bodega existente.
        /// </summary>
        private async void btnModificarBodega_Click(object sender, EventArgs e)
        {
            if (_bodegaEdicion == null)
            {
                MessageBox.Show("No se encontró la bodega a modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Bodega bodegaActualizada = new Bodega
            {
                IdBodega = _bodegaEdicion.IdBodega,
                NombreBodega = txtNombreBodega.Text.Trim(),
                ContraseniaBodega = txtContrasenia.Text.Trim(),
                EstadoBodega = rbActivo.Checked
            };

            var resultado = ServicioValidacionesIngresoDatos.EjecutarValidacionesBodega(bodegaActualizada);
            if (resultado.Error)
            {
                MessageBox.Show(resultado.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!rbActivo.Checked && !rbInactivo.Checked)
            {
                MessageBox.Show("Seleccione un estado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var supabase = await Conexion.GetClientAsync();

                await supabase.Rpc("actualizar_bodega", new
                {
                    p_id_bodega = bodegaActualizada.IdBodega,
                    p_nombre_bodega = bodegaActualizada.NombreBodega,
                    p_contrasenia = bodegaActualizada.ContraseniaBodega,
                    p_estado_bodega = bodegaActualizada.EstadoBodega,
                    p_id_estado = rbActivo.Checked ? 1 : 2
                });

                MessageBox.Show("Bodega modificada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar la bodega: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}