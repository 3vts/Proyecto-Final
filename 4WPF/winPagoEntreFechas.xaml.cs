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
            if (dtpFechaInicio.SelectedDate > dtpFechaFinal.SelectedDate)
            {
                MessageBox.Show("La fecha inicial no puede ser mayor que la fecha final");
            }
            else if (dtpFechaFinal.SelectedDate != null & dtpFechaInicio.SelectedDate != null)
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
            else
            {
                MessageBox.Show("Ambas fechas son requeridas");
            }
        }
    }
}
