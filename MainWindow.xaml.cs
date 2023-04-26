using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfLosSocios
{
    public partial class MainWindow : Window
    {
        private int totalSociosFemeninos;
        private int totalSociosMasculinos;
        private int totalEdad;
        private int totalSocios;
        private double totalAcumulado;

        public MainWindow()
        {
            InitializeComponent();
            rbdFemenino.IsChecked = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e) // Botón CALCULAR
        {
            int inscripcion = 45000;
            int tenis = 250000;
            int futbol = 120000;
            double porcentajeSubvencion = 0.85;

            double totalActividades = 0;
            if (chkTenis.IsChecked == true)
                totalActividades += tenis;

            if (chkFùtbol.IsChecked == true)
                totalActividades += futbol;

            double subtotal = inscripcion + totalActividades;
            double subvencion = subtotal * porcentajeSubvencion;
            double totalAPagar = subtotal - subvencion;

            double pagoFuncionario = totalAPagar;
            double pagoEmpresa = subvencion;

            lblTotalAPagar.Content = pagoFuncionario.ToString("C");
            lblAPagarFuncionarios.Content = pagoFuncionario.ToString("C");
            lblAPagarEmpresa.Content = pagoEmpresa.ToString("C");

            if (rbdFemenino.IsChecked == true)
            {
                totalSociosFemeninos++;
                lblSociosFemeninos.Content = totalSociosFemeninos.ToString();
            }
            else
            {
                totalSociosMasculinos++;
                lblSociosMasculinos.Content = totalSociosMasculinos.ToString();
            }

            int edad = int.Parse(txtEdad_.Text);
            totalEdad += edad;
            totalSocios++;
            double promedioEdad = (double)totalEdad / totalSocios;
            lblPromEdad.Content = promedioEdad.ToString("N2");

            totalAcumulado += totalAPagar;
            lblTotalAPagarGral.Content = totalAcumulado.ToString("C");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) // Botón LIMPIAR
        {
            txtRUT.Clear();
            txtNombre_.Clear();
            txtApellido_.Clear();
            txtEdad_.Clear();
            rbdFemenino.IsChecked = true;
            chkTenis.IsChecked = false;
            chkFùtbol.IsChecked = false;
            lblTotalAPagar.Content = "";
            lblAPagarFuncionarios.Content = "";
            lblAPagarEmpresa.Content = "";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) // Botón SALIR
        {
            Application.Current.Shutdown();
        }
    }
}
