using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using CapaDeDatos.Modelados.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Repositorios
{
    public class ClienteRepositorio
    {
        // Traer todos los clientes activos
        public async Task<List<Cliente>> ObtenerTodosLosClientes()
        {
            try
            {
                var supabase = await Conexion.GetClientAsync();

                var response = await supabase
                    .From<Cliente>() // Asegúrate de tener el modelo Cliente.cs
                    .Select("*")
                    // .Filter("estado_cliente", Supabase.Postgrest.Constants.Operator.Equals, "true") // Descomenta si tienes columna estado
                    .Order("nombre_cliente", Supabase.Postgrest.Constants.Ordering.Ascending)
                    .Get();

                return response.Models;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener clientes: {ex.Message}");
            }
        }
    }
}