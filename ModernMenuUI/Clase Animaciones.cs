using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using FormsTimer = System.Windows.Forms.Timer;
using ModernMenuUI;
using System.Windows.Forms;


namespace ModernMenuUI
{
    internal class Clase_Animaciones
    {
 
        // Mover Formularios de pocisión
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        // Cambiar de Nombre un Label
        public static void CambiarNombreMenu(Label label, String Nombre)
        { 
            label.Text = Nombre;   
        }
        public static void MoverFormulario(IntPtr handle)
        {
            ReleaseCapture();
            SendMessage(handle, 0x112, 0xf012, 0);
        }

        // Animaciones de Inicio de sesion Cuadros de texto
        public static void PrivacidadIngresarDatos(TextBox Caja, String Nombre)
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
