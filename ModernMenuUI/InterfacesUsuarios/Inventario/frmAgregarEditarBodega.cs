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

            System.Diagnostics.Stopwatch swTotal = new System.Diagnostics.Stopwatch();
            System.Diagnostics.Stopwatch swPaso = new System.Diagnostics.Stopwatch();
            swTotal.Start();

            try
            {
                // PASO A: Conexión a Supabase
                swPaso.Start();
                var supabase = await Conexion.GetClientAsync();
                var usuarioAuth = supabase.Auth.CurrentUser;
                swPaso.Stop();
                long tiempoConexion = swPaso.ElapsedMilliseconds;
                swPaso.Reset();

                // PASO B: Insertar bodega
                swPaso.Start();
                await supabase.Rpc("insertar_bodega", new
                {
                    p_nombre_bodega = txtNombreBodega.Text,
                    p_contrasenia = txtContrasenia.Text,
                    p_estado_bodega = rbActivo.Checked,
                    p_id_estado = rbActivo.Checked ? 1 : 2
                });
                swPaso.Stop();
                long tiempoInsercion = swPaso.ElapsedMilliseconds;

                swTotal.Stop();
                string resumen =
                    $"--- MÉTRICAS DE RENDIMIENTO ---\n" +
                    $"Conexión Supabase: {tiempoConexion} ms\n" +
                    $"Inserción Bodega (RPC): {tiempoInsercion} ms\n" +
                    $"Tiempo Total: {swTotal.ElapsedMilliseconds} ms\n" +
                    $"-------------------------------";
                MessageBox.Show(resumen, "Evaluación del Sistema",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                MessageBox.Show("Bodega guardada exitosamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                swTotal.Stop();
                MessageBox.Show($"FALLO DETECTADO:\n" +
                                $"Tiempo hasta el error: {swTotal.ElapsedMilliseconds} ms\n" +
                                $"Error: {ex.Message}", "Análisis de Fiabilidad",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Close();
            }
        }
    }
}
