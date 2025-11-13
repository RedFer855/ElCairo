using CapaDeDatos.Datos;
using CapaDeDatos.Modelados;
using CapaDeDatos.Repositorios;
using Microsoft.VisualBasic.Devices;
using ModernMenuUI.InterfacesUsuarios.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernMenuUI.InterfacesUsuarios.Usuarios
{
    public partial class frmAgregarEditarUsuario : Form
    {
        private Usuario _usuarioActual;
        private readonly UsuarioRepositorio _usuarioRepo = new UsuarioRepositorio();
        //private Cliente supabase;
        public frmAgregarEditarUsuario()
        {
            InitializeComponent();
            _usuarioActual = null;
        }
        public frmAgregarEditarUsuario(Usuario usuario)
        {
            InitializeComponent();
            _usuarioActual = usuario;
            txtCorreo.Click += TextBox_ReadOnlyClick;

        }

        private void frmAgregarEditarUsuario_Load(object sender, EventArgs e)
        {
            if (_usuarioActual != null)
            {
                txtCorreo.Text = _usuarioActual.AliasUsuario;
                cmbRol.DataSource = _usuarioActual.RolUsuario;
                

            }
        }

        private async void btnGuardarEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                if (_usuarioActual == null)
                {
                    MessageBox.Show("No se ha cargado el usuario actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Detectar los cambios
                var cambios = new Dictionary<string, object>();

                string correoNuevo = txtCorreo.Text.Trim().ToLower();

                if (correoNuevo != _usuarioActual.AliasUsuario && !string.IsNullOrWhiteSpace(correoNuevo))
                    cambios["alias_usuario"] = correoNuevo;

                // Ejemplo si tuvieras más campos:
                // if (cmbRol.SelectedValue.ToString() != _usuarioActual.IdRol.ToString())
                //     cambios["id_rol"] = int.Parse(cmbRol.SelectedValue.ToString());

                if (cambios.Count == 0)
                {
                    MessageBox.Show("No se detectaron cambios para guardar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Actualiza solo los campos modificados
                await _usuarioRepo.ActualizarUsuarioParcial(_usuarioActual.UserId, cambios);

                MessageBox.Show("Usuario actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void TextBox_ReadOnlyClick(object sender, EventArgs e)
        {

            TextBox currentTextBox = sender as TextBox;

            if (currentTextBox != null && currentTextBox.ReadOnly)
            {
                MessageBox.Show(
                    "Presione primero el botón Modificar.",
                    "Campo Deshabilitado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private async void cmbRol_DataContextChanged(object sender, EventArgs e)
        {
           
        }
        
    }
}
