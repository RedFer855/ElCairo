using System;
using System.Windows.Forms;
using ModernMenuUI;
using System;
using System.Windows.Forms;
using CapaDeDatos;

namespace ModernMenuUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            /*
            var cliente = clsConexion.GetClientAsync().GetAwaiter().GetResult();

            if (cliente == null)
            {
                MessageBox.Show("Las variables de entorno SUPABASE_URL o SUPABASE_KEY no están configuradas.", "Error de configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            */
            
            Application.Run(new frmIniciosesion());
        }
    }
}