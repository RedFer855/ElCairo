using CapaDeAplicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernMenuUI.ServiciosUI
{
    public class BuscadorInteractivo<T> where T : class
    {
        // Controles que vamos a manipular
        private readonly TextBox _txtBuscar;
        private readonly ListBox _lstSugerencias;
        private readonly DataGridView _dgvResultados;

        // Lógica
        private GestorBusqueda<T> _gestorLogico;
        private CancellationTokenSource _cts;

        // Configuraciones (Delegados)
        private readonly Func<T, string, bool> _criterioExacto;
        private readonly Func<T, string, bool> _criterioParcial;
        private readonly Func<T, string> _formatoVisualLista; // Cómo se ve en el ListBox (ToString)

        public BuscadorInteractivo(
            TextBox txt,
            ListBox lst,
            DataGridView dgv,
            IEnumerable<T> datosIniciales,
            Func<T, string, bool> criterioExacto,
            Func<T, string, bool> criterioParcial,
            Func<T, string> formatoVisualLista) // Personalizar el ToString
        {
            _txtBuscar = txt;
            _lstSugerencias = lst;
            _dgvResultados = dgv;
            _criterioExacto = criterioExacto;
            _criterioParcial = criterioParcial;
            _formatoVisualLista = formatoVisualLista;

            // Inicializar lógica
            ActualizarDatosMaestros(datosIniciales);
        }

        public void ActualizarDatosMaestros(IEnumerable<T> nuevosDatos)
        {
            _gestorLogico = new GestorBusqueda<T>(nuevosDatos);
        }

        // --- EVENTO 1: KeyUp (Escribir con delay) ---
        public async Task ManejarKeyUpAsync(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down) return;

            _cts?.Cancel();
            _cts = new CancellationTokenSource();

            try
            {
                await Task.Delay(300, _cts.Token); // Delay anti-lag
                EjecutarBusqueda();
            }
            catch (TaskCanceledException) { }
        }

        // --- EVENTO 2: KeyDown (Navegar flechas y Enter) ---
        public void ManejarKeyDown(KeyEventArgs e)
        {
            if (!_lstSugerencias.Visible)
            {
                // Si la lista está oculta y dan enter, busca lo que hay en el txt
                if (e.KeyCode == Keys.Enter) EjecutarBusqueda(forzarGrid: true);
                return;
            }

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
            else if (e.KeyCode == Keys.Enter)
            {
                ConfirmarSeleccion();
                e.SuppressKeyPress = true; // Evitar sonido 'ding'
                e.Handled = true;
            }
        }

        // --- EVENTO 3: Click en Lista ---
        public void ManejarClickLista()
        {
            ConfirmarSeleccion();
        }

        // --- EVENTO 4: Perder Foco ---
        public async void ManejarLeave()
        {
            await Task.Delay(200); // Pequeño delay para permitir clic
            if (!_lstSugerencias.Focused) _lstSugerencias.Visible = false;
        }

        // --- LÓGICA PRIVADA ---
        private void EjecutarBusqueda(bool forzarGrid = false)
        {
            var texto = _txtBuscar.Text;
            var resultados = _gestorLogico.Buscar(texto, _criterioExacto, _criterioParcial);

            if (resultados.Count > 0)
            {
                // Mostrar sugerencias
                _lstSugerencias.DataSource = null;
                _lstSugerencias.DataSource = resultados;
                // Aquí usamos el truco para que se vea concatenado sin tocar la clase Producto
                _lstSugerencias.DisplayMember = ""; // Truco para resetear

                // Ajustar altura
                int alturaItem = _lstSugerencias.ItemHeight;
                _lstSugerencias.Height = Math.Min((alturaItem * resultados.Count) + 10, (alturaItem * 10) + 10);
                _lstSugerencias.Visible = true;

                // Si se forzó (ej. Enter en txt), llenamos el grid directo
                if (forzarGrid)
                {
                    _dgvResultados.DataSource = resultados;
                    _lstSugerencias.Visible = false;
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
                // 1. Poner texto en buscador (Opcional: usar el formateador o solo nombre)
                _txtBuscar.Text = _formatoVisualLista(seleccionado);
                _txtBuscar.SelectionStart = _txtBuscar.Text.Length;

                // 2. Llenar Grid con ESE único elemento
                _dgvResultados.DataSource = new List<T> { seleccionado };

                // 3. Limpiar UI
                _lstSugerencias.Visible = false;
                _cts?.Cancel();
            }
        }
    }
}
