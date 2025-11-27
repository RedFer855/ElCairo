using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace CapaServiciosSeguridadValidacion
{
    public class ServicioVerificacionConexion1
    {
        private static readonly ServicioVerificacionConexion1 _instancia = new ServicioVerificacionConexion1();
        public static ServicioVerificacionConexion1 Instancia => _instancia;
        public event Action<NetworkStatus> EstadoDeRedCambiado;
        private readonly System.Timers.Timer _timerVerificacion;
        private NetworkStatus _ultimoEstado;
        private bool _verificandoActualmente = false;

        private ServicioVerificacionConexion1()
        {
            _timerVerificacion = new System.Timers.Timer(3000);
            _timerVerificacion.Elapsed += async (s, e) => await VerificarConexionCompleta();
            _timerVerificacion.AutoReset = true;

            NetworkChange.NetworkAvailabilityChanged += (s, e) =>
            {
                Task.Run(() => VerificarConexionCompleta());
            };

            _ultimoEstado = NetworkStatus.SinRed; 
            Task.Run(() => VerificarConexionCompleta());
        }

        // Método público para forzar verificación si fuera necesario
        public void ForzarVerificacion()
        {
            Task.Run(() => VerificarConexionCompleta());
        }

        private async Task VerificarConexionCompleta()
        {
            if (_verificandoActualmente) return;
            _verificandoActualmente = true;

            NetworkStatus nuevoEstado;

            try
            {
                // PASO 1: Verificar Hardware
                if (!NetworkInterface.GetIsNetworkAvailable())
                {
                    nuevoEstado = NetworkStatus.SinRed;
                    _timerVerificacion.Stop();
                }
                else
                {
                    // PASO 2: Verificar Internet real (Ping a Google)
                    bool hayInternet = await PingInternetAsync();

                    if (hayInternet)
                    {
                        nuevoEstado = NetworkStatus.Internet;
                        // Si ya tenemos internet, apagamos el timer (GestorRealtime ya reconectará)
                        _timerVerificacion.Stop();
                    }
                    else
                    {
                        nuevoEstado = NetworkStatus.RedSinInternet;
                        // Estamos en AMARILLO: Encendemos timer para detectar cuando vuelva
                        if (!_timerVerificacion.Enabled) _timerVerificacion.Start();
                    }
                }

                // PASO 3: Notificar solo si hubo cambio
                if (_ultimoEstado != nuevoEstado)
                {
                    _ultimoEstado = nuevoEstado;
                    // Esto disparará el evento en GestorRealtime -> AlCambiarRed
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

        // Ping Asíncrono (No congela la app)
        private async Task<bool> PingInternetAsync()
        {
            try
            {
                using (var ping = new Ping())
                {
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