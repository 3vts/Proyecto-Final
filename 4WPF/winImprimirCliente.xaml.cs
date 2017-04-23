using System.Windows;
using MahApps.Metro.Controls;

namespace _4WPF
{
    /// <summary>
    /// Interaction logic for winImprimirCliente.xaml
    /// </summary>
    public partial class winImprimirCliente : MetroWindow
    {
        public winImprimirCliente()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var reporte = new rptClientes();
            var dsReporte = new dsReportes();
            using (var adapter = new dsReportesTableAdapters.ClienteTableAdapter())
            {
                adapter.Fill(dsReporte.Cliente);
                reporte.SetDataSource(dsReporte);
                crvClientes.ViewerCore.ReportSource = reporte;
            }
        }
    }
}
