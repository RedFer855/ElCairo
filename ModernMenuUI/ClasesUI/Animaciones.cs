using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using FormsTimer = System.Windows.Forms.Timer;
using System.Windows.Forms;


namespace ModernMenuUI.ClasesUI
{
    internal class clsAnmaciones
    {
        public static string Titulo;
        public static Label TituloLabel;

        public clsAnmaciones(string nom, Label lbl) 
        {
            Titulo = nom;
            TituloLabel = lbl;
        }

        public static void NombreMenuPrincipal()
        {
            CambiarNombreMenu(TituloLabel,Titulo);
        }

        // Cambiar de NombreEmpleado un Label
        public static void CambiarNombreMenu(Label label, string Nombre)
        {
            label.Text = Nombre;
        }

        // Mover Formularios de pocisión
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(nint hwnd, int wmsg, int wparam, int lparam);

        public static void RegresarMenuPrincipal(string nombre)
        {
            
        }

     
        public static void MoverFormulario(nint handle)
        {
            ReleaseCapture();
            SendMessage(handle, 0x112, 0xf012, 0);
        }

        // Animaciones de Inicio de sesion Cuadros de texto
        public static void PrivacidadIngresarDatos(TextBox Caja, string Nombre)
        {
            if (Caja.Text == "CONTRASEÑA")
            {
                Caja.Text = Nombre;
                Caja.ForeColor = Color.DimGray;
                Caja.UseSystemPasswordChar = true;
            }
        }

        public static void ActivarDoubleBuffering(DataGridView control)
        {
            typeof(DataGridView).InvokeMember(
           "DoubleBuffered",
           System.Reflection.BindingFlags.SetProperty |
           System.Reflection.BindingFlags.Instance |
           System.Reflection.BindingFlags.NonPublic,
           null, control, new object[] { true });
        }

    }
}
