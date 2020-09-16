using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RegistroPersonas.DAL;
using RegistroPersonas.Entity;

namespace RegistroPersonas.BLL{
    public class PersonBLL{
        public static bool Guardar(Person person){
            if(!Existe(person.ID))
                return Insertar(person); 
            else    
                return Modificar(person);
        }
        private static bool Insertar(Person person){
            Context context = new Context();
            bool found = false;

            try{
                context.Persons.Add(person);
                found = context.SaveChanges() > 0;
            
            } catch(Exception){
                throw;
            
            } finally{
                context.Dispose();
            }

            return found;
        }
        public static bool Modificar(Person person){
            Context context = new Context();
            bool found = false;

            try{
                context.Entry(person).State = EntityState.Modified;
                found = context.SaveChanges() > 0;
            
            } catch(Exception){
                throw;
            
            } finally{
                context.Dispose();
            }

            return found;
        }
        public static bool Eliminar(int id){
            Context context = new Context();
            bool found = false;

            try{
                var person = context.Persons.Find(id);

                if(person != null){
                    context.Persons.Remove(person);
                    found = context.SaveChanges() > 0;
                }
            
            } catch(Exception){
                throw;
            
            } finally{
                context.Dispose();
            }

            return found;
        }
        public static Person Buscar(int id){
            Context context = new Context();
            Person person;

            try{
                person = context.Persons.Find(id);
            
            } catch(Exception){
                throw;
            
            } finally{
                context.Dispose();
            }

            return person;
        }
        public static bool Existe(int id){
            Context context = new Context();
            bool found = false;

            try{
                found = context.Persons.Any(p => p.ID == id);
            
            } catch(Exception){
                throw;
            
            } finally{
                context.Dispose();
            }

            return found;
        }
    }
}