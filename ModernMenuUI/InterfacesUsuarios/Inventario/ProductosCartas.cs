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
            var repo = new RepositorioImgenSupabase();

            GridColumnas.Controls.Clear();
            //listando las imagenes (los nombres del archivo )
            var nombresImagenes = await repo.ListarImagenes();

            //cargando las imagenes en las tarjetas
            foreach (var nombre in nombresImagenes)
            {
                var tarjeta = new ProductoTarjeta();    
                GridColumnas.Controls.Add(tarjeta);

                //descargando la imagen para ponerla en la tarjeta
                var imagen = await repo.descargarImagenes(nombre);
                tarjeta.AsignarImagen(imagen, nombre);

                //cuando la imagen se selecciona, se activa el evento, se envia el nombre y la url
                //para ingresarlo al image view 
                tarjeta.ImagenSeleccionada += (s, url) =>
                {
                    ImagenSeleccionada?.Invoke(this, url);
                    this.Close();
                };

                //await Task.Delay(75); 

            }
            /*
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

            GridColumnas.ResumeLayout();*/
        }


    }
}
