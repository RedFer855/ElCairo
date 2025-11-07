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
    public class CategoriaRepositorio
    {
        // INSERTAR CATEGORIA
        public static async Task InsertarCategoria(Categoria nuevaCategoria)
        {
            try
            {
                var client = await Conexion.ConnectWithTimeoutAsync(10);
                await client.From<Categoria>().Insert(nuevaCategoria);
            }
            catch (WebException ex)
            {
                throw new Exception("Error de red al guardar la categoría: " + ex.Message, ex);
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

        // OBTENER TODAS LAS CATEGORIAS
        public async Task<List<Categoria>> ObtenerTodasLasCategorias()
        {
            try
            {
                var client = await GetClient();
                var response = await client.From<Categoria>().Get();
                return response?.Models ?? new List<Categoria>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener categorías: {ex.Message}");
                throw new Exception("No se pudieron cargar las categorías.", ex);
            }
        }

        // OBTENER POR ID (Usando la PK 'id_categoria')
        public async Task<Categoria> ObtenerCategoriaPorId(int id)
        {
            var client = await GetClient();
            var response = await client.From<Categoria>()
                .Filter("id_categoria", Operator.Equals, id)
                .Get();
            return response.Models.FirstOrDefault();
        }

        // ACTUALIZAR CATEGORIA
        public static async Task ActualizarCategoria(Categoria categoriaActualizada)
        {
            var client = await Conexion.ConnectWithTimeoutAsync(10);
            await client.From<Categoria>().Update(categoriaActualizada);
        }

        // ELIMINAR CATEGORIA
        public static async Task EliminarCategoria(int id)
        {
            var client = await Conexion.ConnectWithTimeoutAsync(10);
            await client.From<Categoria>()
                .Filter("id_categoria", Operator.Equals, id)
                .Delete();
        }
    }
}