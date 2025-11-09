using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using Supabase.Gotrue.Mfa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
            int idCVenta = ventaResp.Models.First().IdVenta;


            if (ventaResp?.Models != null && ventaResp.Models.Count > 0)
            {
                return ventaResp.Models.First();
            }

            throw new Exception("La base de datos no devolvió la compra.");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al insertar compra: {ex.Message}");
            throw;
        }
        
       /*
         // 1) Insert compra
             // depende del nombre de la propiedad

            // 2) Preparar detalles y hacer insert masivo
            var detalles = new List<DetalleVenta>();
            foreach (DataGridViewRow row in dgvCarrito.Rows)
            {
                detalles.Add(new DetalleVenta {
                    IdVenta = IdVenta,
                    IdProducto = Convert.ToInt32(row.Cells["codigo"].Value),
                    CantidadVenta = Convert.ToInt32(row.Cells["cantidad"].Value),
                    Precio = Convert.ToDecimal(row.Cells["precio"].Value),
                    Subtotal = Convert.ToDecimal(row.Cells["precio"].Value) * Convert.ToInt32(row.Cells["cantidad"].Value)
                });
            }
            await client.From<DetalleVenta>().Insert(detalles).Execute();*/


         
    }

}
