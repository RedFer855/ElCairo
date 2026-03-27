using CapaDeDatos;
using CapaServiciosSeguridadValidacion;
using ModernMenuUI;
using Supabase.Realtime;
using System;
using System;
using System.Windows.Forms;
using System.Windows.Forms;

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

            RealtimeManager.IniciarAsync().GetAwaiter().GetResult();

            Application.Run(new frmIniciosesion());
        }
    }
}