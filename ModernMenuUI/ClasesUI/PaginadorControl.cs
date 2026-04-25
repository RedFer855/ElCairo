using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI.ClasesUI
{
    public partial class PaginadorControl : UserControl
    {
        private int _paginaActual = 1;
        private int _totalPaginas = 1;
        private long _totalRegistros = 0;
        private int _tamanioPagina = 100;

        public event EventHandler<int> PaginaCambiada;
        public event EventHandler<int> TamanioPaginaCambiado;

        public int PaginaActual => _paginaActual;
        public int TamanioPagina => _tamanioPagina;

        public PaginadorControl()
        {
            InitializeComponent();

            // ✅ Agregar items como enteros, no como strings
            cmbTamanioPagina.Items.Clear();
            cmbTamanioPagina.Items.AddRange(new object[] { 50, 100, 200, 500 });
            cmbTamanioPagina.SelectedItem = 100;

            // Suscribir eventos
            btnPrimera.Click += (s, e) => SolicitarPagina(1);
            btnAnterior.Click += (s, e) => SolicitarPagina(_paginaActual - 1);
            btnSiguiente.Click += (s, e) => SolicitarPagina(_paginaActual + 1);
            btnUltima.Click += (s, e) => SolicitarPagina(_totalPaginas);
            cmbTamanioPagina.SelectedIndexChanged += CmbTamanioPagina_SelectedIndexChanged;
        }

        private void CmbTamanioPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTamanioPagina.SelectedItem is int nuevoTamanio
                && nuevoTamanio != _tamanioPagina)
            {
                _tamanioPagina = nuevoTamanio;
                TamanioPaginaCambiado?.Invoke(this, nuevoTamanio);
            }
        }

        private void SolicitarPagina(int pagina)
        {
            if (pagina < 1 || pagina > _totalPaginas || pagina == _paginaActual)
                return;

            PaginaCambiada?.Invoke(this, pagina);
        }

        /// <summary>
        /// Llamado desde el formulario tras recibir resultado del repositorio.
        /// </summary>
        public void Actualizar(int paginaActual, int totalPaginas, long totalRegistros)
        {
            _paginaActual = paginaActual;
            _totalPaginas = Math.Max(totalPaginas, 1);
            _totalRegistros = totalRegistros;

            lblInfo.Text = $"Página {paginaActual} de {_totalPaginas}  •  {totalRegistros:N0} registros";

            btnPrimera.Enabled = paginaActual > 1;
            btnAnterior.Enabled = paginaActual > 1;
            btnSiguiente.Enabled = paginaActual < _totalPaginas;
            btnUltima.Enabled = paginaActual < _totalPaginas;
        }
    }
}