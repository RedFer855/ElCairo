using CapaServiciosSeguridadValidacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI.ServiciosUI
{
    public class ServicioPermisosUI
    {
        // 1. CAMBIO: El diccionario ahora guarda un array de strings (acciones)
        private Dictionary<Control, string[]> _mapaAcciones = new Dictionary<Control, string[]>();

        /// <summary>
        /// Registra un botón que requiere UNA SOLA acción para ser visible.
        /// </summary>
        public void RegistrarBoton(Control control, string nombreAccion)
        {
            if (control != null && !string.IsNullOrEmpty(nombreAccion))
            {
                // Lo guardamos como un array de un solo elemento
                _mapaAcciones[control] = new string[] { nombreAccion };
            }
        }

        /// <summary>
        /// Registra un botón que requiere AL MENOS UNA de varias acciones para ser visible (lógica "OR").
        /// </summary>
        public void RegistrarBoton(Control boton, params string[] nombresAcciones)
        {
            if (boton != null && nombresAcciones != null && nombresAcciones.Length > 0)
            {
                _mapaAcciones[boton] = nombresAcciones;
            }
        }

        /// <summary>
        /// Aplica los permisos a todos los botones registrados.
        /// </summary>
        public void AplicarPermisos()
        {
            var contexto = ServicioSesionUsuario.Contexto;

            if (contexto == null)
            {
                foreach (var par in _mapaAcciones) { par.Key.Visible = false; }
                MessageBox.Show("Error: No se ha cargado el contexto del usuario.", "Error de Permisos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. CAMBIO: La nueva lógica de validación
            foreach (var par in _mapaAcciones)
            {
                var boton = par.Key;
                var accionesRequeridas = par.Value;

                // Con LINQ, preguntamos: "¿ALGUNA de las acciones requeridas existe en los permisos del usuario?"
                // Esto implementa la lógica "OR" de forma muy limpia.
                bool tieneAcceso = accionesRequeridas.Any(accion => contexto.TieneAcceso(accion));

                boton.Visible = tieneAcceso;
            }
        }
    }
}
