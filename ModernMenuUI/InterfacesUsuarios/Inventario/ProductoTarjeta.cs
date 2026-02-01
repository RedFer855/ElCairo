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
        RepositorioImgenSupabase repositorioImg = new RepositorioImgenSupabase();
        public ProductoTarjeta()
        {
            InitializeComponent();
        }
        private async void ProductoTarjeta_Load(object sender, EventArgs e)
        {
        }

        public void AsignarImagen(Image img)
        {
            imgProdTarjeta.Image = img;
        }   

    }
}
