using CapaDeDatos.Datos;
using CapaServiciosSeguridadValidacion;
using Supabase.Realtime;
using Supabase.Realtime.Interfaces;
using Supabase.Realtime.PostgresChanges;
using System;
using System.Threading.Tasks;
using static Supabase.Realtime.PostgresChanges.PostgresChangesOptions;

namespace CapaServiciosSeguridadValidacion
{
    public class GestorRealtime<T> where T : Supabase.Postgrest.Models.BaseModel, new()
    {
        private Supabase.Client _client;
        private RealtimeChannel _subscription;

        public event Action<PostgresChangesResponse> OnCambioBaseDatos;
        public event Action OnReconexionExitosa;

        public GestorRealtime()
        {
            // Ahora que corregiste el archivo del Servicio, esto funcionará
            ServicioVerificacionConexion1.Instancia.EstadoDeRedCambiado += AlCambiarRed;
        }

        private async void AlCambiarRed(NetworkStatus status)
        {
            if (status == NetworkStatus.Internet)
            {
                System.Diagnostics.Debug.WriteLine("Red volvió. GestorRealtime reconectando...");
                await SuscribirAsync();
                OnReconexionExitosa?.Invoke();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Red perdida. Pausando suscripción...");
                await DesuscribirAsync();
            }
        }

        public async Task SuscribirAsync()
        {
            try
            {
                await DesuscribirAsync();

                _client = await Conexion.ConnectWithTimeoutAsync(3);

                // CORRECCIÓN AQUÍ:
                // 1. Obtenemos la referencia a la tabla
                var tableRef = _client.From<T>();

                // 2. Configuramos el evento. El método .On devuelve la suscripción activa.
                // No hace falta llamar a .Subscribe() manualmente en este objeto.
                var channel = await tableRef.On(ListenType.All, (sender, change) =>
                {
                    OnCambioBaseDatos?.Invoke(change);
                });

                // 3. Guardamos la referencia (hacemos un cast si es necesario, o usamos la variable devuelta)
                _subscription = channel;

                System.Diagnostics.Debug.WriteLine($"Suscripción iniciada para {typeof(T).Name}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error Realtime {typeof(T).Name}: {ex.Message}");
            }
        }

        public async Task DesuscribirAsync()
        {
            if (_subscription != null)
            {
                try
                {
                    await Task.Run(() => _subscription.Unsubscribe());
                }
                catch { }
                _subscription = null;
            }
        }
    }
}