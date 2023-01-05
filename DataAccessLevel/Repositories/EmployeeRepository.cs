using DataAccessLevel.Interfaces;
using DataAccessLevel.Models;

namespace DataAccessLevel.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EfCoreDbContext GetContext()
        {
            return new EfCoreDbContext();
        }
        public async Task AddAsync(EmployeeModel employee)
        {
            using (var context = GetContext())
            {
                context.Employees.Add(employee);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(EmployeeModel employee)
        {
            using (var context = GetContext())
            {
                context.Employees.Remove(employee);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<EmployeeModel>> GetAllAsync()
        {
            using (var context = GetContext())
            {
                return context.Employees.ToList();
            }
        }

        public async Task UpdateAsync(EmployeeModel employee)
        {
            using (var context = GetContext())
            {
                var employeeOld = context.Employees.First(x => x.Id == employee.Id);
                employeeOld.FreeHours = employee.FreeHours;
                employeeOld.Name = employee.Name;
                await context.SaveChangesAsync();
            }
        }
    }
}
