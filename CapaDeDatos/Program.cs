// EN: GlobalUsings.cs

// --- LIBRERÍAS DE SUPABASE ---
// Ahora no necesitas ponerlas en Empleado.cs, Usuario.cs, etc.
global using Supabase.Postgrest.Attributes;
global using Supabase.Postgrest.Models;
global using Supabase;

// --- LIBRERÍAS COMUNES DE .NET ---
// Estas son las que siempre repites en todos los archivos.
global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text;
global using System.Threading.Tasks;
global using System.Windows.Forms; // (Si estás en el proyecto de UI)

// --- TUS PROPIOS PROYECTOS ---
// (Esto es muy útil en tu proyecto de UI, para no tener
// que escribir 'using CapaDeDatos' en cada formulario)
global using CapaDeDatos;

namespace CapaDeDatos
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
            Application.Run(new Form1());
        }
    }
}