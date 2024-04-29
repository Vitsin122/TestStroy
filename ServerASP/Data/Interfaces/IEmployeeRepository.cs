using ServerASP.Models;

namespace ServerASP.Data.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employer> SelectAll();
        Employer SelectEmployee(Employer employer);
        Employer SelectEmployeeById(int employerId);
        void InsertEmployee(Employer employer);
        void UpdateEmployee(Employer employer);
        void DeleteEmployee(Employer employer);
        void Save();
    }
}
