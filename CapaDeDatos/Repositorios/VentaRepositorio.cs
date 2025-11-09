using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using Supabase.Gotrue.Mfa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaDeDatos.Repositorios
{
    public class VentaRepositorio
    {
        private async Task<Client> GetClient()
        {
            return await Conexion.ConnectWithTimeoutAsync(10);
        }

        // Inserta la Venta y devuelve el objeto con el ID
        public async Task<Venta> InsertarVenta(Venta nuevaVenta)
        {
            try
            {
                var client = await GetClient();
                var response = await client.From<Venta>().Insert(nuevaVenta);

                if (response?.Models != null && response.Models.Count > 0)
                {
                    return response.Models.First(); // Devuelve la Venta con el ID
                }
                throw new Exception("La base de datos no devolvió la venta insertada.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar venta: {ex.Message}");
                throw;
            }
        }
    }

    // Repositorio para la tabla 'detalle_venta'
    public class DetalleVentaRepositorio
    {
        private async Task<Client> GetClient()
        {
            return await Conexion.ConnectWithTimeoutAsync(10);
        }

        // Inserta todos los detalles del carrito en un solo viaje (Bulk Insert)
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