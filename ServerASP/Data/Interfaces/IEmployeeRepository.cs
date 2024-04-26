using ServerASP.Models;

namespace ServerASP.Data.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employer> SelectAll();
        Employer? SelectById(int id);
        void InsertEmployee(Employer employer);
        void UpdateEmployee(Employer employer);
        void DeleteEmployee(int id);
        void Save();
    }
}
