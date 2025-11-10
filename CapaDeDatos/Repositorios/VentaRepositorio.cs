using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using Sprache;
using Supabase.Gotrue.Mfa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Supabase.Postgrest.Constants;


public class VentaRepositorio
{
    private async Task<Client> GetClient()
    {
        return await Conexion.ConnectWithTimeoutAsync(10);
    }
    public async Task<Venta> InsertarVenta(Venta nuevaVenta)
    {
        try
        {
            var client = await GetClient();

            var ventaResp = await client.From<Venta>().Insert(nuevaVenta);
            int idVenta = ventaResp.Models.First().IdVenta;


            if (ventaResp?.Models != null && ventaResp.Models.Count > 0)
            {
                return ventaResp.Models.First();
            }

            throw new Exception("La base de datos no devolvió la venta.");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al insertar venta: {ex.Message}");
            throw;
        }
        
         
    }

    public async Task<int?> ObtenerVentaId(int idEmpleado)
    {
        try
        {
            var client = await GetClient();

            var ventasResp = await client
                .From<Venta>()
                .Select("id_venta")
                .Filter("id_empleado", Operator.Equals, idEmpleado)
                .Order("id_venta", Ordering.Descending)
                .Limit(1)
                .Get();

            var venta = ventasResp.Models.FirstOrDefault();

            return venta?.IdVenta; // agarra el int ? de la compra
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al obtener el ID de la venta: {ex.Message}");
            throw;
        }
    }

}



