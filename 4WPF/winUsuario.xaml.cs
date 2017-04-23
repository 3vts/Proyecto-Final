using _2LogicaNegocio;
using _3Entidades;
using MahApps.Metro.Controls;
using Microsoft.VisualBasic;
using System;
using System.Windows;

namespace _4WPF
{
    /// <summary>
    /// Interaction logic for winUsuario.xaml
    /// </summary>
    public partial class winUsuario : MetroWindow
    {
        public winUsuario()
        {
            InitializeComponent();
        }

        private void cmdBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var strNum_Usuario = Interaction.InputBox("Digite el login", "Login de Usuario");
                var myUsuario = new UsuarioEN();
                var valida = new UsuarioLN();
                myUsuario = valida.ObtenerUsuarioPorID(strNum_Usuario);
                if (myUsuario == null)
                {
                    throw new Exception("Usuario no existe");
                }
                else
                {
                    txtLogin.Text = myUsuario.Login;
                    txtNombre.Text = myUsuario.Nom_Completo;
                    txtClave.Text = myUsuario.Clave;
                    radAdministrador.IsChecked = myUsuario.Administrador;
                    radDigitador.IsChecked = myUsuario.Digitador;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdInsertar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var myUsuario = new UsuarioEN
                {
                    Login = txtLogin.Text,
                    Nom_Completo = txtNombre.Text,
                    Clave = txtClave.Text,
                    Administrador = (bool)radAdministrador.IsChecked,
                    Digitador = (bool)radDigitador.IsChecked
                };
                var valida = new UsuarioLN();
                valida.InsertarUsuario(myUsuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var myUsuario = new UsuarioEN
                {
                    Login = txtLogin.Text,
                    Nom_Completo = txtNombre.Text,
                    Clave = txtClave.Text,
                    Administrador = (bool)radAdministrador.IsChecked,
                    Digitador = (bool)radDigitador.IsChecked
                };
                var valida = new UsuarioLN();
                valida.ModificarUsuario(myUsuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdBorrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var strNum_Usuario = Interaction.InputBox("Digite el Login", "Login de Usuario");
                var myUsuario = new UsuarioEN();
                var valida = new UsuarioLN();
                myUsuario = valida.ObtenerUsuarioPorID(strNum_Usuario);
                if (myUsuario == null)
                {
                    throw new Exception("Usuario no existe");
                }
                else
                {
                    valida.EliminarUsuario(myUsuario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
