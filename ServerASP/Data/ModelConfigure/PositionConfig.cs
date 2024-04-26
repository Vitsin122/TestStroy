using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerASP.Models;

namespace ServerASP.Data.ModelConfigure
{
    public class PositionConfig : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.HasData(new Position{PositionName = "Программист"}, 
                new Position{PositionName = "Юрист"}, 
                new Position{PositionName = "Бухгалтер"},
                new Position{PositionName = "Менеджер"},
                new Position{PositionName = "Директор"});
        }
    }
}
