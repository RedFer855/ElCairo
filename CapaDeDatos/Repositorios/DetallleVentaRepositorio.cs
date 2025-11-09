using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static Supabase.Postgrest.Constants;

namespace CapaDeDatos.Repositorios
{
    public class DetallleVentaRepositorio
    {
        // INSERTAR DETALLE DE VENTA
        public static async Task InsertarDetalleVenta(DetalleVenta nuevoDetalle)
        {
            try
            {
                var client = await Conexion.ConnectWithTimeoutAsync(10);
                await client.From<DetalleVenta>().Insert(nuevoDetalle);
            }
            catch (WebException ex)
            {
                throw new Exception("Error de red al guardar el detalle: " + ex.Message, ex);
            }
            catch (TimeoutException ex)
            {
                throw new Exception("El servidor tardó demasiado en responder.", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de Supabase: {ex.Message}");
                throw;
            }
        }

        private async Task<Supabase.Client> GetClient() => await Conexion.ConnectWithTimeoutAsync(10);

        // OBTENER TODOS LOS DETALLES (Generalmente no se usa, pero es bueno tenerlo)
        public async Task<List<DetalleVenta>> ObtenerTodosLosDetallesVenta()
        {
            try
            {
                var client = await GetClient();
                var response = await client.From<DetalleVenta>().Get();
                return response?.Models ?? new List<DetalleVenta>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener detalles de venta: {ex.Message}");
                throw new Exception("No se pudieron cargar los detalles de venta.", ex);
            }
        }

        // OBTENER DETALLES POR ID DE VENTA (Más útil)
        public async Task<List<DetalleVenta>> ObtenerDetallesPorIdVenta(int idVenta)
        {
            var client = await GetClient();
            var response = await client.From<DetalleVenta>()
                .Filter("id_venta", Operator.Equals, idVenta)
                .Get();
            return response.Models.ToList();
        }

        // OBTENER POR ID (Usando la PK 'id_detalle_venta')
        public async Task<DetalleVenta> ObtenerDetalleVentaPorId(int id)
        {
            var client = await GetClient();
            var response = await client.From<DetalleVenta>()
                .Filter("id_detalle_venta", Operator.Equals, id)
                .Get();
            return response.Models.FirstOrDefault();
        }

        // (Generalmente los detalles de venta NO se actualizan ni eliminan,
        // pero aquí están los métodos por si tu lógica de negocio los necesita)

        // ACTUALIZAR DETALLE
        public static async Task ActualizarDetalleVenta(DetalleVenta detalleActualizado)
        {
            var client = await Conexion.ConnectWithTimeoutAsync(10);
            await client.From<DetalleVenta>().Update(detalleActualizado);
        }

        // ELIMINAR DETALLE
        public static async Task EliminarDetalleVenta(int id)
        {
            var client = await Conexion.ConnectWithTimeoutAsync(10);
            await client.From<DetalleVenta>()
                .Filter("id_detalle_venta", Operator.Equals, id)
                .Delete();
        }
        public async Task InsertarDetalleVenta(List<DetalleVenta> nuevosDetalles)
        {
            try
            {
                var client = await GetClient();
                await client.From<DetalleVenta>().Insert(nuevosDetalles);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar detalles de venta: {ex.Message}");
                throw;
            }
        }
    }
}
