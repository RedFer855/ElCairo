using System;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;

namespace CapaServiciosSeguridadValidacion
{
    public enum NetworkStatus
    {
        SinRed,          // No hay WiFi/Cable
        RedSinInternet,  // Hay red física, pero no internet real
        Internet         // Hay red y hay internet
    }

    public class ServicioVerificacionConexion : IDisposable
    {
        public event Action<NetworkStatus> EstadoDeRedCambiado;

        private readonly System.Timers.Timer _timerVerificacion;
        private readonly SemaphoreSlim _semaforoVerificacion = new SemaphoreSlim(1, 1);

        private NetworkStatus _ultimoEstadoConocido = NetworkStatus.SinRed;
        private bool _liberado = false;

        public ServicioVerificacionConexion()
        {
            _timerVerificacion = new System.Timers.Timer(10000); // 10 segundos
            _timerVerificacion.AutoReset = true;
            _timerVerificacion.Elapsed += TimerVerificacion_Elapsed;

            NetworkChange.NetworkAvailabilityChanged += NetworkChange_NetworkAvailabilityChanged;

            _ = VerificarConexionCompletaAsync();
        }

        public NetworkStatus HayConexionAhora()
        {
            return _ultimoEstadoConocido;
        }

        public void ForzarVerificacion()
        {
            if (_liberado)
                return;

            _ = VerificarConexionCompletaAsync();
        }

        private void TimerVerificacion_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (_liberado)
                return;

            _ = VerificarConexionCompletaAsync();
        }

        private void NetworkChange_NetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            if (_liberado)
                return;

            _ = VerificarConexionCompletaAsync();
        }

        private async Task VerificarConexionCompletaAsync()
        {
            if (_liberado)
                return;

            // Evita que entren varias verificaciones al mismo tiempo
            if (!await _semaforoVerificacion.WaitAsync(0))
                return;

            try
            {
                if (_liberado)
                    return;

                NetworkStatus nuevoEstado;

                // Paso 1: verificar si existe red física
                if (!NetworkInterface.GetIsNetworkAvailable())
                {
                    nuevoEstado = NetworkStatus.SinRed;
                    DetenerTimerRecuperacion();
                }
                else
                {
                    // Paso 2: verificar internet real
                    bool hayInternet = await PingInternetAsync();

                    if (hayInternet)
                    {
                        nuevoEstado = NetworkStatus.Internet;
                        DetenerTimerRecuperacion();
                    }
                    else
                    {
                        nuevoEstado = NetworkStatus.RedSinInternet;
                        IniciarTimerRecuperacion();
                    }
                }

                // Paso 3: notificar solo si cambia el estado
                if (_ultimoEstadoConocido != nuevoEstado)
                {
                    _ultimoEstadoConocido = nuevoEstado;
                    EstadoDeRedCambiado?.Invoke(nuevoEstado);
                }
            }
            catch
            {
                // Silencioso por ahora
            }
            finally
            {
                _semaforoVerificacion.Release();
            }
        }

        private void IniciarTimerRecuperacion()
        {
            if (_liberado)
                return;

            if (!_timerVerificacion.Enabled)
                _timerVerificacion.Start();
        }

        private void DetenerTimerRecuperacion()
        {
            if (_timerVerificacion.Enabled)
                _timerVerificacion.Stop();
        }

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

        public void Dispose()
        {
            if (_liberado)
                return;

            _liberado = true;

            try
            {
                _timerVerificacion.Stop();
            }
            catch { }

            try
            {
                _timerVerificacion.Elapsed -= TimerVerificacion_Elapsed;
            }
            catch { }

            try
            {
                _timerVerificacion.Dispose();
            }
            catch { }

            try
            {
                NetworkChange.NetworkAvailabilityChanged -= NetworkChange_NetworkAvailabilityChanged;
            }
            catch { }

            EstadoDeRedCambiado = null;

            try
            {
                _semaforoVerificacion.Dispose();
            }
            catch { }
        }
    }
}