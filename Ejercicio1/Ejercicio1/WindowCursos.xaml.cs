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
using Ejercicio1.Repositorios;

namespace Ejercicio1
{
    /// <summary>
    /// Lógica de interacción para WindowCursos.xaml
    /// </summary>
    public partial class WindowCursos : Window
    {
        DataGrid grid;
        List<Cursos> listaCursos = new List<Cursos>();
        //RepositorioCursos repositorio = new RepositorioCursos();
        public WindowCursos(DataGrid grid)
        {
            InitializeComponent();
            this.grid = grid;
            //listaCursos = repositorio.GetCursos();
            listaCursos = MainWindow.unidadTrabajo.RepositorioCurso.getCursos();
            cursosDataGrid.ItemsSource = listaCursos.Select(c => new { c.CursoId, c.NombreCurso });
        }

        private void cursosDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cursosDataGrid.SelectedIndex != -1)
            {
                //Cursos curso = repositorio.getCurso(listaCursos[cursosDataGrid.SelectedIndex].CursoId);
                Cursos curso = MainWindow.unidadTrabajo.RepositorioCurso.getCurso(listaCursos[cursosDataGrid.SelectedIndex].CursoId);
                MainWindow.estudiantes.Cursos.Add(curso);
                grid.ItemsSource = MainWindow.estudiantes.Cursos.Select(s => new { s.CursoId, s.NombreCurso, s.ProfesorId });
                grid.Items.Refresh();
            }
        }
    }
}
