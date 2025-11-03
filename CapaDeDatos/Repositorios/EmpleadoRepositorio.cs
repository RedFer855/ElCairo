using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using Supabase.Interfaces;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supabase.Postgrest;

namespace CapaDeDatos.Repositorios 
{

    public class EmpleadoRepositorio
    {
        // INSERTAR UN EMPLEADO
        public static async Task InsertarEmpleado(Empleado nuevoEmpleado)
        {
            try
            {
                var client = await Conexion.ConnectWithTimeoutAsync(10);
                await client.From<Empleado>().Insert(nuevoEmpleado);
            }
            catch (System.Net.WebException ex)
            {
                throw new Exception("Error de red al guardar empleado: " + ex.Message, ex);
            }
            catch (TimeoutException ex)
            {
                throw new Exception("El servidor tardó demasiado en responder.", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de Supabase: {ex.Message}");
                throw /*new Exception("Error al guardar el empleado en la base de datos.", ex)*/;
            }
        }

        private async Task<Supabase.Client> GetClient()
        {
            // Llama al método estático de tu clase Conexion.cs
            return await Conexion.ConnectWithTimeoutAsync();
        }

        // Asegúrate de que tienes: using System.Threading; en este archivo.

        // 1. Aceptar el token de cancelación como parámetro opcional.
        public async Task<List<Empleado>> ObtenerTodosLosEmpleados(CancellationToken cancellationToken = default)
        {
            try
            {
                var client = await GetClient();
                var queryBuilder = client.From<Empleado>();
                queryBuilder.Order("id_empleado", Supabase.Postgrest.Constants.Ordering.Ascending);

                // CAMBIO: Se pasa el token al método .Get()
                var response = await queryBuilder.Get(cancellationToken);

                return response.Models ?? new List<Empleado>();
            }
            // CAMBIO: Se añade este 'catch' para el timeout
            catch (OperationCanceledException ex) when (cancellationToken.IsCancellationRequested)
            {
                throw new TimeoutException("La consulta de empleados fue cancelada por timeout.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron cargar los empleados. Verifique la conexión.", ex);
            }
        }
    }
}
