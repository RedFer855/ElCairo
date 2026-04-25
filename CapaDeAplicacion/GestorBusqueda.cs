using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeAplicacion
{
    public class GestorBusqueda<T>
    {
        private readonly IEnumerable<T> _listaMaestra;

        public GestorBusqueda(IEnumerable<T> listaMaestra)
        {
            _listaMaestra = listaMaestra ?? new List<T>();
        }

        public List<T> Buscar(string texto, Func<T, string, bool> criterioExacto, Func<T, string, bool> criterioParcial)
        {
            if (string.IsNullOrEmpty(texto)) return new List<T>();
            string busqueda = texto.Trim();

            // 1. Exacta
            if (criterioExacto != null)
            {
                var exacto = _listaMaestra.FirstOrDefault(x => criterioExacto(x, busqueda));
                if (exacto != null) return new List<T> { exacto };
            }

            // 2. Parcial
            if (criterioParcial != null)
            {
                return _listaMaestra.Where(x => criterioParcial(x, busqueda)).Take(20).ToList();
            }

            return new List<T>();
        }
        //hola
    }
}
