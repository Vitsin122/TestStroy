using ServerASP.Data.DBContext;
using ServerASP.Data.Interfaces;
using ServerASP.Models;

namespace ServerASP.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmployeeDBContext context;

        public EmployeeRepository(EmployeeDBContext context)
        {
            this.context = context;
        }

        public void DeleteEmployee(int id)
        {
            Employer? employer = context.Employee.Find(id);

            if (employer != null)
                context.Employee.Remove(employer);
        }

        public void InsertEmployee(Employer employer)
        {
            context.Employee.Add(employer);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public IEnumerable<Employer> SelectAll() => context.Employee.ToList();

        public Employer? SelectById(int id) => context.Employee.Find(id);

        public void UpdateEmployee(Employer employer)
        {
            Employer? currentEmployer = context.Employee.Find(employer.Id);

            if (currentEmployer != null)
            {
                currentEmployer.Firstname = employer.Firstname;
                currentEmployer.Lastname = employer.Lastname;
                currentEmployer.Surname = employer.Surname;
                currentEmployer.Birthday = employer.Birthday;
                currentEmployer.Salary = employer.Salary;
                currentEmployer.isActive = employer.isActive;
                currentEmployer.PositionId = employer.PositionId;
                context.Employee.Update(currentEmployer);
            }
        }
    }
}
