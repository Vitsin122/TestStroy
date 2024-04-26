using ServerASP.Models;

namespace ServerASP.Data.Interfaces
{
    public interface IPositionRepository
    {
        IEnumerable<Position> GetAllPositions();
    }
}
