using CapaDeAplicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI.ServiciosUI
{
    public class BuscadorInteractivo<T> where T : class
    {
        // --- CONTROLES ---
        private readonly TextBox _txtBuscar;
        private readonly ListBox _lstSugerencias;
        private readonly DataGridView _dgvResultados;

        // --- LÓGICA Y VARIABLES ---
        private GestorBusqueda<T> _gestorLogico;
        private CancellationTokenSource _cts;

        // --- DELEGADOS ---
        private readonly Func<T, string, bool> _criterioExacto;
        private readonly Func<T, string, bool> _criterioParcial;
        private readonly Func<T, string> _formatoVisualLista;
        private readonly Action<bool> _notificadorEstado;
        private readonly Func<string, bool> _detectorCodigoBarra;

        // --- CONSTRUCTOR ---
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
            _gestorLogico = new GestorBusqueda<T>(nuevosDatos);
        }

        // --- EVENTO 1: KeyUp (Manual) ---
        public async Task ManejarKeyUpAsync(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down) return;

            // 1. Cancelamos cualquier búsqueda anterior
            _cts?.Cancel();
            _cts = new CancellationTokenSource();

            try
            {
                // 2. Esperamos 300ms
                await Task.Delay(300, _cts.Token);

                // 3. Ejecutamos búsqueda (Mostrar Sugerencias)
                EjecutarBusqueda(forzarGrid: false);
            }
            catch (TaskCanceledException) { }
        }

        // --- EVENTO 2: KeyDown (Escáner/Navegación) ---
        public void ManejarKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // 1. Matar timer pendiente
                _cts?.Cancel();

                // 2. Decidir acción:
                bool esCodigo = _detectorCodigoBarra != null && _detectorCodigoBarra(_txtBuscar.Text.Trim());

                if (!_lstSugerencias.Visible || esCodigo)
                {
                    EjecutarBusqueda(forzarGrid: true);
                }
                else
                {
                    ConfirmarSeleccion();
                }

                e.SuppressKeyPress = true;
                e.Handled = true;
                return;
            }

            // Navegación flechas
            if (_lstSugerencias.Visible)
            {
                if (e.KeyCode == Keys.Down)
                {
                    int next = Math.Min(_lstSugerencias.SelectedIndex + 1, _lstSugerencias.Items.Count - 1);
                    if (next >= 0) _lstSugerencias.SelectedIndex = next;
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Up)
                {
                    int prev = Math.Max(_lstSugerencias.SelectedIndex - 1, 0);
                    if (prev >= 0) _lstSugerencias.SelectedIndex = prev;
                    e.Handled = true;
                }
            }
        }

        public void ManejarClickLista() => ConfirmarSeleccion();

        public async void ManejarLeave()
        {
            await Task.Delay(200);
            if (!_lstSugerencias.Focused) _lstSugerencias.Visible = false;
        }

        // --- LÓGICA PRIVADA ---
        private void EjecutarBusqueda(bool forzarGrid)
        {
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
                    _dgvResultados.DataSource = resultados;
                    _lstSugerencias.Visible = false;
                    _notificadorEstado?.Invoke(true); // Mostrar botón limpiar

                    // CAMBIO: Si encontró algo con escáner/Enter, limpiamos la caja también
                    _txtBuscar.Clear();
                }
                else
                {
                    // Mostrar Sugerencias
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
                if (forzarGrid) MessageBox.Show("No se encontraron resultados.");
            }
        }

        private void ConfirmarSeleccion()
        {
            if (_lstSugerencias.SelectedItem is T seleccionado)
            {
                // CAMBIO PRINCIPAL: En vez de poner texto, lo borramos
                _txtBuscar.Clear();

                // Llenamos el grid con la selección
                _dgvResultados.DataSource = new List<T> { seleccionado };

                _notificadorEstado?.Invoke(true);

                _lstSugerencias.Visible = false;
                _cts?.Cancel();
            }
        }

        public void LimpiarBusqueda()
        {
            _txtBuscar.Clear();
            _lstSugerencias.Visible = false;
            _notificadorEstado?.Invoke(false);
        }
    }
}