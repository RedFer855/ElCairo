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
    public partial class ProductoTarjeta : UserControl
    {
        public string urlImagen{ get; set; }
        public Image imagenSeleccionada { get; set; }

        public event EventHandler<string> ImagenSeleccionada;

        public event EventHandler<Image> ImagenSeleccionada_;
        public ProductoTarjeta()
        {
            InitializeComponent();
        }
        private async void ProductoTarjeta_Load(object sender, EventArgs e)
        {
        }

        public void AsignarImagen(Image img,string url)
        {
            imagenSeleccionada = img;
            urlImagen = url;
            imgProdTarjeta.Image = img;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ImagenSeleccionada?.Invoke(this, urlImagen);
            ImagenSeleccionada_?.Invoke(this, imagenSeleccionada);
            MessageBox.Show("Imagen Seleccionada"+urlImagen);
        }
    }
}
