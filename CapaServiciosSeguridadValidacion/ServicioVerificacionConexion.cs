using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Supabase.Gotrue;
using System;

namespace CapaServiciosSeguridadValidacion
{
    public enum NetworkStatus
    {
        SinRed,          // No hay WiFi/Cable (Rojo)
        RedSinInternet,  // Hay WiFi, pero no hay Ping (Amarillo)
        Internet         // Hay WiFi y hay Ping (Verde)
    }
    public class ServicioVerificacionConexion
    {
        // Evento original
        public event Action<NetworkStatus> EstadoDeRedCambiado;

        // Variables internas para la lógica del Timer
        private readonly System.Timers.Timer _timerVerificacion;
        private NetworkStatus _ultimoEstadoConocido;
        private bool _verificandoActualmente = false;

        public ServicioVerificacionConexion()
        {
            // 1. Configurar el Timer (Watchdog)
            // Se ejecutará cada 3 segundos (3000ms)
            _timerVerificacion = new System.Timers.Timer(3000);
            _timerVerificacion.Elapsed += async (s, e) => await VerificarConexionCompleta();
            _timerVerificacion.AutoReset = true;

            // 2. Escuchar cambios físicos (Cable/WiFi)
            NetworkChange.NetworkAvailabilityChanged += (s, e) =>
            {
                // Al detectar cambio físico, verificamos inmediatamente
                Task.Run(() => VerificarConexionCompleta());
            };

            // 3. Verificación inicial al arrancar la clase
            Task.Run(() => VerificarConexionCompleta());
        }

        // Este método lo usa tu formulario para saber el estado actual sin esperar
        public NetworkStatus HayConexionAhora()
        {
            return _ultimoEstadoConocido;
        }

        // --- LÓGICA INTERNA (Timer y Ping) ---

        private async Task VerificarConexionCompleta()
        {
            // Evitamos que se monten verificaciones si una está tardando
            if (_verificandoActualmente) return;
            _verificandoActualmente = true;

            NetworkStatus nuevoEstado;

            try
            {
                // PASO 1: Verificar Hardware (Cable/WiFi)
                if (!NetworkInterface.GetIsNetworkAvailable())
                {
                    nuevoEstado = NetworkStatus.SinRed;
                    // Si no hay cable, apagamos el Timer (ahorro de recursos)
                    _timerVerificacion.Stop();
                }
                else
                {
                    // PASO 2: Verificar Internet real (Ping a Google)
                    bool hayInternet = await PingInternetAsync();

                    if (hayInternet)
                    {
                        nuevoEstado = NetworkStatus.Internet;
                        // Si ya tenemos internet, apagamos el Timer
                        _timerVerificacion.Stop();
                    }
                    else
                    {
                        nuevoEstado = NetworkStatus.RedSinInternet;
                        // Estamos en AMARILLO: Encendemos el Timer para vigilar el regreso
                        if (!_timerVerificacion.Enabled) _timerVerificacion.Start();
                    }
                }

                // PASO 3: Notificar solo si hubo cambio
                if (_ultimoEstadoConocido != nuevoEstado)
                {
                    _ultimoEstadoConocido = nuevoEstado;
                    EstadoDeRedCambiado?.Invoke(nuevoEstado);
                }
            }
            catch
            {
                // Manejo silencioso
            }
            finally
            {
                _verificandoActualmente = false;
            }
        }

        // Método interno asíncrono para no congelar la UI
        private async Task<bool> PingInternetAsync()
        {
            try
            {
                using (var ping = new Ping())
                {
                    // Ping a Google (8.8.8.8) con 2 segundos de espera máxima
                    var reply = await ping.SendPingAsync("8.8.8.8", 2000);
                    return reply.Status == IPStatus.Success;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
