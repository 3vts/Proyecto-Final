using _2LogicaNegocio;
using _3Entidades;
using MahApps.Metro.Controls;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Windows;

namespace _4WPF
{
    /// <summary>
    /// Interaction logic for winProyectos.xaml
    /// </summary>
    public partial class winProyectos : MetroWindow
    {
        public winProyectos()
        {
            InitializeComponent();
        }

        private void cmdBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var strCod_Proyecto = Interaction.InputBox("Digite el numero de proyecto", "Numero de proyecto");
                var myProyecto = new ProyectosEN();
                var valida = new ProyectosLN();
                myProyecto = valida.ObtenerProyectosPorID(strCod_Proyecto);
                if (myProyecto == null)
                {
                    throw new Exception("Proyecto no existe");
                }
                else
                {

                    txtCodProyecto.Text = myProyecto.Cod_Proyecto;
                    txtNombre.Text = myProyecto.Nombre_Proyecto;
                    dtpFechaCreacion.SelectedDate = myProyecto.Fec_Creacion;
                    dtpFechaFinalizacion.SelectedDate = myProyecto.Fec_Finalizacion;
                    txtCostoTotal.Text = myProyecto.Costo_Total.ToString("N");
                    txtObservaciones.Text = myProyecto.Observaciones;
                    cboNombreCliente.SelectedValue = myProyecto.Num_Cliente;
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
                var myProyecto = new ProyectosEN
                {
                    Cod_Proyecto = txtCodProyecto.Text,
                    Nombre_Proyecto = txtNombre.Text,
                    Fec_Creacion = dtpFechaCreacion.SelectedDate.Value,
                    Fec_Finalizacion = dtpFechaFinalizacion.SelectedDate.Value,
                    Costo_Total = double.Parse(txtCostoTotal.Text),
                    Observaciones = txtObservaciones.Text,
                    Num_Cliente = cboNombreCliente.SelectedValue.ToString()
                };
                var valida = new ProyectosLN();
                valida.InsertarProyectos(myProyecto);
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
                var myProyecto = new ProyectosEN
                {
                    Cod_Proyecto = txtCodProyecto.Text,
                    Nombre_Proyecto = txtNombre.Text,
                    Fec_Creacion = dtpFechaCreacion.SelectedDate.Value,
                    Fec_Finalizacion = dtpFechaFinalizacion.SelectedDate.Value,
                    Costo_Total = double.Parse(txtCostoTotal.Text),
                    Observaciones = txtObservaciones.Text,
                    Num_Cliente = cboNombreCliente.SelectedValue.ToString()
                };
                var valida = new ProyectosLN();
                valida.ModificarProyectos(myProyecto);
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
                var strNum_Proyecto = Interaction.InputBox("Digite el numero de proyecto", "Numero de proyecto");
                var myProyecto = new ProyectosEN();
                var valida = new ProyectosLN();
                myProyecto = valida.ObtenerProyectosPorID(strNum_Proyecto);
                if (myProyecto == null)
                {
                    throw new Exception("Proyecto no existe");
                }
                else
                {
                    valida.EliminarProyectos(myProyecto);
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


        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var lstClientes = new List<ClienteEN>();
            lstClientes = new ClienteLN().ObtenerTodosLosClientes();
            cboNombreCliente.ItemsSource = lstClientes;
        }
    }
}
