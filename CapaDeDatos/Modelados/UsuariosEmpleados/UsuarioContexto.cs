using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados.UsuariosEmpleados
{
    public class UsuarioContexto
    {
        public string UsuarioId { get; set; }
        public Rol Rol { get; set; } 
        public List<acciones> AccionesPermitidas { get; set; } = new(); 

        public bool TieneAcceso(string NombreAccion)
        {
            return AccionesPermitidas?.Any(a => a.NombreAccion?.Trim().ToLower() == NombreAccion?.Trim().ToLower()) == true;
        }
    }
}
