using CapaDeDatos.Modelados;
using CapaDeDatos.Repositorios;
using Supabase;
using Supabase.Postgrest.Models;
using Supabase.Postgrest.Responses;
using Supabase.Realtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ModernMenuUI
{
    public partial class frmEmpleados : Form
    {
        private readonly EmpleadoRepositorio _empleadoRepo;

        public frmEmpleados()
        {
            InitializeComponent();
            dgvEmpleados.AutoGenerateColumns = false;
            _empleadoRepo = new EmpleadoRepositorio();
           
        }

        private async void frmEmpleados_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
            var supabase = await CapaDeDatos.Datos.Conexion.GetClientAsync();

            if (supabase != null)
            {
                MessageBox.Show("Conexión exitosa al servidor.", "Conexión Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                this.Close();
            }
        }

        private async void CargarEmpleados()
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

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            // Hacemos que "Nuevo" haga lo mismo que "Agregar"
            /*frmAgregarEmpleado Empleados = new frmAgregarEmpleado();
            Empleados.ShowDialog();

            // Refresca la lista después de cerrar el diálogo
            CargarEmpleados();*/
            var supabase = await CapaDeDatos.Datos.Conexion.GetClientAsync();
            var session = supabase.Auth.CurrentSession;
            MessageBox.Show(session?.User?.Id);
        }
    }
}