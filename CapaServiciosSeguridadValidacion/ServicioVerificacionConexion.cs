using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CapaServiciosSeguridadValidacion
{
    public class ServicioVerificacionConexion
    {
        // 1. Define un evento público al que los formularios se pueden suscribir.
        //'Action<bool>' significa que el evento enviará un valor booleano (true=conectado, false=desconectado).
        public event Action<bool> EstadoDeRedCambiado;

        // 2. En el constructor de tu clase, suscríbete al evento del sistema
        public ServicioVerificacionConexion()
        {
            NetworkChange.NetworkAvailabilityChanged += OnNetworkAvailabilityChanged;
        }

        // 3. Este método se ejecuta cuando el S.O. detecta un cambio de red
        private void OnNetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            // 4. Dispara NUESTRO evento para notificar a quien esté escuchando (el frmMenuPrincipal)
            EstadoDeRedCambiado?.Invoke(e.IsAvailable);
        }

        // 5. Añade un método para que el formulario principal consulte el estado al iniciar
        public bool HayConexionAhora()
        {
            return NetworkInterface.GetIsNetworkAvailable();
        }
    }
}
