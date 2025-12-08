using CapaDeDatos.Datos;
using CapaDeDatos.Modelados.Ventas;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.InterfacesUsuarios.Ventas;
using Supabase.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Supabase.Realtime.PostgresChanges.PostgresChangesOptions;

namespace ModernMenuUI
{
    /// <summary>
    /// Formulario para la gestión y visualización de clientes.
    /// Permite listar, agregar, editar y monitorear cambios en tiempo real mediante Supabase Realtime.
    /// </summary>
    public partial class frmClientes : Form
    {
        #region Campos Privados

        /// <summary>
        /// Repositorio para acceso a datos de clientes en Supabase.
        /// </summary>
        private readonly ClienteRepositorio _clienteRepo;

        /// <summary>
        /// Canal de suscripción Realtime para escuchar cambios en la tabla de clientes.
        /// </summary>
        private Supabase.Realtime.RealtimeChannel? _clienteSubscription;

        /// <summary>
        /// Servicio para monitorear el estado de la conexión a internet.
        /// </summary>
        private readonly ServicioVerificacionConexion _monitorConexion = new ServicioVerificacionConexion();

        /// <summary>
        /// Cliente de Supabase para realizar operaciones con la base de datos.
        /// </summary>
        private Supabase.Client? _supabaseClient;

        /// <summary>
        /// Cliente actualmente seleccionado en el DataGridView.
        /// </summary>
        private Cliente ClienteSeleccionado = null;

        #endregion

        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia del formulario frmClientes.
        /// Configura el DataGridView, inicializa el repositorio y suscribe eventos de cierre.
        /// </summary>
        public frmClientes()
        {
            InitializeComponent();

            // Desactivar generación automática de columnas para usar diseño personalizado
            dgvClientes.AutoGenerateColumns = false;

            // Inicializar repositorio de clientes
            _clienteRepo = new ClienteRepositorio();

            // Suscribir evento de cierre del formulario
            this.FormClosing += frmClientes_FormClosing;
        }

        #endregion

        #region Eventos de Carga y Cierre

        /// <summary>
        /// Evento que se ejecuta al cargar el formulario.
        /// Inicializa el monitor de conexión, carga los clientes y establece la suscripción Realtime.
        /// </summary>
        /// <param name="sender">Objeto que genera el evento</param>
        /// <param name="e">Argumentos del evento</param>
        private async void frmClientes_Load(object sender, EventArgs e)
        {
            // Suscribir evento de cambio de estado de red
            _monitorConexion.EstadoDeRedCambiado += MonitorConexion_EstadoDeRedCambiado;

            // Cargar lista inicial de clientes
            await CargarClientes();

            // Iniciar escucha de cambios en tiempo real
            await IniciarSuscripcionClientes();
        }

        /// <summary>
        /// Evento que se ejecuta cuando el formulario está cerrándose.
        /// Libera recursos y cancela suscripciones Realtime activas.
        /// </summary>
        /// <param name="sender">Objeto que genera el evento</param>
        /// <param name="e">Argumentos del evento que permiten cancelar el cierre</param>
        private async void frmClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Desechar suscripción Realtime antes de cerrar
            await DesecharSuscripcion();
        }

        #endregion

        #region Eventos de Botones

        /// <summary>
        /// Evento del botón Salir.
        /// Cierra el formulario actual y restaura el nombre del menú principal.
        /// </summary>
        /// <param name="sender">Objeto que genera el evento (btnSalir)</param>
        /// <param name="e">Argumentos del evento</param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Restaurar nombre del menú principal en la interfaz
            clsAnmaciones.NombreMenuPrincipal();

            // Cerrar formulario
            this.Close();
        }

        /// <summary>
        /// Evento del botón Agregar Cliente.
        /// Abre el formulario para crear un nuevo cliente con el campo de correo habilitado.
        /// </summary>
        /// <param name="sender">Objeto que genera el evento (btnCliente)</param>
        /// <param name="e">Argumentos del evento</param>
        private void btnCliente_Click(object sender, EventArgs e)
        {
            // Crear formulario con correo habilitado (nuevo cliente)
            frmAgregarEditarClientes form = new frmAgregarEditarClientes(habilitarCorreo: true);

            // Mostrar como diálogo modal
            form.ShowDialog();

            // Los cambios se reflejarán automáticamente por Realtime
        }

        /// <summary>
        /// Evento del botón Editar Cliente.
        /// Abre el formulario de edición con los datos del cliente seleccionado.
        /// Valida que haya un cliente seleccionado antes de abrir el formulario.
        /// </summary>
        /// <param name="sender">Objeto que genera el evento (btnEditar)</param>
        /// <param name="e">Argumentos del evento</param>
        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Verificar si hay un cliente seleccionado
            if (ClienteSeleccionado != null)
            {
                // Crear formulario de edición pasando el cliente seleccionado
                frmAgregarEditarClientes form = new frmAgregarEditarClientes(ClienteSeleccionado);

                // Mostrar como diálogo modal
                form.ShowDialog();

                // Recargar clientes (respaldo por si Realtime falla)
                CargarClientes();
            }
            else
            {
                // Mostrar mensaje si no hay selección
                MessageBox.Show("Seleccione un cliente primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region Eventos del DataGridView

        /// <summary>
        /// Evento que se ejecuta cuando cambia la selección en el DataGridView.
        /// Actualiza la variable ClienteSeleccionado con el cliente de la fila seleccionada.
        /// </summary>
        /// <param name="sender">Objeto que genera el evento (dgvClientes)</param>
        /// <param name="e">Argumentos del evento</param>
        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            // Verificar si hay al menos una fila seleccionada
            if (dgvClientes.SelectedRows.Count > 0)
            {
                // Obtener el cliente de la fila seleccionada
                ClienteSeleccionado = dgvClientes.SelectedRows[0].DataBoundItem as Cliente;
            }
            else
            {
                // No hay selección, limpiar variable
                ClienteSeleccionado = null;
            }
        }

        #endregion

        #region Métodos de Suscripción Realtime

        /// <summary>
        /// Cancela y libera la suscripción Realtime activa de forma segura.
        /// Previene memory leaks y conexiones huérfanas.
        /// </summary>
        /// <returns>Task que representa la operación asíncrona</returns>
        private async Task DesecharSuscripcion()
        {
            // Verificar si existe una suscripción activa
            if (_clienteSubscription != null)
            {
                try
                {
                    // Ejecutar desuscripción en un thread separado para evitar bloqueos
                    await Task.Run(() => _clienteSubscription.Unsubscribe());

                    System.Diagnostics.Debug.WriteLine("Suscripción de clientes desechada correctamente.");
                }
                catch (Exception ex)
                {
                    // Registrar error pero continuar con la limpieza
                    System.Diagnostics.Debug.WriteLine($"Error al desechar suscripción: {ex.Message}");
                }

                // Liberar referencia
                _clienteSubscription = null;
            }
        }

        /// <summary>
        /// Inicia o reinicia la suscripción Realtime para escuchar cambios en la tabla de clientes.
        /// Se suscribe a todos los eventos (INSERT, UPDATE, DELETE) y actualiza el DataGridView automáticamente.
        /// </summary>
        /// <returns>Task que representa la operación asíncrona</returns>
        private async Task IniciarSuscripcionClientes()
        {
            // Limpiar suscripción anterior si existe
            await DesecharSuscripcion();

            try
            {
                // Obtener cliente de Supabase con timeout de 3 segundos
                _supabaseClient = await Conexion.ConnectWithTimeoutAsync(3);

                // Crear suscripción a la tabla de clientes
                _clienteSubscription = await _supabaseClient
                    .From<Cliente>()
                    .On(ListenType.All, (sender, change) =>  // Escuchar INSERT, UPDATE, DELETE
                    {
                        try
                        {
                            // Verificar que el formulario siga existente y accesible
                            if (this == null || this.IsDisposed || !this.IsHandleCreated)
                            {
                                System.Diagnostics.Debug.WriteLine("Realtime ignorado: formulario no disponible.");
                                return;
                            }

                            // Ejecutar actualización en el hilo UI principal
                            this.BeginInvoke((MethodInvoker)(async () =>
                            {
                                // Verificar nuevamente antes de actualizar
                                if (!this.IsDisposed)
                                {
                                    System.Diagnostics.Debug.WriteLine($"Cambio detectado: {change.Event} en clientes.");

                                    // Recargar lista de clientes
                                    await CargarClientes();
                                }
                            }));
                        }
                        catch (Exception ex)
                        {
                            // Registrar errores del callback sin interrumpir la suscripción
                            System.Diagnostics.Debug.WriteLine($"Error en evento Realtime: {ex.Message}");
                        }
                    });

                System.Diagnostics.Debug.WriteLine("Suscripción Realtime a clientes iniciada.");
            }
            catch (Exception ex)
            {
                // Registrar error de suscripción (la aplicación continúa funcionando sin Realtime)
                System.Diagnostics.Debug.WriteLine($"Error al suscribirse a clientes: {ex.Message}");
            }
        }

        #endregion

        #region Métodos de Carga de Datos

        /// <summary>
        /// Carga todos los clientes desde la base de datos y actualiza el DataGridView.
        /// Incluye timeout de 3 segundos y manejo de errores de conexión.
        /// </summary>
        /// <returns>Task que representa la operación asíncrona</returns>
        private async Task CargarClientes()
        {
            try
            {
                // Cambiar cursor a indicador de espera
                this.Cursor = Cursors.WaitCursor;

                // Crear token de cancelación con timeout de 3 segundos
                using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3)))
                {
                    // Obtener lista de clientes del repositorio
                    List<Cliente> lista = await _clienteRepo.ObtenerTodosLosClientes();

                    // Limpiar DataSource anterior
                    dgvClientes.DataSource = null;

                    // Asignar nueva lista como DataSource
                    dgvClientes.DataSource = lista;
                }

                // Limpiar selección si hay filas
                if (dgvClientes.Rows.Count > 0)
                {
                    dgvClientes.ClearSelection();
                }
            }
            catch (OperationCanceledException)
            {
                // Error de timeout al conectar con el servidor
                MessageBox.Show("No se pudo conectar al servidor (timeout).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Error general al cargar clientes
                MessageBox.Show(ex.Message, "Error al cargar clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Restaurar cursor normal siempre
                this.Cursor = Cursors.Default;
            }
        }

        #endregion

        #region Eventos de Monitoreo de Conexión

        /// <summary>
        /// Evento que se ejecuta cuando cambia el estado de la red (online/offline).
        /// Cuando se recupera la conexión, recarga los datos y reinicia la suscripción Realtime.
        /// </summary>
        /// <param name="status">Estado actual de la red</param>
        private async void MonitorConexion_EstadoDeRedCambiado(NetworkStatus status)
        {
            // Verificar que el formulario esté disponible antes de procesar
            if (!this.IsHandleCreated || this.IsDisposed) return;

            // Procesar solo cuando se recupera la conexión a internet
            if (status == NetworkStatus.Internet)
            {
                // Ejecutar en el hilo UI principal
                this.BeginInvoke((MethodInvoker)(async () =>
                {
                    // Verificar nuevamente antes de actualizar
                    if (!this.IsDisposed)
                    {
                        // Recargar datos después de recuperar conexión
                        await CargarClientes();

                        // Reiniciar suscripción Realtime
                        await IniciarSuscripcionClientes();
                    }
                }));
            }
        }

        #endregion
    }
}