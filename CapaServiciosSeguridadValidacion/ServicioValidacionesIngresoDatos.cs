using CapaDeDatos.Modelados;
using CapaDeDatos.Modelados.Productos;
using CapaDeDatos.Modelados.UsuariosEmpleados;
using CapaDeDatos.Modelados.Ventas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CapaServiciosSeguridadValidacion
{
    public static class ServicioValidacionesIngresoDatos
    {
        private static readonly int[] LongitudesCodigoBarraPermitidas = new[] { 8, 12, 13 };

        public static readonly List<Func<ProductoInsertar, (bool Error, string Mensaje)>> ListaValidacionesProducto =
            new List<Func<ProductoInsertar, (bool Error, string Mensaje)>>()
            {
                p => CodigoBarraValido(p.CodigoBarraProducto, LongitudesCodigoBarraPermitidas),
                p => ValidarNombreApellido(p.NombreProducto, "el nombre del producto"),
                p => ValidarDecimalValido(p.PrecioCompra, "Precio de compra"),
                p => ValidarDecimalValido(p.PrecioVenta, "Precio venta"),
                p => ValidarSeleccion(p.IdCategoria, "una categoría"),
                p => ValidarSeleccion(p.IdMarca, "una marca"),
                p => ValidarSeleccion(p.IdPresentacion, "una presentación"),
                p => ValidarEnteroValido(p.CantidadProducto, "Cantidad"),
                p => ValidarCampoVacio(p.ContenidoProducto, "el contenido del producto"),
                //p => ValidarDecimalValido(p.PrecioVenta, "Precio costo"),
                //p => ValidarSeleccion(p.CantidadProducto,"La cantidad")
            };

        public static (bool Error, string Mensaje) EjecutarValidacionesProducto(ProductoInsertar producto)
        {
            foreach (var regla in ListaValidacionesProducto)
            {
                var resultado = regla(producto);
                if (resultado.Error) return resultado;
            }
            return (false, "");
        }

        public static readonly List<Func<Empleado, (bool Error, string Mensaje)>> ListaValidacionesEmpleado =
        new List<Func<Empleado, (bool Error, string Mensaje)>>()
        {
            e => ValidarDni(e.DniEmpleado, "el DNI"),
            e => ValidarNombreApellido(e.NombreEmpleado, "el nombre del empleado"),
            e => ValidarNombreApellido(e.ApellidoEmpleado, "el apellido del empleado"),
            e => ValidarTelefono(e.TelefonoEmpleado, "el teléfono"),
            e => ValidarEmail(e.EmailEmpleado, "el correo electrónico"),
            e => ValidarDireccion(e.DireccionEmpleado, "la dirección"),
        };

        public static (bool Error, string Mensaje) EjecutarValidacionesEmpleado(Empleado empleado)
        {
            foreach (var regla in ListaValidacionesEmpleado)
            {
                var resultado = regla(empleado);
                if (resultado.Error) return resultado;
            }
            return (false, "");
        }

        public static readonly List<Func<Categoria, (bool Error, string Mensaje)>> ListaValidacionesCategoria =
        new List<Func<Categoria, (bool Error, string Mensaje)>>()
        {
            c => ValidarNombreApellido(c.NombreCategoria, "el nombre de la categoría"),
            c => ValidarDireccion(c.DescripcionCategoria, "la descripción de la categoría"),
        };

        public static (bool Error, string Mensaje) EjecutarValidacionesCategoria(Categoria categoria)
        {
            foreach (var regla in ListaValidacionesCategoria)
            {
                var resultado = regla(categoria);
                if (resultado.Error) return resultado;
            }
            return (false, "");
        }

        public static readonly List<Func<MarcaInsertar, (bool Error, string Mensaje)>> ListaValidacionesMarca =
            new List<Func<MarcaInsertar, (bool Error, string Mensaje)>>()
            {
                m => ValidarNombreApellido(m.NombreMarca, "el nombre de la marca"),
                //m => ValidarDireccion(m, "la descripción de la marca"),
            };

        public static (bool Error, string Mensaje) EjecutarValidacionesMarca(MarcaInsertar _marca)
        {
            foreach (var regla in ListaValidacionesMarca)
            {
                var resultado = regla(_marca);
                if (resultado.Error) return resultado;
            }
            return (false, "");
        }

        public static readonly List<Func<Cliente, (bool Error, string Mensaje)>> ListaValidacionesCliente =
            new List<Func<Cliente, (bool Error, string Mensaje)>>
            {
                cl => ValidarDni(cl.DniCliente, "El dni"),
                cl => ValidarRtn(cl.RtnCliente, "El RTN"),
                cl => ValidarNombreApellido(cl.NombreCliente, "El nombre del cliente"),
                cl => ValidarTelefono(cl.TelefonoCliente, "El número telefónico"),
                cl => ValidarEmail(cl.CorreoCliente, "El correo electrónico"),
                cl => ValidarDireccion(cl.DireccionCliente, "La dirección")
            };

        public static (bool Error, string Mensaje) EjecutarValidacionesCliente(Cliente cliente)
        {
            foreach (var regla in ListaValidacionesCliente)
            {
                var resultado = regla(cliente);
                if (resultado.Error) return resultado;
            }
            return (false, "");
        }

        public static readonly List<Func<Presentacion, (bool Error, string Mensaje)>> ListaValidacionesPresentacion =
            new List<Func<Presentacion, (bool Error, string Mensaje)>>
            {
                p => ValidarNombreApellido(p.NombrePresentacion, "el nombre de la presentación"),
                p => ValidarDireccion(p.DetallePresentacion, "la descripción de la presentación"),

            };
        public static (bool Error, string Mensaje) EjecutarValidacionesPresentacion(Presentacion presentacion)
        {
            foreach (var regla in ListaValidacionesPresentacion)
            {
                var resultado = regla(presentacion);
                if (resultado.Error) return resultado;
            }
            return (false, "");
        }

        public static readonly List<Func<Proveedor, (bool Error, string Mensaje)>> ListaValidacionesProveedor =
            new List<Func<Proveedor, (bool Error, string Mensaje)>>
            {
                pr => ValidarNombreApellido(pr.NombreProveedor, "el nombre del proveedor"),
                pr => ValidarTelefono(pr.TelefonoProveedor, "el número telefónico"),
                pr => ValidarDireccion(pr.DireccionProveedor, "la dirección"),

            };
        public static (bool Error, string Mensaje) EjecutarValidacionesProveedor(Proveedor proveedor)
        {
            foreach (var regla in ListaValidacionesProveedor)
            {
                var resultado = regla(proveedor);
                if (resultado.Error) return resultado;
            }
            return (false, "");
        }

        public static readonly List<Func<Cliente, (bool Error, string Mensaje)>> ListaValidacionesClinte =
            new List<Func<Cliente, (bool Error, string Mensaje)>>
            {
                cl => ValidarDni(cl.DniCliente, "El dni"),
                cl => ValidarRtn(cl.RtnCliente, "El RTN"),
                cl => ValidarNombreApellido(cl.NombreCliente, "El nombre del cliente"),
                cl => ValidarTelefono(cl.TelefonoCliente, "El número telefónico"),
                cl => ValidarEmail(cl.CorreoCliente, "El correo electrónico"),
                cl => ValidarDireccion(cl.DireccionCliente, "La dirección")
            };
        public static (bool Error, string Mensaje) EjecutarValidacionesClinte(Cliente cliente)
        {
            foreach (var regla in ListaValidacionesClinte)
            {
                var resultado = regla(cliente);
                if (resultado.Error) return resultado;
            }
            return (false, "");
        }

        // --- Validaciones individuales ---
        public static (bool Error, string Mensaje) ValidarCampoVacio(string valor, string nombrecampo)
            => string.IsNullOrWhiteSpace(valor)
                ? (true, $"Debe ingresar {nombrecampo}.")
                : (false, "");

        public static (bool Error, string Mensaje) ValidarSeleccion(int id, string nombrecampo)
            => id <= 0
                ? (true, $"Debe seleccionar {nombrecampo}.")
                : (false, "");

        public static (bool Error, string Mensaje) CodigoBarraValido(string codigo, params int[] longitudesPermitidas)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                return (true, "El código de barras no puede estar vacío.");

            if (codigo.Contains(" ") || codigo.Contains("  "))
                return (true, $"El codigo no puede contener espacios.");

            if (!codigo.All(char.IsDigit))
                return (true, "El código de barras solo debe contener números (0-9).");

            if (!longitudesPermitidas.Contains(codigo.Length))
                return (true, $"El código de barras debe tener una longitud de {string.Join(", ", longitudesPermitidas)} dígitos.");

            return (false, "");
        }

        public static (bool Error, string Mensaje) ValidarDecimalValido(object valor, string nombrecampo)
        {
            if (valor == null) return (true, $"{nombrecampo} no puede estar vacío.");

            if (decimal.TryParse(valor.ToString(), out decimal d))
            {
                if (d < 0) return (true, $"{nombrecampo} no puede ser negativo.");
                return (false, "");
            }
            return (true, $"{nombrecampo} debe ser un número decimal válido.");
        }

        public static (bool Error, string Mensaje) ValidarEnteroValido(object valor, string nombrecampo)
        {
            if (valor == null) return (true, $"{nombrecampo} no puede estar vacío.");

            if (int.TryParse(valor.ToString(), out int i))
            {
                if (i < 0) return (true, $"{nombrecampo} no puede ser negativo.");
                return (false, "");
            }
            return (true, $"{nombrecampo} debe ser un número entero válido.");
        }
        /*
        public static (bool Error, string Mensaje) ValidarSoloNumeros(string valor, string nombrecampo)
        {
            if (string.IsNullOrWhiteSpace(valor))
                return (true, $"Debe ingresar {nombrecampo}.");
            if (valor.Contains(" ") || valor.Contains("  "))
                return (true, $"{nombrecampo} no puede contener espacios.");


            if (!valor.All(char.IsDigit))
                return (true, $"{nombrecampo} solo debe contener números.");

            return (false, "");
        }*/
        public static (bool Error, string Mensaje) ValidarTelefono(string valor, string nombrecampo)
        {
            if (valor == null)
                return (true, $"{nombrecampo} no puede estar vacío.");
            if (valor.Length > 9 || valor.Length < 8)
                return (true, $"{nombrecampo} debe tener 8 dígitos.");
            if (valor.Contains(" ") || valor.Contains("  "))
                return (true, $"{nombrecampo} no puede contener espacios.");

            if (!valor.All(char.IsDigit))
                return (true, $"{nombrecampo} solo debe contener números.");
            return (false, "");
        }
        public static (bool Error, string Mensaje) ValidarDni(string valor, string nombrecampo)
        {
            if (valor == null)
                return (true, $"{nombrecampo} no puede estar vacío.");
            if (valor.Length < 13 || valor.Length > 13)
            {
                return (true, $"{nombrecampo} debe de ser de 13 digitos");
            }
            if (int.TryParse(valor.ToString(), out int i))
            {
                if (i < 0) return (true, $"{nombrecampo} no puede ser negativo.");
                return (false, "");
            }
            if (valor.Contains(" ") || valor.Contains("  "))
                return (true, $"{nombrecampo} no puede contener espacios.");

            int contador = 1;

            for (int j = 1; j < valor.Length; j++)
            {
                if (valor[j] == valor[j - 1])
                {
                    contador++;
                    if (contador >= 5)
                        return (true, $"{nombrecampo} no puede contener más de 5 caracteres repetidos consecutivamente.");
                }
                else
                {
                    contador = 1;
                }
            }
            if (!valor.All(char.IsDigit))
                return (true, $"{nombrecampo} solo debe contener números.");

            return (false, "");
        }
        public static (bool Error, string Mensaje) ValidarNombreApellido(string valor, string nombrecampo)
        {
            if (valor == null)
                return (true, $"{nombrecampo} no puede estar vacío.");

            if (valor.Length < 2)
            {
                return (true, $"{nombrecampo} debe de tener minimo 2 letras.");
            }

            if (valor.Any(char.IsDigit))
                return (true, $"{nombrecampo} no puede contener números.");

            if (valor.Contains("  "))
                return (true, $"{nombrecampo} no puede contener multiples espacios.");

            if (!Regex.IsMatch(valor, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$"))
                return (true, $"{nombrecampo} solo puede contener letras con o sin tilde y espacios.");

            for (int i = 0; i < valor.Length - 2; i++)
            {
                if (valor[i] == valor[i + 1] && valor[i] == valor[i + 2])
                    return (true, $"{nombrecampo} no puede contener más de 3 caracteres repetidos consecutivamente.");
            }

            if (valor.Length > 150)
                return (true, $"{nombrecampo} no puede tener más de 150 caracteres.");

            return (false, "");
        }

        public static (bool Error, string Mensaje) ValidarEmail(string valor, string nombrecampo)
        {
            string email = @"^([a-z0-9_\.-]+@[\da-z\.-]+\.[a-z\.]{2,6})$";
            if (valor == null)
                return (true, $"{nombrecampo} no puede estar vacío.");
            if (!Regex.IsMatch(valor, email))
                return (true, $"{nombrecampo} no es un correo electrónico válido.");
            if (valor.Length > 250)
                return (true, $"{nombrecampo} no puede tener más de 250 caracteres.");
            if (valor.Contains(" ") || valor.Contains("  "))
                return (true, $"{nombrecampo} no puede contener espacios.");

            return (false, "");
        }
        public static (bool Error, string Mensaje) ValidarDireccion(string valor, string nombrecampo)
        {
            if (valor == null)
                return (true, $"{nombrecampo} no puede estar vacío.");
            if (valor.Length >= 301 || valor.Length < 10)
                return (true, $"{nombrecampo} no puede ser menor de 10 o mayor de 300 caracteres.");
            if (valor.Contains("  "))
                return (true, $"{nombrecampo} no puede contener multiples espacios.");

            return (false, "");
        }

        public static (bool Error, string Mensaje) ValidarRtn(string valor, string nombrecampo)
        {
            if (valor == null)
                return (true, $"{nombrecampo} no puede estar vacío.");
            if (valor.Length < 14 || valor.Length > 14)
                return (true, $"{nombrecampo} debe de ser de 14 digitos");
            if (int.TryParse(valor.ToString(), out int i))
                if (i < 0) return (true, $"{nombrecampo} no puede ser negativo.");
            if (valor.Contains(" ") || valor.Contains("  "))
                return (true, $"{nombrecampo} no puede contener espacios.");
            if (!valor.All(char.IsDigit))
                return (true, $"{nombrecampo} solo debe contener números.");
            int contador = 1;

            for (int j = 1; j < valor.Length; j++)
            {
                if (valor[j] == valor[j - 1])
                {
                    contador++;
                    if (contador >= 5)
                        return (true, $"{nombrecampo} no puede contener más de 5 caracteres repetidos consecutivamente.");
                }
                else
                {
                    contador = 1;
                }
            }

            return (false, "");
        }

        public static (bool Error, string Mensaje) ValidarContrasenia(string valor, string nombrecampo)
        {
            string contraseniaRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,}$";
            if (!Regex.IsMatch(valor, contraseniaRegex))
                return (true, $"{nombrecampo} debe tener al menos 8 caracteres, una mayúscula, una minúscula, un número y un carácter especial.");
            if (valor.Contains(" ") || valor.Contains("  "))
                return (true, $"{nombrecampo} no puede contener espacios.");

            return (false, "");
        }


    }
}