using CapaDeDatos.Datos;
using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion.CapaServiciosSeguridadValidacion;
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

namespace ModernMenuUI.InterfacesUsuarios.Inventario
{
    public partial class frmCategorias : Form
    {
        private readonly CategoriaRepositorio categoriaRepositorio;
        private List<Categoria> _listaMaestraCategorias = new List<Categoria>();
        private Supabase.Realtime.RealtimeChannel? _categoriasSubscription;
        private readonly ServicioVerificacionConexion _monitorConexion = new ServicioVerificacionConexion();
        private Supabase.Client? _supabaseClient;
        public Categoria CategoriaSeleccionada { get; private set; }

        public frmCategorias()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            categoriaRepositorio = new CategoriaRepositorio();
            dgvCategorias.AutoGenerateColumns = false; // Asumiendo dgvCategorias
            this.FormClosing += frmCategorias_FormClosing;
        }

        private async void frmCategorias_Load(object sender, EventArgs e)
        {
            _monitorConexion.EstadoDeRedCambiado += MonitorConexion_EstadoDeRedCambiado;

            if (!rbMostrarTodos.Checked && !rbMostrarHabilitados.Checked && !rbMostrarDeshabilitados.Checked)
            {
                rbMostrarTodos.Checked = true;
            }

            // Cargar la lista maestra
            await CargarCategoriasMaestras();

            // Aplicar el filtro por defecto
            RefrescarGrid();

            // Iniciar la suscripción
            await IniciarSuscripcionCategorias();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void frmCategorias_FormClosing(object sender, FormClosingEventArgs e)
        {
            await DesecharSuscripcion();
            _monitorConexion.EstadoDeRedCambiado -= MonitorConexion_EstadoDeRedCambiado;
        }

        private async Task CargarCategoriasMaestras()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                // CORRECTO: Llama al método usando la VARIABLE (la instancia)
                _listaMaestraCategorias = await categoriaRepositorio.ObtenerTodasLasCategorias(null);
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("No se pudo conectar con el servidor (tiempo de espera agotado).", "Error de Red", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar categorías", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void RefrescarGrid()
        {
            this.Cursor = Cursors.WaitCursor;

            // 1. Determinar el filtro de estado
            bool? estado = null;
            if (rbMostrarHabilitados.Checked) estado = true;
            if (rbMostrarDeshabilitados.Checked) estado = false;

            // 2. Filtrar la LISTA MAESTRA
            List<Categoria> listaFiltrada;

            if (estado == null)
            {
                listaFiltrada = _listaMaestraCategorias; // Todos
            }
            else
            {
                // Usa la propiedad 'EstadoCategoria' del modelo
                listaFiltrada = _listaMaestraCategorias.Where(c => c.EstadoCategoria == estado).ToList();
            }

            // 3. Asignar al DataGridView
            dgvCategorias.DataSource = null;
            dgvCategorias.DataSource = listaFiltrada;

            if (dgvCategorias.Rows.Count > 0)
                dgvCategorias.ClearSelection();

            this.Cursor = Cursors.Default;
        }


        private async Task DesecharSuscripcion()
        {
            if (_categoriasSubscription != null)
            {
                try
                {
                    await Task.Run(() => _categoriasSubscription.Unsubscribe());
                    System.Diagnostics.Debug.WriteLine("Suscripción de Categorías desechada.");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error al desechar suscripción Categorías: {ex.Message}");
                }
                _categoriasSubscription = null;
            }
        }

        private async Task IniciarSuscripcionCategorias()
        {
            await DesecharSuscripcion();

            try
            {
                _supabaseClient = await Conexion.ConnectWithTimeoutAsync(3);

                // Suscripción a la tabla 'categoria'
                _categoriasSubscription = await _supabaseClient.From<Categoria>()
                    .On(ListenType.All, (sender, change) =>
                    {
                        try
                        {
                            if (this == null || this.IsDisposed || !this.IsHandleCreated) return;

                            this.BeginInvoke((MethodInvoker)(async () =>
                            {
                                if (this.IsDisposed) return;
                                System.Diagnostics.Debug.WriteLine($"Cambio detectado: {change.Event} en Categorías.");

                                // 1. Vuelve a cargar la lista maestra
                                await CargarCategoriasMaestras();
                                // 2. Refresca el grid con filtros
                                RefrescarGrid();
                            }));
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"Error manejando evento Realtime Categorías: {ex.Message}");
                        }
                    });

                System.Diagnostics.Debug.WriteLine("Suscripción a Realtime (Categorías) creada.");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al suscribir a Realtime (Categorías): {ex.Message}");
            }
        }


        private async void MonitorConexion_EstadoDeRedCambiado(NetworkStatus status)
        {
            if (!this.IsHandleCreated || this.IsDisposed) return;

            if (status == NetworkStatus.Internet)
            {
                this.BeginInvoke((MethodInvoker)(async () =>
                {
                    if (this.IsDisposed) return;
                    System.Diagnostics.Debug.WriteLine("Red recuperada. Recargando Categorías y Realtime...");
                    await CargarCategoriasMaestras();
                    RefrescarGrid();
                    await IniciarSuscripcionCategorias();
                }));
            }
        }

        private void rbMostrarHabilitados_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMostrarHabilitados.Checked)
            {
                RefrescarGrid();
            }
        }

        private void rbMostrarDeshabilitados_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMostrarDeshabilitados.Checked)
            {
                RefrescarGrid();
            }
        }

        private void rbMostrarTodos_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbMostrarTodos.Checked)
            {
                RefrescarGrid();
            }
        }

        private void btnSeleccionarCategoria_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count > 0)
            {
                CategoriaSeleccionada = dgvCategorias.SelectedRows[0].DataBoundItem as Categoria;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void dgvCategorias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                CategoriaSeleccionada = dgvCategorias.Rows[e.RowIndex].DataBoundItem as Categoria;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
