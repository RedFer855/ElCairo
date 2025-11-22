using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace CapaServiciosSeguridadValidacion.CapaServiciosSeguridadValidacion
{
    public enum NetworkStatus1
    {
        Internet,
        RedSinInternet,
        SinRed
    }

    public class ServicioVerificacionConexion1
    {

        private static readonly ServicioVerificacionConexion1 _instancia = new ServicioVerificacionConexion1();
        public static ServicioVerificacionConexion1 Instancia => _instancia;


        public event Action<NetworkStatus> EstadoDeRedCambiado;
        private NetworkStatus _ultimoEstado;


        private ServicioVerificacionConexion1()
        {
            NetworkChange.NetworkAvailabilityChanged += (s, e) => VerificarConexion();
            _ultimoEstado = NetworkStatus.SinRed; 
            VerificarConexion(); 
        }

        public async void VerificarConexion()
        {
            bool hayRed = NetworkInterface.GetIsNetworkAvailable();
            NetworkStatus nuevoEstado;

            if (!hayRed)
            {
                nuevoEstado = NetworkStatus.SinRed;
            }
            else
            {
                bool hayInternet = await PingGoogle();
                nuevoEstado = hayInternet ? NetworkStatus.Internet : NetworkStatus.RedSinInternet;
            }

            if (nuevoEstado != _ultimoEstado)
            {
                _ultimoEstado = nuevoEstado;
                EstadoDeRedCambiado?.Invoke(nuevoEstado);
            }
        }

        private async Task<bool> PingGoogle()
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