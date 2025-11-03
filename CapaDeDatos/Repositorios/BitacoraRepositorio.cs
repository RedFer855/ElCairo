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
                string DescCambio,
                string fechaCambio,
                string datosComp
               // string estadoAnterior,
                //string campoAfectado
                /*Accion accion,
                Modulo modulo*/
                )
            {
                try
                {           
                    var bitacora = new Modelados.Bitocora_Empleado
                    {
                        Descripcion = DescCambio,
                        Fecha_Hora = DateTime.Now,
                        datos_comp = datosComp,
                    };
                    await client.From<Bitocora_Empleado>().Insert(bitacora);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al insertar datos en bitacora: {ex.Message}");
                }


            }
        }
    }
}
