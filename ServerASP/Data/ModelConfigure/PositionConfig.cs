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
            builder.HasData(new Position{Id = 1,PositionName = "Программист"}, 
                new Position{Id = 2, PositionName = "Юрист"}, 
                new Position{Id=3, PositionName = "Бухгалтер"},
                new Position{Id=4, PositionName = "Менеджер"},
                new Position{Id = 5,PositionName = "Директор"});
        }
    }
}
