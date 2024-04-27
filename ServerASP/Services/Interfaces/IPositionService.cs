using System.Xml.Serialization;
using ServerASP.Models;

namespace ServerASP.Services.Interfaces
{
    public interface IPositionService
    {
        IEnumerable<Position> GetAllPositions();
    }
}
