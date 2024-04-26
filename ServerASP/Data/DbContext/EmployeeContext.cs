using Microsoft.EntityFrameworkCore;
using ServerASP.Models;
using ServerASP.Data.ModelConfigure;

namespace ServerASP.Data.DBContext
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employer> Employee { get; set; }
        public DbSet<Position> Position { get; set; }

        public EmployeeContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PositionConfig());
            modelBuilder.ApplyConfiguration(new EmployerConfig());
        }
    }
}
