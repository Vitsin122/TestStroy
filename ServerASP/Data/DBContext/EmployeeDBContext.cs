using ServerASP.Models;
using Microsoft.EntityFrameworkCore;

namespace ServerASP.Data.DBContext
{
    public class EmployeeDBContext : DbContext
    {
        public DbSet<Employer> Employee { get; set; }
        public DbSet<Position> Position {  get; set; }

        public EmployeeDBContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=EmployeeDB;Username=postgres;Password=vitalya122");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>().HasKey(x => x.Id);
            modelBuilder.Entity<Position>().Property(x => x.Id).ValueGeneratedOnAdd();


        }
    }
}
