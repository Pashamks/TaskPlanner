using DataAccessLevel.Models;

namespace DataAccessLevel.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeModel>> GetAllAsync();
        Task AddAsync(EmployeeModel employee);
        Task UpdateAsync(EmployeeModel employee);
        Task DeleteAsync(EmployeeModel employee);
    }
}
