using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerASP.Models;

namespace ServerASP.Data.ModelConfigure
{
    public class EmployerConfig : IEntityTypeConfiguration<Employer>
    {
        public void Configure(EntityTypeBuilder<Employer> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.HasOne(e => e.Position).WithMany(p => p.Employers);
            builder.HasData(
                new Employer {Birthday = DateTime.UtcNow, Firstname = "Greg", Surname = "Loh", PositionId = 1, Id = 1, Salary = 134000, isActive = true},
                new Employer {Birthday = DateTime.UtcNow, Firstname = "Adolph", Surname = "Hitler", PositionId = 2, Id = 2, Salary = 90000, isActive = true}
            );
        }
    }
}
