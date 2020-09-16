using System;
using System.ComponentModel.DataAnnotations;

namespace RegistroPersonas.Entity{
    
    public class Person{
        [Key]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }   
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}