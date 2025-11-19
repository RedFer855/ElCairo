using CapaDeDatos.Modelados.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaServiciosSeguridadValidacion
{
    public static class ServicioValidacionesIngresoDatos
    {
        private static readonly int[] LongitudesCodigoBarraPermitidas = new[] { 8, 12, 13 };

        public static readonly List<Func<Producto, (bool Error, string Mensaje)>> ListaValidacionesProducto =
            new List<Func<Producto, (bool Error, string Mensaje)>>()
            {
                p => CodigoBarraValido(p.CodigoBarraProducto, LongitudesCodigoBarraPermitidas),
                p => ValidarCampoVacio(p.NombreProducto, "el nombre del producto"),
                p => ValidarSeleccion(p.IdMarca, "una marca"),
                p => ValidarSeleccion(p.IdCategoria, "una categoría"),
                p => ValidarSeleccion(p.IdPresentacion, "una presentación"),
                p => ValidarSeleccion(p.IdTamanio, "un tamaño"),
                p => ValidarCampoVacio(p.ContenidoProducto, "el contenido del producto"),
                p => ValidarDecimalValido(p.PrecioCompra, "Precio de compra"),
                p => ValidarDecimalValido(p.PrecioCosto, "Precio costo"),
                p => ValidarDecimalValido(p.PrecioVenta, "Precio venta"),
                p => ValidarEnteroValido(p.CantidadProducto, "Cantidad")
            };

        public static (bool Error, string Mensaje) EjecutarValidacionesProducto(Producto producto)
        {
            foreach (var regla in ListaValidacionesProducto)
            {
                var resultado = regla(producto);
                if (resultado.Error) return resultado;
            }
            return (false, "");
        }

        // --- Validaciones individuales ---
        public static (bool Error, string Mensaje) ValidarCampoVacio(string valor, string nombreCampo)
            => string.IsNullOrWhiteSpace(valor)
                ? (true, $"Debe ingresar {nombreCampo}.")
                : (false, "");

        public static (bool Error, string Mensaje) ValidarSeleccion(int id, string nombreCampo)
            => id <= 0
                ? (true, $"Debe seleccionar {nombreCampo}.")
                : (false, "");

        public static (bool Error, string Mensaje) CodigoBarraValido(string codigo, params int[] longitudesPermitidas)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                return (true, "El código de barras no puede estar vacío.");

            if (!codigo.All(char.IsDigit))
                return (true, "El código de barras solo debe contener números (0-9).");

            if (!longitudesPermitidas.Contains(codigo.Length))
                return (true, $"El código de barras debe tener una longitud de {string.Join(", ", longitudesPermitidas)} dígitos.");

            return (false, "");
        }

        public static (bool Error, string Mensaje) ValidarDecimalValido(object valor, string nombreCampo)
        {
            if (valor == null) return (true, $"{nombreCampo} no puede estar vacío.");

            if (decimal.TryParse(valor.ToString(), out decimal d))
            {
                if (d < 0) return (true, $"{nombreCampo} no puede ser negativo.");
                return (false, "");
            }
            return (true, $"{nombreCampo} debe ser un número decimal válido.");
        }

        public static (bool Error, string Mensaje) ValidarEnteroValido(object valor, string nombreCampo)
        {
            if (valor == null) return (true, $"{nombreCampo} no puede estar vacío.");

            if (int.TryParse(valor.ToString(), out int i))
            {
                if (i < 0) return (true, $"{nombreCampo} no puede ser negativo.");
                return (false, "");
            }
            return (true, $"{nombreCampo} debe ser un número entero válido.");
        }
    }
}
