using System.Windows;
using MahApps.Metro.Controls;
using _3Entidades;

namespace _4WPF
{
    /// <summary>
    /// Interaction logic for winMain.xaml
    /// </summary>
    public partial class winMain : MetroWindow
    {
        public UsuarioEN loggedUser;
        public winMain()
        {
            InitializeComponent();
        }

        private void mnuSalir_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Seguro que desea salir?", "Salir de la aplicación", MessageBoxButton.YesNo) == MessageBoxResult.Yes) Close();
        }

        private void mnuitAcercaDe_Click(object sender, RoutedEventArgs e)
        {
            var acercaDe = new winAbout();
            acercaDe.ShowDialog();
        }

        private void mnuitClientes_Click(object sender, RoutedEventArgs e)
        {
           var clientes = new winClientes();
           clientes.ShowDialog();
        }

        private void mnuitProyectos_Click(object sender, RoutedEventArgs e)
        {
            var proyectos = new winProyectos();
            proyectos.ShowDialog();
        }

        private void mnuitUsuarios_Click(object sender, RoutedEventArgs e)
        {
            var usuario = new winUsuario();
            usuario.ShowDialog();
        }

        private void mnuitRegistroPagos_Click(object sender, RoutedEventArgs e)
        {
            var registroPagos = new winRegistroPago();
            registroPagos.ShowDialog();
        }

        private void mnuitPagoFechas_Click(object sender, RoutedEventArgs e)
        {
            var pagoFechas = new winPagoEntreFechas();
            pagoFechas.ShowDialog();
        }

        private void mnuitPagoProyecto_Click(object sender, RoutedEventArgs e)
        {
            var pagoProyecto = new winPagoProyecto();
            pagoProyecto.ShowDialog();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Bienvenido {loggedUser.Nom_Completo}");
            sslbCopyright.Text = "Alvaro Santiesteban 2017";
            sslbUser.Text = $"Usuario actual: {loggedUser.Nom_Completo}";
            sslbUserType.Text = "Privilegios: " + ((loggedUser.Administrador) ? "Administrador" : "Digitador");
            mnuCatalogos.Visibility = (loggedUser.Administrador) ? Visibility.Visible : Visibility.Hidden;
            mnuReportes.Visibility = (loggedUser.Administrador) ? Visibility.Visible : Visibility.Hidden;
        }
    }
}
