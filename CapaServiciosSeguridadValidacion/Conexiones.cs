using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace CapaServiciosSeguridadValidacion
{
    public class ServicioVerificacionConexion1 : IDisposable
    {
        private static readonly ServicioVerificacionConexion1 _instancia = new ServicioVerificacionConexion1();
        public static ServicioVerificacionConexion1 Instancia => _instancia;

        public event Action<NetworkStatus> EstadoDeRedCambiado;

        private readonly System.Timers.Timer _timerVerificacion;
        private NetworkStatus _ultimoEstado;
        private bool _verificandoActualmente = false;
        private bool _disposed = false;

        private ServicioVerificacionConexion1()
        {
            _timerVerificacion = new System.Timers.Timer(3000);
            _timerVerificacion.AutoReset = true;
            _timerVerificacion.Elapsed += TimerVerificacion_Elapsed;

            NetworkChange.NetworkAvailabilityChanged += NetworkAvailabilityChanged_Handler;

            _ultimoEstado = NetworkStatus.SinRed;
            _ = VerificarConexionCompleta();
        }

        private async void TimerVerificacion_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            await VerificarConexionCompleta();
        }

        private void NetworkAvailabilityChanged_Handler(object sender, NetworkAvailabilityEventArgs e)
        {
            _ = VerificarConexionCompleta();
        }

        public void ForzarVerificacion()
        {
            _ = VerificarConexionCompleta();
        }

        private async Task VerificarConexionCompleta()
        {
            if (_verificandoActualmente || _disposed) return;

            _verificandoActualmente = true;

            try
            {
                NetworkStatus nuevoEstado;

                if (!NetworkInterface.GetIsNetworkAvailable())
                {
                    nuevoEstado = NetworkStatus.SinRed;
                    _timerVerificacion.Stop();
                }
                else
                {
                    bool hayInternet = await PingInternetAsync();

                    if (hayInternet)
                    {
                        nuevoEstado = NetworkStatus.Internet;
                        _timerVerificacion.Stop();
                    }
                    else
                    {
                        nuevoEstado = NetworkStatus.RedSinInternet;

                        if (!_timerVerificacion.Enabled)
                            _timerVerificacion.Start();
                    }
                }

                if (_ultimoEstado != nuevoEstado)
                {
                    _ultimoEstado = nuevoEstado;
                    EstadoDeRedCambiado?.Invoke(nuevoEstado);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error verificando conexión: {ex.Message}");
            }
            finally
            {
                _verificandoActualmente = false;
            }
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
            if (_disposed) return;
            _disposed = true;

            NetworkChange.NetworkAvailabilityChanged -= NetworkAvailabilityChanged_Handler;

            _timerVerificacion.Stop();
            _timerVerificacion.Elapsed -= TimerVerificacion_Elapsed;
            _timerVerificacion.Dispose();
        }
    }
}