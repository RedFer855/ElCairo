using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using CapaDeDatos.Modelados.Inventario;
using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Modelados.UsuariosEmpleados;
using CapaDeDatos.Modelados.Ventas;
using Supabase.Realtime;
using Supabase.Realtime.PostgresChanges;
using System;
using System.Threading;
using System.Threading.Tasks;
using static Supabase.Realtime.PostgresChanges.PostgresChangesOptions;

namespace CapaServiciosSeguridadValidacion
{
    public static class RealtimeManager
    {
        private static Supabase.Client? _client;

        private static RealtimeChannel? _bodegaChannel;
        private static RealtimeChannel? _categoriaChannel;
        private static RealtimeChannel? _marcaChannel;
        private static RealtimeChannel? _presentacionChannel;
        private static RealtimeChannel? _productoChannel;
        private static RealtimeChannel? _empleadoChannel;
        private static RealtimeChannel? _clienteChannel;
        private static RealtimeChannel? _proveedorChannel;
        private static RealtimeChannel? _inventarioChannel;

        private static bool _iniciado = false;
        private static readonly SemaphoreSlim _lock = new SemaphoreSlim(1, 1);

        public static event Action<PostgresChangesResponse>? OnBodegaChanged;
        public static event Action<PostgresChangesResponse>? OnCategoriaChanged;
        public static event Action<PostgresChangesResponse>? OnMarcaChanged;
        public static event Action<PostgresChangesResponse>? OnPresentacionChanged;
        public static event Action<PostgresChangesResponse>? OnProductoChanged;
        public static event Action<PostgresChangesResponse>? OnEmpleadoChanged;
        public static event Action<PostgresChangesResponse>? OnClienteChanged;
        public static event Action<PostgresChangesResponse>? OnProveedorChanged;
        public static event Action<PostgresChangesResponse>? OnInventarioChanged;

        public static bool EstaIniciado => _iniciado;

        public static async Task IniciarAsync()
        {
            if (_iniciado) return;

            await _lock.WaitAsync();
            try
            {
                if (_iniciado) return;

                _client = await Conexion.ConnectWithTimeoutAsync(3);

                if (_client == null)
                    throw new Exception("No se pudo crear el cliente de Supabase.");

                _bodegaChannel = await _client.From<Bodega>().On(ListenType.All, (sender, change) =>
                {
                    try { OnBodegaChanged?.Invoke(change); } catch { }
                });

                _categoriaChannel = await _client.From<Categoria>().On(ListenType.All, (sender, change) =>
                {
                    try { OnCategoriaChanged?.Invoke(change); } catch { }
                });

                _marcaChannel = await _client.From<Marca>().On(ListenType.All, (sender, change) =>
                {
                    try { OnMarcaChanged?.Invoke(change); } catch { }
                });

                _presentacionChannel = await _client.From<Presentacion>().On(ListenType.All, (sender, change) =>
                {
                    try { OnPresentacionChanged?.Invoke(change); } catch { }
                });

                _productoChannel = await _client.From<Producto>().On(ListenType.All, (sender, change) =>
                {
                    try { OnProductoChanged?.Invoke(change); } catch { }
                });

                _empleadoChannel = await _client.From<Empleado>().On(ListenType.All, (sender, change) =>
                {
                    try { OnEmpleadoChanged?.Invoke(change); } catch { }
                });

                _clienteChannel = await _client.From<Cliente>().On(ListenType.All, (sender, change) =>
                {
                    try { OnClienteChanged?.Invoke(change); } catch { }
                });

                _proveedorChannel = await _client.From<Proveedor>().On(ListenType.All, (sender, change) =>
                {
                    try { OnProveedorChanged?.Invoke(change); } catch { }
                });

                _inventarioChannel = await _client.From<Inventario>().On(ListenType.All, (sender, change) =>
                {
                    try { OnInventarioChanged?.Invoke(change); } catch { }
                });

                _iniciado = true;

                System.Diagnostics.Debug.WriteLine("Realtime global iniciado correctamente.");
            }
            finally
            {
                _lock.Release();
            }
        }
    }
}