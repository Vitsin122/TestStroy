using ServerASP.Models;

namespace ServerASP.Services.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employer> GetAllEmployee();
        Employer GetEmployeeById(int employeeId);
        void AddEmployee(Employer employer);
        void UpdateEmployee(Employer employer);
        void DeleteEmployee(Employer employer);
    }
}
