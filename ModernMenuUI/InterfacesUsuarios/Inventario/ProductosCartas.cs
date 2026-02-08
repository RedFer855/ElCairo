using CapaDeDatos.Repositorios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI.InterfacesUsuarios.Inventario
{
    public partial class ProductosCartas : Form
    {
        RepositorioImgenSupabase nombreImg = new RepositorioImgenSupabase();
        public event EventHandler<string> ImagenSeleccionada;
        public event EventHandler<Image> ImagenSeleccionada_;

        public ProductosCartas()
        {
            InitializeComponent();
        }

        private async void ProductosCartas_Load(object sender, EventArgs e)
        {
            await cargarImagenes();
        }

        private async Task cargarImagenes()
        {
            /*var nombreImg = new RepositorioImgenSupabase();

            var nombresImagenes = await nombreImg.ListarImagenes();

            GridColumnas.Controls.Clear();

            foreach (var nombre in nombresImagenes)
            {
                var imagen = await nombreImg.LeerImagenes(nombre);

                ProductoTarjeta producto = new ProductoTarjeta();
                //producto.AsignarImagen(imagen);

                GridColumnas.Controls.Add(producto);
            }*/

            var repo = new RepositorioImgenSupabase();
            var imagenes = await repo.ObtenerTodasLasImagenes();

            GridColumnas.SuspendLayout();

            foreach (var item in imagenes)
            {
                var tarjeta = new ProductoTarjeta();
                tarjeta.AsignarImagen(item.imagen,item.nombre);
                tarjeta.ImagenSeleccionada += (s, url) =>
                {
                    ImagenSeleccionada?.Invoke(this, url);
                    this.Close();

                };

                tarjeta.ImagenSeleccionada_ += (s, img) =>
                {
                    ImagenSeleccionada_?.Invoke(this, img);
                };

                GridColumnas.Controls.Add(tarjeta);
            }

            GridColumnas.ResumeLayout();
        }


    }
}
