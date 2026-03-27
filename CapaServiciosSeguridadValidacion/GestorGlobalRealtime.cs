using CapaDeDatos.Datos;
using CapaDeDatos.Modelados.Productos;
using Supabase.Realtime;
using Supabase.Realtime.PostgresChanges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Supabase.Realtime.PostgresChanges.PostgresChangesOptions;

namespace CapaServiciosSeguridadValidacion
{
    public sealed class GestorGlobalRealtime
    {
        private static readonly Lazy<GestorGlobalRealtime> _instancia =
        new Lazy<GestorGlobalRealtime>(() => new GestorGlobalRealtime());

        public static GestorGlobalRealtime Instancia => _instancia.Value;

        private readonly SemaphoreSlim _lock = new SemaphoreSlim(1, 1);
        private RealtimeChannel _canal;
        private bool _iniciado = false;

        public event Action<PostgresChangesResponse> OnCambioProducto;

        private GestorGlobalRealtime() { }

        public async Task IniciarAsync()
        {
            if (_iniciado) return;

            await _lock.WaitAsync();
            try
            {
                if (_iniciado) return;

                var client = await Conexion.GetClientAsync();

                var tableRef = client.From<Producto>();

                _canal = await tableRef.On(ListenType.All, (sender, change) =>
                {
                    OnCambioProducto?.Invoke(change);
                });

                _iniciado = _canal != null;
            }
            finally
            {
                _lock.Release();
            }
        }

        public async Task DetenerAsync()
        {
            await _lock.WaitAsync();
            try
            {
                if (_canal != null)
                {
                    _canal.Unsubscribe();
                    _canal = null;
                }

                _iniciado = false;
                OnCambioProducto = null;
            }
            finally
            {
                _lock.Release();
            }
        }
    }
}
