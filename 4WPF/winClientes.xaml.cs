using System.Windows;
using MahApps.Metro.Controls;
using _3Entidades;
using _2LogicaNegocio;
using System;
using Microsoft.VisualBasic;

namespace _4WPF
{
    /// <summary>
    /// Interaction logic for winClientes.xaml
    /// </summary>
    public partial class winClientes : MetroWindow
    {
        public winClientes()
        {
            InitializeComponent();
        }

        private void cmdSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void cmdInsertar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var myCliente = new ClienteEN
                {
                    Num_Cliente = txtNumCliente.Text,
                    Nombre = txtNombre.Text,
                    Telefono = txtTelefono.Text,
                    Direccion = txtDireccion.Text,
                    Indicador_Empresa = (bool)radEmpresa.IsChecked,
                    Indicador_Persona = (bool)radPersona.IsChecked,
                    Cedula_Juridica = txtCedJur.Text
                };
                var valida = new ClienteLN();
                valida.InsertarCliente(myCliente);
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
                var myCliente = new ClienteEN
                {
                    Num_Cliente = txtNumCliente.Text,
                    Nombre = txtNombre.Text,
                    Telefono = txtTelefono.Text,
                    Direccion = txtDireccion.Text,
                    Indicador_Empresa = (bool)radEmpresa.IsChecked,
                    Indicador_Persona = (bool)radPersona.IsChecked,
                    Cedula_Juridica = txtCedJur.Text
                };
                var valida = new ClienteLN();
                valida.ModificarCliente(myCliente);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var strNum_Cliente = Interaction.InputBox("Digite el numero de cliente", "Numero de cliente");
                var myCliente = new ClienteEN();
                var valida = new ClienteLN();
                myCliente = valida.ObtenerClientePorID(strNum_Cliente);
                if (myCliente == null)
                {
                    throw new Exception("Cliente no existe");
                }
                else
                {
                    txtNumCliente.Text = myCliente.Num_Cliente;
                    txtNombre.Text = myCliente.Nombre;
                    txtTelefono.Text = myCliente.Telefono;
                    txtDireccion.Text = myCliente.Direccion;
                    radEmpresa.IsChecked = myCliente.Indicador_Empresa;
                    radPersona.IsChecked = myCliente.Indicador_Persona;
                    txtCedJur.Text = myCliente.Cedula_Juridica;
                }
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
                var strNum_Cliente = Interaction.InputBox("Digite el numero de cliente", "Numero de cliente");
                var myCliente = new ClienteEN();
                var valida = new ClienteLN();
                myCliente = valida.ObtenerClientePorID(strNum_Cliente);
                if (myCliente == null)
                {
                    throw new Exception("Cliente no existe");
                }
                else
                {
                    valida.EliminarCliente(myCliente);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdImprimir_Click(object sender, RoutedEventArgs e)
        {
            var imprimir = new winImprimirCliente();
            imprimir.ShowDialog();
        }
    }
}
