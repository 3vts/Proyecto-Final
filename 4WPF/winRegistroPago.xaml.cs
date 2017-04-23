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
    /// Interaction logic for winRegistroPago.xaml
    /// </summary>
    public partial class winRegistroPago : MetroWindow
    {
        public winRegistroPago()
        {
            InitializeComponent();
        }

        private void cmdBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var strCod_Pago = Interaction.InputBox("Digite el numero de Pago", "Numero de Pago");
                var myPago = new PagosEN();
                var valida = new PagosLN();
                myPago = valida.ObtenerPagosPorID(strCod_Pago);
                if (myPago == null)
                {
                    throw new Exception("Pago no existe");
                }
                else
                {
                    txtNumPago.Text = myPago.Num_Pago;
                    txtMonto.Text = myPago.Monto_Pago.ToString("N");
                    dtpFechaPago.SelectedDate = myPago.Fecha_Pago;
                    txtBanco.Text = myPago.Banco_Del_Pago;
                    txtObservaciones.Text = myPago.Observaciones;
                    cboCodProyecto.SelectedValue = myPago.Cod_Proyecto;
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
                var myPago = new PagosEN
                {
                    Num_Pago = txtNumPago.Text,
                    Monto_Pago = double.Parse(txtMonto.Text),
                    Fecha_Pago = dtpFechaPago.SelectedDate.Value,
                    Banco_Del_Pago = txtBanco.Text,
                    Observaciones = txtObservaciones.Text,
                    Cod_Proyecto = cboCodProyecto.SelectedValue.ToString()
                };
                var valida = new PagosLN();
                valida.InsertarPagos(myPago);
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
                var myPago = new PagosEN
                {
                    Num_Pago = txtNumPago.Text,
                    Monto_Pago = double.Parse(txtMonto.Text),
                    Fecha_Pago = dtpFechaPago.SelectedDate.Value,
                    Banco_Del_Pago = txtBanco.Text,
                    Observaciones = txtObservaciones.Text,
                    Cod_Proyecto = cboCodProyecto.SelectedValue.ToString()
                };
                var valida = new PagosLN();
                valida.ModificarPagos(myPago);
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
                var strNum_Pago = Interaction.InputBox("Digite el numero de Pago", "Numero de Pago");
                var myPago = new PagosEN();
                var valida = new PagosLN();
                myPago = valida.ObtenerPagosPorID(strNum_Pago);
                if (myPago == null)
                {
                    throw new Exception("Pago no existe");
                }
                else
                {
                    valida.EliminarPagos(myPago);
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
            var lstProyectos = new List<ProyectosEN>();
            lstProyectos = new ProyectosLN().ObtenerTodosLosProyectos();
            cboCodProyecto.ItemsSource = lstProyectos;
        }
    }
}
