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
            var nombresImagenes = await nombreImg.ListarImagenes();

            GridColumnas.Controls.Clear();

            foreach (var nombre in nombresImagenes)
            {
                var imagen = await nombreImg.LeerImagenes(nombre);

                ProductoTarjeta producto = new ProductoTarjeta();
                producto.AsignarImagen(imagen);

                GridColumnas.Controls.Add(producto);
            }
        }
    }
}
