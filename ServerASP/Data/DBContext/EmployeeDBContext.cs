using ServerASP.Models;
using Microsoft.EntityFrameworkCore;
using ServerASP.Data.ModelConfigure;

namespace ServerASP.Data.DBContext
{
    public class EmployeeDBContext : DbContext
    {
        public DbSet<Employer> Employee { get; set; }
        public DbSet<Position> Position {  get; set; }

        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=EmployeeDB;Username=postgres;Password=vitalya122");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PositionConfig());
            modelBuilder.ApplyConfiguration(new EmployerConfig());
            //modelBuilder.Entity<Position>().HasData(new Position { Id = 0, PositionName = "Программист" },
            //    new Position { Id = 1, PositionName = "Юрист" },
            //    new Position { Id = 2, PositionName = "Бухгалтер" },
            //    new Position { Id = 3, PositionName = "Менеджер" },
            //    new Position { Id = 4, PositionName = "Директор" });
        }
    }
}
