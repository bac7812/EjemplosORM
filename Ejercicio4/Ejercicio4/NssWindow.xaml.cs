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
    /// Lógica de interacción para NssWindow.xaml
    /// </summary>
    public partial class NssWindow : Window
    {
        TextBox textBox;
        List<Usuarios> listaUsuarios = new List<Usuarios>();
        public NssWindow(TextBox textBox)
        {
            InitializeComponent();
            this.textBox = textBox;
            listaUsuarios = MainWindow.unidadTrabajo.RepositorioPaciente.getGeneral();
            consultarNssDataGrid.ItemsSource = listaUsuarios.Select(u => new { u.NssUsuario, u.nombre, u.apellidos });
        }

        private void consultarNssDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(consultarNssDataGrid.SelectedIndex != -1)
            {
                string nssPaciente = listaUsuarios[consultarNssDataGrid.SelectedIndex].NssUsuario;
                textBox.Text = nssPaciente;
                Close();
            }
        }
    }
}
