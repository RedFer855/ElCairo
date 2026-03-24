using System;
using System.Threading.Tasks;
using Windows.Security.Credentials;
using Windows.Security.Credentials.UI;
using System.Security.Principal;

namespace ModernMenuUI.ServiciosUI
{
    public class ServicioBiometrico
    {
        private const string NOMBRE_RECURSO = "SistemaVentas_Supabase_Auth";

        public async Task<bool> EsPosibleUsarHuella()
        {
            try
            {
                var disponibilidad = await UserConsentVerifier.CheckAvailabilityAsync();
                return disponibilidad == UserConsentVerifierAvailability.Available;
            }
            catch { return false; }
        }

        public async Task<bool> VerificarIdentidad(string mensaje)
        {
            try
            {
                var resultado = await UserConsentVerifier.RequestVerificationAsync(mensaje);
                // Usamos (int)0 para evitar conflictos de nombres con el Enum
                return (int)resultado == 0;
            }
            catch { return false; }
        }
        public string ObtenerSidWindowsActual()
        {
            try
            {
                // Retorna el identificador único del usuario que tiene la sesión iniciada en Windows
                return WindowsIdentity.GetCurrent().User.Value;
            }
            catch { return string.Empty; }
        }

        public void GuardarTokenSeguro(string emailUsuario, string refreshToken)
        {
            var vault = new PasswordVault();
            var credencial = new PasswordCredential(NOMBRE_RECURSO, emailUsuario, refreshToken);
            vault.Add(credencial);
        }

        public string ObtenerTokenGuardado(string emailUsuario)
        {
            var vault = new PasswordVault();
            try
            {
                var credencial = vault.Retrieve(NOMBRE_RECURSO, emailUsuario);
                credencial.RetrievePassword();
                return credencial.Password;
            }
            catch { return null; }
        }

        public void BorrarToken(string emailUsuario)
        {
            var vault = new PasswordVault();
            try
            {
                var cred = vault.Retrieve(NOMBRE_RECURSO, emailUsuario);
                vault.Remove(cred);
            }
            catch { }
        }
    }
}
