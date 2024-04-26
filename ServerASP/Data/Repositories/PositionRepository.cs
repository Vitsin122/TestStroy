using ServerASP.Data.DBContext;
using ServerASP.Data.Interfaces;
using ServerASP.Models;

namespace ServerASP.Data.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private EmployeeDBContext context;

        /*
        Для гибкости можно было бы передавать просто класс DbContext, чтобы мы не зависили от реализации контекста
        После чего обращаться не к уже существующим DbSet, а вызывать метод Set<>(), который бы создавал DbSet, чтобы мы могли так же работать
        Но я не знаю, насколько это целесообразно здесь. Просто знаю, что можно так делать.
        */
        public PositionRepository(EmployeeDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Position> GetAllPositions() => context.Position.ToList();

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
