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
    /// Lógica de interacción para MedicoWindow.xaml
    /// </summary>
    public partial class MedicoWindow : Window
    {
        TextBox textBox;
        List<Medicos> listaMedicos = new List<Medicos>();
        public MedicoWindow(TextBox textBox)
        {
            InitializeComponent();
            this.textBox = textBox;
            listaMedicos = MainWindow.unidadTrabajo.RepositorioMedico.getGeneral();
            consultarMedicoDataGrid.ItemsSource = listaMedicos.Select(m => new { m.idMedico, m.nombre, m.apellidos, });
        }

        private void consultarMedicoDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (consultarMedicoDataGrid.SelectedIndex != -1)
            {
                string idMedico = listaMedicos[consultarMedicoDataGrid.SelectedIndex].idMedico;
                textBox.Text = idMedico;
                Close();
            }
        }
    }
}
