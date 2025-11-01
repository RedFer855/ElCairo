using CapaDeDatos.Modelados;
using CapaDeDatos.Repositorios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
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