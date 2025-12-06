using CapaDeDatos.Modelados.Inventario;
using CapaDeDatos.Modelados.UsuariosEmpleados;
using CapaDeDatos.Repositorios;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI.InterfacesUsuarios.MenuPrincipal_Ajustes
{
    public partial class frmConfiguracionInicial : Form
    {
        private readonly UsuarioRepositorio _usuarioRepo;
        private readonly BodegaRepositorio _bodegaRepo;
        public frmConfiguracionInicial()
        {
            InitializeComponent();
            _usuarioRepo = new UsuarioRepositorio();
            _bodegaRepo = new BodegaRepositorio();
        }
        private string HashPassword(string password)
        {
            // Nota: Este es un placeholder. Usa tu método de hasheo seguro (ej. BCrypt).
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        private bool ValidarCampos()
        {
            return !string.IsNullOrWhiteSpace(txtUsuario.Text) &&
                   !string.IsNullOrWhiteSpace(txtContraUsuario.Text) &&
                   !string.IsNullOrWhiteSpace(txtBodega.Text) &&
                   !string.IsNullOrWhiteSpace(txtContraBodega.Text);
        }

        private async void btnCrear_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                MessageBox.Show("Por favor, complete todos los campos requeridos.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. HASHEO DE CONTRASEÑAS
            // Los repositorios ahora recibirán el hash, no el texto plano.
            string usuarioPasswordHash = HashPassword(txtContraUsuario.Text);
            string bodegaPasswordHash = HashPassword(txtContraBodega.Text);

            try
            {
                // --- 3. CREACIÓN DEL SUPER ADMINISTRADOR (Auth y Perfil) ---
                // Se asume que el alias del usuario es un correo electrónico.
                Usuario adminCreado = await _usuarioRepo.CrearUsuarioAdminFinalAsync(
                    txtUsuario.Text,
                    txtContraUsuario.Text // Se usa texto plano aquí, ya que el servicio Auth de Supabase lo hashea internamente.
                );

                if (adminCreado == null)
                {
                    MessageBox.Show("Fallo al crear el perfil de administrador.", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // --- 4. CREACIÓN DE LA BODEGA ---

                // El repositorio de bodega recibe el nombre y el HASH de la contraseña de bodega.
                Bodega bodegaInsertada = await _bodegaRepo.CrearBodegaFinalAsync(
                    txtBodega.Text,
                    bodegaPasswordHash // Pasamos el HASH de la contraseña de la bodega
                );

                if (bodegaInsertada == null)
                {
                    MessageBox.Show("Fallo al crear la bodega.", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // --- 5. TRANSICIÓN EXITOSA ---
                MessageBox.Show("¡Configuración Inicial Completa! Intente iniciar sesión con su nuevo usuario.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide(); // Ocultamos la configuración

                // Abrimos el formulario de LOGIN para que el usuario inicie su sesión Auth
                frmIniciosesion login = new frmIniciosesion();
                login.Show();
                this.Close(); // Cerramos la configuración inicial

            }
            catch (Exception ex)
            {
                // Captura cualquier error de red, base de datos, o de autenticación.
                MessageBox.Show($"Ocurrió un error en la configuración: {ex.Message}", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
