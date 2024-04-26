using ServerASP.Models;

namespace ServerASP.Data.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employer> GetAllEmployee();
    }
}
