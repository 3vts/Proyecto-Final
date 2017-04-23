using MahApps.Metro.Controls;
using System.Windows;

namespace _4WPF
{
    /// <summary>
    /// Interaction logic for winPagoEntreFechas.xaml
    /// </summary>
    public partial class winPagoEntreFechas : MetroWindow
    {
        public winPagoEntreFechas()
        {
            InitializeComponent();
        }

        private void cmdCargarReporte_Click(object sender, RoutedEventArgs e)
        {
            var reporte = new rptPagos();
            var dsReporte = new dsReportes();
            using (var adapter = new dsReportesTableAdapters.PagosTableAdapter())
            {
                adapter.qryFechas(dsReporte.Pagos, dtpFechaInicio.SelectedDate, dtpFechaFinal.SelectedDate);
                reporte.SetDataSource(dsReporte);
                crvPagoFechas.ViewerCore.ReportSource = reporte;
            }
        }
    }
}
