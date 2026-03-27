using CapaDeAplicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI.ServiciosUI
{
    public class BuscadorInteractivo<T> : IDisposable where T : class
    {
        private TextBox _txtBuscar;
        private ListBox _lstSugerencias;
        private DataGridView _dgvResultados;

        private GestorBusqueda<T> _gestorLogico;
        private CancellationTokenSource _cts;

        private readonly Func<T, string, bool> _criterioExacto;
        private readonly Func<T, string, bool> _criterioParcial;
        private readonly Func<T, string> _formatoVisualLista;
        private readonly Action<bool> _notificadorEstado;
        private readonly Func<string, bool> _detectorCodigoBarra;

        private bool _disposed = false;

        public BuscadorInteractivo(
            TextBox txt,
            ListBox lst,
            DataGridView dgv,
            IEnumerable<T> datosIniciales,
            Func<T, string, bool> criterioExacto,
            Func<T, string, bool> criterioParcial,
            Func<T, string> formatoVisualLista,
            Action<bool> notificadorEstado = null,
            Func<string, bool> detectorCodigoBarra = null)
        {
            _txtBuscar = txt;
            _lstSugerencias = lst;
            _dgvResultados = dgv;

            _criterioExacto = criterioExacto;
            _criterioParcial = criterioParcial;
            _formatoVisualLista = formatoVisualLista;
            _notificadorEstado = notificadorEstado;
            _detectorCodigoBarra = detectorCodigoBarra;

            ActualizarDatosMaestros(datosIniciales);
        }

        public void ActualizarDatosMaestros(IEnumerable<T> nuevosDatos)
        {
            if (_disposed) return;
            _gestorLogico = new GestorBusqueda<T>(nuevosDatos);
        }

        public async Task ManejarKeyUpAsync(KeyEventArgs e)
        {
            if (_disposed) return;
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down) return;

            _cts?.Cancel();
            _cts?.Dispose();
            _cts = new CancellationTokenSource();

            try
            {
                await Task.Delay(300, _cts.Token);

                if (_disposed) return;

                EjecutarBusqueda(false);
            }
            catch (TaskCanceledException)
            {
            }
        }

        public void ManejarKeyDown(KeyEventArgs e)
        {
            if (_disposed) return;

            if (e.KeyCode == Keys.Enter)
            {
                _cts?.Cancel();

                bool esCodigo = _detectorCodigoBarra != null && _detectorCodigoBarra(_txtBuscar.Text.Trim());

                if (!_lstSugerencias.Visible || esCodigo)
                    EjecutarBusqueda(true);
                else
                    ConfirmarSeleccion();

                e.SuppressKeyPress = true;
                e.Handled = true;
                return;
            }

            if (_lstSugerencias.Visible)
            {
                if (e.KeyCode == Keys.Down)
                {
                    int next = Math.Min(_lstSugerencias.SelectedIndex + 1, _lstSugerencias.Items.Count - 1);
                    if (next >= 0)
                        _lstSugerencias.SelectedIndex = next;

                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Up)
                {
                    int prev = Math.Max(_lstSugerencias.SelectedIndex - 1, 0);
                    if (prev >= 0)
                        _lstSugerencias.SelectedIndex = prev;

                    e.Handled = true;
                }
            }
        }

        public void ManejarClickLista()
        {
            ConfirmarSeleccion();
        }

        public async void ManejarLeave()
        {
            try
            {
                await Task.Delay(200);

                if (_disposed) return;
                if (_lstSugerencias == null) return;

                if (!_lstSugerencias.Focused)
                    _lstSugerencias.Visible = false;
            }
            catch
            {
            }
        }

        private void EjecutarBusqueda(bool forzarGrid)
        {
            if (_disposed) return;
            if (_gestorLogico == null) return;
            if (_txtBuscar == null || _lstSugerencias == null || _dgvResultados == null) return;

            var texto = _txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(texto))
            {
                _lstSugerencias.Visible = false;
                return;
            }

            var resultados = _gestorLogico.Buscar(texto, _criterioExacto, _criterioParcial);

            if (resultados.Count > 0)
            {
                if (forzarGrid)
                {
                    _dgvResultados.DataSource = null;
                    _dgvResultados.DataSource = resultados;

                    _lstSugerencias.Visible = false;
                    _notificadorEstado?.Invoke(true);
                    _txtBuscar.Clear();
                }
                else
                {
                    _lstSugerencias.DataSource = null;
                    _lstSugerencias.DataSource = resultados.Take(10).ToList();

                    int cantidad = Math.Min(resultados.Count, 10);
                    _lstSugerencias.Height = (_lstSugerencias.ItemHeight * cantidad) + 10;
                    _lstSugerencias.Visible = true;
                }
            }
            else
            {
                _lstSugerencias.Visible = false;

                if (forzarGrid)
                {
                    MessageBox.Show(
                        "No se encontraron resultados.",
                        "Información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
        }

        private void ConfirmarSeleccion()
        {
            if (_disposed) return;
            if (_lstSugerencias == null || _dgvResultados == null || _txtBuscar == null) return;

            if (_lstSugerencias.SelectedItem is T seleccionado)
            {
                _txtBuscar.Clear();
                _dgvResultados.DataSource = null;
                _dgvResultados.DataSource = new List<T> { seleccionado };

                _notificadorEstado?.Invoke(true);
                _lstSugerencias.Visible = false;

                _cts?.Cancel();
            }
        }

        public void LimpiarBusqueda()
        {
            if (_disposed) return;
            if (_txtBuscar == null || _lstSugerencias == null) return;

            _txtBuscar.Clear();
            _lstSugerencias.Visible = false;
            _notificadorEstado?.Invoke(false);
        }

        public void Dispose()
        {
            if (_disposed) return;

            _cts?.Cancel();
            _cts?.Dispose();
            _cts = null;

            _txtBuscar = null;
            _lstSugerencias = null;
            _dgvResultados = null;
            _gestorLogico = null;

            _disposed = true;
            GC.SuppressFinalize(this);
        }
    }
}