
using BusinessLogicLevel.Models;

namespace BusinessLogicLevel.Interfaces
{
    public interface IEmployeeManager
    {
        public Task<List<EmployeeModel>> GetEmployees();
        public Task AddEmployee(EmployeeModel employee);
    }
}
