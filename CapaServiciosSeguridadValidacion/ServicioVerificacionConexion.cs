using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CapaServiciosSeguridadValidacion
{
    using Supabase.Gotrue;
    using System;
    using System.Net.NetworkInformation;

    namespace CapaServiciosSeguridadValidacion
    {
        public enum NetworkStatus
        {
            SinRed,         // No hay WiFi/Cable
            RedSinInternet, // Hay WiFi, pero no hay Ping
            Internet        // Hay WiFi y hay Ping
        }
        public class ServicioVerificacionConexion
        {
            // CAMBIO: El evento ahora envía la 'enum'
            public event Action<NetworkStatus> EstadoDeRedCambiado;

            public ServicioVerificacionConexion()
            {
                NetworkChange.NetworkAvailabilityChanged += OnNetworkAvailabilityChanged;
            }

            // Se dispara cuando el WiFi/Cable cambia
            private void OnNetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
            {
                // Llama a la comprobación completa
                NetworkStatus statusActual = HayConexionAhora();
                // Dispara el evento con el estado (enum)
                EstadoDeRedCambiado?.Invoke(statusActual);
            }

            // CAMBIO: El método ahora devuelve la 'enum'
            public NetworkStatus HayConexionAhora()
            {
                if (!NetworkInterface.GetIsNetworkAvailable())
                {
                    return NetworkStatus.SinRed;
                }

                if (PingInternet()) // Llama al método Ping
                {
                    return NetworkStatus.Internet;
                }
                else
                {
                    return NetworkStatus.RedSinInternet;
                }
            }

            // NUEVO: Método que comprueba el Ping a Google
            private bool PingInternet()
            {
                try
                {
                    using (var ping = new Ping())
                    {
                        // Intenta contactar a 8.8.8.8 con 2 segundos de timeout
                        var reply = ping.Send("8.8.8.8", 2000);
                        return (reply != null && reply.Status == IPStatus.Success);
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
