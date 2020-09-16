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
using RegistroPersonas.DAL;
using RegistroPersonas.BLL;
using RegistroPersonas.Entity;

namespace RegistroPersonas {
    public partial class MainWindow : Window {
        private Person Person = new Person();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = Person;
        }
        private void Limpiar(){
            this.Person = new Person();
            this.DataContext = this.Person;
        }
        private bool Validar(){

            if(NombreTextBox.Text == "" || NombreTextBox.Text.All(char.IsNumber)){
                MessageBox.Show("Introduzca un nombre válido", "Datos incorrectos", 
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;   
            
            } else if(TelefonoTextBox.Text == "" || !TelefonoTextBox.Text.All(char.IsNumber)){
                MessageBox.Show("Introduzca un teléfono válido", "Datos incorrectos", 
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;                
            
            } else if(CedulaTextBox.Text == "" || !CedulaTextBox.Text.All(char.IsNumber)){
                MessageBox.Show("Introduzca una cedula válida", "Datos incorrectos", 
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;                
            
            } else if(DireccionTextBox.Text == ""){
                MessageBox.Show("Introduzca una direccion válida", "Datos incorrectos", 
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            
            } else if(FechaNacimientoDatePicker.SelectedDate.ToString() == ""){
                MessageBox.Show("Introduzca una fecha válida", "Datos incorrectos", 
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;

            } else
                return true;
        }
        public void BuscarBoton_Click(object sender, RoutedEventArgs e){
            var person = PersonBLL.Buscar(Convert.ToInt32(IDTextBox.Text));

            if(person != null)
                this.Person = person;
            else{
                this.Person = new Person();
                MessageBox.Show("No se encontró ningún registro", "Sin coincidencias", 
                                MessageBoxButton.OK, MessageBoxImage.Information);
            }

            this.DataContext = this.Person;
        }
        public void NuevoBoton_Click(object sender, RoutedEventArgs e){
            Limpiar();
        }
        public void GuardarBoton_Click(object sender, RoutedEventArgs e){
            
            if(!Validar())
                return;

            var found = PersonBLL.Guardar(Person);

            if(found){
                Limpiar();
                MessageBox.Show("Registro guardado", "Guardado exitoso", 
                                MessageBoxButton.OK, MessageBoxImage.Information);
            
            } else 
                MessageBox.Show("Error", "Hubo un error al guardar", 
                                MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public void EliminarBoton_Click(object sender, RoutedEventArgs e){
            if(PersonBLL.Eliminar(Convert.ToInt32(IDTextBox.Text))){
                Limpiar();
                MessageBox.Show("Registro borrado", "Borrado exitoso", 
                                MessageBoxButton.OK, MessageBoxImage.Information);
            
            } else 
                MessageBox.Show("Error", "Hubo un error al borrar", 
                                MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
