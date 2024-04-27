using ServerASP.Data.Interfaces;

namespace ServerASP.Data.UOF
{
    public class UnitOfWork
    {
        public IEmployeeRepository EmployeeRepository { get; set; }
        public IPositionRepository PositionRepository { get; set; }

        public UnitOfWork(IEmployeeRepository employeeRepository, IPositionRepository positionRepository)
        {
            EmployeeRepository = employeeRepository;
            PositionRepository = positionRepository;
        }
    }
}
