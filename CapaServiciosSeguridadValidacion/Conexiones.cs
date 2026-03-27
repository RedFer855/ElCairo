using System;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;

namespace CapaServiciosSeguridadValidacion
{
    public class ServicioVerificacionConexion1 : IDisposable
    {
        private static readonly Lazy<ServicioVerificacionConexion1> _instancia =
            new Lazy<ServicioVerificacionConexion1>(() => new ServicioVerificacionConexion1());

        public static ServicioVerificacionConexion1 Instancia => _instancia.Value;

        public event Action<NetworkStatus> EstadoDeRedCambiado;

        private readonly System.Timers.Timer _timerVerificacion;
        private readonly SemaphoreSlim _semaforoVerificacion = new SemaphoreSlim(1, 1);

        private NetworkStatus _ultimoEstado = NetworkStatus.SinRed;
        private bool _liberado = false;

        private ServicioVerificacionConexion1()
        {
            _timerVerificacion = new System.Timers.Timer(10000); // 10 segundos, menos agresivo
            _timerVerificacion.AutoReset = true;
            _timerVerificacion.Elapsed += TimerVerificacion_Elapsed;

            NetworkChange.NetworkAvailabilityChanged += NetworkChange_NetworkAvailabilityChanged;

            _ = VerificarConexionCompletaAsync();
        }

        private void TimerVerificacion_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _ = VerificarConexionCompletaAsync();
        }

        private void NetworkChange_NetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            _ = VerificarConexionCompletaAsync();
        }

        public void ForzarVerificacion()
        {
            _ = VerificarConexionCompletaAsync();
        }

        private async Task VerificarConexionCompletaAsync()
        {
            if (_liberado)
                return;

            // Evita verificaciones simultáneas
            if (!await _semaforoVerificacion.WaitAsync(0))
                return;

            try
            {
                if (_liberado)
                    return;

                NetworkStatus nuevoEstado;

                // 1. Verificar si hay red física
                if (!NetworkInterface.GetIsNetworkAvailable())
                {
                    nuevoEstado = NetworkStatus.SinRed;
                    DetenerTimerRecuperacion();
                }
                else
                {
                    // 2. Verificar internet real
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

                // 3. Notificar solo si el estado cambió
                if (_ultimoEstado != nuevoEstado)
                {
                    _ultimoEstado = nuevoEstado;
                    EstadoDeRedCambiado?.Invoke(nuevoEstado);
                }
            }
            catch
            {
                // silencioso por ahora
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