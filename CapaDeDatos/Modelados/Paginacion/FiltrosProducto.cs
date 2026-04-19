using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados.Paginacion
{
    /// <summary>
    /// Agrupa todos los filtros para búsqueda de productos.
    /// El UI lo arma y el repositorio lo consume.
    /// </summary>
    public class FiltrosProducto
    {
        public string TextoBusqueda { get; set; }
        public int? IdMarca { get; set; }
        public int? IdCategoria { get; set; }
        public bool? Estado { get; set; }    // null = todos los estados
        public int Pagina { get; set; } = 1;
        public int TamanioPagina { get; set; } = 100;
    }
}