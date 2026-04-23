using CapaDeDatos.Datos;
using CapaDeDatos.Modelados.Productos;
using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI.ClasesUI
{
    public partial class ProductoSugerenciaItem : UserControl
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        // ← URL base de tu Supabase Storage — cámbiala por la tuya
        private const string STORAGE_URL =
            "https://TUPROYECTO.supabase.co/storage/v1/object/public/productos/";

        public Producto Producto { get; private set; }

        public event EventHandler<Producto> ProductoAgregado;

        public ProductoSugerenciaItem()
        {
            InitializeComponent();
            this.Click += (s, e) => DispararAgregar();
            pbxImagen.Click += (s, e) => DispararAgregar();
            lblNombre.Click += (s, e) => DispararAgregar();
            btnAgregar.Click += (s, e) => DispararAgregar();
        }

        public async Task CargarAsync(Producto producto)
        {
            if (producto == null) return;
            Producto = producto;

            // ✅ Usar NombreProducto directo — ya viene concatenado 
            // desde BarraProductosSugeridos (nombre + marca + contenido)
            lblNombre.Text = producto.NombreProducto;
            lblPrecio.Text = $"L. {producto.PrecioVenta:N2}";
            lblStock.Text = $"Stock: {producto.StockEnBodega}";

            bool disponible = producto.StockEnBodega > 0;
            lblNoDisponible.Visible = !disponible;
            btnAgregar.Visible = disponible;
            btnAgregar.Enabled = disponible;

            lblPrecio.ForeColor = disponible
                ? Color.FromArgb(149, 195, 172)
                : Color.Gray;
            lblStock.ForeColor = disponible
                ? Color.Gray
                : Color.FromArgb(220, 90, 90);

            await CargarImagenAsync(producto.ImagenProducto);
        }

        private async Task CargarImagenAsync(string nombreArchivo)
        {
            // Sin imagen o valor inválido → imagen por defecto
            if (string.IsNullOrWhiteSpace(nombreArchivo)
                || nombreArchivo == "SIN_IMAGEN"
                || nombreArchivo == "NULL")
            {
                pbxImagen.Image = Properties.Resources.sin_imagen;
                return;
            }

            try
            {
                // ✅ Forma correcta según docs de Supabase C#
                var client = await Conexion.GetClientAsync();

                string urlPublica;

                // Si ya es una URL completa la usamos directo
                if (nombreArchivo.StartsWith("http"))
                {
                    urlPublica = nombreArchivo;
                }
                else
                {
                    // Usar GetPublicUrl del SDK — nombre del bucket donde guardas imágenes
                    urlPublica = client.Storage
                        .From("imagenes_productos")  // ← cambia por el nombre de tu bucket
                        .GetPublicUrl(nombreArchivo);
                }

                // Descargar y mostrar
                using var httpClient = new HttpClient();
                byte[] bytes = await httpClient.GetByteArrayAsync(urlPublica);
                using var ms = new MemoryStream(bytes);

                var img = Image.FromStream(ms);
                if (!this.IsDisposed)
                    pbxImagen.Image = img;
            }
            catch
            {
                if (!this.IsDisposed)
                    pbxImagen.Image = Properties.Resources.sin_imagen;
            }
        }

        private void DispararAgregar()
        {
            if (Producto != null && Producto.StockEnBodega > 0)
                ProductoAgregado?.Invoke(this, Producto);
        }
    }
}