using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using _2LogicaNegocio;

namespace _4WPF
{
    /// <summary>
    /// Interaction logic for winLogin.xaml
    /// </summary>
    public partial class winLogin : MetroWindow
    {
        public winLogin()
        {
            InitializeComponent();
        }

        private void cmdIngresar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var valida = new UsuarioLN();
                var myUser = valida.ObtenerUsuarioPorID(txtUsuario.Text);
                if (myUser == null)
                {
                    throw new Exception("Usuario no existe intente de nuevo");
                }
                else if (myUser.Clave != txtPass.Password)
                {
                    throw new Exception("Clave incorrecta intente de nuevo");
                }
                else
                {
                    var main = new winMain
                    {
                        loggedUser = myUser
                    };
                    Close();
                    main.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cmdCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
