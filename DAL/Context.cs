using Microsoft.EntityFrameworkCore;
using RegistroPersonas.Entity;

namespace RegistroPersonas.DAL{
    public class Context : DbContext{
        public DbSet<Person> Persons { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite(@"Data Source=Persons.db");
        }
    }
}