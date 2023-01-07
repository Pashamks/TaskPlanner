using DataAccessLevel.Models;

namespace DataAccessLevel.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeEntity>> GetAllAsync();
        Task AddAsync(EmployeeEntity employee);
        Task UpdateAsync(EmployeeEntity employee);
        Task DeleteAsync(EmployeeEntity employee);
    }
}
