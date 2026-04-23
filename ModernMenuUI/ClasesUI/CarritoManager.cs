using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDeDatos.Modelados.Productos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModernMenuUI.ClasesUI
{
    /// <summary>
    /// Maneja toda la lógica del carrito de facturación.
    /// El formulario solo suscribe el evento CarritoCambiado
    /// y refresca el DGV — no hace cálculos.
    /// </summary>
    public class CarritoManager
    {
        private readonly List<ItemCarrito> _items = new List<ItemCarrito>();
        private readonly int _limiteProductos;

        /// <summary>Se dispara cada vez que el carrito cambia.</summary>
        public event EventHandler CarritoCambiado;

        public CarritoManager(int limiteProductos = 50)
        {
            _limiteProductos = limiteProductos;
        }

        // ── Propiedades de solo lectura ──────────────────────────
        public IReadOnlyList<ItemCarrito> Items => _items.AsReadOnly();
        public int CantidadItems => _items.Count;
        public decimal Subtotal => _items.Sum(i => i.TotalLinea);
        public decimal ISV => Math.Round(Subtotal * 0.15m, 2);
        public decimal Total => Subtotal + ISV;
        public bool EstaVacio => _items.Count == 0;

        // ── Operaciones ──────────────────────────────────────────

        /// <summary>
        /// Agrega o incrementa un producto.
        /// Retorna true si tuvo éxito, false si no hay stock suficiente.
        /// </summary>
        public bool AgregarProducto(Producto producto, int cantidad = 1)
        {
            if (producto == null || cantidad <= 0) return false;
            if (producto.StockEnBodega <= 0) return false;

            var existente = _items.FirstOrDefault(
                i => i.CodigoBarra == producto.CodigoBarraProducto);

            if (existente != null)
            {
                int nueva = existente.Cantidad + cantidad;
                if (nueva > existente.StockDisponible)
                {
                    existente.Cantidad = existente.StockDisponible;
                    CarritoCambiado?.Invoke(this, EventArgs.Empty);
                    return false; // stock insuficiente
                }
                existente.Cantidad = nueva;
            }
            else
            {
                if (_items.Count >= _limiteProductos) return false;

                _items.Add(new ItemCarrito
                {
                    CodigoBarra = producto.CodigoBarraProducto,
                    NombreProducto = producto.NombreProducto,
                    PrecioVenta = producto.PrecioVenta,
                    Cantidad = Math.Min(cantidad, producto.StockEnBodega),
                    StockDisponible = producto.StockEnBodega,
                    IdProducto = producto.IdProducto
                });
            }

            CarritoCambiado?.Invoke(this, EventArgs.Empty);
            return true;
        }

        /// <summary>Elimina un producto del carrito por código de barras.</summary>
        public void Eliminar(string codigoBarra)
        {
            _items.RemoveAll(i => i.CodigoBarra == codigoBarra);
            CarritoCambiado?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Modifica la cantidad de un producto.
        /// delta = +1 suma, -1 resta.
        /// </summary>
        public bool ModificarCantidad(string codigoBarra, int delta)
        {
            var item = _items.FirstOrDefault(i => i.CodigoBarra == codigoBarra);
            if (item == null) return false;

            int nueva = item.Cantidad + delta;
            if (nueva < 1 || nueva > item.StockDisponible) return false;

            item.Cantidad = nueva;
            CarritoCambiado?.Invoke(this, EventArgs.Empty);
            return true;
        }

        /// <summary>Vacía el carrito completamente.</summary>
        public void Limpiar()
        {
            _items.Clear();
            CarritoCambiado?.Invoke(this, EventArgs.Empty);
        }
    }
}