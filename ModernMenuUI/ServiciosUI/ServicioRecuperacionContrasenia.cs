using CapaDeDatos.Datos;
using CapaDeDatos.Modelados.UsuariosEmpleados;
using Supabase.Gotrue;
using Supabase.Gotrue.Exceptions;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Supabase.Gotrue.Constants;

namespace ModernMenuUI.ServiciosUI
{
    public class ServicioRecuperacionContrasenia
    {

        public async Task<(bool ok, string mensaje, string correoNormalizado)> ValidarCorreoRegistradoAsync(string correo)
        {
            try
            {
                correo = (correo ?? string.Empty).Trim().ToLower();

                if (string.IsNullOrWhiteSpace(correo))
                    return (false, "Debe ingresar un correo.", null);

                if (!correo.Contains("@"))
                    correo += "@gmail.com";

                var client = await Conexion.GetClientAsync();

                var resultado = await client
                    .From<Usuario>()
                    .Where(x => x.AliasUsuario == correo && x.EstadoUsuario == true)
                    .Get();

                if (resultado.Models == null || resultado.Models.Count == 0)
                    return (false, "El correo no está registrado en el sistema.", null);

                return (true, "Correo válido.", correo);
            }
            catch (Exception ex)
            {
                return (false, "Error al validar el correo: " + ex.Message, null);
            }
        }



        private string NormalizarCorreo(string correo)
        {
            correo = (correo ?? string.Empty).Trim();

            if (string.IsNullOrWhiteSpace(correo))
                throw new ArgumentException("Debe ingresar un correo.");

            if (!correo.Contains("@"))
                correo += "@gmail.com";

            return correo.ToLower();
        }

        public async Task<(bool ok, string mensaje, string correoNormalizado)> EnviarCodigoAsync(string correo)
        {
            try
            {
                string correoNormalizado = NormalizarCorreo(correo);
                var client = await Conexion.GetClientAsync();

                // Usa el flujo passwordless por email.
                // Como la plantilla Magic link ahora muestra {{ .Token }},
                // Supabase enviará el código OTP al correo.
                bool enviado = await client.Auth.SendMagicLink(correoNormalizado);

                if (!enviado)
                    return (false, "No se pudo enviar el código.", null);

                return (true, "Se envió el código al correo.", correoNormalizado);
            }
            catch (GotrueException ex)
            {
                return (false, "No se pudo enviar el código: " + ex.Message, null);
            }
            catch (Exception ex)
            {
                return (false, "Error al enviar el código: " + ex.Message, null);
            }
        }

        public async Task<(bool ok, string mensaje)> VerificarCodigoAsync(string correo, string codigo)
        {
            try
            {
                string correoNormalizado = NormalizarCorreo(correo);
                codigo = (codigo ?? string.Empty).Trim();

                if (!Regex.IsMatch(codigo, @"^\d{6}$"))
                    return (false, "El código debe tener 6 dígitos numéricos.");

                var client = await Conexion.GetClientAsync();

                // Para OTP por email, el tipo correcto es Email.
                var session = await client.Auth.VerifyOTP(
                    correoNormalizado,
                    codigo,
                    EmailOtpType.Email
                );

                if (session == null)
                    return (false, "No se pudo validar el código.");

                return (true, "Código verificado correctamente.");
            }
            catch (GotrueException ex)
            {
                return (false, "Código inválido o expirado: " + ex.Message);
            }
            catch (Exception ex)
            {
                return (false, "Error al verificar el código: " + ex.Message);
            }
        }

        public async Task<(bool ok, string mensaje)> CambiarContraseniaAsync(string nuevaContrasenia, string confirmarContrasenia)
        {
            try
            {
                nuevaContrasenia = (nuevaContrasenia ?? string.Empty).Trim();
                confirmarContrasenia = (confirmarContrasenia ?? string.Empty).Trim();

                if (string.IsNullOrWhiteSpace(nuevaContrasenia) || string.IsNullOrWhiteSpace(confirmarContrasenia))
                    return (false, "Debe completar ambos campos.");

                if (nuevaContrasenia != confirmarContrasenia)
                    return (false, "Las contraseñas no coinciden.");

                if (nuevaContrasenia.Length < 6)
                    return (false, "La contraseña debe tener al menos 6 caracteres.");

                var client = await Conexion.GetClientAsync();

                var atributos = new UserAttributes
                {
                    Password = nuevaContrasenia
                };

                var usuarioActualizado = await client.Auth.Update(atributos);

                if (usuarioActualizado == null)
                    return (false, "No se pudo actualizar la contraseña.");

                return (true, "Contraseña actualizada correctamente.");
            }
            catch (GotrueException ex)
            {
                return (false, "No se pudo actualizar la contraseña: " + ex.Message);
            }
            catch (Exception ex)
            {
                return (false, "Error al cambiar la contraseña: " + ex.Message);
            }
        }


    }
}