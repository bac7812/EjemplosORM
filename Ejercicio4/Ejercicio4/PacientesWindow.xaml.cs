using Ejercicio4.Repositorios;
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
using System.Windows.Shapes;

namespace Ejercicio4
{
    /// <summary>
    /// Lógica de interacción para PacientesWindow.xaml
    /// </summary>
    public partial class PacientesWindow : Window
    {
        public static UnidadTrabajo unidadTrabajo = new UnidadTrabajo();
        public static Usuarios paciente = new Usuarios();
        public PacientesWindow()
        {
            InitializeComponent();
            pacientesGrid.DataContext = paciente;
            dataGrid.ItemsSource = unidadTrabajo.RepositorioPaciente.getAll();
            dataGrid.CanUserAddRows = false;
        }

        private void crearButton_Click(object sender, RoutedEventArgs e)
        {
            
            paciente.contrasena = contrasenaPasswordBox.Password;
            unidadTrabajo.RepositorioPaciente.añadir(paciente);
            dataGrid.ItemsSource = "";
            dataGrid.ItemsSource = unidadTrabajo.RepositorioPaciente.getAll();
        }

        private void modificarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void eliminarButton_Click(object sender, RoutedEventArgs e)
        {
            unidadTrabajo.RepositorioPaciente.eliminar(paciente);
            paciente = new Usuarios();
            pacientesGrid.DataContext = paciente;
            dataGrid.ItemsSource = "";
            dataGrid.ItemsSource = unidadTrabajo.RepositorioPaciente.getAll();
        }

        private void buscarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void limpiarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            paciente = (Usuarios)dataGrid.SelectedItem;
            if(paciente != null)
            {
                pacientesGrid.DataContext = paciente;
                crearButton.IsEnabled = false;
                modificarButton.IsEnabled = true;
                eliminarButton.IsEnabled = true;
                buscarButton.IsEnabled = false;
            }
        }
    }
}
