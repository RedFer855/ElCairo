using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Supabase.Postgrest.Constants;

namespace CapaDeDatos.Repositorios
{
    public class VentaRepositorio
    {
        // INSERTAR VENTA (y devolver el ID)
        public static async Task<int> InsertarVenta(Venta nuevaVenta)
        {
            try
            {
                var client = await Conexion.ConnectWithTimeoutAsync(10);

                // Hacemos el Insert y pedimos que devuelva los datos insertados
                var response = await client.From<Venta>().Insert(nuevaVenta);
                var ventaInsertada = response.Models.FirstOrDefault();

                if (ventaInsertada != null)
                {
                    return ventaInsertada.IdVenta; // Devuelve el nuevo ID
                }
                else
                {
                    throw new Exception("No se pudo obtener el ID de la venta insertada.");
                }
            }
            catch (WebException ex)
            {
                throw new Exception("Error de red al guardar la venta: " + ex.Message, ex);
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

        // OBTENER TODAS LAS VENTAS
        public async Task<List<Venta>> ObtenerTodasLasVentas()
        {
            try
            {
                var client = await GetClient();
                var response = await client.From<Venta>().Get();
                return response?.Models ?? new List<Venta>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener ventas: {ex.Message}");
                throw new Exception("No se pudieron cargar las ventas.", ex);
            }
        }

        // OBTENER POR ID (Usando la PK 'id_venta')
        public async Task<Venta> ObtenerVentaPorId(int id)
        {
            var client = await GetClient();
            var response = await client.From<Venta>()
                .Filter("id_venta", Operator.Equals, id)
                .Get();
            return response.Models.FirstOrDefault();
        }

        // ACTUALIZAR VENTA
        public static async Task ActualizarVenta(Venta ventaActualizada)
        {
            var client = await Conexion.ConnectWithTimeoutAsync(10);
            await client.From<Venta>().Update(ventaActualizada);
        }

        // ELIMINAR VENTA
        public static async Task EliminarVenta(int id)
        {
            var client = await Conexion.ConnectWithTimeoutAsync(10);
            await client.From<Venta>()
                .Filter("id_venta", Operator.Equals, id)
                .Delete();
        }
    }
}
