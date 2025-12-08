using CapaDeDatos.Datos;
using CapaDeDatos.Modelados.Inventario;
using CapaDeDatos.Modelados.Productos;
using CapaServiciosSeguridadValidacion;
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
    /// Formulario para agregar o editar una bodega.
    /// Proporciona UI para crear una nueva bodega o modificar una existente.
    /// </summary>
    public partial class frmAgregarEditarBodega : Form
    {
        /// <summary>
        /// Inicializa una nueva instancia del formulario en modo "Agregar".
        /// Muestra el botón de guardar y oculta el de modificar.
        /// </summary>
        public frmAgregarEditarBodega()
        {
            InitializeComponent();
            btnGuardarBodega.Visible = true;
            btnModificarBodega.Visible = false;
        }

        /// <summary>
        /// Inicializa una nueva instancia del formulario en modo "Editar".
        /// Rellena los controles con los datos de la bodega proporcionada.
        /// </summary>
        /// <param name="_nuevaBodega">Objeto <see cref="Bodega"/> con los datos a editar.</param>
        public frmAgregarEditarBodega(Bodega _nuevaBodega)
        {
            InitializeComponent();
            txtNombreBodega.Text = _nuevaBodega.NombreBodega;
            btnGuardarBodega.Visible = false;
            btnModificarBodega.Visible = true;
        }

        /// <summary>
        /// Cierra el formulario al pulsar el botón "Volver".
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handler para guardar una nueva bodega.
        /// Valida los datos, llama al RPC de inserción y muestra mensajes de resultado.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private async void btnGuardarBodega_Click(object sender, EventArgs e)
        {
            Bodega bodega= new Bodega
            {
                NombreBodega = txtNombreBodega.Text.Trim(),
                ContraseniaBodega = txtContrasenia.Text.Trim(),
                EstadoBodega = rbActivo.Checked
            };

            // Validaciones
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
                var usuarioAuth = supabase.Auth.CurrentUser;
                
                await supabase.Rpc("insertar_bodega", new
                {
                    p_nombre_bodega = txtNombreBodega.Text,
                    p_contrasenia = txtContrasenia.Text,
                    p_estado_bodega = rbActivo.Checked,
                    p_id_estado = rbActivo.Checked ? 1 : 2
                });
                MessageBox.Show("Bodega guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la bodega: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Close();
            }
        }
    }
}
