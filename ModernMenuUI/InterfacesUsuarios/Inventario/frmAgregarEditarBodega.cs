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
    /// Formulario encargado de agregar y editar bodegas dentro del sistema.
    /// Permite registrar nuevas bodegas o modificar una bodega existente,
    /// aplicando validaciones antes de enviar los datos a Supabase mediante funciones RPC.
    /// </summary>
    public partial class frmAgregarEditarBodega : Form
    {
        /// <summary>
        /// Constructor para el modo **creación** de bodega.
        /// </summary>
        public frmAgregarEditarBodega()
        {
            InitializeComponent();
            btnGuardarBodega.Visible = true;
            btnModificarBodega.Visible = false;
        }

        /// <summary>
        /// Constructor para el modo **edición** de bodega.
        /// Carga en pantalla los valores de la bodega a modificar.
        /// </summary>
        /// <param name="_nuevaBodega">Objeto bodega que se desea editar.</param>
        public frmAgregarEditarBodega(Bodega _nuevaBodega)
        {
            InitializeComponent();

            txtNombreBodega.Text = _nuevaBodega.NombreBodega;

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
            // Construcción del objeto bodega a partir de los valores ingresados
            Bodega bodega = new Bodega
            {
                NombreBodega = txtNombreBodega.Text.Trim(),
                ContraseniaBodega = txtContrasenia.Text.Trim(),
                EstadoBodega = rbActivo.Checked
            };

            // Ejecución del conjunto de validaciones definidas en el servicio
            var resultado = ServicioValidacionesIngresoDatos.EjecutarValidacionesBodega(bodega);
            if (resultado.Error)
            {
                MessageBox.Show(resultado.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validación adicional del estado
            if (!rbActivo.Checked && !rbInactivo.Checked)
            {
                MessageBox.Show("Seleccione un estado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Obtiene el cliente Supabase actual
                var supabase = await Conexion.GetClientAsync();
                var usuarioAuth = supabase.Auth.CurrentUser;

                // Llamada RPC a la función 'insertar_bodega' en PostgreSQL/Supabase
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
                // Cierra el formulario tras intentar guardar
                this.Close();
            }
        }
    }
}
