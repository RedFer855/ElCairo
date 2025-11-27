using CapaDeDatos.Datos;
using CapaDeDatos.Modelados.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Repositorios
{
    public class PresentacionRepositorio
    {
        private async Task<Client> GetClient()
        {
            return await Conexion.ConnectWithTimeoutAsync(3);
        }

        public async Task<List<Presentacion>> ObtenerTodasLasPresentaciones()
        {
            try
            {
                var client = await GetClient();

                // Construir query
                var queryBuilder = client.From<Presentacion>();
                queryBuilder.Order("nombre_presentacion", Supabase.Postgrest.Constants.Ordering.Ascending);

                // Obtener datos
                var response = await queryBuilder.Select("*").Get();

                if (response?.Models != null)
                    return response.Models;

                return new List<Presentacion>();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo obtener la lista de presentaciones. Verifique la conexión.", ex);
            }
        }
        public async Task<int> InsertarPresentacion(Presentacion nuevaPresentacion)
        {
            try
            {
                var client = await GetClient();
                var response = await client.From<Presentacion>().Insert(nuevaPresentacion);
                if (response?.Models != null && response.Models.Count > 0)
                {
                    return response.Models[0].IdPresentacionProducto;
                }
                throw new Exception("No se pudo insertar la presentación.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar la presentación. Verifique la conexión.", ex);
            }
        }

        public async Task ActualizarPresentacion(Presentacion presentacionActualizada)
        {
            try
            {
                var client = await GetClient();
                var response = await client.From<Presentacion>()
                                           .Update(presentacionActualizada);
                if (response?.Models == null || response.Models.Count == 0)
                {
                    throw new Exception("No se pudo actualizar la presentación.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la presentación. Verifique la conexión.", ex);
            }
        }
    }
}
