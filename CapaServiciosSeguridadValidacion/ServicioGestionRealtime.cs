using CapaDeDatos.Datos;
using Supabase.Realtime;
using Supabase.Realtime.PostgresChanges;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using static Supabase.Realtime.PostgresChanges.PostgresChangesOptions;

namespace CapaServiciosSeguridadValidacion
{
    public class GestorRealtime<T> : IDisposable
        where T : Supabase.Postgrest.Models.BaseModel, new()
    {
        private Supabase.Client _client;
        private RealtimeChannel _subscription;

        private readonly SemaphoreSlim _semaforoSuscripcion = new SemaphoreSlim(1, 1);

        private bool _estaSuscrito = false;
        private bool _liberado = false;
        private bool _liberando = false;

        private NetworkStatus? _ultimoEstadoRedProcesado = null;

        public event Action<PostgresChangesResponse> OnCambioBaseDatos;
        public event Action OnReconexionExitosa;

        public GestorRealtime()
        {
            ServicioVerificacionConexion1.Instancia.EstadoDeRedCambiado += AlCambiarRed;
        }

        /// <summary>
        /// Maneja cambios de red evitando reconexiones repetidas o innecesarias.
        /// </summary>
        private async void AlCambiarRed(NetworkStatus status)
        {
            if (_liberado || _liberando)
                return;

            // Evita procesar el mismo estado repetidamente
            if (_ultimoEstadoRedProcesado == status)
                return;

            _ultimoEstadoRedProcesado = status;

            try
            {
                if (status == NetworkStatus.Internet)
                {
                    Debug.WriteLine($"[{typeof(T).Name}] Red volvió. Reconectando realtime...");
                    await SuscribirAsync(forzarResuscripcion: true);

                    if (!_liberado && !_liberando && _estaSuscrito)
                        OnReconexionExitosa?.Invoke();
                }
                else
                {
                    Debug.WriteLine($"[{typeof(T).Name}] Red perdida. Desuscribiendo realtime...");
                    await DesuscribirAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[{typeof(T).Name}] Error en cambio de red: {ex.Message}");
            }
        }

        /// <summary>
        /// Suscripción pública normal.
        /// </summary>
        public Task SuscribirAsync()
        {
            return SuscribirAsync(false);
        }

        /// <summary>
        /// Suscribe al canal de realtime.
        /// forzarResuscripcion = true sirve para reconexión tras pérdida de red.
        /// </summary>
        private async Task SuscribirAsync(bool forzarResuscripcion)
        {
            if (_liberado || _liberando)
                return;

            await _semaforoSuscripcion.WaitAsync();

            try
            {
                if (_liberado || _liberando)
                    return;

                // Si ya está suscrito y no se pidió resuscribir, no hacemos nada
                if (_estaSuscrito && _subscription != null && !forzarResuscripcion)
                {
                    Debug.WriteLine($"[{typeof(T).Name}] Ya existe una suscripción activa.");
                    return;
                }

                // Si estamos forzando reconexión, cerramos la anterior
                if (_subscription != null)
                {
                    try
                    {
                        _subscription.Unsubscribe();
                        Debug.WriteLine($"[{typeof(T).Name}] Suscripción anterior cerrada.");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"[{typeof(T).Name}] Error cerrando suscripción anterior: {ex.Message}");
                    }
                    finally
                    {
                        _subscription = null;
                        _estaSuscrito = false;
                    }
                }

                // Reutiliza cliente si ya existe; evita crear clientes sin necesidad
                if (_client == null)
                {
                    _client = await Conexion.ConnectWithTimeoutAsync(3);
                    Debug.WriteLine($"[{typeof(T).Name}] Cliente Supabase creado.");
                }

                var tableRef = _client.From<T>();

                _subscription = await tableRef.On(ListenType.All, (sender, change) =>
                {
                    if (_liberado || _liberando)
                        return;

                    try
                    {
                        OnCambioBaseDatos?.Invoke(change);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"[{typeof(T).Name}] Error notificando cambio realtime: {ex.Message}");
                    }
                });

                _estaSuscrito = _subscription != null;

                Debug.WriteLine($"[{typeof(T).Name}] Suscripción iniciada correctamente.");
            }
            catch (Exception ex)
            {
                _estaSuscrito = false;
                _subscription = null;
                Debug.WriteLine($"[{typeof(T).Name}] Error al suscribir realtime: {ex.Message}");
            }
            finally
            {
                _semaforoSuscripcion.Release();
            }
        }

        /// <summary>
        /// Desuscribe el canal actual.
        /// </summary>
        public async Task DesuscribirAsync()
        {
            await _semaforoSuscripcion.WaitAsync();

            try
            {
                if (_subscription != null)
                {
                    try
                    {
                        _subscription.Unsubscribe();
                        Debug.WriteLine($"[{typeof(T).Name}] Desuscripción realizada.");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"[{typeof(T).Name}] Error al desuscribir: {ex.Message}");
                    }
                    finally
                    {
                        _subscription = null;
                        _estaSuscrito = false;
                    }
                }
                else
                {
                    _estaSuscrito = false;
                }
            }
            finally
            {
                _semaforoSuscripcion.Release();
            }
        }

        /// <summary>
        /// Libera completamente el gestor para evitar fugas por eventos y reconexiones.
        /// Debe llamarse al cerrar el formulario.
        /// </summary>
        public async Task LiberarAsync()
        {
            if (_liberado || _liberando)
                return;

            _liberando = true;

            try
            {
                // MUY IMPORTANTE: quitar la suscripción al singleton de red
                ServicioVerificacionConexion1.Instancia.EstadoDeRedCambiado -= AlCambiarRed;

                // Cerrar realtime
                await DesuscribirAsync();

                // Romper la cadena de referencias a formularios suscritos
                OnCambioBaseDatos = null;
                OnReconexionExitosa = null;

                // Si quieres forzar recreación futura del cliente, lo soltamos
                _client = null;

                _liberado = true;

                Debug.WriteLine($"[{typeof(T).Name}] GestorRealtime liberado correctamente.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[{typeof(T).Name}] Error al liberar GestorRealtime: {ex.Message}");
            }
            finally
            {
                _liberando = false;
            }
        }

        public void Dispose()
        {
            if (_liberado)
                return;

            try
            {
                ServicioVerificacionConexion1.Instancia.EstadoDeRedCambiado -= AlCambiarRed;
            }
            catch { }

            try
            {
                if (_subscription != null)
                    _subscription.Unsubscribe();
            }
            catch { }

            _subscription = null;
            _estaSuscrito = false;

            OnCambioBaseDatos = null;
            OnReconexionExitosa = null;

            _client = null;
            _liberado = true;

            try
            {
                _semaforoSuscripcion.Dispose();
            }
            catch { }
        }
    }
}