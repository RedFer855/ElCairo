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
                // 1. Obtiene la conexión
                var client = await GetClient();

                // 2. INICIALIZA el constructor de consultas (queryBuilder)
                var queryBuilder = client.From<Empleado>();

                // 3. CONSTRUYE la consulta (Aplica la Ordenación)
                queryBuilder.Order("id_empleado", Supabase.Postgrest.Constants.Ordering.Ascending);

                // 4. EJECUTA la consulta, PASANDO EL TOKEN. 
                //    Si el token se cancela (ej. después de 10 segundos), esta línea lanza OperationCanceledException.
                var response = await queryBuilder.Get(cancellationToken);

                // 5. Devuelve la lista de modelos (objetos Empleado)
                if (response != null && response.Models != null)
                {
                    return response.Models;
                }

                return new List<Empleado>();
            }
            // 6. CAPTURA EXPLÍCITA del error de timeout. 
            //    Si la operación falla por timeout (OperationCanceledException), relanzamos como un TimeoutException.
            catch (OperationCanceledException ex) when (cancellationToken.IsCancellationRequested)
            {
                throw new TimeoutException("Tiempo de espera agotado, verifique su conexión", ex);
            }
            catch (Exception ex)
            {
                // 7. Manejo de otros errores (red, Supabase, etc.)
                Console.WriteLine($"Error de Supabase al obtener empleados: {ex.Message}");
                throw new Exception("No se pudieron cargar los empleados. Verifique la conexión.", ex);
            }
        }
    }
}
