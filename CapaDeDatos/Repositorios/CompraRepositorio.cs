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
    internal class CompraRepositorio
    {
        private async Task<Client> GetClient()
        {
            return await Conexion.ConnectWithTimeoutAsync(10);
        }
        public async Task<Compra> InsertarCompra(Producto nuevoProducto) 
        {
            try 
            { 
                var client = await GetClient();
            
                var compraResp = await client.From<Compra>().Insert(nuevoProducto);
                int idCompra = compraResp.Models.First().IdCompra;


                if (compraResp?.Models != null && compraResp.Models.Count > 0)
                {
                    return compraResp.Models.First();
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
            var detalles = new List<DetalleCompra>();
            foreach (DataGridViewRow row in dgvCarrito.Rows)
            {
                detalles.Add(new DetalleCompra {
                    IdCompra = idCompra,
                    IdProducto = Convert.ToInt32(row.Cells["codigo"].Value),
                    Cantidad = Convert.ToInt32(row.Cells["cantidad"].Value),
                    Precio = Convert.ToDecimal(row.Cells["precio"].Value),
                    Subtotal = Convert.ToDecimal(row.Cells["precio"].Value) * Convert.ToInt32(row.Cells["cantidad"].Value)
                });
            }
            await client.From<DetalleCompra>().Insert(detalles).Execute();

         
         */
    }
}
