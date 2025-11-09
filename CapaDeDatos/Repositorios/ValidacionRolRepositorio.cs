using CapaDeDatos.Modelados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Supabase.Postgrest.Constants;


namespace CapaDeDatos.Repositorios
{
    public class ValidacionRolRepositorio
    {
        private readonly UsuarioRepositorio _usuarioRepo;

        public ValidacionRolRepositorio()
        {
            _usuarioRepo = new UsuarioRepositorio();
        }

        // 🔹 Obtener el rol de un usuario usando UsuarioRepositorio
        public async Task<Rol> ObtenerRolDeUsuario(string uuidUsuario, CancellationToken cancellationToken = default)
        {
            try
            {
                // Asegúrate que tu UsuarioRepositorio tenga este método
                var usuario = await _usuarioRepo.ObtenerDatosUsuario(uuidUsuario, cancellationToken);
                if (usuario == null)
                    throw new Exception($"Usuario con UUID {uuidUsuario} no encontrado.");

                var client = await _usuarioRepo.GetClient(); // Reutilizamos el helper
                var rolResponse = await client
                    .From<Rol>()
                    .Where(r => r.IdRol == usuario.RolUsuario)
                    .Get(cancellationToken);

                return rolResponse.Models.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el rol del usuario.", ex);
            }
        }

        public async Task<List<acciones>> ObtenerAccionesPorRol(int rolId, CancellationToken ct = default)
        {
            var client = await _usuarioRepo.GetClient();

            // 1️⃣ Obtenemos las relaciones entre rol y acciones
            var relacionesResponse = await client
                .From<AccionRol>()
                .Where(ar => ar.IdRol == rolId)
                .Get(ct);

            var accionIds = relacionesResponse.Models
                .Select(ar => ar.IdAccion)
                .Distinct()
                .ToList();

            if (!accionIds.Any())
                return new List<acciones>();

            // 2️⃣ Filtramos las acciones usando Operator.In
            var idsAsObjects = accionIds.Cast<object>().ToList();

            var accionesFiltradasResponse = await client
                .From<acciones>()
                .Filter(a => a.Id, Operator.In, idsAsObjects) // Ajusta 'Id' según el nombre exacto de tu propiedad
                .Get(ct);

            return accionesFiltradasResponse.Models;
        }

        // 🔹 Construye el contexto completo
        public async Task<UsuarioContexto> ConstruirContexto(string uuidUsuario, CancellationToken cancellationToken = default)
        {
            var rol = await ObtenerRolDeUsuario(uuidUsuario, cancellationToken);
            if (rol == null)
                throw new Exception("No se pudo determinar el rol del usuario.");

            var acciones = await ObtenerAccionesPorRol(rol.IdRol, cancellationToken);

            return new UsuarioContexto
            {
                UsuarioId = uuidUsuario,
                Rol = rol,
                AccionesPermitidas = acciones
            };
        }
    }
}
