using Ejercicio4.Repositorios;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Ejercicio4
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static UnidadTrabajo unidadTrabajo = new UnidadTrabajo();
        public static Usuarios paciente = new Usuarios();
        public static Medicos medico = new Medicos();
        public static Historiales historial = new Historiales();
        public static Citas cita = new Citas();
        public static Horarios horario = new Horarios();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void accederButton_Click(object sender, RoutedEventArgs e)
        {
            if (emailIniciarSesionTextBox.Text != "" && contrasenaIniciarSesionPasswordBox.Password != "")
            {
                paciente = unidadTrabajo.RepositorioPaciente.singular(p => p.email == emailIniciarSesionTextBox.Text && p.contrasena == contrasenaIniciarSesionPasswordBox.Password);
                if(paciente != null)
                {
                    inicioSesionGrid.Visibility = Visibility.Hidden;
                    gestionGrid.Visibility = Visibility.Visible;
                    bienvenidoLabel.Content = "Bienviendo " + paciente.nombre;
                }
                else
                {
                    MessageBox.Show("Ese e-mail o contraseña no es correcta", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Introduzca el e-mail y la contraseña del usuario", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void pacientesButton_Click(object sender, RoutedEventArgs e)
        {
            gestionGrid.Visibility = Visibility.Hidden;
            pacientesGrid.Visibility = Visibility.Visible;
            pacientesDataGrid.ItemsSource = unidadTrabajo.RepositorioPaciente.getGeneral();
        }

        private void historialesButton_Click(object sender, RoutedEventArgs e)
        {
            gestionGrid.Visibility = Visibility.Hidden;
            historialesGrid.Visibility = Visibility.Visible;
            historialesDataGrid.ItemsSource = unidadTrabajo.RepositorioHistorial.getGeneral();
        }

        private void citasButton_Click(object sender, RoutedEventArgs e)
        {
            gestionGrid.Visibility = Visibility.Hidden;
            citasGrid.Visibility = Visibility.Visible;
            citasDataGrid.ItemsSource = unidadTrabajo.RepositorioCita.getGeneral();
            fechaCitaDatePicker.BlackoutDates.AddDatesInPast();
        }

        private void cerrarSesionButton_Click(object sender, RoutedEventArgs e)
        {
            gestionGrid.Visibility = Visibility.Hidden;
            inicioSesionGrid.Visibility = Visibility.Visible;
            emailIniciarSesionTextBox.Text = "";
            contrasenaIniciarSesionPasswordBox.Password = "";
            paciente = new Usuarios();
        }

        private void crearPacienteButton_Click(object sender, RoutedEventArgs e)
        {
            if(nssPacienteTextBox.Text != "" && nombreTextBox.Text != "" && apellidosTextBox.Text != "" && dniTextBox.Text != "" && direccionTextBox.Text != "" && localidadTextBox.Text != "" && telefonoTextBox.Text != "" && emailTextBox.Text != "" && contrasenaPasswordBox.Password != "")
            {
                Usuarios nuevo = new Usuarios();
                nuevo.NssUsuario = nssPacienteTextBox.Text;
                nuevo.nombre = nombreTextBox.Text;
                nuevo.apellidos = apellidosTextBox.Text;
                nuevo.dni = dniTextBox.Text;
                nuevo.direccion = direccionTextBox.Text;
                nuevo.localidad = localidadTextBox.Text;
                nuevo.telefono = telefonoTextBox.Text;
                nuevo.email = emailTextBox.Text;
                nuevo.contrasena = contrasenaPasswordBox.Password;
                unidadTrabajo.RepositorioPaciente.añadir(nuevo);
                pacientesDataGrid.ItemsSource = "";
                pacientesDataGrid.ItemsSource = unidadTrabajo.RepositorioPaciente.getGeneral();
                MessageBox.Show("Ya creado nuevo paciente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se puedan estar vacíos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void modificarPacienteButton_Click(object sender, RoutedEventArgs e)
        {
            unidadTrabajo.RepositorioPaciente.modificar(paciente);
            pacientesDataGrid.ItemsSource = "";
            pacientesDataGrid.ItemsSource = unidadTrabajo.RepositorioPaciente.getGeneral();
            MessageBox.Show("Ya modificado paciente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void eliminarPacienteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mensaje = MessageBox.Show("¿Seguro que deseas eliminar el usuario?", "Aviso", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (mensaje.Equals(MessageBoxResult.Yes))
            {
                unidadTrabajo.RepositorioPaciente.eliminar(paciente);
                paciente = new Usuarios();
                pacientesGrid.DataContext = paciente;
                pacientesDataGrid.ItemsSource = "";
                pacientesDataGrid.ItemsSource = unidadTrabajo.RepositorioPaciente.getGeneral();
                crearPacienteButton.IsEnabled = true;
                modificarPacienteButton.IsEnabled = false;
                eliminarPacienteButton.IsEnabled = false;
                buscarPacienteButton.IsEnabled = true;
                MessageBox.Show("Ya eliminado paciente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void buscarPacienteButton_Click(object sender, RoutedEventArgs e)
        {
            paciente = new Usuarios();
            if (nssPacienteTextBox.Text != "")
            {
                paciente = unidadTrabajo.RepositorioPaciente.singular(p => p.NssUsuario == nssPacienteTextBox.Text);

                if (paciente != null)
                {
                    pacientesGrid.DataContext = paciente;
                    contrasenaPasswordBox.Password = paciente.contrasena;
                    crearPacienteButton.IsEnabled = false;
                    modificarPacienteButton.IsEnabled = true;
                    eliminarPacienteButton.IsEnabled = true;
                    buscarPacienteButton.IsEnabled = false;
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

        private void limpiarPacienteButton_Click(object sender, RoutedEventArgs e)
        {
            paciente = new Usuarios();
            pacientesGrid.DataContext = paciente;
            contrasenaPasswordBox.Password = "";
            pacientesDataGrid.ItemsSource = "";
            pacientesDataGrid.ItemsSource = unidadTrabajo.RepositorioPaciente.getGeneral();
            crearPacienteButton.IsEnabled = true;
            modificarPacienteButton.IsEnabled = false;
            eliminarPacienteButton.IsEnabled = false;
            buscarPacienteButton.IsEnabled = true;
        }

        private void volverPacienteButton_Click(object sender, RoutedEventArgs e)
        {
            paciente = new Usuarios();
            pacientesGrid.DataContext = paciente;
            contrasenaPasswordBox.Password = "";
            pacientesDataGrid.ItemsSource = "";
            pacientesDataGrid.ItemsSource = unidadTrabajo.RepositorioPaciente.getGeneral();
            crearPacienteButton.IsEnabled = true;
            modificarPacienteButton.IsEnabled = false;
            eliminarPacienteButton.IsEnabled = false;
            buscarPacienteButton.IsEnabled = true;
            pacientesGrid.Visibility = Visibility.Hidden;
            gestionGrid.Visibility = Visibility.Visible;
        }

        private void pacientesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (pacientesDataGrid.SelectedIndex != -1)
            {
                paciente = (Usuarios)pacientesDataGrid.SelectedItem;

                if (paciente != null)
                {
                    pacientesGrid.DataContext = paciente;
                    contrasenaPasswordBox.Password = paciente.contrasena;
                    crearPacienteButton.IsEnabled = false;
                    modificarPacienteButton.IsEnabled = true;
                    eliminarPacienteButton.IsEnabled = true;
                    buscarPacienteButton.IsEnabled = false;
                }
            }
        }

        private void crearHistorialButton_Click(object sender, RoutedEventArgs e)
        {
            if(idHistorialTextBox.Text != "" && nssHistorialTextBox.Text != "" && idMedicoTextBox.Text != "" && sintomasTextBox.Text != "" && diagnosticoTextBox.Text != "" && tratamientoTextBox.Text != "" && fechaHistorialDatePicker.Text != "")
            {
                Historiales nuevo = new Historiales();
                nuevo.idHistoria = Convert.ToInt32(idHistorialTextBox.Text);
                nuevo.usuario = nssHistorialTextBox.Text;
                nuevo.medico = idMedicoTextBox.Text;
                nuevo.sintomas = sintomasTextBox.Text;
                nuevo.diagnostico = diagnosticoTextBox.Text;
                nuevo.tratamiento = tratamientoTextBox.Text;
                nuevo.fecha = Convert.ToDateTime(fechaHistorialDatePicker.Text);
                unidadTrabajo.RepositorioHistorial.añadir(nuevo);
                historialesDataGrid.ItemsSource = "";
                historialesDataGrid.ItemsSource = unidadTrabajo.RepositorioHistorial.getGeneral();
                MessageBox.Show("Ya creado nuevo historial", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se puedan estar vacíos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void modificarHistorialButton_Click(object sender, RoutedEventArgs e)
        {
            unidadTrabajo.RepositorioHistorial.modificar(historial);
            pacientesDataGrid.ItemsSource = "";
            pacientesDataGrid.ItemsSource = unidadTrabajo.RepositorioPaciente.getGeneral();
            MessageBox.Show("Ya modificado historial", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void eliminarHistorialButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mensaje = MessageBox.Show("¿Seguro que deseas eliminar el historial?", "Aviso", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (mensaje.Equals(MessageBoxResult.Yes))
            {
                unidadTrabajo.RepositorioHistorial.eliminar(historial);
                historial = new Historiales();
                historialesGrid.DataContext = historial;
                idHistorialTextBox.Text = "";
                historialesDataGrid.ItemsSource = "";
                historialesDataGrid.ItemsSource = unidadTrabajo.RepositorioHistorial.getGeneral();
                crearHistorialButton.IsEnabled = true;
                modificarHistorialButton.IsEnabled = false;
                eliminarHistorialButton.IsEnabled = false;
                MessageBox.Show("Ya eliminado historial", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void buscarNssHistorialButton_Click(object sender, RoutedEventArgs e)
        {
            NssWindow nssHistorialWindow = new NssWindow(nssHistorialTextBox);
            nssHistorialWindow.Show();
        }

        private void buscarMedicoHistorialButton_Click(object sender, RoutedEventArgs e)
        {
            MedicoWindow medicoHistorialWindow = new MedicoWindow(idMedicoTextBox);
            medicoHistorialWindow.Show();
        }

        private void limpiarHistorialButton_Click(object sender, RoutedEventArgs e)
        {
            historial = new Historiales();
            historialesGrid.DataContext = historial;
            idHistorialTextBox.Text = "";
            historialesDataGrid.ItemsSource = "";
            historialesDataGrid.ItemsSource = unidadTrabajo.RepositorioHistorial.getGeneral();
            crearHistorialButton.IsEnabled = true;
            modificarHistorialButton.IsEnabled = false;
            eliminarHistorialButton.IsEnabled = false;
        }

        private void volverHistorialButton_Click(object sender, RoutedEventArgs e)
        {
            historial = new Historiales();
            historialesGrid.DataContext = historial;
            idHistorialTextBox.Text = "";
            historialesDataGrid.ItemsSource = "";
            historialesDataGrid.ItemsSource = unidadTrabajo.RepositorioHistorial.getGeneral();
            crearHistorialButton.IsEnabled = true;
            modificarHistorialButton.IsEnabled = false;
            eliminarHistorialButton.IsEnabled = false;
            historialesGrid.Visibility = Visibility.Hidden;
            gestionGrid.Visibility = Visibility.Visible;
        }

        private void historialesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (historialesDataGrid.SelectedIndex != -1)
            {
                historial = (Historiales)historialesDataGrid.SelectedItem;

                if (historial != null)
                {
                    historialesGrid.DataContext = historial;
                    crearHistorialButton.IsEnabled = false;
                    modificarHistorialButton.IsEnabled = true;
                    eliminarHistorialButton.IsEnabled = true;
                    
                }
            }
        }

        private void anadirCitaButton_Click(object sender, RoutedEventArgs e)
        {
            if(nssCitaTextBox.Text != "" && medicoCitaTextBox.Text != "" && fechaCitaDatePicker.Text != "" && horaCitaCombobox.Text != "")
            {
                cita = unidadTrabajo.RepositorioCita.singular(c => c.fecha == fechaCitaDatePicker.Text || c.hora == horaCitaCombobox.Text);
                if(cita == null)
                {
                    Citas nuevo = new Citas();
                    nuevo.usuario = nssCitaTextBox.Text;
                    nuevo.medico = medicoCitaTextBox.Text;
                    nuevo.fecha = fechaCitaDatePicker.Text;
                    nuevo.hora = horaCitaCombobox.Text;
                    paciente = new Usuarios();
                    paciente = unidadTrabajo.RepositorioPaciente.singular(p => p.NssUsuario == nssCitaTextBox.Text);
                    medico = new Medicos();
                    medico = unidadTrabajo.RepositorioMedico.singular(m => m.idMedico == medicoCitaTextBox.Text);
                    unidadTrabajo.RepositorioCita.añadir(nuevo);
                    citasDataGrid.ItemsSource = "";
                    citasDataGrid.ItemsSource = unidadTrabajo.RepositorioCita.getGeneral();
                    MessageBox.Show("Ya añadido nueva cita", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("La cita está ocupada", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("No se puedan estar vacíos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void modificarCitaButton_Click(object sender, RoutedEventArgs e)
        {
            unidadTrabajo.RepositorioCita.modificar(cita);
            citasDataGrid.ItemsSource = "";
            citasDataGrid.ItemsSource = unidadTrabajo.RepositorioCita.getGeneral();
            MessageBox.Show("Ya modificado cita", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void eliminarCitaButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mensaje = MessageBox.Show("¿Seguro que deseas eliminar la cita?", "Aviso", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (mensaje.Equals(MessageBoxResult.Yes))
            {
                unidadTrabajo.RepositorioCita.eliminar(cita);
                cita = new Citas();
                citasGrid.DataContext = cita;
                citasDataGrid.ItemsSource = "";
                citasDataGrid.ItemsSource = unidadTrabajo.RepositorioCita.getGeneral();
                anadirCitaButton.IsEnabled = true;
                modificarCitaButton.IsEnabled = false;
                eliminarCitaButton.IsEnabled = false;
                MessageBox.Show("Ya eliminado cita", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void buscarNssCitaButton_Click(object sender, RoutedEventArgs e)
        {
            NssWindow nssCitaWindow = new NssWindow(nssCitaTextBox);
            nssCitaWindow.Show();
        }

        private void buscarMedicCitaButton_Click(object sender, RoutedEventArgs e)
        {
            MedicoWindow medicoCitaWindow = new MedicoWindow(medicoCitaTextBox);
            medicoCitaWindow.Show();
        }

        private void limpiarCitaButton_Click(object sender, RoutedEventArgs e)
        {
            cita = new Citas();
            citasGrid.DataContext = cita;
            citasDataGrid.ItemsSource = "";
            citasDataGrid.ItemsSource = unidadTrabajo.RepositorioCita.getGeneral();
            anadirCitaButton.IsEnabled = true;
            modificarCitaButton.IsEnabled = false;
            eliminarCitaButton.IsEnabled = false;
            horaCitaCombobox.Items.Clear();
            horaCitaCombobox.IsEnabled = false;
        }

        private void volverCitaButton_Click(object sender, RoutedEventArgs e)
        {
            cita = new Citas();
            citasGrid.DataContext = cita;
            citasDataGrid.ItemsSource = "";
            citasDataGrid.ItemsSource = unidadTrabajo.RepositorioCita.getGeneral();
            anadirCitaButton.IsEnabled = true;
            modificarCitaButton.IsEnabled = false;
            eliminarCitaButton.IsEnabled = false;
            horaCitaCombobox.Items.Clear();
            horaCitaCombobox.IsEnabled = false;
            citasGrid.Visibility = Visibility.Hidden;
            gestionGrid.Visibility = Visibility.Visible;
        }

        private void citasDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (citasDataGrid.SelectedIndex != -1)
            {
                cita = (Citas)citasDataGrid.SelectedItem;

                if (cita != null)
                {
                    citasGrid.DataContext = cita;
                    anadirCitaButton.IsEnabled = false;
                    modificarCitaButton.IsEnabled = true;
                    eliminarCitaButton.IsEnabled = true;
                }
            }
        }

        private void fechaCitaDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                CultureInfo cultureInfo = new CultureInfo("Es-ES");
                string diaSemana = cultureInfo.DateTimeFormat.GetDayName(fechaCitaDatePicker.SelectedDate.Value.DayOfWeek).ToString();
                horario = unidadTrabajo.RepositorioHorario.singular(h => h.Medico == medicoCitaTextBox.Text && h.diaSemana == diaSemana);
                if (horario != null)
                {
                    horaCitaCombobox.IsEnabled = true;
                    horaCitaCombobox.Items.Clear();

                    TimeSpan horaInico = new TimeSpan(0, Convert.ToInt32(horario.horaInic.Split(':')[0]),
                                                        Convert.ToInt32(horario.horaInic.Split(':')[1]), 0, 0);
                    TimeSpan horaFin = new TimeSpan(0, Convert.ToInt32(horario.horaFin.Split(':')[0]),
                                                        Convert.ToInt32(horario.horaFin.Split(':')[1]), 0, 0);
                    TimeSpan tiempoCita = TimeSpan.FromMinutes(10);

                    while (horaInico < horaFin)
                    {
                        horaCitaCombobox.Items.Add(string.Format("{0:hh\\:mm}", horaInico));
                        horaInico = horaInico.Add(tiempoCita);
                    }
                }
                else
                {
                    MessageBox.Show("El médico está ocupado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {

            }
            
        }
    }
}
