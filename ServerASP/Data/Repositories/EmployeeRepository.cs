using Microsoft.EntityFrameworkCore;
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

        public void DeleteEmployee(Employer employer)
        {
            Employer? currentEmployer = context.Employee.Include(p => p.Position).
                                        Where(tempEmployer => tempEmployer.Firstname == employer.Firstname && 
                                                              tempEmployer.Surname == employer.Surname &&
                                                              tempEmployer!.Position!.PositionName == employer!.Position!.PositionName)?.FirstOrDefault();

            if (currentEmployer != null)
                context.Employee.Remove(currentEmployer);
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

        public Employer? SelectEmployee(Employer employer) => context.Employee.Include(p => p.Position).
                                                                Where(tempEmployer => tempEmployer.Firstname == employer.Firstname &&
                                                                                      tempEmployer.Surname == employer.Surname &&
                                                                                      tempEmployer!.Position!.PositionName == employer!.Position!.PositionName)?.FirstOrDefault();
        public void UpdateEmployee(Employer employer)
        {
            
        }
    }
}
