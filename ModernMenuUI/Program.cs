using System;
using System.Windows.Forms;
using ModernMenuUI;
using System;
using System.Windows.Forms;
using CapaDeDatos;
using Supabase.Realtime;
using ModernMenuUI.InterfacesUsuarios.PrimerInicio;

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
            ApplicationConfiguration.Initialize();
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmBienvenida());
        }
    }
}