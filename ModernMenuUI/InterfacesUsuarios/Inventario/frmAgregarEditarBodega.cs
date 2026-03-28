using CapaDeDatos.Datos;
using CapaDeDatos.Modelados.Inventario;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using Serilog;
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

        private static readonly Serilog.ILogger _log = new Serilog.LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/app.txt", rollingInterval: Serilog.RollingInterval.Day)
    .CreateLogger();
        /// <summary>
        /// Constructor para el modo creación de bodega.
        /// </summary>
        public frmAgregarEditarBodega()
        {
            InitializeComponent();
            btnGuardarBodega.Visible = true;
            btnModificarBodega.Visible = false;
            rbActivo.Checked = true;
            rbInactivo.Enabled = false;
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
        private async void frmAgregarEditarBodega_Load(object sender, EventArgs e)
        {
            await CargarDepartamentos();
        }

        /// <summary>
        /// Metodo para cargar los departamentos en el cmbDepartamentos.
        /// </summary>
        private async Task CargarDepartamentos()
        {
            try
            {
                var repo = new BodegaRepositorio(); // la clase donde está obtenerDepartamentos
                var departamentos = await repo.obtenerDepartamentos();

                cmbDepartamentos.DataSource = departamentos;
                cmbDepartamentos.DisplayMember = "NombreDepartamento"; // lo que se muestra
                cmbDepartamentos.ValueMember = "IdDepartamento"; // el valor interno
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando departamentos");
            }
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
                TelefonoSucursal = txtNumero.Text.Trim(),
                IdDepartamento = Convert.ToByte(cmbDepartamentos.SelectedValue),
                EstadoBodega = rbActivo.Checked
            };

            var resultado = ServicioValidacionesIngresoDatos.EjecutarValidacionesBodega(bodega);
            if (resultado.Error)
            {
                _log.Warning("Validación de bodega fallida: {Mensaje}", resultado.Mensaje);
                MessageBox.Show(resultado.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!rbActivo.Checked && !rbInactivo.Checked)
            {
                _log.Warning("Intento de guardar bodega sin estado seleccionado: {Nombre}", bodega.NombreBodega);
                MessageBox.Show("Seleccione un estado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ====== INICIO MÉTRICAS ======
            System.Diagnostics.Stopwatch swTotal = new System.Diagnostics.Stopwatch();
            System.Diagnostics.Stopwatch swPaso = new System.Diagnostics.Stopwatch();
            swTotal.Start();

            try
            {
                // PASO A: Conexión
                swPaso.Start();
                var supabase = await Conexion.GetClientAsync();
                swPaso.Stop();
                long tiempoConexion = swPaso.ElapsedMilliseconds;
                swPaso.Reset();

                // PASO B: Insertar bodega
                _log.Information("Insertando nueva bodega: {Nombre}", bodega.NombreBodega);
                swPaso.Start();
                await supabase.Rpc("insertar_bodega", new
                {
                    p_nombre_bodega = bodega.NombreBodega,
                    p_contrasenia = bodega.ContraseniaBodega,
                    p_numero_telefono = bodega.TelefonoSucursal,
                    p_departamento = bodega.IdDepartamento,
                    p_estado_bodega = rbActivo.Checked,
                    p_id_estado = rbActivo.Checked ? 1 : 2
                });
                swPaso.Stop();
                long tiempoInsercion = swPaso.ElapsedMilliseconds;

                swTotal.Stop();
                _log.Information("Bodega guardada exitosamente: {Nombre}", bodega.NombreBodega);

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
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                swTotal.Stop();
                _log.Error(ex, "Error al guardar bodega: {Nombre}", bodega.NombreBodega);
                MessageBox.Show($"FALLO DETECTADO:\n" +
                                $"Tiempo hasta el error: {swTotal.ElapsedMilliseconds} ms\n" +
                                $"Error: {ex.Message}", "Análisis de Fiabilidad",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Evento que maneja la modificación de una bodega existente.
        /// </summary>
        private async void btnModificarBodega_Click(object sender, EventArgs e)
        {
            if (_bodegaEdicion == null)
            {
                _log.Warning("Intento de modificar bodega sin objeto de edición");
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
                _log.Warning("Validación de bodega fallida al modificar: {Mensaje}", resultado.Mensaje);
                MessageBox.Show(resultado.Mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!rbActivo.Checked && !rbInactivo.Checked)
            {
                _log.Warning("Intento de modificar bodega sin estado seleccionado: {Nombre}", bodegaActualizada.NombreBodega);
                MessageBox.Show("Seleccione un estado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ====== INICIO MÉTRICAS ======
            System.Diagnostics.Stopwatch swTotal = new System.Diagnostics.Stopwatch();
            System.Diagnostics.Stopwatch swPaso = new System.Diagnostics.Stopwatch();
            swTotal.Start();

            try
            {
                // PASO A: Conexión
                swPaso.Start();
                var supabase = await Conexion.GetClientAsync();
                swPaso.Stop();
                long tiempoConexion = swPaso.ElapsedMilliseconds;
                swPaso.Reset();

                // PASO B: Actualizar bodega
                _log.Information("Actualizando bodega ID {Id}: {Nombre}", bodegaActualizada.IdBodega, bodegaActualizada.NombreBodega);
                swPaso.Start();
                await supabase.Rpc("actualizar_bodega", new
                {
                    p_id_bodega = bodegaActualizada.IdBodega,
                    p_nombre_bodega = bodegaActualizada.NombreBodega,
                    p_contrasenia = bodegaActualizada.ContraseniaBodega,
                    p_estado_bodega = bodegaActualizada.EstadoBodega,
                    p_id_estado = rbActivo.Checked ? 1 : 2
                });
                swPaso.Stop();
                long tiempoActualizacion = swPaso.ElapsedMilliseconds;

                swTotal.Stop();
                _log.Information("Bodega modificada exitosamente: {Nombre}", bodegaActualizada.NombreBodega);

                string resumen =
                    $"--- MÉTRICAS DE RENDIMIENTO ---\n" +
                    $"Conexión Supabase: {tiempoConexion} ms\n" +
                    $"Actualización Bodega (RPC): {tiempoActualizacion} ms\n" +
                    $"Tiempo Total: {swTotal.ElapsedMilliseconds} ms\n" +
                    $"-------------------------------";
                MessageBox.Show(resumen, "Evaluación del Sistema",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                MessageBox.Show("Bodega modificada exitosamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                swTotal.Stop();
                _log.Error(ex, "Error al modificar bodega ID {Id}: {Nombre}", bodegaActualizada.IdBodega, bodegaActualizada.NombreBodega);
                MessageBox.Show($"FALLO DETECTADO:\n" +
                                $"Tiempo hasta el error: {swTotal.ElapsedMilliseconds} ms\n" +
                                $"Error: {ex.Message}", "Análisis de Fiabilidad",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}