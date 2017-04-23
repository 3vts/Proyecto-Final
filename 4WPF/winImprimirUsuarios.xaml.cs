using System.Windows;
using MahApps.Metro.Controls;

namespace _4WPF
{
    /// <summary>
    /// Interaction logic for winImprimirUsuarios.xaml
    /// </summary>
    public partial class winImprimirUsuarios : MetroWindow
    {
        public winImprimirUsuarios()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var reporte = new rptUsuarios();
            var dsReporte = new dsReportes();
            using (var adapter = new dsReportesTableAdapters.UsuarioTableAdapter())
            {
                adapter.Fill(dsReporte.Usuario);
                reporte.SetDataSource(dsReporte);
                crvUsuarios.ViewerCore.ReportSource = reporte;
            }
        }
    }
}
