using CapaDeDatos.Datos;
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
using Org.BouncyCastle.Crypto.Digests;
using Supabase.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ModernMenuUI.InterfacesUsuarios.Inventario
{
    public partial class frmBodegas : Form
    {
        private readonly BodegaRepositorio _bodegaRepo = new();
        private readonly GestorRealtime<Bodega> _rtBodega = new();
        public frmBodegas()
        {
            InitializeComponent();
            dgvProducto.AutoGenerateColumns = false;
            dgvProducto.EnableHeadersVisualStyles = false;
            dgvProducto.ActivarDobleBuffer();

            this.FormClosing += frmBodegas_FormClosing;

            _rtBodega.OnCambioBaseDatos += (_) => RecargarUI();
            _rtBodega.OnReconexionExitosa += () => RecargarUI();
        }
        private async void frmBodegas_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            await CargarBodegas();
            await _rtBodega.SuscribirAsync();
            this.Cursor = Cursors.Default;
        }
        private async Task CargarBodegas()
        {
            var lista = await _bodegaRepo.obtenerBodegas();

            dgvProducto.DataSource = null;
            dgvProducto.Columns.Clear();
            //dgvProducto.CellFormatting -= dgvProducto_CellFormatting;
            dgvProducto.AutoGenerateColumns = false;

            dgvProducto.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Bodega",
                DataPropertyName = "NombreBodega"
            });
            dgvProducto.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Departamento",
                DataPropertyName = "NombreDepartamento"
            });
            dgvProducto.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Dirección",
                DataPropertyName = "DireccionSucursal"
            });
            dgvProducto.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Teléfono",
                DataPropertyName = "TelefonoSucursal"
            });
            dgvProducto.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                HeaderText = "Estado",
                DataPropertyName = "EstadoBodega"
            });

            dgvProducto.DataSource = lista;

            if (dgvProducto.Rows.Count > 0)
                dgvProducto.ClearSelection();

        }
        private void RecargarUI()
        {
            if (!IsHandleCreated || IsDisposed) return;
            BeginInvoke(async () => await CargarBodegas());
        }

        private async void frmBodegas_FormClosing(object sender, FormClosingEventArgs e)
        {
            try { await _rtBodega.DesuscribirAsync(); } catch { }
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
                //await RecargarDatos();
            }
        }
    }
}
