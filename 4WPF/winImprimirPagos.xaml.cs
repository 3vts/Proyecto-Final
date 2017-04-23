using System.Windows;
using MahApps.Metro.Controls;

namespace _4WPF
{
    /// <summary>
    /// Interaction logic for winImprimirPagos.xaml
    /// </summary>
    public partial class winImprimirPagos : MetroWindow
    {
        public string cod_Proyecto;
        public winImprimirPagos()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var reporte = new rptPagosFicha();
            var dsReporte = new dsReportes();
            using (var adapter = new dsReportesTableAdapters.PagosTableAdapter())
            {
                adapter.qryProyectos(dsReporte.Pagos, cod_Proyecto);
                reporte.SetDataSource(dsReporte);
                crvPagos.ViewerCore.ReportSource = reporte;
            }
        }
    }
}
