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
using Ejercicio1.Repositorios;

namespace Ejercicio1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public static RepositorioAlumnos repositorioAlumnos = new RepositorioAlumnos();
        public static UnidadTrabajo unidadTrabajo = new UnidadTrabajo();
        public static Estudiantes estudiantes = new Estudiantes();
        public MainWindow()
        {
            InitializeComponent();
            //dataGrid.ItemsSource = repositorioAlumnos.GetAll();
            estudiantes.EstudianteDireccion = new EstudianteDireccion();
            alumnosGrid.DataContext = estudiantes;
            dataGrid.ItemsSource = unidadTrabajo.RepositorioAlumno.GetAll();
            
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.Items.Count > 1)
            {
                estudiantes = (Estudiantes)dataGrid.SelectedItem;

                crearButton.IsEnabled = false;
                modificarButton.IsEnabled = true;
                eliminarButton.IsEnabled = true;
                buscarButton.IsEnabled = false;

                if (estudiantes != null)
                {
                    alumnosGrid.DataContext = estudiantes;

                    if (estudiantes.Cursos != null)
                    {
                        cursosDataGrid.ItemsSource = estudiantes.Cursos.Select(c => new { c.CursoId, c.NombreCurso, c.ProfesorId });
                    }
                }
            }
        }

        private void crearButton_Click(object sender, RoutedEventArgs e)
        {
            if(nombreTextBox.Text != "" )
            {
                //repositorioAlumnos.añadir(estudiantes);
                unidadTrabajo.RepositorioAlumno.añadir(estudiantes);
                dataGrid.ItemsSource = "";
                //dataGrid.ItemsSource = repositorioAlumnos.GetAll();
                dataGrid.ItemsSource = unidadTrabajo.RepositorioAlumno.GetAll();
            }
            else
            {
                MessageBox.Show("No se puedan estar vacíos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }            
        }

        private void asignarButton_Click(object sender, RoutedEventArgs e)
        {
            WindowCursos windowCursos = new WindowCursos(cursosDataGrid);
            windowCursos.Show();
        }

        private void modificarButton_Click(object sender, RoutedEventArgs e)
        {
            //repositorioAlumnos.modificar(estudiantes);
            unidadTrabajo.RepositorioAlumno.modificar(estudiantes);
            dataGrid.ItemsSource = "";
            //dataGrid.ItemsSource = repositorioAlumnos.GetAll();
            dataGrid.ItemsSource = unidadTrabajo.RepositorioAlumno.GetAll();
        }

        private void limpiarButton_Click(object sender, RoutedEventArgs e)
        {
            crearButton.IsEnabled = true;
            modificarButton.IsEnabled = false;
            eliminarButton.IsEnabled = false;
        }

        private void eliminarButton_Click(object sender, RoutedEventArgs e)
        {
            //repositorioAlumnos.eliminar(estudiantes.EstudianteID);
            unidadTrabajo.RepositorioAlumno.eliminar(estudiantes.EstudianteID);
            estudiantes = new Estudiantes();
            estudiantes.EstudianteDireccion = new EstudianteDireccion();
            alumnosGrid.DataContext = estudiantes;
            cursosDataGrid.ItemsSource = "";
            dataGrid.ItemsSource = "";
            //dataGrid.ItemsSource = repositorioAlumnos.GetAll();
            dataGrid.ItemsSource = unidadTrabajo.RepositorioAlumno.GetAll();
            crearButton.IsEnabled = true;
            modificarButton.IsEnabled = false;
            eliminarButton.IsEnabled = false;
            buscarButton.IsEnabled = true;
        }

        private void buscarButton_Click(object sender, RoutedEventArgs e)
        {
            estudiantes = new Estudiantes();
            if(idTextBox.Text != "")
            {
                //estudiantes = repositorioAlumnos.GetAlumno(Convert.ToInt32(idTextBox.Text));
                estudiantes = unidadTrabajo.RepositorioAlumno.GetAlumno(Convert.ToInt32(idTextBox.Text));
                if (estudiantes != null)
                {
                    //dataGrid.ItemsSource = "";
                    //dataGrid.ItemsSource = ;
                    alumnosGrid.DataContext = estudiantes;

                    if (estudiantes.Cursos != null)
                    {
                        cursosDataGrid.ItemsSource = estudiantes.Cursos.Select(c => new { c.CursoId, c.NombreCurso, c.ProfesorId });
                    }
                }
                else
                {
                    MessageBox.Show("No encuentro lo que buscas", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Debes introducir una busqueda", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
