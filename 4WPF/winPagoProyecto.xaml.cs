using System.Collections.Generic;
using System.Windows;
using MahApps.Metro.Controls;
using _3Entidades;
using _2LogicaNegocio;

namespace _4WPF
{
    /// <summary>
    /// Interaction logic for winPagoProyecto.xaml
    /// </summary>
    public partial class winPagoProyecto : MetroWindow
    {
        public winPagoProyecto()
        {
            InitializeComponent();

        }

        private void cmdCargarReporte_Click(object sender, RoutedEventArgs e)
        {
            var reporte = new rptPagos();
            var dsReporte = new dsReportes();
            using (var adapter = new dsReportesTableAdapters.PagosTableAdapter())
            {
                adapter.qryProyectos(dsReporte.Pagos, cboNombreProyecto.SelectedValue.ToString());
                reporte.SetDataSource(dsReporte);
                crvPagoFechas.ViewerCore.ReportSource = reporte;
            }
        }

        private void cmdCargarReporte_Loaded(object sender, RoutedEventArgs e)
        {
            var lstClientes = new List<ProyectosEN>();
            lstClientes = new ProyectosLN().ObtenerTodosLosProyectos();
            cboNombreProyecto.ItemsSource = lstClientes;
        }
    }
}
