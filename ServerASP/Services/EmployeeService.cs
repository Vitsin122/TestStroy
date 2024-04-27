using ServerASP.Models;
using ServerASP.Services.Interfaces;
using ServerASP.Data.UOF;

namespace ServerASP.Services
{
    public class EmployeeService : IEmployeeService
    {
        private UnitOfWork unitOfWork;

        public EmployeeService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddEmployee(Employer employer)
        {
            Position currentEmployerPosition =
                unitOfWork.PositionRepository.GetAllPositions()
                    .Where(position => position.PositionName == employer.Position.PositionName)!.FirstOrDefault();

            employer.Position!.Id = currentEmployerPosition!.Id;
            employer.PositionId = currentEmployerPosition.Id;

            unitOfWork.EmployeeRepository.InsertEmployee(employer);
        }

        public void DeleteEmployee(Employer employer)
        {
            unitOfWork.EmployeeRepository.DeleteEmployee(employer);
        }

        public IEnumerable<Employer> GetAllEmployee()
        {
            return unitOfWork.EmployeeRepository.SelectAll();
        }

        public Employer GetEmployee(Employer employer)
        {
            return unitOfWork.EmployeeRepository.SelectEmployee(employer)!;
        }

        public void UpdateEmployee(Employer employer)
        {
            
        }
    }
}
