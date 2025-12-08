using CapaDeDatos.Modelados.Inventario;
using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Repositorios;
using CapaDominio.Enums;
using CapaDominio.Servicios;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI.Adapters;
using ModernMenuUI.ClasesUI;
using ModernMenuUI.ClasesUI.Extenciones;
using ModernMenuUI.InterfacesUsuarios.Inventario;
using ModernMenuUI.ServiciosUI;
using ModernMenuUI.ServiciosUI.GridFormatters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            dgvProducto.ActivarDobleBuffer();

            this.FormClosing += frmInventarioBodega_FormClosing;

            _rtInventario = new();
            _rtBodega = new();

            _rtInventario.OnCambioBaseDatos += (_) => RecargarUI();
            _rtInventario.OnReconexionExitosa += () => RecargarUI();
            _rtBodega.OnCambioBaseDatos += (_) => RecargarUI();
            _rtBodega.OnReconexionExitosa += () => RecargarUI();

            _permUI.AplicarPermisos();
            _permUI.RegistrarBoton(btnCambiarBodega, "update_inventario");
            _permUI.RegistrarBoton(btnCrearBodega, "update_inventario");
        }

        private async void frmInventarioBodega_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            await CargarDatos();
            await CargarBodegas();
            ConfigurarComboEstado();
            ConectarEventosUI();

            txtBodegaActual.Text = ServicioSesionUsuario.ObtenerNombreBodega();

            await _rtInventario.SuscribirAsync();
            await _rtBodega.SuscribirAsync();

            RefrescarGrid();
            Cursor = Cursors.Default;
        }

        private async void frmInventarioBodega_FormClosing(object sender, FormClosingEventArgs e)
        {
            try { await _rtInventario.DesuscribirAsync(); } catch { }
            try { await _rtBodega.DesuscribirAsync(); } catch { }
        }

        private async Task CargarDatos()
        {
            _maestro = await _inventarioRepo.ObtenerTodoElInventario();

            _buscador = new BuscadorInteractivo<Inventario>(
                txtBuscar,
                lstSugerencias,
                dgvProducto,
                _maestro,
                (i, txt) => !string.IsNullOrWhiteSpace(i.CodigoBarraProducto) && i.CodigoBarraProducto.Equals(txt, StringComparison.OrdinalIgnoreCase),
                (i, txt) =>
                {
                    txt = txt.ToLowerInvariant();
                    string blob = $"{i.NombreProducto} {i.NombreMarca} {i.NombreCategoria} {i.NombrePresentacion} {i.ContenidoProducto}";
                    return !string.IsNullOrWhiteSpace(blob) && blob.ToLowerInvariant().Contains(txt);
                },
                (i) => $"{i.NombreProducto} {(string.IsNullOrEmpty(i.CodigoBarraProducto) ? "" : $"[{i.CodigoBarraProducto}]")} {i.NombreMarca} {i.NombrePresentacion}",
                (activo) =>
                {
                    pnlLimpiarFiltros.Visible = activo;
                    if (!activo) RefrescarGrid();
                },
                (txt) => txt.All(char.IsDigit) && txt.Length >= 8 && txt.Length <= 13
            );

            RefrescarGrid();
        }

        private async Task RecargarDatos()
        {
            _maestro = await _inventarioRepo.ObtenerTodoElInventario();
            _buscador?.ActualizarDatosMaestros(_maestro);
            RefrescarGrid();
        }

        private void RecargarUI()
        {
            if (!IsHandleCreated || IsDisposed) return;

            BeginInvoke(async () =>
            {
                await CargarBodegas();
                await RecargarDatos();
                RefrescarGrid();
            });
        }

        private async Task CargarBodegas()
        {
            var selected = cmbBodega.SelectedValue;

            var lista = await _bodegaRepo.ObtenerTodasLasBodegasAsync();
            lista.Insert(0, new Bodega { IdBodega = 0, NombreBodega = "Todas las bodegas" });

            cmbBodega.SelectedIndexChanged -= cmbBodega_SelectedIndexChanged;

            cmbBodega.DataSource = null;
            cmbBodega.DataSource = lista;
            cmbBodega.DisplayMember = "NombreBodega";
            cmbBodega.ValueMember = "IdBodega";

            if (selected != null)
            {
                if (int.TryParse(selected.ToString(), out int idSel) && lista.Any(b => b.IdBodega == idSel))
                    cmbBodega.SelectedValue = idSel;
                else
                    cmbBodega.SelectedIndex = 0;
            }
            else
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

        private void ConectarEventosUI()
        {
            cmbBodega.SelectedIndexChanged -= cmbBodega_SelectedIndexChanged;
            cmbBodega.SelectedIndexChanged += cmbBodega_SelectedIndexChanged;

            cmbEstado.SelectedIndexChanged -= cmbEstado_SelectedIndexChanged;
            cmbEstado.SelectedIndexChanged += cmbEstado_SelectedIndexChanged;

            txtBuscar.KeyUp -= txtBuscar_KeyUp;
            txtBuscar.KeyUp += txtBuscar_KeyUp;

            txtBuscar.KeyDown -= txtBuscar_KeyDown;
            txtBuscar.KeyDown += txtBuscar_KeyDown;

            txtBuscar.Leave -= txtBuscar_Leave;
            txtBuscar.Leave += txtBuscar_Leave;

            lstSugerencias.MouseClick -= lstSugerencias_MouseClick;
            lstSugerencias.MouseClick += lstSugerencias_MouseClick;

            lstSugerencias.KeyDown -= lstSugerencias_KeyDown;
            lstSugerencias.KeyDown += lstSugerencias_KeyDown;

            btnBuscar.Click -= btnBuscar_Click;
            btnBuscar.Click += btnBuscar_Click;
        }

        private void cmbBodega_SelectedIndexChanged(object sender, EventArgs e) => RefrescarGrid();
        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e) => RefrescarGrid();

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e) => _ = _buscador?.ManejarKeyUpAsync(e);
        private void txtBuscar_KeyDown(object sender, KeyEventArgs e) => _buscador?.ManejarKeyDown(e);
        private void txtBuscar_Leave(object sender, EventArgs e) => _buscador?.ManejarLeave();
        private void lstSugerencias_MouseClick(object sender, MouseEventArgs e) => _buscador?.ManejarClickLista();
        private void lstSugerencias_KeyDown(object sender, KeyEventArgs e) { if (e.KeyCode == Keys.Enter) _buscador?.ManejarClickLista(); }
        private void btnBuscar_Click(object sender, EventArgs e) => _buscador?.ManejarKeyDown(new KeyEventArgs(Keys.Enter));

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
            try
            {
                if (cmbBodega.SelectedValue is int vd) idBodega = vd;
                else if (cmbBodega.SelectedItem is Bodega b) idBodega = b.IdBodega;
                else if (cmbBodega.SelectedValue != null) int.TryParse(cmbBodega.SelectedValue.ToString(), out idBodega);
            }
            catch { idBodega = 0; }

            bool filtroBodegaActivo = idBodega != 0;
            if (filtroBodegaActivo) lista = lista.Where(x => x.IdBodegaInventario == idBodega);

            bool filtroEstadoActivo = cmbEstado.SelectedIndex != 0;
            if (filtroEstadoActivo)
            {
                switch (cmbEstado.SelectedIndex)
                {
                    case 1: lista = lista.Where(x => EstadoDominio(x) == EstadoStock.Critico); break;
                    case 2: lista = lista.Where(x => EstadoDominio(x) == EstadoStock.Advertencia); break;
                    case 3: lista = lista.Where(x => EstadoDominio(x) == EstadoStock.Normal); break;
                }
            }

            var resultado = lista.ToList();

            dgvProducto.DataSource = null;
            dgvProducto.DataSource = resultado;

            if (dgvProducto.Rows.Count > 0) dgvProducto.ClearSelection();

            pnlLimpiarFiltros.Visible = filtroBodegaActivo || filtroEstadoActivo;
        }

        private void dgvProducto_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            InventarioGridFormatter.AplicarFormato(dgvProducto.Rows[e.RowIndex]);
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            _buscador?.LimpiarBusqueda();

            if (cmbBodega.Items.Count > 0) cmbBodega.SelectedIndex = 0;
            cmbEstado.SelectedIndex = 0;

            pnlLimpiarFiltros.Visible = false;

            RefrescarGrid();
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
            if (res == DialogResult.OK)
            {
                await CargarBodegas();
                await RecargarDatos();
            }
        }
    }
}
