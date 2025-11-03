using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using CapaDeDatos.Repositorios;
using Supabase;
using Supabase.Realtime;
using Supabase.Realtime.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Websocket.Client;
using static Supabase.Realtime.PostgresChanges.PostgresChangesOptions;


namespace ModernMenuUI
{
    
    public partial class frmEmpleados : Form
    {
        private readonly EmpleadoRepositorio _empleadoRepo;
        private Supabase.Realtime.RealtimeChannel? _empleadoSubscription;

        public frmEmpleados()
        {
            InitializeComponent();
            dgvEmpleados.AutoGenerateColumns = false;
            _empleadoRepo = new EmpleadoRepositorio();
        }

        
        private async void FrmEmpleados_Load(object sender, EventArgs e)
        {
            await CargarEmpleados(); // Ahora llamamos con await

            await IniciarSuscripcionEmpleados();

        }

       
        private async Task IniciarSuscripcionEmpleados()
        {

            var client = await Conexion.ConnectWithTimeoutAsync(10);


            _empleadoSubscription = await client.From<Empleado>().On(ListenType.All, (sender, change) =>
            {
                
                this.Invoke((MethodInvoker)(async () =>
                {
                    // Lógica para recargar la lista en caso de cualquier cambio (INSERT, UPDATE, DELETE)
                    System.Diagnostics.Debug.WriteLine($"Cambio detectado: {change.Event} en la tabla Empleados.");
                    await CargarEmpleados();
                }));
            });
        }

        private async Task CargarEmpleados()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                List<Empleado> listaDeEmpleados = await _empleadoRepo.ObtenerTodosLosEmpleados();
                dgvEmpleados.DataSource = null;
                dgvEmpleados.DataSource = listaDeEmpleados;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            this.Close();
        }

        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            frmAgregarEmpleado Empleados = new frmAgregarEmpleado();
            Empleados.ShowDialog();

            // Refresca la lista después de cerrar el diálogo
            CargarEmpleados();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // Hacemos que "Nuevo" haga lo mismo que "Agregar"
            frmAgregarEmpleado Empleados = new frmAgregarEmpleado();
            Empleados.ShowDialog();

            // Refresca la lista después de cerrar el diálogo
            CargarEmpleados();
        }

        private void dgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}