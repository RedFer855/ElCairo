using CapaDeDatos.Datos;
using CapaDeDatos.Modelados.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Repositorios
{
    public class CategoriaRepositorio
    {
        private async Task<Client> GetClient()
        {
            // Reutiliza el método de conexión existente
            return await Conexion.ConnectWithTimeoutAsync(3);
        }

        public async Task<List<Categoria>> ObtenerTodasLasCategorias(bool? estadoCategoria = null)
        {
            try
            {
                var client = await GetClient();
                var queryBuilder = client.From<Categoria>();

                // Ordenar por la clave primaria
                queryBuilder.Order("id_categoria", Supabase.Postgrest.Constants.Ordering.Ascending);


                // FILTRO POR ESTADO (EstadoCategoria)
                if (estadoCategoria.HasValue)
                {
                    // Filtra solo por el estado de la categoría (true/false)
                    queryBuilder = (Supabase.Interfaces.ISupabaseTable<Categoria, Supabase.Realtime.RealtimeChannel>)queryBuilder.Where(x => x.EstadoCategoria == estadoCategoria.Value);
                }

                // Selecciona todas las columnas de la tabla Categoria
                var response = await queryBuilder.Select("*").Get();

                if (response?.Models != null)
                {
                    return response.Models;
                }

                return new List<Categoria>();
            }
            catch (Exception ex)
            {
                // Manejo de excepciones estándar
                Console.WriteLine($"Error de Supabase al obtener categorías: {ex.Message}");
                throw new Exception("No se obtuvo respuesta. Verifique los datos y la conexión.", ex);
            }
        }
        public static async Task<int> InsertarCategoria(Categoria nuevaCategoria)
        {
            try
            {
                var client = await new CategoriaRepositorio().GetClient();
                var response = await client.From<Categoria>().Insert(nuevaCategoria);
                if (response?.Models != null && response.Models.Count > 0)
                {
                    return response.Models[0].IdCategoria;
                }
                throw new Exception("No se pudo insertar la categoría.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de Supabase al insertar categoría: {ex.Message}");
                throw new Exception("No se obtuvo respuesta. Verifique los datos y la conexión.", ex);
            }
        }
        public static async Task ActualizarCategoria(Categoria categoriaActualizada)
        {
            try
            {
                var client = await new CategoriaRepositorio().GetClient();
                var response = await client.From<Categoria>()
                                           .Update(categoriaActualizada);
                if (response?.Models == null || response.Models.Count == 0)
                {
                    throw new Exception("No se pudo actualizar la categoría.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de Supabase al actualizar categoría: {ex.Message}");
                throw new Exception("No se obtuvo respuesta. Verifique los datos y la conexión.", ex);
            }
        }
    }
}