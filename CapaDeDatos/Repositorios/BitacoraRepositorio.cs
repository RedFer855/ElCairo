using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static CapaDeDatos.Modelados.Bitocora_Empleado;

namespace CapaDeDatos.Repositorios
{
    public class BitacoraRepositorio
    {


        public static class BitacoraService
        {

            public static async Task RegistrarBitacoraAsync(
                Client client,
                int idEmpleado,
                string estadoAnterior,
                string estadoActual,
                string campoAfectado
                /*Accion accion,
                Modulo modulo*/
                )
            {
                try
                {
                    var cliente = await Conexion.GetClientAsync();
                    string nombreComputadora = Environment.MachineName;
                    string usuarioWindows = Environment.UserName;
                    var bitacora = new Modelados.Bitocora_Empleado
                    {
                        Id_Empleado = idEmpleado,
                        Estado_Anterior = estadoAnterior,
                        Estado_Actual = estadoActual,
                        Campo_Afectado = campoAfectado,
                        Campo_Extra = $"{nombreComputadora} - {usuarioWindows}",
                        /* Id_Accion = (int)accion,   // convertir enum a número
                            Id_Modulo = (int)modulo*/
                    };
                    await cliente.From<Bitocora_Empleado>().Insert(bitacora);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al insertar datos en bitacora: {ex.Message}");
                }


            }
        }
    }
}
