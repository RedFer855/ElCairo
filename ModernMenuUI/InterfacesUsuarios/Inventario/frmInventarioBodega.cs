using CapaDeDatos.Modelados.Inventario;
using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Repositorios;
using CapaDominio.Enums;
using CapaDominio.Servicios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.Adapters;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.ServiciosUI;
using ModernMenuUI.ServiciosUI.GridFormatters;
using System.Data;

namespace ModernMenuUI
{
    public partial class frmInventarioBodega : Form
    {
        private readonly InventarioRepositorio _inventarioRepo = new();
        private readonly BodegaRepositorio _bodegaRepo = new();
        private readonly ServicioPermisosUI _permUI = new();

        private readonly GestorRealtime<Inventario> _rtInventario;
        private readonly GestorRealtime<Bodega> _rtBodega;

        private BuscadorInteractivo<Inventario> _buscador;
        private List<Inventario> _maestro = new();

        public frmInventarioBodega()
        {
            InitializeComponent();

            dgvProducto.AutoGenerateColumns = false;
            dgvProducto.EnableHeadersVisualStyles = false;

            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.SetProperty,
                null, dgvProducto, new object[] { true });

            _rtInventario = new();
            _rtBodega = new();

            _rtInventario.OnCambioBaseDatos += (_) => RecargarUI();
            _rtInventario.OnReconexionExitosa += () => RecargarUI();
            _rtBodega.OnCambioBaseDatos += (_) => RecargarUI();
            _rtBodega.OnReconexionExitosa += () => RecargarUI();

            _permUI.AplicarPermisos();
        }

        private async void frmInventarioBodega_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            await CargarDatos();
            await CargarBodegas();
            ConfigurarComboEstado();

            cmbBodega.SelectedIndexChanged += cmbBodega_SelectedIndexChanged;
            cmbEstado.SelectedIndexChanged += cmbEstado_SelectedIndexChanged;

            txtBodegaActual.Text = ServicioSesionUsuario.ObtenerNombreBodega();

            await _rtInventario.SuscribirAsync();
            await _rtBodega.SuscribirAsync();

            RefrescarGrid();
            this.Cursor = Cursors.Default;
        }

        private async Task CargarDatos()
        {
            _maestro = await _inventarioRepo.ObtenerTodoElInventario();

            _buscador = new BuscadorInteractivo<Inventario>(
                txtBuscar, lstSugerencias, dgvProducto,
                _maestro,
                (i, txt) => i.CodigoBarraProducto != null && i.CodigoBarraProducto.Equals(txt),
                (i, txt) => i.NombreProducto.IndexOf(txt, StringComparison.OrdinalIgnoreCase) >= 0,
                (i) => $"{i.NombreProducto} [{i.CodigoBarraProducto}]",
                (activo) => { pnlLimpiarFiltros.Visible = activo; if (!activo) RefrescarGrid(); },
                (txt) => txt.All(char.IsDigit));

            RefrescarGrid();
        }

        private async Task RecargarDatos()
        {
            _maestro = await _inventarioRepo.ObtenerTodoElInventario();
            _buscador.ActualizarDatosMaestros(_maestro);
            RefrescarGrid();
        }

        private void RecargarUI()
        {
            if (IsHandleCreated)
                BeginInvoke(async () => await RecargarDatos());
        }

        private async Task CargarBodegas()
        {
            var lista = await _bodegaRepo.ObtenerTodasLasBodegasAsync();
            lista.Insert(0, new Bodega { IdBodega = 0, NombreBodega = "Todas las bodegas" });

            cmbBodega.SelectedIndexChanged -= cmbBodega_SelectedIndexChanged;

            cmbBodega.DataSource = lista;
            cmbBodega.DisplayMember = "NombreBodega";
            cmbBodega.ValueMember = "IdBodega";
            cmbBodega.SelectedIndex = 0;

            cmbBodega.SelectedIndexChanged += cmbBodega_SelectedIndexChanged;
        }

        private void ConfigurarComboEstado()
        {
            cmbEstado.SelectedIndexChanged -= cmbEstado_SelectedIndexChanged;

            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("Todos");
            cmbEstado.Items.Add("Crítico");
            cmbEstado.Items.Add("Advertencia");
            cmbEstado.Items.Add("Normal");
            cmbEstado.SelectedIndex = 0;

            cmbEstado.SelectedIndexChanged += cmbEstado_SelectedIndexChanged;
        }

        private void cmbBodega_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefrescarGrid();
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefrescarGrid();
        }

        private EstadoStock EstadoDominio(Inventario inv)
        {
            var dom = InventarioAdapter.Map(inv);
            return EvaluadorStock.ObtenerEstado(dom);
        }

        private void RefrescarGrid()
        {
            if (_maestro == null) return;

            var lista = _maestro.AsEnumerable();

            int idBodega = 0;

            if (cmbBodega.SelectedValue is int vd)
                idBodega = vd;
            else if (cmbBodega.SelectedItem is Bodega b)
                idBodega = b.IdBodega;

            if (idBodega != 0)
                lista = lista.Where(x => x.IdBodegaInventario == idBodega);

            switch (cmbEstado.SelectedIndex)
            {
                case 1:
                    lista = lista.Where(x => EstadoDominio(x) == EstadoStock.Critico);
                    break;
                case 2:
                    lista = lista.Where(x => EstadoDominio(x) == EstadoStock.Advertencia);
                    break;
                case 3:
                    lista = lista.Where(x => EstadoDominio(x) == EstadoStock.Normal);
                    break;
            }

            dgvProducto.DataSource = lista.ToList();

            if (dgvProducto.Rows.Count > 0)
                dgvProducto.ClearSelection();
        }

        private void dgvProducto_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            InventarioGridFormatter.AplicarFormato(dgvProducto.Rows[e.RowIndex]);
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            cmbEstado.SelectedIndex = 0;
            cmbBodega.SelectedIndex = 0;
            _buscador.LimpiarBusqueda();
            RefrescarGrid();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            clsAnmaciones.NombreMenuPrincipal();
            Close();
        }
    }
}
