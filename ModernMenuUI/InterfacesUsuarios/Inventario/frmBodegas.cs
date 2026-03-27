using CapaDeDatos.Modelados.Inventario;
using CapaDeDatos.Repositorios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.ClasesUI.Extenciones;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI.InterfacesUsuarios.Inventario
{
    public partial class frmBodegas : Form
    {
        private readonly BodegaRepositorio _bodegaRepo = new();

        private bool _cerrandoFormulario = false;
        private bool _columnasConfiguradas = false;

        private Action<Supabase.Realtime.PostgresChanges.PostgresChangesResponse>? _handlerCambioBD;

        public frmBodegas()
        {
            InitializeComponent();

            dgvProducto.AutoGenerateColumns = false;
            dgvProducto.EnableHeadersVisualStyles = false;
            dgvProducto.ActivarDobleBuffer();

            ConfigurarColumnasGrid();

            this.FormClosed += frmBodegas_FormClosed;

            _handlerCambioBD = (_) => RecargarUI();
            RealtimeManager.OnBodegaChanged += _handlerCambioBD;
        }

        private void ConfigurarColumnasGrid()
        {
            if (_columnasConfiguradas) return;

            dgvProducto.Columns.Clear();
            dgvProducto.AutoGenerateColumns = false;

            dgvProducto.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colBodega",
                HeaderText = "Bodega",
                DataPropertyName = "NombreBodega"
            });

            dgvProducto.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colDepartamento",
                HeaderText = "Departamento",
                DataPropertyName = "NombreDepartamento"
            });

            dgvProducto.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colDireccion",
                HeaderText = "Dirección",
                DataPropertyName = "DireccionSucursal"
            });

            dgvProducto.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colTelefono",
                HeaderText = "Teléfono",
                DataPropertyName = "TelefonoSucursal"
            });

            dgvProducto.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                Name = "colEstado",
                HeaderText = "Estado",
                DataPropertyName = "EstadoBodega"
            });

            _columnasConfiguradas = true;
        }

        private async void frmBodegas_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                await RealtimeManager.IniciarAsync();
                await CargarBodegas();
            }
            finally
            {
                if (!IsDisposed)
                    this.Cursor = Cursors.Default;
            }
        }

        private async Task CargarBodegas()
        {
            if (_cerrandoFormulario || IsDisposed) return;

            var lista = await _bodegaRepo.obtenerBodegas();

            if (_cerrandoFormulario || IsDisposed) return;

            dgvProducto.SuspendLayout();
            try
            {
                dgvProducto.DataSource = null;
                dgvProducto.DataSource = lista;

                if (dgvProducto.Rows.Count > 0)
                    dgvProducto.ClearSelection();
            }
            finally
            {
                dgvProducto.ResumeLayout();
            }
        }

        private void RecargarUI()
        {
            if (_cerrandoFormulario || !IsHandleCreated || IsDisposed) return;

            try
            {
                BeginInvoke((MethodInvoker)(async () =>
                {
                    if (_cerrandoFormulario || IsDisposed) return;
                    await CargarBodegas();
                }));
            }
            catch
            {
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            Close();
        }

        private async void btnCrearBodega_Click(object sender, EventArgs e)
        {
            using var frm = new frmAgregarEditarBodega();
            var res = frm.ShowDialog();

            if (res == DialogResult.OK && !_cerrandoFormulario && !IsDisposed)
            {
                await CargarBodegas();
            }
        }

        private void frmBodegas_FormClosed(object sender, FormClosedEventArgs e)
        {
            _cerrandoFormulario = true;

            try
            {
                if (_handlerCambioBD != null)
                    RealtimeManager.OnBodegaChanged -= _handlerCambioBD;
            }
            catch
            {
            }

            _handlerCambioBD = null;
            dgvProducto.DataSource = null;
        }
    }
}