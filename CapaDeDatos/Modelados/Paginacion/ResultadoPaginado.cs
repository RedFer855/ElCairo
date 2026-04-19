using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados.Paginacion
{
    /// <summary>
    /// Contenedor genérico para resultados paginados desde Supabase.
    /// NO es una tabla, solo un DTO de transporte.
    /// </summary>
    public class ResultadoPaginado<T> where T : class
    {
        public List<T> Items { get; set; } = new List<T>();
        public int PaginaActual { get; set; }
        public int TamanioPagina { get; set; }
        public long TotalRegistros { get; set; }

        public int TotalPaginas =>
            TamanioPagina <= 0
                ? 0
                : (int)System.Math.Ceiling((double)TotalRegistros / TamanioPagina);

        public bool TienePaginaAnterior => PaginaActual > 1;
        public bool TienePaginaSiguiente => PaginaActual < TotalPaginas;
    }
}
