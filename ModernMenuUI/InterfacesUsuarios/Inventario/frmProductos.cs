using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion.CapaServiciosSeguridadValidacion;
using ModernMenuUI.InterfacesUsuarios.Inventario;
using Supabase.Realtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Supabase.Realtime.PostgresChanges.PostgresChangesOptions;

namespace ModernMenuUI
{
    public partial class frmProductos : Form
    {
        private readonly ProductoRepositorio _productoRepo;
        private readonly MarcaRepositorio _marcaRepo;
        private Producto _productoSeleccionado = null;

        private Supabase.Realtime.RealtimeChannel? _productoSubscription;
        private readonly ServicioVerificacionConexion _monitorConexion = new ServicioVerificacionConexion();
        private Supabase.Client? _supabaseClient;
        Form formularioactivo = null;
        public frmProductos()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            // ===== ESTILO BARRA LATERAL (RowHeader) =====
            dgvProductos.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#DCE6F1");
            dgvProductos.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#57636e");
            dgvProductos.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            _productoRepo = new ProductoRepositorio();
            dgvProductos.AutoGenerateColumns = false;


            _marcaRepo = new MarcaRepositorio();

            this.FormClosing += frmProductos_FormClosing;

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            this.Close();
        }

        private void HoraFecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss tt", new CultureInfo("es-ES"));
            lblFecha.Text = DateTime.Now.ToString("dddd dd 'de' MMMM 'del' yyyy", new CultureInfo("es-ES"));
        }

        private void AbrirFormularioHijo(Form Formulariohijo)
        {
            Editar_Producto formHijo = new Editar_Producto();
            formHijo.StartPosition = FormStartPosition.CenterParent;

            // Evento que detecta cuando el formulario pierde foco
            formHijo.Deactivate += (s, ev) =>
            {
                System.Media.SystemSounds.Exclamation.Play(); // Sonido de advertencia
            };

            formHijo.ShowDialog(); // Modal
        }
        private async void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            Editar_Producto producto = new Editar_Producto();
            DialogResult resultado = producto.ShowDialog();

            // --- AÑADIDO: Refresco del DataGridView ---
            // Comprueba la "señal" (OK o Cancel) que envió el formulario pequeño
            if (resultado == DialogResult.OK)
            {
                // Si la señal fue "OK", refresca el DataGridView
                // (null = Cargar Todos, respetando tu filtro)
                await CargarProductos(null);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (_productoSeleccionado != null)
            {
                // ¡Clave! Abre el formulario de diálogo PASANDO el objeto
                Editar_Producto productoEditar = new Editar_Producto(_productoSeleccionado);
                productoEditar.ShowDialog();

                // No necesitas refrescar el DGV aquí, porque
                // tu lógica de Realtime se encargará de eso automáticamente.
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un producto de la lista para editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            btnNuevo.Enabled = dgvProductos.SelectedRows.Count > 0;
            if (dgvProductos.SelectedRows.Count > 0)
            {
                var filaSeleccionada = dgvProductos.SelectedRows[0];
                _productoSeleccionado = filaSeleccionada.DataBoundItem as Producto;
            }
            else
            {
                _productoSeleccionado = null;
            }
        }
        // 1. REEMPLAZA tu método 'CargarProductos'
        private async Task CargarProductos(bool? estado = null) // Ahora acepta un filtro
        {
            try
            {
                this.Cursor = Cursors.WaitCursor; // Pone el cursor de espera
                gbxEstado.Enabled = false;     // Deshabilita los radio buttons

                // 2. Llama al método del repositorio con el filtro
                // (Debes modificar tu _productoRepo.ObtenerProductos para que acepte el 'estado')
                List<Producto> listaDeProductos = await _productoRepo.ObtenerTodosLosProductos(estado);

                // 3. Asigna los datos al DataGridView
                dgvProductos.DataSource = null;
                dgvProductos.DataSource = listaDeProductos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar productos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default; // Devuelve el cursor
                gbxEstado.Enabled = true;     // Vuelve a habilitar los radio buttons
            }
        }

        private async void frmProductos_Load(object sender, EventArgs e)
        {
            await CargarProductos(null);
            await CargarMarcasAsync();
            await IniciarSuscripcionProductos();
        }
        private async Task DesecharSuscripcion()
        {
            if (_productoSubscription != null)
            {
                try
                {
                    await Task.Run(() => _productoSubscription.Unsubscribe());
                    System.Diagnostics.Debug.WriteLine("Suscripción (Producto) desechada con éxito.");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error al desechar suscripción (Producto): {ex.Message}");
                }
                _productoSubscription = null;
            }
        }
        private async Task IniciarSuscripcionProductos()
        {
            await DesecharSuscripcion();
            try
            {
                _supabaseClient = await Conexion.ConnectWithTimeoutAsync(10);

                _productoSubscription = await _supabaseClient.From<Producto>()
                    .On(ListenType.All, (sender, change) =>
                    {
                        if (this == null || this.IsDisposed || !this.IsHandleCreated) return;
                        this.BeginInvoke((MethodInvoker)(async () =>
                        {
                            if (this.IsDisposed) return;
                            System.Diagnostics.Debug.WriteLine($"Cambio detectado en Productos: {change.Event}. Recargando...");
                            await CargarProductos(null); // Recarga la tabla
                        }));
                    });
                System.Diagnostics.Debug.WriteLine("Suscripción a Productos (Realtime) creada.");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al suscribir a Realtime (Producto): {ex.Message}");
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
                    await CargarProductos(null);
                    await IniciarSuscripcionProductos();
                }));
            }
        }
        private async void rbMostrarTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                await CargarProductos(null); // 'null' significa Todos
            }
        }

        private async void rbMostrarHabilitados_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                await CargarProductos(true); // 'true' significa Habilitados
            }
        }

        private async void rbMostrardeshabilitados_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                await CargarProductos(false); // 'false' significa Deshabilitados
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            /*frmAgregarEditarMarca marca = new frmAgregarEditarMarca();
            marca.ShowDialog();*/

            frmAgregarEditarMarca formDeIngreso = new frmAgregarEditarMarca();

            // Muestra el formulario como un diálogo y "pausa" este código
            DialogResult resultado = formDeIngreso.ShowDialog();

            // 5. ¡AQUÍ ESTÁ LA MAGIA!
            //    Comprueba la "señal" (OK o Cancel) que envió el formulario pequeño
            if (resultado == DialogResult.OK)
            {
                // 6. Si la señal fue "OK", refresca el ComboBox
                MessageBox.Show("Marca agregada. Refrescando lista...", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Vuelve a llamar al método de carga
                await CargarMarcasAsync();
            }

            // Si el usuario presionó "Cancelar", no hace nada.
        }

        private async Task CargarMarcasAsync()
        {
            try
            {
                // Llama al repositorio (Capa de Datos) para obtener la lista
                // (Usando la instancia _marcaRepo)
                var listaDeMarcas = await _marcaRepo.ObtenerTodasLasMarcas();

                // Configura el ComboBox
                // (Asumiendo que tu ComboBox se llama cmbMarca)

                // Le dice al ComboBox qué datos usar
                //cmbMarca.DataSource = listaDeMarcas;

                // Le dice qué propiedad del modelo 'Marca' mostrar al usuario
                // (Usa el nombre de la propiedad de tu clase C#)
                //cmbMarca.DisplayMember = "NombreMarcaMarca";

                // Le dice qué propiedad usar como valor interno (el ID)
                // cmbMarca.ValueMember = "IdMarca";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las marcas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void frmProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            await DesecharSuscripcion();
        }

        private void gbxEstado_Enter(object sender, EventArgs e)
        {

        }
    }

}
