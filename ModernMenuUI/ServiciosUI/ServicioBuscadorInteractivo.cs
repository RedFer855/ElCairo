namespace ModernMenuUI.ServiciosUI
{
    using CapaDeAplicacion;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    // =========================================================
    // BUSCADOR INTERACTIVO CORREGIDO
    // =========================================================
    public class BuscadorInteractivo<T> where T : class
    {
        private readonly TextBox _txtBuscar;
        private readonly ListBox _lstSugerencias;
        private readonly DataGridView _dgvResultados;

        private GestorBusqueda<T> _gestorLogico;
        private CancellationTokenSource _cts;

        private readonly Func<T, string, bool> _criterioExacto;
        private readonly Func<T, string, bool> _criterioParcial;
        private readonly Func<T, string> _formatoVisualLista;
        private readonly Action<bool> _notificadorEstado;
        private readonly Func<string, bool> _detectorCodigoBarra;

        private bool _liberado = false;

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
            if (_liberado) return;
            _gestorLogico = new GestorBusqueda<T>(nuevosDatos);
        }

        public async Task ManejarKeyUpAsync(KeyEventArgs e)
        {
            if (_liberado) return;
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                return;

            // Antes solo cancelaba; ahora también dispone
            _cts?.Cancel();
            _cts?.Dispose();
            _cts = new CancellationTokenSource();

            try
            {
                await Task.Delay(300, _cts.Token);
                if (_liberado) return;
                EjecutarBusqueda(false);
            }
            catch (TaskCanceledException)
            {
            }
            catch (ObjectDisposedException)
            {
            }
        }

        public void ManejarKeyDown(KeyEventArgs e)
        {
            if (_liberado) return;

            if (e.KeyCode == Keys.Enter)
            {
                _cts?.Cancel();
                _cts?.Dispose();
                _cts = null;

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
                    int siguiente = Math.Min(_lstSugerencias.SelectedIndex + 1, _lstSugerencias.Items.Count - 1);
                    if (siguiente >= 0)
                        _lstSugerencias.SelectedIndex = siguiente;

                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Up)
                {
                    int anterior = Math.Max(_lstSugerencias.SelectedIndex - 1, 0);
                    if (anterior >= 0)
                        _lstSugerencias.SelectedIndex = anterior;

                    e.Handled = true;
                }
            }
        }

        public void ManejarClickLista()
        {
            if (_liberado) return;
            ConfirmarSeleccion();
        }

        public async void ManejarLeave()
        {
            if (_liberado) return;

            try
            {
                await Task.Delay(200);
                if (_liberado) return;

                if (!_lstSugerencias.Focused)
                    _lstSugerencias.Visible = false;
            }
            catch
            {
            }
        }

        private void EjecutarBusqueda(bool forzarGrid)
        {
            if (_liberado || _gestorLogico == null) return;

            var texto = _txtBuscar.Text.Trim();
            bool hayTexto = !string.IsNullOrEmpty(texto);

            if (!hayTexto)
            {
                _lstSugerencias.Visible = false;
                return;
            }

            var resultados = _gestorLogico.Buscar(texto, _criterioExacto, _criterioParcial);

            if (resultados.Count > 0)
            {
                if (forzarGrid)
                {
                    // Quitar referencia anterior antes de reasignar
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
                    _lstSugerencias.DisplayMember = "";

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
            if (_liberado) return;

            if (_lstSugerencias.SelectedItem is T seleccionado)
            {
                _txtBuscar.Clear();

                _dgvResultados.DataSource = null;
                _dgvResultados.DataSource = new List<T> { seleccionado };

                _notificadorEstado?.Invoke(true);

                _lstSugerencias.Visible = false;

                _cts?.Cancel();
                _cts?.Dispose();
                _cts = null;
            }
        }

        public void LimpiarBusqueda()
        {
            if (_liberado) return;

            _txtBuscar.Clear();
            _lstSugerencias.Visible = false;
            _notificadorEstado?.Invoke(false);
        }

        public void Liberar()
        {
            if (_liberado) return;
            _liberado = true;

            try
            {
                _cts?.Cancel();
                _cts?.Dispose();
                _cts = null;
            }
            catch
            {
            }

            try
            {
                _lstSugerencias.DataSource = null;
                _dgvResultados.DataSource = null;
            }
            catch
            {
            }

            _gestorLogico = null;
        }
    }
}