using BCrypt.Net;
using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using Microsoft.VisualBasic.Devices;
using Supabase;
using Supabase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Supabase.Postgrest.Constants;

namespace CapaDeDatos.Repositorios
{
    public class BodegasRepositorio
    {
            public static async Task<bool> IniciarSesion(string idBodega, string passwordInput)
            {
                try
                {
                    var supabaseClient = await Conexion.ConnectWithTimeoutAsync(10);

                    // Filtrar por ID de bodega (seguro contra inyecciones)
                    var bodegas = await supabaseClient
                        .From<Bodega>()
                        .Filter("id_bodega", Operator.Equals, idBodega)
                        .Get();

                    var bodega = bodegas.Models.FirstOrDefault();
                    if (bodega == null)
                    {
                        MessageBox.Show("Credenciales incorrectas o bodega no encontrada");
                        return false;
                    }

                    if (!bodega.EstadoBodega)
                    {
                        MessageBox.Show("La bodega está inactiva");
                        return false;
                    }

                    bool ok = PasswordHasher.VerifyHash(bodega.ContraseniaBodega, passwordInput);
                    if (!ok) {   
                        MessageBox.Show("Credenciales incorrectas");
                        return false;
                    }
                    // Si llegó hasta aquí, el login fue exitoso
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al buscar Bodega: {ex.Message}");
                    return false;
                }
            }

        protected static class PasswordHasher
        {
            public static string HashPassword(string plainPassword)
            {
                return BCrypt.Net.BCrypt.HashPassword(plainPassword);
            }

            public static bool VerifyHash(string storedHash, string passwordInput)
            {
                return BCrypt.Net.BCrypt.Verify(passwordInput, storedHash);
            }
        }

    }
}
