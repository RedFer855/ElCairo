using CapaDeDatos.Datos;
using CapaDeDatos.Modelados.UsuariosEmpleados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Repositorios
{

    public class BitacoraRepositorio
    {
        private async Task<Supabase.Client> GetClient()
        {
            return await Conexion.ConnectWithTimeoutAsync(3);
        }

        public async Task<List<Bitacora>> ObtenerTodasLasBitacoras(CancellationToken cancellationToken = default)
        {
            try
            {
                var client = await GetClient();
                var response = await client
                                        .From<Bitacora>()
                                        .Select("*, usuario(*)") 
                                        .Order("fecha_hora", Supabase.Postgrest.Constants.Ordering.Descending)
                                        .Get(cancellationToken);

                //queryBuilder.Order("fecha_hora", Supabase.Postgrest.Constants.Ordering.Descending);

                // Se pasa el token al método .Get() para permitir la cancelación
               // var response = await queryBuilder.Get(cancellationToken);

                return response.Models ?? new List<Bitacora>();
            }
            catch (OperationCanceledException ex) when (cancellationToken.IsCancellationRequested)
            {
                throw new TimeoutException("La consulta de bitácoras fue cancelada por tiempo de espera Agotado.", ex);
            }
            catch (Exception ex)
            {
                throw; //new Exception("No se pudieron cargar los registros de bitácora.", ex);
            }
        }
    }
}
