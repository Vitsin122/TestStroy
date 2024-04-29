using Microsoft.EntityFrameworkCore;
using ServerASP.Data.DBContext;
using ServerASP.Data.Interfaces;
using ServerASP.Data.UOF;
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

        public void DeleteEmployee(Employer employer)
        {
            var Employer = context.Employee.Find(employer.Id);

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

        public IEnumerable<Employer> SelectAll() => context.Employee.Include(p=>p.Position).ToList();

        public Employer SelectEmployee(Employer employer) => context.Employee.Include(p => p.Position).
                                                                Where(tempEmployer => tempEmployer.Firstname == employer.Firstname &&
                                                                                      tempEmployer.Surname == employer.Surname &&
                                                                                      tempEmployer.Position.PositionName == employer.Position.PositionName)!.First();

        public Employer SelectEmployeeById(int employerId)
        {
            return context.Employee.Find(employerId);
        }
        public void UpdateEmployee(Employer employer)
        {
            context.Entry(employer).State = EntityState.Modified;
        }
    }
}
