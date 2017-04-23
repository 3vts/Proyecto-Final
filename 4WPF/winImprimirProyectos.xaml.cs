using System.Windows;
using MahApps.Metro.Controls;

namespace _4WPF
{
    /// <summary>
    /// Interaction logic for winImprimirProyectos.xaml
    /// </summary>
    public partial class winImprimirProyectos : MetroWindow
    {
        public winImprimirProyectos()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var reporte = new rptProyectos();
            var dsReporte = new dsReportes();
            using (var adapter = new dsReportesTableAdapters.ProyectosTableAdapter())
            {
                adapter.Fill(dsReporte.Proyectos);
                reporte.SetDataSource(dsReporte);
                crvProyectos.ViewerCore.ReportSource = reporte;
            }
        }
    }
}
