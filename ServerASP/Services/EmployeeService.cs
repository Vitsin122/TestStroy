using System.Transactions;
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

            employer.Position = currentEmployerPosition;
            employer.PositionId = currentEmployerPosition.Id;

            unitOfWork.EmployeeRepository.InsertEmployee(employer);

            unitOfWork.EmployeeRepository.Save();
        }

        public void DeleteEmployee(Employer employer)
        {
            unitOfWork.EmployeeRepository.DeleteEmployee(employer);

            unitOfWork.EmployeeRepository.Save();
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
            Employer currentEmployer = unitOfWork.EmployeeRepository.SelectEmployeeById(employer.Id);

            currentEmployer.Firstname = employer.Firstname;
            currentEmployer.Surname = employer.Surname;
            currentEmployer.Lastname = employer.Lastname;
            currentEmployer.Birthday = employer.Birthday;
            currentEmployer.Salary = employer.Salary;
            currentEmployer.isActive = employer.isActive;

            Position currentPosition = unitOfWork.PositionRepository.GetAllPositions().Where(p => p.PositionName == employer.Position.PositionName)!.First();

            currentEmployer.PositionId = currentPosition.Id;
            currentEmployer.Position = currentPosition;

            unitOfWork.EmployeeRepository.UpdateEmployee(currentEmployer);

            unitOfWork.EmployeeRepository.Save();
        }
    }
}
