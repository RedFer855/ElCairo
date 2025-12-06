using CapaDeDatos;
using CapaDeDatos.Repositorios;
using ModernMenuUI;
using ModernMenuUI.InterfacesUsuarios.MenuPrincipal_Ajustes;
using Supabase.Realtime;
using System;
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
            //Application.Run(new frmIniciosesion());
            // Application.Run(new frmConfiguracionInicial());

            bool esPrimerUso = false;
            var usuarioRepo = new UsuarioRepositorio();

            try
            {
                esPrimerUso = usuarioRepo.VerificarPrimerUsoAsync().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error verificando el estado del sistema: {ex.Message}",
                    "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (esPrimerUso)
            {
                Application.Run(new frmConfiguracionInicial());
            }
            else
            {
                Application.Run(new frmIniciosesion());
            }

        }
    }
}