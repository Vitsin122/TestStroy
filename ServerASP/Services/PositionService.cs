using ServerASP.Data.UOF;
using ServerASP.Models;
using ServerASP.Services.Interfaces;

namespace ServerASP.Services
{
    public class PositionService : IPositionService
    {
        private UnitOfWork unitOfWork;

        public PositionService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Position> GetAllPositions() => unitOfWork.PositionRepository.GetAllPositions();
    }
}
