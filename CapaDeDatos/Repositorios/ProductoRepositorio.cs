using CapaDeDatos.Datos;
using CapaDeDatos.Modelados.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Supabase.Postgrest.Constants;
using CapaDeDatos.Modelados.Paginacion;
using System.Threading;

namespace CapaDeDatos.Repositorios
{
    public class ProductoRepositorio
    {
        private async Task<Client> GetClient()
        {
            return await Conexion.ConnectWithTimeoutAsync(3);
        }

        public async Task<List<Producto>> ObtenerTodosLosProductos(bool? estado = null, int? marcaId = null, int? categoriaId = null)
        {
            try
            {
                var client = await GetClient();
                var queryBuilder = client.From<Producto>();
                queryBuilder.Order("id_producto", Supabase.Postgrest.Constants.Ordering.Ascending);


                if (estado.HasValue)
                {
                    queryBuilder = (Supabase.Interfaces.ISupabaseTable<Producto, Supabase.Realtime.RealtimeChannel>)queryBuilder.Where(x => x.EstadoProducto == estado.Value);
                }

                if (marcaId.HasValue && marcaId.Value > 0)
                {
                    queryBuilder = (Supabase.Interfaces.ISupabaseTable<Producto, Supabase.Realtime.RealtimeChannel>)queryBuilder.Where(x => x.IdMarca == marcaId.Value);
                }

                if (categoriaId.HasValue && categoriaId.Value > 0)
                {
                    queryBuilder = (Supabase.Interfaces.ISupabaseTable<Producto, Supabase.Realtime.RealtimeChannel>)queryBuilder.Where(x => x.IdCategoria == categoriaId.Value);
                }

                var response = await queryBuilder.Select("*,presentacion(*), marca(*), categoria(*))").Get();

                if (response != null && response.Models != null)
                {
                    return response.Models;
                }

                return new List<Producto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de Supabase al obtener productos: {ex.Message}");
                throw;// new Exception("No se obtuvo respuesta. Verifique los datos y la conexión.", ex);
            }
        }
        public async Task<ProductoInsertar> InsertarProducto(ProductoInsertar nuevoProducto)
        {
            if (nuevoProducto == null)
                throw new ArgumentNullException(nameof(nuevoProducto), "El producto a insertar no puede ser nulo.");

            try
            {
                var client = await GetClient();

                var response = await client
                    .From<ProductoInsertar>()
                    .Insert(nuevoProducto);

                if (response?.Models != null && response.Models.Count > 0)
                    return response.Models.First();

                throw new Exception("La base de datos no devolvió el producto insertado.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de Supabase al insertar producto: {ex.Message}");
                throw;// new Exception("No se pudo guardar el producto. Verifique los datos y la conexión.", ex);
            }
        }


        public async Task<ProductoInsertar> ActualizarProducto(ProductoInsertar _productoEditar)
        {
            if (_productoEditar == null)
                throw new ArgumentNullException(nameof(_productoEditar), "El producto a modificar no puede ser nulo.");

            try
            {
                var client = await GetClient();

                // OPTIMIZACIÓN:
                // 1. No necesitamos pasar el ID aparte, ya viene dentro de '_productoEditar.IdProducto'.
                // 2. No necesitamos .Where(), Supabase usa el [PrimaryKey] del modelo para saber a quién actualizar.

                var response = await client
                    .From<ProductoInsertar>()
                    .Update(_productoEditar);

                if (response?.Models != null && response.Models.Count > 0)
                    return response.Models.First();

                throw new Exception("La base de datos no devolvió el producto modificado o no se encontró el ID.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de Supabase al modificar producto: {ex.Message}");
                throw;// new Exception("No se pudo modificar el producto. Verifique los datos y la conexión.", ex);
            }
        }

        

        public async Task<List<Producto>> ObtenerProductosPorMarcasAsync(List<int> idMarcas)
        {
            if (idMarcas == null || idMarcas.Count == 0)
                return new List<Producto>();

            var client = await Conexion.ConnectWithTimeoutAsync(10);

            var resp = await client
                            .From<Producto>()
                            .Select("*, marca(*), categoria(*)")     // 👈 IMPORTANTE: JOIN
                            .Filter("id_marca", Operator.In, idMarcas)
                            .Get();


            return resp.Models ?? new List<Producto>();
        }

        public async Task<List<Producto>> ObtenerActivos(bool estado = true, int? marcaId = null, int? categoriaId = null)
        {
            try
            {
                var client = await GetClient();
                var query = client.From<Producto>()
                                  .Order("id_producto", Supabase.Postgrest.Constants.Ordering.Ascending);

                // Solo productos activos
                query = query.Filter("estado_producto", Supabase.Postgrest.Constants.Operator.Equals, estado.ToString().ToLower());//estado a string por que postgresql no maneja datos bool en sus consultas

                if (marcaId.HasValue && marcaId.Value > 0)
                    query = query.Filter("id_marca", Supabase.Postgrest.Constants.Operator.Equals, marcaId.Value);

                if (categoriaId.HasValue && categoriaId.Value > 0)
                    query = query.Filter("id_categoria", Supabase.Postgrest.Constants.Operator.Equals, categoriaId.Value);

                var response = await query.Select("*, marca(*), categoria(*),presentacion(*)").Get();

                return response?.Models ?? new List<Producto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener productos activos: {ex.Message}");
                throw;
            }


        }

        // =========================================================
        // ===== MÉTODOS PAGINADOS (NUEVOS) ========================
        // =========================================================

        /// <summary>
        /// Obtiene productos paginados desde Supabase aplicando filtros en servidor.
        /// Solo trae la página solicitada, NO carga todo en memoria.
        /// </summary>
        public async Task<ResultadoPaginado<Producto>> ObtenerProductosPaginadosAsync(
            FiltrosProducto filtros,
            CancellationToken ct = default)
        {
            if (filtros == null)
                throw new ArgumentNullException(nameof(filtros));

            if (filtros.Pagina < 1) filtros.Pagina = 1;
            if (filtros.TamanioPagina < 1) filtros.TamanioPagina = 100;

            try
            {
                var client = await GetClient();
                var queryCount = client.From<Producto>();
                var queryData = client.From<Producto>();

                // --- Aplicar filtros (se aplican a AMBAS queries) ---
                AplicarFiltrosBase(ref queryCount, filtros);
                AplicarFiltrosBase(ref queryData, filtros);

                // 1. Contar total (sin traer datos) ---
                long total = await queryCount
                    .Count(Supabase.Postgrest.Constants.CountType.Exact, ct);

                // 2. Calcular rango ---
                int desde = (filtros.Pagina - 1) * filtros.TamanioPagina;
                int hasta = desde + filtros.TamanioPagina - 1;

                // 3. Traer solo la página con joins ---
                var response = await queryData
                    .Select("*, presentacion(*), marca(*), categoria(*)")
                    .Order("id_producto", Supabase.Postgrest.Constants.Ordering.Ascending)
                    .Range(desde, hasta)
                    .Get(ct);

                return new ResultadoPaginado<Producto>
                {
                    Items = response?.Models ?? new List<Producto>(),
                    PaginaActual = filtros.Pagina,
                    TamanioPagina = filtros.TamanioPagina,
                    TotalRegistros = total
                };
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error paginación productos: {ex.Message}");
                throw new Exception("No se pudo cargar la página de productos.", ex);
            }
        }

        /// <summary>
        /// Consulta ligera: solo nombres de producto para autocompletar.
        /// No incluye joins, es MUY rápida.
        /// </summary>
        public async Task<List<Producto>> ObtenerSugerenciasAsync(
     string texto,
     bool? estado = true,
     int limite = 10,
     CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return new List<Producto>();

            try
            {
                var client = await GetClient();
                var query = client.From<Producto>();

                if (estado.HasValue)
                    query = (Supabase.Interfaces.ISupabaseTable<Producto, Supabase.Realtime.RealtimeChannel>)
                        query.Filter("estado_producto", Operator.Equals,
                                     estado.Value.ToString().ToLower());

                string textoLimpio = texto.Trim();
                bool esCodigo = textoLimpio.All(char.IsDigit)
                                && textoLimpio.Length >= 8
                                && textoLimpio.Length <= 13;

                if (esCodigo)
                    query = (Supabase.Interfaces.ISupabaseTable<Producto, Supabase.Realtime.RealtimeChannel>)
                        query.Filter("codigo_barra_producto", Operator.Equals, textoLimpio);
                else
                    query = (Supabase.Interfaces.ISupabaseTable<Producto, Supabase.Realtime.RealtimeChannel>)
                        query.Filter("nombre_producto", Operator.ILike, $"%{textoLimpio}%");

                var response = await query
                    .Select("nombre_producto, codigo_barra_producto, contenido_producto, marca(*), presentacion(*)")
                    .Limit(limite)
                    .Get(ct);

                // ← Retorna Producto completo, no string
                return response?.Models ?? new List<Producto>();
            }
            catch (OperationCanceledException) { throw; }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error sugerencias: {ex.Message}");
                return new List<Producto>();
            }
        }
        /// <summary>
        /// Busca UN producto exacto por código de barras (para lector POS).
        /// </summary>
        public async Task<Producto> BuscarPorCodigoBarraAsync(
            string codigo,
            CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(codigo)) return null;

            try
            {
                var client = await GetClient();
                var response = await client
                    .From<Producto>()
                    .Select("*, presentacion(*), marca(*), categoria(*)")
                    .Filter("codigo_barra_producto", Operator.Equals, codigo.Trim())
                    .Limit(1)
                    .Get(ct);

                return response?.Models?.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error buscar por código: {ex.Message}");
                return null;
            }
        }

        // =========================================================
        // Helper privado para aplicar filtros comunes
        // =========================================================
        private void AplicarFiltrosBase(
            ref Supabase.Interfaces.ISupabaseTable<Producto, Supabase.Realtime.RealtimeChannel> query,
            FiltrosProducto filtros)
        {
            if (filtros.Estado.HasValue)
            {
                query = (Supabase.Interfaces.ISupabaseTable<Producto, Supabase.Realtime.RealtimeChannel>)
                    query.Filter("estado_producto", Operator.Equals,
                                 filtros.Estado.Value.ToString().ToLower());
            }

            if (filtros.IdMarca.HasValue && filtros.IdMarca.Value > 0)
            {
                query = (Supabase.Interfaces.ISupabaseTable<Producto, Supabase.Realtime.RealtimeChannel>)
                    query.Filter("id_marca", Operator.Equals, filtros.IdMarca.Value);
            }

            if (filtros.IdCategoria.HasValue && filtros.IdCategoria.Value > 0)
            {
                query = (Supabase.Interfaces.ISupabaseTable<Producto, Supabase.Realtime.RealtimeChannel>)
                    query.Filter("id_categoria", Operator.Equals, filtros.IdCategoria.Value);
            }

            if (!string.IsNullOrWhiteSpace(filtros.TextoBusqueda))
            {
                string texto = filtros.TextoBusqueda.Trim();
                bool esCodigo = texto.All(char.IsDigit)
                                && texto.Length >= 8
                                && texto.Length <= 13;

                if (esCodigo)
                {
                    query = (Supabase.Interfaces.ISupabaseTable<Producto, Supabase.Realtime.RealtimeChannel>)
                        query.Filter("codigo_barra_producto", Operator.Equals, texto);
                }
                else
                {
                    query = (Supabase.Interfaces.ISupabaseTable<Producto, Supabase.Realtime.RealtimeChannel>)
                        query.Filter("nombre_producto", Operator.ILike, $"%{texto}%");
                }
            }
        }
    }
}
