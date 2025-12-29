using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using CapaDeDatos.Modelados.UsuariosEmpleados;
using CapaDeDatos.Modelados.Ventas;
using ModernMenuUI.ClasesUI;
using Supabase.Realtime;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI.InterfacesUsuarios.Ventas
{
    /// <summary>
    /// Formulario encargado de mostrar el cierre diario de ventas
    /// de un empleado específico en una fecha seleccionada.
    /// Permite ver detalle, totalizar ventas, imprimir y escuchar cambios.
    /// </summary>
    public partial class frmCierreDiario : Form
    {
        /// <summary>
        /// Suscripción Realtime para monitorear la tabla de ventas.
        /// </summary>
        private RealtimeChannel? _ventasSubscription;

        /// <summary>
        /// Flag que controla que el formulario haya terminado de cargar
        /// antes de ejecutar búsquedas automáticas por eventos.
        /// </summary>
        private bool _formCargado = false;


        // ============================================================
        //  CONSTRUCTOR
        // ============================================================

        /// <summary>
        /// Inicializa componentes y configura el DataGridView.
        /// </summary>
        public frmCierreDiario()
        {
            InitializeComponent();

            dgvCierre.AutoGenerateColumns = false;
            txtTotalVentas.ReadOnly = true;

            this.FormClosing += frmCierreDiario_FormClosing;
        }


        // ============================================================
        //  MÉTODOS DE SUSCRIPCIÓN REALTIME
        // ============================================================

        /// <summary>
        /// Se encarga de desuscribir la escucha Realtime en Supabase
        /// para evitar fugas de memoria o eventos fantasma.
        /// </summary>
        private async Task DesecharSuscripcionVentas()
        {
            if (_ventasSubscription != null)
            {
                try
                {
                    await Task.Run(() => _ventasSubscription.Unsubscribe());
                    System.Diagnostics.Debug.WriteLine("Suscripción a Ventas desechada.");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error al desuscribir Ventas: {ex.Message}");
                }

                _ventasSubscription = null;
            }
        }


        // ============================================================
        //  MÉTODOS DE CARGA DE INFORMACIÓN
        // ============================================================

        /// <summary>
        /// Llama el RPC "fn_cierre_diario_alias" para obtener el cierre diario
        /// de un empleado y fecha seleccionada.  
        /// Llena el DataGridView y calcula el total del día.
        /// </summary>
        private async Task CargarCierreDiarioAsync()
        {
            var supabase = await Conexion.GetClientAsync();

            string alias = cmbEmpleado.SelectedValue?.ToString();
            DateTime fecha = dtpFecha.Value.Date;

            // Evita errores si no hay empleado seleccionado
            if (string.IsNullOrWhiteSpace(alias))
                return;

            var lista = await supabase.Rpc<List<CierreDiarioResult>>("fn_cierre_diario_alias", new
            {
                p_alias_usuario = alias,
                p_fecha = fecha.ToString("yyyy-MM-dd")
            });

            // Asignación al DGV principal
            dgvCierre.DataSource = lista;

            // Sumatoria de subtotales
            decimal totalDia = lista.Sum(x => x.Subtotal);
            txtTotalVentas.Text = "L." + totalDia.ToString("0.00");
        }


        /// <summary>
        /// Obtiene todos los alias de usuario de la tabla usuarios,
        /// los carga en el ComboBox y establece el modo DropDownList.
        /// </summary>
        private async Task CargarAliasUsuariosAsync()
        {
            try
            {
                var supabase = await Conexion.GetClientAsync();

                var resp = await supabase
                    .From<Usuario>()
                    .Select("alias_usuario")
                    .Get();

                var lista = resp.Models.ToList();

                cmbEmpleado.DataSource = lista;
                cmbEmpleado.DisplayMember = "AliasUsuario";
                cmbEmpleado.ValueMember = "AliasUsuario";
                cmbEmpleado.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Muestra el cierre diario aplicando animación de carga.
        /// Llama internamente a CargarCierreDiarioAsync().
        /// </summary>
        private async Task GenerarCierreAsync()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                await CargarCierreDiarioAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el cierre: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        // ============================================================
        //  EVENTOS
        // ============================================================

        /// <summary>
        /// Sale del formulario regresando al menú principal.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            this.Close();
        }


        /// <summary>
        /// Se ejecuta al cambiar la fecha.  
        /// Solo actúa si el formulario ya terminó de cargar.
        /// </summary>
        private async void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (!_formCargado) return;
            if (cmbEmpleado.SelectedValue == null) return;

            await GenerarCierreAsync();
        }


        /// <summary>
        /// Evento LOAD: carga usuarios, fecha e inicializa bandera de carga.
        /// </summary>
        private async void frmCierreDiario_Load(object sender, EventArgs e)
        {
            dgvCierre.DataSource = new List<CierreDiarioResult>();

            await CargarAliasUsuariosAsync();
            dtpFecha.Value = DateTime.Today;

            _formCargado = true;
        }


        /// <summary>
        /// Al cambiar de empleado, vuelve a generar el cierre diario.
        /// </summary>
        private async void cmbEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_formCargado) return;
            if (cmbEmpleado.SelectedValue == null) return;

            await GenerarCierreAsync();
        }


        /// <summary>
        /// Se llama al cerrar el formulario: elimina la suscripción realtime.
        /// </summary>
        private async void frmCierreDiario_FormClosing(object sender, FormClosingEventArgs e)
        {
            await DesecharSuscripcionVentas();
        }


        // ============================================================
        //  BOTÓN IMPRIMIR CIERRE
        // ============================================================

        /// <summary>
        /// Valida datos cargados y envía el cierre diario
        /// al formulario de impresión.
        /// </summary>
        private void btnImprimirCierre_Click(object sender, EventArgs e)
        {
            var datosCierre = dgvCierre.DataSource as List<CierreDiarioResult>;

            string totalVentas = txtTotalVentas.Text;
            string alias = cmbEmpleado.Text;
            string fecha = dtpFecha.Value.ToShortDateString();

            if (datosCierre == null || !datosCierre.Any())
            {
                MessageBox.Show(
                    "No hay datos cargados para exportar. Por favor, selecciona un empleado y una fecha con ventas.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning
                );
                return;
            }

            using (var frm = new frmImprimirCierre(datosCierre, totalVentas, alias, fecha))
            {
                frm.ShowDialog();
            }
        }


        // ============================================================
        //  BUSCAR EMPLEADO
        // ============================================================

        /// <summary>
        /// Abre el formulario de usuarios para buscar un empleado.
        /// </summary>
        private void btnBuscarEmpleado_Click(object sender, EventArgs e)
        {
            frmUsuario _usuarioCierre = new frmUsuario();
            _usuarioCierre.ShowDialog();
        }
    }
}
