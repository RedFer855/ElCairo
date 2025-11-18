using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace CapaDeDatos.Repositorios
{
    public class ProveedorRepositorio
    {
        // 1. Obtener TODOS los proveedores (para guardar en caché)
        public async Task<List<Proveedor>> ObtenerTodosLosProveedores()
        {
            try
            {
                var supabase = await Conexion.GetClientAsync();

                // Traemos todos los proveedores que estén activos (estado_proveedor = true)
                // Si quieres traer también los inactivos, quita el .Filter
                var response = await supabase
                    .From<Proveedor>()
                    .Select("*")
                    .Filter("estado_proveedor", Supabase.Postgrest.Constants.Operator.Equals, "true")
                    .Order("nombre_proveedor", Supabase.Postgrest.Constants.Ordering.Ascending)
                    .Get();

                return response.Models;
            }
            catch (Exception ex)
            {
                // Es buena práctica lanzar la excepción para manejarla en el formulario
                throw new Exception($"Error al obtener proveedores: {ex.Message}");
            }
        }

        // 2. Buscar proveedores por coincidencia de nombre (Búsqueda directa a la BD)
        // NOTA: Como ya tienes una lista en memoria en el form, este método es opcional,
        // pero útil si la lista es demasiado grande.
        public async Task<List<Proveedor>> BuscarProveedoresPorNombre(string terminoBusqueda)
        {
            try
            {
                var supabase = await Conexion.GetClientAsync();

                var response = await supabase
                    .From<Proveedor>()
                    .Select("*")
                    .Filter("estado_proveedor", Supabase.Postgrest.Constants.Operator.Equals, "true")
                    .Filter("nombre_proveedor", Supabase.Postgrest.Constants.Operator.ILike, $"%{terminoBusqueda}%") // ILike es Case Insensitive
                    .Get();

                return response.Models;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error buscando proveedor: {ex.Message}");
            }
        }

        // 3. Obtener un proveedor por su ID (útil para validaciones)
        public async Task<Proveedor> ObtenerProveedorPorId(int id)
        {
            try
            {
                var supabase = await Conexion.GetClientAsync();

                var response = await supabase
                    .From<Proveedor>()
                    .Select("*")
                    .Filter("id_proveedor", Supabase.Postgrest.Constants.Operator.Equals, id)
                    .Single();

                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task InsertarProveedor(Proveedor nuevoProveedor)
        {
            try
            {
                var supabase = await Conexion.GetClientAsync();

                // Supabase inserta el objeto y devuelve la respuesta
                await supabase
                    .From<Proveedor>()
                    .Insert(nuevoProveedor);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al insertar proveedor: {ex.Message}");
            }
        }
        public async Task ActualizarProveedor(Proveedor proveedorEditar)
        {
            try
            {
                var supabase = await Conexion.GetClientAsync();

                // Actualiza el registro donde coincida el ID
                await supabase
                    .From<Proveedor>()
                    .Update(proveedorEditar);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar proveedor: {ex.Message}");
            }
        }
       
    }
}